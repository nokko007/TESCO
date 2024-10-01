Public Class FrmChkDup

    Private Sub FrmDAily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call setcombo()
    End Sub


    Private Sub setcombo()



        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer

        sql = " SELECT  ID ,  WeekNo ,  PickupDate FROM  TBL_WKCYCLE WITH (NOLOCK)  order by  WeekNo"


        CmbStartweek.Items.Clear()
        CmbStartweek.Items.Clear()
        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    CmbStartweek.Items.Add(Trim(rs1.Tables(0).Rows(x)("WeekNo").ToString) & "                               :" & Trim(rs1.Tables(0).Rows(x)("ID").ToString) & "|" & Trim(rs1.Tables(0).Rows(x)("PickupDate").ToString))
                Next x
            End If
        End If



        Exit Sub

    End Sub

    Private Sub CmbStartweek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbStartweek.SelectedIndexChanged
        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer


        'ID
        CmbStartweek.Tag = Trim(Mid(CmbStartweek.Text, InStr(CmbStartweek.Text, ":") + 1, InStr(CmbStartweek.Text, "|") - InStr(CmbStartweek.Text, ":") - 1))
        'Pickupdate
        Txtstartweek.Text = Trim(Mid(CmbStartweek.Text, InStr(CmbStartweek.Text, "|") + 1, 100))

        Debug.Print(CmbStartweek.Tag)
        Debug.Print(Txtstartweek.Text)




        sql = " SELECT  id , MailbagNumber, DCNAME FROM TBL_MAILBAG where  WKCYCLE_ID = '" & CmbStartweek.Tag & "' order by  MailbagNumber "


        CmbMAilbag.Items.Clear()

        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    CmbMAilbag.Items.Add(Trim(rs1.Tables(0).Rows(x)("MailbagNumber").ToString) & "                                                :" & Trim(rs1.Tables(0).Rows(x)("ID").ToString) & "|" & Trim(rs1.Tables(0).Rows(x)("DCNAME").ToString))
                Next x
            End If
        End If

        TxtDC.Text = Trim(Mid(CmbMAilbag.Text, InStr(CmbMAilbag.Text, "|") + 1, 100))

        Exit Sub





    End Sub

    Private Sub CmbEnvelope_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEnvelope.SelectedIndexChanged

        'envelope number
        CmbEnvelope.Tag = Trim(Mid(CmbEnvelope.Text, InStr(CmbEnvelope.Text, ":") + 1, InStr(CmbEnvelope.Text, "|") - InStr(CmbEnvelope.Text, ":") - 1))
        'storename
        Txtenvelope.Text = Trim(Mid(CmbEnvelope.Text, InStr(CmbEnvelope.Text, "|") + 1, 100))



        TxtDate.Text = CmbEnvelope.Tag
        TxtStore.Text = Txtenvelope.Text


    End Sub

    Private Sub CmbMAilbag_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMAilbag.SelectedIndexChanged
        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer


        'ID
        CmbMAilbag.Tag = Trim(Mid(CmbMAilbag.Text, 1, InStr(CmbMAilbag.Text, ":") - 1))
        'Pickupdate
        TxtMailbag.Text = Trim(Mid(CmbMAilbag.Text, InStr(CmbMAilbag.Text, "|") + 1, 100))







        Debug.Print(CmbMAilbag.Tag)
        Debug.Print(TxtMailbag.Text)

        sql = " SELECT EnvelopeNo,DateFrontLetter,storeName " & _
        "  FROM  TBL_MAILBAG " & _
        " INNER JOIN  TBL_STORE ON  TBL_MAILBAG.Store =  TBL_STORE.storeID  " & _
        " where  MailbagNumber = '" & CmbMAilbag.Tag & "' order by  EnvelopeNo "


        CmbEnvelope.Items.Clear()

        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    CmbEnvelope.Items.Add(Trim(rs1.Tables(0).Rows(x)("EnvelopeNo").ToString) & "                                      :" & Trim(rs1.Tables(0).Rows(x)("DateFrontLetter").ToString) & "|" & Trim(rs1.Tables(0).Rows(x)("storeName").ToString))
                Next x
            End If
        End If

        TxtDC.Text = Trim(Mid(CmbMAilbag.Text, InStr(CmbMAilbag.Text, "|") + 1, 100))

        Exit Sub



    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

    End Sub
End Class