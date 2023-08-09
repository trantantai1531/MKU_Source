<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WLabelPrintFrame" CodeFile="WLabelPrintFrame.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Emiclib - Printer</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset id="fWLabelPrintFrame" border="0" frameSpacing="0" rows="50,*" frameBorder="0">
		<frame id="TaskBar" name="TaskBar" src="WLabelPrintTaskBar.aspx" scrolling="no"/>
		<frame id="Display" name="Display" src="WLabelPrintDisplay.aspx" scrolling="yes"/>
	</frameset>
</HTML>
