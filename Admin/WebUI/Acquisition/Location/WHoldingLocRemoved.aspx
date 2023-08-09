<%@ Page Language="vb" AutoEventWireup="false" EnableViewStateMAC="False" EnableViewState="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WHoldingLocRemoved" CodeFile="WHoldingLocRemoved.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WHoldingLocRemoved</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="1" width="100%">
				<tr>
					<td class="lbPageTitle" align="center" colSpan="3"><asp:label id="lblTitle" runat="server">Kết quả ghi nhận thanh lý</asp:label></td>
				</tr>
				<tr>
					<td align="right" colSpan="3"><asp:hyperlink id="lnkOtherRemove" Runat="server" NavigateUrl="WHoldingLocRemove.aspx">Giao dịch thanh lý khác</asp:hyperlink></td>
				</tr>
				<tr>
					<td width="50%"><asp:label id="lblLibName" Runat="server">
							<b>Thư viện:</b></asp:label></td>
					<td width="15%"><asp:label id="lblLocName" Runat="server">
							<b>Kho:</b></asp:label></td>
					<td><asp:label id="lblReason" Runat="server">
							<b>Lý do:</b></asp:label></td>
				</tr>
				<tr>
					<td align="center" colSpan="3">processing...
					</td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="1" width="100%">
				<tr>
					<td class="lbPageTitle"><asp:label id="lblDetailResult" runat="server">Chi tiết kết quả</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblTotalRemove" runat="server">Số đăng ký cá biệt đưa vào thanh lý:</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblNumRemove" runat="server">Số đăng ký cá biệt được ghi nhận thanh lý:</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblNumNoRemove" runat="server">Số đăng ký cá biệt không được ghi nhận thanh lý (vì đang ghi mượn):</asp:label></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
