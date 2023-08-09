<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WHiddenItem.aspx.vb" Inherits="WHiddenItem"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WHiddenItem</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<input id="hiddenIDs" type="hidden" size="2" name="hiddenIDs" runat="server">
		</form>
		<script language="javascript">
		document.forms[0].hiddenIDs.value=parent.HiddenSaveIDs.document.forms[0].txtSaveID.value;
		document.forms[0].action='WSavedList.aspx';
		document.forms[0].submit();
		</script>
	</body>
</HTML>
