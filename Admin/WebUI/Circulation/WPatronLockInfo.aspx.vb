Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPatronLockInfo
        Inherits clsWBase
        Private objBPatron As New clsBPatron
        Dim strPatronCode As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblCheckOutDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblDueDate As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            strPatronCode = Request("PatronCode")
            Call ShowDetail()
        End Sub

        Private Sub Initialize()
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()
        End Sub
        Private Sub ShowDetail()
            Dim tblResult As DataTable
            objBPatron.PatronCode = strPatronCode
            tblResult = objBPatron.GetPatronLockInfo()
            If Not IsDBNull(tblResult.Rows(0).Item("FullName")) Then
                lblFN.Text &= tblResult.Rows(0).Item("FullName")
            End If
            If Not IsDBNull(tblResult.Rows(0).Item("PatronCode")) Then
                lblCD.Text &= tblResult.Rows(0).Item("PatronCode")
            End If
            If Not IsDBNull(tblResult.Rows(0).Item("Note")) Then
                lblNote.Text &= tblResult.Rows(0).Item("Note")
            End If
            If Not IsDBNull(tblResult.Rows(0).Item("STARTEDDATE")) Then
                lblLock.Text &= tblResult.Rows(0).Item("STARTEDDATE")
            End If
            If Not IsDBNull(tblResult.Rows(0).Item("FINISHDATE")) Then
                lblUnlock.Text &= tblResult.Rows(0).Item("FINISHDATE")
            End If
        End Sub
    End Class
End Namespace
