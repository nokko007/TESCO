Public Class ClsGenReport

    Public Function Gen_Daily(ByVal pGen As String) As Object
        'On Error GoTo error_Handler


        Dim sql As String
        Dim i As Boolean
        Dim j As Short ' จำนวน Col
        Dim TProgress As Short ' เก็บ Value
        Dim rs As ADODB.Recordset
        Dim TitleTemp As String

        Dim xlApp As Microsoft.Office.Interop.Excel.Application ' Excel Application Object 
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook ' Excel Workbook Object 
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet  ' Excel Workbook Object 


        '    CHTime = Format(Now, "HHMMSS")
        '    FrmProgress.Show
        '    LabTime.Caption = "ใช้เวลาโหลด = " & (Format(Now, "HHMMSS") - CHTime) & " วินาที"


        If MsgBox("คุณต้องการทำรายการ Gen ใช่หรือไม่", MsgBoxStyle.OkCancel, "ยืนยันการทำรายการ") = MsgBoxResult.Cancel Then Exit Function

        rs = New ADODB.Recordset
        i = cGenfile.SelectForGenYesFile(pGen, rs)
        If i = False Then Exit Function
        If rs.RecordCount <= 0 Then MsgBox("ไม่มีข้อมูลที่จะทำรายการ", MsgBoxStyle.Information, "ไม่พบข้อมูล") : Exit Function

        FrmProgress.Show()
        FrmProgress.ProgressBar1.Minimum = 0
        FrmProgress.ProgressBar1.Value = 0
        FrmProgress.ProgressBar1.Maximum = rs.RecordCount
        '        cPolicy.SUP_STATUS = "Gen. Yes File : " & Format(TxtPolicyDate, "DD/MM/YYYY")
        '        i = cQC.InsertStatusForEdit

        'frmSelectQC.Hide

        'FrmProgress.Show
        'เปิด WorkBook เก่า



        xlApp = CreateObject("Excel.Application")
        xlApp.Visible = True
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

        xlBook = xlApp.Workbooks.Open(PathReport & "EDC.xls", )
        xlBook.Windows(1).Visible = True
        xlSheet = xlBook.Worksheets(1)


        xlSheet.PageSetup.LeftHeader = xlSheet.PageSetup.LeftHeader & VB6.Format(Now, "DD-MMM-YYYY")


        TProgress = Val(CStr(100 / rs.RecordCount))

        rs.MoveFirst()

        For j = 1 To rs.RecordCount

            If pGen = "EDC1" Or pGen = "Re-EDC1" Then

                cGenfile.URN = IIf(IsDBNull(rs.Fields("URN").Value) = False, rs.Fields("URN").Value, "")
                cGenfile.EName = IIf(IsDBNull(rs.Fields("ENG_NAME").Value) = False, rs.Fields("ENG_NAME").Value, "")
                cGenfile.ESurName = IIf(IsDBNull(rs.Fields("ENG_SURNAME").Value) = False, rs.Fields("ENG_SURNAME").Value, "")
                cGenfile.CREDITCARD = IIf(IsDBNull(rs.Fields("CREDITCARD").Value) = False, rs.Fields("CREDITCARD").Value, "")
                cGenfile.ExpiryID = VB6.Format(rs.Fields("CARD_EXPIRE").Value, "MM/YY")

                If Mid(rs.Fields("campaign").Value, 1, 1) <> "P" Or Mid(rs.Fields("campaign").Value, 1, 7) = "PA SURE" Then
                    If rs.Fields("Paytype").Value = "จ่ายเต็ม" Then
                        cGenfile.total = rs.Fields("POLICYCURRENCYALL").Value
                    Else
                        cGenfile.total = rs.Fields("CURRENCYREALALL").Value '* rs!ACC_EDC_MONTH
                    End If
                Else
                    'nokko 20090722 แบ่ง 6 งวด
                    If rs.Fields("Paytype").Value = "รายปี" Then
                        cGenfile.total = rs.Fields("SUMCURRENCY").Value
                    ElseIf rs.Fields("Paytype").Value = "แบ่งชำระ" Then
                        cGenfile.total = CStr(rs.Fields("SUMCURRENCY").Value / 4) '* rs!ACC_EDC_MONTH
                    ElseIf rs.Fields("Paytype").Value = "แบ่งชำระ 6 งวด" Then
                        cGenfile.total = CStr(rs.Fields("SUMCURRENCY").Value / 6) '* rs!ACC_EDC_MONTH
                    End If
                End If

                cGenfile.TSRName = IIf(IsDBNull(rs.Fields("TSR_LOGINNAME").Value) = False, rs.Fields("TSR_LOGINNAME").Value, "")
                cGenfile.Paytype = IIf(IsDBNull(rs.Fields("Paytype").Value) = False, rs.Fields("Paytype").Value, "")

                cGenfile.Payround = CStr(1)
                cGenfile.campaign = IIf(IsDBNull(rs.Fields("campaign").Value) = False, rs.Fields("campaign").Value, "")
            Else ''''งวด 2-4


                cGenfile.URN = IIf(IsDBNull(rs.Fields("URN").Value) = False, rs.Fields("URN").Value, "")
                cGenfile.EName = IIf(IsDBNull(rs.Fields("ENG_NAME").Value) = False, rs.Fields("ENG_NAME").Value, "")
                cGenfile.ESurName = IIf(IsDBNull(rs.Fields("ENG_SURNAME").Value) = False, rs.Fields("ENG_SURNAME").Value, "")
                cGenfile.CREDITCARD = IIf(IsDBNull(rs.Fields("CREDITCARD").Value) = False, rs.Fields("CREDITCARD").Value, "")
                cGenfile.ExpiryID = VB6.Format(rs.Fields("CARD_EXPIRE").Value, "MM/YY")
                cGenfile.total = rs.Fields("EDC_AMOUNT").Value
                cGenfile.TSRName = IIf(IsDBNull(rs.Fields("TSR_LOGINNAME").Value) = False, rs.Fields("TSR_LOGINNAME").Value, "")
                cGenfile.Paytype = IIf(IsDBNull(rs.Fields("Paytype").Value) = False, rs.Fields("Paytype").Value, "")

                cGenfile.Payround = IIf(IsDBNull(rs.Fields("SEQUENCE").Value) = False, rs.Fields("SEQUENCE").Value, "")
                cGenfile.campaign = IIf(IsDBNull(rs.Fields("campaign").Value) = False, rs.Fields("campaign").Value, "")

            End If

            i = cGenfile.PrintToXLS(j + 1, xlSheet)

            rs.MoveNext()
            FrmProgress.ProgressBar1.Value = FrmProgress.ProgressBar1.Value + 1
        Next j

        'UPGRADE_WARNING: Couldn't resolve default property of object xlSheet.Columns().EntireColumn. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        xlSheet.Columns._Default("A:E").EntireColumn.AutoFit() 'เพื่อให้ โชว์ข้อมูลพอดีกับช่อง
        'xlBook.SaveAs cConfig.PathReport & "\output\Date" & Format(Now, "yyyyMMdd") & Format(Now, "_HHMMSS") & ".xls"

        '    Unload FrmProgress
        '    FrmEDC2Excel.Show
        'Me.WindowState = 2
        xlApp.Visible = True
        MsgBox("Gen ข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.OkOnly, "")
        FrmProgress.Close()
        '
        'resume_err:
        '    Exit Sub
        '
        'error_Handler:
        ''    If Err = 1004 Then MsgBox "กรุณาตรวจสอบ ห้อง " & cConfig.PathReport & "\output\", vbInformation, "ไม่พบที่อยู่"
        ''    Call ShowError(Me.Name & "_Form_Load", Err, Error$)
        '    GoTo resume_err

    End Function
End Class
