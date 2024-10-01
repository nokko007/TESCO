
Option Strict Off
Option Explicit On

Public Class ClsMailbag

    Dim lMailbagID As String
    Dim lWKCYCLE_ID As String
    Dim lDCNAME As String
    Dim lStoreID As String
    Dim lMailbagNumber As String
    Dim lSealNo As String
    Dim lEnvelopeNo As String
    Dim lAppInform As String

    Dim lNoBarcodeApp As String
    Dim lDateFrontLetter As String



    Public Property MailbagID() As String
        Get
            MailbagID = lMailbagID
        End Get
        Set(ByVal Value As String)
            lMailbagID = Value
        End Set
    End Property


    Public Property WKCYCLE_ID() As String
        Get
            WKCYCLE_ID = lWKCYCLE_ID
        End Get
        Set(ByVal Value As String)
            lWKCYCLE_ID = Value
        End Set
    End Property


    Public Property DCNAME() As String
        Get
            DCNAME = lDCNAME
        End Get
        Set(ByVal Value As String)
            lDCNAME = Value
        End Set
    End Property

    Public Property StoreID() As String
        Get
            StoreID = lStoreID
        End Get
        Set(ByVal Value As String)
            lStoreID = Value
        End Set
    End Property

    Public Property MailbagNumber() As String
        Get
            MailbagNumber = lMailbagNumber
        End Get
        Set(ByVal Value As String)
            lMailbagNumber = Value
        End Set
    End Property

    Public Property SealNo() As String
        Get
            SealNo = lSealNo
        End Get
        Set(ByVal Value As String)
            lSealNo = Value
        End Set
    End Property

    Public Property EnvelopeNo() As String
        Get
            EnvelopeNo = lEnvelopeNo
        End Get
        Set(ByVal Value As String)
            lEnvelopeNo = Value
        End Set
    End Property

    Public Property AppInform() As String
        Get
            AppInform = lAppInform
        End Get
        Set(ByVal Value As String)
            lAppInform = Value
        End Set
    End Property

   

    Public Property NoBarcodeApp() As String
        Get
            NoBarcodeApp = lNoBarcodeApp
        End Get
        Set(ByVal Value As String)
            lNoBarcodeApp = Value
        End Set
    End Property

    Public Property DateFrontLetter() As String
        Get
            DateFrontLetter = lDateFrontLetter
        End Get
        Set(ByVal Value As String)
            lDateFrontLetter = Value
        End Set
    End Property

    Public Function INSERTMAILBAG() As Boolean


        INSERTMAILBAG = False
        Dim sql As String
        sql = "INSERT INTO TBL_MAILBAG " & _
            "(WKCYCLE_ID, DCNAME, STOREID, MAILBAGNUMBER, SEALNO, " & _
            " ENVELOPENO, APPINFORM,  NOBARCODEAPP, DATEFRONTLETTER, " & _
            " CREATEDDATE, CREATEDBY, UPDATEDDATE, UPDATEBY  )" & _
            " VALUES( " & lWKCYCLE_ID & "  ,'" & lDCNAME & "' ," & lStoreID & ",'" & lMailbagNumber & "','" & lSealNo & "'," & _
            " '" & lEnvelopeNo & "','" & lAppInform & "','" & lNoBarcodeApp & "','" & lDateFrontLetter & "'," & _
            " getdate(),'" & cOfficer.Login & "', getdate(),'" & cOfficer.Login & "')"

        If cConnect.Execute(sql) = True Then
            INSERTMAILBAG = True
        Else
            Exit Function
        End If

    End Function

    Public Function UPDATEMAILBAG() As Boolean
        UPDATEMAILBAG = False
        Dim sql As String
        sql = "UPDATE    TBL_MAILBAG " & _
             " SET WKCYCLE_ID = " & lWKCYCLE_ID & "  , DCNAME = '" & lDCNAME & "' , " & _
             " STOREID = " & lStoreID & ", MAILBAGNUMBER = '" & lMailbagNumber & "', " & _
             " SEALNO = '" & lSealNo & "', ENVELOPENO = '" & lEnvelopeNo & "', " & _
             " APPINFORM = '" & lAppInform & "', NOBARCODEAPP = '" & lNoBarcodeApp & "', " & _
             " DATEFRONTLETTER = '" & lDateFrontLetter & "', UPDATEDDATE = GETDATE() , " & _
             " UPDATEBY = '" & cOfficer.Login & "'  " & _
             " WHERE  MAILBAG_ID = " & lMailbagID & "  "


        If cConnect.Execute(sql) = True Then
            UPDATEMAILBAG = True
        Else
            Exit Function
        End If

    End Function



    Public Function DELETEMAILBAG() As Boolean
        DELETEMAILBAG = False
        Dim sql As String
        sql = "DELETE  TBL_MAILBAG " & _
            " WHERE  MAILBAG_ID = " & lMailbagID & "  "

        If cConnect.Execute(sql) = True Then
            DELETEMAILBAG = True
        Else
            Exit Function
        End If

    End Function
    Public Function SELECTMAILBAG(ByRef pRs As Data.DataSet) As Boolean
        SELECTMAILBAG = False
        Dim sql As String
        pRs = New Data.DataSet


        sql = "SELECT     MAILBAG_ID, WKCYCLE_ID, DCNAME, STOREID, " & _
        " MAILBAGNUMBER, SEALNO, ENVELOPENO, APPINFORM,  NOBARCODEAPP, " & _
        " CONVERT(VARCHAR(10),DATEFRONTLETTER,20) " & _
        " FROM  TBL_MAILBAG "

        If lWKCYCLE_ID <> "" Then
            sql = sql & " WHERE WKCYCLE_ID = " & lWKCYCLE_ID & "  "
        End If

        If lDCNAME <> "" Then
            sql = sql & " AND DCNAME = '" & lDCNAME & "'  "
        End If

        If lStoreID <> "" Then
            sql = sql & "  AND STOREID= " & lStoreID & " "
        End If



        sql = sql & " ORDER BY WKCYCLE_ID, DCNAME, STOREID,       MAILBAGNUMBER, SEALNO, cast(ENVELOPENO as int) "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        SELECTMAILBAG = True


    End Function
    Public Function CHKDUPMAILBAG(ByRef pRs As Data.DataSet) As Boolean
        CHKDUPMAILBAG = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT     MAILBAG_ID, WKCYCLE_ID, DCNAME, STOREID, " & _
       " MAILBAGNUMBER, SEALNO, ENVELOPENO, APPINFORM,  NOBARCODEAPP, " & _
       " CONVERT(VARCHAR(10),DATEFRONTLETTER,20) " & _
       " FROM  TBL_MAILBAG "


        sql = sql & " WHERE (WKCYCLE_ID = " & lWKCYCLE_ID & " AND DCNAME = '" & lDCNAME & "' " & _
                    " AND STOREID =" & lStoreID & " AND MAILBAGNUMBER = '" & lMailbagNumber & "' AND ENVELOPENO = '" & lEnvelopeNo & "'  ) "



        If lMailbagID <> "" Then
            sql = sql & " AND MAILBAG_ID <> " & lMailbagID & " "
        End If
        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        CHKDUPMAILBAG = True


    End Function
    Public Function CHKUSEMAILBAG(ByRef pRs As Data.DataSet) As Boolean

        CHKUSEMAILBAG = False
        Dim sql As String
        pRs = New Data.DataSet

        sql = "SELECT * FROM TBL_MEMBER_CLUBCARD WHERE MAILBAG_ID = " & lMailbagID & " "

        If cConnect.OpenSql(sql, pRs) = False Then
            MsgBox("Error Searching!!")
            Exit Function
        End If


        CHKUSEMAILBAG = True


    End Function

End Class

