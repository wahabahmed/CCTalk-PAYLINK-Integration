unit aesimhei;

interface

{****************************************************************
Delphi Program Structures and Constants
****************************************************************}
 const
    ORIGINAL_VERSION   = $10001 ;
    DISPENSER_UPDATE   = $10002 ;
    STRINGS_RETURNED   = $10005 ;
    BARCODE_ACCEPTOR   = $10006 ;
    INTERFACE_VERSION  = BARCODE_ACCEPTOR ;

    SYSTEM_MASK        = $f0000000 ;
    INTERFACE_FAILED   = $80000000 ;

    DISPENSER_MASK     = $0fff0000 ;

    ACCEPTOR_MASK      = $0000ffff ;


    ACCEPTOR_DEAD      = $00000001 ;   // No response to communications for this device
//  ACCEPTOR_ALL_DEAD  = $00000002 ;   // No response from any device on this connection
    ACCEPTOR_DISABLED  = $00000004 ;   // Disabled by Interface
    ACCEPTOR_INHIBIT   = $00000008 ;   // Specific by Application
    ACCEPTOR_FRAUD     = $00000010 ;   // Reported from device
    ACCEPTOR_BUSY      = $00000020 ;   // Reported from device
    ACCEPTOR_FAULT     = $00000040 ;   // Reported from device
    ACCEPTOR_NO_KEY    = $00000080 ;   // Reported from device

    MAX_ACCEPTOR_COINS = 256 ;         // Maximum coins or notes
                                       // handled by any device




Type
  TAcceptorCoin = record
    Value          : LongInt ;      // Value of this coin
    Inhibit        : LongInt ;      // Set by PC: this coin is inhibited
    Count          : LongInt ;      // Total number read "ever"
    Path           : LongInt ;      // Set by PC: this coin's chosen output path
    PathCount      : LongInt ;      // Number "ever" sent down the chosen Path
    PathSwitchLevel: LongInt ;      // Set by PC: PathCount level to switch coin to default path
    DefaultPath    : Byte    ;      // Set by PC: Default path for this specific coin
    FutureExpansion: Byte    ;      // Set by PC: for future use
    HeldInEscrow   : Byte    ;      // count of this note / coin in escrow (usually max 1)
    FutureExpansion2 : Byte  ;
    CoinName       : PAnsiChar ;    // The string, usually as returned from the acceptor, describing this coin
  end ;

Type
  TAcceptorBlock = record
    UnitType          : LongInt  ;     // Specification of this unit
    Status            : LongInt ;      // AcceptorStatuses - zero if device OK
    NoOfCoins         : LongInt ;      // The number of different coins handled
    InterfaceNumber   : LongInt ;      // The bus / connection
    UnitAddress       : LongInt ;      // For addressable units
    DefaultPath       : LongInt ;
    BarcodesStacked   : LongInt ;      // The total number of barcode tickets stacked by this acceptor
    Currency          : array [0..3] of AnsiChar ;      // Main currency code reported
                                       // by an intelligent acceptor
    Coin              : Array[0..MAX_ACCEPTOR_COINS - 1] of TAcceptorCoin ;
                                       // (only NoOfCoins are set up)
    SerialNumber      : LongInt ;      // Reported serial number
    Description       : PAnsiChar ;    // Device specific string for type / revision / coin set
    EscrowBarcodeHere : LongInt ;      // If this is non zero, then the barcode reported by BarcodeInEscrow is from this acceptor
 end ;



const
    MAX_DISPENSERS         = 16 ;        // Maximum handled

                // Coin Count Status Values
    DISPENSER_COIN_NONE     = 0 ;         // No dispenser coin reporting
    DISPENSER_COIN_LOW      = 1 ;         // Less than the low sensor level
    DISPENSER_COIN_MID      = 2 ;         // Above low sensor but below high
    DISPENSER_COIN_HIGH     = 3 ;         // High sensor level reported

    DISPENSER_ACCURATE      = -1 ;        // Coin Count reported by Dispenser
    DISPENSER_ACCURATE_FULL = -2 ;        // Coin Count as reported by Dispenser,
                                          //  is over limit.
    DISPENSER_REASSIGN_VALUE   = 100 ;    // The Value has just been updated by the application
    DISPENSER_VALUE_REASSIGNED = 101 ;    // The updated Value has just been accepted by the IMHEI

    DISPENSER_CASHBOX_DUMP   = 120 ;      // Dump the hopper if you can
    DISPENSER_PARTIAL_DUMP   = 121 ;      // Dump some of the hopper if you can
    DISPENSER_DUMP_FINISHED  = 122 ;      // recycler dump has just complete 
    
Type
  TDispenserBlock = record
    UnitType        : LongInt ;        // Specification of this unit
    Status          : LongInt ;        // Individual Dispenser status
                                       // This takes the same values as PayStatus()
    InterfaceNumber : LongInt ;        // The bus / connection
    UnitAddress     : LongInt ;        // For addressable units
    Value           : LongInt ;        // The value of the coins in this dispensor
    Count           : LongInt ;        // Number dispensed since interface commissioned
    Inhibit         : LongInt ;        // Set to 1 to inhibit Dispenser
    NotesToDump     : LongInt ;        // Only read by Paylink in conjunction with DISPENSER_PARTIAL_DUMP
                                       // an intelligent dispenser
    CoinCount       : LongInt ;        // The number of coins in the dispenser
    CoinCountStatus : LongInt ;        // Flags Relating to Coin Count (See above)
    SerialNumber   : LongInt ;         // Reported serial number
    Description    : PAnsiChar ;       // Device specific string for type / revision / coin set
  end ;                                // an intelligent dispenser
          




