<%@ Page Language="vb" AutoEventWireup="false" Inherits="WReceiveFrame" CodeFile="WReceiveFrame.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WReceiveFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<FRAMESET cols="240,*" FRAMEBORDER="0" FRAMESPACING="0" BORDER="0">
		<FRAMESET rows="46,*" FRAMEBORDER="0" FRAMESPACING="0" BORDER="0">
			<FRAME NAME="folder" SRC="WProcMode.aspx?Mode=0" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no">
			<FRAME NAME="taskbar" SRC="WLocTreeView.aspx?Mode=0" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="auto">
		</FRAMESET>
		<frameset rows="*,40" border="0" frameborder="0" framespacing="0">
			<FRAME NAME="display" SRC="../../WNothing.aspx" MARGINHEIGHT="0" MARGINWIDTH="10">
			<FRAME NAME="mainfunc" SRC="WTaskBarFunc.aspx?Mode=0" MARGINHEIGHT="0" MARGINWIDTH="10">
		</frameset>
	</FRAMESET>
</HTML>
