<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORDeniedReport" CodeFile="WORDeniedReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WORDeniedReport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" width="100%" cellpadding="0" cellspacing="0">
				<tr>
					<td Class="lbPageTitle">
						<asp:Label ID="lblHeader" Runat="server" cssClass="lbPageTitle">Báo cáo những yêu cầu từ chối</asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:DataGrid id="dtgIRReport" runat="server" AutoGenerateColumns="False" Width="100%"></asp:DataGrid>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền khai thác chức năng này.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
