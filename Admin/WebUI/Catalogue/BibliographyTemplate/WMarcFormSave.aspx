<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFormSave" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WMarcFormSave.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFormSave</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList ID="ddlLabel" Visible="False" Runat="server" Width="0">
				<asp:ListItem Value="0">Tạo mẫu biên mục</asp:ListItem>
				<asp:ListItem Value="1">thành công!</asp:ListItem>
				<asp:ListItem Value="2">Sửa mẫu biên mục</asp:ListItem>
				<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
