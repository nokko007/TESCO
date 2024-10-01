

Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class FrmDailyKeyin
    Public ReportName As String
    'Public DataSource As DataTable

    Dim crDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Private strConn As String =  "Server=192.168.8.2 ;User Id=root; Password=ImitAdmin ; Database=TESCO_W1; port=3306; Allow Zero Datetime=True"
    Private ds As DataSet
    Private myDa As MySqlDataAdapter

    Private rpt1 As New RptDailyKeyin

    Dim rpt As ReportDocument
    Dim tblLogon As CrystalDecisions.CrystalReports.Engine.Table
    Dim rptLogon As CrystalDecisions.Shared.TableLogOnInfo
    Dim nZoom As Integer


    Private Sub FrmDAily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CalGetSystemDate()
    End Sub



    Private Sub cmdCarlendar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCarlendar1.Click
        On Error GoTo error_Handler
        Dim d As String

        d = CALDateGet("") ' d format dd/mm/yyyy+543

        If d <> "" Then
            txtDate.Text = d
        Else
            txtDate.Text = ""
        End If

resume_err:
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "_" & "cmdCarlendar_Click", Err.Number, ErrorToString())
        GoTo resume_err
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GenerateReport()
    End Sub

    Private Sub GenerateReport()

        rpt = New ReportDocument
        If OptKeyin.Checked = True Then
            rpt.Load(PATHREPORT & "KEYIN.rpt")
            nZoom = 100
            Display()
            CRViewer1.ShowRefreshButton = False
            Exit Sub
        ElseIf OptQC.Checked = True Then
            rpt.Load(PATHREPORT & "QC.rpt")
            nZoom = 100
            Display()
            CRViewer1.ShowRefreshButton = False
            Exit Sub
        End If


        

        
    End Sub

    Sub Display()
        For Each tblLogon In rpt.Database.Tables
            rptLogon = tblLogon.LogOnInfo
            With rptLogon.ConnectionInfo
                .ServerName = ServerName
                .UserID = UserIDName
                .Password = PasswordName
                .DatabaseName = DataBaseName
            End With
            tblLogon.ApplyLogOnInfo(rptLogon)
        Next tblLogon
        CRViewer1.ReportSource = rpt
        CRViewer1.Zoom(nZoom)




    End Sub



    Private Sub Cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdexit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub
End Class