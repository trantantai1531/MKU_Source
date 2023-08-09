<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataPut" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCataPut.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCataPut</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã tài liệu không tồn tại</asp:ListItem>
				<asp:ListItem Value="1">Lỗi trong khi cập nhật bảng Item</asp:ListItem>
				<asp:ListItem Value="2">Lỗi trong khi cập nhật trường</asp:ListItem>
				<asp:ListItem Value="3">Dữ liệu bản ghi không hợp lệ</asp:ListItem>
				<asp:ListItem Value="4">Lỗi trong khi cập nhật</asp:ListItem>
				<asp:ListItem Value="5">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="6">Nguồn lỗi</asp:ListItem>
				<asp:ListItem Value="7">Mô tả lỗi</asp:ListItem>
				<asp:ListItem Value="8">Lý do lỗi</asp:ListItem>
				<asp:ListItem Value="9">Cập nhật bản ghi thành công</asp:ListItem>
				<asp:ListItem Value="10">Thêm mới bản ghi thành công.</asp:ListItem>
				<asp:ListItem Value="11">Bạn có muốn xếp giá cho ấn phẩm vừa biên mục không?</asp:ListItem>
				<asp:ListItem Value="12">Đang cập nhật dữ liệu, xin vui lòng chờ trong chốc lát...</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
