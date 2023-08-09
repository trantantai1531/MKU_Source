<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldsDefaultHidden" CodeFile="WMarcFieldsDefaultHidden.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>WMarcFieldsDefaultHidden</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Nhãn trường không tồn tại</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</html>
