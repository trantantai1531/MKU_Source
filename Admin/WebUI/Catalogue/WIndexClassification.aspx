<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexClassification" CodeFile="WIndexClassification.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexClassification</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" cellpadding="2" cellspacing="1" bgcolor="#f3f3f3">
				<TR class="lbPageTitle">
					<TD colspan="2">
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle">Phân loại</asp:Label></TD>
				</TR>
				<TR>
					<TD class="lbGroupTitle" colspan="2">
						<asp:Label id="lblCapTranfer" runat="server" CssClass="lbGroupTitle">Trao đổi dữ liệu</asp:Label></TD>
				</TR>
				<TR class="lbFunctionTR" height="50" width="50">
					<TD vAlign="middle" align="center" width="50">
						<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="Catalogue/WExportClassification.aspx">
							<img border="0" src="images/xuat_khau_ban_ghi.gif">
						</asp:hyperlink>
					</TD>
					<td>
						<asp:HyperLink id="Hyperlink2" runat="server" NavigateUrl="Catalogue/WExportClassification.aspx">Xuất khẩu bản ghi</asp:HyperLink>
						<BR>
						<asp:label id="Label1" runat="server" CssClass="lbFunctionDetail">Xuất khẩu bản ghi ra file.</asp:label>
					</td>
				</TR>
				<TR class="lbFunctionTR" height="50" width="50">
					<td vAlign="middle" align="center" width="50"><asp:hyperlink id="imgImport" runat="server" NavigateUrl="Catalogue/WImportClassification.aspx">
							<img border="0" src="images/nhap_khau_ban_ghi.gif">
						</asp:hyperlink>
					</td>
					<td>
						<asp:HyperLink id="lnkImpFromFile" runat="server" NavigateUrl="Catalogue/WImportClassification.aspx">Nhập khẩu bản ghi từ tệp</asp:HyperLink>
						<BR>
						<asp:label id="lblImpFromFile" runat="server" CssClass="lbFunctionDetail">Nhập khẩu bản ghi biên mục từ nguồn bên ngoài (qua tệp ISO 2709).</asp:label>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
