' Class: WStatClassHidden
' Puspose: load faculties of the selected college
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatClassHidden
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
        Private objBFaculty As New clsBFaculty

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadBackFaculty()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBFaculty object
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.ConnectionString = Session("ConnectionString")
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBFaculty.Initialize()
        End Sub

        ' Method: LoadBackFaculty
        ' Purpose: LoadBackFaculty data method
        Private Sub LoadBackFaculty()
            Dim tblFaculty As DataTable
            Dim strJs As String = ""
            Dim intCount As Integer

            If Request.QueryString("CollegeID") & "" <> "" Then
                ' Select Faculty by collegeID
                objBFaculty.CollegeID = CInt(Request.QueryString("CollegeID"))
                objBFaculty.ID = 0
                Try
                    tblFaculty = objBFaculty.GetFaculty

                    ' Sheck error
                    Call WriteErrorMssg(objBFaculty.ErrorCode, objBFaculty.ErrorMsg)

                    If Not tblFaculty Is Nothing AndAlso tblFaculty.Rows.Count > 0 Then
                        strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).length=1;"
                        strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].text='" & ddlLabel.Items(0).Text & "';"
                        strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].value=0;"
                        For intCount = 0 To tblFaculty.Rows.Count - 1
                            strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).length++;"
                            strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].text='" & tblFaculty.Rows(intCount).Item("Faculty") & "';"
                            strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].value=" & tblFaculty.Rows(intCount).Item("ID") & ";"
                        Next

                        Page.RegisterClientScriptBlock("AddFacultyJs", "<script language = 'javascript'>" & strJs & ";</script>")
                    Else
                        strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).length=1;"
                        strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].text='';"
                        strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].value=0;"
                        Page.RegisterClientScriptBlock("AddFacultyJs", "<script language = 'javascript'>" & strJs & ";</script>")
                    End If
                Catch ex As Exception
                    strErrorMsg = ex.Message
                End Try
            Else
                strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).length=1;"
                strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].text='';"
                strJs = strJs & "eval(parent.TaskBar.document.forms[0].ddlFaculty).options[eval(parent.TaskBar.document.forms[0].ddlFaculty).options.length-1].value=0;"
                Page.RegisterClientScriptBlock("AddFacultyJs", "<script language = 'javascript'>" & strJs & ";</script>")
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBFaculty Is Nothing Then
                objBFaculty.Dispose(True)
                objBFaculty = Nothing
            End If
        End Sub
    End Class
End Namespace