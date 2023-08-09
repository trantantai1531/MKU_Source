<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCatawork" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WCatawork.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCatawork</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="5" leftmargin="5">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="0">
				<TR>
					<TD colspan="2" class="lbPageTitle"><asp:label id="lblHeader" Runat="server" CssClass="lbPageTitle">Bổ sung và biên mục sơ lược</asp:label></TD>
				</TR>
				<tr>
					<td align="right" width="30%"><asp:label id="lblCapLeader" Runat="server" Font-Bold="True">Chỉ dẫn đầu biểu ghi:</asp:label></td>
					<td align="left"><asp:label id="lblLeader" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblCapCodeBook" Runat="server" Font-Bold="True" Width="104px">Mã tài liệu:</asp:label></td>
					<td align="left"><asp:label id="lblCodeBook" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblCapISBN" Runat="server" Font-Bold="True" Width="112px">Số định danh:</asp:label></td>
					<td align="left"><asp:label id="lblISBN" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblCapTitle" Runat="server" Font-Bold="True" Width="80px">Nhan đề:</asp:label></td>
					<td align="left"><asp:label id="lblTitle" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblCapPub" Runat="server" Font-Bold="True" Width="80px">Xuất bản:</asp:label></td>
					<td align="left"><asp:label id="lblPub" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblCapQuantity" Runat="server" Font-Bold="True" Width="144px">Đặc trưng số lượng</asp:label></td>
					<td align="left"><asp:label id="lblQuantity" Runat="server"></asp:label></td>
				</tr>
				<TR>
					<TD colSpan="2"><asp:label id="lblNote" Runat="server" Font-Size="Smaller" Width="424px" Height="24px">Để biên mục chi tiết cho ấn phẩm này, hãy sử dụng phiên hệ Biên mục.</asp:label></TD>
				</TR>
				<TR Class="lbControlBar">
					<TD colSpan="2">
						<asp:button id="btnBack" runat="server" Text="Biên mục ấn phẩm khác(c)" Width="180px"></asp:button>&nbsp;
						<asp:button id="btnConUpdate" runat="server" Text="Tiếp tục cập nhật dữ liệu xếp giá(u)" Width="240px"></asp:button></TD>
				</TR>
				<tr>
					<td colSpan="2">&nbsp; <INPUT type="hidden" size="1" name="txtBooksID" id="txtBooksID" runat="server">&nbsp;
						<INPUT type="hidden" size="1" name="txtPOID" id="txtPOID" runat="server">&nbsp; <INPUT id="txtCode" type="hidden" size="1" name="txtBooksID" runat="server">&nbsp;<INPUT id="txtCodePO" type="hidden" size="1" name="txtPOID" runat="server">&nbsp;&nbsp;
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Tạo mới biểu ghi biên mục có mã tài liệu: </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
