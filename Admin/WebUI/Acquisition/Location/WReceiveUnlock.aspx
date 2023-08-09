<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WReceiveUnlock" CodeFile="WReceiveUnlock.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WReceiveUnlock</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body onload="document.forms[0].txtCopyNumberFrom.focus();">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td class="lbPageTitle" colSpan="2"><asp:label id="lblHeader" runat="server">Kiểm nhận và mở khóa các ấn phẩm</asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblLib" runat="server"><u>T</u>hư viện:</asp:label>&nbsp;
					</td>
					<td><asp:dropdownlist id="ddlLib" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblLoc" runat="server"><u>K</u>ho:</asp:label>&nbsp;
					</td>
					<td><asp:dropdownlist id="ddlLoc" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblCopyNumberFrom" runat="server">ĐKC<u>B</u> từ:</asp:label>&nbsp;
					</td>
					<td><asp:textbox id="txtCopyNumberFrom" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblCopyNumberTo" runat="server">Đ<u>K</u>CB tới:</asp:label>&nbsp;
					</td>
					<td><asp:textbox id="txtCopyNumberTo" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"></td>
					<td><asp:button id="btnReceiveUnlock" Runat="server" Text="Kiểm nhận/Mở khóa(k)" Width="160px"></asp:button></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Kiểm nhận và mở khóa thành công!</asp:ListItem>
				<asp:ListItem Value="3">-------Chọn thư viện---------</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa chọn đủ thông tin!</asp:ListItem>
				<asp:ListItem Value="5">Không tồn tại dữ liệu!</asp:ListItem>
				<asp:ListItem Value="6">Bạn không được cấp quyền sử dụng tính năng này.</asp:ListItem>
			</asp:dropdownlist><input id="hidLocID" type="hidden" name="hidLocID" runat="server">
		</form>
	</body>
</HTML>
