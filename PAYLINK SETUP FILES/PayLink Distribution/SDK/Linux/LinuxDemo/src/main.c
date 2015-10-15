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
#include <sys/types.h>

/*--------------------------------------------------------------------------*\
 * AES Includes.
\*--------------------------------------------------------------------------*/
#include "Aesimhei.h"

/*--------------------------------------------------------------------------*\
 * GTK Includes.
\*--------------------------------------------------------------------------*/
#ifdef HAVE_CONFIG_H
#  include <config.h>
#endif
#include <gtk/gtk.h>
#include <gnome.h>

/*--------------------------------------------------------------------------*\
 * Application Includes.
\*--------------------------------------------------------------------------*/
#include "interface.h"
#include "support.h"
#include "data_funcs.h"

/*--------------------------------------------------------------------------*\
 * Global Variables.
\*--------------------------------------------------------------------------*/
GtkWidget *WinMain              = NULL;
GtkWidget *WinPayout            = NULL;
GtkWidget *WinAcceptors         = NULL;
GtkWidget *WinLeds              = NULL;
GtkWidget *WinDispensers        = NULL;
gint       TimerTag             = -1;
int        OpenError            =  0;
double     TotalAmountRead      =  0;
double     StartTotalAmountRead =  0;

/*--------------------------------------------------------------------------*\
 * AbortHandler:
 * -------------
 *
 * This ensures the AESAccess Shared library destructor function is called.
 * If the application exits normaly the destructor is always called, however
 * if the application receives a signal (SIGINT...) the destructor is not
 * called, that is why we need this signal handler (force exit() call).
 *
 * Arguments:
 * ----------
 *
 * Return:
 * -------
 *
\*--------------------------------------------------------------------------*/
void 
AbortHandler                            (int             signum)
{   exit(0);
}

/*--------------------------------------------------------------------------*\
 * :
 * -------------
 *
 *
 * Arguments:
 * ----------
 *
 * Return:
 * -------
 *
\*--------------------------------------------------------------------------*/
int
main (int argc, char *argv[])
{
  GtkWidget *lbl_status         = NULL;
  
  /*-- Catch signals so we exit cleanly -------------------------------*/
  (void)signal(SIGHUP,    AbortHandler); (void)signal(SIGINT,  AbortHandler);
  (void)signal(SIGQUIT,   AbortHandler); (void)signal(SIGILL,  AbortHandler);
  (void)signal(SIGTRAP,   AbortHandler); (void)signal(SIGABRT, AbortHandler);
  (void)signal(SIGBUS,    AbortHandler); (void)signal(SIGFPE,  AbortHandler);
  (void)signal(SIGKILL,   AbortHandler); (void)signal(SIGUSR1, AbortHandler);
  (void)signal(SIGSEGV,   AbortHandler); (void)signal(SIGUSR2, AbortHandler);
  (void)signal(SIGPIPE,   AbortHandler); (void)signal(SIGALRM, AbortHandler);
  (void)signal(SIGTERM,   AbortHandler); (void)signal(SIGCHLD, AbortHandler);
  (void)signal(SIGCONT,   AbortHandler); (void)signal(SIGSTOP, AbortHandler);
  (void)signal(SIGTSTP,   AbortHandler); (void)signal(SIGTTIN, AbortHandler);
  (void)signal(SIGTTOU,   AbortHandler); (void)signal(SIGURG,  AbortHandler);
  (void)signal(SIGXCPU,   AbortHandler); (void)signal(SIGXFSZ, AbortHandler);
  (void)signal(SIGVTALRM, AbortHandler); (void)signal(SIGPROF, AbortHandler);
  (void)signal(SIGWINCH,  SIG_IGN);      (void)signal(SIGIO,   AbortHandler);
  (void)signal(SIGPWR,    AbortHandler); (void)signal(SIGSYS,  AbortHandler);
  
  /*-- Initialise Gnome Library --------------------------------------*/
  gnome_program_init (PACKAGE, VERSION, LIBGNOMEUI_MODULE,
                      argc, argv,
                      GNOME_PARAM_APP_DATADIR, PACKAGE_DATA_DIR,
                      NULL);
  
  /*-- Create application windows ------------------------------------*/
  WinMain       = create_win_main ();
  WinPayout     = create_win_payout();
  WinAcceptors  = create_win_acceptors();
  WinLeds       = create_win_leds();
  WinDispensers = create_win_dispensers();
  
  /*-- Set window positions / icons ----------------------------------*/
  gtk_window_set_position       (GTK_WINDOW(WinMain),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinMain), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  gtk_window_set_position       (GTK_WINDOW(WinPayout),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinPayout), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  gtk_window_set_position       (GTK_WINDOW(WinAcceptors),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinAcceptors), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  gtk_window_set_position       (GTK_WINDOW(WinLeds),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinLeds), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  gtk_window_set_position       (GTK_WINDOW(WinDispensers),GTK_WIN_POS_CENTER_ALWAYS);
  gtk_window_set_icon_from_file (GTK_WINDOW(WinDispensers), 
                                 "../pixmaps/AESDemo-icon.png", NULL);
  
  /*-- Set Status Label that driver is OK -----------------------------*/
  lbl_status = lookup_widget(GTK_WIDGET(WinMain), "lblStatus");
  gtk_label_set_label (GTK_LABEL(lbl_status), "Driver: OK");
  
  /*-- Determine if we have access to the device ----------------------*/
  if ((OpenMHE()) != 0)
  { /*-- This will get caught in the Update Data function -------------*/
    OpenError = 1;
  }      
  
  /*-- Add a timer for our update function ----------------------------*/
  TimerTag = g_timeout_add ( (guint) 500, DataFn_UpdateData, NULL );
  
  /*-- Start the main gtk event processing loop -----------------------*/
  gtk_main ();
  return 0;
}
