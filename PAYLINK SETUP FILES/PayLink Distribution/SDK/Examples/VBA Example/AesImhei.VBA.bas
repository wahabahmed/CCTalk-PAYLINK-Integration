Attribute VB_Name = "AesImhei"
'***************************************************************
'
'Definitions for the interface provided by the:
'Aardvark Embedded Solutions Intelligent Money Handling Equipment Interface
'
'****************************************************************
Public Const ORIGINAL_VERSION = &H10001
Public Const DISPENSER_UPDATE = &H10002
Public Const STRINGS_RETURNED = &H10005
Public Const BARCODE_ACCEPTOR = &H10006
Public Const INTERFACE_VERSION = BARCODE_ACCEPTOR

Public Const SYSTEM_MASK = &HF0000000
Public Const INTERFACE_FAILED = &H80000000


' AcceptorConstants
Public Const ACCEPTOR_MASK = &HFFFF
Public Const ACCEPTOR_DEAD = &H1             ' No response to communications for this device
'Public Const ACCEPTOR_ALL_DEAD  = &H02      ' No response from any device on this connection
Public Const ACCEPTOR_DISABLED = &H4         ' Disabled by Interface
Public Const ACCEPTOR_INHIBIT = &H8          ' Specific by Application
Public Const ACCEPTOR_FRAUD = &H10           ' Reported from device
Public Const ACCEPTOR_BUSY = &H20            ' Reported from device
Public Const ACCEPTOR_FAULT = &H40           ' Reported from device

Public Const MAX_ACCEPTOR_COINS = 256        ' Maximum coins or notes handled by any device


Type CharString
    Char(0 To 256)   As Byte
End Type

Type CString
    Pointer          As Long
End Type


Type AcceptorCoin
    Value            As Long      ' Value of this coin
    Inhibit          As Long      ' Set by PC: this coin is inhibited
    Count            As Long      ' Total number read "ever"
    Path             As Long      ' Set by PC: this coin's chosen output path
    PathCount        As Long      ' Number "ever" sent down the chosen Path
    PathSwitchLevel  As Long      ' Set by PC: PathCount level to switch coin to default path
    DefaultPath      As Byte      ' Set by PC: Default path for this specific coin
    FutureExpansion  As Byte      ' Set by PC: for future use
    HeldInEscrow     As Byte      ' count of this note / coin in escrow (usually max 1)
    FutureExpansion2 As Byte
    CoinName         As CString   ' The string, usually as returned from the acceptor, describing this coin
End Type

Type AcceptorBlock
    Unit             As Long      ' Specification of this unit
    Status           As Long      ' AcceptorStatuses - zero if device OK
    NoOfCoins        As Long      ' The number of different coins handled
    InterfaceNumber  As Long      ' The bus / connection
    UnitAddress      As Long      ' For addressable units
    DefaultPath      As Long
    BarcodesStacked  As Long       ' The total number of barcode tickets stacked by this acceptor
    Currency         As String * 4 ' Currency code reported
                                  ' by an intelligent acceptor
    Coin(0 To MAX_ACCEPTOR_COINS - 1) As AcceptorCoin ' Only NoOfCoins are set up
                                    ' (only NoOfCoins are set up)
    SerialNumber     As Long       ' Reported serial number
    Description      As CString    ' Pointer to character
                                   ' Device specific string for type / revision / coin set
    EscrowBarcodeHere As Long      ' If this is non zero, then the barcode reported by BarcodeInEscrow is from this acceptor
End Type




' DispenserConstants
Public Const MAX_DISPENSERS = 16                                ' Maximum handled

                ' Coin Count Status Values
Public Const DISPENSER_COIN_NONE = 0                 ' No dispenser coin reporting
Public Const DISPENSER_COIN_LOW = 1                   ' Less than the low sensor level
Public Const DISPENSER_COIN_MID = 2                   ' Above low sensor but below high
Public Const DISPENSER_COIN_HIGH = 3                 ' High sensor level reported

Public Const DISPENSER_ACCURATE = -1                  ' Coin Count reported by Dispenser
Public Const DISPENSER_ACCURATE_FULL = -2         ' Coin Count as reported by Dispenser,
                                                  '  is over limit.
Public Const DISPENSER_REASSIGN_VALUE   = 100     ' The Value has just been updated by the application
Public Const DISPENSER_VALUE_REASSIGNED = 101     ' The updated Value has just been accepted by the IMHEI

Public Const DISPENSER_CASHBOX_DUMP     = 120     ' Dump the hopper if you can

Type DispenserBlock
    Unit            As Long       ' Specification of this unit
    Status          As Long       ' AcceptorStatuses - zero if device OK
                                  ' This takes the same values As PayStatus()
    InterfaceNumber As Long       ' The bus / connection
    UnitAddress     As Long       ' For addressable units
    Value           As Long       ' The value of the coins in this dispensor
    Count           As Long       ' Number dispensed since interface commissioned
    Inhibit         As Long
    Currency         As String * 4 ' Currency code reported
                                  ' by an intelligent acceptor
    CoinCount       As Long       ' The number of coins in the dispenser
    CoinCountStatus As Long       ' Flags Relating to Coin Count (See above)
    SerialNumber     As Long      ' Reported serial number
    Description      As CString   ' Device specific string for type / revision / coin set
End Type                          ' an intelligent dispenser





'*************************************************************
'Device Identity Constants
'
'These constants are ORed together to form the coded device
'identity that can be extracted from the interface.
'
'Example
'
'   As an example, a Money Controls Serial Compact Hopper 2 will
'have the following device code DP_MCL_SCH2, made up from:
'
' A device specifc code         ORed with
' DP_COIN_PAYOUT_DEVICE         ORed with
' DP_CCTALK_INTERFACE           ORed with
' DP_MANU_MONEY_CONTROLS        ORed with
'
'This is a device code of        &H01020101
'*************************************************************

Public Const DP_GENERIC_MASK = &HFF000000

Public Const DP_COIN_ACCEPT_DEVICE = &H2000000
Public Const DP_NOTE_ACCEPT_DEVICE = &H12000000
Public Const DP_CARD_ACCEPT_DEVICE = &H22000000

Public Const DP_COIN_PAYOUT_DEVICE = &H1000000
Public Const DP_NOTE_PAYOUT_DEVICE = &H11000000
Public Const DP_CARD_PAYOUT_DEVICE = &H21000000

         ' These describe the interface via which this device is connected:
Public Const DP_INTERFACE_MASK = &HFF0000
Public Const DP_INTERFACE_UNIT = &H0
Public Const DP_ONBOARD_PARALLEL_INTERFACE = &H10000
Public Const DP_CCTALK_INTERFACE = &H20000
Public Const DP_SSP_INTERFACE = &H30000
Public Const DP_HII_INTERFACE = &H40000
Public Const DP_ARDAC_INTERFACE = &H50000
Public Const DP_JCM_INTERFACE = &H60000
Public Const DP_GPT_INTERFACE = &H70000
Public Const DP_MDB_INTERFACE = &H80000
Public Const DP_MDB_LEVEL_3_INTERFACE = &H80000
Public Const DP_MDB_LEVEL_2_INTERFACE = &H90000
Public Const DP_F56_INTERFACE        =  &HA0000


                               ' These describe the manufacturer of the device.
Public Const DP_ID003_NOTE = 0 Or DP_JCM_INTERFACE _
                               Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_MDB_LEVEL_2 = 0 Or DP_MDB_LEVEL_2_INTERFACE _
                                Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MDB_LEVEL_3 = 0 Or DP_MDB_LEVEL_3_INTERFACE _
                                Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MDB_LEVEL_2_TUBE = 0 Or DP_MDB_LEVEL_2_INTERFACE _
                                     Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MDB_TYPE_3_PAYOUT = 0 Or DP_MDB_LEVEL_3_INTERFACE _
                                      Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MDB_BILL = 0 Or DP_MDB_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_CC_GHOST_HOPPER = 255 Or DP_CCTALK_INTERFACE _
                                       Or DP_COIN_PAYOUT_DEVICE '        Used by Value hopperz

                               ' These describe the manufacturer of the device.
Public Const DP_MANUFACTURER_MASK = &HFF00
Public Const DP_MANU_UNKNOWN = &H0
Public Const DP_MANU_MONEY_CONTROLS = &H100
Public Const DP_MANU_INNOVATIVE_TECH = &H200
Public Const DP_MANU_MARS_ELECTRONICS = &H300
Public Const DP_MANU_AZKOYEN      = &H400
Public Const DP_MANU_NRI          = &H500
Public Const DP_MANU_ICT          = &H600
Public Const DP_MANU_JCM          = &H700
Public Const DP_MANU_GPT          = &H800
Public Const DP_MANU_COINCO       = &H900
Public Const DP_MANU_ASAHI_SEIKO  = &HA00
Public Const DP_MANU_ASTROSYSTEMS = &HB00
Public Const DP_MANU_MERKUR       = &HC00
Public Const DP_MANU_FUJITSU      = &HD00

            ' These device types are manufacturer-dependent
            '       so that each manufacturer can have up to 255 known devices.
Public Const DP_SPECIFIC_DEVICE_MASK = &HFF

                                                     ' Money Controls Devices
Public Const DP_MCL_SCH2 = 1 Or DP_MANU_MONEY_CONTROLS _
                             Or DP_CCTALK_INTERFACE _
                             Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MCL_SUH1 = 2 Or DP_MANU_MONEY_CONTROLS _
                             Or DP_CCTALK_INTERFACE _
                             Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MCL_SCH3A = 3 Or DP_MANU_MONEY_CONTROLS _
                              Or DP_CCTALK_INTERFACE _
                              Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MCL_SCH3 = 4 Or DP_MANU_MONEY_CONTROLS _
                             Or DP_CCTALK_INTERFACE _
                             Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MCL_SUH5 =  5 Or DP_MANU_MONEY_CONTROLS _
                              Or DP_CCTALK_INTERFACE _
                              Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MCL_SCH5 =  6 Or DP_MANU_MONEY_CONTROLS _
                              Or DP_CCTALK_INTERFACE _
                              Or DP_COIN_PAYOUT_DEVICE

Public Const DP_MCL_BCR_HOPPER =  7 Or DP_MANU_MONEY_CONTROLS _
                                    Or DP_CCTALK_INTERFACE _
                                    Or DP_COIN_PAYOUT_DEVICE



Public Const DP_MCL_SR3 = 2 Or DP_MANU_MONEY_CONTROLS _
                            Or DP_CCTALK_INTERFACE _
                            Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MCL_SR5 = 3 Or DP_MANU_MONEY_CONTROLS _
                               Or DP_CCTALK_INTERFACE _
                               Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MCL_CONDOR = 6 Or DP_MANU_MONEY_CONTROLS _
                               Or DP_CCTALK_INTERFACE _
                               Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MCL_BCR = 7 Or DP_MANU_MONEY_CONTROLS _
                            Or DP_CCTALK_INTERFACE _
                            Or DP_COIN_ACCEPT_DEVICE



Public Const DP_MCL_LUMINA = 5 Or DP_MANU_MONEY_CONTROLS _
                               Or DP_CCTALK_INTERFACE _
                               Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_MCL_7200 = 6 Or DP_MANU_MONEY_CONTROLS _
                               Or DP_CCTALK_INTERFACE _
                               Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_MCL_ARDAC_ELITE = 7 Or DP_MANU_MONEY_CONTROLS _
                               Or DP_CCTALK_INTERFACE _
                               Or DP_NOTE_ACCEPT_DEVICE




Public Const DP_MCL_WACS = 1 Or DP_MANU_MONEY_CONTROLS _
                               Or DP_ARDAC_INTERFACE _
                               Or DP_NOTE_ACCEPT_DEVICE



Public Const DP_MCL_ARDAC = 1 Or DP_MANU_MONEY_CONTROLS _
                               Or DP_JCM_INTERFACE _
                               Or DP_NOTE_ACCEPT_DEVICE


                                   ' Coin Co Devices
Public Const DP_COINCO_MDB = DP_MANU_COINCO _
                          Or DP_MDB_LEVEL_3_INTERFACE _
                          Or DP_COIN_ACCEPT_DEVICE

Public Const DP_COINCO_VORTEX = 1 Or DP_MANU_COINCO _
                                  Or DP_MDB_INTERFACE _
                                  Or DP_COIN_ACCEPT_DEVICE

Public Const DP_COINCO_GLOBAL = 2 Or DP_MANU_COINCO _
                                  Or DP_MDB_INTERFACE _
                                  Or DP_COIN_ACCEPT_DEVICE

Public Const DP_COINCO_MDB_BILL = DP_MANU_COINCO _
                                       Or DP_MDB_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_COINCO_BILLPRO = 1 Or DP_MANU_COINCO _
                                       Or DP_MDB_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

                                   ' Azcoin Devices
Public Const DP_AZK_HOPPER = DP_MANU_AZKOYEN _
                          Or DP_CCTALK_INTERFACE _
                          Or DP_COIN_PAYOUT_DEVICE

Public Const DP_AZK_HOPPER_U  =  1 Or DP_MANU_AZKOYEN _
                                   Or DP_CCTALK_INTERFACE _
                                   Or DP_COIN_PAYOUT_DEVICE

Public Const DP_AZK_HOPPER_UPL =  2 Or DP_MANU_AZKOYEN _
                                    Or DP_CCTALK_INTERFACE _
                                    Or DP_COIN_PAYOUT_DEVICE

Public Const DP_AZK_MDB = DP_MANU_AZKOYEN _
                       Or DP_MDB_INTERFACE _
                       Or DP_COIN_ACCEPT_DEVICE

Public Const DP_AZK_A6 = DP_MANU_AZKOYEN _
                      Or DP_CCTALK_INTERFACE _
                      Or DP_COIN_ACCEPT_DEVICE


                                                     ' Mars Electronics Devices
Public Const DP_MARS_CASHFLOW_126 = 1 Or DP_MANU_MARS_ELECTRONICS _
                                       Or DP_HII_INTERFACE _
                                       Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MARS_CASHFLOW_9500 = 2 Or DP_MANU_MARS_ELECTRONICS _
                                       Or DP_HII_INTERFACE _
                                       Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MARS_MDB = DP_MANU_MARS_ELECTRONICS _
                                       Or DP_MDB_INTERFACE _
                                       Or DP_COIN_ACCEPT_DEVICE

Public Const DP_MARS_CASHFLOW_690 = 1 Or DP_MANU_MARS_ELECTRONICS _
                                       Or DP_MDB_INTERFACE _
                                       Or DP_COIN_ACCEPT_DEVICE

                                                      ' Innovative Devices
Public Const DP_INNOV_NV4 = 4 Or DP_MANU_INNOVATIVE_TECH _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_INNOV_NV7 = 7 Or DP_MANU_INNOVATIVE_TECH _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_INNOV_NV8 = 8 Or DP_MANU_INNOVATIVE_TECH _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_INNOV_NV9 = 9 Or DP_MANU_INNOVATIVE_TECH _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_INNOV_NV10 = 10 Or DP_MANU_INNOVATIVE_TECH _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_INNOV_NV200 =  11 Or DP_MANU_INNOVATIVE_TECH _
                                  Or DP_CCTALK_INTERFACE _
                                  Or DP_NOTE_ACCEPT_DEVICE

                                                     ' NRI Devices
