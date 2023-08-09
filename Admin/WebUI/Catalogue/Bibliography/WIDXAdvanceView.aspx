<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIDXAdvanceView" CodeFile="WIDXAdvanceView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIDXAdvanceView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftmargin="0" rightmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td colspan="2"><asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">Xuất danh mục đã chọn ra các dạng file</asp:Label></td>
				</tr>
				<tr>
					<td width="30%" align="right"><asp:Label ID="lblFileName" Runat="server">Tên <u>f</u>ile: </asp:Label></td>
					<td width="70%"><asp:TextBox ID="txtFileName" Runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td width="30%" align="right"><asp:Label ID="lblExtension" Runat="server">Mở <u>r</u>ộng: </asp:Label></td>
					<td width="70%"><asp:DropDownList ID="ddlExtension" Runat="server">
							<asp:ListItem Value="1" Selected="True">doc</asp:ListItem>
							<asp:ListItem Value="2">pdf</asp:ListItem>
							<asp:ListItem Value="3">excel</asp:ListItem>
							<asp:ListItem Value="4">html</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td width="30%" align="right"><asp:Label ID="lblAction" Runat="server">Xử lý: </asp:Label></td>
					<td width="70%"><asp:RadioButton ID="optDownload" Runat="server" GroupName="Action" Checked="true" Text="<u>K</u>hông xem"></asp:RadioButton><asp:RadioButton ID="optView" Runat="server" GroupName="Action" Text="<u>X</u>em"></asp:RadioButton></td>
				</tr>
				<tr>
					<td width="30%" align="right"></td>
					<td width="70%"><asp:Button ID="btnProcess" Runat="server" Text="Thực hiện(t)"></asp:Button>&nbsp;<asp:Button ID="btnReset" Runat="server" Text="Làm lại(i)"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
