<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRChangeFolder" CodeFile="WIRChangeFolder.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIRChangeFolder</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible=False>
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
				<asp:ListItem Value="3">Chuyển sang thư mục thích hợp:</asp:ListItem>
				<asp:ListItem Value="4">Chuyển thành công !</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
