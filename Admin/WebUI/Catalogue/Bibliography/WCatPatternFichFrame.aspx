<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatPatternFichFrame" validateRequest="false" CodeFile="WCatPatternFichFrame.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WCatPatternFichFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset id="PatternFich" rows="*,0" border="0" frameborder="0" framespacing="0">
		<frame id="Display" name="Display" src="WCatPatternFichDisplay.aspx" noresize scrolling="auto">
		<frame id="Hidden" name="Hidden" src="WCatPatternFichHidden.aspx" noresize scrolling="no">
	</frameset>
</HTML>
