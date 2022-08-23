Public Class Form1

    Dim num1, num2, result As Double
    Dim operatorSign As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each button As Control In Controls  'targets buttons in form
            If TypeOf button Is Button Then     'if button is true button
                If Not (button.Text.Equals("CE") Or     'if button text is not CE
                        button.Text.Equals("DEL") Or    'if button text is not DEL
                        button.Text.Equals("+/-") Or    'if button text is not +/-
                        button.Text.Equals("C")) Then   'if button text is not C
                    AddHandler button.Click, AddressOf button_Click     'add event handler to button
                End If
            End If
        Next
    End Sub

    Private Sub button_Click(sender As Object, e As EventArgs)
        Dim button As Button = sender

        If isOperator(button) Then  'if an operator
            If Not displayTextBox.Text.Equals("") Then   'if display is not empty
                If button.Text.Equals("=") Then     'if button is 'equal to'
                    num2 = Double.Parse(displayTextBox.Text)    'let num2 = display text
                    result = calculate(operatorSign, num1, num2)    'let result = calculate(x,y,z)
                    displayTextBox.Text = Convert.ToString(result)  'display result
                Else    'if button is not 'equal to'
                    operatorSign = button.Text  'get operator sign
                    num1 = Double.Parse(displayTextBox.Text)    'let num1 = display text
                    displayTextBox.Clear()  'clear display
                End If
            End If
        Else    'if a number
            displayTextBox.Text += button.Text  'display button text
        End If
    End Sub

    'function to calculate result
    Function calculate(operatorSign As String, num1 As Double, num2 As Double) As Double
        Dim result As Double = 0    'initialise result

        Select Case operatorSign
            Case "+"
                result = num1 + num2
            Case "-"
                result = num1 - num2
            Case "x"
                result = num1 * num2
            Case "/"
                If num2 <> 0 Then   'if and if only num2 <> 0
                    result = num1 / num2
                End If
        End Select

        Return result   'returns result value
    End Function

    'function to check if button is an operator
    Function isOperator(button As Button) As Boolean
        If (button.Text.Equals("+") Or      'if button text is '+'
            button.Text.Equals("-") Or      'if button text is '-'
            button.Text.Equals("x") Or      'if button text is 'x'
            button.Text.Equals("/") Or      'if button text is '/'
            button.Text.Equals("=")) Then   'if button text is '='
            Return True     'returns true
        Else
            Return False    'else return false
        End If
    End Function

    'function to reset variables
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        displayTextBox.Clear()
        num1 = 0
        num2 = 0
    End Sub

    'function to make number negative or positive
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim value As Double = Double.Parse(displayTextBox.Text)    'declaring and initializing value

        If Not displayTextBox.Text.Contains("-") Then   'if number is positive
            displayTextBox.Text = Convert.ToString(value + (value * (-2)))    'convert to negative
        Else    'if number is negative
            displayTextBox.Text = Convert.ToString((value) + ((value) * (-2)))    'convert to positive
        End If
    End Sub

    'function for backspace
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim value As String = displayTextBox.Text   'declaring and initializing value
        Dim last As String = value(value.Length - 1)    'get last character

        displayTextBox.Text = value.Replace(last, "")   'remove from display
    End Sub
End Class
