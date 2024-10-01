Option Strict Off
Option Explicit On
Friend Class frmLogin
    Inherits System.Windows.Forms.Form


    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        End
    End Sub

    Private Sub CmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOK.Click
        'On Error GoTo error_Handler


        Dim i As Boolean
        Dim rs As Data.DataSet

        rs = New Data.DataSet


     


        If Trim(TxtLogin.Text) = "" Then
            MsgBox("ยังไม่ได้ใส่ชื่อ Login", MsgBoxStyle.OkOnly, "")
            Exit Sub
        End If

        If Trim(TxtPassword.Text) = "" Then
            MsgBox("ยังไม่ได้ใส่ Password", MsgBoxStyle.OkOnly, "")
            Exit Sub
        End If

        cOfficer.Login = Trim(TxtLogin.Text)
        cOfficer.PASSWORD = Trim(TxtPassword.Text)

        If cOfficer.SelectLogin = True Then

            'cOfficer.StartCalltime = GetDateTime()



            Me.Hide()
            FrmMain.Show()
            'Process.Start("explorer.exe", "\\192.168.0.2")
            'FrmMain.Focus()
        End If


resume_error:
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "_" & "cmdOk_Click", Err.Number, ErrorToString())
        GoTo resume_error
    End Sub

    Private Sub frmLogin_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo error_Handler
        Dim rs As data.dataset
        Dim i As Short

        cConnect = New clsConnectNet
        cConnectMY = New clsConnectMySQL

        cOfficer = New clsOfficer
        cXML = New ClsXML

        cGpg = New ClsGPG

        If cConnect.Connect(DNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If
       

        'gInbound = False

        lLogin = False

resume_error:
        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "Form_Load", Err.Number, ErrorToString())
        GoTo resume_error
    End Sub

    Private Sub frmLogin_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If lLogin = False Then End
    End Sub

    Private Sub txtLogin_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLogin.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then System.Windows.Forms.SendKeys.SendWait("{tab}")
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPASSWORD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPASSWORD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'On Error GoTo error_Handler

        If KeyAscii = 13 Then
            KeyAscii = 0
            Call cmdOk_Click(cmdOk, New System.EventArgs())
        End If

resume_err:
        GoTo EventExitSub

error_Handler:
        Call ShowError(Me.Name & "_" & "txtPASSWORD_KeyPress", Err.Number, ErrorToString())
        GoTo resume_err

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

   
End Class