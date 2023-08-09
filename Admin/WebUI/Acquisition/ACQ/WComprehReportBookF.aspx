<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WComprehReportBookF" CodeFile="WComprehReportBookF.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WComprehReportBookF</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset id="ComprehReportBook" rows="6%,*,0" runat="server" frameborder="0" framespacing="0">
		<frame id="TaskBar" src="WComprehReportBookT.aspx" runat="server" scrolling="no" />
		<frame id="Display" src="WComprehReportBookD.aspx" runat="server" scrolling="auto" />
		<frame id="hiddenbase" name="hiddenbase" marginWidth="0" marginHeight="0" src="">
	</frameset>
</HTML>
