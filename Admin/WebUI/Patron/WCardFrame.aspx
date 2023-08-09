<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCardFrame" CodeFile="WCardFrame.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WCardFrame</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset framespacing="0" border="0" rows="*,28" frameborder="0">
		<frame name="result" src="WCardDisplay.aspx">
		<frame name="taskbar" scrolling="no" noresize="noresize" src="WCardTaskBar.aspx">
		<noframes>
			<body>
				<p>This page uses frames, but your browser doesn't support them.</p>
			</body>
		</noframes>
	</frameset>
</HTML>
