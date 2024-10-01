Option Strict Off
Option Explicit On
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class clsConnectNet

    Private cAdo As New Data.SqlClient.SqlConnection
    Private cDa As New Data.SqlClient.SqlDataAdapter


    Public Function Connect(ByVal pDSN As String) As Boolean
        'On Error GoTo error_Handler

        Dim strAccess As String

        Connect = False

        With cAdo
            If .State = 1 Then
                GoTo error_Handler
            End If
            .ConnectionString = pDSN
            .Open()

        End With

        Connect = True

Exit_Function:
        Exit Function

error_Handler:
        'Call ShowLog
        GoTo Exit_Function

    End Function

    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        cAdo = New Data.SqlClient.SqlConnection
        cDa = New Data.SqlClient.SqlDataAdapter
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    'Public Function Connection() As ADODB.Connection
    '        On Error GoTo error_Handler

    '        Connection = cAdo

    'Exit_Function:
    '        Exit Function

    'error_Handler:
    '        Call ShowLog()
    '        GoTo Exit_Function

    'End Function

    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()
        'UPGRADE_NOTE: Object cAdo may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        cAdo = Nothing
        'UPGRADE_NOTE: Object crs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        cDa = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    Private Sub ShowLog(Optional ByRef pSql As String = "")


        If Trim(pSql) <> "" Then MsgBox("Sql Error : " & pSql)

        'Using connection As New Data.SqlClient.SqlConnection(DNS)
        Using connection As New Data.SqlClient.SqlConnection(DNS)
            Dim command As New Data.SqlClient.SqlCommand(pSql, connection)

            Try
                command.Connection.Open()
                command.ExecuteNonQuery()

            Catch ex As Data.SqlClient.SqlException


                Dim i As Integer
                For i = 0 To ex.Errors.Count - 1
                    MsgBox("Index #" & i.ToString() & ControlChars.NewLine _
                        & "Message: " & ex.Errors(i).Message & ControlChars.NewLine _
                        & "LineNumber: " & ex.Errors(i).LineNumber & ControlChars.NewLine _
                        & "Source: " & ex.Errors(i).Source & ControlChars.NewLine _
                        & "Procedure: " & ex.Errors(i).Procedure & ControlChars.NewLine)
                Next i

            End Try

        End Using

    End Sub

    Public Sub Disconnect()
        On Error GoTo error_Handler

        cAdo.Close()

Exit_Function:

        Exit Sub

error_Handler:
        Call ShowLog()
        GoTo Exit_Function

    End Sub

    Public Function OpenSql(ByVal pSql As String, ByRef pRs As Data.DataSet) As Boolean
        On Error GoTo error_Handler
        Dim rs As Data.DataSet
        Dim da As Data.SqlClient.SqlDataAdapter

        pRs = Nothing
        OpenSql = False

        da = New Data.SqlClient.SqlDataAdapter
        rs = New Data.DataSet
        rs.Tables.Clear()
        da.SelectCommand = New SqlClient.SqlCommand(pSql, cAdo)
        da.Fill(rs, "TABLE1")

        If rs Is Nothing Then
            Exit Function
        End If

        pRs = rs
        OpenSql = True


Exit_Function:
        da = Nothing
        Exit Function

error_Handler:
        Call ShowLog(pSql)
        GoTo Exit_Function


    End Function

    Public Function Execute(ByVal pSql As String) As Boolean
        'On Error GoTo error_Handler

        Dim l As Boolean
        Dim rCmd As Data.SqlClient.SqlCommand
        Execute = False


        rCmd = New Data.SqlClient.SqlCommand
        rCmd.CommandText = pSql
        rCmd.Connection = cAdo
        If rCmd.ExecuteNonQuery() = 0 Then
            'rCmd.ExecuteNonQuery() Then
            Exit Function
        Else
            Execute = True
        End If





Exit_Function:
        Exit Function

error_Handler:
        Call ShowLog(pSql)
        GoTo Exit_Function
    End Function

    Public Sub BeginTrans()
        On Error GoTo error_Handler


        Dim transaction As Data.SqlClient.SqlTransaction
        transaction = cAdo.BeginTransaction

Exit_Sub:
        Exit Sub

error_Handler:
        Call ShowLog()
        GoTo Exit_Sub
    End Sub

    Public Sub Commit()
        On Error GoTo error_Handler

        Dim transaction As Data.SqlClient.SqlTransaction
        transaction.Commit()

Exit_Sub:
        Exit Sub

error_Handler:
        Call ShowLog()
        GoTo Exit_Sub
    End Sub

    Public Sub Rollback()
        On Error GoTo error_Handler




        Dim transaction As Data.SqlClient.SqlTransaction

        transaction.Rollback()
        'cAdo.RollbackTrans()


Exit_Sub:
        Exit Sub

error_Handler:
        Call ShowLog()
        GoTo Exit_Sub
    End Sub


End Class
