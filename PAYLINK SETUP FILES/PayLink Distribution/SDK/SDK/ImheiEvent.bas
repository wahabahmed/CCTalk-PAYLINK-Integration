Attribute VB_Name                                               = "ImheiEvent"
'***************************************************************
'
'Definitions for events provided by the Aardvark Embedded Solutions
'Intelligent Money Handling Equipment Interface
'
'****************************************************************/


'**************************************************************
'Event codes have an internal structure, allowing cateogizations.
'The bottom 6 bits are the unique code for the event,
'serious fault related codes have bit 5 set.
'Above this are bits describing the type of unit affected.
'***************************************************************

' Values to allow this categoisation to be acheived

Public Const EVENT_CODE_MASK        = &H3F
Public Const UNIT_TYPE_MASK         = &HFC0
Public Const FAULT_BIT              = &H20
Public Const COIN_DISPENSER_EVENT   = &H40
Public Const NOTE_DISPENSER_EVENT   = &H80
Public Const COIN_EVENT             = &HC0
Public Const NOTE_EVENT             = &H100

    
    
           ' The common base codes
Public Const EVENT_OK          = 0                           ' Internal use only
Public Const EVENT_BUSY        = 1                           ' Internal use only

Public Const REJECTED          = 2
Public Const INHIBITED         = 3
Public Const MISREAD           = 4
Public Const FRAUD             = 5
Public Const JAM               = 6
Public Const JAM_FIXED         = 7
Public Const RETURN            = 8
Public Const OUTPUT_PROBLEM    = 9
Public Const OUTPUT_FIXED      = 10
Public Const INTERNAL_PROBLEM  = 11
Public Const UNKNOWN           = 12
Public Const DISPENSE_UPDATE   = 13
Public Const UNRECOGNISED      = 14                                                           
Public Const DISPENSE_PENDING  = 15
                                             
                               ' Fault codes
Public Const NOW_OK            = 0
Public Const REPORTED_FAULT    = 1
Public Const UNIT_TIMEOUT      = 2
Public Const UNIT_RESET        = 3
Public Const SELF_TEST_REFUSED = 4



' The actual Full Event Codes
    ' General
Public Const IMHEI_NULL                      = 0
Public Const IMHEI_INTERFACE_START           = 1
Public Const IMHEI_APPICATION_START          = 2
Public Const IMHEI_APPICATION_EXIT           = 3

Public Const IMHEI_OVERFLOW                  = &H1F



Public Const IMHEI_COIN_NOW_OK               = COIN_EVENT Or FAULT_BIT Or NOW_OK
Public Const IMHEI_COIN_UNIT_REPORTED_FAULT  = COIN_EVENT Or FAULT_BIT Or REPORTED_FAULT
Public Const IMHEI_COIN_UNIT_TIMEOUT         = COIN_EVENT Or FAULT_BIT Or UNIT_TIMEOUT
Public Const IMHEI_COIN_UNIT_RESET           = COIN_EVENT Or FAULT_BIT Or UNIT_RESET
Public Const IMHEI_COIN_SELF_TEST_REFUSED    = COIN_EVENT Or FAULT_BIT Or SELF_TEST_REFUSED


Public Const IMHEI_COIN_REJECT_COIN          = COIN_EVENT Or REJECTED
Public Const IMHEI_COIN_INHIBITED_COIN       = COIN_EVENT Or INHIBITED
Public Const IMHEI_COIN_FRAUD_ATTEMPT        = COIN_EVENT Or FRAUD
Public Const IMHEI_COIN_ACCEPTOR_JAM         = COIN_EVENT Or JAM
Public Const IMHEI_COIN_COIN_RETURN          = COIN_EVENT Or RETURN_CODE
Public Const IMHEI_COIN_SORTER_JAM           = COIN_EVENT Or OUTPUT_PROBLEM
Public Const IMHEI_COIN_SORTER_FIXED         = COIN_EVENT Or OUTPUT_FIXED
Public Const IMHEI_COIN_INTERNAL_PROBLEM     = COIN_EVENT Or INTERNAL_PROBLEM
Public Const IMHEI_COIN_UNCLASSIFIED_EVENT   = COIN_EVENT Or UNKNOWN



    ' Note Acceptors
Public Const IMHEI_NOTE_NOW_OK               = NOTE_EVENT Or FAULT_BIT Or NOW_OK
Public Const IMHEI_NOTE_UNIT_REPORTED_FAULT  = NOTE_EVENT Or FAULT_BIT Or REPORTED_FAULT
Public Const IMHEI_NOTE_UNIT_TIMEOUT         = NOTE_EVENT Or FAULT_BIT Or UNIT_TIMEOUT
Public Const IMHEI_NOTE_UNIT_RESET           = NOTE_EVENT Or FAULT_BIT Or UNIT_RESET
Public Const IMHEI_NOTE_SELF_TEST_REFUSED    = NOTE_EVENT Or FAULT_BIT Or SELF_TEST_REFUSED

Public Const IMHEI_NOTE_REJECT_NOTE          = NOTE_EVENT Or REJECTED
Public Const IMHEI_NOTE_INHIBITED_NOTE       = NOTE_EVENT Or INHIBITED
Public Const IMHEI_NOTE_NOTE_MISREAD         = NOTE_EVENT Or MISREAD
Public Const IMHEI_NOTE_FRAUD_ATTEMPT        = NOTE_EVENT Or FRAUD
Public Const IMHEI_NOTE_ACCEPTOR_JAM         = NOTE_EVENT Or JAM
Public Const IMHEI_NOTE_ACCEPTOR_JAM_FIXED   = NOTE_EVENT Or JAM_FIXED
Public Const IMHEI_NOTE_NOTE_RETURNED        = NOTE_EVENT Or RETURN_CODE
Public Const IMHEI_NOTE_STACKER_PROBLEM      = NOTE_EVENT Or OUTPUT_PROBLEM
Public Const IMHEI_NOTE_STACKER_FIXED        = NOTE_EVENT Or OUTPUT_FIXED
Public Const IMHEI_NOTE_INTERNAL_ERROR       = NOTE_EVENT Or INTERNAL_PROBLEM
Public Const IMHEI_NOTE_UNCLASSIFIED_EVENT   = NOTE_EVENT Or UNKNOWN

    ' Coin Dispenser
Public Const IMHEI_COIN_DISPENSER_NOW_OK            = COIN_DISPENSER_EVENT Or FAULT_BIT Or NOW_OK
Public Const IMHEI_COIN_DISPENSER_REPORTED_FAULT    = COIN_DISPENSER_EVENT Or FAULT_BIT Or REPORTED_FAULT
Public Const IMHEI_COIN_DISPENSER_TIMEOUT           = COIN_DISPENSER_EVENT Or FAULT_BIT Or UNIT_TIMEOUT
Public Const IMHEI_COIN_DISPENSER_RESET             = COIN_DISPENSER_EVENT Or FAULT_BIT Or UNIT_RESET
Public Const IMHEI_COIN_DISPENSER_SELF_TEST_REFUSED = COIN_DISPENSER_EVENT Or FAULT_BIT Or SELF_TEST_REFUSED

Public Const IMHEI_COIN_DISPENSER_FRAUD_ATTEMPT     = COIN_DISPENSER_EVENT Or FRAUD
Public Const IMHEI_COIN_DISPENSER_UPDATE            = COIN_DISPENSER_EVENT Or DISPENSE_UPDATE

    ' Note Dispenser
Public Const IMHEI_NOTE_DISPENSER_NOW_OK            = NOTE_DISPENSER_EVENT Or FAULT_BIT Or NOW_OK
Public Const IMHEI_NOTE_DISPENSER_REPORTED_FAULT    = NOTE_DISPENSER_EVENT Or FAULT_BIT Or REPORTED_FAULT
Public Const IMHEI_NOTE_DISPENSER_TIMEOUT           = NOTE_DISPENSER_EVENT Or FAULT_BIT Or UNIT_TIMEOUT
Public Const IMHEI_NOTE_DISPENSER_RESET             = NOTE_DISPENSER_EVENT Or FAULT_BIT Or UNIT_RESET
Public Const IMHEI_NOTE_DISPENSER_SELF_TEST_REFUSED = NOTE_DISPENSER_EVENT Or FAULT_BIT Or SELF_TEST_REFUSED

Public Const IMHEI_NOTE_DISPENSER_FRAUD_ATTEMPT     = NOTE_DISPENSER_EVENT Or FRAUD
Public Const IMHEI_NOTE_DISPENSER_UPDATE            = NOTE_DISPENSER_EVENT Or DISPENSE_UPDATE
Public Const IMHEI_NOTE_DISPENSER_REJECTED          = NOTE_DISPENSER_EVENT Or REJECTED
Public Const IMHEI_NOTE_DISPENSER_PENDING           = NOTE_DISPENSER_EVENT Or DISPENSE_PENDING
