Imports AESImhei
Public Class FrmDispensers
    Private DispenserDetails(16) As AESImhei.DispenserBlock
    ' Public Value As String



    Private Sub FrmDispensers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TmrDispensers.Start()

        LblNoDispensers.Show()
        LblDispenseZero.Hide()
        LblDispenseOne.Hide()
        LblDispenseTwo.Hide()
        LblDispenseThree.Hide()
        LblDispenseFour.Hide()
        LblDispenseFive.Hide()
        LblDispenseSix.Hide()
        LblDispenseSeven.Hide()
        LblDispenseEight.Hide()
        LblDispenseNine.Hide()
        LblDispenseTen.Hide()
        LblDispenseEleven.Hide()
        LblDispenseTwelve.Hide()
        LblDispenseThirteen.Hide()
        LblDispenseFourteen.Hide()
        LblDispenseFifteen.Hide()

        TxtValueZero.Hide()
        TxtValueOne.Hide()
        TxtValueTwo.Hide()
        TxtValueThree.Hide()
        TxtValueFour.Hide()
        TxtValueFive.Hide()
        TxtValueSix.Hide()
        TxtValueSeven.Hide()
        TxtValueEight.Hide()
        TxtValueNine.Hide()
        TxtValueTen.Hide()
        TxtValueEleven.Hide()
        TxtValueTwelve.Hide()
        TxtValueThirteen.Hide()
        TxtValueFourteen.Hide()
        TxtValueFifteen.Hide()

        TxtAddressZero.Hide()
        TxtAddressOne.Hide()
        TxtAddressTwo.Hide()
        TxtAddressThree.Hide()
        TxtAddressFour.Hide()
        TxtAddressFive.Hide()
        TxtAddressSix.Hide()
        TxtAddressSeven.Hide()
        TxtAddressEight.Hide()
        TxtAddressNine.Hide()
        TxtAddressTen.Hide()
        TxtAddressEleven.Hide()
        TxtAddressTwelve.Hide()
        TxtAddressThirteen.Hide()
        TxtAddressFourteen.Hide()
        TxtAddressFifteen.Hide()

        TxtCoinsPaidZero.Hide()
        TxtCoinsPaidOne.Hide()
        TxtCoinsPaidTwo.Hide()
        TxtCoinsPaidThree.Hide()
        TxtCoinsPaidFour.Hide()
        TxtCoinsPaidFive.Hide()
        TxtCoinsPaidSix.Hide()
        TxtCoinsPaidSeven.Hide()
        TxtCoinsPaidEight.Hide()
        TxtCoinsPaidNine.Hide()
        TxtCoinsPaidTen.Hide()
        TxtCoinsPaidEleven.Hide()
        TxtCoinsPaidTwelve.Hide()
        TxtCoinsPaidThirteen.Hide()
        TxtCoinsPaidFourteen.Hide()
        TxtCoinsPaidFifteen.Hide()


        TxtContentsZero.Hide()
        TxtContentsOne.Hide()
        TxtContentsTwo.Hide()
        TxtContentsThree.Hide()
        TxtContentsFour.Hide()
        TxtContentsFive.Hide()
        TxtContentsSix.Hide()
        TxtContentsSeven.Hide()
        TxtContentsEight.Hide()
        TxtContentsNine.Hide()
        TxtContentsTen.Hide()
        TxtContentsEleven.Hide()
        TxtContentsTwelve.Hide()
        TxtContentsThirteen.Hide()
        TxtContentsFourteen.Hide()
        TxtContentsFifteen.Hide()

        TxtStatusZero.Hide()
        TxtStatusOne.Hide()
        TxtStatusTwo.Hide()
        TxtStatusThree.Hide()
        TxtStatusFour.Hide()
        TxtStatusFive.Hide()
        TxtStatusSix.Hide()
        TxtStatusSeven.Hide()
        TxtStatusEight.Hide()
        TxtStatusNine.Hide()
        TxtStatusTen.Hide()
        TxtStatusEleven.Hide()
        TxtStatusTwelve.Hide()
        TxtStatusThirteen.Hide()
        TxtStatusFourteen.Hide()
        TxtStatusFifteen.Hide()

        ChkInhibitZero.Hide()
        ChkInhibitOne.Hide()
        ChkInhibitTwo.Hide()
        ChkInhibitThree.Hide()
        ChkInhibitFour.Hide()
        ChkInhibitFive.Hide()
        ChkInhibitSix.Hide()
        ChkInhibitSeven.Hide()
        ChkInhibitEight.Hide()
        ChkInhibitNine.Hide()
        ChkInhibitTen.Hide()
        ChkInhibitEleven.Hide()
        ChkInhibitTwelve.Hide()
        ChkInhibitThirteen.Hide()
        ChkInhibitFourteen.Hide()
        ChkInhibitFifteen.Hide()

    End Sub



    Private Sub TmrDispensers_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrDispensers.Tick

        'It is in a timer to ensure that the status will change in real time



        Dim ReturnCode As Boolean
        Dim J As Integer
        Dim I As Integer

        'To remove compiler warnings of uninitialised structure

        For J = 0 To 15
            DispenserDetails(J) = New AESImhei.DispenserBlock
            DispenserDetails(J).Unit = 0
            DispenserDetails(J).Status = 0
            DispenserDetails(J).InterfaceNumber = 0
            DispenserDetails(J).UnitAddress = 0
            DispenserDetails(J).Value = 0
            DispenserDetails(J).Count = 0
            DispenserDetails(J).Inhibit = 0
            DispenserDetails(J).CoinCount = 0
            DispenserDetails(J).CoinCountStatus = 0
        Next J


        I = 0
        Do
            ReturnCode = ReadDispenserDetails(I, DispenserDetails(I))
            If ReturnCode = True Then
                Dispensers(I, DispenserDetails(I))
            End If

            I = I + 1
        Loop While ReturnCode = True

        Me.Height = 80 + (I * 30)

    End Sub

    Private Sub ChkInhibitZero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitZero.CheckedChanged

        'this checks that when the check button has been checked, it is not already inhibited, and if
        'this is the case, it will inhibit that dispenser

        If ChkInhibitZero.Checked = True And DispenserDetails(0).Inhibit = 0 Then
            DispenserDetails(0).Inhibit = 1
            WriteDispenserDetails(0, DispenserDetails(0))
        End If


        If ChkInhibitZero.Checked = False And DispenserDetails(0).Inhibit <> 0 Then
            DispenserDetails(0).Inhibit = 0
            WriteDispenserDetails(0, DispenserDetails(0))
        End If

    End Sub

    Private Sub ChkInhibitOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitOne.CheckedChanged

        If ChkInhibitOne.Checked = True And DispenserDetails(1).Inhibit = 0 Then
            DispenserDetails(1).Inhibit = 1
            WriteDispenserDetails(1, DispenserDetails(1))
        End If


        If ChkInhibitOne.Checked = False And DispenserDetails(1).Inhibit <> 0 Then
            DispenserDetails(1).Inhibit = 0
            WriteDispenserDetails(1, DispenserDetails(1))
        End If

    End Sub

    Private Sub ChkInhibitTwo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitTwo.CheckedChanged

        If ChkInhibitZero.Checked = True And DispenserDetails(0).Inhibit = 0 Then
            DispenserDetails(0).Inhibit = 1
            WriteDispenserDetails(0, DispenserDetails(0))
        End If


        If ChkInhibitZero.Checked = False And DispenserDetails(0).Inhibit <> 0 Then
            DispenserDetails(0).Inhibit = 0
            WriteDispenserDetails(0, DispenserDetails(0))
        End If

    End Sub

    Private Sub ChkInhibitThree_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitThree.CheckedChanged

        If ChkInhibitThree.Checked = True And DispenserDetails(3).Inhibit = 0 Then
            DispenserDetails(3).Inhibit = 1
            WriteDispenserDetails(3, DispenserDetails(3))
        End If


        If ChkInhibitThree.Checked = False And DispenserDetails(3).Inhibit <> 0 Then
            DispenserDetails(3).Inhibit = 0
            WriteDispenserDetails(3, DispenserDetails(3))
        End If

    End Sub

    Private Sub ChkInhibitFour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitFour.CheckedChanged

        If ChkInhibitFour.Checked = True And DispenserDetails(4).Inhibit = 0 Then
            DispenserDetails(4).Inhibit = 1
            WriteDispenserDetails(4, DispenserDetails(4))
        End If


        If ChkInhibitFour.Checked = False And DispenserDetails(4).Inhibit <> 0 Then
            DispenserDetails(4).Inhibit = 0
            WriteDispenserDetails(4, DispenserDetails(4))
        End If


    End Sub

    Private Sub ChkInhibitFive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitFive.CheckedChanged

        If ChkInhibitFive.Checked = True And DispenserDetails(5).Inhibit = 0 Then
            DispenserDetails(5).Inhibit = 1
            WriteDispenserDetails(5, DispenserDetails(5))
        End If


        If ChkInhibitFive.Checked = False And DispenserDetails(5).Inhibit <> 0 Then
            DispenserDetails(5).Inhibit = 0
            WriteDispenserDetails(5, DispenserDetails(5))
        End If


    End Sub

    Private Sub ChkInhibitSix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitSix.CheckedChanged

        If ChkInhibitSix.Checked = True And DispenserDetails(6).Inhibit = 0 Then
            DispenserDetails(6).Inhibit = 1
            WriteDispenserDetails(6, DispenserDetails(6))
        End If


        If ChkInhibitSix.Checked = False And DispenserDetails(6).Inhibit <> 0 Then
            DispenserDetails(6).Inhibit = 0
            WriteDispenserDetails(6, DispenserDetails(6))
        End If


    End Sub

    Private Sub ChkInhibitSeven_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitSeven.CheckedChanged

        If ChkInhibitSeven.Checked = True And DispenserDetails(7).Inhibit = 0 Then
            DispenserDetails(7).Inhibit = 1
            WriteDispenserDetails(7, DispenserDetails(7))
        End If


        If ChkInhibitSeven.Checked = False And DispenserDetails(7).Inhibit <> 0 Then
            DispenserDetails(7).Inhibit = 0
            WriteDispenserDetails(7, DispenserDetails(7))
        End If


    End Sub

    Private Sub ChkInhibitEight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitEight.CheckedChanged

        If ChkInhibitEight.Checked = True And DispenserDetails(8).Inhibit = 0 Then
            DispenserDetails(8).Inhibit = 1
            WriteDispenserDetails(8, DispenserDetails(8))
        End If


        If ChkInhibitEight.Checked = False And DispenserDetails(8).Inhibit <> 0 Then
            DispenserDetails(8).Inhibit = 0
            WriteDispenserDetails(8, DispenserDetails(8))
        End If


    End Sub

    Private Sub ChkInhibitNine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitNine.CheckedChanged

        If ChkInhibitNine.Checked = True And DispenserDetails(9).Inhibit = 0 Then
            DispenserDetails(9).Inhibit = 1
            WriteDispenserDetails(9, DispenserDetails(9))
        End If


        If ChkInhibitNine.Checked = False And DispenserDetails(9).Inhibit <> 0 Then
            DispenserDetails(9).Inhibit = 0
            WriteDispenserDetails(9, DispenserDetails(9))
        End If


    End Sub


End Class