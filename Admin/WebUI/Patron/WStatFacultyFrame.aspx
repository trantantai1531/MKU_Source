<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatFacultyFrame" CodeFile="WStatFacultyFrame.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>WStatFacultyFrame</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</head>
	<frameset border="0" framespacing="0" <%--rows="44,*"--%> frameborder="no" id="Faculty">
		<%--<frame id="TaskBar" src="WStatFacultyTaskbar.aspx" frameborder="no" scrolling="no">--%>
		<frame id="Display" src="WStatFacultyResult.aspx" frameborder="no" scrolling="auto">
	</frameset>
</html>
