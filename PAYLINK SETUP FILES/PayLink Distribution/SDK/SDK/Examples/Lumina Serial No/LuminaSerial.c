#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include "..\..\Aesimhei.h"


int main(int ac, char **av)
    {
    char Line[80] ;
    int i ;
    long Serial ;
    long OpenStatus = OpenMHE() ;

    if (OpenStatus != 0)
        {
        printf("IMHEI open failed - %ld\n", OpenStatus) ;
        return 0 ;
        }

    if (ac < 2)
        {
        printf("Enter Serial No: ") ;
        putchar(-1) ;
        gets(Line) ;
        }
    else
        {
        strcpy(Line, av[1]) ;
        }

    // We need this as BCD hex
    Serial = 0 ;
    for (i = 0 ; Line[i] ; ++i)
        {
        Serial <<= 4;
        Serial |= Line[i] & 0xf ;
        }

    if (Serial == 0)
        {
        printf("Abandoned\n", Serial) ;
        }
    else
        {
        SetDeviceKey(2, 40, Serial) ;
        printf("Lumina Serial Number set to %06x\n", Serial) ;
        }
    return 1 ;
    }
