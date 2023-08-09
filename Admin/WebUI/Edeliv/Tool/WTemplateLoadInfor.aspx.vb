'Class WTemplateLoadInfor
'Puspose: Load template
'Creator: Tuanhv
'CreatedDate: 08/11/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WTemplateLoadInfor
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

        '***************************************DECLARE VARIABLES*******************************************
        Private objBCTemplate As New clsBCommonTemplate

        '*************************************END DECLARE VARIABLES*****************************************

        'Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            'Bind javascript
            Call BindScript()
            If Not Page.IsPostBack Then
                'load data from this form to parent form
                If Request("SelectPackTemplateMan") <> "" Then
                    Call LoadBackDataPack()
                Else
                    Call LoadBackData()
                End If
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(161) Then
                Call WriteErrorMssg(lblLabel1.Text)
            End If
        End Sub

        'Initialize method
        'Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            'Init objBCTemplate
            objBCTemplate.ConnectionString = Session("ConnectionString")
            objBCTemplate.DBServer = Session("DBServer")
            objBCTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCTemplate.Initialize()
        End Sub

#Region "LoadBackData to parent form"
        'Purpose: LoadBackData to parent form
        Private Sub LoadBackData()
            If Not Request("TemplateID") Is Nothing Then
                Dim strJsScript As String = ""
                If Request("TemplateID") = 0 Then
                    strJsScript = "RefeshPage();"
                Else
                    Dim strName As String = ""
                    Dim strHeader As String = ""
                    Dim strCollums As String = ""
                    Dim strCollumCaption As String = ""
                    Dim strWidth As String = ""
                    Dim strAlign As String = ""
                    Dim strFormat As String = ""
                    Dim strFooter As String = ""
                    Dim arrTemplate() As String
                    Dim tblTemplate As DataTable
                    tblTemplate = Nothing
                    objBCTemplate.TemplateID = CInt(Request("TemplateID"))
                    objBCTemplate.TemplateType = CInt(Request("TemplateType"))
                    tblTemplate = objBCTemplate.GetTemplate
                    If Not tblTemplate Is Nothing Then
                        If tblTemplate.Rows.Count > 0 Then
                            strName = tblTemplate.Rows(0).Item("Title")
                            arrTemplate = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                            strHeader = arrTemplate(0).Replace("<~>", "\n")
                            strCollums = arrTemplate(1)
                            strCollumCaption = arrTemplate(2).Replace("<~>", "\n")
                            strWidth = arrTemplate(3).Replace("<~>", "\n")
                            strAlign = arrTemplate(4).Replace("<~>", "\n")
                            strFormat = arrTemplate(5).Replace("<~>", "\n")
                            strFooter = arrTemplate(6).Replace("<~>", "\n")
                            strJsScript = "LoadBackData('" & strName & "','" & strHeader & "','" & strCollums & "','" & strCollumCaption & "','" & strWidth & "','" & strAlign & "','" & strFormat & "','" & strFooter & "');"
                        Else
                            strJsScript = "RefeshPage();"
                        End If
                    Else 'don't have data-> refesh page
                        strJsScript = "RefeshPage();"
                    End If
                End If
                Page.RegisterClientScriptBlock("HiddenActionJs", "<script language='javascript'>" & strJsScript & "</script>")
            End If
        End Sub

        'Purpose: LoadBackData to parent form
        Private Sub LoadBackDataPack()
            If Not Request("TemplateID") Is Nothing Then
                Dim strJsScript As String = ""
                If Request("TemplateID") = 0 Then
                    strJsScript = "RefeshPagePack();"
                Else
                    Dim strName As String = ""
                    Dim strContents As String = ""
                    Dim tblTemplate As DataTable
                    tblTemplate = Nothing
                    objBCTemplate.TemplateID = CInt(Request("TemplateID"))
                    objBCTemplate.TemplateType = CInt(Request("TemplateType"))
                    tblTemplate = objBCTemplate.GetTemplate
                    If Not tblTemplate Is Nothing Then
                        If tblTemplate.Rows.Count > 0 Then
                            strName = tblTemplate.Rows(0).Item("Title")
                            If Not IsDBNull(tblTemplate.Rows(0).Item("Content")) Then
                                strContents = CStr(tblTemplate.Rows(0).Item("Content")).Replace("<~>", "\n")
                                strJsScript = "LoadBackDataPack('" & strName & "','" & strContents & "');"
                            End If
                        Else
                            strJsScript = "RefeshPagePack();"
                        End If
                    Else 'don't have data-> refesh page
                        strJsScript = "RefeshPagePack();"
                    End If
                End If
                Page.RegisterClientScriptBlock("HiddenActionJs", "<script language='javascript'>" & strJsScript & "</script>")
            End If
        End Sub
#End Region

        'BindScript method
        'Purpose: Bind Javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'src = '../js/Tool/WTemplateLoadInfor.js'></script>")
        End Sub

        'Dispose method
        'Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCTemplate Is Nothing Then
                    objBCTemplate.Dispose(True)
                    objBCTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

