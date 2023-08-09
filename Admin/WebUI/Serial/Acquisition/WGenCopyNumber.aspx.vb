' Class: WGenCopyNumber
' Puspose: Generate copynumber
' Creator: Oanhtn
' CreatedDate: 22/04/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WGenCopyNumber
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
        Private objBCopyNumer As New clsBCopyNumber

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadBackData()
        End Sub

        ' Method: LoadBackData
        ' Purpose: load back data to opener form
        Private Sub LoadBackData()
            Dim strJS As String = ""
            Dim intLocID As Integer = 0
            Dim strCopyNumber As String = ""

            If Request("LocID") & "" <> "" Then
                intLocID = CInt(Request("LocID"))
            End If
            objBCopyNumer.LocID = intLocID
            strCopyNumber = objBCopyNumer.GenCopyNumber()
            ' Write error
            Call WriteErrorMssg(objBCopyNumer.ErrorCode, objBCopyNumer.ErrorMsg)

            strJS = "parent.Workform.document.forms[0].txtCopyNumber.value='" & strCopyNumber & "'"
            Page.RegisterClientScriptBlock("selfJs", "<script language = 'javascript' >" & strJS & ";</script>")
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Init for objBCommon
            objBCopyNumer.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumer.DBServer = Session("DBServer")
            objBCopyNumer.ConnectionString = Session("ConnectionString")
            Call objBCopyNumer.Initialize()
        End Sub

        ' Method: Page_Unload
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCopyNumer Is Nothing Then
                    objBCopyNumer.Dispose(True)
                    objBCopyNumer = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace