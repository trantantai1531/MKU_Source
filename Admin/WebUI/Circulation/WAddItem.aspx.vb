Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WAddItem
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

        ' Declare BusinessRules and clsWCommon class variables
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBForm As New clsBForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindDropdownList()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBCommonBusiness
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.UserID = Session("UserID")
            objBCommonBusiness.Initialize()

            ' Init objBForm object
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Add new copy number right
            If Not CheckPemission(188) Then
                Call WriteErrorMssg(ddlLabel.Items(3).Text)
            End If
        End Sub

        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' src = 'Js/WAddItem.js'></script>")

            btnAdd.Attributes.Add("OnClick", "javascript:if (!Update('" & ddlLabel.Items(2).Text & "')) {return false;}")
            btnDelete.Attributes.Add("OnClick", "javascript:document.forms[0].reset();return false;")
            txt245_a.Attributes.Add("OnChange", "javascript:top.main.Hiddenbase.location.href='WCheckItemTitle.aspx?Value=' + this.value;")
        End Sub

        ' BindDropdownList method
        ' Purpose: Bind the data for Item type and Medium drop down list
        Private Sub BindDropdownList()
            Dim tblItemType As DataTable
            Dim tblMedium As DataTable
            Dim tblSecLevel As DataTable
            Dim tblForm As DataTable

            tblItemType = objBCommonBusiness.GetItemTypes
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

            tblMedium = objBCommonBusiness.GetMediums
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

            If Not tblItemType Is Nothing Then
                If tblItemType.Rows.Count > 0 Then
                    With ddlItemType
                        .DataSource = tblItemType
                        .DataTextField = "Type"
                        .DataValueField = "ID"
                        .DataBind()
                    End With
                End If
            End If

            If Not tblMedium Is Nothing Then
                If tblMedium.Rows.Count > 0 Then
                    With ddlMedium
                        .DataSource = tblMedium
                        .DataTextField = "Medium"
                        .DataValueField = "ID"
                        .DataBind()
                    End With
                End If
            End If

            Dim ArrT() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}
            Dim ArrV() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}

            tblSecLevel = CreateTable(ArrT, ArrV)

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)

            If Not tblSecLevel Is Nothing Then
                If tblSecLevel.Rows.Count > 0 Then
                    ddlSecLevel.DataSource = tblSecLevel
                    ddlSecLevel.DataTextField = "TextField"
                    ddlSecLevel.DataValueField = "ValueField"
                    ddlSecLevel.DataBind()
                End If
            End If

            objBForm.IsAuthority = 0
            tblForm = objBForm.GetForms
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBForm.ErrorMsg, ddlLabel.Items(1).Text, objBForm.ErrorCode)
            If Not tblForm Is Nothing Then
                If tblForm.Rows.Count > 0 Then
                    ddlForm.DataSource = tblForm
                    ddlForm.DataTextField = "Name"
                    ddlForm.DataValueField = "ID"
                    ddlForm.DataBind()
                    ddlForm.SelectedIndex = 0
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace