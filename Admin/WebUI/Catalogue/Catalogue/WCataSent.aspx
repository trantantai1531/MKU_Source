<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataSent" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCataSent.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCataSent</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="OnLoad()"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD ><asp:button id="btnUpdate" runat="server" Width="70" Text="Nhập(u)"></asp:button>&nbsp;<asp:button id="btnPreview" runat="server" Width="63" Text="Xem(v)"></asp:button>&nbsp;<asp:button id="btnReset" runat="server" Width="56" Text="Huỷ(r)"></asp:button>&nbsp;<asp:button id="btnValidate" runat="server" Width="78" Text="Hợp lệ(m)"></asp:button>&nbsp;<asp:button id="btnAddFields" runat="server" Width="116" Text="Thêm trường(f)"></asp:button>&nbsp;<asp:button id="btnSpellCheck" runat="server" Width="98" Text="Chính tả(s)"></asp:button></TD>
					<TD align="right" ><asp:textbox id="txtTime" runat="server"></asp:textbox></TD>
				</TR>
			</TABLE>
		    <input id="txtUpdateNow" type="hidden" value="0" name="txtUpdateNow" runat="server"/>
		    <input id="txtFormID" type="hidden" name="txtFormID" runat="server"/> <input id="txtLeader" type="hidden" name="txtLeader" runat="server"/>
		    <input id="txtModule" type="hidden" name="txtModule" runat="server"/> <input id="txtAddedFieldCodes" type="hidden" name="txtAddedFieldCodes" runat="server"/>
		    <input id="txtModifiedFieldCodes" type="hidden" name="txtModifiedFieldCodes" runat="server"/>
		    <input id="txtFieldCodes" type="hidden" name="txtFieldCodes" runat="server"/> <input id="IsAuthority" type="hidden" value="0" name="IsAuthority" runat="server"/>
		    <input id="tag" type="hidden" name="tag" runat="server"/> <input id="total" type="hidden" name="total" runat="server"/>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Emiclib -- Xem trước dữ liệu bản ghi</asp:ListItem>
				<asp:ListItem Value="1">Xem trước bản ghi biên mục</asp:ListItem>
				<asp:ListItem Value="2">Đóng</asp:ListItem>
				<asp:ListItem Value="3">Bạn hãy kiểm tra giá trị của trường</asp:ListItem>
				<asp:ListItem Value="4">Bản ghi này không được cập nhật nếu trường này trống hoặc không hợp lệ</asp:ListItem>
				<asp:ListItem Value="5">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="7">Bạn có chắc chắn muốn hủy thông tin không? Nếu có click OK, nếu không click Cancel.</asp:ListItem>
			</asp:DropDownList>
			<!-- Table for show hidden fields//-->
			<asp:table id="tblHiddenFields" runat="server" Width="0px" Height="0px"></asp:table>
			<!-- Table for show javascript functions//-->
			<asp:label id="lblMyJS" runat="server" Width="0px"></asp:label></form>
	</body>
</HTML>
