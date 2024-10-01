Option Strict Off
Option Explicit On

Public Class ClsStore
    Dim lStoreID As String
    Dim lSTORENAME As String

    Public WriteOnly Property StoreID() As String
        Set(ByVal Value As String)
            lStoreID = Value
        End Set
    End Property
    Public WriteOnly Property STORENAME() As String
        Set(ByVal Value As String)
            lSTORENAME = Value
        End Set
    End Property

    Public Function INSERTStore() As Boolean

        INSERTStore = False
        Dim sql As String
        sql = "INSERT INTO TBL_STORE " & _
            " (STOREID, STORENAME)" & _
            " VALUES     (" & lStoreID & " ,'" & lSTORENAME & "') "

        If cConnect.Execute(sql) = True Then
            INSERTStore = True
        Else
            Exit Function
        End If

    End Function

    Public Function UPDATEStore() As Boolean
        UPDATEStore = False
        Dim sql As String
        sql = "UPDATE  TBL_STORE " & _
            " SET STORENAME  '" & lSTORENAME & "  " & _
            " WHERE STOREID =  " & lStoreID & " "

        If cConnect.Execute(sql) = True Then
            UPDATEStore = True
        Else
            Exit Function
        End If

    End Function



    Public Function DELETEStore() As Boolean
        DELETEStore = False
        Dim sql As String
        sql = "DELETE  TBL_STORE " & _
            " WHERE STOREID =  " & lStoreID & ""

        If cConnect.Execute(sql) = True Then
            DELETEStore = True
        Else
            Exit Function
        End If

    End Function
    Public Function SELECTStore(ByRef pRs As Data.DataSet) As Boolean
        SELECTStore = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT STOREID, STORENAME FROM TBL_STORE"

        If lStoreID <> "" Or lSTORENAME <> "" Then
            sql = sql & " WHERE "
        End If


        If lStoreID <> "" Then
            sql = sql & " STOREID  = " & lStoreID & " "
        End If

        If lStoreID <> "" And lSTORENAME <> "" Then
            sql = sql & " AND STORENAME  like '" & lSTORENAME & "%' "
        ElseIf lStoreID = "" And lSTORENAME <> "" Then
            sql = sql & "  STORENAME  like  '" & lSTORENAME & "%' "
        End If

        sql = sql & " ORDER BY STOREID "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        SELECTStore = True


    End Function
    Public Function CHKDUPStore(ByRef pRs As Data.DataSet) As Boolean
        CHKDUPStore = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT STOREID, STORENAME FROM TBL_STORE"

        sql = sql & " WHERE "

        sql = sql & "  STORENAME = '" & lStoreName & "'  "




        sql = sql & " OR  STOREID  = " & lStoreID & " "


        sql = sql & " ORDER BY STOREID "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        CHKDUPStore = True


    End Function
    Public Function CHKUSEStore(ByRef pRs As Data.DataSet) As Boolean

        CHKUSEStore = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT * FROM TBL_MAILBAG WHERE STORE = " & lStoreID & " "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        CHKUSEStore = True


    End Function

End Class
