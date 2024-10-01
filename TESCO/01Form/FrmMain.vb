Public Class FrmMain

    Private Sub CmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FrmGenSubmit.MdiParent = Me
        FrmGenSubmit.Parent = PnlDisplay
        FrmGenSubmit.Dock = DockStyle.Fill
        FrmGenSubmit.Show()

        'FrmGenSubmit.Show()
        ''FrmGenSubmit.MdiParent = Me
        'Me.Hide()
    End Sub

    Private Sub CmdXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FrmGenXML.MdiParent = Me
        FrmGenXML.Parent = PnlDisplay
        FrmGenXML.Dock = DockStyle.Fill
        FrmGenXML.Show()


        'FrmGenXML.Show()
        ''FrmGenXML.MdiParent = Me
        'Me.Hide()

    End Sub

    Private Sub CmdDailyReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FrmDAily.MdiParent = Me
        FrmDAily.Parent = PnlDisplay
        FrmDAily.Dock = DockStyle.Fill
        FrmDAily.Show()

    End Sub

    Private Sub CmdLOG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo error_Handler
        Dim i As Boolean

        If MsgBox("คุณต้องการออกจากระบบใช่หรือไม่", MsgBoxStyle.OkCancel, "ยืนยันการออกจากระบบ") = MsgBoxResult.Cancel Then
            'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
            'Cancel = -1
            'Call MenuEnable()
            Exit Sub
        End If
        'cOfficer.Logout()
        Me.Close()
        End

resume_error:
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "MDIForm_Unload", Err.Number, ErrorToString())
        GoTo resume_error
    End Sub

    Private Sub CmdChkDup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmChkDup.MdiParent = Me
        FrmChkDup.Parent = PnlDisplay
        FrmChkDup.Dock = DockStyle.Fill
        FrmChkDup.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MunExit.Click
        On Error GoTo error_Handler
        Dim i As Boolean

        If MsgBox("คุณต้องการออกจากระบบใช่หรือไม่", MsgBoxStyle.OkCancel, "ยืนยันการออกจากระบบ") = MsgBoxResult.Cancel Then
            'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
            'Cancel = -1
            'Call MenuEnable()
            Exit Sub
        End If
        'cOfficer.Logout()
        Me.Close()
        End

