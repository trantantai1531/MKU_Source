<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatClassResult" CodeFile="WStatClassResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatClassResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgColor="#ffffff" onload="GenURL(7)" topmargin="0" leftmargin="0"
		rightmargin="0">
		<form id="Form1" runat="server" method="post" style="POSITION: relative">
			<table cellPadding="1" width="100%" align="center" border="0" id="Table1" cellSpacing="1"
				bgcolor="#ffffff">
				<TR>
					<TD align="center"><asp:Label ID="lblNotFound" Runat="server" Width="100%" CssClass="main-head-form" Visible="False">Không tìm thấy dữ liệu</asp:Label>
					</TD>
				</TR>
				<tr>
					<TD align="center" width="100%"><IMG src="" name="anh1" border="0" id="anh1" runat="server">
						<IMG src="" name="anh2" border="0" id="anh2" runat="server">
					</TD>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lổi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Số lượng sinh viên</asp:ListItem>
				<asp:ListItem Value="4">Tên lớp</asp:ListItem>
				<asp:ListItem Value="5">Tỉ lệ % sinh viên theo lớp</asp:ListItem>
				<asp:ListItem Value="6">Không rõ</asp:ListItem>
				<asp:ListItem Value="7">Thống kê theo lớp</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
