<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WUpLoadManagement" CodeFile="WUpLoadManagement.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WUpLoadManagement</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD align="center">
						<asp:label id="lblFile" runat="server" CssClass="lbPageTitle">Tải File</asp:label></TD>
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
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
