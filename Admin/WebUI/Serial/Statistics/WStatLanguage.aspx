<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WstatLanguage" CodeFile="WStatLanguage.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thống kê theo ngôn ngữ tài liệu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
           <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" onload="if(document.forms[0].hidHave.value>0)GenURLImg1(9);">
		<form id="Form1" method="post" runat="server">
			<table width="100%" id="divBody">
				<TR Class="lbPageTitle">
					<td ><asp:Label ID="lblHeader" Runat="server" cssClass="main-head-form" Width="100%">Thống kê ấn phẩm định kỳ theo ngôn ngữ</asp:Label></td>
				</TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:Label CssClass="lbSubformTitle" Width="100%" id="lblTitleChartBarItem1" Runat="server">Biểu đồ hình cột</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG src="" border="0" usemap="#map1" name="Image1" runat="server" id="anh1">
					<asp:label id="lblNostatic" Runat="server" Visible=False>Không có thông tin thống kê !</asp:label></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:Label CssClass="lbSubformTitle" Width="100%" id="lblTitleChartBarCopynumber1" Runat="server">Biểu đồ hình tròn</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG src="" border="0" name="Image2" runat="server" id="anh2">
					<asp:label id="lblNostatic1" Runat="server" Visible=False>Không có thông tin thống kê !</asp:label></TD>
				</TR>
			</table>
			<asp:DropDownList id="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Ngôn ngữ tài liệu</asp:ListItem>
				<asp:ListItem Value="4">Số lượng ấn phẩm</asp:ListItem>
			</asp:DropDownList>
			<input id="hidHave" runat="server" type="hidden" value="0" NAME="hidHave">
		</form>
	</body>
</HTML>
