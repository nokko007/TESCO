Imports system.io

Public Class FRmIncompleted
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    Private Sub ChkDigit()
        Dim Ddigit(18) As Integer
        Dim MultiplyST(18) As Integer
        Dim Result1(18) As Integer
        Dim Result2(18) As Integer
        Dim Result3(18) As Integer
        Dim TotalResult3 As Integer
        Dim ChkDigit As Integer
        Dim CHKPASS As Boolean
        Dim i, t As Integer
        Dim lp As Integer



        'For lp = 0 To ListXML.Items.Count - 1

        'check clubcard
        CHKPASS = False

        'Dim inp As String
        'inp = InputBox("cc no", "", "")
        'If inp = "" Then Exit Sub
        '''debug.Print("Input =" & inp)
        'Step1 - แยก Digit
        ''debug.Print("inp = " & ListXML.Items(lp).ToString)
        ''debug.Print("Split")
        For i = 1 To 18
            Ddigit(i) = Mid(TxtClubcardID.Text, i, 1)

            'debug.Print(i & "= " & Ddigit(i))
        Next i
        'Step 2 Multiply
        MultiplyST(1) = Ddigit(1) * 2
        MultiplyST(2) = Ddigit(2) * 1
        MultiplyST(3) = Ddigit(3) * 2
        MultiplyST(4) = Ddigit(4) * 1
        MultiplyST(5) = Ddigit(5) * 2
        MultiplyST(6) = Ddigit(6) * 1
        MultiplyST(7) = Ddigit(7) * 2
        MultiplyST(8) = Ddigit(8) * 1
        MultiplyST(9) = Ddigit(8) * 2
        MultiplyST(10) = Ddigit(10) * 1
        MultiplyST(11) = Ddigit(11) * 2
        MultiplyST(12) = Ddigit(12) * 1
        MultiplyST(13) = Ddigit(13) * 2
        MultiplyST(14) = Ddigit(14) * 1
        MultiplyST(15) = Ddigit(15) * 2
        MultiplyST(16) = Ddigit(16) * 1
        MultiplyST(17) = Ddigit(17) * 2

        'debug.Print("MULTI")
        For i = 1 To 18
            'debug.Print(MultiplyST(i))
        Next i



        'Step 3 Trunc หารปัดเศษทิ้งเสมอ
        'debug.Print("Result1")
        For t = 1 To 18
            Result1(t) = MultiplyST(t) \ 10
            'debug.Print(Result1(t))
        Next t



        'Step 4 
        'debug.Print("Result2")
        For t = 1 To 18
            Result2(t) = ((MultiplyST(t) / 10) - Result1(t)) * 10
            'debug.Print(Result2(t))
        Next t



        'Step 5 result 1 + result 2

        'debug.Print("Result3")
        For t = 1 To 18
            Result3(t) = Result1(t) + Result2(t)
            'debug.Print(Result3(t))
        Next t



        'Step 6 sum Result 3  
        'debug.Print("TotalResult3")
        TotalResult3 = 0
        For t = 1 To 18
            TotalResult3 = TotalResult3 + Result3(t)
        Next t
        'debug.Print(TotalResult3)

        ChkDigit = 10 - (((TotalResult3) / 10) - (TotalResult3 \ 10)) * 10

        If ChkDigit = 10 Then ChkDigit = 0
        'debug.Print(Ddigit(18))
        'debug.Print(ChkDigit)
        If Ddigit(18) = ChkDigit Then
            MsgBox("OK")
            CHKPASS = True
        Else
            MsgBox("INVALID")
            CHKPASS = False
            'LstChkDigitError.Items.Add(ListXML.Items(lp).ToString)
            'ListXML1.Items.Add(ListXML.Items(lp).ToString)
            'lp = lp + 1
            'debug.Print(ListXML.Items.Count - 1)
            'GoTo nextlp
        End If











        'nextlp:

        '        Next lp



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Incompleted()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub

    Private Sub Incompleted()
        Dim sql, SQLUP, sqlins As String
        Dim rs1 As Data.DataSet

        sql = "SELECT * FROM tlc_member_clubcard WHERE Clubcard_No = '" & Trim(TxtClubcardID.Text) & "' "
        rs1 = New Data.DataSet
        If cConnect.OpenSql(sql, rs1) = True Then
            If rs1.Tables(0).Rows.Count > 0 Then 'เจอใน DB
                SQLUP = "UPDATE tlc_member_clubcard  SET FLAG = 'INCOMPLETED' , form_type =" & Trim(TxtFormtype.Text) & "   WHERE Clubcard_No = '" & Trim(TxtClubcardID.Text) & "'"
                If cConnect.Execute(SQLUP) = True Then
                    MsgBox("COMPLETED")
                    TxtClubcardID.Text = ""
                End If
            Else 'ไม่เจอใน DB
                SQLUP = "INSERT INTO  tlc_member_clubcard (MAILBAG_ID,Clubcard_No,Flag,form_type) VALUES('" & Trim(CmbMAilbag.Tag) & "','" & Trim(TxtClubcardID.Text) & "',  'INCOMPLETED' ," & Trim(TxtFormtype.Text) & ")"
                If cConnect.Execute(SQLUP) = True Then
                    MsgBox("COMPLETED")
                    TxtClubcardID.Text = ""
                End If
            End If
        End If

    End Sub


    Private Sub setcombo()



        Dim i As Boolean

        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim rs1 As Data.DataSet
        Dim x As Integer

        sql = " SELECT  ID ,  WeekNo ,  PickupDate FROM  TBL_WKCYCLE  WITH (NOLOCK)  order by  WeekNo"


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

    Private Sub FRmIncompleted_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setcombo()
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




        sql = " SELECT  id , MailbagNumber, DCNAME FROM TBL_MAILBAG  WITH (NOLOCK) where  WKCYCLE_ID = '" & CmbStartweek.Tag & "' order by  MailbagNumber "


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

        'TxtDC.Text = Trim(Mid(CmbMAilbag.Text, InStr(CmbMAilbag.Text, "|") + 1, 100))

        Exit Sub





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
        "  FROM  TBL_MAILBAG  WITH (NOLOCK) " & _
        " INNER JOIN  TBL_STORE  WITH (NOLOCK) ON  TBL_MAILBAG.Store =  TBL_STORE.storeID  " & _
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

        'TxtDC.Text = Trim(Mid(CmbMAilbag.Text, InStr(CmbMAilbag.Text, "|") + 1, 100))

        Exit Sub



    End Sub

    Private Sub CmbEnvelope_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEnvelope.SelectedIndexChanged

        'envelope number
        CmbEnvelope.Tag = Trim(Mid(CmbEnvelope.Text, InStr(CmbEnvelope.Text, ":") + 1, InStr(CmbEnvelope.Text, "|") - InStr(CmbEnvelope.Text, ":") - 1))
        'storename
        Txtenvelope.Text = Trim(Mid(CmbEnvelope.Text, InStr(CmbEnvelope.Text, "|") + 1, 100))



        'TxtDate.Text = CmbEnvelope.Tag
        'TxtStore.Text = Txtenvelope.Text


    End Sub

    Private Sub TxtClubcardID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClubcardID.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 13
                Incompleted()
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub TxtClubcardID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClubcardID.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        Dim SQLMY As String
        Dim SQL As String
        Dim rsmy As New Data.DataSet
        Dim imy As Long


        SQLMY = "SELECT * FROM  `TBL_AMPER` ORDER BY id"
        cConnectMY.OpenSql1(SQLMY, rsmy)
        If rsmy.Tables(0).Rows.Count > 0 Then

            For imy = 0 To (rsmy.Tables(0).Rows.Count - 1)
                SQL = "INSERT INTO TBL_AMPER (URN, AMPER_CODE, AMPER_TEXT, " & _
                " PROVINCE_CODE, PROVINCE_TEXT, POSTCODE) VALUES " & _
                " ( '" & rsmy.Tables(0).Rows(imy)(0).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(1).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(2).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(3).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(4).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(5).ToString & "' )  "
                cConnect.Execute(SQL)
            Next imy
            MsgBox("cOMPLETED")
        Else
            MsgBox("NORECORD")

        End If


        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click



        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        Dim SQLMY As String
        Dim SQL As String
        Dim rsmy As New Data.DataSet
        Dim imy As Long


        SQLMY = "SELECT   `ID`, `WeekNo`, DATE_FORMAT( `PickupDate` ,  '%Y-%m-%d' ), DATE_FORMAT( `CreatedDate` ,  '%Y-%m-%d' ), `CreatedBy`, DATE_FORMAT( `UpdatedDate` ,  '%Y-%m-%d' ), `UpdatedBy` FROM  TBL_WKCYCLE ORDER BY id"
        cConnectMY.OpenSql1(SQLMY, rsmy)
        If rsmy.Tables(0).Rows.Count > 0 Then

            For imy = 0 To (rsmy.Tables(0).Rows.Count - 1)
                SQL = " INSERT INTO TBL_WKCYCLE " & _
                      " (WEEKID, WEEKNO, PICKUPDATE, CREATEDDATE, CREATEDBY, " & _
                      "  UPDATEDATE, UPDATEBY )  VALUES  " & _
                " ( '" & rsmy.Tables(0).Rows(imy)(0).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(1).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(2).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(3).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(4).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(5).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(6).ToString & "'   " & _
                "  )  "
                cConnect.Execute(SQL)
            Next imy
            MsgBox("COMPLETED")
        Else
            MsgBox("NORECORD")

        End If


        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If





    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        Dim SQLMY As String
        Dim SQL As String
        Dim rsmy As New Data.DataSet
        Dim imy As Long


        SQLMY = "SELECT `id`, " & _
 " `WKCYCLE_ID`, " & _
 " `DCNAME`,  " & _
 " `Store`, " & _
 "  `MailbagNumber`,  " & _
 " `SealNo`,  " & _
 " `EnvelopeNo`, " & _
 "  `AppInform`,  " & _
 " `UnsignApp`, " & _
 "  `NoBarcodeApp`,  " & _
 "  DATE_FORMAT( `DateFrontLetter` ,  '%Y-%m-%d' ), " & _
 "  DATE_FORMAT(  `CreatedDate` ,  '%Y-%m-%d' ), " & _
 "  `CreatedBy`, " & _
 "  DATE_FORMAT(`UpdatedDate` ,  '%Y-%m-%d' ), " & _
  " `UpdatedBy` " & _
  "  FROM `TBL_MAILBAG`"
        cConnectMY.OpenSql1(SQLMY, rsmy)
        If rsmy.Tables(0).Rows.Count > 0 Then

            For imy = 0 To (rsmy.Tables(0).Rows.Count - 1)
                SQL = " INSERT INTO TBL_MAILBAG  " & _
                      " (MAILBAG_ID, WKCYCLE_ID, DCNAME, STOREID, MAILBAGNUMBER, " & _
                    " SEALNO, ENVELOPENO, APPINFORM, UNSIGNAPP, NOBARCODEAPP, " & _
                    " DATEFRONTLETTER, CREATEDDATE, CREATEDBY, UPDATEDDATE, UPDATEBY) " & _
                    " VALUES      " & _
                " ( '" & rsmy.Tables(0).Rows(imy)(0).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(1).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(2).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(3).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(4).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(5).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(6).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(7).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(8).ToString & "'  , " & _
                "  '" & rsmy.Tables(0).Rows(imy)(9).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(10).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(11).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(12).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(13).ToString & "',   " & _
                "  '" & rsmy.Tables(0).Rows(imy)(14).ToString & "'   " & _
                "  )  "
                cConnect.Execute(SQL)
            Next imy
            MsgBox("COMPLETED")
        Else
            MsgBox("NORECORD")

        End If


        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If



    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        Dim SQLMY As String
        Dim SQL As String
        Dim rsmy As New Data.DataSet
        Dim imy As Long


        SQLMY = " SELECT `storeID`, `storeName` FROM `TBL_STORE` "
        cConnectMY.OpenSql1(SQLMY, rsmy)
        If rsmy.Tables(0).Rows.Count > 0 Then

            For imy = 0 To (rsmy.Tables(0).Rows.Count - 1)



                SQL = " INSERT INTO TBL_STORE (STOREID, STORENAME) " & _
                    " VALUES      " & _
                " ( " & rsmy.Tables(0).Rows(imy)(0).ToString & " ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(1).ToString & "')  "



                cConnect.Execute(SQL)
            Next imy
            MsgBox("COMPLETED")
        Else
            MsgBox("NORECORD")

        End If


        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        Dim SQLMY As String
        Dim SQL As String
        Dim rsmy As New Data.DataSet
        Dim imy As Long


        SQLMY = " SELECT A.ID, " & _
        " A.MAILBAG_ID, " & _
        " CLUBCARD_NO, " & _
        " NAME_1, " & _
        " NAME_2, " & _
        " OFFICIAL_ID,  " & _
        " PRIMARY_CARD_ACCOUNT_NUMBER, " & _
        " CARD_ACCOUNT_NUMBER,  " & _
        " cast(customer_use_status as char(1)) as customer_use_status1,  " & _
        "  cast(customer_mail_status as char(1)) as customer_mail_status1," & _
        " cast(family_member_1_gender_code as char(1)) as family_member_1_gender_code1, " & _
        " FAMILY_MEMBER_1_DOB,  " & _
        " '', " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " '', " & _
        " FAMILY_MEMBER_2_DOB,  " & _
        " FAMILY_MEMBER_3_DOB,  " & _
        " FAMILY_MEMBER_4_DOB, " & _
        " FAMILY_MEMBER_5_DOB,  " & _
        " '', " & _
        " ADDRESS_LINE_1, " & _
        " ADDRESS_LINE_2,  " & _
        " ADDRESS_LINE_3, " & _
        " CITY,  " & _
        " PROVINCE_CODE,  " & _
        " COUNTRY, " & _
        " POSTAL_CODE, " & _
        " DAYTIME_PHONE_NUMBER,  " & _
        " EVENING_PHONE_NUMBER, " & _
        " MOBILE_PHONE_NUMBER, " & _
        " '',  " & _
        " EMAIL_ADDRESS, " & _
        " '', " & _
        " '',  " & _
        " cast(business_type_code as char(1)) as business_type_code1, " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " '', " & _
        " PREFERRED_STORE_CODE,  " & _
        " JOINED_STORE_CODE,  " & _
        " PREFERRED_CONTACT_TYPE_CODE, " & _
        " TITLE_CODE, " & _
        " '1', " & _
        " '1', " & _
        " '1',   " & _
        " '1', " & _
        " '1', " & _
        " '1',  " & _
        " '1', " & _
        " '1', " & _
        " '1', " & _
        " '1', " & _
        " '1', " & _
        " '1',  " & _
        " '', " & _
        " '', " & _
        " '',  " & _
        " '',  " & _
        " '', " & _
        " '',  " & _
        " DATE_FORMAT( TBL_MAILBAG.DateFrontLetter ,  '%Y-%m-%d' ) as DateFrontLetter1, " & _
        " '', " & _
        " cast(race_code as char(1)) as race_code1,  " & _
        "  NUMBER_OF_HOUSEHOLD_MEMBERS, " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " CAST(expat AS char(1))  as expat1, " & _
        " CAST(form_type AS char(1))  as form_type1,  " & _
        " FLAG, COUNTING_EMPLOYEEID,  " & _
        "  DATE_FORMAT( `COUNTING_DATE` ,  '%Y-%m-%d' ),  " & _
        "  `KEYIN_EMPLOYEEID`  ,  " & _
        "  DATE_FORMAT(KEYIN_DATE,  '%Y-%m-%d') , " & _
        "  DATE_FORMAT( `SUBMIT_DATE` ,  '%Y-%m-%d' ) " & _
        " FROM `tlc_member_clubcard` A inner join TBL_MAILBAG on A.`MAILBAG_ID`  =TBL_MAILBAG.id  "
        cConnectMY.OpenSql1(SQLMY, rsmy)
        If rsmy.Tables(0).Rows.Count > 0 Then

            For imy = 0 To (rsmy.Tables(0).Rows.Count - 1)


                Dim SHOME_ID As String
                Dim SBUILDING_TYPE As String
                Dim SBUILDING As String
                Dim SROOM_NO As String
                Dim SFLOOR As String
                Dim SMOU As String
                Dim SSOI As String
                Dim SSTREET As String
                Dim STUMBOL As String

                Dim SCITY As String
                Dim SPROVINCE_CODE As String
                Dim SPROVINCE As String

                Dim SIDTYPE As String
                Dim SID As String


                '''''''''''



                SHOME_ID = ""
                SBUILDING_TYPE = ""
                SBUILDING = ""
                SROOM_NO = ""
                SFLOOR = ""
                SMOU = ""
                SSOI = ""
                SSTREET = ""
                STUMBOL = ""
                SCITY = ""
                SPROVINCE_CODE = ""
                SPROVINCE = ""
                SIDTYPE = ""
                SID = ""


                Dim tmpaddr1() As String
                'Dim resultaddr1 As String
                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("address_line_1").ToString) And rsmy.Tables(0).Rows(imy)("address_line_1").ToString <> "" Then

                    tmpaddr1 = Split((rsmy.Tables(0).Rows(imy)("address_line_1").ToString), "##")

                    If Trim(tmpaddr1(0)) <> "" Then
                        SHOME_ID = Trim(tmpaddr1(0))
                    Else
                        SHOME_ID = ""
                    End If

                    SBUILDING_TYPE = ""
                    SBUILDING = ""

                    If Trim(tmpaddr1(1)) = "0" Then
                        SBUILDING_TYPE = "อาคาร"
                        SBUILDING = Trim(tmpaddr1(2))
                        'resultaddr1 = resultaddr1 & " " & "อาคาร " & Trim(tmpaddr1(2))
                    ElseIf Trim(tmpaddr1(1)) = "1" Then
                        SBUILDING_TYPE = "หมู่บ้าน"
                        SBUILDING = Trim(tmpaddr1(2))
                    Else
                        SBUILDING_TYPE = ""
                        SBUILDING = Trim(tmpaddr1(2))
                    End If






                    If Trim(tmpaddr1(3)) <> "" Then
                        SROOM_NO = Trim(tmpaddr1(3))
                    Else
                        SROOM_NO = ""
                    End If

                    If Trim(tmpaddr1(4)) <> "" Then
                        SFLOOR = Trim(tmpaddr1(4))
                    Else
                        SFLOOR = ""
                    End If
                Else
                    SHOME_ID = ""
                    SBUILDING_TYPE = ""
                    SBUILDING = ""
                    SROOM_NO = ""
                    SFLOOR = ""

                End If





                Dim tmpaddr2() As String
                'Dim resultaddr2 As String
                'tmpaddr1 = ""
                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("address_line_2").ToString) And rsmy.Tables(0).Rows(imy)("address_line_2").ToString <> "" Then


                    tmpaddr2 = Split((rsmy.Tables(0).Rows(imy)("address_line_2").ToString), "##")
                    ' out debug.print(tmpaddr2(0))
                    ' out debug.print(tmpaddr2(1))
                    ' out debug.print(tmpaddr2(2))

                    If Trim(tmpaddr2(0)) <> "" Then
                        SMOU = Trim(tmpaddr2(0))
                    Else
                        SMOU = ""
                    End If


                    If Trim(tmpaddr2(1)) <> "" Then
                        SSOI = Trim(tmpaddr2(1))
                    Else
                        SSOI = ""
                    End If

                    If Trim(tmpaddr2(2)) <> "" Then
                        SSTREET = Trim(tmpaddr2(2))
                    Else
                        SSTREET = ""
                    End If

                Else

                    SMOU = ""
                    SSOI = ""
                    SSTREET = ""
                End If


                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("address_line_3").ToString) And rsmy.Tables(0).Rows(imy)("address_line_3").ToString <> "" Then

                    STUMBOL = rsmy.Tables(0).Rows(imy)("address_line_3").ToString
                Else
                    STUMBOL = ""
                End If



                Dim tmpCity() As String

                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("CITY").ToString) And rsmy.Tables(0).Rows(imy)("CITY").ToString <> "" Then


                    tmpCity = Split((rsmy.Tables(0).Rows(imy)("CITY").ToString), "##")

                    If Trim(tmpCity(1)) <> "" Then
                        SCITY = Trim(tmpCity(1))
                    Else
                        SCITY = ""
                    End If
                Else
                    SCITY = ""
                End If

                Dim tmpProvince() As String



                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("PROVINCE_CODE").ToString) And rsmy.Tables(0).Rows(imy)("PROVINCE_CODE").ToString <> "" Then
                    tmpProvince = Split((rsmy.Tables(0).Rows(imy)("PROVINCE_CODE").ToString), "##")

                    If Trim(tmpProvince(0)) <> "" Then
                        SPROVINCE_CODE = Trim(tmpProvince(0))
                        SPROVINCE = Trim(tmpProvince(1))
                    Else

                        SPROVINCE_CODE = -1
                        SPROVINCE = Trim(tmpProvince(1))
                    End If
                Else
                    SPROVINCE_CODE = -1
                    SPROVINCE = ""
                End If

                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("OFFICIAL_ID").ToString) Then
                    If Mid(rsmy.Tables(0).Rows(0)("OFFICIAL_ID").ToString, 1, 1) = "1" Then
                        SIDTYPE = "หมายเลขบัตรประชาชน"
                        SID = Mid(rsmy.Tables(0).Rows(imy)("OFFICIAL_ID").ToString, 4, 13)
                    Else
                        SIDTYPE = "Passport"
                        SID = Mid(rsmy.Tables(0).Rows(imy)("OFFICIAL_ID").ToString, 4, 20)
                    End If
                Else
                    SIDTYPE = ""
                    SID = ""
                End If

                SQL = " INSERT INTO TBL_MEMBER_CLUBCARD  " & _
                      " (CUSTID, MAILBAG_ID, CLUBCARD_NO, " & _
        " NAME_1, NAME_2, OFFICIAL_ID,  " & _
        " PRIMARY_CARD_ACCOUNT_NUMBER, CARD_ACCOUNT_NUMBER,  CUSTOMER_USE_STATUS,  " & _
        " CUSTOMER_MAIL_STATUS, FAMILY_MEMBER_1_GENDER_CODE, FAMILY_MEMBER_1_DOB,  " & _
        " FAMILY_MEMBER_2_GENDER_CODE, FAMILY_MEMBER_3_GENDER_CODE, FAMILY_MEMBER_4_GENDER_CODE,  " & _
        " FAMILY_MEMBER_5_GENDER_CODE, FAMILY_MEMBER_6_GENDER_CODE, FAMILY_MEMBER_2_DOB,  " & _
        " FAMILY_MEMBER_3_DOB,  FAMILY_MEMBER_4_DOB, FAMILY_MEMBER_5_DOB,  " & _
        " FAMILY_MEMBER_6_DOB, ADDRESS_LINE_1, ADDRESS_LINE_2,  " & _
        " ADDRESS_LINE_3, CITY,  PROVINCE_CODE,  " & _
        " COUNTRY, POSTAL_CODE, DAYTIME_PHONE_NUMBER,  " & _
        " EVENING_PHONE_NUMBER, MOBILE_PHONE_NUMBER, FAX_NUMBER,  " & _
        " EMAIL_ADDRESS, BUSINESS_NAME, BUSINESS_REGISTRATION_NUMBER,  " & _
        " BUSINESS_TYPE_CODE, BUSINESS_ADDRESS_LINE_1, BUSINESS_ADDRESS_LINE_2,  " & _
        " BUSINESS_ADDRESS_LINE_3, BUSINESS_ADDRESS_LINE_4, BUSINESS_ADDRESS_LINE_5,  " & _
        " BUSINESS_ADDRESS_LINE_6, BUSINESS_POSTAL_CODE, PREFERRED_STORE_CODE,  " & _
        " JOINED_STORE_CODE,  PREFERRED_CONTACT_TYPE_CODE, TITLE_CODE, " & _
        "  TESCOGROUP_MAIL_FLAG, TESCOGROUP_EMAIL_FLAG, TESCOGROUP_PHONE_FLAG,   " & _
        " TESCOGROUP_SMS_FLAG, PARTNER_MAIL_FLAG, PARTNER_EMAIL_FLAG,  " & _
        " PARTNER_PHONE_FLAG, PARTNER_SMS_FLAG, RESEARCH_MAIL_FLAG, " & _
        " RESEARCH_EMAIL_FLAG, RESEARCH_PHONE_FLAG, RESEARCH_SMS_FLAG,  " & _
        " DIABETIC_FLAG, VEGETERIAN_FLAG, TEETOTAL_FLAG,  " & _
        " HALAL_FLAG,  LACTOSE_FLAG, CELIAC_FLAG,  " & _
        " CUSTOMER_CREATED_DATE, PREFERRED_MAILING_ADDRESS_FLAG, RACE_CODE,  " & _
        "  NUMBER_OF_HOUSEHOLD_MEMBERS, CARD_MEMBER_NAME_NRIC, CARD_MEMBER_DOB,  " & _
        " CARD_MEMBER_GENDER_CODE, EXPAT, FORM_TYPE,  " & _
        " FLAG, COUNTING_EMPLOYEEID,  " & _
        " COUNTING_DATE,  " & _
        " KEYIN_EMPLOYEEID,  " & _
        " KEYIN_DATE,  " & _
        " SUBMIT_DATE, " & _
        " HOME_ID, BUILDING_TYPE, BUILDING, ROOM_NO, FLOOR, MOU, SOI, STREET, TUMBOL,PROVINCE,IDTYPE ) " & _
                    " VALUES      " & _
                " ( '" & rsmy.Tables(0).Rows(imy)(0).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(1).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(2).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(3).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(4).ToString & "' ,  " & _
                "  '" & SID & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(6).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(7).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(8).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(9).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(10).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(11).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(12).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(13).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(14).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(15).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(16).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(17).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(18).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(19).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(20).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(21).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(22).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(23).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(24).ToString & "' ,  " & _
                "  '" & SCITY & "' ,  " & _
                "  '" & SPROVINCE_CODE & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(27).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(28).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(29).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(30).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(31).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(32).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(33).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(34).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(35).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(36).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(37).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(38).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(39).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(40).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(41).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(42).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(43).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(44).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(45).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(46).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(47).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(48).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(49).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(50).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(51).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(52).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(53).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(54).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(55).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(56).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(57).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(58).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(59).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(60).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(61).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(62).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(63).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(64).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(65).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(66).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(67).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(68).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(69).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(70).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(71).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(72).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(73).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(74).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(75).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(76).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(77).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(78).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(79).ToString & "' ,  " & _
                "  '" & rsmy.Tables(0).Rows(imy)(80).ToString & "' ,  " & _
                " '" & SHOME_ID & "' ,  " & _
                "  '" & SBUILDING_TYPE & "' ,  " & _
                "  '" & SBUILDING & "' ,  " & _
                "  '" & SROOM_NO & "' ,  " & _
                "  '" & SFLOOR & "' ,  " & _
                "  '" & SMOU & "' ,  " & _
                "  '" & SSOI & "' ,  " & _
                "  '" & SSTREET & "' ,  " & _
                "  '" & STUMBOL & "',  " & _
                "  '" & SPROVINCE & "',  " & _
                "  '" & SIDTYPE & "')  "



                cConnect.Execute(SQL)
            Next imy
            MsgBox("COMPLETED")
        Else
            MsgBox("NORECORD")

        End If


        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        Dim SQLMY As String
        Dim SQL As String
        Dim rsmy As New Data.DataSet
        Dim imy As Long


        SQLMY = "SELECT `id`, `member_name`, `member_surname`, `member_employeeid`, `username`, `password`, `auth`, `isActivate`,DATE_FORMAT( `created_date` ,  '%Y-%m-%d' )  FROM `TBL_MEMBER`  ORDER BY id"
        cConnectMY.OpenSql1(SQLMY, rsmy)
        If rsmy.Tables(0).Rows.Count > 0 Then

            For imy = 0 To (rsmy.Tables(0).Rows.Count - 1)
                SQL = "INSERT INTO TBL_MEMBER " & _
                      " (id, member_name, member_surname, " & _
                      " member_employeeid, username, password, " & _
                      " auth, isActivate, created_date)" & _
                      " VALUES     " & _
                      " ( '" & rsmy.Tables(0).Rows(imy)(0).ToString & "'," & _
                      "  '" & rsmy.Tables(0).Rows(imy)(1).ToString & "'," & _
                      "  '" & rsmy.Tables(0).Rows(imy)(2).ToString & "'," & _
                      "  '0', " & _
                      "  '" & rsmy.Tables(0).Rows(imy)(4).ToString & "'," & _
                      "  '" & rsmy.Tables(0).Rows(imy)(5).ToString & "'," & _
                      "  '" & rsmy.Tables(0).Rows(imy)(6).ToString & "', " & _
                      "  '1'," & _
                      "  '" & rsmy.Tables(0).Rows(imy)(8).ToString & "') "
                cConnect.Execute(SQL)
            Next imy
            MsgBox("cOMPLETED")
        Else
            MsgBox("NORECORD")

        End If


        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If
    End Sub




    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        Dim SQLMY As String
        Dim SQL As String
        Dim rsmy As New Data.DataSet
        Dim imy As Long


        SQLMY = " SELECT ID, " & _
        " A.MAILBAG_ID, " & _
        " CLUBCARD_NO, " & _
        " NAME_1, " & _
        " NAME_2, " & _
        " OFFICIAL_ID,  " & _
        " PRIMARY_CARD_ACCOUNT_NUMBER, " & _
        " CARD_ACCOUNT_NUMBER,  " & _
        " cast(customer_use_status as char(1)) as customer_use_status1,  " & _
        "  cast(customer_mail_status as char(1)) as customer_mail_status1," & _
        " cast(family_member_1_gender_code as char(1)) as family_member_1_gender_code1, " & _
        " FAMILY_MEMBER_1_DOB,  " & _
        " '', " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " '', " & _
        " FAMILY_MEMBER_2_DOB,  " & _
        " FAMILY_MEMBER_3_DOB,  " & _
        " FAMILY_MEMBER_4_DOB, " & _
        " FAMILY_MEMBER_5_DOB,  " & _
        " '', " & _
        " ADDRESS_LINE_1, " & _
        " ADDRESS_LINE_2,  " & _
        " ADDRESS_LINE_3, " & _
        " CITY,  " & _
        " PROVINCE_CODE,  " & _
        " COUNTRY, " & _
        " POSTAL_CODE, " & _
        " DAYTIME_PHONE_NUMBER,  " & _
        " EVENING_PHONE_NUMBER, " & _
        " MOBILE_PHONE_NUMBER, " & _
        " '',  " & _
        " EMAIL_ADDRESS, " & _
        " '', " & _
        " '',  " & _
        " cast(business_type_code as char(1)) as business_type_code1, " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " '', " & _
        " PREFERRED_STORE_CODE,  " & _
        " JOINED_STORE_CODE,  " & _
        " PREFERRED_CONTACT_TYPE_CODE, " & _
        " TITLE_CODE, " & _
        " '1', " & _
        " '1', " & _
        " '1',   " & _
        " '1', " & _
        " '1', " & _
        " '1',  " & _
        " '1', " & _
        " '1', " & _
        " '1', " & _
        " '1', " & _
        " '1', " & _
        " '1',  " & _
        " '', " & _
        " '', " & _
        " '',  " & _
        " '',  " & _
        " '', " & _
        " '',  " & _
        " DATE_FORMAT( TBL_MAILBAG.DateFrontLetter ,  '%Y-%m-%d' ) as DateFrontLetter1, " & _
        " '', " & _
        " cast(race_code as char(1)) as race_code1,  " & _
        "  NUMBER_OF_HOUSEHOLD_MEMBERS, " & _
        " '', " & _
        " '',  " & _
        " '', " & _
        " CAST(expat AS char(1))  as expat1, " & _
        " CAST(form_type AS char(1))  as form_type1,  " & _
        " FLAG, COUNTING_EMPLOYEEID,  " & _
        "  DATE_FORMAT( `COUNTING_DATE` ,  '%Y-%m-%d' ),  " & _
        "  `KEYIN_EMPLOYEEID`  ,  " & _
        "  DATE_FORMAT(KEYIN_DATE,  '%Y-%m-%d') , " & _
        "  DATE_FORMAT( `SUBMIT_DATE` ,  '%Y-%m-%d' ) ," & _
        " `QC_EmployeeID`, DATE_FORMAT(`QC_Date` ,  '%Y-%m-%d' ), `SUBMIT_FLAG`, `IMG_FLAG`" & _
        " FROM `tlc_member_clubcard_QC` A inner join TBL_MAILBAG on A.`MAILBAG_ID`  =TBL_MAILBAG.id  "
        cConnectMY.OpenSql1(SQLMY, rsmy)
        If rsmy.Tables(0).Rows.Count > 0 Then

            For imy = 0 To (rsmy.Tables(0).Rows.Count - 1)


                Dim SHOME_ID As String
                Dim SBUILDING_TYPE As String
                Dim SBUILDING As String
                Dim SROOM_NO As String
                Dim SFLOOR As String
                Dim SMOU As String
                Dim SSOI As String
                Dim SSTREET As String
                Dim STUMBOL As String

                Dim SCITY As String
                Dim SPROVINCE_CODE As String
                Dim SPROVINCE As String

                Dim SIDTYPE As String
                Dim SID As String


                '''''''''''



                SHOME_ID = ""
                SBUILDING_TYPE = ""
                SBUILDING = ""
                SROOM_NO = ""
                SFLOOR = ""
                SMOU = ""
                SSOI = ""
                SSTREET = ""
                STUMBOL = ""
                SCITY = ""
                SPROVINCE_CODE = ""
                SPROVINCE = ""
                SIDTYPE = ""
                SID = ""


                Dim tmpaddr1() As String
                'Dim resultaddr1 As String
                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("address_line_1").ToString) And rsmy.Tables(0).Rows(imy)("address_line_1").ToString <> "" Then

                    tmpaddr1 = Split((rsmy.Tables(0).Rows(imy)("address_line_1").ToString), "##")

                    If Trim(tmpaddr1(0)) <> "" Then
                        SHOME_ID = Trim(tmpaddr1(0))
                    Else
                        SHOME_ID = ""
                    End If

                    SBUILDING_TYPE = ""
                    SBUILDING = ""

                    If Trim(tmpaddr1(1)) = "0" Then
                        SBUILDING_TYPE = "อาคาร"
                        SBUILDING = Trim(tmpaddr1(2))
                        'resultaddr1 = resultaddr1 & " " & "อาคาร " & Trim(tmpaddr1(2))
                    ElseIf Trim(tmpaddr1(1)) = "1" Then
                        SBUILDING_TYPE = "หมู่บ้าน"
                        SBUILDING = Trim(tmpaddr1(2))
                    Else
                        SBUILDING_TYPE = ""
                        SBUILDING = Trim(tmpaddr1(2))
                    End If






                    If Trim(tmpaddr1(3)) <> "" Then
                        SROOM_NO = Trim(tmpaddr1(3))
                    Else
                        SROOM_NO = ""
                    End If

                    If Trim(tmpaddr1(4)) <> "" Then
                        SFLOOR = Trim(tmpaddr1(4))
                    Else
                        SFLOOR = ""
                    End If
                Else
                    SHOME_ID = ""
                    SBUILDING_TYPE = ""
                    SBUILDING = ""
                    SROOM_NO = ""
                    SFLOOR = ""

                End If





                Dim tmpaddr2() As String
                'Dim resultaddr2 As String
                'tmpaddr1 = ""
                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("address_line_2").ToString) And rsmy.Tables(0).Rows(imy)("address_line_2").ToString <> "" Then


                    tmpaddr2 = Split((rsmy.Tables(0).Rows(imy)("address_line_2").ToString), "##")
                    ' out debug.print(tmpaddr2(0))
                    ' out debug.print(tmpaddr2(1))
                    ' out debug.print(tmpaddr2(2))

                    If Trim(tmpaddr2(0)) <> "" Then
                        SMOU = Trim(tmpaddr2(0))
                    Else
                        SMOU = ""
                    End If


                    If Trim(tmpaddr2(1)) <> "" Then
                        SSOI = Trim(tmpaddr2(1))
                    Else
                        SSOI = ""
                    End If

                    If Trim(tmpaddr2(2)) <> "" Then
                        SSTREET = Trim(tmpaddr2(2))
                    Else
                        SSTREET = ""
                    End If

                Else

                    SMOU = ""
                    SSOI = ""
                    SSTREET = ""
                End If


                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("address_line_3").ToString) And rsmy.Tables(0).Rows(imy)("address_line_3").ToString <> "" Then

                    STUMBOL = rsmy.Tables(0).Rows(imy)("address_line_3").ToString
                Else
                    STUMBOL = ""
                End If



                Dim tmpCity() As String

                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("CITY").ToString) And rsmy.Tables(0).Rows(imy)("CITY").ToString <> "" Then


                    tmpCity = Split((rsmy.Tables(0).Rows(imy)("CITY").ToString), "##")

                    If Trim(tmpCity(1)) <> "" Then
                        SCITY = Trim(tmpCity(1))
                    Else
                        SCITY = ""
                    End If
                Else
                    SCITY = ""
                End If

                Dim tmpProvince() As String



                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("PROVINCE_CODE").ToString) And rsmy.Tables(0).Rows(imy)("PROVINCE_CODE").ToString <> "" Then
                    tmpProvince = Split((rsmy.Tables(0).Rows(imy)("PROVINCE_CODE").ToString), "##")

                    If Trim(tmpProvince(0)) <> "" Then
                        SPROVINCE_CODE = Trim(tmpProvince(0))
                        SPROVINCE = Trim(tmpProvince(1))
                    Else

                        SPROVINCE_CODE = -1
                        SPROVINCE = Trim(tmpProvince(1))
                    End If
                Else
                    SPROVINCE_CODE = -1
                    SPROVINCE = ""
                End If

                If Not IsDBNull(rsmy.Tables(0).Rows(imy)("OFFICIAL_ID").ToString) Then
                    If Mid(rsmy.Tables(0).Rows(0)("OFFICIAL_ID").ToString, 1, 1) = "1" Then
                        SIDTYPE = "หมายเลขบัตรประชาชน"
                        SID = Mid(rsmy.Tables(0).Rows(imy)("OFFICIAL_ID").ToString, 4, 13)
                    Else
                        SIDTYPE = "Passport"
                        SID = Mid(rsmy.Tables(0).Rows(imy)("OFFICIAL_ID").ToString, 4, 20)
                    End If
                Else
                    SIDTYPE = ""
                    SID = ""
                End If

                '''''''''''''''''''''


                SQL = " INSERT INTO TBL_MEMBER_CLUBCARD_HISTORY  (CUSTID, MAILBAG_ID, CLUBCARD_NO, NAME_1, NAME_2, IDTYPE, OFFICIAL_ID, PRIMARY_CARD_ACCOUNT_NUMBER, CARD_ACCOUNT_NUMBER, " & _
                        " CUSTOMER_USE_STATUS, CUSTOMER_MAIL_STATUS,  FAMILY_MEMBER_1_GENDER_CODE, FAMILY_MEMBER_1_DOB, FAMILY_MEMBER_2_GENDER_CODE, FAMILY_MEMBER_3_GENDER_CODE,FAMILY_MEMBER_4_GENDER_CODE , " & _
                          " FAMILY_MEMBER_5_GENDER_CODE, FAMILY_MEMBER_6_GENDER_CODE, FAMILY_MEMBER_2_DOB, FAMILY_MEMBER_3_DOB,  " & _
                          " FAMILY_MEMBER_4_DOB, FAMILY_MEMBER_5_DOB, FAMILY_MEMBER_6_DOB, HOME_ID, BUILDING_TYPE, BUILDING, ROOM_NO, [FLOOR], MOU,  " & _
                          " SOI, STREET, TUMBOL, ADDRESS_LINE_1, ADDRESS_LINE_2, ADDRESS_LINE_3, CITY, PROVINCE_CODE, PROVINCE, COUNTRY, POSTAL_CODE,  " & _
                          " DAYTIME_PHONE_NUMBER, EVENING_PHONE_NUMBER, MOBILE_PHONE_NUMBER, FAX_NUMBER, EMAIL_ADDRESS, BUSINESS_NAME,  " & _
                          " BUSINESS_REGISTRATION_NUMBER, BUSINESS_TYPE_CODE, BUSINESS_ADDRESS_LINE_1, BUSINESS_ADDRESS_LINE_2,  " & _
                          " BUSINESS_ADDRESS_LINE_3, BUSINESS_ADDRESS_LINE_4, BUSINESS_ADDRESS_LINE_5, BUSINESS_ADDRESS_LINE_6,  " & _
                          " BUSINESS_POSTAL_CODE, PREFERRED_STORE_CODE, JOINED_STORE_CODE, PREFERRED_CONTACT_TYPE_CODE, TITLE_CODE,  " & _
                          " TESCOGROUP_MAIL_FLAG, TESCOGROUP_EMAIL_FLAG, TESCOGROUP_PHONE_FLAG, TESCOGROUP_SMS_FLAG, PARTNER_MAIL_FLAG,  " & _
                          " PARTNER_EMAIL_FLAG, PARTNER_PHONE_FLAG, PARTNER_SMS_FLAG, RESEARCH_MAIL_FLAG, RESEARCH_EMAIL_FLAG,  " & _
                          " RESEARCH_PHONE_FLAG, RESEARCH_SMS_FLAG, DIABETIC_FLAG, VEGETERIAN_FLAG, TEETOTAL_FLAG, HALAL_FLAG, LACTOSE_FLAG,  " & _
                          " CELIAC_FLAG, CUSTOMER_CREATED_DATE, PREFERRED_MAILING_ADDRESS_FLAG, RACE_CODE, NUMBER_OF_HOUSEHOLD_MEMBERS,  " & _
                          " CARD_MEMBER_NAME_NRIC, CARD_MEMBER_DOB, CARD_MEMBER_GENDER_CODE, EXPAT, FORM_TYPE, FLAG, COUNTING_EMPLOYEEID,  " & _
                        " COUNTING_DATE, KEYIN_EMPLOYEEID, KEYIN_DATE, QC_EMPLOYEEID, QC_DATE, SUBMIT_EMPLOYEEID, SUBMIT_DATE, SUBMIT_FLAG, IMG_DATE,IMG_FLAG, ADJUST_FLAG,VERSION_DATE)  " & _
                        " SELECT    CUSTID, MAILBAG_ID, CLUBCARD_NO, NAME_1, NAME_2, IDTYPE, OFFICIAL_ID, PRIMARY_CARD_ACCOUNT_NUMBER, CARD_ACCOUNT_NUMBER, " & _
                        " CUSTOMER_USE_STATUS, CUSTOMER_MAIL_STATUS  ,FAMILY_MEMBER_1_GENDER_CODE, FAMILY_MEMBER_1_DOB, FAMILY_MEMBER_2_GENDER_CODE, FAMILY_MEMBER_3_GENDER_CODE,FAMILY_MEMBER_4_GENDER_CODE , " & _
                          " FAMILY_MEMBER_5_GENDER_CODE, FAMILY_MEMBER_6_GENDER_CODE, FAMILY_MEMBER_2_DOB, FAMILY_MEMBER_3_DOB,  " & _
                          " FAMILY_MEMBER_4_DOB, FAMILY_MEMBER_5_DOB, FAMILY_MEMBER_6_DOB, HOME_ID, BUILDING_TYPE, BUILDING, ROOM_NO, [FLOOR], MOU,  " & _
                          " SOI, STREET, TUMBOL, ADDRESS_LINE_1, ADDRESS_LINE_2, ADDRESS_LINE_3, CITY, PROVINCE_CODE, PROVINCE, COUNTRY, POSTAL_CODE,  " & _
                          " DAYTIME_PHONE_NUMBER, EVENING_PHONE_NUMBER, MOBILE_PHONE_NUMBER, FAX_NUMBER, EMAIL_ADDRESS, BUSINESS_NAME,  " & _
                          " BUSINESS_REGISTRATION_NUMBER, BUSINESS_TYPE_CODE, BUSINESS_ADDRESS_LINE_1, BUSINESS_ADDRESS_LINE_2,  " & _
                          " BUSINESS_ADDRESS_LINE_3, BUSINESS_ADDRESS_LINE_4, BUSINESS_ADDRESS_LINE_5, BUSINESS_ADDRESS_LINE_6,  " & _
                          " BUSINESS_POSTAL_CODE, PREFERRED_STORE_CODE, JOINED_STORE_CODE, PREFERRED_CONTACT_TYPE_CODE, TITLE_CODE,  " & _
                          " TESCOGROUP_MAIL_FLAG, TESCOGROUP_EMAIL_FLAG, TESCOGROUP_PHONE_FLAG, TESCOGROUP_SMS_FLAG, PARTNER_MAIL_FLAG,  " & _
                          " PARTNER_EMAIL_FLAG, PARTNER_PHONE_FLAG, PARTNER_SMS_FLAG, RESEARCH_MAIL_FLAG, RESEARCH_EMAIL_FLAG,  " & _
                          " RESEARCH_PHONE_FLAG, RESEARCH_SMS_FLAG, DIABETIC_FLAG, VEGETERIAN_FLAG, TEETOTAL_FLAG, HALAL_FLAG, LACTOSE_FLAG,  " & _
                          " CELIAC_FLAG, CUSTOMER_CREATED_DATE, PREFERRED_MAILING_ADDRESS_FLAG, RACE_CODE, NUMBER_OF_HOUSEHOLD_MEMBERS,  " & _
                          " CARD_MEMBER_NAME_NRIC, CARD_MEMBER_DOB, CARD_MEMBER_GENDER_CODE, EXPAT, FORM_TYPE, FLAG, COUNTING_EMPLOYEEID,  " & _
                        " COUNTING_DATE, KEYIN_EMPLOYEEID, KEYIN_DATE,  QC_EMPLOYEEID, QC_DATE, SUBMIT_EMPLOYEEID,SUBMIT_DATE, SUBMIT_FLAG,IMG_DATE,IMG_FLAG, ADJUST_FLAG ,getdate() " & _
                        " FROM         TBL_MEMBER_CLUBCARD  " & _
                        " WHERE CUSTID = " & rsmy.Tables(0).Rows(imy)(0).ToString & "   "


                If cConnect.Execute(SQL) = True Then
                    'MsgBox(" KEEP HISTORY OK")
                Else
                    MsgBox(" KEEP HISTORY FAILED")

                End If



                '''''''''''''''''''''''

                SQL = " UPDATE  TBL_MEMBER_CLUBCARD  SET  " & _
                      " MAILBAG_ID='" & rsmy.Tables(0).Rows(imy)(1).ToString & "', " & _
                      " CLUBCARD_NO='" & rsmy.Tables(0).Rows(imy)(2).ToString & "', " & _
        " NAME_1='" & rsmy.Tables(0).Rows(imy)(3).ToString & "'," & _
        " NAME_2='" & rsmy.Tables(0).Rows(imy)(4).ToString & "', " & _
        " OFFICIAL_ID= '" & SID & "' ,  " & _
        " PRIMARY_CARD_ACCOUNT_NUMBER='" & rsmy.Tables(0).Rows(imy)(6).ToString & "', " & _
        " CARD_ACCOUNT_NUMBER='" & rsmy.Tables(0).Rows(imy)(7).ToString & "', " & _
        " CUSTOMER_USE_STATUS='" & rsmy.Tables(0).Rows(imy)(8).ToString & "',  " & _
        " CUSTOMER_MAIL_STATUS='" & rsmy.Tables(0).Rows(imy)(9).ToString & "', " & _
        " FAMILY_MEMBER_1_GENDER_CODE='" & rsmy.Tables(0).Rows(imy)(10).ToString & "', " & _
        " FAMILY_MEMBER_1_DOB='" & rsmy.Tables(0).Rows(imy)(11).ToString & "',  " & _
        " FAMILY_MEMBER_2_GENDER_CODE='" & rsmy.Tables(0).Rows(imy)(12).ToString & "', " & _
        " FAMILY_MEMBER_3_GENDER_CODE='" & rsmy.Tables(0).Rows(imy)(13).ToString & "',  " & _
        " FAMILY_MEMBER_4_GENDER_CODE='" & rsmy.Tables(0).Rows(imy)(14).ToString & "',  " & _
        " FAMILY_MEMBER_5_GENDER_CODE='" & rsmy.Tables(0).Rows(imy)(15).ToString & "',  " & _
        " FAMILY_MEMBER_6_GENDER_CODE='" & rsmy.Tables(0).Rows(imy)(16).ToString & "',  " & _
        " FAMILY_MEMBER_2_DOB='" & rsmy.Tables(0).Rows(imy)(17).ToString & "',  " & _
        " FAMILY_MEMBER_3_DOB='" & rsmy.Tables(0).Rows(imy)(18).ToString & "',   " & _
        " FAMILY_MEMBER_4_DOB='" & rsmy.Tables(0).Rows(imy)(19).ToString & "',  " & _
        " FAMILY_MEMBER_5_DOB='" & rsmy.Tables(0).Rows(imy)(20).ToString & "',  " & _
        " FAMILY_MEMBER_6_DOB='" & rsmy.Tables(0).Rows(imy)(21).ToString & "',  " & _
        " ADDRESS_LINE_1='" & rsmy.Tables(0).Rows(imy)(22).ToString & "',  " & _
        " ADDRESS_LINE_2='" & rsmy.Tables(0).Rows(imy)(23).ToString & "',  " & _
        " ADDRESS_LINE_3='" & rsmy.Tables(0).Rows(imy)(24).ToString & "',  " & _
        " CITY='" & SCITY & "',   " & _
        " PROVINCE_CODE= '" & SPROVINCE_CODE & "',  " & _
        " COUNTRY ='" & rsmy.Tables(0).Rows(imy)(27).ToString & "',  " & _
        " POSTAL_CODE ='" & rsmy.Tables(0).Rows(imy)(28).ToString & "',  " & _
        " DAYTIME_PHONE_NUMBER ='" & rsmy.Tables(0).Rows(imy)(29).ToString & "',  " & _
        " EVENING_PHONE_NUMBER ='" & rsmy.Tables(0).Rows(imy)(30).ToString & "',  " & _
        " MOBILE_PHONE_NUMBER ='" & rsmy.Tables(0).Rows(imy)(31).ToString & "',  " & _
        " FAX_NUMBER ='" & rsmy.Tables(0).Rows(imy)(32).ToString & "',  " & _
        " EMAIL_ADDRESS ='" & rsmy.Tables(0).Rows(imy)(33).ToString & "',  " & _
        " BUSINESS_NAME ='" & rsmy.Tables(0).Rows(imy)(34).ToString & "',  " & _
        " BUSINESS_REGISTRATION_NUMBER ='" & rsmy.Tables(0).Rows(imy)(35).ToString & "',  " & _
        " BUSINESS_TYPE_CODE ='" & rsmy.Tables(0).Rows(imy)(36).ToString & "',  " & _
        " BUSINESS_ADDRESS_LINE_1 ='" & rsmy.Tables(0).Rows(imy)(37).ToString & "',  " & _
        " BUSINESS_ADDRESS_LINE_2 ='" & rsmy.Tables(0).Rows(imy)(38).ToString & "',  " & _
        " BUSINESS_ADDRESS_LINE_3 ='" & rsmy.Tables(0).Rows(imy)(39).ToString & "',  " & _
        " BUSINESS_ADDRESS_LINE_4 ='" & rsmy.Tables(0).Rows(imy)(40).ToString & "',  " & _
        " BUSINESS_ADDRESS_LINE_5 ='" & rsmy.Tables(0).Rows(imy)(41).ToString & "',  " & _
        " BUSINESS_ADDRESS_LINE_6 ='" & rsmy.Tables(0).Rows(imy)(41).ToString & "',  " & _
        " BUSINESS_POSTAL_CODE ='" & rsmy.Tables(0).Rows(imy)(43).ToString & "', " & _
        " PREFERRED_STORE_CODE ='" & rsmy.Tables(0).Rows(imy)(44).ToString & "',  " & _
        " JOINED_STORE_CODE ='" & rsmy.Tables(0).Rows(imy)(45).ToString & "',   " & _
        " PREFERRED_CONTACT_TYPE_CODE ='" & rsmy.Tables(0).Rows(imy)(46).ToString & "',  " & _
        " TITLE_CODE ='" & rsmy.Tables(0).Rows(imy)(47).ToString & "', " & _
        "  TESCOGROUP_MAIL_FLAG ='" & rsmy.Tables(0).Rows(imy)(48).ToString & "',  " & _
        " TESCOGROUP_EMAIL_FLAG ='" & rsmy.Tables(0).Rows(imy)(49).ToString & "',  " & _
        " TESCOGROUP_PHONE_FLAG ='" & rsmy.Tables(0).Rows(imy)(50).ToString & "',   " & _
        " TESCOGROUP_SMS_FLAG ='" & rsmy.Tables(0).Rows(imy)(51).ToString & "',  " & _
        " PARTNER_MAIL_FLAG ='" & rsmy.Tables(0).Rows(imy)(52).ToString & "',  " & _
        " PARTNER_EMAIL_FLAG ='" & rsmy.Tables(0).Rows(imy)(53).ToString & "',  " & _
        " PARTNER_PHONE_FLAG ='" & rsmy.Tables(0).Rows(imy)(54).ToString & "',  " & _
        " PARTNER_SMS_FLAG ='" & rsmy.Tables(0).Rows(imy)(55).ToString & "',  " & _
        " RESEARCH_MAIL_FLAG ='" & rsmy.Tables(0).Rows(imy)(56).ToString & "', " & _
        " RESEARCH_EMAIL_FLAG ='" & rsmy.Tables(0).Rows(imy)(57).ToString & "',  " & _
        " RESEARCH_PHONE_FLAG ='" & rsmy.Tables(0).Rows(imy)(58).ToString & "',  " & _
        " RESEARCH_SMS_FLAG ='" & rsmy.Tables(0).Rows(imy)(59).ToString & "',  " & _
        " DIABETIC_FLAG ='" & rsmy.Tables(0).Rows(imy)(60).ToString & "',  " & _
        " VEGETERIAN_FLAG ='" & rsmy.Tables(0).Rows(imy)(61).ToString & "',  " & _
        " TEETOTAL_FLAG ='" & rsmy.Tables(0).Rows(imy)(62).ToString & "',  " & _
        " HALAL_FLAG ='" & rsmy.Tables(0).Rows(imy)(63).ToString & "',  " & _
        "  LACTOSE_FLAG ='" & rsmy.Tables(0).Rows(imy)(64).ToString & "',  " & _
        " CELIAC_FLAG ='" & rsmy.Tables(0).Rows(imy)(65).ToString & "',  " & _
        " CUSTOMER_CREATED_DATE ='" & rsmy.Tables(0).Rows(imy)(66).ToString & "',  " & _
        " PREFERRED_MAILING_ADDRESS_FLAG ='" & rsmy.Tables(0).Rows(imy)(67).ToString & "',  " & _
        " RACE_CODE ='" & rsmy.Tables(0).Rows(imy)(68).ToString & "',  " & _
        "  NUMBER_OF_HOUSEHOLD_MEMBERS ='" & rsmy.Tables(0).Rows(imy)(69).ToString & "',  " & _
        " CARD_MEMBER_NAME_NRIC ='" & rsmy.Tables(0).Rows(imy)(70).ToString & "',  " & _
        " CARD_MEMBER_DOB ='" & rsmy.Tables(0).Rows(imy)(71).ToString & "',  " & _
        " CARD_MEMBER_GENDER_CODE ='" & rsmy.Tables(0).Rows(imy)(72).ToString & "',  " & _
        " EXPAT ='" & rsmy.Tables(0).Rows(imy)(73).ToString & "',  " & _
        " FORM_TYPE ='" & rsmy.Tables(0).Rows(imy)(74).ToString & "',  " & _
        " FLAG ='" & rsmy.Tables(0).Rows(imy)(75).ToString & "',  " & _
        " COUNTING_EMPLOYEEID ='" & rsmy.Tables(0).Rows(imy)(76).ToString & "',  " & _
        " COUNTING_DATE ='" & rsmy.Tables(0).Rows(imy)(77).ToString & "',  " & _
        " KEYIN_EMPLOYEEID ='" & rsmy.Tables(0).Rows(imy)(78).ToString & "',  " & _
        " KEYIN_DATE ='" & rsmy.Tables(0).Rows(imy)(79).ToString & "',  " & _
        " SUBMIT_DATE ='" & rsmy.Tables(0).Rows(imy)(80).ToString & "', " & _
        " HOME_ID='" & SHOME_ID & "',  " & _
        " BUILDING_TYPE='" & SBUILDING_TYPE & "',  " & _
        " BUILDING= '" & SBUILDING & "',  " & _
        " ROOM_NO= '" & SROOM_NO & "',  " & _
        " FLOOR= '" & SFLOOR & "' ,  " & _
        " MOU='" & SMOU & "',  " & _
        " SOI= '" & SSOI & "',  " & _
        " STREET='" & SSTREET & "',  " & _
        " TUMBOL= '" & STUMBOL & "', " & _
        " PROVINCE= '" & SPROVINCE & "', " & _
        " IDTYPE= '" & SIDTYPE & "', " & _
        " QC_EMPLOYEEID='" & rsmy.Tables(0).Rows(imy)(81).ToString & "',  " & _
        " QC_DATE='" & rsmy.Tables(0).Rows(imy)(82).ToString & "',  " & _
        " SUBMIT_FLAG='" & rsmy.Tables(0).Rows(imy)(83).ToString & "',  " & _
        " IMG_FLAG='" & rsmy.Tables(0).Rows(imy)(84).ToString & "'  " & _
        " WHERE CUSTID = " & rsmy.Tables(0).Rows(imy)(0).ToString & "  "



                cConnect.Execute(SQL)
            Next imy
            MsgBox("COMPLETED")
        Else
            MsgBox("NORECORD")

        End If


        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click



        Dim i As Long
        Dim sql As String
        'FileOpen(9, "C:\Documents and Settings\yuwadee.t\Desktop\ClubcardList_20120629.txt", OpenMode.Input)
        'MsgBox("completed")



        Dim myReader As StreamReader
        Dim CurrentLine As String
        Dim strValue() As String

        myReader = New StreamReader("C:\Documents and Settings\yuwadee.t\My Documents\Downloads\V_CLUBCARD.csv", System.Text.UnicodeEncoding.Default)
        i = 0
        Debug.Print(Now())
        While myReader.Peek <> -1
            CurrentLine = myReader.ReadLine
            i = i + 1
            strValue = CurrentLine.Split("|")
            If Mid(strValue(0), 1, 4) = "6340" Then

                sql = " INSERT INTO TBL_TESCO  " & _
                      " (CLUBCARD_NO ) " & _
                    " VALUES      " & _
                " ( '" & strValue(0) & "'  )  "
                cConnect.Execute(sql)
            End If
            If i Mod 20000 = 0 Then
                'Sleep(4000)
            End If
        End While

        Debug.Print(Now())
        Debug.Print(i)
        MsgBox("OK")
        myReader.Close()
        myReader = Nothing

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim SQL, SQL1 As String
        Dim RS As New Data.DataSet
        Dim I, x As Integer

        Dim SQLMY As String

        Dim rsmy As New Data.DataSet
        Dim imy As Long



        SQL = "SELECT CUSTID  FROM TBL_MEMBER_CLUBCARD  WHERE (KEYIN_EMPLOYEEID = '' OR KEYIN_EMPLOYEEID IS NULL) AND FLAG <> 'NEW'"
        cConnect.OpenSql(SQL, RS)


        If RS.Tables(0).Rows.Count < 1 Then
            Exit Sub
        End If
        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If
        x = 0
        For I = 0 To RS.Tables(0).Rows.Count - 1

     



            SQLMY = "SELECT `username`, `id` FROM `KEYIN_ID` WHERE `id`  = " & RS.Tables(0).Rows(I)("CUSTID").ToString & " "
            cConnectMY.OpenSql1(SQLMY, rsmy)
            'Debug.Print(RSMY.Tables(0).Rows.Count)
            'Debug.Print(RSMY.Tables(0).Rows(0)(0).ToString)

            If rsmy.Tables(0).Rows.Count < 1 Then
                GoTo nextlp
                x = x + 1
            End If

            If rsmy.Tables(0).Rows(0)(0).ToString = "" Or IsDBNull(rsmy.Tables(0).Rows(0)(0).ToString) Then
                GoTo nextlp
                x = x + 1
            End If

            SQL1 = "UPDATE TBL_MEMBER_CLUBCARD " & _
            " SET KEYIN_EMPLOYEEID  = '" & rsmy.Tables(0).Rows(0)(0).ToString & "' " & _
            "WHERE CUSTID  = " & RS.Tables(0).Rows(I)("CUSTID").ToString & ""

            'Debug.Print(SQL1)
            cConnect.Execute(SQL1)
nextlp: Next I
        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        MsgBox("cOMPLETED")
        MsgBox(x)


      

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim SQL, SQL1 As String
        Dim RS As New Data.DataSet
        Dim I, x As Integer

        Dim SQLMY As String

        Dim rsmy As New Data.DataSet
        Dim imy As Long



        SQL = "SELECT CUSTID  FROM TBL_MEMBER_CLUBCARD  WHERE (QC_EMPLOYEEID = '' OR QC_EMPLOYEEID IS NULL) AND FLAG <> 'NEW'"
        cConnect.OpenSql(SQL, RS)


        If RS.Tables(0).Rows.Count < 1 Then
            Exit Sub
        End If
        If cConnectMY.Connect(MYDNS) = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If
        x = 0
        For I = 0 To RS.Tables(0).Rows.Count - 1





            SQLMY = "SELECT `username`, `id` FROM `QC_ID` WHERE `id`  = " & RS.Tables(0).Rows(I)("CUSTID").ToString & " "
            cConnectMY.OpenSql1(SQLMY, rsmy)
            'Debug.Print(RSMY.Tables(0).Rows.Count)
            'Debug.Print(RSMY.Tables(0).Rows(0)(0).ToString)

            If rsmy.Tables(0).Rows.Count < 1 Then
                GoTo nextlp
                x = x + 1
            End If

            If rsmy.Tables(0).Rows(0)(0).ToString = "" Or IsDBNull(rsmy.Tables(0).Rows(0)(0).ToString) Then
                GoTo nextlp
                x = x + 1
            End If

            SQL1 = "UPDATE TBL_MEMBER_CLUBCARD " & _
            " SET QC_EMPLOYEEID  = '" & rsmy.Tables(0).Rows(0)(0).ToString & "' " & _
            "WHERE CUSTID  = " & RS.Tables(0).Rows(I)("CUSTID").ToString & ""

            'Debug.Print(SQL1)
            cConnect.Execute(SQL1)
nextlp: Next I
        If cConnectMY.DisConnect = False Then
            MsgBox("ติดต่อฐานข้อมูลไม่ได้", MsgBoxStyle.Critical)
        End If

        MsgBox("cOMPLETED")
        MsgBox(x)




    End Sub
End Class