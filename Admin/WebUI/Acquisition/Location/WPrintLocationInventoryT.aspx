<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPrintLocationInventoryT" CodeFile="WPrintLocationInventoryT.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPrintLocationInventoryT</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="3" width="100%">
				<tr>
					<td>
						<asp:button id="btnLastPage" Text="Trang trước(p)" Width="98px" Runat="server"></asp:button></td>
					<td align="center">
						<asp:label id="lblIndexPage" Runat="server">Tran<U>g</U> thứ</asp:label>&nbsp;
						<asp:textbox id="txtPageIndex" Runat="server" Width="50px">1</asp:textbox>&nbsp;
						<asp:label id="lblIndexPage1" Runat="server">trong số</asp:label>&nbsp;
						<asp:label id="lblIndexPage2" Runat="server">trang</asp:label></td>
					<td align="right">
						<asp:button id="btnNextPage" Text="Trang tiếp(n)" Width="95px" Runat="server"></asp:button>
					</td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False" Width=0 Height=0>
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Vượt quá số trang cho phép!</asp:ListItem>
				<asp:ListItem Value="3">Phải là số!</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
			</asp:dropdownlist>
			<script language="javascript">
				GotoSubmit();
			</script>
		</form>
	</body>
</HTML>
