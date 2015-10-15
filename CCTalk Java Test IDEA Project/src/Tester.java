import aes.imhei.AESImhei;

/***
 * Please Read My documentation to setup the PAYLINK correctly
 * This class will show you that how you can open connection with devices and get the values back.
 * @OpenRes indicates the status of connection is established or not
 * @switches i am defining the switch pin number where i have connected my button you can add 15 switches
 * @EventDetail will always gives you all information about an event like event code, status etc...
 * @NextAcceptorEvent will gives you coin/note acceptor information
 * @acceptorCoin Will hold all information about your current money inserted but you need to set value each time
 * @TheAcceptor will check your coin and note acceptor and it will show you all information about currency, unit, name etc..
 * @TheDispenser will control your Dispenser values like money changer.
 * @E2Prom will read and write bytes to the devices
 * @Barcode hold the current value of barcode from barcode reader
 * @Ticket will print barcode Data
 */

class Tester {
    static {
        //Load API From Library
        System.loadLibrary("AesImheiJava");
    }

    //Define Global Values
    private static int lastCurrencyValue = 0;
    private static int newCurrencyValue = 0;
    private static int lastAcceptedCoin = 0;


    public static void main(String[] Args) {
        System.out.println("Hello");

        // Define the input number where you have connected your switch or buttons
        int[] switches = {7};

        //Open MHE
        int OpenRes = AESImhei.OpenMHE();

        //Check if connection established
        if (OpenRes == 0) {
            int Ret;
            //IF driver connection established then enable Paylink interface
            AESImhei.EnableInterface();

            //Get current total value of the coin acceptor
            lastCurrencyValue = AESImhei.CurrentValue();
            AESImhei.CurrentUpdates();

            //Check Firmware
            String Date[] = new String[1];
            String Time[] = new String[1];
            AESImhei.FirmwareVersion(Date, Time);
            System.out.println("Firmware: on " + Date[0] + " at " + Time[0]);
            System.out.println("");

            //Define event for details
            AESImhei.EventDetailBlock EventDetail = new AESImhei.EventDetailBlock();

            Ret = AESImhei.NextSystemEvent(EventDetail);

            System.out.print("System - ");
            if (Ret == 0) {
                System.out.println("nothing");
            } else {
                System.out.println("EventCode:" + EventDetail.EventCode);
                System.out.println("RawEvent:" + EventDetail.RawEvent);
                System.out.println("DispenserEvent:" + EventDetail.DispenserEvent);
                System.out.println("Index:" + EventDetail.Index);
                System.out.println("");
            }

            Ret = AESImhei.NextAcceptorEvent(0, EventDetail);
            System.out.print("Acceptor - ");
            if (Ret == 0) {
                System.out.println("nothing");
            } else {
                System.out.println("EventCode:" + EventDetail.EventCode);
                System.out.println("RawEvent:" + EventDetail.RawEvent);
                System.out.println("DispenserEvent:" + EventDetail.DispenserEvent);
                System.out.println("Index:" + EventDetail.Index);
                System.out.println("");
            }

            Ret = AESImhei.NextDispenserEvent(0, EventDetail);
            System.out.print("Dispenser - ");
            if (Ret == 0) {
                System.out.println("nothing");
            } else {
                System.out.println("EventCode:" + EventDetail.EventCode);
                System.out.println("RawEvent:" + EventDetail.RawEvent);
                System.out.println("DispenserEvent:" + EventDetail.DispenserEvent);
                System.out.println("Index:" + EventDetail.Index);
                System.out.println("");
            }

            //Create Object to store values for accepted coins
            AESImhei.AcceptorCoin acceptorCoin = new AESImhei.AcceptorCoin();

            //Get the Acceptors
            AESImhei.AcceptorBlock TheAcceptor = new AESImhei.AcceptorBlock();
            //Read All Acceptors like coin, note acceptors etc...
            for (int A = 0; AESImhei.ReadAcceptorDetails(A, TheAcceptor); ++A) {
                /***
                 * Please read the documentation about currency
                 * and changing the name of the coins
                 * My SR5 Coin acceptor default currency is GB but i have changed it into Euro
                 */
                TheAcceptor.Currency = "EU";
                System.out.println("Unit:" + TheAcceptor.Unit);
                System.out.println("Status:" + TheAcceptor.Status);
                System.out.println("NoOfCoins:" + TheAcceptor.NoOfCoins);
                System.out.println("InterfaceNumber:" + TheAcceptor.InterfaceNumber);
                System.out.println("Currency:" + TheAcceptor.Currency);

                /***
                 * Check the values for the coins i.e 50,100,200 it will always give you values in cents so if you divide it by 100
                 * then you will get money value. Don't forget to change value to float to make it useable
                 */
                for (int i = 0; i < TheAcceptor.NoOfCoins; ++i) {
                    TheAcceptor.Coin[i].CoinName = TheAcceptor.Currency + TheAcceptor.Coin[i].Value + "A";
                    System.out.println("   Value:" + TheAcceptor.Coin[i].Value);
                    System.out.println("   Name :" + TheAcceptor.Coin[i].CoinName);
                    TheAcceptor.Coin[i].Path = (TheAcceptor.Coin[i].Path + 1) & 7;
                }
                AESImhei.WriteAcceptorDetails(0, TheAcceptor);
                System.out.println("");
            }

            /***
             * If you have connected money changer then it will handle these dispenser
             */
            AESImhei.DispenserBlock TheDispenser = new AESImhei.DispenserBlock();
            for (int D = 0; AESImhei.ReadDispenserDetails(D, TheDispenser); ++D) {
                System.out.println("Description:" + TheDispenser.Description);
                System.out.println("UnitAddress:" + TheDispenser.UnitAddress);
                System.out.println("Value:" + TheDispenser.Value);
                System.out.println("Count:" + TheDispenser.Count);
                if (TheDispenser.Value == 100) {
                    TheDispenser.Inhibit = (TheDispenser.Inhibit == 0) ? 1 : 0;
                    AESImhei.WriteDispenserDetails(D, TheDispenser);
                }
            }
            System.out.println("");

            /***
             * The following code will give you an access to work with barcode readers
             * It will read the barcode value and then set into Escrow
             */
            AESImhei.BarcodeEnable();
            String Barcode[] = new String[1];
            Ret = AESImhei.BarcodeInEscrow(Barcode);
            System.out.println("Barcode Escrow returns: " + Ret + " <" + Barcode[0] + ">");

            AESImhei.BarcodeAccept();

            Ret = AESImhei.BarcodeStacked(Barcode);
            System.out.println("Barcode  returns: " + Ret + " <" + Barcode[0] + ">");

            System.out.println("");

            /***
             * The ticker will allow you to print the barcode ticket for any product
             * Make sure that you have installed barcode reader correctly
             */
            AESImhei.TicketDescription Ticket = new AESImhei.TicketDescription();
            Ticket.TicketType = 0;
            Ticket.BarcodeData = "123456789012345678";
            Ticket.AmountInWords = "Amount In Words";
            Ticket.AmountAsNumber = "$43.56";
            Ticket.MachineIdentity = "654321";
            Ticket.DatePrinted = "65/43/21";
            Ticket.TimePrinted = "12:34:56";
            AESImhei.BarcodePrint(Ticket);

            Ret = AESImhei.BarcodePrintStatus();
            if ((Ret & AESImhei.PRINTER_FAULT) != 0) {
                System.out.println("Print Error");
            } else while ((AESImhei.BarcodePrintStatus() & AESImhei.PRINTER_BUSY) != 0) {
            }
            System.out.println("");


            AESImhei.CounterCaption(1, "For 1");
            AESImhei.CounterCaption(4, "Caption 4");
            System.out.println("Caption for 1: " + AESImhei.ReadCounterCaption(1));
            System.out.println("Caption for 4: " + AESImhei.ReadCounterCaption(4));
            System.out.println("");

            /***
             * Read and write data using E2Prom
             */
            byte[] Data = new byte[16];

            AESImhei.E2PromRead(Data, 8);
            System.out.println("E2Prom Read: <" + new String(Data, 0, 8) + ">");
            Data = "ABCDefghxxx".getBytes();
            AESImhei.E2PromWrite(Data, 8);
            AESImhei.E2PromRead(Data, 8);
            System.out.println("E2Prom Read: <" + new String(Data, 0, 8) + ">");
            Data = "1234wxyzxxx".getBytes();
            AESImhei.E2PromWrite(Data, 4);
            AESImhei.E2PromRead(Data, 8);
            System.out.println("E2Prom Read: <" + new String(Data, 0, 8) + ">");


            AESImhei.EscrowControlBlock TheEscrowControlBlock = new AESImhei.EscrowControlBlock();
            if (AESImhei.ReadEscrowBlock(0, TheEscrowControlBlock)) {
                System.out.println("Escrow available State: " + TheEscrowControlBlock.State + " Notes: " + TheEscrowControlBlock.NoInEscrow);
                System.out.println("Value: " + TheEscrowControlBlock.EscrowNote[0].Value + " Status: " + TheEscrowControlBlock.EscrowNote[0].Status);


                AESImhei.EscrowCommand(0, AESImhei.EXT_ESCROW_START);
            }

            System.out.print("Done:");

//            byte[] b = new byte[128];
//            try {
//                System.in.read(b);
//            } catch (IOException E) {
//            }


            /***
             * Now This is example infinite loop to check the coin value or others
             */
            while (true) {
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }


                int val = AESImhei.AvailableValue();
                int curr = AESImhei.CurrentValue();


                newCurrencyValue = AESImhei.CurrentValue();

                //Check How much money is inserted
                if (newCurrencyValue != lastCurrencyValue) {
                    // More money has arrived (we do not care where from)
                    int valueInserted = (newCurrencyValue - lastCurrencyValue);
                    System.out.println("> user inserted " + valueInserted);
                    lastAcceptedCoin = valueInserted;
                    acceptorCoin.Value += valueInserted;
                }

                //User has used all of its money
                if (acceptorCoin.Value == 0) {
                    lastCurrencyValue = newCurrencyValue;
                }

                /***
                 * The below loop will show you that how to check the button/switch is on or off
                 */
                for (int Loop = 0; Loop < switches.length; ++Loop) {
                    int switchNumberToCheck = (int) switches[Loop];
                    String switchStatus = AESImhei.SwitchCloses(switchNumberToCheck) == AESImhei.SwitchOpens(switchNumberToCheck) ? "ON" : "OFF";
                    System.out.println("Switch " + switchNumberToCheck + " is currently " + switchStatus);
                }

            }

        } else {
            System.out.println("OpenMHE Failed " + OpenRes);
        }

    }

    /***
     *
     * @param acceptorCoinValue hold all values of the coins
     */
    public static void useMoney(AESImhei.AcceptorCoin acceptorCoinValue) {

        acceptorCoinValue.Value -= 50;
    }

    public static void resetMoney() {
        lastCurrencyValue = newCurrencyValue;
    }

    /***
     * Get info of las Inserted Coin
     * @param Value
     * @return
     */
    public static int getLastInsertedCoinValue(int Value) {
        return lastAcceptedCoin;
    }
}
