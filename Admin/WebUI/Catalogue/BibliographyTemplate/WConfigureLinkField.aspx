<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WConfigureLinkField" CodeFile="WConfigureLinkField.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WConfigureLinkField</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellPadding="3" cellspacing="3" width="100%" border="0">
				<TR>
					<TD colspan="2" align="center" class="lbPageTitle">
						<asp:Label Cssclass="lbPageTitle" id="lblMainTitle" runat="server" Width="100%">Thiết đặt kiểu liên kết</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblMarcLinkTypes" runat="server"><u>K</u>iểu liên kết: </asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlMarcLinkTypes" runat="server" AutoPostBack="False"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Button id="btnClose" runat="server" Text="Đóng"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
