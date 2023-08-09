<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexCatalogue" CodeFile="WIndexCatalogue.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexCatalogue</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD><asp:HyperLink CssClass="lbLinkFunction" id="lnkSetDefaultValue" runat="server">Đặt giá trị ngầm định</asp:HyperLink></TD>
					<TD><asp:HyperLink CssClass="lbLinkFunction" id="lnkNew" runat="server">Tạo mới</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px"><asp:label id="lblSetDefaultValue" runat="server" CssClass="lbLabel">Bạn có thể đặt các giá trị ngầm định cho việc biên mục tài liệu</asp:label></TD>
					<TD style="HEIGHT: 21px"><asp:label id="lblNew" runat="server" CssClass="lbLabel">Biên mục mới tài liệu</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:HyperLink CssClass="lbLinkFunction" id="lnkCatalogue" runat="server">Biên mục chi tiết</asp:HyperLink></TD>
					<TD><asp:HyperLink CssClass="lbLinkFunction" id="lnkUpdate" runat="server">Sửa bản ghi biên mục</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblCatalogue" runat="server" CssClass="lbLabel">Biên mục chi tiết cho những bản ghi đã được biên mục sơ lược</asp:label></TD>
					<TD><asp:label id="lblUpdate" runat="server" CssClass="lbLabel">Sửa bản ghi biên mục</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px"><asp:HyperLink CssClass="lbLinkFunction" id="lnkExpData" runat="server">Xuất khẩu dữ liệu</asp:HyperLink></TD>
					<TD style="HEIGHT: 16px"><asp:HyperLink CssClass="lbLinkFunction" id="lnkDelete" runat="server">Xoá</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblExpData" runat="server" CssClass="lbLabel">Xuất khẩu dữ liệu</asp:label></TD>
					<TD><asp:label id="lblDelete" runat="server" CssClass="lbLabel">Xoá bản ghi biên mục</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:HyperLink CssClass="lbLinkFunction" id="lnkImpFromFile" runat="server">Nhập khẩu từ tệp</asp:HyperLink></TD>
					<TD><asp:HyperLink CssClass="lbLinkFunction" id="lnkBrowse" runat="server">Xem</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblImpFromFile" runat="server" CssClass="lbLabel">Nhập khẩu bản ghi từ tệp</asp:label></TD>
					<TD><asp:label id="lblBrowse" runat="server" CssClass="lbLabel">Duyệt xem các bản ghi</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:HyperLink CssClass="lbLinkFunction" id="lnkImpFromZ3950" runat="server">Nhập khẩu qua Z39.50</asp:HyperLink></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblImpFromZ3950" runat="server" CssClass="lbLabel">Nhập khẩu các bản ghi qua Z39.50</asp:label></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
