
Option Strict Off
Option Explicit On

Public Class FrmCounting

    Dim MAILBAGADD As Boolean


    Dim STOREADD As Boolean
    Dim rsapp As Data.DataSet


    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub

    Private Sub FrmWeek_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CalGetSystemDate() ' ดึงค่าวันปัจจุบันใส่ปฏิทิน
        Call settoolbarload()
        Call setcombo()


    End Sub



    Private Sub settoolbarload()
        CmdNew.Enabled = True
        CmdAdd.Enabled = True
        CmdEdit.Enabled = False
        CmdDelete.Enabled = False

    End Sub


    Private Sub settoolbaredit()
        CmdNew.Enabled = True
        CmdAdd.Enabled = False
        CmdEdit.Enabled = True
        CmdDelete.Enabled = True

    End Sub
    Private Sub SearchMailbag()
        Dim sql As String
        Dim rs1 As Data.DataSet

        rs1 = New Data.DataSet

        cMailbag.WKCYCLE_ID = ""
        cMailbag.DCNAME = ""
        cMailbag.StoreID = ""

        If Cmbweek.Text = "" Then
            MsgBox("ยังไม่ได้เลือก Week")
            Exit Sub
        End If

        If CmbDC.Text = "" Then
            MsgBox("ยังไม่ได้เลือก DC")
            Exit Sub
        End If

        If CmbStore.Text = "" Then
            MsgBox("ยังไม่ได้เลือก Store ")
            Exit Sub
        End If


        cMailbag.WKCYCLE_ID = Cmbweek.Tag
        cMailbag.DCNAME = CmbDC.Text
        cMailbag.StoreID = TxtStoreId.Text



        If cMailbag.SELECTMAILBAG(rs1) = False Then
            MsgBox("ไม่พบข้อมูลที่ต้องการ")
            Exit Sub
        End If

        Datagridview1.AutoGenerateColumns = True
        Datagridview1.DataSource = rs1.Tables(0)
        Datagridview1.Refresh()
        Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        Call selectapp()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim rs1 As New Data.DataSet


        cMailbag.WKCYCLE_ID = ""
        cMailbag.DCNAME = ""
        cMailbag.StoreID = ""
        cMailbag.MailbagNumber = ""
        cMailbag.SealNo = ""
        cMailbag.EnvelopeNo = ""
        cMailbag.AppInform = ""
        cMailbag.NoBarcodeApp = ""
        cMailbag.DateFrontLetter = ""

        If Cmbweek.Text = "" Then
            MsgBox("ยังไม่ได้เลือก Week")
            Exit Sub
        End If

        If CmbDC.Text = "" Then
            MsgBox("ยังไม่ได้เลือก DC")
            Exit Sub
        End If

        If CmbStore.Text = "" Then
            MsgBox("ยังไม่ได้เลือก Store ")
            Exit Sub
        End If



        If CmbMailbag.Text = "" Then
            MsgBox("ยังไม่ได้กรอกเลขที่ Mailbag ")
            Exit Sub
        End If

        If TxtSeal.Text = "" Then
            MsgBox("ยังไม่ได้กรอก Seal No ")
            Exit Sub
        End If

        If CmbEnvelope.Text = "" Then
            MsgBox("ยังไม่ได้กรอก Envelope")
            Exit Sub
        End If

        If TxtApp.Text = "" Then
            MsgBox("ยังไม่ได้กรอก App Inform ")
            Exit Sub
        End If

        If TxtNobc.Text = "" Then
            MsgBox("ยังไม่ได้กรอก No Barcode App ")
            Exit Sub
        End If

        If TxtDate.Text = "" Then
            MsgBox("ยังไม่ได้เลือกวันที่หน้าซอง")
            Exit Sub
        End If

        cMailbag.WKCYCLE_ID = Cmbweek.Tag
        cMailbag.DCNAME = CmbDC.Text
        cMailbag.StoreID = TxtStoreId.Text

        cMailbag.MailbagNumber = Trim(CmbMailbag.Text)
        cMailbag.SealNo = Trim(TxtSeal.Text)
        cMailbag.EnvelopeNo = Trim(CmbEnvelope.Text)
        cMailbag.AppInform = Trim(TxtApp.Text)
        cMailbag.NoBarcodeApp = Trim(TxtNobc.Text)
        cMailbag.DateFrontLetter = ChangeThaiDateToEngDate(TxtDate.Text)

        If cMailbag.CHKDUPMAILBAG(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้ มีข้อมูลอยู่ในระบบแล้ว")
                Call ClrTextbox()

                Datagridview1.AutoGenerateColumns = True
                Datagridview1.DataSource = rs1.Tables(0)
                Datagridview1.Refresh()
                Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Exit Sub
            End If
        Else
            MsgBox("ไม่สามารถเพิ่มข้อมูลได้ มีข้อมูลอยู่ในระบบแล้ว")
            Exit Sub

        End If

        If cMailbag.INSERTMAILBAG = True Then
            MsgBox("Data Added")
            Call SearchMailbag()
        Else
            MsgBox("ไม่สามารถ Add ข้อมูลได้กรุณาติดต่อ IT")
        End If
        Call ClrTextbox()
        Call settoolbarload()

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        ClrTextbox()
        ClrGrid()
        settoolbarload()
    End Sub


    Private Sub ClrTextbox()
        cmbweek.tag = ""
        Cmbweek.SelectedIndex = -1
        TxtPickupDate.Text = ""
        CmbDC.SelectedIndex = -1
        TxtStoreId.Text = ""
        CmbStore.SelectedIndex = -1
        CmbMailbag.Text = ""
        TxtMailbagID.Text = ""
        TxtSeal.Text = ""
        CmbEnvelope.Text = ""
        TxtApp.Text = ""
        TxtNobc.Text = ""
        TxtDate.Text = ""

    End Sub

    Private Sub ClrGrid()

        Datagridview1.DataSource = Nothing
        Datagridview1.Refresh()

    End Sub

    Private Sub Datagridview1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellClick
        If Datagridview1.Rows.Count < 1 Then Exit Sub
        cClubcard.custid = ""
        cClubcard.custid = (Datagridview1.Rows.Item(e.RowIndex).Cells(0).Value.ToString)

        cClubcard.Flag = ""
        cClubcard.Flag = (Datagridview1.Rows.Item(e.RowIndex).Cells(5).Value.ToString)

        'Call Chkweekid(Cmbweek, Datagridview1.Rows.Item(e.RowIndex).Cells(1).Value.ToString)
        'Call ChkStoreID(CmbStore, Datagridview1.Rows.Item(e.RowIndex).Cells(3).Value.ToString)


        ''TxtPickupDate.Text = ""
        'CmbDC.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(2).Value.ToString)
        ''TxtStoreId.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(3).Value.ToString)
        ''CmbStore.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(4).Value.ToString)
        'CmbMailbag.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(4).Value.ToString)
        'TxtMailbagID.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(0).Value.ToString)
        'TxtSeal.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(5).Value.ToString)
        'CmbEnvelope.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(6).Value.ToString)
        'TxtApp.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(7).Value.ToString)
        'TxtNobc.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(8).Value.ToString)
        'TxtDate.Text = ChangeEngDateToThaiDate(Datagridview1.Rows.Item(e.RowIndex).Cells(9).Value.ToString)




        settoolbaredit()
    End Sub




    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Dim rs1 As New Data.DataSet

        If MsgBox("ยืนยันการแก้ไขข้อมูล", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If Trim(TxtMailbagID.Text) = "" Then
            MsgBox("ยังไม่ได้เลือกรายการที่ต้องการแก้ไข")
            Exit Sub
        End If


        cMailbag.WKCYCLE_ID = ""
        cMailbag.DCNAME = ""
        cMailbag.StoreID = ""
        cMailbag.MailbagNumber = ""
        cMailbag.SealNo = ""
        cMailbag.EnvelopeNo = ""
        cMailbag.AppInform = ""
        cMailbag.NoBarcodeApp = ""
        cMailbag.DateFrontLetter = ""

        If Cmbweek.Text = "" Then
            MsgBox("ยังไม่ได้เลือก Week")
            Exit Sub
        End If

        If CmbDC.Text = "" Then
            MsgBox("ยังไม่ได้เลือก DC")
            Exit Sub
        End If

        If CmbStore.Text = "" Then
            MsgBox("ยังไม่ได้เลือก Store ")
            Exit Sub
        End If



        If CmbMailbag.Text = "" Then
            MsgBox("ยังไม่ได้กรอกเลขที่ Mailbag ")
            Exit Sub
        End If

        If TxtSeal.Text = "" Then
            MsgBox("ยังไม่ได้กรอก Seal No ")
            Exit Sub
        End If

        If CmbEnvelope.Text = "" Then
            MsgBox("ยังไม่ได้กรอก Envelope")
            Exit Sub
        End If

        If TxtApp.Text = "" Then
            MsgBox("ยังไม่ได้กรอก App Inform ")
            Exit Sub
        End If

        If TxtNobc.Text = "" Then
            MsgBox("ยังไม่ได้กรอก No Barcode App ")
            Exit Sub
        End If

        If TxtDate.Text = "" Then
            MsgBox("ยังไม่ได้เลือกวันที่หน้าซอง")
            Exit Sub
        End If
        cMailbag.MailbagID = TxtMailbagID.Text
        cMailbag.WKCYCLE_ID = Cmbweek.Tag
        cMailbag.DCNAME = CmbDC.Text
        cMailbag.StoreID = TxtStoreId.Text

        cMailbag.MailbagNumber = Trim(CmbMailbag.Text)
        cMailbag.SealNo = Trim(TxtSeal.Text)
        cMailbag.EnvelopeNo = Trim(CmbEnvelope.Text)
        cMailbag.AppInform = Trim(TxtApp.Text)
        cMailbag.NoBarcodeApp = Trim(TxtNobc.Text)
        cMailbag.DateFrontLetter = ChangeThaiDateToEngDate(TxtDate.Text)


        If cMailbag.CHKDUPMAILBAG(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้ มีข้อมูลอยู่ในระบบแล้ว")
                Call ClrTextbox()

                Datagridview1.AutoGenerateColumns = True
                Datagridview1.DataSource = rs1.Tables(0)
                Datagridview1.Refresh()
                Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Exit Sub
            End If
        Else
            MsgBox("ไม่สามารถเพิ่มข้อมูลได้ มีข้อมูลอยู่ในระบบแล้ว")
            Exit Sub

        End If

        If cMailbag.UPDATEMAILBAG = True Then
            MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
            Call SearchMailbag()
        Else
            MsgBox("ไม่สามารถแก้ไขข้อมูลได้กรุณาติดต่อ IT")
        End If
        Call ClrTextbox()
        Call settoolbarload()
    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click
        Dim rs1 As New Data.DataSet

        If MsgBox("ยืนยันการลบข้อมูล", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If Trim(cClubcard.custid) = "" Then
            MsgBox("ยังไม่ได้เลือกรายการที่ต้องการลบ")
            Exit Sub
        End If


        If Trim(cClubcard.Flag) <> "NEW" And Trim(cClubcard.Flag) <> "DUPLICATE" And Trim(cClubcard.Flag) <> "INVALID" Then
            MsgBox("ไม่สามารถลบได้ รายการที่ลบได้ Flag จะต้องเป็น NEW , DUPLICATE หรือ INVALID เท่านั้น")
            Exit Sub
        End If
        Dim SQL As String

        SQL = "DELETE FROM TBL_MEMBER_CLUBCARD WHERE CUSTID = " & cClubcard.custid & " "

        cConnect.Execute(SQL)

        MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
        Call selectapp()

    End Sub


    Private Sub setcombo()



        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer

        sql = " SELECT  WEEKID ,  WEEKNO , CONVERT(VARCHAR(10), PICKUPDATE,20) AS PICKUPDATE FROM  TBL_WKCYCLE  WITH (NOLOCK) order by  WEEKNO DESC "



        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    Cmbweek.Items.Add(Trim(rs1.Tables(0).Rows(x)("WEEKNO").ToString) & "                   :" & Trim(rs1.Tables(0).Rows(x)("WEEKID").ToString) & "|" & Trim(rs1.Tables(0).Rows(x)("PICKUPDATE").ToString))
                Next x
            End If
        End If




        sql = " SELECT  DCNAME   FROM  TBL_DC WITH (NOLOCK)  "


        CmbDC.Items.Clear()
        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    CmbDC.Items.Add(Trim(rs1.Tables(0).Rows(x)("DCNAME").ToString))
                Next x
            End If
        End If


        STOREADD = False
        sql = " SELECT STOREID , STORENAME  FROM  TBL_STORE  WITH (NOLOCK) order by STORENAME "


        CmbStore.Items.Clear()
        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    CmbStore.Items.Add(Trim(rs1.Tables(0).Rows(x)("STORENAME").ToString) & "                                                                                     |" & Trim(rs1.Tables(0).Rows(x)("STOREID").ToString))
                Next x
            End If
        End If


        STOREADD = True

    End Sub

    Private Sub cmdCarlendar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCarlendar1.Click
        On Error GoTo error_Handler
        Dim d As String

        d = CALDateGet("") ' d format dd/mm/yyyy+543

        If d <> "" Then
            TxtDate.Text = d
        Else
            TxtDate.Text = ""
        End If

resume_err:
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "_" & "cmdCarlendar_Click", Err.Number, ErrorToString())
        GoTo resume_err
    End Sub
    Private Sub CmbStartweek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbweek.SelectedIndexChanged
        If Cmbweek.SelectedIndex = -1 Then Exit Sub
        Cmbweek.Tag = Trim(Mid(Cmbweek.Text, InStr(Cmbweek.Text, ":") + 1, InStr(Cmbweek.Text, "|") - InStr(Cmbweek.Text, ":") - 1))
        TxtPickupDate.Text = ChangeEngDateToThaiDate(Trim(Mid(Cmbweek.Text, InStr(Cmbweek.Text, "|") + 1, 100)))

        TxtPickupDate.Text = ""
        CmbDC.SelectedIndex = -1
        TxtStoreId.Text = ""
        CmbStore.SelectedIndex = -1
        CmbMailbag.SelectedIndex = -1
        TxtMailbagID.Text = ""
        TxtSeal.Text = ""
        CmbEnvelope.SelectedIndex = -1
        TxtApp.Text = ""
        TxtNobc.Text = ""
        TxtDate.Text = ""


    End Sub

    'Private Sub CmbStore_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbStore.KeyPress
    '    Dim KeyAscii As Short = Asc(e.KeyChar)
    '    Dim findString As String = String.Empty
    '    'Select Case KeyAscii
    '    '    Case 13
    '    If KeyAscii < 65 Or KeyAscii > 90 Then
    '        Exit Sub
    '    End If
    '    If KeyAscii < 161 Or KeyAscii > 205 Then
    '        Exit Sub
    '    End If
    '    TextBox1.Text = TextBox1.Text & Chr(KeyAscii)

    '    'ChkStorename(CmbStore, TxtStoreId.Text)
    '    'findString = TxtStoreId.Text
    '    'With CmbStore
    '    '    .SelectedIndex = CmbStore.FindString(findString)
    '    'End With
    '    'If CmbStore.SelectedIndex > -1 Then e.Handled = True

    '    '    Case Else

    '    'Exit Sub
    '    'End Select



    'End Sub

    Private Sub CmbStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbStore.SelectedIndexChanged



        If STOREADD = False Then Exit Sub

        If CmbStore.SelectedIndex = -1 Then Exit Sub



        CmbMailbag.SelectedIndex = -1
        TxtMailbagID.Text = ""
        TxtSeal.Text = ""
        CmbEnvelope.SelectedIndex = -1
        TxtApp.Text = ""
        TxtNobc.Text = ""
        TxtDate.Text = ""



        If CmbDC.Text = "" Then Exit Sub

        If Cmbweek.Text = "" Then Exit Sub

        If CmbStore.Text = "" Then Exit Sub

        TxtStoreId.Text = Trim(Mid(CmbStore.Text, InStr(CmbStore.Text, "|") + 1, 20))

        Dim sql As String
        Dim rs As Data.DataSet
        Dim I As Integer

        sql = "SELECT MAILBAGNUMBER FROM TBL_MAILBAG  WITH (NOLOCK)  " & _
        " WHERE   WKCYCLE_ID = " & Trim(Cmbweek.Tag) & "  " & _
        " AND   DCNAME = '" & CmbDC.Text & "'   " & _
        " AND   STOREID = " & Trim(TxtStoreId.Text) & "  " & _
        " GROUP BY  MAILBAGNUMBER  ORDER BY MAILBAGNUMBER "
        rs = New Data.DataSet

        If cConnect.OpenSql(sql, rs) = False Then
            Exit Sub
        End If

        If rs.Tables(0).Rows.Count < 1 Then
            Exit Sub
        End If


        CmbMailbag.Items.Clear()
        MAILBAGADD = False
        For I = 0 To rs.Tables(0).Rows.Count - 1
            CmbMailbag.Items.Add(rs.Tables(0).Rows(I)("MAILBAGNUMBER").ToString)
        Next

        MAILBAGADD = True
    End Sub

    Private Sub TxtStoreId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStoreId.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13


                ChkStoreID(CmbStore, TxtStoreId.Text)
                'findString = TxtStoreId.Text
                'With CmbStore
                '    .SelectedIndex = CmbStore.FindString(findString)
                'End With
                'If CmbStore.SelectedIndex > -1 Then e.Handled = True

            Case Else
                Exit Sub
        End Select





    End Sub


    Public Function ChkStoreID(ByVal objCombo As ComboBox, ByVal TextToFind As String) As Boolean
        Dim NumOfItems As Object 'The Number Of Items In ComboBox
        Dim IndexNum As Integer 'Index
        objCombo.SelectedIndex = IndexNum

        NumOfItems = objCombo.Items.Count
        For IndexNum = 0 To NumOfItems - 1


            'Debug.Print(Trim(Mid(CmbStore.Text, InStr(CmbStore.Text, "|") + 1, 20)))

            If Trim(Mid(objCombo.Items(IndexNum).ToString, InStr(objCombo.Items(IndexNum).ToString, "|") + 1, 20)) = TextToFind Then



                'If InStr(objCombo.Items(IndexNum).ToString, TextToFind) <> 0 Then
                objCombo.SelectedIndex = IndexNum
                ChkStoreID = True
                Exit Function
            End If
        Next IndexNum
        objCombo.SelectedIndex = -1
        ChkStoreID = False
    End Function

    Public Function ChkStorename(ByVal objCombo As ComboBox, ByVal TextToFind As String) As Boolean
        Dim NumOfItems As Object 'The Number Of Items In ComboBox
        Dim IndexNum As Integer 'Index
        objCombo.SelectedIndex = IndexNum

        NumOfItems = objCombo.Items.Count
        For IndexNum = 0 To NumOfItems - 1


            'Debug.Print(Trim(Mid(CmbStore.Text, InStr(CmbStore.Text, "|") + 1, 20)))

            If InStr(Trim(Mid(objCombo.Items(IndexNum).ToString, 1, InStr(objCombo.Items(IndexNum).ToString, "|") - 1)), TextToFind) <> 0 Then

                'If InStr(objCombo.Items(IndexNum).ToString, TextToFind) <> 0 Then
                objCombo.SelectedIndex = IndexNum
                ChkStorename = True
                Exit Function
            End If
        Next IndexNum
        objCombo.SelectedIndex = -1
        ChkStorename = False
    End Function


    Public Function Chkweekid(ByVal objCombo As ComboBox, ByVal TextToFind As String) As Boolean
        Dim NumOfItems As Object 'The Number Of Items In ComboBox
        Dim IndexNum As Integer 'Index
        objCombo.SelectedIndex = IndexNum

        NumOfItems = objCombo.Items.Count
        For IndexNum = 0 To NumOfItems - 1


            'Debug.Print(Trim(Mid(CmbStore.Text, InStr(CmbStore.Text, "|") + 1, 20)))

            'Trim(Mid(Cmbweek.Text, InStr(Cmbweek.Text, ":") + 1, InStr(Cmbweek.Text, "|") - InStr(Cmbweek.Text, ":") - 1))
            If Trim(Mid(objCombo.Items(IndexNum).ToString, InStr(objCombo.Items(IndexNum).ToString, ":") + 1, InStr(objCombo.Items(IndexNum).ToString, "|") - InStr(objCombo.Items(IndexNum).ToString, ":") - 1)) = TextToFind Then



                'If InStr(objCombo.Items(IndexNum).ToString, TextToFind) <> 0 Then
                objCombo.SelectedIndex = IndexNum
                Chkweekid = True
                Exit Function
            End If
        Next IndexNum
        objCombo.SelectedIndex = -1
        Chkweekid = False
    End Function

    Private Sub CmbMailbag_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMailbag.SelectedIndexChanged

        If MAILBAGADD = False Then Exit Sub

        If CmbMailbag.SelectedIndex = -1 Then Exit Sub

        TxtSeal.Text = ""
        CmbEnvelope.SelectedIndex = -1
        TxtApp.Text = ""
        TxtNobc.Text = ""
        TxtDate.Text = ""


        If CmbDC.Text = "" Then Exit Sub

        If Cmbweek.Text = "" Then Exit Sub

        If CmbStore.Text = "" Then Exit Sub


        Dim SQL As String
        Dim rs As Data.DataSet
        Dim I As Integer

        SQL = "SELECT ENVELOPENO , MAILBAG_ID FROM TBL_MAILBAG  " & _
        " WHERE   WKCYCLE_ID = " & Trim(Cmbweek.Tag) & "  " & _
        " AND   DCNAME = '" & CmbDC.Text & "'   " & _
        " AND   STOREID = " & Trim(TxtStoreId.Text) & "  " & _
        " AND   MAILBAGNUMBER  = '" & Trim(CmbMailbag.Text) & "'  " & _
        " GROUP BY  ENVELOPENO,MAILBAG_ID  ORDER BY cast(ENVELOPENO as int),MAILBAG_ID "
        rs = New Data.DataSet

        If cConnect.OpenSql(SQL, rs) = False Then
            Exit Sub
        End If

        If rs.Tables(0).Rows.Count < 1 Then
            Exit Sub
        End If
        CmbEnvelope.Items.Clear()

        For I = 0 To rs.Tables(0).Rows.Count - 1
            CmbEnvelope.Items.Add(Trim(rs.Tables(0).Rows(I)("ENVELOPENO").ToString) & "                                       |" & Trim(rs.Tables(0).Rows(I)("MAILBAG_ID").ToString))
        Next


    End Sub

    Private Sub CmbEnvelope_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEnvelope.SelectedIndexChanged


        If CmbEnvelope.SelectedIndex = -1 Then Exit Sub

        TxtSeal.Text = ""
        TxtApp.Text = ""
        TxtNobc.Text = ""
        TxtDate.Text = ""

        TxtMailbagID.Text = Trim(Mid(CmbEnvelope.Text, InStr(CmbEnvelope.Text, "|") + 1, 10))


        If CmbDC.Text = "" Then Exit Sub

        If Cmbweek.Text = "" Then Exit Sub

        If CmbStore.Text = "" Then Exit Sub


        Dim SQL As String
        Dim rs As Data.DataSet
        Dim I As Integer

        SQL = "SELECT     SEALNO,  APPINFORM, NOBARCODEAPP, convert(varchar(10),DATEFRONTLETTER,20) as DATEFRONTLETTER " & _
        " FROM         TBL_MAILBAG  WITH (NOLOCK)  " & _
        " WHERE    MAILBAG_ID  = " & Trim(TxtMailbagID.Text) & "  "
        rs = New Data.DataSet

        If cConnect.OpenSql(SQL, rs) = False Then
            Exit Sub
        End If

        If rs.Tables(0).Rows.Count < 1 Then
            Exit Sub
        End If


        TxtSeal.Text = rs.Tables(0).Rows(0)(0).ToString
        TxtApp.Text = rs.Tables(0).Rows(0)(1).ToString
        TxtNobc.Text = rs.Tables(0).Rows(0)(2).ToString
        TxtDate.Text = ChangeEngDateToThaiDate(rs.Tables(0).Rows(0)(3).ToString)

        selectapp()
        TxtClubcard.Text = ""
        TxtClubcard.Focus()

    End Sub

    Public Sub selectapp()

        Dim SQL As String
        Dim I As Integer
        SQL = " SELECT     CUSTID, CLUBCARD_NO, NAME_1, NAME_2,  (case when CUSTOMER_USE_STATUS = 0 then 'SIGNED' else 'UNSIGN' end) as 'SIGN/UNSIGN',FLAG " & _
                " FROM         TBL_MEMBER_CLUBCARD  WITH (NOLOCK)  " & _
                " WHERE    MAILBAG_ID  = " & Trim(TxtMailbagID.Text) & " ORDER BY CUSTID desc"
        rsapp = New Data.DataSet

        If cConnect.OpenSql(SQL, rsapp) = False Then
            Exit Sub
        End If

        If rsapp.Tables(0).Rows.Count < 1 Then
            Exit Sub
        End If
        Datagridview1.AutoGenerateColumns = True
        Datagridview1.DataSource = rsapp.Tables(0)
        Datagridview1.Refresh()
        Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Txtqty.Text = rsapp.Tables(0).Rows.Count
        selectCounting()
    End Sub

    Private Sub selectCounting()
        Dim SQL As String
        Dim rs As New Data.DataSet
        SQL = " SELECT  sum(  case when CUSTOMER_USE_STATUS = 0 then 1 else 0 end ) sign, sum(  case when CUSTOMER_USE_STATUS = 6 then 1 else 0 end ) unsign " & _
                        " FROM         TBL_MEMBER_CLUBCARD  WITH (NOLOCK)  " & _
                        " WHERE    MAILBAG_ID  = " & Trim(TxtMailbagID.Text) & " "
        rsapp = New Data.DataSet

        If cConnect.OpenSql(SQL, rs) = False Then
            Exit Sub
        End If

        txtSign.Text = rs.Tables(0).Rows(0)("sign").ToString
        Txtunsign.Text = rs.Tables(0).Rows(0)("unsign").ToString
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
                If Len(TxtClubcard.Text) <> 18 Then
                    MsgBox("หมายเลข Clubcard ไม่ครบ 18 หลัก ")
                    TxtClubcard.Text = ""
                    TxtClubcard.Focus()
                    Exit Sub
                End If
                If CheckDigit(TxtClubcard.Text) = False Then

                    If MsgBox("เลข Clubcard ไม่ถูกต้อง Invalid  ต้องการเพิ่มเข้าในระบบหรือไม่ ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        TxtClubcard.Text = ""
                        TxtClubcard.Focus()
                        Exit Sub
                    Else
                        cClubcard.Flag = "INVALID"
                        Call InsertNewClubcard()
                        selectapp()
                        TxtClubcard.Text = ""
                        TxtClubcard.Focus()
                        Exit Sub
                    End If

                End If



                If CheckDupClubcardTESCO(TxtClubcard.Text) = True Then
                    If MsgBox("เลข Clubcard ซ้ำต้องการเพิ่มเข้าในระบบหรือไม่ ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        TxtClubcard.Text = ""
                        TxtClubcard.Focus()
                        Exit Sub
                    Else
                        cClubcard.Flag = "DUPLICATE"
                        Call InsertNewClubcard()
                        Exit Sub
                    End If
                End If

                If CheckDupClubcard(TxtClubcard.Text) = True Then
                    If MsgBox("เลข Clubcard ซ้ำต้องการเพิ่มเข้าในระบบหรือไม่ ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        TxtClubcard.Text = ""
                        TxtClubcard.Focus()
                        Exit Sub
                    Else
                        cClubcard.Flag = "DUPLICATE"
                        Call InsertNewClubcard()

                    End If
                    Exit Sub
                Else
                    cClubcard.Flag = "NEW"
                    Call InsertNewClubcard()
                End If
                selectapp()

            Case KeyAscii < 48 Or KeyAscii > 57
                Exit Sub
        End Select
    End Sub



    Public Sub InsertNewClubcard()
        cClubcard.MAILBAG_ID = Trim(TxtMailbagID.Text)
        cClubcard.CLUBCARD_NO = Trim(TxtClubcard.Text)
        If Optsign.Checked = True Then

            cClubcard.customer_use_status = 0
            cClubcard.customer_mail_status = 0
            cClubcard.preferred_store_code = Trim(TxtStoreId.Text)
            cClubcard.joined_store_code = Trim(TxtStoreId.Text)
            cClubcard.customer_created_date = ChangeThaiDateToEngDate(TxtDate.Text)

        ElseIf OptUnsign.Checked = True Then
            cClubcard.customer_use_status = 6
            cClubcard.customer_mail_status = 3
            cClubcard.preferred_store_code = Trim(TxtStoreId.Text)
            cClubcard.joined_store_code = Trim(TxtStoreId.Text)
            cClubcard.customer_created_date = ChangeThaiDateToEngDate(TxtDate.Text)
        End If

        If cClubcard.InsertNewClubcard = True Then
            Call selectapp()
        Else
            MsgBox("Insert NEW App Error!")
            Exit Sub
        End If

        TxtClubcard.Text = ""
        TxtClubcard.Focus()

    End Sub


    Private Sub TxtClubcard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClubcard.TextChanged

    End Sub

    Private Sub CmbDC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDC.SelectedIndexChanged

        TxtStoreId.Text = ""
        CmbStore.SelectedIndex = -1
        CmbMailbag.SelectedIndex = -1
        TxtMailbagID.Text = ""
        TxtSeal.Text = ""
        CmbEnvelope.SelectedIndex = -1
        TxtApp.Text = ""
        TxtNobc.Text = ""
        TxtDate.Text = ""
 
    End Sub

    Private Sub TxtStoreId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStoreId.TextChanged

    End Sub

    Private Sub Datagridview1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellContentClick

    End Sub
End Class