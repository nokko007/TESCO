<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChkDigit
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtClubcardID = New System.Windows.Forms.TextBox
        Me.CmdExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(97, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "check"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtClubcardID
        '
        Me.TxtClubcardID.Location = New System.Drawing.Point(23, 44)
        Me.TxtClubcardID.Name = "TxtClubcardID"
        Me.TxtClubcardID.Size = New System.Drawing.Size(246, 20)
        Me.TxtClubcardID.TabIndex = 1
        '
        'CmdExit
        '
        Me.CmdExit.Location = New System.Drawing.Point(95, 147)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(96, 27)
        Me.CmdExit.TabIndex = 2
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'FrmChkDigit
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.TxtClubcardID)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmChkDigit"
        Me.Text = "Chk digit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtClubcardID As System.Windows.Forms.TextBox
    Friend WithEvents CmdExit As System.Windows.Forms.Button
End Class
