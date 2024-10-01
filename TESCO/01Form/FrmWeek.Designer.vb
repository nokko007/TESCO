<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWeek
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWeek))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.CmdNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.TxtWeekNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtWeekId = New System.Windows.Forms.TextBox
        Me.cmdCarlendar1 = New System.Windows.Forms.Button
        Me.Datagridview1 = New System.Windows.Forms.DataGridView
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
        Me.Label19.Text = "Pickup Date"
        '
        'txtDate
        '
        Me.txtDate.AcceptsReturn = True
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDate.Enabled = False
        Me.txtDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDate.Location = New System.Drawing.Point(199, 128)
        Me.txtDate.MaxLength = 50
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDate.Size = New System.Drawing.Size(111, 22)
        Me.txtDate.TabIndex = 1
        Me.txtDate.TabStop = False
        '
        'TxtWeekNo
        '
        Me.TxtWeekNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtWeekNo.Location = New System.Drawing.Point(242, 91)
        Me.TxtWeekNo.Name = "TxtWeekNo"
        Me.TxtWeekNo.Size = New System.Drawing.Size(68, 22)
        Me.TxtWeekNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(121, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Week No."
        '
        'TxtWeekId
        '
        Me.TxtWeekId.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtWeekId.Enabled = False
        Me.TxtWeekId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtWeekId.Location = New System.Drawing.Point(199, 91)
        Me.TxtWeekId.Name = "TxtWeekId"
        Me.TxtWeekId.Size = New System.Drawing.Size(37, 22)
        Me.TxtWeekId.TabIndex = 70
        '
        'cmdCarlendar1
        '
        Me.cmdCarlendar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmdCarlendar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCarlendar1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCarlendar1.Image = CType(resources.GetObject("cmdCarlendar1.Image"), System.Drawing.Image)
        Me.cmdCarlendar1.Location = New System.Drawing.Point(316, 128)
        Me.cmdCarlendar1.Name = "cmdCarlendar1"
        Me.cmdCarlendar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCarlendar1.Size = New System.Drawing.Size(25, 25)
        Me.cmdCarlendar1.TabIndex = 2
        Me.cmdCarlendar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCarlendar1.UseVisualStyleBackColor = False
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
        Me.Datagridview1.TabIndex = 74
        '
        'FrmWeek
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1015, 706)
        Me.ControlBox = False
        Me.Controls.Add(Me.Datagridview1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.cmdCarlendar1)
        Me.Controls.Add(Me.TxtWeekId)
        Me.Controls.Add(Me.TxtWeekNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmWeek"
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
    Public WithEvents txtDate As System.Windows.Forms.TextBox
    Public WithEvents cmdCarlendar1 As System.Windows.Forms.Button
    Friend WithEvents TxtWeekNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtWeekId As System.Windows.Forms.TextBox
    Friend WithEvents CmdNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Datagridview1 As System.Windows.Forms.DataGridView
End Class
