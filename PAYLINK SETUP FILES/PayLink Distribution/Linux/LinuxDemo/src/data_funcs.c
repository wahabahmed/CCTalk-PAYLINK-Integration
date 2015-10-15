/*--------------------------------------------------------------------------*\
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
\*--------------------------------------------------------------------------*/

/*--------------------------------------------------------------------------*\
 * System Includes.
\*--------------------------------------------------------------------------*/
#include <stdio.h>
#include <stdlib.h>
#include <signal.h>
#include <string.h>
#include <sys/types.h>

/*--------------------------------------------------------------------------*\
 * AES Includes.
\*--------------------------------------------------------------------------*/
#include "Aesimhei.h"
#include "ImheiEvent.h"

/*--------------------------------------------------------------------------*\
 * GTK Includes.
\*--------------------------------------------------------------------------*/
#include <gtk/gtk.h>
#include <gnome.h>

/*--------------------------------------------------------------------------*\
 * Application Includes.
\*--------------------------------------------------------------------------*/
#include "interface.h"
#include "support.h"
#include "data_funcs.h"

/*--------------------------------------------------------------------------*\
 * External Variables.
\*--------------------------------------------------------------------------*/
extern GtkWidget *WinMain;
extern GtkWidget *WinPayout;
extern GtkWidget *WinAcceptors;
extern GtkWidget *WinLeds;
extern GtkWidget *WinDispensers;
extern gint       TimerTag;
extern int        OpenError;
extern double     TotalAmountRead;
extern double     StartTotalAmountRead;

/*--------------------------------------------------------------------------*\
 * Private Global Variables.
\*--------------------------------------------------------------------------*/
static GtkWidget      *ErrDialog    = NULL;
static GtkWidget      *ErrConDialog = NULL;
static AcceptorBlock   Acceptor;
static DispenserBlock  Dispenser;
static int             AcceptorIndex      = -1;
static int             PaidAtStart        =  0;
static gint            AcceptorTimerTag   = -1;
static gint            AcceptorStopTimer  =  0;
static gint            LedsTimerTag       = -1;
static gint            LedsStopTimer      =  0;
static gint            PayoutTimerTag     = -1;
static gint            PayoutStopTimer    =  0;
static long            ReqPayout          =  0;
static gint            DispenserTimerTag  = -1;
static gint            DispenserStopTimer =  0;


