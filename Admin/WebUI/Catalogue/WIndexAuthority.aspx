<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexAuthority" CodeFile="WIndexAuthority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexAuthority</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,0');">
		<form id="Form1" method="post" runat="server">
			<TABLE width="100%" cellpadding="4" cellspacing="1" bgcolor="#f3f3f3">
				<TR class="lbPageTitle">
					<TD align="left" colSpan="6">
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle">Từ chuẩn</asp:Label></TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD width="33%" colSpan="2">
						<asp:Label id="lblCapBib" runat="server" CssClass="lbGroupTitle">Biên mục</asp:Label></TD>
					<TD width="33%" colSpan="2">
						<asp:Label id="lblCapTranfer" runat="server" CssClass="lbGroupTitle">Trao đổi dữ liệu</asp:Label></TD>
					<TD width="34%" colSpan="2">
						<asp:Label id="lblCapTemplate" runat="server" CssClass="lbGroupTitle">Khung biên mục</asp:Label></TD>
				</TR>
				<TR class="lbFunctionTR">
					<TD align="center" colSpan="1" height="50" rowSpan="1">
						<asp:hyperlink id="imgSetDefault" runat="server" NavigateUrl="Catalogue/WMarcFieldsDefault.aspx">
							<img border="0" src="images/dat_gia_tri_ngam_dinh.gif">
						</asp:hyperlink>
					</TD>
					<TD height="50">
						<asp:HyperLink id="lnkSetDefaultValue" runat="server" NavigateUrl="Catalogue/WMarcFieldsDefault.aspx">Đặt giá trị ngầm định</asp:HyperLink><BR>
						<asp:label id="lblSetDefaultValue" runat="server" CssClass="lbFunctionDetail">Thiết đặt giá trị ngầm định cho các trường thuộc tính của tài liệu ấn phẩm cần biên mục trong phiên làm việc.</asp:label>
					</TD>
					<TD align="center" height="50">
						<asp:hyperlink id="imgExport" runat="server" NavigateUrl="Catalogue/WExportRecordToFileAuthority.aspx">
							<img border="0" src="images/xuat_khau_ban_ghi.gif">
						</asp:hyperlink>
					</TD>
					<TD height="50">
						<asp:HyperLink id="lnkExpData" runat="server" NavigateUrl="Catalogue/WExportRecordToFileAuthority.aspx">Xuất khẩu bản ghi</asp:HyperLink><BR>
						<asp:label id="lblExpData" runat="server" CssClass="lbFunctionDetail">Xuất khẩu bản ghi ra file.</asp:label>
					</TD>
					<TD align="center" height="50">
						<asp:hyperlink id="imgBibTemplate" runat="server" NavigateUrl="BibliographyTemplate/WIndexTemplateAuthority.aspx">
							<img border="0" src="images/mau_bien_muc.gif">
						</asp:hyperlink>
					</TD>
					<TD align="left" colSpan="1" height="50" rowSpan="1">
						<asp:HyperLink id="lnkBibTemplate" runat="server" NavigateUrl="BibliographyTemplate/WIndexTemplateAuthority.aspx">Mẫu biên mục/Trường biên mục</asp:HyperLink><BR>
						<asp:label id="Label1" runat="server" CssClass="lbFunctionDetail"> Tạo mới, sửa, gộp các mẫu biên mục.</asp:label>
					</TD>
				</TR>
				<TR class="lbFunctionTR">
					<TD align="center" height="50">
						<asp:hyperlink id="ImgCreateNew" runat="server" NavigateUrl="Catalogue/WMarcFormSelect.aspx">
							<img border="0" src="images/tao_moi.gif">
						</asp:hyperlink>
					</TD>
					<td colSpan="1" height="50" rowSpan="1">
						<asp:HyperLink id="lnkNew" runat="server" NavigateUrl="Catalogue/WMarcFormSelect.aspx">Tạo mới</asp:HyperLink>
						<BR>
						<asp:label id="lblNew" runat="server" CssClass="lbFunctionDetail">Biên mục từ đầu một tài liệu ấn phẩm.</asp:label>
					</td>
					<TD align="center" height="50">
						<asp:hyperlink id="imgImport" runat="server" NavigateUrl="Catalogue/WImportFromFile.aspx">
							<img border="0" src="images/nhap_khau_ban_ghi.gif">
						</asp:hyperlink>
					</TD>
					<td colSpan="1" height="50" rowSpan="1">
						<asp:HyperLink id="lnkImpFromFile" runat="server" NavigateUrl="Catalogue/WImportFromFile.aspx">Nhập khẩu bản ghi từ tệp</asp:HyperLink><BR>
						<asp:label id="lblImpFromFile" runat="server" CssClass="lbFunctionDetail">Nhập khẩu bản ghi biên mục từ nguồn bên ngoài (qua tệp ISO 2709).</asp:label><BR>
					</td>
					<TD align="center" colSpan="1" height="50" rowSpan="1"></TD>
					<td colSpan="1" height="50" rowSpan="1"><BR>
					</td>
				</TR>
				<tr class="lbFunctionTR">
					<td align="center" height="50">
						<asp:hyperlink id="imgModify" runat="server" NavigateUrl="Catalogue/WFindAuthorityID.aspx">
							<img border="0" src="images/sua_ban_ghi_bien_muc.gif">
						</asp:hyperlink>
					</td>
					<td colSpan="1" height="50" rowSpan="1" style="HEIGHT: 50px">
						<asp:HyperLink id="lnkUpdate" runat="server" NavigateUrl="Catalogue/WFindAuthorityID.aspx">Sửa bản ghi biên mục</asp:HyperLink><BR>
						<asp:label id="lblUpdate" runat="server" CssClass="lbFunctionDetail">Sửa chữa thuộc tính của các tài liệu ấn phẩm đã được biên mục trong cơ sở dữ liệu.</asp:label>
					</td>
					<td align="center" colSpan="1" height="50" rowSpan="1" style="HEIGHT: 50px"></td>
					<td colSpan="1" height="50" rowSpan="1" style="HEIGHT: 50px"><BR>
					</td>
					<td align="center" height="50" style="HEIGHT: 50px"></td>
					<td colSpan="1" height="50" rowSpan="1" style="HEIGHT: 50px"><BR>
					</td>
				</tr>
				<tr class="lbFunctionTR">
					<td colSpan="1" height="50" rowSpan="1" align="center">
						<asp:hyperlink id="imgViewItem" runat="server" NavigateUrl="javascript:location.href='WNothing.htm'; parent.Sentform.location.href='Catalogue/WControlBar.aspx'">
							<img border="0" src="images/xem.gif">
						</asp:hyperlink>
					</td>
					<td height="50">
						<asp:HyperLink id="lnkBrowse" runat="server" NavigateUrl="javascript:location.href='WNothing.htm'; parent.Sentform.location.href='Catalogue/WControlBar.aspx'">Xem</asp:HyperLink><BR>
						<asp:label id="lblBrowse" runat="server" CssClass="lbFunctionDetail">Liệt kê lần lượt các bản ghi theo thứ tự nhập vào cơ sở dữ liệu.</asp:label></td>
					<td height="50" align="center"></td>
					<td height="50"><br>
					</td>
					<td align="center" height="50"></td>
					<td colSpan="1" height="50" rowSpan="1"><br>
					</td>
				</tr>
			</TABLE>
			<asp:label id="lblLabel1" runat="server" Visible="False">Mã lỗi</asp:label>
			<asp:label id="lblLabel2" runat="server" Visible="False">Chi tiết lỗi</asp:label>
		</form>
	</body>
</HTML>
