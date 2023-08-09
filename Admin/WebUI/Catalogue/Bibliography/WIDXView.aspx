<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIDXView" CodeFile="WIDXView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIDXView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body onload="parent.document.getElementById('frmMain').setAttribute('rows','*,35');">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblLabel" runat="server" Visible="False">Nhan đề khác;Nhan đề ngoài bìa;Nhan đề trên trang tên bổ sung;Nhan đề hoa văn;Nhan đề chạy;Nhan đề gáy sách;Nhan đề thay đổi;Nhan đề dịch</asp:Label>
			<asp:Label ID="lblLabel0" Runat="server" Visible="False">Bạn không được cấp quyền sử dụng chức năng này</asp:Label>
			<asp:Label ID="lblLabel1" Runat="server" Visible="False">Tạo mới</asp:Label>
			<asp:Label ID="lblLabel2" Runat="server" Visible="False">Mã lỗi</asp:Label>
			<asp:Label ID="lblLabel3" Runat="server" Visible="False">Chi tiết lỗi</asp:Label>
			<asp:Label ID="lblLabel4" Runat="server" Visible="False">Mẫu phích : </asp:Label>

			<asp:DropDownList ID="ddlAboutAction" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
				<asp:ListItem Value="1">Mẫu phích mới chưa được ghi nhận</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật mẫu phích thành công</asp:ListItem>
				<asp:ListItem Value="3">Đã ghi nhận mẫu phích mới</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa nhập tên phích</asp:ListItem>
				<asp:ListItem Value="5">Mẫu phích mới đã được ghi nhận</asp:ListItem>
				<asp:ListItem Value="6">"Insert: "</asp:ListItem>
				<asp:ListItem Value="7">"Update: "</asp:ListItem>
				<asp:ListItem Value="8">"Delete: "</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
