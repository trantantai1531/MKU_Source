' Class: WHiddenPatron
' Purpose: Check patron code
' Creator: Kiemdv
' Created Date: 02/02/2005

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WHiddenPatron
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
        Private objBPatronCollection As New clsBPatronCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Select Case Request("Action")
                Case "CheckCode"
                    Call CheckCode()
            End Select
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' objBPatronCollection's property        
            objBPatronCollection.DBServer = Session("DBServer")
            objBPatronCollection.ConnectionString = Session("ConnectionString")
            objBPatronCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronCollection.initialize()
        End Sub

        ' Method: CheckCode
        Private Sub CheckCode()
            Dim arrData()
            Dim strChar As String
            Dim inti As Integer
            strChar = "!@#$%^&*()_+|':?.>,</\=-"
            Dim strCode As String = Trim(Request("Code"))
            For inti = 0 To strCode.Length - 1
                If InStr(strChar, strCode.Substring(inti, 1)) > 0 Then
                    Page.RegisterClientScriptBlock("CheckCode", "<script language = 'javascript'>alert('" & lblError.Text & "'); parent.Workform.document.forms[0].txtCode.value='';</script>")
                    Exit Sub
                End If
            Next
            objBPatronCollection.TypeSearch = "Simple"
            objBPatronCollection.Code = Trim(Request("Code"))

            arrData = objBPatronCollection.Search()

            If arrData(0) <> -1 Then
                Page.RegisterClientScriptBlock("CheckCode", "<script language = 'javascript'>alert('" & msgExistCode.Text & "'); parent.Workform.document.forms[0].txtCode.value='';</script>")
            End If
        End Sub

        ' Method: Page_Unload
        ' Purpose: Dispose all object when Ubload form
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronCollection Is Nothing Then
                    objBPatronCollection.Dispose(True)
                    objBPatronCollection = Nothing
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace