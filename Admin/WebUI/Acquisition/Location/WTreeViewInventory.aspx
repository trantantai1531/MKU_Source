<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WTreeViewInventory" CodeFile="WTreeViewInventory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WLocTreeView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="5" leftmargin="5" style="background-color: #FCFCC8;padding-right: 13px;">
		<form id="Form1" method="post" runat="server">
			<div style="LEFT:0px; POSITION:absolute; TOP:50px">
				<table border="0">
					<tr>
						<td>
							<font size="-2">
								<a style="FONT-SIZE:6pt;COLOR:silver;TEXT-DECORATION:none" href="http://www.treemenu.net/" target="_blank"></a></font>
						</td>
					</tr>
				</table>
			</div>
			<asp:Label Runat="server" ID="lblScript">
				<script>initializeDocument()</script>
			</asp:Label>
			<asp:Label ID="lblRoot" Runat="server" Visible="False">Các kho được kiểm kê</asp:Label>
			<asp:Label ID="lblNoName" Runat="server" Visible="False">Chưa xác định</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
					<asp:ListItem Value="0">Mã lỗi </asp:ListItem>
					<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
					<asp:ListItem Value="3">Kiểm kê</asp:ListItem>
				</asp:DropDownList>
		</form>
	</body>
</HTML>
