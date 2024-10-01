<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuery
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtClubcard = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Datagridview1 = New System.Windows.Forms.DataGridView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.CmdNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdView = New System.Windows.Forms.Button
        CType(Me.Datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtClubcard
        '
        Me.TxtClubcard.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtClubcard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtClubcard.Location = New System.Drawing.Point(484, 47)
        Me.TxtClubcard.Name = "TxtClubcard"
        Me.TxtClubcard.Size = New System.Drawing.Size(237, 23)
        Me.TxtClubcard.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(328, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "‡≈¢∑’Ë„∫ ¡—§√ Club Card"
        '
        'Datagridview1
        '
        Me.Datagridview1.AllowUserToAddRows = False
        Me.Datagridview1.AllowUserToDeleteRows = False
        Me.Datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datagridview1.Location = New System.Drawing.Point(53, 103)
        Me.Datagridview1.Name = "Datagridview1"
        Me.Datagridview1.ReadOnly = True
        Me.Datagridview1.Size = New System.Drawing.Size(914, 283)
        Me.Datagridview1.TabIndex = 75
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdNew, Me.CmdExit, Me.CmdAdd, Me.CmdEdit, Me.CmdDelete, Me.CmdSearch})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1015, 24)
        Me.MenuStrip1.TabIndex = 76
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CmdNew
        '
        Me.CmdNew.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdNew.Image = Global.WindowsApplication1.My.Resources.Resources._new
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(61, 20)
        Me.CmdNew.Text = "New"
        '
        'CmdExit
        '
        Me.CmdExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdExit.Image = Global.WindowsApplication1.My.Resources.Resources._exit
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(56, 20)
        Me.CmdExit.Text = "Exit"
        '
        'CmdAdd
        '
        Me.CmdAdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdAdd.Image = Global.WindowsApplication1.My.Resources.Resources.add
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(58, 20)
        Me.CmdAdd.Text = "Add"
        Me.CmdAdd.Visible = False
        '
        'CmdEdit
        '
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdEdit.Image = Global.WindowsApplication1.My.Resources.Resources.save
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(57, 20)
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.Visible = False
        '
        'CmdDelete
        '
        Me.CmdDelete.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdDelete.Image = Global.WindowsApplication1.My.Resources.Resources.delete
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(72, 20)
        Me.CmdDelete.Text = "Delete"
        Me.CmdDelete.Visible = False
        '
        'CmdSearch
        '
        Me.CmdSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmdSearch.Image = Global.WindowsApplication1.My.Resources.Resources.search
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(76, 20)
        Me.CmdSearch.Text = "Search"
        Me.CmdSearch.Visible = False
        '
        'CmdView
        '
        Me.CmdView.Location = New System.Drawing.Point(802, 409)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(165, 31)
        Me.CmdView.TabIndex = 77
        Me.CmdView.Text = "View Application"
        Me.CmdView.UseVisualStyleBackColor = True
        '
        'FrmQuery
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1015, 706)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdView)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Datagridview1)
        Me.Controls.Add(Me.TxtClubcard)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmQuery"
        Me.Text = "Chk digit"
        CType(Me.Datagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtClubcard As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Datagridview1 As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CmdNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdView As System.Windows.Forms.Button
End Class
