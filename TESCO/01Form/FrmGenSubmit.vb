Imports MySql.Data.MySqlClient

Imports Ionic.Zip

Imports System.io

Public Class FrmGenSubmit
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    Dim processing As Boolean
    Dim fileprocess As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cConnect = New clsConnectNet
        cGpg = New ClsGPG


        cConnect.Connect(DNS)
        Call CalGetSystemDate() ' ดึงค่าวันปัจจุบันใส่ปฏิทิน


    End Sub

    Private Sub Cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdexit.Click
        cConnect.DisConnect()
        Me.Close()
        FrmMain.Show()
        FrmMain.Mnuenable()

    End Sub




    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click




        Dim i As Boolean
        Dim rs1 As Data.DataSet
        Dim sql, DDATE As String
        'Dim TempLoop As Short
        Dim x As Integer

        If Optsigned.Checked = False And Optunsigned.Checked = False Then
            MsgBox("ยังไม่ได้เลือกประเภท Application", MsgBoxStyle.OkOnly, "")
            Exit Sub
        End If

        If Optsigned.Checked = True Then
            sql = " SELECT Clubcard_No  FROM tlc_member_clubcard " & _
                    "  WHERE customer_use_status =0 and Flag = 'QC' " & _
                    " order by Clubcard_No "
        ElseIf Optunsigned.Checked = True Then
            sql = " SELECT Clubcard_No  FROM tlc_member_clubcard " & _
                              "  WHERE customer_use_status =6 and Flag = 'QC' " & _
                              " order by Clubcard_No "
        End If
        Listsigned.Items.Clear()
        rs1 = New Data.DataSet

        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    Listsigned.Items.Add(Trim(rs1.Tables(0).Rows(x)("Clubcard_No").ToString))
                Next x
            End If
            TxtRecno.Text = rs1.Tables(0).Rows.Count
        End If


        If rs1.Tables(0).Rows.Count = 0 Then
            CmdSubmit.Enabled = False
        Else
            CmdSubmit.Enabled = True
        End If


        Exit Sub
        ''''''exit sub for new code

        If txtDate.Text = "" Then
            MsgBox("ยังไม่ได้เลือกวันที่", MsgBoxStyle.OkOnly, "")
            Exit Sub
        End If
        DDATE = ChangeThaiDateToEngDate(txtDate.Text)
        rs1 = New Data.DataSet
        sql = " SELECT  CLUBCARDNO ,  MAILABLE ,  FLAG FROM  T_TEST.TBL_DATA " & _
        " WHERE  FLAG =  'SUBMIT' AND  MAILABLE =  'SIGNED'  and    DATE_FORMAT( SUBMITDATE ,  '%Y-%m-%d' ) = '" & DDATE & "'  ORDER BY  MAILABLE ,  CLUBCARDNO  "
        Listsigned.Items.Clear()
        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    Listsigned.Items.Add(Trim(rs1.Tables(0).Rows(x)("CLUBCARDNO").ToString))
                Next x
            End If

        End If





        rs1 = New Data.DataSet
        sql = " SELECT  CLUBCARDNO ,  MAILABLE ,  FLAG FROM  T_TEST.TBL_DATA " & _
       " WHERE  FLAG =  'SUBMIT' AND  MAILABLE =  'UNSIGNED'  and    DATE_FORMAT( SUBMITDATE ,  '%Y-%m-%d' ) = '" & DDATE & "'  ORDER BY  MAILABLE ,  CLUBCARDNO  "
        Listunsigned.Items.Clear()
        i = cConnect.OpenSql(sql, rs1)
        If i = True Then
            If rs1.Tables(0).Rows.Count <> 0 Then
                For x = 0 To rs1.Tables(0).Rows.Count - 1
                    Listunsigned.Items.Add(Trim(rs1.Tables(0).Rows(x)("CLUBCARDNO").ToString))
                Next x
            End If

        End If





    End Sub



    Private Sub CmdCopySigned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCopySigned.Click
        Dim fileCnt As Integer
        Dim totalloop As Integer
        Dim i As Integer
        Dim loopcount As Integer
        Dim target, target1 As String
        Dim folderSSS As String
        Dim Ddate As String


        If Listsigned.Items.Count < 1 Then Exit Sub



        fileCnt = TxtFilecnt.Text

        loopcount = Listsigned.Items.Count / fileCnt
        If loopcount = 0 Then loopcount = 1
        'Dim TotalLoop As Integer
        Dim difftotal As Integer
        difftotal = (loopcount * fileCnt) - Listsigned.Items.Count



        If Trim(TxtFilecnt.Text) = "" Then
            MsgBox("ยังไม่ได้กำหนดจำนวนไฟล์ต่อ 1 Folder")
            Exit Sub
        End If


        If Len(Trim(loopcount)) > 3 Then
            MsgBox("กำหนดจำนวนไฟล์ต่อ folder น้อยเกินไป กรุณากำหนดใหม่")
            Exit Sub
        End If

        Ddate = ChangeThaiDateToEngDate(txtDate.Text)


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


            For i = 1 To fileCnt

                Debug.Print((Txtsourcesign.Text & Listsigned.Items(0) & ".pdf"))

                Debug.Print(Dir(Txtsourcesign.Text & Listsigned.Items(0) & ".pdf"))

                If Dir(Txtsourcesign.Text & Listsigned.Items(0) & ".pdf") <> "" Then
                    Debug.Print(target & "\")


                    FileCopy(Txtsourcesign.Text & Listsigned.Items(0) & ".pdf", target & "\" & Listsigned.Items(0) & ".pdf")
                    Listsigned_OK.Items.Add(Listsigned.Items(0))
                    Listsigned.Items.RemoveAt(0)
                Else
                    Listsignederror.Items.Add(Listsigned.Items(0))
                    Listsigned.Items.RemoveAt(0)
                End If


            Next i

            'add file to zip

            Dim OKFILE As String
            Dim zipMD5Hash, gpgMD5Hash As String
            Dim zipFSize, gpgFSize As String

            'เขียน Header file

            OKFILE = target & ".OK"
            FileOpen(1, OKFILE, OpenMode.Output)


            Call addtoZIP(target)

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
            'เขียน Header file
            PrintLine(1, "--                              Image Export Summary                              --")
            PrintLine(1, "--                                                                                --")
            PrintLine(1, "--     Export date  : " & Ddate & "                                                  --")
            PrintLine(1, "--     Records  : " & Listsigned_OK.Items.Count & "                                                              --")
            PrintLine(1, "--                                                                                --")
            PrintLine(1, "")
            PrintLine(1, "File name                     MD5SUM                                            Size")
            PrintLine(1, "----------------------        --------------------------------           -----------")

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
            PrintLine(1, tmpprtln)

            'PrintLine(1, target1 & ".zip.gpg" & "             " & gpgMD5Hash & "        " & gpgFSize)

            'PrintLine(1, target1 & ".zip" & "             " & zipMD5Hash & "        " & zipFSize)


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
            PrintLine(1, tmpprtln)
            PrintLine(1, "Image files list")
            PrintLine(1, "------------------------------------------------------------------------------------")


            Dim x, y As Integer
            Dim PrtStr As String

            y = 1
            PrtStr = ""
            For x = 0 To Listsigned_OK.Items.Count - 1
                If PrtStr = "" Then
                    PrtStr = Listsigned_OK.Items(x).ToString
                Else
                    PrtStr = PrtStr & "   " & Listsigned_OK.Items(x).ToString
                End If


                If y = 4 Then
                    PrintLine(1, PrtStr)
                    PrtStr = ""
                    y = 0
                End If
                y = y + 1
            Next x



            FileClose(1)
            Listsigned_OK.Items.Clear()
nextloop: Next totalloop

        MsgBox("Completed")


    End Sub

    Private Sub CmdCopyunSigned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCopyunSigned.Click
        Dim fileCnt As Integer
        Dim totalloop As Integer
        Dim i As Integer
        Dim loopcount As Integer
        Dim target, target1 As String
        Dim folderSSS As String
        Dim Ddate As String


        If Listunsigned.Items.Count < 1 Then Exit Sub



        fileCnt = TxtFilecnt.Text

        loopcount = Listunsigned.Items.Count / fileCnt

        If loopcount = 0 Then loopcount = 1

        'Dim TotalLoop As Integer
        Dim difftotal As Integer
        difftotal = (loopcount * fileCnt) - Listunsigned.Items.Count



        If Trim(TxtFilecnt.Text) = "" Then
            MsgBox("ยังไม่ได้กำหนดจำนวนไฟล์ต่อ 1 Folder")
            Exit Sub
        End If


        If Len(Trim(loopcount)) > 3 Then
            MsgBox("กำหนดจำนวนไฟล์ต่อ folder น้อยเกินไป กรุณากำหนดใหม่")
            Exit Sub
        End If

        Ddate = ChangeThaiDateToEngDate(txtDate.Text)



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

            target = TxtTarget.Text & "UNSIGNED_IMG_" & Ddate & "_" & folderSSS
            target1 = "UNSIGNED_IMG_" & Ddate & "_" & folderSSS
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


            For i = 1 To fileCnt

                Debug.Print((TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf"))

                Debug.Print(Dir(TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf"))

                If Dir(TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf") <> "" Then
                    Debug.Print(target & "\")


                    FileCopy(TxtsourceUnsign.Text & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf", target & "\" & "UNSIGNED-" & Listunsigned.Items(0) & ".pdf")
                    Listunsigned_OK.Items.Add(Listunsigned.Items(0))
                    Listunsigned.Items.RemoveAt(0)
                Else
                    Listunsignederror.Items.Add(Listunsigned.Items(0))
                    Listunsigned.Items.RemoveAt(0)
                End If


            Next i

            'add file to zip

            Dim OKFILE As String
            Dim zipMD5Hash, gpgMD5Hash As String
            Dim zipFSize, gpgFSize As String

            'เขียน Header file

            OKFILE = target & ".OK"
            FileOpen(1, OKFILE, OpenMode.Output)


            Call addtoZIP(target)

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
            'เขียน Header file
            PrintLine(1, "--                              Image Export Summary                              --")
            PrintLine(1, "--                                                                                --")
            PrintLine(1, "--     Export date  : " & Ddate & "                                                  --")
            PrintLine(1, "--     Records  : " & Listunsigned_OK.Items.Count & "                                                              --")
            PrintLine(1, "--                                                                                --")
            PrintLine(1, "")
            PrintLine(1, "File name                          MD5SUM                                       Size")
            PrintLine(1, "----------------------             --------------------------------      -----------")

            prtln = ""

            If Len(target1 & ".zip.gpg") < 36 Then
                For z = Len(target1 & ".zip.gpg") + 1 To 36 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = target1 & ".zip.gpg" & prtln & gpgMD5Hash

            prtln = ""

            If Len(tmpprtln) < 79 Then
                For z = Len(tmpprtln) + 1 To 79 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = tmpprtln & prtln & gpgFSize
            PrintLine(1, tmpprtln)

            'PrintLine(1, target1 & ".zip.gpg" & "             " & gpgMD5Hash & "        " & gpgFSize)

            'PrintLine(1, target1 & ".zip" & "             " & zipMD5Hash & "        " & zipFSize)


            prtln = ""

            If Len(target1 & ".zip") < 36 Then
                For z = Len(target1 & ".zip") + 1 To 36 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = target1 & ".zip" & prtln & zipMD5Hash

            prtln = ""

            If Len(tmpprtln) < 79 Then
                For z = Len(tmpprtln) + 1 To 79 - 1
                    prtln = prtln & " "
                Next z

            End If
            tmpprtln = tmpprtln & prtln & zipFSize
            PrintLine(1, tmpprtln)
            PrintLine(1, "Image files list")
            PrintLine(1, "------------------------------------------------------------------------------------")


            Dim x, y As Integer
            Dim PrtStr As String

            y = 1
            PrtStr = ""
            For x = 0 To Listunsigned_OK.Items.Count - 1
                If PrtStr = "" Then
                    PrtStr = Listunsigned_OK.Items(x).ToString
                Else
                    PrtStr = PrtStr & "   " & Listunsigned_OK.Items(x).ToString
                End If


                If y = 4 Then
                    PrintLine(1, PrtStr)
                    PrtStr = ""
                    y = 0
                End If
                y = y + 1
            Next x



            FileClose(1)
            Listunsigned_OK.Items.Clear()
nextloop: Next totalloop

        MsgBox("Completed")

    End Sub

    Private Sub addtoZIP(ByVal Target As String)
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
    Function Getfilesize(ByVal Target As String) As String
        Dim mbb As Double
        Getfilesize = ""
        Dim fileDetail As IO.FileInfo
        fileDetail = My.Computer.FileSystem.GetFileInfo(Target)
        mbb = 0
        Debug.Print(fileDetail.Length)
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
        Debug.Print(Target)




        'Shell("C:\windows\system32\cmd.exe gpg --always-trust --recipient Walainuch.Tummanitayakul@TH.TESCO.COM --encrypt " & Target)
        Dim ccc As String
        ccc = Shell("gpg --always-trust --recipient Walainuch.Tummanitayakul@TH.TESCO.COM --encrypt " & Target)
        RunExternalFile(ccc)

lp:     If Dir(Target & ".gpg", FileAttribute.Archive) = "" Then
            GoTo lp
        Else
            Exit Sub
        End If









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
        Dim i As Integer
        Dim sql As String
        If MsgBox("ต้องการ Update เป็น Submit จำนวน " & TxtRecno.Text & "รายการใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Listsigned.Items.Clear()
        Listsigned_OK.Items.Clear()
        Listsignederror.Items.Clear()


        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = Listsigned.Items.Count - 1
        For i = 0 To Listsigned.Items.Count - 1

            sql = "UPDATE tlc_member_clubcard  SET FLAG = 'SUBMIT' , " & _
            " SUBMIT_DATE = DATE_FORMAT( CURDATE( ) ,  '%Y-%m-%d' ) " & _
            " WHERE Clubcard_No   = '" & Listsigned.Items(0).ToString & "' " & _
            " and Flag  = 'QC'  "

            If cConnect.Execute(sql) = True Then
                Listsigned_OK.Items.Add(Listsigned.Items(0))
                Listsigned.Items.RemoveAt(0)
                TxtOK.Text = Listsigned_OK.Items.Count
            Else
                Listsignederror.Items.Add(Listsigned.Items(0))
                Listsigned.Items.RemoveAt(0)
                TxtError.Text = Listsignederror.Items.Count
            End If

            ProgressBar1.Value = i

        Next i
        MsgBox("Update Completed", MsgBoxStyle.OkOnly, "")
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

    Private Sub CmdSavelogError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSavelogError.Click
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
End Class
