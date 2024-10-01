Option Strict Off
Option Explicit On
Public Class clsOfficer

    Dim lLogin As String ' Login ที่ Online อยู่
    Dim lPass As String
    Public lThaiTitle As String
    Public lLoginFName As String
    Public lLoginLName As String

    Dim lMEMBERID As String
    Dim lLOGINNAME As String ' Login ที่จะเพิ่ม แก้ไข ลบ
    Dim lAuth As String ' 
    Dim lTtitle As String
    Dim lEtitle As String
    Dim lTFname As String
    Dim lTLname As String
    Dim lEFname As String
    Dim lELname As String
    Dim lNICKNAME As String
    Dim lPASSWORD As String
    Dim lLevelID As String
    Dim lTeamLeader As String
    Dim lStartdate As String
    Dim lStopdate As String
    Dim lAccessStatus As Short
    Dim lPROJECT_CODE As String
    Dim lTSRPicture As String

    Dim lLICENSE As String 'bom_20081021 เพิ่ม เลขที่ตัวแทน

    Dim lAppDate As String
    '''' FOR MONITORING'''''

    Dim lscreen As String
    Dim lStartCalltime As String
    Dim lcustomer As String
    Dim lIsACtive As String



    Public Sub ClearParameter()
        On Error GoTo error_Handler

        lLOGINNAME = ""
        lAuth = ""
        lTtitle = ""
        lEtitle = ""
        lTFname = ""
        lTLname = ""
        lEFname = ""
        lELname = ""
        lNICKNAME = ""
        lPASSWORD = ""
        lLevelID = CStr(0)
        lTeamLeader = CStr(0)
        lStartdate = ""
        lStopdate = ""
        lAccessStatus = 0
        lPROJECT_CODE = ""
        lTSRPicture = ""
        lscreen = ""
        lStartCalltime = ""
        lcustomer = ""
        lAppDate = ""

resume_err:
        Exit Sub

error_Handler:
        Call ShowError("ClsOfficer" & "_" & "ClearParameter", Err.Number, ErrorToString())
        GoTo resume_err
    End Sub

    Public WriteOnly Property AccessStatus() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lAccessStatus = CShort(Value)
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "AccessStatus", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property Stopdate() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lStopdate = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "Stopdate", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property Startdate() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lStartdate = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "Startdate", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property


    Public Property TEAMLEADER() As String
        Get
            TEAMLEADER = lTeamLeader
        End Get
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lTeamLeader = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "Teamleader", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property LevelID() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lLevelID = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "Levelid", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property PASSWORD() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lPASSWORD = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "PASSWORD", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property NICKNAME() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lNICKNAME = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "NICKNAME", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property ELname() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lELname = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "ELname", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property EFname() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lEFname = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "EFname", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property TLname() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lTLname = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "TLname", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property TFname() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lTFname = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "TFname", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property Etitle() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lEtitle = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "Etitle", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public WriteOnly Property Ttitle() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lTtitle = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "Ttitle", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    'bom_20081021 เพิ่ม เลขที่ตัวแทน
    Public WriteOnly Property LICENSE() As String
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lLICENSE = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "LOGINNAME", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property


    Public Property LOGINNAME() As String
        Get
            On Error GoTo error_Handler

            LOGINNAME = lLOGINNAME
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "LOGINNAME", Err.Number, ErrorToString())
            GoTo resume_err
        End Get
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lLOGINNAME = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "LOGINNAME", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property


    Public Property IsActive() As String
        Get
            On Error GoTo error_Handler

            IsActive = lIsActive
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "IsActive", Err.Number, ErrorToString())
            GoTo resume_err
        End Get
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lIsACtive = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "IsActive", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property



    Public Property MEMBERID() As String
        Get
            On Error GoTo error_Handler

            MEMBERID = lMEMBERID
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "MEMBERID", Err.Number, ErrorToString())
            GoTo resume_err
        End Get
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lMEMBERID = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "MEMBERID", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property


    Public Property AUTH() As String
        Get
            On Error GoTo error_Handler

            AUTH = lAUTH
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "AUTH", Err.Number, ErrorToString())
            GoTo resume_err
        End Get
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lAuth = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "AUTH", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public Property PROJECT_CODE() As String
        Get
            On Error GoTo error_Handler

            PROJECT_CODE = lPROJECT_CODE
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "PROJECT_CODE", Err.Number, ErrorToString())
            GoTo resume_err
        End Get
        Set(ByVal Value As String)
            On Error GoTo error_Handler

            lPROJECT_CODE = Value
resume_err:
            Exit Property

error_Handler:
            Call ShowError("ClsOfficer" & "_" & "PROJECT_CODE", Err.Number, ErrorToString())
            GoTo resume_err
        End Set
    End Property

    Public Property Login() As String
        Get
            Login = lLogin
        End Get
        Set(ByVal Value As String)
            lLogin = Value
        End Set
    End Property

    '''' PROPERTY FOR MONITOR''''
    Public Property customer() As String
        Get
            customer = lcustomer
        End Get
        Set(ByVal Value As String)
            lcustomer = Value
        End Set
    End Property
    Public Property screen() As String
        Get
            screen = lscreen
        End Get
        Set(ByVal Value As String)
            lscreen = Value
        End Set
    End Property
    Public Property StartCalltime() As String
        Get
            StartCalltime = lStartCalltime
        End Get
        Set(ByVal Value As String)
            lStartCalltime = Value
        End Set
    End Property
    Public Property AppDate() As String
        Get
            AppDate = lAppDate
        End Get
        Set(ByVal Value As String)
            lAppDate = Value
        End Set
    End Property
    ''''END  PROPERTY FOR MONITOR''''

    Public Property TSRPicture() As String
        Get
            TSRPicture = lTSRPicture
        End Get
        Set(ByVal Value As String)
            lTSRPicture = Value
        End Set
    End Property

    Public Function SelectOfficer(ByRef pRs As Data.DataSet, Optional ByRef pProject As String = "") As Short
        On Error GoTo error_Handler
        Dim sql As String
        Dim where As Boolean
        Dim i As Short

        SelectOfficer = False

        sql = "SELECT  id, member_name, member_surname, username, password, auth, isActivate, created_date " & _
            " FROM TBL_MEMBER  WITH (NOLOCK) "
        If cOfficer.LOGINNAME <> "" Then
            sql = sql & " WHERE username = '" & cOfficer.LOGINNAME & "' "
        End If
        If cOfficer.MEMBERID <> "" Then
            sql = sql & " AND id <> " & cOfficer.MEMBERID & " "
        End If
        sql = sql & " ORDER BY username "

        i = cConnect.OpenSql(sql, pRs)
        SelectOfficer = True
resume_err:
        Exit Function

error_Handler:
        Call ShowError("ClsOfficer" & "_" & "SelectOfficer", Err.Number, ErrorToString())
        GoTo resume_err
    End Function

    Public Function InsertOfficer() As Boolean
        On Error GoTo error_Handler
        Dim sql As String
        Dim i As Boolean

        InsertOfficer = False

        sql = "INSERT INTO TBL_MEMBER " & _
            " (member_name, member_surname,  " & _
            " username, password, auth,  " & _
            " isActivate, created_date) " & _
            " VALUES     ('" & lEFname & "' ,'" & lELname & "', " & _
            " '" & lLOGINNAME & "',  '" & lPASSWORD & "', '" & lLevelID & "', " & _
            " '" & lIsACtive & "' ,getdate() )"




        i = cConnect.Execute(sql)

        If i = True Then InsertOfficer = True

resume_err:
        Exit Function

error_Handler:
        Call ShowError("ClsOfficer" & "_" & "InsertOfficer", Err.Number, ErrorToString())
        GoTo resume_err
    End Function

    '    Public Function DeleteOfficer() As Boolean
    '        On Error GoTo error_Handler
    '        Dim sql As String
    '        Dim i As Short

    '        DeleteOfficer = False

    '        sql = "DELETE TBL_OFFICER WHERE LOGINNAME = '" & lLOGINNAME & "' "

    '        i = cConnect.Execute(sql)

    '        If i >= 0 Then DeleteOfficer = True

    'resume_err:
    '        Exit Function

    'error_Handler:
    '        Call ShowError("ClsOfficer" & "_" & "DeleteOfficer", Err.Number, ErrorToString())
    '        GoTo resume_err
    '    End Function

    Public Function UpdateOfficer() As Boolean
        On Error GoTo error_Handler
        Dim sql As String
        Dim i As Boolean

        UpdateOfficer = False

        sql = "UPDATE    TBL_MEMBER " & _
                " SET  member_name ='" & lEFname & "' , member_surname ='" & lELname & "', " & _
                " username ='" & lLOGINNAME & "',  " & _
                " password ='" & lPASSWORD & "', auth =" & lLevelID & ",  " & _
                " isActivate =" & lIsACtive & ", created_date = getdate() " & _
                " where id = " & lMEMBERID & " "

        i = cConnect.Execute(sql)

       




        If i = True Then UpdateOfficer = True

resume_err:
        Exit Function

error_Handler:
        Call ShowError("ClsOfficer" & "_" & "UpdateOfficer", Err.Number, ErrorToString())
        GoTo resume_err
    End Function

    Public Function SelectLogin() As Boolean
        On Error GoTo error_Handler
        Dim rs As Data.DataSet
        Dim rs1 As Data.DataSet
        Dim i, j As Boolean
        Dim k As Boolean
        Dim sql As String
        SelectLogin = False

        rs = New Data.DataSet

        sql = "SELECT * FROM TBL_MEMBER WITH (NOLOCK) WHERE   username   = '" & lLogin & "'"
        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        i = cConnect.OpenSql(sql, rs)
        If Not i Then
            SelectLogin = False
            Exit Function
        End If
        If rs.Tables(0).Rows.Count = 0 Then
            MsgBox("ไม่พบชื่อนี้ในการเข้าระบบ กรุณาใส่ชื่อที่มีในระบบ", MsgBoxStyle.Information, "ชื่อเข้าระบบ")
            SelectLogin = False
            With frmLogin.TxtLogin
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                .Focus()
            End With
            Exit Function
        End If
        If rs.Tables(0).Rows(0)("password").ToString <> lPASSWORD Then
            MsgBox("รหัสผ่านไม่ถูกต้อง กรุณาใส่รหัสผ่านอีกครั้ง", MsgBoxStyle.Information, "รหัสผ่าน")
            SelectLogin = False
            frmLogin.TxtPassword.Text = ""
            frmLogin.TxtPassword.Focus()
            Exit Function
        End If
        'If rs.Tables(0).Rows(0)("auth").ToString <> ProgramLevel Then
        '    MsgBox("ไม่ใช่ Admin ไม่สามารถเข้าระบบได้", MsgBoxStyle.Information, "สิทธิในการเข้าระบบ")
        '    SelectLogin = False
        '    With frmLogin.TxtLogin
        '        .SelectionStart = 0
        '        .SelectionLength = Len(.Text)
        '        .Focus()
        '    End With
        '    Exit Function
        'End If
        If rs.Tables(0).Rows(0)("isActivate").ToString <> True Then
            MsgBox("User นี้ถูกระงับการใช้งานชั่วคราว", MsgBoxStyle.Information, "สิทธิในการเข้าระบบ")
            SelectLogin = False
            Exit Function
        End If
        LOGINNAME = rs.Tables(0).Rows(0)("USERNAME").ToString
        AUTH = rs.Tables(0).Rows(0)("auth").ToString()


        'rs1 = New Data.DataSet
        ''***********************************************
        'sql = "SELECT * FROM TBL_LOGINTIME WHERE TSR_LOGINNAME = '" & lLogin & "' AND LOGOUTTIME = '' "
        ''UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'j = cConnect.OpenSql(sql, rs1)
        'If j = False Then
        '    SelectLogin = False
        '    Exit Function
        'End If

        'If rs1.Tables(0).Rows.Count <> 0 Then
        '    sql = "UPDATE TBL_LOGINTIME SET LOGOUTTIME = getdate() WHERE TSR_LOGINNAME = '" & lLogin & "' AND LOGOUTTIME = '' "
        '    'UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    j = cConnect.Execute(sql)
        'End If
        ''***********************************************
        'sql = "INSERT INTO TBL_LOGINTIME(PROJECT_CODE,TSR_LOGINNAME ,LEVEL_ID,LOGINTIME,LOGOUTTIME) values('" & rs.Tables("table1").Rows(0)("PROJECT_CODE").ToString & "' ,'" & rs.Tables("table1").Rows(0)("LOGINNAME").ToString & "' ,'" & ProgramLevel & "', getdate() ,'')"
        'k = cConnect.Execute(sql)
        'If k = False Then
        '    MsgBox("Error Insert Login")
        '    SelectLogin = False
        '    Exit Function
        'End If
        ' '' MONITOR
        'If FrmTSRMain.Tag = "TSR" Then
        '    sql = "SELECT * FROM TBL_MONITOR WHERE LOGINNAME = '" & lLogin & "'"
        '    k = cConnect.OpenSql(sql, rs1)
        '    If rs.Tables(0).Rows.Count > 0 Then
        '        sql = "DELETE FROM TBL_MONITOR WHERE LOGINNAME = '" & lLogin & "'"
        '        k = cConnect.Execute(sql)
        '    End If

        '    sql = "INSERT INTO TBL_MONITOR (LOGINNAME ,STARTCALLTIME,SCREEN,CUSTOMER) VALUES('" & rs.Tables("table1").Rows(0)("LOGINNAME").ToString & "' , GETDATE() ,'','')"
        '    k = cConnect.Execute(sql)
        '    If k = False Then
        '        MsgBox("Error Insert Monitor")
        '        SelectLogin = False
        '        Exit Function
        '    End If
        'End If
        ''END MONITOR
        'gProject = rs.Tables("table1").Rows(0)("PROJECT_CODE").ToString
        'PROJECT_CODE = rs.Tables("table1").Rows(0)("PROJECT_CODE").ToString
        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'cOfficer.TEAMLEADER = IIf(IsDBNull(rs.Tables("table1").Rows(0)("TeamLeader_Name").ToString), "", rs.Tables("table1").Rows(0)("TeamLeader_Name").ToString)

        'gTsr = rs.Tables("table1").Rows(0)("LOGINNAME").ToString
        'cConfig.TSR = rs.Tables("table1").Rows(0)("FNAME_THAI").ToString & "  " & rs.Tables("table1").Rows(0)("LNAME_THAI").ToString

        ''bom_20081021 เพิ่ม เลขที่ตัวแทน
        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not IsDBNull(rs.Tables("table1").Rows(0)("LICENSE").ToString) Then
        '    cConfig.LICENSE = rs.Tables("table1").Rows(0)("LICENSE").ToString
        'End If

        ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'If Not IsDBNull(rs.Tables("table1").Rows(0)("tsr_picture").ToString) Then
        '    gTsrPicture = rs.Tables("table1").Rows(0)("tsr_picture").ToString
        'End If

        'If Not IsDBNull(rs.Tables("table1").Rows(0)("FNAME_THAI").ToString) Then
        '    gTsrName = rs.Tables("table1").Rows(0)("FNAME_THAI").ToString & " " & rs.Tables("table1").Rows(0)("LNAME_THAI").ToString
        'End If
        SelectLogin = True

resume_error:
        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing
        'UPGRADE_NOTE: Object rs1 may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs1 = Nothing
        Exit Function

error_Handler:
        Call ShowError("ClsOfficer" & "_" & "SelectLogin", Err.Number, ErrorToString())
        GoTo resume_error

    End Function

    '    Public Function Logout() As Boolean
    '        Dim sql As String
    '        Dim i As Boolean
    '        Dim pass As String
    '        Dim rs As Data.DataSet

    '        On Error GoTo error_Handler

    '        Logout = False

    '        rs = New Data.DataSet
    '        sql = "SELECT * FROM TBL_LOGINTIME WHERE TSR_LOGINNAME = '" & lLogin & "' AND LOGOUTTIME = '' AND PROJECT_CODE = '" & gProject & "'"

    '        If cConnect.OpenSql(sql, rs) = False Then
    '            If rs.Tables("table1").Rows.Count = 0 Then
    '                MsgBox("ไม่สามารถบันทึกเวลาออกได้")
    '                GoTo resume_error
    '            End If
    '        End If

    '        If rs.Tables(0).Rows.Count > 0 Then
    '            sql = "UPDATE TBL_LOGINTIME SET LOGOUTTIME = GETDATE()  " & " WHERE TSR_LOGINNAME = '" & lLogin & "' AND LOGOUTTIME = '' AND PROJECT_CODE = '" & gProject & "'"

    '            i = cConnect.Execute(sql)
    '            If i = False Then
    '                MsgBox("บันทึกเวลาออกจากระบบไม่ได้", MsgBoxStyle.Critical)
    '                GoTo resume_error
    '            End If
    '        End If
    '        '
    '        If FrmTSRMain.Tag = "TSR" Then
    '            sql = "DELETE FROM TBL_MONITOR WHERE LOGINNAME = '" & lLogin & "'"
    '            i = cConnect.Execute(sql)
    '            If i = False Then
    '                MsgBox("บันทึกเวลาออกจารระบบไม่ได้", MsgBoxStyle.Critical)
    '                GoTo resume_error
    '            End If
    '        End If
    '        Logout = True

    'resume_error:
    '        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '        rs = Nothing
    '        Exit Function

    'error_Handler:
    '        Call ShowError("ClsOfficer" & "_" & "_Logout", Err.Number, ErrorToString())
    '        GoTo resume_error

    '    End Function

    '    Public Function updateMonitor() As Boolean
    '        On Error GoTo error_Handler
    '        Dim i As Short
    '        Dim sql As String
    '        updateMonitor = False
    '        sql = "UPDATE TBL_MONITOR SET CUSTOMER = '" & cOfficer.customer & "',STARTCALLTIME = CONVERT(VARCHAR(20),'" & cOfficer.StartCalltime & "',20),SCREEN = '" & cOfficer.screen & "' WHERE LOGINNAME = '" & cOfficer.Login & "'"
    '        i = cConnect.Execute(sql)
    '        If i < 0 Then
    '            updateMonitor = False
    '            Exit Function
    '        End If
    '        updateMonitor = True

    'resume_error:

    '        Exit Function

    'error_Handler:
    '        Call ShowError("ClsOfficer" & "_" & "UpdateMonitor", Err.Number, ErrorToString())
    '        GoTo resume_error

    '    End Function

    '    Public Function Selectsuccess() As String 'เลือกรายชื่อที่เพิ่ง Success มา 10 นาที
    '        On Error GoTo error_Handler
    '        Dim sql As String
    '        Dim i As Boolean
    '        Dim rs As Data.DataSet
    '        Dim tmpstr As String
    '        Dim x As Integer

    '        Selectsuccess = ""

    '        sql = "SELECT TSR_LOGINNAME, COUNT(CUSTID) AS SUMCUSTID " & "From TBL_CALLHISTORY " & "WHERE ((CALLSTATUS = 'Success')  " & "OR (CALLSTATUS = 'Follow Payment')  " & "OR (CALLSTATUS = 'Follow Doc'  AND STATUSREASON = 'Follow Doc')  ) " & "AND (DATEDIFF(minute, ENDCALLTIME, GETDATE()) <= 10) " & "GROUP BY TSR_LOGINNAME"

    '        i = cConnect.OpenSql(sql, rs)
    '        If rs.Tables(0).Rows.Count > 0 Then

    '            For x = 1 To rs.Tables(0).Rows.Count - 1
    '                Selectsuccess = Selectsuccess & "< ตอนนี้คุณ " & rs.Tables("table1").Rows(x)("TSR_LOGINNAME").ToString & " ขายได้อีกแล้ว จำนวน = " & rs.Tables("table1").Rows(x)("SUMCUSTID").ToString & " ใบ > "

    '            Next


    '        End If

    'resume_error:

    '        Exit Function

    'error_Handler:
    '        Call ShowError("ClsOfficer" & "_" & "SelectSuccess", Err.Number, ErrorToString())
    '        GoTo resume_error

    '    End Function

    '    Public Function SelectUserTSR(ByRef pProgramLevel As String) As String
    '        On Error GoTo error_Handler
    '        Dim sql As String
    '        Dim i As Boolean
    '        Dim rs As Data.DataSet

    '        SelectUserTSR = "0"

    '        sql = "SELECT     COUNT(*) AS CountUserTSR " & "FROM TBL_LOGINTIME " & "WHERE     (LOGOUTTIME = '') AND (LEVEL_ID = '" & pProgramLevel & "') " & "AND (CONVERT(VARCHAR(10), LOGINTIME, 120) = CONVERT(VARCHAR(10), GETDATE(), 120)) "

    '        i = cConnect.OpenSql(sql, rs)
    '        If i = True Then
    '            SelectUserTSR = rs.Tables("table1").Rows(0)("CountUserTSR").ToString
    '        End If
    'resume_error:

    '        Exit Function

    'error_Handler:
    '        Call ShowError("ClsOfficer" & "_" & "SelectUserTSR", Err.Number, ErrorToString())
    '        GoTo resume_error

    '    End Function
End Class