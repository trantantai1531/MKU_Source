<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WMainFrameLinkEdeliv.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.Catalogue_WMainFrameLinkEdeliv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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
				noresize scrolling="no">
			<frameset id="frmMain" rows="*,0">
				<FRAME NAME="Workform" SRC="Catalogue/WMarcFormSelect.aspx?FileIds=<%=Request.QueryString("FileIds")%>" MARGINHEIGHT="0" MARGINWIDTH="0" noresize>
				<FRAME NAME="Sentform" SRC="WNothing.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"
					noresize>
			</frameset>
		</frameset>
		<FRAME NAME="Hiddenbase" SRC="WNothing.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"
			FRAMEBORDER="0">
	</FRAMESET>
</html>
