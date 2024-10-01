<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.PnlDisplay = New System.Windows.Forms.Panel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MnuMember = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuWeek = New System.Windows.Forms.ToolStripMenuItem
        Me.WeekCycleSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MailbagSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StoreSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuCounting = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuKeyin = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuQC = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuQuery = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuYesFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuCheckDup = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateToSubmitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.XMLGeneratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChkdigitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReport = New System.Windows.Forms.ToolStripMenuItem
        Me.DailyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DailyLogBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DailyKeyinByKeyinStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DailySubmitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IncompletedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MunExit = New System.Windows.Forms.ToolStripMenuItem
        Me.ReGenerateXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MoveImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlDisplay
        '
        Me.PnlDisplay.Location = New System.Drawing.Point(1, 25)
        Me.PnlDisplay.Name = "PnlDisplay"
        Me.PnlDisplay.Size = New System.Drawing.Size(1015, 706)
        Me.PnlDisplay.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMember, Me.MnuWeek, Me.MnuCounting, Me.MnuKeyin, Me.MnuQC, Me.MnuQuery, Me.MnuYesFile, Me.MnuReport, Me.IncompletedToolStripMenuItem, Me.MunExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1016, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuMember
        '
        Me.MnuMember.Name = "MnuMember"
        Me.MnuMember.Size = New System.Drawing.Size(100, 20)
        Me.MnuMember.Text = "Member Setup"
        '
        'MnuWeek
        '
        Me.MnuWeek.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WeekCycleSetupToolStripMenuItem, Me.MailbagSetupToolStripMenuItem, Me.StoreSetupToolStripMenuItem})
        Me.MnuWeek.Name = "MnuWeek"
        Me.MnuWeek.Size = New System.Drawing.Size(189, 20)
        Me.MnuWeek.Text = "Week && Mailbag && Store Setup"
        '
        'WeekCycleSetupToolStripMenuItem
        '
        Me.WeekCycleSetupToolStripMenuItem.Name = "WeekCycleSetupToolStripMenuItem"
        Me.WeekCycleSetupToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.WeekCycleSetupToolStripMenuItem.Text = "Week Cycle Setup"
        '
        'MailbagSetupToolStripMenuItem
        '
        Me.MailbagSetupToolStripMenuItem.Name = "MailbagSetupToolStripMenuItem"
        Me.MailbagSetupToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.MailbagSetupToolStripMenuItem.Text = "Mailbag setup"
        '
        'StoreSetupToolStripMenuItem
        '
        Me.StoreSetupToolStripMenuItem.Name = "StoreSetupToolStripMenuItem"
        Me.StoreSetupToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.StoreSetupToolStripMenuItem.Text = "Store Setup"
        '
        'MnuCounting
        '
        Me.MnuCounting.Name = "MnuCounting"
        Me.MnuCounting.Size = New System.Drawing.Size(131, 20)
        Me.MnuCounting.Text = "Application Counting"
        '
        'MnuKeyin
        '
        Me.MnuKeyin.Name = "MnuKeyin"
        Me.MnuKeyin.Size = New System.Drawing.Size(111, 20)
        Me.MnuKeyin.Text = "Application Keyin"
        '
        'MnuQC
        '
        Me.MnuQC.Name = "MnuQC"
        Me.MnuQC.Size = New System.Drawing.Size(98, 20)
        Me.MnuQC.Text = "Application QC"
        '
        'MnuQuery
        '
        Me.MnuQuery.Name = "MnuQuery"
        Me.MnuQuery.Size = New System.Drawing.Size(115, 20)
        Me.MnuQuery.Text = "Application Query"
        '
        'MnuYesFile
        '
        Me.MnuYesFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCheckDup, Me.UpdateToSubmitToolStripMenuItem, Me.XMLGeneratorToolStripMenuItem, Me.ChkdigitToolStripMenuItem, Me.ReGenerateXMLToolStripMenuItem, Me.MoveImageToolStripMenuItem})
        Me.MnuYesFile.Name = "MnuYesFile"
        Me.MnuYesFile.Size = New System.Drawing.Size(60, 20)
        Me.MnuYesFile.Text = "Yes File"
        '
        'MnuCheckDup
        '
        Me.MnuCheckDup.Name = "MnuCheckDup"
        Me.MnuCheckDup.Size = New System.Drawing.Size(194, 22)
        Me.MnuCheckDup.Text = "Check Duplicate"
        Me.MnuCheckDup.Visible = False
        '
        'UpdateToSubmitToolStripMenuItem
        '
        Me.UpdateToSubmitToolStripMenuItem.Name = "UpdateToSubmitToolStripMenuItem"
        Me.UpdateToSubmitToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.UpdateToSubmitToolStripMenuItem.Text = "01. Update to Submit"
        Me.UpdateToSubmitToolStripMenuItem.Visible = False
        '
        'XMLGeneratorToolStripMenuItem
        '
        Me.XMLGeneratorToolStripMenuItem.Name = "XMLGeneratorToolStripMenuItem"
        Me.XMLGeneratorToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.XMLGeneratorToolStripMenuItem.Text = "01. XML Generator"
        '
        'ChkdigitToolStripMenuItem
        '
        Me.ChkdigitToolStripMenuItem.Name = "ChkdigitToolStripMenuItem"
        Me.ChkdigitToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ChkdigitToolStripMenuItem.Text = "02. Chkdigit"
        '
        'MnuReport
        '
        Me.MnuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailyReportToolStripMenuItem, Me.DailyLogBookToolStripMenuItem, Me.DailyKeyinByKeyinStaffToolStripMenuItem, Me.DailySubmitToolStripMenuItem})
        Me.MnuReport.Name = "MnuReport"
        Me.MnuReport.Size = New System.Drawing.Size(56, 20)
        Me.MnuReport.Text = "Report"
        '
        'DailyReportToolStripMenuItem
        '
        Me.DailyReportToolStripMenuItem.Name = "DailyReportToolStripMenuItem"
        Me.DailyReportToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DailyReportToolStripMenuItem.Text = "01. Daily Report"
        '
        'DailyLogBookToolStripMenuItem
        '
        Me.DailyLogBookToolStripMenuItem.Name = "DailyLogBookToolStripMenuItem"
        Me.DailyLogBookToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DailyLogBookToolStripMenuItem.Text = "02. Daily Log Book"
        '
        'DailyKeyinByKeyinStaffToolStripMenuItem
        '
        Me.DailyKeyinByKeyinStaffToolStripMenuItem.Name = "DailyKeyinByKeyinStaffToolStripMenuItem"
        Me.DailyKeyinByKeyinStaffToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DailyKeyinByKeyinStaffToolStripMenuItem.Text = "03. Daily Keyin  && QC"
        '
        'DailySubmitToolStripMenuItem
        '
        Me.DailySubmitToolStripMenuItem.Name = "DailySubmitToolStripMenuItem"
        Me.DailySubmitToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DailySubmitToolStripMenuItem.Text = "04. Daily Submit "
        '
        'IncompletedToolStripMenuItem
        '
        Me.IncompletedToolStripMenuItem.Name = "IncompletedToolStripMenuItem"
        Me.IncompletedToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.IncompletedToolStripMenuItem.Text = "Incompleted"
        Me.IncompletedToolStripMenuItem.Visible = False
        '
        'MunExit
        '
        Me.MunExit.Name = "MunExit"
        Me.MunExit.Size = New System.Drawing.Size(39, 20)
        Me.MunExit.Text = "Exit"
        '
        'ReGenerateXMLToolStripMenuItem
        '
        Me.ReGenerateXMLToolStripMenuItem.Name = "ReGenerateXMLToolStripMenuItem"
        Me.ReGenerateXMLToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ReGenerateXMLToolStripMenuItem.Text = "03. Re-Generate XML"
        '
        'MoveImageToolStripMenuItem
        '
        Me.MoveImageToolStripMenuItem.Name = "MoveImageToolStripMenuItem"
        Me.MoveImageToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.MoveImageToolStripMenuItem.Text = "04. Move Image"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlDisplay)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.Text = "Tesco Clubcard"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuYesFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateToSubmitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XMLGeneratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyLogBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyKeyinByKeyinStaffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailySubmitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MunExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuKeyin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCounting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuWeek As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeekCycleSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MailbagSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCheckDup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkdigitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncompletedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StoreSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuQC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMember As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReGenerateXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
