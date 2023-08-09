<%@ Reference Page="~/Acquisition/ACQ/WLabelPrintDisplay.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WLabelPrintDisplay" CodeFile="WLabelPrintDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WLabelPrintDisplay</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%"><asp:Label ID="lblDisplay" Runat="server" Width="100%"></asp:Label></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="Log">In nhãn gáy nhãn bìa</asp:ListItem>
				<asp:ListItem Value="ErrorMsg">Chi ti?t l?i </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã l?i </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
