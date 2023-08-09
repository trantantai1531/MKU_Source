<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WLocTreeView" CodeFile="WLocTreeView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
	<body>
		<form id="Form1" method="post" runat="server">
			<div style="LEFT:0px; POSITION:absolute; TOP:100px">
				<table border="0">
					<tr>
						<td>
							<font size="-2"><a style="FONT-SIZE:6pt;COLOR:silver;TEXT-DECORATION:none" href="http://www.treemenu.net/"
									target="_blank"></a></font>
						</td>
					</tr>
				</table>
			</div>
			<asp:Label Runat="server" ID="lblScript">
				<script>initializeDocument()</script>
			</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Hệ thống lưu trữ</asp:ListItem>
				<asp:ListItem Value="3">Không xác định</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
