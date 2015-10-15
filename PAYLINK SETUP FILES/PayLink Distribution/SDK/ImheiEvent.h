/***************************************************************

Definitions for events provided by the Aardvark Embedded Solutions
Intelligent Money Handling Equipment Interface

****************************************************************/
#ifndef __IMHEIEVENT_H
#define __IMHEIEVENT_H

/**************************************************************
Event codes have an internal structure, allowing cateogizations.
The bottom 6 bits are the unique code for the event,
serious fault related codes have bit 5 set.
Above this are bits describing the type of unit affected.
***************************************************************/

/* enums to allow this categoisation to be acheived */
enum
    {
    EVENT_CODE_MASK       =   0x03f,
    UNIT_TYPE_MASK        =  ~0x03f,
    FAULT_BIT             =   0x020,
    COIN_DISPENSER_EVENT  =   0x040,
    NOTE_DISPENSER_EVENT  =   0x080,
    COIN_EVENT            =   0x0C0,
    NOTE_EVENT            =   0x100
    } ;



/* The common base codes */
enum
    {
    EVENT_OK,           /* Internal use only */
    EVENT_BUSY,         /* Internal use only */

    REJECTED,
    INHIBITED,
    MISREAD,
    FRAUD,
    JAM,
    JAM_FIXED,
    RETURN,
    OUTPUT_PROBLEM,
    OUTPUT_FIXED,
    INTERNAL_PROBLEM,
    UNKNOWN,
    DISPENSE_UPDATE,
    UNRECOGNISED,
    DISPENSE_PENDING,

                        /* Fault codes */
    NOW_OK = 0,
    REPORTED_FAULT,
    UNIT_TIMEOUT,
    UNIT_RESET,
    SELF_TEST_REFUSED
    } ;



