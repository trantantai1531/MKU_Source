<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCheckAttachField" CodeFile="WCheckAttachField.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckAttachField</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Nhãn trường mẹ</asp:ListItem>
				<asp:ListItem Value="1">có kiểu dữ liệu là Attached File, vì vậy không thể tạo được trường con</asp:ListItem>
				<asp:ListItem Value="2">không thể có nhiều hơn 1 trường con có kiểu dữ liệu là Attached File. Hiện đã có trường con</asp:ListItem>
				<asp:ListItem Value="3">là trường Attached File</asp:ListItem>
				<asp:ListItem Value="4">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
