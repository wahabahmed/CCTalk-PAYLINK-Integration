{***************************************************************

Definitions for events provided by the Aardvark Embedded Solutions
Intelligent Money Handling Equipment Interface

****************************************************************}
unit ImheiEvent;

interface

{**************************************************************
Event codes have an internal structure, allowing cateogizations.
The bottom 6 bits are the unique code for the event,
serious fault related codes have bit 5 set.
Above this are bits describing the type of unit affected.
***************************************************************}
 const

// Values to allow this categoisation to be acheived

    EVENT_CODE_MASK       =   $03f ;
    UNIT_TYPE_MASK        =   $fc0 ;
    FAULT_BIT             =   $020 ;
    COIN_DISPENSER_EVENT  =   $040 ;
    NOTE_DISPENSER_EVENT  =   $080 ;
    COIN_EVENT            =   $0C0 ;
    NOTE_EVENT            =   $100 ;



// The common base codes
    EVENT_OK                            =  0 ; // Internal use only
    EVENT_BUSY                          =  1 ; // Internal use only

    REJECTED                            =  2 ;                                                 
    INHIBITED                           =  3 ;                                                  
    MISREAD                             =  4 ;                                                
    FRAUD                               =  5 ;                                              
    JAM                                 =  6 ;                                            
    JAM_FIXED                           =  7 ;                                                  
    RETURN                              =  8 ;                                               
    OUTPUT_PROBLEM                      =  9 ;                                                       
    OUTPUT_FIXED                        =  10 ;                                                      
    INTERNAL_PROBLEM                   =   11 ;                                                          
    UNKNOWN                            =   12 ;                                                 
    DISPENSE_UPDATE                    =   13 ;                                                        
    UNRECOGNISED                       =   14 ;                                                           
    DISPENSE_PENDING                   =   15 ;
                                             
                                        // Fault codes
    NOW_OK                              = 0 ;
    REPORTED_FAULT                      = 1 ;
    UNIT_TIMEOUT                        = 2 ;
    UNIT_RESET                          = 3 ;
    SELF_TEST_REFUSED                   = 4 ;



