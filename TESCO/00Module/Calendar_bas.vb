Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Module Calendar

    Public gCurrentDate As Short
    Public gCurrentMonth As Short
    Public gCurrentYear As Short

    Public gCalDate As Short
    Public gCalMonth As Short
    Public gCalYear As Short


    Public gThaiMonth(13) As String
    Public gThainum(10) As String
    Public gThai As Boolean
    Private Const MODULE_NAME As String = "MCarlendar"

   



    Function CALDateGet(ByVal pDate As String) As String
        'pDate format is dd/mm/yyyy
        'On Error GoTo ErrHandle
        Dim wStr As String
        Dim i As Short
        Dim j As Short

        If (Len(pDate) <> 10 And pDate <> "") Then
            CALDateGet = ""
            Exit Function
        End If
        Call CALDefault(pDate)


        Frmcalendar.ShowDialog()
        If gCalDate > 0 Then
            'CALDateGet = CALEngToThaiStyle(Format$(gCalYear - 543, "0000") & "-" & Format$(gCalMonth, "00") & "-" & Format$(gCalDate, "00"))
            CALDateGet = Format(gCalDate, "00") & "/" & Format(gCalMonth, "00") & "/" & Format(gCalYear, "00")
        Else
            CALDateGet = ""
        End If
        Exit Function
ErrHandle:
        Call ShowError("CALDateGet", Err.Number, ErrorToString())
        Resume Next
    End Function

    Function CALDateGetNew(ByVal pDate As String) As String
        'pDate format is dd/mm/yyyy
        On Error GoTo ErrHandle

        Frmcalendar.ShowDialog()
        If gCalDate > 0 Then
            CALDateGetNew = Format(gCalDate, "00") & "/" & Format(gCalMonth, "00") & "/" & Format(gCalYear, "00")
        Else
            CALDateGetNew = ""
        End If
        Exit Function
ErrHandle:
        Call ShowError("CALDateGetNew", Err.Number, ErrorToString())
        Resume Next
    End Function

    Sub CALDefault(ByRef pDate As String)
        On Error GoTo ErrHandle
        If pDate = "" Then
            gCalYear = gCurrentYear + 543
            gCalDate = gCurrentDate
            gCalMonth = gCurrentMonth
        Else
            gCalYear = Val(Mid(pDate, 7, 4))
            gCalMonth = Val(Mid(pDate, 4, 2))
            gCalDate = Val(Mid(pDate, 1, 2))
        End If
        Exit Sub
ErrHandle:
        Call ShowError("CALDefault", Err.Number, ErrorToString())
        Resume Next
    End Sub

    Function CALEngToThaiStyle(ByRef pDate As String) As String
        On Error GoTo ErrHandle
        Dim d As String
        ' Format In yyyy-MM-DD HH:MM:SS
        ' Format Out DD MM(Thai) yyyy
        d = Trim(pDate)
        '    If pDate = "" Or pDate = "-" Then
        If d = "" Or d = "-" Then
            CALEngToThaiStyle = d
            '       CALEngToThaiStyle = ""
            Exit Function
        End If
        CALEngToThaiStyle = CALThaiStyle(CShort(Mid(pDate, 9, 2))) & " " & gThaiMonth(Val(Mid(pDate, 6, 2))) & " " & CALThaiStyle(CShort(VB.Left(pDate, 4)) + 543) & " " & Mid(pDate, 12, 5)
        Exit Function
ErrHandle:
        Call ShowError("CALEngToThaiStyle", Err.Number, ErrorToString())
        Resume Next
    End Function

    

    Sub CALIntDateThai()
        On Error GoTo ErrHandle

        If gThai = True Then
            gThainum(0) = "๐"
            gThainum(1) = "๑"
            gThainum(2) = "๒"
            gThainum(3) = "๓"
            gThainum(4) = "๔"
            gThainum(5) = "๕"
            gThainum(6) = "๖"
            gThainum(7) = "๗"
            gThainum(8) = "๘"
            gThainum(9) = "๙"
        Else
            gThainum(0) = "0"
            gThainum(1) = "1"
            gThainum(2) = "2"
            gThainum(3) = "3"
            gThainum(4) = "4"
            gThainum(5) = "5"
            gThainum(6) = "6"
            gThainum(7) = "7"
            gThainum(8) = "8"
            gThainum(9) = "9"
        End If
        gThaiMonth(1) = "ม.ค."
        gThaiMonth(2) = "ก.พ."
        gThaiMonth(3) = "มี.ค."
        gThaiMonth(4) = "เม.ย."
        gThaiMonth(5) = "พ.ค."
        gThaiMonth(6) = "มิ.ย."
        gThaiMonth(7) = "ก.ค."
        gThaiMonth(8) = "ส.ค."
        gThaiMonth(9) = "ก.ย."
        gThaiMonth(10) = "ต.ค."
        gThaiMonth(11) = "พ.ย."
        gThaiMonth(12) = "ธ.ค."

        Exit Sub
