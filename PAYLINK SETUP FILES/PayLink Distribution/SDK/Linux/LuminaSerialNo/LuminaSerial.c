/*--------------------------------------------------------------------------*\
 * System Includes.
\*--------------------------------------------------------------------------*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/*--------------------------------------------------------------------------*\
 * AES Includes.
\*--------------------------------------------------------------------------*/
#include "Aesimhei.h"

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
main                                    (int                     argc, 
                                         char                   *argv[])
{
	char *p ;
    char Line[80] ;
    int  i ;
    long Serial ;
    long OpenStatus = OpenMHE() ;

    if (OpenStatus != 0)
    {   printf("IMHEI open failed - %ld\n", OpenStatus) ;
        return 0 ;
    }

    if (argc < 2)
    {   printf("Enter Serial No: ") ;
        p = fgets(Line, 79, stdin) ;
    }else
    {	strcpy(Line, argv[1]) ;
    }

    /*-- We need this as BCD hex --------------------------------------*/
    Serial = 0 ;
    for (i = 0 ; Line[i] && (Line[i] != '\n') && (Line[i] != '\r'); ++i)
    {   Serial <<= 4;
        Serial |= Line[i] & 0xf ;
    }

    if (Serial == 0)
    {   printf("Abandoned (%06lX)\n", Serial) ;
    }else
    {   SetDeviceKey(2, 40, Serial) ;
        printf("Lumina Serial Number set to %06lX\n", Serial) ;
    }
    return 1 ;
}
