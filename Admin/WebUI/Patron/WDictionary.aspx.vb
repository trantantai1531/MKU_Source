' Class: WDictionary
' Puspose: management dictionaries
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WDictionary
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCollege As clsBCollege
        Private objBEthnic As clsBEthnic
        Private objBProvince As clsBProvince
        Private objBOccupation As clsBOccupation
        Private objBEducation As clsBEducation
        Private objBFaculty As clsBFaculty
        Private objBCommonBusiness As clsBCommonBusiness
        Private Dicname As String

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dicname = Request.QueryString("dicname")
            Call Initialize()
            Call BindJS()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            Select Case UCase(Dicname)
                Case "COLLEGE"
                    lblTitle.Text = ddlLabel.Items(4).Text & " " & ddlLabel.Items(12).Text
                    lblDictionary.Text = ddlLabel.Items(12).Text & ":"
                    objBCollege = New clsBCollege
                    objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
                    objBCollege.DBServer = Session("DBServer")
                    objBCollege.ConnectionString = Session("ConnectionString")
                    Call objBCollege.Initialize()
                Case "ETHNIC"
                    lblTitle.Text = ddlLabel.Items(4).Text & " " & ddlLabel.Items(5).Text
                    lblDictionary.Text = ddlLabel.Items(5).Text & ":"
                    objBEthnic = New clsBEthnic
                    txtDictionary.MaxLength = 20
                    objBEthnic.InterfaceLanguage = Session("InterfaceLanguage")
                    objBEthnic.DBServer = Session("DBServer")
                    objBEthnic.ConnectionString = Session("ConnectionString")
                    Call objBEthnic.Initialize()
                Case "PROVINCE"
                    lblTitle.Text = ddlLabel.Items(4).Text & " " & ddlLabel.Items(8).Text
                    lblDictionary.Text = ddlLabel.Items(8).Text & ":"
                    objBProvince = New clsBProvince
                    objBProvince.InterfaceLanguage = Session("InterfaceLanguage")
                    objBProvince.DBServer = Session("DBServer")
                    objBProvince.ConnectionString = Session("ConnectionString")
                    Call objBProvince.Initialize()
                Case "OCCUPATION"
                    lblTitle.Text = ddlLabel.Items(4).Text & " " & ddlLabel.Items(7).Text
                    lblDictionary.Text = ddlLabel.Items(7).Text & ":"
                    objBOccupation = New clsBOccupation
                    objBOccupation.InterfaceLanguage = Session("InterfaceLanguage")
                    objBOccupation.DBServer = Session("DBServer")
                    objBOccupation.ConnectionString = Session("ConnectionString")
                    Call objBOccupation.Initialize()
                Case "EDUCATION"
                    lblTitle.Text = ddlLabel.Items(4).Text & " " & ddlLabel.Items(6).Text
                    lblDictionary.Text = ddlLabel.Items(6).Text & ":"
                    objBEducation = New clsBEducation
                    objBEducation.InterfaceLanguage = Session("InterfaceLanguage")
                    objBEducation.DBServer = Session("DBServer")
                    objBEducation.ConnectionString = Session("ConnectionString")
                    Call objBEducation.Initialize()
                Case "FACULTY"
                    lblTitle.Text = ddlLabel.Items(4).Text & " " & ddlLabel.Items(3).Text
                    lblDictionary.Text = ddlLabel.Items(3).Text & ":"
                    objBFaculty = New clsBFaculty
                    objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
                    objBFaculty.DBServer = Session("DBServer")
                    objBFaculty.ConnectionString = Session("ConnectionString")
                    Call objBFaculty.Initialize()
                Case "COUNTRY"
                    lblTitle.Text = ddlLabel.Items(4).Text & " " & ddlLabel.Items(2).Text
                    lblDictionary.Text = ddlLabel.Items(2).Text & ":"
                    objBCommonBusiness = New clsBCommonBusiness
                    objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
                    objBCommonBusiness.DBServer = Session("DBServer")
                    objBCommonBusiness.ConnectionString = Session("ConnectionString")
                    Call objBCommonBusiness.Initialize()
            End Select
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("onClick", "self.close();")
            btnAdd.Attributes.Add("onClick", "javascript:if (CheckNull(document.forms[0].txtDictionary)) {alert('" & ddlLabel.Items(9).Text & "'); return false;}")
        End Sub

        ' Event: btnAdd_Click
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intOut As Integer = 0

            ' Set DictionaryID value
            Select Case UCase(Dicname)
                Case "ETHNIC"
                    objBEthnic.Ethnic = txtDictionary.Text.Trim
                    intOut = objBEthnic.Create()
                    If objBEthnic.ErrorCode > 0 Then
                        Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
                        Exit Sub
                    End If
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(4).Text & ": " & txtDictionary.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "COLLEGE"
                    objBCollege.College = txtDictionary.Text.Trim
                    intOut = objBCollege.Create()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCollege.ErrorMsg, ddlLabel.Items(0).Text, objBCollege.ErrorCode)

                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(4).Text & ": " & txtDictionary.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "PROVINCE"
                    objBProvince.Province = txtDictionary.Text.Trim
                    intOut = objBProvince.Create()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBProvince.ErrorMsg, ddlLabel.Items(0).Text, objBProvince.ErrorCode)

                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(4).Text & ": " & txtDictionary.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "OCCUPATION"
                    objBOccupation.Occupation = txtDictionary.Text.Trim
                    intOut = objBOccupation.Create()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBOccupation.ErrorMsg, ddlLabel.Items(0).Text, objBOccupation.ErrorCode)

                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(4).Text & ": " & txtDictionary.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "EDUCATION"
                    objBEducation.Education = txtDictionary.Text.Trim
                    intOut = objBEducation.Create()
                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBEducation.ErrorMsg, ddlLabel.Items(0).Text, objBEducation.ErrorCode)

                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(4).Text & ": " & txtDictionary.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case "FACULTY"
                    objBFaculty.CollegeID = Request("CollegeID")
                    objBFaculty.Faculty = txtDictionary.Text.Trim
                    intOut = objBFaculty.Create()

                    ' Check error
                    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBFaculty.ErrorMsg, ddlLabel.Items(0).Text, objBFaculty.ErrorCode)

                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(4).Text & ": " & txtDictionary.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End Select
            If intOut = -1 Then ' Exist
                Page.RegisterClientScriptBlock("Alert", "<script language = 'javascript'>alert('" & ddlLabel.Items(10).Text & "');</script>")
            Else
                Select Case UCase(Dicname)
                    Case "ETHNIC"
                        Page.RegisterClientScriptBlock("AddItem", "<script language='javascript'>AddItem(opener.document.forms[0].ddlEthnic, '" & txtDictionary.Text.Trim & "', " & intOut & "); opener.document.forms[0].hidEthnic.value = " & intOut & ";</script>")
                    Case "COLLEGE"
                        Page.RegisterClientScriptBlock("AddItem", "<script language='javascript'>AddItem(opener.document.forms[0].ddlCollege, '" & txtDictionary.Text.Trim & "', " & intOut & "); opener.document.forms[0].hidCollege.value = " & intOut & ";</script>")
                    Case "PROVINCE"
                        Page.RegisterClientScriptBlock("AddItem", "<script language='javascript'>AddItem(opener.document.forms[0].ddlProvince, '" & txtDictionary.Text.Trim & "', " & intOut & "); opener.document.forms[0].hidProvince.value = " & intOut & ";</script>")
                    Case "OCCUPATION"
                        Page.RegisterClientScriptBlock("AddItem", "<script language='javascript'>AddItem(opener.document.forms[0].ddlOccupation, '" & txtDictionary.Text.Trim & "', " & intOut & "); opener.document.forms[0].hidOccupation.value = " & intOut & ";</script>")
                    Case "EDUCATION"
                        Page.RegisterClientScriptBlock("AddItem", "<script language='javascript'>AddItem(opener.document.forms[0].ddlEducation, '" & txtDictionary.Text.Trim & "', " & intOut & "); opener.document.forms[0].hidEducation.value = " & intOut & ";</script>")
                    Case "FACULTY"
                        Page.RegisterClientScriptBlock("AddItem", "<script language='javascript'>AddItem(opener.document.forms[0].ddlFaculty, '" & txtDictionary.Text.Trim & "', " & intOut & "); opener.document.forms[0].hidFaculty.value = " & intOut & ";</script>")
                End Select
            End If
        End Sub

        ' Page Unload Method
        ' Call Dispose mthod to release all objects
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Used for release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBFaculty Is Nothing Then
                    objBFaculty.Dispose(True)
                    objBFaculty = Nothing
                End If
                If Not objBEthnic Is Nothing Then
                    objBEthnic.Dispose(True)
                    objBEthnic = Nothing
                End If
                If Not objBEducation Is Nothing Then
                    objBEducation.Dispose(True)
                    objBEducation = Nothing
                End If
                If Not objBOccupation Is Nothing Then
                    objBOccupation.Dispose(True)
                    objBOccupation = Nothing
                End If
                If Not objBCollege Is Nothing Then
                    objBCollege.Dispose(True)
                    objBCollege = Nothing
                End If
                If Not objBProvince Is Nothing Then
                    objBProvince.Dispose(True)
                    objBProvince = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace