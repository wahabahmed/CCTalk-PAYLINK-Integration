Imports AESImhei

Public Class FrmMain
    Private ActiveDispenser As AESImhei.DispenserBlock = New AESImhei.DispenserBlock
    Public TotalAmountIn As Integer
    Public NewTotalAmountIn As Integer
    Public AmountJustIn As Integer
    Public TotalPayout As Integer
    Public NewTotalPayout As Integer
    Public AmountToPayout As Integer
    Public EscrowAmount As Integer
    Public NewEscrowAmount As Integer
    Public AmountInEscrow As Integer
    Public PriorResetAmount As Integer
    Public ActiveHopper As Integer
    Public IndicatorStatus(16) As Boolean
    Public SwitchStatus(16) As Boolean


    Private Sub BtnSwitches_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSwitches.Click

        FrmSwitches.Show() 'opens the Switches and LEDs form

    End Sub



    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim I As Integer

        For I = 0 To 15
            IndicatorStatus(I) = False
            IndicatorOff(I)
        Next I



        ActiveHopper = -1



        Me.Height = 470 'sets the main length of the form
        OpenMHE()
        EnableInterface()
        'these start talking to the bill acceptor
        TmrMain.Start()

        TotalAmountIn = CurrentValue() 'assigns to variable TotalAmountIn
        TxtTotalAmount.Text = Format(TotalAmountIn / 100, "currency") 'displays htis as currency
        EscrowAmount = EscrowThroughput() 'assigns to the varable EscrowAmount


        CurrentPaid() 'calls the CurrentPaid functon

        TotalPayout = CurrentPaid() 'assigns this to the variable TotalPayout
        TxtTotalPayout.Text = Format(TotalPayout / 100, "currency") 'Displays this as currency




        Dim HopperTotal As Integer
        Dim AccumulatedTotal As Integer
        Dim ReturnCode As Boolean

        HopperTotal = 0
        AccumulatedTotal = 0

        Do

            ReturnCode = ReadDispenserDetails(AccumulatedTotal, ActiveDispenser)

            If ReturnCode = True Then

                HopperTotal = HopperTotal + ActiveDispenser.Value

            End If

            AccumulatedTotal = AccumulatedTotal + 1

        Loop While ReturnCode = True


        TxtPayout.Text = Format((HopperTotal / 100) * 2, "f2")



    End Sub


    Private Sub TmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrMain.Tick
        'In the timer run

        NewTotalAmountIn = CurrentValue() 'Assigns to the variable NewTotalAmountIn


        'TxtPriorReset.Text = AmountJustIn
        TxtPriorReset.Text = Format(PriorResetAmount / 100, "currency")


        If NewTotalAmountIn <> TotalAmountIn Then
            'this will check to see if a note has been added by checking whether the new CurrentValue
            'is greater than CurrentValue a moment ago

            AmountJustIn = NewTotalAmountIn - TotalAmountIn
            'this works out the amount in by deducting the old CurrentValue from the new CurrentValue if they aren't equal
            TxtAmountRead.Text = Format(AmountJustIn / 100, "currency")

            TotalAmountIn = NewTotalAmountIn
            TxtTotalAmount.Text = Format(TotalAmountIn / 100, "currency") 'dsplays the total amount in


            PriorResetAmount = PriorResetAmount + AmountJustIn


        End If


        NewEscrowAmount = EscrowThroughput() 'Assigns to the variable NewEscrowAmount
        If NewEscrowAmount <> EscrowAmount Then 'checks to see if the old and new escrow amounts are the same

            AmountInEscrow = NewEscrowAmount - EscrowAmount 'if not, then assigns the difference to the variable AmountInEscrow
            TxtAmountEscrow.Text = Format(AmountInEscrow / 100, "currency") 'displays this as currency

            EscrowAmount = NewEscrowAmount 'updates "old" escrow amount

        End If


        'This secton will determine and display the current status of the hopper(s) on the main form
        Dim P As Integer
        Dim StatusString As String

        StatusString = ""   ' Suppress compiler warning

        P = LastPayStatus()
        PayingStatus(P, StatusString)
        TxtPayStatus.Text = StatusString



        'This secton wll update the total amount dispensed in real time
        Dim Payout As Integer

        NewTotalPayout = CurrentPaid()

        If NewTotalPayout <> TotalPayout Then

            Payout = NewTotalPayout - TotalPayout

            TotalPayout = NewTotalPayout
            TxtTotalPayout.Text = Format(TotalPayout / 100, "currency")

        End If

    End Sub

    Private Sub ChkEscrow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEscrow.CheckedChanged
        'When the check box (made tyo appear as a button) is checked/unchecked
        If ChkEscrow.Checked = True Then

            Me.Height = 576 'Increases the length of the main form
            ChkEscrow.Text = "Escrow Off" 'changes the text on the "escrow button"

            EscrowEnable() 'calls the escrow functon

        Else

            Me.Height = 470 'If the check box is unchecked then it is as the same height as when the form loads

            ChkEscrow.Text = "Escrow On" 'And the text on the check box will return to "Escrow On"
            EscrowDisable()

        End If
    End Sub

    Private Sub BtnResetAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnResetAmount.Click
        'When the "reset" button is clicked

        TxtAmountRead.Text = Format("0.00", "currency") 'Clears the text box
        AmountJustIn = 0 'clears the variable
        TxtPriorReset.Text = Format("0.00", "currency") 'Sets the total amount in the text box prior to resetting to 0
        PriorResetAmount = 0

    End Sub

    Private Sub BtnAcceptEscrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcceptEscrow.Click
        EscrowAccept() 'calls the functon to accept the note in escrow
        TxtAmountEscrow.Text = "£0.00" 'clears the text box once the note has been accepted as there is no longer anything in escrow

    End Sub

    Private Sub BtnReturnEscrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReturnEscrow.Click
        EscrowReturn() 'calls the functon to reject th enote in escrow
        TxtAmountEscrow.Text = "£0.00" 'clears the text box once the note has been rejected, as there is no longer anything in escrow
    End Sub

    Private Sub BtnPayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPayout.Click


        Dim ToBePaid As String

        ToBePaid = Val(TxtPayout.Text)

        AmountToPayout = ToBePaid * 100
        PayOut(AmountToPayout) 'calls the PayOut functon




        'This takes the value that has been typed into the text 
        'box under "payout", and assigns it to the variable ToBePaid
        'This can then be manpulated (it is multiplied by 100 as the coin dispensers/acceptors
        'work in pence) and the PayOut functon can be called to pay this out.


    End Sub


    Private Sub BtnDispensers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDispensers.Click
        'Displays the Dispensers form when it's clicked
        'If the form is already open, it brings that form to the front.  
        FrmDispensers.Show()
        FrmDispensers.BringToFront()

    End Sub

    Private Sub FrmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'When the button "Exit" is clicked
        EscrowDisable() 'prevents the bill acceptor being in escrow mode

    End Sub

    Private Sub BtnBarCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBarCodes.Click
        FrmBarCodes.Show()
        FrmBarCodes.BringToFront()
    End Sub

    Private Sub BtnMeter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMeter.Click
        FrmMeter.Show()
        FrmMeter.BringToFront()
    End Sub

    Private Sub BtnAcceptors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcceptors.Click
        FrmAcceptors.Show()
        FrmAcceptors.BringToFront()
    End Sub

End Class
