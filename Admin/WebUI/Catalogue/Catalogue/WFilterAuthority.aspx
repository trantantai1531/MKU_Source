<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WFilterAuthority" CodeFile="WFilterAuthority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WFilterAuthority</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" align="center">
				<tr class="lbPageTitle">
					<td align="left" colSpan="2"><asp:label id="lblTitle" Runat="server" CssClass="lbPageTitle">Lọc bản ghi Authority</asp:label></td>
				</tr>
				<tr>
				</tr>
				<tr>
					<td align="right" width="10%"><asp:label id="lblAccessEntry" Runat="server">Mục từ chứa:</asp:label></td>
					<td align="left" width="90%"><asp:textbox id="txtAccessEntry" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblReference" Runat="server">Trong dữ liệu:</asp:label></td>
					<td align="left"><asp:dropdownlist id="ddlReference" Runat="server" style="Z-INDEX:105">							
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td></td>
					<td><asp:button id="btnFilter" Runat="server" Text="Lọc(f)" CausesValidation="True"></asp:button></td>
				</tr>
			</table>
			<asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Không tìm thấy bản ghi nào thoả mãn điều kiện lọc!</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="3">----- Chọn dữ liệu -----</asp:ListItem>
				<asp:ListItem Value="4">Bạn phải nhập hoặc chọn ít nhất một điều kiện lọc!</asp:ListItem>
			</asp:DropDownList>
		</form>
		
		<script language = javascript>
			document.forms[0].txtAccessEntry.focus();
		</script>
	</body>
</HTML>
