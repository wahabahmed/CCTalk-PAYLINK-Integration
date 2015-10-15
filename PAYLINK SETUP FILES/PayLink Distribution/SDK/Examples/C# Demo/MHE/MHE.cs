using System;
using System.Runtime.InteropServices;

namespace AES
{
    /// <summary>
    /// Money Handling Equiment.
    /// A class for interfacing with an Aardvark Intelligent Money Haldling Equipment Interface Box
    /// </summary>
    public class MHE
    {
        private bool enabled = false; // this is to keep track of the enabled status of the Interface
        private CounterMeter meter;
        private AcceptorList acceptors;
        private DispenserList dispensers;

        public EscrowFunc Escrow;
        public BarcodeFunc Barcode;
        public DESFunc DES;

        public class AcceptorList : System.Collections.Generic.List<Acceptor>
        {
            public new Acceptor this[int Index]
            {
                get
                {
                    Acceptor acceptor = this.Find((acc) => acc.number == Index);

                    if (acceptor != null)
                    {
                        AESImhei.ReadAcceptorDetails(acceptor.number, acceptor);
                    }

                    return acceptor;
                }
                set
                {
                    Acceptor acceptor = this.Find((acc) => acc.number == Index);

                    if (acceptor != null)
                    {
                        this.Remove(acceptor);
                    }
                    if (value != null)
                    {
                        this.Add(value);
                    }
                }
            }
        }

        public class DispenserList : System.Collections.Generic.List<Dispenser>
        {
            public new Dispenser this[int Index]
            {
                get
                {
                    Dispenser dispenser = this.Find((disp) => disp.number == Index);

                    if (dispenser != null)
                    {
                        AESImhei.ReadDispenserDetails(dispenser.number, dispenser);
                    }

                    return dispenser;
                }
                set
                {
                    Dispenser dispenser = this.Find((disp) => disp.number == Index);
                    if (dispenser != null)
                    {
                        this.Remove(dispenser);
                    }
                    dispenser = value;
                    this.Add(dispenser);
                }
            }
        }

        public AcceptorList Acceptors
        {
            get
            {
                return acceptors;
            }
        }

        public DispenserList Dispensers
        {
            get
            {
                return dispensers;
            }
        }

        public CounterMeter Meter
        {
            get
            {
                return meter;
            }
        }

        /// <summary>
        /// Opens the MHE interface.
        /// </summary>
        /// <returns></returns>
        public int Open()
        {
            int retValue = AESImhei.OpenMHE();

            if (retValue != 0) return retValue;

            meter = new CounterMeter();

            acceptors = new AcceptorList();
            // find out what Acceptors are connected by
            // attempting to get info on them
            for (int i = 0; i < 16; ++i)
            {
                // look for it and add it if it's there
                Acceptor acceptor = new Acceptor(i);
                if (AESImhei.ReadAcceptorDetails(i, acceptor))
                {
                    acceptors[i] = acceptor;
                }
            }

            dispensers = new DispenserList();
            // get info on all dispensers
            for (int i = 0; i < 16; ++i)
            {
                Dispenser dispenser = new Dispenser(i);
                if (AESImhei.ReadDispenserDetails(i, dispenser))
                {
                    dispensers[i] = dispenser;
                }
            }

            return retValue;
        }

        public bool Enabled
        {
            set
            {
                if (value)
                {
                    AESImhei.EnableInterface();
                }
                else
                {
                    AESImhei.DisableInterface();
                }
                enabled = value;
            }
            get
            {
                return enabled;
            }
        }

        public int CurrentValue
        {
            get
            {
                return AESImhei.CurrentValue();
            }
        }

        public int CurrentPaid
        {
            get
            {
                return AESImhei.CurrentPaid();
            }
        }

        public void PayOut(int Amount)
        {
            AESImhei.PayOut(Amount);
        }

        public DispenserPayStatus PayStatus
        {
            get
            {
                return (DispenserPayStatus)AESImhei.LastPayStatus();
            }
        }

        public enum AESWDriverStatus
        {
            NOT_USB = AESImhei.NOT_USB,// Interface is to a PCI card
            USB_IDLE = AESImhei.USB_IDLE, // No driver or other program running
            STANDARD_DRIVER = AESImhei.STANDARD_DRIVER, // The driver program is running normally
            FLASH_LOADER = AESImhei.FLASH_LOADER, // The flash re-programming tool is using the link
            MANUFACTURING_TEST = AESImhei.MANUFACTURING_TEST, // The manufacturing test tool is using the link
            DRIVER_RESTART = AESImhei.DRIVER_RESTART, // The standard driver is in the process of exiting / restarting
            USB_ERROR = AESImhei.USB_ERROR  // The driver has received an errOR from the low level driver
        }

        public AESWDriverStatus USBDriverStatus
        {
            get
            {
                return (AESWDriverStatus)AESImhei.USBDriverStatus();
            }
        }

        public void USBDriverExit()
        {
            AESImhei.USBDriverExit();
        }

        [Flags]
        public enum DeviceIdentity
        {
            // Some Generic Identities
            DP_ID003_NOTE = 0x00 | AESImhei.DP_JCM_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_MDB_LEVEL_2 = 0x00 | AESImhei.DP_MDB_LEVEL_2_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MDB_LEVEL_3 = 0x00 | AESImhei.DP_MDB_LEVEL_3_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MDB_LEVEL_2_TUBE = 0x00 | AESImhei.DP_MDB_LEVEL_2_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE,
            DP_MDB_TYPE_3_PAYOUT = 0x00 | AESImhei.DP_MDB_LEVEL_3_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE,
            DP_MDB_BILL = 0x00 | AESImhei.DP_MDB_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_CC_GHOST_HOPPER = 0xFF | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE,// Used by Value hopperz

            DP_MCL_SCH2 = 0x01 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE,
            DP_MCL_SUH1 = 0x02 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE,
            DP_MCL_SCH3 = 0x03 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE,
            DP_MCL_SR3 = 0x02 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MCL_SR5 = 0x03 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MCL_CONDOR = 0x06 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MCL_LUMINA = 0x05 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_MCL_7200 = 0x06 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_MCL_WACS = 0x01 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_ARDAC_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_MCL_ARDAC = 0x01 | AESImhei.DP_MANU_MONEY_CONTROLS | AESImhei.DP_JCM_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,

            // Coin Co Devices
            DP_COINCO_MDB = 0x00 | AESImhei.DP_MANU_COINCO | AESImhei.DP_MDB_LEVEL_3_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_COINCO_VORTEX = 0x01 | AESImhei.DP_MANU_COINCO | AESImhei.DP_MDB_LEVEL_3_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_COINCO_GLOBAL = 0x02 | AESImhei.DP_MANU_COINCO | AESImhei.DP_MDB_LEVEL_3_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_COINCO_MDB_BILL = 0x00 | AESImhei.DP_MANU_COINCO | AESImhei.DP_MDB_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_COINCO_BILLPRO = 0x01 | AESImhei.DP_MANU_COINCO | AESImhei.DP_MDB_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,

            // Azcoin Devices
            DP_AZK_HOPPER = 0x00 | AESImhei.DP_MANU_AZKOYEN | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE,
            DP_AZK_MDB = 0x00 | AESImhei.DP_MANU_AZKOYEN | AESImhei.DP_MDB_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,

            // Mars Electronics Devices
            DP_MARS_CASHFLOW_126 = 0x01 | AESImhei.DP_MANU_MARS_ELECTRONICS | AESImhei.DP_HII_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MARS_CASHFLOW_9500 = 0x02 | AESImhei.DP_MANU_MARS_ELECTRONICS | AESImhei.DP_HII_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MARS_MDB = 0x00 | AESImhei.DP_MANU_MARS_ELECTRONICS | AESImhei.DP_MDB_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_MARS_CASHFLOW_690 = 0x01 | AESImhei.DP_MANU_MARS_ELECTRONICS | AESImhei.DP_MDB_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,

            // Innovative Devices
            DP_INNOV_NV4 = 0x04 | AESImhei.DP_MANU_INNOVATIVE_TECH | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_INNOV_NV7 = 0x07 | AESImhei.DP_MANU_INNOVATIVE_TECH | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_INNOV_NV8 = 0x08 | AESImhei.DP_MANU_INNOVATIVE_TECH | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_INNOV_NV9 = 0x09 | AESImhei.DP_MANU_INNOVATIVE_TECH | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_INNOV_NV10 = 0x10 | AESImhei.DP_MANU_INNOVATIVE_TECH | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,

            // NRI Devices
            DP_NRI_G40 = 0x01 | AESImhei.DP_MANU_NRI | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,
            DP_ICT_U85 = 0x01 | AESImhei.DP_MANU_ICT | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_ACCEPT_DEVICE,

            //  JCM Devices
            DP_JCM_CC_EBA = 0x00 | AESImhei.DP_MANU_JCM | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_JCM_CC_WBA = 0x01 | AESImhei.DP_MANU_JCM | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_JCM_VEGA = 0x02 | AESImhei.DP_MANU_JCM | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,
            DP_JCM_VEGA_RC = 0x02 | AESImhei.DP_MANU_JCM | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_NOTE_PAYOUT_DEVICE,
            DP_JCM_NOTE = 0x00 | AESImhei.DP_MANU_JCM | AESImhei.DP_JCM_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,

            //  GPT Devices
            DP_GPT_NOTE = 0x00 | AESImhei.DP_MANU_GPT | AESImhei.DP_GPT_INTERFACE | AESImhei.DP_NOTE_ACCEPT_DEVICE,

            // Asahi Seiko Devices
            DP_AS_WH2 = 0x00 | AESImhei.DP_MANU_ASAHI_SEIKO | AESImhei.DP_CCTALK_INTERFACE | AESImhei.DP_COIN_PAYOUT_DEVICE
        }

        [Flags]
        public enum AcceptorStatus
        {
            OK = 0,
            Busy = AESImhei.ACCEPTOR_BUSY,
            Dead = AESImhei.ACCEPTOR_DEAD,
            Disabled = AESImhei.ACCEPTOR_DISABLED,
            Fault = AESImhei.ACCEPTOR_FAULT,
            Fraud = AESImhei.ACCEPTOR_FRAUD,
            Inhibit = AESImhei.ACCEPTOR_INHIBIT
        }

        public class Acceptor : AESImhei.AcceptorBlock
        {
            internal int number;

            public Acceptor(int Number)
            {
                number = Number;
            }

            public bool ReadDetails()
            {
                return AESImhei.ReadAcceptorDetails(this.number, this);
            }

            public void WriteDetails()
            {
                AESImhei.WriteAcceptorDetails(this.number, this);
            }
        }

        public enum DispenserPayStatus
        {
            OnGoing = AESImhei.PAY_ONGOING,//           ' The interface is in the process of paying out
            Finished = AESImhei.PAY_FINISHED,//          ' The payout process is up to date
            Empty = AESImhei.PAY_EMPTY,//            ' The dispenser is empty
            Jammed = AESImhei.PAY_JAMMED,//           ' The dispenser is jammed
            US = AESImhei.PAY_US,//               ' Dispenser non functional
            Fraud = AESImhei.PAY_FRAUD,//            ' Fraud attempt detected
            Blocked = AESImhei.PAY_FAILED_BLOCKED,//   ' The dispenser optos are blocked
            NoHopper = AESImhei.PAY_NO_HOPPER,//        ' There are no dispensers
            Inhibited = AESImhei.PAY_INHIBITED,//        ' The only possible dispenser is inhibited
            SecurityFail = AESImhei.PAY_SECURITY_FAIL,//    ' The internal security checks failed
            HopperReset = AESImhei.PAY_HOPPER_RESET,//     ' The hopper reset during a payout
            NotExact = AESImhei.PAY_NOT_EXACT,//       ' The hopper cannot payout the exact amount
            Ghost = AESImhei.PAY_GHOST,//           ' This hopper does not really exist - it's a part of another unit
            NoKey = AESImhei.PAY_NO_KEY   /* Waiting on a valid key exchange */
        }

        public enum DispenserCoinStatus
        {
            // Coin Count Status Values
            None = AESImhei.DISPENSER_COIN_NONE,// No dispenser coin reporting
            Low = AESImhei.DISPENSER_COIN_LOW,// Less than the low sensor level
            Mid = AESImhei.DISPENSER_COIN_MID,// Above low sensor but below high
            High = AESImhei.DISPENSER_COIN_HIGH,// High sensor level reported

            Accurate = AESImhei.DISPENSER_ACCURATE,// Coin Count reported by Dispenser
            Accurate_Full = AESImhei.DISPENSER_ACCURATE_FULL // Coin Count As reported by Dispenser, is over limit.
        }

        public class Dispenser : AESImhei.DispenserBlock
        {
            internal int number;


            public Dispenser(int Number)
            {
                number = Number;
            }


            public bool ReadDetails()
            {
                return AESImhei.ReadDispenserDetails(this.number, this);
            }

            public void WriteDetails()
            {
                AESImhei.WriteDispenserDetails(this.number, this);
            }
        }


        /**************************************************************
        Event codes have an internal structure, allowing cateogizations.
        The bottom 6 bits are the unique code for the event,
        serious fault related codes have bit 5 set.
        Above this are bits describing the type of unit affected.
        ***************************************************************/

        public class Event : AESImhei.EventDetailBlock
        {
            public const System.UInt16 EVENT_CODE_MASK = 0x001f;
            public const System.UInt16 UNIT_TYPE_MASK = 0xffc0; //~0x003f
            public const System.UInt16 FAULT_BIT = 0x0020;
            public const System.UInt16 COIN_DISPENSER_EVENT = 0x0040;
            public const System.UInt16 NOTE_DISPENSER_EVENT = 0x0080;
            public const System.UInt16 COIN_EVENT = 0x00C0;
            public const System.UInt16 NOTE_EVENT = 0x0100;

            // The common base codes
            public const System.UInt16 EVENT_OK = 0x00;           // Internal use only
            public const System.UInt16 EVENT_BUSY = 0x01;         // Internal use only
            public const System.UInt16 REJECTED = 0x02;
            public const System.UInt16 INHIBITED = 0x03;
            public const System.UInt16 MISREAD = 0x04;
            public const System.UInt16 FRAUD = 0x05;
            public const System.UInt16 JAM = 0x06;
            public const System.UInt16 JAM_FIXED = 0x07;
            public const System.UInt16 RETURN = 0x08;
            public const System.UInt16 OUTPUT_PROBLEM = 0x09;
            public const System.UInt16 OUTPUT_FIXED = 0x0a;
            public const System.UInt16 INTERNAL_PROBLEM = 0x0b;
            public const System.UInt16 UNKNOWN = 0x0c;
            public const System.UInt16 DISPENSE_UPDATE = 0x0d;

            // Fault codes
            public const System.UInt16 NOW_OK = 0x00;
            public const System.UInt16 REPORTED_FAULT = 0x01;
            public const System.UInt16 UNIT_TIMEOUT = 0x02;
            public const System.UInt16 UNIT_RESET = 0x03;
            public const System.UInt16 SELF_TEST_REFUSED = 0x04;

            // The actual Full Event Codes
            public enum Code : ushort
            {
                // General
                IMHEI_NULL = 0x0000,
                IMHEI_INTERFACE_START = 0x0001,
                IMHEI_APPLICATION_START = 0x0002,
                IMHEI_APPLICATION_EXIT = 0x0003,
                IMHEI_OVERFLOW = 0x001f,

                // Coin Acceptors
                IMHEI_COIN_NOW_OK = COIN_EVENT | FAULT_BIT | NOW_OK,
                IMHEI_COIN_UNIT_REPORTED_FAULT = COIN_EVENT | FAULT_BIT | REPORTED_FAULT,
                IMHEI_COIN_UNIT_TIMEOUT = COIN_EVENT | FAULT_BIT | UNIT_TIMEOUT,
                IMHEI_COIN_UNIT_RESET = COIN_EVENT | FAULT_BIT | UNIT_RESET,
                IMHEI_COIN_SELF_TEST_REFUSED = COIN_EVENT | FAULT_BIT | SELF_TEST_REFUSED,


                IMHEI_COIN_REJECT_COIN = COIN_EVENT | REJECTED,
                IMHEI_COIN_INHIBITED_COIN = COIN_EVENT | INHIBITED,
                IMHEI_COIN_FRAUD_ATTEMPT = COIN_EVENT | FRAUD,
                IMHEI_COIN_ACCEPTOR_JAM = COIN_EVENT | JAM,
                IMHEI_COIN_COIN_RETURN = COIN_EVENT | RETURN,
                IMHEI_COIN_SORTER_JAM = COIN_EVENT | OUTPUT_PROBLEM,
                IMHEI_COIN_INTERNAL_PROBLEM = COIN_EVENT | INTERNAL_PROBLEM,
                IMHEI_COIN_UNCLASSIFIED_EVENT = COIN_EVENT | UNKNOWN,

                // Note Acceptors
                IMHEI_NOTE_NOW_OK = NOTE_EVENT | FAULT_BIT | NOW_OK,
                IMHEI_NOTE_UNIT_REPORTED_FAULT = NOTE_EVENT | FAULT_BIT | REPORTED_FAULT,
                IMHEI_NOTE_UNIT_TIMEOUT = NOTE_EVENT | FAULT_BIT | UNIT_TIMEOUT,
                IMHEI_NOTE_UNIT_RESET = NOTE_EVENT | FAULT_BIT | UNIT_RESET,
                IMHEI_NOTE_SELF_TEST_REFUSED = NOTE_EVENT | FAULT_BIT | SELF_TEST_REFUSED,

                IMHEI_NOTE_REJECT_NOTE = NOTE_EVENT | REJECTED,
                IMHEI_NOTE_INHIBITED_NOTE = NOTE_EVENT | INHIBITED,
                IMHEI_NOTE_NOTE_MISREAD = NOTE_EVENT | MISREAD,
                IMHEI_NOTE_FRAUD_ATTEMPT = NOTE_EVENT | FRAUD,
                IMHEI_NOTE_ACCEPTOR_JAM = NOTE_EVENT | JAM,
                IMHEI_NOTE_ACCEPTOR_JAM_FIXED = NOTE_EVENT | JAM_FIXED,
                IMHEI_NOTE_NOTE_RETURNED = NOTE_EVENT | RETURN,
                IMHEI_NOTE_STACKER_PROBLEM = NOTE_EVENT | OUTPUT_PROBLEM,
                IMHEI_NOTE_STACKER_FIXED = NOTE_EVENT | OUTPUT_FIXED,
                IMHEI_NOTE_INTERNAL_ERROR = NOTE_EVENT | INTERNAL_PROBLEM,
                IMHEI_NOTE_UNCLASSIFIED_EVENT = NOTE_EVENT | UNKNOWN,

                // Coin Dispenser
                IMHEI_COIN_DISPENSER_NOW_OK = COIN_DISPENSER_EVENT | FAULT_BIT | NOW_OK,
                IMHEI_COIN_DISPENSER_REPORTED_FAULT = COIN_DISPENSER_EVENT | FAULT_BIT | REPORTED_FAULT,
                IMHEI_COIN_DISPENSER_TIMEOUT = COIN_DISPENSER_EVENT | FAULT_BIT | UNIT_TIMEOUT,
                IMHEI_COIN_DISPENSER_RESET = COIN_DISPENSER_EVENT | FAULT_BIT | UNIT_RESET,
                IMHEI_COIN_DISPENSER_SELF_TEST_REFUSED = COIN_DISPENSER_EVENT | FAULT_BIT | SELF_TEST_REFUSED,

                IMHEI_COIN_DISPENSER_FRAUD_ATTEMPT = COIN_DISPENSER_EVENT | FRAUD,
                IMHEI_COIN_DISPENSER_UPDATE = COIN_DISPENSER_EVENT | DISPENSE_UPDATE,
            }
        }

        public Event.Code NextEvent(MHE.Event EventDetails)
        {
            return (Event.Code)AESImhei.NextEvent(EventDetails);
        }

        public System.Int32 AvailableValue
        {
            get
            {
                return AESImhei.AvailableValue();
            }
        }

        public void ValueNeeded(System.Int32 Amount)
        {
            AESImhei.ValueNeeded(Amount);
        }

        public System.Int32 SerialNumber
        {
            get
            {
                return AESImhei.SerialNumber();
            }
        }

        public struct EscrowFunc
        {
            public int Throughput
            {
                get
                {
                    return AESImhei.EscrowThroughput();
                }
            }

            public void Accept()
            {
                AESImhei.EscrowAccept();
            }

            public void Return()
            {
                AESImhei.EscrowReturn();
            }

            public bool Enabled
            {
                set
                {
                    if (value)
                    {
                        AESImhei.EscrowEnable();
                    }
                    else
                    {
                        AESImhei.EscrowDisable();
                    }
                }
            }
        }


        public class BarcodeTicket : AESImhei.TicketDescription
        {
            public BarcodeTicket(Int32 Type)
            {
                TicketType = Type;
                BarcodeData = String.Empty;
                AmountInWords = String.Empty;
                AmountAsNumber = String.Empty;
                MachineIdentity = String.Empty;
                DatePrinted = String.Empty;
                TimePrinted = String.Empty;
            }
        }

        [Flags]
        public enum BarcodePrinterStatus : int
        {
            NotPresent = AESImhei.PRINTER_NONE,// Printer non functional / not present
            Faulty = AESImhei.PRINTER_FAULT,// There is a fault somewhere

            Idle = AESImhei.PRINTER_IDLE,// The printer is OK / Idle /Finished
            Busy = AESImhei.PRINTER_BUSY,// Printing is currently taking place
            PlatenUp = AESImhei.PRINTER_PLATEN_UP,
            PaperOut = AESImhei.PRINTER_PAPER_OUT,
            HeadFault = AESImhei.PRINTER_HEAD_FAULT,
            VoltFault = AESImhei.PRINTER_VOLT_FAULT,
            TempFault = AESImhei.PRINTER_TEMP_FAULT,
            InternalError = AESImhei.PRINTER_INTERNAL_ERROR,
            PaperInChute = AESImhei.PRINTER_PAPER_IN_CHUTE,
            Offline = AESImhei.PRINTER_OFFLINE,
            MissingSupplyIndex = AESImhei.PRINTER_MISSING_SUPPY_INDEX,
            CutterFault = AESImhei.PRINTER_CUTTER_FAULT,
            PaperJam = AESImhei.PRINTER_PAPER_JAM,
            PaperLow = AESImhei.PRINTER_PAPER_LOW,
            Open = AESImhei.PRINTER_OPEN,

            // These values can be set when Idle
            TopOfForm = AESImhei.PRINTER_TOP_OF_FORM,// The last ticket is finished
            BarcodeDone = AESImhei.PRINTER_BARCODE_DONE,// The last barcode has been printed
            JustReset = AESImhei.PRINTER_JUST_RESET
        }

        public struct BarcodeFunc
        {
            public void Print(BarcodeTicket Ticket)
            {
                AESImhei.BarcodePrint(Ticket);
            }

            public BarcodePrinterStatus PrinterStatus
            {
                get
                {
                    return (BarcodePrinterStatus)AESImhei.BarcodePrintStatus();
                }
            }

            public void Enable()
            {
                AESImhei.BarcodeEnable();
            }

            public void Disable()
            {
                AESImhei.BarcodeDisable();
            }

            public bool TicketInEscrow(out string Barcode)
            {
                Barcode = String.Empty;
                return AESImhei.BarcodeInEscrow(ref Barcode) != 0;
            }

            public int TicketsStacked(out string Barcode)
            {
                Barcode = String.Empty;
                return AESImhei.BarcodeStacked(ref Barcode);
            }

            public void TicketAccept()
            {
                AESImhei.BarcodeAccept();
            }

            public void TicketReturn()
            {
                AESImhei.BarcodeReturn();
            }
        }

        public void IndicatorOn(int IndicatorNumber)
        {
            AESImhei.IndicatorOn(IndicatorNumber);
        }

        public void IndicatorOff(int IndicatorNumber)
        {
            AESImhei.IndicatorOff(IndicatorNumber);
        }

        public int SwitchOpens(int SwitchNumber)
        {
            return AESImhei.SwitchOpens(SwitchNumber);
        }

        public int SwitchCloses(int SwitchNumber)
        {
            return AESImhei.SwitchCloses(SwitchNumber);
        }