Public Const DP_NRI_G40 = 1 Or DP_MANU_NRI _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_COIN_ACCEPT_DEVICE

Public Const DP_NRI_CURRENZA_H2 = 1 or DP_MANU_NRI _
                                       or DP_CCTALK_INTERFACE _
                                       or DP_COIN_PAYOUT_DEVICE

                                                     ' ICT Devices
Public Const DP_ICT_U85 = 1 Or DP_MANU_ICT _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_COIN_ACCEPT_DEVICE

                                                     ' AstroSystems Devices
Public Const DP_AST_GBA = 1 or DP_MANU_ASTROSYSTEMS	_
                            Or DP_CCTALK_INTERFACE _
                            Or DP_NOTE_ACCEPT_DEVICE

                                                     ' JCM Devices
Public Const DP_JCM_CC_EBA = 0 Or DP_MANU_JCM _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_JCM_CC_WBA = 1 Or DP_MANU_JCM _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_JCM_NOTE = 0 Or DP_MANU_JCM _
                                       Or DP_JCM_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE


                                       '  GPT Devices
Public Const DP_GPT_NOTE = 0 Or DP_MANU_GPT _
                                       Or DP_GPT_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE


                                                    ' Asahi Seiko Devices
Public Const DP_AS_WH2 = 0 Or DP_MANU_ASAHI_SEIKO _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_COIN_PAYOUT_DEVICE


Public Const DP_MERKUR_100        =  1 Or DP_MANU_MERKUR _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_ACCEPT_DEVICE

Public Const DP_MERKUR_100_PAY    =  1 Or DP_MANU_MERKUR _
                                       Or DP_CCTALK_INTERFACE _
                                       Or DP_NOTE_PAYOUT_DEVICE

Public Const DP_FUJITSU_F56       =  6 Or DP_MANU_FUJITSU _
                                       Or DP_F56_INTERFACE _
                                       Or DP_NOTE_PAYOUT_DEVICE

Public Const DP_FUJITSU_F53       =  3 Or DP_MANU_FUJITSU _
                                       Or DP_F56_INTERFACE _
                                       Or DP_NOTE_PAYOUT_DEVICE

'*************************************************************
'Configuration Constants
'
'These constants are used when loading configuartion records
'into the Genoa / Milan cards.
'
'*************************************************************

' Comms Channels
Public Const UNUSED_CHANNEL = 255
Public Const CCTALK_CHANNEL = 0
Public Const MILAN_HI2_CHANNEL = 1
Public Const GENOA_RS232_CHANNEL = 1
Public Const MAIN_RS232_CHANNEL = 2
Public Const MDB_CHANNEL = 3

' Protocol Values
Public Const DIAGNOSTICS_COMMS = 0
Public Const CCTALK_PROTOCOL = 1
Public Const HI2_PROTOCOL = 2
Public Const ID003_PROTOCOL = 3
Public Const GPT_PROTOCOL = 4
Public Const ARDAC_PROTOCOL = 5
Public Const PAYCHECK_PROTOCOL = 6

' Device Values
Public Const COIN_ACCEPTOR = 0
Public Const NOTE_ACCEPTOR = 1
Public Const COIN_DISPENSER = 2
Public Const BARCODE_PRINTER = 3









'****************************************************************
'The OpenMHE call is made by the PC application software to open the
'"Money Handling Equipment" Interface.
'
'Parameters
'None
'
'Return Value
'If the Open call succeeds then the value zero is returned.
'
'In the event of a failure an error code will be returned
'either as a direct echo of a Windows API call failure
'or to indicate internally detected failures that closely
'correspond to the quoted meanings.
'****************************************************************
Declare Function OpenMHEVersion Lib "AesImhei.dll" Alias "_OpenMHEVersion@4" (ByVal InterfaceVersion As Long) As Long

'****************************************************************
'The OpenSpecificMHE call is made by the PC application software
'to open a "Money Handling Equipment" Interface with a specific
'serial number.
'
'Parameters
'Alphanumeric
'
'Return Value
'If the Open call succeeds then the value zero is returned.
'
'In the event of a failure an error code will be returned,
'either as a direct echo of a Windows API call failure,
'or to indicate internally detected failures that closely
'correspond to the quoted meanings.
'****************************************************************
Declare Function OpenSpecificMHEVersion Lib "Aesimhei.dl" Alias "_OpenSpecificMHEVersion@8" _
                                                                                                (ByRef Serial As CharString, ByVal InterfaceVersion As Long) As Long
                               
'****************************************************************
'The EnableInterface call is used to allow users to enter coins
'or notes into the system. This would be called when a game is
'initialised and ready to accept credit.
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'This must be called following the call to OpenMHE before
'any coins / notes will be registered.
'****************************************************************
Declare Sub EnableInterface Lib "AesImhei.dll" Alias "_EnableInterface@0" ()




'****************************************************************
'The DisableInterface call is used to prevent users from
'entering any more coins or notes.
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'1. There is no guarantee that a coin or note can not be
'successfully read after this call has been made, a
'successful read may be in progress.
'****************************************************************
Declare Sub DisableInterface Lib "AesImhei.dll" Alias "_DisableInterface@0" ()




'****************************************************************
'The CurrentValue call is used to determine the total value
'of all coins and notes read by the money handling equipment
'connected to the interface.
'
'Parameters
'None
'
'Return Value
'The current value, in the lowest denomination of the
'currency (i.e. cents / pence etc.) of all coins and notes read.
'
'Remarks
'1. The value returned by this call is never reset, but
'increments for the life of the interface card. Since
'this is a long (32 bit) integer, the card can accept
'£21,474,836.47 of credit before it runs into any rollover
'problems. This value is expected to exceed the life of the game.
'2. It is the responsibility of the application to keep track
'of value that has been used up and to monitor for new
'coin / note insertions by increases in the returned value.
'3. Note that this value should be read following the call
'to OpenMHE and before the call to EnableInterface to establish
'a starting point before any coins or notes are read.
'****************************************************************
Declare Function CurrentValue Lib "AesImhei.dll" Alias "_CurrentValue@0" () As Long





'****************************************************************
'The PayOut call is used by the PC application to instruct
'the interface to pay out coins (or notes).
'
'
'Parameters
'This is the value, in the lowest denomination of the currency
'(i.e. cents / pence etc.) of the coins and notes to be paid out.
'
'Return Value
'None
'
'Remarks
'1. This function operates in value, not coins. It is the
'responsibility of the interface to decode this and to choose how
'many coins (or notes) to pay out, and from which device to pay
'them.
'****************************************************************
Declare Sub PayOut Lib "AesImhei.dll" Alias "_PayOut@4" (ByVal Value As Long)



'/****************************************************************
'The PayStatus call provides the current status of the payout process.
'
'
'Parameters
'
'None
'
'Return Values.
'            Mnemonic          Value     Meaning
Public Const PAY_ONGOING = 0           ' The interface is in the process of paying out
Public Const PAY_FINISHED = 1          ' The payout process is up to date
Public Const PAY_EMPTY = -1            ' The dispenser is empty
Public Const PAY_JAMMED = -2           ' The dispenser is jammed
Public Const PAY_US = -3               ' Dispenser non functional
Public Const PAY_FRAUD = -4            ' Fraud attempt detected
Public Const PAY_FAILED_BLOCKED = -5   ' The dispenser optos are blocked
Public Const PAY_NO_HOPPER = -6        ' There are no dispensers
Public Const PAY_INHIBITED = -7        ' The only possible dispenser is inhibited
Public Const PAY_SECURITY_FAIL = -8    ' The internal security checks failed
Public Const PAY_HOPPER_RESET = -9     ' The hopper reset during a payout
Public Const PAY_NOT_EXACT = -10       ' The hopper cannot payout the exact amount
Public Const PAY_GHOST = -11           ' This hopper does not really exist - it's a part of another unit
Public Const PAY_NO_KEY = -12          ' The hopper needs to perform a Key Exchange

'Remarks
'
'Following a call to PayOut, the programmer should poll this to
'check the progress of the operation.
'
'If one out of mutliple hoppers has a problem the PCI card will do
'the best it can.
'
'If it can not pay out the entire amount, the status will reflect
'the last attempt.
'
'****************************************************************/
Declare Function LastPayStatus Lib "AesImhei.dll" Alias "_LastPayStatus@0" () As Long





'****************************************************************
'The IndicatorOn / IndicatorOff calls are used by the PC application
'to control LED's and indicator lamps connected to the interface.
'
'Parameters
'This is the number of the Lamp that is being controlled.
'
'Return Value
'None
'
'Remarks
'1. Although the interface is described in terms of lamps, any
'equipment at all may in fact be controlled by these calls
'depending only on what is physically connected to the interface card.
'****************************************************************
Declare Sub IndicatorOn Lib "AesImhei.dll" Alias "_IndicatorOn@4" (ByVal IndicatorNumber As Long)
Declare Sub IndicatorOff Lib "AesImhei.dll" Alias "_IndicatorOff@4" (ByVal IndicatorNumber As Long)





'****************************************************************
'The calls to SwitchOpens and SwitchCloses are made by the PC
'application to read the state of switches connected to the
'interface card.
'
'
'Parameters
'This is the number of the switch that is being controlled.
'
'In principle the interface card can support 64 switches
'though note that not all of these may be physically present
'within a game cabinet.
'
'Return Value
'The number of times that the specified switch has been
'observed to open or to close, respectively.
'
'Remarks
'1. The value returned by this call is only (and always)
'reset by the OpenMHE call.
'
'2. The convention is that at initialisation time all
'switches are open.
'
'3. A switch that starts off closed will therefore return a
'value of 1 to a SwitchCloses call immediately following the
'OpenMHE call.
'
'4. The expression (SwitchCloses(n) == SwitchOpens(n)) will
'always return 0 if the switch is currently closed and 1 if
'the switch is currently open.
'
'5. The pressing / tapping of a switch by a user will be
'detected by an increment in the value returned by
'SwitchCloses or SwtichOpens.
'
'6. The user only needs to monitor changes in one of the
'two functions (in the same way as most windowing interfaces
'only need to provide functions for button up or button
'down events).
'****************************************************************
Declare Function SwitchOpens Lib "AesImhei.dll" Alias "_SwitchOpens@4" (ByVal SwitchNumber As Long) As Long
Declare Function SwitchCloses Lib "AesImhei.dll" Alias "_SwitchCloses@4" (ByVal SwitchNumber As Long) As Long





'****************************************************************
'The CurrentPaid call is available to keep track of
'the total money paid out because of calls to the
'PayOut function.
'
'Parameters
'None
'
'Return Value
'The current value, in the lowest denomination of the
'currency (i.e. cents / pence etc.) of all coins and notes
'ever paid out.
'
'Remarks
'
'1. This value that is returned by this function is updated
'in real time, as the money handling equipment succeeds in
'dispensing coins.
'
'2. The value that is returned by this call is never reset
'but increments for the life of the interface card. It is
'the responsibility of the application to keep track of
'starting values and to monitor for new coin / note successful
'payments by increases in the returned value.
'
'3. Note that this value can be read following the call to
'OpenMHE and before the call to EnableInterface to establish
'a starting point before any coins or notes are paid out.
'****************************************************************
Declare Function CurrentPaid Lib "AesImhei.dll" Alias "_CurrentPaid@0" () As Long




'****************************************************************
'The SystemStatus call provides a single summary of the status
'all the money handling equipment connected to the interface.
'It is a logical OR of the status of all of the individual
'device statuses.
'
'Parameters
'None
'
'Return Value
'Zero if all devices are completely normal.
'Negative if there is a major problem with any device.
'
'Remarks
'
'This returns a logical OR of the status of all of the individual
'device statuses.
'****************************************************************/
Declare Function SystemStatus Lib "AesImhei.dll" Alias "_SystemStatus@0" () As Long





'****************************************************************
'Detect updates to the data presented to the API by the firmware.
'
'The fact that the value returned by CurrentUpdates has changed,
'prompts the application to re-examine all the variable data
'in which it is interested.
'
'Parameters
'None
'
'Return Value
'Technically CurrentUpdates returns the number of times that the
'API data has been updated since the PC system initialised.
'In practice, only changes in this value are significant.
'
'Remarks
'1. It is possible that the value could change without
'any visible data changing.
'****************************************************************
Declare Function CurrentUpdates Lib "AesImhei.dll" Alias "_CurrentUpdates@0" () As Long






'****************************************************************
'NextEvent
'
'Synopsis
'All Acceptor / hopper events received will be queued (in a short queue).
'These can be retrieved with NextEvent.
'
'Parameters
'1. EventDetail
'   NULL or the address of the strucutre at which to store the details of
'   the event.
'
'Return Value
'The return code is 0 (IMHEI_NULL) if no event is available  otherwise
'it is the next event.
'
'Remarks
'1. In the event that one or more event is missed  the code
'   IMHEI_OVERFLOW will replace the missed events.
'2. As note  coin & hoper event codes do not overlap  the EventDetail
'   parameter can often be set to NULL as the device is implicit in the event.
'3. The values for the codes returned are in the separate files ImheiEvent
'
'****************************************************************
Type EventDetailBlock
    EventCode      As Long      ' The code (as rturned by NextEvent
    RawEvent       As Long      ' The actual code returned by the peripheral
    DispenserEvent As Long      ' True if the device was a dispenser
                                      ' False for an acceptor
    Index          As Long      ' The ReadxxxBlock index of the generating device
End Type

Declare Function NextEvent Lib "AesImhei.dll" Alias "_NextEvent@4" (ByRef EventDetails As EventDetailBlock) As Long

                               
      
      
                               


'****************************************************************
'The AvailableValue call is available to keep track of how much
'money is available in the coin (or note) dispensers.
'
'Parameters
'
'None
'
'Return Value
'
'The approximate minimum value, in the lowest denomination
'of the currency (i.e. cents / pence etc.) of all coins and
'notes that could be paid out.
'
'Remarks
'The accuracy of the value returned by this call is entirely
'dependent upon the accuracy of the information returned by
'the money dispensers.
'
'If no information is obtainable, this returns 10,000 if at
'least one dispenser is working normally, and zero if all
'dispensers are failing to pay out.
'****************************************************************/
Declare Function AvailableValue Lib "AesImhei.dll" Alias "_AvailableValue@0" () As Long




'****************************************************************
'The ValueNeeded call provides an interface to an optional
'credit card acceptor unit.
'
'It is not envisaged that this would be used within many systems
'but may be used, for example, in vending applications.
'
'
'Parameters
'The figure that CurrentValue is required to reach before
'the next event can happen.
'
'Return Value
'None
'
'Remarks
'1. This function does not necessarily have any affect
'on the system. If the MHE includes a credit card acceptor
'or similar, then the MHE interface unit will arrange for the
'next use of that unit to bring CurrentValue up to latest
'figure supplied by this routine.
'
'2. If CurrentValue is greater or equal to the last supplied
'figure then any such acceptors are disabled.
'****************************************************************
Declare Sub ValueNeeded Lib "AesImhei.dll" Alias "_ValueNeeded@4" (ByVal Amount As Long)





'****************************************************************
'SerialNumber
'
'Synopsis
'The SerialNumber call provides access to the electronic serial number
'stored on the device.
'
'Parameters
'None
'
'Return Value
'32 bit serial number.
'
'Remarks
'1. A serial number of -1 indicates that a serial number has not been
'set in the device.
'2. A serial number of 0 indicates that the device firmware does not
'support serial numbers
'****************************************************************
Declare Function SerialNumber Lib "AesImhei.dll" Alias "_SerialNumber@0" () As Long





'****************************************************************
'escrow
'
'At start-up, the system does not report escrow details and all
'acceptors are run in "normal" mode where all currency is accepted.
'To use escrow the call EscrowEnable() is issued. Following this
'the call EscrowThroughput() will return the total value of all
'currency that has ever been held in escrow (in the same way as
'for CurrentValue() except that the value is preserved over resets).
'An increase in the value returned indicates that a note is now in
'escrow.
'The HeldInEscrow field within the AcceptorCoin structure will
'indicate the number of each note / coin that is currently being held.
'
'The EscrowAccept() call will cause the IMHEI card to complete
'the acceptance of the currency in question that, when complete,
'will be indicated by an increase in CurrentValue().
'An EscrowReturn() call will cause the currency to be returned
'with no further indication to the game. Following either call,
'the EscrowThroughput() value may increase immediately due to
'another acceptor having an escrow holding.
'****************************************************************


'****************************************************************
'EscrowEnable - Change the mode of operation of all escrow capable
'acceptors to hold inserted currency in escrow until a call of
'EscrowAccept.
'
'The EscrowEnable call is used to start using the escrow system
'
'Parameters
'None
'
'Return Value
'None
'****************************************************************}
Declare Sub EscrowEnable Lib "AesImhei.dll" Alias "_EscrowEnable@0" ()




'****************************************************************
'EscrowDisable - Change the mode of operation of all escrow capable
'acceptors back to the default mode in which all currency is fully
'accepted on insertion
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'1. If any currency is currently held in escrow when this call
'is made, it will be accepted without comment.
'****************************************************************
Declare Sub EscrowDisable Lib "AesImhei.dll" Alias "_EscrowDisable@0" ()




'****************************************************************
'EscrowThroughput - Determine the cumulative monetary value that
'has been held in escrow since the system was reset.
'
'The EscrowThroughput call is used to determine the cumulative total
'value of all coins and notes read by the money handling equipment
'that have ever been held in escrow.
'
'Parameters
'None
'
'Return Value
'The current value, in the lowest denomination of the currency
'(i.e. cents / pence etc.) of all coins and notes read.
'
'Remarks
'1. It is the responsibility of the application to keep track of
'value that has been accepted and to monitor for new coin / note
'insertions by increases in the returned value.
'
'2. Note that this value should be read following the call to OpenMHE
'and before the call to EnableInterface / EscrowEnable to establish a
'starting point before any coins or notes are read.
'****************************************************************
Declare Function EscrowThroughput Lib "AesImhei.dll" Alias "_EscrowThroughput@0" () As Long




'****************************************************************
'EscrowAccept - If the acceptor that was last reported as holding
'currency in escrow is still in that state, this call will cause
'it to accept that currency.
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'1. If a second acceptor has (unreported) currency in escrow
'at the time this call is made, it will immediately cause the
'EscrowThroughput to be updated.
'2. If no currency is currently held in escrow when this call is
'made, it will be silently ignored.
'****************************************************************
Declare Sub EscrowAccept Lib "AesImhei.dll" Alias "_EscrowAccept@0" ()




'****************************************************************
'EscrowReturn - If the acceptor that was last reported as holding
'currency in escrow is still in that state, this call will cause
'it to return that currency.
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'1. If a second acceptor has (unreported) currency in escrow at
'the time this call is made, it will immediately cause the
'EscrowThroughput to be updated.
'2. If no currency is currently held in escrow when this call
'is made, it will be silently ignored.
'****************************************************************
Declare Sub EscrowReturn Lib "AesImhei.dll" Alias "_EscrowReturn@0" ()







'****************************************************************
'Bar Codes
'Where an acceptor provides barcode facilities  the IMHEI card fully
'support this by enabling bar code acceptance and reporting the barcodes
'read.
'
'Barcode reading is always handled using the Escrow position on the
'acceptor. The barcode is held in the acceptor pending a call from the
'application the either stack or return it.
'
'In most systems  only one barcode capable acceptor will be present
'the IMHEI card will however support barcodes on an unlimited number
'of acceptors. In order to allow for accurate information and control
'to pass between the game and the IMHEI firmware  the barcode reported
'is limited to a single acceptor at time. If two acceptors are holding
'barcoded tickets at the same time  the second will not be reported until
'the first has completed.
'
'All the barcodes processed by the IMHEI system are in the format
'“Interleaved 2 of 5” and are 18 characters long. (Functions return a 19
'character NULL terminated string.)
'
'Barcodes read by the IMHEI can also be printed if a dedicated barcode
'printer is connected.
'****************************************************************





'****************************************************************
'BarcodeEnable
'
'Synopsis
'Change the mode of operation of all Barcode capable acceptors to
'accept tickets with barcodes on them.
'
'The BarcodeEnable call is used to start using the Barcode system
'
'Parameters
'None
'
'Return Value
'None
'****************************************************************
Declare Sub BarcodeEnable Lib "AesImhei.dll" Alias "_BarcodeEnable@0" ()




'****************************************************************
'BarcodeDisable
'
'Synopsis
'Change the mode of operation of all Barcode capable acceptors
'back to the default mode in which only currency is accepted.
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'1. If a Barcoded ticket is currently held when this call is made
'it will be returned without comment.
'****************************************************************
Declare Sub BarcodeDisable Lib "AesImhei.dll" Alias "_BarcodeDisable@0" ()






'****************************************************************
'BarcodeInEscrow
'
'Synopsis
'This is the regular “polling” call that the application should
'make into the DLL to obtain the current status of the barcode
'system. If a barcode is read by an acceptor it will be held in
'escrow and this call will return true in notification of the fact.
'
'Parameters
'1. BarcodeString
'A pointer to a buffer of at least 19 characters into which the
'last barcode read from any acceptor is placed. This will be all
'NULL if no barcoded ticket has been read since system start-up.
'
'Return Value
'The return value is true if there is a barcode ticket currently
'held in an Acceptor  flase if there is not.
'
'Remarks
'1. There is no guarantee that at the time the call is made the
'acceptor has not irrevocably decided to auto-eject the ticket.
'****************************************************************
Declare Function BarcodeInEscrow Lib "AesImhei.dll" Alias "_BarcodeInEscrow@4" (ByRef BarcodeString As CharString) As Long











'****************************************************************
'BarcodeStacked
'
'Synopsis
'Following a call to BarcodeAccept the system may complete the
'reading of a barcoded ticket. If it does  then the count returned
'by BarcodeStacked will increment. There is no guarantee that this
'will take place  so the application should continue to poll
'BarcodeInEscrow.
'
'Parameters
'2. BarcodeString
'A pointer to a buffer of at least 19 characters into which the
'last barcode read from any acceptor is placed. This will be all
'NULL if no barcoded ticket has been read since system start-up.
'
'Return Value
'The count of all the barcoded tickets that have been stacked since
'system start-up. An increase in this value indicates that the
'current ticket has been stacked - its contents will be in the
'BarcodeString buffer.
'
'Remarks
'2. It is the responsibility of the application to keep track of
'the number of tickets that have been accepted and to monitor for
'new insertions by increases in the returned value.
'
'3. Note that this value should be read following the call to
'OpenMHE and before the call to EnableInterface / BarcodeEnable
'to establish a starting point before any new tickets are read.
'****************************************************************
Declare Function BarcodeStacked Lib "AesImhei.dll" Alias "_BarcodeStacked@4" (ByRef BarcodeString As CharString) As Long