{*************************************************************
Device Identity Constants

These constants are ORed together to form the coded device
identity that can be extracted from the interface.

Example

As an example ; a Money Controls Serial Compact Hopper 2 will
have the following device code DP_MCL_SCH2 ; made up from:

· A device specifc code         ORed with
· DP_COIN_PAYOUT_DEVICE         ORed with
· DP_CCTALK_INTERFACE           ORed with
· DP_MANU_MONEY_CONTROLS        ORed with

This is a device code of        $01020101
*************************************************************}
 const
    DP_GENERIC_MASK               =  $ff000000 ;

    DP_COIN_ACCEPT_DEVICE         =  $02000000 ;
    DP_NOTE_ACCEPT_DEVICE         =  $12000000 ;
    DP_CARD_ACCEPT_DEVICE         =  $22000000 ;

    DP_COIN_PAYOUT_DEVICE         =  $01000000 ;
    DP_NOTE_PAYOUT_DEVICE         =  $11000000 ;
    DP_CARD_PAYOUT_DEVICE         =  $21000000 ;

         // These describe the interface via which this device is connected:
    DP_INTERFACE_MASK             =  $00ff0000 ;
    DP_INTERFACE_UNIT             =  $00000000 ;
    DP_ONBOARD_PARALLEL_INTERFACE =  $00010000 ;
    DP_CCTALK_INTERFACE           =  $00020000 ;
    DP_SSP_INTERFACE              =  $00030000 ;
    DP_HII_INTERFACE              =  $00040000 ;
    DP_ARDAC_INTERFACE            =  $00050000 ;
    DP_JCM_INTERFACE              =  $00060000 ;
    DP_GPT_INTERFACE              =  $00070000 ;
    DP_MDB_INTERFACE              =  $00080000 ;
    DP_MDB_LEVEL_3_INTERFACE      =  $00080000 ;
    DP_MDB_LEVEL_2_INTERFACE      =  $00090000 ;
    DP_F56_INTERFACE              =  $000A0000 ;
    DP_CCNET_INTERFACE            =  $000B0000 ;


    // Some Generic Identities
    DP_ID003_NOTE                 =  0 or DP_JCM_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_ID003_RECYCLER             =  2 or DP_JCM_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_ID003_BOX                  =  2 or DP_JCM_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_MDB_LEVEL_2                =  0 or DP_MDB_LEVEL_2_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MDB_LEVEL_3                =  0 or DP_MDB_LEVEL_3_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MDB_LEVEL_2_TUBE           =  0 or DP_MDB_LEVEL_2_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MDB_TYPE_3_PAYOUT          =  0 or DP_MDB_LEVEL_3_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MDB_BILL                   =  0 or DP_MDB_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_CC_GHOST_HOPPER          =  255 or DP_CCTALK_INTERFACE        // Used by Value hopperz
                                       or DP_COIN_PAYOUT_DEVICE ;

                               // These describe the manufacturer of the device.
    DP_MANUFACTURER_MASK          =  $0000ff00 ;
    DP_MANU_UNKNOWN               =  $00000000 ;
    DP_MANU_MONEY_CONTROLS        =  $00000100 ;
    DP_MANU_INNOVATIVE_TECH       =  $00000200 ;
    DP_MANU_MARS_ELECTRONICS      =  $00000300 ;
    DP_MANU_AZKOYEN               =  $00000400 ;
    DP_MANU_NRI                   =  $00000500 ;
    DP_MANU_ICT                   =  $00000600 ;
    DP_MANU_JCM                   =  $00000700 ;
    DP_MANU_GPT                   =  $00000800 ;
    DP_MANU_COINCO                =  $00000900 ;
    DP_MANU_ASAHI_SEIKO           =  $00000A00 ;
    DP_MANU_ASTROSYSTEMS          =  $00000B00 ;
    DP_MANU_MERKUR                =  $00000C00 ;
    DP_MANU_FUJITSU               =  $00000D00 ;
    DP_MANU_CASHCODE              =  $00000E00 ;
    DP_MANU_MFS                   =  $00000F00 ;

                               // These device types are manufacturer-dependent ;
            //       so that each manufacturer can have up to 255 known devices.
    DP_SPECIFIC_DEVICE_MASK       =  $000000ff ;

                                                     // Money Controls Devices
    DP_MCL_SCH2                   =  1 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MCL_SUH1                   =  2 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MCL_SCH3A                  =  3 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MCL_SCH3                   =  4 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MCL_SUH5                   =  5 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MCL_SCH5                   =  6 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MCL_BCR_HOPPER             =  7 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;


    DP_MCL_CR100_HOPPER           =  8 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;


    DP_MCL_NR2_HOPPER             = 10 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_MCL_SR3                    =  2 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MCL_SR5                    =  3 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MCL_CONDOR                 =  6 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MCL_BCR                    =  7 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MCL_CR100                  =  8 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MCL_BCS                    =  9 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MCL_NR2                    = 10 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MCL_LUMINA                 =  5 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_MCL_7200                   =  6 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_MCL_ARDAC_ELITE            =  7 or DP_MANU_MONEY_CONTROLS
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;




    DP_MCL_WACS                   =  1 or DP_MANU_MONEY_CONTROLS
                                       or DP_ARDAC_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;



    DP_MCL_ARDAC                  =  1 or DP_MANU_MONEY_CONTROLS
                                       or DP_JCM_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;


                                                     // Coin Co Devices
    DP_COINCO_MDB                 =       DP_MANU_COINCO
                                       or DP_MDB_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_COINCO_VORTEX              =  1 or DP_MANU_COINCO
                                       or DP_MDB_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_COINCO_GLOBAL              =  2 or DP_MANU_COINCO
                                       or DP_MDB_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_COINCO_MDB_BILL            =      DP_MANU_COINCO
                                       or DP_MDB_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_COINCO_BILLPRO             =  1 or DP_MANU_COINCO
                                       or DP_MDB_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

                                                    // Azcoin Devices
    DP_AZK_HOPPER                 =       DP_MANU_AZKOYEN
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_AZK_HOPPER_U               =  1 or DP_MANU_AZKOYEN
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_AZK_HOPPER_UPL             =  2 or DP_MANU_AZKOYEN
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_AZK_MDB                    =       DP_MANU_AZKOYEN
                                       or DP_MDB_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_AZK_A6                     =       DP_MANU_AZKOYEN
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;


                                                     // Mars Electronics Devices
    DP_MARS_CASHFLOW_126          =  1 or DP_MANU_MARS_ELECTRONICS
                                       or DP_HII_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MARS_CASHFLOW_9500         =  2 or DP_MANU_MARS_ELECTRONICS
                                       or DP_HII_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MARS_MDB                   =       DP_MANU_MARS_ELECTRONICS
                                       or DP_MDB_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_MARS_CASHFLOW_690          =  1 or DP_MANU_MARS_ELECTRONICS
                                       or DP_MDB_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

                                                     // Innovative Devices
    DP_INNOV_NV4                  =  4 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_INNOV_NV7                  =  7 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_INNOV_NV8                  =  8 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_INNOV_NV9                 =   9 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_INNOV_NV10                =  10 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_INNOV_NV200               =  11 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_SHOPPER_ACCEPT            =  12 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_INNOV_NV200_NOTE          =   1 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_INNOV_NV11                =   2 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_INNOV_NV11_RC             =   2 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_SHOPPER_TOTAL             =   3 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

    DP_SHOPPER                   =   4 or DP_MANU_INNOVATIVE_TECH
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;


                                                     // NRI Devices
    DP_NRI_G40                    =  1 or DP_MANU_NRI
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_NRI_PELICANO               =  2 or DP_MANU_NRI
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_ACCEPT_DEVICE ;

    DP_NRI_CURRENZA_H2            =  1 or DP_MANU_NRI
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;

                                                     // ICT Devices
    DP_ICT_U85                    =  1 or DP_MANU_ICT
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

                                                     // AstroSystems Devices
    DP_AST_GBA                    =  1 or DP_MANU_ASTROSYSTEMS
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

                                                     // JCM Devices
    DP_JCM_CC_EBA                 =  0 or  DP_MANU_JCM
                                       or  DP_CCTALK_INTERFACE            // ON cctalk interface
                                       or  DP_NOTE_ACCEPT_DEVICE ;

    DP_JCM_CC_WBA                 =  1 or  DP_MANU_JCM
                                       or  DP_CCTALK_INTERFACE
                                       or  DP_NOTE_ACCEPT_DEVICE ;

    DP_JCM_VEGA                   =  2 or DP_MANU_JCM
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_JCM_VEGA_RC                =  2 or DP_MANU_JCM
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;
    DP_JCM_NOTE                   =  0 or DP_MANU_JCM
                                       or DP_JCM_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;


                                                     // GPT Devices
    DP_GPT_NOTE                   =  0 or DP_MANU_GPT
                                       or DP_GPT_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;


                                                    // Asahi Seiko Devices
    DP_AS_WH2                     =  0 or DP_MANU_ASAHI_SEIKO
                                       or DP_CCTALK_INTERFACE
                                       or DP_COIN_PAYOUT_DEVICE ;


    DP_MERKUR_100                 =  1 or DP_MANU_MERKUR
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_MERKUR_100_PAY             =  1 or DP_MANU_MERKUR
                                       or DP_CCTALK_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_FUJITSU_F56                =  6 or DP_MANU_FUJITSU
                                       or DP_F56_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_FUJITSU_F53                =  3 or DP_MANU_FUJITSU
                                       or DP_F56_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_FUJITSU_F400               =  4 or DP_MANU_FUJITSU
                                       or DP_F56_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_CDM_4000                   =  1 or DP_MANU_MFS
                                       or DP_F56_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;

    DP_CC_RECYCLER                =  1 or DP_MANU_CASHCODE
                                       or DP_CCNET_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_CC_ACCEPTOR                =  2 or DP_MANU_CASHCODE
                                       or DP_CCNET_INTERFACE
                                       or DP_NOTE_ACCEPT_DEVICE ;

    DP_CC_CASSETTE                =  1 or DP_MANU_CASHCODE
                                       or DP_CCNET_INTERFACE
                                       or DP_NOTE_PAYOUT_DEVICE ;









{****************************************************************
The OpenMHE call is made by the PC application software to open the
"Money Handling Equipment" Interface.

Parameters
None

Return Value
If the Open call succeeds then the value zero is returned.

In the event of a failure an error code will be returned ;
either as a direct echo of a Windows API call failure ;
or to indicate internally detected failures that closely
correspond to the quoted meanings.
****************************************************************}
Function OpenMHE : LongInt ;
Function OpenMHEVersion(InterfaceVersion : LongInt )
                               : LongInt ; stdcall ; external 'Aesimhei.dll' name '_OpenMHEVersion@4' ;

{****************************************************************
The OpenSpecificMHE call is made by the PC application software
to open a "Money Handling Equipment" Interface with a specific
serial number.

Parameters
Alphanumeric

Return Value
If the Open call succeeds then the value zero is returned.

In the event of a failure an error code will be returned,
either as a direct echo of a Windows API call failure,
or to indicate internally detected failures that closely
correspond to the quoted meanings.
****************************************************************}
Function OpenSpecificMHE(SerialNumber : PAnsiChar) : LongInt ;
Function OpenSpecificMHEVersion(SerialNumber : PAnsiChar ; InterfaceVersion : LongInt)
                               : LongInt ; stdcall ; external 'Aesimhei.dll' name '_OpenSpecificMHEVersion@8' ;
                               
{****************************************************************
The EnableInterface call is used to allow users to enter coins
or notes into the system. This would be called when a game is
initialised and ready to accept credit.

Parameters
None

Return Value
None

Remarks
This must be called following the call to OpenMHE before
any coins / notes will be registered.

It must ALSO be called prior to reading any of the switches.
****************************************************************}
Procedure EnableInterface        ; stdcall ; external 'Aesimhei.dll' name '_EnableInterface@0';



{****************************************************************
The DisableInterface call is used to prevent users from
entering any more coins or notes.

Parameters
None

Return Value
None

Remarks
1. There is no guarantee that a coin or note can not be
successfully read after this call has been made, a
successful read may be in progress.
****************************************************************}
Procedure DisableInterface       ; stdcall ; external 'Aesimhei.dll' name '_DisableInterface@0';




{****************************************************************
The CurrentValue call is used to determine the total value
of all coins and notes read by the money handling equipment
connected to the interface.

Parameters
None

Return Value
The current value, in the lowest denomination of the
currency (i.e. cents / pence etc.) of all coins and notes read.

Remarks
1. The value returned by this call is never reset, but
increments for the life of the interface card. Since
this is a 32 bit integer, the card can accept
£21,474,836.47 of credit before it runs into any rollover
problems. This value is expected to exceed the life of the game.
2. It is the responsibility of the application to keep track
of value that has been used up and to monitor for new
coin / note insertions by increases in the returned value.
3. Note that this value should be read following the call
to OpenMHE and before the call to EnableInterface to establish
a starting point before any coins or notes are read.
****************************************************************}
Function CurrentValue : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_CurrentValue@0';





{****************************************************************
The PayOut call is used by the PC application to instruct
the interface to pay out coins (or notes).


Parameters
This is the value, in the lowest denomination of the currency
(i.e. cents / pence etc.) of the coins and notes to be paid out.

Return Value
None

Remarks
1. This function operates in value, not coins. It is the
responsibility of the interface to decode this and to choose how
many coins (or notes) to pay out, and from which device to pay
them.
****************************************************************}
Procedure PayOut(
        Amount : LongInt )       ; stdcall ; external 'Aesimhei.dll' name '_PayOut@4';



{****************************************************************
The PayStatus call provides the current status of the payout process.


Parameters

None

Return Values.
     Mnemonic        Value     Meaning
****************************************************************}
const
     PAY_ONGOING        =  0 ;   // The interface is in the process of paying out
     PAY_FINISHED       =  1 ;   // The payout process is up to date
     PAY_EMPTY          = -1 ;   // The dispenser is empty
     PAY_JAMMED         = -2 ;   // The dispenser is jammed
     PAY_US             = -3 ;   // Dispenser non functional
     PAY_FRAUD          = -4 ;   // Fraud attempt detected
     PAY_FAILED_BLOCKED = -5 ;   // The dispenser optos are blocked
     PAY_NO_HOPPER      = -6 ;   // There are no dispensers
     PAY_INHIBITED      = -7 ;   // The only possible dispenser is inhibited
     PAY_SECURITY_FAIL  = -8 ;   // The internal security checks failed
     PAY_HOPPER_RESET   = -9 ;   // The hopper reset during a payout
     PAY_NOT_EXACT      = -10 ;  // The hopper cannot payout the exact amount
     PAY_GHOST          = -11 ;  // This hopper does not really exist - it's a part of another unit
     PAY_NO_KEY         = -12 ;  // Waiting on a valid key exchange

{****************************************************************
Remarks

Following a call to PayOut, the programmer should poll this to
check the progress of the operation.

If one out of mutliple hoppers has a problem the PCI card will do
the best it can.

If it can not pay out the entire amount, the status will reflect
the last attempt.

****************************************************************}
Function LastPayStatus : LongInt ; stdcall ; external 'Aesimhei.dll' name '_LastPayStatus@0';










{****************************************************************
SetDispenseQuantity

Synopsis
The SetDispenseQuantity call will set the given quantity as the number of
coins (notes) to be dispensed from a specific dispenser on the next call
to PaySpecific ().


Parameters
1.  Index
This parameter specifies the dispenser that is being set up .
2.  Quantity
This sets the quantity of coins (notes) to be dispensed from the indicated
dispenser.
3.  Value
This is provided as a cross check, and must be the value of the
coin / notes dispensed by this dispenser.

Return Value
If the dispenser referenced is valid, and contains coins (notes) of the
specified value, the return value is value of the resultant payout
(i.e. Quantity * Value). If there is a problem in the specification,
then zero is returned.

Remarks
1.  Once a quantity has been set by use of this call, it remains set
through all other Paylink interface calls until cleared as a side
effect of a PaySpecific () call.
2.  Although both are not necessary, both the Index and the Value
parameters are required as a security check.
3.  A non-zero return indicates only that the payout will be attempted -
no reference is made to the operability of the dispenser.
****************************************************************}
Function SetDispenseQuantity(Index    : LongInt ;
                             Quantity : LongInt ;
                             Value    : LongInt
                )  : LongInt     ; stdcall ; external 'Aesimhei.dll' name '_SetDispenseQuantity@12';





{****************************************************************
PaySpecific

Synopsis
The PaySpecific call takes no parameters. It causes Paylink to
attempt to pay out all the coins (notes) specified by earlier
calls to SetDispenseQuantity().


Parameters
None

Return Value
The total value of the payout being attempted.

Remarks
1.  The only differences between the progress of a payout started
by PaySpecific() and one started by the traditional PayOut() call
is the quantity of the different coins (notes) chosen, and the fact
that there is no "fall over" to a lower value dispenser if a higher
value dispenser is, or becomes, empty.
2.  As with PayOut(), progress is monitored by repeated calls to
LastPayStatus() waiting for PAY_ONGOING to change. Again, as with a
pay out started by PayOut(), the total value paid can be monitored
by calls to CurrentPaid() and the coins (notes) paid for each dispenser
found / monitored using the Count field of the Dispenser blocks
3.  Having transferred the counts set by PaySpecific() to the
Paylink unit for this pay out, the counts are then cleared.
****************************************************************}
Function  PaySpecific: LongInt ; stdcall ; external 'Aesimhei.dll' name '_PaySpecific@0';










{****************************************************************
The IndicatorOn / IndicatorOff calls are used by the PC application
to control LED's and indicator lamps connected to the interface.

Parameters
This is the number of the Lamp that is being controlled.

Return Value
None

Remarks
1. Although the interface is described in terms of lamps, any
equipment at all may in fact be controlled by these calls,
depending only on what is physically connected to the interface card.
****************************************************************}
Procedure IndicatorOn(
        Number : LongInt )       ; stdcall ; external 'Aesimhei.dll' name '_IndicatorOn@4';
Procedure IndicatorOff(
        Number : LongInt )       ; stdcall ; external 'Aesimhei.dll' name '_IndicatorOff@4';




{****************************************************************
The calls to SwitchOpens and SwitchCloses are made by the PC
application to read the state of switches connected to the
interface card.


Parameters
This is the number of the switch that is being controlled.

In principle the interface card can support 64 switches,
though note that not all of these may be physically present
within a game cabinet.

Return Value
The number of times that the specified switch has been
observed to open or to close, respectively.

Remarks
1. The value returned by this call is only (and always)
reset by the OpenMHE call.

2. The convention is that at initialisation time all
switches are open.

3. A switch that starts off closed will therefore return a
value of 1 to a SwitchCloses call immediately following the
OpenMHE call.

4. The expression (SwitchCloses(n) == SwitchOpens(n)) will
always return 0 if the switch is currently closed and 1 if
the switch is currently open.

5. The pressing / tapping of a switch by a user will be
detected by an increment in the value returned by
SwitchCloses or SwtichOpens.

6. The user only needs to monitor changes in one of the
two functions (in the same way as most windowing interfaces
only need to provide functions for button up or button
down events).
****************************************************************}
Function SwitchOpens(
        Number : LongInt
                )  : LongInt     ; stdcall ; external 'Aesimhei.dll' name '_SwitchOpens@4';
Function SwitchCloses(
        Number : LongInt
                )  : LongInt     ; stdcall ; external 'Aesimhei.dll' name '_SwitchCloses@4';





{****************************************************************
The CurrentPaid call is available to keep track of
the total money paid out because of calls to the
PayOut function.

Parameters
None

Return Value
The current value, in the lowest denomination of the
currency (i.e. cents / pence etc.) of all coins and notes
ever paid out.

Remarks

1. This value that is returned by this function is updated
in real time, as the money handling equipment succeeds in
dispensing coins.

2. The value that is returned by this call is never reset,
but increments for the life of the interface card. It is
the responsibility of the application to keep track of
starting values and to monitor for new coin / note successful
payments by increases in the returned value.

3. Note that this value can be read following the call to
OpenMHE and before the call to EnableInterface to establish
a starting point before any coins or notes are paid out.
****************************************************************}
Function CurrentPaid : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_CurrentPaid@0';




{****************************************************************
The SystemStatus call is not implemented.

It would provides a single summary of the status
all the money handling equipment connected to the interface.
It is a logical OR of the status of all of the individual
device statuses.

Parameters
None

Return Value
Zero if all devices are completely normal.
Negative if there is a major problem with any device.

Remarks

This returns a logical OR of the status of all of the individual
device statuses.
****************************************************************}
// Function SystemStatus : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_SystemStatus@0';



{****************************************************************
The CheckOperation call allows an application to check that the Paylink
and its connection to the PC are operational. It also allow
the application to automatically close down currency acceptance
in the event of any PC malfunction.



Parameters

1. Sequence
A unique number for this call, freely chosen by the application.
2. Timeout
A time in milliseconds before which another CheckOperation() call
must be made in order to continue the normal operation of Paylink.
If zero, then this functionality is inactive.

Return Value
The last Sequence value of which the Paylink unit has been notified,
or -1 if the Paylink does not support this facility.

Remarks
1. In normal operation, Paylink can be expected to have updated the
value to be returned by this within 100 milliseconds of the previous
call. It is suggested that this call is made every 500 milliseconds
or longer to allow for transient delays.
2. If the Timeout expires, Paylink will “silently” disable all the
acceptors that are connected to it. The next call to CheckOperation()
will “silently” re-enable them.
****************************************************************}
Function CheckOperation(
                 Sequence : LongInt ; 
                 Timeout : LongInt) : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_CheckOperation@8';





{****************************************************************
Detect updates to the data presented to the API by the firmware.

The fact that the value returned by CurrentUpdates has changed,
prompts the application to re-examine all the variable data
in which it is interested.

Parameters
None

Return Value
Technically CurrentUpdates returns the number of times that the
API data has been updated since the PC system initialised.
In practice, only changes in this value are significant.

Remarks
1. It is possible that the value could change without
any visible data changing.
****************************************************************}
Function CurrentUpdates : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_CurrentUpdates@0';





{****************************************************************
Des Lock
A DES system can be basically secured in one of two ways:
1. The PC and Paylink are both in the same secure enclosure.
    Here there is no need to provide any security control over
    the USB connection - access to the USB cable is equivalent to
    access to the hard disc of the PC, and this level of access c
    annot be contracted by electronic means.
2. The Paylink, or more particularly the USB connection, is
    accessible from the general cabinet area.
    Here a fraud attempt is possible by removing existing USB cable
    and connecting the Paylink USB socket to the fraudster’s laptop.

To prevent this security problem, the PC application can use DES lock,
the functions associated with DES lock are described in this section.
(Only) While Paylink is DES locked:
• The PC and Paylink cross check that each other are using the same key.
• The Payout call only works if the key has been matched
• New DES peripherals can’t be added without Paylink being unlocked
• Pressing the DES button deletes all DES keys (peripheral and Paylink) and unlocks Paylink

Some points about this system are:
• Updates to existing Paylink applications are optional
    - although there can be a security risk.
• The DES lock key is provided by the PC, and so can be held on a read only disk system.
• A DES lock aware application will spot if a different
    Paylink is substituted, or if the Paylink is unlocked in order to change the peripherals
****************************************************************}





{****************************************************************
Inform the DLL that of the current key that is to be shared between the PC and Paylink


Parameters
1. Key
The 8 byte DES key previously applied using the DESLockSet function.


Return Value
None.

Remarks
1. The Key should be as unpredictable as possible. Ideally, it will
    be a random number generated by the application and saved for future use.
    For system with read only file systems, it could be derived from Processor ID or similar.

2. The DESStatus function (see below) will enable the application to
    determine the success of this function.
****************************************************************}
Procedure DESSetKey(Key : PAnsiChar)  ; stdcall ; external 'Aesimhei.dll' name '_DESSetKey@4';






{****************************************************************
Apply the lock using the key quoted in this function call.

Parameters
1. Key
    The 8 byte DES key chosen by the PC.

Return Value
None

Remarks
If the Paylink is already DES Locked, then this function will not
change the key unless DESSetKey has already matched the key stored by Paylink.

****************************************************************}
Procedure DESLockSet(Key : PAnsiChar)  ; stdcall ; external 'Aesimhei.dll' name '_DESLockSet@4';





{****************************************************************
Clear any previous applied DES lock.

Parameters
None

Return Value
None

Remarks
1. If the Paylink is already DES Locked, then this function will
    not unlock Paylink unless DESSetKey has already matched the key stored by Paylink.

2. This function differs from pressing the DES button in that
    keys for the existing DES peripherals are not lost. This can therefore
    be used by application when an engineer wishes to only update a single peripheral.

****************************************************************}
Procedure DESLockClear ; stdcall ; external 'Aesimhei.dll' name '_DESLockClear@0';





{****************************************************************
Synopsis
The DESStatus call provides the current status of the DES lock system.

Parameters
None

Return Values.
     Mnemonic        Value     Meaning
****************************************************************}
const
     DES_UNLOCKED   = 0  ;   // The Paylink is unlocked                     
     DES_MATCH      = 1  ;   // DES Key matched by Paylink and PC           
     DES_NOT        = -1 ;   // Not a DES Paylink                           
     DES_WRONG      = -2 ;   // Paylink wrong key                           
     DES_CHECKING   = -3 ;   // DES Key checking is still being performed.  
     DES_APPLYING   = -4 ;   // DES Lock is being applied                   
{****************************************************************

Remarks
1. Following a call to DESLockSet, or DESSetKey, the programmer
    should poll this to check the operation.

2. The Paylink system is only operation when either DES_UNLOCKED
    or DES_MATCH has been returned by this function.
****************************************************************}
Function DESStatus : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_DESStatus@0' ;







{****************************************************************
All Acceptor / hopper events received will be queued (in a short queue).
These can be retrieved with NextEvent.

Parameters
1. EventDetail
   NULL or the address of the strucutre at which to store the details of
   the event.

Return Value
The return code is 0 (IMHEI_NULL) if no event is available ; otherwise
it is the next event.

Remarks
1. In the event that one or more event is missed ; the code
   IMHEI_OVERFLOW will replace the missed events.
2. As note ; coin & hoper event codes do not overlap ; the EventDetail
   parameter can often be set to NULL as the device is implicit in the event.
3. The values for the codes returned are in the separate files ImheiEvent

****************************************************************}
Type
  TEventDetailBlock = Record
    EventCode      : LongInt ;     // The code (as rturned by NextEvent
    RawEvent       : LongInt ;     // The actual code returned by the peripheral
    DispenserEvent : LongInt ;     // True if the device was a dispenser
                                      // False for an acceptor
    Index          : LongInt ;     // The ReadxxxBlock index of the generating device
end ;

Function NextEvent(var EventDetails : TEventDetailBlock) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_NextEvent@4';


{****************************************************************
NextAcceptorEvent
NextDispenserEvent
NextSystemEvent

Synopsis
These calls provide controlled access to exactly the same set of events
as the NextEvent call described above.

The difference is that, rather than providing access to one single queue
with all events, these provide access to a number of queues. One independent
queue is provided for each acceptor is the system, one for each dispenser
in the system, and one  final queue for all system oriented events.


Parameters

1. Number
The same value as that used in a call to ReadxxxDetails. All events
returned will have an Index value equal to this.

2. EventDetail
NULL, or the address of the single structure at which to store more
details of the event given by the return value.

Return Value

Remarks
1. If these calls are used in a system that also calls NextEvent,
    the result is undefined.
2. Systems with more than 32 acceptors or dispensers should not
    use these calls
3. Un-accessed queues will silently discard events.
****************************************************************}
Function NextAcceptorEvent(Number   : LongInt ;
                               var EventDetails : TEventDetailBlock) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_NextAcceptorEvent@8';

Function NextDispenserEvent(Number   : LongInt ;
                            var EventDetails : TEventDetailBlock) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_NextDispenserEvent@8';

Function NextSystemEvent(var EventDetails : TEventDetailBlock) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_NextSystemEvent@4';








{****************************************************************
The AvailableValue call is available to keep track of how much
money is available in the coin (or note) dispensers.

Parameters

None

Return Value

The approximate minimum value ; in the lowest denomination
of the currency (i.e. cents / pence etc.) of all coins and
notes that could be paid out.

Remarks
The accuracy of the value returned by this call is entirely
dependent upon the accuracy of the information returned by
the money dispensers.

If no information is obtainable ; this returns 10 ;000 if at
least one dispenser is working normally ; and zero if all
dispensers are failing to pay out.
****************************************************************}
Function AvailableValue : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_AvailableValue@0';




{****************************************************************
The ValueNeeded call provides an interface to an optional
credit card acceptor unit.

It is not envisaged that this would be used within many systems,
but may be used, for example, in vending applications.


Parameters
The figure that CurrentValue is required to reach before
the next event can happen.

Return Value
None

Remarks
1. This function does not necessarily have any affect
on the system. If the MHE includes a credit card acceptor,
or similar, then the MHE interface unit will arrange for the
next use of that unit to bring CurrentValue up to latest
figure supplied by this routine.

2. If CurrentValue is greater or equal to the last supplied
figure then any such acceptors are disabled.
****************************************************************}
Procedure ValueNeeded(
        Amount : LongInt )       ; stdcall ; external 'Aesimhei.dll' name '_ValueNeeded@4';





{****************************************************************
The SerialNumber call provides access to the electronic serial number
stored on the device.

Parameters
None

Return Value
32 bit serial number.

Remarks
1. A serial number of -1 indicates that a serial number has not been
set in the device.
2. A serial number of 0 indicates that the device firmware does not
support serial numbers
****************************************************************}
Function SerialNumber : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_SerialNumber@0';





{****************************************************************
Escrow

At start-up, the system does not report escrow details and all
acceptors are run in "normal" mode where all currency is accepted.
To use escrow the call EscrowEnable() is issued. Following this
the call EscrowThroughput() will return the total value of all
currency that has ever been held in escrow (in the same way as
for CurrentValue() except that the value is not preserved over
resets). An increase in the value returned indicates that a note
is now in escrow.
The HeldInEscrow field within the AcceptorCoin structure will
indicate the number of each note / coin that is currently being
held.

The EscrowAccept() call will cause the IMHEI card to complete
the acceptance of the currency in question that, when complete,
will be indicated by an increase in CurrentValue().
An EscrowReturn() call will cause the currency to be returned
with no further indication to the game. Following either call,
the EscrowThroughput() value may increase immediately due to
another acceptor having an escrow holding.
****************************************************************}


{****************************************************************
EscrowEnable - Change the mode of operation of all escrow capable
acceptors to hold inserted currency in escrow until a call of
EscrowAccept.

The EscrowEnable call is used to start using the escrow system

Parameters
None

Return Value
None
****************************************************************}
Procedure EscrowEnable        ; stdcall ; external 'Aesimhei.dll' name '_EscrowEnable@0';




{****************************************************************
EscrowDisable - Change the mode of operation of all escrow capable
acceptors back to the default mode in which all currency is fully
accepted on insertion

Parameters
None

Return Value
None

Remarks
1. If any currency is currently held in escrow when this call
is made, it will be accepted without comment.
****************************************************************}
Procedure EscrowDisable        ; stdcall ; external 'Aesimhei.dll' name '_EscrowDisable@0';




{****************************************************************
EscrowThroughput - Determine the cumulative monetary value that
has been held in escrow since the system was reset.

The EscrowThroughput call is used to determine the cumulative total
value of all coins and notes read by the money handling equipment
that have ever been held in escrow.

Parameters
None

Return Value
The current value, in the lowest denomination of the currency
(i.e. cents / pence etc.) of all coins and notes read.

Remarks
1. It is the responsibility of the application to keep track of
value that has been accepted and to monitor for new coin / note
insertions by increases in the returned value.

2. Note that this value should be read following the call to OpenMHE
and before the call to EnableInterface / EscrowEnable to establish a
starting point before any coins or notes are read.

3. If the acceptor auto-returns the coin / note then this will
fall to its previous value. This can (potentially) occur after a
call to EscrowAccept() or EscrowReturn() if the acceptor has already
started its return sequence.

****************************************************************}
Function EscrowThroughput : LongInt  ; stdcall ; external 'Aesimhei.dll' name '_EscrowThroughput@0';




{****************************************************************
EscrowAccept - If the acceptor that was last reported as holding
currency in escrow is still in that state, this call will cause
it to accept that currency.

Parameters
None

Return Value
None

Remarks
1. If a second acceptor has (unreported) currency in escrow
at the time this call is made, it will immediately cause the
EscrowThroughput to be updated.
2. If no currency is currently held in escrow when this call is
made, it will be silently ignored.
****************************************************************}
Procedure EscrowAccept        ; stdcall ; external 'Aesimhei.dll' name '_EscrowAccept@0';




{****************************************************************
EscrowReturn - If the acceptor that was last reported as holding
currency in escrow is still in that state, this call will cause
it to Return that currency.

Parameters
None

Return Value
None

Remarks
1. If a second acceptor has (unreported) currency in escrow at
the time this call is made, it will immediately cause the
EscrowThroughput to be updated.
2. If no currency is currently held in escrow when this call
is made, it will be silently ignored.
****************************************************************}
Procedure EscrowReturn        ; stdcall ; external 'Aesimhei.dll' name '_EscrowReturn@0';







{****************************************************************
Bar Codes
Where an acceptor provides barcode facilities, the IMHEI card fully
support this by enabling bar code acceptance and reporting the barcodes
read.

Barcode reading is always handled using the Escrow position on the
acceptor. The barcode is held in the acceptor pending a call from the
application the either stack or return it.

In most systems, only one barcode capable acceptor will be present,
the IMHEI card will however support barcodes on an unlimited number
of acceptors. In order to allow for accurate information and control
to pass between the game and the IMHEI firmware, the barcode reported
is limited to a single acceptor at time. If two acceptors are holding
barcoded tickets at the same time, the second will not be reported until
the first has completed.

The basic barcodes processed by the IMHEI system are in the format
“Interleaved 2 of 5” and are 18 characters long. (Functions return a 19
character NULL terminated string.) Later barcode system now return up to
40 characters, so the functions with the suffix Ext will handle any
length.

Barcodes read by the IMHEI can also be printed if a dedicated barcode
printer is connected.
****************************************************************}





{****************************************************************
Change the mode of operation of all Barcode capable acceptors to
accept tickets with barcodes on them.

The BarcodeEnable call is used to start using the Barcode system

Parameters
None

Return Value
None
****************************************************************}
Procedure BarcodeEnable        ; stdcall ; external 'Aesimhei.dll' name '_BarcodeEnable@0';




{****************************************************************
Change the mode of operation of all Barcode capable acceptors
back to the default mode in which only currency is accepted.

Parameters
None

Return Value
None

Remarks
1. If a Barcoded ticket is currently held when this call is made,
it will be returned without comment.
****************************************************************}
Procedure BarcodeDisable        ; stdcall ; external 'Aesimhei.dll' name '_BarcodeDisable@0';






{****************************************************************
This is the regular “polling” call that the application should
make into the DLL to obtain the current status of the barcode
system. If a barcode is read by an acceptor it will be held in
escrow and this call will return true in notification of the fact.

Parameters
1. BarcodeString
A pointer to a buffer of at least 19 characters into which the
last barcode read from any acceptor is placed. This will be all
NULL if no barcoded ticket has been read since system start-up.

2. BufferLength
The available length of the buffer. This can be larger than 19 to
accomodate increases in barcode length.

Return Value
The return value is true if there is a barcode ticket currently
held in an Acceptor, flase if there is not.

Remarks
1. There is no guarantee that at the time the call is made the
acceptor has not irrevocably decided to auto-eject the ticket.
****************************************************************}
Function BarcodeInEscrow (BarcodeString : PAnsiChar ) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_BarcodeInEscrow@4';
Function BarcodeInEscrowExt (BarcodeString : PAnsiChar; BufferLength : LongInt  ) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_BarcodeInEscrowExt@8';











{****************************************************************
Following a call to BarcodeAccept the system may complete the
reading of a barcoded ticket. If it does, then the count returned
by BarcodeStacked will increment. There is no guarantee that this
will take place, so the application should continue to poll
BarcodeInEscrow.

Parameters
2. BarcodeString
A pointer to a buffer of at least 19 characters into which the
last barcode read from any acceptor is placed. This will be all
NULL if no barcoded ticket has been read since system start-up.

2. BufferLength
The available length of the buffer. This can be larger than 19 to
accomodate increases in barcode length.


Return Value
The count of all the barcoded tickets that have been stacked since
system start-up. An increase in this value indicates that the
current ticket has been stacked - its contents will be in the
BarcodeString buffer.

Remarks
2. It is the responsibility of the application to keep track of
the number of tickets that have been accepted and to monitor for
new insertions by increases in the returned value.

3. Note that this value should be read following the call to
OpenMHE and before the call to EnableInterface / BarcodeEnable
to establish a starting point before any new tickets are read.
****************************************************************}
Function BarcodeStacked (BarcodeString : PAnsiChar ) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_BarcodeStacked@4';
Function BarcodeStackedExt (BarcodeString : PAnsiChar; BufferLength : LongInt ) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_BarcodeStackedExt@8';







{****************************************************************
If the acceptor that was last reported as holding a Barcode
ticket is still in that state, this call will cause it to
accept that currency.

Parameters
None

Return Value
None

Remarks
1. If a second acceptor has (unreported) currency in Barcode
at the time this call is made, it will immediately cause the
BarcodeTicket to be updated.
2. If no ticket is currently held when this call is made, it
will be silently ignored.
****************************************************************}
Procedure BarcodeAccept        ; stdcall ; external 'Aesimhei.dll' name '_BarcodeAccept@0';






{****************************************************************
If the acceptor that was last reported as holding a Barcode
ticket is still in that state, this call will cause it to
return that currency.

Parameters
None

Return Value
None

Remarks
1. If a second acceptor has (unreported) currency in Barcode at
the time this call is made, it will immediately cause the
BarcodeTicket to be updated.
2. If no ticket is currently held when this call is made,
it will be silently ignored.
****************************************************************}
Procedure BarcodeReturn        ; stdcall ; external 'Aesimhei.dll' name '_BarcodeReturn@0';








{****************************************************************
This call is used to print a barcoded ticket ; if the IMHEI system
supports a printer.

Parameters
1. TicketContents.
Pointer to a TicketDescription structure that holds pointers
to the strings that the application is “filling in”. NULL pointers
will cause the relevant fields to default (usually to blanks).
****************************************************************}
Type
  TTicketDescription = record
    TicketType          : LongInt ;    // The "template" for the ticket
    BarcodeData         : PAnsiChar ;
    AmountInWords       : PAnsiChar ;
    AmountAsNumber      : PAnsiChar ;      // But still a string
    MachineIdentity     : PAnsiChar ;
    DatePrinted         : PAnsiChar ;
    TimePrinted         : PAnsiChar ;
  end ;

{****************************************************************

Return Value
None

Remarks
1. There are a number of fields that can be printed a barcode ticket.
Rather than provide a function with a large number of possibly null
parameters, we use a structure, which may have fields added to end.
The user should ensure that all unused pointers are zero.
2. Before issuing this call the application should ensure that
BarcodePrintStatus has returned a status of PRINTER_IDLE
3. The mechanics of the priniting mechanism rely on BarcodePrintStatus
being called regularly after this call, in order to “stage” the data
to the interface.
****************************************************************}
Procedure BarcodePrint  (var TicketContents : TTicketDescription)
                       ; stdcall ; external 'Aesimhei.dll' name '_BarcodePrint@4';








{****************************************************************
This call is used to determine the status of the barcoded ticket
printing system.

Parameters
None

Return Value
This is a bit sensitive status. All error conditions have the top (sign)
bit set. The values for None and Idle are full 32 bit values.
    Mnemonic                       Value             Meaning
}
const
    PRINTER_NONE                 =  0 ;           // Printer non functional / not present
    PRINTER_FAULT                =  $80000000 ;   // There is a fault somewhere
    PRINTER_IDLE                 =  $00000001 ;   // The printer is OK / Idle /Finished
    PRINTER_BUSY                 =  $00000002 ;   // Printing is currently taking place

    PRINTER_PLATEN_UP            =  $00000004 ;
    PRINTER_PAPER_OUT            =  $00000008 ;
    PRINTER_HEAD_FAULT           =  $00000010 ;
    PRINTER_VOLT_FAULT           =  $00000040 ;
    PRINTER_TEMP_FAULT           =  $00000080 ;
    PRINTER_INTERNAL_ERROR       =  $00000100 ;
    PRINTER_PAPER_IN_CHUTE       =  $00000200 ;
    PRINTER_OFFLINE              =  $00000400 ;
    PRINTER_MISSING_SUPPY_INDEX  =  $00000800 ;
    PRINTER_CUTTER_FAULT         =  $00001000 ;
    PRINTER_PAPER_JAM            =  $00002000 ;
    PRINTER_PAPER_LOW            =  $00004000 ;
    PRINTER_OPEN                 =  $00008000 ;
                                                  // These values can be set when Idle
    PRINTER_TOP_OF_FORM          =  $00010000 ;   // The last ticket is finished
    PRINTER_BARCODE_DONE         =  $00020000 ;   // The last barcode has been printed
    PRINTER_JUST_RESET           =  $00040000 ;
{
Remarks
1. The mechanics of the priniting mechanism rely on this
being called regularly after the BarcodePrint call, in order
to “stage” the data to the interface, until PRINTER_BUSY is no
longer returned.
****************************************************************}
Function BarcodePrintStatus : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_BarcodePrintStatus@0';









{****************************************************************
The ReadAcceptorDetails call provides a snapshot of all
the information possessed by the interface on a single
unit of money handling equipment.


Parameters

1. Number
The serial number of the coin or note acceptor about
which information is required.

2. Snapshot
A pointer to a program buffer into which all the
information about the specified acceptor will be copied.

Return Value

True if the specified input device exists, False if the
end of the list is reached.

Remarks
The serial numbers of the acceptors are contiguous and
run from zero upwards.
****************************************************************}
Function ReadAcceptorDetails (Number   : LongInt ;
                          var Snapshot : TAcceptorBlock) : Boolean ;
                          stdcall ; external 'Aesimhei.dll' name '_ReadAcceptorDetails@8';





{****************************************************************
The WriteAcceptorDetails call updates all the changeable
information to the interface for a single unit of money
accepting equipment.

Parameters
1. Number
        The serial number of the coin or note acceptor
        being configured.

2. Snapshot
        A pointer to a program buffer containing the
        configuration data for the specified acceptor.
        See below for details.

Return Value
None.

Remarks
The serial numbers of the acceptors are contiguous
and run from zero upwards.
A call to ReadAcceptorDetails followed by call to
WriteAcceptorDetails for the same data will have no
effect on the system.
****************************************************************}
Procedure WriteAcceptorDetails (Number : LongInt ;
                          var Snapshot : TAcceptorBlock) ;
                          stdcall ; external 'Aesimhei.dll' name '_WriteAcceptorDetails@8';



{****************************************************************
The ReadDispenserDetails call provides a snapshot of all the
information possessed by the interface on a single unit of
money dispensing equipment.

Parameters
1. Number
The serial number of the coin or note dispenser about which
information is required.

2. Snapshot
A pointer to a program buffer into which all the information about
the specified dispenser will be copied.

Return Value
True if the specified input device exists, False if the end of the
list is reached.

Remarks
The serial numbers of the dispensers are contiguous and run from
zero upwards.
****************************************************************}
Function ReadDispenserDetails (Number   : LongInt ;
                          var Snapshot : TDispenserBlock) : Boolean ;
                          stdcall ; external 'Aesimhei.dll' name '_ReadDispenserDetails@8';





{****************************************************************
The WriteDispenserDetails call updates all the changeable information
to the interface for a single unit of money handling equipment.


Parameters
1. Number
The serial number of the coin or note dispenser being configured.

2. Snapshot
A pointer to a program buffer containing the configuration data for
the specified dispenser. See below for details.

Return Value
None.

Remarks

The serial numbers of the dispensers are contiguous and run
from zero upwards. A call to ReadDispenserDetails followed by
call to WriteDispenserDetails for the same data will have no
effect on the system.
****************************************************************}
Procedure WriteDispenserDetails (Number : LongInt ;
                          var Snapshot : TDispenserBlock) ;
                          stdcall ; external 'Aesimhei.dll' name '_WriteDispenserDetails@8';







{****************************************************************
The CounterIncrement call is made by the PC application software
to increment a specific counter value.

Parameters
1. CounterNo
This is the number of the counter to be incremented.


2. Increment
This is the value to be added to the specified counter.


Return Value
None

Remarks
If the counter specified is higher than the highest supported,
then call is silently ignored.

****************************************************************}
Procedure CounterIncrement( CounterNo : Integer ;
                            Increment : Integer ) ;
                               stdcall ; external 'Aesimhei.dll' name '_CounterIncrement@8';






{****************************************************************
The CounterCaption call is used to associate a caption with the
specified counter. This is related to the CounterDisplay call
described below.


Parameters
1. CounterNo
This is the number of the counter to be incremented.

Caption
2. This is an ASCII string that will be associated with the counter.

Return Value
None

Remarks
1. The meter hardware may have limited display capability.
It is the system designer’s responsibility to use captions
that are within the meter hardware’s capabilities.

2. If the counter specified is higher than the highest supported,
then call is silently ignored.
****************************************************************}
Procedure CounterCaption( CounterNo : Integer ;
                          Caption   : PAnsiChar) ;
                                  stdcall ; external 'Aesimhei.dll' name '_CounterCaption@8';



{****************************************************************
The CounterRead call is made by the PC application software to
obtain a specific counter value as stored by the meter interface.

Parameters
1. CounterNo
   This is the number of the counter to be incremented.

Return Value
The Value of the specified meter at system start-up.

Remarks
1. If the counter specified is higher than the highest supported,
   then the call returns -1

2. If the counter external hardware does not support counter
   read-out, then this will return the total of all increments
   since PC start-up.

3. If error conditions prevent the meter updating, this call will
   show the value it should be at, not its actual value.
   (The value is only read from the meter at system start-up.)
****************************************************************}
Function CounterRead(CounterNo : Integer) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_CounterRead@4' ;



{****************************************************************
The ReadCounterCaption call is used to determine the caption for
the specified counter

Parameters
1. CounterNo
   This is the number of the counter to be incremented.

Return Value
None

Remarks
1. If the counter specified is higher than the highest supported,
   then the call returns an empty string ("").
2. All captions stored in the meter are read out at system start-up
   and used to initialise the captions used by the interface.
****************************************************************}
Function ReadCounterCaption(CounterNo : Integer) : PAnsiChar ;
                               stdcall ; external 'Aesimhei.dll' name '_ReadCounterCaption@4' ;




{****************************************************************
The CounterDisplay call is used to control what is displayed on the meter.

Parameters
1. DisplayCode
If positive, this specifies the counter that will be continuously
             display by the meter hardware.

If negative, then the display will cycle between the caption (if set)
             for the specified counter for 1 second, followed by its
             value for 2 seconds.

Return Value
None

Remarks
1. This result of this call with a negative parameter is undefined
   if no counters have an associated caption.
2. Whenever the meter displayed is changed, the caption (if set)
   is always displayed for one second.
****************************************************************}
Procedure CounterDisplay (DisplayCode : LongInt) ;
                               stdcall ; external 'Aesimhei.dll' name '_CounterDisplay@4' ;



{****************************************************************
The MeterStatus call is used determine whether working meter
equipment is connected.

Parameters
None

Return Value
One of the following:
Return Values.
     Mnemonic        Value     Meaning
****************************************************************}
const
     METER_OK      =  0 ;   //  A Meter is present and working correctly
     METER_MISSING =  1 ;   //  No Meter has ever been found
     METER_DIED    =  2 ;   //  The Meter is no longer functioning
     METER_FAILED  =  3 ;   //  The Meter is functioning ; but is itself
                           //     reporting internal problems

{****************************************************************
Remarks
None
****************************************************************}
Function MeterStatus : LongInt ;
                     stdcall ; external 'Aesimhei.dll' name '_MeterStatus@0' ;




{****************************************************************
The MeterSerialNo call is used determine which item meter
equipment is connected.


Parameters
None

Return Value
The 32-bit serial number retrieved from the meter equipment.

Remarks

Where the meter equipment is not present or does not have serial
number capabilities, zero is returned.
****************************************************************}
Function MeterSerialNo : LongInt ;
                       stdcall ; external 'Aesimhei.dll' name '_MeterSerialNo@0' ;




{****************************************************************
The E2PromReset call is made by the PC application software to
clear all the E2PROM counters on the card.


Parameters
1. LockE2Prom
   This is a Boolean flag.
   If zero, then the E2PROM counters may be reset again later.
   If non zero, then all future calls to this function will have
   no effect on the card.

Return Value
None

Remarks
None
****************************************************************}
Procedure E2PromReset (LockE2Prom : LongInt) ;
                               stdcall ; external 'Aesimhei.dll' name '_E2PromReset@4' ;





{****************************************************************
The E2PromWrite call is made by the PC application software
to write to all or part of the user E2PROM on the card.


Parameters
1. UserBuffer
   This is the address of the user’s buffer, from which BufferLength
   bytes of data are copied to the start of the user area.
2. BufferLength
   This is the count of the number bytes to be transferred.
   If this is greater than 256 the extra will be silently ignored.

Return Value
None

Remarks
1. This call schedules the write to the E2PROM memory and returns
   immediately. There is no way of knowing when the E2PROM has
   actually been updated but, barring hardware errors, it will be
   complete within one second of the call.
****************************************************************}
Procedure E2PromWrite (UserBuffer   : PAnsiChar ;
                       BufferLength : LongInt) ;
                               stdcall ; external 'Aesimhei.dll' name '_E2PromWrite@8' ;





{****************************************************************
The E2PromRead call is made by the PC application software to obtain
all or part of the user E2PROM from the card.

Parameters
1. UserBuffer
   This is the address of the user’s buffer, into which the current
   contents of the user E2PROM area are copied.
2. BufferLength
   This is the count of the number bytes to be transferred. If this
   is greater than 256 the extra will be silently ignored.

Return Value
None

Remarks
1. Unwritten E2Prom memory is initialised all one bits.
2. Writes performed by E2PromWrite will be reflected immediately
   in the data returned by this function, regardless of whether
   or not they have been committed to E2Prom memory.
****************************************************************}
Procedure E2PromRead (UserBuffer   : PAnsiChar ;
                      BufferLength : LongInt) ;
                               stdcall ; external 'Aesimhei.dll' name '_E2PromRead@8' ;




{*******************************************************************************************
********************************************************************************************

Paylink provides for an Extended Escrow system if the note acceptor(s)
connected provide sufficient facilities for that.

This is the main structure used by this system.

********************************************************************************************
********************************************************************************************}

const
    MAX_ESCROW = 64 ;                     // Maximum number of notes in Escrow
    ESCROW_CURRENT_VERSION = 0 ;          // The current version of the Escrow system


    ESCROW_NOTE_HELD     = 0 ;
    ESCROW_NOTE_STACKED  = 1 ;           // Set if this note was Stacked to the cashbox.
    ESCROW_NOTE_RETURNED = 2 ;           // Set if this note was returned.
    ESCROW_NOTE_PROBLEM  = 3 ;           // Set if this note could not be returned / stacked.
Type
  TEscrowNoteDetails = record
    
    Value               : LongInt ;          // Value of this note
    NoteNumber          : LongInt ;          // The index of the AcceptorCoin in the AcceptorBlock
    Location            : LongInt ;          // The dispenser on which this note is stored
    Status              : LongInt ;          // See the enum above
    Reserved            : array [0..1] of LongInt ;
    end ;



Type
  TEscrowControlBlock = record
    EscrowVersion       : LongInt ;          // The version of the escrow system available on Paylink.
    State               : LongInt ;          // The current state of the Escrow System
    Result              : LongInt ;          // The result of the previous Escrow Command
    TotalValue          : LongInt ;          // The total values of all the notes in Escrow
    ValueReturned       : LongInt ;          // The total values of all the notes just returned from Escrow
    AcceptorNo          : LongInt ;          // The index of the acceptor running escrow
    NoInEscrow          : LongInt ;          // The number of notes currently in escrow
    Reserved            : array [0..15] of LongInt ;
    EscrowNote          : array [0..MAX_ESCROW - 1] of TEscrowNoteDetails ; // details on the notes in Escrow
    end ;




{****************************************************************

An Extended Escrow system is always in exactly one state, which
is one of the following Constants for EscrowControlBlock.State

****************************************************************}

const
    EXT_ESCROW_NONE               = 0 ;        // This Paylink system does not implement extended escrow
    EXT_ESCROW_OFF                = 1 ;        // The extended escrow system is not running.
    EXT_ESCROW_IDLE               = 2 ;        // The extended escrow system is running, but not doing anything
    EXT_ESCROW_WAITING            = 3 ;        // The extended escrow system is running, waiting for notes, but empty
    EXT_ESCROW_LOADING            = 4 ;        // Notes are in transit within the the escrow system
    EXT_ESCROW_STORED             = 5 ;        // The escrow system is idle, storing notes.
    EXT_ESCROW_PAUSED             = 6 ;        // The escrow system is storing notes, but not accepting any more
    EXT_ESCROW_STACKING           = 7 ;        // The escrow system is transfering notes to the cash box.
    EXT_ESCROW_RETURNING          = 8 ;        // The escrow system is returning notes to the user.
    EXT_ESCROW_RETURNED_OK        = 9 ;        // The escrow system has finished returning notes to the user
    EXT_ESCROW_RETURNING_PROBLEM  = 10 ;       // While returning notes to the user, there was a problem
    EXT_ESCROW_STACKED_OK         = 11 ;       // The escrow system has finished returning notes to the user
    EXT_ESCROW_STACKING_PROBLEM   = 12 ;       // The process of stacking notes failed.
    EXT_ESCROW_FULL               = 13 ;       // The escrow system is full, the acceptor is disabled
    EXT_ESCROW_POWER_ACTIVE       = 14 ;       // The escrow system was running when Paylink was powered off


{****************************************************************

An Escrow system command will result in one of the following code as EscrowControlBlock.Result

****************************************************************}

const
    EXT_ESCROW_COMPLETE         = 0 ;          // The last escrow command completed correctly, the Escrow block now reflects that.
    EXT_ESCROW_BUSY             = 1 ;          // An escrow command has been accepted, but not completed, the Escrow block is invalid.
    EXT_ESCROW_WRONGSTATE       = 2 ;          // A valid escrow command was issued, but the Escrow system was unable to action it.
    EXT_ESCROW_ERROR            = 3 ;          // An invalid escrow command was issued.




{***************************************************************
ReadEscrowBlock

Synopsis
The ReadEscrowBlock call is used to obtain the latest information for an
EscrowControlBlock.



Parameters
1.  Number
The sequence number of the escrow control system about which information is required.
2.  Snapshot
A pointer to a program buffer into which all the information about the specified
acceptor will be copied.

Return Value
Non zero if the specified Escrow control block exists, Zero if the end of the list is
reached.

Remarks
1.  Zero can be returned when Number has the value of zero if no escrow control systems
are running.


****************************************************************}
Function ReadEscrowBlock (Number   : LongInt ;
                      var Snapshot : TEscrowControlBlock) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_ReadEscrowBlock@8' ;


{***************************************************************
EscrowCommand

Synopsis
The EscrowCommand call is used by the application to handle all interaction with the extended
escrow system.

The following commands are defined:  }

const
    EXT_ESCROW_START        = 0 ;  // Turn on the Escrow system
    EXT_ESCROW_STOP         = 1 ;  // Turn off the Escrow system
    EXT_ESCROW_ACCEPT       = 2 ;  // Allows the acceptor to input notes to the Escrow system
    EXT_ESCROW_PAUSE        = 3 ;  // Stop accepting notes and allow system to settle
    EXT_ESCROW_STACK        = 4 ;  // Transfer notes to the cash box (or retain them in the recyler)
    EXT_ESCROW_RETURN       = 5 ;  // Return all escrowed notes to the user.

{
Parameters
1.  Number
The sequence number of the escrow control system for which the command is intended.
2.  Command
The command being issued..

Return Value
None

Remarks
1.  The success or failure and subsequent progress of a command are determined by value set into
the Result and State fields of the EscrowControlBlock.
2.  Immediately following this call, the Result field of the EscrowControlBlock will always be
EXT_ESCROW_BUSY.
3.  For any particular State of the escrow control system only a small subset of commands are valid.
Any other command will generate EXT_ESCROW_WRONGSTATE.

****************************************************************}
Procedure EscrowCommand  (Number : LongInt ;
                          Command : LongInt) ;
                               stdcall ; external 'Aesimhei.dll' name '_EscrowCommand@8' ;






{****************************************************************
The SetDeviceKey call is made by the PC application software to
set such things as an encryption key.


Parameters
1. InterfaceNo
   The Interface on which the device is located
2. Address
   The address of the device whose key is being updated
3. Key
   The 32 bit key to be remembered for the device.

Return Value
None

Remarks
1. At present, this can only be used for a Lumina acceptor at address
   40 on interface 2, the cctalk interface. The key (as 6 hex digits)
   is used as the encryption key.

2. An example application for this is available within the SDK folder
   structure.
****************************************************************}
Procedure SetDeviceKey(InterfaceNo : LongInt ;
                       Address     : LongInt ;
                       Key         : LongInt) ;
                               stdcall ; external 'Aesimhei.dll' name '_SetDeviceKey@12' ;




