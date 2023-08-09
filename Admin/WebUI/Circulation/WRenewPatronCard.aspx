<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WRenewPatronCard" CodeFile="WRenewPatronCard.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Gia hạn thẻ</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD colspan="2" align="center">
						<asp:Label CssClass="main-group-form" id="lblPageTitle" runat="server" Width="100%">Gia hạn thẻ bạn đọc</asp:Label></TD>
				</TR>
				<TR valign =bottom>
					<TD align="right" style="HEIGHT: 57px">
						<asp:Label id="lblPatronCodelb" runat="server">Số thẻ:</asp:Label></TD>
					<TD style="HEIGHT: 57px">
						<b>
							<asp:Label id="lblPatronCode" runat="server"></asp:Label></b></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblRenew" runat="server">Gia hạn đến ngày:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtNewDate" runat="server" Width="100px"></asp:TextBox>
						<asp:HyperLink id="lnkCal" runat="server">Lịch</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD align="center" colspan="2">
						<asp:Button id="btnRenew" runat="server" Width="88px" Text="Gia hạn(r)"></asp:Button>
						<asp:Button id="btnClose" runat="server" Width="60px" Text="Đóng(o)"></asp:Button></TD>
				</TR>
			</TABLE>
			<input type="hidden" id="hidLoanMode" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập điểm hết hạn mới</asp:ListItem>
				<asp:ListItem Value="4">Gia hạn thẻ bạn đọc</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
