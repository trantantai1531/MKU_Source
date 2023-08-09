' class 
' Puspose: Load AcqTemplate
' Creator: Sondp
' CreatedDate: 20/02/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WAcqReportTemplateHidden
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

        Private objBCT As New clsBCommonTemplate
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                If Not Request.QueryString("TemplateID") & "" = "" Then
                    If IsNumeric(Request.QueryString("TemplateID")) Then
                        If CInt(Request.QueryString("TemplateID")) > 0 Then
                            Dim arrCollum() As String
                            Dim strTitle, strHeader, strPageHeader, strCollum, strCollumCaption, strCollumWidth, strAlign, strFormat, strTableColor, strEventColor, strOddColor, strPageFooter, strFooter, strScriptJs As String
                            Dim tblTemplate As New DataTable
                            objBCT.TemplateID = CInt(Request.QueryString("TemplateID"))
                            objBCT.TemplateType = 11
                            Try
                                tblTemplate = objBCT.GetTemplate
                                ' Catch errors
                                Call WriteErrorMssg(ddlLog.Items(0).Text, objBCT.ErrorMsg, ddlLog.Items(1).Text, objBCT.ErrorCode)
                                If Not tblTemplate Is Nothing Then
                                    If tblTemplate.Rows.Count > 0 Then
                                        strTitle = tblTemplate.Rows(0).Item("Title")
                                        arrCollum = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                                        If UBound(arrCollum) > 0 Then
                                            strHeader = arrCollum(0).Replace("<~>", "\n").Replace("'", "")
                                            strPageHeader = arrCollum(1).Replace("<~>", "\n").Replace("'", "")
                                            strCollum = arrCollum(2)
                                            strCollumCaption = arrCollum(3).Replace("<~>", "\n").Replace("'", "")
                                            strCollumWidth = arrCollum(4).Replace("<~>", "\n").Replace("'", "")
                                            strAlign = arrCollum(5).Replace("<~>", "\n").Replace("'", "")
                                            strFormat = arrCollum(6).Replace("<~>", "\n").Replace("'", "")
                                            strTableColor = arrCollum(7)
                                            strEventColor = arrCollum(8)
                                            strOddColor = arrCollum(9)
                                            strPageFooter = arrCollum(10).Replace("<~>", "\n").Replace("'", "")
                                            strFooter = arrCollum(11).Replace("<~>", "\n").Replace("'", "")
                                        End If
                                        strScriptJs = "LoadBackData('" & strHeader & "','" & strPageHeader & "','" & strCollum & "','" & strCollumCaption & "','" & strCollumWidth & "','" & strAlign & "','" & strFormat & "','" & strTableColor & "','" & strEventColor & "','" & strOddColor & "','" & strPageFooter & "','" & strFooter & "','" & strTitle & "');"
                                        Page.RegisterClientScriptBlock("LoadBackDataJs", "<script language='javascript'>" & strScriptJs & "</script>")
                                    End If
                                End If
                            Catch ex As Exception
                                Response.Write(ex.Message)
                            End Try
                        End If
                    End If
                End If
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WAcqReportTemplateHJs", "<script language='javascript' src='../Js/ACQ/WAcqReportTemplate.js'></script>")
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
        End Sub
    End Class
End Namespace