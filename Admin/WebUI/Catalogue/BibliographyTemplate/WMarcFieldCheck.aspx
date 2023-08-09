<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldCheck" CodeFile="WMarcFieldCheck.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFieldCheck</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">				
				<asp:ListItem Value="0">Nhãn trường</asp:ListItem>
				<asp:ListItem Value="1"> được sử dụng cho trường </asp:ListItem>
				<asp:ListItem Value="2">Bạn có thể tạo trường con cho trường này!</asp:ListItem>
				<asp:ListItem Value="3">Trường mẹ không tồn tại!</asp:ListItem>
				<asp:ListItem Value="4">Nhãn trường mẹ </asp:ListItem>
				<asp:ListItem Value="5"> có kiểu dữ liệu là Attached File, vì vậy không thể tạo được trường con!</asp:ListItem>
				<asp:ListItem Value="6">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="7">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>			
		</form>
	</body>
</HTML>