resume_error:
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "MDIForm_Unload", Err.Number, ErrorToString())
        GoTo resume_error
    End Sub

    Public Sub MnuDisable()
        MnuMember.Enabled = False
        MnuWeek.Enabled = False
        MnuCounting.Enabled = False
        MnuKeyin.Enabled = False
        MnuQC.Enabled = False
        MnuQuery.Enabled = False
        MnuCheckDup.Enabled = False
        MnuYesFile.Enabled = False
        MnuReport.Enabled = False

    End Sub


    Public Sub Mnuenable()
        Select Case cOfficer.AUTH
            Case 1
                MnuMember.Enabled = True
                MnuWeek.Enabled = True
                MnuCounting.Enabled = True
                MnuKeyin.Enabled = True
                MnuQC.Enabled = True
                MnuQuery.Enabled = True
                MnuCheckDup.Enabled = True
                MnuYesFile.Enabled = True
                MnuReport.Enabled = True
            Case 2
                MnuMember.Enabled = False
                MnuWeek.Enabled = True
                MnuCounting.Enabled = True
                MnuKeyin.Enabled = True
                MnuQC.Enabled = True
                MnuQuery.Enabled = True
                MnuCheckDup.Enabled = False
                MnuYesFile.Enabled = False
                MnuReport.Enabled = False
            Case 3
                MnuMember.Enabled = False
                MnuWeek.Enabled = False
                MnuCounting.Enabled = False
                MnuKeyin.Enabled = True
                MnuQC.Enabled = False
                MnuQuery.Enabled = False
                MnuCheckDup.Enabled = False
                MnuYesFile.Enabled = False
                MnuReport.Enabled = False
        End Select

    End Sub

    Private Sub UpdateToSubmitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToSubmitToolStripMenuItem.Click
        FrmGenSubmit.MdiParent = Me
        FrmGenSubmit.Parent = PnlDisplay
        FrmGenSubmit.Dock = DockStyle.Fill
        FrmGenSubmit.Show()
        MnuDisable()
    End Sub

    Private Sub XMLGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XMLGeneratorToolStripMenuItem.Click

        FrmGenXML.MdiParent = Me
        FrmGenXML.Parent = PnlDisplay
        FrmGenXML.Dock = DockStyle.Fill
        FrmGenXML.Show()
        MnuDisable()

    End Sub

    Private Sub DailyKeyinByKeyinStaffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyKeyinByKeyinStaffToolStripMenuItem.Click
        FrmDailyKeyin.MdiParent = Me
        FrmDailyKeyin.Parent = PnlDisplay
        FrmDailyKeyin.Dock = DockStyle.Fill
        FrmDailyKeyin.Show()
        MnuDisable()
    End Sub

    Private Sub DailyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyReportToolStripMenuItem.Click
        FrmDAily.MdiParent = Me
        FrmDAily.Parent = PnlDisplay
        FrmDAily.Dock = DockStyle.Fill
        FrmDAily.Show()
        MnuDisable()
    End Sub

    Private Sub ChkdigitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmChkDigit.MdiParent = Me
        FrmChkDigit.Parent = PnlDisplay
        FrmChkDigit.Dock = DockStyle.Fill
        FrmChkDigit.Show()
        MnuDisable()
    End Sub

    Private Sub IncompletedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FRmIncompleted.MdiParent = Me
        FRmIncompleted.Parent = PnlDisplay
        FRmIncompleted.Dock = DockStyle.Fill
        FRmIncompleted.Show()
        MnuDisable()
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Me.Text & " {DataBase : " & DataBaseName & "}" & "   Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision & " {Loginname : " & cOfficer.Login & "}"


        cWeek = New ClsWeek
        cStore = New ClsStore
        cMailbag = New ClsMailbag
        cClubcard = New ClsClubcard
        'cCustomRadiobutton = New CustomRadioButton
        Mnuenable()

    End Sub

    Private Sub WeekCycleSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeekCycleSetupToolStripMenuItem.Click
        FrmWeek.MdiParent = Me
        FrmWeek.Parent = PnlDisplay
        FrmWeek.Dock = DockStyle.Fill
        FrmWeek.Show()
        MnuDisable()
    End Sub

    Private Sub StoreSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreSetupToolStripMenuItem.Click
        FrmStore.MdiParent = Me
        FrmStore.Parent = PnlDisplay
        FrmStore.Dock = DockStyle.Fill
        FrmStore.Show()
        MnuDisable()
    End Sub

    Private Sub MailbagSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MailbagSetupToolStripMenuItem.Click
        FrmMailbag.MdiParent = Me
        FrmMailbag.Parent = PnlDisplay
        FrmMailbag.Dock = DockStyle.Fill
        FrmMailbag.Show()
        MnuDisable()
    End Sub



    Private Sub IncompletedToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncompletedToolStripMenuItem.Click
        FRmIncompleted.MdiParent = Me
        FRmIncompleted.Parent = PnlDisplay
        FRmIncompleted.Dock = DockStyle.Fill
        FRmIncompleted.Show()
        MnuDisable()
    End Sub

    Private Sub ApplicationCountinfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCounting.Click
        FrmCounting.MdiParent = Me
        FrmCounting.Parent = PnlDisplay
        FrmCounting.Dock = DockStyle.Fill
        FrmCounting.Show()
        MnuDisable()
    End Sub

    Private Sub ApplicationKeyinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuKeyin.Click
        gFormName = "KEYIN"
        FRmKeyin.MdiParent = Me
        FRmKeyin.Parent = PnlDisplay
        FRmKeyin.Dock = DockStyle.Fill
        FRmKeyin.Show()
        MnuDisable()
    End Sub

    Private Sub ChkdigitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkdigitToolStripMenuItem.Click
        FrmChkDigit.MdiParent = Me
        FrmChkDigit.Parent = PnlDisplay
        FrmChkDigit.Dock = DockStyle.Fill
        FrmChkDigit.Show()
        MnuDisable()
    End Sub

    Private Sub ApplicationQCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuQC.Click
        gFormName = "QC"
        FRmKeyin.MdiParent = Me
        FRmKeyin.Parent = PnlDisplay
        FRmKeyin.Dock = DockStyle.Fill
        FRmKeyin.Show()
        MnuDisable()
    End Sub

    Private Sub ApplicationQueryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuQuery.Click
        gFormName = "QUERY"
        FrmQuery.MdiParent = Me
        FrmQuery.Parent = PnlDisplay
        FrmQuery.Dock = DockStyle.Fill
        FrmQuery.Show()
        MnuDisable()
    End Sub

    Private Sub MnuMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMember.Click
        FrmOfficer.MdiParent = Me
        FrmOfficer.Parent = PnlDisplay
        FrmOfficer.Dock = DockStyle.Fill
        FrmOfficer.Show()
        MnuDisable()
    End Sub

    Private Sub ReGenerateXMLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReGenerateXMLToolStripMenuItem.Click
        FrmReGenXML.MdiParent = Me
        FrmReGenXML.Parent = PnlDisplay
        FrmReGenXML.Dock = DockStyle.Fill
        FrmReGenXML.Show()
        MnuDisable()
    End Sub

    Private Sub MoveImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveImageToolStripMenuItem.Click
        FrmMoveIMG.MdiParent = Me
        FrmMoveIMG.Parent = PnlDisplay
        FrmMoveIMG.Dock = DockStyle.Fill
        FrmMoveIMG.Show()
        MnuDisable()
    End Sub
End Class