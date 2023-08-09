Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WShowRoleOfModule
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

        Dim objBCommonBusiness As New clsBCommonBusiness
        Dim objBRole As New clsBRole

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBRole object
            objBRole.ConnectionString = Session("ConnectionString")
            objBRole.DBServer = Session("DBServer")
            objBRole.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRole.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonBusiness.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WShowRoleOfModule.js'></script>")

            ' Declare variables
            Dim tblRights As DataTable
            Dim tblLocation As DataTable
            Dim strArrJS As String = ""
            Dim strDest As String = ""
            Dim strLocDest As String = ""
            Dim intIndex As Integer

            ' Check the module ID and bind the javscript arrays
            If Not Request.QueryString("ModuleID") Is Nothing Then
                Select Case Request.QueryString("ModuleID")
                    Case 1
                        objBRole.ModuleID = 1
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(2).Text
                        TRLocLabel.Visible = False
                        TRLoc.Visible = False
                    Case 2
                        objBRole.ModuleID = 2
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(3).Text
                        TRLocLabel.Visible = False
                        TRLoc.Visible = False
                    Case 3
                        objBRole.ModuleID = 3
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(4).Text
                        TRLocLabel.Visible = True
                        TRLoc.Visible = True
                    Case 4
                        objBRole.ModuleID = 4
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(5).Text
                        TRLocLabel.Visible = True
                        TRLoc.Visible = True
                    Case 5
                        objBRole.ModuleID = 5
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(6).Text
                        TRLocLabel.Visible = True
                        TRLoc.Visible = True
                    Case 6
                        objBRole.ModuleID = 6
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(9).Text
                        TRLocLabel.Visible = False
                        TRLoc.Visible = False
                    Case 8
                        objBRole.ModuleID = 8
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(7).Text
                        TRLocLabel.Visible = False
                        TRLoc.Visible = False
                    Case 9
                        objBRole.ModuleID = 9
                        lblPageTitle.Text = lblPageTitle.Text & " " & ddlLabel.Items(8).Text
                        TRLocLabel.Visible = False
                        TRLoc.Visible = False
                End Select
                objBRole.UID = 0
                If Session("UserID") <> 1 Then
                    objBRole.ParentID = Session("UserID")
                End If
                ' Get user rights (ALL)
                tblRights = objBRole.GetRights
                ' Compare with the basic right or user right(request) then grand rights
                If Not tblRights Is Nothing Then
                    If tblRights.Rows.Count > 0 Then
                        strArrJS = "<SCRIPT LANGUAGE='JavaScript'>" & Chr(10)
                        strArrJS = strArrJS & "var Rights = new Array(" & tblRights.Rows.Count & ");" & Chr(10)
                        strArrJS = strArrJS & "var IDs = new Array(" & tblRights.Rows.Count & ");" & Chr(10)
                        If Not Request.QueryString("Dest") Is Nothing Then
                            strDest = Request.QueryString("Dest")
                        End If
                        For intIndex = 0 To tblRights.Rows.Count - 1
                            strArrJS = strArrJS & "Rights[" & intIndex & "] = '" & tblRights.Rows(intIndex).Item("Right") & "';" & Chr(10)
                            strArrJS = strArrJS & "IDs[" & intIndex & "] = " & tblRights.Rows(intIndex).Item("ID") & ";" & Chr(10)
                        Next
                        strArrJS = strArrJS & "function ReCheckRights() {" & Chr(10)
                        strArrJS = strArrJS & "grants = "","" + " & strDest & ".value;" & Chr(10)
                        strArrJS = strArrJS & "j = 0;" & Chr(10)
                        strArrJS = strArrJS & "k = 0;" & Chr(10)
                        strArrJS = strArrJS & "for (i = 0; i < " & tblRights.Rows.Count & "; i++) {" & Chr(10)
                        strArrJS = strArrJS & "if (grants.indexOf("","" + IDs[i] + "","") >= 0) {" & Chr(10)
                        strArrJS = strArrJS & "document.forms[0].lstAccept.options.length = j + 1;" & Chr(10)
                        strArrJS = strArrJS & "document.forms[0].lstAccept.options[j].value = IDs[i];" & Chr(10)
                        strArrJS = strArrJS & "document.forms[0].lstAccept.options[j].text = Rights[i];" & Chr(10)
                        strArrJS = strArrJS & "j = j + 1;" & Chr(10)
                        strArrJS = strArrJS & "} else {"
                        strArrJS = strArrJS & "document.forms[0].lstDeny.options.length = k + 1;" & Chr(10)
                        strArrJS = strArrJS & "document.forms[0].lstDeny.options[k].value = IDs[i];" & Chr(10)
                        strArrJS = strArrJS & "document.forms[0].lstDeny.options[k].text = Rights[i];" & Chr(10)
                        strArrJS = strArrJS & "k = k + 1;" & Chr(10)
                        strArrJS = strArrJS & "}" & Chr(10)
                        strArrJS = strArrJS & "}" & Chr(10)

                        ' Get the user locations rights
                        If Not Session("UserID") = 1 Then
                            objBCommonBusiness.UserID = Session("UserID")
                        Else
                            objBCommonBusiness.UserID = 0
                        End If

                        objBCommonBusiness.LibID = clsSession.GlbSite
                        tblLocation = objBCommonBusiness.GetLocations(1)
                        If Request.QueryString("ModuleID") = 3 Or Request.QueryString("ModuleID") = 4 Or Request.QueryString("ModuleID") = 5 Then
                            If Not tblLocation Is Nothing Then
                                If tblLocation.Rows.Count > 0 Then
                                    strArrJS = strArrJS & "var LocRights = new Array(" & tblLocation.Rows.Count & ");" & Chr(10)
                                    strArrJS = strArrJS & "var LocIDs = new Array(" & tblLocation.Rows.Count & ");" & Chr(10)
                                    If Not Request.QueryString("LocDest") Is Nothing Then
                                        strLocDest = Request.QueryString("LocDest")
                                    End If
                                    For intIndex = 0 To tblLocation.Rows.Count - 1
                                        strArrJS = strArrJS & "LocIDs[" & intIndex & "] = " & tblLocation.Rows(intIndex).Item("ID") & ";" & Chr(10)
                                        strArrJS = strArrJS & "LocRights[" & intIndex & "] = '" & tblLocation.Rows(intIndex).Item("LOCNAME") & "';" & Chr(10)
                                    Next
                                    strArrJS = strArrJS & "grants = "","" + " & strLocDest & ".value;" & Chr(10)
                                    strArrJS = strArrJS & "j = 0;" & Chr(10)
                                    strArrJS = strArrJS & "k = 0;" & Chr(10)
                                    strArrJS = strArrJS & "for (i = 0; i < " & tblLocation.Rows.Count & "; i++) {" & Chr(10)
                                    strArrJS = strArrJS & "if (grants.indexOf("","" + LocIDs[i] + "","") >= 0) {" & Chr(10)
                                    strArrJS = strArrJS & "document.forms[0].lstLocAccept.options.length = j + 1;" & Chr(10)
                                    strArrJS = strArrJS & "document.forms[0].lstLocAccept.options[j].value = LocIDs[i];" & Chr(10)
                                    strArrJS = strArrJS & "document.forms[0].lstLocAccept.options[j].text = LocRights[i];" & Chr(10)
                                    strArrJS = strArrJS & "j = j + 1;" & Chr(10)
                                    strArrJS = strArrJS & "} else {"
                                    strArrJS = strArrJS & "document.forms[0].lstLocDeny.options.length = k + 1;" & Chr(10)
                                    strArrJS = strArrJS & "document.forms[0].lstLocDeny.options[k].value = LocIDs[i];" & Chr(10)
                                    strArrJS = strArrJS & "document.forms[0].lstLocDeny.options[k].text = LocRights[i];" & Chr(10)
                                    strArrJS = strArrJS & "k = k + 1;" & Chr(10)
                                    strArrJS = strArrJS & "}" & Chr(10)
                                    strArrJS = strArrJS & "}" & Chr(10)
                                End If
                            End If
                        End If
                        strArrJS = strArrJS & "}" & Chr(10)
                        strArrJS = strArrJS & "</SCRIPT>" & Chr(10)
                        Page.RegisterClientScriptBlock("LoadRights", strArrJS)
                    End If
                End If
            End If

            btnClose.Attributes.Add("OnClick", "javascript:self.close();return false;")
            btnAccept.Attributes.Add("OnClick", "javascript:AddItems();return false;")
            btnDeny.Attributes.Add("OnClick", "javascript:RemoveItems();return false;")
            btnLocAccept.Attributes.Add("OnClick", "javascript:AddLocs(" & strLocDest & ");return false;")
            btnLocDeny.Attributes.Add("OnClick", "javascript:RemoveLocs(" & strLocDest & ");return false;")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRole Is Nothing Then
                    objBRole.Dispose(True)
                    objBRole = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace