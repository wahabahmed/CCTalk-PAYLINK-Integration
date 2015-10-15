using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        String b ;
        System.Console.WriteLine("Hello") ;

        int OpenRes = AESImhei.OpenMHE() ;

        if (OpenRes == 0)
            {
            int Ret ;
            AESImhei.EnableInterface() ;

            String Date = "xx";
            String Time = "yy";
            AESImhei.FirmwareVersion(ref Date, ref Time);

            System.Console.WriteLine("Firmware: on " + Date + " at " + Time) ;
            System.Console.WriteLine("") ;

            AESImhei.EventDetailBlock EventDetail = new AESImhei.EventDetailBlock() ;
            AESImhei.NextEvent(EventDetail) ;

            System.Console.WriteLine("EventCode:" + EventDetail.EventCode) ;
            System.Console.WriteLine("RawEvent:" + EventDetail.RawEvent) ;
            System.Console.WriteLine("DispenserEvent:" + EventDetail.DispenserEvent) ;
            System.Console.WriteLine("Index:" + EventDetail.Index) ;
            System.Console.WriteLine("") ;


            AESImhei.AcceptorBlock TheAcceptor = new AESImhei.AcceptorBlock() ;
            AESImhei.ReadAcceptorDetails(0, TheAcceptor) ;

            System.Console.WriteLine("Unit:" + TheAcceptor.Unit) ;
            System.Console.WriteLine("Status:" + TheAcceptor.Status) ;
            System.Console.WriteLine("NoOfCoins:" + TheAcceptor.NoOfCoins) ;
            System.Console.WriteLine("InterfaceNumber:" + TheAcceptor.InterfaceNumber) ;
            System.Console.WriteLine("Currency:" + TheAcceptor.Currency) ;
            System.Console.WriteLine("Coins:" + TheAcceptor.NoOfCoins) ;
            System.Console.WriteLine("Description:" + TheAcceptor.Description) ;

            for (int i = 0 ; i < TheAcceptor.NoOfCoins ; ++i)
                {
                System.Console.WriteLine("   Value:" + TheAcceptor.Coin[i].Value) ;
                System.Console.WriteLine("   Name :" + TheAcceptor.Coin[i].CoinName) ;
                TheAcceptor.Coin[i].Path = (TheAcceptor.Coin[i].Path + 1) & 7 ;
                }
            AESImhei.WriteAcceptorDetails(0, TheAcceptor) ;
            System.Console.WriteLine("") ;



            AESImhei.DispenserBlock TheDispenser = new AESImhei.DispenserBlock() ;
            for(int D = 0 ; AESImhei.ReadDispenserDetails(D, TheDispenser) ; ++D)
            {
                System.Console.WriteLine("Description:" + TheDispenser.Description) ;
                System.Console.WriteLine("UnitAddress:" + TheDispenser.UnitAddress) ;
                System.Console.WriteLine("Value:" + TheDispenser.Value) ;
                System.Console.WriteLine("Count:" + TheDispenser.Count) ;
                if (TheDispenser.Value == 100)
                    {
                    TheDispenser.Inhibit = (TheDispenser.Inhibit == 0) ? 1 : 0 ;
                    AESImhei.WriteDispenserDetails(D, TheDispenser) ;
                    }
            }
            System.Console.WriteLine("") ;


            AESImhei.BarcodeEnable() ;
            String Barcode = "xx" ;
            Ret = AESImhei.BarcodeInEscrow(ref Barcode) ;
            System.Console.WriteLine("Barcode Escrow returns: " + Ret + " <" + Barcode + ">") ;

            AESImhei.BarcodeAccept() ;

            Ret = AESImhei.BarcodeStacked(ref Barcode) ;
            System.Console.WriteLine("Barcode  returns: " + Ret + " <" + Barcode + ">") ;

            System.Console.WriteLine("") ;


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
                System.Console.WriteLine("Print Error") ;
                }
            else while ((AESImhei.BarcodePrintStatus() &  AESImhei.PRINTER_BUSY) != 0) {}
            System.Console.WriteLine("Print Status: " + AESImhei.BarcodePrintStatus()) ;



            AESImhei.CounterCaption(1, "For 1") ;
            AESImhei.CounterCaption(4, "Caption 4") ;
            System.Console.WriteLine("Caption for 1: " + AESImhei.ReadCounterCaption(1)) ;
            System.Console.WriteLine("Caption for 4: " + AESImhei.ReadCounterCaption(4)) ;
            System.Console.WriteLine("") ;

            byte[] Data = new byte[16] ;

              Data[0] = (Byte)'A' ;
              Data[1] = (Byte)'B' ;
              Data[2] = (Byte)'C' ;
              Data[3] = (Byte)'D' ;
              Data[4] = (Byte)'E' ;
              Data[5] = (Byte)'F' ;
              Data[6] = (Byte)'G' ;
              Data[7] = (Byte)'H' ;
              Data[8] = (Byte)'I' ;
              Data[9] = (Byte)'J' ;
            AESImhei.E2PromRead(Data, 8) ;
              System.Console.WriteLine("E2Prom Old Read: <"
                + (char)Data[0]
                + (char)Data[1]
                + (char)Data[2]
                + (char)Data[3]
                + (char)Data[4]
                + (char)Data[5]
                + (char)Data[6]
                + (char)Data[7]
                + (char)Data[8]
                + (char)Data[9]
                + ">") ;

              Data[0] = (Byte)'A' ;
              Data[1] = (Byte)'B' ;
              Data[2] = (Byte)'C' ;
              Data[3] = (Byte)'D' ;
              Data[4] = (Byte)'E' ;
              Data[5] = (Byte)'F' ;
              Data[6] = (Byte)'G' ;
              Data[7] = (Byte)'H' ;
              Data[8] = (Byte)'I' ;
              Data[9] = (Byte)'J' ;
            AESImhei.E2PromWrite(Data, 8) ;

              Data[8] = (Byte)'x' ;
              Data[9] = (Byte)'y' ;
            AESImhei.E2PromRead(Data, 8) ;
              System.Console.WriteLine("E2Prom New Read: <"
                + (char)Data[0]
                + (char)Data[1]
                + (char)Data[2]
                + (char)Data[3]
                + (char)Data[4]
                + (char)Data[5]
                + (char)Data[6]
                + (char)Data[7]
                + (char)Data[8]
                + (char)Data[9]
                + ">") ;

              Data[0] = (Byte)'1' ;
              Data[1] = (Byte)'2' ;
              Data[2] = (Byte)'3' ;
              Data[3] = (Byte)'4' ;
              Data[4] = (Byte)'5' ;
              Data[5] = (Byte)'6' ;
              Data[6] = (Byte)'7' ;
              Data[7] = (Byte)'8' ;
              Data[8] = (Byte)'9' ;
              Data[9] = (Byte)'a' ;
            AESImhei.E2PromWrite(Data, 4) ;

              Data[0] = (Byte)'A' ;
              Data[1] = (Byte)'B' ;
              Data[2] = (Byte)'C' ;
              Data[3] = (Byte)'D' ;
              Data[4] = (Byte)'E' ;
              Data[5] = (Byte)'F' ;
              Data[6] = (Byte)'G' ;
              Data[7] = (Byte)'H' ;
              Data[8] = (Byte)'a' ;
              Data[9] = (Byte)'b' ;
            AESImhei.E2PromRead(Data, 8) ;
              System.Console.WriteLine("E2Prom Wrote only 4: <"
                + (char)Data[0]
                + (char)Data[1]
                + (char)Data[2]
                + (char)Data[3]
                + (char)Data[4]
                + (char)Data[5]
                + (char)Data[6]
                + (char)Data[7]
                + (char)Data[8]
                + (char)Data[9]
                + ">") ;


            AESImhei.EscrowControlBlock TheEscrowControlBlock = new AESImhei.EscrowControlBlock() ;
            if (AESImhei.ReadEscrowBlock(0, TheEscrowControlBlock))
                {
                System.Console.WriteLine("Escrow available State: " + TheEscrowControlBlock.State) ;

                AESImhei.EscrowCommand(0, AESImhei.EXT_ESCROW_START) ;
                }
            }
        else
            {
            System.Console.WriteLine("OpenMHE Failed " + OpenRes) ;
            }

        System.Console.Write("Done:") ;
        b = System.Console.ReadLine() ;
        }
    }
}
