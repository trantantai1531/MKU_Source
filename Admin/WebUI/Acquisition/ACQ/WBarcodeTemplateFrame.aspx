<%@ Page Language="vb" AutoEventWireup="false" Inherits="WBarcodeTemplateFrame" CodeFile="WBarcodeTemplateFrame.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WBarcodeTemplateFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset id="BarcodeTemplate" rows="*,0" border="0" runat="server" frameSpacing="0" frameBorder="0">
		<frame id="Display" runat="server" src="WBarcodeTemplateEdit.aspx" scrolling="yes">
		</frame>
		<frame id="Hidden" runat="server" src="WBarcodeTemplateHidden.aspx" scrolling="no">
		</frame>
	</frameset>
</HTML>
