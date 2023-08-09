' class 
' Puspose: Change Status
' Creator: Sonnt
' CreatedDate: 07/04/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition

    Partial Class WPOChangeStatus
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

        Private objBIO As New clsBItemOrder
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                hdPOID.Value = Request.QueryString("POID")
                hdStatusID.Value = Request.QueryString("StatusID")
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WAcqForm2Js", "<script language='javascript' src='../Js/ACQ/WCopyNumRem.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkSetDate, txtSetDate, ddlLabel.Items(3).Text)
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblData As New DataTable
            Dim inti As Integer
            Try
                tblData = objBIO.GetAcqStatus
                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        ddlStatus.DataSource = tblData
                        ddlStatus.DataTextField = "Status"
                        ddlStatus.DataValueField = "ID"
                        ddlStatus.DataBind()
                        If hdStatusID.Value <> 0 Then
                            For inti = 0 To ddlStatus.Items.Count - 1
                                If ddlStatus.Items(inti).Value = hdStatusID.Value Then
                                    ddlStatus.Items(inti).Selected = True
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If
            Catch ex As Exception
            Finally
                tblData.Dispose()
                tblData = Nothing
            End Try
            txtSetDate.Text = ""
            txtNote.Text = ""
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Try
                objBIO.POID = hdPOID.Value
                objBIO.StatusID = ddlStatus.SelectedValue
                objBIO.SetDate = Trim(txtSetDate.Text)
                objBIO.Note = txtNote.Text
                objBIO.InsertAcqPoStatus()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Call BindData()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub
    End Class
End Namespace
