<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqImportByTemplate.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.Catalogue_Catalogue_AcqImportByTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
</html>