        public bool IsSwitchOpen(int SwitchNumber)
        {
            return SwitchCloses(SwitchNumber) == SwitchOpens(SwitchNumber);
        }

        public class Counter
        {
            private const int maxCaptionLength = 256;
            private System.Byte number;
            private CounterMeter.CounterDisplayMode displayMode;

            public Counter(Byte Number)
            {
                number = Number;
                displayMode = CounterMeter.CounterDisplayMode.CounterOnly;
            }

            public Byte Number
            {
                get
                {
                    return number;
                }
            }

            public string Caption
            {
                get
                {
                    //// get caption for counter
                    return AESImhei.ReadCounterCaption(number);
                }

                set
                {
                    AESImhei.CounterCaption(number, value);
                }
            }

            public int Count
            {
                get
                {
                    return AESImhei.CounterRead(number);
                }
            }

            public CounterMeter.CounterDisplayMode DisplayMode
            {
                get
                {
                    return displayMode;
                }
                set
                {
                    if (displayMode != value)
                    {
                        displayMode = value;
                    }
                }
            }

            public int Increment(int Increment)
            {
                AESImhei.CounterIncrement(number, Increment);
                return AESImhei.CounterRead(number);
            }

        }

        public enum MeterStatus
        {
            OK = AESImhei.METER_OK,             //  A Meter is present and working correctly
            Missing = AESImhei.METER_MISSING,        //  No Meter has ever been found
            Died = AESImhei.METER_DIED,           //  The Meter is no longer functioning
            Failed = AESImhei.METER_FAILED         //  The Meter is functioning but is itself
        }

        public class CounterMeter
        {
            public CounterList Counter;

            public enum CounterDisplayMode
            {
                CounterOnly,
                Both
            }

            public class CounterList : System.Collections.Generic.List<Counter>
            {
                public Counter this[Byte Index]
                {
                    get
                    {
                        return this.Find((counter) => counter.Number == Index);
                    }
                    set
                    {
                        Counter counter = this.Find((c) => c.Number == Index);
                        if (counter != null)
                        {
                            this.Remove(counter);
                        }
                        this.Add(value);
                    }
                }
            }


            public CounterMeter()
            {
                Counter = new CounterList();

                for (byte i = 1; i <= 16; ++i)
                {
                    Int32 count = AESImhei.CounterRead(i);
                    if (count >= 0)
                    {
                        Counter counter = new Counter(i);
                        Counter[i] = counter;
                    }
                }
            }

            public int SerialNumber
            {
                get
                {
                    return AESImhei.MeterSerialNo();
                }
            }

            public MeterStatus Status
            {
                get
                {
                    return (MeterStatus)AESImhei.MeterStatus();
                }
            }

            public void DisplayCounter(Byte Number)
            {
                MHE.Counter counter = Counter[Number];
                switch (counter.DisplayMode)
                {
                    case CounterMeter.CounterDisplayMode.CounterOnly:
                        AESImhei.CounterDisplay((int)counter.Number * 1);
                        break;
                    case CounterMeter.CounterDisplayMode.Both:
                        AESImhei.CounterDisplay((int)counter.Number * -1);
                        break;
                }
            }
        }

        public enum DESStatus
        {
            PaylinkUnlocked = AESImhei.DES_UNLOCKED,   /* The Paylink is unlocked                        */
            KeyMatched = AESImhei.DES_MATCH,   /* DES Key matched by Paylink and PC              */
            PaylinkNotDES = AESImhei.DES_NOT,   /* Not a DES Paylink                              */
            WrongKey = AESImhei.DES_WRONG,   /* Paylink wrong key                              */
            CheckingKey = AESImhei.DES_CHECKING,   /* DES Key checking is still being performed.     */
            ApplyingLock = AESImhei.DES_APPLYING    /* DES Lock is being applied                      */
        }

        public struct DESFunc
        {
            public void SetKey(Byte[] Key)
            {
                AESImhei.DESSetKey(Key);
            }

            public void LockSet(Byte[] Key)
            {
                AESImhei.DESLockSet(Key);
            }

            public void LockClear()
            {
                AESImhei.DESLockClear();
            }

            public DESStatus Status
            {
                get { return (DESStatus)AESImhei.DESStatus(); }
            }
        }

    }
}
