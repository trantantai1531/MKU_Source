
Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCardPrintCardSuccessful
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
        Private objBPC As New clsBPatronCollection
        Private objBP As New clsBPatron
        Dim intMaxest As Integer = 0

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData1()
            End If
            Call BindJS()
        End Sub

        ' Method: Initialize
        Public Sub Initialize()
            ' Initialize objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.DBServer = Session("DBServer")
            Call objBPC.initialize()

            ' Initialize objBP object
            objBP.InterfaceLanguage = Session("InterfaceLanguage")
            objBP.ConnectionString = Session("ConnectionString")
            objBP.DBServer = Session("DBServer")
            Call objBP.Initialize()
        End Sub

        ' Method: CheckFormPermission 
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(148) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCardPrintSuccessfulLs", "<script language = 'javascript' src = 'js/WCardPrintSuccessful.js'></script>")
            btnSave.Attributes.Add("OnClick", "if(!CheckOptionsNull('DgrPrinted', 'chkID', 2, 500, '" & ddlLabel.Items(3).Text & "')) return false;")
            btnClose.Attributes.Add("OnClick", "CloseForm();")
        End Sub

        ' BindData1 method
        Private Function BindData1() As Integer
            Dim strID As String
            Dim tblData As New DataTable

            If Not (Session("TemplateID") Is Nothing) Then
                txtTemplateID.Text = Session("TemplateID")
            Else
                txtTemplateID.Text = "1"
            End If

            strID = Replace(Session("strPatronIDs"), " ", "")
            hdIDs.Value = strID

            If strID <> "" Then
                tblData = objBPC.GetCardNotPrinted(strID)

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

                DgrPrinted.DataSource = tblData
                DgrPrinted.DataBind()
                intMaxest = tblData.Rows.Count
            End If
            BindData1 = intMaxest

            tblData.Dispose()
            tblData = Nothing
        End Function

        ' BindData method
        Private Function BindData() As Integer
            Dim strID As String
            Dim intMax As Integer = 1
            Dim tblData As New DataTable
            If Not (Session("TemplateID") Is Nothing) Then
                txtTemplateID.Text = Session("TemplateID")
            Else
                txtTemplateID.Text = "1"
            End If
            DgrPrinted.Visible = False
            strID = hdIDs.Value
            If strID <> "" Then
                tblData = objBPC.GetCardNotPrinted(strID)
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)
                If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                    DgrPrinted.Visible = True
                    DgrPrinted.DataSource = tblData
                    DgrPrinted.DataBind()
                    intMax = tblData.Rows.Count
                End If
            End If
            BindData = intMax
            tblData.Dispose()
            tblData = Nothing
        End Function

        ' Event: btnSave_Click
        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim chkSelected As CheckBox
            Dim strSelectedIDs As String = ""
            Dim strNotSelectedIDs As String = ""
            Dim dtgItem As DataGridItem

            ' Return the IDs string for deletting
            For Each dtgItem In DgrPrinted.Items
                chkSelected = dtgItem.FindControl("chkID")
                If chkSelected.Checked Then
                    strSelectedIDs = strSelectedIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                Else
                    strNotSelectedIDs = strNotSelectedIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                End If
            Next
            If Right(strNotSelectedIDs, 1) = "," Then
                strNotSelectedIDs = Left(strNotSelectedIDs, Len(strNotSelectedIDs) - 1)
            End If
            hdIDs.Value = strNotSelectedIDs
            If Trim(strSelectedIDs) <> "" Then
                objBPC.InsertPatronPrintCard(strSelectedIDs, CInt(txtTemplateID.Text), CInt(txtIssueLibraryID.Text))

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)
            End If
            Call BindData()
        End Sub

        ' Method: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBP Is Nothing Then
                objBP.Dispose(True)
                objBP = Nothing
            End If
            If Not objBPC Is Nothing Then
                objBPC.Dispose(True)
                objBPC = Nothing
            End If
        End Sub
    End Class
End Namespace