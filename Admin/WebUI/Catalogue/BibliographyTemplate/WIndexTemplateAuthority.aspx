<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexTemplateAuthority" CodeFile="WIndexTemplateAuthority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexTemplateAuthority</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR>
					<TD Class="lbPageTitle" align="center" colspan="2">
						<asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Mẫu biên mục (Dữ liệu căn cứ)</asp:label></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:label id="lblForm" runat="server" CssClass="lbLabel">Bạn có thể tạo mới, sửa, gộp các <U>
								m</U>ẫu biên mục.</asp:label></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center"><asp:listbox id="lstMarcForm" runat="server" Rows="7" Height="220px" Width="248px"></asp:listbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD colspan="2" align="center"><asp:Button id="btnUpdate" runat="server" Text="Cập nhật(u)" Width="98px"></asp:Button>&nbsp;<asp:dropdownlist id="ddlMarcForm" runat="server"></asp:dropdownlist><asp:Button id="btnMerger" runat="server" Width="70px" Text="Gộp(m)"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Tạo mới</asp:ListItem>
				<asp:ListItem Value="1">Bạn chưa chọn mẫu nguồn cần gộp</asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="4">Gộp các mẫu biên mục</asp:ListItem>
				<asp:ListItem Value="5">Gộp mẫu biên mục thành công!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
