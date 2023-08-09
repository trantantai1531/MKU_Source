<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WHelpOverView" CodeFile="WHelpOverView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWHelpBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WHelpOverView</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<frameset cols="24%,*" border="1" frameborder="1" framespacing="1" id="Allframe">
		<frameset rows="5%,*" border="0" frameborder="0" framespacing="0">
			<frame name="topleft" id="topleft" src="wHelpHeader.aspx" scrolling="no">
			<frame name="left" id="left" src="WHelpTreeViewInput.aspx?Type=3">
		</frameset>
		<frame name="right" id="right" src="WHelpOverViewDetail.aspx?New=1">
	</frameset>
</HTML>
