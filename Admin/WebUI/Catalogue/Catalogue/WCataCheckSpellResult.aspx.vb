' WCataCheckSpellResult class
' Purpose: Show cheking result
' Creator: Oanhtn
' CreatedDate: 09/06/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Imports System
Imports System.Web
Imports System.Web.UI.WebControls

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataCheckSpellResult
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

        ' Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindData()
            Call BindJavascript()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript function
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../Js/Catalogue/WCataCheckSpell.js'></script>")
            Page.RegisterClientScriptBlock("WCataCheckSpellResultJs", "<script language = 'javascript' src = '../Js/Catalogue/WCataCheckSpellResult.js'></script>")
            btnReplace.Attributes.Add("OnClick", "javascript:u8(); return false;")
            btnReplaceAll.Attributes.Add("OnClick", "javascript:tru(); return false;")
            btnIgnore.Attributes.Add("OnClick", "javascript:cx(); return false;")
            btnIgnoreAll.Attributes.Add("OnClick", "javascript:vb(); return false;")
            btnClose.Attributes.Add("OnClick", "javascript:f(); return false;")
            pp.Attributes.Add("OnChange", "javascript:uu();")
            pp.Attributes.Add("ondblclick", "javascript:autoUpdate();")
        End Sub

        ' BindData method
        ' Purpose: write document
        Private Sub BindData()
            Dim objSpell
            Dim Word
            Dim Words()
            Dim Parts()
            Dim Suggestions()
            Dim Suggestion
            Dim strJavascripts As String = ""
            Dim strTemp As String = ""
            Dim strValue As String = ToUTF8(Request("fieldvalue_0"))

            objSpell = Server.CreateObject("spcom.spellcheck")
            objSpell.Languages = "vn,en,ru,ge,fr"
            Words = objSpell.check(strValue & "")
            objSpell = Nothing
            strTemp = Replace(Replace(Replace(Request("fieldvalue_0"), """", "\"""), Chr(13), "\n"), Chr(10), "\r")

            strJavascripts = strJavascripts & "var directEdit=""YES"";" & Chr(13)
            strJavascripts = strJavascripts & "var confirmAfterLearn=false;" & Chr(13)
            strJavascripts = strJavascripts & "var confirmAfterReplace=true;" & Chr(13)
            strJavascripts = strJavascripts & "var p2=0;" & Chr(13)
            strJavascripts = strJavascripts & "var ec=0;" & Chr(13)
            strJavascripts = strJavascripts & "var po=new Array();" & Chr(13)
            strJavascripts = strJavascripts & "var er=new Object();" & Chr(13)
            strJavascripts = strJavascripts & "var learned=""null"";" & Chr(13)

            strJavascripts = strJavascripts & "function E(fd,ho,s4) {" & Chr(13)
            strJavascripts = strJavascripts & "this.fd=fd;" & Chr(13)
            strJavascripts = strJavascripts & "this.s4=s4;" & Chr(13)
            strJavascripts = strJavascripts & "this.ho=ho;" & Chr(13)
            strJavascripts = strJavascripts & "this.a=a;" & Chr(13)
            strJavascripts = strJavascripts & "this.b=new Object();" & Chr(13)
            strJavascripts = strJavascripts & "this.c=0;" & Chr(13)
            strJavascripts = strJavascripts & "this.replaced=false;" & Chr(13)
            strJavascripts = strJavascripts & "}" & Chr(13)

            strJavascripts = strJavascripts & "function a(s) {" & Chr(13)
            strJavascripts = strJavascripts & "this.b[this.c]=s;" & Chr(13)
            strJavascripts = strJavascripts & "this.c++;" & Chr(13)
            strJavascripts = strJavascripts & "}" & Chr(13)

            strJavascripts = strJavascripts & "var y9=new Array();" & Chr(13)
            strJavascripts = strJavascripts & "y9[y9.length]= """ & strTemp & """;" & Chr(13)
            strJavascripts = strJavascripts & "var v=new Array();" & Chr(13)

            For Each Word In Words
                Word = ToUTF8Back(Word)
                Parts = Split(Word, " $ ")
                strJavascripts = strJavascripts & "er[ec]=new E(0,""" & Parts(1) & """,""" & Parts(0) & """);" & Chr(13)
                If UBound(Parts) >= 2 Then
                    Suggestions = Split(Parts(2), ",")
                    For Each Suggestion In Suggestions
                        strJavascripts = strJavascripts & "er[ec].a(new Option(""" & Suggestion & """));" & Chr(13)
                        strJavascripts = strJavascripts & "v[v.length]=""" & Suggestion & """;" & Chr(13)
                    Next
                End If
                strJavascripts = strJavascripts & "ec++;" & Chr(13)
            Next
            Page.RegisterClientScriptBlock("LoadJS", "<script language = 'javascript'>" & strJavascripts & " </script>")
            strJavascripts = ""
            strJavascripts = "<script type=""text/javascript"">" & Chr(13)
            strJavascripts = strJavascripts & "document.open();"
            strJavascripts = strJavascripts & "document.write("" "");"
            strJavascripts = strJavascripts & "document.close();"
            strJavascripts = strJavascripts & "runChecker();" & Chr(13)
            strJavascripts = strJavascripts & "</script>" & Chr(13)
            lblJS.Text = strJavascripts
        End Sub
    End Class
End Namespace