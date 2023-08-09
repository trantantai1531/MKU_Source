<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WSetFieldShow" CodeFile="WSetFieldShow.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thiết đặt tham số hiển thị</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr class="lbPageTitle">
					<td colspan="2">
						<asp:label id="lblTitle" CssClass="main-group-form" runat="server" Width="100%">Thiết đặt tham số hiển thị</asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%">
						<asp:label id="lblFieldShow" runat="server">Chọn cộ<u>t</u>:</asp:label></td>
					<td>
						<asp:listbox id="lstFieldShow" runat="server" Height="84px" SelectionMode="Multiple" Width="216">
							<asp:ListItem Value="0" Selected="True">Số thẻ</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">Họ tên</asp:ListItem>
							<asp:ListItem Value="2" Selected="True">Ngày sinh</asp:ListItem>
							<asp:ListItem Value="3">Ngày cấp</asp:ListItem>
							<asp:ListItem Value="4">Ngày hết hạn</asp:ListItem>
							<asp:ListItem Value="5">Giới tính</asp:ListItem>
							<asp:ListItem Value="6">Dân tộc</asp:ListItem>
							<asp:ListItem Value="7">Trường</asp:ListItem>
							<asp:ListItem Value="8">Khoa</asp:ListItem>
							<asp:ListItem Value="9">Khoá</asp:ListItem>
							<asp:ListItem Value="10">Lớp</asp:ListItem>
							<asp:ListItem Value="11">Địa chỉ</asp:ListItem>
							<asp:ListItem Value="12">Điện thoại</asp:ListItem>
					<%--		<asp:ListItem Value="13">Di động</asp:ListItem>--%>
							<asp:ListItem Value="14">Email</asp:ListItem>
							<asp:ListItem Value="15">Ghi chú</asp:ListItem>
						<%--	<asp:ListItem Value="16">Nhóm ngành nghề</asp:ListItem>--%>
							<asp:ListItem Value="17">Nhóm</asp:ListItem>
						</asp:listbox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblPageSize" runat="server">Số <u>d</u>òng/trang:</asp:label></td>
					<td>
						<asp:textbox id="txtPageSize" Width="200px" runat="server" text="20"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td>
						<asp:button id="btnSet" runat="server" text="Thiết đặt(s)" Width="98px"></asp:button>
						<asp:button id="btnClose" runat="server" text="Đóng(s)" Width="70px"></asp:button>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Số trang phải là số nguyên</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
