<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WUpload" CodeFile="WUpload.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tải ảnh độc giả</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD align="center">
						<asp:label id="lblFile" runat="server" CssClass="lbPageTitle">Tải ảnh đọc giả</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<INPUT id="FileUpload" type="file" size="30" name="FileUpload" runat="server"></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:button id="btnUpload" runat="server" Width="82px" Text="Tải lên(a)"></asp:button>&nbsp;
						<asp:button id="btnClose" runat="server" Width="82px" Text="Đóng(o)"></asp:button></TD>
				</TR>
			</TABLE>
			<input id="hidAllowedFiles" type="hidden" runat="server" NAME="hidAllowedFiles" value="png;jpg;gif;bmp">
			<input id="hidDenniedFiles" type="hidden" runat="server" NAME="hidDenniedFiles">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Kiểu file này không hợp lệ!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
