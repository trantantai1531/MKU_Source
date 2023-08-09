<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WFicheSaveFile" CodeFile="WFicheSaveFile.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WFicheSaveFile</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<p>
			</p>
			<p>
			</p>
			<table border="0" width="100%">
				<tr align="center">
					<td>
						<asp:Label id="lblOne" runat="server" CssClass="lbLabel">Bấm</asp:Label>&nbsp;
						<asp:HyperLink id="lnkLink" runat="server">vào đây</asp:HyperLink>&nbsp;
						<asp:Label id="lblTwo" runat="server" CssClass="lbLabel">để lấy kết quả</asp:Label></td>
				</tr>
				<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
					<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
					<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="2">Không chuyển được sang định dạng file Word, bạn chỉ có thể xem dưới dạng HTML!!!</asp:ListItem>
				</asp:DropDownList>
			</table>
		</form>
	</body>
</HTML>
