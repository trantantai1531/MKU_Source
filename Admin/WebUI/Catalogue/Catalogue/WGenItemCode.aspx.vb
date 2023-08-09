' WCataSent class
' Purpose: Generate new ItemCode
' Creator: Oanhtn
' CreatedDate: 02/04/2004
' Modification history:
'   - 02/03/2005 by Oanhtn: review & test

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WGenItemCode
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
        Private objBInput As New clsBInput

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call GenItemCode()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBInput object
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            objBInput.DBServer = Session("DBServer")
            objBInput.ConnectionString = Session("ConnectionString")
            Call objBInput.Initialize()

            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
        End Sub

        ' GenItemCode method
        ' Purpose: generate the code of new item
        Private Sub GenItemCode()
            Dim strItemCode As String = ""
            Dim strErrorMsg As String = ""

            Try
                strItemCode = objBInput.Gen001(CInt(Session("IsAuthority")))
            Catch ex As Exception
                strErrorMsg = ex.Message.ToCharArray
            End Try

            If Not strItemCode = "" Then
                Page.RegisterClientScriptBlock("LoadBackData", "<script language = 'javascript'>parent.Workform.document.forms[0].tag001.value='" & strItemCode & "'; parent.Sentform.document.forms[0].tag001.value='" & strItemCode & "'; u('001'); UpdateLeader('', '', '', 'parent.Workform.document.forms[0].txtLeader');</script>")
            Else
                Call WriteErrorMssg(0, strErrorMsg)
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
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace