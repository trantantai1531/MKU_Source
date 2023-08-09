<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPOChangeStatus" CodeFile="WPOChangeStatus.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Đổi trạng thái hợp đồng</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="center" colSpan="2">
						<asp:label id="lblMailTitle" runat="server" Width="100%" CssClass="lbPageTitle">Thay đổi trạng thái của đơn đặt</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="30%">
						<asp:label id="lblSetDate" runat="server"><U>N</U>gày thay đổi:</asp:label></TD>
					<TD>
						<asp:textbox id="txtSetDate" runat="server"></asp:textbox>
						<asp:hyperlink id="lnkSetDate" runat="server">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblStatus" runat="server"><U>T</U>rạng thái:</asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlStatus" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblNote" runat="server">Nội dung</asp:label></TD>
					<TD>
						<asp:textbox id="txtNote" runat="server" Width="200px"></asp:textbox>
						<asp:button id="btnUpdate" runat="server" Text="Thay đổi(u)" Width="91px"></asp:button></TD>
				</TR>
			</TABLE>
			<input id="hdPOID" type="hidden" value="0" name="hdPOID" runat="server"> 
			<input id="hdStatusID" type="hidden" value="0" name="hdStatusID" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0px">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
