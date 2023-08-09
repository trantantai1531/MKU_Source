' WSpelling class
' Purpose: Check spell
' Creator: Khoana
' CreatedDate: 03/06/2004
' Modification history:
'   - 11/03/2005 by Oanhtn: review

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WSpelling
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
            Call BindJavascript()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript function
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../Js/Catalogue/WCataCheckSpell.js'></script>")
            Page.RegisterClientScriptBlock("WSpellingJs", "<script language = 'javascript' src = '../Js/Catalogue/WSpelling.js'></script>")
        End Sub

        ' BindData method
        ' Purpose: write document
        Private Sub BindData()
            Dim strJs As String = ""

            strJs = strJs & "<SCRIPT language=""JavaScript"">" & Chr(13)
            strJs = strJs & "function getCookie(name) {" & Chr(13)
            strJs = strJs & "var dc = document.cookie;" & Chr(13)
            strJs = strJs & "var prefix = name + "" = "";" & Chr(13)
            strJs = strJs & "var begin = dc.indexOf(""; "" + prefix);" & Chr(13)
            strJs = strJs & "if (begin == -1) {" & Chr(13)
            strJs = strJs & "begin = dc.indexOf(prefix);" & Chr(13)
            strJs = strJs & "if (begin != 0) return null;" & Chr(13)
            strJs = strJs & "} else" & Chr(13)
            strJs = strJs & "begin += 2;" & Chr(13)
            strJs = strJs & "var end = document.cookie.indexOf("";"", begin);" & Chr(13)
            strJs = strJs & "if (end == -1)" & Chr(13)
            strJs = strJs & "end = dc.length;" & Chr(13)
            strJs = strJs & "return unescape(dc.substring(begin + prefix.length, end));" & Chr(13)
            strJs = strJs & "}" & Chr(13)

            strJs = strJs & "document.open();" & Chr(13)
            strJs = strJs & "document.write('<FORM ACTION="" '+opener.spellCheckURL+'"" METHOD=""POST"" NAME=""jspell"">');" & Chr(13)
            strJs = strJs & "document.write('<INPUT TYPE=hidden NAME=""imagePath"" VALUE=""'+opener.imagePath+'"">');" & Chr(13)
            strJs = strJs & "document.write('<INPUT TYPE=hidden NAME=""fieldCount"" VALUE=""1"">');" & Chr(13)
            strJs = strJs & "document.write('<INPUT TYPE=hidden NAME=""learned"" VALUE=""'+getCookie(""learned"")+'"">');" & Chr(13)
            strJs = strJs & "document.write('<INPUT TYPE=hidden NAME=""proxyURL"" VALUE=""'+opener.spellCheckURL+'"">');" & Chr(13)
            strJs = strJs & "document.write('<INPUT TYPE=hidden NAME=""styleSheetURL"" VALUE=""'+opener.styleSheetURL+'"">');" & Chr(13)

            strJs = strJs & "document.write('<INPUT TYPE=hidden NAME=""field_0"" VALUE=""fieldvalue_0"">');" & Chr(13)
            strJs = strJs & "document.write('<INPUT TYPE=hidden NAME=""fieldvalue_0"" VALUE="""">');" & Chr(13)

            strJs = strJs & "if (opener.hidePreviewPanel) document.write('<INPUT type=hidden NAME=""hidePreviewPanel"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""hidePreviewPanel"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.confirmAfterLearn) document.write('<INPUT type=hidden NAME=""confirmAfterLearn"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""confirmAfterLearn"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.confirmAfterReplace) document.write('<INPUT type=hidden NAME=""confirmAfterReplace"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""confirmAfterReplace"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.directmode) document.write('<INPUT type=hidden NAME=""directEdit"" VALUE=""YES"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""directEdit"" VALUE=""NO"">');" & Chr(13)

            strJs = strJs & "if (opener.disableLearn) document.write('<INPUT type=hidden NAME=""enableLearn"" VALUE=""NO"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""enableLearn"" VALUE=""YES"">');" & Chr(13)

            strJs = strJs & "if (opener.forceUpperCase) document.write('<INPUT type=hidden NAME=""forceUpperCase"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""forceUpperCase"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.ignoreIrregularCaps) document.write('<INPUT type=hidden NAME=""ignoreIrregularCaps"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""ignoreIrregularCaps"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.ignoreFirstCaps) document.write('<INPUT type=hidden NAME=""ignoreFirstCaps"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""ignoreFirstCaps"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.ignoreUpper) document.write('<INPUT type=hidden NAME=""ignoreUpper"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""ignoreUpper"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.ignoreNumbers) document.write('<INPUT type=hidden NAME=""ignoreNumbers"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""ignoreNumbers"" VALUE=""False"">');" & Chr(13)

            strJs = strJs & "if (opener.ignoreDouble) document.write('<INPUT type=hidden NAME=""ignoreDouble"" VALUE=""True"">');" & Chr(13)
            strJs = strJs & "else document.write('<INPUT type=hidden NAME=""ignoreDouble"" VALUE=""False"">');"

            strJs = strJs & "document.write('<INPUT type=hidden NAME=""supplementalDictionary"" VALUE=""'+opener.supplementalDictionary+'"">');" & Chr(13)

            strJs = strJs & "document.close();"
            strJs = strJs & "</SCRIPT>"
            strJs = strJs & "</FORM>"

            strJs = strJs & "<SCRIPT>"
            strJs = strJs & "document.open();"
            strJs = strJs & "document.write('<SCR' + 'IPT>');"
            strJs = strJs & "document.write('document.forms[""jspell""].fieldvalue_0.value=opener.top.document.forms[0].txtMyField.value');" & Chr(13)
            strJs = strJs & "document.write('</SCR' + 'IPT>');"
            strJs = strJs & "document.close();"
            strJs = strJs & "</SCRIPT>"
            lblJs.Text = "<script language = 'JavaScript1.1'>" & strJs & "</script>"
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace