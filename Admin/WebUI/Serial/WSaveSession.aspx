<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSaveSession" CodeFile="WSaveSession.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSaveSession</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
		    <INPUT id="hidItemID" type="hidden" name="hidItemID" runat="server"/> <INPUT id="hidTitle" type="hidden" name="hidTitle" runat="server"/>
			<asp:Button id="btnSave" runat="server" Width="88px" style="display: none"></asp:Button>
			<asp:Label id="lblChangePage" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
