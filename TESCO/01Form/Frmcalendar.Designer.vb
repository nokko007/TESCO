<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmcalendar
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
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmbYear = New System.Windows.Forms.ComboBox
        Me.cmbMonth = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me._lblDate_0 = New System.Windows.Forms.Label
        Me._lblDate_1 = New System.Windows.Forms.Label
        Me.LblCaption = New System.Windows.Forms.Label
        Me._lblDate_2 = New System.Windows.Forms.Label
        Me._lblDate_3 = New System.Windows.Forms.Label
        Me._lblDate_5 = New System.Windows.Forms.Label
        Me._lblDate_4 = New System.Windows.Forms.Label
        Me._lblDate_6 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cmdYRight = New System.Windows.Forms.Label
        Me.cmdMRight = New System.Windows.Forms.Label
        Me.cmdYLeft = New System.Windows.Forms.Label
        Me.cmdMLeft = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(70, 223)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(61, 29)
        Me.cmdOk.TabIndex = 18
        Me.cmdOk.Text = "ตกลง"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmbYear
        '
        Me.cmbYear.BackColor = System.Drawing.Color.White
        Me.cmbYear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbYear.Location = New System.Drawing.Point(166, 12)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbYear.Size = New System.Drawing.Size(63, 21)
        Me.cmbYear.TabIndex = 5
        '
        'cmbMonth
        '
        Me.cmbMonth.BackColor = System.Drawing.Color.White
        Me.cmbMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMonth.Location = New System.Drawing.Point(28, 12)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMonth.Size = New System.Drawing.Size(80, 21)
        Me.cmbMonth.TabIndex = 4
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(138, 223)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(61, 29)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        '_lblDate_0
        '
        Me._lblDate_0.BackColor = System.Drawing.Color.White
        Me._lblDate_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDate_0.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me._lblDate_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._lblDate_0.Location = New System.Drawing.Point(4, 40)
        Me._lblDate_0.Name = "_lblDate_0"
        Me._lblDate_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDate_0.Size = New System.Drawing.Size(36, 18)
        Me._lblDate_0.TabIndex = 16
        Me._lblDate_0.Text = "อาทิตย์"
        Me._lblDate_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_1
        '
        Me._lblDate_1.BackColor = System.Drawing.Color.White
        Me._lblDate_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDate_1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me._lblDate_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblDate_1.Location = New System.Drawing.Point(40, 40)
        Me._lblDate_1.Name = "_lblDate_1"
        Me._lblDate_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDate_1.Size = New System.Drawing.Size(36, 18)
        Me._lblDate_1.TabIndex = 15
        Me._lblDate_1.Text = "จันทร์"
        Me._lblDate_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCaption
        '
        Me.LblCaption.BackColor = System.Drawing.Color.Transparent
        Me.LblCaption.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblCaption.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCaption.Location = New System.Drawing.Point(6, 7)
        Me.LblCaption.Name = "LblCaption"
        Me.LblCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCaption.Size = New System.Drawing.Size(249, 25)
        Me.LblCaption.TabIndex = 22
        Me.LblCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblDate_2
        '
        Me._lblDate_2.BackColor = System.Drawing.Color.White
        Me._lblDate_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDate_2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me._lblDate_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblDate_2.Location = New System.Drawing.Point(76, 40)
        Me._lblDate_2.Name = "_lblDate_2"
        Me._lblDate_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDate_2.Size = New System.Drawing.Size(36, 18)
        Me._lblDate_2.TabIndex = 14
        Me._lblDate_2.Text = "อังคาร"
        Me._lblDate_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_3
        '
        Me._lblDate_3.BackColor = System.Drawing.Color.White
        Me._lblDate_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDate_3.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me._lblDate_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblDate_3.Location = New System.Drawing.Point(112, 40)
        Me._lblDate_3.Name = "_lblDate_3"
        Me._lblDate_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDate_3.Size = New System.Drawing.Size(36, 18)
        Me._lblDate_3.TabIndex = 13
        Me._lblDate_3.Text = "พุธ"
        Me._lblDate_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_5
        '
        Me._lblDate_5.BackColor = System.Drawing.Color.White
        Me._lblDate_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDate_5.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me._lblDate_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblDate_5.Location = New System.Drawing.Point(184, 40)
        Me._lblDate_5.Name = "_lblDate_5"
        Me._lblDate_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDate_5.Size = New System.Drawing.Size(36, 18)
        Me._lblDate_5.TabIndex = 11
        Me._lblDate_5.Text = "ศุกร์"
        Me._lblDate_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_4
        '
        Me._lblDate_4.BackColor = System.Drawing.Color.White
        Me._lblDate_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDate_4.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me._lblDate_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblDate_4.Location = New System.Drawing.Point(148, 40)
        Me._lblDate_4.Name = "_lblDate_4"
        Me._lblDate_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDate_4.Size = New System.Drawing.Size(36, 18)
        Me._lblDate_4.TabIndex = 12
        Me._lblDate_4.Text = "พฤหัสฯ"
        Me._lblDate_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_6
        '
        Me._lblDate_6.BackColor = System.Drawing.Color.White
        Me._lblDate_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDate_6.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me._lblDate_6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me._lblDate_6.Location = New System.Drawing.Point(220, 40)
        Me._lblDate_6.Name = "_lblDate_6"
        Me._lblDate_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDate_6.Size = New System.Drawing.Size(36, 18)
        Me._lblDate_6.TabIndex = 10
        Me._lblDate_6.Text = "เสาร์"
        Me._lblDate_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Frame1.Controls.Add(Me.cmbYear)
        Me.Frame1.Controls.Add(Me.cmbMonth)
        Me.Frame1.Controls.Add(Me._lblDate_0)
        Me.Frame1.Controls.Add(Me._lblDate_1)
        Me.Frame1.Controls.Add(Me._lblDate_2)
        Me.Frame1.Controls.Add(Me._lblDate_3)
        Me.Frame1.Controls.Add(Me._lblDate_4)
        Me.Frame1.Controls.Add(Me._lblDate_5)
        Me.Frame1.Controls.Add(Me._lblDate_6)
        Me.Frame1.Controls.Add(Me.cmdYRight)
        Me.Frame1.Controls.Add(Me.cmdMRight)
        Me.Frame1.Controls.Add(Me.cmdYLeft)
        Me.Frame1.Controls.Add(Me.cmdMLeft)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(2, 27)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(259, 65)
        Me.Frame1.TabIndex = 21
        Me.Frame1.TabStop = False
        '
        'cmdYRight
        '
        Me.cmdYRight.AutoSize = True
        Me.cmdYRight.BackColor = System.Drawing.Color.Transparent
        Me.cmdYRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdYRight.ForeColor = System.Drawing.Color.Blue
        Me.cmdYRight.Location = New System.Drawing.Point(232, 16)
        Me.cmdYRight.Name = "cmdYRight"
        Me.cmdYRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdYRight.Size = New System.Drawing.Size(19, 13)
        Me.cmdYRight.TabIndex = 9
        Me.cmdYRight.Text = ">>"
        '
        'cmdMRight
        '
        Me.cmdMRight.AutoSize = True
        Me.cmdMRight.BackColor = System.Drawing.Color.Transparent
        Me.cmdMRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMRight.ForeColor = System.Drawing.Color.Blue
        Me.cmdMRight.Location = New System.Drawing.Point(108, 16)
        Me.cmdMRight.Name = "cmdMRight"
        Me.cmdMRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMRight.Size = New System.Drawing.Size(19, 13)
        Me.cmdMRight.TabIndex = 8
        Me.cmdMRight.Text = ">>"
        '
        'cmdYLeft
        '
        Me.cmdYLeft.AutoSize = True
        Me.cmdYLeft.BackColor = System.Drawing.Color.Transparent
        Me.cmdYLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdYLeft.ForeColor = System.Drawing.Color.Blue
        Me.cmdYLeft.Location = New System.Drawing.Point(148, 16)
        Me.cmdYLeft.Name = "cmdYLeft"
        Me.cmdYLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdYLeft.Size = New System.Drawing.Size(19, 13)
        Me.cmdYLeft.TabIndex = 7
        Me.cmdYLeft.Text = "<<"
        '
        'cmdMLeft
        '
        Me.cmdMLeft.AutoSize = True
        Me.cmdMLeft.BackColor = System.Drawing.Color.Transparent
        Me.cmdMLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMLeft.ForeColor = System.Drawing.Color.Blue
        Me.cmdMLeft.Location = New System.Drawing.Point(12, 16)
        Me.cmdMLeft.Name = "cmdMLeft"
        Me.cmdMLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMLeft.Size = New System.Drawing.Size(19, 13)
        Me.cmdMLeft.TabIndex = 6
        Me.cmdMLeft.Text = "<<"
        '
        'Frmcalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 259)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.LblCaption)
        Me.Controls.Add(Me.Frame1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frmcalendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กรุณาเลือกวันที่"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents cmbYear As System.Windows.Forms.ComboBox
    Public WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents _lblDate_0 As System.Windows.Forms.Label
    Public WithEvents _lblDate_1 As System.Windows.Forms.Label
    Public WithEvents LblCaption As System.Windows.Forms.Label
    Public WithEvents _lblDate_2 As System.Windows.Forms.Label
    Public WithEvents _lblDate_3 As System.Windows.Forms.Label
    Public WithEvents _lblDate_5 As System.Windows.Forms.Label
    Public WithEvents _lblDate_4 As System.Windows.Forms.Label
    Public WithEvents _lblDate_6 As System.Windows.Forms.Label

    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdYRight As System.Windows.Forms.Label
    Public WithEvents cmdMRight As System.Windows.Forms.Label
    Public WithEvents cmdYLeft As System.Windows.Forms.Label
    Public WithEvents cmdMLeft As System.Windows.Forms.Label
End Class
