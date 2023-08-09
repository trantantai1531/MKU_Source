<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WClassificationReference" CodeFile="WClassificationReference.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Từ điển dữ liệu phân loại</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="center">
						<asp:Label CssClass="main-group-form" id="lblMainTilte" runat="server">Từ điển dữ liệu phân loại (Classification)</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label CssClass="lbLabel" id="lblClassificationReference" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:ListBox id="lsbClassificationReference" runat="server" Width="224px" Height="200px"></asp:ListBox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button id="btnSelect" runat="server" Text="Chọn(s)" Width="67px"></asp:Button>&nbsp;
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" Width="67px"></asp:Button></TD>
				</TR>
			</TABLE>
			<input type="hidden" id="hidFrame" runat="server" name="hidFrame"> <input type="hidden" id="hidStoreFrame" runat="server" NAME="hidStoreFrame">
			<input type="hidden" id="hidKeyword" runat="server" NAME="hidKeyword"> <input type="hidden" id="hidTag" runat="server" NAME="hidTag">
			<input type="hidden" id="hidBib" runat="server" NAME="hidBib"> <input type="hidden" id="hidRepeatable" runat="server" NAME="hidRepeatable">
			<input type="hidden" id="hidClassificationID" runat="server" NAME="hidClassificationID"
				value="0">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chỉ số UDC</asp:ListItem>
				<asp:ListItem Value="3">Chỉ số DDC</asp:ListItem>
				<asp:ListItem Value="4">Chỉ số khác</asp:ListItem>
				<asp:ListItem Value="5">Chỉ số BBK</asp:ListItem>
				<asp:ListItem Value="6">Trường này không được sử dụng cho chỉ số phân loại nào!</asp:ListItem>
				<asp:ListItem Value="7">Không có mục từ thoả mãn điều kiện!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
