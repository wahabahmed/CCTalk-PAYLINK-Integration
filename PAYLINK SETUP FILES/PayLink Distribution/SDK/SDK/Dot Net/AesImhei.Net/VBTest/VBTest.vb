Module VBTest
    Sub Main()
        Dim b As String
        System.Console.WriteLine("Hello")
        Dim OpenRes As Integer = AESImhei.OpenMHE()

        If OpenRes = 0 Then
            Dim Ret As Integer
            AESImhei.EnableInterface()

            Dim DateStr As String
            REM            Date = "xx"
            Dim TimeStr As String
            REM String Time = "yy"
            AESImhei.FirmwareVersion(DateStr, TimeStr)

            System.Console.WriteLine("Firmware: on " + DateStr + " at " + TimeStr)
            System.Console.WriteLine("")

            Dim EventDetail As AESImhei.EventDetailBlock = New AESImhei.EventDetailBlock

            AESImhei.NextEvent(EventDetail)

            System.Console.WriteLine("EventCode:" + Str(EventDetail.EventCode))
            System.Console.WriteLine("RawEvent:" + Str(EventDetail.RawEvent))
            System.Console.WriteLine("DispenserEvent:" + Str(EventDetail.DispenserEvent))
            System.Console.WriteLine("Index:" + Str(EventDetail.Index))
            System.Console.WriteLine("")


            Dim TheAcceptor As AESImhei.AcceptorBlock = New AESImhei.AcceptorBlock
            AESImhei.ReadAcceptorDetails(0, TheAcceptor)
            System.Console.WriteLine("Unit:" + Str(TheAcceptor.Unit))
            System.Console.WriteLine("Status:" + Str(TheAcceptor.Status))
            System.Console.WriteLine("NoOfCoins:" + Str(TheAcceptor.NoOfCoins))
            System.Console.WriteLine("InterfaceNumber:" + Str(TheAcceptor.InterfaceNumber))
            System.Console.WriteLine("Currency:" + TheAcceptor.Currency)
            System.Console.WriteLine("Coins:" + Str(TheAcceptor.NoOfCoins))
            System.Console.WriteLine("Description:" + TheAcceptor.Description)
            Dim i As Integer
            For i = 0 To TheAcceptor.NoOfCoins - 1
                System.Console.WriteLine("   Value:" + Str(TheAcceptor.Coin(i).Value))
                System.Console.WriteLine("   Name :" + TheAcceptor.Coin(i).CoinName)
                TheAcceptor.Coin(i).Path = (TheAcceptor.Coin(i).Path + 1) & 7
            Next
            AESImhei.WriteAcceptorDetails(0, TheAcceptor)
            System.Console.WriteLine("")

            Dim TheDispenser As AESImhei.DispenserBlock = New AESImhei.DispenserBlock
            Dim D As Integer = 0
            While AESImhei.ReadDispenserDetails(D, TheDispenser)
                D = D + 1
                System.Console.WriteLine("Description:" + TheDispenser.Description)
                System.Console.WriteLine("UnitAddress:" + Str(TheDispenser.UnitAddress))
                System.Console.WriteLine("Value:" + Str(TheDispenser.Value))
                System.Console.WriteLine("Count:" + Str(TheDispenser.Count))
            End While
            System.Console.WriteLine("")

            AESImhei.EscrowEnable()
            AESImhei.BarcodeEnable()
            Dim Barcode As String
            Ret = AESImhei.BarcodeInEscrow(Barcode)
            System.Console.WriteLine("Barcode Escrow returns: " + Str(Ret) + " <" + Barcode + ">")

            AESImhei.BarcodeAccept()
            Ret = AESImhei.BarcodeStacked(Barcode)
            System.Console.WriteLine("Barcode  returns: " + Str(Ret) + " <" + Barcode + ">")
            System.Console.WriteLine("")

            AESImhei.CounterCaption(1, "For 1")
            AESImhei.CounterCaption(4, "Caption 4")
            System.Console.WriteLine("Caption for 1: " + AESImhei.ReadCounterCaption(1))
            System.Console.WriteLine("Caption for 4: " + AESImhei.ReadCounterCaption(4))
            System.Console.WriteLine("")

            Dim Data(16) As Byte



            Data(0) = Asc("A")
            Data(1) = Asc("B")
            Data(2) = Asc("C")
            Data(3) = Asc("D")
            Data(4) = Asc("E")
            Data(5) = Asc("F")
            Data(6) = Asc("G")
            Data(7) = Asc("H")
            Data(8) = Asc("I")
            Data(9) = Asc("J")

            AESImhei.E2PromRead(Data, 8)
            System.Console.WriteLine("E2Prom Old Read: <" _
              + Chr(Data(0)) _
              + Chr(Data(1)) _
              + Chr(Data(2)) _
              + Chr(Data(3)) _
              + Chr(Data(4)) _
              + Chr(Data(5)) _
              + Chr(Data(6)) _
              + Chr(Data(7)) _
              + Chr(Data(8)) _
              + Chr(Data(9)) _
              + ">")

            Data(0) = Asc("A")
            Data(1) = Asc("B")
            Data(2) = Asc("C")
            Data(3) = Asc("D")
            Data(4) = Asc("E")
            Data(5) = Asc("F")
            Data(6) = Asc("G")
            Data(7) = Asc("H")
            Data(8) = Asc("I")
            Data(9) = Asc("J")
            AESImhei.E2PromWrite(Data, 8)

            Data(8) = Asc("x")
            Data(9) = Asc("y")
            AESImhei.E2PromRead(Data, 8)
            System.Console.WriteLine("E2Prom New Read: <" _
              + Chr(Data(0)) _
              + Chr(Data(1)) _
              + Chr(Data(2)) _
              + Chr(Data(3)) _
              + Chr(Data(4)) _
              + Chr(Data(5)) _
              + Chr(Data(6)) _
              + Chr(Data(7)) _
              + Chr(Data(8)) _
              + Chr(Data(9)) _
              + ">")

            Data(0) = Asc("1")
            Data(1) = Asc("2")
            Data(2) = Asc("3")
            Data(3) = Asc("4")
            Data(4) = Asc("5")
            Data(5) = Asc("6")
            Data(6) = Asc("7")
            Data(7) = Asc("8")
            Data(8) = Asc("9")
            Data(9) = Asc("a")
            AESImhei.E2PromWrite(Data, 4)

            Data(0) = Asc("A")
            Data(1) = Asc("B")
            Data(2) = Asc("C")
            Data(3) = Asc("D")
            Data(4) = Asc("E")
            Data(5) = Asc("F")
            Data(6) = Asc("G")
            Data(7) = Asc("H")
            Data(8) = Asc("a")
            Data(9) = Asc("b")
            AESImhei.E2PromRead(Data, 8)
            System.Console.WriteLine("E2Prom Wrote only 4: <" _
              + Chr(Data(0)) _
              + Chr(Data(1)) _
              + Chr(Data(2)) _
              + Chr(Data(3)) _
              + Chr(Data(4)) _
              + Chr(Data(5)) _
              + Chr(Data(6)) _
              + Chr(Data(7)) _
              + Chr(Data(8)) _
              + Chr(Data(9)) _
              + ">")

        Else
            System.Console.WriteLine("OpenMHE Failed " + Str(OpenRes))
        End If




                System.Console.Write("Done:")
                b = System.Console.ReadLine
    End Sub
End Module
