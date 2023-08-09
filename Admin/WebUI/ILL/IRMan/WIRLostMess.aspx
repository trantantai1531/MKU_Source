<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRLostMess" CodeFile="WIRLostMess.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gửi thông báo mất</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblEnableView" cellSpacing="3" cellPadding="2" width="100%">
				<tr class="lbPageTitle">
					<td><asp:label id="lblHeader" cssClass="lbPageTitle" Runat="server" Width="100%">Gửi thông báo mất</asp:label></td>
				</tr>
				<tr class="lbSubFormTitle">
					<td><asp:label id="lblNote" Runat="server" cssclass="lbSubFormTitle" Width="100%">Ghi <u>c</u>hú:</asp:label></td>
				<tr>
					<td>
						<asp:textbox id="txtNote" Runat="server" Rows="7" TextMode="MultiLine" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="btnSend" Runat="server" Width="70px" Text="Gửi (g)"></asp:button>&nbsp;
						<asp:button id="btnNoSend" Runat="server" Width="70px" Text="Đóng(d)"></asp:button></td>
				</tr>
			</table>
			<input id="hidILLID" type="hidden" runat="server"> <input id="RequesterID" type="hidden" runat="server">
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False" Height="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
				<asp:ListItem Value="3">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
				<asp:ListItem Value="4">Thông điệp được gửi thành công</asp:ListItem>
				<asp:ListItem Value="5">Thông điệp chưa được gửi đi!</asp:ListItem>
				<asp:ListItem Value="6">Lỗi trong quá trình xử lý dữ liệu.</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
