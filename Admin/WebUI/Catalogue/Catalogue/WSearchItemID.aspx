<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WSearchItemID" CodeFile="WSearchItemID.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tìm bản ghi biên mục</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" onload="document.forms[0].txtTitle.focus()">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="1" cellspacing="1">
				<tr class="lbPageTitle">
					<td colSpan="2" align="center">
						<asp:Label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tìm kiếm biểu ghi biên mục</asp:Label></td>
				</tr>
				<tr>
					<td align="right" width="30%">
						<asp:label id="lblTitle" runat="server"><u>N</u>han đề chính:</asp:label></td>
					<td>
						<asp:textbox id="txtTitle" runat="server" Width="216px"></asp:textbox></td>
				</tr>
				<TR>
					<TD align="right">
						<asp:label id="lblCopyNumber" runat="server"><u>M</u>ã xếp giá:</asp:label></TD>
					<TD>
						<asp:textbox id="txtCopyNumber" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblAuthor" runat="server"><u>T</u>ác giả:</asp:label></TD>
					<TD>
						<asp:textbox id="txtAuthor" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblPublisher" runat="server">Nhà xuất <u>b</u>ản:</asp:label></TD>
					<TD>
						<asp:textbox id="txtPublisher" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblYear" runat="server">Năm <u>x</u>uất bản:</asp:label></TD>
					<TD><asp:textbox id="txtYear" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblISBN" runat="server"><u>I</u>SBN:</asp:label></TD>
					<TD><asp:textbox id="txtISBN" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblItemType" runat="server"><u>D</u>ạng tài liệu:</asp:label></TD>
					<TD><asp:DropDownList ID="ddlItemType" Runat="server"></asp:DropDownList></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center" colSpan="2">
						<asp:button id="btnSearch" runat="server" Text="Tìm(s)" Width="78px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="98px"></asp:button></TD>
				</TR>
			</table>
			<table width="100%" border="0" cellpadding="1" cellspacing="1">
				<TR>
					<TD align="center">
						<asp:Label id="lblCapResult" runat="server" Visible="False">Tìm thấy:</asp:Label>
						<asp:Label id="lblResult" runat="server" Visible="False" Font-Bold="True" ForeColor="Maroon"></asp:Label>
						<asp:Label id="lblCap" runat="server" Visible="False">bản ghi biên mục</asp:Label></TD>
				</TR>
				<tr>
					<td align="center">
						<asp:Table id="tblResult" runat="server" Width="100%" CellPadding="2" CellSpacing="1" BorderWidth="0"></asp:Table></td>
				</tr>
			</table>
			<input type="hidden" id="hidFieldCode" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="3">Chọn</asp:ListItem>
				<asp:ListItem Value="4">Thông tin biên mục</asp:ListItem>
				<asp:ListItem Value="5">Không có bản ghi nào thoả mãn điều kiện tìm kiếm!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
