<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIdxIdx" CodeFile="WIdxIdx.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIdxIdx</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblFail" runat="server" Visible="False">Không có dữ liệu và mã danh mục!</asp:Label>
			<asp:Label ID="lblLabel0" Runat="server" Visible="False">Bạn không được cấp quyền sử dụng chức năng này</asp:Label>
			<asp:Label ID="lblLabel1" Runat="server" Visible="False">Tạo mới</asp:Label>
			<asp:Label ID="lblLabel2" Runat="server" Visible="False">Mã lỗi</asp:Label>
			<asp:Label ID="lblLabel3" Runat="server" Visible="False">Chi tiết lỗi</asp:Label>
			<asp:Label ID="lblLabel4" Runat="server" Visible="False">Mẫu phích : </asp:Label>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Không có dữ liệu và mã danh mục!</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
