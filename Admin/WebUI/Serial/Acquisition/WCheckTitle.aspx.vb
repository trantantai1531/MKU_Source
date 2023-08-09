' Class: WCheckTitle
' Puspose: check exist periodical depending on title
' Creator: Tuanhv
' CreatedDate: 23/09/2004
' Modification history:

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WCheckTitle
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
        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()

            'bind data with title exit item and request
            If BinDataExitItem() = False And BindDataExitItemPO() = False Then
                Response.Write(lblAlert.Text)
            End If

        End Sub

        'Get data allow Title you get form CreatedRequest with data in Item
        Function BinDataExitItem() As Boolean
            Dim tblResuft As DataTable
            Dim intCountResuft As Integer
            Dim intRow As Integer
            Dim tblTemp As DataTable
            BinDataExitItem = True
            'objBItemCollection.ItemType = Trim(lblTypeCode.Text)
            objBItemCollection.Title = Request("Title")
            tblResuft = objBItemCollection.GetExistTitles
            intCountResuft = tblResuft.Rows.Count

            Dim arrField1(intCountResuft) As String
            Dim arrField2(intCountResuft) As String
            Dim arrField3(intCountResuft) As String
            If intCountResuft > 0 Then
                For intRow = 0 To intCountResuft - 1
                    arrField2(intRow) = CStr(tblResuft.Rows(intRow).Item("Content"))
                    arrField3(intRow) = CStr(tblResuft.Rows(intRow).Item("ItemID"))
                    arrField1(intRow) = CStr(intRow + 1)
                Next

                ' ????
                ' tblTemp = objWCommon.CreateSomeRowToTable(arrField1, arrField2, arrField3)
                dgrResult.Visible = True
                lnkAvailable1.Visible = True
                dgrResult.DataSource = tblTemp
                dgrResult.DataBind()
            Else
                dgrResult.Visible = False
                lnkAvailable1.Visible = False
                BinDataExitItem = False
            End If
        End Function

        'Get data allow Title you get form CreatedRequest with data in AcqRequest
        Function BindDataExitItemPO() As Boolean
            BindDataExitItemPO = True
            Dim tblResuft As DataTable
            Dim intCountResuft As Integer
            Dim intRow As Integer
            Dim tblTemp As DataTable

            objBItemCollection.Title = Request("Title")
            tblResuft = objBItemCollection.GetExistTitlesPO("TT")
            intCountResuft = tblResuft.Rows.Count

            Dim arrField1(intCountResuft) As String
            Dim arrField2(intCountResuft) As String
            If intCountResuft > 0 Then
                For intRow = 0 To intCountResuft - 1
                    arrField2(intRow) = CStr(tblResuft.Rows(intRow).Item("Title"))
                    arrField1(intRow) = CStr(intRow + 1)
                Next

                tblTemp = CreateTable(arrField1, arrField2)
                dgrResult1.Visible = True
                lbkOrdered2.Visible = True
                dgrResult1.DataSource = tblTemp
                dgrResult1.DataBind()
            Else
                dgrResult1.Visible = False
                lbkOrdered2.Visible = False
                BindDataExitItemPO = False
            End If
        End Function

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBAcqRequest object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.Initialize()
        End Sub

        'Get information allow Title when you check it 
        Private Sub dgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    tblCell = e.Item.Cells(2)
                    Dim lnk As HyperLink
                    lnk = CType(tblCell.FindControl("lnkReuse"), HyperLink)
                    lnk.Font.Bold = True

                    ' Add the attribute for the hiperlink to modify an item
                    lnk.NavigateUrl = "#"
                    lnk.Attributes.Add("onclick", "JavaScript:opener.top.main.Hiddenbase.location.href='WAcqRequestHidden.aspx?ID=" & DataBinder.Eval(e.Item.DataItem, "ArrField3") & "'; self.close();")

            End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace