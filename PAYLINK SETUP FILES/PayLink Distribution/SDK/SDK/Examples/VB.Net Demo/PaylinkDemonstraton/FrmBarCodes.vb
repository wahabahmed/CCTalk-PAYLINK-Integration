Imports AESImhei

Public Class FrmBarCodes
    Public BCTime As String
    Public BCDate As String
    Public SecondWordAmount As String
    Public BCMachine As String
    Public BCValue As String
    '************************************************************************************************************
    'This section of the project enables barcodes to be read, handles the barcodes held in escrow,
    'enables barcodes to be printed and it calls the cunction that converts the number integers to strings.
    '************************************************************************************************************
    Private Sub FrmBarCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '************************************************************************************************************
        'Calls the function to enable the barcodes to be read
        'Starts both the timers
        '************************************************************************************************************
        BarcodeEnable()
        TmrBarcodesOne.Start()
        TmrBCDate.Start()

        TxtBCMachine.Text = "1234"
        TxtBCValue.Text = "123456789012345678"

    End Sub

    Private Sub FrmBarCodes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        BarcodeDisable()
        '************************************************************************************************************
        'If the form is closed, it calls the function to stop talking
        'allowing for barcodes to be read
        '************************************************************************************************************
    End Sub

    Private Sub BtnBCAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBCAccept.Click
        BarcodeAccept()
        '************************************************************************************************************
        'Calls the function to accept the barcode in escrow
        '************************************************************************************************************

    End Sub

    Private Sub BtnBCReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBCReturn.Click
        BarcodeReturn()
        '************************************************************************************************************
        'Calls the function to return the barcode in escrow
        '************************************************************************************************************
    End Sub

    Private Sub TmrBarcodes_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrBarcodesOne.Tick
        Dim BCEscrow As Boolean
        Dim BarcodeString As String
        BarcodeString = "" 'Suppresses compiler warning
        '************************************************************************************************************
        'If a barcode is held in escrow, it returns either true or false
        'This allocates the value of the barcode held in escrow to the 
        'textbox TxtBCHeld
        'This is done in a timer to compensate for a barcode being added 
        'whilst the window is open
        '************************************************************************************************************

        BCEscrow = BarcodeInEscrow(BarcodeString)
        If BCEscrow = True Then
            TxtBCHeld.Text = BarcodeString
        End If
        '************************************************************************************************************
        'Think i can loose this?
        '************************************************************************************************************
        'This calls a function in the BarcodesModule do display the status 
        'of the barcode printer
        ' Dim BarcodePrinter As Integer
        'Dim PrinterStatus As String
        'PrinterStatus = "" 'Suppresses compiler warnings

        'This calls the function to establish the status of the barcode printer
        'It uses the information obtained form Paylink and feeds this in to
        'a function in the BarcodeModule to display the status as text
        'BCPrinter(BarcodePrinter, PrinterStatus)
        ' TxtBCStatus.Text = PrinterStatus


    End Sub

    Private Sub TmrBarcodesTwo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrBarcodesTwo.Tick
        '************************************************************************************************************
        'Think i can loose this too?
        '************************************************************************************************************
        'Dim BCStacked As Boolean
        'Dim LastBarcodeStacked As String
        'Dim BCCount As Integer
        'This assigns the barcodes that have been stacked and counted ot a variable
        'and if there has been a new barcode stacked it adds it to the count
        'This is done in a timer to allow it to change itf a barcode has been added 
        'whilst the window is open

        'LastBarcodeStacked = "" ' Suppresses compiler warning
        'BCCount = BarcodeStacked(LastBarcodeStacked)
        'BCStacked = BarcodeStacked(LastBarcodeStacked)

        'If BCStacked = True Then

        ' TxtBCStacked.Text = LastBarcodeStacked
        ' TxtBCCount.Text = BCCount

        'End If

    End Sub

    Private Sub TmrBCDate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrBCDate.Tick
        '************************************************************************************************************
        'This displays the date and time, and is done in a timer so 
        'it'll be constantly updated.
        'It obtains the date from the computer clock that it is being run off, to ensure,
        'provided that the computer clock is set correctly, that the date and time
        'will be correct, so if the window is shut, and re-opened the time will 
        'have updated correctly.
        '************************************************************************************************************


        BCTime = "" 'Suppresses compiler warnings
        BCTime = TimeString
        TxtBCTime.Text = BCTime

        BCDate = "" 'Suppresses compiler warnings
        BCDate = Format(Now, "dd MMM yyyy")
        TxtBCDate.Text = BCDate

    End Sub

    Private Sub BtnBCChangeAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBCChangeAmount.Click
        '************************************************************************************************************
        'This is section that calls the cuntion to change the numerical amount to a word amount
        '************************************************************************************************************
        Dim AlphaNumberic As String
        StrAmount = TxtBCAmount.Text
        NumberConvert.NumberConvert(StrAmount, AlphaNumberic)
        TxtBCWordAmount.Text = AlphaNumberic


    End Sub

    Private Sub TxtBCAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBCAmount.TextChanged

        '************************************************************************************************************
        'This section occurs when the text in TxtAmount is changed in anyway
        'This enables the program to validate the text entered 
        'It checks to ensure it only contains numbers, and full stop, commas, p, P or the specified 
        'currency symbols (at the moment £, $, €, but this can be altered)
        'And to do this is calls the function CharacterValidity
        'If it is not one of the accepted characters enetered, then the machine beeps and shows a warning
        'This will continue everytime there is a text changed until the illegal characters are deleted
        '************************************************************************************************************
        Dim Q As Integer
        Dim I As Integer
        Dim CharacterTyped As String
        Dim Kosher As Boolean

        Q = Len(TxtBCAmount.Text)

        For I = 1 To Q
            CharacterTyped = TxtBCAmount.Text.Substring(I - 1, 1)
            CharacterValidity(CharacterTyped, Kosher)
            If Kosher = False Then
                Beep()
                MessageBox.Show("Character Not Accepted")
            End If
        Next I


    End Sub


    Private Sub BtnTicketPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTicketPrint.Click
        '************************************************************************************************************
        'This calls the fucntion to print barcodes and feeds it all the relevant information
        '************************************************************************************************************
        SecondWordAmount = TxtBCWordAmount.Text
        BCMachine = TxtBCMachine.Text
        BCValue = TxtBCValue.Text
        REM BarcodePrint()
    End Sub


End Class