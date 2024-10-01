Public Class FrmQuery



    Private Sub TxtClubcard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClubcard.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim findString As String = String.Empty
        Select Case KeyAscii
            Case 13
                'If CheckDigit(TxtClubcard.Text) = False Then
                '    If MsgBox("เลข Clubcard ไม่ถูกต้อง Invalid", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                '        TxtClubcard.Text = ""
                '        TxtClubcard.Focus()

                '        Exit Sub
                '    End If
                'Else
                selectapp()


                'End If

            Case 48 To 57
                e.Handled = False
            Case 8, 13, 46
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TxtClubcard_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtClubcard.GotFocus
        Dim TypeOfLanguage = New System.Globalization.CultureInfo("EN") ' or "fa-IR" for Farsi(Iran) 
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)
    End Sub

    Private Sub selectapp()
        Dim sql As String
        Dim rs1 As Data.DataSet
        cClubcard.custid = ""
        cClubcard.CLUBCARD_NO = ""
        cClubcard.Flag = ""

        rs1 = New Data.DataSet
        sql = "SELECT * FROM V_QUERY_APP WHERE CLUBCARD_NO like  '" & Trim(TxtClubcard.Text) & "%' "


        rs1 = New Data.DataSet

        If cConnect.OpenSql(sql, rs1) = False Then
            Exit Sub
        End If

        If rs1.Tables(0).Rows.Count < 1 Then
            MsgBox("ไม่พบข้อมูลที่ต้องการ")
            'Exit Sub
        End If
        Datagridview1.AutoGenerateColumns = True
        Datagridview1.DataSource = rs1.Tables(0)
        Datagridview1.Refresh()
        Datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        TxtClubcard.SelectAll()

    End Sub


    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub

    Private Sub TxtClubcard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClubcard.TextChanged

    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click

        If cClubcard.CLUBCARD_NO = "" Or cClubcard.custid = "" Then
            MsgBox("ยังไม่ได้เลือกรายการที่ต้องการดู", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cClubcard.Flag = "NEW" Then
            MsgBox("ไม่สามารถดูรายการที่ต้องการได้เนื่องจาก Flag เป็น NEW", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cClubcard.Flag = "DUPLICATE" Then
            MsgBox("ไม่สามารถดูรายการที่ต้องการได้เนื่องจาก Flag เป็น NEW", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        FRmKeyin.MdiParent = FrmMain
        FRmKeyin.Parent = FrmMain.PnlDisplay
        FRmKeyin.Dock = DockStyle.Fill
        FRmKeyin.Show()

        FRmKeyin.TxtClubcard.Text = cClubcard.CLUBCARD_NO
        Me.Hide()

    End Sub

    Private Sub Datagridview1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellClick
        cClubcard.custid = Datagridview1.Rows.Item(e.RowIndex).Cells(0).Value.ToString
        cClubcard.CLUBCARD_NO = Datagridview1.Rows.Item(e.RowIndex).Cells(1).Value.ToString
        cClubcard.Flag = Datagridview1.Rows.Item(e.RowIndex).Cells(2).Value.ToString
    End Sub


    Private Sub Datagridview1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellContentClick

    End Sub

    Private Sub FrmQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cClubcard.custid = ""
        cClubcard.CLUBCARD_NO = ""
        cClubcard.Flag = ""

    End Sub
End Class