<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORLost" CodeFile="WORLost.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
			<table id="tblEnableView" cellSpacing="3" cellPadding="0" width="100%">
				<TR>
					<td class="lbPageTitle"><asp:label id="lblHeader" cssClass="lbPageTitle" Runat="server">Gửi thông báo mất</asp:label></td>
				</TR>
				<TR>
					<td><asp:label id="lblNote" Runat="server"><u>G</u>hi chú:</asp:label></td>
				</TR>
				<tr>
					<td>
						<asp:textbox id="txtNote" Runat="server" TextMode="MultiLine" Rows="7" Width="100%"></asp:textbox>
					</td>
				</tr>
				<TR>
					<td align="center"><asp:button id="btnSend" Runat="server" Text="Gửi(g)"></asp:button>&nbsp;
						<asp:button id="btnNoSend" Runat="server" Text="Không gửi(k)"></asp:button></td>
				</TR>
			</table>		
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
				<asp:ListItem Value="4">Thông điệp đã được gửi đi thành công.</asp:ListItem>
				<asp:ListItem Value="5">Ở trạng thái hiện thời của yêu cầu, không thể thực hiện thao tác này.</asp:ListItem>
				<asp:ListItem Value="6">Lỗi ! Thông điệp không gửi đi được.</asp:ListItem>
			</asp:DropDownList>
			<input id="hdnILLID" type="hidden" name="ILLID" runat="server"> <input id="hdnResponderID" type="hidden" name="ResponderID" runat="server"><br>
		</form>
	</body>
</HTML>