ErrHandle:
        Call ShowError(MODULE_NAME & "_CALIntDateThai", Err.Number, ErrorToString())
        Resume Next
    End Sub

    Sub CALSetDate(ByRef pDate As Short, ByRef pMonth As Short, ByRef pYear As Short)
        On Error GoTo ErrHandle
        gCalDate = pDate
        gCalMonth = pMonth
        gCalYear = pYear
        Exit Sub
ErrHandle:
        Call ShowError(MODULE_NAME & "_CALSetDate", Err.Number, ErrorToString())
        Resume Next
    End Sub

  

    Function CALThaiStyle(ByRef EngDate As Short) As String
        On Error GoTo ErrHandle
        Dim i As Short
        Dim s1 As String
        Dim s2 As String

        s2 = ""
        s1 = Trim(Str(EngDate))
        If gThai = True Then
            For i = 1 To Len(s1)
                s2 = s2 & gThainum(CShort(Mid(s1, i, 1)))
            Next i
        Else
            s2 = s1
        End If
        CALThaiStyle = s2
        Exit Function
ErrHandle:
        Call ShowError(MODULE_NAME & "_CALThaiStyle", Err.Number, ErrorToString())
        Resume Next
    End Function



    Sub CalGetSystemDate()
        On Error GoTo error_Handler
        Dim rs As Data.DataSet
        Dim i As Boolean
        Dim sql As String

        sql = "SELECT CONVERT(VARCHAR(10),GETDATE(),120) as EXPR1" '120 = Format  ODBC yyyy-MM-DD
        rs = New Data.DataSet
        i = cConnect.OpenSql(sql, rs)
        If i = True Then
            gCurrentYear = CShort(Left(rs.Tables(0).Rows(0)("EXPR1").ToString, 4))
            gCurrentMonth = CShort(Mid(rs.Tables(0).Rows(0)("EXPR1").ToString, 6, 2))
            gCurrentDate = CShort(Right(rs.Tables(0).Rows(0)("EXPR1").ToString, 2))
        End If

resume_err:
        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing
        Exit Sub

error_Handler:
        Call ShowError(MODULE_NAME & "_CalGetSystemDate", Err.Number, ErrorToString())
    End Sub

    Function CALAge(ByRef pBODDate As String) As String 'แบบ 6 เดือน 1 วัน ปัดขึ้น
        On Error GoTo ErrHandle
        Dim Y As Integer
        Dim Bdate As String
        Dim Tmp As String 'Date

        If Trim(pBODDate) <> "" Then
            Tmp = CDate(Left(GetDateTime, 10))
            Bdate = CDate(ChangeThaiDateToEngDate(pBODDate))

            '            Tmp = Format("2006-05-10", "dd/mm/yyyy")

            'Tmp = (Format(Tmp, "dd/mm/yyyy"))
            'Bdate = (Format(Bdate, "dd/mm/yyyy"))

            Y = Int((DateDiff(Microsoft.VisualBasic.DateInterval.Month, CDate(Bdate), CDate(Tmp))) / 12)
            Select Case ((DateDiff(Microsoft.VisualBasic.DateInterval.Month, CDate(Bdate), CDate(Tmp))) Mod 12)
                Case 6 : If VB.Day(Bdate) <= VB.Day(Tmp) Then Y = Y + 1
                Case 7 To 12 : Y = Y + 1
            End Select
            CALAge = CStr(Y)

        End If

        Exit Function

ErrHandle:
        Call ShowError(MODULE_NAME & "_" & "CALAge", Err.Number, ErrorToString())
        Resume Next
    End Function
End Module