Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WILLInComingHidden
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
        Private objBCommonDBSystem As New clsBCommonDBSystem

        'Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
        End Sub

        Private Sub Initialize()
            '  Init objBCommonDBSystem
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.Initialize()
        End Sub

        Private Sub LoadData()
            Dim dtbLib As DataTable
            objBCommonDBSystem.SQLStatement = "SELECT ID,Code FROM ILL_LIBRARIES WHERE LibrarySymbol = '" & Request.QueryString("RequesterSymbol") & "' AND PostDelivCountry = " & Request.QueryString("PostDelivCountry") & " AND EmailReplyAddress = '" & Request.QueryString("EmailReplyAddress") & "'"
            dtbLib = objBCommonDBSystem.RetrieveItemInfor
            If Not dtbLib Is Nothing AndAlso dtbLib.Rows.Count > 0 Then
                Page.RegisterClientScriptBlock("Exits", "if (confirm('?')==true) parent.Workform.document.forms[0].hidDublicate.value=1;")
            End If
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace