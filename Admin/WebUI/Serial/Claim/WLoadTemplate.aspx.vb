' Class: WLoadTemplate
' Puspose: Load Template infor
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   +)1/10/2004: by Sondp

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WLoadTemplate
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
        Private objBDBCommon As New clsBCommonDBSystem
        Private objBCTemplate As New clsBCommonTemplate
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            Call LoadBackData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            'Init objBDBCommon
            objBDBCommon.ConnectionString = Session("ConnectionString")
            objBDBCommon.DBServer = Session("DBServer")
            objBDBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBDBCommon.Initialize()
            'Init objBCTemplate

            objBCTemplate.ConnectionString = Session("ConnectionString")
            objBCTemplate.DBServer = Session("DBServer")
            objBCTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCTemplate.Initialize()

        End Sub

        ' Purponse: LoadBackData to form WClaimTemplateManagement.aspx
        Private Sub LoadBackData()
            If Not Request("TemplateID") Is Nothing Then
                Dim strJsScript As String = ""
                If Request("TemplateID") = 0 Then
                    strJsScript = "RefeshPage();"
                Else
                    Dim strName As String = ""
                    Dim strHeader As String = ""
                    Dim strPageHeader As String = ""
                    Dim strCollum As String = ""
                    Dim strCollumCaption As String = ""
                    Dim strCollumnWidth As String = ""
                    Dim strCollumnAlign As String = ""
                    Dim strCollumnFormat As String = ""
                    Dim strTableColor As String = ""
                    Dim strOddColor As String = ""
                    Dim strEventColor As String = ""
                    Dim strPageFooter As String = ""
                    Dim strFooter As String = ""
                    Dim arrTemplate() As String
                    Dim tblTemplate As New DataTable
                    tblTemplate = Nothing
                    objBCTemplate.TemplateID = CInt(Request("TemplateID"))
                    objBCTemplate.TemplateType = 6
                    objBCTemplate.LibID = clsSession.GlbSite
                    tblTemplate = objBCTemplate.GetTemplate
                    If Not tblTemplate Is Nothing Then
                        If tblTemplate.Rows.Count > 0 Then

                            strName = tblTemplate.Rows(0).Item("Title")
                            arrTemplate = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                            ' Get data 
                            strHeader = arrTemplate(0).Replace("<~>", "\n").Replace("'", "")
                            Dim itemArrtemplateCount = arrTemplate.Count()
                            If itemArrtemplateCount > 1 Then
                                strPageHeader = arrTemplate(1).Replace("<~>", "\n").Replace("'", "")
                            End If
                            If itemArrtemplateCount > 2 Then
                                strCollum = Trim(arrTemplate(2))
                            End If
                            If itemArrtemplateCount > 3 Then
                                strCollumCaption = arrTemplate(3).Replace("<~>", "\n").Replace("'", "")
                            End If
                            If itemArrtemplateCount > 4 Then
                                strCollumnWidth = arrTemplate(4).Replace("<~>", "\n").Replace("'", "")
                            End If
                            If itemArrtemplateCount > 5 Then
                                strCollumnAlign = arrTemplate(5).Replace("<~>", "\n").Replace("'", "")
                            End If
                            If itemArrtemplateCount > 6 Then
                                strCollumnFormat = arrTemplate(6).Replace("<~>", "\n").Replace("'", "")
                            End If
                            If itemArrtemplateCount > 7 Then
                                strTableColor = arrTemplate(7)
                            End If
                            If itemArrtemplateCount > 8 Then
                                strEventColor = arrTemplate(8)
                            End If
                            If itemArrtemplateCount > 9 Then
                                strOddColor = arrTemplate(9)
                            End If
                            If itemArrtemplateCount > 10 Then
                                strPageFooter = arrTemplate(10).Replace("<~>", "\n").Replace("'", "")
                            End If
                            If itemArrtemplateCount > 11 Then
                                strFooter = arrTemplate(11).Replace("<~>", "\n").Replace("'", "")
                            End If
                            strJsScript = "LoadBackData('" & strName & "','" & strHeader & "','" & strPageHeader & "','" & strCollum & "','" & strCollumCaption & "','" & strCollumnWidth & "','" & strCollumnAlign & "','" & strCollumnFormat & "','" & strTableColor & "','" & strOddColor & "','" & strEventColor & "','" & strPageFooter & "','" & strFooter & "');"
                        Else
                            strJsScript = "RefeshPage();"
                        End If
                    Else ' Don't have data-> refesh page
                        strJsScript = "RefeshPage();"
                    End If
                    End If
                    Page.RegisterClientScriptBlock("HiddenActionJs", "<script language='javascript'>" & strJsScript & "</script>")
                    End If
        End Sub

        ' BindScript method
        ' Purpose: Bind Javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("RegisterLoadTemplateJs", "<script language='javascript' src='../Js/Claim/WLoadTemplate.js'></script>")
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBDBCommon Is Nothing Then
                    objBDBCommon.Dispose(True)
                    objBDBCommon = Nothing
                End If
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