Imports AESImhei

Module AcceptorsModule
    '************************************************************************************************************
    'This module will interrogate paylink to determine the differing aspects of the acceptors connected
    'to paylink.
    'It will also convert the status and name to string text.
    '************************************************************************************************************
    Public AcceptorType As String
    Public AcceptorName(16) As String
    Public AcceptorUnitAddress(16) As Integer
    Public NoOfCoins(16) As Integer
    Public EventCount(16) As Integer
    Public AcceptorCurrency(16) As String
    Public DefaultAcceptorPath(16) As Integer
    Public AcceptorInterface(16) As Integer
    Public StatusOfAcceptor(16) As String
    Public Coin(256) As AcceptorCoin
    Public CoinValue(16, 16) As Integer
    Public CoinCount(16, 16) As Integer
    Public CoinRouted(16, 16) As Integer
    Public CoinPathCount(16, 16) As Integer
    Public CoinSwitchLevel(16, 16) As Integer
    Public InhibitCoin(16, 16) As Integer
    Public CoinDefault(16, 16) As Byte
    Public CoinEscrow(16, 16) As Byte

    Public K As Integer

    Public Sub Acceptor(ByVal AcceptorNumber As Integer, ByRef TheAcceptor As AESImhei.AcceptorBlock)
        '************************************************************************************************************
        'This is a sub-routine that interrogates Paylink and maintains all the information for
        'a possible 16 acceptors in arrays that can be manipluated/displayed later.
        'This will happen when the acceptors form loads.
        'It is passed the acceptornumber as an integer and returns different values for an
        'AcceptorBlock.
        '************************************************************************************************************
        Dim Status As String

        DecodeAcceptorIdent(TheAcceptor.Unit, AcceptorType)
        AcceptorName(AcceptorNumber) = AcceptorType
        AcceptorUnitAddress(AcceptorNumber) = TheAcceptor.UnitAddress
        NoOfCoins(AcceptorNumber) = TheAcceptor.NoOfCoins
        AcceptorCurrency(AcceptorNumber) = TheAcceptor.Currency
        DefaultAcceptorPath(AcceptorNumber) = TheAcceptor.DefaultPath
        AcceptorInterface(AcceptorNumber) = TheAcceptor.InterfaceNumber
        AcceptorStatus(TheAcceptor.Status, Status)
        StatusOfAcceptor(AcceptorNumber) = Status
        Coin = TheAcceptor.Coin

        '************************************************************************************************************
        'For each of the possible 16 acceptors there are a possible 16 coins, and so I again 
        'interrogate paylink to obtain these for each connected acceptor and store
        'them in 2-dimensional arrays.
        '************************************************************************************************************

        For K = 0 To 15
            CoinValue(AcceptorNumber, K) = Coin(K).Value
            CoinCount(AcceptorNumber, K) = Coin(K).Count
            CoinRouted(AcceptorNumber, K) = Coin(K).Path
            CoinPathCount(AcceptorNumber, K) = Coin(K).PathCount
            CoinSwitchLevel(AcceptorNumber, K) = Coin(K).PathSwitchLevel
            CoinDefault(AcceptorNumber, K) = Coin(K).DefaultPath
            CoinEscrow(AcceptorNumber, K) = Coin(K).HeldInEscrow
            InhibitCoin(AcceptorNumber, K) = Coin(K).Inhibit


        Next K


    End Sub
    Public Sub DecodeAcceptorIdent(ByVal AcceptorIdent As Integer, ByRef DecodedIdent As String)
        '************************************************************************************************************
        'This subroutine will change the coded name of the acceptor to text to be displayed ont he form.
        'It is passed the acceptor coded name and returns the string name.
        '************************************************************************************************************
        Select Case AcceptorIdent

            'Money Controls Devices
            Case DP_MCL_SR3
                DecodedIdent = "MCL ccTalk SR3"

            Case DP_MCL_SR5
                DecodedIdent = "MCL ccTalk SR5"

            Case DP_MCL_CONDOR
                DecodedIdent = "MCL ccTalk Condor"

            Case DP_MCL_LUMINA
                DecodedIdent = "MCL ccTalk Lumina"

            Case DP_MCL_7200
                DecodedIdent = "MCL ccTalk 7200"

            Case DP_MCL_ARDAC_ELITE
                DecodedIdent = "MCL ccTalk Ardac Elite"

            Case DP_MCL_WACS
                DecodedIdent = "MCL Ardac WACS"

            Case DP_MCL_ARDAC
                DecodedIdent = "MCL JCM Ardac"

                'Coinco Devices
            Case DP_COINCO_MDB
                DecodedIdent = "Coinco MDB"

            Case DP_COINCO_VORTEX
                DecodedIdent = "Coinco MDB Vortex"

            Case DP_COINCO_GLOBAL
                DecodedIdent = "Coinco MDB Global"

            Case DP_COINCO_MDB_BILL
                DecodedIdent = "Coinco MDB Bill"

            Case DP_COINCO_BILLPRO
                DecodedIdent = "Coinco MDB BillPro"

                'Azcoin Devices
            Case DP_AZK_MDB
                DecodedIdent = "Azcoin MDB"

            Case DP_AZK_A6
                DecodedIdent = "Azcoin ccTalk A6"

                'Mars Electronic Devices
            Case DP_MARS_CASHFLOW_126
                DecodedIdent = "Mars HII 126"

            Case DP_MARS_CASHFLOW_9500
                DecodedIdent = "Mars HII 9500"

            Case DP_MARS_MDB
                DecodedIdent = "Mars MDB"

            Case DP_MARS_CASHFLOW_690
                DecodedIdent = "Mars MDB 690"

                'Innovative Technology Devices
            Case DP_INNOV_NV4
                DecodedIdent = "Innovative ccTalk NV4"

            Case DP_INNOV_NV7
                DecodedIdent = "Innovative ccTalk NV7"

            Case DP_INNOV_NV8
                DecodedIdent = "Innovative ccTalk NV8"

            Case DP_INNOV_NV9
                DecodedIdent = "Innovative ccTalk NV9"

            Case DP_INNOV_NV10
                DecodedIdent = "Innovative ccTalk NV10"

                'NRI devices
            Case DP_NRI_G40
                DecodedIdent = "NRI ccTalk G40"

                'ICT Devices
            Case DP_ICT_U85
                DecodedIdent = "ICT ccTalk U85"

                'Astrosystems Devices
            Case DP_AST_GBA
                DecodedIdent = "Astrosystems ccTalk GBA"

                'JCM Devices
            Case DP_JCM_CC_EBA
                DecodedIdent = "JCM ccTalk EBA"

            Case DP_JCM_CC_WBA
                DecodedIdent = "JCM ccTalk WBA"

            Case DP_JCM_NOTE
                DecodedIdent = "JCM Note"

                'GPT Devices
            Case DP_GPT_NOTE
                DecodedIdent = "GPT Note"





            Case Else
                DecodedIdent = "Unknown Acceptor"





        End Select

    End Sub
    Public Sub AcceptorStatus(ByVal AcceptorConstantsDecoded As Integer, ByRef Status As String)
        '************************************************************************************************************
        'This is a subrountine that will establish the status of the acceptors.
        'It is passed the coded status of the acceptor and returns the string status of the acceptor.
        '************************************************************************************************************
        If AcceptorConstantsDecoded = 0 Then
            Status = "Idle OK"

        ElseIf (AcceptorConstantsDecoded And ACCEPTOR_DEAD) <> 0 Then
            Status = "No Response"

        ElseIf (AcceptorConstantsDecoded And (ACCEPTOR_DISABLED Or ACCEPTOR_INHIBIT)) <> 0 Then
            Status = "Disabled"

        ElseIf (AcceptorConstantsDecoded And ACCEPTOR_FRAUD) <> 0 Then
            Status = "Fraud"

        ElseIf (AcceptorConstantsDecoded And ACCEPTOR_BUSY) <> 0 Then
            Status = "Busy"

        ElseIf (AcceptorConstantsDecoded And ACCEPTOR_FAULT) <> 0 Then
            Status = "Error"

        End If

    End Sub

    Public Function BoolToInt(ByRef State As Boolean) As Integer
        '************************************************************************************************************
        'This is a function that converts a boolean to an integer.
        '************************************************************************************************************

        If State = True Then
            BoolToInt = 1
        Else
            BoolToInt = 0
        End If
    End Function




End Module
