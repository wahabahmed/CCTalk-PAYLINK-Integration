#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include "..\..\Aesimhei.h"


unsigned char Block[256 + 64] ;

static void DumpBuffer(void)
    {
    int i ;
    int OnLine = 0 ;
    for (i = 0 ; i < sizeof Block ; ++i)
        {
        if (Block[i] == 0xff)
            {
            putchar('.') ;
            }
        else if (Block[i] < ' ' || Block[i] > 127)
            {
            putchar('~') ;
            }
        else
            {
            putchar(Block[i]) ;
            }
        if (++OnLine > 63)
            {
            putchar('\n') ;
            OnLine = 0 ;
            }
        }
    }


int main(int ac, char **av)
    {
    char Line[80] ;
    int Len, Off, i ;
    long OpenStatus = OpenMHE() ;

    if (OpenStatus != 0)
        {
        printf("IMHEI open failed - %ld\n", OpenStatus) ;
        return 0 ;
        }

    printf("E2Prom exerciser\n") ;
    memset(Block, 'x', sizeof Block) ;

    EnableInterface() ;

    printf("Length to read:") ;
    putchar(-1) ;
    gets(Line) ;
    Len = atoi(Line) ;

    printf("Reading %d bytes -\n", Len) ;
    E2PromRead (Block, Len);
    DumpBuffer() ;


    printf("Total length to write:") ;
    putchar(-1) ;
    gets(Line) ;
    Len = atoi(Line) ;
    if (Len > sizeof Block)
        Len = sizeof Block ;

    printf("offset to start change:") ;
    putchar(-1) ;
    gets(Line) ;
    Off = atoi(Line) ;
    if (Off > sizeof Block)
        Off = sizeof Block ;

    for (i = Off ; i < Len ; ++i)
        Block[i] = 'A' + i - Off ;

    DumpBuffer() ;
    E2PromWrite (Block, Len);

    printf("Press <Return> to exit:") ;
    putchar(-1) ;
    gets(Line) ;
    return 1 ;
    }
