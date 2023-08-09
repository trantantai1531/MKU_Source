<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatMonthTaskbar" CodeFile="WStatMonthTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatMonthTaskbar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

       
	</HEAD>
	<body bgColor="white" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="StatMongth" width="100%" border="0">
				<TR>
					<TD>
						<asp:label id="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle main-head-form">Thông kê ấn phẩm theo các tháng trong năm</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblYear" Runat="server"><u>N</u>ăm: </asp:label>&nbsp;
						<asp:dropdownlist id="ddlYear" Runat="server"></asp:dropdownlist>
						<asp:button id="btnStatistic" Runat="server" Text="Thống kê(s)" Width="92px"></asp:button>
						<asp:button id="btnClose" Runat="server" Text="Trở lại(b)" Width="92px"></asp:button>
                        <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
