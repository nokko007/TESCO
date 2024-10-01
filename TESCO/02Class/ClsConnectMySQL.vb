Imports System.Data
Imports MySql.Data.MySqlClient



Public Class clsConnectMySQL
    Private objConn As MySqlConnection


    Public Function Connect(ByVal pDSN As String) As Boolean
        'On Error GoTo error_Handler

        Connect = False


        objConn = New MySqlConnection(pDSN)

        objConn.Open()






        Connect = True

Exit_Function:
        Exit Function

error_Handler:
        'Call ShowLog
        GoTo Exit_Function

    End Function


    Public Function DisConnect() As Boolean
        'On Error GoTo error_Handler



        DisConnect = False

        If objConn.State = ConnectionState.Open Then
            objConn.Close()
        End If





        DisConnect = True

Exit_Function:
        Exit Function

error_Handler:
        'Call ShowLog
        GoTo Exit_Function

    End Function



    '    Public Function OpenSql(ByVal pSql As String, ByRef pRs As Data.DataSet) As Boolean
    '        'On Error GoTo error_Handler

    '        'Dim objCmd As MySqlCommand
    '        'Dim dtAdapter As MySqlDataAdapter

    '        'Dim rs As Data.DataSet

    '        'rs = New Data.DataSet

    '        'OpenSql = False
    '        'dtAdapter = New MySqlDataAdapter

    '        'objCmd = New MySqlCommand(pSql, objConn)

    '        ''dtReader = objCmd.ExecuteReader


    '        'dtAdapter.SelectCommand = objCmd
    '        'rs.Tables.Clear()
    '        'dtAdapter.Fill(rs, "TABLE1")

    '        'pRs = rs
    '        ''''''''''''''''














    '        Dim rs As Data.DataSet
    '        Dim da As MySqlDataAdapter

    '        pRs = Nothing
    '        OpenSql = False

    '        da = New MySqlDataAdapter
    '        rs = New Data.DataSet
    '        rs.Tables.Clear()
    '        da.SelectCommand = New MySqlCommand(pSql, objConn)
    '        da.Fill(rs, "TABLE1")

    '        If rs Is Nothing Then
    '            Exit Function
    '        End If

    '        pRs = rs


    '        OpenSql = True
    '        '''''


    '        'Public Function LoadGrid()
    '        '    '-- create a connection string
    '        '    Dim cConnString As String
    '        '    cConnString = "Server=HOTH;Database=junk;User" & _
    '        '    "ID=root;Password="
    '        '    '-- create a connection object and specify the conn string
    '        '    Dim oConn As New MySqlClient.MySqlConnection
    '        '    oConn.ConnectionString = cConnString
    '        '    oConn.Open()
    '        '    '-- create a command object
    '        '    Dim oCmd As New MySqlClient.MySqlCommand
    '        '    oCmd.CommandText = "select * from customers"
    '        '    oCmd.Connection = oConn
    '        '    '-- create a data adapter
    '        '    Dim oAdapt As New ByteFX.Data.MySqlClient.MySqlDataAdapter
    '        '    oAdapt.SelectCommand = oCmd
    '        '    '-- load the data into a dataset
    '        '    Dim ds As New DataSet
    '        '    oAdapt.Fill(ds, "customers")
    '        '    '-- show the results in a grid
    '        '    Me.DataGrid1.DataSource = ds.Tables("customers")
    '        '    oConn.Close()
    '        'End Function

    '        ''''''''''''''

    'Exit_Function:
    '        pRs = Nothing
    '        Exit Function

    'error_Handler:
    '        Call ShowLog(pSql)
    '        GoTo Exit_Function


    '    End Function


    Public Function OpenSql1(ByVal pSql As String, ByRef pRs As Data.DataSet) As Boolean
        'On Error GoTo error_Handler
        Dim objCmd As New MySqlCommand
        Dim dtAdapter As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim strSQL As String
        OpenSql1 = False

        strSQL = pSql


        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With

        dtAdapter.SelectCommand = objCmd

        dtAdapter.Fill(ds)
        'MsgBox(ds.Tables(0).Rows.Count)
        pRs = ds

        OpenSql1 = True

Exit_Function:
        'pRs = Nothing
        Exit Function

error_Handler:
        Call ShowLog(pSql)
        GoTo Exit_Function


    End Function
    Public Function SetReportDataAdapter(ByVal pSql As String, ByRef pRs As Data.DataSet, ByRef pDT As MySqlDataAdapter) As Boolean
        'On Error GoTo error_Handler
        Dim objCmd As New MySqlCommand
        'Dim dtAdapter As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim strSQL As String
        SetReportDataAdapter = False

        strSQL = pSql


        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With

        pDT.SelectCommand = objCmd

        pDT.Fill(ds)
        'MsgBox(ds.Tables(0).Rows.Count)
        pRs = ds

        SetReportDataAdapter = True

Exit_Function:
        'pRs = Nothing
        Exit Function

error_Handler:
        Call ShowLog(pSql)
        GoTo Exit_Function


    End Function
    Private Sub ShowLog(Optional ByRef pSql As String = "")


        'If Trim(pSql) <> "" Then MsgBox("Sql Error : " & pSql)

        ''Using connection As New Data.SqlClient.SqlConnection(DNS)
        'Using connection As New Data.SqlClient.SqlConnection(DNS)
        '    Dim command As New Data.SqlClient.SqlCommand(pSql, connection)

        '    Try
        '        command.Connection.Open()
        '        command.ExecuteNonQuery()

        '    Catch ex As Data.SqlClient.SqlException


        '        Dim i As Integer
        '        For i = 0 To ex.Errors.Count - 1
        '            MsgBox("Index #" & i.ToString() & ControlChars.NewLine _
        '                & "Message: " & ex.Errors(i).Message & ControlChars.NewLine _
        '                & "LineNumber: " & ex.Errors(i).LineNumber & ControlChars.NewLine _
        '                & "Source: " & ex.Errors(i).Source & ControlChars.NewLine _
        '                & "Procedure: " & ex.Errors(i).Procedure & ControlChars.NewLine)
        '        Next i

        '    End Try

        'End Using

    End Sub


    Public Function Execute(ByVal pSql As String) As Boolean
        'On Error GoTo error_Handler
        Dim objCmd As New MySqlCommand
        Dim dtAdapter As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim strSQL As String
        Execute = False

        strSQL = pSql


        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With

        objCmd.ExecuteNonQuery()

        'dtAdapter.Fill(ds)
        ''MsgBox(ds.Tables(0).Rows.Count)
        'pRs = ds

        Execute = True

Exit_Function:
        'pRs = Nothing
        Exit Function

error_Handler:
        Call ShowLog(pSql)
        GoTo Exit_Function


    End Function
End Class
