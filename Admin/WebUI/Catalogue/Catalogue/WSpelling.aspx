<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WSpelling" CodeFile="WSpelling.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSpelling</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META HTTP-EQUIV="Content-type" CONTENT="text/html; charset=ISO-8859-1">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body onLoad="document.forms[0].submit()">
		<P align="center">
			Performing Spell Check...
		<SCRIPT language="JavaScript">

		function getCookie(name) {
		var dc = document.cookie;
		var prefix = name + "=";
		var begin = dc.indexOf("; " + prefix);
		if (begin == -1) {
		begin = dc.indexOf(prefix);
		if (begin != 0) return null;
		} else
		begin += 2;
		var end = document.cookie.indexOf(";", begin);
		if (end == -1)
		end = dc.length;
		return unescape(dc.substring(begin + prefix.length, end));
		}
		
		document.open();
		document.write('<FORM ACTION="'+opener.spellCheckURL+'" METHOD="POST" NAME="jspell">');
		document.write('<INPUT TYPE=hidden NAME="imagePath" VALUE="'+opener.imagePath+'">');
		document.write('<INPUT TYPE=hidden NAME="fieldCount" VALUE="1">');
		document.write('<INPUT TYPE=hidden NAME="learned" VALUE="'+getCookie("learned")+'">');
		document.write('<INPUT TYPE=hidden NAME="proxyURL" VALUE="'+opener.spellCheckURL+'">');
		document.write('<INPUT TYPE=hidden NAME="styleSheetURL" VALUE="'+opener.styleSheetURL+'">');

		document.write('<INPUT TYPE=hidden NAME="field_0" VALUE="fieldvalue_0">');
		document.write('<INPUT TYPE=hidden NAME="fieldvalue_0" VALUE="">');

		if (opener.hidePreviewPanel)
			document.write('<INPUT type=hidden NAME="hidePreviewPanel" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="hidePreviewPanel" VALUE="False">');

		if (opener.confirmAfterLearn)
			document.write('<INPUT type=hidden NAME="confirmAfterLearn" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="confirmAfterLearn" VALUE="False">');

		if(opener.confirmAfterReplace)
			document.write('<INPUT type=hidden NAME="confirmAfterReplace" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="confirmAfterReplace" VALUE="False">');

		if (opener.directmode)
			document.write('<INPUT type=hidden NAME="directEdit" VALUE="YES">');
		else 
			document.write('<INPUT type=hidden NAME="directEdit" VALUE="NO">');

		if (opener.disableLearn) // defaults to enabled, must explicitly disable learning words.
			document.write('<INPUT type=hidden NAME="enableLearn" VALUE="NO">');
		else 
			document.write('<INPUT type=hidden NAME="enableLearn" VALUE="YES">');

		if (opener.forceUpperCase) // defaults to false
			document.write('<INPUT type=hidden NAME="forceUpperCase" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="forceUpperCase" VALUE="False">');

		if (opener.ignoreIrregularCaps)
			document.write('<INPUT type=hidden NAME="ignoreIrregularCaps" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="ignoreIrregularCaps" VALUE="False">');

		if(opener.ignoreFirstCaps)
			document.write('<INPUT type=hidden NAME="ignoreFirstCaps" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="ignoreFirstCaps" VALUE="False">');

		if(opener.ignoreUpper)
			document.write('<INPUT type=hidden NAME="ignoreUpper" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="ignoreUpper" VALUE="False">');

		if(opener.ignoreNumbers)
			document.write('<INPUT type=hidden NAME="ignoreNumbers" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="ignoreNumbers" VALUE="False">');

		if(opener.ignoreDouble)
			document.write('<INPUT type=hidden NAME="ignoreDouble" VALUE="True">');
		else
			document.write('<INPUT type=hidden NAME="ignoreDouble" VALUE="False">');

		document.write('<INPUT type=hidden NAME="supplementalDictionary" VALUE="'+opener.supplementalDictionary+'">');

		document.close();
		</SCRIPT>
		</FORM>

		<SCRIPT>
		document.open();
		document.write('<SCR' + 'IPT>');
		document.write('document.forms["jspell"].fieldvalue_0.value=opener.top.document.forms[0].txtMyField.value');
		document.write('</SCR' + 'IPT>');
		document.close();
		</SCRIPT>					
		<asp:Label Runat="server" ID="lblJs"></asp:Label>
		</P>
	</body>
</HTML>
