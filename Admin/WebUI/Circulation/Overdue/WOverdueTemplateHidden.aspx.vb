' Class: WOverdueTemplate
' Puspose: all process in Template Table
' Creator: Sondp
' CreatedDate: 20/12/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOverdueTemplateHidden
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
        Private objBCTemplate As New clsBCommonTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call LoadBackData()
        End Sub

        ' Method: LoadBackData
        ' Purpose: load data to called form
        Private Sub LoadBackData()
            Dim strJS As String = ""

            If Not Request("TemplateID") = "" Then
                If Request("TemplateID") = 0 Then
                    strJS = "RefeshPage();"
                Else
                    Dim strName As String = ""
                    Dim strHeader As String = ""
                    Dim strCollums As String = ""
                    Dim strCollumCaption As String = ""
                    Dim strWidth As String = ""
                    Dim strAlign As String = ""
                    Dim strWord As String = ""
                    Dim strFooter As String = ""
                    Dim arrTemplate() As String
                    Dim tblTemplate As DataTable

                    tblTemplate = Nothing
                    objBCTemplate.TemplateID = CInt(Request("TemplateID"))
                    objBCTemplate.TemplateType = 2
                    tblTemplate = objBCTemplate.GetTemplate
                    Try
                        If Not tblTemplate Is Nothing Then
                            If tblTemplate.Rows.Count > 0 Then
                                strName = tblTemplate.Rows(0).Item("Title")
                                arrTemplate = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                                Response.Write(UBound(arrTemplate))
                                strHeader = arrTemplate(0).Replace("<~>", "\n")
                                strCollums = arrTemplate(1)
                                strCollumCaption = arrTemplate(2).Replace("<~>", "\n")
                                strWidth = arrTemplate(3).Replace("<~>", "\n")
                                strAlign = arrTemplate(4).Replace("<~>", "\n")
                                strWord = arrTemplate(5).Replace("<~>", "\n")
                                strFooter = arrTemplate(6).Replace("<~>", "\n")
                                strJS = "LoadBackData('" & strName & "','" & strHeader & "','" & strCollums & "','" & strCollumCaption & "','" & strWidth & "','" & strAlign & "','" & strWord & "','" & strFooter & "');"
                            Else
                                strJS = "RefeshPage();"
                            End If
                        Else 'don't have data-> refesh page
                            strJS = "RefeshPage();"
                        End If
                    Catch ex As Exception ' Check error
                        Call WriteErrorMssg(0, ex.Message.Trim)
                    End Try
                End If
                Page.RegisterClientScriptBlock("HiddenActionJs", "<script language='javascript'>" & strJS & "</script>")
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBCTemplate
            objBCTemplate.ConnectionString = Session("ConnectionString")
            objBCTemplate.DBServer = Session("DBServer")
            objBCTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCTemplate.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("RegisterActionTemplateJs", "<script language='javascript' src='../Js/Overdue/WOverdueTemplate.js'></script>")
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
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