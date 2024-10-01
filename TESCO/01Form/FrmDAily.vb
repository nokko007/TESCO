Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class FrmDAily

    Private Sub FrmDAily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call setcombo()
    End Sub


    Private Sub setcombo()



        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer

        sql = " SELECT  ID ,  WeekNo ,  PickupDate FROM  TBL_WKCYCLE  WITH (NOLOCK) order by  WeekNo"



        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    CmbStartweek.Items.Add(Trim(rs1.Tables(0).Rows(x)("WeekNo").ToString) & "                   :" & Trim(rs1.Tables(0).Rows(x)("ID").ToString) & "|" & Trim(rs1.Tables(0).Rows(x)("PickupDate").ToString))
                    CmbEndweek.Items.Add(Trim(rs1.Tables(0).Rows(x)("WeekNo").ToString) & "                   :" & Trim(rs1.Tables(0).Rows(x)("ID").ToString) & "|" & Trim(rs1.Tables(0).Rows(x)("PickupDate").ToString))
                Next x
            End If
        End If



        Exit Sub

    End Sub

    Private Sub CmbStartweek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbStartweek.SelectedIndexChanged
        CmbStartweek.Tag = Trim(Mid(CmbStartweek.Text, InStr(CmbStartweek.Text, "                   :") + 21, InStr(CmbStartweek.Text, "                   :") - 1))
        Txtstartweek.Text = Trim(Mid(CmbStartweek.Text, InStr(CmbStartweek.Text, "|") + 1, 100))
        Debug.Print(CmbStartweek.Tag)
        Debug.Print(Txtstartweek.Text)
    End Sub

    Private Sub CmdGenreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdStep1.Click, Button1.Click
        Dim Ddate As String
        Dim ds1, ds2, ds3 As Data.DataSet
        Dim Dt As MySqlDataAdapter
        Dim sql As String
        Dim rptKEYIN As New RptDailyKeyin
        Dim rptQC As New RptDailyQC
        Dim bs As BindingSource
        Dim i As Integer
        Dim NewDataRow As DataRow

        'step1

        sql = "SELECT C.WEEKNO AS WEEK,CONVERT(VARCHAR(10),C.PICKUPDATE,20) AS PICKUPDATE," & _
