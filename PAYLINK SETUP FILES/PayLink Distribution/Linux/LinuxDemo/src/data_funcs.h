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
 * Ensure we have delay function defined 
\*--------------------------------------------------------------------------*/
#ifndef delay
  #define delay(n)	usleep(n * 1000)
#endif

/*--------------------------------------------------------------------------*\
 * 
\*--------------------------------------------------------------------------*/
int      DataFn_UpdateData                         (gpointer);

void*    DataFn_RetryOpen                          (gint,
                                                    gpointer);
                                         
int      DataFn_Reset                              (void);

int      DataFn_PayOut                             (void);

int      DataFn_AcceptorUpdateData                 (gpointer);

void     DataFn_StartAcceptorTimer                 (void);

void     DataFn_StopAcceptorTimer                  (void);

void     DataFn_WriteToAcceptor                    (void);

void     DataFn_WriteAllToAcceptor                 (void);

void     DataFn_SetInhibitState                    (GtkToggleButton*,
                                                    int);

void     DataFn_ChangeAcceptorStatus               (GtkToggleButton*);

void     DataFn_UpdateAcceptor                     (void);

void     DataFn_SetupAcceptors                     (void);

void     DataFn_AcceptorChanged                    (void);

int      DataFn_LedsUpdateData                     (gpointer);

void     DataFn_StartLedsTimer                     (void);

void     DataFn_StopLedsTimer                      (void);

void     DataFn_SetLedState                         (GtkToggleButton*,
                                                    int);
                                                    
int      DataFn_PayoutUpdateData                   (gpointer);

void     DataFn_StartPayoutTimer                   (void);

void     DataFn_StopPayoutTimer                    (void);

void     DataFn_SetupDispensers                    (void);

void     DataFn_StartDispenserTimer                (void);

void     DataFn_StopDispenserTimer                 (void);

int      DataFn_UpdateDispensers                   (gpointer);

void     DataFn_SetDispInhibitState                (GtkToggleButton*,
                                                    int);

char*    DataFn_EventDecode                        (int);
