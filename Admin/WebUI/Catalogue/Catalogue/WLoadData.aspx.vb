Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WLoadData
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
        Private strItemTopNum As String
        Private intType As Integer
        Private strJVScript As String

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBItemCollection object
            objBItemCollection.IsAuthority = Session("IsAuthority")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.Initialize()
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim strTempID As String = ""
            Dim tblItem As DataTable
            Dim strFormID As String

            ' Get the Top number
            strItemTopNum = Request("intTopNum")
            intType = Request("intType")

            ' Get the IDs string and post to the control bar (if get the top number)
            objBItemCollection.TopNum = CInt(strItemTopNum)
            tblItem = objBItemCollection.GetIDByTopNum
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    strTempID = CStr(tblItem.Rows(0).Item(0))

                    objBItemCollection.ItemIDs = strTempID
                    strFormID = CStr(objBItemCollection.GetItemMainInfor().Rows(0).Item("FormID"))
                    Page.RegisterClientScriptBlock("JSPostFormID", "<script language='javascript'>parent.Sentform.document.forms[0].hidFormID.value = " & strFormID & ";</script>")
                    strJVScript = "parent.Sentform.document.forms[0].ItemID.value =" & strTempID & ";"
                    Page.RegisterClientScriptBlock("JSPostItemID", "<script language='javascript'>" & strJVScript & "</script>")
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
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