{****************************************************************
The WriteInterfaceBlock call sends a "raw" block to the specified
interface.

There is no guarantee as to when, in relation to this, regular
polling sequences will be sent, except that while the system is
disabled, the interface card will not put any traffic onto the
interface.

Parameters
1. Interface
The serial number of the interface that is being accessed.

2. Block
A pointer to program buffer with a raw message for the interface.
This must be a sequence of bytes, with any addresses and embedded lengths
required by the peripheral device included. Overheads such as
standard checksums will be added by the IMHEI.
3. Length

The number of bytes in the message.

Return Value
None

Remarks
Using this function with some interfaces does not make sense,
see status returns from ReadInterfaceBlock.
****************************************************************}
Procedure WriteInterfaceBlock (InterfaceNo : LongInt ;
                               Block      : PAnsiChar ;
                               Length     : LongInt) ;
                               stdcall ; external 'Aesimhei.dll' name '_WriteInterfaceBlock@12';






{****************************************************************
The ReadInterfaceBlock call reads the "raw" response to a
single WriteInterfaceBlock.


Parameters
1. Interface
The serial number of the interface being accessed

2. Block
A pointer to the program buffer into which any response is read.

3. Length
The space available in the program buffer.

Return Values
     +ve return values indicate a message has been returned.
     Other values are:
     Mnemonic              Value     Meaning
****************************************************************}
const
     INTERFACE_NO_DATA   =  -5 ; //  The handshake has completed ; but no data was returned.
     INTERFACE_TOO_LONG  =  -4 ; //  Input command is too long
     INTERFACE_NON_EXIST =  -3 ; //  Non command oriented interface
     INTERFACE_OVERFLOW  =  -2 ; //  Command buffer overflow
     INTERFACE_TIMEOUT   =  -1 ; //  Timeout on the interface - no response occurred
     INTERFACE_BUSY      =  0  ; //  The response from the WriteInterfaceBlock has not
                                 //     yet been received

{****************************************************************
Remarks

1. Repeated calls to WriteInterfaceBlock without a successful
response are not guaranteed not to overflow internal buffers.

2. The program is expected to "poll" the interface for a response,
indicated by a non-zero return value.
****************************************************************}
Function ReadInterfaceBlock (InterfaceNo : LongInt ;
                               Block      : PAnsiChar ;
                               Length     : LongInt) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_ReadInterfaceBlock@12';




{****************************************************************
The RawPort functions operates at a lower level than the above. These
calls are not expected to be used by user written application.
****************************************************************}


{****************************************************************
The DoRawPort sends a command block to the raw port handler.
Note: These calls provide access to the very lowest level of
      the IMHEI hardware. The port number is a reference to the
      of the serial communicationshardware, and has no connection
      with Interface numbers.

The results of that command then have to be retrieved by polling
RawPortResult for a non-zero result.

All Raw port access *must* start with a RAW_CLAIM_PORT block, which
will disable the normal port handler and end with a RAW_RELEASE_PORT
which will re-instate the normal port handler.

A successfull RAW_WRITE_DATA will be indicated by a return value of
1 to a subsequent RawPortResult call, after all the data has been transmitted.

A RAW_READ_DATA call will ignore the Length and Message, a subsequent call
to RawPortResult will either return INTERFACE_NO_DATA or all the data that
fas been read so far. (This will then be lost from the IMHEI)

If the Raw access may have changed the hardware configuration (including coin values),
the IMHEI can then be reset using RAW_RESET_IMHEI. Following a reset a
successful call of OpenINHEI must be made and any and all information
regarding acceptors and dispenser may change.

****************************************************************}
const RAW_BLOCK_SIZE = 140 ;

Type
   TRawPortStruct = Record
    RawFunction : LongInt ;
    PortNumber  : LongInt ;
    Length      : LongInt ;
    Message     : array [0..RAW_BLOCK_SIZE] of AnsiChar ;
end ;

const
    RAW_CLAIM_PORT   = 0 ;
    RAW_WRITE_DATA   = 1 ;
    RAW_READ_DATA    = 2 ;
    RAW_RELEASE_PORT = 3 ;
    RAW_RESET_IMHEI  = 4 ;


    RAW_SET_9600_N_8 = 5 ;
    RAW_SET_9600_E_8 = 6 ;
    RAW_SET_9600_O_8 = 7 ;
    RAW_SET_9600_E_9 = 8 ;
    RAW_SET_19200_O_8 = 9 ;
    RAW_SET_57600_O_8 = 10 ;
    RAW_SET_38400_N_8 = 11 ;
    
    
Procedure DoRawPort(var  Block : TRawPortStruct) ;
                               stdcall ; external 'Aesimhei.dll' name '_DoRawPort@4';


{****************************************************************
The RawPortResult returns the response to a single DoRawPort call.

Parameters
1. Message
   If the DoRawPort function was RAW_READ_DATA, this is a pointer
   to a RAW_BLOCK_SIZE byte block.

Return Values are as for ReadInterfaceBlock above.
****************************************************************}

Function RawPortResult(var Message : array of AnsiChar ) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_RawPortResult@4' ;




{****************************************************************
The USBDriverStatus call allows an interested application to retrieve
the status of the USBDriver program for Paylink system.

Parameters
    None

Return Values
     Mnemonic              Value     Meaning
****************************************************************}
const
    NOT_USB                = -1 ;    // Interface is to a PCI card
    USB_IDLE               = 0;      // No driver or other program running
    STANDARD_DRIVER        = 1;      // The driver program is running normally
    FLASH_LOADER           = 2;      // The flash re-programming tool is using the link
    MANUFACTURING_TEST     = 3;      // The manufacturing test tool is using the link
    DRIVER_RESTART         = 4;      // The standard driver is in the process of exiting / restarting
    USB_ERROR              = 5;      // The driver has received an error from the low level driver
    DRIVER_EXIT            = 6;      // A Driver exit has been requested by the OS
{****************************************************************
Remarks

For PCI systems this is obviously meaningless and the system returns NOT_USB

****************************************************************}
Function USBDriverStatus : LongInt ;
                       stdcall ; external 'Aesimhei.dll' name '_USBDriverStatus@0' ;




{****************************************************************
The USBDriverExit call allows a control application to request that
the USB driver program exits in a controlled manner.

Parameters
    None

Return Values
    None

Remarks

This sets the USBDriverStatus to DRIVER_RESTART. Driver programs with
version 1.0.3.1 or greater will report their exit by changing the
USBDriverStatus to USB_IDLE.

For PCI systems this is obviously meaningless and has no effect.
****************************************************************}
Procedure USBDriverExit ;    stdcall ; external 'Aesimhei.dll' name '_USBDriverExit@0' ;





{****************************************************************
The FirmwareVersion call allows a control application to discover the
exact description of the firmware running on the unit.

Parameters
    1.  CompileDate
        This is a pointer to a 16 byte area that receives a null terminated
        printable version of the date on which the firmware was installed.
    2.  CompileTime
        This is a pointer to a 16 byte area that receives a null terminated
        printable version of the time at which the firmware was installed.

Return Values
    The firmware version as a 32 bit integer. This is normally shown as
    4 x 8 bit numbers separated by dots.

Remarks

Either or both of the charecter pointers may be null.
****************************************************************}
Function  FirmwareVersion(CompileDate, CompileTime : PAnsiChar) : LongInt ;
                               stdcall ; external 'Aesimhei.dll' name '_FirmwareVersion@8';










{****************************************************************
The IMHEIConsistencyError call allows an application to check that a
transient (hardware) error has not caused corruption of the underlying
data structures used to hold the current monetary situation.
Although the use of state tables removes the vulnerability of the
system to time problems, it increases its vulnerability to expensive
hardware errors (which could falsely indicate very large money increments.)

Parameters
    1.  CoinTime
        This is the minimum time in milliseconds that will elapse between
        successive coin insertions. It should be overridden by the application
        where a fast coin acceptor is in use.
    2.  NoteTime
        This is the minimum time in milliseconds that will elapse between
        successive note insertions. It should be overridden by the application
        where a fast note acceptor is in use.

Return Value
    If all the data structures are both consistent and reasonable, the
    function returns NULL.

    If there is any problem an English text message is returned describing
    the problem.


Remarks
    1.  A non-NULL return is a totally unrecoverable situation.
        It is expected that application will report the error,
            and then stop operation.

    2.  As well as calling this function periodically, it is recommended that
        it is called after the detection of a credit increase.
****************************************************************}
const
    STANDARD_COIN_TIME = 500 ;
    STANDARD_NOTE_TIME = 5000 ;

Function IMHEIConsistencyError(CoinTime, NoteTime : Integer) : PAnsiChar ;
                               stdcall ; external 'Aesimhei.dll' name '_IMHEIConsistencyError@8' ;


Implementation
Function OpenMHE : LongInt ;
Begin 
    OpenMHE := OpenMHEVersion(INTERFACE_VERSION) ;
End ;


Function OpenSpecificMHE(SerialNumber : PAnsiChar) : LongInt ;
Begin
    OpenSpecificMHE := OpenSpecificMHEVersion(SerialNumber, INTERFACE_VERSION)
End ;

end.
