
Option Strict Off
Option Explicit On

Public Class FrmMailbag




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

        'If CmbDC.Text = "" Then
        '    MsgBox("ยังไม่ได้เลือก DC")
        '    Exit Sub
        'End If

        'If CmbStore.Text = "" Then
        '    MsgBox("ยังไม่ได้เลือก Store ")
        '    Exit Sub
        'End If


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

        TxtQty.Text = rs1.Tables(0).Rows.Count

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        Call SearchMailbag()
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



        If TxtMailbag.Text = "" Then
            MsgBox("ยังไม่ได้กรอกเลขที่ Mailbag ")
            Exit Sub
        End If

        If TxtSeal.Text = "" Then
            MsgBox("ยังไม่ได้กรอก Seal No ")
            Exit Sub
        End If

        If TxtEnvelope.Text = "" Then
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

        cMailbag.MailbagNumber = Trim(TxtMailbag.Text)
        cMailbag.SealNo = Trim(TxtSeal.Text)
        cMailbag.EnvelopeNo = Trim(TxtEnvelope.Text)
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
        TxtMailbag.Text = ""
        TxtMailbagID.Text = ""
        TxtSeal.Text = ""
        TxtEnvelope.Text = ""
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


        Call Chkweekid(Cmbweek, Datagridview1.Rows.Item(e.RowIndex).Cells(1).Value.ToString)
        Call ChkStoreID(CmbStore, Datagridview1.Rows.Item(e.RowIndex).Cells(3).Value.ToString)

        
        'TxtPickupDate.Text = ""
        CmbDC.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(2).Value.ToString)
        'TxtStoreId.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(3).Value.ToString)
        'CmbStore.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(4).Value.ToString)
        TxtMailbag.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(4).Value.ToString)
        TxtMailbagID.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(0).Value.ToString)
        TxtSeal.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(5).Value.ToString)
        TxtEnvelope.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(6).Value.ToString)
        TxtApp.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(7).Value.ToString)
        TxtNobc.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(8).Value.ToString)
        TxtDate.Text = ChangeEngDateToThaiDate(Datagridview1.Rows.Item(e.RowIndex).Cells(9).Value.ToString)




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



        If TxtMailbag.Text = "" Then
            MsgBox("ยังไม่ได้กรอกเลขที่ Mailbag ")
            Exit Sub
        End If

        If TxtSeal.Text = "" Then
            MsgBox("ยังไม่ได้กรอก Seal No ")
            Exit Sub
        End If

        If TxtEnvelope.Text = "" Then
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

        cMailbag.MailbagNumber = Trim(TxtMailbag.Text)
        cMailbag.SealNo = Trim(TxtSeal.Text)
        cMailbag.EnvelopeNo = Trim(TxtEnvelope.Text)
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

        If Trim(TxtMailbagID.Text) = "" Then
            MsgBox("ยังไม่ได้เลือกรายการที่ต้องการลบ")
            Exit Sub
        End If

  

        cMailbag.MailbagID = Trim(TxtMailbagID.Text)
        'cWeek.WeekNo = Trim(Cmbweek.Text)
        'cWeek.PickupDate = ChangeThaiDateToEngDate(Trim(TxtDate.Text))



        If cMailbag.CHKUSEMAILBAG(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("ไม่สามารถลบข้อมูลได้ เนื่องจากรหัส Mailbag ถูกนำไปใช้แล้ว")
                Call ClrTextbox()

                Datagridview1.AutoGenerateColumns = True
                Datagridview1.DataSource = rs1.Tables(0)
                Datagridview1.Refresh()
                Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Exit Sub
            End If
        End If

        If cMailbag.DELETEMAILBAG = True Then
            MsgBox("ลบข้อมูลเรียบร้อยแล้ว")
            Call ClrTextbox()
            Call SearchMailbag()
        Else
            MsgBox("ไม่สามารถลบข้อมูลได้กรุณาติดต่อ IT")
        End If
        Call settoolbarload()

    End Sub


    Private Sub setcombo()



        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer

        sql = " SELECT  WEEKID ,  WEEKNO , CONVERT(VARCHAR(10), PICKUPDATE,20) AS PICKUPDATE FROM  TBL_WKCYCLE order by  WEEKNO DESC "



        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    Cmbweek.Items.Add(Trim(rs1.Tables(0).Rows(x)("WEEKNO").ToString) & "                   :" & Trim(rs1.Tables(0).Rows(x)("WEEKID").ToString) & "|" & Trim(rs1.Tables(0).Rows(x)("PICKUPDATE").ToString))
                Next x
            End If
        End If




        sql = " SELECT  DCNAME  FROM  TBL_DC "


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



        sql = " SELECT STOREID , STORENAME  FROM  TBL_STORE order by STORENAME "


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


  
    End Sub

    Private Sub cmdCarlendar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCarlendar1.Click
        On Error GoTo error_Handler
        Dim d As String

        d = CALDateGet("") ' d format dd/mm/yyyy+543

        If d <> "" Then
            txtDate.Text = d
        Else
            txtDate.Text = ""
        End If

resume_err:
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "_" & "cmdCarlendar_Click", Err.Number, ErrorToString())
        GoTo resume_err
    End Sub

    Private Sub Cmbweek_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmbweek.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
               
                SendKeys.Send(vbTab)
             
   
            Case Else
                e.Handled = True
        End Select
    End Sub
    Private Sub CmbStartweek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbweek.SelectedIndexChanged
        If Cmbweek.SelectedIndex = -1 Then Exit Sub
        Cmbweek.Tag = Trim(Mid(Cmbweek.Text, InStr(Cmbweek.Text, ":") + 1, InStr(Cmbweek.Text, "|") - InStr(Cmbweek.Text, ":") - 1))
        TxtPickupDate.Text = ChangeEngDateToThaiDate(Trim(Mid(Cmbweek.Text, InStr(Cmbweek.Text, "|") + 1, 100)))
        Debug.Print(Cmbweek.Tag)
        Debug.Print(TxtPickupDate.Text)
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
        TxtStoreId.Text = Trim(Mid(CmbStore.Text, InStr(CmbStore.Text, "|") + 1, 20))
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

    Private Sub TxtEnvelope_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEnvelope.KeyPress
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

    Private Sub TxtEnvelope_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEnvelope.TextChanged

    End Sub

    Private Sub TxtApp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApp.KeyPress
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

    Private Sub TxtApp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApp.TextChanged

    End Sub

    Private Sub TxtNobc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNobc.KeyPress, TxtQty.KeyPress
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

    Private Sub TxtNobc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNobc.KeyUp, TxtQty.KeyUp

    End Sub

    Private Sub TxtNobc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNobc.TextChanged, TxtQty.TextChanged

    End Sub

    Private Sub CmbDC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDC.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13

                SendKeys.Send(vbTab)


            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub CmbDC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDC.SelectedIndexChanged

    End Sub

    Private Sub TxtMailbag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMailbag.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
        End Select
    End Sub

    Private Sub TxtMailbag_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMailbag.TextChanged

    End Sub

    Private Sub TxtStoreId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStoreId.TextChanged

    End Sub

    Private Sub TxtSeal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSeal.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                SendKeys.Send(vbTab)
        End Select
    End Sub

    Private Sub TxtSeal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSeal.TextChanged

    End Sub
End Class