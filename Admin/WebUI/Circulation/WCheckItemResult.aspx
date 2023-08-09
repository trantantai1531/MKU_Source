<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckItemResult" CodeFile="WCheckItemResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckItemResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<asp:Table id="tblResult" Runat="server" Width="100%" BorderWidth="2px"></asp:Table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Hiển thị các bản ghi</asp:ListItem>
				<asp:ListItem Value="3">Thêm ĐCCB theo ấn phẩm này</asp:ListItem>
				<asp:ListItem Value="4">Mở biểu ghi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
