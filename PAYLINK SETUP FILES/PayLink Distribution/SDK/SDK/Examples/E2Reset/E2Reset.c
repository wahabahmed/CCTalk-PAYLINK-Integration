#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include "..\..\Aesimhei.h"


int main(int ac, char **av)
    {
    char Line[80] ;
    long OpenStatus = OpenMHE() ;

    if (OpenStatus != 0)
        {
        printf("IMHEI open failed - %ld\n", OpenStatus) ;
        return 0 ;
        }

    if (ac < 2)
        {
        E2PromReset(0) ;
        printf("PCI card counters cleared\n") ;
        }
    else
        {
        printf("Clearing and locking PCI card counters. Enter OK to continue:") ;
        putchar(-1) ;
        gets(Line) ;
        if (Line[0] == 'O' &&
            Line[1] == 'K')
            {
            E2PromReset(1) ;
            printf("PCI card counters cleared & locked\n") ;
            }
        else
            {
            printf("No action taken\n") ;
            }
        }
    return 1 ;
    }
