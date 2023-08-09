' WIdxIdx class
' Purpose: Show index page
' Creator: Kiemdv
' CreatedDate: 28/07/2004
' Modification history 
'   - 22/02/2005 by Tuanhv: review

' ?????????????????? Error

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIdxIdx
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

        Private objBIdxIdx As New clsBIdxIdx

        ' Event Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all variables for objects and form
        Private Sub Initialize()
            ' Object objBIdxIdx
            objBIdxIdx.DBServer = Session("DBServer")
            objBIdxIdx.ConnectionString = Session("ConnectionString")
            objBIdxIdx.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBIdxIdx.Initialize()
        End Sub

        ' BindData sub
        ' Purpose: Bind data for Controls
        Private Sub BindData()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Response.Write(objBIdxIdx.LoadData(Request("FieldSToIndex"), Request("BibliographyName"), Request("BibliographyCode"), ddlLabel.Items(0).Text))
        End Sub

        ' Event Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBIdxIdx Is Nothing Then
                        objBIdxIdx.Dispose(True)
                        objBIdxIdx = Nothing
                    End If
                Else
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace