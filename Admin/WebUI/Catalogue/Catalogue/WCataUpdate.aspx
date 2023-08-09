<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataUpdate" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCataUpdate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCataUpdate</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR>
					<TD align="center">
						<asp:Button id="btnBack" runat="server" Text="Quay lại trang trước(b)" Visible="False"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Sửa nội dung bản ghi biên mục</asp:ListItem>
				<asp:ListItem Value="1">Mã tài liệu không tồn tại</asp:ListItem>
				<asp:ListItem Value="2">Lỗi trong khi cập nhật bảng Item</asp:ListItem>
				<asp:ListItem Value="3">Lỗi trong khi cập nhật trường</asp:ListItem>
				<asp:ListItem Value="4">Dữ liệu bản ghi không hợp lệ</asp:ListItem>
				<asp:ListItem Value="5">Lỗi trong khi cập nhật</asp:ListItem>
				<asp:ListItem Value="6">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="7">Nguồn lỗi</asp:ListItem>
				<asp:ListItem Value="8">Mô tả lỗi</asp:ListItem>
				<asp:ListItem Value="9">Lý do lỗi</asp:ListItem>
				<asp:ListItem Value="10">Cập nhật bản ghi thành công</asp:ListItem>
				<asp:ListItem Value="11">Cập nhật bản ghi thành công. Bấm OK để nhập thông tin xếp giá của ấn phẩm, bấm Cancel để tiếp tục biên mục ấn phẩm khác.</asp:ListItem>
				<asp:ListItem Value="12">Đang cập nhật dữ liệu, xin vui lòng chờ trong chốc lát...</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
