<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStore
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.CmdNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtStoreID = New System.Windows.Forms.TextBox
        Me.Datagridview1 = New System.Windows.Forms.DataGridView
        Me.TxtStoreName = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdNew, Me.CmdAdd, Me.CmdEdit, Me.CmdDelete, Me.CmdSearch, Me.CmdExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1015, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CmdNew
        '
        Me.CmdNew.Image = Global.WindowsApplication1.My.Resources.Resources._new
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(60, 20)
        Me.CmdNew.Text = "New"
        '
        'CmdAdd
        '
        Me.CmdAdd.Image = Global.WindowsApplication1.My.Resources.Resources.add
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(57, 20)
        Me.CmdAdd.Text = "Add"
        '
        'CmdEdit
        '
        Me.CmdEdit.Image = Global.WindowsApplication1.My.Resources.Resources.save
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(56, 20)
        Me.CmdEdit.Text = "Edit"
        '
        'CmdDelete
        '
        Me.CmdDelete.Image = Global.WindowsApplication1.My.Resources.Resources.delete
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(71, 20)
        Me.CmdDelete.Text = "Delete"
        '
        'CmdSearch
        '
        Me.CmdSearch.Image = Global.WindowsApplication1.My.Resources.Resources.search
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(72, 20)
        Me.CmdSearch.Text = "Search"
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.WindowsApplication1.My.Resources.Resources._exit
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(55, 20)
        Me.CmdExit.Text = "Exit"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.Location = New System.Drawing.Point(121, 131)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 14)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "Store Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(121, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 14)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Store ID"
        '
        'TxtStoreID
        '
        Me.TxtStoreID.BackColor = System.Drawing.Color.White
        Me.TxtStoreID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtStoreID.Location = New System.Drawing.Point(199, 91)
        Me.TxtStoreID.Name = "TxtStoreID"
        Me.TxtStoreID.Size = New System.Drawing.Size(113, 22)
        Me.TxtStoreID.TabIndex = 0
        '
        'Datagridview1
        '
        Me.Datagridview1.AllowUserToAddRows = False
        Me.Datagridview1.AllowUserToDeleteRows = False
        Me.Datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datagridview1.Location = New System.Drawing.Point(124, 182)
        Me.Datagridview1.Name = "Datagridview1"
        Me.Datagridview1.ReadOnly = True
        Me.Datagridview1.Size = New System.Drawing.Size(500, 471)
        Me.Datagridview1.TabIndex = 2
        '
        'TxtStoreName
        '
        Me.TxtStoreName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtStoreName.Location = New System.Drawing.Point(199, 128)
        Me.TxtStoreName.Name = "TxtStoreName"
        Me.TxtStoreName.Size = New System.Drawing.Size(425, 22)
        Me.TxtStoreName.TabIndex = 1
        '
        'FrmStore
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1015, 706)
        Me.ControlBox = False
        Me.Controls.Add(Me.Datagridview1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TxtStoreID)
        Me.Controls.Add(Me.TxtStoreName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmStore"
        Me.Text = "Chk digit"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Datagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtStoreID As System.Windows.Forms.TextBox
    Friend WithEvents CmdNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Datagridview1 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtStoreName As System.Windows.Forms.TextBox
End Class
