<%@ Page Language="vb" AutoEventWireup="false" Inherits="WViewInventoryFrame" CodeFile="WViewInventoryFrame.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML >
	<HEAD>
		<TITLE>WViewInventoryFarme</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset rows="50,*" FRAMEBORDER="0" FRAMESPACING="0" BORDER="0">
		<frame name="banner" scrolling="no" src="WCloseInventory.aspx">
		<frameset cols="25%,*">
			<frame name="contents" src="WTreeViewInventory.aspx" scrolling="auto">
			<frame name="main" src="WViewLiq.aspx" scrolling="auto">
		</frameset>
	</frameset>
</HTML>
