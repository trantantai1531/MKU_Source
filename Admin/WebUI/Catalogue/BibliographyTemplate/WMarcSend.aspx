<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcSend" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WMarcSend.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcSend</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0"
		onload="parent.document.getElementById('frmMain').setAttribute('rows','*,45');">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align=left>
				<TR align=left>
					<TD align="left" width=55%>
						<asp:label id="lblFormName" runat="server"><U>T</U>ên form:</asp:label><asp:DropDownList id="ddlFormName" runat="server"></asp:DropDownList><asp:textbox id="txtFormName" runat="server" Width="170px"></asp:textbox></TD>
					<TD  align="left" width=30%>
						<asp:button id="btnUpdate" runat="server" Text="Cập nhật(u)" Width="92px"></asp:button>
						<asp:button id="btnReset" runat="server" Text="Làm lại(r)" Width="80px"></asp:button>
						<asp:button id="btnView" runat="server" Text="Xem(v)" Width="60px"></asp:button></TD>
					<TD align="left">
						<asp:button id="btnNew" runat="server" Text="Tạo trường(c)" Width="102px"></asp:button></TD>
				</TR>
			</TABLE>
			<INPUT id="txtFormID" type="hidden" value="0" name="txtFormID" runat="server"> <INPUT id="txtPickedFields" type="hidden" value="," name="txtPickedFields" runat="server">
			<INPUT id="txtPickedTags" type="hidden" value="," name="txtPickedTags" runat="server">
			<INPUT id="txtLoadedFields" type="hidden" value="," name="txtLoadedFields" runat="server">
			<INPUT id="txtMandatoryFields" type="hidden" value="," name="txtMandatoryFields" runat="server">
			<INPUT id="txtFieldDefaultValues" type="hidden" name="txtFieldDefaultValues" runat="server">
			<INPUT id="txtFieldIndicatorValues" type="hidden" name="txtFieldIndicatorValues" runat="server">
			<INPUT id="txtTextBoxFields" type="hidden" name="txtTextBoxFields" runat="server">
			<INPUT id="txtExcludeFields" type="hidden" name="txtExcludeFields" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">---------- Chọn ----------</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập tên mẫu biên mục!</asp:ListItem>
				<asp:ListItem Value="4">Bạn phải chọn ít nhất một trường cho mẫu biên mục!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
