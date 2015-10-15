Imports AESImhei

Module DispensersModule
    Public Sub Dispensers(ByVal DispenserNumber As Integer, ByRef TheDispenser As AESImhei.DispenserBlock)

        'This function is called on when dispensers are added to Palink.
        'The number of dispensers determines which case (0 to 15) to use.
        'Each case shows the appropriate text box, gets the information for each
        'hopper from Paylink and displays it. It also allows the user to 
        'inhibit the hopper and if this is checked, tells the Paylink board that this
        'hopper is inhibited.
        '(It also controls the form length, and so the form gets longer the more hoppers that are added)

        Dim Tempstring As String
        Dim StatusString As String

        Tempstring = ""
        StatusString = ""

        Select Case DispenserNumber


            Case 0

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueZero.Show()
                FrmDispensers.TxtAddressZero.Show()
                FrmDispensers.TxtCoinsPaidZero.Show()
                FrmDispensers.TxtContentsZero.Show()
                FrmDispensers.TxtStatusZero.Show()
                FrmDispensers.LblDispenseZero.Show()
                FrmDispensers.ChkInhibitZero.Show()

                FrmDispensers.TxtValueZero.Text = TheDispenser.Value
                FrmDispensers.TxtAddressZero.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidZero.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsZero.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusZero.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseZero.Text = Tempstring


                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitZero.Checked = True

                Else
                    FrmDispensers.ChkInhibitZero.Checked = False

                End If


            Case 1

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueOne.Show()
                FrmDispensers.TxtAddressOne.Show()
                FrmDispensers.TxtCoinsPaidOne.Show()
                FrmDispensers.TxtContentsOne.Show()
                FrmDispensers.TxtStatusOne.Show()
                FrmDispensers.LblDispenseOne.Show()
                FrmDispensers.ChkInhibitOne.Show()

                FrmDispensers.TxtValueOne.Text = TheDispenser.Value
                FrmDispensers.TxtAddressOne.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidOne.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsOne.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusOne.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseOne.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitOne.Checked = True

                Else
                    FrmDispensers.ChkInhibitOne.Checked = False

                End If

            Case 2

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueTwo.Show()
                FrmDispensers.TxtAddressTwo.Show()
                FrmDispensers.TxtCoinsPaidTwo.Show()
                FrmDispensers.TxtContentsTwo.Show()
                FrmDispensers.TxtStatusTwo.Show()
                FrmDispensers.LblDispenseTwo.Show()
                FrmDispensers.ChkInhibitTwo.Show()

                FrmDispensers.TxtValueTwo.Text = TheDispenser.Value
                FrmDispensers.TxtAddressTwo.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidTwo.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsTwo.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusTwo.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseTwo.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitTwo.Checked = True

                Else
                    FrmDispensers.ChkInhibitTwo.Checked = False

                End If

            Case 3

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueThree.Show()
                FrmDispensers.TxtAddressThree.Show()
                FrmDispensers.TxtCoinsPaidThree.Show()
                FrmDispensers.TxtContentsThree.Show()
                FrmDispensers.TxtStatusThree.Show()
                FrmDispensers.LblDispenseThree.Show()
                FrmDispensers.ChkInhibitThree.Show()

                FrmDispensers.TxtValueThree.Text = TheDispenser.Value
                FrmDispensers.TxtAddressThree.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidThree.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsThree.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusThree.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseThree.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitThree.Checked = True

                Else
                    FrmDispensers.ChkInhibitThree.Checked = False

                End If

            Case 4

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueFour.Show()
                FrmDispensers.TxtAddressFour.Show()
                FrmDispensers.TxtCoinsPaidFour.Show()
                FrmDispensers.TxtContentsFour.Show()
                FrmDispensers.TxtStatusFour.Show()
                FrmDispensers.LblDispenseFour.Show()
                FrmDispensers.ChkInhibitFour.Show()

                FrmDispensers.TxtValueFour.Text = TheDispenser.Value
                FrmDispensers.TxtAddressFour.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidFour.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsFour.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusFour.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseFour.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitFour.Checked = True

                Else
                    FrmDispensers.ChkInhibitFour.Checked = False

                End If

            Case 5

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueFive.Show()
                FrmDispensers.TxtAddressFive.Show()
                FrmDispensers.TxtCoinsPaidFive.Show()
                FrmDispensers.TxtContentsFive.Show()
                FrmDispensers.TxtStatusFive.Show()
                FrmDispensers.LblDispenseFive.Show()
                FrmDispensers.ChkInhibitFive.Show()

                FrmDispensers.TxtValueFive.Text = TheDispenser.Value
                FrmDispensers.TxtAddressFive.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidFive.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsFive.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusFive.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseFive.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitFive.Checked = True

                Else
                    FrmDispensers.ChkInhibitFive.Checked = False

                End If

            Case 6

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueSix.Show()
                FrmDispensers.TxtAddressSix.Show()
                FrmDispensers.TxtCoinsPaidSix.Show()
                FrmDispensers.TxtContentsSix.Show()
                FrmDispensers.TxtStatusSix.Show()
                FrmDispensers.LblDispenseSix.Show()
                FrmDispensers.ChkInhibitSix.Show()

                FrmDispensers.TxtValueSix.Text = TheDispenser.Value
                FrmDispensers.TxtAddressSix.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidSix.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsSix.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusSix.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseSix.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitSix.Checked = True

                Else
                    FrmDispensers.ChkInhibitSix.Checked = False

                End If

            Case 7

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueSeven.Show()
                FrmDispensers.TxtAddressSeven.Show()
                FrmDispensers.TxtCoinsPaidSeven.Show()
                FrmDispensers.TxtContentsSeven.Show()
                FrmDispensers.TxtStatusSeven.Show()
                FrmDispensers.LblDispenseSeven.Show()
                FrmDispensers.ChkInhibitSeven.Show()

                FrmDispensers.TxtValueSeven.Text = TheDispenser.Value
                FrmDispensers.TxtAddressSeven.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidSeven.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsSeven.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusSeven.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseSeven.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitSeven.Checked = True

                Else
                    FrmDispensers.ChkInhibitSeven.Checked = False

                End If

            Case 8

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueEight.Show()
                FrmDispensers.TxtAddressEight.Show()
                FrmDispensers.TxtCoinsPaidEight.Show()
                FrmDispensers.TxtContentsEight.Show()
                FrmDispensers.TxtStatusEight.Show()
                FrmDispensers.LblDispenseEight.Show()
                FrmDispensers.ChkInhibitEight.Show()

                FrmDispensers.TxtValueEight.Text = TheDispenser.Value
                FrmDispensers.TxtAddressEight.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidEight.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsEight.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusEight.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseEight.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitEight.Checked = True

                Else
                    FrmDispensers.ChkInhibitEight.Checked = False

                End If

            Case 9

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueNine.Show()
                FrmDispensers.TxtAddressNine.Show()
                FrmDispensers.TxtCoinsPaidNine.Show()
                FrmDispensers.TxtContentsNine.Show()
                FrmDispensers.TxtStatusNine.Show()
                FrmDispensers.LblDispenseNine.Show()
                FrmDispensers.ChkInhibitNine.Show()

                FrmDispensers.TxtValueNine.Text = TheDispenser.Value
                FrmDispensers.TxtAddressNine.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidNine.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsNine.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusNine.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseNine.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitNine.Checked = True

                Else
                    FrmDispensers.ChkInhibitNine.Checked = False

                End If

            Case 10

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueTen.Show()
                FrmDispensers.TxtAddressTen.Show()
                FrmDispensers.TxtCoinsPaidTen.Show()
                FrmDispensers.TxtContentsTen.Show()
                FrmDispensers.TxtStatusTen.Show()
                FrmDispensers.LblDispenseTen.Show()
                FrmDispensers.ChkInhibitTen.Show()

                FrmDispensers.TxtValueTen.Text = TheDispenser.Value
                FrmDispensers.TxtAddressTen.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidTen.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsTen.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusTen.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseTen.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitTen.Checked = True

                Else
                    FrmDispensers.ChkInhibitTen.Checked = False

                End If

            Case 11

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueEleven.Show()
                FrmDispensers.TxtAddressEleven.Show()
                FrmDispensers.TxtCoinsPaidEleven.Show()
                FrmDispensers.TxtContentsEleven.Show()
                FrmDispensers.TxtStatusEleven.Show()
                FrmDispensers.LblDispenseEleven.Show()
                FrmDispensers.ChkInhibitEleven.Show()

                FrmDispensers.TxtValueEleven.Text = TheDispenser.Value
                FrmDispensers.TxtAddressEleven.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidEleven.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsEleven.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusEleven.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseEleven.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitEleven.Checked = True

                Else
                    FrmDispensers.ChkInhibitEleven.Checked = False

                End If


            Case 12

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueTwelve.Show()
                FrmDispensers.TxtAddressTwelve.Show()
                FrmDispensers.TxtCoinsPaidTwelve.Show()
                FrmDispensers.TxtContentsTwelve.Show()
                FrmDispensers.TxtStatusTwelve.Show()
                FrmDispensers.LblDispenseTwelve.Show()
                FrmDispensers.ChkInhibitTwelve.Show()

                FrmDispensers.TxtValueTwelve.Text = TheDispenser.Value
                FrmDispensers.TxtAddressTwelve.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidTwelve.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsTwelve.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusTwelve.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseTwelve.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitTwelve.Checked = True

                Else
                    FrmDispensers.ChkInhibitTwelve.Checked = False

                End If

            Case 13

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueThirteen.Show()
                FrmDispensers.TxtAddressThirteen.Show()
                FrmDispensers.TxtCoinsPaidThirteen.Show()
                FrmDispensers.TxtContentsThirteen.Show()
                FrmDispensers.TxtStatusThirteen.Show()
                FrmDispensers.LblDispenseThirteen.Show()
                FrmDispensers.ChkInhibitThirteen.Show()

                FrmDispensers.TxtValueThirteen.Text = TheDispenser.Value
                FrmDispensers.TxtAddressThirteen.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidThirteen.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsThirteen.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusThirteen.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseThirteen.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitThirteen.Checked = True

                Else
                    FrmDispensers.ChkInhibitThirteen.Checked = False

                End If

            Case 14

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueFourteen.Show()
                FrmDispensers.TxtAddressFourteen.Show()
                FrmDispensers.TxtCoinsPaidFourteen.Show()
                FrmDispensers.TxtContentsFourteen.Show()
                FrmDispensers.TxtStatusFourteen.Show()
                FrmDispensers.LblDispenseFourteen.Show()
                FrmDispensers.ChkInhibitFourteen.Show()

                FrmDispensers.TxtValueFourteen.Text = TheDispenser.Value
                FrmDispensers.TxtAddressFourteen.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidFourteen.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsFourteen.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusFourteen.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseFourteen.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitFourteen.Checked = True

                Else
                    FrmDispensers.ChkInhibitFourteen.Checked = False

                End If

            Case 15

                FrmDispensers.LblNoDispensers.Hide()
                FrmDispensers.TxtValueFifteen.Show()
                FrmDispensers.TxtAddressFifteen.Show()
                FrmDispensers.TxtCoinsPaidFifteen.Show()
                FrmDispensers.TxtContentsFifteen.Show()
                FrmDispensers.TxtStatusFifteen.Show()
                FrmDispensers.LblDispenseFifteen.Show()
                FrmDispensers.ChkInhibitFifteen.Show()

                FrmDispensers.TxtValueFifteen.Text = TheDispenser.Value
                FrmDispensers.TxtAddressFifteen.Text = TheDispenser.UnitAddress
                FrmDispensers.TxtCoinsPaidFifteen.Text = TheDispenser.Count
                DispenserContents(TheDispenser.CoinCountStatus, Tempstring)
                FrmDispensers.TxtContentsFifteen.Text = Tempstring
                PayingStatus(TheDispenser.Status, StatusString)
                FrmDispensers.TxtStatusFifteen.Text = StatusString
                DecodeDispenserIdent(TheDispenser.Unit, Tempstring)
                FrmDispensers.LblDispenseFifteen.Text = Tempstring

                If TheDispenser.Inhibit <> 0 Then
                    FrmDispensers.ChkInhibitFifteen.Checked = True

                Else
                    FrmDispensers.ChkInhibitFifteen.Checked = False

                End If

        End Select

    End Sub


    Public Sub DispenserContents(ByVal Contents As Integer, ByRef DecodedContentsString As String)
        'This is a sub-routine that will establish the contents of the dispensers from
        'Paylink and translates this.
        Select Case Contents

            Case DISPENSER_COIN_NONE
                DecodedContentsString = "None"

            Case DISPENSER_COIN_LOW
                DecodedContentsString = "Low"

            Case DISPENSER_COIN_MID
                DecodedContentsString = "Mid"

            Case DISPENSER_COIN_HIGH
                DecodedContentsString = "High"

            Case DISPENSER_ACCURATE
                DecodedContentsString = "Accurate??"

            Case DISPENSER_ACCURATE_FULL
                DecodedContentsString = "Full"

            Case DISPENSER_REASSIGN_VALUE
                DecodedContentsString = "Value Updated"

            Case DISPENSER_VALUE_REASSIGNED
                DecodedContentsString = "Value assigned"


        End Select




    End Sub


    Public Sub DispenserStatus(ByVal DispStatus As Integer, ByRef DecodedStatusString As String)

        Select Case DispStatus

            Case PAY_ONGOING
                DecodedStatusString = "Paying"

            Case PAY_FINISHED
                DecodedStatusString = "Idle OK"

            Case PAY_EMPTY
                DecodedStatusString = "Hopper Empty"

            Case PAY_JAMMED
                DecodedStatusString = "Dispenser Jammmed"

            Case PAY_US
                DecodedStatusString = "Dispenser non functonal"

            Case PAY_FRAUD
                DecodedStatusString = "Fraud attempt"

            Case PAY_FAILED_BLOCKED
                DecodedStatusString = "Dispenser Blocked"

            Case PAY_NO_HOPPER
                DecodedStatusString = "No dispenser matches the amount to be paid"

            Case PAY_INHIBITED
                DecodedStatusString = "Inhibited"

            Case PAY_SECURITY_FAIL
                DecodedStatusString = "Security Fail"




        End Select




    End Sub



    Public Sub DecodeDispenserIdent(ByVal DispenserIdent As Integer, ByRef DecodedIdent As String)


        Select Case DispenserIdent
            'Money Controls Devices
            Case DP_MCL_SCH2
                DecodedIdent = "MCL ccTalk SCH2"

            Case DP_MCL_SUH1
                DecodedIdent = "MCL ccTalk SUH1"

            Case DP_MCL_SCH3
                DecodedIdent = "MCL ccTalk SCH3"

                'Azcoin Devices
            Case DP_AZK_HOPPER
                DecodedIdent = "Azcoin ccTalk Hopper"

                'Asahi Seiko devices
            Case DP_AS_WH2
                DecodedIdent = "Asahi Seiko ccTalk WH2"

        End Select



    End Sub

    Public Sub PayingStatus(ByVal StatusValue As Integer, ByRef DispenserStatus As String)


        Select Case StatusValue

            Case PAY_ONGOING
                DispenserStatus = "Paying"

            Case PAY_FINISHED
                DispenserStatus = "Idle OK"

            Case PAY_EMPTY
                DispenserStatus = "Empty"

            Case PAY_JAMMED
                DispenserStatus = "Jammed"

            Case PAY_US
                DispenserStatus = "Faulty"

            Case PAY_FRAUD
                DispenserStatus = "Fraud"

            Case PAY_FAILED_BLOCKED
                DispenserStatus = "Blocked"

            Case PAY_NO_HOPPER
                DispenserStatus = "No dispenser matches amount"

            Case PAY_INHIBITED
                DispenserStatus = "Inhibited"

            Case PAY_SECURITY_FAIL
                DispenserStatus = "Security fail"


        End Select




    End Sub


End Module