" CONVERT(VARCHAR(10),A.QC_DATE,20) AS REPORTDT " & _
" INTO #TBL_DATE_UNION " & _
" FROM ((TBL_MEMBER_CLUBCARD A JOIN TBL_MAILBAG B ON((A.MAILBAG_ID = B.MAILBAG_ID))) " & _
" JOIN TBL_WKCYCLE C ON((B.WKCYCLE_ID = C.WEEKID))) " & _
" WHERE (A.QC_DATE IS NOT NULL)  and C.WEEKNO = " & CmbStartweek.Text & " " & _
" GROUP BY C.WEEKNO,CONVERT(VARCHAR(10),C.PICKUPDATE,20), " & _
" CONVERT(VARCHAR(10),A.QC_DATE,20)  "



        ds1 = New Data.DataSet
        'Dt = New MySqlDataAdapter
        bs = New BindingSource


        If cConnect.OpenSql(sql, ds1) = False Then
            MsgBox("Daily Header error step1", MsgBoxStyle.OkOnly)
            Exit Sub
        End If



        dg1.AutoGenerateColumns = True
        bs.DataSource = ds1.Tables(0)
        dg1.DataSource = bs
        dg1.Refresh()

        Debug.Print(dg1.Rows.Count)


        'step2
        sql = "SELECT A.WEEKNO AS WEEK,CONVERT(VARCHAR(10),A.PICKUPDATE,20) AS PICKUPDATE, " & _
        " CONVERT(VARCHAR(10),B.CREATEDDATE,20) AS REPORTDT  " & _
        " FROM (TBL_WKCYCLE A JOIN TBL_MAILBAG B ON((A.WEEKID = B.WKCYCLE_ID)))  " & _
        " WHERE (B.CREATEDDATE IS NOT NULL) and C.WEEKNO = " & CmbStartweek.Text & "   " & _
        " GROUP BY A.WEEKNO,CONVERT(VARCHAR(10),A.PICKUPDATE,20),CONVERT(VARCHAR(10),B.CREATEDDATE,20)   "
        ds2 = New Data.DataSet
        bs = New BindingSource



        If cConnect.OpenSql(sql, ds2) = False Then
            MsgBox("Daily Header error step2", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'Dt.Fill(ds)
        If ds2.Tables(0).Rows.Count <> 0 Then

            For i = 0 To ds2.Tables(0).Rows.Count - 1
                NewDataRow = ds1.Tables(0).NewRow()

                NewDataRow(0) = ds2.Tables(0).Rows(i)(0).ToString
                NewDataRow(1) = ds2.Tables(0).Rows(i)(1).ToString
                NewDataRow(2) = ds2.Tables(0).Rows(i)(2).ToString
                NewDataRow(3) = ds2.Tables(0).Rows(i)(3).ToString

                ds1.Tables(0).Rows.Add(NewDataRow)

            Next i
        End If


        dg1.AutoGenerateColumns = True
        bs.DataSource = ds1.Tables(0)
        dg1.DataSource = bs
        dg1.Refresh()

        Debug.Print(dg1.Rows.Count)


        'step3



        sql = " SELECT C.WEEKNO AS WEEK,CONVERT(VARCHAR(10),C.PICKUPDATE,20) AS PICKUPDATE, " & _
        " CONVERT(VARCHAR(10),A.COUNTING_DATE,20) AS REPORTDT  " & _
        " FROM ((TBL_MEMBER_CLUBCARD A JOIN TBL_MAILBAG B ON((A.MAILBAG_ID = B.MAILBAG_ID)))  " & _
        " JOIN TBL_WKCYCLE C ON((B.WKCYCLE_ID = C.WEEKID)))  " & _
        " WHERE (A.COUNTING_DATE IS NOT NULL) and C.WEEKNO = " & CmbStartweek.Text & "   " & _
        " GROUP BY C.WEEKNO,CONVERT(VARCHAR(10),C.PICKUPDATE,20),CONVERT(VARCHAR(10),A.COUNTING_DATE,20) "
        ds2 = New Data.DataSet
        bs = New BindingSource



        If cConnect.OpenSql(sql, ds3) = False Then
            MsgBox("Daily Header error step2", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'Dt.Fill(ds)
        If ds3.Tables(0).Rows.Count <> 0 Then

            For i = 0 To ds3.Tables(0).Rows.Count - 1
                NewDataRow = ds1.Tables(0).NewRow()

                NewDataRow(0) = ds3.Tables(0).Rows(i)(0).ToString
                NewDataRow(1) = ds3.Tables(0).Rows(i)(1).ToString
                NewDataRow(2) = ds3.Tables(0).Rows(i)(2).ToString
                NewDataRow(3) = ds3.Tables(0).Rows(i)(3).ToString

                ds1.Tables(0).Rows.Add(NewDataRow)

            Next i
        End If


        dg1.AutoGenerateColumns = True
        bs.DataSource = ds1.Tables(0)
        dg1.DataSource = bs
        dg1.Refresh()



        'step4



        sql = "  SELECT C.WEEKNO AS WEEKNO,CONVERT(VARCHAR(10),C.PICKUPDATE,20) AS PICKUPDATE, " & _
        " CONVERT(VARCHAR(10),A.KEYIN_DATE,20) AS REPORTDT  " & _
        " FROM ((TBL_MEMBER_CLUBCARD A JOIN TBL_MAILBAG B ON((A.MAILBAG_ID = B.MAILBAG_ID)))  " & _
        " JOIN TBL_WKCYCLE C ON((B.WKCYCLE_ID = C.WEEKID)))  " & _
        " WHERE (A.KEYIN_DATE IS NOT NULL) and C.WEEKNO = " & CmbStartweek.Text & "   " & _
        " GROUP BY C.WEEKNO,CONVERT(VARCHAR(10),C.PICKUPDATE,20),CONVERT(VARCHAR(10),A.KEYIN_DATE,20) "
        ds2 = New Data.DataSet
        bs = New BindingSource



        If cConnect.OpenSql(sql, ds3) = False Then
            MsgBox("Daily Header error step2", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'Dt.Fill(ds)
        If ds3.Tables(0).Rows.Count <> 0 Then

            For i = 0 To ds3.Tables(0).Rows.Count - 1
                NewDataRow = ds1.Tables(0).NewRow()

                NewDataRow(0) = ds3.Tables(0).Rows(i)(0).ToString
                NewDataRow(1) = ds3.Tables(0).Rows(i)(1).ToString
                NewDataRow(2) = ds3.Tables(0).Rows(i)(2).ToString
                NewDataRow(3) = ds3.Tables(0).Rows(i)(3).ToString

                ds1.Tables(0).Rows.Add(NewDataRow)

            Next i
        End If


        dg1.AutoGenerateColumns = True
        bs.DataSource = ds1.Tables(0)
        dg1.DataSource = bs
        dg1.Refresh()


        'step5



        sql = " SELECT C.WEEKNO AS WEEKNO,CONVERT(VARCHAR(10),C.PICKUPDATE,20) AS PICKUPDATE, " & _
         " CONVERT(VARCHAR(10),A.SUBMIT_DATE,20 )AS REPORTDT  " & _
         " FROM ((TBL_MEMBER_CLUBCARD A JOIN TBL_MAILBAG B ON((A.MAILBAG_ID = B.MAILBAG_ID)))  " & _
         " JOIN TBL_WKCYCLE C ON((B.WKCYCLE_ID = C.WEEKID)))  " & _
         " WHERE (A.SUBMIT_DATE IS NOT NULL) and C.WEEKNO = " & CmbStartweek.Text & "  " & _
         "  GROUP BY C.WEEKNO,CONVERT(VARCHAR(10),C.PICKUPDATE,20),CONVERT(VARCHAR(10),A.SUBMIT_DATE,20)"

        ds2 = New Data.DataSet
        bs = New BindingSource



        If cConnect.OpenSql(sql, ds3) = False Then
            MsgBox("Daily Header error step2", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'Dt.Fill(ds)
        If ds3.Tables(0).Rows.Count <> 0 Then

            For i = 0 To ds3.Tables(0).Rows.Count - 1
                NewDataRow = ds1.Tables(0).NewRow()

                NewDataRow(0) = ds3.Tables(0).Rows(i)(0).ToString
                NewDataRow(1) = ds3.Tables(0).Rows(i)(1).ToString
                NewDataRow(2) = ds3.Tables(0).Rows(i)(2).ToString
                NewDataRow(3) = ds3.Tables(0).Rows(i)(3).ToString

                ds1.Tables(0).Rows.Add(NewDataRow)

            Next i
        End If


        dg1.AutoGenerateColumns = True
        bs.DataSource = ds1.Tables(0)
        dg1.DataSource = bs
        dg1.Refresh()


        Debug.Print(dg1.Rows.Count)





    End Sub

    Private Sub Cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdexit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub

End Class