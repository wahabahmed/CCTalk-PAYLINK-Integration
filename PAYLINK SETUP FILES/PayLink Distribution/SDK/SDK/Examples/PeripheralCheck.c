#include <stdlib.h>
#include <string.h>
#include <Windows.h>
#include <memory.h>
#include <stdio.h>
#include <io.h>
#include <fcntl.h>
#include <time.h>
#include <sys/types.h>
#include <sys/stat.h>

#include "AESimhei.h"

void PrintAboutAcceptors(void)
    {
    AcceptorBlock AcceptorDetails ;
    char * AcceptorName ;
    int AcceptorNo ;
    int CoinNo ;

    for (AcceptorNo = 0 ; ReadAcceptorDetails(AcceptorNo,
                                             &AcceptorDetails) ; ++ AcceptorNo)
        {
        switch(AcceptorDetails.Unit)
            {
        case DP_AST_GBA:
            AcceptorName = "AstroSystems GBA" ;
            break ;

        case DP_AZK_A6:
            AcceptorName = "Azkoyen A6" ;
            break ;

        case DP_AZK_MDB:
            AcceptorName = "Azkoyen MDB Changer" ;
            break ;

        case DP_COINCO_BILLPRO:
            AcceptorName = "CoinCo BillPro" ;
            break ;

        case DP_COINCO_GLOBAL:
            AcceptorName = "CoinCo Global" ;
            break ;

        case DP_COINCO_MDB:
            AcceptorName = "CoinCo MDB Changer" ;
            break ;

        case DP_COINCO_MDB_BILL:
            AcceptorName = "CoinCo MDB Bill" ;
            break ;

        case DP_COINCO_VORTEX:
            AcceptorName = "CoinCo Vortex" ;
            break ;

        case DP_GPT_NOTE:
            AcceptorName = "GPT Argus" ;
            break ;

        case DP_ICT_U85:
            AcceptorName = "ICT U85" ;
            break ;

        case DP_ID003_NOTE:
            AcceptorName = "ID-003 Note" ;
            break ;

        case DP_INNOV_NV10:
            AcceptorName = "Innovative NV10" ;
            break ;

        case DP_INNOV_NV4:
            AcceptorName = "Innovative NV4" ;
            break ;

        case DP_INNOV_NV7:
            AcceptorName = "Innovative NV7" ;
            break ;

        case DP_INNOV_NV8:
            AcceptorName = "Innovative NV8" ;
            break ;

        case DP_INNOV_NV9:
            AcceptorName = "Innovative NV9" ;
            break ;

        case DP_JCM_CC_EBA:
            AcceptorName = "JCM EBA on cctalk" ;
            break ;

        case DP_JCM_CC_WBA:
            AcceptorName = "JCM WBA on cctalk" ;
            break ;

        case DP_JCM_NOTE:
            AcceptorName = "JCM Note" ;
            break ;

        case DP_MARS_CASHFLOW_126:
            AcceptorName = "Mars Cashflow 126" ;
            break ;

        case DP_MARS_CASHFLOW_690:
            AcceptorName = "Mars Cashflow 690" ;
            break ;

        case DP_MARS_CASHFLOW_9500:
            AcceptorName = "Mars Cashflow 9500" ;
            break ;

        case DP_MARS_MDB:
            AcceptorName = "Mars MDB Changer" ;
            break ;

        case DP_MCL_7200:
            AcceptorName = "MCL 7200" ;
            break ;

        case DP_MCL_ARDAC:
            AcceptorName = "MCL Ardac /ID-003" ;
            break ;

        case DP_MCL_ARDAC_ELITE:
            AcceptorName = "MCL Ardac Elite" ;
            break ;

        case DP_MCL_CONDOR:
            AcceptorName = "MCL Condor" ;
            break ;

        case DP_MCL_LUMINA:
            AcceptorName = "MCL Lumina" ;
            break ;

        case DP_MCL_SR3:
            AcceptorName = "MCL SR3" ;
            break ;

        case DP_MCL_SR5:
            AcceptorName = "MCL SR5" ;
            break ;

        case DP_MCL_WACS:
            AcceptorName = "MCL Ardac / WACS" ;
            break ;

        case DP_MDB_BILL:
            AcceptorName = "MBD Bill" ;
            break ;

        case DP_MDB_LEVEL_2:
            AcceptorName = "MDB Level 2 Changer" ;
            break ;

        case DP_MDB_LEVEL_3:
            AcceptorName = "MDB Level 3 Changer" ;
            break ;

        case DP_NRI_G40:
            AcceptorName = "NRI G40" ;
            break ;



        case DP_HII_INTERFACE | DP_COIN_ACCEPT_DEVICE:
            AcceptorName = "Hi2 Coin" ;
            break ;

        case DP_CCTALK_INTERFACE | DP_COIN_ACCEPT_DEVICE:
            AcceptorName = "ccTalk Coin" ;
            break ;

        case DP_CCTALK_INTERFACE | DP_NOTE_ACCEPT_DEVICE:
            AcceptorName = "ccTalk Note" ;
            break ;


        default:
            AcceptorName = "Unknown" ;
            break ;
            }

        printf("    Acceptor %d: %s, Default Path %ld,\n",
                                                AcceptorNo,
                                                AcceptorName,
                                                AcceptorDetails.DefaultPath) ;
        printf("       Rejected count %ld, Currency <%s>, %ld coins:\n",
                                                AcceptorDetails.RejectCount,
                                                AcceptorDetails.Currency,
                                                AcceptorDetails.NoOfCoins) ;

        for (CoinNo = 0 ; CoinNo < AcceptorDetails.NoOfCoins ; ++CoinNo)
           {
           printf("          Coin %2d, Value %4ld, Count %4ld, Path %ld, Coins %4ld",
                                                CoinNo,
                                                AcceptorDetails.Coin[CoinNo].Value,
                                                AcceptorDetails.Coin[CoinNo].Count,
                                                AcceptorDetails.Coin[CoinNo].Path,
                                                AcceptorDetails.Coin[CoinNo].PathCount) ;

           if (AcceptorDetails.Coin[CoinNo].DefaultPath)
              printf(", Default Path %d", AcceptorDetails.Coin[CoinNo].DefaultPath) ;

           printf("\n") ;
           }
        }
    }


