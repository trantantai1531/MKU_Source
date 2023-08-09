' class 
' Puspose: Manager Template
' Creator: Sondp
' CreatedDate: 10/03/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WOPTemplateH
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
            If Not Request.QueryString("TemplateID") & "" = "" Then
                Dim strScript As String
                If Request.QueryString("TemplateID") <= 0 Then
                    strScript = "ClearData();"
                Else
                    Dim tblTemplate As New DataTable
                    Dim strTitle, strHeader, strPageHeader, strCollum, strCollumCaption, strCollumWidth, strAlign, strFormat, strTableColor, strEventColor, strOddColor, strPageFooter, strFooter, arrTemp() As String
                    objBCT.TemplateID = Request.QueryString("TemplateID")
                    objBCT.TemplateType = Request.QueryString("TemplateType")
                    tblTemplate = objBCT.GetTemplate
                    If Not tblTemplate Is Nothing Then
                        If tblTemplate.Rows.Count > 0 Then
                            strTitle = tblTemplate.Rows(0).Item("Title")
                            arrTemp = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                            ' Get data 
                            strHeader = arrTemp(0).Replace("<~>", "\n").Replace("'", "")
                            strPageHeader = arrTemp(1).Replace("<~>", "\n").Replace("'", "")
                            strCollum = Trim(arrTemp(2))
                            strCollumCaption = arrTemp(3).Replace("<~>", "\n").Replace("'", "")
                            strCollumWidth = arrTemp(4).Replace("<~>", "\n").Replace("'", "")
                            strAlign = arrTemp(5).Replace("<~>", "\n").Replace("'", "")
                            strFormat = arrTemp(6).Replace("<~>", "\n").Replace("'", "")
                            strTableColor = arrTemp(7)
                            strEventColor = arrTemp(8)
                            strOddColor = arrTemp(9)
                            strPageFooter = arrTemp(10).Replace("<~>", "\n").Replace("'", "")
                            strFooter = arrTemp(11).Replace("<~>", "\n").Replace("'", "")
                            strScript = "LoadBackData('" & strHeader & "','" & strPageHeader & "','" & strCollum & "','" & strCollumCaption & "','" & strCollumWidth & "','" & strAlign & "','" & strFormat & "','" & strTableColor & "','" & strEventColor & "','" & strOddColor & "','" & strPageFooter & "','" & strFooter & "','" & strTitle & "','" & Request.QueryString("TemplateType") & "');"
                        End If
                    End If
                End If
                Page.RegisterClientScriptBlock("LoadBackDataJs", "<script language='javascript'>" & strScript & "</script>")
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

        ' BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WPOTemplateHJs", "<script language='javascript' src='../Js/PO/WOPTemplate.js'></script>")
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