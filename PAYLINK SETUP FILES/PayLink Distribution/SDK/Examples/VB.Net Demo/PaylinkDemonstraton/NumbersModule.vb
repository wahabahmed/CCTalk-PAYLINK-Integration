Module NumbersModule

    Public Sub MainAmount(ByVal Number As Integer, ByRef NumberValue As String)
        '``````````````````````````````````````````````````````````````````````````````````
        'This function displays the basic numbers in text form if it has been called
        'Zero, however, will be dealt with seperately.


        Select Case Number

            Case 0
                NumberValue = ""

            Case 1
                NumberValue = " One"

            Case 2
                NumberValue = " Two"

            Case 3
                NumberValue = " Three"

            Case 4
                NumberValue = " Four"

            Case 5
                NumberValue = " Five"

            Case 6
                NumberValue = " Six"

            Case 7
                NumberValue = " Seven"

            Case 8
                NumberValue = " Eight"

            Case 9
                NumberValue = " Nine"

        End Select
    End Sub

    Public Sub TensAmount(ByVal TensNumber As Integer, ByRef TensNumberValue As String)
        '``````````````````````````````````````````````````````````````````````````````````
        'This section displays the appropriate text value for a number in the tens position of the group of three
        'unless it returns a zero or one.
        'These shall be dealt with seperately.

        Select Case TensNumber

            Case 0
                TensNumberValue = ""

            Case 1
                TensNumberValue = ""

            Case 2
                TensNumberValue = " Twenty"

            Case 3
                TensNumberValue = " Thirty"

            Case 4
                TensNumberValue = " Fourty"

            Case 5
                TensNumberValue = " Fifty"

            Case 6
                TensNumberValue = " Sixty"

            Case 7
                TensNumberValue = " Seventy"

            Case 8
                TensNumberValue = " Eighty"

            Case 9
                TensNumberValue = " Ninety"


        End Select


    End Sub

    Public Sub TeenPart(ByVal TeenNumber As Integer, ByRef TeenValue As String)
        '``````````````````````````````````````````````````````````````````````````````````
        'This function deals with the tens position of the three digit number returning a one
        'It then uses the units position to determine which case to use

        Select Case TeenNumber

            Case 0
                TeenValue = " Ten"

            Case 1
                TeenValue = " Eleven"

            Case 2
                TeenValue = " Twelve"

            Case 3
                TeenValue = " Thirteen"

            Case 4
                TeenValue = " Fourteen"

            Case 5
                TeenValue = " Fifteen"

            Case 6
                TeenValue = " Sixteen"

            Case 7
                TeenValue = " Seventeen"

            Case 8
                TeenValue = " Eighteen"

            Case 9
                TeenValue = " Nineteen"

        End Select
    End Sub

    Public Sub Conjuctions(ByVal GroupNumber As Integer, ByRef Joiner As String)
        '``````````````````````````````````````````````````````````````````````````````````
        'This function when called determines which of these joiner words to use
        'It is dependent on the number of groups of three WholeIntegers contains

        Select Case GroupNumber
            Case 0
                Joiner = " and"

            Case 1
                Joiner = " Thousand,"

            Case 2
                Joiner = " Million,"

            Case 3
                Joiner = " Billion,"

            Case 4
                Joiner = " Trillion,"

        End Select

    End Sub

    Public Sub Currency(ByVal WhichCurrency As Integer, ByRef CurrencyType As String, ByRef CurrencyDecimal As String, ByRef CurrencySingular As String, ByRef DecimalSingular As String)
        '``````````````````````````````````````````````````````````````````````````````````
        'This section deals with which currency to use
        'There is a default currency to use, the latter of these cases.
        'These are dependent on whether or not there has been onbe of the accepted currency symbols (£, $, €) typed into the text box

        Select Case WhichCurrency

            Case 0
                CurrencyType = " Pounds"
                CurrencyDecimal = " Pence"
                CurrencySingular = " Pound"
                DecimalSingular = " Pence"

            Case 1
                CurrencyType = " Dollars"
                CurrencyDecimal = " Cents"
                CurrencySingular = " Dollar"
                DecimalSingular = " Cent"

            Case 2
                CurrencyType = " Euros"
                CurrencyDecimal = " Cents"
                CurrencySingular = " Euro"
                DecimalSingular = " Cent"


            Case 3
                'This is the general default currency if none has been specified.
                CurrencyType = " Units"
                CurrencyDecimal = " Units"
                CurrencySingular = " Unit"
                DecimalSingular = " Unit"


        End Select

    End Sub

    Public Sub GroupsThree(ByVal Group As String, ByRef GroupValue As String)
        '``````````````````````````````````````````````````````````````````````````````````
        'This is the function that displays the text value of the numerical value of each group of three numbers.
        'It looks at the digits in the hundreds, tens and units position and calls the functions appropriately.

        Dim HundredsNumberValue As String
        Dim TensNumberValue As String
        Dim UnitsNumberValue As String
        Dim Hundreds As String
        Dim Tens As String
        Dim Units As String
        Dim TeenValue As String
        HundredsNumberValue = "" 'Suppresses compiler warnings
        TensNumberValue = ""
        UnitsNumberValue = ""
        TeenValue = ""




        Hundreds = NumberConvert.WholeIntegers.Substring(0, 1)
        MainAmount(Hundreds, HundredsNumberValue)
        Tens = NumberConvert.WholeIntegers.Substring(1, 1)
        TensAmount(Tens, TensNumberValue)
        Units = NumberConvert.WholeIntegers.Substring(2, 1)
        MainAmount(Units, UnitsNumberValue)
        TeenPart(Units, TeenValue)

        If Hundreds = 0 And Tens = 0 And Units = 0 Then
            GroupValue = GroupValue + ""

        ElseIf Hundreds = 0 And Tens = 0 Then
            GroupValue = GroupValue + UnitsNumberValue

        ElseIf Hundreds = 0 And Tens = 1 Then
            GroupValue = GroupValue + TeenValue

        ElseIf Hundreds = 0 And Tens > 1 Then
            GroupValue = GroupValue + TensNumberValue + UnitsNumberValue

        ElseIf Tens = 1 Then
            GroupValue = GroupValue + HundredsNumberValue + " Hundred and" + TeenValue

        ElseIf Tens > 1 Then
            GroupValue = GroupValue + HundredsNumberValue + " Hundred and" + TensNumberValue + UnitsNumberValue

        ElseIf Tens = 0 And Units = 0 Then
            GroupValue = GroupValue + HundredsNumberValue + " Hundred"

        ElseIf Tens = 0 Then
            GroupValue = GroupValue + HundredsNumberValue + " Hundred and" + UnitsNumberValue

        End If ' if tens = 1


    End Sub

    Public Sub Decimals(ByVal DecimalNumber As String, ByRef DecimalValue As String)
        '``````````````````````````````````````````````````````````````````````````````````
        'This is the function that displays the value of the two digits after the deciamle place
        'It uses the same theory as the function above, however there are only
        'tens and units positions in this case.
        'It again calls the functions prior to this regarding displaying text as appropriate.
        Dim I As Integer
        Dim DecimalHundreds As String
        Dim DecimalTens As String
        Dim DecimalUnits As String
        Dim DecimalHundredsNumberValue As String
        Dim DecimalTensNumberValue As String
        Dim DecimalUnitsNumberValue As String
        Dim DecimalTeenValue As String


        DecimalHundredsNumberValue = "" 'Suppresses compiler warnings
        DecimalTensNumberValue = ""
        DecimalUnitsNumberValue = ""
        DecimalHundreds = ""
        DecimalTens = ""
        DecimalUnits = ""
        DecimalTeenValue = ""

        I = 0
        I = Len(DecimalNumber)


        If I = 2 And NumberConvert.NewDecimal.Substring(0, 1) = 0 Then
            DecimalTens = NumberConvert.NewDecimal.Substring(1, 1)

            TensAmount(DecimalTens, DecimalTensNumberValue)

            If DecimalTens = 1 Then
                DecimalValue = DecimalValue + " Ten"

            Else
                DecimalValue = DecimalValue + DecimalTensNumberValue

            End If

        Else

            DecimalHundreds = NumberConvert.NewDecimal.Substring(0, 1)
            MainAmount(DecimalHundreds, DecimalHundredsNumberValue)
            DecimalTens = NumberConvert.NewDecimal.Substring(1, 1)
            TensAmount(DecimalTens, DecimalTensNumberValue)
            DecimalUnits = NumberConvert.NewDecimal.Substring(2, 1)
            MainAmount(DecimalUnits, DecimalUnitsNumberValue)
            TeenPart(DecimalUnits, DecimalTeenValue)


            If DecimalHundreds = 0 And DecimalTens = 0 And DecimalUnits = 0 Then
                DecimalValue = DecimalValue + ""

            ElseIf DecimalHundreds = 0 And DecimalTens = 0 Then
                DecimalValue = DecimalValue + DecimalUnitsNumberValue

            ElseIf DecimalHundreds = 0 And DecimalTens = 1 Then
                DecimalValue = DecimalValue + DecimalTeenValue

            ElseIf DecimalHundreds = 0 And DecimalTens > 1 Then
                DecimalValue = DecimalValue + DecimalTensNumberValue + DecimalUnitsNumberValue

            ElseIf DecimalTens = 1 Then
                DecimalValue = DecimalValue + DecimalHundredsNumberValue + " Hundred and" + DecimalTeenValue

            ElseIf DecimalTens > 1 Then
                DecimalValue = DecimalValue + DecimalHundredsNumberValue + " Hundred and" + DecimalTensNumberValue + DecimalUnitsNumberValue

            ElseIf DecimalTens = 0 And DecimalUnits = 0 Then
                DecimalValue = DecimalValue + DecimalHundredsNumberValue + " Hundred"

            ElseIf DecimalTens = 0 Then
                DecimalValue = DecimalValue + DecimalHundredsNumberValue + " Hundred and" + DecimalUnitsNumberValue

            End If
        End If
    End Sub


    Public Sub CharacterValidity(ByVal Character As String, ByRef Valid As Boolean)
        '``````````````````````````````````````````````````````````````````````````````````
        'This is the function regarding the validity of the characters typed into the text box.
        'It is called when ever the text in the text box is changed.
        'It looks at the character that has changed, if it is one of the following (numbers, the currency symbols,
        ' commas,full stops, p or P) and returns True to a boolean variable if it is.
        'If it is any other character, then it returns a false.

        Select Case Character
            Case 0
                Valid = True
            Case 1
                Valid = True
            Case 2
                Valid = True
            Case 3
                Valid = True
            Case 4
                Valid = True
            Case 5
                Valid = True
            Case 6
                Valid = True
            Case 7
                Valid = True
            Case 8
                Valid = True
            Case 9
                Valid = True
            Case "£"
                Valid = True
            Case "$"
                Valid = True
            Case "€"
                Valid = True
            Case "."
                Valid = True
            Case ","
                Valid = True
            Case "p"
                Valid = True
            Case "P"
                Valid = True
            Case Else
                Valid = False



        End Select
    End Sub




End Module
