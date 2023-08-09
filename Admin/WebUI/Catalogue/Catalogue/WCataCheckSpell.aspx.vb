' WCataCheckSpell class
' Purpose: spellcheck
' Creator: Khoana
' CreatedDate: 03/06/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Imports System
Imports System.Web
Imports System.Web.UI.WebControls

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataCheckSpell
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
            Call BindJavascript()
            Call BindData()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript function
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../Js/Catalogue/WCataCheckSpell.js'></script>")
            Page.RegisterClientScriptBlock("WCataCheckSpellJs", "<script language = 'javascript' src = '../Js/Catalogue/WCataCheckSpell.js'></script>")
            btnSpell.Attributes.Add("onclick", "javascript:spellcheck();return false;")
            btnUpdate.Attributes.Add("onclick", "javascript:update();")
        End Sub

        ' BindData method
        ' Purpose: get data from QueryString and load into txtMyField textbox
        Private Sub BindData()
            Dim strData As String = ""
            Dim intIndex As Integer = 0
            Dim strTag As String = ""
            Dim strThisTag As String = ""
            Dim Tags(0)
            'Dim objTVcom As New TVCOMLib.utf8

            Tags(0) = "00"
            For Each strTag In Request.Form
                If Left(strTag, 3) = "tag" And Not strTag = "tags" Then
                    If Not Trim(Request(strTag)) = "" And strTag >= "tag100" Then
                        ReDim Preserve Tags(intIndex)
                        strThisTag = Replace(Request(strTag), """", "\""")
                        If Right(strThisTag, 2) = "$&" Then
                            strThisTag = Left(strThisTag, Len(strThisTag) - 2) & Chr(13)
                        End If
                        Tags(intIndex) = Right(strTag, 3) & Chr(9) & strThisTag
                        strData = strData & CStr(Tags(intIndex)) & Chr(13)
                        intIndex = intIndex + 1
                    End If
                End If
            Next
            If Not UBound(Tags) < 1 Then
                'Call objTVcom.Sort(Tags, 0)
                txtMyField.Text = strData
            End If
        End Sub
    End Class
End Namespace