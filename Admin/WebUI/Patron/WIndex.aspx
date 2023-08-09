<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WIndex" CodeFile="WIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>WIndex</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</head>
	<frameset border="0" frameSpacing="0" rows="*,0" frameBorder="0">
		<frameset cols="0,0,*">
			<FRAME NAME="Refernce" SRC="../Common/WReference.aspx" MARGINHEIGHT="0" MARGINWIDTH="0"
				noresize scrolling="no">
			<frame name="Left" src="WLeft.html" marginwidth="0" marginheight="0" noresize scrolling="no">
			<!--<frame name="Workform" src="WDocumentIndex.aspx" marginwidth="0" marginheight="0" noresize>-->
			<frame name="Workform" src="WPatronIndex.aspx" marginwidth="0" marginheight="0" noresize>
		</frameset>
		<frame name="hiddenbase" src="WHiddenBase.aspx" noResize marginwidth="0" marginheight="0">
	</frameset>
</html>
