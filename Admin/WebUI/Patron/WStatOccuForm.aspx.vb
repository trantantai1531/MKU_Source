' Class: WStatOccuForm
' Puspose: Show statistic by occupation
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatOccuForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblOccupationAlert As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBO As New clsBOccupation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBO object
            objBO.DBServer = Session("DBServer")
            objBO.ConnectionString = Session("ConnectionString")
            objBO.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBO.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(52) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WStatOccuFormJs", "<script language='javascript' src='js/WStatOccuForm.js'></script>")

            btnAdd.Attributes.Add("OnClick", "AddItem();return false;")
            btnRemove.Attributes.Add("OnClick", "RemoveItem();return false;")
            btnStatistic.Attributes.Add("OnClick", "return(CheckOccupation('" & ddlLabel.Items(3).Text & "'));")
            btnBack.Attributes.Add("OnClick", "parent.Workform.location.href='WStatIndex.aspx';return(false);")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblOccupation As New DataTable

            'tblOccupation = InsertOneRow(objBO.GetOccupation, ddlLabel.Items(4).Text)
            tblOccupation = objBO.GetOccupation
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBO.ErrorMsg, ddlLabel.Items(1).Text, objBO.ErrorCode)

            If Not tblOccupation Is Nothing Then
                If tblOccupation.Rows.Count > 0 Then
                    lbSource.DataSource = tblOccupation
                    lbSource.DataTextField = "Occupation"
                    lbSource.DataValueField = "ID"
                    lbSource.DataBind()
                End If
            End If
        End Sub

        ' Method: btnStatistic_Click
        Private Sub btnStatistic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatistic.Click
            Response.Redirect("WStatOccuResult.aspx?IDs=" & txtID.Value)
        End Sub

        ' Method: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBO Is Nothing Then
                objBO.Dispose(True)
                objBO = Nothing
            End If
        End Sub
    End Class
End Namespace