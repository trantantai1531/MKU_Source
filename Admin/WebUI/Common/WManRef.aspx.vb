' Class: WManRef
' Puspose: Management references

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI
    Partial Class WManRef
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBRef As New clsBReference

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindTitle()
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all object
        Private Sub Initialize()
            ' Init objBRef object
            objBRef.DBServer = Session("DBServer")
            objBRef.InterfaceLanguage = Session("InterfaceLanguage")
            objBRef.ConnectionString = Session("ConnectionString")
            Call objBRef.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../js/WManRef.js'></script>")
        End Sub

        ' BindTitle method
        Private Sub BindTitle()
            Dim intModule As Integer

            If IsNumeric(Session("ModuleID") & "") Then
                intModule = CInt(Session("ModuleID"))
            Else
                intModule = 1
            End If

            Select Case intModule
                Case 1 ' CATALOGUE
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(3).Text
                Case 2 ' PATRON
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(4).Text
                Case 3 ' CIRCULATION
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(5).Text
                Case 4 ' ACQUISITION
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(6).Text
                Case 5 ' SERIAL
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(7).Text
                Case 6 ' ADMIN
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(10).Text
                Case 8 ' ILL
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(8).Text
                Case 9 ' E-DELIVERY
                    lblTitle.Text = lblTitle.Text & " " & ddlLabel.Items(9).Text
            End Select
        End Sub

        ' Method: BindData
        Private Sub BindData(Optional ByVal intPg As Integer = 0)
            Dim tblData As DataTable
            Dim dvFavourit As DataView
            Dim strFavourit As String = ""
            Dim intIndex As Integer
            Dim strArrJS As String = ""

            If IsNumeric(Session("UserID") & "") Then
                objBRef.UserID = CInt(Session("UserID"))
            Else
                objBRef.UserID = 1
            End If

            If IsNumeric(Session("ModuleID") & "") Then
                objBRef.ModuleID = CInt(Session("ModuleID"))
            Else
                objBRef.ModuleID = 1
            End If


            tblData = objBRef.GetReference()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRef.ErrorMsg, ddlLabel.Items(0).Text, objBRef.ErrorCode)

            If Not tblData Is Nothing Then
                If tblData.Rows.Count > 0 Then
                    dvFavourit = New DataView
                    dvFavourit.Table = tblData

                    dvFavourit.RowFilter = "IsRef=1"
                    If dvFavourit.Count > 0 Then
                        For intIndex = 0 To dvFavourit.Count - 1
                            strFavourit = strFavourit & dvFavourit.Item(intIndex).Row("ID") & ","
                        Next
                    End If

                    hidRef.Value = strFavourit

                    strArrJS = "<SCRIPT LANGUAGE='JavaScript'>" & Chr(10)
                    strArrJS = strArrJS & "var Refs = new Array(" & tblData.Rows.Count & ");" & Chr(10)
                    strArrJS = strArrJS & "var IDs = new Array(" & tblData.Rows.Count & ");" & Chr(10)

                    For intIndex = 0 To tblData.Rows.Count - 1
                        strArrJS = strArrJS & "Refs[" & intIndex & "] = '" & tblData.Rows(intIndex).Item("Name") & "';" & Chr(10)
                        strArrJS = strArrJS & "IDs[" & intIndex & "] = " & tblData.Rows(intIndex).Item("ID") & ";" & Chr(10)
                    Next
                    strArrJS = strArrJS & "function ReCheckRefs() {" & Chr(10)
                    strArrJS = strArrJS & "grants = "","" + " & "document.forms[0].hidRef.value;" & Chr(10)
                    'strArrJS = strArrJS & "grants = "","" + " & strFavourit & Chr(10)
                    strArrJS = strArrJS & "j = 0;" & Chr(10)
                    strArrJS = strArrJS & "k = 0;" & Chr(10)
                    strArrJS = strArrJS & "for (i = 0; i < " & tblData.Rows.Count & "; i++) {" & Chr(10)
                    strArrJS = strArrJS & "if (grants.indexOf("","" + IDs[i] + "","") >= 0) {" & Chr(10)
                    strArrJS = strArrJS & "document.forms[0].lstAccept.options.length = j + 1;" & Chr(10)
                    strArrJS = strArrJS & "document.forms[0].lstAccept.options[j].value = IDs[i];" & Chr(10)
                    strArrJS = strArrJS & "document.forms[0].lstAccept.options[j].text = Refs[i];" & Chr(10)
                    strArrJS = strArrJS & "j = j + 1;" & Chr(10)
                    strArrJS = strArrJS & "} else {"
                    strArrJS = strArrJS & "document.forms[0].lstDeny.options.length = k + 1;" & Chr(10)
                    strArrJS = strArrJS & "document.forms[0].lstDeny.options[k].value = IDs[i];" & Chr(10)
                    strArrJS = strArrJS & "document.forms[0].lstDeny.options[k].text = Refs[i];" & Chr(10)
                    strArrJS = strArrJS & "k = k + 1;" & Chr(10)
                    strArrJS = strArrJS & "}" & Chr(10)
                    strArrJS = strArrJS & "}" & Chr(10)

                    strArrJS = strArrJS & "}" & Chr(10)
                    strArrJS = strArrJS & "</SCRIPT>" & Chr(10)
                    Page.RegisterClientScriptBlock("LoadFavour", strArrJS)

                    btnAccept.Attributes.Add("OnClick", "javascript:AddItems();return false;")
                    btnDeny.Attributes.Add("OnClick", "javascript:RemoveItems();return false;")
                End If
            End If
        End Sub

        ' Event: btnSave_Click
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim strIDs As String = ""
            Dim bytModuleID As Byte

            If hidRef.Value <> "," Then
                If hidRef.Value.Trim <> "" Then
                    strIDs = Left(hidRef.Value, Len(hidRef.Value) - 1)
                End If
                objBRef.RefIDs = strIDs
                If IsNumeric(Session("UserID") & "") Then
                    objBRef.UserID = CInt(Session("UserID"))
                Else
                    objBRef.UserID = 0
                End If
                If IsNumeric(Session("ModuleID") & "") Then
                    objBRef.ModuleID = CInt(Session("ModuleID"))
                    bytModuleID = CInt(Session("ModuleID"))
                Else
                    objBRef.ModuleID = 0
                    bytModuleID = 0
                End If
                Call objBRef.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBRef.ErrorMsg, ddlLabel.Items(0).Text, objBRef.ErrorCode)

                ' Alter message
                Page.RegisterClientScriptBlock("Alter", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                Call BindData()
                Page.RegisterClientScriptBlock("RefreshReference", "<script language='javascript'>parent.Refernce.location.href='../Common/WReference.aspx';</script>")
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRef Is Nothing Then
                    objBRef.Dispose(True)
                    objBRef = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace