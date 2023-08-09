<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldHelp" CodeFile="WMarcFieldHelp.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Trợ giúp nhập dữ liệu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onKeyPress="thisMicrosoftKeyPress()" style="background-color:White;">
		<form id="Form1" action="WMarcFieldHelp.aspx" method="post" runat="server">
			<INPUT id="txtBreakType" type="hidden" value="0" name="txtBreakType" runat="server">
			<INPUT id="txtFieldCount" type="hidden" value="0" name="txtFieldCount" runat="server">
			<INPUT id="txtAuthority" type="hidden" name="txtAuthority" runat="server"> <INPUT id="txtFieldCode" type="hidden" name="txtFieldCode" runat="server">
			<INPUT id="txtFormID" type="hidden" value="0" name="txtFormID" runat="server"> <INPUT id="txtBreakPoint" type="hidden" value="0" name="txtBreakPoint" runat="server">
			<INPUT id="txtIndicator" type="hidden" name="txtIndicator" runat="server"> <INPUT id="txtRest" type="hidden" name="txtRest" runat="server">
			<INPUT id="txtValue" type="hidden" name="txtValue" runat="server" value="##">
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="center" colSpan="2"><asp:label id="lblMainTitle" CssClass="lbPageTitle" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblDetail" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:table id="tblData" runat="server" BorderWidth="0px" CellSpacing="0" CellPadding="2" Width="100%"></asp:table></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center"><asp:button id="btnUpdate" Runat="server" Width="70px" Text="Nhập(u)" style="margin-right:5px"></asp:button><asp:button id="btnClose" Runat="server" Width="70px" Text="Đóng(o)"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Không phải trường lặp</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
