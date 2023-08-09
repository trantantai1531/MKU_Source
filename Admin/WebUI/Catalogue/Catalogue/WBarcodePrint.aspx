<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WBarcodePrint" CodeFile="WBarcodePrint.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBarcodePrint</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bgcolor="#ffffff">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" height="100%" runat="server"
				bgcolor="#ffffff">
				<tr>
					<td width="100%" height="100%"><asp:HyperLink ID="hrf" Runat="server" Visible="False" NavigateUrl="">Xem</asp:HyperLink>
						<asp:Label ID="lblDisplay" Runat="server" Width="100%" Height="100%"></asp:Label></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="Display">In mã vạch cho tài liệu</asp:ListItem>
				<asp:ListItem Value="SaveToFile">Lưu in mã vạch vào file</asp:ListItem>
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
