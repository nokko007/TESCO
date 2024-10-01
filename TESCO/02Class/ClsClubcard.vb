Public Class ClsClubcard
    Dim lMAILBAG_ID As String
    Dim lCLUBCARD_NO As String
    Dim lCustid As String
    Dim lname_1 As String
    Dim lname_2 As String
    Dim lidtype As String
    Dim lofficial_id As String
    Dim lprimary_card_account_number As String
    Dim lcard_account_number As String
    Dim lcustomer_use_status As String
    Dim lcustomer_mail_status As String
    Dim lfamily_member_1_gender_code As String
    Dim lfamily_member_1_dob As String
    Dim lfamily_member_2_gender_code As String
    Dim lfamily_member_3_gender_code As String
    Dim lfamily_member_4_gender_code As String
    Dim lfamily_member_5_gender_code As String
    Dim lfamily_member_6_gender_code As String
    Dim lfamily_member_2_dob As String
    Dim lfamily_member_3_dob As String
    Dim lfamily_member_4_dob As String
    Dim lfamily_member_5_dob As String
    Dim lfamily_member_6_dob As String
    Dim lHOMEid As String
    Dim lBUILDING_TYPE As String
    Dim lBUILDING As String
    Dim lROOM_NO As String
    Dim lFLOOR As String
    Dim lMOU As String
    Dim lSOI As String
    Dim lSTREET As String
    Dim lTUMBOL As String

    Dim laddress_line_1 As String
    Dim laddress_line_2 As String
    Dim laddress_line_3 As String
    Dim lcity As String
    Dim lprovince_code As String
    Dim lprovince As String
    Dim lcountry As String
    Dim lpostal_code As String
    Dim ldaytime_phone_number As String
    Dim levening_phone_number As String
    Dim lmobile_phone_number As String
    Dim lfax_number As String
    Dim lemail_address As String
    Dim lbusiness_name As String
    Dim lbusiness_registration_number As String
    Dim lbusiness_type_code As String
    Dim lbusiness_address_line_1 As String
    Dim lbusiness_address_line_2 As String
    Dim lbusiness_address_line_3 As String
    Dim lbusiness_address_line_4 As String
    Dim lbusiness_address_line_5 As String
    Dim lbusiness_address_line_6 As String
    Dim lbusiness_postal_code As String
    Dim lpreferred_store_code As String
    Dim ljoined_store_code As String
    Dim lpreferred_contact_type_code As String
    Dim ltitle_code As String
    Dim ltescogroup_mail_flag As String
    Dim ltescogroup_email_flag As String
    Dim ltescogroup_phone_flag As String
    Dim ltescogroup_sms_flag As String
    Dim lpartner_mail_flag As String
    Dim lpartner_email_flag As String
    Dim lpartner_phone_flag As String
    Dim lpartner_sms_flag As String
    Dim lresearch_mail_flag As String
    Dim lresearch_email_flag As String
    Dim lresearch_phone_flag As String
    Dim lresearch_sms_flag As String
    Dim ldiabetic_flag As String
    Dim lvegetarian_flag As String
    Dim lteetotal_flag As String
    Dim lhalal_flag As String
    Dim llactose_flag As String
    Dim lceliac_flag As String
    Dim lcustomer_created_date As String
    Dim lpreferred_mailing_address_flag As String
    Dim lrace_code As String
    Dim lnumber_of_household_members As String
    Dim lcard_member_name_nric As String
    Dim lcard_member_dob As String
    Dim lcard_member_gender_code As String
    Dim lexpat As String
    Dim lform_type As String
    Dim lADJUST_FLAG As String
    Dim lFlag As String



    Public Property MAILBAG_ID() As String
        Get
            MAILBAG_ID = lMAILBAG_ID
        End Get
        Set(ByVal Value As String)
            lMAILBAG_ID = Value
        End Set
    End Property


    Public Property CLUBCARD_NO() As String
        Get
            CLUBCARD_NO = lCLUBCARD_NO
        End Get
        Set(ByVal Value As String)
            lCLUBCARD_NO = Value
        End Set
    End Property




    Public Property custid() As String
        Get
            custid = lCustid
        End Get
        Set(ByVal Value As String)
            lCustid = Value
        End Set
    End Property


    Public Property name_1() As String
        Get
            name_1 = lname_1
        End Get
        Set(ByVal Value As String)
            lname_1 = Value
        End Set
    End Property


    Public Property name_2() As String
        Get
            name_2 = lname_2
        End Get
        Set(ByVal Value As String)
            lname_2 = Value
        End Set
    End Property


    Public Property idtype() As String
        Get
            idtype = lidtype
        End Get
        Set(ByVal Value As String)
            lidtype = Value
        End Set
    End Property

    Public Property official_id() As String
        Get
            official_id = lofficial_id
        End Get
        Set(ByVal Value As String)
            lofficial_id = Value
        End Set
    End Property


    Public Property primary_card_account_number() As String
        Get
            primary_card_account_number = lprimary_card_account_number
        End Get
        Set(ByVal Value As String)
            lprimary_card_account_number = Value
        End Set
    End Property


    Public Property card_account_number() As String
        Get
            card_account_number = lcard_account_number
        End Get
        Set(ByVal Value As String)
            lcard_account_number = Value
        End Set
    End Property


    Public Property customer_use_status() As String
        Get
            customer_use_status = lcustomer_use_status
        End Get
        Set(ByVal Value As String)
            lcustomer_use_status = Value
        End Set
    End Property


    Public Property customer_mail_status() As String
        Get
            customer_mail_status = lcustomer_mail_status
        End Get
        Set(ByVal Value As String)
            lcustomer_mail_status = Value
        End Set
    End Property


    Public Property family_member_1_gender_code() As String
        Get
            family_member_1_gender_code = lfamily_member_1_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_1_gender_code = Value
        End Set
    End Property


    Public Property family_member_1_dob() As String
        Get
            family_member_1_dob = lfamily_member_1_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_1_dob = Value
        End Set
    End Property


    Public Property family_member_2_gender_code() As String
        Get
            family_member_2_gender_code = lfamily_member_2_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_2_gender_code = Value
        End Set
    End Property


    Public Property family_member_3_gender_code() As String
        Get
            family_member_3_gender_code = lfamily_member_3_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_3_gender_code = Value
        End Set
    End Property


    Public Property family_member_4_gender_code() As String
        Get
            family_member_4_gender_code = lfamily_member_4_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_4_gender_code = Value
        End Set
    End Property


    Public Property family_member_5_gender_code() As String
        Get
            family_member_5_gender_code = lfamily_member_5_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_5_gender_code = Value
        End Set
    End Property


    Public Property family_member_6_gender_code() As String
        Get
            family_member_6_gender_code = lfamily_member_6_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_6_gender_code = Value
        End Set
    End Property


    Public Property family_member_2_dob() As String
        Get
            family_member_2_dob = lfamily_member_2_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_2_dob = Value
        End Set
    End Property


    Public Property family_member_3_dob() As String
        Get
            family_member_3_dob = lfamily_member_3_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_3_dob = Value
        End Set
    End Property


    Public Property family_member_4_dob() As String
        Get
            family_member_4_dob = lfamily_member_4_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_4_dob = Value
        End Set
    End Property


    Public Property family_member_5_dob() As String
        Get
            family_member_5_dob = lfamily_member_5_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_5_dob = Value
        End Set
    End Property


    Public Property family_member_6_dob() As String
        Get
            family_member_6_dob = lfamily_member_6_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_6_dob = Value
        End Set
    End Property


    Public Property HOMEID() As String
        Get
            HOMEID = lHOMEid
        End Get
        Set(ByVal Value As String)
            lHOMEid = Value
        End Set
    End Property




    Public Property BUILDING_TYPE() As String
        Get
            BUILDING_TYPE = lBUILDING_TYPE
        End Get
        Set(ByVal Value As String)
            lBUILDING_TYPE = Value
        End Set
    End Property


    Public Property BUILDING() As String
        Get
            BUILDING = lBUILDING
        End Get
        Set(ByVal Value As String)
            lBUILDING = Value
        End Set
    End Property



    Public Property ROOM_NO() As String
        Get
            ROOM_NO = lROOM_NO
        End Get
        Set(ByVal Value As String)
            lROOM_NO = Value
        End Set
    End Property





    Public Property FLOOR() As String
        Get
            FLOOR = lFLOOR
        End Get
        Set(ByVal Value As String)
            lFLOOR = Value
        End Set
    End Property




    Public Property MOU() As String
        Get
            MOU = lMOU
        End Get
        Set(ByVal Value As String)
            lMOU = Value
        End Set
    End Property




    Public Property SOI() As String
        Get
            SOI = lSOI
        End Get
        Set(ByVal Value As String)
            lSOI = Value
        End Set
    End Property



    Public Property STREET() As String
        Get
            STREET = lSTREET
        End Get
        Set(ByVal Value As String)
            lSTREET = Value
        End Set
    End Property

    Public Property TUMBOL() As String
        Get
            TUMBOL = lTUMBOL
        End Get
        Set(ByVal Value As String)
            lTUMBOL = Value
        End Set
    End Property


    Public Property address_line_1() As String
        Get
            address_line_1 = laddress_line_1
        End Get
        Set(ByVal Value As String)
            laddress_line_1 = Value
        End Set
    End Property


    Public Property address_line_2() As String
        Get
            address_line_2 = laddress_line_2
        End Get
        Set(ByVal Value As String)
            laddress_line_2 = Value
        End Set
    End Property


    Public Property address_line_3() As String
        Get
            address_line_3 = laddress_line_3
        End Get
        Set(ByVal Value As String)
            laddress_line_3 = Value
        End Set
    End Property


    Public Property city() As String
        Get
            city = lcity
        End Get
        Set(ByVal Value As String)
            lcity = Value
        End Set
    End Property


    Public Property province_code() As String
        Get
            province_code = lprovince_code
        End Get
        Set(ByVal Value As String)
            lprovince_code = Value
        End Set
    End Property

    Public Property province() As String
        Get
            province = lprovince
        End Get
        Set(ByVal Value As String)
            lprovince = Value
        End Set
    End Property

    Public Property country() As String
        Get
            country = lcountry
        End Get
        Set(ByVal Value As String)
            lcountry = Value
        End Set
    End Property


    Public Property postal_code() As String
        Get
            postal_code = lpostal_code
        End Get
        Set(ByVal Value As String)
            lpostal_code = Value
        End Set
    End Property


    Public Property daytime_phone_number() As String
        Get
            daytime_phone_number = ldaytime_phone_number
        End Get
        Set(ByVal Value As String)
            ldaytime_phone_number = Value
        End Set
    End Property


    Public Property evening_phone_number() As String
        Get
            evening_phone_number = levening_phone_number
        End Get
        Set(ByVal Value As String)
            levening_phone_number = Value
        End Set
    End Property


    Public Property mobile_phone_number() As String
        Get
            mobile_phone_number = lmobile_phone_number
        End Get
        Set(ByVal Value As String)
            lmobile_phone_number = Value
        End Set
    End Property


    Public Property fax_number() As String
        Get
            fax_number = lfax_number
        End Get
        Set(ByVal Value As String)
            lfax_number = Value
        End Set
    End Property


    Public Property email_address() As String
        Get
            email_address = lemail_address
        End Get
        Set(ByVal Value As String)
            lemail_address = Value
        End Set
    End Property


    Public Property business_name() As String
        Get
            business_name = lbusiness_name
        End Get
        Set(ByVal Value As String)
            lbusiness_name = Value
        End Set
    End Property


    Public Property business_registration_number() As String
        Get
            business_registration_number = lbusiness_registration_number
        End Get
        Set(ByVal Value As String)
            lbusiness_registration_number = Value
        End Set
    End Property


    Public Property business_type_code() As String
        Get
            business_type_code = lbusiness_type_code
        End Get
        Set(ByVal Value As String)
            lbusiness_type_code = Value
        End Set
    End Property


    Public Property business_address_line_1() As String
        Get
            business_address_line_1 = lbusiness_address_line_1
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_1 = Value
        End Set
    End Property


    Public Property business_address_line_2() As String
        Get
            business_address_line_2 = lbusiness_address_line_2
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_2 = Value
        End Set
    End Property


    Public Property business_address_line_3() As String
        Get
            business_address_line_3 = lbusiness_address_line_3
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_3 = Value
        End Set
    End Property


    Public Property business_address_line_4() As String
        Get
            business_address_line_4 = lbusiness_address_line_4
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_4 = Value
        End Set
    End Property


    Public Property business_address_line_5() As String
        Get
            business_address_line_5 = lbusiness_address_line_5
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_5 = Value
        End Set
    End Property
    Public Property business_address_line_6() As String
        Get
            business_address_line_6 = lbusiness_address_line_6
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_6 = Value
        End Set
    End Property

    Public Property business_postal_code() As String
        Get
            business_postal_code = lbusiness_postal_code
        End Get
        Set(ByVal Value As String)
            lbusiness_postal_code = Value
        End Set
    End Property


    Public Property preferred_store_code() As String
        Get
            preferred_store_code = lpreferred_store_code
        End Get
        Set(ByVal Value As String)
            lpreferred_store_code = Value
        End Set
    End Property


    Public Property joined_store_code() As String
        Get
            joined_store_code = ljoined_store_code
        End Get
        Set(ByVal Value As String)
            ljoined_store_code = Value
        End Set
    End Property


    Public Property preferred_contact_type_code() As String
        Get
            preferred_contact_type_code = lpreferred_contact_type_code
        End Get
        Set(ByVal Value As String)
            lpreferred_contact_type_code = Value
        End Set
    End Property


    Public Property title_code() As String
        Get
            title_code = ltitle_code
        End Get
        Set(ByVal Value As String)
            ltitle_code = Value
        End Set
    End Property


    Public Property tescogroup_mail_flag() As String
        Get
            tescogroup_mail_flag = ltescogroup_mail_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_mail_flag = Value
        End Set
    End Property


    Public Property tescogroup_email_flag() As String
        Get
            tescogroup_email_flag = ltescogroup_email_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_email_flag = Value
        End Set
    End Property


    Public Property tescogroup_phone_flag() As String
        Get
            tescogroup_phone_flag = ltescogroup_phone_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_phone_flag = Value
        End Set
    End Property


    Public Property tescogroup_sms_flag() As String
        Get
            tescogroup_sms_flag = ltescogroup_sms_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_sms_flag = Value
        End Set
    End Property


    Public Property partner_mail_flag() As String
        Get
            partner_mail_flag = lpartner_mail_flag
        End Get
        Set(ByVal Value As String)
            lpartner_mail_flag = Value
        End Set
    End Property


    Public Property partner_email_flag() As String
        Get
            partner_email_flag = lpartner_email_flag
        End Get
        Set(ByVal Value As String)
            lpartner_email_flag = Value
        End Set
    End Property


    Public Property partner_phone_flag() As String
        Get
            partner_phone_flag = lpartner_phone_flag
        End Get
        Set(ByVal Value As String)
            lpartner_phone_flag = Value
        End Set
    End Property


    Public Property partner_sms_flag() As String
        Get
            partner_sms_flag = lpartner_sms_flag
        End Get
        Set(ByVal Value As String)
            lpartner_sms_flag = Value
        End Set
    End Property


    Public Property research_mail_flag() As String
        Get
            research_mail_flag = lresearch_mail_flag
        End Get
        Set(ByVal Value As String)
            lresearch_mail_flag = Value
        End Set
    End Property


    Public Property research_email_flag() As String
        Get
            research_email_flag = lresearch_email_flag
        End Get
        Set(ByVal Value As String)
            lresearch_email_flag = Value
        End Set
    End Property


    Public Property research_phone_flag() As String
        Get
            research_phone_flag = lresearch_phone_flag
        End Get
        Set(ByVal Value As String)
            lresearch_phone_flag = Value
        End Set
    End Property


    Public Property research_sms_flag() As String
        Get
            research_sms_flag = lresearch_sms_flag
        End Get
        Set(ByVal Value As String)
            lresearch_sms_flag = Value
        End Set
    End Property


    Public Property diabetic_flag() As String
        Get
            diabetic_flag = ldiabetic_flag
        End Get
        Set(ByVal Value As String)
            ldiabetic_flag = Value
        End Set
    End Property


    Public Property vegetarian_flag() As String
        Get
            vegetarian_flag = lvegetarian_flag
        End Get
        Set(ByVal Value As String)
            lvegetarian_flag = Value
        End Set
    End Property


    Public Property teetotal_flag() As String
        Get
            teetotal_flag = lteetotal_flag
        End Get
        Set(ByVal Value As String)
            lteetotal_flag = Value
        End Set
    End Property


    Public Property halal_flag() As String
        Get
            halal_flag = lhalal_flag
        End Get
        Set(ByVal Value As String)
            lhalal_flag = Value
        End Set
    End Property


    Public Property lactose_flag() As String
        Get
            lactose_flag = llactose_flag
        End Get
        Set(ByVal Value As String)
            llactose_flag = Value
        End Set
    End Property


    Public Property celiac_flag() As String
        Get
            celiac_flag = lceliac_flag
        End Get
        Set(ByVal Value As String)
            lceliac_flag = Value
        End Set
    End Property


    Public Property customer_created_date() As String
        Get
            customer_created_date = lcustomer_created_date
        End Get
        Set(ByVal Value As String)
            lcustomer_created_date = Value
        End Set
    End Property


    Public Property preferred_mailing_address_flag() As String
        Get
            preferred_mailing_address_flag = lpreferred_mailing_address_flag
        End Get
        Set(ByVal Value As String)
            lpreferred_mailing_address_flag = Value
        End Set
    End Property


    Public Property race_code() As String
        Get
            race_code = lrace_code
        End Get
        Set(ByVal Value As String)
            lrace_code = Value
        End Set
    End Property


    Public Property number_of_household_members() As String
        Get
            number_of_household_members = lnumber_of_household_members
        End Get
        Set(ByVal Value As String)
            lnumber_of_household_members = Value
        End Set
    End Property


    Public Property card_member_name_nric() As String
        Get
            card_member_name_nric = lcard_member_name_nric
        End Get
        Set(ByVal Value As String)
            lcard_member_name_nric = Value
        End Set
    End Property


    Public Property card_member_dob() As String
        Get
            card_member_dob = lcard_member_dob
        End Get
        Set(ByVal Value As String)
            lcard_member_dob = Value
        End Set
    End Property


    Public Property card_member_gender_code() As String
        Get
            card_member_gender_code = lcard_member_gender_code
        End Get
        Set(ByVal Value As String)
            lcard_member_gender_code = Value
        End Set
    End Property


    Public Property expat() As String
        Get
            expat = lexpat
        End Get
        Set(ByVal Value As String)
            lexpat = Value
        End Set
    End Property


    Public Property form_type() As String
        Get
            form_type = lform_type
        End Get
        Set(ByVal Value As String)
            lform_type = Value
        End Set
    End Property


    Public Property Flag() As String
        Get
            Flag = lFlag
        End Get
        Set(ByVal Value As String)
            lFlag = Value
        End Set

    End Property
    Public Property ADJUST_FLAG() As String
        Get
            ADJUST_FLAG = lADJUST_FLAG
        End Get
        Set(ByVal Value As String)
            lADJUST_FLAG = Value
        End Set
    End Property

    Public Function InsertNewClubcard() As Boolean

        InsertNewClubcard = False
        Dim sql As String
 
        sql = " INSERT INTO TBL_MEMBER_CLUBCARD  " & _
                " ( MAILBAG_ID, CLUBCARD_NO,  CUSTOMER_USE_STATUS, " & _
                " CUSTOMER_MAIL_STATUS, JOINED_STORE_CODE,PREFERRED_STORE_CODE, " & _
                "  CUSTOMER_CREATED_DATE ,  " & _
                " FLAG, COUNTING_EMPLOYEEID,  " & _
                " COUNTING_DATE ) " & _
                            " VALUES      " & _
                        " ( '" & cClubcard.MAILBAG_ID & "' ,  " & _
                        "  '" & cClubcard.CLUBCARD_NO & "' ,  " & _
                        "  '" & cClubcard.customer_use_status & "' ,  " & _
                        "  '" & cClubcard.customer_mail_status & "' ,  " & _
                        "  '" & cClubcard.joined_store_code & "' ,  " & _
                        "  '" & cClubcard.preferred_store_code & "' ,  " & _
                        "  '" & cClubcard.customer_created_date & "' ,  " & _
                        "  '" & cClubcard.Flag & "' ,  " & _
                        "  '" & cOfficer.LOGINNAME & "' ,  " & _
                        "  getdate()  )  "
        If cConnect.Execute(sql) = True Then
            InsertNewClubcard = True
        Else
            InsertNewClubcard = False

        End If
    End Function

   
    Public Function UpdateKEYINClubcard() As Boolean

        UpdateKEYINClubcard = False
        Dim sql As String
        With cClubcard
            sql = " UPDATE    TBL_MEMBER_CLUBCARD " & _
                " SET   NAME_1 =  '" & .name_1 & "' , " & _
                " NAME_2 ='" & .name_2 & "', " & _
                " IDTYPE ='" & .idtype & "', " & _
                " OFFICIAL_ID ='" & .official_id & "', " & _
                " PRIMARY_CARD_ACCOUNT_NUMBER ='" & .primary_card_account_number & "', " & _
                " CARD_ACCOUNT_NUMBER ='" & .card_account_number & "', " & _
                " FAMILY_MEMBER_1_GENDER_CODE ='" & .family_member_1_gender_code & "', " & _
                " FAMILY_MEMBER_1_DOB ='" & .family_member_1_dob & "', " & _
                " FAMILY_MEMBER_2_DOB ='" & .family_member_2_dob & "', " & _
                " FAMILY_MEMBER_3_DOB ='" & .family_member_3_dob & "', " & _
                " FAMILY_MEMBER_4_DOB ='" & .family_member_4_dob & "', " & _
                " FAMILY_MEMBER_5_DOB ='" & .family_member_5_dob & "', " & _
                " HOME_ID ='" & .HOMEID & "', " & _
                " BUILDING_TYPE ='" & .BUILDING_TYPE & "', " & _
                " BUILDING ='" & .BUILDING & "', " & _
                " ROOM_NO ='" & .ROOM_NO & "', " & _
                " FLOOR ='" & .FLOOR & "', " & _
                " MOU ='" & .MOU & "', " & _
                " SOI ='" & .SOI & "', " & _
                " STREET ='" & .STREET & "', " & _
                " TUMBOL ='" & .TUMBOL & "', " & _
                " CITY ='" & .city & "', " & _
                " PROVINCE_CODE ='" & .province_code & "', " & _
                " PROVINCE ='" & .province & "', " & _
                " COUNTRY ='" & .country & "', " & _
                " POSTAL_CODE ='" & .postal_code & "', " & _
                " DAYTIME_PHONE_NUMBER ='" & .daytime_phone_number & "', " & _
                " EVENING_PHONE_NUMBER ='" & .evening_phone_number & "', " & _
                " MOBILE_PHONE_NUMBER ='" & .mobile_phone_number & "', " & _
                " EMAIL_ADDRESS ='" & .email_address & "', " & _
                " BUSINESS_TYPE_CODE ='" & .business_type_code & "', " & _
                " TITLE_CODE ='" & .title_code & "', " & _
                " RACE_CODE ='" & .race_code & "', " & _
                " NUMBER_OF_HOUSEHOLD_MEMBERS ='" & .number_of_household_members & "', " & _
                " EXPAT ='" & .expat & "', " & _
                " FORM_TYPE ='" & .form_type & "', " & _
                " FLAG ='" & .Flag & "', " & _
                " KEYIN_EMPLOYEEID ='" & cOfficer.Login & "', " & _
                " KEYIN_DATE = GETDATE()," & _
                " ADJUST_FLAG = '" & .ADJUST_FLAG & "' " & _
                " WHERE CUSTID = " & .custid & "  AND FLAG= 'NEW' "

        End With
        If cConnect.Execute(sql) = True Then
            UpdateKEYINClubcard = True
        Else
            UpdateKEYINClubcard = False

        End If
    End Function
    Public Function EditKEYINClubcard() As Boolean

        EditKEYINClubcard = False
        Dim sql As String
        With cClubcard
            sql = " UPDATE    TBL_MEMBER_CLUBCARD " & _
                " SET   NAME_1 =  '" & .name_1 & "' , " & _
                " NAME_2 ='" & .name_2 & "', " & _
                " IDTYPE ='" & .idtype & "', " & _
                " OFFICIAL_ID ='" & .official_id & "', " & _
                " PRIMARY_CARD_ACCOUNT_NUMBER ='" & .primary_card_account_number & "', " & _
                " CARD_ACCOUNT_NUMBER ='" & .card_account_number & "', " & _
                " FAMILY_MEMBER_1_GENDER_CODE ='" & .family_member_1_gender_code & "', " & _
                " FAMILY_MEMBER_1_DOB ='" & .family_member_1_dob & "', " & _
                " FAMILY_MEMBER_2_DOB ='" & .family_member_2_dob & "', " & _
                " FAMILY_MEMBER_3_DOB ='" & .family_member_3_dob & "', " & _
                " FAMILY_MEMBER_4_DOB ='" & .family_member_4_dob & "', " & _
                " FAMILY_MEMBER_5_DOB ='" & .family_member_5_dob & "', " & _
                " HOME_ID ='" & .HOMEID & "', " & _
                " BUILDING_TYPE ='" & .BUILDING_TYPE & "', " & _
                " BUILDING ='" & .BUILDING & "', " & _
                " ROOM_NO ='" & .ROOM_NO & "', " & _
                " FLOOR ='" & .FLOOR & "', " & _
                " MOU ='" & .MOU & "', " & _
                " SOI ='" & .SOI & "', " & _
                " STREET ='" & .STREET & "', " & _
                " TUMBOL ='" & .TUMBOL & "', " & _
                " CITY ='" & .city & "', " & _
                " PROVINCE_CODE ='" & .province_code & "', " & _
                " PROVINCE ='" & .province & "', " & _
                " COUNTRY ='" & .country & "', " & _
                " POSTAL_CODE ='" & .postal_code & "', " & _
                " DAYTIME_PHONE_NUMBER ='" & .daytime_phone_number & "', " & _
                " EVENING_PHONE_NUMBER ='" & .evening_phone_number & "', " & _
                " MOBILE_PHONE_NUMBER ='" & .mobile_phone_number & "', " & _
                " EMAIL_ADDRESS ='" & .email_address & "', " & _
                " BUSINESS_TYPE_CODE ='" & .business_type_code & "', " & _
                " TITLE_CODE ='" & .title_code & "', " & _
                " RACE_CODE ='" & .race_code & "', " & _
                " NUMBER_OF_HOUSEHOLD_MEMBERS ='" & .number_of_household_members & "', " & _
                " EXPAT ='" & .expat & "', " & _
                " FORM_TYPE ='" & .form_type & "', " & _
                " FLAG ='" & .Flag & "', " & _
                " KEYIN_EMPLOYEEID ='" & cOfficer.Login & "', " & _
                " ADJUST_FLAG = '" & .ADJUST_FLAG & "' " & _
                " WHERE CUSTID = " & .custid & "  AND FLAG= 'KEYIN' "

        End With
        If cConnect.Execute(sql) = True Then
            EditKEYINClubcard = True
        Else
            EditKEYINClubcard = False

        End If
    End Function


    Public Function UpdateQCClubcard() As Boolean

        UpdateQCClubcard = False
        Dim sql As String
        With cClubcard
            sql = " UPDATE    TBL_MEMBER_CLUBCARD " & _
                " SET   NAME_1 =  '" & .name_1 & "' , " & _
                " NAME_2 ='" & .name_2 & "', " & _
                " IDTYPE ='" & .idtype & "', " & _
                " OFFICIAL_ID ='" & .official_id & "', " & _
                " PRIMARY_CARD_ACCOUNT_NUMBER ='" & .primary_card_account_number & "', " & _
                " CARD_ACCOUNT_NUMBER ='" & .card_account_number & "', " & _
                " FAMILY_MEMBER_1_GENDER_CODE ='" & .family_member_1_gender_code & "', " & _
                " FAMILY_MEMBER_1_DOB ='" & .family_member_1_dob & "', " & _
                " FAMILY_MEMBER_2_DOB ='" & .family_member_2_dob & "', " & _
                " FAMILY_MEMBER_3_DOB ='" & .family_member_3_dob & "', " & _
                " FAMILY_MEMBER_4_DOB ='" & .family_member_4_dob & "', " & _
                " FAMILY_MEMBER_5_DOB ='" & .family_member_5_dob & "', " & _
                " HOME_ID ='" & .HOMEID & "', " & _
                " BUILDING_TYPE ='" & .BUILDING_TYPE & "', " & _
                " BUILDING ='" & .BUILDING & "', " & _
                " ROOM_NO ='" & .ROOM_NO & "', " & _
                " FLOOR ='" & .FLOOR & "', " & _
                " MOU ='" & .MOU & "', " & _
                " SOI ='" & .SOI & "', " & _
                " STREET ='" & .STREET & "', " & _
                " TUMBOL ='" & .TUMBOL & "', " & _
                " CITY ='" & .city & "', " & _
                " PROVINCE_CODE ='" & .province_code & "', " & _
                " PROVINCE ='" & .province & "', " & _
                " COUNTRY ='" & .country & "', " & _
                " POSTAL_CODE ='" & .postal_code & "', " & _
                " DAYTIME_PHONE_NUMBER ='" & .daytime_phone_number & "', " & _
                " EVENING_PHONE_NUMBER ='" & .evening_phone_number & "', " & _
                " MOBILE_PHONE_NUMBER ='" & .mobile_phone_number & "', " & _
                " EMAIL_ADDRESS ='" & .email_address & "', " & _
                " BUSINESS_TYPE_CODE ='" & .business_type_code & "', " & _
                " TITLE_CODE ='" & .title_code & "', " & _
                " RACE_CODE ='" & .race_code & "', " & _
                " NUMBER_OF_HOUSEHOLD_MEMBERS ='" & .number_of_household_members & "', " & _
                " EXPAT ='" & .expat & "', " & _
                " FORM_TYPE ='" & .form_type & "', " & _
                " FLAG ='" & .Flag & "', " & _
                " QC_EMPLOYEEID ='" & cOfficer.Login & "', " & _
                " QC_DATE = GETDATE()," & _
                " ADJUST_FLAG = '" & .ADJUST_FLAG & "' " & _
                " WHERE CUSTID = " & .custid & "  AND FLAG= 'KEYIN' "

        End With
        If cConnect.Execute(sql) = True Then
            UpdateQCClubcard = True
        Else
            UpdateQCClubcard = False

        End If
    End Function
    Public Function EditQCClubcard() As Boolean

        EditQCClubcard = False
        Dim sql As String
        With cClubcard
            sql = " UPDATE    TBL_MEMBER_CLUBCARD " & _
                " SET   NAME_1 =  '" & .name_1 & "' , " & _
                " NAME_2 ='" & .name_2 & "', " & _
                " IDTYPE ='" & .idtype & "', " & _
                " OFFICIAL_ID ='" & .official_id & "', " & _
                " PRIMARY_CARD_ACCOUNT_NUMBER ='" & .primary_card_account_number & "', " & _
                " CARD_ACCOUNT_NUMBER ='" & .card_account_number & "', " & _
                " FAMILY_MEMBER_1_GENDER_CODE ='" & .family_member_1_gender_code & "', " & _
                " FAMILY_MEMBER_1_DOB ='" & .family_member_1_dob & "', " & _
                " FAMILY_MEMBER_2_DOB ='" & .family_member_2_dob & "', " & _
                " FAMILY_MEMBER_3_DOB ='" & .family_member_3_dob & "', " & _
                " FAMILY_MEMBER_4_DOB ='" & .family_member_4_dob & "', " & _
                " FAMILY_MEMBER_5_DOB ='" & .family_member_5_dob & "', " & _
                " HOME_ID ='" & .HOMEID & "', " & _
                " BUILDING_TYPE ='" & .BUILDING_TYPE & "', " & _
                " BUILDING ='" & .BUILDING & "', " & _
                " ROOM_NO ='" & .ROOM_NO & "', " & _
                " FLOOR ='" & .FLOOR & "', " & _
                " MOU ='" & .MOU & "', " & _
                " SOI ='" & .SOI & "', " & _
                " STREET ='" & .STREET & "', " & _
                " TUMBOL ='" & .TUMBOL & "', " & _
                " CITY ='" & .city & "', " & _
                " PROVINCE_CODE ='" & .province_code & "', " & _
                " PROVINCE ='" & .province & "', " & _
                " COUNTRY ='" & .country & "', " & _
                " POSTAL_CODE ='" & .postal_code & "', " & _
                " DAYTIME_PHONE_NUMBER ='" & .daytime_phone_number & "', " & _
                " EVENING_PHONE_NUMBER ='" & .evening_phone_number & "', " & _
                " MOBILE_PHONE_NUMBER ='" & .mobile_phone_number & "', " & _
                " EMAIL_ADDRESS ='" & .email_address & "', " & _
                " BUSINESS_TYPE_CODE ='" & .business_type_code & "', " & _
                " TITLE_CODE ='" & .title_code & "', " & _
                " RACE_CODE ='" & .race_code & "', " & _
                " NUMBER_OF_HOUSEHOLD_MEMBERS ='" & .number_of_household_members & "', " & _
                " EXPAT ='" & .expat & "', " & _
                " FORM_TYPE ='" & .form_type & "', " & _
                " FLAG ='" & .Flag & "', " & _
                " QC_EMPLOYEEID ='" & cOfficer.Login & "', " & _
                " ADJUST_FLAG = '" & .ADJUST_FLAG & "' " & _
                " WHERE CUSTID = " & .custid & "  AND FLAG= 'QC' "

        End With
        If cConnect.Execute(sql) = True Then
            EditQCClubcard = True
        Else
            EditQCClubcard = False

        End If
    End Function
    Public Function KeepHistory() As Boolean

        KeepHistory = False
        Dim sql As String
        With cClubcard
            sql = " INSERT INTO TBL_MEMBER_CLUBCARD_HISTORY  (CUSTID, MAILBAG_ID, CLUBCARD_NO, NAME_1, NAME_2, IDTYPE, OFFICIAL_ID, PRIMARY_CARD_ACCOUNT_NUMBER, CARD_ACCOUNT_NUMBER, " & _
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
                    " COUNTING_DATE, KEYIN_EMPLOYEEID, KEYIN_DATE, QC_EMPLOYEEID, QC_DATE, SUBMIT_EMPLOYEEID, SUBMIT_DATE, SUBMIT_FLAG, ADJUST_FLAG,VERSION_DATE)  " & _
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
                    " COUNTING_DATE, KEYIN_EMPLOYEEID, KEYIN_DATE,  QC_EMPLOYEEID, QC_DATE, SUBMIT_EMPLOYEEID,SUBMIT_DATE, SUBMIT_FLAG, ADJUST_FLAG ,getdate() " & _
                    " FROM         TBL_MEMBER_CLUBCARD  " & _
                    " WHERE CUSTID = " & .custid & "   "

        End With
        If cConnect.Execute(sql) = True Then
            KeepHistory = True
        Else
            KeepHistory = False

        End If
    End Function
End Class
