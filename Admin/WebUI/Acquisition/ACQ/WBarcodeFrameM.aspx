<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBarcodeFrameM" CodeFile="WBarcodeFrameM.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>In mã vạch</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<frameset id="BarCode" rows="15%,*,0" runat="server" frameborder="0" framespacing="0">
		<frame id="TaskBar" name="TaskBar" src="WBarcodeTaskBar.aspx" scrolling="no">
		<frame id="Content" name="Content" src="" scrolling="yes">
		<frame id="Display" name="Display" src="WBarcodeLazerPrint.aspx" scrolling="no">
	</frameset>
</HTML>
