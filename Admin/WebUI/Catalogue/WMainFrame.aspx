<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMainFrame" CodeFile="WMainFrame.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WMainFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<FRAMESET rows="*,0" FRAMEBORDER="0" FRAMESPACING="0" BORDER="0">
		<frameset cols="0,*">
			<FRAME NAME="Refernce" SRC="../Common/WReference.aspx" MARGINHEIGHT="0" MARGINWIDTH="0"
				noresize scrolling="no" rows="*,39">
			<frameset id="frmMain" rows="*,42">
				<FRAME NAME="Workform" SRC="WOverViewCatalogue.aspx" MARGINHEIGHT="0" MARGINWIDTH="0" noresize>
				<FRAME NAME="Sentform" SRC="WNothing.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"
					noresize>
			</frameset>
		</frameset>
		<FRAME NAME="Hiddenbase" SRC="WNothing.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"
			FRAMEBORDER="0">
	</FRAMESET>
</HTML>
