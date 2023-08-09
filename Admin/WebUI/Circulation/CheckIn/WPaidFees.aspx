<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPaidFees" CodeFile="WPaidFees.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thu phí</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR>
					<TD colspan="2" align="center">
						<asp:Label id="lblPageTitle" runat="server" CssClass="lbPageTitle" Width="100%">Thu phí/phạt mượn ấn phẩm</asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right" width="40%">
						<asp:Label id="lblFeelb" runat="server">Phí mượn:</asp:Label></TD>
					<TD>
						<b>
							<asp:Label id="lblFees" runat="server">0</asp:Label></b></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblFineslb" runat="server">Phạt:</asp:Label></TD>
					<TD>
						<b>
							<asp:Label id="lblFines" runat="server">0</asp:Label></b></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:Button id="btnLog" runat="server" Width="50px" Text="Thu(t)"></asp:Button>&nbsp;
						<asp:Button id="btnClose" runat="server" Width="73px" Text="Bỏ qua(b)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
