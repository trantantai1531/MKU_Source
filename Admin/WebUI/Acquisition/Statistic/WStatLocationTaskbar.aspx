<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatLocationTaskbar" CodeFile="WStatLocationTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatLocationTaskbar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td>
						<asp:Label ID="lblLocation" Runat="server">Đị<U>a</U> điểm: </asp:Label>
						<asp:DropDownList ID="ddlLocation" Runat="server"></asp:DropDownList>&nbsp;
						<asp:Button id="btnStatistic" runat="server" Text="Thống kê(t)" Width="83px"></asp:Button>
						<asp:Button ID="btnBack" Runat="server" Text="Trở lại(l)" Width="76px"></asp:Button>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">------ Chọn toàn bộ ------</asp:ListItem>
				<asp:ListItem Value="3">----- Chọn -----</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
