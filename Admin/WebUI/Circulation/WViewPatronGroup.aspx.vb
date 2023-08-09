' Class WViewPatronGroup
' Puspose: Tìm kiếm thông tin nhóm bạn đọc
' Creator: Tuanhv
' CreatedDate: 26/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: Review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WViewPatronGroup
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
        Private objBPatronGroup As New clsBPatronGroup

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call Bindata()
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBPatronGroup object
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()
        End Sub

        ' Method: Bindata
        ' Purpose: Get information about Patrongroup 
        Private Sub Bindata()
            Dim intPatronGroupID As Integer = CInt(Request("PatronGroupID"))
            Dim tblPatronGroup As DataTable
            Dim tblRowPatron() As DataRow
            Dim tblRow As DataRow

            ' Get information of the selected patrongroup
            tblPatronGroup = objBPatronGroup.GetPatronGroup

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

            If Not tblPatronGroup Is Nothing Then
                tblRowPatron = tblPatronGroup.Select("ID=" & intPatronGroupID)
                For Each tblRow In tblRowPatron
                    lblNameData.Text = tblRow.Item("Name")
                    lblLoanQuotaData.Text = tblRow.Item("LoanQuota")
                    lblInlibraryQuotaData.Text = tblRow.Item("InLibraryQuota")
                    lblHoldQuotaData.Text = tblRow.Item("HoldQuota")
                    LblHoldTurnTimeOutData.Text = tblRow.Item("HoldTurnTimeOut")
                Next
            End If

            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
            tblPatronGroup = Nothing
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronGroup Is Nothing Then
                    objBPatronGroup.Dispose(True)
                    objBPatronGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace