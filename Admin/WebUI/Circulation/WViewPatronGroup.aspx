<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WViewPatronGroup" CodeFile="WViewPatronGroup.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xem thông tin về nhóm bạn đọc</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="100%" cellPadding="3" border="0" cellSpacing="0">
				<tr>
					<td colspan="2" align="center">
						<asp:Label ID="lblTitlePage" CssClass="main-group-form" Width="100%" Runat="server">Xem thông tin của nhóm bạn đọc </asp:Label>
					</td>
				</tr>
				<TR>
					<TD align="right" width="50%">
						<asp:Label id="lblName" runat="server">Tên nhóm: </asp:Label></TD>
					<TD>
						<b>
							<asp:Label id="lblNameData" runat="server"></asp:Label></b>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblLoanQuota" runat="server">Số ấn phẩm được mượn về: </asp:Label></TD>
					<TD>
						<b>
							<asp:Label id="lblLoanQuotaData" runat="server"></asp:Label></b>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblInlibraryQuota" runat="server">Số sách được mượn tại chỗ: </asp:Label></TD>
					<TD>
						<b>
							<asp:Label id="lblInlibraryQuotaData" runat="server"></asp:Label></b>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblHoldQuota" runat="server">Số sách được giữ chỗ: </asp:Label></TD>
					<TD>
						<b>
							<asp:Label id="lblHoldQuotaData" runat="server"></asp:Label></b>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="LblHoldTurnTimeOut" runat="server">Thời gian bảo lưu lượt giữ chỗ(Ngày): </asp:Label></TD>
					<TD>
						<b>
							<asp:Label id="LblHoldTurnTimeOutData" runat="server"></asp:Label></b>
					</TD>
				</TR>
				<TR>
					<TD colspan="2" align="center" class="lbControlBar">
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" Width="64px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