// The actual Full Event Codes
    // General
    IMHEI_NULL                          =   0 ;
    IMHEI_INTERFACE_START               =   1 ;
    IMHEI_APPLICATION_START             =   2 ;
    IMHEI_APPLICATION_EXIT              =   3 ;

    IMHEI_OVERFLOW                      = $1f ;


    // Coin Acceptors
    IMHEI_COIN_NOW_OK                   = COIN_EVENT or FAULT_BIT or NOW_OK ;
    IMHEI_COIN_UNIT_REPORTED_FAULT      = COIN_EVENT or FAULT_BIT or REPORTED_FAULT ;
    IMHEI_COIN_UNIT_TIMEOUT             = COIN_EVENT or FAULT_BIT or UNIT_TIMEOUT ;
    IMHEI_COIN_UNIT_RESET               = COIN_EVENT or FAULT_BIT or UNIT_RESET ;
    IMHEI_COIN_SELF_TEST_REFUSED        = COIN_EVENT or FAULT_BIT or SELF_TEST_REFUSED ;


    IMHEI_COIN_REJECT_COIN              = COIN_EVENT or REJECTED ;
    IMHEI_COIN_INHIBITED_COIN           = COIN_EVENT or INHIBITED ;
    IMHEI_COIN_FRAUD_ATTEMPT            = COIN_EVENT or FRAUD ;
    IMHEI_COIN_ACCEPTOR_JAM             = COIN_EVENT or JAM ;
    IMHEI_COIN_COIN_RETURN              = COIN_EVENT or RETURN ;
    IMHEI_COIN_SORTER_JAM               = COIN_EVENT or OUTPUT_PROBLEM ;
    IMHEI_COIN_SORTER_FIXED             = COIN_EVENT or OUTPUT_FIXED ;
    IMHEI_COIN_INTERNAL_PROBLEM         = COIN_EVENT or INTERNAL_PROBLEM ;
    IMHEI_COIN_UNRECOGNISED             = COIN_EVENT or UNRECOGNISED ;
    IMHEI_COIN_UNCLASSIFIED_EVENT       = COIN_EVENT or UNKNOWN ;



    // Note Acceptors
    IMHEI_NOTE_NOW_OK                   = NOTE_EVENT or FAULT_BIT or NOW_OK ;
    IMHEI_NOTE_UNIT_REPORTED_FAULT      = NOTE_EVENT or FAULT_BIT or REPORTED_FAULT ;
    IMHEI_NOTE_UNIT_TIMEOUT             = NOTE_EVENT or FAULT_BIT or UNIT_TIMEOUT ;
    IMHEI_NOTE_UNIT_RESET               = NOTE_EVENT or FAULT_BIT or UNIT_RESET ;
    IMHEI_NOTE_SELF_TEST_REFUSED        = NOTE_EVENT or FAULT_BIT or SELF_TEST_REFUSED ;

    IMHEI_NOTE_REJECT_NOTE              = NOTE_EVENT or REJECTED ;
    IMHEI_NOTE_INHIBITED_NOTE           = NOTE_EVENT or INHIBITED ;
    IMHEI_NOTE_NOTE_MISREAD             = NOTE_EVENT or MISREAD ;
    IMHEI_NOTE_FRAUD_ATTEMPT            = NOTE_EVENT or FRAUD ;
    IMHEI_NOTE_ACCEPTOR_JAM             = NOTE_EVENT or JAM ;
    IMHEI_NOTE_ACCEPTOR_JAM_FIXED       = NOTE_EVENT or JAM_FIXED ;
    IMHEI_NOTE_NOTE_RETURNED            = NOTE_EVENT or RETURN ;
    IMHEI_NOTE_STACKER_PROBLEM          = NOTE_EVENT or OUTPUT_PROBLEM ;
    IMHEI_NOTE_STACKER_FIXED            = NOTE_EVENT or OUTPUT_FIXED ;
    IMHEI_NOTE_INTERNAL_ERROR           = NOTE_EVENT or INTERNAL_PROBLEM ;
    IMHEI_NOTE_UNCLASSIFIED_EVENT       = NOTE_EVENT or UNKNOWN ;

    // Coin Dispenser
    IMHEI_COIN_DISPENSER_NOW_OK            = COIN_DISPENSER_EVENT or FAULT_BIT or NOW_OK ;
    IMHEI_COIN_DISPENSER_REPORTED_FAULT    = COIN_DISPENSER_EVENT or FAULT_BIT or REPORTED_FAULT ;
    IMHEI_COIN_DISPENSER_TIMEOUT           = COIN_DISPENSER_EVENT or FAULT_BIT or UNIT_TIMEOUT ;
    IMHEI_COIN_DISPENSER_RESET             = COIN_DISPENSER_EVENT or FAULT_BIT or UNIT_RESET ;
    IMHEI_COIN_DISPENSER_SELF_TEST_REFUSED = COIN_DISPENSER_EVENT or FAULT_BIT or SELF_TEST_REFUSED ;

    IMHEI_COIN_DISPENSER_FRAUD_ATTEMPT     = COIN_DISPENSER_EVENT or FRAUD ;
    IMHEI_COIN_DISPENSER_UPDATE            = COIN_DISPENSER_EVENT or DISPENSE_UPDATE ;

    // Note Dispenser
    IMHEI_NOTE_DISPENSER_NOW_OK            = NOTE_DISPENSER_EVENT or FAULT_BIT or NOW_OK ;
    IMHEI_NOTE_DISPENSER_REPORTED_FAULT    = NOTE_DISPENSER_EVENT or FAULT_BIT or REPORTED_FAULT ;
    IMHEI_NOTE_DISPENSER_TIMEOUT           = NOTE_DISPENSER_EVENT or FAULT_BIT or UNIT_TIMEOUT ;
    IMHEI_NOTE_DISPENSER_RESET             = NOTE_DISPENSER_EVENT or FAULT_BIT or UNIT_RESET ;
    IMHEI_NOTE_DISPENSER_SELF_TEST_REFUSED = NOTE_DISPENSER_EVENT or FAULT_BIT or SELF_TEST_REFUSED ;

    IMHEI_NOTE_DISPENSER_FRAUD_ATTEMPT     = NOTE_DISPENSER_EVENT or FRAUD ;
    IMHEI_NOTE_DISPENSER_UPDATE            = NOTE_DISPENSER_EVENT or DISPENSE_UPDATE ;
    IMHEI_NOTE_DISPENSER_REJECTED          = NOTE_DISPENSER_EVENT or REJECTED ;
    IMHEI_NOTE_DISPENSER_PENDING           = NOTE_DISPENSER_EVENT or DISPENSE_PENDING ;
    IMHEI_NOTE_DISPENSER_PROBLEM           = NOTE_DISPENSER_EVENT or OUTPUT_PROBLEM ;

Function EventDecode(var Event : Longint) : String ;


Implementation