void PrintAboutDispensers(void)
    {
    DispenserBlock DispenserDetails ;
    char * DispenserName ;
    int DispenserNo ;

    for (DispenserNo = 0 ; ReadDispenserDetails(DispenserNo,
                                           &DispenserDetails) ; ++ DispenserNo)
        {
        switch(DispenserDetails.Unit)
            {
       case DP_AS_WH2:
           DispenserName = "Asahi Seiko Escalator" ;
           break ;

       case DP_AZK_HOPPER:
           DispenserName = "Azkoyen Hopper" ;
           break ;

       case DP_CC_GHOST_HOPPER:
                DispenserName = "Ghost (Coin count only)" ;
                break ;

            case DP_MCL_SCH2:
                DispenserName = "MCL Serial Compact Hopper 2" ;
                break ;

            case DP_MCL_SCH3A:
                DispenserName = "MCL Combi Hopper" ;
                break ;

            case DP_MCL_SCH3:
                DispenserName = "MCL Serial Compact Hopper 3" ;
                break ;

            case DP_MCL_SUH1:
                DispenserName = "MCL Serial Universal Hopper" ;
           break ;

       case DP_MDB_LEVEL_2_TUBE:
           DispenserName = "MDB Tube" ;
           break ;

       case DP_MDB_TYPE_3_PAYOUT:
           DispenserName = "MDB Payout System" ;
           break ;

        default:
            DispenserName = "Unknown" ;
            break ;
            }

        printf("    Dispenser %d: %s\n        Coin Value %ld, Number Paid %ld,\n",
                                                DispenserNo,
                                                DispenserName,
                                                DispenserDetails.Value,
                                                DispenserDetails.Count) ;
        printf("        Inhibit %ld, Address %ld\n",
                                                DispenserDetails.Inhibit,
                                                DispenserDetails.UnitAddress) ;
        }
    }






int main(int ac, char **av)
    {
    printf("AES Intelligent Money Handling Equipment Interface\n") ;

    if ((Result = OpenIMHEI()) != 0)
        {
        printf("\nAcceptor Details\n") ;
        PrintAboutAcceptors() ;
        printf("\nDispenser Details\n") ;
        PrintAboutDispensers() ;
        }
    else
        {
        printf("    *** Error <%d> from DLL Open\n", Result) ;
        }
    }
