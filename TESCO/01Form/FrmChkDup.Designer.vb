<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChkDup
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
        Me.CmdGenreport = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmdexit = New System.Windows.Forms.Button
        Me.CmbStartweek = New System.Windows.Forms.ComboBox
        Me.CmbMAilbag = New System.Windows.Forms.ComboBox
        Me.TxtMailbag = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txtenvelope = New System.Windows.Forms.TextBox
        Me.CmbEnvelope = New System.Windows.Forms.ComboBox
        Me.TxtDate = New System.Windows.Forms.TextBox
        Me.TxtDC = New System.Windows.Forms.TextBox
        Me.TxtStore = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.TxtDup = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Txtstartweek
        '
        Me.Txtstartweek.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Txtstartweek.Location = New System.Drawing.Point(393, 70)
        Me.Txtstartweek.Name = "Txtstartweek"
        Me.Txtstartweek.Size = New System.Drawing.Size(126, 20)
        Me.Txtstartweek.TabIndex = 67
        '
        'CmdGenreport
        '
        Me.CmdGenreport.BackColor = System.Drawing.SystemColors.Control
        Me.CmdGenreport.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdGenreport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdGenreport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdGenreport.Location = New System.Drawing.Point(278, 422)
        Me.CmdGenreport.Name = "CmdGenreport"
        Me.CmdGenreport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdGenreport.Size = New System.Drawing.Size(139, 24)
        Me.CmdGenreport.TabIndex = 64
        Me.CmdGenreport.Text = "Check Dup"
        Me.CmdGenreport.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "กรุณาเลือก week"
        '
        'Cmdexit
        '
        Me.Cmdexit.BackColor = System.Drawing.SystemColors.Control
        Me.Cmdexit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdexit.Location = New System.Drawing.Point(278, 463)
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
        Me.CmbStartweek.Size = New System.Drawing.Size(109, 21)
        Me.CmbStartweek.TabIndex = 69
        '
        'CmbMAilbag
        '
        Me.CmbMAilbag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMAilbag.FormattingEnabled = True
        Me.CmbMAilbag.Location = New System.Drawing.Point(278, 103)
        Me.CmbMAilbag.Name = "CmbMAilbag"
        Me.CmbMAilbag.Size = New System.Drawing.Size(109, 21)
        Me.CmbMAilbag.TabIndex = 72
        '
        'TxtMailbag
        '
        Me.TxtMailbag.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtMailbag.Location = New System.Drawing.Point(393, 104)
        Me.TxtMailbag.Name = "TxtMailbag"
        Me.TxtMailbag.Size = New System.Drawing.Size(126, 20)
        Me.TxtMailbag.TabIndex = 71
        Me.TxtMailbag.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "กรุณาเลือก MailBag"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(138, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "กรุณาเลือก Envelope"
        '
        'Txtenvelope
        '
        Me.Txtenvelope.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Txtenvelope.Location = New System.Drawing.Point(393, 137)
        Me.Txtenvelope.Name = "Txtenvelope"
        Me.Txtenvelope.Size = New System.Drawing.Size(126, 20)
        Me.Txtenvelope.TabIndex = 71
        Me.Txtenvelope.Visible = False
        '
        'CmbEnvelope
        '
        Me.CmbEnvelope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEnvelope.FormattingEnabled = True
        Me.CmbEnvelope.Location = New System.Drawing.Point(278, 137)
        Me.CmbEnvelope.Name = "CmbEnvelope"
        Me.CmbEnvelope.Size = New System.Drawing.Size(109, 21)
        Me.CmbEnvelope.TabIndex = 72
        '
        'TxtDate
        '
        Me.TxtDate.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtDate.Location = New System.Drawing.Point(278, 211)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(84, 20)
        Me.TxtDate.TabIndex = 71
        '
        'TxtDC
        '
        Me.TxtDC.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtDC.Location = New System.Drawing.Point(278, 176)
        Me.TxtDC.Name = "TxtDC"
        Me.TxtDC.Size = New System.Drawing.Size(320, 20)
        Me.TxtDC.TabIndex = 71
        '
        'TxtStore
        '
        Me.TxtStore.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtStore.Location = New System.Drawing.Point(278, 246)
        Me.TxtStore.Name = "TxtStore"
        Me.TxtStore.Size = New System.Drawing.Size(320, 20)
        Me.TxtStore.TabIndex = 71
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtTotal.Location = New System.Drawing.Point(278, 281)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(65, 20)
        Me.TxtTotal.TabIndex = 71
        '
        'TxtDup
        '
        Me.TxtDup.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtDup.Location = New System.Drawing.Point(278, 317)
        Me.TxtDup.Name = "TxtDup"
        Me.TxtDup.Size = New System.Drawing.Size(65, 20)
        Me.TxtDup.TabIndex = 71
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(138, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Date in front of Letter"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(138, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "DC"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(138, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Store"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(138, 284)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Total App"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(138, 320)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Total Dup"
        '
        'CmdSearch
        '
        Me.CmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdSearch.Location = New System.Drawing.Point(278, 380)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdSearch.Size = New System.Drawing.Size(139, 24)
        Me.CmdSearch.TabIndex = 64
        Me.CmdSearch.Text = "Search"
        Me.CmdSearch.UseVisualStyleBackColor = False
        '
        'FrmChkDup
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(900, 506)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmbEnvelope)
        Me.Controls.Add(Me.TxtDup)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtStore)
        Me.Controls.Add(Me.TxtDC)
        Me.Controls.Add(Me.TxtDate)
        Me.Controls.Add(Me.Txtenvelope)
        Me.Controls.Add(Me.CmbMAilbag)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtMailbag)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbStartweek)
        Me.Controls.Add(Me.Txtstartweek)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.CmdGenreport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmdexit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmChkDup"
        Me.Text = "FrmDAily"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtstartweek As System.Windows.Forms.TextBox
    Public WithEvents CmdGenreport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmbStartweek As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMAilbag As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMailbag As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtenvelope As System.Windows.Forms.TextBox
    Friend WithEvents CmbEnvelope As System.Windows.Forms.ComboBox
    Friend WithEvents TxtDate As System.Windows.Forms.TextBox
    Friend WithEvents TxtDC As System.Windows.Forms.TextBox
    Friend WithEvents TxtStore As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtDup As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents CmdSearch As System.Windows.Forms.Button
End Class