Function EventDecode(var Event : Longint) : String ;
Begin
    Case Event of
       // General
       IMHEI_NULL                              : EventDecode := 'Null';
       IMHEI_INTERFACE_START                   : EventDecode := 'Interface Start';
       IMHEI_APPLICATION_START                 : EventDecode := 'Application Start';
       IMHEI_APPLICATION_EXIT                  : EventDecode := 'Application Exit';

       IMHEI_OVERFLOW                          : EventDecode := 'Overflow';


       // Coin Acceptors
       IMHEI_COIN_NOW_OK                       : EventDecode := 'Coin: Now Ok';
       IMHEI_COIN_UNIT_REPORTED_FAULT          : EventDecode := 'Coin: Unit Reported Fault';
       IMHEI_COIN_UNIT_TIMEOUT                 : EventDecode := 'Coin: Unit Timeout';
       IMHEI_COIN_UNIT_RESET                   : EventDecode := 'Coin: Unit Reset';
       IMHEI_COIN_SELF_TEST_REFUSED            : EventDecode := 'Coin: Self Test Refused';


       IMHEI_COIN_REJECT_COIN                  : EventDecode := 'Coin: Reject Coin';
       IMHEI_COIN_INHIBITED_COIN               : EventDecode := 'Coin: Inhibited Coin';
       IMHEI_COIN_FRAUD_ATTEMPT                : EventDecode := 'Coin: Fraud Attempt';
       IMHEI_COIN_ACCEPTOR_JAM                 : EventDecode := 'Coin: Acceptor Jam';
       IMHEI_COIN_COIN_RETURN                  : EventDecode := 'Coin: Coin Return';
       IMHEI_COIN_SORTER_JAM                   : EventDecode := 'Coin: Sorter Jam';
       IMHEI_COIN_SORTER_FIXED                 : EventDecode := 'Coin: Sorter Fixed';
       IMHEI_COIN_INTERNAL_PROBLEM             : EventDecode := 'Coin: Internal Problem';
       IMHEI_COIN_UNRECOGNISED                 : EventDecode := 'Coin: Unrecognised Coin';
       IMHEI_COIN_UNCLASSIFIED_EVENT           : EventDecode := 'Coin: Unclassified Event';



       // Note Acceptors
       IMHEI_NOTE_NOW_OK                       : EventDecode := 'Note: Now Ok';
       IMHEI_NOTE_UNIT_REPORTED_FAULT          : EventDecode := 'Note: Unit Reported Fault';
       IMHEI_NOTE_UNIT_TIMEOUT                 : EventDecode := 'Note: Unit Timeout';
       IMHEI_NOTE_UNIT_RESET                   : EventDecode := 'Note: Unit Reset';
       IMHEI_NOTE_SELF_TEST_REFUSED            : EventDecode := 'Note: Self Test Refused';

       IMHEI_NOTE_REJECT_NOTE                  : EventDecode := 'Note: Reject Note';
       IMHEI_NOTE_INHIBITED_NOTE               : EventDecode := 'Note: Inhibited Note';
       IMHEI_NOTE_NOTE_MISREAD                 : EventDecode := 'Note: Note Misread';
       IMHEI_NOTE_FRAUD_ATTEMPT                : EventDecode := 'Note: Fraud Attempt';
       IMHEI_NOTE_ACCEPTOR_JAM                 : EventDecode := 'Note: Acceptor Jam';
       IMHEI_NOTE_ACCEPTOR_JAM_FIXED           : EventDecode := 'Note: Acceptor Jam Fixed';
       IMHEI_NOTE_NOTE_RETURNED                : EventDecode := 'Note: Note Returned';
       IMHEI_NOTE_STACKER_PROBLEM              : EventDecode := 'Note: Stacker Problem';
       IMHEI_NOTE_STACKER_FIXED                : EventDecode := 'Note: Stacker Fixed';
       IMHEI_NOTE_INTERNAL_ERROR               : EventDecode := 'Note: Internal Error';
       IMHEI_NOTE_UNCLASSIFIED_EVENT           : EventDecode := 'Note: Unclassified Event';

    // Coin Dispenser
    IMHEI_COIN_DISPENSER_NOW_OK                : EventDecode := 'Hopper: Now OK' ;
    IMHEI_COIN_DISPENSER_REPORTED_FAULT        : EventDecode := 'Hopper: Unit Reported Fault';
    IMHEI_COIN_DISPENSER_TIMEOUT               : EventDecode := 'Hopper: Unit Timeout';
    IMHEI_COIN_DISPENSER_RESET                 : EventDecode := 'Hopper: Unit Reset';
    IMHEI_COIN_DISPENSER_SELF_TEST_REFUSED     : EventDecode := 'Hopper: Self Test Refused';

    IMHEI_COIN_DISPENSER_FRAUD_ATTEMPT         : EventDecode := 'Hopper: Fraud Attempt';
    IMHEI_COIN_DISPENSER_UPDATE                : EventDecode := 'Hopper: Level Updated';

    // Note Dispenser
    IMHEI_NOTE_DISPENSER_NOW_OK                : EventDecode := 'Note Disp: Now OK' ;
    IMHEI_NOTE_DISPENSER_REPORTED_FAULT        : EventDecode := 'Note Disp: Unit Reported Fault';
    IMHEI_NOTE_DISPENSER_TIMEOUT               : EventDecode := 'Note Disp: Unit Timeout';
    IMHEI_NOTE_DISPENSER_RESET                 : EventDecode := 'Note Disp: Unit Reset';
    IMHEI_NOTE_DISPENSER_SELF_TEST_REFUSED     : EventDecode := 'Note Disp: Self Test Refused';

    IMHEI_NOTE_DISPENSER_FRAUD_ATTEMPT         : EventDecode := 'Note Disp: Fraud Attempt';
    IMHEI_NOTE_DISPENSER_UPDATE                : EventDecode := 'Note Disp: Level Updated';
    IMHEI_NOTE_DISPENSER_REJECTED              : EventDecode := 'Note Disp: Note(s) not paid out' ;
    IMHEI_NOTE_DISPENSER_PENDING               : EventDecode := 'Note Disp: Note(s) pending' ;
    IMHEI_NOTE_DISPENSER_PROBLEM               : EventDecode := 'Note Disp: Jammed on payout' ;
       else                                      EventDecode := 'Unknown Message Code' ;
    end;
end;

end.
