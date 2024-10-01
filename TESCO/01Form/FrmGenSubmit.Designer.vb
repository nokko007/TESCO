<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenSubmit
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGenSubmit))
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Cmdexit = New System.Windows.Forms.Button
        Me.cmdCarlendar1 = New System.Windows.Forms.Button
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.CmdCopySigned = New System.Windows.Forms.Button
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtRecno = New System.Windows.Forms.TextBox
        Me.TxtTarget = New System.Windows.Forms.TextBox
        Me.Txtsourcesign = New System.Windows.Forms.TextBox
        Me.TxtFilecnt = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.CmdSubmit = New System.Windows.Forms.Button
        Me.TxtsourceUnsign = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Listsigned = New System.Windows.Forms.ListBox
        Me.Listunsigned = New System.Windows.Forms.ListBox
        Me.Listsignederror = New System.Windows.Forms.ListBox
        Me.Listunsignederror = New System.Windows.Forms.ListBox
        Me.Listsigned_OK = New System.Windows.Forms.ListBox
        Me.Listunsigned_OK = New System.Windows.Forms.ListBox
        Me.CmdCopyunSigned = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Optsigned = New System.Windows.Forms.RadioButton
        Me.Optunsigned = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.CmdBrowse = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TxtOK = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtError = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.CmdSaveLogOK = New System.Windows.Forms.Button
        Me.CmdSavelogError = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(681, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "วันที่"
        Me.Label2.Visible = False
        '
        'Cmdexit
        '
        Me.Cmdexit.BackColor = System.Drawing.SystemColors.Control
        Me.Cmdexit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdexit.Location = New System.Drawing.Point(453, 174)
        Me.Cmdexit.Name = "Cmdexit"
        Me.Cmdexit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cmdexit.Size = New System.Drawing.Size(139, 24)
        Me.Cmdexit.TabIndex = 19
        Me.Cmdexit.Text = "Exit"
        Me.Cmdexit.UseVisualStyleBackColor = False
        '
        'cmdCarlendar1
        '
        Me.cmdCarlendar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmdCarlendar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCarlendar1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCarlendar1.Image = CType(resources.GetObject("cmdCarlendar1.Image"), System.Drawing.Image)
        Me.cmdCarlendar1.Location = New System.Drawing.Point(917, 132)
        Me.cmdCarlendar1.Name = "cmdCarlendar1"
        Me.cmdCarlendar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCarlendar1.Size = New System.Drawing.Size(25, 25)
        Me.cmdCarlendar1.TabIndex = 17
        Me.cmdCarlendar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCarlendar1.UseVisualStyleBackColor = False
        Me.cmdCarlendar1.Visible = False
        '
        'txtDate
        '
        Me.txtDate.AcceptsReturn = True
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDate.Enabled = False
        Me.txtDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDate.Location = New System.Drawing.Point(791, 132)
        Me.txtDate.MaxLength = 50
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDate.Size = New System.Drawing.Size(111, 20)
        Me.txtDate.TabIndex = 16
        Me.txtDate.TabStop = False
        Me.txtDate.Visible = False
        '
        'CmdCopySigned
        '
        Me.CmdCopySigned.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCopySigned.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdCopySigned.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdCopySigned.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdCopySigned.Location = New System.Drawing.Point(698, 308)
        Me.CmdCopySigned.Name = "CmdCopySigned"
        Me.CmdCopySigned.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdCopySigned.Size = New System.Drawing.Size(139, 24)
        Me.CmdCopySigned.TabIndex = 15
        Me.CmdCopySigned.Text = "Copy SIGN IMG File"
        Me.CmdCopySigned.UseVisualStyleBackColor = False
        Me.CmdCopySigned.Visible = False
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(341, 28)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(139, 25)
        Me.CmdSearch.TabIndex = 20
        Me.CmdSearch.Text = "Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(88, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "จำนวน"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "รายการ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(681, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Source-signed"
        Me.Label6.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(681, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Target"
        Me.Label9.Visible = False
        '
        'TxtRecno
        '
        Me.TxtRecno.Location = New System.Drawing.Point(152, 73)
        Me.TxtRecno.Name = "TxtRecno"
        Me.TxtRecno.Size = New System.Drawing.Size(68, 20)
        Me.TxtRecno.TabIndex = 32
        '
        'TxtTarget
        '
        Me.TxtTarget.AcceptsReturn = True
        Me.TxtTarget.Location = New System.Drawing.Point(791, 232)
        Me.TxtTarget.Name = "TxtTarget"
        Me.TxtTarget.Size = New System.Drawing.Size(408, 20)
        Me.TxtTarget.TabIndex = 30
        Me.TxtTarget.Text = "D:\Test_Tesco_IMG\20120614\"
        Me.TxtTarget.Visible = False
        '
        'Txtsourcesign
        '
        Me.Txtsourcesign.AcceptsReturn = True
        Me.Txtsourcesign.Location = New System.Drawing.Point(791, 158)
        Me.Txtsourcesign.Name = "Txtsourcesign"
        Me.Txtsourcesign.Size = New System.Drawing.Size(408, 20)
        Me.Txtsourcesign.TabIndex = 31
        Me.Txtsourcesign.Text = "\\192.168.0.69\Good App-Named\"
        Me.Txtsourcesign.Visible = False
        '
        'TxtFilecnt
        '
        Me.TxtFilecnt.Location = New System.Drawing.Point(791, 282)
        Me.TxtFilecnt.Name = "TxtFilecnt"
        Me.TxtFilecnt.Size = New System.Drawing.Size(68, 20)
        Me.TxtFilecnt.TabIndex = 42
        Me.TxtFilecnt.Text = "50"
        Me.TxtFilecnt.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(882, 285)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "รายการ"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(681, 285)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "จำนวน file ต่อ 1 folder"
        Me.Label11.Visible = False
        '
        'CmdSubmit
        '
        Me.CmdSubmit.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSubmit.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdSubmit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSubmit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdSubmit.Location = New System.Drawing.Point(341, 70)
        Me.CmdSubmit.Name = "CmdSubmit"
        Me.CmdSubmit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdSubmit.Size = New System.Drawing.Size(139, 24)
        Me.CmdSubmit.TabIndex = 15
        Me.CmdSubmit.Text = "Update to Submit"
        Me.CmdSubmit.UseVisualStyleBackColor = False
        '
        'TxtsourceUnsign
        '
        Me.TxtsourceUnsign.AcceptsReturn = True
        Me.TxtsourceUnsign.Location = New System.Drawing.Point(791, 195)
        Me.TxtsourceUnsign.Name = "TxtsourceUnsign"
        Me.TxtsourceUnsign.Size = New System.Drawing.Size(408, 20)
        Me.TxtsourceUnsign.TabIndex = 44
        Me.TxtsourceUnsign.Text = "\\192.168.0.69\Unsigned App-Named\"
        Me.TxtsourceUnsign.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(681, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Source-unsigned"
        Me.Label4.Visible = False
        '
        'Listsigned
        '
        Me.Listsigned.FormattingEnabled = True
        Me.Listsigned.Location = New System.Drawing.Point(26, 218)
        Me.Listsigned.Name = "Listsigned"
        Me.Listsigned.Size = New System.Drawing.Size(566, 160)
        Me.Listsigned.TabIndex = 45
        '
        'Listunsigned
        '
        Me.Listunsigned.FormattingEnabled = True
        Me.Listunsigned.Location = New System.Drawing.Point(712, 417)
        Me.Listunsigned.Name = "Listunsigned"
        Me.Listunsigned.Size = New System.Drawing.Size(390, 108)
        Me.Listunsigned.TabIndex = 46
        Me.Listunsigned.Visible = False
        '
        'Listsignederror
        '
        Me.Listsignederror.FormattingEnabled = True
        Me.Listsignederror.Location = New System.Drawing.Point(317, 417)
        Me.Listsignederror.Name = "Listsignederror"
        Me.Listsignederror.Size = New System.Drawing.Size(274, 277)
        Me.Listsignederror.TabIndex = 45
        '
        'Listunsignederror
        '
        Me.Listunsignederror.FormattingEnabled = True
        Me.Listunsignederror.Location = New System.Drawing.Point(916, 566)
        Me.Listunsignederror.Name = "Listunsignederror"
        Me.Listunsignederror.Size = New System.Drawing.Size(186, 173)
        Me.Listunsignederror.TabIndex = 45
        Me.Listunsignederror.Visible = False
        '
        'Listsigned_OK
        '
        Me.Listsigned_OK.FormattingEnabled = True
        Me.Listsigned_OK.Location = New System.Drawing.Point(27, 417)
        Me.Listsigned_OK.Name = "Listsigned_OK"
        Me.Listsigned_OK.Size = New System.Drawing.Size(274, 277)
        Me.Listsigned_OK.TabIndex = 45
        '
        'Listunsigned_OK
        '
        Me.Listunsigned_OK.FormattingEnabled = True
        Me.Listunsigned_OK.Location = New System.Drawing.Point(712, 566)
        Me.Listunsigned_OK.Name = "Listunsigned_OK"
        Me.Listunsigned_OK.Size = New System.Drawing.Size(186, 173)
        Me.Listunsigned_OK.TabIndex = 45
        Me.Listunsigned_OK.Visible = False
        '
        'CmdCopyunSigned
        '
        Me.CmdCopyunSigned.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCopyunSigned.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdCopyunSigned.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdCopyunSigned.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdCopyunSigned.Location = New System.Drawing.Point(1112, 225)
        Me.CmdCopyunSigned.Name = "CmdCopyunSigned"
        Me.CmdCopyunSigned.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdCopyunSigned.Size = New System.Drawing.Size(139, 24)
        Me.CmdCopyunSigned.TabIndex = 15
        Me.CmdCopyunSigned.Text = "Copy UNSIGNED IMG File"
        Me.CmdCopyunSigned.UseVisualStyleBackColor = False
        Me.CmdCopyunSigned.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "List to Generate"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(718, 401)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "List Unsigned app. to Generate"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 397)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 13)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "List Generate OK"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(314, 397)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "List Generate error"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(711, 550)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(161, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "List unsigned app.  Generate OK"
        Me.Label15.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(900, 550)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(167, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "List unsigned app.  Generate error"
        Me.Label16.Visible = False
        '
        'Optsigned
        '
        Me.Optsigned.AutoSize = True
        Me.Optsigned.Location = New System.Drawing.Point(80, 36)
        Me.Optsigned.Name = "Optsigned"
        Me.Optsigned.Size = New System.Drawing.Size(58, 17)
        Me.Optsigned.TabIndex = 48
        Me.Optsigned.TabStop = True
        Me.Optsigned.Text = "Signed"
        Me.Optsigned.UseVisualStyleBackColor = True
        '
        'Optunsigned
        '
        Me.Optunsigned.AutoSize = True
        Me.Optunsigned.Location = New System.Drawing.Point(235, 36)
        Me.Optunsigned.Name = "Optunsigned"
        Me.Optunsigned.Size = New System.Drawing.Size(70, 17)
        Me.Optunsigned.TabIndex = 49
        Me.Optunsigned.TabStop = True
        Me.Optunsigned.Text = "Unsigned"
        Me.Optunsigned.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Optunsigned)
        Me.GroupBox1.Controls.Add(Me.TxtRecno)
        Me.GroupBox1.Controls.Add(Me.Optsigned)
        Me.GroupBox1.Controls.Add(Me.CmdSearch)
        Me.GroupBox1.Controls.Add(Me.CmdSubmit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(566, 156)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "XML Type"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(49, 124)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(474, 12)
        Me.ProgressBar1.TabIndex = 50
        Me.ProgressBar1.Visible = False
        '
        'CmdBrowse
        '
        Me.CmdBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CmdBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdBrowse.Image = CType(resources.GetObject("CmdBrowse.Image"), System.Drawing.Image)
        Me.CmdBrowse.Location = New System.Drawing.Point(1205, 182)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdBrowse.Size = New System.Drawing.Size(25, 25)
        Me.CmdBrowse.TabIndex = 51
        Me.CmdBrowse.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdBrowse.UseVisualStyleBackColor = False
        Me.CmdBrowse.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'TxtOK
        '
        Me.TxtOK.Location = New System.Drawing.Point(160, 394)
        Me.TxtOK.Name = "TxtOK"
        Me.TxtOK.Size = New System.Drawing.Size(68, 20)
        Me.TxtOK.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(114, 397)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "จำนวน"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(258, 397)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "รายการ"
        '
        'TxtError
        '
        Me.TxtError.Location = New System.Drawing.Point(474, 394)
        Me.TxtError.Name = "TxtError"
        Me.TxtError.Size = New System.Drawing.Size(68, 20)
        Me.TxtError.TabIndex = 57
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(414, 397)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "จำนวน"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(548, 397)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "รายการ"
        '
        'CmdSaveLogOK
        '
        Me.CmdSaveLogOK.Location = New System.Drawing.Point(26, 700)
        Me.CmdSaveLogOK.Name = "CmdSaveLogOK"
        Me.CmdSaveLogOK.Size = New System.Drawing.Size(94, 21)
        Me.CmdSaveLogOK.TabIndex = 58
        Me.CmdSaveLogOK.Text = "Savelog"
        Me.CmdSaveLogOK.UseVisualStyleBackColor = True
        '
        'CmdSavelogError
        '
        Me.CmdSavelogError.Location = New System.Drawing.Point(317, 700)
        Me.CmdSavelogError.Name = "CmdSavelogError"
        Me.CmdSavelogError.Size = New System.Drawing.Size(94, 21)
        Me.CmdSavelogError.TabIndex = 58
        Me.CmdSavelogError.Text = "Savelog"
        Me.CmdSavelogError.UseVisualStyleBackColor = True
        '
        'FrmGenSubmit
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1082, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdSavelogError)
        Me.Controls.Add(Me.CmdSaveLogOK)
        Me.Controls.Add(Me.TxtError)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtOK)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CmdBrowse)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Listunsigned)
        Me.Controls.Add(Me.Listunsignederror)
        Me.Controls.Add(Me.Listsignederror)
        Me.Controls.Add(Me.Listunsigned_OK)
        Me.Controls.Add(Me.Listsigned_OK)
        Me.Controls.Add(Me.Listsigned)
        Me.Controls.Add(Me.TxtsourceUnsign)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtFilecnt)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txtsourcesign)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cmdexit)
        Me.Controls.Add(Me.TxtTarget)
        Me.Controls.Add(Me.cmdCarlendar1)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CmdCopyunSigned)
        Me.Controls.Add(Me.CmdCopySigned)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGenSubmit"
        Me.Text = "Generate Submit"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Cmdexit As System.Windows.Forms.Button
    Public WithEvents cmdCarlendar1 As System.Windows.Forms.Button
    Public WithEvents txtDate As System.Windows.Forms.TextBox
    Public WithEvents CmdCopySigned As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtRecno As System.Windows.Forms.TextBox
    Friend WithEvents TxtTarget As System.Windows.Forms.TextBox
    Friend WithEvents Txtsourcesign As System.Windows.Forms.TextBox
    Friend WithEvents TxtFilecnt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents CmdSubmit As System.Windows.Forms.Button
    Friend WithEvents TxtsourceUnsign As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Listsigned As System.Windows.Forms.ListBox
    Friend WithEvents Listunsigned As System.Windows.Forms.ListBox
    Friend WithEvents Listsignederror As System.Windows.Forms.ListBox
    Friend WithEvents Listunsignederror As System.Windows.Forms.ListBox
    Friend WithEvents Listsigned_OK As System.Windows.Forms.ListBox
    Friend WithEvents Listunsigned_OK As System.Windows.Forms.ListBox
    Public WithEvents CmdCopyunSigned As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Optsigned As System.Windows.Forms.RadioButton
    Friend WithEvents Optunsigned As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TxtOK As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtError As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CmdSaveLogOK As System.Windows.Forms.Button
    Friend WithEvents CmdSavelogError As System.Windows.Forms.Button

End Class
