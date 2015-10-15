#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include "..\..\Aesimhei.h"

void PayCoins(long NoOfCoins) ;

int main(int ac, char **av)
    {
    if (ac < 2)
        PayCoins(1) ;
    else
        PayCoins(atoi(av[1])) ;
    return 1 ;
    }



void PayCoins(long NoOfCoins)
    {
    long OpenStatus = OpenMHE() ;
    long CurrentPayOut ;
  
    if (OpenStatus != 0)
        {
        printf("IMHEI open failed - %ld\n", OpenStatus) ;
        }
    else
        {
        // Then the open call was successful
        // The interface is currently disabled
        CurrentPayOut = CurrentPaid() ;
        printf("Value paid to date: %d\n", CurrentPayOut) ;

        EnableInterface() ;

        PayOut(NoOfCoins * 100) ;

        while (LastPayStatus() == PAY_ONGOING)
          {
          if (CurrentPayOut != CurrentPaid())
               {
               CurrentPayOut = CurrentPaid() ;
               printf("      Now paid out: %ld\n", CurrentPayOut) ;
               }
           Sleep(10) ;
           }

        if (LastPayStatus() != PAY_FINISHED)
           {
           printf("Error %ld when paying %ld coins\n", LastPayStatus(), NoOfCoins) ;
           printf("        Total value paid out: %ld\n", CurrentPaid()) ;
           }
        else
           {
           printf("%ld coins paid out, Value %ld\n", NoOfCoins, CurrentPaid()) ;
           }
        }
    }

