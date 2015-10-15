#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include "..\..\Aesimhei.h"

int main(int argc, char * argv[])
{
        long OpenResult ;

        int OpenCount[2]  = {-4 , -4} ;
    int CloseCount[2] = {-4 , -4} ;

    int NewOpen[2]  ;
    int NewClose[2] ;

        // We initially open two Paylink channels
        // and enable both Paylinks...

        // We also set up the INITIAL counts
        // of switch opens and switch closes

        OpenResult = OpenSpecificMHE("AE000001") ;
        if (OpenResult)
        {
                printf("AE000001: Open Result: %d\n", OpenResult) ;

                return 1;
        }
        EnableInterface() ;
        OpenCount[0]  = SwitchOpens(0) ;
        CloseCount[0] = SwitchCloses(0) ;


        OpenResult = OpenSpecificMHE("AE000002") ;
        if (OpenResult)
        {
                printf("AE000002: Open Result: %d\n", OpenResult) ;

                return 1;
        }
        EnableInterface() ;
        OpenCount[1]  = SwitchOpens(0) ;
        CloseCount[1] = SwitchCloses(0) ;

        // Now we loop, swapping between the two devices
        // and reading switch 0 in each case...

        printf("Checking Paylinks AE000001 and AE000002...\n") ;

        while(1)
        {
                OpenResult = OpenSpecificMHE("AE000001") ;

                if (OpenResult)
                {
                        printf("AE000001: Open Result: %d\n", OpenResult) ;

                        return 1;
                }

                NewOpen[0]  = SwitchOpens(0)  ;
                NewClose[0] = SwitchCloses(0) ;

                if (NewOpen[0] != OpenCount[0])
                {
                        printf("<AE000001> Open %d=>%d\n", OpenCount[0], NewOpen[0]) ;
                        OpenCount[0] = NewOpen[0] ;
                }

                if (NewClose[0] != CloseCount[0])
                {
                        printf("<AE000001> Close %d=>%d\n", CloseCount[0], NewClose[0]) ;
                        CloseCount[0] = NewClose[0] ;
                }

                OpenResult = OpenSpecificMHE("AE000002") ;

                if (OpenResult)
                {
                        printf("AE000002: Open Result: %d\n", OpenResult) ;

                        return 1;
                }

                NewOpen[1] = SwitchOpens(0) ;
                NewClose[1] = SwitchCloses(0) ;

                if (NewOpen[1] != OpenCount[1])
                {
                        printf("<AE000002> Open %d=>%d\n", OpenCount[1], NewOpen[1]) ;
                        OpenCount[1] = NewOpen[1] ;
                }

                if (NewClose[1] != CloseCount[1])
                {
                        printf("<AE000002> Close %d=>%d\n", CloseCount[1], NewClose[1]) ;
                        CloseCount[1] = NewClose[1] ;
                }

                Sleep(1) ;      // Allow other applications to "get a look in"
        }

        return 0;
}