/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
int
DataFn_UpdateData                         (gpointer      data)
{
  GtkWidget *txt_amount_read      = lookup_widget(GTK_WIDGET(WinMain), "txtAmountRead");
  GtkWidget *txt_amount_just_read = lookup_widget(GTK_WIDGET(WinMain), "txtAmountJustRead");
  GtkWidget *txt_total_payout     = lookup_widget(GTK_WIDGET(WinMain), "txtAmountPaidOut");
  GtkWidget *lbl_status           = lookup_widget(GTK_WIDGET(WinMain), "lblStatus");
  GtkWidget *cmb_event            = lookup_widget(GTK_WIDGET(WinMain), "cmbEvent");

  double     amount_read          = 0;
  double     amount_paid          = 0;
  gchar      buff [ 256 ]         = "";
  char      *err_msg              = NULL;
  long       event                = 0;
  int        status               = 0;

  EventDetailBlock   event_details;
  static int first = 1;

  /*-- Determine if we have access to the device ----------------------*/
  if (OpenError == 1)
  { GtkWidget *errDialog = gtk_message_dialog_new (GTK_WINDOW(WinMain),
                              GTK_DIALOG_DESTROY_WITH_PARENT,
                              GTK_MESSAGE_ERROR,
                              GTK_BUTTONS_CLOSE,
                              "Erorr opening PayLink device !\n");
    gtk_window_set_position (GTK_WINDOW(errDialog),GTK_WIN_POS_CENTER_ALWAYS);

    gtk_window_set_title (GTK_WINDOW(errDialog),
                              "Aardvark Embedded Solutions");
    gtk_window_set_icon_from_file (GTK_WINDOW(errDialog),
                              "../pixmaps/AESDemo-icon.png", NULL);
    gtk_dialog_run (GTK_DIALOG (errDialog));
    gtk_widget_destroy (errDialog);
    exit (EXIT_FAILURE);
  }

  if (first)
  { /*-- Show the main application window -----------------------------*/
    first = 0;
    gtk_widget_show (WinMain);

    /*-- Enable the AES interface -------------------------------------*/
    EnableInterface() ;

    /*-- Determine total amount read ----------------------------------*/
    txt_amount_read = lookup_widget(GTK_WIDGET(WinMain), "txtAmountRead");
    TotalAmountRead = StartTotalAmountRead = ((double)CurrentValue () / 100.0);
    sprintf(buff, "%02.02f", TotalAmountRead);
    gtk_entry_set_text (GTK_ENTRY(txt_amount_read), buff);
  }

  /*-- Determine if there has been an error ---------------------------*/
  err_msg = IMHEIConsistencyError(STANDARD_COIN_TIME, STANDARD_NOTE_TIME);
  if (err_msg && *err_msg)
  { ErrConDialog = gtk_message_dialog_new (GTK_WINDOW(WinMain),
                              GTK_DIALOG_DESTROY_WITH_PARENT,
                              GTK_MESSAGE_ERROR,
                              GTK_BUTTONS_CLOSE,
                              "Error Detected:\n%s",
                              err_msg);
    gtk_window_set_title (GTK_WINDOW(ErrConDialog),
                              "Aardvark Embedded Solutions");
    gtk_window_set_icon_from_file (GTK_WINDOW(ErrConDialog),
                              "../pixmaps/AESDemo-icon.png", NULL);
    gtk_dialog_run (GTK_DIALOG (ErrConDialog));
    gtk_widget_destroy (ErrConDialog);
  }

  /*-- Determine Driver Status ----------------------------------------*/
  switch ((status = USBDriverStatus()))
  { case NOT_USB:           strcpy (buff, "");                       break;
    case USB_IDLE:          strcpy (buff, "Driver: Not loaded");     break;
    case STANDARD_DRIVER:   strcpy (buff, "Driver: OK");             break;
    case FLASH_LOADER:      strcpy (buff, "Flash reprogramming");    break;
    case MANUFACTURING_TEST:strcpy (buff, "Manufacturing Test");     break;
    case DRIVER_RESTART:    strcpy (buff, "Driver: Restarting");     break;
    case USB_ERROR:         strcpy (buff, "Driver: USB Error");      break;
    default:                strcpy (buff, "Driver: Unknown Status"); break;
  }
  gtk_label_set_label (GTK_LABEL(lbl_status), buff);
  if (status != STANDARD_DRIVER)
  {
    /*-- Clear data values --------------------------------------------*/
    gtk_entry_set_text (GTK_ENTRY(txt_amount_just_read), "0.00");
    gtk_entry_set_text (GTK_ENTRY(txt_amount_read),      "0.00");
    return TRUE;
  }

  /*-- Determine total amount read  -----------------------------------*/
  if ((amount_read = ((double)CurrentValue () / 100.0)))
  {
    /*-- Determine if this value has changed --------------------------*/
    if (amount_read != TotalAmountRead)
    { TotalAmountRead = amount_read;
      amount_read     = TotalAmountRead - StartTotalAmountRead;

      /*-- Update amount just read widget -----------------------------*/
      if (amount_read < 0)
        strcpy(buff, "0.00");
      else
        sprintf(buff, "%02.02f", amount_read);
      gtk_entry_set_text (GTK_ENTRY(txt_amount_just_read), buff);

      /*-- Update total amount read widget ----------------------------*/
      sprintf(buff, "%02.02f", TotalAmountRead);
      gtk_entry_set_text (GTK_ENTRY(txt_amount_read), buff);
    }
  }

  /*-- Determine total amount paid out --------------------------------*/
  if ((amount_paid = ((double)CurrentPaid () / 100.0)))
  { /*-- Update total amount read widget ------------------------------*/
    if (amount_paid < 0)
      strcpy(buff, "0.00");
    else
      sprintf(buff, "%02.02f", amount_paid);
    gtk_entry_set_text (GTK_ENTRY(txt_total_payout), buff);
  }

  /*-- Update events --------------------------------------------------*/
  event = NextEvent(&event_details);
  if (event)
  { char *event_txt = DataFn_EventDecode(event);
    char  latest_txt[256];

    if (event >= COIN_DISPENSER_EVENT)
    { if (event_details.DispenserEvent == 0)
      { sprintf(latest_txt, "%-35.35s | Raw Code: %2lX  Acc:%ld", event_txt,
                               event_details.RawEvent, event_details.Index);
      }else
      { sprintf(latest_txt, "%-35.35s | Raw Code: %2lX Disp:%ld", event_txt,
                               event_details.RawEvent, event_details.Index) ;
      }
    }else
      sprintf(latest_txt, "%s", event_txt);

    gtk_combo_box_prepend_text (GTK_COMBO_BOX(cmb_event), latest_txt);
    gtk_combo_box_set_active   (GTK_COMBO_BOX(cmb_event), 0);
  }
  return TRUE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void*
DataFn_RetryOpen                        (gint            reply,
                                         gpointer        data)
{
  /*-- User did not wish to retry opening device (exit) ---------------*/
  if (reply == 1)
    gtk_main_quit ();

  /*-- Retry opening device -------------------------------------------*/
  ErrDialog = NULL;
  return NULL;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
int
DataFn_Reset                            (void)
{
  GtkWidget *txt_amount_just_read = lookup_widget(GTK_WIDGET(WinMain), "txtAmountJustRead");
  double     amount_read          = 0;

  if ((amount_read = ((double)CurrentValue () / 100.0)))
  { gtk_entry_set_text (GTK_ENTRY(txt_amount_just_read), "0.00");
    StartTotalAmountRead = TotalAmountRead = amount_read;
  }
  return TRUE;
}


/****************************************************************************\
 ****************************************************************************
                          Acceptor Data Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
int
DataFn_AcceptorUpdateData                 (gpointer      data)
{
  GtkWidget *lbl_acpt_status   = lookup_widget(GTK_WIDGET(WinAcceptors), "lbl_acpt_status");
  GtkWidget *txt_acpt_cnt      = NULL;
  GtkWidget *txt_acpt_no_spth  = NULL;
  GtkWidget *txt_acpt_no_esc   = NULL;
  char       buff [256];
  int        i;

  /*-- Determine if we are required to perform the update ------------*/
  if (AcceptorStopTimer) return FALSE;

  /*-- Ensure Acceptor index has been set correctly -------------------*/
  if  (AcceptorIndex < 0)
    return TRUE;

  /*-- Attempt to read acceptor details -------------------------------*/
  if (!ReadAcceptorDetails(AcceptorIndex, &Acceptor))
  { DataFn_SetupAcceptors();
    return TRUE;
  }

  /*-- Determine acceptor status --------------------------------------*/
  switch (Acceptor.Status)
  { case 0                : strcpy(buff, "OK");                   break;
    case ACCEPTOR_DEAD    : strcpy(buff, "Dead");                 break;
//  case ACCEPTOR_ALL_DEAD: strcpy(buff, "All Dead");             break;
    case ACCEPTOR_DISABLED: strcpy(buff, "Disabled");             break;
//  case ACCEPTOR_FRAUD   : strcpy(buff, "Fraud");                break;
    case ACCEPTOR_BUSY    : strcpy(buff, "Busy");                 break;
    case ACCEPTOR_FAULT   : strcpy(buff, "Fault");                break;
    default               : sprintf(buff, "0x%08lX", Acceptor.Status); break;
  }
  gtk_label_set_text (GTK_LABEL(lbl_acpt_status), buff);

  for (i=0; i<16; i++)
  { sprintf(buff ,"txt_acpt_cnt_%02d",      i+1);
    txt_acpt_cnt      = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_no_spth_%02d",  i+1);
    txt_acpt_no_spth  = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_no_esc_%02d",   i+1);
    txt_acpt_no_esc   = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);


    if (i < Acceptor.NoOfCoins-1)
    { sprintf(buff, "%ld", Acceptor.Coin[i].Count);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_cnt), buff);
      sprintf(buff, "%ld", Acceptor.Coin[i].PathCount);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_no_spth), buff);
      sprintf(buff, "%d", Acceptor.Coin[i].HeldInEscrow);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_no_esc), buff);
    }
  }
  return TRUE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StartAcceptorTimer                 (void)
{
  AcceptorTimerTag  = g_timeout_add ( (guint) 500, DataFn_AcceptorUpdateData, NULL );
  AcceptorStopTimer = 0;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StopAcceptorTimer                  (void)
{
  AcceptorStopTimer = 1;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_WriteToAcceptor                    (void)
{
  GtkWidget *tgl_acpt_bchupdts = lookup_widget(GTK_WIDGET(WinAcceptors), "tgl_acpt_bchupdts");
  gboolean   state;

  state = gtk_toggle_button_get_active (GTK_TOGGLE_BUTTON(tgl_acpt_bchupdts));
  if ((state == FALSE) && (AcceptorIndex >= 0))
    WriteAcceptorDetails(AcceptorIndex, &Acceptor);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_WriteAllToAcceptor                 (void)
{
  WriteAcceptorDetails(AcceptorIndex, &Acceptor);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_SetInhibitState                    (GtkToggleButton *togglebutton,
                                           int              index)
{
  gboolean state = gtk_toggle_button_get_active (GTK_TOGGLE_BUTTON(togglebutton));
  Acceptor.Coin[index].Inhibit = (int)state;
  DataFn_WriteToAcceptor();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_ChangeAcceptorStatus               (GtkToggleButton *togglebutton)
{
  gboolean state = gtk_toggle_button_get_active (GTK_TOGGLE_BUTTON(togglebutton));
  if (state == TRUE)
      Acceptor.Status |= ACCEPTOR_INHIBIT;
  else
      Acceptor.Status &= ~ACCEPTOR_INHIBIT;
  WriteAcceptorDetails(AcceptorIndex, &Acceptor);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_UpdateAcceptor                     (void)
{
  const gchar *val               = NULL;
  GtkWidget   *txt_acpt_rpth     = NULL;
  GtkWidget   *txt_acpt_dpth     = NULL;
  GtkWidget   *txt_acpt_lvl_swth = NULL;
  GtkWidget   *txt_def_path      = lookup_widget (GTK_WIDGET(WinAcceptors), "txt_acpt_dflt_path");
  char         buff [256];
  int          i;

  /*-- Update the acceptor default path ------------------------------*/
  if ((val = gtk_entry_get_text (GTK_ENTRY(txt_def_path))))
    Acceptor.DefaultPath = strtol(val, NULL, 10);

  /*-- Update remainder of acceptor data -----------------------------*/
  for (i=0; i<16; i++)
  { /*-- Build widget names ------------------------------------------*/
    sprintf(buff ,"txt_acpt_rpth_%02d",     i+1);
    txt_acpt_rpth     = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_dpth_%02d",     i+1);
    txt_acpt_dpth     = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_lvl_swth_%02d", i+1);
    txt_acpt_lvl_swth = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);

    /*-- Read values and update if required --------------------------*/
    if (i < Acceptor.NoOfCoins-1)
    { if ((val = gtk_entry_get_text (GTK_ENTRY(txt_acpt_rpth))))
        Acceptor.Coin[i].Path = strtol(val, NULL, 10);
      if ((val = gtk_entry_get_text (GTK_ENTRY(txt_acpt_dpth))))
        Acceptor.Coin[i].DefaultPath = strtol(val, NULL, 10);
      if ((val = gtk_entry_get_text (GTK_ENTRY(txt_acpt_lvl_swth))))
        Acceptor.Coin[i].PathSwitchLevel = strtol(val, NULL, 10);
    }
  }
  DataFn_WriteToAcceptor();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_SetupAcceptors                     (void)
{
  GtkWidget    *cmb_acpt = lookup_widget  (GTK_WIDGET(WinAcceptors), "cmb_acpt_acceptors");
  char          buff        [256];
  char          acceptorName[256];
  int           serial = 0;
  static int first = 0;

  /*-- Determine what acceptors are available ------------------------*/
  for (serial=0; !first && ReadAcceptorDetails(serial, &Acceptor); serial++)
  { switch (Acceptor.Unit)
    { case DP_AST_GBA:
        strcpy (acceptorName, "AstroSystems GBA");                break;
      case DP_AZK_MDB:
        strcpy (acceptorName, "Azkoyen MDB Changer");             break;
      case DP_COINCO_BILLPRO:
        strcpy (acceptorName, "CoinCo BillPro");                  break;
      case DP_COINCO_GLOBAL:
        strcpy (acceptorName, "CoinCo Global");                   break;
      case DP_COINCO_MDB:
        strcpy (acceptorName, "CoinCo MDB Changer");              break;
      case DP_COINCO_MDB_BILL:
        strcpy (acceptorName, "CoinCo MDB Bill");                 break;
      case DP_COINCO_VORTEX:
        strcpy (acceptorName, "CoinCo Vortex");                   break;
      case DP_GPT_NOTE:
        strcpy (acceptorName, "GPT Argus");                       break;
      case DP_ICT_U85:
        strcpy (acceptorName, "ICT U85");                         break;
      case DP_ID003_NOTE:
        strcpy (acceptorName, "ID-003 Note");                     break;
      case DP_INNOV_NV10:
        strcpy (acceptorName, "Innovative NV10");                 break;
      case DP_INNOV_NV4:
        strcpy (acceptorName, "Innovative NV4");                  break;
      case DP_INNOV_NV7:
        strcpy (acceptorName, "Innovative NV7");                  break;
      case DP_INNOV_NV8:
        strcpy (acceptorName, "Innovative NV8");                  break;
      case DP_INNOV_NV9:
        strcpy (acceptorName, "Innovative NV9");                  break;
      case DP_JCM_CC_EBA:
        strcpy (acceptorName, "JCM EBA on cctalk");               break;
      case DP_JCM_CC_WBA:
        strcpy (acceptorName, "JCM WBA on cctalk");               break;
      case DP_JCM_NOTE:
        strcpy (acceptorName, "JCM Note");                        break;
      case DP_MARS_CASHFLOW_126:
        strcpy (acceptorName, "Mars Cashflow 126");               break;
      case DP_MARS_CASHFLOW_690:
        strcpy (acceptorName, "Mars Cashflow 690");               break;
      case DP_MARS_CASHFLOW_9500:
        strcpy (acceptorName, "Mars Cashflow 9500");              break;
      case DP_MARS_MDB:
        strcpy (acceptorName, "Mars MDB Changer");                break;
      case DP_MCL_7200:
        strcpy (acceptorName, "MCL 7200");                        break;
      case DP_MCL_ARDAC:
        strcpy (acceptorName, "MCL Ardac /ID-003");               break;
      case DP_MCL_CONDOR:
        strcpy (acceptorName, "MCL Condor");                      break;
      case DP_MCL_LUMINA:
        strcpy (acceptorName, "MCL Lumina");                      break;
      case DP_MCL_SR3:
        strcpy (acceptorName, "MCL SR3");                         break;
      case DP_MCL_SR5:
        strcpy (acceptorName, "MCL SR5");                         break;
      case DP_MCL_WACS:
        strcpy (acceptorName, "MCL Ardac / WACS");                break;
      case DP_MDB_BILL:
        strcpy (acceptorName, "MBD Bill");                        break;
      case DP_MDB_LEVEL_2:
        strcpy (acceptorName, "MDB Level 2 Changer");             break;
      case DP_MDB_LEVEL_3:
        strcpy (acceptorName, "MDB Level 3 Changer");             break;
      case DP_NRI_G40:
        strcpy (acceptorName, "NRI G40");                         break;
      case DP_HII_INTERFACE   | DP_COIN_ACCEPT_DEVICE:
        strcpy (acceptorName, "Hi2 Coin");                        break;
      case DP_CCTALK_INTERFACE | DP_COIN_ACCEPT_DEVICE:
        strcpy (acceptorName, "ccTalk Coin");                     break;
      case DP_CCTALK_INTERFACE | DP_NOTE_ACCEPT_DEVICE:
        strcpy (acceptorName, "ccTalk Note");                     break;
      default:
        strcpy (acceptorName, "Unknown");                         break;
    }

    /*-- Add this acceptor to combo box display ----------------------*/
    sprintf (buff, "%d: %s", serial+1, acceptorName);
    gtk_combo_box_append_text (GTK_COMBO_BOX(cmb_acpt), buff);
  }

  /*-- Ensure acceptors were detected --------------------------------*/
  if (!serial && !first)
  { gtk_combo_box_append_text (GTK_COMBO_BOX(cmb_acpt), "No acceptors");
    gtk_combo_box_set_active  (GTK_COMBO_BOX(cmb_acpt), 0);
  }

  /*-- Show the Acceptors window -------------------------------------*/
  if (WinAcceptors != NULL)
    gtk_widget_show_all(GTK_WIDGET(WinAcceptors));

  /*-- Set the first entry to be active ------------------------------*/
  gtk_combo_box_set_active  (GTK_COMBO_BOX(cmb_acpt), 0);
  first = 1;
  return;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_AcceptorChanged                    (void)
{
  GtkWidget *cmb_acpt          = lookup_widget (GTK_WIDGET(WinAcceptors), "cmb_acpt_acceptors");
  GtkWidget *txt_interface     = lookup_widget (GTK_WIDGET(WinAcceptors), "txt_acpt_interface");
  GtkWidget *txt_unit_addr     = lookup_widget (GTK_WIDGET(WinAcceptors), "txt_acpt_unit_addr");
  GtkWidget *txt_def_path      = lookup_widget (GTK_WIDGET(WinAcceptors), "txt_acpt_dflt_path");
  GtkWidget *txt_currency      = lookup_widget (GTK_WIDGET(WinAcceptors), "txt_acpt_currency");
  GtkWidget *txt_types         = lookup_widget (GTK_WIDGET(WinAcceptors), "txt_acpt_type_hndld");
  GtkWidget *lbl_acpt_status   = lookup_widget (GTK_WIDGET(WinAcceptors), "lbl_acpt_status");
  GtkWidget *chk_acpt_disable  = lookup_widget (GTK_WIDGET(WinAcceptors), "chk_acpt_disable");
  GtkWidget *txt_acpt_val      = NULL;
  GtkWidget *txt_acpt_cnt      = NULL;
  GtkWidget *txt_acpt_rpth     = NULL;
  GtkWidget *txt_acpt_dpth     = NULL;
  GtkWidget *txt_acpt_no_spth  = NULL;
  GtkWidget *txt_acpt_lvl_swth = NULL;
  GtkWidget *txt_acpt_no_esc   = NULL;
  GtkWidget *chk_acpt_inhib    = NULL;
  char       buff [256];
  int        i;
  long       no_coins;

  /*-- Determine the currently selected entry ------------------------*/
  AcceptorIndex = gtk_combo_box_get_active(GTK_COMBO_BOX(cmb_acpt));

  /*-- Read acceptor details for the required device -----------------*/
  if (!ReadAcceptorDetails(AcceptorIndex, &Acceptor))
    return;

  /*-- Start to fill in the interface --------------------------------*/
  sprintf(buff, "%ld", Acceptor.InterfaceNumber);
  gtk_entry_set_text (GTK_ENTRY(txt_interface), buff);
  sprintf(buff, "%ld", Acceptor.UnitAddress);
  gtk_entry_set_text (GTK_ENTRY(txt_unit_addr), buff);
  sprintf(buff, "%ld", Acceptor.DefaultPath);
  gtk_entry_set_text (GTK_ENTRY(txt_def_path), buff);
  sprintf(buff, "%ld", Acceptor.NoOfCoins);
  gtk_entry_set_text (GTK_ENTRY(txt_types), buff);
  gtk_entry_set_text (GTK_ENTRY(txt_currency), Acceptor.Currency);
  no_coins = Acceptor.NoOfCoins;

  for (i=0; i<16; i++)
  { sprintf(buff ,"txt_acpt_val_%02d",      i+1);
    txt_acpt_val      = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_cnt_%02d",      i+1);
    txt_acpt_cnt      = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_rpth_%02d",     i+1);
    txt_acpt_rpth     = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_dpth_%02d",     i+1);
    txt_acpt_dpth     = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_no_spth_%02d",  i+1);
    txt_acpt_no_spth  = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_lvl_swth_%02d", i+1);
    txt_acpt_lvl_swth = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"txt_acpt_no_esc_%02d",   i+1);
    txt_acpt_no_esc   = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);
    sprintf(buff ,"chk_acpt_inhib_%02d",    i+1);
    chk_acpt_inhib    = lookup_widget  (GTK_WIDGET(WinAcceptors), buff);

    if (i < Acceptor.NoOfCoins-1)
    { gtk_widget_show(GTK_WIDGET(txt_acpt_val));
      gtk_widget_show(GTK_WIDGET(txt_acpt_cnt));
      gtk_widget_show(GTK_WIDGET(txt_acpt_rpth));
      gtk_widget_show(GTK_WIDGET(txt_acpt_dpth));
      gtk_widget_show(GTK_WIDGET(txt_acpt_no_spth));
      gtk_widget_show(GTK_WIDGET(txt_acpt_lvl_swth));
      gtk_widget_show(GTK_WIDGET(txt_acpt_no_esc));
      gtk_widget_show(GTK_WIDGET(chk_acpt_inhib));

      sprintf(buff, "%ld", Acceptor.Coin[i].Value);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_val), buff);
      sprintf(buff, "%ld", Acceptor.Coin[i].Count);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_cnt), buff);
      sprintf(buff, "%ld", Acceptor.Coin[i].Path);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_rpth), buff);
      sprintf(buff, "%d", Acceptor.Coin[i].DefaultPath);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_dpth), buff);
      sprintf(buff, "%ld", Acceptor.Coin[i].PathCount);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_no_spth), buff);
      sprintf(buff, "%d", Acceptor.Coin[i].HeldInEscrow);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_no_esc), buff);
      sprintf(buff, "%ld", Acceptor.Coin[i].PathSwitchLevel);
      gtk_entry_set_text (GTK_ENTRY(txt_acpt_lvl_swth), buff);

      if (Acceptor.Coin[i].Inhibit == 0)
         gtk_toggle_button_set_active(GTK_TOGGLE_BUTTON(chk_acpt_inhib), FALSE);
      else
         gtk_toggle_button_set_active(GTK_TOGGLE_BUTTON(chk_acpt_inhib), TRUE);

    }else
    { gtk_widget_hide(GTK_WIDGET(txt_acpt_val));
      gtk_widget_hide(GTK_WIDGET(txt_acpt_cnt));
      gtk_widget_hide(GTK_WIDGET(txt_acpt_rpth));
      gtk_widget_hide(GTK_WIDGET(txt_acpt_dpth));
      gtk_widget_hide(GTK_WIDGET(txt_acpt_no_spth));
      gtk_widget_hide(GTK_WIDGET(txt_acpt_lvl_swth));
      gtk_widget_hide(GTK_WIDGET(txt_acpt_no_esc));
      gtk_widget_hide(GTK_WIDGET(chk_acpt_inhib));
    }
  }

  /*-- Determine acceptor status --------------------------------------*/
  switch (Acceptor.Status)
  { case 0                : strcpy(buff, "OK");                   break;
    case ACCEPTOR_DEAD    : strcpy(buff, "Dead");                 break;
//  case ACCEPTOR_ALL_DEAD: strcpy(buff, "All Dead");             break;
    case ACCEPTOR_DISABLED:
      strcpy(buff, "Disabled");
      gtk_toggle_button_set_active(GTK_TOGGLE_BUTTON(chk_acpt_disable), TRUE);
      break;
//  case ACCEPTOR_FRAUD   : strcpy(buff, "Fraud");                break;
    case ACCEPTOR_BUSY    : strcpy(buff, "Busy");                 break;
    case ACCEPTOR_FAULT   : strcpy(buff, "Fault");                break;
    default               : sprintf(buff, "0x%08lX", Acceptor.Status); break;
  }
  gtk_label_set_text (GTK_LABEL(lbl_acpt_status), buff);
  return;
}


/****************************************************************************\
 ****************************************************************************
                       Switches / LEDs Data Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StartLedsTimer                     (void)
{
  LedsTimerTag = g_timeout_add ( (guint) 500, DataFn_LedsUpdateData, NULL );
  LedsStopTimer = 0;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StopLedsTimer                      (void)
{
  LedsStopTimer = 1;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
int
DataFn_LedsUpdateData                     (gpointer      data)
{
  GtkWidget   *img_leds   = NULL;
  char         buff [256];
  int          i;

   /*-- Determine if we are required to perform the update ------------*/
  if (LedsStopTimer) return FALSE;

  for (i=0; i<16; i++)
  { /*-- Build widget names ------------------------------------------*/
    sprintf(buff ,"img_leds_%02d",     i);
    img_leds = lookup_widget  (GTK_WIDGET(WinLeds), buff);

    if (SwitchCloses(i) != SwitchOpens(i))
    { /*-- Show switch as being on (green) ---------------------------*/
      gtk_image_set_from_stock (GTK_IMAGE(img_leds), "gtk-yes", GTK_ICON_SIZE_BUTTON);
    }else
    { /*-- Show switch as being off (red) ----------------------------*/
      gtk_image_set_from_stock (GTK_IMAGE(img_leds), "gtk-no", GTK_ICON_SIZE_BUTTON);
    }
  }
  return TRUE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_SetLedState                        (GtkToggleButton *togglebutton,
                                           int              index)
{
  gboolean state = gtk_toggle_button_get_active (GTK_TOGGLE_BUTTON(togglebutton));
  if (state == TRUE)
    IndicatorOn (index);
  else
    IndicatorOff(index);
}


/****************************************************************************\
 ****************************************************************************
                          Payout Data Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StartPayoutTimer                   (void)
{
  PayoutTimerTag = g_timeout_add ( (guint) 500, DataFn_PayoutUpdateData, NULL );
  PayoutStopTimer= 0;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StopPayoutTimer                    (void)
{
  PayoutStopTimer = 1;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
int
DataFn_PayOut                             (void)
{
  GtkWidget *txt_payout    = lookup_widget(GTK_WIDGET(WinMain),   "txtPayout");
  GtkWidget *btn_ok        = lookup_widget(GTK_WIDGET(WinPayout), "btn_pay_ok");
  GtkWidget *txt_requested = lookup_widget(GTK_WIDGET(WinPayout), "txt_pay_requested");
  GtkWidget *txt_paid      = lookup_widget(GTK_WIDGET(WinPayout), "txt_pay_paid");
  GtkWidget *txt_hopper    = lookup_widget(GTK_WIDGET(WinPayout), "txt_pay_hopper");
  gchar     *pay           = (gchar*)gtk_entry_get_text(GTK_ENTRY(txt_payout));

  /*-- Determine if data available (and greater than zero) ------------*/
  if ((!*pay) || (atoi(pay) <= 0))
  {
    /*-- Show error dialog inforing the user a value should be entered */
    GtkWidget *dia = gnome_warning_dialog_parented (
                                           "Please enter an amount to payout!",
                                           GTK_WINDOW(WinMain));

    gtk_window_set_title (GTK_WINDOW(dia), "Aardvark Embedded Solutions");
    gtk_window_set_icon_from_file (GTK_WINDOW(dia),
                              "../pixmaps/AESDemo-icon.png", NULL);
    gtk_window_set_modal          (GTK_WINDOW(dia), TRUE);
    gtk_window_set_position       (GTK_WINDOW(dia),GTK_WIN_POS_CENTER_ALWAYS);
    return FALSE;
  }

  /*-- Determine if decimal value has been entered --------------------*/
  if (strchr(pay, '.'))
    ReqPayout = (long)(strtod(pay, (char **)NULL)) * 100;
  else
    ReqPayout = (long) atoi(pay);

  if (ReqPayout)
  { /*-- Keep record of what has been paid ----------------------------*/
    PaidAtStart = CurrentPaid();

    /*-- Attempt to pay out the required amount -----------------------*/
    PayOut (ReqPayout);

    /*-- Show the PayOut window ---------------------------------------*/
    gtk_entry_set_text (GTK_ENTRY(txt_requested), "");
    gtk_entry_set_text (GTK_ENTRY(txt_paid),      "");
    gtk_entry_set_text (GTK_ENTRY(txt_hopper),    "");
    gtk_widget_set_sensitive (GTK_WIDGET(btn_ok), FALSE);
    gtk_window_set_position (GTK_WINDOW(WinPayout),GTK_WIN_POS_CENTER_ALWAYS);
    gtk_widget_show_all(GTK_WIDGET(WinPayout));
  }
  return TRUE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
int
DataFn_PayoutUpdateData                   (gpointer      data)
{
  GtkWidget *btn_ok        = lookup_widget(GTK_WIDGET(WinPayout), "btn_pay_ok");
  GtkWidget *txt_requested = lookup_widget(GTK_WIDGET(WinPayout), "txt_pay_requested");
  GtkWidget *txt_paid      = lookup_widget(GTK_WIDGET(WinPayout), "txt_pay_paid");
  GtkWidget *txt_hopper    = lookup_widget(GTK_WIDGET(WinPayout), "txt_pay_hopper");
  char buff[256];

  /*-- Determine if we are required to perform the update ------------*/
  if (PayoutStopTimer) return FALSE;

  /*-- Set required amount --------------------------------------------*/
  sprintf(buff,"%02.02f", (float)((float)ReqPayout / 100.0));
  gtk_entry_set_text (GTK_ENTRY(txt_requested), buff);

  /*-- Set amount currently paid --------------------------------------*/
  sprintf(buff,"%02.02f", (float)(CurrentPaid() - PaidAtStart) / 100.0);
  gtk_entry_set_text (GTK_ENTRY(txt_paid), buff);

  /*-- Determine current pay out status -------------------------------*/
  if (LastPayStatus() < 0)
  { switch (LastPayStatus())
    { case PAY_FINISHED      : strcpy(buff, "Idle OK");         break;
      case PAY_ONGOING       : strcpy(buff, "Paying");          break;
      case PAY_EMPTY         : strcpy(buff, "Empty");           break;
      case PAY_JAMMED        : strcpy(buff, "Jammed");          break;
      case PAY_US            : strcpy(buff, "U/S");             break;
      case PAY_FRAUD         : strcpy(buff, "Fraud Attempt");   break;
      case PAY_FAILED_BLOCKED: strcpy(buff, "Blocked");         break;
      case PAY_NO_HOPPER     : strcpy(buff, "No Dispenser");    break;
      case PAY_INHIBITED     : strcpy(buff, "Inhibited");       break;
      case PAY_SECURITY_FAIL : strcpy(buff, "Security Fail");   break;
      case PAY_HOPPER_RESET  : strcpy(buff, "Dispenser Reset"); break;
      case PAY_NOT_EXACT     : strcpy(buff, "No Exact Coin");   break;
      case PAY_GHOST         : strcpy(buff, "Ghost");           break;
      default                : sprintf(buff, "Error %d", LastPayStatus());
    }

    /*-- Enable the OK button -----------------------------------------*/
    gtk_widget_set_sensitive (GTK_WIDGET(btn_ok), TRUE);

    /*-- Stop the update timer ----------------------------------------*/
    DataFn_StopPayoutTimer();

  }else if (LastPayStatus() > 0)
  { strcpy(buff, "Finished");

    /*-- Enable the OK button -----------------------------------------*/
    gtk_widget_set_sensitive (GTK_WIDGET(btn_ok), TRUE);

  }else
    strcpy(buff, "Currently Paying");

  /*-- Set status text ------------------------------------------------*/
  gtk_entry_set_text (GTK_ENTRY(txt_hopper), buff);
  return TRUE;
}

/****************************************************************************\
 ****************************************************************************
                          Dispenser Data Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_SetupDispensers                    (void)
{
  GtkWidget *lbl_disp_type  = NULL;
  GtkWidget *txt_disp_value = NULL;
  GtkWidget *txt_disp_addr  = NULL;
  GtkWidget *txt_disp_paid  = NULL;
  GtkWidget *txt_disp_conts = NULL;
  GtkWidget *txt_disp_sts   = NULL;
  GtkWidget *chk_disp_inhib = NULL;
  GtkWidget *hbox_disp      = NULL;
  char          buff    [256];
  char          dispName[256];
  int           serial = 0;
  int           i      = 0;

  /*-- Determine what dispensers are available ------------------------*/
  for (i=0,serial=0; ReadDispenserDetails(serial, &Dispenser); serial++,i++)
  {
    /*-- Locate required widgets --------------------------------------*/
    sprintf(buff ,"lbl_disp_type_%02d",      i);
    lbl_disp_type  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_value_%02d",     i);
    txt_disp_value = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_addr_%02d",      i);
    txt_disp_addr  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_paid_%02d",      i);
    txt_disp_paid  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_conts_%02d",     i);
    txt_disp_conts = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_sts_%02d",       i);
    txt_disp_sts   = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"chk_disp_inhib_%02d",     i);
    chk_disp_inhib = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"hbox_disp_%02d",          i);
    hbox_disp      = lookup_widget  (GTK_WIDGET(WinDispensers), buff);

    /*-- Show the required widgets ------------------------------------*/
    gtk_widget_show(GTK_WIDGET(lbl_disp_type));
    gtk_widget_show(GTK_WIDGET(txt_disp_value));
    gtk_widget_show(GTK_WIDGET(txt_disp_addr));
    gtk_widget_show(GTK_WIDGET(txt_disp_paid));
    gtk_widget_show(GTK_WIDGET(txt_disp_conts));
    gtk_widget_show(GTK_WIDGET(txt_disp_sts));
    gtk_widget_show(GTK_WIDGET(chk_disp_inhib));
    gtk_widget_set_sensitive (GTK_WIDGET(chk_disp_inhib), TRUE);
    gtk_widget_show(GTK_WIDGET(hbox_disp));

    /*-- Determine unit type ------------------------------------------*/
    switch (Dispenser.Unit)
    { case DP_AS_WH2:           strcpy(dispName, "Asahi Seiko Escalator");      break;
      case DP_AZK_HOPPER:       strcpy(dispName, "Azkoyen Hopper");             break;
      case DP_CC_GHOST_HOPPER:  strcpy(dispName, "Ghost (Coin count only)");    break;
      case DP_MCL_SCH2:         strcpy(dispName, "MCL Serial Compact Hopper");  break;
      case DP_MCL_SCH3:         strcpy(dispName, "MCL Combi Hopper");           break;
      case DP_MCL_SUH1:         strcpy(dispName, "MCL Serial Universal Hopper");break;
      case DP_MDB_LEVEL_2_TUBE: strcpy(dispName, "MDB Tube");                   break;
      case DP_MDB_TYPE_3_PAYOUT:strcpy(dispName, "MDB Payout System");          break;
      default:                  strcpy(dispName, "Unknown");                    break;
    }
    gtk_label_set_text (GTK_LABEL(lbl_disp_type), dispName);

    /*-- Determine dispenser value / addr / count ---------------------*/
    sprintf(buff, "%ld", Dispenser.Value);
    gtk_entry_set_text (GTK_ENTRY(txt_disp_value), buff);
    sprintf(buff, "%ld",Dispenser.UnitAddress);
    gtk_entry_set_text (GTK_ENTRY(txt_disp_addr), buff);
    sprintf(buff, "%ld", Dispenser.Count);
    gtk_entry_set_text (GTK_ENTRY(txt_disp_paid), buff);

    /*-- Determine coin count contents --------------------------------*/
    switch (Dispenser.CoinCountStatus)
    { case DISPENSER_COIN_NONE    : strcpy (buff, "-");                             break;
      case DISPENSER_COIN_LOW     : strcpy (buff, "Low");                           break;
      case DISPENSER_COIN_MID     : strcpy (buff, "Normal");                        break;
      case DISPENSER_COIN_HIGH    : strcpy (buff, "High");                          break;
      case DISPENSER_ACCURATE     : sprintf(buff, "%ld",      Dispenser.CoinCount); break;
      case DISPENSER_ACCURATE_FULL: sprintf(buff, "Full %ld", Dispenser.CoinCount); break;
      default                     : strcpy (buff, "Unknown");                       break;
    }
    gtk_entry_set_text (GTK_ENTRY(txt_disp_conts), buff);

    /*-- Determine dispenser status -----------------------------------*/
    switch (Dispenser.Status)
    { case PAY_FINISHED      : strcpy(buff, "Idle OK");         break;
      case PAY_ONGOING       : strcpy(buff, "Paying");          break;
      case PAY_EMPTY         : strcpy(buff, "Empty");           break;
      case PAY_JAMMED        : strcpy(buff, "Jammed");          break;
      case PAY_US            : strcpy(buff, "U/S");             break;
      case PAY_FRAUD         : strcpy(buff, "Fraud Attempt");   break;
      case PAY_FAILED_BLOCKED: strcpy(buff, "Blocked");         break;
      case PAY_NO_HOPPER     : strcpy(buff, "No Dispenser");    break;
      case PAY_INHIBITED     : strcpy(buff, "Inhibited");       break;
      case PAY_SECURITY_FAIL : strcpy(buff, "Security Fail");   break;
      case PAY_HOPPER_RESET  : strcpy(buff, "Dispenser Reset"); break;
      case PAY_NOT_EXACT     : strcpy(buff, "No Exact Coin");   break;
      case PAY_GHOST         : strcpy(buff, "Ghost");           break;
      default                : sprintf(buff, "Error %ld", Dispenser.Status);
    }
    gtk_entry_set_text (GTK_ENTRY(txt_disp_sts), buff);

    /*-- Determine if the dispenser is inhibited ----------------------*/
    if (Dispenser.Inhibit == 0)
      gtk_toggle_button_set_active(GTK_TOGGLE_BUTTON(chk_disp_inhib), FALSE);
    else
      gtk_toggle_button_set_active(GTK_TOGGLE_BUTTON(chk_disp_inhib), TRUE);
  }

  for (i=serial; i<=15; i++)
  {  /*-- Locate required widgets --------------------------------------*/
    sprintf(buff ,"lbl_disp_type_%02d",      i);
    lbl_disp_type  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_value_%02d",     i);
    txt_disp_value = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_addr_%02d",      i);
    txt_disp_addr  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_paid_%02d",      i);
    txt_disp_paid  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_conts_%02d",     i);
    txt_disp_conts = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_sts_%02d",       i);
    txt_disp_sts   = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"chk_disp_inhib_%02d",     i);
    chk_disp_inhib = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"hbox_disp_%02d",          i);
    hbox_disp      = lookup_widget  (GTK_WIDGET(WinDispensers), buff);

    /*-- Clear values from widgets ------------------------------------*/
    gtk_label_set_text (GTK_LABEL(lbl_disp_type),  "");
    gtk_entry_set_text (GTK_ENTRY(txt_disp_value), "");
    gtk_entry_set_text (GTK_ENTRY(txt_disp_addr),  "");
    gtk_entry_set_text (GTK_ENTRY(txt_disp_paid),  "");
    gtk_entry_set_text (GTK_ENTRY(txt_disp_conts), "");
    gtk_entry_set_text (GTK_ENTRY(txt_disp_sts),   "");
    gtk_widget_set_sensitive (GTK_WIDGET(chk_disp_inhib), FALSE);


    /*-- Hide the required widgets ------------------------------------*/
    gtk_widget_hide(GTK_WIDGET(lbl_disp_type));
    gtk_widget_hide(GTK_WIDGET(txt_disp_value));
    gtk_widget_hide(GTK_WIDGET(txt_disp_addr));
    gtk_widget_hide(GTK_WIDGET(txt_disp_paid));
    gtk_widget_hide(GTK_WIDGET(txt_disp_conts));
    gtk_widget_hide(GTK_WIDGET(txt_disp_sts));
    gtk_widget_hide(GTK_WIDGET(chk_disp_inhib));
    gtk_widget_hide(GTK_WIDGET(hbox_disp));
  }

  /*-- Display text if no dispensers located --------------------------*/
  if (serial == 0)
  {
    GtkWidget *errDialog = gtk_message_dialog_new (GTK_WINDOW(WinMain),
                              GTK_DIALOG_DESTROY_WITH_PARENT,
                              GTK_MESSAGE_WARNING,
                              GTK_BUTTONS_CLOSE,
                              "No Dispensers on system\n");
    gtk_window_set_title (GTK_WINDOW(errDialog),
                              "Aardvark Embedded Solutions");
    gtk_window_set_icon_from_file (GTK_WINDOW(errDialog),
                              "../pixmaps/AESDemo-icon.png", NULL);
    gtk_dialog_run (GTK_DIALOG (errDialog));
    gtk_widget_destroy (errDialog);
    DispenserStopTimer = 1;
  }else
  { /*-- Show the Acceptors window -------------------------------------*/
    gtk_widget_show_all(GTK_WIDGET(WinDispensers));
  }
  return;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StartDispenserTimer                (void)
{
  DispenserTimerTag = g_timeout_add ( (guint) 500, DataFn_UpdateDispensers, NULL );
  DispenserStopTimer= 0;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_StopDispenserTimer                 (void)
{
  DispenserStopTimer = 1;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
int
DataFn_UpdateDispensers                   (gpointer      data)
{
  GtkWidget *lbl_disp_type  = NULL;
  GtkWidget *txt_disp_value = NULL;
  GtkWidget *txt_disp_addr  = NULL;
  GtkWidget *txt_disp_paid  = NULL;
  GtkWidget *txt_disp_conts = NULL;
  GtkWidget *txt_disp_sts   = NULL;
  char       buff [256];
  int        i;

  /*-- Determine if we are required to perform the update -------------*/
  if (DispenserStopTimer) return FALSE;

  /*-- Update dispenser data ------------------------------------------*/
  for (i=0; ReadDispenserDetails(i, &Dispenser); i++)
  {
    /*-- Locate required widgets --------------------------------------*/
    sprintf(buff ,"lbl_disp_type_%02d",      i);
    lbl_disp_type  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_value_%02d",     i);
    txt_disp_value = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_addr_%02d",      i);
    txt_disp_addr  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_paid_%02d",      i);
    txt_disp_paid  = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_conts_%02d",     i);
    txt_disp_conts = lookup_widget  (GTK_WIDGET(WinDispensers), buff);
    sprintf(buff ,"txt_disp_sts_%02d",       i);
    txt_disp_sts   = lookup_widget  (GTK_WIDGET(WinDispensers), buff);

    /*-- Determine unit type ------------------------------------------*/
    switch (Dispenser.Unit)
    { case DP_AS_WH2:           strcpy(buff, "Asahi Seiko Escalator");      break;
      case DP_AZK_HOPPER:       strcpy(buff, "Azkoyen Hopper");             break;
      case DP_CC_GHOST_HOPPER:  strcpy(buff, "Ghost (Coin count only)");    break;
      case DP_MCL_SCH2:         strcpy(buff, "MCL Serial Compact Hopper");  break;
      case DP_MCL_SCH3:         strcpy(buff, "MCL Combi Hopper");           break;
      case DP_MCL_SUH1:         strcpy(buff, "MCL Serial Universal Hopper");break;
      case DP_MDB_LEVEL_2_TUBE: strcpy(buff, "MDB Tube");                   break;
      case DP_MDB_TYPE_3_PAYOUT:strcpy(buff, "MDB Payout System");          break;
      default:                  strcpy(buff, "Unknown");                    break;
    }
    gtk_label_set_text (GTK_LABEL(lbl_disp_type), buff);

    /*-- Determine dispenser value / addr / count ---------------------*/
    sprintf(buff, "%ld", Dispenser.Value);
    gtk_entry_set_text (GTK_ENTRY(txt_disp_value), buff);
    sprintf(buff, "%ld",Dispenser.UnitAddress);
    gtk_entry_set_text (GTK_ENTRY(txt_disp_addr), buff);
    sprintf(buff, "%ld", Dispenser.Count);
    gtk_entry_set_text (GTK_ENTRY(txt_disp_paid), buff);

    /*-- Determine coin count contents --------------------------------*/
    switch (Dispenser.CoinCountStatus)
    { case DISPENSER_COIN_NONE    : strcpy (buff, "-");                             break;
      case DISPENSER_COIN_LOW     : strcpy (buff, "Low");                           break;
      case DISPENSER_COIN_MID     : strcpy (buff, "Normal");                        break;
      case DISPENSER_COIN_HIGH    : strcpy (buff, "High");                          break;
      case DISPENSER_ACCURATE     : sprintf(buff, "%ld",      Dispenser.CoinCount); break;
      case DISPENSER_ACCURATE_FULL: sprintf(buff, "Full %ld", Dispenser.CoinCount); break;
      default                     : strcpy (buff, "Unknown");                       break;
    }
    gtk_entry_set_text (GTK_ENTRY(txt_disp_conts), buff);

    /*-- Determine dispenser status -----------------------------------*/
    switch (Dispenser.Status)
    { case PAY_FINISHED      : strcpy(buff, "Idle OK");         break;
      case PAY_ONGOING       : strcpy(buff, "Paying");          break;
      case PAY_EMPTY         : strcpy(buff, "Empty");           break;
      case PAY_JAMMED        : strcpy(buff, "Jammed");          break;
      case PAY_US            : strcpy(buff, "U/S");             break;
      case PAY_FRAUD         : strcpy(buff, "Fraud Attempt");   break;
      case PAY_FAILED_BLOCKED: strcpy(buff, "Blocked");         break;
      case PAY_NO_HOPPER     : strcpy(buff, "No Dispenser");    break;
      case PAY_INHIBITED     : strcpy(buff, "Inhibited");       break;
      case PAY_SECURITY_FAIL : strcpy(buff, "Security Fail");   break;
      case PAY_HOPPER_RESET  : strcpy(buff, "Dispenser Reset"); break;
      case PAY_NOT_EXACT     : strcpy(buff, "No Exact Coin");   break;
      case PAY_GHOST         : strcpy(buff, "Ghost");           break;
      default                : sprintf(buff, "Error %ld", Dispenser.Status);
    }
    gtk_entry_set_text (GTK_ENTRY(txt_disp_sts), buff);
  }
  return TRUE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
DataFn_SetDispInhibitState                (GtkToggleButton *togglebutton,
                                           int              index)
{
  gboolean state = gtk_toggle_button_get_active (GTK_TOGGLE_BUTTON(togglebutton));

  ReadDispenserDetails(index, &Dispenser);
  Dispenser.Inhibit = (state == TRUE) ? 1 : 0;
  WriteDispenserDetails(index, &Dispenser);
}


/****************************************************************************\
 ****************************************************************************
                          Generic Data Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
char*
DataFn_EventDecode                        (int            event)
{
  switch (event)
  {
    case IMHEI_NULL                     : return "Null";
    case IMHEI_INTERFACE_START          : return "Interface Start";
    case IMHEI_APPLICATION_START        : return "Application Start";
    case IMHEI_APPLICATION_EXIT         : return "Application Exit";
    case IMHEI_OVERFLOW                 : return "Overflow";

    /*-- Coin Acceptors -----------------------------------------------*/
    case IMHEI_COIN_NOW_OK              : return "Coin: Now Ok";
    case IMHEI_COIN_UNIT_REPORTED_FAULT : return "Coin: Unit Reported Fault";
    case IMHEI_COIN_UNIT_TIMEOUT        : return "Coin: Unit Timeout";
    case IMHEI_COIN_UNIT_RESET          : return "Coin: Unit Reset";
    case IMHEI_COIN_SELF_TEST_REFUSED   : return "Coin: Self Test Refused";
    case IMHEI_COIN_REJECT_COIN         : return "Coin: Reject Coin";
    case IMHEI_COIN_INHIBITED_COIN      : return "Coin: Inhibited Coin";
    case IMHEI_COIN_FRAUD_ATTEMPT       : return "Coin: Fraud Attempt";
    case IMHEI_COIN_ACCEPTOR_JAM        : return "Coin: Acceptor Jam";
    case IMHEI_COIN_COIN_RETURN         : return "Coin: Coin Return";
    case IMHEI_COIN_SORTER_JAM          : return "Coin: Sorter Jam";
    case IMHEI_COIN_INTERNAL_PROBLEM    : return "Coin: Internal Problem";
    case IMHEI_COIN_UNCLASSIFIED_EVENT  : return "Coin: Unclassified Event";

    /*-- Note Acceptors -----------------------------------------------*/
    case IMHEI_NOTE_NOW_OK              : return "Note: Now Ok";
    case IMHEI_NOTE_UNIT_REPORTED_FAULT : return "Note: Unit Reported Fault";
    case IMHEI_NOTE_UNIT_TIMEOUT        : return "Note: Unit Timeout";
    case IMHEI_NOTE_UNIT_RESET          : return "Note: Unit Reset";
    case IMHEI_NOTE_SELF_TEST_REFUSED   : return "Note: Self Test Refused";
    case IMHEI_NOTE_REJECT_NOTE         : return "Note: Reject Note";
    case IMHEI_NOTE_INHIBITED_NOTE      : return "Note: Inhibited Note";
    case IMHEI_NOTE_NOTE_MISREAD        : return "Note: Note Misread";
    case IMHEI_NOTE_FRAUD_ATTEMPT       : return "Note: Fraud Attempt";
    case IMHEI_NOTE_ACCEPTOR_JAM        : return "Note: Acceptor Jam";
    case IMHEI_NOTE_ACCEPTOR_JAM_FIXED  : return "Note: Acceptor Jam Fixed";
    case IMHEI_NOTE_NOTE_RETURNED       : return "Note: Note Returned";
    case IMHEI_NOTE_STACKER_PROBLEM     : return "Note: Stacker Problem";
    case IMHEI_NOTE_STACKER_FIXED       : return "Note: Stacker Fixed";
    case IMHEI_NOTE_INTERNAL_ERROR      : return "Note: Internal Error";
    case IMHEI_NOTE_UNCLASSIFIED_EVENT  : return "Note: Unclassified Event";

    /*-- Coin Dispenser ------------------------------------------------*/
    case IMHEI_COIN_DISPENSER_NOW_OK             : return "Hopper: Now OK" ;
    case IMHEI_COIN_DISPENSER_REPORTED_FAULT     : return "Hopper: Unit Reported Fault";
    case IMHEI_COIN_DISPENSER_TIMEOUT            : return "Hopper: Unit Timeout";
    case IMHEI_COIN_DISPENSER_RESET              : return "Hopper: Unit Reset";
    case IMHEI_COIN_DISPENSER_SELF_TEST_REFUSED  : return "Hopper: Self Test Refused";
    case IMHEI_COIN_DISPENSER_FRAUD_ATTEMPT      : return "Hopper: Fraud Attempt";
    case IMHEI_COIN_DISPENSER_UPDATE             : return "Hopper: Level Updated";

    default                             : return "Unknown Message Code" ;
  }
}
