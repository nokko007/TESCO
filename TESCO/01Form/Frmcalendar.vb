Option Strict Off
Option Explicit On

Imports VB = Microsoft.VisualBasic
Imports VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support


Public Class Frmcalendar





    Inherits System.Windows.Forms.Form

    Const WM_USER As Short = &H400S
    Const CB_SHOWDROPDOWN As Integer = WM_USER + 15


    Dim lYear As Short
    Dim lMonth As Short
    Dim lDate As Short
    Dim lStart As Short
    Dim lDays As Short
    Dim lMonthString(13) As String
    Dim lNODays(13) As Short
    Dim lmousepointer As Short
    Dim lOldDate As Short
    Private pnlDate1(31) As Button
    'Dim pnlDate1(31) As Button
    Dim count As Integer


    Private Sub cmbMonth_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        Call GetCurrent(Format(CShort(cmbMonth.SelectedIndex + 1), "00") & "-" & Format(lDate, "00") & "-" & Format(lYear, "0000"), lYear, lMonth, lDate, lStart, lDays)
        Redraw()
    End Sub

    'UPGRADE_WARNING: Event cmbYear.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub cmbYear_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        Call GetCurrent(Format(lMonth, "00") & "-" & Format(lDate, "00") & "-" & Format(cmbYear.SelectedIndex + 2401, "0000"), lYear, lMonth, lDate, lStart, lDays)
        Redraw()
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        gCalDate = 0
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdMLeft_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMLeft.Click
        If cmbMonth.SelectedIndex > 0 Then
            cmbMonth.SelectedIndex = cmbMonth.SelectedIndex - 1
        Else
            cmbMonth.SelectedIndex = 11
        End If
    End Sub

    Private Sub cmdMRight_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMRight.Click
        If cmbMonth.SelectedIndex < cmbMonth.Items.Count - 1 Then
            cmbMonth.SelectedIndex = cmbMonth.SelectedIndex + 1
        Else
            cmbMonth.SelectedIndex = 0
        End If
    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call CALSetDate(lDate, lMonth, lYear)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdYLeft_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdYLeft.Click
        If cmbYear.SelectedIndex > 0 Then
            cmbYear.SelectedIndex = cmbYear.SelectedIndex - 1
        End If
    End Sub

    Private Sub cmdYRight_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdYRight.Click
        If cmbYear.SelectedIndex < cmbYear.Items.Count - 1 Then
            cmbYear.SelectedIndex = cmbYear.SelectedIndex + 1
        End If
    End Sub

    Private Sub frmCalendar_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim i As Short
        Dim d As String
        Dim iYearindex As Integer
        Dim ThaiYear As String

        CalGetSystemDate()


        lMonthString(1) = "มกราคม"
        lNODays(1) = 31
        lMonthString(2) = "กุมภาพันธ์"
        lNODays(2) = 28
        lMonthString(3) = "มีนาคม"
        lNODays(3) = 31
        lMonthString(4) = "เมษายน"
        lNODays(4) = 30
        lMonthString(5) = "พฤษภาคม"
        lNODays(5) = 31
        lMonthString(6) = "มิถุนายน"
        lNODays(6) = 30
        lMonthString(7) = "กรกฎาคม"
        lNODays(7) = 31
        lMonthString(8) = "สิงหาคม"
        lNODays(8) = 31
        lMonthString(9) = "กันยายน"
        lNODays(9) = 30
        lMonthString(10) = "ตุลาคม"
        lNODays(10) = 31
        lMonthString(11) = "พฤศจิกายน"
        lNODays(11) = 30
        lMonthString(12) = "ธันวาคม"
        lNODays(12) = 31


        If (gCalMonth = 0) Or (gCalDate = 0) Or (gCalYear = 0) Then
            d = Format(gCurrentMonth, "00") & "-" & Format(gCurrentDate, "00") & "-" & Format(gCurrentYear + 543, "0000")
        Else
            'format date mm/dd/yyyy(inthai)
            d = Format(gCalMonth, "00") & "-" & Format(gCalDate, "00") & "-" & Format(gCalYear, "0000")
        End If

        Call GetCurrent(d, lYear, lMonth, lDate, lStart, lDays)

        iYearindex = 0
        For i = 2401 To 2700
            cmbYear.Items.Add(i)
            If i <= lYear Then
                iYearindex = iYearindex + 1
            End If
        Next i
        cmbYear.SelectedIndex = iYearindex - 1

        ThaiYear = (lYear)
        For i = 0 To 299
            If (ThaiYear = cmbYear.Items(i).ToString) Then
                cmbYear.SelectedIndex = i
            End If
        Next i

        For i = 1 To 12
            cmbMonth.Items.Add(lMonthString(i))
        Next i
        lOldDate = -1
        cmbMonth.SelectedIndex = lMonth - 1

        Call Redraw()

    End Sub

    Private Sub frmCalendar_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        'Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        'Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'DragForm Me.hWnd
    End Sub

    'Private Sub frmCalendar_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       If lOldDate >= 0 Then
    '           If System.Drawing.ColorTranslator.ToOle(pnlDate(lOldDate).BackColor) <> System.Drawing.ColorTranslator.ToOle(Me.BackColor) Then
    '               pnlDate(lOldDate).BackColor = Me.BackColor
    '           End If
    '       End If
    'End Sub


    Private Sub frmCalendar_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = lmousepointer
        'UPGRADE_NOTE: Object frmCalendar may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Me = Nothing
    End Sub

    Private Sub GetCurrent(ByRef pCDate As String, ByRef pYear As Short, ByRef pMonth As Short, ByRef pDate As Short, ByRef pStart As Short, ByRef pDays As Short)
        Dim nYear As Short
        Dim d1 As Date
        Dim d2 As Date


        pYear = CShort(CDbl(VB.Right(Trim(pCDate), 4)) - 543)
        pMonth = CShort(VB.Left(Trim(pCDate), 2))
        pDate = CShort(Mid(Trim(pCDate), 4, 2))
        d1 = DateSerial(pYear, pMonth, 1)
        nYear = pYear
        If ((pMonth Mod 12) = 0) Then
            nYear = pYear + 1
        End If
        d2 = DateSerial(nYear, (pMonth Mod 12) + 1, 1)
        pYear = pYear + 543
        pDays = DateDiff(DateInterval.Day, d1, d2)
        pStart = Weekday(d1) - 1
    End Sub

    Private Sub lblCaption_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LblCaption.MouseDown
        'Dim Button As Short = eventArgs.Button \ &H100000
        'Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        'Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        'Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'DragForm Me.hWnd
    End Sub

    Private Sub pnlDate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        ''Dim Index As Short = pnlDate.GetIndex(eventSender)
        'lDate = pnlDate.Text
        'LblCaption.Text = CALThaiStyle(lDate) & " " & lMonthString(lMonth) & " พ.ศ. " & CALThaiStyle(lYear)
    End Sub





    Private Sub Redraw()




        Dim i As Short
        Dim X As Short
        Dim Y As Short
        Dim n As Short




        LblCaption.Text = CALThaiStyle(lDate) & " " & lMonthString(lMonth) & " พ.ศ. " & CALThaiStyle(lYear)

        n = lStart
        X = 36
        Y = 96
        For i = 1 To count - 1
            Me.Controls.Remove(pnlDate1(i))
        Next




        For count = 1 To lDays

            pnlDate1(count) = New Button

            If count = 31 Then

                pnlDate1(count).Left = ((X * n))
                pnlDate1(count).Top = (Y)
                pnlDate1(count).Width = 36
                pnlDate1(count).Height = 19
            End If
            pnlDate1(count).Width = 36
            pnlDate1(count).Height = 19
            pnlDate1(count).Left = ((X * n)) + 4
            pnlDate1(count).Top = (Y)
            pnlDate1(count).Text = count.ToString
            If n = 6 Then
                pnlDate1(count).BackColor = Color.DarkGray
            ElseIf n = 0 Then
                pnlDate1(count).BackColor = Color.LightPink
            Else
                pnlDate1(count).BackColor = Color.LightBlue
            End If

            pnlDate1(count).SetBounds(((X * n)) + 4, (Y), 36, 19)
            pnlDate1(count).Name = "pnldate" & count.ToString
            Me.Controls.Add(pnlDate1(count))
            pnlDate1(count).Tag = pnlDate1(count).Text
            AddHandler pnlDate1(count).Click, AddressOf OnButtonClick
            pnlDate1(count).Visible = True


            n = n + 1
            If (n >= 7) Then
                Y = Y + 19
                n = 0
            End If
        Next count
        If (n > 0) Then
            Y = Y + 19
        End If
        'MsgBox(count)
        'Do While i <= 31
        '    pnlDate(i).Visible = False
        '    i = i + 1
        'Loop

        'Dim count As Integer, pnld As Button

        'count = 5

        'For Each ctl As Control In Controls

        '    If TypeOf ctl Is Label Then

        '        lbl = CType(ctl, Label)

        '        count -= 1

        '        LabelArray(count) = lbl

        '    End If

        'Next


    End Sub
    Private Sub OnButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnClicked As Button = DirectCast(sender, Button)
        Dim intSBIndex As Integer = Integer.Parse(btnClicked.Tag)
        'MsgBox(btnClicked.Text)

        lDate = (btnClicked.Text)
        LblCaption.Text = CALThaiStyle(lDate) & " " & lMonthString(lMonth) & " พ.ศ. " & CALThaiStyle(lYear)

    End Sub










End Class