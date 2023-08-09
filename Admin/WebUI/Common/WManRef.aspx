<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WManRef" CodeFile="WManRef.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WManRef</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ReCheckRefs();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colspan="2"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle">Thiết đặt các tính năng thường dùng của</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR class="lbGroupTitle">
								<TD align="center" width="46%"><asp:label id="lblAccept" runat="server" cssclass="lbGroupTitle">Các chức năng thường dùng</asp:label></TD>
								<TD align="center"></TD>
								<TD align="center" width="46%"><asp:label id="lblDeny" runat="server" cssclass="lbGroupTitle">Các chức năng ít dùng</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:listbox id="lstAccept" runat="server" SelectionMode="Multiple" Width="100%" Height="300px"></asp:listbox></TD>
								<TD align="center"><asp:button id="btnAccept" runat="server" Width="40px"  Text="<<"></asp:button><br>
									<asp:button id="btnDeny" runat="server" Width="40px" Text=">>"></asp:button></TD>
								<TD><asp:listbox id="lstDeny" runat="server" SelectionMode="Multiple" Width="100%" Height="300px"></asp:listbox></TD>
							</TR>
							<TR class="lbControlBar">
								<TD align="center" colSpan="3"><asp:button id="btnSave" Width="90px" Runat="server" Text="Cập nhật(u)"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<input type="hidden" id="hidRef" runat="server">
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật thành công</asp:ListItem>
				<asp:ListItem Value="3">Phân hệ Biên mục</asp:ListItem>
				<asp:ListItem Value="4">Phân hệ Bạn đọc</asp:ListItem>
				<asp:ListItem Value="5">Phân hệ Mượn - Trả</asp:ListItem>
				<asp:ListItem Value="6">Phân hệ Bổ sung</asp:ListItem>
				<asp:ListItem Value="7">Phân hệ Ấn phẩm định kỳ</asp:ListItem>
				<asp:ListItem Value="8">Phân hệ ILL</asp:ListItem>
				<asp:ListItem Value="9">Phân hệ Phát hành</asp:ListItem>
				<asp:ListItem Value="10">Phân hệ Quản trị</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
