Imports System.Globalization
Imports System.Threading





Public Class FRmKeyin

    Dim RSNEW As Data.DataSet

    'Item is filled either manually or from database
    Dim lsttumbol As New List(Of String)
    Dim lststreet As New List(Of String)
    Dim lstSoi As New List(Of String)
    'AutoComplete collection that will help to filter keep the records.
    Dim MySource As New AutoCompleteStringCollection()

    Private Sub FRmKeyin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If FraKEYIN.Visible = False Then Exit Sub

        If gFormName = "QUERY" Then Exit Sub
        If e.KeyValue = Keys.F10 Then
            'Me.KeyPreview = False
            If MsgBox("ต้องการ Save ข้อมูลใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            Else
                Call SAVEDATA()
            End If

        End If


    End Sub





    Private Sub FRmKeyin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FraKEYIN.Visible = False
        CalGetSystemDate()
        Call setcombo()
        If gFormName = "KEYIN" Then
            Call SelectKeyin()
        ElseIf gFormName = "QC" Then
            Call SelectQC()
        ElseIf gFormName = "QUERY" Then
            Call selectApp()
        End If

        TxtClubcard.Focus()
        Me.KeyPreview = True
    End Sub

    Private Sub TxtClubcard_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtClubcard.GotFocus
        Dim TypeOfLanguage = New System.Globalization.CultureInfo("EN") ' or "fa-IR" for Farsi(Iran) 
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)
    End Sub

    Private Sub TxtClubcard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClubcard.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                If CheckDigit(TxtClubcard.Text) = False Then
                    If MsgBox("เลข Clubcard ไม่ถูกต้อง Invalid", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        TxtClubcard.Text = ""
                        TxtClubcard.Focus()

                        Exit Sub
                    End If
                Else
                    Call clrForm()
                    selectApp()
                    TxtClubcard.Focus()
                    'TxtClubcard.SelectAll()
                    'TxtProvince.Enabled = False
                    'Txtamper.Enabled = False
                    Exit Sub

                End If

            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtClubcardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClubcard.TextChanged

    End Sub

    Public Sub selectApp()

        Dim sql As String
        RSNEW = New Data.DataSet
        If gFormName = "KEYIN" Then
            sql = "SELECT * FROM TBL_MEMBER_CLUBCARD WITH (NOLOCK)  WHERE CLUBCARD_NO = '" & Trim(TxtClubcard.Text) & "'   and  (FLAG = 'KEYIN' or FLAG = 'NEW' or FLAG = 'QC' ) "
        ElseIf gFormName = "QC" Then
            sql = "SELECT * FROM TBL_MEMBER_CLUBCARD WITH (NOLOCK)  WHERE CLUBCARD_NO = '" & Trim(TxtClubcard.Text) & "' and   (FLAG = 'KEYIN' or FLAG = 'QC' )   "
        ElseIf gFormName = "QUERY" Then
            sql = "SELECT * FROM TBL_MEMBER_CLUBCARD WITH (NOLOCK)  WHERE CUSTID  = '" & cClubcard.custid & "' "
        End If

        If cConnect.OpenSql(sql, RSNEW) = False Then
            MsgBox("ไม่สามารถ Select ข้อมูลได้กรุณาติดต่อ IT", MsgBoxStyle.OkOnly)
            TxtClubcard.Focus()
            TxtClubcard.SelectAll()
            Exit Sub
        End If

        If RSNEW.Tables(0).Rows.Count < 1 Then
            MsgBox("ไม่พบข้อมูล Clubcard ", MsgBoxStyle.OkOnly)
            TxtClubcard.Focus()
            TxtClubcard.SelectAll()
            Exit Sub
        End If

        Dim i As Integer
        Dim ChkNew As Boolean
        ChkNew = False
        Dim CRD1 As DateTime
        Dim CRD2 As String

        If gFormName = "KEYIN" Then
            If RSNEW.Tables(0).Rows(0)("FLAG").ToString = "QC" Then
                MsgBox("รายการนี้ถูก QC ไปแล้ว ไม่สามารถเรียกมาแก้ไขได้อีก")
                TxtClubcard.Focus()
                TxtClubcard.SelectAll()
                Exit Sub
            End If
            If RSNEW.Tables(0).Rows(0)("FLAG").ToString = "NEW" Then
                FraKEYIN.Visible = True
                Call clrForm()
                LblFlag.Text = "NEW"

                cClubcard.custid = RSNEW.Tables(0).Rows(0)("CUSTID").ToString

                CRD1 = RSNEW.Tables(0).Rows(0)("CUSTOMER_CREATED_DATE").ToString
                CRD2 = CRD1.ToString("yyyy-MM-dd")
                Txtdate.Text = ChangeEngDateToThaiDate(CRD2)

                TxtClubcard.Focus()
                TxtClubcard.SelectAll()
            ElseIf RSNEW.Tables(0).Rows(0)("FLAG").ToString = "KEYIN" Then
                If RSNEW.Tables(0).Rows(0)("KEYIN_EMPLOYEEID").ToString <> cOfficer.Login Then
                    MsgBox("ไม่สามารถแก้ไขข้อมูลได้เนื่องจากไม่ใช้เจ้าของ Record")
                    TxtClubcard.SelectAll()
                    Exit Sub
                End If
                LblFlag.Text = RSNEW.Tables(0).Rows(0)("FLAG").ToString
                cClubcard.custid = RSNEW.Tables(0).Rows(0)("CUSTID").ToString
                Call settextbox()
                FraKEYIN.Visible = True
                TxtClubcard.Focus()
                'TxtClubcard.SelectAll()
            End If

        ElseIf gFormName = "QC" Then
            LblFlag.Text = RSNEW.Tables(0).Rows(0)("FLAG").ToString
            cClubcard.custid = RSNEW.Tables(0).Rows(0)("CUSTID").ToString
            Call settextbox()
            FraKEYIN.Visible = True
            TxtClubcard.Focus()
            TxtClubcard.SelectAll()

        ElseIf gFormName = "QUERY" Then
            LblFlag.Text = RSNEW.Tables(0).Rows(0)("FLAG").ToString
            'cClubcard.custid = RSNEW.Tables(0).Rows(0)("CUSTID").ToString
            Call settextbox()
            FraKEYIN.Visible = True
            CmdSave.Visible = False
            TxtClubcard.Focus()
            TxtClubcard.SelectAll()
        End If

        'If RSNEW.Tables(0).Rows(0)("FLAG").ToString = "NEW" Then

        '    FraKEYIN.Visible = True
        '    Call clrForm()
        '    LblFlag.Text = "NEW"
        '    OptFormtype1.Focus()
        '    cClubcard.custid = RSNEW.Tables(0).Rows(0)("CUSTID").ToString
        'ElseIf Flag Then

        '    LblFlag.Text = RSNEW.Tables(0).Rows(0)("FLAG").ToString
        '    cClubcard.custid = RSNEW.Tables(0).Rows(0)("CUSTID").ToString

        '    Call settextbox()
        '    FraKEYIN.Visible = True
        'End If


    End Sub
    Public Sub clrForm()



        TxtName.Text = ""
        TxtSurname.Text = ""
        OptID1.Checked = True

        TxtID1.Text = ""
        TxtID2.Text = ""
        TxtID3.Text = ""
        TxtID4.Text = ""
        TxtID5.Text = ""
        TxtID6.Text = ""


        TxtPrimarycard1.Text = ""

        TxtPrimarycard2.Text = ""
        TxtPrimarycard3.Text = ""

        TxtBD1.Text = ""
        TxtBD2.Text = ""
        TxtBD3.Text = ""


        Txtfamilydob1.Text = ""

        Txtfamilydob2.Text = ""

        Txtfamilydob3.Text = ""

        Txtfamilydob4.Text = ""


        TxtHomeID.Text = ""




        TxtBuliding.Text = ""
        TxtRoom.Text = ""
        TxtFloor.Text = ""
        TxtMou.Text = ""
        TxtSoi.Text = ""
        TxtStreet.Text = ""
        TxtTumbol.Text = ""

        ChkProvince.Checked = False

        TxtProvince.Text = ""


        Txtamper.Text = ""


        Txtpostcode.Text = ""
        TxtOfficetel1.Text = ""
        TxtOfficetel2.Text = ""
        TxtOfficetel3.Text = ""

        TxtHometel1.Text = ""
        TxtHometel2.Text = ""
        TxtHometel3.Text = ""


        TxtMobileTel1.Text = ""
        TxtMobileTel2.Text = ""
        TxtMobileTel3.Text = ""

        Txtemail1.Text = ""
        Cmbemail2.Text = ""

        Txtfamilymember.Text = ""

        Txtdate.Text = ""

        '''''''''''''''''''''''''








        CmbProvince.SelectedIndex = -1
        CmbCountry.SelectedIndex = 0
        CmbAmper.SelectedIndex = -1

        OptFormtype1.Checked = True

        OptMR.Checked = False
        OptMRS.Checked = False
        OptMs.Checked = False
        OptUNTITLE.Checked = True

        OptHome1.Checked = False
        OptHome2.Checked = False
        OptHome3.Checked = False

        OptRace0.Checked = True
        OptRace1.Checked = False
        OptRace2.Checked = False
        OptRace3.Checked = False
        OptRace4.Checked = False

        Optbusiness1.Checked = True

        LblFlag.Text = ""

        TxtProvince.Enabled = False
        Txtamper.Enabled = False

    End Sub


    Public Sub SelectKeyin()
        Dim sql As String
        Dim rs As Data.DataSet
        sql = "SELECT COUNT(*) FROM TBL_MEMBER_CLUBCARD WITH (NOLOCK)  " & _
        " WHERE CONVERT(VARCHAR(10),KEYIN_DATE,20) = CONVERT(VARCHAR(10),GETDATE(),20)   " & _
        " AND KEYIN_EMPLOYEEID = '" & cOfficer.Login & "'  "
        rs = New Data.DataSet
        If cConnect.OpenSql(sql, rs) = False Then
            LblCounting.Text = "Error Select!!!!"
        Else
            LblCounting.Text = "จำนวนที่ Keyin ได้ในวันนี้  " & rs.Tables(0).Rows(0)(0).ToString & " ใบ "

        End If

        LblCounting.ForeColor = Color.BlueViolet


    End Sub
    Public Sub SelectQC()
        Dim sql As String
        Dim rs As Data.DataSet
        sql = "SELECT COUNT(*) FROM TBL_MEMBER_CLUBCARD WITH (NOLOCK) " & _
        " WHERE CONVERT(VARCHAR(10),QC_DATE,20) = CONVERT(VARCHAR(10),GETDATE(),20)   " & _
        " AND QC_EMPLOYEEID = '" & cOfficer.Login & "'  "
        rs = New Data.DataSet
        If cConnect.OpenSql(sql, rs) = False Then
            LblCounting.Text = "Error Select!!!!"
        Else
            LblCounting.Text = "จำนวนที่ QC ได้ในวันนี้  " & rs.Tables(0).Rows(0)(0).ToString & " ใบ "
        End If


        LblCounting.ForeColor = Color.Red

    End Sub

    Private Sub TxtPrimarycard1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrimarycard1.GotFocus
        TxtPrimarycard1.SelectAll()
    End Sub

    Private Sub TxtPrimarycard2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrimarycard2.GotFocus
        TxtPrimarycard2.SelectAll()
    End Sub

    Private Sub TxtPrimarycard3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrimarycard3.GotFocus
        TxtPrimarycard3.SelectAll()
    End Sub

    Private Sub TxtPrimarycard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrimarycard1.KeyPress, TxtPrimarycard3.KeyPress, TxtPrimarycard2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select


    End Sub

    Private Sub TxtPrimarycard_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrimarycard1.LostFocus

    End Sub

    Private Sub TxtID1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtID1.GotFocus
        TxtID1.SelectAll()
    End Sub

    Private Sub TxtID1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtID1.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtID2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtID2.GotFocus
        TxtID2.SelectAll()
    End Sub


    Private Sub TxtID2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtID2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtID3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtID3.GotFocus
        TxtID3.SelectAll()
    End Sub


    Private Sub TxtID3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtID3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtID4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtID4.GotFocus
        TxtID4.SelectAll()
    End Sub


    Private Sub TxtID4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtID4.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtID5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtID5.GotFocus
        TxtID5.SelectAll()
    End Sub


    Private Sub TxtID5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtID5.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub TxtBD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBD1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub TxtBD2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBD2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub TxtBD3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBD3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub Txtpostcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtpostcode.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtHometel1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHometel1.GotFocus
        TxtHometel1.SelectAll()
    End Sub


    Private Sub TxtHometel1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHometel1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 9
                'SendKeys.Send(vbTab)
                If Len(TxtHometel1.Text) = 0 Then
                    TxtOfficetel1.Focus()
                Else
                    SendKeys.Send(vbTab)
                End If
            Case 13
                'SendKeys.Send(vbTab)
                If Len(TxtHometel1.Text) = 0 Then
                    TxtOfficetel1.Focus()
                Else
                    SendKeys.Send(vbTab)
                End If
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtHometel2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHometel2.GotFocus
        TxtHometel2.SelectAll()
    End Sub


    Private Sub TxtHometel2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHometel2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtHometel3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHometel3.GotFocus
        TxtHometel3.SelectAll()
    End Sub


    Private Sub TxtHometel3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHometel3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtOfficetel1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOfficetel1.GotFocus
        TxtOfficetel1.SelectAll()
    End Sub


    Private Sub TxtOfficetel1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOfficetel1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                If TxtOfficetel1.Text = "" Then
                    TxtMobileTel1.Focus()
                Else
                    SendKeys.Send(vbTab)
                End If


            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtOfficetel2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOfficetel2.GotFocus
        TxtOfficetel2.SelectAll()
    End Sub


    Private Sub TxtOfficetel2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOfficetel2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtOfficetel3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOfficetel3.GotFocus
        TxtOfficetel3.SelectAll()
    End Sub



    Private Sub TxtOfficetel3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOfficetel3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtMobileTel1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMobileTel1.GotFocus
        TxtMobileTel1.SelectAll()
    End Sub



    Private Sub TxtMobileTel1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMobileTel1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtMobileTel2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMobileTel2.GotFocus
        TxtMobileTel2.SelectAll()
    End Sub


    Private Sub TxtMobileTel2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMobileTel2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtMobileTel3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMobileTel3.GotFocus
        TxtMobileTel3.SelectAll()
    End Sub


    Private Sub TxtMobileTel3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMobileTel3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub Txtfamilymember_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtfamilymember.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub Txtfamilydob1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtfamilydob1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub Txtfamilydob2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtfamilydob2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub Txtfamilydob3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtfamilydob3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub Txtfamilydob4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtfamilydob4.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub


    Private Sub TxtID1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtID1.TextChanged


        If Len(TxtID1.Text) = 1 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtID2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtID2.TextChanged
        If Len(TxtID2.Text) = 4 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtID3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtID3.TextChanged
        If Len(TxtID3.Text) = 5 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtID4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtID4.TextChanged
        If Len(TxtID4.Text) = 2 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtID5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtID5.TextChanged
        If Len(TxtID5.Text) = 1 Then
            TxtBD1.Focus()
        End If
    End Sub

    Private Sub TxtBD1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBD1.TextChanged
        If Len(TxtBD1.Text) = 2 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtBD2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBD2.TextChanged
        If Len(TxtBD2.Text) = 2 Then
            If Val(TxtBD2.Text) < 0 Or Val(TxtBD2.Text) > 12 Then
                MsgBox("เดือนเกิดไม่ถูกต้อง")
                TxtBD2.SelectAll()
                Exit Sub
            End If
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtBD3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBD3.TextChanged


        If Len(TxtBD3.Text) = 4 Then
            If Val(gCurrentYear) - (Val(TxtBD3.Text) - 543) < 0 Or Val(gCurrentYear) - (Val(TxtBD3.Text) - 543) > 100 Then
                MsgBox("อายุเกิน 100 ปี กรุณาตรวจสอบปีเกิดใหม่อีกครั้ง", MsgBoxStyle.OkOnly, "")
            End If

            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtHometel1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHometel1.TextChanged

        If Mid(Trim(TxtHometel1.Text), 1, 2) = "02" Then
            SendKeys.Send(vbTab)
            Exit Sub
        End If
        If Len(TxtHometel1.Text) = 3 Then
            SendKeys.Send(vbTab)
        End If

    End Sub

    Private Sub TxtHometel2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHometel2.TextChanged


        If Len(TxtHometel2.Text) = 3 Then
            SendKeys.Send(vbTab)
        End If


    End Sub

    Private Sub TxtHometel3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHometel3.TextChanged
        If Mid(Trim(TxtHometel1.Text), 1, 2) = "02" Then

            If Len(TxtHometel3.Text) = 4 Then
                SendKeys.Send(vbTab)
            End If
        Else
            If Len(TxtHometel3.Text) = 3 Then
                SendKeys.Send(vbTab)
            End If
        End If


    End Sub

    Private Sub TxtOfficetel1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOfficetel1.TextChanged
        If Mid(Trim(TxtOfficetel1.Text), 1, 2) = "02" Then
            SendKeys.Send(vbTab)
            Exit Sub
        End If
        If Len(TxtOfficetel1.Text) = 3 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtOfficetel2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOfficetel2.TextChanged
        If Len(TxtOfficetel2.Text) = 3 Then
            SendKeys.Send(vbTab)
        End If

    End Sub

    Private Sub TxtOfficetel3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOfficetel3.TextChanged
        If Mid(Trim(TxtOfficetel1.Text), 1, 2) = "02" Then

            If Len(TxtOfficetel3.Text) = 4 Then
                SendKeys.Send(vbTab)
            End If
        Else
            If Len(TxtOfficetel3.Text) = 3 Then
                SendKeys.Send(vbTab)
            End If
        End If

    End Sub

    Private Sub TxtMobileTel1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMobileTel1.TextChanged
        If Len(TxtMobileTel1.Text) = 3 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtMobileTel2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMobileTel2.TextChanged
        If Len(TxtMobileTel2.Text) = 3 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtMobileTel3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMobileTel3.TextChanged
        If Len(TxtMobileTel3.Text) = 4 Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        SAVEDATA()

        'Call SetClubcardValue()

        'If gFormName = "KEYIN" Then

        '    If LblFlag.Text = "NEW" Then
        '        If cClubcard.UpdateKEYINClubcard = False Then
        '            MsgBox("Error update to Keyin")
        '            Exit Sub
        '        End If
        '    ElseIf LblFlag.Text = "KEYIN" Then
        '        If cClubcard.EditKEYINClubcard = False Then
        '            MsgBox("Error update to Keyin")
        '            Exit Sub
        '        End If
        '        Call SelectKeyin()
        '    End If
        'ElseIf gFormName = "QC" Then

        '    If LblFlag.Text = "KEYIN" Then

        '        If cClubcard.KeepHistory = False Then
        '            MsgBox("Error Keep History")
        '            Exit Sub
        '        End If

        '        If cClubcard.UpdateQCClubcard = False Then
        '            MsgBox("Error update to Keyin")
        '            Exit Sub
        '        End If

        '    ElseIf LblFlag.Text = "QC" Then
        '        If cClubcard.KeepHistory = False Then
        '            MsgBox("Error Keep History")
        '            Exit Sub
        '        End If

        '        If cClubcard.EditQCClubcard = False Then
        '            MsgBox("Error update to QC")
        '            Exit Sub
        '        End If
        '    End If
        '    Call SelectQC()
        'End If

        'FraKEYIN.Visible = False
        'Call clrForm()

        'TxtClubcard.Text = ""
        'TxtClubcard.Focus()

    End Sub

    Public Function SetClubcardValue()

        cClubcard.name_1 = Trim(TxtName.Text)
        cClubcard.name_2 = Trim(TxtSurname.Text)
        If OptID1.Checked = True Then
            cClubcard.idtype = OptID1.Text
            cClubcard.official_id = Trim(TxtID1.Text) & Trim(TxtID2.Text) & Trim(TxtID3.Text) & Trim(TxtID4.Text) & Trim(TxtID5.Text)
        ElseIf OptID2.Checked = True Then
            cClubcard.idtype = OptID2.Text
            cClubcard.official_id = Trim(TxtID6.Text)
        ElseIf OptID3.Checked = True Then
            cClubcard.idtype = OptID3.Text
            cClubcard.official_id = ""
        End If

        If OptFormtype1.Checked = True Then
            cClubcard.primary_card_account_number = Trim(TxtClubcard.Text)
        ElseIf OptFormtype2.Checked = True Then
            cClubcard.primary_card_account_number = Trim("6340091" & TxtPrimarycard1.Text & TxtPrimarycard2.Text & TxtPrimarycard3.Text)
        End If

        cClubcard.card_account_number = Trim(TxtClubcard.Text)
        'cClubcard.customer_use_status = ""
        'cClubcard.customer_mail_status = ""

        If OptMR.Checked = True Then
            cClubcard.family_member_1_gender_code = "0"
        ElseIf OptMs.Checked = True Or OptMRS.Checked = True Then
            cClubcard.family_member_1_gender_code = "1"
        Else
            cClubcard.family_member_1_gender_code = "2"
        End If
        If Trim(TxtBD1.Text) = "" And Trim(TxtBD2.Text) = "" And Trim(TxtBD3.Text) = "" Then
            cClubcard.family_member_1_dob = ""
        Else
            cClubcard.family_member_1_dob = ChangeThaiDateToEngDate(Trim(TxtBD1.Text) & "/" & Trim(TxtBD2.Text) & "/" & Trim(TxtBD3.Text))
        End If

        If Txtfamilydob1.Text <> "" Then
            cClubcard.family_member_2_dob = gCurrentYear - Val(Txtfamilydob1.Text) & "-01-01"
        Else
            cClubcard.family_member_2_dob = ""
        End If

        If Txtfamilydob2.Text <> "" Then
            cClubcard.family_member_3_dob = gCurrentYear - Val(Txtfamilydob2.Text) & "-01-01"
        Else
            cClubcard.family_member_3_dob = ""
        End If

        If Txtfamilydob3.Text <> "" Then
            cClubcard.family_member_4_dob = gCurrentYear - Val(Txtfamilydob3.Text) & "-01-01"
        Else
            cClubcard.family_member_4_dob = ""
        End If


        If Txtfamilydob4.Text <> "" Then
            cClubcard.family_member_5_dob = gCurrentYear - Val(Txtfamilydob4.Text) & "-01-01"
        Else
            cClubcard.family_member_5_dob = ""
        End If

        cClubcard.HOMEID = Trim(TxtHomeID.Text)
        If OptHome1.Checked = True Then
            cClubcard.BUILDING_TYPE = OptHome1.Text
        ElseIf OptHome2.Checked = True Then
            cClubcard.BUILDING_TYPE = OptHome2.Text
        Else
            cClubcard.BUILDING_TYPE = OptHome3.Text
        End If

        cClubcard.BUILDING = Trim(TxtBuliding.Text)
        cClubcard.ROOM_NO = Trim(TxtRoom.Text)
        cClubcard.FLOOR = Trim(TxtFloor.Text)
        cClubcard.MOU = Trim(TxtMou.Text)
        cClubcard.SOI = Trim(TxtSoi.Text)
        cClubcard.STREET = Trim(TxtStreet.Text)
        cClubcard.TUMBOL = Trim(TxtTumbol.Text)

        'cClubcard.address_line_1 = ""
        'cClubcard.address_line_2 = ""
        'cClubcard.address_line_3 = ""
        If ChkProvince.Checked = True Then

            cClubcard.city = Txtamper.Text
            cClubcard.province_code = "-1"
            cClubcard.province = TxtProvince.Text
        Else
            cClubcard.city = Trim(CmbAmper.Text)
            cClubcard.province = Trim(CmbProvince.Text)
            cClubcard.province_code = Trim(TxtProvincecode.Text)
        End If



        cClubcard.country = Trim(CmbCountry.Text)
        cClubcard.postal_code = Trim(Txtpostcode.Text)
        If Trim(TxtOfficetel1.Text) = "" And Trim(TxtOfficetel2.Text) = "" And Trim(TxtOfficetel3.Text) = "" Then
            cClubcard.daytime_phone_number = ""
        Else
            cClubcard.daytime_phone_number = Trim(TxtOfficetel1.Text) & "-" & Trim(TxtOfficetel2.Text) & Trim(TxtOfficetel3.Text)
        End If

        If Trim(TxtHometel1.Text) = "" And Trim(TxtHometel2.Text) = "" And Trim(TxtHometel3.Text) = "" Then
            cClubcard.evening_phone_number = ""
        Else
            cClubcard.evening_phone_number = Trim(TxtHometel1.Text) & "-" & Trim(TxtHometel2.Text) & Trim(TxtHometel3.Text)
        End If

        If Trim(TxtMobileTel1.Text) = "" And Trim(TxtMobileTel2.Text) = "" And Trim(TxtMobileTel3.Text) = "" Then
            cClubcard.mobile_phone_number = ""
        Else
            cClubcard.mobile_phone_number = Trim(TxtMobileTel1.Text) & "-" & Trim(TxtMobileTel2.Text) & Trim(TxtMobileTel3.Text)
        End If



        If Trim(Txtemail1.Text) = "" And Trim(Cmbemail2.Text) = "" Then
            cClubcard.email_address = ""
        Else
            cClubcard.email_address = Trim(Txtemail1.Text) & "@" & Trim(Cmbemail2.Text)
        End If

        If Optbusiness1.Checked = True Then
            cClubcard.business_type_code = "0"
        ElseIf Optbusiness2.Checked = True Then
            cClubcard.business_type_code = "1"
        ElseIf Optbusiness3.Checked = True Then
            cClubcard.business_type_code = "2"
        ElseIf Optbusiness4.Checked = True Then
            cClubcard.business_type_code = "3"
        ElseIf Optbusiness5.Checked = True Then
            cClubcard.business_type_code = "4"
        ElseIf Optbusiness6.Checked = True Then
            cClubcard.business_type_code = "6"
        Else
            cClubcard.business_type_code = "0"
        End If


        If OptMR.Checked = True Then
            cClubcard.title_code = "Mr"
        ElseIf OptMs.Checked = True Then
            cClubcard.title_code = "Ms"
        ElseIf OptMRS.Checked = True Then
            cClubcard.title_code = "Mrs"
        Else
            cClubcard.title_code = "Unknown"
        End If


        If OptRace1.Checked = True Then
            cClubcard.race_code = "1"
        ElseIf OptRace2.Checked = True Then
            cClubcard.race_code = "3"
        ElseIf OptRace3.Checked = True Then
            cClubcard.race_code = "2"
        ElseIf OptRace4.Checked = True Then
            cClubcard.race_code = "4"
        Else
            cClubcard.race_code = "0"
        End If




        cClubcard.number_of_household_members = Trim(Txtfamilymember.Text)
        If OptID1.Checked = True Then
            cClubcard.expat = "0"
        ElseIf OptID2.Checked = True Then
            cClubcard.expat = "1"
        Else
            If (Asc(Mid(Trim(TxtName.Text), 1, 1)) >= 65 And Asc(Mid(Trim(TxtName.Text), 1, 1)) <= 90) Then
                cClubcard.expat = "1"
            ElseIf (Asc(Mid(Trim(TxtName.Text), 1, 1)) >= 97 And Asc(Mid(Trim(TxtName.Text), 1, 1)) <= 122) Then
                cClubcard.expat = "1"
            Else
                cClubcard.expat = "0"
            End If
        End If



        If OptFormtype1.Checked = True Then
            cClubcard.form_type = "1"
        ElseIf OptFormtype2.Checked = True Then
            cClubcard.Flag = "2"
        End If

        If Trim(TxtPrimarycard1.Text) = Trim(TxtClubcard.Text) And cClubcard.form_type = "2" Then
            cClubcard.form_type = "1"
            cClubcard.ADJUST_FLAG = "FORMTYPE"
        ElseIf Trim(TxtPrimarycard1.Text) <> "" And Trim(TxtPrimarycard1.Text) <> Trim(TxtClubcard.Text) And cClubcard.form_type = "1" Then
            cClubcard.form_type = "2"
            cClubcard.ADJUST_FLAG = "FORMTYPE"
        Else : cClubcard.ADJUST_FLAG = ""
        End If

        If gFormName = "KEYIN" Then
            cClubcard.Flag = "KEYIN"
        ElseIf gFormName = "QC" Then
            cClubcard.Flag = "QC"
        End If
    End Function

    Private Sub TxtPrimarycard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrimarycard1.TextChanged
        OptFormtype2.Checked = True

        If Len(TxtPrimarycard1.Text) = 4 Then
            TxtPrimarycard2.SelectAll()
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        Dim TypeOfLanguage = New System.Globalization.CultureInfo("TH") ' or "fa-IR" for Farsi(Iran) 
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged

    End Sub

    Private Sub TxtSurname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSurname.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtSurname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSurname.TextChanged

    End Sub

    Private Sub Txtpostcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtpostcode.TextChanged

    End Sub

    Private Sub TxtHomeID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHomeID.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtHomeID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHomeID.TextChanged

    End Sub

    Private Sub TxtBuliding_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuliding.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtBuliding_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuliding.TextChanged

    End Sub

    Private Sub TxtRoom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRoom.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtRoom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRoom.TextChanged

    End Sub

    Private Sub TxtFloor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFloor.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtFloor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFloor.TextChanged

    End Sub

    Private Sub TxtMou_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMou.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtMou_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMou.TextChanged

    End Sub

    Private Sub TxtSoi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then   ' On enter I planned to add it the list
            If Not lstSoi.Contains(TxtSoi.Text) Then  ' If item not present already
                ' Add to the source directly
                TxtSoi.AutoCompleteCustomSource.Add(TxtSoi.Text)
            End If
            SendKeys.Send(vbTab)
        ElseIf e.KeyCode = Keys.Delete Then 'On delete key, planned to remove entry

            ' declare a dummy source
            Dim coll As AutoCompleteStringCollection = TxtStreet.AutoCompleteCustomSource

            ' remove item from new source
            coll.Remove(TxtSoi.Text)

            ' Bind the updates
            TxtSoi.AutoCompleteCustomSource = coll

            ' Clear textbox
            TxtSoi.Clear()

        End If
    End Sub

    Private Sub TxtSoi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtSoi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtStreet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStreet.KeyDown
        If e.KeyCode = Keys.Enter Then   ' On enter I planned to add it the list
            If Not lststreet.Contains(TxtStreet.Text) Then  ' If item not present already
                ' Add to the source directly
                TxtStreet.AutoCompleteCustomSource.Add(TxtStreet.Text)
            End If
            SendKeys.Send(vbTab)
        ElseIf e.KeyCode = Keys.Delete Then 'On delete key, planned to remove entry

            ' declare a dummy source
            Dim coll As AutoCompleteStringCollection = TxtStreet.AutoCompleteCustomSource

            ' remove item from new source
            coll.Remove(TxtStreet.Text)

            ' Bind the updates
            TxtStreet.AutoCompleteCustomSource = coll

            ' Clear textbox
            TxtStreet.Clear()

        End If
    End Sub

    Private Sub TxtStreet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStreet.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtStreet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStreet.TextChanged

    End Sub

    Private Sub TxtTumbol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTumbol.KeyDown
        If e.KeyCode = Keys.Enter Then   ' On enter I planned to add it the list
            If Not lsttumbol.Contains(TxtTumbol.Text) Then  ' If item not present already
                ' Add to the source directly
                TxtTumbol.AutoCompleteCustomSource.Add(TxtTumbol.Text)
            End If
            SendKeys.Send(vbTab)
        ElseIf e.KeyCode = Keys.Delete Then 'On delete key, planned to remove entry

            ' declare a dummy source
            Dim coll As AutoCompleteStringCollection = TxtTumbol.AutoCompleteCustomSource

            ' remove item from new source
            coll.Remove(TxtTumbol.Text)

            ' Bind the updates
            TxtTumbol.AutoCompleteCustomSource = coll

            ' Clear textbox
            TxtTumbol.Clear()

        End If
    End Sub

    Private Sub TxtTumbol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTumbol.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
                'CmbProvince.Focus()


        End Select
    End Sub

    Private Sub TxtTumbol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTumbol.TextChanged

    End Sub

    Private Sub CmbProvince_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbProvince.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)


        End Select


    End Sub




    Private Sub CmbProvince_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProvince.SelectedIndexChanged
        CmbAmper.Text = ""
        CmbAmper.Items.Clear()
        If CmbProvince.SelectedIndex = -1 Then Exit Sub



        Dim sql As String
        Dim rs As Data.DataSet
        Dim I As Integer

        sql = " SELECT PROVINCE_CODE " & _
                   " FROM TBL_AMPER WITH (NOLOCK) WHERE PROVINCE_TEXT = '" & Trim(CmbProvince.Text) & "' "

        rs = New Data.DataSet

        If cConnect.OpenSql(sql, rs) = False Then
            Exit Sub
        End If

        If rs.Tables(0).Rows.Count < 1 Then

            TxtProvincecode.Text = "-1"
            Exit Sub
        Else
            TxtProvincecode.Text = rs.Tables(0).Rows(I)("PROVINCE_CODE").ToString

        End If





        sql = "SELECT AMPER_TEXT ,POSTCODE FROM TBL_AMPER WITH (NOLOCK)  " & _
        " WHERE PROVINCE_TEXT = '" & Trim(CmbProvince.Text) & "'  " & _
        " ORDER BY AMPER_TEXT "
        rs = New Data.DataSet

        If cConnect.OpenSql(sql, rs) = False Then
            Exit Sub
        End If

        If rs.Tables(0).Rows.Count < 1 Then

            Exit Sub
        End If


        CmbAmper.Items.Clear()
        Txtpostcode.Text = ""
        For I = 0 To rs.Tables(0).Rows.Count - 1
            CmbAmper.Items.Add(rs.Tables(0).Rows(I)("AMPER_TEXT").ToString)
        Next




    End Sub

    Private Sub CmbAmper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbAmper.KeyPress, Cmbemail2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub CmbAmper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAmper.SelectedIndexChanged
        If CmbAmper.SelectedIndex = -1 Then Exit Sub





        Dim sql As String
        Dim rs As Data.DataSet
        Dim I As Integer


        sql = "SELECT AMPER_TEXT ,POSTCODE FROM TBL_AMPER WITH (NOLOCK) " & _
        " WHERE PROVINCE_TEXT = '" & Trim(CmbProvince.Text) & "'  " & _
        " AND  AMPER_TEXT = '" & Trim(CmbAmper.Text) & "' "

        rs = New Data.DataSet

        If cConnect.OpenSql(sql, rs) = False Then
            Exit Sub
        End If

        If rs.Tables(0).Rows.Count < 1 Then
            Exit Sub
        End If


        Txtpostcode.Text = rs.Tables(0).Rows(I)("POSTCODE").ToString


    End Sub

    Private Sub CmbCountry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCountry.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub CmbCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCountry.SelectedIndexChanged

    End Sub

    Private Sub TxtProvince_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProvince.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub TxtProvince_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProvince.TextChanged

    End Sub

    Private Sub Txtamper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtamper.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Txtamper_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtamper.TextChanged

    End Sub

    Private Sub Txtfamilymember_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtfamilymember.TextChanged

    End Sub

    Private Sub Txtfamilydob1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtfamilydob1.TextChanged

    End Sub

    Private Sub ChkProvince_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkProvince.CheckedChanged
        If ChkProvince.Checked = True Then
            TxtProvince.Enabled = True
            Txtamper.Enabled = True
        ElseIf ChkProvince.Checked = False Then
            TxtProvince.Enabled = False
            Txtamper.Enabled = False

        End If
    End Sub

    Private Sub Txtemail1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtemail1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Txtemail1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtemail1.TextChanged

    End Sub

    Private Sub Txtemail2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Txtemail2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub setcombo()


        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer

        sql = " SELECT PROVINCE_CODE, PROVINCE_TEXT  " & _
            " FROM TBL_AMPER WITH (NOLOCK) GROUP BY PROVINCE_CODE, PROVINCE_TEXT order by   PROVINCE_TEXT "



        rs1 = New Data.DataSet
        CmbProvince.Items.Clear()
        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    CmbProvince.Items.Add(Trim(rs1.Tables(0).Rows(x)("PROVINCE_TEXT").ToString))
                Next x
            End If
        End If


        CmbCountry.Items.Clear()
        CmbCountry.Items.Add("ไทย")
        CmbCountry.Items.Add("Laos")
        CmbCountry.Items.Add("Cambodia")
        CmbCountry.Items.Add("Myanmar")
        CmbCountry.Items.Add("Malaysia")
        CmbCountry.Items.Add("Others")


        Cmbemail2.Items.Clear()
        Cmbemail2.Items.Add("")
        Cmbemail2.Items.Add("hotmail.com")
        Cmbemail2.Items.Add("hotmail.co.th")
        Cmbemail2.Items.Add("windowslive.com")
        Cmbemail2.Items.Add("yahoo.com")
        Cmbemail2.Items.Add("yahoo.co.th")
        Cmbemail2.Items.Add("gmail.com")
        Cmbemail2.Items.Add("msn.com")
        Cmbemail2.Items.Add("msn.co.th")



        'auto completed textbox

        sql = " SELECT TUMBOL   " & _
            " FROM TBL_MEMBER_CLUBCARD WITH (NOLOCK) GROUP BY TUMBOL order by   TUMBOL "



        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    lsttumbol.Add(Trim(rs1.Tables(0).Rows(x)("TUMBOL").ToString))
                Next x
            End If
        End If

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lsttumbol.ToArray)

        'this AutocompleteStringcollection binded to the textbox as custom
        'source.
        TxtTumbol.AutoCompleteCustomSource = MySource

        'Auto complete mode set to suggest append so that it will sugesst one
        'or more suggested completion strings it has bith ‘Suggest’ and
        '‘Append’ functionality
        TxtTumbol.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        'Set to Custom source we have filled already
        TxtTumbol.AutoCompleteSource = AutoCompleteSource.CustomSource



        ''''''street


        sql = " SELECT STREET   " & _
            " FROM TBL_MEMBER_CLUBCARD  WITH (NOLOCK) GROUP BY STREET order by   STREET "



        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    lsttumbol.Add(Trim(rs1.Tables(0).Rows(x)("STREET").ToString))
                Next x
            End If
        End If

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lsttumbol.ToArray)

        'this AutocompleteStringcollection binded to the textbox as custom
        'source.
        TxtStreet.AutoCompleteCustomSource = MySource

        'Auto complete mode set to suggest append so that it will sugesst one
        'or more suggested completion strings it has bith ‘Suggest’ and
        '‘Append’ functionality
        TxtStreet.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        'Set to Custom source we have filled already
        TxtStreet.AutoCompleteSource = AutoCompleteSource.CustomSource




        'soi


        ''''''street


        sql = " SELECT SOI   " & _
            " FROM TBL_MEMBER_CLUBCARD WITH (NOLOCK)  where SOI <>'' and not(SOI is null) GROUP BY SOI order by   SOI "



        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    lstSoi.Add(Trim(rs1.Tables(0).Rows(x)("SOI").ToString))
                Next x
            End If
        End If


        txtsoi.AutoCompleteCustomSource = MySource
        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lstSoi.ToArray)

        'this AutocompleteStringcollection binded to the textbox as custom
        'source.
        txtsoi.AutoCompleteCustomSource = MySource

        'Auto complete mode set to suggest append so that it will sugesst one
        'or more suggested completion strings it has bith ‘Suggest’ and
        '''Append’ functionality
        txtsoi.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        'Set to Custom source we have filled already
        txtsoi.AutoCompleteSource = AutoCompleteSource.CustomSource

        'end auto completed textbox
        'end auto completed textbox

    End Sub







    Private Sub OptMR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptMR.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            'Case 9
            '    OptMs.Focus()
            '    OptMs.Checked = False
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptMRS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptMRS.CheckedChanged

    End Sub

    Private Sub OptMRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptMRS.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
                'Case 9
                '    OptMRS.Focus()
                '    OptMRS.Checked = False
        End Select
    End Sub

    Private Sub OptMs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptMs.CheckedChanged

    End Sub

    Private Sub OptMs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptMs.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
                'Case 9
                '    OptUNTITLE.Focus()
                '    OptUNTITLE.Checked = False
        End Select
    End Sub

    Private Sub OptUNTITLE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptUNTITLE.CheckedChanged

    End Sub

    Private Sub OptUNTITLE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptUNTITLE.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptHome1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptHome1.CheckedChanged

    End Sub

    Private Sub OptHome1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptHome1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptHome2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptHome2.CheckedChanged

    End Sub

    Private Sub OptHome2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptHome2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptHome3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptHome3.CheckedChanged

    End Sub

    Private Sub OptHome3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptHome3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptID1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptID1.CheckedChanged

    End Sub

    Private Sub OptID1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptID1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptID2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptID2.CheckedChanged, OptID3.CheckedChanged

    End Sub

    Private Sub OptID2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptID2.KeyPress, OptID3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptRace1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRace1.CheckedChanged

    End Sub

    Private Sub OptRace1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptRace1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptRace2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRace2.CheckedChanged

    End Sub

    Private Sub OptRace2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptRace2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptRace3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRace3.CheckedChanged

    End Sub

    Private Sub OptRace3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptRace3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub OptRace4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRace4.CheckedChanged, OptRace0.CheckedChanged

    End Sub

    Private Sub OptRace4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptRace4.KeyPress, OptRace0.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Optbusiness1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Optbusiness1.CheckedChanged

    End Sub

    Private Sub Optbusiness1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Optbusiness1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Optbusiness2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Optbusiness2.CheckedChanged

    End Sub

    Private Sub Optbusiness2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Optbusiness2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Optbusiness3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Optbusiness3.CheckedChanged

    End Sub

    Private Sub Optbusiness3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Optbusiness3.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Optbusiness4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Optbusiness4.CheckedChanged

    End Sub

    Private Sub Optbusiness4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Optbusiness4.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Optbusiness5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Optbusiness5.CheckedChanged

    End Sub

    Private Sub Optbusiness5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Optbusiness5.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub

    Private Sub Optbusiness6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Optbusiness6.CheckedChanged

    End Sub

    Private Sub Optbusiness6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Optbusiness6.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)

        End Select
    End Sub
    Private Sub settextbox()
        Dim i As Integer



        TxtName.Text = RSNEW.Tables(0).Rows(0)("NAME_1").ToString
        TxtSurname.Text = RSNEW.Tables(0).Rows(0)("NAME_2").ToString
        If RSNEW.Tables(0).Rows(0)("IDTYPE").ToString = OptID1.Text Then
                OptID1.Checked = True
            TxtID1.Text = Mid(RSNEW.Tables(0).Rows(0)("OFFICIAL_ID").ToString, 1, 1)
            TxtID2.Text = Mid(RSNEW.Tables(0).Rows(0)("OFFICIAL_ID").ToString, 2, 4)
            TxtID3.Text = Mid(RSNEW.Tables(0).Rows(0)("OFFICIAL_ID").ToString, 6, 5)
            TxtID4.Text = Mid(RSNEW.Tables(0).Rows(0)("OFFICIAL_ID").ToString, 11, 2)
            TxtID5.Text = Mid(RSNEW.Tables(0).Rows(0)("OFFICIAL_ID").ToString, 13, 1)
        ElseIf RSNEW.Tables(0).Rows(0)("IDTYPE").ToString = OptID2.Text Then
            OptID2.Checked = True
            TxtID6.Text = RSNEW.Tables(0).Rows(0)("OFFICIAL_ID").ToString
        Else
            OptID1.Checked = False
            OptID2.Checked = False
            TxtID1.Text = ""
            TxtID2.Text = ""
            TxtID3.Text = ""
            TxtID4.Text = ""
            TxtID5.Text = ""
            TxtID6.Text = ""
        End If



        If RSNEW.Tables(0).Rows(0)("FORM_TYPE").ToString = 1 Then
            OptFormtype1.Checked = True
            TxtPrimarycard1.Text = ""
            TxtPrimarycard2.Text = ""
            TxtPrimarycard3.Text = ""
        Else
            OptFormtype2.Checked = True
            TxtPrimarycard1.Text = Trim(Mid(RSNEW.Tables(0).Rows(0)("PRIMARY_CARD_ACCOUNT_NUMBER").ToString, 8, 4))
            TxtPrimarycard2.Text = Trim(Mid(RSNEW.Tables(0).Rows(0)("PRIMARY_CARD_ACCOUNT_NUMBER").ToString, 12, 4))
            TxtPrimarycard3.Text = Trim(Mid(RSNEW.Tables(0).Rows(0)("PRIMARY_CARD_ACCOUNT_NUMBER").ToString, 16, 3))

        End If


        Dim BD1 As DateTime
        Dim BD2 As String


        BD1 = RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_1_DOB").ToString
        BD2 = BD1.ToString("yyyy-MM-dd")
        If BD2 = "1900-01-01" Then
            TxtBD1.Text = ""
            TxtBD2.Text = ""
            TxtBD3.Text = ""
        Else

            TxtBD1.Text = Mid(BD2, 9, 2)
            TxtBD2.Text = Mid(BD2, 6, 2)
            TxtBD3.Text = Mid(BD2, 1, 4) + 543
        End If


        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_2_DOB").ToString) And RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_2_DOB").ToString <> "" And Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_2_DOB").ToString) <> "1900" Then
            Txtfamilydob1.Text = gCurrentYear - Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_2_DOB").ToString)
        Else
            Txtfamilydob1.Text = ""
        End If

        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_3_DOB").ToString) And RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_3_DOB").ToString <> "" And Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_3_DOB").ToString) <> "1900" Then
            Txtfamilydob2.Text = gCurrentYear - Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_3_DOB").ToString)
        Else
            Txtfamilydob2.Text = ""
        End If

        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_4_DOB").ToString) And RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_4_DOB").ToString <> "" And Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_4_DOB").ToString) <> "1900" Then
            Txtfamilydob3.Text = gCurrentYear - Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_4_DOB").ToString)
        Else
            Txtfamilydob3.Text = ""
        End If

        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_5_DOB").ToString) And RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_5_DOB").ToString <> "" And Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_5_DOB").ToString) <> "1900" Then
            Txtfamilydob4.Text = gCurrentYear - Year(RSNEW.Tables(0).Rows(0)("FAMILY_MEMBER_5_DOB").ToString)
        Else
            Txtfamilydob4.Text = ""
        End If

        TxtHomeID.Text = (RSNEW.Tables(0).Rows(0)("HOME_ID").ToString)


        If RSNEW.Tables(0).Rows(0)("BUILDING_TYPE").ToString = OptHome1.Text Then
            OptHome1.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("BUILDING_TYPE").ToString = OptHome2.Text Then
            OptHome2.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("BUILDING_TYPE").ToString = OptHome3.Text Then
            OptHome3.Checked = True
        Else
            OptHome1.Checked = False
            OptHome2.Checked = False
            OptHome3.Checked = False
        End If

        TxtBuliding.Text = RSNEW.Tables(0).Rows(0)("BUILDING").ToString
        TxtRoom.Text = RSNEW.Tables(0).Rows(0)("ROOM_NO").ToString
        TxtFloor.Text = RSNEW.Tables(0).Rows(0)("FLOOR").ToString
        TxtMou.Text = RSNEW.Tables(0).Rows(0)("MOU").ToString
        TxtSoi.Text = RSNEW.Tables(0).Rows(0)("SOI").ToString
        TxtStreet.Text = RSNEW.Tables(0).Rows(0)("STREET").ToString
        TxtTumbol.Text = RSNEW.Tables(0).Rows(0)("TUMBOL").ToString


        'cClubcard.address_line_1").tostring =  ""
        'cClubcard.address_line_2").tostring =  ""
        'cClubcard.address_line_3").tostring =  "" 
        ChkCombo(CmbProvince, Trim(RSNEW.Tables(0).Rows(0)("province").ToString))
        If CmbProvince.SelectedIndex = -1 Then
            TxtProvince.Text = RSNEW.Tables(0).Rows(0)("province").ToString
            TxtProvince.Enabled = True
            ChkProvince.Checked = True
        Else
            TxtProvince.Enabled = False
            ChkProvince.Checked = False
        End If
        ChkCombo(CmbAmper, Trim(RSNEW.Tables(0).Rows(0)("city").ToString))
        If CmbAmper.SelectedIndex = -1 Then
            Txtamper.Text = RSNEW.Tables(0).Rows(0)("city").ToString
            Txtamper.Enabled = True
        Else
            Txtamper.Enabled = False
        End If



        ChkCountry(CmbCountry, Trim(RSNEW.Tables(0).Rows(0)("COUNTRY").ToString))

        Txtpostcode.Text = RSNEW.Tables(0).Rows(0)("POSTAL_CODE").ToString
        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString) And RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString <> "" And RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString <> "-" Then
            TxtOfficetel1.Text = Mid(RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString, 1, InStr(RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString, "-") - 1)
            TxtOfficetel2.Text = Mid(RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString, InStr(RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString, "-") + 1, 3)
            TxtOfficetel3.Text = Mid(RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString, InStr(RSNEW.Tables(0).Rows(0)("daytime_phone_number").ToString, "-") + 4, 4)
        End If

        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString) And RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString <> "" And RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString <> "-" Then
            TxtHometel1.Text = Mid(RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString, 1, InStr(RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString, "-") - 1)
            TxtHometel2.Text = Mid(RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString, InStr(RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString, "-") + 1, 3)
            TxtHometel3.Text = Mid(RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString, InStr(RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString, "-") + 4, 4)
        End If


        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("mobile_phone_number").ToString) And RSNEW.Tables(0).Rows(0)("mobile_phone_number").ToString <> "" And RSNEW.Tables(0).Rows(0)("evening_phone_number").ToString <> "-" Then
            TxtMobileTel1.Text = Mid(RSNEW.Tables(0).Rows(0)("mobile_phone_number").ToString, 1, 3)
            TxtMobileTel2.Text = Mid(RSNEW.Tables(0).Rows(0)("mobile_phone_number").ToString, 5, 3)
            TxtMobileTel3.Text = Mid(RSNEW.Tables(0).Rows(0)("mobile_phone_number").ToString, 8, 4)
        End If

        If Not IsDBNull(RSNEW.Tables(0).Rows(0)("email_address").ToString) And RSNEW.Tables(0).Rows(0)("email_address").ToString <> "" And RSNEW.Tables(0).Rows(0)("email_address").ToString <> "-" Then
            Txtemail1.Text = Mid(RSNEW.Tables(0).Rows(0)("email_address").ToString, 1, InStr(RSNEW.Tables(0).Rows(0)("email_address").ToString, "@") - 1)
            Cmbemail2.Text = Trim(Mid(RSNEW.Tables(0).Rows(0)("email_address").ToString, InStr(RSNEW.Tables(0).Rows(0)("email_address").ToString, "@") + 1, 100))
        End If



        If RSNEW.Tables(0).Rows(0)("business_type_code").ToString = ("0") Then
            Optbusiness1.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("business_type_code").ToString = ("1") Then
            Optbusiness2.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("business_type_code").ToString = ("2") Then
            Optbusiness3.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("business_type_code").ToString = ("3") Then
            Optbusiness4.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("business_type_code").ToString = ("4") Then
            Optbusiness5.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("business_type_code").ToString = ("6") Then
            Optbusiness6.Checked = True
        Else
            Optbusiness1.Checked = True
        End If


        If RSNEW.Tables(0).Rows(0)("title_code").ToString = ("Mr") Then
            OptMR.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("title_code").ToString = ("Ms") Then
            OptMs.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("title_code").ToString = ("Mrs") Then
            OptMRS.Checked = True
        Else
            OptUNTITLE.Checked = True
        End If


        If RSNEW.Tables(0).Rows(0)("race_code").ToString = ("1") Then
            OptRace1.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("race_code").ToString = ("3") Then
            OptRace2.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("race_code").ToString = ("2") Then
            OptRace3.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("race_code").ToString = ("4") Then
            OptRace4.Checked = True
        ElseIf RSNEW.Tables(0).Rows(0)("race_code").ToString = ("0") Then
            OptRace0.Checked = True
        Else
            OptRace1.Checked = False
            OptRace2.Checked = False
            OptRace3.Checked = False
            OptRace4.Checked = False
        End If


        If RSNEW.Tables(0).Rows(0)("number_of_household_members").ToString = "0" Then
            Txtfamilymember.Text = ""
        Else
            Txtfamilymember.Text = RSNEW.Tables(0).Rows(0)("number_of_household_members").ToString
        End If


        Dim CRD1 As DateTime
        Dim CRD2 As String


        CRD1 = RSNEW.Tables(0).Rows(0)("CUSTOMER_CREATED_DATE").ToString
        CRD2 = CRD1.ToString("yyyy-MM-dd")
        Txtdate.Text = ChangeEngDateToThaiDate(CRD2)


    End Sub

    Public Function ChkCombo(ByVal objCombo As ComboBox, ByVal TextToFind As String) As Boolean
        Dim NumOfItems As Object 'The Number Of Items In ComboBox
        Dim IndexNum As Integer 'Index
        'objCombo.SelectedIndex = IndexNum

        NumOfItems = objCombo.Items.Count
        For IndexNum = 0 To NumOfItems - 1


            'Debug.Print(Trim(Mid(CmbStore.Text, InStr(CmbStore.Text, "|") + 1, 20)))

            If objCombo.Items(IndexNum).ToString = TextToFind Then



                'If InStr(objCombo.Items(IndexNum).ToString, TextToFind) <> 0 Then
                objCombo.SelectedIndex = IndexNum
                ChkCombo = True
                Exit Function
            End If
        Next IndexNum
        objCombo.SelectedIndex = -1
        ChkCombo = False
    End Function

    Public Function ChkCountry(ByVal objCombo As ComboBox, ByVal TextToFind As String) As Boolean
        Dim NumOfItems As Object 'The Number Of Items In ComboBox
        Dim IndexNum As Integer 'Index
        'objCombo.SelectedIndex = IndexNum

        NumOfItems = objCombo.Items.Count
        For IndexNum = 0 To NumOfItems - 1


            'Debug.Print(Trim(Mid(CmbStore.Text, InStr(CmbStore.Text, "|") + 1, 20)))

            If Trim(objCombo.Items(IndexNum).ToString) = TextToFind Then



                'If InStr(objCombo.Items(IndexNum).ToString, TextToFind) <> 0 Then
                objCombo.SelectedIndex = IndexNum
                ChkCountry = True
                Exit Function
            End If
        Next IndexNum
        objCombo.SelectedIndex = -1
        ChkCountry = False
    End Function

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click

        If gFormName = "QUERY" Then
            Me.Close()
            FrmQuery.MdiParent = FrmMain
            FrmQuery.Parent = FrmMain.PnlDisplay
            FrmQuery.Dock = DockStyle.Fill
            FrmQuery.Show()
            FrmQuery.TxtClubcard.Text = cClubcard.CLUBCARD_NO

        Else
            Me.Close()
            FrmMain.Show()
            FrmMain.Mnuenable()
        End If

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        Call clrForm()
        FraKEYIN.Visible = False
        TxtClubcard.Text = ""
        TxtClubcard.Focus()
    End Sub



    Private Sub TxtPrimarycard2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrimarycard2.TextChanged
        If Len(TxtPrimarycard2.Text) = 4 Then
            TxtPrimarycard3.SelectAll()
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub TxtPrimarycard3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrimarycard3.LostFocus
        If TxtPrimarycard1.Text = "" Or TxtPrimarycard2.Text = "" Or TxtPrimarycard3.Text = "" Then
            Exit Sub
        End If

        If Len("6340091" & TxtPrimarycard1.Text & TxtPrimarycard2.Text & TxtPrimarycard3.Text) <> 18 Then
            MsgBox("เลขบัตรเดิมไม่ครบ 18 หลัก", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If CheckDigit("6340091" & TxtPrimarycard1.Text & TxtPrimarycard2.Text & TxtPrimarycard3.Text) = False Then
            MsgBox("เลขบัตรเดิมไม่ถูกต้อง", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub TxtPrimarycard3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrimarycard3.TextChanged
        If Len(TxtPrimarycard3.Text) = 3 Then

            SendKeys.Send(vbTab)

        End If
    End Sub
    Private Sub SAVEDATA()


        Call SetClubcardValue()

        If gFormName = "KEYIN" Then

            If LblFlag.Text = "NEW" Then
                If cClubcard.UpdateKEYINClubcard = False Then
                    MsgBox("Error update to Keyin")
                    Exit Sub
                End If
            ElseIf LblFlag.Text = "KEYIN" Then
                If cClubcard.EditKEYINClubcard = False Then
                    MsgBox("Error update to Keyin")
                    Exit Sub
                End If

            End If

            Call SelectKeyin()
        ElseIf gFormName = "QC" Then

            If LblFlag.Text = "KEYIN" Then

                If cClubcard.KeepHistory = False Then
                    MsgBox("Error Keep History")
                    Exit Sub
                End If

                If cClubcard.UpdateQCClubcard = False Then
                    MsgBox("Error update to Keyin")
                    Exit Sub
                End If

            ElseIf LblFlag.Text = "QC" Then
                If cClubcard.KeepHistory = False Then
                    MsgBox("Error Keep History")
                    Exit Sub
                End If

                If cClubcard.EditQCClubcard = False Then
                    MsgBox("Error update to QC")
                    Exit Sub
                End If
            End If
            Call SelectQC()
        End If

        FraKEYIN.Visible = False
        Call clrForm()

        TxtClubcard.Text = ""
        TxtClubcard.Focus()
    End Sub

    Private Sub OptFormtype1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptFormtype1.CheckedChanged

    End Sub

    Private Sub OptFormtype1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OptFormtype1.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                OptUNTITLE.Focus()

        End Select
    End Sub

    Private Sub TxtSoi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class