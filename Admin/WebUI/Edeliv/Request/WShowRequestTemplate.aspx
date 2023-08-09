<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WShowRequestTemplate" CodeFile="WShowRequestTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WShowRequestTemplate</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" cellpadding="2" cellspacing="0" border="0">
				<tr class="lbPagetitle">
					<td align="center" colspan="2">
						<asp:Label ID="lblTitleTemplate" Runat="server">Gửi hoá đơn thanh toán</asp:Label>
					</td>
				</tr>
				<tr>
					<TD vAlign="top" colspan="2"><asp:label id="lbFormat" Runat="server"><U>K</U>huôn dạng: </asp:label>
						<asp:dropdownlist id="ddlFormatName" Width="300px" Runat="server"></asp:dropdownlist></TD>
				</tr>
				<tr class="lbControlBar">
					<td width="30%"></td>
					<td><asp:button id="btnPrintLetter" Runat="server" Text="In thư(p)" Width="78px"></asp:button>&nbsp;<asp:button id="btnSendEmail" Runat="server" Text="Gửi thư(s)" Width="90px"></asp:button>
					</td>
				</tr>
				<tr>
					<td width="100%" colspan="2"><asp:Label ID="lblOutMsg" Runat="server" Width="100%"></asp:Label></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">---------- Chọn ----------</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
