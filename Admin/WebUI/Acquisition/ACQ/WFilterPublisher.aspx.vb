Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WFilterPublisher
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

        Private objBDic As New clsBDictionary

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call BindData()
        End Sub

        ' Method: BindJS
        Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("Onclick", "self.close();return false;")

            lstPublisher.Attributes.Add("Onclick", "if (document.forms[0].lstPublisher.options.length > 0 ) {opener.document.forms[0].txt260_b.value=document.forms[0].lstPublisher.options[document.forms[0].lstPublisher.selectedIndex].text; self.close();} ")
        End Sub

        ' Method: BindData
        Sub BindData()
            Dim tblData As DataTable
            objBDic.DisplayEntry = Request.QueryString("val")

            tblData = objBDic.GetPublisher
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                lstPublisher.DataSource = tblData
                lstPublisher.DataTextField = "DisplayEntry"
                lstPublisher.DataValueField = "ID"
                lstPublisher.DataBind()
            End If
        End Sub

        ' Method: Initialize
        ' Init all object use form
        Sub Initialize()
            objBDic.InterfaceLanguage = Session("InterfaceLanguage")
            objBDic.ConnectionString = Session("ConnectionString")
            objBDic.DBServer = Session("DBServer")
            Call objBDic.Initialize()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBDic Is Nothing Then
                        objBDic.Dispose(True)
                        objBDic = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace