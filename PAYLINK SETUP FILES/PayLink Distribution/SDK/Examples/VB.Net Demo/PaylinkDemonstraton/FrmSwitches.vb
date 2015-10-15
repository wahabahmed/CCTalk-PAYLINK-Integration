Imports AESImhei

Public Class FrmSwitches
    '************************************************************************************************************
    'This forms with either turn the LED on or off depding on the status of the button clicked on the form.
    'It also will change the on screen appearences of boxes representing the switches depend on if they
    'are set to 1 or 0
    '************************************************************************************************************



    '************************************************************************************************************
    'When form loads, this just ensures that the checkboxes are che3cked accordingly and starts the timer.
    '************************************************************************************************************


    Private Sub FrmSwitches_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TmrSwitches.Start()

        ChkZero.Checked = FrmMain.IndicatorStatus(0)
        ChkOne.Checked = FrmMain.IndicatorStatus(1)
        ChkTwo.Checked = FrmMain.IndicatorStatus(2)
        ChkThree.Checked = FrmMain.IndicatorStatus(3)
        ChkFour.Checked = FrmMain.IndicatorStatus(4)
        ChkFive.Checked = FrmMain.IndicatorStatus(5)
        ChkSix.Checked = FrmMain.IndicatorStatus(6)
        ChkSeven.Checked = FrmMain.IndicatorStatus(7)
        ChkEight.Checked = FrmMain.IndicatorStatus(8)
        ChkNine.Checked = FrmMain.IndicatorStatus(9)
        ChkTen.Checked = FrmMain.IndicatorStatus(10)
        ChkEleven.Checked = FrmMain.IndicatorStatus(11)
        ChkTwelve.Checked = FrmMain.IndicatorStatus(12)
        ChkThirteen.Checked = FrmMain.IndicatorStatus(13)
        ChkFourteen.Checked = FrmMain.IndicatorStatus(14)
        ChkFifteen.Checked = FrmMain.IndicatorStatus(15)


    End Sub

    '************************************************************************************************************
    'This is the section that will change the external LED depending on the status of the checkboxes on the form
    'being checked or not.
    '************************************************************************************************************

    Private Sub ChkZero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkZero.CheckedChanged

        FrmMain.IndicatorStatus(0) = ChkZero.Checked
        If ChkZero.Checked = True Then
            IndicatorOn(0)
        Else
            IndicatorOff(0)
        End If

    End Sub

    Private Sub ChkOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOne.CheckedChanged

        FrmMain.IndicatorStatus(1) = ChkOne.Checked
        If ChkOne.Checked = True Then
            IndicatorOn(1)
        Else
            IndicatorOff(1)
        End If

    End Sub

    Private Sub ChkTwo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTwo.CheckedChanged

        FrmMain.IndicatorStatus(2) = ChkTwo.Checked
        If ChkTwo.Checked = True Then
            IndicatorOn(2)
        Else
            IndicatorOff(2)
        End If

    End Sub

    Private Sub ChkThree_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkThree.CheckedChanged

        FrmMain.IndicatorStatus(3) = ChkThree.Checked
        If ChkThree.Checked = True Then
            IndicatorOn(3)
        Else
            IndicatorOff(3)
        End If

    End Sub

    Private Sub ChkFour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFour.CheckedChanged

        FrmMain.IndicatorStatus(4) = ChkFour.Checked
        If ChkFour.Checked = True Then
            IndicatorOn(4)
        Else
            IndicatorOff(4)
        End If

    End Sub

    Private Sub ChkFive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFive.CheckedChanged

        FrmMain.IndicatorStatus(5) = ChkFive.Checked
        If ChkFive.Checked = True Then
            IndicatorOn(5)
        Else
            IndicatorOff(5)
        End If

    End Sub

    Private Sub ChkSix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSix.CheckedChanged

        FrmMain.IndicatorStatus(6) = ChkSix.Checked
        If ChkSix.Checked = True Then
            IndicatorOn(6)
        Else
            IndicatorOff(6)
        End If

    End Sub

    Private Sub ChkSeven_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSeven.CheckedChanged

        FrmMain.IndicatorStatus(7) = ChkSeven.Checked
        If ChkSeven.Checked = True Then
            IndicatorOn(7)
        Else
            IndicatorOff(7)
        End If

    End Sub

    Private Sub ChkEight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEight.CheckedChanged

        FrmMain.IndicatorStatus(8) = ChkEight.Checked
        If ChkEight.Checked = True Then
            IndicatorOn(8)
        Else
            IndicatorOff(8)
        End If

    End Sub

    Private Sub ChkNine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkNine.CheckedChanged

        FrmMain.IndicatorStatus(9) = ChkNine.Checked
        If ChkNine.Checked = True Then
            IndicatorOn(9)
        Else
            IndicatorOff(9)
        End If

    End Sub

    Private Sub ChkTen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTen.CheckedChanged

        FrmMain.IndicatorStatus(10) = ChkTen.Checked
        If ChkTen.Checked = True Then
            IndicatorOn(10)
        Else
            IndicatorOff(10)
        End If

    End Sub

    Private Sub ChkEleven_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEleven.CheckedChanged

        FrmMain.IndicatorStatus(11) = ChkEleven.Checked
        If ChkEleven.Checked = True Then
            IndicatorOn(11)
        Else
            IndicatorOff(11)
        End If

    End Sub

    Private Sub ChkTwelve_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTwelve.CheckedChanged

        FrmMain.IndicatorStatus(12) = ChkTwelve.Checked
        If ChkTwelve.Checked = True Then
            IndicatorOn(12)
        Else
            IndicatorOff(12)
        End If

    End Sub

    Private Sub ChkThirteen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkThirteen.CheckedChanged

        FrmMain.IndicatorStatus(13) = ChkThirteen.Checked
        If ChkThirteen.Checked = True Then
            IndicatorOn(13)
        Else
            IndicatorOff(13)
        End If

    End Sub

    Private Sub ChkFourteen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFourteen.CheckedChanged

        FrmMain.IndicatorStatus(14) = ChkFourteen.Checked
        If ChkFourteen.Checked = True Then
            IndicatorOn(14)
        Else
            IndicatorOff(14)
        End If

    End Sub

    Private Sub ChkFifteen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFifteen.CheckedChanged

        FrmMain.IndicatorStatus(15) = ChkFifteen.Checked
        If ChkFifteen.Checked = True Then
            IndicatorOn(15)
        Else
            IndicatorOff(15)
        End If

    End Sub


    Private Sub TmrSwitches_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrSwitches.Tick
        '************************************************************************************************************
        'This is the section that will change the appearence of on screen boxes depending on if the the external
        'switches are set to 0 or 1
        '************************************************************************************************************

        If SwitchOpens(0) = SwitchCloses(0) Then
            PnlZero.BackColor = Color.Green
        Else
            PnlZero.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(1) = SwitchCloses(1) Then
            PnlOne.BackColor = Color.Green
        Else
            PnlOne.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(2) = SwitchCloses(2) Then
            PnlTwo.BackColor = Color.Green
        Else
            PnlTwo.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(3) = SwitchCloses(3) Then
            PnlThree.BackColor = Color.Green
        Else
            PnlThree.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(4) = SwitchCloses(4) Then
            PnlFour.BackColor = Color.Green
        Else
            PnlFour.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(5) = SwitchCloses(5) Then
            PnlFive.BackColor = Color.Green
        Else
            PnlFive.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(6) = SwitchCloses(6) Then
            PnlSix.BackColor = Color.Green
        Else
            PnlSix.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(7) = SwitchCloses(7) Then
            PnlSeven.BackColor = Color.Green
        Else
            PnlSeven.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(8) = SwitchCloses(8) Then
            PnlEight.BackColor = Color.Green
        Else
            PnlEight.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(9) = SwitchCloses(9) Then
            PnlNine.BackColor = Color.Green
        Else
            PnlNine.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(10) = SwitchCloses(10) Then
            PnlTen.BackColor = Color.Green
        Else
            PnlTen.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(11) = SwitchCloses(11) Then
            PnlEleven.BackColor = Color.Green
        Else
            PnlEleven.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(12) = SwitchCloses(12) Then
            PnlTwelve.BackColor = Color.Green
        Else
            PnlTwelve.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(13) = SwitchCloses(13) Then
            PnlThirteen.BackColor = Color.Green
        Else
            PnlThirteen.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(14) = SwitchCloses(14) Then
            PnlFourteen.BackColor = Color.Green
        Else
            PnlFourteen.BackColor = Color.Aquamarine
        End If


        If SwitchOpens(15) = SwitchCloses(15) Then
            PnlFifteen.BackColor = Color.Green
        Else
            PnlFifteen.BackColor = Color.Aquamarine
        End If


    End Sub


End Class