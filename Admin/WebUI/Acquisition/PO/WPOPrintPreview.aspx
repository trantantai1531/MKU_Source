<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPOPrintPreview" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WPOPrintPreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPOPrintPreview</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%"><asp:Label ID="lblDisplay" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr>
					<td width="100%" align="center"><asp:Button ID="btnClose" Runat="server" Text="Đóng(g)"></asp:Button>&nbsp;
						<asp:Button id="btnPrint" runat="server" Width="61px" Text="In(I)"></asp:Button></td>
				</tr>
			</table>
			<asp:TextBox id="hidvalue" runat="server" Width="0px"></asp:TextBox>
		</form>
	</body>
</HTML>
