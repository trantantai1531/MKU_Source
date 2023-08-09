' WMarcFieldSend class
' Creator: Oanhtn
' CreatedDate: 10/05/2004
' Modification history
'   - 22/02/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldSend
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJS()
            Call BindData()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcFieldSendJs", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcFieldSend.js'></script>")

            btnProcess.Attributes.Add("OnClick", "javascript:CheckAll('" & ddlLabel.Items(2).Text & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "', '" & ddlLabel.Items(6).Text & "', '" & ddlLabel.Items(7).Text & "', '" & ddlLabel.Items(8).Text & "', '" & ddlLabel.Items(9).Text & "'); return false;")
        End Sub

        ' BindData method
        ' Purpose: set text for button's text
        Private Sub BindData()
            Dim strCreate As String = ddlLabel.Items(0).Text
            Dim strUpdate As String = ddlLabel.Items(1).Text

            If CStr(Request("FieldCode")) = "0" Then
                btnProcess.Text = strCreate
                If Not CheckPemission(19) Then
                    btnProcess.Enabled = False
                End If
            Else
                btnProcess.Text = strUpdate
                If Not CheckPemission(20) Then
                    btnProcess.Enabled = False
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace