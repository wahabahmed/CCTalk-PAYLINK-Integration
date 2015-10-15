Imports AESImhei
Public Class FrmAcceptors
    Private AcceptorDetails(16) As AESImhei.AcceptorBlock
    Private newCoin(16) As AcceptorCoin
    Public ReturnCode As Boolean
    Public I As Integer
    Public SelectedAcceptor As Integer

    Private Sub FrmAcceptors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TmrAcceptors.Start()

        'CmbAcceptors.Items.Add(AcceptorsModule.AcceptorName(0))

        I = 0

        Do
            AcceptorDetails(I) = New AESImhei.AcceptorBlock

            ReturnCode = ReadAcceptorDetails(I, AcceptorDetails(I))


            If ReturnCode = True Then

                Acceptor(I, AcceptorDetails(I))

                CmbAcceptors.Items.Add(AcceptorsModule.AcceptorName(I))

            End If



            I = I + 1

        Loop While ReturnCode = True

        CmbAcceptors.SelectedIndex = 0






    End Sub

    Private Sub TmrAcceptors_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrAcceptors.Tick
        'This is added to the timer so that the status will be updated from paylink as the the acceptor
        'is disabled or enabled
        I = 0

        Do
            AcceptorDetails(I) = New AESImhei.AcceptorBlock

            ReturnCode = ReadAcceptorDetails(I, AcceptorDetails(I))


            If ReturnCode = True Then

                Acceptor(I, AcceptorDetails(I))


            End If


            I = I + 1

        Loop While ReturnCode = True



        'Takes the selected index of the item selected in the drop down box
        SelectedAcceptor = CmbAcceptors.SelectedIndex

        'This selected index is then fed into Acceptor, to display the acceptor
        'details which have already been obtained in form load time

        TxtAcceptorStatus.Text = StatusOfAcceptor(SelectedAcceptor)
        TxtUnitAddress.Text = AcceptorUnitAddress(SelectedAcceptor)
        TxtAcceptorTypes.Text = NoOfCoins(SelectedAcceptor)
        TxtEventCount.Text = EventCount(SelectedAcceptor)
        TxtDefaulted.Text = DefaultAcceptorPath(SelectedAcceptor)
        TxtInterface.Text = AcceptorInterface(SelectedAcceptor)
        TxtCurrency.Text = AcceptorCurrency(SelectedAcceptor)



        ReadAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))



        'This populates the various text boxes regarding coins that can be accepted 
        'depending on the selected acceptor
        TxtValueZero.Text = CoinValue(SelectedAcceptor, 0)
        TxtCountZero.Text = CoinCount(SelectedAcceptor, 0)
        TxtRoutedZero.Text = CoinRouted(SelectedAcceptor, 0)
        TxtDefaultZero.Text = CoinDefault(SelectedAcceptor, 0)
        TxtSentZero.Text = CoinPathCount(SelectedAcceptor, 0)
        TxtLevelZero.Text = CoinSwitchLevel(SelectedAcceptor, 0)
        TxtEscrowZero.Text = CoinEscrow(SelectedAcceptor, 0)

        TxtValueOne.Text = CoinValue(SelectedAcceptor, 1)
        TxtCountOne.Text = CoinCount(SelectedAcceptor, 1)
        TxtRoutedOne.Text = CoinRouted(SelectedAcceptor, 1)
        TxtDefaultOne.Text = CoinDefault(SelectedAcceptor, 1)
        TxtSentOne.Text = CoinPathCount(SelectedAcceptor, 1)
        TxtLevelOne.Text = CoinSwitchLevel(SelectedAcceptor, 1)
        TxtEscrowOne.Text = CoinEscrow(SelectedAcceptor, 1)

        TxtValueTwo.Text = CoinValue(SelectedAcceptor, 2)
        TxtCountTwo.Text = CoinCount(SelectedAcceptor, 2)
        TxtRoutedTwo.Text = CoinRouted(SelectedAcceptor, 2)
        TxtDefaultTwo.Text = CoinDefault(SelectedAcceptor, 2)
        TxtSentTwo.Text = CoinPathCount(SelectedAcceptor, 2)
        TxtLevelTwo.Text = CoinSwitchLevel(SelectedAcceptor, 2)
        TxtEscrowTwo.Text = CoinEscrow(SelectedAcceptor, 2)

        TxtValueThree.Text = CoinValue(SelectedAcceptor, 3)
        TxtCountThree.Text = CoinCount(SelectedAcceptor, 3)
        TxtRoutedThree.Text = CoinRouted(SelectedAcceptor, 3)
        TxtDefaultThree.Text = CoinDefault(SelectedAcceptor, 3)
        TxtSentThree.Text = CoinPathCount(SelectedAcceptor, 3)
        TxtLevelThree.Text = CoinSwitchLevel(SelectedAcceptor, 3)
        TxtEscrowThree.Text = CoinEscrow(SelectedAcceptor, 3)

        TxtValueFour.Text = CoinValue(SelectedAcceptor, 4)
        TxtCountFour.Text = CoinCount(SelectedAcceptor, 4)
        TxtRoutedFour.Text = CoinRouted(SelectedAcceptor, 4)
        TxtDefaultFour.Text = CoinDefault(SelectedAcceptor, 4)
        TxtSentFour.Text = CoinPathCount(SelectedAcceptor, 4)
        TxtLevelFour.Text = CoinSwitchLevel(SelectedAcceptor, 4)
        TxtEscrowFour.Text = CoinEscrow(SelectedAcceptor, 4)

        TxtValueFive.Text = CoinValue(SelectedAcceptor, 5)
        TxtCountFive.Text = CoinCount(SelectedAcceptor, 5)
        TxtRoutedFive.Text = CoinRouted(SelectedAcceptor, 5)
        TxtDefaultFive.Text = CoinDefault(SelectedAcceptor, 5)
        TxtSentFive.Text = CoinPathCount(SelectedAcceptor, 5)
        TxtLevelFive.Text = CoinSwitchLevel(SelectedAcceptor, 5)
        TxtEscrowFive.Text = CoinEscrow(SelectedAcceptor, 5)

        TxtValueSix.Text = CoinValue(SelectedAcceptor, 6)
        TxtCountSix.Text = CoinCount(SelectedAcceptor, 6)
        TxtRoutedSix.Text = CoinRouted(SelectedAcceptor, 6)
        TxtDefaultSix.Text = CoinDefault(SelectedAcceptor, 6)
        TxtSentSix.Text = CoinPathCount(SelectedAcceptor, 6)
        TxtLevelSix.Text = CoinSwitchLevel(SelectedAcceptor, 6)
        TxtEscrowSix.Text = CoinEscrow(SelectedAcceptor, 6)

        TxtValueSeven.Text = CoinValue(SelectedAcceptor, 7)
        TxtCountSeven.Text = CoinCount(SelectedAcceptor, 7)
        TxtRoutedSeven.Text = CoinRouted(SelectedAcceptor, 7)
        TxtDefaultSeven.Text = CoinDefault(SelectedAcceptor, 7)
        TxtSentSeven.Text = CoinPathCount(SelectedAcceptor, 7)
        TxtLevelSeven.Text = CoinSwitchLevel(SelectedAcceptor, 7)
        TxtEscrowSeven.Text = CoinEscrow(SelectedAcceptor, 7)

        TxtValueEight.Text = CoinValue(SelectedAcceptor, 8)
        TxtCountEight.Text = CoinCount(SelectedAcceptor, 8)
        TxtRoutedEight.Text = CoinRouted(SelectedAcceptor, 8)
        TxtDefaultEight.Text = CoinDefault(SelectedAcceptor, 8)
        TxtSentEight.Text = CoinPathCount(SelectedAcceptor, 8)
        TxtLevelEight.Text = CoinSwitchLevel(SelectedAcceptor, 8)
        TxtEscrowEight.Text = CoinEscrow(SelectedAcceptor, 8)

        TxtValueNine.Text = CoinValue(SelectedAcceptor, 9)
        TxtCountNine.Text = CoinCount(SelectedAcceptor, 9)
        TxtRoutedNine.Text = CoinRouted(SelectedAcceptor, 9)
        TxtDefaultNine.Text = CoinDefault(SelectedAcceptor, 9)
        TxtSentNine.Text = CoinPathCount(SelectedAcceptor, 9)
        TxtLevelNine.Text = CoinSwitchLevel(SelectedAcceptor, 9)
        TxtEscrowNine.Text = CoinEscrow(SelectedAcceptor, 9)

        TxtValueTen.Text = CoinValue(SelectedAcceptor, 10)
        TxtCountTen.Text = CoinCount(SelectedAcceptor, 10)
        TxtRoutedTen.Text = CoinRouted(SelectedAcceptor, 10)
        TxtDefaultTen.Text = CoinDefault(SelectedAcceptor, 10)
        TxtSentTen.Text = CoinPathCount(SelectedAcceptor, 10)
        TxtLevelTen.Text = CoinSwitchLevel(SelectedAcceptor, 10)
        TxtEscrowTen.Text = CoinEscrow(SelectedAcceptor, 10)

        TxtValueEleven.Text = CoinValue(SelectedAcceptor, 11)
        TxtCountEleven.Text = CoinCount(SelectedAcceptor, 11)
        TxtRoutedEleven.Text = CoinRouted(SelectedAcceptor, 11)
        TxtDefaultEleven.Text = CoinDefault(SelectedAcceptor, 11)
        TxtSentEleven.Text = CoinPathCount(SelectedAcceptor, 11)
        TxtLevelEleven.Text = CoinSwitchLevel(SelectedAcceptor, 11)
        TxtEscrowEleven.Text = CoinEscrow(SelectedAcceptor, 11)

        TxtValueTwelve.Text = CoinValue(SelectedAcceptor, 12)
        TxtCountTwelve.Text = CoinCount(SelectedAcceptor, 12)
        TxtRoutedTwelve.Text = CoinRouted(SelectedAcceptor, 12)
        TxtDefaultTwelve.Text = CoinDefault(SelectedAcceptor, 12)
        TxtSentTwelve.Text = CoinPathCount(SelectedAcceptor, 12)
        TxtLevelTwelve.Text = CoinSwitchLevel(SelectedAcceptor, 12)
        TxtEscrowTwelve.Text = CoinEscrow(SelectedAcceptor, 12)

        TxtValueThirteen.Text = CoinValue(SelectedAcceptor, 13)
        TxtCountThirteen.Text = CoinCount(SelectedAcceptor, 13)
        TxtRoutedThirteen.Text = CoinRouted(SelectedAcceptor, 13)
        TxtDefaultThirteen.Text = CoinDefault(SelectedAcceptor, 13)
        TxtSentThirteen.Text = CoinPathCount(SelectedAcceptor, 13)
        TxtLevelThirteen.Text = CoinSwitchLevel(SelectedAcceptor, 13)
        TxtEscrowThirteen.Text = CoinEscrow(SelectedAcceptor, 13)

        TxtValueFourteen.Text = CoinValue(SelectedAcceptor, 14)
        TxtCountFourteen.Text = CoinCount(SelectedAcceptor, 14)
        TxtRoutedFourteen.Text = CoinRouted(SelectedAcceptor, 14)
        TxtDefaultFourteen.Text = CoinDefault(SelectedAcceptor, 14)
        TxtSentFourteen.Text = CoinPathCount(SelectedAcceptor, 14)
        TxtLevelFourteen.Text = CoinSwitchLevel(SelectedAcceptor, 14)
        TxtEscrowFourteen.Text = CoinEscrow(SelectedAcceptor, 14)

        TxtValueFifteen.Text = CoinValue(SelectedAcceptor, 15)
        TxtCountFifteen.Text = CoinCount(SelectedAcceptor, 15)
        TxtRoutedFifteen.Text = CoinRouted(SelectedAcceptor, 15)
        TxtDefaultfifteen.Text = CoinDefault(SelectedAcceptor, 15)
        TxtSentfifteen.Text = CoinPathCount(SelectedAcceptor, 15)
        TxtLevelfifteen.Text = CoinSwitchLevel(SelectedAcceptor, 15)
        TxtEscrowFifteen.Text = CoinEscrow(SelectedAcceptor, 15)


        If AcceptorDetails(SelectedAcceptor).Coin(0).Inhibit <> 0 Then
            ChkInhibitZero.Checked = True
        Else
            ChkInhibitZero.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(1).Inhibit <> 0 Then
            ChkInhibitOne.Checked = True
        Else
            ChkInhibitOne.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(2).Inhibit <> 0 Then
            ChkInhibitTwo.Checked = True
        Else
            ChkInhibitTwo.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(3).Inhibit <> 0 Then
            ChkInhibitThree.Checked = True
        Else
            ChkInhibitThree.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(4).Inhibit <> 0 Then
            ChkInhibitFour.Checked = True
        Else
            ChkInhibitFour.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(5).Inhibit <> 0 Then
            ChkInhibitFive.Checked = True
        Else
            ChkInhibitFive.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(6).Inhibit <> 0 Then
            ChkInhibitSix.Checked = True
        Else
            ChkInhibitSix.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(7).Inhibit <> 0 Then
            ChkInhibitSeven.Checked = True
        Else
            ChkInhibitSeven.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(8).Inhibit <> 0 Then
            ChkInhibitEight.Checked = True
        Else
            ChkInhibitEight.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(9).Inhibit <> 0 Then
            ChkInhibitNine.Checked = True
        Else
            ChkInhibitNine.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(10).Inhibit <> 0 Then
            ChkInhibitTen.Checked = True
        Else
            ChkInhibitTen.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(11).Inhibit <> 0 Then
            ChkInhibitEleven.Checked = True
        Else
            ChkInhibitEleven.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(12).Inhibit <> 0 Then
            ChkInhibitTwelve.Checked = True
        Else
            ChkInhibitTwelve.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(13).Inhibit <> 0 Then
            ChkInhibitThirteen.Checked = True
        Else
            ChkInhibitThirteen.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(14).Inhibit <> 0 Then
            ChkInhibitFourteen.Checked = True
        Else
            ChkInhibitOne.Checked = False
        End If

        If AcceptorDetails(SelectedAcceptor).Coin(15).Inhibit <> 0 Then
            ChkInhibitFifteen.Checked = True
        Else
            ChkInhibitFifteen.Checked = False
        End If
    End Sub

    Private Sub ChkInhibitZero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitZero.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(0).Inhibit = BoolToInt(ChkInhibitZero.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitOne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitOne.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(1).Inhibit = BoolToInt(ChkInhibitOne.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitTwo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitTwo.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(2).Inhibit = BoolToInt(ChkInhibitTwo.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitThree_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitThree.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(3).Inhibit = BoolToInt(ChkInhibitThree.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitFour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitFour.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(4).Inhibit = BoolToInt(ChkInhibitFour.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitFive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitFive.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(5).Inhibit = BoolToInt(ChkInhibitFive.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitSix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitSix.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(6).Inhibit = BoolToInt(ChkInhibitSix.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitSeven_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitSeven.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(7).Inhibit = BoolToInt(ChkInhibitSeven.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitEight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitEight.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(8).Inhibit = BoolToInt(ChkInhibitEight.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitNine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitNine.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(9).Inhibit = BoolToInt(ChkInhibitNine.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitTen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitTen.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(10).Inhibit = BoolToInt(ChkInhibitTen.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitEleven_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitEleven.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(11).Inhibit = BoolToInt(ChkInhibitEleven.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitTwelve_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitTwelve.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(12).Inhibit = BoolToInt(ChkInhibitTwelve.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitThirteen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitThirteen.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(13).Inhibit = BoolToInt(ChkInhibitThirteen.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitFourteen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitFourteen.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(14).Inhibit = BoolToInt(ChkInhibitFourteen.Checked)

        WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

    End Sub

    Private Sub ChkInhibitFifteen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInhibitFifteen.CheckedChanged

        AcceptorDetails(SelectedAcceptor).Coin(15).Inhibit = BoolToInt(ChkInhibitFifteen.Checked)



    End Sub

    Private Sub ChkDisable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDisable.CheckedChanged


        If ((ChkDisable.Checked = True) And _
        (Not (AcceptorDetails(SelectedAcceptor).Status And (ACCEPTOR_DISABLED Or ACCEPTOR_INHIBIT)))) <> 0 Then
            AcceptorDetails(SelectedAcceptor).Status = ACCEPTOR_INHIBIT
            WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))
        End If


        If ((ChkDisable.Checked = False) And _
        (AcceptorDetails(SelectedAcceptor).Status And _
                       (ACCEPTOR_DISABLED Or ACCEPTOR_INHIBIT))) <> 0 Then


            AcceptorDetails(SelectedAcceptor).Status = AcceptorDetails(SelectedAcceptor).Status And (Not ACCEPTOR_INHIBIT)

            WriteAcceptorDetails(SelectedAcceptor, AcceptorDetails(SelectedAcceptor))

        End If
    End Sub

End Class