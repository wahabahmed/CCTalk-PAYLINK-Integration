/*--------------------------------------------------------------------------*\
 * System Includes.
\*--------------------------------------------------------------------------*/
#include <stdio.h>
#include <stdlib.h>
#include <signal.h>
#include <time.h>
#include <unistd.h>
#include <sys/time.h>
#include <sys/types.h>

/*--------------------------------------------------------------------------*\
 * AES Includes.
\*--------------------------------------------------------------------------*/
#include "Aesimhei.h"


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
 * PayCoins:
 * ---------
 *
 *
 * Arguments:
 * ----------
 *
 * Return:
 * -------
 *
\*--------------------------------------------------------------------------*/
void 
PayCoins                                (long            NoOfCoins)
{
    long OpenStatus = OpenMHE() ;
    long CurrentPayOut ;
  
    if (OpenStatus != 0)
        printf("IMHEI open failed - %ld\n", OpenStatus) ;
    else
    {   /*-- Then the open call was successful ------------------------*/
        /*-- The interface is currently disabled ----------------------*/
        CurrentPayOut = CurrentPaid() ;
        printf("Value paid to date: %ld\n", CurrentPayOut) ;

        EnableInterface() ;

        PayOut(NoOfCoins * 100) ;

        while (LastPayStatus() == PAY_ONGOING)
        {   if (CurrentPayOut != CurrentPaid())
            {   CurrentPayOut = CurrentPaid() ;
                printf("      Now paid out: %ld\n", CurrentPayOut) ;
            }
            Sleep(10) ;
        }

        if (LastPayStatus() != PAY_FINISHED)
        {   printf("Error %d when paying %ld coins\n", LastPayStatus(), NoOfCoins) ;
            printf("        Total value paid out: %ld\n", CurrentPaid()) ;
        }else
            printf("%ld coins paid out, Value %ld\n", NoOfCoins, CurrentPaid()) ;
    }
}

/*--------------------------------------------------------------------------*\
 * main:
 * -----
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
main                                    (int             ac,
                                         char          **av)
{
    /*-- Catch signals so we exit cleanly -----------------------------*/
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
    
    if (ac < 2)
        PayCoins(1) ;
    else
        PayCoins(atoi(av[1])) ;
    return 1 ;
}
