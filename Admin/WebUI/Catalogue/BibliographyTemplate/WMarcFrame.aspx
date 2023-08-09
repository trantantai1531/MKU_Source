<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFrame" CodeFile="WMarcFrame.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WMarcFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<FRAMESET COLS="46%,*" FRAMEBORDER="0" FRAMESPACING="0" BORDER="0">
		<FRAMESET ROWS="57,*" FRAMEBORDER="0" FRAMESPACING="0" BORDER="0">
			<FRAME SRC="WMarcFieldBlocks.aspx" NAME="MarcBlocks" MARGINWIDTH="10" MARGINHEIGHT="5"
				SCROLLING="no">
			<FRAME SRC="WMarcFields.aspx" NAME="MarcFields" MARGINWIDTH="10" MARGINHEIGHT="5">
		</FRAMESET>
		<FRAME SRC="WNothing.htm" NAME="MarcSubFields" MARGINWIDTH="10" MARGINHEIGHT="5">
	</FRAMESET>
</HTML>
