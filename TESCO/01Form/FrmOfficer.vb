Public Class FrmOfficer






    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub

    Private Sub FrmWeek_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CalGetSystemDate() ' ดึงค่าวันปัจจุบันใส่ปฏิทิน
        Call settoolbarload()
        'Call setcombo()


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
    Private Sub SearchOfficer()
        Dim sql As String
        Dim rs1 As Data.DataSet

        rs1 = New Data.DataSet
        cOfficer.MEMBERID = ""
        cOfficer.EFname = ""
        cOfficer.ELname = ""
        cOfficer.LOGINNAME = ""
        cOfficer.PASSWORD = ""
        cOfficer.LevelID = ""
        cOfficer.IsActive = ""

        'If txtName.Text = "" Or TxtSurname.Text = "" Or TxtUser.Text = "" Or TxtPassword.Text = "" Then
        '    MsgBox("กรุณากรอกข้อมูลให้ครบทุกช่อง")
        '    Exit Sub
        'End If

        'If OptLevel1.Checked = False And OptLevel2.Checked = False And OptLevel3.Checked = False Then
        '    MsgBox("กรุณาเลือก Level")
        '    Exit Sub
        'End If

        'If OptActive0.Checked = False And OptActive1.Checked = False Then
        '    MsgBox("กรุณาเลือก Active Status")
        '    Exit Sub
        'End If



        cOfficer.EFname = txtName.Text
        cOfficer.ELname = TxtSurname.Text
        cOfficer.LOGINNAME = TxtUser.Text
        cOfficer.PASSWORD = TxtPassword.Text

        If OptLevel1.Checked = True Then
            cOfficer.LevelID = "1"
        ElseIf OptLevel2.Checked = True Then
            cOfficer.LevelID = "2"
        ElseIf OptLevel3.Checked = True Then
            cOfficer.LevelID = "3"
        End If

        If OptActive0.Checked = True Then
            cOfficer.IsActive = "0"
        ElseIf OptActive1.Checked = True Then
            cOfficer.IsActive = "1"
        End If







        If cOfficer.SelectOfficer(rs1) = False Then
            MsgBox("ไม่พบข้อมูลที่ต้องการ")
            Exit Sub
        End If

        Datagridview1.AutoGenerateColumns = True
        Datagridview1.DataSource = rs1.Tables(0)
        Datagridview1.Refresh()
        Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        cOfficer.MEMBERID = ""
        Call SearchOfficer()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim rs1 As New Data.DataSet



        cOfficer.EFname = ""
        cOfficer.ELname = ""
        cOfficer.LOGINNAME = ""
        cOfficer.PASSWORD = ""
        cOfficer.LevelID = ""
        cOfficer.IsActive = ""


        If txtName.Text = "" Or TxtSurname.Text = "" Or TxtUser.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("กรุณากรอกข้อมูลให้ครบทุกช่อง")
            Exit Sub
        End If

        If OptLevel1.Checked = False And OptLevel2.Checked = False And OptLevel3.Checked = False Then
            MsgBox("กรุณาเลือก Level")
            Exit Sub
        End If

        If OptActive0.Checked = False And Optactive1.Checked = False Then
            MsgBox("กรุณาเลือก Active Status")
            Exit Sub
        End If

        cOfficer.EFname = txtName.Text
        cOfficer.ELname = TxtSurname.Text
        cOfficer.LOGINNAME = TxtUser.Text
        cOfficer.PASSWORD = TxtPassword.Text

        If OptLevel1.Checked = True Then
            cOfficer.LevelID = "1"
        ElseIf OptLevel2.Checked = True Then
            cOfficer.LevelID = "2"
        ElseIf OptLevel3.Checked = True Then
            cOfficer.LevelID = "3"
        End If

        If OptActive0.Checked = True Then
            cOfficer.IsActive = "0"
        ElseIf Optactive1.Checked = True Then
            cOfficer.IsActive = "1"
        End If



        If cOfficer.SelectOfficer(rs1) = True Then
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

        If cOfficer.InsertOfficer = True Then
            MsgBox("Data Added")
            Call SearchOfficer()
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
        txtName.Tag = ""
        txtName.Text = ""
        TxtSurname.Text = ""
        TxtUser.Text = ""
        TxtPassword.Text = ""

        OptLevel1.Checked = False
        OptLevel2.Checked = False
        OptLevel3.Checked = False
        OptActive0.Checked = False
        Optactive1.Checked = False


    End Sub

    Private Sub ClrGrid()

        Datagridview1.DataSource = Nothing
        Datagridview1.Refresh()

    End Sub

    Private Sub Datagridview1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellClick
        If Datagridview1.Rows.Count < 1 Then Exit Sub


        txtName.Tag = (Datagridview1.Rows.Item(e.RowIndex).Cells(0).Value.ToString)
        txtName.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(1).Value.ToString)
        TxtSurname.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(2).Value.ToString)
        TxtUser.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(3).Value.ToString)
        TxtPassword.Text = (Datagridview1.Rows.Item(e.RowIndex).Cells(4).Value.ToString)

        If (Datagridview1.Rows.Item(e.RowIndex).Cells(5).Value.ToString) = 1 Then
            OptLevel1.Checked = True
        ElseIf (Datagridview1.Rows.Item(e.RowIndex).Cells(5).Value.ToString) = 2 Then
            OptLevel2.Checked = True
        ElseIf (Datagridview1.Rows.Item(e.RowIndex).Cells(5).Value.ToString) = 3 Then
            OptLevel3.Checked = True
        End If

        If (Datagridview1.Rows.Item(e.RowIndex).Cells(6).Value.ToString) = 1 Then
            Optactive1.Checked = True
        ElseIf (Datagridview1.Rows.Item(e.RowIndex).Cells(6).Value.ToString) = 0 Then
            OptActive0.Checked = True

        End If





        settoolbaredit()
    End Sub




    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Dim rs1 As New Data.DataSet

        If MsgBox("ยืนยันการแก้ไขข้อมูล", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If Trim(txtName.Tag) = "" Then
            MsgBox("ยังไม่ได้เลือกรายการที่ต้องการแก้ไข")
            Exit Sub
        End If



        cOfficer.EFname = ""
        cOfficer.ELname = ""
        cOfficer.LOGINNAME = ""
        cOfficer.PASSWORD = ""
        cOfficer.LevelID = ""
        cOfficer.IsActive = ""


        If txtName.Text = "" Or TxtSurname.Text = "" Or TxtUser.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("กรุณากรอกข้อมูลให้ครบทุกช่อง")
            Exit Sub
        End If

        If OptLevel1.Checked = False And OptLevel2.Checked = False And OptLevel3.Checked = False Then
            MsgBox("กรุณาเลือก Level")
            Exit Sub
        End If

        If OptActive0.Checked = False And Optactive1.Checked = False Then
            MsgBox("กรุณาเลือก Active Status")
            Exit Sub
        End If


        cOfficer.MEMBERID = txtName.Tag
        cOfficer.EFname = txtName.Text
        cOfficer.ELname = TxtSurname.Text
        cOfficer.LOGINNAME = TxtUser.Text
        cOfficer.PASSWORD = TxtPassword.Text

        If OptLevel1.Checked = True Then
            cOfficer.LevelID = "1"
        ElseIf OptLevel2.Checked = True Then
            cOfficer.LevelID = "2"
        ElseIf OptLevel3.Checked = True Then
            cOfficer.LevelID = "3"
        End If

        If OptActive0.Checked = True Then
            cOfficer.IsActive = "0"
        ElseIf Optactive1.Checked = True Then
            cOfficer.IsActive = "1"
        End If



        If cOfficer.SelectOfficer(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้ มีข้อมูลอยู่ในระบบแล้ว")
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

        If cOfficer.UpdateOfficer = True Then
            MsgBox("แก้ไขข้อมูลเรียบร้อยแล้ว")
            Call SearchOfficer()
        Else
            MsgBox("ไม่สามารถแก้ไขข้อมูลได้กรุณาติดต่อ IT")
        End If
        Call ClrTextbox()
        Call settoolbarload()
    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click
       

    End Sub




    Private Sub Datagridview1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellContentClick

    End Sub
End Class