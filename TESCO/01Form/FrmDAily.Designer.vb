<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDAily
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
        Me.Txtstartweek = New System.Windows.Forms.TextBox
        Me.CmdStep1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmdexit = New System.Windows.Forms.Button
        Me.CmbStartweek = New System.Windows.Forms.ComboBox
        Me.CmbEndweek = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.dg1 = New System.Windows.Forms.DataGridView
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txtstartweek
        '
        Me.Txtstartweek.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Txtstartweek.Location = New System.Drawing.Point(340, 70)
        Me.Txtstartweek.Name = "Txtstartweek"
        Me.Txtstartweek.Size = New System.Drawing.Size(126, 20)
        Me.Txtstartweek.TabIndex = 67
        '
        'CmdStep1
        '
        Me.CmdStep1.BackColor = System.Drawing.SystemColors.Control
        Me.CmdStep1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdStep1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdStep1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStep1.Location = New System.Drawing.Point(278, 152)
        Me.CmdStep1.Name = "CmdStep1"
        Me.CmdStep1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdStep1.Size = New System.Drawing.Size(139, 24)
        Me.CmdStep1.TabIndex = 64
        Me.CmdStep1.Text = "Step1 add counting date"
        Me.CmdStep1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "กรุณาเลือก week เริ่มต้น"
        '
        'Cmdexit
        '
        Me.Cmdexit.BackColor = System.Drawing.SystemColors.Control
        Me.Cmdexit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdexit.Location = New System.Drawing.Point(437, 152)
        Me.Cmdexit.Name = "Cmdexit"
        Me.Cmdexit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cmdexit.Size = New System.Drawing.Size(139, 24)
        Me.Cmdexit.TabIndex = 68
        Me.Cmdexit.Text = "Exit"
        Me.Cmdexit.UseVisualStyleBackColor = False
        '
        'CmbStartweek
        '
        Me.CmbStartweek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStartweek.FormattingEnabled = True
        Me.CmbStartweek.Location = New System.Drawing.Point(278, 69)
        Me.CmbStartweek.Name = "CmbStartweek"
        Me.CmbStartweek.Size = New System.Drawing.Size(56, 21)
        Me.CmbStartweek.TabIndex = 69
        '
        'CmbEndweek
        '
        Me.CmbEndweek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEndweek.FormattingEnabled = True
        Me.CmbEndweek.Location = New System.Drawing.Point(278, 107)
        Me.CmbEndweek.Name = "CmbEndweek"
        Me.CmbEndweek.Size = New System.Drawing.Size(56, 21)
        Me.CmbEndweek.TabIndex = 72
        Me.CmbEndweek.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox1.Location = New System.Drawing.Point(340, 108)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(126, 20)
        Me.TextBox1.TabIndex = 71
        Me.TextBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "กรุณาเลือก week สิ้นสุด"
        Me.Label2.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(2, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(139, 24)
        Me.Button1.TabIndex = 64
        Me.Button1.Text = "Generate Report"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dg1
        '
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Location = New System.Drawing.Point(62, 275)
        Me.dg1.Name = "dg1"
        Me.dg1.Size = New System.Drawing.Size(634, 118)
        Me.dg1.TabIndex = 73
        '
        'FrmDAily
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(900, 506)
        Me.ControlBox = False
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.CmbEndweek)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbStartweek)
        Me.Controls.Add(Me.Txtstartweek)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CmdStep1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmdexit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmDAily"
        Me.Text = "FrmDAily"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtstartweek As System.Windows.Forms.TextBox
    Public WithEvents CmdStep1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmbStartweek As System.Windows.Forms.ComboBox
    Friend WithEvents CmbEndweek As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
End Class
