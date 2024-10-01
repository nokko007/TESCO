Public Class FrmChkDigit
    Private Sub ChkDigit()
        Dim Ddigit(18) As Integer
        Dim MultiplyST(18) As Integer
        Dim Result1(18) As Integer
        Dim Result2(18) As Integer
        Dim Result3(18) As Integer
        Dim TotalResult3 As Integer
        Dim ChkDigit As Integer
        Dim CHKPASS As Boolean
        Dim i, t As Integer
        Dim lp As Integer


        If Len(TxtClubcardID.Text) <> 18 Then
            MsgBox("ตัวเลขไม่ครบ 18 หลัก")
            Exit Sub
        End If
        'For lp = 0 To ListXML.Items.Count - 1

        'check clubcard
        CHKPASS = False

        'Dim inp As String
        'inp = InputBox("cc no", "", "")
        'If inp = "" Then Exit Sub
        '''debug.Print("Input =" & inp)
        'Step1 - แยก Digit
        ''debug.Print("inp = " & ListXML.Items(lp).ToString)
        ''debug.Print("Split")
        For i = 1 To 18
            Ddigit(i) = Mid(TxtClubcardID.Text, i, 1)

            'debug.Print(i & "= " & Ddigit(i))
        Next i
        'Step 2 Multiply
        MultiplyST(1) = Ddigit(1) * 2
        MultiplyST(2) = Ddigit(2) * 1
        MultiplyST(3) = Ddigit(3) * 2
        MultiplyST(4) = Ddigit(4) * 1
        MultiplyST(5) = Ddigit(5) * 2
        MultiplyST(6) = Ddigit(6) * 1
        MultiplyST(7) = Ddigit(7) * 2
        MultiplyST(8) = Ddigit(8) * 1
        MultiplyST(9) = Ddigit(8) * 2
        MultiplyST(10) = Ddigit(10) * 1
        MultiplyST(11) = Ddigit(11) * 2
        MultiplyST(12) = Ddigit(12) * 1
        MultiplyST(13) = Ddigit(13) * 2
        MultiplyST(14) = Ddigit(14) * 1
        MultiplyST(15) = Ddigit(15) * 2
        MultiplyST(16) = Ddigit(16) * 1
        MultiplyST(17) = Ddigit(17) * 2

        'debug.Print("MULTI")
        For i = 1 To 18
            'debug.Print(MultiplyST(i))
        Next i



        'Step 3 Trunc หารปัดเศษทิ้งเสมอ
        'debug.Print("Result1")
        For t = 1 To 18
            Result1(t) = MultiplyST(t) \ 10
            'debug.Print(Result1(t))
        Next t



        'Step 4 
        'debug.Print("Result2")
        For t = 1 To 18
            Result2(t) = ((MultiplyST(t) / 10) - Result1(t)) * 10
            'debug.Print(Result2(t))
        Next t



        'Step 5 result 1 + result 2

        'debug.Print("Result3")
        For t = 1 To 18
            Result3(t) = Result1(t) + Result2(t)
            'debug.Print(Result3(t))
        Next t



        'Step 6 sum Result 3  
        'debug.Print("TotalResult3")
        TotalResult3 = 0
        For t = 1 To 18
            TotalResult3 = TotalResult3 + Result3(t)
        Next t
        'debug.Print(TotalResult3)

        ChkDigit = 10 - (((TotalResult3) / 10) - (TotalResult3 \ 10)) * 10

        If ChkDigit = 10 Then ChkDigit = 0
        'debug.Print(Ddigit(18))
        'debug.Print(ChkDigit)
        If Ddigit(18) = ChkDigit Then
            MsgBox("OK")
            CHKPASS = True
        Else
            MsgBox("INVALID")
            CHKPASS = False
            'LstChkDigitError.Items.Add(ListXML.Items(lp).ToString)
            'ListXML1.Items.Add(ListXML.Items(lp).ToString)
            'lp = lp + 1
            'debug.Print(ListXML.Items.Count - 1)
            'GoTo nextlp
        End If











        'nextlp:

        '        Next lp



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call ChkDigit()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub
End Class