/* The actual Full Event Codes */
enum
    {
    /* General */
    IMHEI_NULL                          =   0,
    IMHEI_INTERFACE_START               =   1,
    IMHEI_APPLICATION_START             =   2,
    IMHEI_APPLICATION_EXIT              =   3,

    IMHEI_OVERFLOW                      = 0x1f,


    /* Coin Acceptors */
    IMHEI_COIN_NOW_OK                   = COIN_EVENT | FAULT_BIT | NOW_OK,
    IMHEI_COIN_UNIT_REPORTED_FAULT      = COIN_EVENT | FAULT_BIT | REPORTED_FAULT,
    IMHEI_COIN_UNIT_TIMEOUT             = COIN_EVENT | FAULT_BIT | UNIT_TIMEOUT,
    IMHEI_COIN_UNIT_RESET               = COIN_EVENT | FAULT_BIT | UNIT_RESET,
    IMHEI_COIN_SELF_TEST_REFUSED        = COIN_EVENT | FAULT_BIT | SELF_TEST_REFUSED,


    IMHEI_COIN_REJECT_COIN              = COIN_EVENT | REJECTED,
    IMHEI_COIN_INHIBITED_COIN           = COIN_EVENT | INHIBITED,
    IMHEI_COIN_FRAUD_ATTEMPT            = COIN_EVENT | FRAUD,
    IMHEI_COIN_ACCEPTOR_JAM             = COIN_EVENT | JAM,
    IMHEI_COIN_COIN_RETURN              = COIN_EVENT | RETURN,
    IMHEI_COIN_SORTER_JAM               = COIN_EVENT | OUTPUT_PROBLEM,
    IMHEI_COIN_SORTER_FIXED             = COIN_EVENT | OUTPUT_FIXED,
    IMHEI_COIN_INTERNAL_PROBLEM         = COIN_EVENT | INTERNAL_PROBLEM,
    IMHEI_COIN_UNRECOGNISED             = COIN_EVENT | UNRECOGNISED,
    IMHEI_COIN_UNCLASSIFIED_EVENT       = COIN_EVENT | UNKNOWN,



    /* Note Acceptors */
    IMHEI_NOTE_NOW_OK                   = NOTE_EVENT | FAULT_BIT | NOW_OK,
    IMHEI_NOTE_UNIT_REPORTED_FAULT      = NOTE_EVENT | FAULT_BIT | REPORTED_FAULT,
    IMHEI_NOTE_UNIT_TIMEOUT             = NOTE_EVENT | FAULT_BIT | UNIT_TIMEOUT,
    IMHEI_NOTE_UNIT_RESET               = NOTE_EVENT | FAULT_BIT | UNIT_RESET,
    IMHEI_NOTE_SELF_TEST_REFUSED        = NOTE_EVENT | FAULT_BIT | SELF_TEST_REFUSED,

    IMHEI_NOTE_REJECT_NOTE              = NOTE_EVENT | REJECTED,
    IMHEI_NOTE_INHIBITED_NOTE           = NOTE_EVENT | INHIBITED,
    IMHEI_NOTE_NOTE_MISREAD             = NOTE_EVENT | MISREAD,
    IMHEI_NOTE_FRAUD_ATTEMPT            = NOTE_EVENT | FRAUD,
    IMHEI_NOTE_ACCEPTOR_JAM             = NOTE_EVENT | JAM,
    IMHEI_NOTE_ACCEPTOR_JAM_FIXED       = NOTE_EVENT | JAM_FIXED,
    IMHEI_NOTE_NOTE_RETURNED            = NOTE_EVENT | RETURN,
    IMHEI_NOTE_STACKER_PROBLEM          = NOTE_EVENT | OUTPUT_PROBLEM,
    IMHEI_NOTE_STACKER_FIXED            = NOTE_EVENT | OUTPUT_FIXED,
    IMHEI_NOTE_INTERNAL_ERROR           = NOTE_EVENT | INTERNAL_PROBLEM,
    IMHEI_NOTE_UNCLASSIFIED_EVENT       = NOTE_EVENT | UNKNOWN,

    /* Coin Dispenser */
    IMHEI_COIN_DISPENSER_NOW_OK            = COIN_DISPENSER_EVENT | FAULT_BIT | NOW_OK,
    IMHEI_COIN_DISPENSER_REPORTED_FAULT    = COIN_DISPENSER_EVENT | FAULT_BIT | REPORTED_FAULT,
    IMHEI_COIN_DISPENSER_TIMEOUT           = COIN_DISPENSER_EVENT | FAULT_BIT | UNIT_TIMEOUT,
    IMHEI_COIN_DISPENSER_RESET             = COIN_DISPENSER_EVENT | FAULT_BIT | UNIT_RESET,
    IMHEI_COIN_DISPENSER_SELF_TEST_REFUSED = COIN_DISPENSER_EVENT | FAULT_BIT | SELF_TEST_REFUSED,

    IMHEI_COIN_DISPENSER_FRAUD_ATTEMPT     = COIN_DISPENSER_EVENT | FRAUD,
    IMHEI_COIN_DISPENSER_UPDATE            = COIN_DISPENSER_EVENT | DISPENSE_UPDATE,

    /* Note Dispenser */
    IMHEI_NOTE_DISPENSER_NOW_OK            = NOTE_DISPENSER_EVENT | FAULT_BIT | NOW_OK,
    IMHEI_NOTE_DISPENSER_REPORTED_FAULT    = NOTE_DISPENSER_EVENT | FAULT_BIT | REPORTED_FAULT,
    IMHEI_NOTE_DISPENSER_TIMEOUT           = NOTE_DISPENSER_EVENT | FAULT_BIT | UNIT_TIMEOUT,
    IMHEI_NOTE_DISPENSER_RESET             = NOTE_DISPENSER_EVENT | FAULT_BIT | UNIT_RESET,
    IMHEI_NOTE_DISPENSER_SELF_TEST_REFUSED = NOTE_DISPENSER_EVENT | FAULT_BIT | SELF_TEST_REFUSED,

    IMHEI_NOTE_DISPENSER_FRAUD_ATTEMPT     = NOTE_DISPENSER_EVENT | FRAUD,
    IMHEI_NOTE_DISPENSER_UPDATE            = NOTE_DISPENSER_EVENT | DISPENSE_UPDATE,
    IMHEI_NOTE_DISPENSER_REJECTED          = NOTE_DISPENSER_EVENT | REJECTED,
    IMHEI_NOTE_DISPENSER_PENDING           = NOTE_DISPENSER_EVENT | DISPENSE_PENDING,
    IMHEI_NOTE_DISPENSER_PROBLEM           = NOTE_DISPENSER_EVENT | OUTPUT_PROBLEM
    } ;


#endif
