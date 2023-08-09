' Class: WPatron
' Puspose: management patron
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review
' Modification History:
'   -29/09/2006 by Tuannv

Imports System.IO
Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WPatron
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidCurrentPage As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatron As New clsBPatron
        Private objBEthnic As New clsBEthnic
        Private objBCollege As New clsBCollege
        Private objBFaculty As New clsBFaculty
        Private objBProvince As New clsBProvince
        Private objBEducation As New clsBEducation
        Private objBOccupation As New clsBOccupation
        Private objBUniversity As New clsBUniversity
        Private objBPatronGroup As New clsBPatronGroup
        Private objBOtherAddress As New clsBOtherAddress
        Private objBCommonBusiness As New clsBCommonBusiness
        Private intPatronID As Integer = 0

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
                Call LoadData()
            End If
            Call LoadDefaultValue()
        End Sub
        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            'Nhap ho so
            If Not CheckPemission(46) Then
                'Sua ho so
                'If Not CheckPemission(48) And Not CheckPemission(51) Then
                '    btnUpdate.Enabled = False
                'Else
                If CInt(Request("TypeSearch")) > 0 Then
                    btnUpdate.Enabled = True
                Else
                    btnUpdate.Enabled = False
                End If
                'End If
            Else
                btnUpdate.Enabled = True
            End If

            'Xoa ho so
            If Not CheckPemission(51) Then
                btnDelete.Enabled = False
            End If
            'Tra cuu ho so ban doc
            If Not CheckPemission(45) Then
                'btnSearch.Enabled = False
            End If
            'Quan ly danh muc
            If Not CheckPemission(213) Then
                lnkAddCollege.Enabled = False
                lnkAddCountry.Enabled = False
                lnkAddEducation.Enabled = False
                lnkAddEthnic.Enabled = False
                lnkAddFaculty.Enabled = False
                lnkAddOccupation.Enabled = False
                lnkAddProvince.Enabled = False
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            If Not Request("PatronID") & "" = "" Then
                hidPatronID.Value = Request("PatronID")
            End If
            If Not Request("IndexID") & "" = "" Then
                Dim ArrID()
                ArrID = Session("PatronIDs")
                hidPatronID.Value = ArrID(CInt(Request("IndexID")))
            End If
            If Not Request("TypeSearch") & "" = "" Then
                'btnSearch.Enabled = False
            Else
                If Not CheckPemission(45) Then
                    'btnSearch.Enabled = False
                Else
                    'btnSearch.Enabled = True
                End If
            End If

            ' Init objBCommonBusiness object
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonBusiness.Initialize()

            ' Init objBPatron object
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatron.Initialize()

            ' Init objBUniversity object
            objBUniversity.DBServer = Session("DBServer")
            objBUniversity.ConnectionString = Session("ConnectionString")
            objBUniversity.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBUniversity.Initialize()

            ' Init objBOtherAddress object
            objBOtherAddress.DBServer = Session("DBServer")
            objBOtherAddress.ConnectionString = Session("ConnectionString")
            objBOtherAddress.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOtherAddress.initialize()

            ' Init objBPatronGroup object
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()

            ' Init objEthnic object
            objBEthnic.DBServer = Session("DBServer")
            objBEthnic.ConnectionString = Session("ConnectionString")
            objBEthnic.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBEthnic.Initialize()

            ' Init objBEducation object
            objBEducation.DBServer = Session("DBServer")
            objBEducation.ConnectionString = Session("ConnectionString")
            objBEducation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBEducation.Initialize()

            ' Init objBOccupation object
            objBOccupation.DBServer = Session("DBServer")
            objBOccupation.ConnectionString = Session("ConnectionString")
            objBOccupation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOccupation.Initialize()

            ' Init objBCollege object
            objBCollege.DBServer = Session("DBServer")
            objBCollege.ConnectionString = Session("ConnectionString")
            objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCollege.Initialize()

            ' Init objBFaculty object
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.ConnectionString = Session("ConnectionString")
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBFaculty.Initialize()

            ' Init objBProvince object
            objBProvince.DBServer = Session("DBServer")
            objBProvince.ConnectionString = Session("ConnectionString")
            objBProvince.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBProvince.Initialize()

            If txtValidDate.Text = "" Then
                txtValidDate.Text = Session("ToDay")
                txtLastIssuedDate.Text = Session("ToDay")
            End If
            If Session("UseDefaultvalue") Is Nothing Then
                Session("UseDefaultvalue") = 0
            End If
        End Sub

        ' Method: ShowPatronImage
        ' Purpose: show image of this patron
        Private Sub ShowPatronImage()
            imgPatron.Src = "../Images/Card/Empty.gif"

            If hidCode.Value <> "" Then
                Dim strUrl As String = "../Images/Card/" & hidCode.Value.Trim
                imgPatron.Src = "../Common/ShowPic.aspx?intw=90&inth=120&Url=" & strUrl
            End If
        End Sub

        ' Method: BindData
        ' Purpose: BindData for Control
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim strJS As String = ""
            Dim intNOR As Integer = 0
            Dim intIndex As Integer
            Dim inti As Integer

            ' Set default value
            txtCurrentRecord.Text = 0
            txtTotalRecord.Text = 0

            ' BindData for ddlEthnic
            tblTemp = objBEthnic.GetEthnic
            Dim tmpView As DataView = tblTemp.DefaultView()
            tmpView.Sort = "Ethnic ASC"
            tblTemp = Nothing
            tblTemp = tmpView.ToTable()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBEthnic.ErrorMsg, ddlLabel.Items(0).Text, objBEthnic.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlEthnic.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlEthnic.DataTextField = "Ethnic"
                ddlEthnic.DataValueField = "ID"
                ddlEthnic.DataBind()

                tblTemp.Clear()
            End If

            ' BindData for ddlPatronGroup
            tblTemp = Nothing
            tblTemp = objBPatronGroup.GetPatronGroup()
            tmpView = Nothing
            tmpView = tblTemp.DefaultView()
            tmpView.Sort = "Name ASC"
            tblTemp = Nothing
            tblTemp = tmpView.ToTable()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlPatronGroup.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlPatronGroup.DataTextField = "Name"
                ddlPatronGroup.DataValueField = "ID"
                ddlPatronGroup.DataBind()
                tblTemp.Clear()
            End If

            ' BindData for ddlEducation
            tblTemp = Nothing
            tblTemp = objBEducation.GetEducation

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBEducation.ErrorMsg, ddlLabel.Items(0).Text, objBEducation.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlEducation.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlEducation.DataTextField = "EducationLevel"
                ddlEducation.DataValueField = "ID"
                ddlEducation.DataBind()
                tblTemp.Clear()
            End If

            ' BindData for ddlOccupation
            tblTemp = Nothing
            tblTemp = objBOccupation.GetOccupation
            tmpView = Nothing
            tmpView = tblTemp.DefaultView()
            tmpView.Sort = "Occupation ASC"
            tblTemp = Nothing
            tblTemp = tmpView.ToTable()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBOccupation.ErrorMsg, ddlLabel.Items(0).Text, objBOccupation.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlOccupation.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlOccupation.DataTextField = "Occupation"
                ddlOccupation.DataValueField = "ID"
                ddlOccupation.DataBind()
                tblTemp.Clear()
            End If

            ' BindData for ddlCollege
            tblTemp = Nothing
            tblTemp = objBCollege.GetCollege

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCollege.ErrorMsg, ddlLabel.Items(0).Text, objBCollege.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlCollege.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlCollege.DataTextField = "College"
                ddlCollege.DataValueField = "ID"
                ddlCollege.DataBind()
                tblTemp.Clear()
            End If

            ' BindData for ddlProvince
            tblTemp = Nothing
            tblTemp = objBProvince.GetProvince
            tmpView = Nothing
            tmpView = tblTemp.DefaultView()
            tmpView.Sort = "Province ASC"
            tblTemp = Nothing
            tblTemp = tmpView.ToTable()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBProvince.ErrorMsg, ddlLabel.Items(0).Text, objBProvince.ErrorCode)
            ddlProvince.Items.Clear()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ' ddlProvince.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlProvince.DataSource = tblTemp
                ddlProvince.DataTextField = "Province"
                ddlProvince.DataValueField = "ID"
                ddlProvince.DataBind()
                ddlProvince.Items(0).Selected = True
                tblTemp.Clear()
            End If

            ' BindData for ddlCountry
            tblTemp = Nothing
            tblTemp = objBCommonBusiness.GetCountries
            tmpView = Nothing
            tmpView = tblTemp.DefaultView()
            tmpView.Sort = "Country ASC"
            tblTemp = Nothing
            tblTemp = tmpView.ToTable()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlCountry.DataSource = tblTemp
                ddlCountry.DataTextField = "Country"
                ddlCountry.DataValueField = "ID"
                ddlCountry.DataBind()

                For inti = 0 To tblTemp.Rows.Count - 1
                    If CStr(tblTemp.Rows(inti).Item("ISOCode")).ToLower = "vn" Then
                        ddlCountry.SelectedIndex = inti
                        Exit For
                    End If
                Next

                tblTemp.Clear()
            End If

            ' Get faculty
            tblTemp = Nothing
            tblTemp = objBFaculty.GetFaculty
            tmpView = Nothing
            tmpView = tblTemp.DefaultView()
            tmpView.Sort = "Faculty ASC"
            tblTemp = Nothing
            tblTemp = tmpView.ToTable()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBFaculty.ErrorMsg, ddlLabel.Items(0).Text, objBFaculty.ErrorCode)

            If Not tblTemp Is Nothing Then
                intNOR = tblTemp.Rows.Count
                If intNOR > 0 Then
                    strJS = strJS & "FacultyName = new Array(" & intNOR & ");" & Chr(10)
                    strJS = strJS & "FacultyID = new Array(" & intNOR & ");" & Chr(10)
                    strJS = strJS & "CollegeID = new Array(" & intNOR & ");" & Chr(10)

                    For intIndex = 0 To intNOR - 1
                        strJS = strJS & "CollegeID[" & intIndex & "] = " & tblTemp.Rows(intIndex).Item("CollegeID") & ";" & Chr(10)
                        strJS = strJS & "FacultyID[" & intIndex & "] = " & tblTemp.Rows(intIndex).Item("ID") & ";" & Chr(10)
                        strJS = strJS & "FacultyName[" & intIndex & "] = '" & tblTemp.Rows(intIndex).Item("Faculty") & "';" & Chr(10)
                    Next
                    Page.RegisterClientScriptBlock("LoadFacultyJS", "<script language='javascript'>" & strJS & "</script>")
                End If
            End If
            hidCheckedID.Value = 1
        End Sub

        ' Method: LoadData
        ' Purpose: LoadData for controls
        Private Sub LoadData()
            Dim intPatronID As Integer = CInt(hidPatronID.Value)
            Dim tblPatron As DataTable
            Dim intIndex As Integer
            Dim intEthnicID, intPatronGroupID, intEducationID, intOccupationID As Integer
            Dim intCollegeID = 0, intFacultyID, intProvinceID, intCountryID As Integer

            ' Exist if new patron record
            If intPatronID = 0 Then Exit Sub

            ' Get patron's informations
            objBPatron.PatronIDs = intPatronID ' Request("PatronID")
            tblPatron = objBPatron.GetPatron()

            ' Show data
            If Not tblPatron Is Nothing AndAlso tblPatron.Rows.Count > 0 Then
                ' Set value for control of patron 
                ' FirstName
                txtFirstName.Text = tblPatron.Rows(0).Item("FirstName").ToString.Trim & " " & tblPatron.Rows(0).Item("MiddleName").ToString.Trim
                ' LastName
                txtLastName.Text = tblPatron.Rows(0).Item("LastName").ToString.Trim
                ' Sex
                If tblPatron.Rows(0).Item("Sex") Or tblPatron.Rows(0).Item("Sex").ToString.Trim = "1" Then
                    optMale.Checked = True
                Else
                    optFeMale.Checked = True
                End If
                ' DOB
                If Not IsDBNull(tblPatron.Rows(0).Item("DOB")) Then
                    txtDOB.Text = tblPatron.Rows(0).Item("DOB").ToString.Trim
                End If

                ' Ethnic
                If Not IsDBNull(tblPatron.Rows(0).Item("EthnicID")) Then
                    intEthnicID = CInt(tblPatron.Rows(0).Item("EthnicID"))
                    hidEthnic.Value = intEthnicID
                    For intIndex = 0 To ddlEthnic.Items.Count - 1
                        If ddlEthnic.Items(intIndex).Value = intEthnicID Then
                            ddlEthnic.SelectedIndex = intIndex
                            Exit For
                        End If
                    Next
                End If
                ' PatronGroup
                If Session("DBServer") = "ORACLE" Then
                    If Not IsDBNull(tblPatron.Rows(0).Item("PATRONGROUPID")) Then
                        intPatronGroupID = CInt(tblPatron.Rows(0).Item("PATRONGROUPID"))
                    End If
                Else
                    If Not IsDBNull(tblPatron.Rows(0).Item("PatronGroupID")) Then
                        intPatronGroupID = CInt(tblPatron.Rows(0).Item("PatronGroupID"))
                    End If
                End If
                hidPatronGroup.Value = intPatronGroupID
                For intIndex = 0 To ddlPatronGroup.Items.Count - 1
                    If ddlPatronGroup.Items(intIndex).Value = intPatronGroupID Then
                        ddlPatronGroup.SelectedIndex = intIndex
                        Exit For
                    End If
                Next
                ' Code
                txtCode.Text = tblPatron.Rows(0).Item("Code").ToString.Trim

                ' Image
                hidCode.Value = tblPatron.Rows(0).Item("Portrait").ToString.Trim
                Call ShowPatronImage()

                ' LastIssued Date
                txtLastIssuedDate.Text = tblPatron.Rows(0).Item("LASTISSUEDDATE").ToString.Trim
                ' Valid Date
                txtValidDate.Text = tblPatron.Rows(0).Item("VALIDDATE").ToString.Trim
                ' Expired Date
                txtExpiredDate.Text = tblPatron.Rows(0).Item("EXPIREDDATE").ToString.Trim
                ' Education ID
                If Not IsDBNull(tblPatron.Rows(0).Item("EducationID")) Then
                    intEducationID = CInt(tblPatron.Rows(0).Item("EducationID"))
                End If
                hidEducation.Value = intEducationID
                For intIndex = 0 To ddlEducation.Items.Count - 1
                    If ddlEducation.Items(intIndex).Value = intEducationID Then
                        ddlEducation.SelectedIndex = intIndex
                        Exit For
                    End If
                Next
                ' Occupation ID
                If Not IsDBNull(tblPatron.Rows(0).Item("OccupationID")) Then
                    intOccupationID = CInt(tblPatron.Rows(0).Item("OccupationID"))
                End If
                hidOccupation.Value = intOccupationID
                For intIndex = 0 To ddlOccupation.Items.Count - 1
                    If ddlOccupation.Items(intIndex).Value = intOccupationID Then
                        ddlOccupation.SelectedIndex = intIndex
                        Exit For
                    End If
                Next
                ' WorkPlace
                txtWorkPlace.Text = tblPatron.Rows(0).Item("WorkPlace").ToString.Trim
                ' Telephone
                txtTelephone.Text = tblPatron.Rows(0).Item("Telephone").ToString.Trim
                ' Mobile
                txtMobile.Text = tblPatron.Rows(0).Item("Mobile").ToString.Trim
                ' Email
                txtEmail.Text = tblPatron.Rows(0).Item("Email").ToString.Trim
                ' Note
                txtNote.Text = tblPatron.Rows(0).Item("Note").ToString.Trim
                'IDCard
                txtIDCard.Text = tblPatron.Rows(0).Item("IDCard").ToString.Trim
                'facebook
                txtFacebook.Text = tblPatron.Rows(0).Item("Facebook").ToString.Trim

                ' Set value for control of University 
                Dim tblUniversity As DataTable
                Dim tblFaculty As DataTable
                objBUniversity.PatronIDs = intPatronID
                tblUniversity = objBUniversity.GetUniversity

                If Not tblUniversity Is Nothing AndAlso tblUniversity.Rows.Count > 0 Then
                    ' Get college
                    If Not IsDBNull(tblUniversity.Rows(0).Item("CollegeID")) Then
                        intCollegeID = CInt(tblUniversity.Rows(0).Item("CollegeID"))
                    End If
                    For intIndex = 0 To ddlCollege.Items.Count - 1
                        If ddlCollege.Items(intIndex).Value = intCollegeID Then
                            ddlCollege.SelectedIndex = intIndex
                            Exit For
                        End If
                    Next
                    ' Get faculty
                    If intCollegeID > 0 Then
                        objBFaculty.CollegeID = intCollegeID
                        tblFaculty = objBFaculty.GetFaculty
                        Dim tmpView As DataView = tblFaculty.DefaultView()
                        tmpView.Sort = "Faculty ASC"
                        tblFaculty = Nothing
                        tblFaculty = tmpView.ToTable()
                        If Not tblFaculty Is Nothing AndAlso tblFaculty.Rows.Count > 0 Then
                            ddlFaculty.DataSource = InsertOneRow(tblFaculty, ddlLabel.Items(14).Text)
                            ddlFaculty.DataTextField = "Faculty"
                            ddlFaculty.DataValueField = "ID"
                            ddlFaculty.DataBind()
                            If Not IsDBNull(tblUniversity.Rows(0).Item("FacultyID")) Then
                                intFacultyID = CInt(tblUniversity.Rows(0).Item("FacultyID"))
                            End If
                            hidFaculty.Value = intFacultyID
                            For intIndex = 0 To ddlFaculty.Items.Count - 1
                                If ddlFaculty.Items(intIndex).Value = intFacultyID Then
                                    ddlFaculty.SelectedIndex = intIndex
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    ' Get grade
                    txtGrade.Text = tblUniversity.Rows(0).Item("Grade").ToString.Trim
                    ' Get class
                    txtClass.Text = tblUniversity.Rows(0).Item("Class").ToString.Trim
                End If

                ' Get address informations
                Dim tblOtherAddress As DataTable
                Dim intTotalRecord, inti, intj, intID, intisActive As Integer
                Dim strAddressInfor As String = ""
                Dim strJs, strAddress, strCity, strZip As String
                objBOtherAddress.PatronID = intPatronID
                tblOtherAddress = objBOtherAddress.GetOtherAddress()
                If Not tblOtherAddress Is Nothing AndAlso tblOtherAddress.Rows.Count > 0 Then
                    strJs = "var inti; "
                    intTotalRecord = tblOtherAddress.Rows.Count
                    txtTotalRecord.Text = intTotalRecord
                    For inti = 0 To tblOtherAddress.Rows.Count - 1
                        intID = tblOtherAddress.Rows(inti).Item("ID")
                        If Not IsDBNull(tblOtherAddress.Rows(inti).Item("Address")) Then
                            strAddress = tblOtherAddress.Rows(inti).Item("Address")
                        Else
                            strAddress = ""
                        End If
                        intProvinceID = tblOtherAddress.Rows(inti).Item("ProvinceID")
                        intCountryID = tblOtherAddress.Rows(inti).Item("CountryID")
                        strCity = tblOtherAddress.Rows(inti).Item("City") & ""
                        strZip = tblOtherAddress.Rows(inti).Item("Zip") & ""
                        intisActive = tblOtherAddress.Rows(inti).Item("Active")
                        strJs = strJs & "PatronAdd[" & inti & "]=new PatronAddress(" & intID & ",'" & strAddress & "','" & strCity & "'," & intProvinceID & "," & intCountryID & ",'" & strZip & "'," & intisActive & ");" & vbCrLf
                    Next
                    ' Load first record
                    txtCurrentRecord.Text = 1
                    hidCurrentRecord.Value = 0
                    txtAddress.Text = tblOtherAddress.Rows(0).Item("Address") & ""
                    txtCity.Text = tblOtherAddress.Rows(0).Item("City") & ""
                    txtZip.Text = tblOtherAddress.Rows(0).Item("Zip") & ""
                    ' CountryID
                    For inti = 0 To ddlCountry.Items.Count - 1
                        If ddlCountry.Items(inti).Value = tblOtherAddress.Rows(0).Item("CountryID") Then
                            ddlCountry.Items(ddlCountry.SelectedIndex).Selected = False
                            ddlCountry.Items(inti).Selected = True
                            Exit For
                        End If
                    Next
                    ' ProvinceID
                    For inti = 0 To ddlProvince.Items.Count - 1
                        If ddlProvince.Items(inti).Value = tblOtherAddress.Rows(0).Item("ProvinceID") Then
                            ddlProvince.Items(ddlProvince.SelectedIndex).Selected = False
                            ddlProvince.Items(inti).Selected = True
                            Exit For
                        End If
                    Next
                    ' Active address
                    If CInt(tblOtherAddress.Rows(0).Item("Active")) = 0 Then
                        cbxActive.Checked = False
                    Else
                        cbxActive.Checked = True
                    End If
                    Page.RegisterClientScriptBlock("BindOtherAddJs", "<script language='javascript'>" & strJs & "</script>")
                End If
            End If
            hidEthnic.Value = ddlEthnic.SelectedValue
            hidPatronGroup.Value = ddlPatronGroup.SelectedValue
            hidEducation.Value = ddlEducation.SelectedValue
            hidOccupation.Value = ddlOccupation.SelectedValue
            hidCollege.Value = ddlCollege.SelectedValue
            hidFaculty.Value = ddlFaculty.SelectedValue
        End Sub

        ' Method: BindJS
        ' Bind JavaScript for controls
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SeflJs", "<script language='javascript' src='Js/WPatron.js?x=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnGenCard.Attributes.Add("onClick", "return GenCard();")
            ' Navigate buttons
            btnFirst.Attributes.Add("OnClick", "MoveFirstRecord(); return false;")
            btnPrevious.Attributes.Add("OnClick", "MovePreviousRecord('" & ddlLabel.Items(21).Text & "'); return false;")
            btnNext.Attributes.Add("OnClick", "MoveNextRecord('" & ddlLabel.Items(22).Text & "'); return false;")
            btnLast.Attributes.Add("OnClick", "MoveLastRecord(); return false;")
            btnNew.Attributes.Add("OnClick", "AddNewRecord(); return false;")
            btnDelete.Attributes.Add("OnClick", "DeleteRecord(); return false;")
            ' Check error
            txtCode.Attributes.Add("onChange", "javascript:if(!CheckSymbol(this,'" & ddlLabel.Items(30).Text & "')){this.focus();this.value=''}else {parent.hiddenbase.location.href='WHiddenPatron.aspx?Action=CheckCode&CodeOld='+ document.forms[0].txtCode.value + '&Code='+ document.forms[0].txtCode.value + '&ddlLabel.Items(4)Exits=" & "" & "';}")
            'txtCode.Attributes.Add("onChange", "javascript:parent.hiddenbase.location.href='WHiddenPatron.aspx?Action=CheckCode&Code=tuan'")
            'txtCode.Attributes.Add("onChange", "return CheckSymbol(this,'" & ddlLabel.Items(30).Text & "');")

            txtEmail.Attributes.Add("onchange", "return CheckValidEmail(this,'');")
            ddlEthnic.Attributes.Add("onchange", "document.forms[0].hidEthnic.value = this.options[this.selectedIndex].value;")
            ddlPatronGroup.Attributes.Add("onchange", "document.forms[0].hidPatronGroup.value = this.options[this.selectedIndex].value;")
            ddlEducation.Attributes.Add("onchange", "document.forms[0].hidEducation.value = this.options[this.selectedIndex].value;")
            ddlOccupation.Attributes.Add("onchange", "document.forms[0].hidOccupation.value = this.options[this.selectedIndex].value;")
            ddlCollege.Attributes.Add("onchange", "document.forms[0].hidCollege.value = this.options[this.selectedIndex].value; FilterFaculty(this.options[this.selectedIndex].value, '" & ddlLabel.Items(14).Text & "');")
            ddlFaculty.Attributes.Add("onchange", "document.forms[0].hidFaculty.value = this.options[this.selectedIndex].value;")

            cbxActive.Attributes.Add("OnClick", "ActiveAddress('" & ddlLabel.Items(27).Text & "');")
            ' Add new items
            lnkAddEthnic.NavigateUrl = "javascript:OpenWindow('WDictionary.aspx?id=opener.document.forms[0].ddlEthnic&idtxt=opener.document.forms[0].txtEthnic&Dicname=Ethnic','Ethnic',290,95,220,100)"
            lnkAddEducation.NavigateUrl = "javascript:OpenWindow('WDictionary.aspx?Dicname=Education','Education',290,95,220,100)"
            lnkAddOccupation.NavigateUrl = "javascript:OpenWindow('WDictionary.aspx?Dicname=Occupation','Occupation',290,95,220,100)"
            lnkAddProvince.NavigateUrl = "javascript:OpenWindow('WDictionary.aspx?Dicname=Province','Province',290,95,220,100)"
            lnkAddCountry.NavigateUrl = "javascript:OpenWindow('WDictionary.aspx?Dicname=Country','Country',290,95,220,100)"
            lnkAddCollege.NavigateUrl = "javascript:OpenWindow('WDictionary.aspx?Dicname=College','College',290,95,220,100)"
            lnkAddFaculty.NavigateUrl = "javascript:if (document.forms[0].ddlCollege.selectedIndex==0) {alert('" & ddlLabel.Items(24).Text & "');} else {OpenWindow('WDictionary.aspx?CollegeID=' + document.forms[0].ddlCollege.options[document.forms[0].ddlCollege.selectedIndex].value + '&Dicname=Faculty','Faculty',290,95,210,100);}"

            lnkPatronImage.NavigateUrl = "javascript:AddImage('" & ddlLabel.Items(23).Text & "');"
            lnkDetailPatronGroup.NavigateUrl = "javascript: OpenWindow('WPatronGroup.aspx?Id=' + document.forms[0].ddlPatronGroup.options[document.forms[0].ddlPatronGroup.options.selectedIndex].value,'DetailPatronGroup',500,350,200,220)"

            ' Show detail
            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkDOB, txtDOB, ddlLabel.Items(26).Text)
            SetOnclickCalendar(lnkValidDate, txtValidDate, ddlLabel.Items(26).Text)
            SetOnclickCalendar(lnkExpiredDate, txtExpiredDate, ddlLabel.Items(26).Text)
            SetOnclickCalendar(lnkLastIssuedDate, txtLastIssuedDate, ddlLabel.Items(26).Text)

            ' Do actions
            btnUpdate.Attributes.Add("OnClick", "return CheckAll('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(28).Text & "','" & Session("DateFormat") & "','" & ddlLabel.Items(11).Text & "','" & ddlLabel.Items(29).Text & "');")
            btnSearch.NavigateUrl = "WSimpleSearch.aspx"
        End Sub

        ' Method: SetParameters
        ' Purpose: Set value
        Private Sub SetParameters()
            ' Set parameters for Patron
            If InStr(txtFirstName.Text.Trim, " ") > 0 Then
                objBPatron.FirstName = Left(txtFirstName.Text, InStr(txtFirstName.Text.Trim, " ")).Trim()
                objBPatron.MiddleName = Right(txtFirstName.Text.Trim, Len(txtFirstName.Text.Trim) - InStr(txtFirstName.Text.Trim, " ")).Trim()
            Else
                objBPatron.FirstName = txtFirstName.Text.Trim
            End If
            objBPatron.LastName = txtLastName.Text.Trim
            If optMale.Checked Then
                objBPatron.Sex = 1
            Else
                objBPatron.Sex = 0
            End If
            objBPatron.DOB = txtDOB.Text
            If hidEthnic.Value <> "" Then
                objBPatron.EthnicID = hidEthnic.Value
            End If
            If hidPatronGroup.Value <> "" Then
                objBPatron.PatronGroupID = hidPatronGroup.Value
            End If
            If Not (txtCode.Text.Trim & "" = "") Then
                objBPatron.Code = txtCode.Text.Trim
            End If

            objBPatron.Portrait = hidCode.Value.Trim
            objBPatron.LastIssuedDate = txtLastIssuedDate.Text.Trim
            objBPatron.ValidDate = txtValidDate.Text.Trim
            objBPatron.ExpiredDate = txtExpiredDate.Text.Trim
            objBPatron.AddressInfor = txtAddress.Text.Trim
            If hidEducation.Value <> "" Then
                objBPatron.EducationID = hidEducation.Value
            End If
            If hidOccupation.Value <> "" Then
                objBPatron.OccupationID = hidOccupation.Value
            End If
            objBPatron.WorkPlace = txtWorkPlace.Text.Trim
            objBPatron.Telephone = txtTelephone.Text.Trim
            objBPatron.Mobile = txtMobile.Text.Trim
            objBPatron.Email = txtEmail.Text.Trim
            objBPatron.Facebook = txtFacebook.Text.Trim
            objBPatron.Note = txtNote.Text.Trim
            objBPatron.IDCard = txtIDCard.Text
            ' Set parameters for University
            If hidCollege.Value <> "" Then
                objBPatron.CollegeIDCPU = hidCollege.Value
            Else
                objBPatron.CollegeIDCPU = 0
            End If
            If hidFaculty.Value <> "" Then
                objBPatron.FacultyIDCPU = hidFaculty.Value
            Else
                objBPatron.FacultyIDCPU = 0
            End If
            objBPatron.GradeCPU = txtGrade.Text.Trim
            objBPatron.ClassCPU = txtClass.Text.Trim
            If Not hidAddressInfor.Value = "" Then
                'objBPatron.AddressInfor = Replace(Replace(hidAddressInfor.Value.Trim, "\t", Chr(9)), "\n", vbCrLf)
                objBPatron.AddressInfor = Replace(Replace(hidAddressInfor.Value.Trim, Chr(9), "$&"), "\n", vbCrLf)
            Else
                objBPatron.AddressInfor = ""
            End If
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: Update information for current patron
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Call SetParameters()
            Dim intRetval As Integer

            If CInt(hidPatronID.Value) > 0 Then
                objBPatron.PatronID = CInt(hidPatronID.Value)
                intRetval = objBPatron.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)

                ' WriteLog
                Call WriteLog(26, ddlLabel.Items(25).Text & ": " & txtCode.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intRetval > 0 Then
                    Page.RegisterClientScriptBlock("Success", "<Script language='JavaScript'>alert('" & ddlLabel.Items(17).Text & "');</Script>")
                Else
                    Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('" & ddlLabel.Items(16).Text & "');</Script>")
                End If
                Call BindData()
                Call LoadData()
            Else
                intRetval = objBPatron.Create()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)

                ' WriteLog
                Call WriteLog(26, ddlLabel.Items(25).Text & ": " & txtCode.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intRetval > 0 Then
                    Page.RegisterClientScriptBlock("Success", "<Script language='JavaScript'>alert('" & ddlLabel.Items(19).Text & "');document.location.href='WPatron.aspx';</Script>")
                Else
                    Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('" & ddlLabel.Items(18).Text & "');</Script>")
                End If
            End If
            Call SetDefault()
            'btnSearch.Enabled = True
        End Sub

        ' Method: SetDefault
        ' Purpose: Set some default values
        Private Sub SetDefault()
            If cbxSetDefault.Checked Then
                Session("UseDefaultvalue") = 1
                Session("vValidDate") = txtValidDate.Text.Trim
                Session("vExpiredDate") = txtExpiredDate.Text.Trim
                Session("vLastIssuedDate") = txtLastIssuedDate.Text.Trim
                Session("vWorkPlace") = txtWorkPlace.Text.Trim
                Session("vEthnicID") = hidEthnic.Value.Trim
                Session("vEducationID") = hidEducation.Value.Trim
                Session("vCollegeID") = hidCollege.Value.Trim
                Session("vFacultyID") = hidFaculty.Value.Trim
                Session("vOccupationID") = hidOccupation.Value.Trim
                Session("vPatronGroupID") = hidPatronGroup.Value.Trim
                Session("vGrade") = txtGrade.Text.Trim
                Session("vClass") = txtClass.Text.Trim
            Else
                Session("UseDefaultvalue") = 0
                Session("vValidDate") = ""
                Session("vExpiredDate") = ""
                Session("vLastIssuedDate") = ""
                Session("vWorkPlace") = ""
                Session("vEthnicID") = 0
                Session("vEducationID") = 0
                Session("vCollegeID") = 0
                Session("vFacultyID") = 0
                Session("vOccupationID") = 0
                Session("vPatronGroupID") = 0
                Session("vGrade") = ""
                Session("vClass") = ""
            End If
        End Sub

        ' Method: LoadDefaultValue
        ' Purpose: load default value
        Private Sub LoadDefaultValue()
            If Session("UseDefaultvalue") = 1 And hidPatronID.Value = "0" Then
                Dim strJS As String = "<script language='javascript'>" & Chr(10)
                strJS = strJS & "LoadDefaultValue('" & ddlLabel.Items(14).Text & "', '" & Session("vValidDate").ToString & "', '" & Session("vExpiredDate").ToString & "', '" & Session("vLastIssuedDate").ToString & "', '" & Session("vWorkPlace").ToString & "', " & Session("vEthnicID").ToString & ", " & Session("vEducationID").ToString & ", " & Session("vCollegeID").ToString & ", " & Session("vFacultyID").ToString & ", " & Session("vOccupationID").ToString & ", " & Session("vPatronGroupID").ToString & ", '" & Session("vGrade").ToString & "', '" & Session("vClass").ToString & "')" & Chr(10)
                strJS = strJS & "</script>" & Chr(10)
                lblJS.Text = strJS
            End If
        End Sub

        ' Event: Page_Unload
        ' Purpose: release all allocated objects
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPatron Is Nothing Then
                objBPatron.Dispose(True)
                objBPatron = Nothing
            End If
            If Not objBOtherAddress Is Nothing Then
                objBOtherAddress.Dispose(True)
                objBOtherAddress = Nothing
            End If
            If Not objBUniversity Is Nothing Then
                objBUniversity.Dispose(True)
                objBUniversity = Nothing
            End If
            If Not objBCollege Is Nothing Then
                objBCollege.Dispose(True)
                objBCollege = Nothing
            End If
            If Not objBPatronGroup Is Nothing Then
                objBPatronGroup.Dispose(True)
                objBPatronGroup = Nothing
            End If
            If Not objBEducation Is Nothing Then
                objBEducation.Dispose(True)
                objBEducation = Nothing
            End If
            If Not objBEthnic Is Nothing Then
                objBEthnic.Dispose(True)
                objBEthnic = Nothing
            End If
            If Not objBFaculty Is Nothing Then
                objBFaculty.Dispose(True)
                objBFaculty = Nothing
            End If
            If Not objBOccupation Is Nothing Then
                objBOccupation.Dispose(True)
                objBOccupation = Nothing
            End If
            If Not objBProvince Is Nothing Then
                objBProvince.Dispose(True)
                objBProvince = Nothing
            End If
            If Not objBCommonBusiness Is Nothing Then
                objBCommonBusiness.Dispose(True)
                objBCommonBusiness = Nothing
            End If
        End Sub
    End Class
End Namespace