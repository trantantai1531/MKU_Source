﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatTimesFrame.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatTimesFrame" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatDayFrame</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset id="StatDay" runat="server" rows="180,*" border="0">
		<frame id="TaskBar" name="TaskBar" runat="server" src="WStatTimesTaskbar.aspx" scrolling="no" />
		<frame id="Display" name="Display" runat="server" src="" scrolling="yes" />
	</frameset>
</HTML>
