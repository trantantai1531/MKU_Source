<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatMonthFrame" CodeFile="WStatMonthFrame.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WStatMonthFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset id="StatMonth" runat="server" rows="120,*" border="0" frameSpacing="0" frameBorder="0">
		<frame id="TaskBar" name="TaskBar" runat="server" src="WStatMonthTaskbar.aspx" scrolling="no" />
		<frame id="Display" name="Display" runat="server" src="" scrolling="yes" />
	</frameset>
</HTML>
