 #include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include "..\..\Aesimhei.h"

void AcceptCurrencyExample(int NoOfChanges) ;

int main(int ac, char **av)
    {
    if (ac < 2)
        AcceptCurrencyExample(2) ;
    else
        AcceptCurrencyExample(atoi(av[1])) ;
    return 1 ;
    }



    // Set to send 1/2 NoOfChanges £1 coins to cashbox
void SetCoinLevel(Level)
    {
    AcceptorBlock AcceptorDetails ;
    int AcceptorNo ;
    int CoinNo ;

    for (AcceptorNo = 0 ; ReadAcceptorDetails(AcceptorNo,
                                             &AcceptorDetails) ; ++ AcceptorNo)
        {
        for (CoinNo = 0 ; CoinNo < AcceptorDetails.NoOfCoins ; ++CoinNo)
           {
           if (AcceptorDetails.Coin[CoinNo].Value == 100)
               {
               AcceptorDetails.Coin[CoinNo].Path = 1 ;
               AcceptorDetails.Coin[CoinNo].PathSwitchLevel = Level +
                                          AcceptorDetails.Coin[CoinNo].PathCount;
               printf("Acceptor %d, Coin %d, Current count on path %d\n",
                                                        AcceptorNo,
                                                        CoinNo,
                                                        AcceptorDetails.Coin[CoinNo].PathCount) ;
               WriteAcceptorDetails(AcceptorNo, &AcceptorDetails) ;
               }
           }
        }
    }



void AcceptCurrencyExample(int NoOfChanges)
    {
    long LastCurrencyValue ;
    long NewCurrencyValue  ;

    long OpenStatus = OpenMHE() ;

    if (OpenStatus != 0)
        {
        printf("IMHEI open failed - %ld\n", OpenStatus) ;
        return ;
        }

    printf("Unit Serial Number: %d\n", SerialNumber()) ;

    // Then the open call was successful
    // Currency acceptance is currently disabled
    LastCurrencyValue = CurrentValue() ;

    printf("Initial currency accepted = %ld pence\n",
                                            LastCurrencyValue) ;

    SetCoinLevel(NoOfChanges / 2) ;

    EnableInterface() ;

    printf("Processing %d change events\n", NoOfChanges) ;
    while (NoOfChanges > 0)
        {
        Sleep(100) ;

        NewCurrencyValue = CurrentValue() ;
        if (NewCurrencyValue != LastCurrencyValue)
            {
            // More money has arrived (we do not care where from)
            printf("The user has just inserted %ld pence\n",
                            NewCurrencyValue - LastCurrencyValue) ;
            LastCurrencyValue = NewCurrencyValue ;
            --NoOfChanges ;
            }
        }
    }

