Imports MySql.Data.MySqlClient

Imports Ionic.Zip

Imports System.io

Public Class FrmGenXML
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    Dim processing As Boolean
    Dim fileprocess As Integer
    Dim rsXML As Data.DataSet
    Dim XMLData As String ' file name of XML Data file  file number #9
    Dim XMLData1 As String ' XML data File name  แบบไม่มี path

    Dim appendMode9 As Boolean = False ' This overwrites the entire file.
    Dim sw9 As StreamWriter

    Dim appendMode8 As Boolean = False ' This overwrites the entire file.
    Dim sw8 As StreamWriter



    Dim XMLType As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cConnect = New clsConnectMySQL
        'cGpg = New ClsGPG


        'cConnect.Connect(DNS)
        'Call CalGetSystemDate() ' ดึงค่าวันปัจจุบันใส่ปฏิทิน

        'XMLType = ""
    End Sub

    Private Sub Cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdexit.Click
        cConnect.DisConnect()
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()
    End Sub




    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click




        Dim i As Boolean

        Dim sql, DDATE, QCDATE As String
        'Dim TempLoop As Short
        Dim x As Integer

        Dim IMGtarget As String
        Dim IMGSource As String

        'If Optsigned.Checked = False And Optunsigned.Checked = False Then
        '    MsgBox("ยังไม่ได้เลือกประเภท Application", MsgBoxStyle.OkOnly, "")
        '    Exit Sub
        'End If

        If (txtDate.Text) = "" Then
            MsgBox("ยังไม่ได้เลือกวันที่ Submit", MsgBoxStyle.OkOnly, "")
            Exit Sub
        End If


        DDATE = ChangeThaiDateToEngDate(txtDate.Text)

        If (TxtQCDate.Text) = "" Then
            MsgBox("ยังไม่ได้เลือกวันที่ QC", MsgBoxStyle.OkOnly, "")
            Exit Sub
        End If


        QCDATE = ChangeThaiDateToEngDate(TxtQCDate.Text)
        'signed 


        sql = " SELECT     CLUBCARD_NO, CUSTID FROM TBL_MEMBER_CLUBCARD  " & _
                "  WHERE  FLAG = 'QC'  and   (SUBMIT_FLAG IS NULL or  SUBMIT_FLAG='' ) " & _
                " and convert(varchar(10),QC_DATE,20)  < = '" & QCDATE & "'   " & _
                " order by CUSTID "

        'sql = " SELECT     CLUBCARD_NO, CUSTID FROM TBL_MEMBER_CLUBCARD  " & _
        '                "  WHERE  FLAG = 'QC'  and   (  SUBMIT_FLAG='SUBMIT' ) " & _
        '                " and convert(varchar(10),SUBMIT_DATE,20)  = '" & QCDATE & "'   " & _
        '                " order by CUSTID "




        ListXML.Items.Clear()
        rsXML = New Data.DataSet

        i = cConnect.OpenSql(sql, rsXML)
        If i = True Then
            If rsXML.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rsXML.Tables(0).Rows.Count - 1
                    ListXML.Items.Add(Trim(rsXML.Tables(0).Rows(x)("CLUBCARD_NO").ToString) & "|" & Trim(rsXML.Tables(0).Rows(x)("CUSTID").ToString))
                Next x
            End If
        End If


        'search image

        'sign
        sql = " SELECT     CLUBCARD_NO, CUSTID FROM TBL_MEMBER_CLUBCARD  " & _
                "  WHERE CUSTOMER_USE_STATUS =0 and FLAG = 'QC'  and   (IMG_FLAG IS NULL or  IMG_FLAG='' )" & _
                " and convert(varchar(10),QC_DATE,20)  < = '" & QCDATE & "'   " & _
                " order by CUSTID "

        'sql = " SELECT     CLUBCARD_NO, CUSTID FROM TBL_MEMBER_CLUBCARD  " & _
        '                "  WHERE CUSTOMER_USE_STATUS =0 and FLAG = 'QC'  and   ( IMG_FLAG='IMGOK' )" & _
        '                " and convert(varchar(10),IMG_DATE,20)  = '" & QCDATE & "'   " & _
        '                " order by CUSTID "


        LstSignIMG.Items.Clear()
        rsXML = New Data.DataSet

        i = cConnect.OpenSql(sql, rsXML)
        If i = True Then
            If rsXML.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rsXML.Tables(0).Rows.Count - 1

                    IMGSource = Txtsourcesign.Text
                    IMGtarget = IMGSource & Trim(rsXML.Tables(0).Rows(x)("CLUBCARD_NO").ToString) & ".pdf"

                    If Dir(IMGtarget, FileAttribute.Archive) <> "" Then
                        LstSignIMG.Items.Add(Trim(rsXML.Tables(0).Rows(x)("CLUBCARD_NO").ToString) & "|" & Trim(rsXML.Tables(0).Rows(x)("CUSTID").ToString))
                    End If

                Next x
            End If
        End If




        'add unsign ต่อท้าย

        sql = " SELECT     CLUBCARD_NO, CUSTID FROM TBL_MEMBER_CLUBCARD  " & _
                "  WHERE CUSTOMER_USE_STATUS =6 and FLAG = 'QC'  and   (IMG_FLAG IS NULL or  IMG_FLAG='' )  " & _
                " and convert(varchar(10),QC_DATE,20)   <= '" & QCDATE & "'   " & _
                " order by CUSTID "

        'sql = " SELECT     CLUBCARD_NO, CUSTID FROM TBL_MEMBER_CLUBCARD  " & _
        '                       "  WHERE CUSTOMER_USE_STATUS =6 and FLAG = 'QC'  and   ( IMG_FLAG='IMGOK' )" & _
        '                       " and convert(varchar(10),IMG_DATE,20)  = '" & QCDATE & "'   " & _
        '                       " order by CUSTID "


        LstUNsignIMG.Items.Clear()
        rsXML = New Data.DataSet

        i = cConnect.OpenSql(sql, rsXML)
        If i = True Then
            If rsXML.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rsXML.Tables(0).Rows.Count - 1

                    IMGSource = TxtsourceUnsign.Text & "unsigned-"
                    IMGtarget = IMGSource & Trim(rsXML.Tables(0).Rows(x)("CLUBCARD_NO").ToString) & ".pdf"

                    If Dir(IMGtarget, FileAttribute.Archive) <> "" Then
                        LstUNsignIMG.Items.Add(Trim(rsXML.Tables(0).Rows(x)("CLUBCARD_NO").ToString) & "|" & Trim(rsXML.Tables(0).Rows(x)("CUSTID").ToString))
                    End If

                Next x
            End If
        End If



        TxtRecno.Text = ListXML.Items.Count
        Txtsignimg.Text = LstSignIMG.Items.Count
        Txtunsignimg.Text = LstUNsignIMG.Items.Count

        If ListXML.Items.Count = 0 Then
            CmdUpdate.Enabled = False
            CmdSubmit.Enabled = False
        Else
            CmdUpdate.Enabled = True
            CmdSubmit.Enabled = False
        End If





    End Sub



    '    Private Sub CmdCopySigned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCopySigned.Click, Button3.Click
    '        Dim fileCnt As Integer
    '        Dim totalloop As Integer
    '        Dim i As Integer
    '        Dim loopcount As Integer
    '        Dim target, target1 As String
    '        Dim folderSSS As String
    '        Dim Ddate As String


    '        If ListXML.Items.Count < 1 Then Exit Sub



    '        fileCnt = TxtFilecnt.Text

    '        loopcount = ListXML.Items.Count / fileCnt
    '        If loopcount = 0 Then loopcount = 1
    '        'Dim TotalLoop As Integer
    '        Dim difftotal As Integer
    '        difftotal = (loopcount * fileCnt) - ListXML.Items.Count



    '        If Trim(TxtFilecnt.Text) = "" Then
    '            MsgBox("ยังไม่ได้กำหนดจำนวนไฟล์ต่อ 1 Folder")
    '            Exit Sub
    '        End If


    '        If Len(Trim(loopcount)) > 3 Then
    '            MsgBox("กำหนดจำนวนไฟล์ต่อ folder น้อยเกินไป กรุณากำหนดใหม่")
    '            Exit Sub
    '        End If

    '        Ddate = ChangeThaiDateToEngDate(txtDate.Text)


    '        For totalloop = 1 To loopcount
    '            folderSSS = ""

    '            Select Case Len(Trim(totalloop))

    '                Case 1
    '                    folderSSS = "00" & Trim(totalloop)
    '                Case 2
    '                    folderSSS = "0" & Trim(totalloop)
    '                Case 3
    '                    folderSSS = Trim(totalloop)
    '            End Select

    '            target = TxtTarget.Text & "IMG_" & Ddate & "_" & folderSSS
    '            target1 = "IMG_" & Ddate & "_" & folderSSS
    '            If Dir(target, FileAttribute.Directory) = "" Then
    '                MkDir(target)
    '            Else
    '                If MsgBox("มี folder ชื่อว่า " & target & "อยู่แล้วต้องการ copy ทับใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                    RmDir(target)
    '                    MkDir(target)
    '                    GoTo nextloop
    '                End If
    '            End If


    '            If totalloop = loopcount Then
    '                fileCnt = fileCnt - difftotal
    '            Else
    '                fileCnt = fileCnt
    '            End If


    '            For i = 1 To fileCnt

    '                ' out debug.print((Txtsourcesign.Text & ListXML.Items(0) & ".pdf"))

    '                ' out debug.print(Dir(Txtsourcesign.Text & ListXML.Items(0) & ".pdf"))

    '                If Dir(Txtsourcesign.Text & ListXML.Items(0) & ".pdf") <> "" Then
    '                    ' out debug.print(target & "\")


    '                    FileCopy(Txtsourcesign.Text & ListXML.Items(0) & ".pdf", target & "\" & ListXML.Items(0) & ".pdf")
    '                    Listsigned_OK.Items.Add(ListXML.Items(0))
    '                    ListXML.Items.RemoveAt(0)
    '                Else
    '                    Listsignederror.Items.Add(ListXML.Items(0))
    '                    ListXML.Items.RemoveAt(0)
    '                End If


    '            Next i

    '            'add file to zip

    '            Dim OKFILE As String
    '            Dim zipMD5Hash, gpgMD5Hash As String
    '            Dim zipFSize, gpgFSize As String

    '            'เขียน Header file

    '            OKFILE = target & ".OK"
    '            FileOpen(1, OKFILE, OpenMode.Output)


    '            Call addfoldertoZIP(target)

    '            Sleep(8000)

    '            ' write text file


    '            zipMD5Hash = ""
    '            zipFSize = ""


    '            zipMD5Hash = getMD5Hash(target & ".zip")
    'recal1:


    '            If Val(Getfilesize(target & ".zip")) = 0 Then
    '                GoTo recal1
    '            Else
    '                zipFSize = Getfilesize(target & ".zip")
    '                GoTo nextloop1
    '            End If

    'nextloop1:




    '            Call EncryptGPG(target & ".zip")

    '            Sleep(8000)

    '            gpgMD5Hash = ""
    '            gpgFSize = ""


    '            gpgMD5Hash = getMD5Hash(target & ".zip.gpg")
    'recal2:
    '            If Val(Getfilesize(target & ".zip.gpg")) = 0 Then
    '                GoTo recal2
    '            Else
    '                gpgFSize = Getfilesize(target & ".zip.gpg")
    '                GoTo nextloop2
    '            End If
    'nextloop2:
    '            Dim tmpprtln As String
    '            Dim prtln As String
    '            Dim z As Integer
    '            'เขียน Header file
    '            sw1.writeline("--                              Image Export Summary                              --")
    '            sw1.writeline("--                                                                                --")
    '            sw1.writeline("--     Export date  : " & Ddate & "                                                  --")
    '            sw1.writeline("--     Records  : " & Listsigned_OK.Items.Count & "                                                              --")
    '            sw1.writeline("--                                                                                --")
    '            sw1.writeline("")
    '            sw1.writeline("File name                     MD5SUM                                            Size")
    '            sw1.writeline("----------------------        --------------------------------           -----------")

    '            prtln = ""

    '            If Len(target1 & ".zip.gpg") < 31 Then
    '                For z = Len(target1 & ".zip.gpg") + 1 To 31 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = target1 & ".zip.gpg" & prtln & gpgMD5Hash

    '            prtln = ""

    '            If Len(tmpprtln) < 74 Then
    '                For z = Len(tmpprtln) + 1 To 74 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = tmpprtln & prtln & gpgFSize
    '            sw1.writeline(tmpprtln)

    '            'sw1.writeline( target1 & ".zip.gpg" & "             " & gpgMD5Hash & "        " & gpgFSize)

    '            'sw1.writeline( target1 & ".zip" & "             " & zipMD5Hash & "        " & zipFSize)


    '            prtln = ""

    '            If Len(target1 & ".zip") < 31 Then
    '                For z = Len(target1 & ".zip") + 1 To 31 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = target1 & ".zip" & prtln & zipMD5Hash

    '            prtln = ""

    '            If Len(tmpprtln) < 74 Then
    '                For z = Len(tmpprtln) + 1 To 74 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = tmpprtln & prtln & zipFSize
    '            sw1.writeline(tmpprtln)
    '            sw1.writeline("Image files list")
    '            sw1.writeline("------------------------------------------------------------------------------------")


    '            Dim x, y As Integer
    '            Dim PrtStr As String

    '            y = 1
    '            PrtStr = ""
    '            For x = 0 To Listsigned_OK.Items.Count - 1
    '                If PrtStr = "" Then
    '                    PrtStr = Listsigned_OK.Items(x).ToString
    '                Else
    '                    PrtStr = PrtStr & "   " & Listsigned_OK.Items(x).ToString
    '                End If


    '                If y = 4 Then
    '                    sw1.writeline(PrtStr)
    '                    PrtStr = ""
    '                    y = 0
    '                End If
    '                y = y + 1
    '            Next x



    '            sw1.Close()
    '            Listsigned_OK.Items.Clear()
    'nextloop: Next totalloop

    '        MsgBox("Completed")


    '    End Sub

    '    Private Sub CmdCopyunSigned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCopyunSigned.Click
    '        Dim fileCnt As Integer
    '        Dim totalloop As Integer
    '        Dim i As Integer
    '        Dim loopcount As Integer
    '        Dim target, target1 As String
    '        Dim folderSSS As String
    '        Dim Ddate As String


    '        If Listunsigned.Items.Count < 1 Then Exit Sub



    '        fileCnt = TxtFilecnt.Text

    '        loopcount = Listunsigned.Items.Count / fileCnt

    '        If loopcount = 0 Then loopcount = 1

    '        'Dim TotalLoop As Integer
    '        Dim difftotal As Integer
    '        difftotal = (loopcount * fileCnt) - Listunsigned.Items.Count



    '        If Trim(TxtFilecnt.Text) = "" Then
    '            MsgBox("ยังไม่ได้กำหนดจำนวนไฟล์ต่อ 1 Folder")
    '            Exit Sub
    '        End If


    '        If Len(Trim(loopcount)) > 3 Then
    '            MsgBox("กำหนดจำนวนไฟล์ต่อ folder น้อยเกินไป กรุณากำหนดใหม่")
    '            Exit Sub
    '        End If

    '        Ddate = ChangeThaiDateToEngDate(txtDate.Text)



    '        For totalloop = 1 To loopcount
    '            folderSSS = ""

    '            Select Case Len(Trim(totalloop))

    '                Case 1
    '                    folderSSS = "00" & Trim(totalloop)
    '                Case 2
    '                    folderSSS = "0" & Trim(totalloop)
    '                Case 3
    '                    folderSSS = Trim(totalloop)
    '            End Select

    '            target = TxtTarget.Text & "UNSIGNED_IMG_" & Ddate & "_" & folderSSS
    '            target1 = "UNSIGNED_IMG_" & Ddate & "_" & folderSSS
    '            If Dir(target, FileAttribute.Directory) = "" Then
    '                MkDir(target)
    '            Else
    '                If MsgBox("มี folder ชื่อว่า " & target & "อยู่แล้วต้องการ copy ทับใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                    RmDir(target)
    '                    MkDir(target)
    '                    GoTo nextloop
    '                End If
    '            End If


    '            If totalloop = loopcount Then
    '                fileCnt = fileCnt - difftotal
    '            Else
    '                fileCnt = fileCnt
    '            End If


    '            For i = 1 To fileCnt

    '                ' out debug.print((TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf"))

    '                ' out debug.print(Dir(TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf"))

    '                If Dir(TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf") <> "" Then
    '                    ' out debug.print(target & "\")


    '                    FileCopy(TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf", target & "\" & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf")
    '                    Listunsigned_OK.Items.Add(Listunsigned.Items(0))
    '                    Listunsigned.Items.RemoveAt(0)
    '                Else
    '                    Listunsignederror.Items.Add(Listunsigned.Items(0))
    '                    Listunsigned.Items.RemoveAt(0)
    '                End If


    '            Next i

    '            'add file to zip

    '            Dim OKFILE As String
    '            Dim zipMD5Hash, gpgMD5Hash As String
    '            Dim zipFSize, gpgFSize As String

    '            'เขียน Header file

    '            OKFILE = target & ".OK"
    '            FileOpen(1, OKFILE, OpenMode.Output)


    '            Call addfoldertoZIP(target)

    '            Sleep(8000)

    '            ' write text file


    '            zipMD5Hash = ""
    '            zipFSize = ""


    '            zipMD5Hash = getMD5Hash(target & ".zip")
    'recal1:


    '            If Val(Getfilesize(target & ".zip")) = 0 Then
    '                GoTo recal1
    '            Else
    '                zipFSize = Getfilesize(target & ".zip")
    '                GoTo nextloop1
    '            End If

    'nextloop1:




    '            Call EncryptGPG(target & ".zip")

    '            Sleep(8000)

    '            gpgMD5Hash = ""
    '            gpgFSize = ""


    '            gpgMD5Hash = getMD5Hash(target & ".zip.gpg")
    'recal2:
    '            If Val(Getfilesize(target & ".zip.gpg")) = 0 Then
    '                GoTo recal2
    '            Else
    '                gpgFSize = Getfilesize(target & ".zip.gpg")
    '                GoTo nextloop2
    '            End If
    'nextloop2:
    '            Dim tmpprtln As String
    '            Dim prtln As String
    '            Dim z As Integer
    '            'เขียน Header file
    '            sw1.writeline("--                              Image Export Summary                              --")
    '            sw1.writeline("--                                                                                --")
    '            sw1.writeline("--     Export date  : " & Ddate & "                                                  --")
    '            sw1.writeline("--     Records  : " & Listunsigned_OK.Items.Count & "                                                              --")
    '            sw1.writeline("--                                                                                --")
    '            sw1.writeline("")
    '            sw1.writeline("File name                          MD5SUM                                       Size")
    '            sw1.writeline("----------------------             --------------------------------      -----------")

    '            prtln = ""

    '            If Len(target1 & ".zip.gpg") < 36 Then
    '                For z = Len(target1 & ".zip.gpg") + 1 To 36 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = target1 & ".zip.gpg" & prtln & gpgMD5Hash

    '            prtln = ""

    '            If Len(tmpprtln) < 79 Then
    '                For z = Len(tmpprtln) + 1 To 79 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = tmpprtln & prtln & gpgFSize
    '            sw1.writeline(tmpprtln)

    '            'sw1.writeline( target1 & ".zip.gpg" & "             " & gpgMD5Hash & "        " & gpgFSize)

    '            'sw1.writeline( target1 & ".zip" & "             " & zipMD5Hash & "        " & zipFSize)


    '            prtln = ""

    '            If Len(target1 & ".zip") < 36 Then
    '                For z = Len(target1 & ".zip") + 1 To 36 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = target1 & ".zip" & prtln & zipMD5Hash

    '            prtln = ""

    '            If Len(tmpprtln) < 79 Then
    '                For z = Len(tmpprtln) + 1 To 79 - 1
    '                    prtln = prtln & " "
    '                Next z

    '            End If
    '            tmpprtln = tmpprtln & prtln & zipFSize
    '            sw1.writeline(tmpprtln)
    '            sw1.writeline("Image files list")
    '            sw1.writeline("------------------------------------------------------------------------------------")


    '            Dim x, y As Integer
    '            Dim PrtStr As String

    '            y = 1
    '            PrtStr = ""
    '            For x = 0 To Listunsigned_OK.Items.Count - 1
    '                If PrtStr = "" Then
    '                    PrtStr = Listunsigned_OK.Items(x).ToString
    '                Else
    '                    PrtStr = PrtStr & "   " & Listunsigned_OK.Items(x).ToString
    '                End If


    '                If y = 4 Then
    '                    sw1.writeline(PrtStr)
    '                    PrtStr = ""
    '                    y = 0
    '                End If
    '                y = y + 1
    '            Next x



    '            sw1.Close()
    '            Listunsigned_OK.Items.Clear()
    'nextloop: Next totalloop

    '        MsgBox("Completed")

    '    End Sub

    Private Sub addfoldertoZIP(ByVal Target As String)
        Using zip As ZipFile = New ZipFile


            zip.AddDirectory(Target)
            zip.Save(Target & ".zip")





        End Using
lp:     If Dir(Target & ".zip", FileAttribute.Archive) = "" Then
            GoTo lp
        Else
            Exit Sub
        End If

    End Sub

    Private Sub addfiletoZIP(ByVal FSource As String, ByVal Target As String)


        Using zip As ZipFile = New ZipFile()

            zip.AddFile(FSource, "")
            zip.Save(Target & ".zip")





        End Using


lp:     If Dir(Target & ".zip", FileAttribute.Archive) = "" Then
            GoTo lp
        Else
            Exit Sub
        End If

    End Sub


    Function Getfilesize(ByVal Target As String) As String
        Dim mbb As Double
        Getfilesize = ""
        Dim fileDetail As IO.FileInfo
        fileDetail = My.Computer.FileSystem.GetFileInfo(Target)
        mbb = 0
        ' out debug.print(fileDetail.Length)
        mbb = fileDetail.Length / (1024 ^ 2)
        Getfilesize = (Math.Round(mbb, 2) & " MB")


    End Function
    Function getMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function



    '''''''''''''for GPG'''''''''''''''

    Private Sub EncryptGPG(ByVal Target As String)
        ' out debug.print(Target)




        ''Shell("C:\windows\system32\cmd.exe gpg --always-trust --recipient Walainuch.Tummanitayakul@TH.TESCO.COM --encrypt " & Target)
        'Dim ccc As String
        ''ccc = Shell("gpg --always-trust --recipient Walainuch.Tummanitayakul@TH.TESCO.COM --encrypt " & Target)
        'ccc = Shell("gpg --always-trust --recipient sinawat@q-mad.com --encrypt " & Target)


        'RunExternalFile(ccc)

        Dim ccc As String
        'ccc = Shell("gpg --always-trust --recipient Walainuch.Tummanitayakul@TH.TESCO.COM --encrypt " & Target)
        ccc = "gpg --always-trust --recipient sinawat@q-mad.com --encrypt " & Target

        Dim myprocess As New Process
        Dim StartInfo As New System.Diagnostics.ProcessStartInfo
        StartInfo.FileName = "cmd" 'starts cmd window
        StartInfo.RedirectStandardInput = True
        StartInfo.RedirectStandardOutput = True
        StartInfo.UseShellExecute = False 'required to redirect
        myprocess.StartInfo = StartInfo
        myprocess.Start()
        Dim SR As System.IO.StreamReader = myprocess.StandardOutput
        Dim SW As System.IO.StreamWriter = myprocess.StandardInput
        SW.WriteLine(ccc) 'the command you wish to run.....
        SW.WriteLine("exit") 'exits command prompt window
        txtresult.Text = SR.ReadToEnd 'returns results of the command window
        SW.Close()
        SR.Close()


lp:     If Dir(Target & ".gpg", FileAttribute.Archive) = "" Then
            GoTo lp
        Else
            Exit Sub
        End If









    End Sub
    Private Sub CMDAutomate()
        'Dim myprocess As New Process
        'Dim StartInfo As New System.Diagnostics.ProcessStartInfo
        'StartInfo.FileName = "cmd" 'starts cmd window
        'StartInfo.RedirectStandardInput = True
        'StartInfo.RedirectStandardOutput = True
        'StartInfo.UseShellExecute = False 'required to redirect
        'myprocess.StartInfo = StartInfo
        'myprocess.Start()
        'Dim SR As System.IO.StreamReader = myprocess.StandardOutput
        'Dim SW As System.IO.StreamWriter = myprocess.StandardInput
        'SW.WriteLine(txtCommand.Text) 'the command you wish to run.....
        'SW.WriteLine("exit") 'exits command prompt window
        'txtResults.Text = SR.ReadToEnd 'returns results of the command window
        'SW.Close()
        'SR.Close()
    End Sub


    Function RunExternalFile(ByVal Args As String) As String

        Dim pro As New Diagnostics.Process
        pro.StartInfo.Arguments = Args
        pro.StartInfo.FileName = "cmd.exe"
        pro.StartInfo.RedirectStandardOutput = True
        pro.StartInfo.UseShellExecute = False
        pro.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        pro.Start()
        pro.WaitForExit()
        Return pro.StandardOutput.ReadToEnd
    End Function



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


    Private Sub CmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBrowse.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        ' Description that displays above the dialog box control. 

        MyFolderBrowser.Description = "Select the Folder"
        ' Sets the root folder where the browsing starts from 
        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            TxtTarget.Text = MyFolderBrowser.SelectedPath & "\"
        End If
    End Sub


    Private Sub CmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSubmit.Click
        If TxtTarget.Text = "" Then
            MsgBox("ยังไม่ได้เลือก Target folder")
            Exit Sub

        End If

        Dim i As Integer
        Dim sql As String

        'If OptIMG.Checked = False And OptNOIMG.Checked = False Then
        '    MsgBox("ยังไม่ได้เลือกประเภทที่ต้องการ GEN")
        '    Exit Sub
        'End If
        'If OptIMG.Checked = True Then
        If MsgBox("ต้องการ Generate XML เป็น Submit จำนวน " & ListXML.Items.Count & " รายการใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        'Else
        'If MsgBox("ต้องการ Generate XML เป็น Submit จำนวน " & lst.Items.Count & " รายการใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '    Exit Sub
        'End If
        'End If

        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = ListXML.Items.Count - 1

        ' Write the string as utf-8.
        ' This also writes the 3-byte utf-8 preamble at the beginning of the file.

        Dim XMLPREFIX As String   'Prefix for XML file
        Dim XMLOK As String ' XML OK File name  file number #8

        Dim ddate As String
        'Select Case XMLType
        '    Case "SIGNED"
        '        XMLPREFIX = "Customers_"
        '    Case "UNSIGNED"
        '        XMLPREFIX = "Unsigned_Customers_"
        'End Select
        ddate = Replace(ChangeThaiDateToEngDate(txtDate.Text), "-", "") & "_" & Format(Now(), "HHMM")
        'ddate = Replace(ChangeThaiDateToEngDate(txtDate.Text), "-", "") & "_" & "1607"
        ' open file XML Data & XML OK to write data
        XMLPREFIX = "Customers_"
        XMLData = TxtTarget.Text & XMLPREFIX & ddate & "_001.xml"

        XMLData1 = XMLPREFIX & ddate & "_001.xml"
        XMLOK = TxtTarget.Text & XMLPREFIX & ddate & "_001.OK"

        'Write XML Data header

        sw9 = New StreamWriter(XMLData, appendMode9, System.Text.Encoding.UTF8)
        'FileOpen(9, XMLData, OpenMode.Output)
        sw9.WriteLine("<?xml version=" & """" & "1.0" & """" & " encoding=" & """" & "utf-8" & """" & " standalone=" & """" & "yes" & """" & "?>")
        sw9.WriteLine("<customers xmlns:xsi=" & """" & "http://www.w3.org/2001/XMLSchema-instance" & """" & ">")




        For i = 0 To ListXML.Items.Count - 1

            Dim cCUSTID As String
            'write XML Data file
            cCUSTID = Trim(Mid(ListXML.Items(i).ToString, InStr(ListXML.Items(i).ToString, "|") + 1, 100))
            ClearXML()
            ' out debug.print(ListXMLtogen.Items.Count)
            ' out debug.print(ListXMLtogen.Items(i).ToString)
            SetXMLValue(cCUSTID)
            WriteXML()




            ProgressBar1.Value = i

        Next i


        'close XML Data File
        sw9.WriteLine("</customers>")
        sw9.Close()

        Sleep(5000)


        ' out debug.print(Dir(XMLData, FileAttribute.Archive))


        ' Zip XML Data File
        ' Gpg XML Data File

        Dim xmlMD5Hash, zipMD5Hash, gpgMD5Hash As String
        Dim XmlFSize, zipFSize, gpgFSize As String

        'เขียน Header file
        xmlMD5Hash = ""
        XmlFSize = ""

        xmlMD5Hash = getMD5Hash(XMLData)


recal0:
        If Val(Getfilesize(XMLData)) = 0 Then
            GoTo recal0
        Else
            XmlFSize = Getfilesize(XMLData)
            GoTo nextloop0
        End If




nextloop0:



        Call addfiletoZIP(XMLData, Replace(XMLData, ".xml", ""))

        Sleep(8000)

        ' write text file


        zipMD5Hash = ""
        zipFSize = ""


        zipMD5Hash = getMD5Hash(Replace(XMLData, ".xml", "") & ".zip")
recal1:


        If Val(Getfilesize(Replace(XMLData, ".xml", "") & ".zip")) = 0 Then
            GoTo recal1
        Else
            zipFSize = Getfilesize(Replace(XMLData, ".xml", "") & ".zip")
            GoTo nextloop1
        End If

nextloop1:




        Call EncryptGPG(Replace(XMLData, ".xml", "") & ".zip")

        Sleep(8000)

        gpgMD5Hash = ""
        gpgFSize = ""


        gpgMD5Hash = getMD5Hash(Replace(XMLData, ".xml", "") & ".zip.gpg")
recal2:
        If Val(Getfilesize(Replace(XMLData, ".xml", "") & ".zip.gpg")) = 0 Then
            GoTo recal2
        Else
            gpgFSize = Getfilesize(Replace(XMLData, ".xml", "") & ".zip.gpg")
            GoTo nextloop2
        End If
nextloop2:
        Dim tmpprtln As String
        Dim prtln As String
        Dim z As Integer
        'เขียน Header file

        'Write XML OK header

        sw8 = New StreamWriter(XMLOK, appendMode8, System.Text.Encoding.UTF8)

        'FileOpen(8, XMLOK, OpenMode.Output)

        sw8.WriteLine("--                               XML Export Summary                               --")
        sw8.WriteLine("--                                                                                --")
        sw8.WriteLine("--     Export date : " & ChangeThaiDateToEngDate(txtDate.Text) & "                                                 --")

        sw8.WriteLine("--     Records  : " & ListXML.Items.Count & "                                                              --")
        sw8.WriteLine("--                                                                                --")
        sw8.WriteLine("")
        sw8.WriteLine("File name                            MD5SUM                                            Size")
        sw8.WriteLine("----------------------               --------------------------------           -----------")

        prtln = ""



        'xml
        'If Len(XMLData1) < 38 Then
        '    For z = Len(XMLData1) + 1 To 38 - 1
        '        prtln = prtln & " "
        '    Next z

        'End If
        tmpprtln = XMLData1 & "      " & xmlMD5Hash

        prtln = ""

        If Len(tmpprtln) < 82 Then
            For z = Len(tmpprtln) + 1 To 82 - 1
                prtln = prtln & " "
            Next z

        End If
        tmpprtln = tmpprtln & prtln & XmlFSize
        sw8.WriteLine(tmpprtln)


        'zip
        prtln = ""

        'If Len(Replace(XMLData1, ".xml", "") & ".zip") < 38 Then
        '    For z = Len(Replace(XMLData1, ".xml", "") & ".zip") + 1 To 38 - 1
        '        prtln = prtln & " "
        '    Next z

        'End If
        tmpprtln = Replace(XMLData1, ".xml", "") & ".zip" & "      " & zipMD5Hash

        prtln = ""

        If Len(tmpprtln) < 82 Then
            For z = Len(tmpprtln) + 1 To 82 - 1
                prtln = prtln & " "
            Next z

        End If
        tmpprtln = tmpprtln & prtln & zipFSize
        sw8.WriteLine(tmpprtln)

        'gpg


        If Len(Replace(XMLData1, ".xml", "") & ".zip.gpg") < 38 Then
            For z = Len(Replace(XMLData1, ".xml", "") & ".zip.gpg") + 1 To 38 - 1
                prtln = prtln & " "
            Next z

        End If
        tmpprtln = Replace(XMLData1, ".xml", "") & ".zip.gpg" & "  " & gpgMD5Hash

        prtln = ""

        If Len(tmpprtln) < 82 Then
            For z = Len(tmpprtln) + 1 To 82 - 1
                prtln = prtln & " "
            Next z

        End If
        tmpprtln = tmpprtln & prtln & gpgFSize
        sw8.WriteLine(tmpprtln)

        'sw1.writeline( target1 & ".zip.gpg" & "             " & gpgMD5Hash & "        " & gpgFSize)

        'sw1.writeline( target1 & ".zip" & "             " & zipMD5Hash & "        " & zipFSize)



        sw8.WriteLine("  Image files           records")
        sw8.WriteLine("----------------        ------")
        ''''''''''''''''''''''''''''''''''''



        ''write XML OK footer & Close 
        'sw8.writeline( "--     Records  : " & Listsigned_OK.Items.Count & "                                                              --")
        'sw8.writeline( "--                                                                                --")
        'sw8.writeline( "")
        'sw8.writeline( "File name                     MD5SUM                                            Size")
        'sw8.writeline( "----------------------        --------------------------------           -----------")



        'Copy IMG File

        Call copyIMG()



        'Copy unsigend IMG File

        Call copyunsignedIMG()


        sw8.Close()



        MsgBox("Generate Completed", MsgBoxStyle.OkOnly, "")
        ProgressBar1.Visible = False
        CmdSubmit.Enabled = False

    End Sub

    Private Sub CmdSaveLogOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSaveLogOK.Click
        Dim cdl As New SaveFileDialog

        cdl.DefaultExt = "txt"
        cdl.Title = "Save Text File"
        cdl.Filter = "Text File|*.txt"
        cdl.InitialDirectory = Application.StartupPath
        cdl.OverwritePrompt = True

        If cdl.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim s As New StreamWriter(cdl.FileName)
            Dim x As Integer
            Dim z As String
            Dim cr_lf As String = Chr(13) + Chr(10)

            For x = 0 To Listsigned_OK.Items.Count - 1
                z = z & Listsigned_OK.Items(x).ToString + cr_lf
            Next x

            s.Write(z)
            s.Close()
            MsgBox("Save Completed")
        End If

    End Sub

    Private Sub CmdSavelogError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdIMGERROR.Click
        Dim cdl As New SaveFileDialog

        cdl.DefaultExt = "txt"
        cdl.Title = "Save Text File"
        cdl.Filter = "Text File|*.txt"
        cdl.InitialDirectory = Application.StartupPath
        cdl.OverwritePrompt = True

        If cdl.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim s As New StreamWriter(cdl.FileName)
            Dim x As Integer
            Dim z As String
            Dim cr_lf As String = Chr(13) + Chr(10)

            For x = 0 To Listsignederror.Items.Count - 1
                z = z & Listsignederror.Items(x).ToString + cr_lf
            Next x

            s.Write(z)
            s.Close()
            MsgBox("Save Completed")
        End If
    End Sub

    Private Sub SetXMLValue(ByVal cCustid As String)
        Dim sql As String
        Dim rs1 As Data.DataSet
        Dim i As Boolean
        sql = " SELECT NAME_1, " & _
  "  NAME_2,  " & _
  "  OFFICIAL_ID, " & _
  "  PRIMARY_CARD_ACCOUNT_NUMBER,  " & _
  "  CARD_ACCOUNT_NUMBER,  " & _
  "  CUSTOMER_USE_STATUS , " & _
  "   CUSTOMER_MAIL_STATUS, " & _
  "   FAMILY_MEMBER_1_GENDER_CODE  , " & _
  "   CONVERT(VARCHAR(10),FAMILY_MEMBER_1_DOB,20) AS FAMILY_MEMBER_1_DOB1 ,  " & _
  "  FAMILY_MEMBER_2_GENDER_CODE, " & _
  "   FAMILY_MEMBER_3_GENDER_CODE, " & _
  "   FAMILY_MEMBER_4_GENDER_CODE, " & _
  "  FAMILY_MEMBER_5_GENDER_CODE, " & _
  "  FAMILY_MEMBER_6_GENDER_CODE, " & _
  "  CONVERT(VARCHAR(10),FAMILY_MEMBER_2_DOB,20) AS FAMILY_MEMBER_2_DOB1 ,  " & _
  "  CONVERT(VARCHAR(10),FAMILY_MEMBER_3_DOB,20) AS FAMILY_MEMBER_3_DOB1 , " & _
  "  CONVERT(VARCHAR(10),FAMILY_MEMBER_4_DOB,20) AS FAMILY_MEMBER_4_DOB1 , " & _
  "  CONVERT(VARCHAR(10),FAMILY_MEMBER_5_DOB,20) AS FAMILY_MEMBER_5_DOB1 ,  " & _
  "  FAMILY_MEMBER_6_DOB, " & _
  "   ADDRESS_LINE_1, " & _
  "   ADDRESS_LINE_2, " & _
  "   ADDRESS_LINE_3, " & _
  "   CITY,  " & _
  "  PROVINCE_CODE, " & _
  "  COUNTRY,  " & _
  "  POSTAL_CODE, " & _
  "   DAYTIME_PHONE_NUMBER, " & _
  "  EVENING_PHONE_NUMBER, " & _
  "  MOBILE_PHONE_NUMBER,  " & _
  "  FAX_NUMBER, " & _
  "   EMAIL_ADDRESS, " & _
  "   BUSINESS_NAME, " & _
  "   BUSINESS_REGISTRATION_NUMBER, " & _
  "  BUSINESS_TYPE_CODE  ,  " & _
  "  BUSINESS_ADDRESS_LINE_1,  " & _
  "  BUSINESS_ADDRESS_LINE_2,  " & _
  "  BUSINESS_ADDRESS_LINE_3, " & _
  "   BUSINESS_ADDRESS_LINE_4,  " & _
  "  BUSINESS_ADDRESS_LINE_5,  " & _
  "  BUSINESS_ADDRESS_LINE_6,  " & _
  "  BUSINESS_POSTAL_CODE,  " & _
  "  TBL_MAILBAG.STOREID  AS STORE1,  " & _
  " TBL_MAILBAG.STOREID AS STORE2 , " & _
  "   PREFERRED_CONTACT_TYPE_CODE, " & _
  "   TITLE_CODE, " & _
  "  TESCOGROUP_MAIL_FLAG, " & _
  "  TESCOGROUP_EMAIL_FLAG, " & _
  "  TESCOGROUP_PHONE_FLAG, " & _
  "   TESCOGROUP_SMS_FLAG,  " & _
  "  PARTNER_MAIL_FLAG,  " & _
  "  PARTNER_EMAIL_FLAG,  " & _
  "  PARTNER_PHONE_FLAG,  " & _
  "  PARTNER_SMS_FLAG, " & _
  "  RESEARCH_MAIL_FLAG, " & _
  "  RESEARCH_EMAIL_FLAG, " & _
  "  RESEARCH_PHONE_FLAG, " & _
  "  RESEARCH_SMS_FLAG,  " & _
  "  DIABETIC_FLAG, " & _
  "   VEGETERIAN_FLAG, " & _
  "   TEETOTAL_FLAG, " & _
  "   HALAL_FLAG, " & _
  "   LACTOSE_FLAG, " & _
  "   CELIAC_FLAG, " & _
  "   CONVERT(VARCHAR(10), TBL_MAILBAG.DATEFRONTLETTER , 20 ) AS DATEFRONTLETTER1, " & _
  "  PREFERRED_MAILING_ADDRESS_FLAG, " & _
  "  RACE_CODE  , " & _
  "  NUMBER_OF_HOUSEHOLD_MEMBERS, " & _
  "  CARD_MEMBER_NAME_NRIC, " & _
  "  CARD_MEMBER_DOB,  " & _
  "  CARD_MEMBER_GENDER_CODE, " & _
  "   EXPAT ,  " & _
  "  FORM_TYPE,  HOME_ID, BUILDING_TYPE, BUILDING, ROOM_NO, FLOOR, MOU, SOI, STREET, TUMBOL,IDTYPE " & _
" FROM TBL_MEMBER_CLUBCARD inner join TBL_MAILBAG on TBL_MEMBER_CLUBCARD.MAILBAG_ID  =TBL_MAILBAG .MAILBAG_ID  " & _
"  WHERE CUSTID= '" & cCustid & "' "

        'Listsigned.Items.Clear()
        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then



                '01
                cXML.name_1 = (rs1.Tables(0).Rows(0)("NAME_1").ToString)
                '02
                cXML.name_2 = (rs1.Tables(0).Rows(0)("NAME_2").ToString)
                '03
                If Not IsDBNull(rs1.Tables(0).Rows(0)("official_id").ToString) Then
                    cXML.official_id = (rs1.Tables(0).Rows(0)("official_id").ToString)
                Else
                    cXML.official_id = ""
                End If
                '04  
                cXML.primary_card_account_number = (rs1.Tables(0).Rows(0)("PRIMARY_CARD_ACCOUNT_NUMBER").ToString)
                '05
                cXML.card_account_number = (rs1.Tables(0).Rows(0)("CARD_ACCOUNT_NUMBER").ToString)
                '06
                cXML.customer_use_status = Val(rs1.Tables(0).Rows(0)("CUSTOMER_USE_STATUS").ToString)
                '07
                cXML.customer_mail_status = Val(rs1.Tables(0).Rows(0)("CUSTOMER_MAIL_STATUS").ToString)
                '08
                cXML.family_member_1_gender_code = Val(rs1.Tables(0).Rows(0)("FAMILY_MEMBER_1_GENDER_CODE").ToString)
                '09

                If (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_1_DOB1").ToString) = "1900-01-01" Then
                    cXML.family_member_1_dob = ""
                Else
                    cXML.family_member_1_dob = (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_1_DOB1").ToString)
                End If

                '10
                cXML.family_member_2_gender_code = ""
                '11
                cXML.family_member_3_gender_code = ""
                '12
                cXML.family_member_4_gender_code = ""
                '13
                cXML.family_member_5_gender_code = ""
                '14
                cXML.family_member_6_gender_code = ""
                '15

                If (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_2_DOB1").ToString) = "1900-01-01" Then
                    cXML.family_member_2_dob = ""
                Else
                    cXML.family_member_2_dob = (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_2_DOB1").ToString)
                End If
                '16

                If (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_3_DOB1").ToString) = "1900-01-01" Then
                    cXML.family_member_3_dob = ""
                Else
                    cXML.family_member_3_dob = (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_3_DOB1").ToString)
                End If
                '17

                If (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_4_DOB1").ToString) = "1900-01-01" Then
                    cXML.family_member_4_dob = ""
                Else
                    cXML.family_member_4_dob = (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_4_DOB1").ToString)
                End If
                '18

                If (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_5_DOB1").ToString) = "1900-01-01" Then
                    cXML.family_member_5_dob = ""
                Else
                    cXML.family_member_5_dob = (rs1.Tables(0).Rows(0)("FAMILY_MEMBER_5_DOB1").ToString)
                End If
                '19
                cXML.family_member_6_dob = ""
                '20
                'Dim tmpaddr1() As String
                Dim resultaddr1 As String
                resultaddr1 = ""
                'HOME_ID, BUILDING_TYPE, BUILDING, ROOM_NO, FLOOR, MOU, SOI, STREET, TUMBOL
                If Not IsDBNull((rs1.Tables(0).Rows(0)("HOME_ID").ToString)) And Trim(rs1.Tables(0).Rows(0)("HOME_ID").ToString) <> "" Then
                    resultaddr1 = Trim(resultaddr1) & "เลขที่  " & (rs1.Tables(0).Rows(0)("HOME_ID").ToString)
                Else
                    resultaddr1 = Trim(resultaddr1)
                End If

                If Not IsDBNull((rs1.Tables(0).Rows(0)("BUILDING").ToString)) And Trim(rs1.Tables(0).Rows(0)("BUILDING").ToString) <> "" Then
                    resultaddr1 = Trim(resultaddr1) & (rs1.Tables(0).Rows(0)("BUILDING_TYPE").ToString) & " " & (rs1.Tables(0).Rows(0)("BUILDING").ToString) & " "
                Else
                    resultaddr1 = Trim(resultaddr1)
                End If

                If Not IsDBNull((rs1.Tables(0).Rows(0)("ROOM_NO").ToString)) And Trim(rs1.Tables(0).Rows(0)("ROOM_NO").ToString) <> "" Then
                    resultaddr1 = Trim(resultaddr1) & " ห้อง " & (rs1.Tables(0).Rows(0)("ROOM_NO").ToString)
                Else
                    resultaddr1 = Trim(resultaddr1)
                End If

                If Not IsDBNull((rs1.Tables(0).Rows(0)("FLOOR").ToString)) And Trim(rs1.Tables(0).Rows(0)("FLOOR").ToString) <> "" Then
                    resultaddr1 = Trim(resultaddr1) & " ชั้น " & (rs1.Tables(0).Rows(0)("HOME_ID").ToString)
                Else
                    resultaddr1 = Trim(resultaddr1)
                End If


                cXML.address_line_1 = Replace(resultaddr1, "&", "")

               

                ''21

         

                Dim resultaddr2 As String
                resultaddr2 = ""
                'MOU, SOI, STREET, TUMBOL
                If Not IsDBNull((rs1.Tables(0).Rows(0)("MOU").ToString)) And Trim(rs1.Tables(0).Rows(0)("MOU").ToString) <> "" Then
                    resultaddr2 = Trim(resultaddr2) & "หมู่  " & (rs1.Tables(0).Rows(0)("MOU").ToString)
                Else
                    resultaddr2 = Trim(resultaddr2)
                End If

                If Not IsDBNull((rs1.Tables(0).Rows(0)("SOI").ToString)) And Trim(rs1.Tables(0).Rows(0)("SOI").ToString) <> "" Then
                    resultaddr2 = Trim(resultaddr2) & " ซอย " & (rs1.Tables(0).Rows(0)("SOI").ToString)
                Else
                    resultaddr2 = Trim(resultaddr2)
                End If

                If Not IsDBNull((rs1.Tables(0).Rows(0)("STREET").ToString)) And Trim(rs1.Tables(0).Rows(0)("STREET").ToString) <> "" Then
                    resultaddr2 = Trim(resultaddr2) & " ถนน " & (rs1.Tables(0).Rows(0)("STREET").ToString)
                Else
                    resultaddr2 = Trim(resultaddr2)
                End If

                cXML.address_line_2 = Replace(resultaddr2, "&", "")


                Dim resultaddr3 As String
                resultaddr3 = ""
                'TUMBOL
                If Not IsDBNull((rs1.Tables(0).Rows(0)("TUMBOL").ToString)) And Trim(rs1.Tables(0).Rows(0)("TUMBOL").ToString) <> "" Then
                    If rs1.Tables(0).Rows(0)("PROVINCE_CODE").ToString = "75" Then
                        resultaddr3 = "แขวง  " & (rs1.Tables(0).Rows(0)("TUMBOL").ToString)
                    Else
                        resultaddr3 = "ตำบล  " & (rs1.Tables(0).Rows(0)("TUMBOL").ToString)
                    End If
                Else
                    resultaddr3 = Trim(resultaddr3)
                End If
                cXML.address_line_3 = Replace(resultaddr3, "&", "")


                If Not IsDBNull((rs1.Tables(0).Rows(0)("CITY").ToString)) And Trim(rs1.Tables(0).Rows(0)("CITY").ToString) <> "" Then
                    If rs1.Tables(0).Rows(0)("PROVINCE_CODE").ToString = "75" Then
                        cXML.city = "เขต  " & (rs1.Tables(0).Rows(0)("CITY").ToString)
                    Else
                        cXML.city = "อำเภอ  " & (rs1.Tables(0).Rows(0)("CITY").ToString)
                    End If
                Else
                    cXML.city = ""
                End If

                cXML.province_code = (rs1.Tables(0).Rows(0)("PROVINCE_CODE").ToString)

                    '25
                cXML.country = (rs1.Tables(0).Rows(0)("COUNTRY").ToString)
                    '26
                cXML.postal_code = (rs1.Tables(0).Rows(0)("POSTAL_CODE").ToString)
                    '27
                cXML.daytime_phone_number = (rs1.Tables(0).Rows(0)("DAYTIME_PHONE_NUMBER").ToString)
                    '28
                cXML.evening_phone_number = (rs1.Tables(0).Rows(0)("EVENING_PHONE_NUMBER").ToString)
                    '29
                cXML.mobile_phone_number = (rs1.Tables(0).Rows(0)("MOBILE_PHONE_NUMBER").ToString)
                    '30
                    cXML.fax_number = ""
                    '31
       
                cXML.email_address = (rs1.Tables(0).Rows(0)("EMAIL_ADDRESS").ToString)



                'cXML.email_address = (rs1.Tables(0).Rows(0)("email_address").ToString)
                '32
                cXML.business_name = ""
                '33
                cXML.business_registration_number = ""
                '34
                cXML.business_type_code = Val(rs1.Tables(0).Rows(0)("BUSINESS_TYPE_CODE").ToString)
                '35
                cXML.business_address_line_1 = ""
                '36
                cXML.business_address_line_2 = ""
                '37
                cXML.business_address_line_3 = ""
                '38
                cXML.business_address_line_4 = ""
                '39
                cXML.business_address_line_5 = ""
                '40
                cXML.business_address_line_6 = ""
                '41
                cXML.business_postal_code = ""
                '42
                cXML.preferred_store_code = Val(rs1.Tables(0).Rows(0)("STORE1").ToString)
                '43
                cXML.joined_store_code = (rs1.Tables(0).Rows(0)("STORE2").ToString)
                '44
                cXML.preferred_contact_type_code = "14"
                '45
       
                cXML.title_code = (rs1.Tables(0).Rows(0)("TITLE_CODE").ToString)

                '46
                cXML.tescogroup_mail_flag = "1"
                '47
                cXML.tescogroup_email_flag = "1"
                '48
                cXML.tescogroup_phone_flag = "1"
                '49
                cXML.tescogroup_sms_flag = "1"
                '50
                cXML.partner_mail_flag = "1"
                '51
                cXML.partner_email_flag = "1"
                '52
                cXML.partner_phone_flag = "1"
                '53
                cXML.partner_sms_flag = "1"
                '54
                cXML.research_mail_flag = "1"
                '55
                cXML.research_email_flag = "1"
                '56
                cXML.research_phone_flag = "1"
                '57
                cXML.research_sms_flag = "1"
                '58
                cXML.diabetic_flag = ""
                '59
                cXML.vegetarian_flag = ""
                '60
                cXML.teetotal_flag = ""
                '61
                cXML.halal_flag = ""
                '62
                cXML.lactose_flag = ""
                '63
                cXML.celiac_flag = ""
                '64
                cXML.customer_created_date = (rs1.Tables(0).Rows(0)("DATEFRONTLETTER1").ToString)
                '65
                cXML.preferred_mailing_address_flag = ""
                '66
                cXML.race_code = Val(rs1.Tables(0).Rows(0)("RACE_CODE").ToString)
                '67
                If (rs1.Tables(0).Rows(0)("NUMBER_OF_HOUSEHOLD_MEMBERS").ToString) = 0 Then
                    cXML.number_of_household_members = ""

                Else
                    cXML.number_of_household_members = (rs1.Tables(0).Rows(0)("NUMBER_OF_HOUSEHOLD_MEMBERS").ToString)

                End If
                '68
                cXML.card_member_name_nric = ""
                '69
                cXML.card_member_dob = ""
                '70
                cXML.card_member_gender_code = ""
                '71

                If (rs1.Tables(0).Rows(0)("OFFICIAL_ID").ToString) <> "" And (rs1.Tables(0).Rows(0)("IDTYPE").ToString) = "หมายเลขบัตรประชาชน" Then
                    cXML.expat = "0"
                ElseIf (rs1.Tables(0).Rows(0)("OFFICIAL_ID").ToString) <> "" And (rs1.Tables(0).Rows(0)("IDTYPE").ToString) <> "หมายเลขบัตรประชาชน" Then
                    cXML.expat = "1"
                Else

                    If rs1.Tables(0).Rows(0)("NAME_1").ToString = "" Then
                        cXML.expat = "0"
                    Else
                        If Asc(Mid((rs1.Tables(0).Rows(0)("NAME_1").ToString), 1, 1)) < 161 Or Asc(Mid((rs1.Tables(0).Rows(0)("NAME_1").ToString), 1, 1)) > 206 Then
                            cXML.expat = "1"
                        Else
                            cXML.expat = "0"
                        End If
                    End If
                End If
                ''01
                'cXML.name_1 = (rs1.Tables(0).Rows(0)("name_1").ToString)
                ''02
                'cXML.name_2 = (rs1.Tables(0).Rows(0)("name_2").ToString)
                ''03
                '    cXML.official_id =


                'cXML.expat = Val(rs1.Tables(0).Rows(0)("expat1").ToString)
                '72
                cXML.form_type = Val(rs1.Tables(0).Rows(0)("FORM_TYPE").ToString)

            End If
            End If


    End Sub
    Private Sub WriteXML()


        sw9.WriteLine("<customer>")
        'type 1 ส่งทั้งหมด 2 ส่งเฉพาะ 3 field


        If cXML.form_type = 1 Then

            sw9.WriteLine("<name_1>" & cXML.name_1 & "</name_1>")
            sw9.WriteLine("<name_2>" & cXML.name_2 & "</name_2>")
            sw9.WriteLine("<official_id>" & cXML.official_id & "</official_id>")
            sw9.WriteLine("<primary_card_account_number>" & cXML.primary_card_account_number & "</primary_card_account_number>")
            sw9.WriteLine("<card_account_number>" & cXML.card_account_number & "</card_account_number>")
            sw9.WriteLine("<customer_use_status>" & cXML.customer_use_status & "</customer_use_status>")
            sw9.WriteLine("<customer_mail_status>" & cXML.customer_mail_status & "</customer_mail_status>")
            sw9.WriteLine("<family_member_1_gender_code>" & cXML.family_member_1_gender_code & "</family_member_1_gender_code>")
            sw9.WriteLine("<family_member_1_dob>" & cXML.family_member_1_dob & "</family_member_1_dob>")
            sw9.WriteLine("<family_member_2_gender_code>" & cXML.family_member_2_gender_code & "</family_member_2_gender_code>")
            sw9.WriteLine("<family_member_3_gender_code>" & cXML.family_member_3_gender_code & "</family_member_3_gender_code>")
            sw9.WriteLine("<family_member_4_gender_code>" & cXML.family_member_4_gender_code & "</family_member_4_gender_code>")
            sw9.WriteLine("<family_member_5_gender_code>" & cXML.family_member_5_gender_code & "</family_member_5_gender_code>")
            sw9.WriteLine("<family_member_6_gender_code>" & cXML.family_member_6_gender_code & "</family_member_6_gender_code>")
            sw9.WriteLine("<family_member_2_dob>" & cXML.family_member_2_dob & "</family_member_2_dob>")
            sw9.WriteLine("<family_member_3_dob>" & cXML.family_member_3_dob & "</family_member_3_dob>")
            sw9.WriteLine("<family_member_4_dob>" & cXML.family_member_4_dob & "</family_member_4_dob>")
            sw9.WriteLine("<family_member_5_dob>" & cXML.family_member_5_dob & "</family_member_5_dob>")
            sw9.WriteLine("<family_member_6_dob>" & cXML.family_member_6_dob & "</family_member_6_dob>")
            sw9.WriteLine("<address_line_1>" & cXML.address_line_1 & "</address_line_1>")
            sw9.WriteLine("<address_line_2>" & cXML.address_line_2 & "</address_line_2>")
            sw9.WriteLine("<address_line_3>" & cXML.address_line_3 & "</address_line_3>")
            sw9.WriteLine("<city>" & cXML.city & "</city>")
            sw9.WriteLine("<province_code>" & cXML.province_code & "</province_code>")
            sw9.WriteLine("<country>" & cXML.country & "</country>")
            sw9.WriteLine("<postal_code>" & cXML.postal_code & "</postal_code>")
            sw9.WriteLine("<daytime_phone_number>" & cXML.daytime_phone_number & "</daytime_phone_number>")
            sw9.WriteLine("<evening_phone_number>" & cXML.evening_phone_number & "</evening_phone_number>")
            sw9.WriteLine("<mobile_phone_number>" & cXML.mobile_phone_number & "</mobile_phone_number>")
            sw9.WriteLine("<fax_number>" & cXML.fax_number & "</fax_number>")
            sw9.WriteLine("<email_address>" & cXML.email_address & "</email_address>")
            sw9.WriteLine("<business_name>" & cXML.business_name & "</business_name>")
            sw9.WriteLine(" <business_registration_number>" & cXML.business_registration_number & "</business_registration_number>")
            sw9.WriteLine(" <business_type_code>" & cXML.business_type_code & "</business_type_code>")
            sw9.WriteLine("<business_address_line_1>" & cXML.business_address_line_1 & "</business_address_line_1>")
            sw9.WriteLine("<business_address_line_2>" & cXML.business_address_line_2 & "</business_address_line_2>")
            sw9.WriteLine("<business_address_line_3>" & cXML.business_address_line_3 & "</business_address_line_3>")
            sw9.WriteLine("<business_address_line_4>" & cXML.business_address_line_4 & "</business_address_line_4>")
            sw9.WriteLine("<business_address_line_5>" & cXML.business_address_line_5 & "</business_address_line_5>")
            sw9.WriteLine("<business_address_line_6>" & cXML.business_address_line_6 & "</business_address_line_6>")
            sw9.WriteLine("<business_postal_code>" & cXML.business_postal_code & "</business_postal_code>")
            sw9.WriteLine("<preferred_store_code>" & cXML.preferred_store_code & "</preferred_store_code>")
            sw9.WriteLine("<joined_store_code>" & cXML.joined_store_code & "</joined_store_code>")
            sw9.WriteLine("<preferred_contact_type_code>" & cXML.preferred_contact_type_code & "</preferred_contact_type_code>")
            sw9.WriteLine("<title_code>" & cXML.title_code & "</title_code>")
            sw9.WriteLine("<tescogroup_mail_flag>" & cXML.tescogroup_mail_flag & "</tescogroup_mail_flag>")
            sw9.WriteLine("<tescogroup_email_flag>" & cXML.tescogroup_email_flag & "</tescogroup_email_flag>")
            sw9.WriteLine("<tescogroup_phone_flag>" & cXML.tescogroup_phone_flag & "</tescogroup_phone_flag>")
            sw9.WriteLine("<tescogroup_sms_flag>" & cXML.tescogroup_sms_flag & "</tescogroup_sms_flag>")
            sw9.WriteLine("<partner_mail_flag>" & cXML.partner_mail_flag & "</partner_mail_flag>")
            sw9.WriteLine("<partner_email_flag>" & cXML.partner_email_flag & "</partner_email_flag>")
            sw9.WriteLine("<partner_phone_flag>" & cXML.partner_phone_flag & "</partner_phone_flag>")
            sw9.WriteLine("<partner_sms_flag>" & cXML.partner_sms_flag & "</partner_sms_flag>")
            sw9.WriteLine("<research_mail_flag>" & cXML.research_mail_flag & "</research_mail_flag>")
            sw9.WriteLine("<research_email_flag>" & cXML.research_email_flag & "</research_email_flag>")
            sw9.WriteLine("<research_phone_flag>" & cXML.research_phone_flag & "</research_phone_flag>")
            sw9.WriteLine("<research_sms_flag>" & cXML.research_sms_flag & "</research_sms_flag>")
            sw9.WriteLine("<diabetic_flag>" & cXML.diabetic_flag & "</diabetic_flag>")
            sw9.WriteLine("<vegetarian_flag>" & cXML.vegetarian_flag & "</vegetarian_flag>")
            sw9.WriteLine("<teetotal_flag>" & cXML.teetotal_flag & "</teetotal_flag>")
            sw9.WriteLine("<halal_flag>" & cXML.halal_flag & "</halal_flag>")
            sw9.WriteLine("<lactose_flag>" & cXML.lactose_flag & "</lactose_flag>")
            sw9.WriteLine("<celiac_flag>" & cXML.celiac_flag & "</celiac_flag>")
            sw9.WriteLine("<customer_created_date>" & cXML.customer_created_date & "</customer_created_date>")
            sw9.WriteLine("<preferred_mailing_address_flag>" & cXML.preferred_mailing_address_flag & "</preferred_mailing_address_flag>")
            sw9.WriteLine("<race_code>" & cXML.race_code & "</race_code>")
            sw9.WriteLine("<number_of_household_members>" & cXML.number_of_household_members & "</number_of_household_members>")
            sw9.WriteLine("<card_member_name_nric>" & cXML.card_member_name_nric & "</card_member_name_nric>")
            sw9.WriteLine("<card_member_dob>" & cXML.card_member_dob & "</card_member_dob>")
            sw9.WriteLine("<card_member_gender_code>" & cXML.card_member_gender_code & "</card_member_gender_code>")
            sw9.WriteLine("<expat>" & cXML.expat & "</expat>")
            sw9.WriteLine("<form_type>" & cXML.form_type & "</form_type>")



        ElseIf cXML.form_type = 2 Then
            sw9.WriteLine("<card_account_number>" & cXML.card_account_number & "</card_account_number>")
            sw9.WriteLine("<form_type>" & cXML.form_type & "</form_type>")
            sw9.WriteLine("<primary_card_account_number>" & cXML.primary_card_account_number & "</primary_card_account_number>")

        End If
        sw9.WriteLine("</customer>")
    End Sub

    Private Sub ClearXML()
        '01
        cXML.name_1 = ""
        '02
        cXML.name_2 = ""
        '03
        cXML.official_id = ""
        '04  
        cXML.primary_card_account_number = ""
        '05
        cXML.card_account_number = ""
        '06
        cXML.customer_use_status = ""
        '07
        cXML.customer_mail_status = ""
        '08
        cXML.family_member_1_gender_code = ""
        '09
        cXML.family_member_1_dob = ""
        '10
        cXML.family_member_2_gender_code = ""
        '11
        cXML.family_member_3_gender_code = ""
        '12
        cXML.family_member_4_gender_code = ""
        '13
        cXML.family_member_5_gender_code = ""
        '14
        cXML.family_member_6_gender_code = ""
        '15
        cXML.family_member_2_dob = ""
        '16
        cXML.family_member_3_dob = ""
        '17
        cXML.family_member_4_dob = ""
        '18
        cXML.family_member_5_dob = ""
        '19
        cXML.family_member_6_dob = ""
        '20
        cXML.address_line_1 = ""
        '21
        cXML.address_line_2 = ""
        '22
        cXML.address_line_3 = ""
        '23
        cXML.city = ""
        '24
        cXML.province_code = ""
        '25
        cXML.country = ""
        '26
        cXML.postal_code = ""
        '27
        cXML.daytime_phone_number = ""
        '28
        cXML.evening_phone_number = ""
        '29
        cXML.mobile_phone_number = ""
        '30
        cXML.fax_number = ""
        '31
        cXML.email_address = ""
        '32
        cXML.business_name = ""
        '33
        cXML.business_registration_number = ""
        '34
        cXML.business_type_code = ""
        '35
        cXML.business_address_line_1 = ""
        '36
        cXML.business_address_line_2 = ""
        '37
        cXML.business_address_line_3 = ""
        '38
        cXML.business_address_line_4 = ""
        '39
        cXML.business_address_line_5 = ""
        '40
        cXML.business_address_line_6 = ""
        '41
        cXML.business_postal_code = ""
        '42
        cXML.preferred_store_code = ""
        '43
        cXML.joined_store_code = ""
        '44
        cXML.preferred_contact_type_code = ""
        '45
        cXML.title_code = ""
        '46
        cXML.tescogroup_mail_flag = ""
        '47
        cXML.tescogroup_email_flag = ""
        '48
        cXML.tescogroup_phone_flag = ""
        '49
        cXML.tescogroup_sms_flag = ""
        '50
        cXML.partner_mail_flag = ""
        '51
        cXML.partner_email_flag = ""
        '52
        cXML.partner_phone_flag = ""
        '53
        cXML.partner_sms_flag = ""
        '54
        cXML.research_mail_flag = ""
        '55
        cXML.research_email_flag = ""
        '56
        cXML.research_phone_flag = ""
        '57
        cXML.research_sms_flag = ""
        '58
        cXML.diabetic_flag = ""
        '59
        cXML.vegetarian_flag = ""
        '60
        cXML.teetotal_flag = ""
        '61
        cXML.halal_flag = ""
        '62
        cXML.lactose_flag = ""
        '63
        cXML.celiac_flag = ""
        '64
        cXML.customer_created_date = ""
        '65
        cXML.preferred_mailing_address_flag = ""
        '66
        cXML.race_code = ""
        '67
        cXML.number_of_household_members = ""
        '68
        cXML.card_member_name_nric = ""
        '69
        cXML.card_member_dob = ""
        '70
        cXML.card_member_gender_code = ""
        '71
        cXML.expat = ""
        '72
        cXML.form_type = ""

    End Sub

    Private Sub CmdCheckIMG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCheckIMG.Click

        Dim i As Integer
        Dim IMGSource As String
        Dim IMGtarget As String
        'Select Case XMLType
        '    Case "SIGNED"

        '    Case "UNSIGNED"

        'End Select


        'check signed img
        IMGSource = Txtsourcesign.Text

        LstSignIMGOK.Items.Clear()
        Txtimgerror.Text = "0"
        For i = 0 To ListsignedIMG.Items.Count - 1
            IMGtarget = IMGSource & Mid(ListsignedIMG.Items(i).ToString, 1, 18) & ".pdf"

            If Dir(IMGtarget, FileAttribute.Archive) = "" Then
                LstSignIMGOK.Items.Add(ListsignedIMG.Items(i).ToString)
                Txtimgerror.Text = LstSignIMGOK.Items.Count
            End If

        Next i



        'check unsigned img

        IMGSource = TxtsourceUnsign.Text & "unsigned-"

        LstUnsignIMGOK.Items.Clear()
        Txtimgerror.Text = "0"
        For i = 0 To ListUnsignedIMG.Items.Count - 1
            IMGtarget = IMGSource & Mid(ListUnsignedIMG.Items(i).ToString, 1, 18) & ".pdf"

            If Dir(IMGtarget, FileAttribute.Archive) = "" Then
                LstUnsignIMGOK.Items.Add(ListUnsignedIMG.Items(i).ToString)
                Txtimgerror.Text = LstUnsignIMGOK.Items.Count
            End If

        Next i


        MsgBox("Completed")
        Txtimgerror.Text = LstSignIMGOK.Items.Count


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdIMGcheckERROR.Click
        Dim cdl As New SaveFileDialog

        cdl.DefaultExt = "txt"
        cdl.Title = "Save Text File"
        cdl.Filter = "Text File|*.txt"
        cdl.InitialDirectory = Application.StartupPath
        cdl.OverwritePrompt = True

        If cdl.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim s As New StreamWriter(cdl.FileName)
            Dim x As Integer
            Dim z As String
            Dim cr_lf As String = Chr(13) + Chr(10)

            For x = 0 To LstSignIMGOK.Items.Count - 1

                s.WriteLine("'" & Trim(LstSignIMGOK.Items(x).ToString) & "',")

                'z = z & Trim(ListsignedIMGError.Items(x).ToString) & +cr_lf
            Next x

            s.Close()
            MsgBox("Save Completed")
        End If
    End Sub

    Private Sub copyIMG()



        Dim fileCnt As Integer
        Dim totalloop As Integer
        Dim i As Integer
        Dim loopcount As Integer
        Dim target, target1 As String
        Dim folderSSS As String
        Dim Ddate As String

        If LstSignIMG.Items.Count = 0 Then Exit Sub

        fileCnt = TxtFilecnt.Text

        loopcount = LstSignIMG.Items.Count / fileCnt
        If loopcount = 0 Then loopcount = 1
        'Dim TotalLoop As Integer
        Dim difftotal As Integer
        difftotal = (loopcount * fileCnt) - LstSignIMG.Items.Count



        If Trim(TxtFilecnt.Text) = "" Then
            MsgBox("ยังไม่ได้กำหนดจำนวนไฟล์ต่อ 1 Folder")
            Exit Sub
        End If


        If Len(Trim(loopcount)) > 3 Then
            MsgBox("กำหนดจำนวนไฟล์ต่อ folder น้อยเกินไป กรุณากำหนดใหม่")
            Exit Sub
        End If

        Ddate = Replace(ChangeThaiDateToEngDate(txtDate.Text), "-", "")


        For totalloop = 1 To loopcount
            folderSSS = ""

            Select Case Len(Trim(totalloop))

                Case 1
                    folderSSS = "00" & Trim(totalloop)
                Case 2
                    folderSSS = "0" & Trim(totalloop)
                Case 3
                    folderSSS = Trim(totalloop)
            End Select

            target = TxtTarget.Text & "IMG_" & Ddate & "_" & folderSSS
            target1 = "IMG_" & Ddate & "_" & folderSSS
            If Dir(target, FileAttribute.Directory) = "" Then
                MkDir(target)
            Else
                If MsgBox("มี folder ชื่อว่า " & target & "อยู่แล้วต้องการ copy ทับใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RmDir(target)
                    MkDir(target)
                    GoTo nextloop
                End If
            End If


            If totalloop = loopcount Then
                fileCnt = fileCnt - difftotal
            Else
                fileCnt = fileCnt
            End If

            Listsigned_OK.Items.Clear()

            For i = 1 To fileCnt

                ' out debug.print((Txtsourcesign.Text & LstSignIMG.Items(0) & ".pdf"))

                ' out debug.print(Dir(Txtsourcesign.Text & LstSignIMG.Items(0) & ".pdf"))

                If Dir(Txtsourcesign.Text & Mid(LstSignIMG.Items(0), 1, 18) & ".pdf") <> "" Then
                    ' out debug.print(target & "\")


                    FileCopy(Txtsourcesign.Text & Mid(LstSignIMG.Items(0), 1, 18) & ".pdf", target & "\" & Mid(LstSignIMG.Items(0), 1, 18) & ".pdf")
                    Listsigned_OK.Items.Add(LstSignIMG.Items(0))
                    LstSignIMG.Items.RemoveAt(0)
                Else
                    Listsignederror.Items.Add(LstSignIMG.Items(0))
                    LstSignIMG.Items.RemoveAt(0)
                End If


            Next i

            'add file to zip

            Dim OKFILE As String
            Dim zipMD5Hash, gpgMD5Hash As String
            Dim zipFSize, gpgFSize As String

            Dim appendMode1 As Boolean = False ' This overwrites the entire file.
            Dim sw1 As StreamWriter
            'เขียน Header file

            OKFILE = target & ".OK"
            sw1 = New StreamWriter(OKFILE, appendMode1, System.Text.Encoding.UTF8)
            'FileOpen(1, OKFILE, OpenMode.Output)


            Call addfoldertoZIP(target)

            Sleep(8000)

            ' write text file


            zipMD5Hash = ""
            zipFSize = ""


            zipMD5Hash = getMD5Hash(target & ".zip")
recal1:


            If Val(Getfilesize(target & ".zip")) = 0 Then
                GoTo recal1
            Else
                zipFSize = Getfilesize(target & ".zip")
                GoTo nextloop1
            End If

nextloop1:




            Call EncryptGPG(target & ".zip")

            Sleep(8000)

            gpgMD5Hash = ""
            gpgFSize = ""


            gpgMD5Hash = getMD5Hash(target & ".zip.gpg")
recal2:
            If Val(Getfilesize(target & ".zip.gpg")) = 0 Then
                GoTo recal2
            Else
                gpgFSize = Getfilesize(target & ".zip.gpg")
                GoTo nextloop2
            End If
nextloop2:
            Dim tmpprtln As String
            Dim prtln As String
            Dim z As Integer
            Dim numberoffiles As Integer
            numberoffiles = System.IO.Directory.GetFiles(target).Length
            'เขียน Header file
            sw1.writeline("--                              Image Export Summary                              --")
            sw1.writeline("--                                                                                --")
            sw1.WriteLine("--     Export date  : " & ChangeThaiDateToEngDate(txtDate.Text) & "                                                  --")
            sw1.writeline("--     Records  : " & numberoffiles & "                                                              --")
            sw1.writeline("--                                                                                --")
            sw1.writeline("")
            sw1.writeline("File name                     MD5SUM                                            Size")
            sw1.writeline("----------------------        --------------------------------           -----------")
            'write  to XML.OK
            sw8.WriteLine(target1 & "            " & numberoffiles)



            prtln = ""

            If Len(target1 & ".zip.gpg") < 31 Then
                For z = Len(target1 & ".zip.gpg") + 1 To 31 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = target1 & ".zip.gpg" & prtln & gpgMD5Hash

            prtln = ""

            If Len(tmpprtln) < 74 Then
                For z = Len(tmpprtln) + 1 To 74 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = tmpprtln & prtln & gpgFSize
            sw1.writeline(tmpprtln)

            'sw1.writeline( target1 & ".zip.gpg" & "             " & gpgMD5Hash & "        " & gpgFSize)

            'sw1.writeline( target1 & ".zip" & "             " & zipMD5Hash & "        " & zipFSize)


            prtln = ""

            If Len(target1 & ".zip") < 31 Then
                For z = Len(target1 & ".zip") + 1 To 31 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = target1 & ".zip" & prtln & zipMD5Hash

            prtln = ""

            If Len(tmpprtln) < 74 Then
                For z = Len(tmpprtln) + 1 To 74 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = tmpprtln & prtln & zipFSize
            sw1.writeline(tmpprtln)
            sw1.writeline("Image files list")
            sw1.writeline("------------------------------------------------------------------------------------")


            Dim x, y As Integer
            Dim PrtStr As String
            Dim lastline As Integer
            Dim firstloop As Integer

            y = 1
            PrtStr = ""

            lastline = Listsigned_OK.Items.Count Mod 4
            firstloop = (Listsigned_OK.Items.Count - lastline)


            For x = 0 To firstloop - 1
                If PrtStr = "" Then
                    PrtStr = Listsigned_OK.Items(x).ToString
                Else
                    PrtStr = PrtStr & "   " & Listsigned_OK.Items(x).ToString
                End If

                If y = 4 Then
                    sw1.writeline(PrtStr)
                    PrtStr = ""
                    y = 0
                End If
                y = y + 1
            Next x
            ' out debug.print(x)
            Dim s As Integer
            s = x + 1
            If lastline <> 0 Then
                For x = s To x + lastline
                    If PrtStr = "" Then
                        PrtStr = Listsigned_OK.Items(x - 1).ToString
                    Else
                        PrtStr = PrtStr & "   " & Listsigned_OK.Items(x - 1).ToString
                    End If

                Next x
                sw1.writeline(PrtStr)
            End If


            'For x = 0 To Listsigned_OK.Items.Count - 1
            '    If PrtStr = "" Then
            '        PrtStr = Listsigned_OK.Items(x).ToString
            '    Else
            '        PrtStr = PrtStr & "   " & Listsigned_OK.Items(x).ToString
            '    End If
            '    If y = 4 Then
            '        sw1.writeline( PrtStr)
            '        PrtStr = ""
            '        y = 0
            '    End If
            '    y = y + 1
            'Next x



            sw1.Close()
            Listsigned_OK.Items.Clear()
nextloop: Next totalloop
    End Sub

    Private Sub copyunsignedIMG()



        Dim fileCnt As Integer
        Dim totalloop As Integer
        Dim i As Integer
        Dim loopcount As Integer
        Dim target, target1 As String
        Dim folderSSS As String
        Dim Ddate As String
        If LstUNsignIMG.Items.Count = 0 Then Exit Sub



        fileCnt = TxtFilecnt.Text

        loopcount = LstUNsignIMG.Items.Count / fileCnt
        If loopcount = 0 Then loopcount = 1
        'Dim TotalLoop As Integer
        Dim difftotal As Integer
        difftotal = (loopcount * fileCnt) - LstUNsignIMG.Items.Count



        If Trim(TxtFilecnt.Text) = "" Then
            MsgBox("ยังไม่ได้กำหนดจำนวนไฟล์ต่อ 1 Folder")
            Exit Sub
        End If


        If Len(Trim(loopcount)) > 3 Then
            MsgBox("กำหนดจำนวนไฟล์ต่อ folder น้อยเกินไป กรุณากำหนดใหม่")
            Exit Sub
        End If

        Ddate = Replace(ChangeThaiDateToEngDate(txtDate.Text), "-", "")


        For totalloop = 1 To loopcount
            folderSSS = ""

            Select Case Len(Trim(totalloop))

                Case 1
                    folderSSS = "00" & Trim(totalloop)
                Case 2
                    folderSSS = "0" & Trim(totalloop)
                Case 3
                    folderSSS = Trim(totalloop)
            End Select

            target = TxtTarget.Text & "UNSIGNED-" & "IMG_" & Ddate & "_" & folderSSS
            target1 = "UNSIGNED-" & "IMG_" & Ddate & "_" & folderSSS
            If Dir(target, FileAttribute.Directory) = "" Then
                MkDir(target)
            Else
                If MsgBox("มี folder ชื่อว่า " & target & "อยู่แล้วต้องการ copy ทับใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RmDir(target)
                    MkDir(target)
                    GoTo nextloop
                End If
            End If


            If totalloop = loopcount Then
                fileCnt = fileCnt - difftotal
            Else
                fileCnt = fileCnt
            End If

            Listunsigned_OK.Items.Clear()
            Listunsignederror.Items.Clear()

            For i = 1 To fileCnt

                ' out debug.print((TxtsourceUnsign.Text & "unsigned-" & LstUNsignIMG.Items(0) & ".pdf"))

                ' out debug.print(Dir(TxtsourceUnsign.Text & "unsigned-" & LstUNsignIMG.Items(0) & ".pdf"))

                If Dir(TxtsourceUnsign.Text & "unsigned-" & Mid(LstUNsignIMG.Items(0), 1, 18) & ".pdf") <> "" Then
                    ' out debug.print(target & "\")
                    FileCopy(TxtsourceUnsign.Text & "unsigned-" & Mid(LstUNsignIMG.Items(0), 1, 18) & ".pdf", target & "\" & Mid(LstUNsignIMG.Items(0), 1, 18) & ".pdf")

                    'Unsign ส่งไฟล์ไม่มี prefix เหมือน Sign
                    'FileCopy(TxtsourceUnsign.Text & "unsigned-" & LstUNsignIMG.Items(0) & ".pdf", target & "\" & "unsigned-" & LstUNsignIMG.Items(0) & ".pdf")
                    Listunsigned_OK.Items.Add(LstUNsignIMG.Items(0))
                    LstUNsignIMG.Items.RemoveAt(0)
                Else
                    Listunsignederror.Items.Add(LstUNsignIMG.Items(0))
                    LstUNsignIMG.Items.RemoveAt(0)
                End If


            Next i

            'add file to zip

            Dim OKFILE As String
            Dim zipMD5Hash, gpgMD5Hash As String
            Dim zipFSize, gpgFSize As String
            Dim appendMode1 As Boolean = False ' This overwrites the entire file.
            Dim sw1 As StreamWriter
            'เขียน Header file

            OKFILE = target & ".OK"
            sw1 = New StreamWriter(OKFILE, appendMode1, System.Text.Encoding.UTF8)
            'FileOpen(1, OKFILE, OpenMode.Output)


            Call addfoldertoZIP(target)

            Sleep(8000)

            ' write text file


            zipMD5Hash = ""
            zipFSize = ""


            zipMD5Hash = getMD5Hash(target & ".zip")
recal1:


            If Val(Getfilesize(target & ".zip")) = 0 Then
                GoTo recal1
            Else
                zipFSize = Getfilesize(target & ".zip")
                GoTo nextloop1
            End If

nextloop1:




            Call EncryptGPG(target & ".zip")

            Sleep(8000)

            gpgMD5Hash = ""
            gpgFSize = ""


            gpgMD5Hash = getMD5Hash(target & ".zip.gpg")
recal2:
            If Val(Getfilesize(target & ".zip.gpg")) = 0 Then
                GoTo recal2
            Else
                gpgFSize = Getfilesize(target & ".zip.gpg")
                GoTo nextloop2
            End If
nextloop2:
            Dim tmpprtln As String
            Dim prtln As String
            Dim z As Integer
            Dim numberoffiles As Integer
            numberoffiles = System.IO.Directory.GetFiles(target).Length
            'เขียน Header file
            sw1.writeline("--                                   Image Export Summary                              --")
            sw1.writeline("--                                                                                --")
            sw1.writeline("--          Export date  : " & Ddate & "                                                  --")
            sw1.writeline("--          Records  : " & numberoffiles & "                                                              --")
            sw1.writeline("--                                                                                --")
            sw1.writeline("")
            sw1.writeline("File name                          MD5SUM                                            Size")
            sw1.writeline("----------------------             --------------------------------           -----------")
            'write  to XML.OK
            sw8.WriteLine(target1 & "            " & numberoffiles)



            prtln = ""

            If Len(target1 & ".zip.gpg") < 36 Then
                For z = Len(target1 & ".zip.gpg") + 1 To 36 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = target1 & ".zip.gpg" & prtln & gpgMD5Hash

            prtln = ""

            If Len(tmpprtln) < 80 Then
                For z = Len(tmpprtln) + 1 To 80 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = tmpprtln & prtln & gpgFSize
            sw1.writeline(tmpprtln)

            'sw1.writeline( target1 & ".zip.gpg" & "             " & gpgMD5Hash & "        " & gpgFSize)

            'sw1.writeline( target1 & ".zip" & "             " & zipMD5Hash & "        " & zipFSize)


            prtln = ""

            If Len(target1 & ".zip") < 36 Then
                For z = Len(target1 & ".zip") + 1 To 36 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = target1 & ".zip" & prtln & zipMD5Hash

            prtln = ""

            If Len(tmpprtln) < 80 Then
                For z = Len(tmpprtln) + 1 To 80 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = tmpprtln & prtln & zipFSize
            sw1.writeline(tmpprtln)
            sw1.writeline("Image files list")
            sw1.writeline("------------------------------------------------------------------------------------")


            Dim x, y As Integer
            Dim PrtStr As String
            Dim lastline As Integer
            Dim firstloop As Integer

            y = 1
            PrtStr = ""

            lastline = Listunsigned_OK.Items.Count Mod 4
            firstloop = (Listunsigned_OK.Items.Count - lastline)


            For x = 0 To firstloop - 1
                If PrtStr = "" Then
                    PrtStr = Listunsigned_OK.Items(x).ToString
                Else
                    PrtStr = PrtStr & "   " & Listunsigned_OK.Items(x).ToString
                End If

                If y = 4 Then
                    sw1.writeline(PrtStr)
                    PrtStr = ""
                    y = 0
                End If
                y = y + 1
            Next x
            ' out debug.print(x)
            Dim s As Integer
            s = x + 1
            If lastline <> 0 Then
                For x = s To x + lastline
                    If PrtStr = "" Then
                        PrtStr = Listunsigned_OK.Items(x - 1).ToString
                    Else
                        PrtStr = PrtStr & "   " & Listunsigned_OK.Items(x - 1).ToString
                    End If

                Next x
                sw1.WriteLine(PrtStr)
            End If


            'For x = 0 To Listunsigned_OK.Items.Count - 1
            '    If PrtStr = "" Then
            '        PrtStr = Listunsigned_OK.Items(x).ToString
            '    Else
            '        PrtStr = PrtStr & "   " & Listunsigned_OK.Items(x).ToString
            '    End If
            '    If y = 4 Then
            '        sw1.writeline( PrtStr)
            '        PrtStr = ""
            '        y = 0
            '    End If
            '    y = y + 1
            'Next x



            sw1.Close()
            Listunsigned_OK.Items.Clear()
nextloop: Next totalloop
    End Sub

    Private Sub CmdUnsigmimgerror_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUnsigmimgerror.Click
        Dim cdl As New SaveFileDialog

        cdl.DefaultExt = "txt"
        cdl.Title = "Save Text File"
        cdl.Filter = "Text File|*.txt"
        cdl.InitialDirectory = Application.StartupPath
        cdl.OverwritePrompt = True

        If cdl.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim s As New StreamWriter(cdl.FileName)
            Dim x As Integer
            Dim z As String
            Dim cr_lf As String = Chr(13) + Chr(10)

            For x = 0 To LstUnsignIMGOK.Items.Count - 1
                z = z & LstUnsignIMGOK.Items(x).ToString + cr_lf
            Next x

            s.Write(z)
            s.Close()
            MsgBox("Save Completed")
        End If
    End Sub

    Private Sub CmdBrowsetarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBrowsetarget.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        ' Description that displays above the dialog box control. 

        MyFolderBrowser.Description = "Select the Folder"
        ' Sets the root folder where the browsing starts from 
        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            TxtTarget.Text = MyFolderBrowser.SelectedPath & "\"
        End If
    End Sub

    Private Sub ListXML_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListXML.SelectedIndexChanged, LstChkDigitError.SelectedIndexChanged, ListXMLtoGen.SelectedIndexChanged

    End Sub

    Private Sub CmdChkdigit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdChkdigit1.Click
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



        For lp = 0 To ListXML.Items.Count - 1

            'check clubcard
            CHKPASS = False

            'Dim inp As String
            'inp = InputBox("cc no", "", "")
            'If inp = "" Then Exit Sub
            '''' out debug.print("Input =" & inp)
            'Step1 - แยก Digit
            ''' out debug.print("inp = " & ListXML.Items(lp).ToString)
            ''' out debug.print("Split")
            For i = 1 To 18
                Ddigit(i) = Mid(ListXML.Items(lp).ToString, i, 1)

                '' out debug.print(i & "= " & Ddigit(i))
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

            '' out debug.print("MULTI")
            For i = 1 To 18
                '' out debug.print(MultiplyST(i))
            Next i



            'Step 3 Trunc หารปัดเศษทิ้งเสมอ
            '' out debug.print("Result1")
            For t = 1 To 18
                Result1(t) = MultiplyST(t) \ 10
                '' out debug.print(Result1(t))
            Next t



            'Step 4 
            '' out debug.print("Result2")
            For t = 1 To 18
                Result2(t) = ((MultiplyST(t) / 10) - Result1(t)) * 10
                '' out debug.print(Result2(t))
            Next t



            'Step 5 result 1 + result 2

            '' out debug.print("Result3")
            For t = 1 To 18
                Result3(t) = Result1(t) + Result2(t)
                '' out debug.print(Result3(t))
            Next t



            'Step 6 sum Result 3  
            '' out debug.print("TotalResult3")
            TotalResult3 = 0
            For t = 1 To 18
                TotalResult3 = TotalResult3 + Result3(t)
            Next t
            '' out debug.print(TotalResult3)

            ChkDigit = 10 - (((TotalResult3) / 10) - (TotalResult3 \ 10)) * 10

            If ChkDigit = 10 Then ChkDigit = 0
            '' out debug.print(Ddigit(18))
            '' out debug.print(ChkDigit)
            If Ddigit(18) = ChkDigit Then
                CHKPASS = True
            Else
                CHKPASS = False
                LstChkDigitError.Items.Add(ListXML.Items(lp).ToString)
                'ListXML1.Items.Add(ListXML.Items(lp).ToString)
                'lp = lp + 1
                '' out debug.print(ListXML.Items.Count - 1)
                GoTo nextlp
            End If

            '''''''''''' check primary card
            If Mid(ListXML.Items(lp).ToString, 1, 18) = Mid(ListXML.Items(lp).ToString, 20, 18) Then
                ListXMLtoGen.Items.Add(ListXML.Items(lp).ToString)
                If Mid(ListXML.Items(lp).ToString, 39, 1) = "S" Then
                    ListsignedIMG.Items.Add(Trim(Mid(ListXML.Items(lp).ToString, 1, 18)))
                Else
                    ListUnsignedIMG.Items.Add(Trim(Mid(ListXML.Items(lp).ToString, 1, 18)))
                End If
                GoTo nextlp
            End If




            ''check clubcard
            'CHKPASS = False

            'Dim inp As String
            'inp = InputBox("cc no", "", "")
            'If inp = "" Then Exit Sub
            ''' out debug.print("Input =" & inp)
            'Step1 - แยก Digit
            '' out debug.print("Split")
            For i = 1 To 18
                Ddigit(i) = Mid(ListXML.Items(lp).ToString, i + 19, 1)

                '' out debug.print(Ddigit(i))
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

            '' out debug.print("MULTI")
            For i = 1 To 18
                '' out debug.print(MultiplyST(i))
            Next i



            'Step 3 Trunc หารปัดเศษทิ้งเสมอ
            '' out debug.print("Result1")
            For t = 1 To 18
                Result1(t) = MultiplyST(t) \ 10
                '' out debug.print(Result1(t))
            Next t



            'Step 4 
            '' out debug.print("Result2")
            For t = 1 To 18
                Result2(t) = ((MultiplyST(t) / 10) - Result1(t)) * 10
                '' out debug.print(Result2(t))
            Next t



            'Step 5 result 1 + result 2

            '' out debug.print("Result3")
            For t = 1 To 18
                Result3(t) = Result1(t) + Result2(t)
                '' out debug.print(Result3(t))
            Next t



            'Step 6 sum Result 3  
            '' out debug.print("TotalResult3")
            TotalResult3 = 0
            For t = 1 To 18
                TotalResult3 = TotalResult3 + Result3(t)
            Next t
            '' out debug.print(TotalResult3)


            ChkDigit = 10 - ((TotalResult3 / 10) - (TotalResult3 \ 10)) * 10
            If ChkDigit = 10 Then ChkDigit = 0

            '' out debug.print("digit 18 ")
            '' out debug.print(Ddigit(18))

            '' out debug.print("ChkDigit ")
            '' out debug.print(ChkDigit)
            If Ddigit(18) = ChkDigit Then
                ListXMLtoGen.Items.Add(ListXML.Items(lp).ToString)

                If Mid(ListXML.Items(lp).ToString, 39, 1) = "S" Then
                    ListsignedIMG.Items.Add(Trim(Mid(ListXML.Items(lp).ToString, 1, 18)))
                Else
                    ListUnsignedIMG.Items.Add(Trim(Mid(ListXML.Items(lp).ToString, 1, 18)))
                End If
                CHKPASS = True
            Else
                CHKPASS = False
                LstChkDigitError.Items.Add(ListXML.Items(lp).ToString)

                '' out debug.print(ListXML.Items.Count - 1)
                'ListXML.Items.RemoveAt(lp)
                'lp = lp + 1
                '''' out debug.print(ListXML.Items.Count - 1)
                GoTo nextlp
            End If












nextlp:
            If lp = 127 Then
                ' out debug.print(lp)
            End If
        Next lp

        TxtRecno.Text = ListXMLtoGen.Items.Count


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cdl As New SaveFileDialog

        cdl.DefaultExt = "txt"
        cdl.Title = "Save Text File"
        cdl.Filter = "Text File|*.txt"
        cdl.InitialDirectory = Application.StartupPath
        cdl.OverwritePrompt = True

        If cdl.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim s As New StreamWriter(cdl.FileName)
            Dim x As Integer
            Dim z As String
            Dim cr_lf As String = Chr(13) + Chr(10)

            For x = 0 To LstChkDigitError.Items.Count - 1

                s.WriteLine("'" & Trim(LstChkDigitError.Items(x).ToString) & "',")

                'z = z & Trim(ListsignedIMGError.Items(x).ToString) & +cr_lf
            Next x

            s.Close()
            MsgBox("Save Completed")
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cdl As New SaveFileDialog

        cdl.DefaultExt = "txt"
        cdl.Title = "Save Text File"
        cdl.Filter = "Text File|*.txt"
        cdl.InitialDirectory = Application.StartupPath
        cdl.OverwritePrompt = True

        If cdl.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim s As New StreamWriter(cdl.FileName)
            Dim x As Integer
            Dim z As String
            Dim cr_lf As String = Chr(13) + Chr(10)

            For x = 0 To ListsignedIMG.Items.Count - 1

                s.WriteLine("'" & Trim(ListsignedIMG.Items(x).ToString) & "',")

                'z = z & Trim(ListsignedIMGError.Items(x).ToString) & +cr_lf
            Next x

            s.Close()
            MsgBox("Save Completed")
        End If
    End Sub

    'Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Dim cdl As New SaveFileDialog

    '    cdl.DefaultExt = "txt"
    '    cdl.Title = "Save Text File"
    '    cdl.Filter = "Text File|*.txt"
    '    cdl.InitialDirectory = Application.StartupPath
    '    cdl.OverwritePrompt = True

    '    If cdl.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        Dim s As New StreamWriter(cdl.FileName)
    '        Dim x As Integer
    '        Dim z As String
    '        Dim cr_lf As String = Chr(13) + Chr(10)

    '        For x = 0 To ListUnsignedIMG.Items.Count - 1

    '            s.WriteLine("'" & Trim(ListUnsignedIMG.Items(x).ToString) & "',")

    '            'z = z & Trim(ListsignedIMGError.Items(x).ToString) & +cr_lf
    '        Next x

    '        s.Close()
    '        MsgBox("Save Completed")
    '    End If
    'End Sub

    Private Sub cmdCarlendar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCarlendar2.Click
        On Error GoTo error_Handler
        Dim d As String

        d = CALDateGet("") ' d format dd/mm/yyyy+543

        If d <> "" Then
            TxtQCDate.Text = d
        Else
            TxtQCDate.Text = ""
        End If

resume_err:
        Exit Sub

error_Handler:
        Call ShowError(Me.Name & "_" & "cmdCarlendar2_Click", Err.Number, ErrorToString())
        GoTo resume_err
    End Sub

    Private Sub CmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUpdate.Click
        Dim sql As String
        Dim i As Integer

        If MsgBox("ต้องการ Update to Submit จำนวน " & TxtRecno.Text & " รายการใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub




        'sign
        Dim cCUSTID As String
        For i = 0 To ListXML.Items.Count - 1
            cCUSTID = Trim(Mid(ListXML.Items(i).ToString, InStr(ListXML.Items(i).ToString, "|") + 1, 100))

            sql = "UPDATE    TBL_MEMBER_CLUBCARD " & _
                    " SET  SUBMIT_DATE = '" & ChangeThaiDateToEngDate(txtDate.Text) & "'  , " & _
                    " SUBMIT_FLAG ='SUBMIT', SUBMIT_EMPLOYEEID = '" & cOfficer.Login & "' " & _
                    " WHERE CUSTID =  " & cCUSTID & " "
            cConnect.Execute(sql)

        Next i



        'sign  img

        For i = 0 To LstSignIMG.Items.Count - 1
            cCUSTID = Trim(Mid(LstSignIMG.Items(i).ToString, InStr(LstSignIMG.Items(i).ToString, "|") + 1, 100))

            sql = "UPDATE    TBL_MEMBER_CLUBCARD " & _
                    " SET  IMG_DATE = '" & ChangeThaiDateToEngDate(txtDate.Text) & "'  ,   IMG_FLAG ='IMGOK'  " & _
                    " WHERE CUSTID =  " & cCUSTID & " "
            cConnect.Execute(sql)

        Next i


        'unsign  img

        For i = 0 To LstUNsignIMG.Items.Count - 1
            cCUSTID = Trim(Mid(LstUNsignIMG.Items(i).ToString, InStr(LstUNsignIMG.Items(i).ToString, "|") + 1, 100))

            sql = "UPDATE    TBL_MEMBER_CLUBCARD " & _
                    " SET   IMG_DATE = '" & ChangeThaiDateToEngDate(txtDate.Text) & "'  , IMG_FLAG ='IMGOK'  " & _
                    " WHERE CUSTID =  " & cCUSTID & " "
            cConnect.Execute(sql)

        Next i

        MsgBox("Update Completed")
        CmdSubmit.Enabled = True

    End Sub
End Class
