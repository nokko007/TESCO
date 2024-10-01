<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDailyKeyin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDailyKeyin))
        Me.Cmdexit = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.cmdCarlendar1 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.OptKeyin = New System.Windows.Forms.RadioButton
        Me.OptQC = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CRViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmdexit
        '
        Me.Cmdexit.BackColor = System.Drawing.SystemColors.Control
        Me.Cmdexit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdexit.Location = New System.Drawing.Point(593, 30)
        Me.Cmdexit.Name = "Cmdexit"
        Me.Cmdexit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cmdexit.Size = New System.Drawing.Size(139, 24)
        Me.Cmdexit.TabIndex = 68
        Me.Cmdexit.Text = "Exit"
        Me.Cmdexit.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(189, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "วันที่ "
        Me.Label19.Visible = False
        '
        'txtDate
        '
        Me.txtDate.AcceptsReturn = True
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDate.Enabled = False
        Me.txtDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDate.Location = New System.Drawing.Point(232, 84)
        Me.txtDate.MaxLength = 50
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDate.Size = New System.Drawing.Size(110, 20)
        Me.txtDate.TabIndex = 70
        Me.txtDate.TabStop = False
        Me.txtDate.Visible = False
        '
        'cmdCarlendar1
        '
        Me.cmdCarlendar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmdCarlendar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCarlendar1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCarlendar1.Image = CType(resources.GetObject("cmdCarlendar1.Image"), System.Drawing.Image)
        Me.cmdCarlendar1.Location = New System.Drawing.Point(361, 79)
        Me.cmdCarlendar1.Name = "cmdCarlendar1"
        Me.cmdCarlendar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCarlendar1.Size = New System.Drawing.Size(24, 25)
        Me.cmdCarlendar1.TabIndex = 71
        Me.cmdCarlendar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCarlendar1.UseVisualStyleBackColor = False
        Me.cmdCarlendar1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(430, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 25)
        Me.Button1.TabIndex = 69
        Me.Button1.Text = "Load Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OptKeyin
        '
        Me.OptKeyin.AutoSize = True
        Me.OptKeyin.Location = New System.Drawing.Point(20, 19)
        Me.OptKeyin.Name = "OptKeyin"
        Me.OptKeyin.Size = New System.Drawing.Size(51, 17)
        Me.OptKeyin.TabIndex = 74
        Me.OptKeyin.TabStop = True
        Me.OptKeyin.Text = "Keyin"
        Me.OptKeyin.UseVisualStyleBackColor = True
        '
        'OptQC
        '
        Me.OptQC.AutoSize = True
        Me.OptQC.Location = New System.Drawing.Point(120, 19)
        Me.OptQC.Name = "OptQC"
        Me.OptQC.Size = New System.Drawing.Size(40, 17)
        Me.OptQC.TabIndex = 74
        Me.OptQC.TabStop = True
        Me.OptQC.Text = "QC"
        Me.OptQC.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptKeyin)
        Me.GroupBox1.Controls.Add(Me.OptQC)
        Me.GroupBox1.Location = New System.Drawing.Point(182, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 55)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Report Type"
        '
        'CRViewer1
        '
        Me.CRViewer1.ActiveViewIndex = -1
        Me.CRViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewer1.Location = New System.Drawing.Point(28, 112)
        Me.CRViewer1.Name = "CRViewer1"
        Me.CRViewer1.SelectionFormula = ""
        Me.CRViewer1.Size = New System.Drawing.Size(869, 567)
        Me.CRViewer1.TabIndex = 73
        Me.CRViewer1.ViewTimeSelectionFormula = ""
        '
        'FrmDailyKeyin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1015, 706)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CRViewer1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.cmdCarlendar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Cmdexit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmDailyKeyin"
        Me.Text = "FrmDAily"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents txtDate As System.Windows.Forms.TextBox
    Public WithEvents cmdCarlendar1 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OptKeyin As System.Windows.Forms.RadioButton
    Friend WithEvents OptQC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CRViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
