<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WZFind" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WZFind.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WZFind</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%">
				<tr class="lbGridPager">
					<td><asp:label id="lblNext" Visible="False" Runat="server">Xem 10 biểu ghi tiếp: </asp:label><asp:textbox id="txtNext" Width="56px" Visible="False" Runat="server">1</asp:textbox><asp:button id="btnNext" Visible="False" Runat="server" Text="Xem >>"></asp:button></td>
				</tr>
				<tr>
					<td><asp:table id="tblResult" runat="server" Width="100%"></asp:table></td>
				</tr>
				<tr class="lbGridHeader">
					<td align="center"><asp:label id="NotFound" Visible="False" Runat="server">Không tìm thấy bản ghi nào thoả mãn điều kiện</asp:label></td>
				</tr>
				<tr class="lbPageTitle">
					<td align="center"><asp:button id="btnClose" Runat="server" Text="Đóng (c)"></asp:button><asp:label id="lblTitle" Visible="False" Runat="server">Kết quả tìm kiếm</asp:label><asp:label id="lblFound" Visible="False" Runat="server">tìm thấy</asp:label><asp:label id="lblUnitRec" Visible="False" Runat="server">Biểu ghi</asp:label><asp:label id="lblSelect" Visible="False" Runat="server">Kích vào đây để lấy về thông tin bản ghi biên mục cần chọn!</asp:label></td>
				</tr>
				<TR>
					<TD align="center"><asp:label id="lblAuthor" Visible="False" Runat="server">Tác giả</asp:label><asp:label id="lblTitles" Visible="False" Runat="server">Nhan đề</asp:label><asp:label id="lblPublisher" Visible="False" Runat="server">Xuất bản</asp:label><asp:label id="Label2" Visible="False" Runat="server">Xuất bản</asp:label><asp:label id="lblOthers" Visible="False" Runat="server">Thông tin khác</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<INPUT id="txtHidPlaceOfPub" type="hidden" runat="server" name="txtHidPlaceOfPub">
						<INPUT id="txtHidSponsoringBody" type="hidden" runat="server" name="txtHidSponsoringBody">
						<INPUT type="hidden" id="txtItemCode" size="8" name="txtItemCode" runat="server">
						<INPUT type="hidden" runat="server" id="txtHidTitle" name="txtHidTitle"> <INPUT type="hidden" runat="server" id="txtHidAuthor" name="txtHidAuthor">
						<INPUT type="hidden" runat="server" id="txtHidISBN" name="txtHidISBN"> <INPUT type="hidden" runat="server" id="txtHidISSN" name="txtHidISSN">
						<INPUT type="hidden" runat="server" id="txtHidPublisher" name="txtHidPublisher">
						<INPUT type="hidden" runat="server" id="txtHidPublishYear" name="txtHidPublishYear">
						<INPUT type="hidden" runat="server" id="txtHidPublishOrder" name="txtHidPublishOrder">
						<asp:Label id="lblJS" runat="server"></asp:Label>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
