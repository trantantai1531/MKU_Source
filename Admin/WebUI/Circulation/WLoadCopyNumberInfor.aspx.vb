' Class: WLoadCopyNumberInfor
' Puspose: Get informations of CopyNumber to checkin (checkout)
' Creator: Oanhtn
' CreatedDate: 30/08/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WLoadCopyNumberInfor
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
        Private objBCopyNumber As New clsBCopyNumber

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call GetCopyNumberInfor()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' GetCopyNumberInfor method
        ' Purpose: Get all information of the selected CopyNumber
        Private Sub GetCopyNumberInfor()
            Dim intLoanMode As Int16
            Dim intLoanTypeID As Integer
            Dim strCopyNumber = Trim(Request("CopyNumber"))
            Dim tblCopyNumberInfor As DataTable

            If Not strCopyNumber = "" Then
                objBCopyNumber.CopyNumber = strCopyNumber
                tblCopyNumberInfor = objBCopyNumber.GetCopyNumberInfor
                If Not tblCopyNumberInfor Is Nothing Then
                    hidItemID.Value = tblCopyNumberInfor.Rows(0).Item("ItemID")
                    hidLoanTypeID.Value = tblCopyNumberInfor.Rows(0).Item("LoanTypeID")
                    hidLocationID.Value = tblCopyNumberInfor.Rows(0).Item("LocationID")
                End If
            End If
            ' Load CheckOutMain
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCopyNumber Is Nothing Then
                    objBCopyNumber.Dispose(True)
                    objBCopyNumber = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace