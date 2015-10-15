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
 * GTK Includes.
\*--------------------------------------------------------------------------*/
#ifdef HAVE_CONFIG_H
#  include <config.h>
#endif
#include <gtk/gtk.h>

/*--------------------------------------------------------------------------*\
 * Application Includes.
\*--------------------------------------------------------------------------*/
#include "callbacks.h"
#include "interface.h"
#include "support.h"
#include "data_funcs.h"

/*--------------------------------------------------------------------------*\
 * AES Includes.
\*--------------------------------------------------------------------------*/
#include "Aesimhei.h"

/*--------------------------------------------------------------------------*\
 * External Variables.
\*--------------------------------------------------------------------------*/
extern GtkWidget *WinMain;
extern GtkWidget *WinPayout;
extern GtkWidget *WinAcceptors;
extern GtkWidget *WinLeds;
extern GtkWidget *WinDispensers;


/****************************************************************************\
 ****************************************************************************
                       Main Window Call Back Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_btnReset_button_press_event         (GtkWidget       *widget,
                                        GdkEventButton  *event,
                                        gpointer         user_data)
{ DataFn_Reset();
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_btnPayIt_button_press_event         (GtkWidget       *widget,
                                        GdkEventButton  *event,
                                        gpointer         user_data)
{ DataFn_PayOut();
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_btnAcceptor_button_press_event      (GtkWidget       *widget,
                                        GdkEventButton  *event,
                                        gpointer         user_data)
{ 
  DataFn_SetupAcceptors();
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_btnSwitchs_button_press_event       (GtkWidget       *widget,
                                        GdkEventButton  *event,
                                        gpointer         user_data)
{ if (WinLeds != NULL)
    gtk_widget_show_all(GTK_WIDGET(WinLeds));
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_btnDispensers_button_press_event    (GtkWidget       *widget,
                                        GdkEventButton  *event,
                                        gpointer         user_data)
{ 
  DataFn_SetupDispensers();
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 * Place holder for when this functionality is added (ported).
\*--------------------------------------------------------------------------*/
gboolean
on_btnMeter_button_press_event         (GtkWidget       *widget,
                                        GdkEventButton  *event,
                                        gpointer         user_data)
{ return FALSE;
}

/*--------------------------------------------------------------------------*\
 * Place holder for when this functionality is added (ported).
\*--------------------------------------------------------------------------*/
void
on_togEscrow_toggled                   (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{
}

/*--------------------------------------------------------------------------*\
 * Place holder for when this functionality is added (ported).
\*--------------------------------------------------------------------------*/
gboolean
on_btnBarcodes_button_press_event      (GtkWidget       *widget,
                                        GdkEventButton  *event,
                                        gpointer         user_data)
{ return FALSE;
}

/*--------------------------------------------------------------------------*\
 * 
\*--------------------------------------------------------------------------*/
void
on_cmbEvent_changed                    (GtkComboBox     *combobox,
                                        gpointer         user_data)
{
  gtk_combo_box_set_active (GTK_COMBO_BOX(combobox), 0);
}

/****************************************************************************\
 ****************************************************************************
                         Pay Out Call Back Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_win_payout_show                     (GtkWidget       *widget,
                                        gpointer         user_data)
{
  /*-- Start the update timer going -----------------------------------*/
  DataFn_StartPayoutTimer();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_win_payout_delete_event             (GtkWidget       *widget,
                                        GdkEvent        *event,
                                        gpointer         user_data)
{
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopPayoutTimer();
  
  /*-- As this event deletes the window we need to re-create it -------*/
  WinPayout = create_win_payout();
  gtk_window_set_position       (GTK_WINDOW(WinPayout),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinPayout), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_btn_pay_ok_clicked                  (GtkButton       *button,
                                        gpointer         user_data)
{ 
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopPayoutTimer();
  
  /*-- Hide the leds window -------------------------------------------*/
  gtk_widget_hide (GTK_WIDGET(WinPayout));
}


/****************************************************************************\
 ****************************************************************************
                      Switches / LEDs Call Back Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_win_leds_show                       (GtkWidget       *widget,
                                        gpointer         user_data)
{
  /*-- Start the update timer going -----------------------------------*/
  DataFn_StartLedsTimer();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_win_leds_delete_event               (GtkWidget       *widget,
                                        GdkEvent        *event,
                                        gpointer         user_data)
{
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopLedsTimer();
  
  /*-- As this event deletes the window we need to re-create it -------*/
  WinLeds = create_win_leds();
  gtk_window_set_position       (GTK_WINDOW(WinLeds),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinLeds), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_btn_leds_ok_clicked                 (GtkButton       *button,
                                        gpointer         user_data)
{
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopLedsTimer();
  
  /*-- Hide the leds window -------------------------------------------*/
  gtk_widget_hide (GTK_WIDGET(WinLeds));
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_00_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 0);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_01_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 1);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_02_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 2);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_03_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 3);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_04_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 4);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_05_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 5);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_06_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 6);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_07_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 7);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_08_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 8);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_09_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 9);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_10_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 10);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_11_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 11);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_12_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 12);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_13_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 13);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_14_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 14);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_leds_15_toggled                 (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetLedState(togglebutton, 15);
}

/****************************************************************************\
 ****************************************************************************
                      Acceptors Call Back Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_win_acceptors_show                  (GtkWidget       *widget,
                                        gpointer         user_data)
{
  /*-- Start the update timer going -----------------------------------*/
  DataFn_StartAcceptorTimer();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_win_acceptors_delete_event          (GtkWidget       *widget,
                                        GdkEvent        *event,
                                        gpointer         user_data)
{
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopAcceptorTimer();
  
  /*-- As this event deletes the window we need to re-create it -------*/
  WinAcceptors = create_win_acceptors();
  gtk_window_set_position       (GTK_WINDOW(WinAcceptors),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinAcceptors), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_btn_acpt_done_clicked               (GtkButton       *button,
                                        gpointer         user_data)
{ 
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopAcceptorTimer();
  
  /*-- Hide the acceptor window ---------------------------------------*/
  gtk_widget_hide (GTK_WIDGET(WinAcceptors));
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_cmb_acpt_acceptors_changed          (GtkComboBox     *combobox,
                                        gpointer         user_data)
{
  DataFn_AcceptorChanged();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_disable_toggled            (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{
  DataFn_ChangeAcceptorStatus(togglebutton);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_acpt_activate                       (GtkEntry        *entry,
                                        gpointer         user_data)
{ 
  DataFn_UpdateAcceptor();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_tgl_acpt_bchupdts_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{
  if (!(gtk_toggle_button_get_active (GTK_TOGGLE_BUTTON(togglebutton))))
    DataFn_WriteAllToAcceptor ();
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_01_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 0);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_02_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 1);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_03_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 2);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_04_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 3);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_05_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 4);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_06_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 5);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_07_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 6);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_08_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 7);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_09_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 8);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_10_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 9);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_11_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 10);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_12_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 11);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_13_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 12);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_14_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 13);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_15_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 14);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_acpt_inhib_16_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetInhibitState(togglebutton, 15);
}


/****************************************************************************\
 ****************************************************************************
                       Dispensers Call Back Functions
 ****************************************************************************
\****************************************************************************/
/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_win_dispensers_show                 (GtkWidget       *widget,
                                        gpointer         user_data)
{
  /*-- Start the update timer going -----------------------------------*/
  DataFn_StartDispenserTimer();
  
  /*-- Set up the dispensers display ----------------------------------*/
  DataFn_SetupDispensers ();
}


/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
gboolean
on_win_dispensers_delete_event         (GtkWidget       *widget,
                                        GdkEvent        *event,
                                        gpointer         user_data)
{
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopDispenserTimer();
  
  /*-- As this event deletes the window we need to re-create it -------*/
  WinAcceptors = create_win_dispensers();
  gtk_window_set_position       (GTK_WINDOW(WinDispensers),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinDispensers), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  return FALSE;
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_btn_dispen_ok_clicked               (GtkButton       *button,
                                        gpointer         user_data)
{ 
  /*-- Stop the update timer going -----------------------------------*/
  DataFn_StopDispenserTimer();
  
  /*-- Hide the dispensers window ------------------------------------*/
  gtk_widget_hide (GTK_WIDGET(WinDispensers));
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_00_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 0);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_01_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 1);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_02_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 2);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_03_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 3);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_04_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 4);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_05_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 5);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_06_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 6);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_07_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 7);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_08_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 8);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_09_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 9);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_10_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 10);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_11_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 11);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_12_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 12);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_13_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 13);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_14_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 14);
}

/*--------------------------------------------------------------------------*\
 *
\*--------------------------------------------------------------------------*/
void
on_chk_disp_inhib_15_toggled           (GtkToggleButton *togglebutton,
                                        gpointer         user_data)
{ DataFn_SetDispInhibitState (togglebutton, 15);
}
