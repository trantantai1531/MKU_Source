' class WMoveLoc
' Puspose: move a location to another
' Creator: Lent
' CreatedDate: 23-2-2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WMoveLocationHidden
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
        Private objBLocation As New clsBLocation

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Initialize()
            Call LoadBackData()
        End Sub

        '********* Initialize objects's Property
        Public Sub Initialize()
            ' Initialize objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBLocation.Initialize()
        End Sub

        ' ********* Load back data
        Private Sub LoadBackData()
            Dim strScript As String = ""
            Dim intLibID As Integer = 0
            Dim TempTable As New DataTable
            Dim strPathForm As String = "parent.mainacq.document.forms[0]."
            Dim inti As Integer

            If Request("LibID") & "" <> "" Then
                intLibID = CInt(Request("LibID"))
            End If

            If UCase(Request("Action")) = "SOURCE" Then
                intLibID = CInt(Request("LibID"))
                objBLocation.LibID = intLibID
                objBLocation.UserID = Session("UserID")
                objBLocation.LocID = 0
                objBLocation.Status = -1
                TempTable = objBLocation.GetLocation
                Call WriteErrorMssg(objBLocation.ErrorCode, objBLocation.ErrorMsg)
                If Not TempTable Is Nothing Then
                    strScript = strScript & strPathForm & "ddlLocSource.options.length=0;"
                    For inti = 0 To TempTable.Rows.Count - 1
                        strScript = strScript & strPathForm & "ddlLocSource.options.length++;"
                        strScript = strScript & strPathForm & "ddlLocSource.options[" & strPathForm & "ddlLocSource.options.length-1].value=" & TempTable.Rows(inti).Item("ID") & ";"
                        strScript = strScript & strPathForm & "ddlLocSource.options[" & strPathForm & "ddlLocSource.options.length-1].text='" & TempTable.Rows(inti).Item("Symbol") & "';"
                    Next
                End If
            Else
                intLibID = CInt(Request("LibID"))
                objBLocation.LibID = intLibID
                objBLocation.UserID = Session("UserID")
                objBLocation.LocID = 0
                objBLocation.Status = -1
                TempTable = objBLocation.GetLocation
                Call WriteErrorMssg(objBLocation.ErrorCode, objBLocation.ErrorMsg)
                If Not TempTable Is Nothing Then
                    strScript = strScript & strPathForm & "ddlLocDestination.options.length=0;"
                    For inti = 0 To TempTable.Rows.Count - 1
                        strScript = strScript & strPathForm & "ddlLocDestination.options.length++;"
                        strScript = strScript & strPathForm & "ddlLocDestination.options[" & strPathForm & "ddlLocDestination.options.length-1].value=" & TempTable.Rows(inti).Item("ID") & ";"
                        strScript = strScript & strPathForm & "ddlLocDestination.options[" & strPathForm & "ddlLocDestination.options.length-1].text='" & TempTable.Rows(inti).Item("Symbol") & "';"
                    Next
                End If
            End If
            Page.RegisterClientScriptBlock("LoadBackData", "<script language='javascript'>" & strScript & "</script>")
        End Sub
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace