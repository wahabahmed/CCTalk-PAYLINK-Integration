Imports AESImhei
Module BarcodeModule
    Public Sub BCPrinter(ByVal BarcodePrinter As Integer, ByRef PrinterStatus As String)
        '*************************************************************
        'REVISIT THIS
        'curently the printer status doesn't update
        '*************************************************************

        'This is a sub-routine to establish the status of the barcode printer from Paylink

        Select Case BarcodePrinter

            Case PRINTER_NONE

                PrinterStatus = "None"

            Case PRINTER_FAULT

                PrinterStatus = "Faulty"

            Case PRINTER_IDLE

                PrinterStatus = "Idle OK"

            Case PRINTER_BUSY

                PrinterStatus = "Busy"

            Case Else

                PrinterStatus = "???"

        End Select
    End Sub


End Module
