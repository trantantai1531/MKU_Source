' class: WCopyNumber
' Puspose: Management system copynumber
' Creator: Vantd
' CreatedDate: 01/02/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports System.Globalization
Imports System.IO
Imports Microsoft.Office.Interop
Imports OfficeOpenXml
Imports OfficeOpenXml.Style


Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class UpdateDataBse
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMsgAlert As System.Web.UI.WebControls.Label
        Protected WithEvents lblExisting As System.Web.UI.WebControls.Label
        Protected WithEvents lblMesErr1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMesErr2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCB As New clsBCommonBusiness
        Private objBLib As New clsBLibrary
        Private objBLoc As New clsBLocation
        Private objBCopyNumber As New clsBCopyNumber
        Private objBInput As New clsBInput
        Private objBLoanType As New clsBLoanType
        Private objBItem As New clsBItem
        Private objBItemCol As New clsBItemCollection
        Private objBDB As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()

            If Not Page.IsPostBack Then

            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check form permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(44) Then

            End If
            If Not CheckPemission(103) Then

            End If
            If Not CheckPemission(104) Then

            End If
        End Sub



        ' Method: Initialize
        ' Purpose: Init all need objects
        Sub Initialize()
            ' Init objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            ' Init objBLib object
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            Call objBLib.Initialize()

            ' Init objBLoc object
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            objBLoc.Initialize()

            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()

            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            ' Init objBLoanType object
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()

            ' Init objBItem object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()

            ' Init objBItemCol object
            objBItemCol.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCol.DBServer = Session("DBServer")
            objBItemCol.ConnectionString = Session("ConnectionString")
            Call objBItemCol.Initialize()

            ' Init objBDB object
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBDB.DBServer = Session("DBServer")
            objBDB.ConnectionString = Session("ConnectionString")
            Call objBDB.Initialize()

        End Sub




        ' Method: Page_Unload
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub



        Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            Dim query = txtQuery.InnerText.Trim()
            Dim checkContainSelect = query.Split(" ")(0)
            lblMessage.Text = ""
            lblMessage.ForeColor = Color.Red
            If checkContainSelect.Contains("select") Then
                Dim resultData = objBCB.ExcuteQuery(query)
                dtgResult.Visible = True
                dtgResult.DataSource = resultData
                dtgResult.DataBind()
            Else
                Dim result = objBCB.ExcuteQuery(query)

                If Not result Is Nothing AndAlso result.Rows.Count > 0 Then
                    dtgResult.Visible = True
                    dtgResult.DataSource = result
                    dtgResult.DataBind()
                Else
                    lblMessage.Text = "Cập nhật dữ liệu thành công"

                End If


                'If result.Rows(0).Item() Then
                '    Page.RegisterClientScriptBlock("GenJs", "<script language = 'javascript'> alert('Cập nhật dữ liệu thành công')</script>")
                'Else
                '    Page.RegisterClientScriptBlock("GenJs", "<script language = 'javascript'> alert('Có lỗi trong quá trình xử lý')</script>")
                'End If
            End If
        End Sub



        ' Method: Dispose
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCB Is Nothing Then
                    objBCB.Dispose(True)
                    objBCB = Nothing
                End If
                If Not objBLib Is Nothing Then
                    objBLib.Dispose(True)
                    objBLib = Nothing
                End If
                If Not objBLoc Is Nothing Then
                    objBLoc.Dispose(True)
                    objBLoc = Nothing
                End If
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBItemCol Is Nothing Then
                    objBItemCol.Dispose(True)
                    objBItemCol = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub



        Protected Sub dtgResult_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            dtgResult.CurrentPageIndex = e.NewPageIndex
            Dim query = txtQuery.InnerText.Trim()
            Dim checkContainSelect = query.Split(" ")(0)
            If checkContainSelect.Contains("select") Then
                Dim resultData = objBCB.ExcuteQueryToDatatable(query)
                dtgResult.DataSource = resultData
                dtgResult.DataBind()
            End If
        End Sub

        Protected Sub dtgResult_PreRender(sender As Object, e As EventArgs) Handles dtgResult.PreRender

            Dim dg As DataGrid = sender

            If dg.AllowPaging = True And dg.AutoGenerateColumns = True Then
                'Get the Table
                If dg.Controls.Count > 0 Then
                    Dim tab As System.Web.UI.WebControls.Table =
                    dg.Controls(0)
                    'Change the Top Pager
                    If dg.PagerStyle.Position = PagerPosition.Bottom Or
                    dg.PagerStyle.Position = PagerPosition.TopAndBottom Then
                        tab.Rows(tab.Rows.Count - 1).Cells(0).Attributes.Add("colspan", tab.Rows(1).Cells.Count.ToString())
                        'Change the Bottom Pager
                        If (dg.PagerStyle.Position = PagerPosition.Top Or
                        dg.PagerStyle.Position = PagerPosition.TopAndBottom) Then

                            tab.Rows(0).Cells(0).Attributes.Add("colspan", tab.Rows(1).Cells.Count.ToString())
                        End If
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace