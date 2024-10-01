Public Class ClsXML

    Dim lname_1 As String
    Dim lname_2 As String
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
    Dim laddress_line_1 As String
    Dim laddress_line_2 As String
    Dim laddress_line_3 As String
    Dim lcity As String
    Dim lprovince_code As String
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


    Public Property name_1() As String
        Get
            name_1 = lname_1
        End Get
        Set(ByVal Value As String)
            lname_1 = value
        End Set
    End Property


    Public Property name_2() As String
        Get
            name_2 = lname_2
        End Get
        Set(ByVal Value As String)
            lname_2 = value
        End Set
    End Property


    Public Property official_id() As String
        Get
            official_id = lofficial_id
        End Get
        Set(ByVal Value As String)
            lofficial_id = value
        End Set
    End Property


    Public Property primary_card_account_number() As String
        Get
            primary_card_account_number = lprimary_card_account_number
        End Get
        Set(ByVal Value As String)
            lprimary_card_account_number = value
        End Set
    End Property


    Public Property card_account_number() As String
        Get
            card_account_number = lcard_account_number
        End Get
        Set(ByVal Value As String)
            lcard_account_number = value
        End Set
    End Property


    Public Property customer_use_status() As String
        Get
            customer_use_status = lcustomer_use_status
        End Get
        Set(ByVal Value As String)
            lcustomer_use_status = value
        End Set
    End Property


    Public Property customer_mail_status() As String
        Get
            customer_mail_status = lcustomer_mail_status
        End Get
        Set(ByVal Value As String)
            lcustomer_mail_status = value
        End Set
    End Property


    Public Property family_member_1_gender_code() As String
        Get
            family_member_1_gender_code = lfamily_member_1_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_1_gender_code = value
        End Set
    End Property


    Public Property family_member_1_dob() As String
        Get
            family_member_1_dob = lfamily_member_1_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_1_dob = value
        End Set
    End Property


    Public Property family_member_2_gender_code() As String
        Get
            family_member_2_gender_code = lfamily_member_2_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_2_gender_code = value
        End Set
    End Property


    Public Property family_member_3_gender_code() As String
        Get
            family_member_3_gender_code = lfamily_member_3_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_3_gender_code = value
        End Set
    End Property


    Public Property family_member_4_gender_code() As String
        Get
            family_member_4_gender_code = lfamily_member_4_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_4_gender_code = value
        End Set
    End Property


    Public Property family_member_5_gender_code() As String
        Get
            family_member_5_gender_code = lfamily_member_5_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_5_gender_code = value
        End Set
    End Property


    Public Property family_member_6_gender_code() As String
        Get
            family_member_6_gender_code = lfamily_member_6_gender_code
        End Get
        Set(ByVal Value As String)
            lfamily_member_6_gender_code = value
        End Set
    End Property


    Public Property family_member_2_dob() As String
        Get
            family_member_2_dob = lfamily_member_2_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_2_dob = value
        End Set
    End Property


    Public Property family_member_3_dob() As String
        Get
            family_member_3_dob = lfamily_member_3_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_3_dob = value
        End Set
    End Property


    Public Property family_member_4_dob() As String
        Get
            family_member_4_dob = lfamily_member_4_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_4_dob = value
        End Set
    End Property


    Public Property family_member_5_dob() As String
        Get
            family_member_5_dob = lfamily_member_5_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_5_dob = value
        End Set
    End Property


    Public Property family_member_6_dob() As String
        Get
            family_member_6_dob = lfamily_member_6_dob
        End Get
        Set(ByVal Value As String)
            lfamily_member_6_dob = value
        End Set
    End Property


    Public Property address_line_1() As String
        Get
            address_line_1 = laddress_line_1
        End Get
        Set(ByVal Value As String)
            laddress_line_1 = value
        End Set
    End Property


    Public Property address_line_2() As String
        Get
            address_line_2 = laddress_line_2
        End Get
        Set(ByVal Value As String)
            laddress_line_2 = value
        End Set
    End Property


    Public Property address_line_3() As String
        Get
            address_line_3 = laddress_line_3
        End Get
        Set(ByVal Value As String)
            laddress_line_3 = value
        End Set
    End Property


    Public Property city() As String
        Get
            city = lcity
        End Get
        Set(ByVal Value As String)
            lcity = value
        End Set
    End Property


    Public Property province_code() As String
        Get
            province_code = lprovince_code
        End Get
        Set(ByVal Value As String)
            lprovince_code = value
        End Set
    End Property


    Public Property country() As String
        Get
            country = lcountry
        End Get
        Set(ByVal Value As String)
            lcountry = value
        End Set
    End Property


    Public Property postal_code() As String
        Get
            postal_code = lpostal_code
        End Get
        Set(ByVal Value As String)
            lpostal_code = value
        End Set
    End Property


    Public Property daytime_phone_number() As String
        Get
            daytime_phone_number = ldaytime_phone_number
        End Get
        Set(ByVal Value As String)
            ldaytime_phone_number = value
        End Set
    End Property


    Public Property evening_phone_number() As String
        Get
            evening_phone_number = levening_phone_number
        End Get
        Set(ByVal Value As String)
            levening_phone_number = value
        End Set
    End Property


    Public Property mobile_phone_number() As String
        Get
            mobile_phone_number = lmobile_phone_number
        End Get
        Set(ByVal Value As String)
            lmobile_phone_number = value
        End Set
    End Property


    Public Property fax_number() As String
        Get
            fax_number = lfax_number
        End Get
        Set(ByVal Value As String)
            lfax_number = value
        End Set
    End Property


    Public Property email_address() As String
        Get
            email_address = lemail_address
        End Get
        Set(ByVal Value As String)
            lemail_address = value
        End Set
    End Property


    Public Property business_name() As String
        Get
            business_name = lbusiness_name
        End Get
        Set(ByVal Value As String)
            lbusiness_name = value
        End Set
    End Property


    Public Property business_registration_number() As String
        Get
            business_registration_number = lbusiness_registration_number
        End Get
        Set(ByVal Value As String)
            lbusiness_registration_number = value
        End Set
    End Property


    Public Property business_type_code() As String
        Get
            business_type_code = lbusiness_type_code
        End Get
        Set(ByVal Value As String)
            lbusiness_type_code = value
        End Set
    End Property


    Public Property business_address_line_1() As String
        Get
            business_address_line_1 = lbusiness_address_line_1
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_1 = value
        End Set
    End Property


    Public Property business_address_line_2() As String
        Get
            business_address_line_2 = lbusiness_address_line_2
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_2 = value
        End Set
    End Property


    Public Property business_address_line_3() As String
        Get
            business_address_line_3 = lbusiness_address_line_3
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_3 = value
        End Set
    End Property


    Public Property business_address_line_4() As String
        Get
            business_address_line_4 = lbusiness_address_line_4
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_4 = value
        End Set
    End Property


    Public Property business_address_line_5() As String
        Get
            business_address_line_5 = lbusiness_address_line_5
        End Get
        Set(ByVal Value As String)
            lbusiness_address_line_5 = value
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
            lbusiness_postal_code = value
        End Set
    End Property


    Public Property preferred_store_code() As String
        Get
            preferred_store_code = lpreferred_store_code
        End Get
        Set(ByVal Value As String)
            lpreferred_store_code = value
        End Set
    End Property


    Public Property joined_store_code() As String
        Get
            joined_store_code = ljoined_store_code
        End Get
        Set(ByVal Value As String)
            ljoined_store_code = value
        End Set
    End Property


    Public Property preferred_contact_type_code() As String
        Get
            preferred_contact_type_code = lpreferred_contact_type_code
        End Get
        Set(ByVal Value As String)
            lpreferred_contact_type_code = value
        End Set
    End Property


    Public Property title_code() As String
        Get
            title_code = ltitle_code
        End Get
        Set(ByVal Value As String)
            ltitle_code = value
        End Set
    End Property


    Public Property tescogroup_mail_flag() As String
        Get
            tescogroup_mail_flag = ltescogroup_mail_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_mail_flag = value
        End Set
    End Property


    Public Property tescogroup_email_flag() As String
        Get
            tescogroup_email_flag = ltescogroup_email_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_email_flag = value
        End Set
    End Property


    Public Property tescogroup_phone_flag() As String
        Get
            tescogroup_phone_flag = ltescogroup_phone_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_phone_flag = value
        End Set
    End Property


    Public Property tescogroup_sms_flag() As String
        Get
            tescogroup_sms_flag = ltescogroup_sms_flag
        End Get
        Set(ByVal Value As String)
            ltescogroup_sms_flag = value
        End Set
    End Property


    Public Property partner_mail_flag() As String
        Get
            partner_mail_flag = lpartner_mail_flag
        End Get
        Set(ByVal Value As String)
            lpartner_mail_flag = value
        End Set
    End Property


    Public Property partner_email_flag() As String
        Get
            partner_email_flag = lpartner_email_flag
        End Get
        Set(ByVal Value As String)
            lpartner_email_flag = value
        End Set
    End Property


    Public Property partner_phone_flag() As String
        Get
            partner_phone_flag = lpartner_phone_flag
        End Get
        Set(ByVal Value As String)
            lpartner_phone_flag = value
        End Set
    End Property


    Public Property partner_sms_flag() As String
        Get
            partner_sms_flag = lpartner_sms_flag
        End Get
        Set(ByVal Value As String)
            lpartner_sms_flag = value
        End Set
    End Property


    Public Property research_mail_flag() As String
        Get
            research_mail_flag = lresearch_mail_flag
        End Get
        Set(ByVal Value As String)
            lresearch_mail_flag = value
        End Set
    End Property


    Public Property research_email_flag() As String
        Get
            research_email_flag = lresearch_email_flag
        End Get
        Set(ByVal Value As String)
            lresearch_email_flag = value
        End Set
    End Property


    Public Property research_phone_flag() As String
        Get
            research_phone_flag = lresearch_phone_flag
        End Get
        Set(ByVal Value As String)
            lresearch_phone_flag = value
        End Set
    End Property


    Public Property research_sms_flag() As String
        Get
            research_sms_flag = lresearch_sms_flag
        End Get
        Set(ByVal Value As String)
            lresearch_sms_flag = value
        End Set
    End Property


    Public Property diabetic_flag() As String
        Get
            diabetic_flag = ldiabetic_flag
        End Get
        Set(ByVal Value As String)
            ldiabetic_flag = value
        End Set
    End Property


    Public Property vegetarian_flag() As String
        Get
            vegetarian_flag = lvegetarian_flag
        End Get
        Set(ByVal Value As String)
            lvegetarian_flag = value
        End Set
    End Property


    Public Property teetotal_flag() As String
        Get
            teetotal_flag = lteetotal_flag
        End Get
        Set(ByVal Value As String)
            lteetotal_flag = value
        End Set
    End Property


    Public Property halal_flag() As String
        Get
            halal_flag = lhalal_flag
        End Get
        Set(ByVal Value As String)
            lhalal_flag = value
        End Set
    End Property


    Public Property lactose_flag() As String
        Get
            lactose_flag = llactose_flag
        End Get
        Set(ByVal Value As String)
            llactose_flag = value
        End Set
    End Property


    Public Property celiac_flag() As String
        Get
            celiac_flag = lceliac_flag
        End Get
        Set(ByVal Value As String)
            lceliac_flag = value
        End Set
    End Property


    Public Property customer_created_date() As String
        Get
            customer_created_date = lcustomer_created_date
        End Get
        Set(ByVal Value As String)
            lcustomer_created_date = value
        End Set
    End Property


    Public Property preferred_mailing_address_flag() As String
        Get
            preferred_mailing_address_flag = lpreferred_mailing_address_flag
        End Get
        Set(ByVal Value As String)
            lpreferred_mailing_address_flag = value
        End Set
    End Property


    Public Property race_code() As String
        Get
            race_code = lrace_code
        End Get
        Set(ByVal Value As String)
            lrace_code = value
        End Set
    End Property


    Public Property number_of_household_members() As String
        Get
            number_of_household_members = lnumber_of_household_members
        End Get
        Set(ByVal Value As String)
            lnumber_of_household_members = value
        End Set
    End Property


    Public Property card_member_name_nric() As String
        Get
            card_member_name_nric = lcard_member_name_nric
        End Get
        Set(ByVal Value As String)
            lcard_member_name_nric = value
        End Set
    End Property


    Public Property card_member_dob() As String
        Get
            card_member_dob = lcard_member_dob
        End Get
        Set(ByVal Value As String)
            lcard_member_dob = value
        End Set
    End Property


    Public Property card_member_gender_code() As String
        Get
            card_member_gender_code = lcard_member_gender_code
        End Get
        Set(ByVal Value As String)
            lcard_member_gender_code = value
        End Set
    End Property


    Public Property expat() As String
        Get
            expat = lexpat
        End Get
        Set(ByVal Value As String)
            lexpat = value
        End Set
    End Property


    Public Property form_type() As String
        Get
            form_type = lform_type
        End Get
        Set(ByVal Value As String)
            lform_type = value
        End Set
    End Property


End Class
