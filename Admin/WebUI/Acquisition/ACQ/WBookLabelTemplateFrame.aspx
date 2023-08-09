<%@ Page Language="vb" AutoEventWireup="false" Inherits="WBookLabelTemplateFrame" CodeFile="WBookLabelTemplateFrame.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WBookLabelTemplateFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset id="BookLabelTemplate" rows="*,0" border="0" runat="server" frameSpacing="0" frameBorder="0">
		<frame id="Display" runat="server" src="WBookLabelTemplateDisplay.aspx" scrolling="yes"></frame>
		<frame id="Hidden" runat="server" src="WBookLabelTemplateHidden.aspx" scrolling="no"></frame>
	</frameset>
</HTML>
