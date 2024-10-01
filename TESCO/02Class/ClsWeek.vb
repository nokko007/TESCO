Option Strict Off
Option Explicit On

Public Class ClsWeek
    Dim lWeekID As String
    Dim lWeekNo As String
    Dim lPickupDate As String
    Public WriteOnly Property WeekID() As String
        Set(ByVal Value As String)
            lWeekID = Value
        End Set
    End Property
    Public WriteOnly Property WeekNo() As String
        Set(ByVal Value As String)
            lWeekNo = Value
        End Set
    End Property
    Public WriteOnly Property PickupDate() As String
        Set(ByVal Value As String)
            lPickupDate = Value
        End Set
    End Property
    Public Function INSERTWEEK() As Boolean
        INSERTWEEK = False
        Dim sql As String
        sql = "INSERT INTO TBL_WKCYCLE " & _
            " (WEEKNO, PICKUPDATE, CREATEDATE, CREATEBY, UPDATEDATE, UPDATEBY)" & _
            " VALUES     (" & lWeekNo & " ,'" & lPickupDate & "' ,GETDATE(),'" & cOfficer.Login & "' ,GETDATE(),'" & cOfficer.Login & "') "

        If cConnect.Execute(sql) = True Then
            INSERTWEEK = True
        Else
            Exit Function
        End If

    End Function

    Public Function UPDATEWEEK() As Boolean
        UPDATEWEEK = False
        Dim sql As String
        sql = "UPDATE  TBL_WKCYCLE " & _
            " SET WEEKNO= " & lWeekNo & ", PICKUPDATE='" & lPickupDate & "', UPDATEDATE=GETDATE(), UPDATEBY='" & cOfficer.Login & "'  " & _
            " WHERE WEEKID =  " & lWeekID & ""

        If cConnect.Execute(sql) = True Then
            UPDATEWEEK = True
        Else
            Exit Function
        End If

    End Function



    Public Function DELETEWEEK() As Boolean
        DELETEWEEK = False
        Dim sql As String
        sql = "DELETE  TBL_WKCYCLE " & _
            " WHERE WEEKID =  " & lWeekID & ""

        If cConnect.Execute(sql) = True Then
            DELETEWEEK = True
        Else
            Exit Function
        End If

    End Function
    Public Function SELECTWEEK(ByRef pRs As Data.DataSet) As Boolean
        SELECTWEEK = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT WEEKID, WEEKNO,  CONVERT(VARCHAR(10),PICKUPDATE,20) as PICKUPDATE FROM TBL_WKCYCLE  WITH (NOLOCK) "

        If lWeekNo <> "" Or lPickupDate <> "" Then
            sql = sql & " WHERE "
        End If

   

        If lWeekNo <> "" Then
            sql = sql & "  WEEKNO = " & lWeekNo & "  "
        End If

        If lWeekNo <> "" And lPickupDate <> "" Then
            sql = sql & " AND CONVERT(VARCHAR(10),PICKUPDATE,20) = '" & lPickupDate & "' "
        ElseIf lWeekNo = "" And lPickupDate <> "" Then
            sql = sql & "  CONVERT(VARCHAR(10),PICKUPDATE,20) = '" & lPickupDate & "' "
        End If

        sql = sql & " ORDER BY WEEKNO desc "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        SELECTWEEK = True


    End Function
    Public Function CHKDUPWEEK(ByRef pRs As Data.DataSet) As Boolean
        CHKDUPWEEK = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT WEEKID, WEEKNO,  CONVERT(VARCHAR(10),PICKUPDATE,20) as PICKUPDATE FROM TBL_WKCYCLE  WITH (NOLOCK) "

        sql = sql & " WHERE "

        sql = sql & "  (WEEKNO = " & lWeekNo & "  "

        sql = sql & " OR CONVERT(VARCHAR(10),PICKUPDATE,20) = '" & lPickupDate & "') "

        If lWeekID <> "" Then

            sql = sql & " AND WEEKID  <> " & lWeekID & " "

        End If
        sql = sql & " ORDER BY WEEKNO desc "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        CHKDUPWEEK = True


    End Function
    Public Function CHKUSEWEEK(ByRef pRs As Data.DataSet) As Boolean

        CHKUSEWEEK = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT * FROM TBL_MAILBAG WITH (NOLOCK)  WHERE WKCYCLE_ID = " & lWeekID & " "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        CHKUSEWEEK = True


    End Function

End Class
