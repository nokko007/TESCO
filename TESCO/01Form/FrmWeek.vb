
Option Strict Off
Option Explicit On

Public Class FrmWeek




    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub

    Private Sub FrmWeek_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CalGetSystemDate() ' �֧����ѹ�Ѩ�غѹ��軯ԷԹ
        Call settoolbarload()



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
    Private Sub searchWeek()
        Dim sql As String
        Dim rs1 As Data.DataSet

        rs1 = New Data.DataSet
        cWeek.WeekID = ""
        cWeek.WeekNo = ""
        cWeek.PickupDate = ""

        If Trim(TxtWeekNo.Text) <> "" Then
            cWeek.WeekNo = Trim(TxtWeekNo.Text)
        End If
        If Trim(txtDate.Text) <> "" Then
            cWeek.PickupDate = ChangeThaiDateToEngDate(Trim(txtDate.Text))
        End If

        If cWeek.SELECTWEEK(rs1) = False Then
            MsgBox("��辺�����ŷ���ͧ���")
            Exit Sub
        End If

            DataGridView1.AutoGenerateColumns = True
            DataGridView1.DataSource = rs1.Tables(0)
            DataGridView1.Refresh()
        Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        Call searchWeek()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim rs1 As New Data.DataSet
        If Trim(TxtWeekNo.Text) = "" Then
            MsgBox("�ѧ������͡ Week No")
            Exit Sub
        End If
        If Trim(txtDate.Text) = "" Then
            MsgBox("�ѧ����� Pickup Date")
            Exit Sub
        End If
        cWeek.WeekID = ""
        cWeek.WeekNo = Trim(TxtWeekNo.Text)
        cWeek.PickupDate = ChangeThaiDateToEngDate(Trim(txtDate.Text))

        If cWeek.CHKDUPWEEK(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("�������ö������������ �բ�����������к�����")
                Call ClrTextbox()

                Datagridview1.AutoGenerateColumns = True
                Datagridview1.DataSource = rs1.Tables(0)
                Datagridview1.Refresh()
                Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Exit Sub
            End If
        End If

        If cWeek.INSERTWEEK = True Then
            MsgBox("Data Added")
            Call searchWeek()
        Else
            MsgBox("�������ö Add ���������سҵԴ��� IT")
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
        TxtWeekId.Text = ""
        TxtWeekNo.Text = ""
        txtDate.Text = ""
    End Sub

    Private Sub ClrGrid()

        Datagridview1.DataSource = Nothing
        Datagridview1.Refresh()

    End Sub

    Private Sub Datagridview1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellClick
        If Datagridview1.Rows.Count < 1 Then Exit Sub

        TxtWeekId.Text = Datagridview1.Rows.Item(e.RowIndex).Cells(0).Value.ToString
        TxtWeekNo.Text = Datagridview1.Rows.Item(e.RowIndex).Cells(1).Value.ToString
        txtDate.Text = ChangeEngDateToThaiDate(Datagridview1.Rows.Item(e.RowIndex).Cells(2).Value.ToString)
        settoolbaredit()
    End Sub

 


    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Dim rs1 As New Data.DataSet

        If MsgBox("�׹�ѹ�����䢢�����", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If Trim(TxtWeekId.Text) = "" Then
            MsgBox("�ѧ��������͡��¡�÷���ͧ������")
            Exit Sub
        End If

        If Trim(TxtWeekNo.Text) = "" Then
            MsgBox("�ѧ������͡ Week No")
            Exit Sub
        End If
        If Trim(txtDate.Text) = "" Then
            MsgBox("�ѧ����� Pickup Date")
            Exit Sub
        End If

        cWeek.WeekID = Trim(TxtWeekId.Text)
        cWeek.WeekNo = Trim(TxtWeekNo.Text)
        cWeek.PickupDate = ChangeThaiDateToEngDate(Trim(txtDate.Text))



        If cWeek.CHKDUPWEEK(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("�������ö��䢢������� �բ�����������к�����")
                Call ClrTextbox()

                Datagridview1.AutoGenerateColumns = True
                Datagridview1.DataSource = rs1.Tables(0)
                Datagridview1.Refresh()
                Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Exit Sub
            End If
        End If

        If cWeek.UPDATEWEEK = True Then
            MsgBox("��䢢��������º��������")
            Call searchWeek()
        Else
            MsgBox("�������ö��䢢��������سҵԴ��� IT")
        End If
        Call ClrTextbox()
        Call settoolbarload()
    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click
        Dim rs1 As New Data.DataSet

        If MsgBox("�׹�ѹ���ź������", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If Trim(TxtWeekId.Text) = "" Then
            MsgBox("�ѧ��������͡��¡�÷���ͧ������")
            Exit Sub
        End If

        If Trim(TxtWeekNo.Text) = "" Then
            MsgBox("�ѧ������͡ Week No")
            Exit Sub
        End If
        If Trim(txtDate.Text) = "" Then
            MsgBox("�ѧ����� Pickup Date")
            Exit Sub
        End If

        cWeek.WeekID = Trim(TxtWeekId.Text)
        cWeek.WeekNo = Trim(TxtWeekNo.Text)
        cWeek.PickupDate = ChangeThaiDateToEngDate(Trim(txtDate.Text))



        If cWeek.CHKUSEWEEK(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("�������öź�������� ���ͧ�ҡ���� Week �١���������")
                Call ClrTextbox()

                Datagridview1.AutoGenerateColumns = True
                Datagridview1.DataSource = Nothing
                Datagridview1.Refresh()
                Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Exit Sub
            End If
        End If

        If cWeek.DELETEWEEK = True Then
            MsgBox("ź���������º��������")
            Call ClrTextbox()
            Call searchWeek()
        Else
            MsgBox("�������öź���������سҵԴ��� IT")
        End If
        Call settoolbarload()

    End Sub

    Private Sub Datagridview1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellContentClick

    End Sub
End Class