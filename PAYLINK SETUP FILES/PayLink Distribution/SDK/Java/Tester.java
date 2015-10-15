import java.io.*;
import aes.imhei.AESImhei ;


class Tester {
    static {
        System.loadLibrary("AesImheiJava");
        }
    public static void main(String[] Args){
        System.out.println("Hello") ;

        int OpenRes = AESImhei.OpenMHE() ;

        if (OpenRes == 0)
            {
            int Ret ;
            AESImhei.EnableInterface() ;


            String Date[] = new String[1] ;
            String Time[] = new String[1] ;
            AESImhei.FirmwareVersion(Date, Time) ;
            System.out.println("Firmware: on " + Date[0] + " at " + Time[0]) ;
            System.out.println("") ;

            AESImhei.EventDetailBlock EventDetail = new AESImhei.EventDetailBlock() ;

            Ret = AESImhei.NextSystemEvent(EventDetail) ;

            System.out.print("System - ") ;
            if (Ret == 0)
                {
                System.out.println("nothing") ;
                }
            else
                {
                System.out.println("EventCode:" + EventDetail.EventCode) ;
                System.out.println("RawEvent:" + EventDetail.RawEvent) ;
                System.out.println("DispenserEvent:" + EventDetail.DispenserEvent) ;
                System.out.println("Index:" + EventDetail.Index) ;
                System.out.println("") ;
                }

            Ret = AESImhei.NextAcceptorEvent(0, EventDetail) ;
            System.out.print("Acceptor - ") ;
            if (Ret == 0)
                {
                System.out.println("nothing") ;
                }
            else
                {
                System.out.println("EventCode:" + EventDetail.EventCode) ;
                System.out.println("RawEvent:" + EventDetail.RawEvent) ;
                System.out.println("DispenserEvent:" + EventDetail.DispenserEvent) ;
                System.out.println("Index:" + EventDetail.Index) ;
                System.out.println("") ;
                }

            Ret = AESImhei.NextDispenserEvent(0, EventDetail) ;
            System.out.print("Dispenser - ") ;
            if (Ret == 0)
                {
                System.out.println("nothing") ;
                }
            else
                {
                System.out.println("EventCode:" + EventDetail.EventCode) ;
                System.out.println("RawEvent:" + EventDetail.RawEvent) ;
                System.out.println("DispenserEvent:" + EventDetail.DispenserEvent) ;
                System.out.println("Index:" + EventDetail.Index) ;
                System.out.println("") ;
                }



            AESImhei.AcceptorBlock TheAcceptor = new AESImhei.AcceptorBlock() ;
            for(int A = 0 ; AESImhei.ReadAcceptorDetails(A, TheAcceptor) ; ++A)
                {
                System.out.println("Unit:" + TheAcceptor.Unit) ;
                System.out.println("Status:" + TheAcceptor.Status) ;
                System.out.println("NoOfCoins:" + TheAcceptor.NoOfCoins) ;
                System.out.println("InterfaceNumber:" + TheAcceptor.InterfaceNumber) ;
                System.out.println("Currency:" + TheAcceptor.Currency) ;
                for (int i = 0 ; i < TheAcceptor.NoOfCoins ; ++i)
                    {
                    System.out.println("   Value:" + TheAcceptor.Coin[i].Value) ;
                    System.out.println("   Name :" + TheAcceptor.Coin[i].CoinName) ;
                    TheAcceptor.Coin[i].Path = (TheAcceptor.Coin[i].Path + 1) & 7 ;
                    }
                AESImhei.WriteAcceptorDetails(0, TheAcceptor) ;
                System.out.println("") ;
                }




            AESImhei.DispenserBlock TheDispenser = new AESImhei.DispenserBlock() ;
            for(int D = 0 ; AESImhei.ReadDispenserDetails(D, TheDispenser) ; ++D)
                {
                System.out.println("Description:" + TheDispenser.Description) ;
                System.out.println("UnitAddress:" + TheDispenser.UnitAddress) ;
                System.out.println("Value:" + TheDispenser.Value) ;
                System.out.println("Count:" + TheDispenser.Count) ;
                if (TheDispenser.Value == 100)
                    {
                    TheDispenser.Inhibit = (TheDispenser.Inhibit == 0) ? 1 : 0 ;
                    AESImhei.WriteDispenserDetails(D, TheDispenser) ;
                    }
            }
            System.out.println("") ;


            AESImhei.BarcodeEnable() ;
            String Barcode[] = new String[1] ;
            Ret = AESImhei.BarcodeInEscrow(Barcode) ;
            System.out.println("Barcode Escrow returns: " + Ret + " <" + Barcode[0] + ">") ;

            AESImhei.BarcodeAccept() ;

            Ret = AESImhei.BarcodeStacked(Barcode) ;
            System.out.println("Barcode  returns: " + Ret + " <" + Barcode[0] + ">") ;

            System.out.println("") ;


            AESImhei.TicketDescription Ticket = new AESImhei.TicketDescription() ;
            Ticket.TicketType       =  0 ;
            Ticket.BarcodeData      = "123456789012345678" ;
            Ticket.AmountInWords    = "Amount In Words" ;
            Ticket.AmountAsNumber   = "$43.56" ;
            Ticket.MachineIdentity  = "654321" ;
            Ticket.DatePrinted      = "65/43/21" ;
            Ticket.TimePrinted      = "12:34:56" ;
            AESImhei.BarcodePrint(Ticket) ;

            Ret = AESImhei.BarcodePrintStatus() ;
            if ((Ret & AESImhei.PRINTER_FAULT) != 0)
                {
                System.out.println("Print Error") ;
                }
            else while ((AESImhei.BarcodePrintStatus() &  AESImhei.PRINTER_BUSY) != 0) {}
            System.out.println("") ;



            AESImhei.CounterCaption(1, "For 1") ;
            AESImhei.CounterCaption(4, "Caption 4") ;
            System.out.println("Caption for 1: " + AESImhei.ReadCounterCaption(1)) ;
            System.out.println("Caption for 4: " + AESImhei.ReadCounterCaption(4)) ;
            System.out.println("") ;


            byte[] Data = new byte[16] ;

            AESImhei.E2PromRead(Data, 8) ;
            System.out.println("E2Prom Read: <" + new String(Data, 0, 8) + ">") ;
            Data = "ABCDefghxxx".getBytes() ;
            AESImhei.E2PromWrite(Data, 8) ;
            AESImhei.E2PromRead(Data, 8) ;
            System.out.println("E2Prom Read: <" + new String(Data, 0, 8) + ">") ;
            Data = "1234wxyzxxx".getBytes() ;
            AESImhei.E2PromWrite(Data, 4) ;
            AESImhei.E2PromRead(Data, 8) ;
            System.out.println("E2Prom Read: <" + new String(Data, 0, 8) + ">") ;


            AESImhei.EscrowControlBlock TheEscrowControlBlock = new AESImhei.EscrowControlBlock() ;
            if (AESImhei.ReadEscrowBlock(0, TheEscrowControlBlock))
                {
                System.out.println("Escrow available State: " + TheEscrowControlBlock.State + " Notes: " + TheEscrowControlBlock.NoInEscrow) ;
                System.out.println("Value: " + TheEscrowControlBlock.EscrowNote[0].Value + " Status: " + TheEscrowControlBlock.EscrowNote[0].Status) ;


                AESImhei.EscrowCommand(0, AESImhei.EXT_ESCROW_START) ;
                }

            System.out.print("Done:") ;
            byte[] b = new byte[128] ;
                try {
                System.in.read(b) ;
                }
            catch(IOException E) {}
            }
        else
            {
            System.out.println("OpenMHE Failed " + OpenRes) ;
            }
      }
}
