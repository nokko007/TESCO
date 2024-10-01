
Option Strict Off
Option Explicit On

Public Class FrmStore




    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub

    Private Sub FrmStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CalGetSystemDate() ' �֧����ѹ�Ѩ�غѹ��軯ԷԹ
        Call settoolbarload()



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
    Private Sub searchStore()
        Dim sql As String
        Dim rs1 As Data.DataSet

        rs1 = New Data.DataSet
        cStore.StoreID = ""
        cStore.StoreName = ""

        If Trim(TxtStoreID.Text) <> "" Then
            cStore.StoreID = Trim(TxtStoreID.Text)
        End If

        If Trim(TxtStoreName.Text) <> "" Then
            cStore.STORENAME = Trim(TxtStoreName.Text)
        End If

        If cStore.SELECTStore(rs1) = False Then
            MsgBox("��辺�����ŷ���ͧ���")
            Exit Sub
        End If

        Datagridview1.AutoGenerateColumns = True
        DataGridView1.DataSource = rs1.Tables(0)
        Datagridview1.Refresh()
        Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        Call searchStore()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim rs1 As New Data.DataSet
        If Trim(TxtStoreID.Text) = "" Then
            MsgBox("�ѧ������͡ Store No")
            Exit Sub
        End If
        
        cStore.StoreID = Trim(TxtStoreID.Text)
        cStore.StoreName = Trim(TxtStoreName.Text)


        If cStore.CHKDUPStore(rs1) = True Then
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

        If cStore.INSERTStore = True Then
            MsgBox("Data Added")
            Call searchStore()
        Else
            MsgBox("�������ö Add ���������سҵԴ��� IT")
        End If
        Call ClrTextbox()
        Call settoolbarload()

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        ClrTextbox()
        settoolbarload()
    End Sub


    Private Sub ClrTextbox()
        TxtStoreId.Text = ""
        TxtStoreName.Text = ""
    End Sub



    Private Sub Datagridview1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellClick
        If Datagridview1.Rows.Count < 1 Then Exit Sub

        TxtStoreId.Text = Datagridview1.Rows.Item(e.RowIndex).Cells(0).Value.ToString
        TxtStoreName.Text = Datagridview1.Rows.Item(e.RowIndex).Cells(1).Value.ToString
        settoolbaredit()
    End Sub




    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Dim rs1 As New Data.DataSet

        If MsgBox("�׹�ѹ�����䢢�����", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If Trim(TxtStoreId.Text) = "" Then
            MsgBox("�ѧ��������͡��¡�÷���ͧ������")
            Exit Sub
        End If

        If Trim(TxtStoreID.Text) = "" Then
            MsgBox("�ѧ������͡ Store No")
            Exit Sub
        End If


        cStore.StoreID = Trim(TxtStoreID.Text)
        cStore.StoreName = Trim(TxtStoreName.Text)

        If cStore.CHKDUPStore(rs1) = True Then
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

        If cStore.UPDATEStore = True Then
            MsgBox("��䢢��������º��������")
            Call searchStore()
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

        If Trim(TxtStoreId.Text) = "" Then
            MsgBox("�ѧ��������͡��¡�÷���ͧ������")
            Exit Sub
        End If

        If Trim(TxtStoreID.Text) = "" Then
            MsgBox("�ѧ������͡ Store No")
            Exit Sub
        End If
       

        cStore.StoreID = Trim(TxtStoreID.Text)
        cStore.StoreName = Trim(TxtStoreName.Text)



        If cStore.CHKUSEStore(rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then
                MsgBox("�������öź�������� ���ͧ�ҡ���� Store �١���������")
                Call ClrTextbox()
                Datagridview1.AutoGenerateColumns = True
                Datagridview1.DataSource = rs1.Tables(0)
                Datagridview1.Refresh()
                Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Exit Sub
            End If
        End If

        If cStore.DELETEStore = True Then
            MsgBox("ź���������º��������")
            Call ClrTextbox()
            Call searchStore()
        Else
            MsgBox("�������öź���������سҵԴ��� IT")
        End If
        Call settoolbarload()

    End Sub

    Private Sub Datagridview1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellContentClick

    End Sub
End Class