<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WPreviewLetter" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WPreviewLetter.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPreviewLetter</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <style>
            .conten-letter {
                text-align: left
            }
        </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td width="100%" align="center"><asp:Label ID="lblOutMsg" Runat="server" Width="100%"></asp:Label></td>
				</tr>
			</table>
			<asp:Label ID="lblClose" Runat="server" Visible="False">Ðóng</asp:Label>
		</form>
	</body>
</HTML>
