Module NumberConvert


    Public WholeDigits As Integer
    Public StrAmount As String
    Public NumericAmount As String
    Public Fields() As String
    Public WholeIntegers As String
    Public DecimalIntegers As String
    'Public OriginalAmount As String
    Public OriginalDecimal As String
    'Public Group As Integer
    Public NewDecimal As String
    'Public GoodString As String
    Public AlphaNumeric As String

    Public CurrencyToUse As Integer
    Public CurrencyType As String
    Public CurrencyDecimal As String
    Public CurrencySingular As String
    Public DecimalSingular As String

    Public Sub NumberConvert(ByVal StrAmount As String, ByRef AlphaNumeric As String)

        '************************************************************************************************************
        'This Section determines whether or not there has been a value added to the text box
        'If there has, then the rest of the code under this comand deals with that scenario
        'If there hasn't, the code immediately after this comment displays so


        CurrencyToUse = 3
        Currency(CurrencyToUse, CurrencyType, CurrencyDecimal, CurrencySingular, DecimalSingular)

        AlphaNumeric = ""

        If StrAmount = "0.00" Then
            AlphaNumeric = "No" + CurrencyType + " and No" + CurrencyDecimal

        ElseIf StrAmount = "00.00" Then
            AlphaNumeric = "No" + CurrencyType + " and No" + CurrencyDecimal

        ElseIf StrAmount = "0.0" Then
            AlphaNumeric = "No" + CurrencyType + " and No" + CurrencyDecimal

        ElseIf StrAmount = "0" Then
            AlphaNumeric = "No" + CurrencyType + " and No" + CurrencyDecimal

        ElseIf StrAmount = "" Then
            AlphaNumeric = "No" + CurrencyType + " and No" + CurrencyDecimal

        Else
            '``````````````````````````````````````````````````````````````````````````````````
            'This adds a zero to the front of the text and the variable if the user has typed in teh decimal
            'at the beginning of the string.

            If StrAmount.Substring(0, 1) = "." Then
                StrAmount = StrAmount.Insert(0, "0")
                'TxtAmount.Text = TxtAmount.Text.Insert(0, "0")
            End If


            '``````````````````````````````````````````````````````````````````````````````````
            'This IF statemnent checks to see if the user has added a "p" or "P" into the string and if so, removes it.

            If StrAmount.Contains("p") Then
                StrAmount = StrAmount.Replace("p", "")

            ElseIf StrAmount.Contains("P") Then
                StrAmount = StrAmount.Replace("P", "")
            End If

            '``````````````````````````````````````````````````````````````````````````````````
            'This If Statement determines whether or not there is a decimal place, 
            'if there is, then it goes on to split the string into characters before the decimal place, and characters after it.
            'It then assigns the characters before the decimal place to the variable WholeIntegers.
            If StrAmount.Contains(".") Then
                WholeDigits = StrAmount.LastIndexOf(".")
            Else
                StrAmount = StrAmount + ".00"
                WholeDigits = StrAmount.LastIndexOf(".")
            End If


            NumericAmount = StrAmount
            Fields = Split(NumericAmount, ".")
            WholeIntegers = Fields(0)
            Dim DecimalLen As Integer
            DecimalIntegers = Fields(1)

            '``````````````````````````````````````````````````````````````````````````````````
            'If there is a decimal place, then the characters after it are assigned to the variable DecimalIntegers
            'and the length of this string is obtained.
            'The length is checked to reduce errors if the user types the decimal in a non-standard way
            'E.g. 10.1 as opposed to 10.10 
            'It also checks to see that the user has used only two decimal places, and alerts them if more are used.
            'It will only take the first two characters as the decimals.

            DecimalLen = Len(DecimalIntegers)
            If DecimalLen > 0 Then
                If DecimalIntegers < 10 And DecimalLen = 2 Then
                    OriginalDecimal = DecimalIntegers.Substring(0, 2)

                ElseIf DecimalIntegers < 10 And DecimalLen = 1 Then
                    OriginalDecimal = DecimalIntegers.Substring(0, 1)

                ElseIf DecimalIntegers > 9 Then

                    OriginalDecimal = DecimalIntegers.Substring(0, 2)

                    If Len(DecimalIntegers) > 2 Then
                        MessageBox.Show("Decimal value too high")
                        OriginalDecimal = DecimalIntegers.Substring(0, 2)

                    End If
                End If
            End If

            '``````````````````````````````````````````````````````````````````````````````````
            'This section will determine which currency to be used if it has been specified
            'in the text box. It also defaults to a specified currency if no currency symbol (£, $, €) has  been typed.
            'It also removes the symbol from the string for later manipulation

            'OriginalAmount = WholeIntegers

            If WholeIntegers.Contains(",") Then
                WholeIntegers = WholeIntegers.Replace(",", "")
            End If

            If WholeIntegers.Contains("£") Then
                WholeIntegers = WholeIntegers.Replace("£", "")
                CurrencyToUse = 0
            ElseIf WholeIntegers.Contains("$") Then
                WholeIntegers = WholeIntegers.Replace("$", "")
                CurrencyToUse = 1

            ElseIf WholeIntegers.Contains("€") Then
                WholeIntegers = WholeIntegers.Replace("€", "")
                CurrencyToUse = 2

            Else
                CurrencyToUse = 3
            End If

            Dim Digits As String
            Digits = ""
            Dim TempWholeIntegers As String
            Dim TempWholeIntegersLen As Integer
            Dim T As Integer

            TempWholeIntegers = WholeIntegers
            TempWholeIntegersLen = Len(TempWholeIntegers)

            Dim Checked As Boolean
            Dim W As Integer

            Do
                For T = 1 To TempWholeIntegersLen
                    Digits = TempWholeIntegers.Substring(T - 1, 1)

                    If Digits <> "0" Then
                        Checked = False
                        W = 1
                        T = TempWholeIntegersLen

                    ElseIf T = TempWholeIntegersLen Then
                        Checked = False
                        W = 0

                    ElseIf Digits = "0" Then

                        Checked = True
                    End If
                Next T
            Loop Until Checked = False


            If W = 0 Then
                WholeIntegers = "0"

            End If

            If WholeIntegers = "0" Then
                AlphaNumeric = "No"

            End If
            '``````````````````````````````````````````````````````````````````````````````````
            'This section will get the length of the string WholeIntegers. 
            'As there is a limit, if the length of the string exceeds 15 then an error
            'message is displayed and all the variables/text boxes are reset to 0
            Dim J As Integer
            J = Len(WholeIntegers)

            If J > 15 Then
                MessageBox.Show("Value too high")
                StrAmount = ""
                NumericAmount = 0
                WholeIntegers = 0
                DecimalIntegers = 0
                'OriginalAmount = 0
                OriginalDecimal = 0
                NewDecimal = 0
                AlphaNumeric = "No" + CurrencyType + " and "


            Else

                '``````````````````````````````````````````````````````````````````````````````````
                'This section uses integer arithmetic to check if the length of the string
                'is divisible by 3.
                'If not, then a 0 is added to the front of the string until it is

                Dim P As Integer
                P = J \ 3
                P = P * 3
                While P <> J
                    WholeIntegers = WholeIntegers.Insert(0, "0")
                    J = Len(WholeIntegers)
                    P = J \ 3
                    P = P * 3
                End While
            End If
            '``````````````````````````````````````````````````````````````````````````````````
            'This section divides WholeIntergers by 3, and allocating the result into the variable B
            'As the programs deals with num,bers in groups of three, the value of B will indicate how many groups there is and which "joiner" to use
            '(Joiners are the nouns thousand, million, etc or the conjuction and)
            'It takes each group of three and calls the function GroupsF#Three to decode the number
            'And provide the appropriate text
            Dim G, B As Integer
            Dim WholeIntegerSection As String
            Dim Joiner As String
            Joiner = "" 'Suppresses compiler warnings
            NewDecimal = ""

            Dim GroupValue As String
            GroupValue = ""


            G = Len(WholeIntegers)
            B = G / 3

            While B > 0
                WholeIntegerSection = WholeIntegers.Substring(0, 3)
                GroupsThree(WholeIntegerSection, GroupValue)
                WholeIntegers = WholeIntegers.Remove(0, 3)

                B = B - 1
                If B > 0 Then

                    If WholeIntegerSection <> 0 Then
                        Conjuctions(B, Joiner)
                        If B = 0 Then
                            Currency(CurrencyToUse, CurrencyType, CurrencyDecimal, CurrencySingular, DecimalSingular)
                            AlphaNumeric = AlphaNumeric + GroupValue + CurrencyType + Joiner

                        Else
                            AlphaNumeric = AlphaNumeric + GroupValue + Joiner
                        End If

                    ElseIf B = 0 Then
                        Conjuctions(B, Joiner)
                        Currency(CurrencyToUse, CurrencyType, CurrencyDecimal, CurrencySingular, DecimalSingular)

                        AlphaNumeric = AlphaNumeric + GroupValue + Joiner


                    End If

                ElseIf B = 0 Then

                    If WholeIntegerSection = "001" And G = 3 Then
                        Conjuctions(B, Joiner)
                        Currency(CurrencyToUse, CurrencyType, CurrencyDecimal, CurrencySingular, DecimalSingular)
                        AlphaNumeric = AlphaNumeric + GroupValue + CurrencySingular + Joiner


                    Else
                        Conjuctions(B, Joiner)
                        Currency(CurrencyToUse, CurrencyType, CurrencyDecimal, CurrencySingular, DecimalSingular)

                        AlphaNumeric = AlphaNumeric + GroupValue + CurrencyType + Joiner

                    End If
                End If
                GroupValue = ""
            End While
            '``````````````````````````````````````````````````````````````````````````````````
            'This section looks at the beginning of the text in TxtWordamount and if it starts with " a"
            '(I.E. no value before it) it removes that and replaces it with "No Pounds and"
            Dim StrLen As Integer
            StrLen = Len(StrAmount)


            If StrLen > 0 Then
                If AlphaNumeric.Substring(0, 2) = " a" Then
                    AlphaNumeric = AlphaNumeric.Replace(" and", "No" + CurrencyType + " and")
                End If
            End If


            '``````````````````````````````````````````````````````````````````````````````````
            'This section enables the decimal value to be displayed with the appropriate currency (if one has been typed in or the default one) by calling the function
            'Currency. 
            Dim DecimalValue As String
            DecimalValue = ""
            NewDecimal = OriginalDecimal
            Currency(CurrencyToUse, CurrencyType, CurrencyDecimal, CurrencySingular, DecimalSingular)
            NewDecimal = NewDecimal.Insert("0", 0)
            Decimals(NewDecimal, DecimalValue)


            If OriginalDecimal = 0 Then
                AlphaNumeric = AlphaNumeric + DecimalValue + " No" + CurrencyDecimal

            ElseIf OriginalDecimal = "01" Then



                AlphaNumeric = AlphaNumeric + DecimalValue + DecimalSingular

            Else

                AlphaNumeric = AlphaNumeric + DecimalValue + CurrencyDecimal

            End If

        End If

    End Sub

End Module
