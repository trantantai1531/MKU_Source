Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCataForm
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
        Private objBCommon As New clsBCommonBusiness
        Private objBPO As New clsBPurchaseOrder
        Private objBForm As New clsBForm
        Private objBLoanType As New clsBLoanType

        ' Init all object
        Private Sub Initialize()
            ' Init BCommonBusiness object
            objBCommon.DBServer = Session("DBServer")
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.ConnectionString = Session("ConnectionString")
            Call objBCommon.Initialize()

            ' Init BPurchaseOrder object
            objBPO.DBServer = Session("DBServer")
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()

            ' Init objBForm
            objBForm.DBServer = Session("DBServer")
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()

            ' Init clsBLoanType object
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(43) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' Load data for all controls
        Private Sub LoadData()
            Dim inti As Integer
            Dim tblTemp As New DataTable

            ' Cataloge bibliography temp
            ddlFormID.DataSource = objBForm.GetForms
            ddlFormID.DataTextField = "Name"
            ddlFormID.DataValueField = "ID"
            ddlFormID.DataBind()

            ' Item type
            tblTemp = objBCommon.GetItemTypes()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlItemType.DataSource = tblTemp
                ddlItemType.DataTextField = "Type"
                ddlItemType.DataValueField = "Type"
                ddlItemType.DataBind()
                For inti = 0 To tblTemp.Rows.Count - 1
                    If CStr(tblTemp.Rows(inti).Item("TypeCode")).ToLower = "sh" Then
                        ddlItemType.SelectedIndex = inti
                        Exit For
                    End If
                Next
            End If

            tblTemp.Clear()

            ' Medium
            tblTemp = objBCommon.GetMediums()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlMedium.DataSource = tblTemp
                ddlMedium.DataTextField = "Medium"
                ddlMedium.DataValueField = "Medium"
                ddlMedium.DataBind()

                For inti = 0 To tblTemp.Rows.Count - 1
                    If CStr(tblTemp.Rows(inti).Item("Code")).ToLower = "g" Then
                        ddlMedium.SelectedIndex = inti
                        Exit For
                    End If
                Next
            End If

            tblTemp.Clear()

            objBLoanType.LibID = clsSession.GlbSite
            tblTemp = objBLoanType.GetLoanTypes
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLoanType.DataSource = tblTemp
                ddlLoanType.DataTextField = "LoanType"
                ddlLoanType.DataValueField = "ID"
                ddlLoanType.DataBind()
                tblTemp.Clear()
            End If

            tblTemp.Clear()

            ' AcqSource ddropdownlist
            tblTemp = objBCommon.GetAcqSources
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlAcqSource.DataSource = tblTemp
                ddlAcqSource.DataTextField = "Source"
                ddlAcqSource.DataValueField = "ID"
                ddlAcqSource.DataBind()
                tblTemp.Clear()
            End If
            tblTemp.Clear()

            ' Record type
            ddlRecType.DataSource = objBCommon.GetRecordTypes
            ddlRecType.DataTextField = "Description"
            ddlRecType.DataValueField = "Code"
            ddlRecType.DataBind()

            ' Directory level
            ddlLevelDir.DataSource = objBCommon.GetDirLevels
            ddlLevelDir.DataTextField = "Description"
            ddlLevelDir.DataValueField = "Code"
            ddlLevelDir.DataBind()

            ' Ordered item by contract
            objBPO.LibID = clsSession.GlbSite
            ddlAcqPO_ITEM.DataSource = InsertOneRow(objBPO.GetListPOs, ddlLabel.Items(3).Text)
            ddlAcqPO_ITEM.DataValueField = "ID"
            ddlAcqPO_ITEM.DataTextField = "Title"
            ddlAcqPO_ITEM.DataBind()

            Dim ArrT() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}
            Dim ArrV() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}

            ddlLevelSec.DataSource = CreateTable(ArrT, ArrV)
            ddlLevelSec.DataTextField = "TextField"
            ddlLevelSec.DataValueField = "ValueField"
            ddlLevelSec.DataBind()

            If Request.QueryString("strTitle") <> "" Then
                txt245_a.Text = Request.QueryString("strTitle")
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../js/ACQ/WCataForm.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnUpdate.Attributes.Add("OnClick", "return Update_cl('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(6).Text & "');")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")

            'Me.SetOnclickZ3950(btnZ3950, "../..")
            btnZ3950.Attributes.Add("OnClick", "return OpenZ3950();")
            ddlAcqPO_ITEM.Attributes.Add("OnChange", "BookChange(); return false;")

            lnkHelp.NavigateUrl = "javascript:ShowPub()"
            lnkListCataQueu.NavigateUrl = "javascript:ShowListCat()"

            txt020_a.Attributes.Add("OnChange", "CheckISBN();")
            txt245_a.Attributes.Add("OnChange", "Check245();")
        End Sub

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call LoadData()
            End If
            Call BindJS()
        End Sub

        ' Page_UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
                End If
                If Not objBCommon Is Nothing Then
                    objBCommon.Dispose(True)
                    objBCommon = Nothing
                End If
                If Not objBPO Is Nothing Then
                    objBPO.Dispose(True)
                    objBPO = Nothing
                End If
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace