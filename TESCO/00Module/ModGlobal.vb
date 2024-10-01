Option Strict Off
Option Explicit On
Module modGlobal

    Public Const MYDNS As String = "Server=192.168.8.2 ;User Id=root; Password=ImitAdmin ; Database=TESCO_W1; port=3306; Allow Zero Datetime=True"
    Public Const MYDNS2 As String = "Server=192.168.8.2 ;User Id=root; Password=ImitAdmin ; Database=T_TESCO_W1; port=3306; Allow Zero Datetime=True"



    Public Const ServerName As String = "192.168.8.2"
    Public Const UserIDName As String = "sa"
    Public Const PasswordName As String = "Imit11779933"
    Public Const DataBaseName = "TESCO_W1"

    'Public Const ServerName As String = "192.168.0.2\CHILDSERVER"
    'Public Const UserIDName As String = "sa"
    'Public Const PasswordName As String = "11779933"
    'Public Const DataBaseName = "TESCO_W1"
    ''Public Const DataBaseName = "T_TESCO_W1"

    Public Const PATHREPORT As String = "\\192.168.8.2\lotus\Report\"

    Public Const DNS As String = "Data Source=" & ServerName & ";Initial Catalog=" & DataBaseName & ";Persist Security Info=True;User ID=" & UserIDName & ";Password=" & PasswordName & ";Connect Timeout=25"
    Public lLogin As Boolean
    Public cConnect As clsConnectNet
    Public cConnectMY As clsConnectMySQL
    Public cWeek As ClsWeek
    Public cStore As ClsStore
    Public cMailbag As ClsMailbag
    Public cGpg As ClsGPG
    Public cOfficer As clsOfficer

    Public cClubcard As ClsClubcard

    'Public cCustomRadiobutton As CustomRadioButton


    Public cXML As ClsXML
    Public Const ProgramLevel As Integer = 1
    Public lOGINNAME As String

    Public gFormName As String




    Public Sub ShowError(ByVal pstr As String, ByVal pErr As Integer, ByVal pError As String)
        Dim i As Short
        MsgBox(pstr & " Error Code " & pErr & " Error " & pError)
        'i = cConnect.Connect(DNS)
    End Sub


    Public Function GetDateTime() As String
        'Output yyyy-mm-dd hh:mi:ss
        On Error GoTo error_Handler
        Dim sql As String
        Dim rs As Data.DataSet
        Dim i As Short

        GetDateTime = ""
        rs = New Data.DataSet
        sql = "SELECT CURDATE( ) as DT"
        i = cConnect.OpenSql(sql, rs)
        If i Then
            If rs.Tables("table1").Rows.Count > 0 Then
                GetDateTime = Trim(rs.Tables("table1").Rows(0)("DT").ToString)
            End If
        End If

resume_err:
        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing
        Exit Function

error_Handler:
        Call ShowError("modGlobal_GetDateTime", Err.Number, ErrorToString())
        GoTo resume_err
    End Function


    Public Function ChangeThaiDateToEngDate(ByVal pDate As String) As String
        'Input dd/mm/yyyy+543
        'output yyyy-mm-dd
        On Error GoTo error_Handler
        Dim Tmp As String

        ChangeThaiDateToEngDate = ""
        If pDate <> "" Then
            '        If Trim$(Str$(Val(Mid$(pDate, 7, 4)))) > 2300 Then
            '            Tmp = Trim$(Str$(Val(Mid$(pDate, 7, 4) - 543)))
            '        Else
            '            Tmp = Trim$(Str$(Val(Mid$(pDate, 7, 4))))
            '        End If
            Tmp = IIf(Val(Mid(pDate, 7, 4)) > 2300, Val(Mid(pDate, 7, 4)) - 543, Val(Mid(pDate, 7, 4)))
            Tmp = Tmp & "-" & Mid(pDate, 4, 2) & "-" & Mid(pDate, 1, 2)
            ChangeThaiDateToEngDate = Tmp & Mid(pDate, 11, 10)
        End If

resume_err:
        Exit Function

error_Handler:
        Call ShowError("modGlobal_ChangeThaiDateToEngDate", Err.Number, ErrorToString())
        GoTo resume_err
    End Function


    Public Function ChangeEngDateToThaiDate(ByVal pDate As String) As String
        'Input yyyy-mm-dd
        'output dd/mm/yyyy+543
        On Error GoTo error_Handler
        Dim Tmp As String

        ChangeEngDateToThaiDate = ""
        If pDate <> "" And Left(pDate, 10) <> "1900-01-01" Then

            Tmp = IIf(Val(Left(pDate, 4)) < 2300, Val(Left(pDate, 4)) + 543, Val(Left(pDate, 4)))
            Tmp = Mid(pDate, 9, 2) & "/" & Mid(pDate, 6, 2) & "/" & Tmp
            ChangeEngDateToThaiDate = Tmp & Mid(pDate, 11, Len(pDate) - 10)
        End If

resume_err:
        Exit Function

error_Handler:
        Call ShowError("modGlobal_ChangeEngDateToThaiDate", Err.Number, ErrorToString())
        GoTo resume_err
    End Function

    Public Function CheckDigit(ByVal textinput As String) As Boolean

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


        CheckDigit = False


        If Mid(textinput, 1, 7) <> "6340091" Then
            CheckDigit = False
            Exit Function
        End If
        If textinput = "" Then
            Exit Function
        End If

        For i = 1 To 18
            Ddigit(i) = Mid(textinput, i, 1)

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

        ChkDigit = 10 - (((TotalResult3) / 10) - (TotalResult3 \ 10)) * 10

        If ChkDigit = 10 Then ChkDigit = 0
        If Ddigit(18) = ChkDigit Then
            'MsgBox("OK")
            CheckDigit = True
        Else
            'MsgBox("INVALID")
            CheckDigit = False
        End If

    End Function


    Public Function CheckDupClubcard(ByVal textinput As String) As Boolean
        CheckDupClubcard = False
        Dim sql As String
        Dim rs1 As Data.DataSet
        sql = "SELECT     CLUBCARD_NO " & _
                " FROM         TBL_MEMBER_CLUBCARD  WITH (NOLOCK) " & _
                " WHERE CLUBCARD_NO = '" & textinput & "' "
        rs1 = New Data.DataSet

        If cConnect.OpenSql(sql, rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                CheckDupClubcard = True
                Exit Function

            End If


        Else
            MsgBox("Check Dup Error กรุณาติดต่อ IT")
            Exit Function

        End If

    End Function


    Public Function CheckDupClubcardTESCO(ByVal textinput As String) As Boolean
        CheckDupClubcardTESCO = False
        Dim sql As String
        Dim rs1 As Data.DataSet
        sql = "SELECT     CLUBCARD_NO " & _
                " FROM         TBL_TESCO  WITH (NOLOCK) " & _
                " WHERE CLUBCARD_NO = '" & textinput & "' "
        rs1 = New Data.DataSet

        If cConnect.OpenSql(sql, rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                CheckDupClubcardTESCO = True
                Exit Function

            End If


        Else
            MsgBox("Check Dup Error กรุณาติดต่อ IT")
            Exit Function

        End If

    End Function
End Module