'****************************************************************
'BarcodeAccept
'
'Synopsis
'If the acceptor that was last reported as holding a Barcode
'ticket is still in that state  this call will cause it to
'accept that currency.
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'1. If a second acceptor has (unreported) currency in Barcode
'at the time this call is made  it will immediately cause the
'BarcodeTicket to be updated.
'2. If no ticket is currently held when this call is made  it
'will be silently ignored.
'****************************************************************
Declare Sub BarcodeAccept Lib "AesImhei.dll" Alias "_BarcodeAccept@0" ()






'****************************************************************
'BarcodeReturn
'
'Synopsis
'If the acceptor that was last reported as holding a Barcode
'ticket is still in that state  this call will cause it to
'return that currency.
'
'Parameters
'None
'
'Return Value
'None
'
'Remarks
'1. If a second acceptor has (unreported) currency in Barcode at
'the time this call is made  it will immediately cause the
'BarcodeTicket to be updated.
'2. If no ticket is currently held when this call is made
'it will be silently ignored.
'****************************************************************
Declare Sub BarcodeReturn Lib "AesImhei.dll" Alias "BarcodeReturn_@0" ()








'****************************************************************
'BarcodePrint
'
'Synopsis
'This call is used to print a barcoded ticket  if the IMHEI system
'supports a printer.
'
'Parameters
'1. TicketContents.
'Pointer to a TicketDescription structure that hold pointers to
'the strings that the application is “filling in”. NULL pointers
'will cause the relevant fields to default (usually to blanks).
'****************************************************************
Type TicketDescription
    TicketType          As Long     ' The "template" for the ticket
'    BarcodeData       As CharString
'    AmountInWords     As CharString
'    AmountAsNumber    As CharString       ' But still a string
'    MachineIdentity   As CharString
'    DatePrinted       As CharString
'    TimePrinted       As CharString
End Type
'
'****************************************************************
'
'Return Value
'None
'
'Remarks
'1. There are a number of fields that can be printed a barcode ticket.
'Rather than provide a function with a large number of possibly null
'parameters  we use a structure  which may have fields added to end.
'The user should ensure that all unused pointers are zero.
'2. Before issuing this call the application should ensure that
'BarcodePrintStatus has returned a status of PRINTER_IDLE
'3. The mechanics of the priniting mechanism rely on BarcodePrintStatus
'being called regularly after this call  in order to “stage” the data
'to the interface.
'****************************************************************
Declare Sub BarcodePrint Lib "AesImhei.dll" Alias "_BarcodePrint@4" (ByRef TicketContents As TicketDescription)








'****************************************************************
'BarcodePrintStatus
'
'Synopsis
'This call is used to determine the status of the barcoded ticket
'printing system.
'
'Parameters
'None
'
'Return Value
'This is a bit sensitive status. All error conditions have the top (sign)
'bit set. The values for None and Idle are full 32 bit values.
'            Mnemonic                      Value             Meaning
Public Const PRINTER_NONE = 0                                ' Printer non functional / not present
Public Const PRINTER_FAULT = &H80000000                      ' There is a fault somewhere
Public Const PRINTER_IDLE = &H1                              ' The printer is OK / Idle /Finished
Public Const PRINTER_BUSY = &H2                              ' Printing is currently taking place

Public Const PRINTER_PLATEN_UP = &H4
Public Const PRINTER_PAPER_OUT = &H8
Public Const PRINTER_HEAD_FAULT = &H10
Public Const PRINTER_VOLT_FAULT = &H40
Public Const PRINTER_TEMP_FAULT = &H80
Public Const PRINTER_INTERNAL_ERROR = &H100
Public Const PRINTER_PAPER_IN_CHUTE = &H200
Public Const PRINTER_OFFLINE = &H400
Public Const PRINTER_MISSING_SUPPY_INDEX = &H800
Public Const PRINTER_CUTTER_FAULT = &H1000
Public Const PRINTER_PAPER_JAM = &H2000
Public Const PRINTER_PAPER_LOW = &H4000
Public Const PRINTER_OPEN = &H8000
                                                             ' These values can be set when Idle
Public Const PRINTER_TOP_OF_FORM = &H10000                   ' The last ticket is finished
Public Const PRINTER_BARCODE_DONE = &H20000                  ' The last barcode has been printed
Public Const PRINTER_JUST_RESET = &H40000

'Remarks
'1. The mechanics of the priniting mechanism rely on this
'being called regularly after the BarcodePrint call  in order
'to “stage” the data to the interface  until PRINTER_BUSY is no
'longer returned.
'****************************************************************
Declare Function BarcodePrintStatus Lib "AesImhei.dll" Alias "_BarcodePrintStatus@0" () As Long









'****************************************************************
'The ReadAcceptorDetails call provides a snapshot of all
'the information possessed by the interface on a single
'unit of money handling equipment.
'
'
'Parameters
'
'1. Number
'The serial number of the coin or note acceptor about
'which information is required.
'
'2. Snapshot
'A pointer to a program buffer into which all the
'information about the specified acceptor will be copied.
'
'Return Value
'
'True if the specified input device exists, False if the
'end of the list is reached.
'
'Remarks
'The serial numbers of the acceptors are contiguous and
'run from zero upwards.
'****************************************************************
Declare Function ReadAcceptorDetails Lib "AesImhei.dll" Alias "_ReadAcceptorDetails@8" (ByVal Number As Long, _
                                                                                         ByRef Snapshot As AcceptorBlock) As Long





'****************************************************************
'The WriteAcceptorDetails call updates all the changeable
'information to the interface for a single unit of money
'accepting equipment.
'
'Parameters
'1. Number
'        The serial number of the coin or note acceptor
'        being configured.
'
'2. Snapshot
'        A pointer to a program buffer containing the
'        configuration data for the specified acceptor.
'        See below for details.
'
'Return Value
'None.
'
'Remarks
'The serial numbers of the acceptors are contiguous
'and run from zero upwards.
'A call to ReadAcceptorDetails followed by call to
'WriteAcceptorDetails for the same data will have no
'effect on the system.
'****************************************************************
Declare Sub WriteAcceptorDetails Lib "AesImhei.dll" Alias "_WriteAcceptorDetails@8" (ByVal Number As Long, ByRef Snapshot As AcceptorBlock)



'****************************************************************
'The ReadDispenserDetails call provides a snapshot of all the
'information possessed by the interface on a single unit of
'money dispensing equipment.
'
'Parameters
'1. Number
'The serial number of the coin or note dispenser about which
'information is required.
'
'2. Snapshot
'A pointer to a program buffer into which all the information about
'the specified dispenser will be copied.
'
'Return Value
'True if the specified input device exists, False if the end of the
'list is reached.
'
'Remarks
'The serial numbers of the dispensers are contiguous and run from
'zero upwards.
'****************************************************************/
Declare Function ReadDispenserDetails Lib "AesImhei.dll" Alias "_ReadDispenserDetails@8" (ByVal Number As Long, ByRef Snapshot As DispenserBlock) As Long





'****************************************************************
'The WriteDispenserDetails call updates all the changeable information
'to the interface for a single unit of money handling equipment.
'
'
'Parameters
'1. Number
'The serial number of the coin or note dispenser being configured.
'
'2. Snapshot
'A pointer to a program buffer containing the configuration data for
'the specified dispenser. See below for details.
'
'Return Value
'None.
'
'Remarks
'
'The serial numbers of the dispensers are contiguous and run
'from zero upwards. A call to ReadDispenserDetails followed by
'call to WriteDispenserDetails for the same data will have no
'effect on the system.
'****************************************************************
Declare Sub WriteDispenserDetails Lib "AesImhei.dll" Alias "_WriteDispenserDetails@8" (ByVal Number As Long, ByRef Snapshot As DispenserBlock)





'****************************************************************
'The CounterIncrement call is made by the PC application software
'to increment a specific counter value.
'
'Parameters
'1. CounterNo
'This is the number of the counter to be incremented.
'
'
'2. Increment
'This is the value to be added to the specified counter.
'
'
'Return Value
'None
'
'Remarks
'If the counter specified is higher than the highest supported
'then call is silently ignored.
'
'****************************************************************
Declare Sub CounterIncrement Lib "AesImhei.dll" Alias "_CounterIncrement@8" (ByVal CounterNo As Byte, ByVal Increment As Integer)






'****************************************************************
'The CounterCaption call is used to associate a caption with the
'specified counter. This is related to the CounterDisplay call
'described below.
'
'
'Parameters
'1. CounterNo
'This is the number of the counter to be incremented.
'
'Caption
'2. This is an ASCII string that will be associated with the counter.
'
'Return Value
'None
'
'Remarks
'1. The meter hardware may have limited display capability.
'It is the system designer’s responsibility to use captions
'that are within the meter hardware’s capabilities.
'
'2. If the counter specified is higher than the highest supported
'then call is silently ignored.
'****************************************************************/
Declare Sub CounterCaption Lib "AesImhei.dll" Alias "_CounterCaption@8" (ByVal CounterNo As Byte, ByRef Caption As CharString)



'****************************************************************
'The CounterRead call is made by the PC application software to
'obtain a specific counter value as stored by the meter interface.
'
'Parameters
'1. CounterNo
'   This is the number of the counter to be incremented.
'
'Return Value
'The Value of the specified meter at system start-up.
'
'Remarks
'1. If the counter specified is higher than the highest supported
'   then the call returns -1
'
'2. If the counter external hardware does not support counter
'   read-out, then this will return the total of all increments
'   since PC start-up.
'
'3. If error conditions prevent the meter updating, this call will
'   show the value it should be at, not its actual value.
'   (The value is only read from the meter at system start-up.)
'****************************************************************
Declare Function CounterRead Lib "AesImhei.dll" Alias "_CounterRead@4" (ByVal CounterNo As Byte) As Long



'****************************************************************
'The ReadCounterCaption call is used to determine the caption for
'the specified counter
'
'Parameters
'1. CounterNo
'   This is the number of the counter to be incremented.
'
'Return Value
'None
'
'Remarks
'1. If the counter specified is higher than the highest supported
'   then the call returns an empty string ("").
'2. All captions stored in the meter are read out at system start-up
'   and used to initialise the captions used by the interface.
'****************************************************************
Declare Function ReadCounterCaption Lib "AesImhei.dll" Alias "_ReadCounterCaption@4" (ByVal CounterNo As Byte) As CharString



'****************************************************************
'The CounterDisplay call is used to control what is displayed on the meter.
'
'Parameters
'1. DisplayCode
'If positive, this specifies the counter that will be continuously
'             display by the meter hardware.
'
'If negative, then the display will cycle between the caption (if set)
'             for the specified counter for 1 second, followed by its
'             value for 2 seconds.
'
'Return Value
'None
'
'Remarks
'1. This result of this call with a negative parameter is undefined
'   if no counters have an associated caption.
'2. Whenever the meter displayed is changed, the caption (if set)
'   is always displayed for one second.
'****************************************************************
Declare Sub CounterDisplay Lib "AesImhei.dll" Alias "_CounterDisplay@4" (ByVal DisplayCode As Long)



'****************************************************************
'The MeterStatus call is used determine whether working meter
'equipment is connected.
'
'long MeterStatus ( void )
'
'Parameters
'None
'
'Return Value
'One of the following:
'Return Values.
'            Mnemonic          Value     Meaning
Public Const METER_OK = 0             '  A Meter is present and working correctly
Public Const METER_MISSING = 1        '  No Meter has ever been found
Public Const METER_DIED = 2           '  The Meter is no longer functioning
Public Const METER_FAILED = 3         '  The Meter is functioning but is itself

'Remarks
'None
'****************************************************************
Declare Function MeterStatus Lib "AesImhei.dll" Alias "_MeterStatus@0" () As Long




'****************************************************************
'The MeterSerialNo call is used determine which item meter
'equipment is connected.
'
'
'Parameters
'None
'
'Return Value
'The 32-bit serial number retrieved from the meter equipment.
'
'Remarks
'
'Where the meter equipment is not present or does not have serial
'number capabilities, zero is returned.
'****************************************************************
Declare Function MeterSerialNo Lib "AesImhei.dll" Alias "_MeterSerialNo@0" () As Long







'****************************************************************
'The E2PromReset call is made by the PC application software to
'clear all the E2PROM counters on the card.
'
'
'Parameters
'1. LockE2Prom
'   This is a Boolean flag.
'   If zero, then the E2PROM counters may be reset again later.
'   If non zero, then all future calls to this function will have
'   no effect on the card.
'
'Return Value
'None
'
'Remarks
'None
'****************************************************************
Declare Sub E2PromReset Lib "AesImhei.dll" Alias "_E2PromReset@4" (ByVal LockE2Prom As Long)






'****************************************************************
'The E2PromWrite call is made by the PC application software
'to write to all or part of the user E2PROM on the card.
'
'
'Parameters
'1. UserBuffer
'   This is the address of the user’s buffer, from which BufferLength
'   bytes of data are copied to the start of the user area.
'2. BufferLength
'   This is the count of the number bytes to be transferred.
'   If this is greater than 256 the extra will be silently ignored.
'
'Return Value
'None
'
'Remarks
'1. This call schedules the write to the E2PROM memory and returns
'   immediately. There is no way of knowing when the E2PROM has
'   actually been updated but, barring hardware errors, it will be
'   complete within one second of the call.
'****************************************************************
Declare Sub E2PromWrite Lib "AesImhei.dll" Alias "_E2PromWrite@8" (ByRef UserBuffer As CharString, ByVal BufferLength)






'****************************************************************
'The E2PromRead call is made by the PC application software to obtain
'all or part of the user E2PROM from the card.
'
'Parameters
'1. UserBuffer
'   This is the address of the user’s buffer, into which the current
'   contents of the user E2PROM area are copied.
'2. BufferLength
'   This is the count of the number bytes to be transferred. If this
'   is greater than 256 the extra will be silently ignored.
'
'Return Value
'None
'
'Remarks
'1. Unwritten E2Prom memory is initialised all one bits.
'2. Writes performed by E2PromWrite will be reflected immediately
'   in the data returned by this function, regardless of whether
'   or not they have been committed to E2Prom memory.
'****************************************************************}
Declare Sub E2PromRead Lib "AesImhei.dll" Alias "_E2PromRead@8" (ByRef UserBuffer As CharString, ByVal BufferLength)









'****************************************************************
'Synopsis
'The SetDeviceKey call is made by the PC application software to
'set such things as an encryption key.
'
'
'Parameters
'1. InterfaceNo
'   The Interface on which the device is located
'2. Address
'   The address of the device whose key is being updated
'3. Key
'   The 32 bit key to be remembered for the device.
'
'Return Value
'None
'
'Remarks
'1. At present, this can only be used for a Lumina acceptor at address
'   40 on interface 2, the cctalk interface. The key (as 6 hex digits)
'   is used as the encryption key.
'
'2. An example application for this is available within the SDK folder
'   structure.
'****************************************************************
Declare Sub SetDeviceKey Lib "AesImhei.dll" Alias "_SetDeviceKey@12" (ByVal InterfaceNo As Long, ByVal Address As Long, ByVal Key As Long)






'***************************************************************
'The WriteInterfaceBlock call sends a "raw" block to the specified
'interface.
'
'There is no guarantee as to when, in relation to this, regular
'polling sequences will be sent, except that while the system is
'disabled, the interface card will not put any traffic onto the
'interface.
'
'Parameters
'1. Interface
'The serial number of the interface that is being accessed.
'
'2. Block
'A pointer to program buffer with a raw message for the interface.
'This must be a sequence of bytes, and must have any checksums
'and addresses required by the peripheral device included.
'3. Length
'
'The number of bytes in the message.
'
'Return Value
'None
'
'Remarks
'Using this function with some interfaces does not make sense
'see status returns from ReadInterfaceBlock.
'****************************************************************/
Declare Sub WriteInterfaceBlock Lib "AesImhei.dll" Alias "_WriteInterfaceBlock@12" (ByVal Interface As Long, ByRef Block As CharString, ByVal Length As Long)






'****************************************************************
'The ReadInterfaceBlock call reads the "raw" response to a
'single WriteInterfaceBlock.
'
'
'Parameters
'1. Interface
'The serial number of the interface being accessed
'
'2. Block
'A pointer to the program buffer into which any response is read.
'
'3. Length
'The space available in the program buffer.
'
'Return Values
'            Mnemonic              Value      Meaning
Public Const INTERFACE_NO_DATA = -5         '  The handshake has completed ; but no data was returned.
Public Const INTERFACE_TOO_LONG = -4        '  input command is too long
Public Const INTERFACE_NON_EXIST = -3       '  Non command oriented interface
Public Const INTERFACE_OVERFLOW = -2        '  Command buffer overflow
Public Const INTERFACE_TIMEOUT = -1         '  Timeout on the interface - no response occurred
Public Const INTERFACE_BUSY = 0             '  The response from the WriteInterfaceBlock has not
                                            '     yet been received
'
'Remarks
'
'1. Repeated calls to WriteInterfaceBlock without a successful
'response are not guaranteed not to overflow internal buffers.
'
'2. The program is expected to "poll" the interface for a response
'indicated by a non-zero return value.
'****************************************************************
Declare Function ReadInterfaceBlock Lib "AesImhei.dll" Alias "_ReadInterfaceBlock@12" (ByVal Interface As Long, ByRef Block As CharString, ByVal Length As Long) As Long







'****************************************************************
'The USBDriverStatus call allows an interested application to retrieve
'the status of the USBDriver program for Paylink system.
'
'Parameters
'    None
'
'Return Values
'            Mnemonic              Value     Meaning
Public Const NOT_USB = -1                    ' Interface is to a PCI card
Public Const USB_IDLE = 0                    ' No driver or other program running
Public Const STANDARD_DRIVER = 1             ' The driver program is running normally
Public Const FLASH_LOADER = 2                ' The flash re-programming tool is using the link
Public Const MANUFACTURING_TEST = 3          ' The manufacturing test tool is using the link
Public Const DRIVER_RESTART = 4              ' The standard driver is in the process of exiting / restarting
Public Const USB_ERROR = 5                   ' The driver has received an error from the low level driver
Public Const DRIVER_EXIT = 6                 ' A Driver exit has been requested by the OS
'
'Remarks
'
'For PCI systems this is obviously meaningless and the system returns NOT_USB
'
'****************************************************************
Declare Function USBDriverStatus Lib "AesImhei.dll" Alias "_USBDriverStatus@0" () As Long





'****************************************************************
'The USBDriverExit call allows a control application to request that
'the USB driver program exits in a controlled manner.
'
'Parameters
'    None
'
'Return Values
'    None
'
'Remarks
'
'This set the USBDriverStatus to DRIVER_RESTART. Driver programs with
'version 1.0.3.1 or greater will report their exit by changing the
'USBDriverStatus to USB_IDLE.
'
'For PCI systems this is obviously meaningless and has no effect.
'****************************************************************
Declare Sub USBDriverExit Lib "AesImhei.dll" Alias "_USBDriverExit@0" ()





'****************************************************************
'The FirmwareVersion call allows a control application to discover the
'exact description of the firmware running on the unit.
'
'Parameters
'    1.  CompileDate
'        This is a pointer to a 16 byte area that receives a null terminated
'        printable version of the date on which the firmware was installed.
'    2.  CompileTime
'        This is a pointer to a 16 byte area that receives a null terminated
'        printable version of the time at which the firmware was installed.
'
'Return Values
'    The firware version as a 32 bit integer. This is normally shown as
'    4 x 8 bit numbers separated by dots.
'
'Remarks
'
'Either or both of the charecter pointers may be null.
'****************************************************************
Declare Function FirmwareVersion Lib "AesImhei.dll" Alias "_FirmwareVersion@8" (ByRef CompileDate As CharString, _
                                                                                                                                                             ByRef CompileTime As CharString) As Long






'****************************************************************
'The IMHEIConsistencyError function allows an application to
'check that a transient (hardware) error has not caused corruption of the
'underlying data structures used to hold the current monetary situation.
'
'Parameters
'    1.  CoinTime
'        This is the minimum time in milliseconds that will elapse between
'        successive coin insertions. It should be overriden by the application
'        where a fast coin acceptor is in use.
'    2.  NoteTime
'        This is the minimum time in milliseconds that will elapse between
'        successive note insertions. It should be overriden by the application
'        where a fast note acceptor is in use.
'
'Return Value
'    If all the data structures are both consistent and reasonable, the function
'    return NULL.
'    If there is any problem an english text message is returned decribing
'    the problem.
'
'Remarks
'    1.  A non-NULL return is a totally unrecoverable situation.
'        It is expected that application will report the error,
'            and then stop operation.
'
'    2.  As well as calling this function periodically, it is recommended that
'        it is called after the detection of a credit increase.
'****************************************************************
Public Const STANDARD_COIN_TIME = 500
Public Const STANDARD_NOTE_TIME = 5000

Declare Function IMHEIConsistencyError Lib "AesImhei.dll" Alias "_IMHEIConsistencyError@8" (ByVal CoinTime As Long, ByVal NoteTime As Long) As CharString

Private Declare Function lstrlen Lib "Kernel32.dll" Alias "lstrlenA" ( _
    ByVal lpString As Long) As Long
Private Declare Function lstrcpy Lib "Kernel32.dll" Alias "lstrcpyA" ( _
    ByVal lpString1 As String, ByVal lpString2 As Long) As Long
Public Function OpenMHE() As Long
  OpenMHE = OpenMHEVersion(INTERFACE_VERSION)
End Function

Public Function OpenSpecificMHE(ByRef Serial As CharString) As Long
  OpenSpecificMHE = OpenSpecificMHEVersion(Serial, INTERFACE_VERSION)
End Function

    
Public Function GetString(ByRef Param As CString) As String
    Dim Temp As String
    Temp = String(lstrlen(Param.Pointer), " ")
    Call lstrcpy(Temp, Param.Pointer)
    GetString = Temp
End Function

