<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatDayTaskbar" CodeFile="WStatDayTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatDayTaskbar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="StatDay" width="100%" border="0">
				<TR>
					<TD>
						<asp:label id="lblMainTitle" Runat="server" CssClass="lbPageTitle" Width="100%">Thống kê ấn phẩm bổ sung theo ngày tháng năm</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblYear" Runat="server">Nă<u>m</u>: </asp:label>
						<asp:dropdownlist id="ddlYear" Runat="server"></asp:dropdownlist>&nbsp;
						<asp:label id="lblMonth" Runat="server">Thá<u>n</u>g: </asp:label>
						<asp:dropdownlist id="ddlMonth" Runat="server">
							<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
							<asp:ListItem Value="2">2</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="4">4</asp:ListItem>
							<asp:ListItem Value="5">5</asp:ListItem>
							<asp:ListItem Value="6">6</asp:ListItem>
							<asp:ListItem Value="7">7</asp:ListItem>
							<asp:ListItem Value="8">8</asp:ListItem>
							<asp:ListItem Value="9">9</asp:ListItem>
							<asp:ListItem Value="10">10</asp:ListItem>
							<asp:ListItem Value="11">11</asp:ListItem>
							<asp:ListItem Value="12">12</asp:ListItem>
						</asp:dropdownlist>&nbsp;
						<asp:button id="btnStatistic" Runat="server" Text="Thống kê(s)" Width="92px"></asp:button>
						<asp:button id="btnClose" Runat="server" Text="Trở lại(b)" Width="88px"></asp:button>
                        <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
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
