' WCheckItemCode class
' Purpose: Check exist item depending on ItemCode
' Creator: Oanhtn
' CreatedDate: 23/05/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCheckItemCode
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
        Private objBItem As New clsBItem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call Process()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBItem object
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()

            ' LoadJs functions
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Process method
        ' Purpose: check existing itemcode and loadback cataloguing form
        Private Sub Process()
            Dim strItemCode As String = Request("ItemCode")
            Dim strSessionID As String = Session.SessionID
            Dim strJavaScript As String
            Dim tblTemp As DataTable

            ' Check exists
            objBItem.Code = strItemCode
            objBItem.SessionID = strSessionID
            objBItem.IsUnion = 1 ' check also ITEM table
            tblTemp = objBItem.GetReserveItemCode

            If tblTemp Is Nothing Then
                If tblTemp.Rows.Count = 0 Then
                    Call objBItem.CreateItemCodeRes()
                Else
                    strJavaScript = strJavaScript & "alert('" & lblLabel1.Text & "');" & Chr(10)
                    strJavaScript = strJavaScript & "parent.Workform.document.forms[0].tag001.value = '';" & Chr(10)
                    strJavaScript = strJavaScript & "parent.Workform.document.forms[0].tag001.focus();" & Chr(10)
                    Page.RegisterClientScriptBlock("Exists", "<script language = 'javascript'>" & strJavaScript & "</script>")
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
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace