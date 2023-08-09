<%@ Page Language="vb" AutoEventWireup="false" EnableEventValidation="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPOTemplateP" CodeFile="WPOTemplateP.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xem trước mẫu đơn</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
         <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/media.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="RequestPreview" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%"><asp:label id="lblPageHeader" Runat="server" Width="100%"></asp:label></td>
				</tr>
				<tr>
					<td width="100%"><asp:label id="lblDisplay" Runat="server" Width="100%"></asp:label></td>
				</tr>
				<tr>
					<td width="100%"><asp:label id="lblPageFooter" Runat="server" Width="100%"></asp:label></td>
				</tr>
				<tr class="lbControlBar">
					<td align="center" width="100%">
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="78px"></asp:Button></td>
				</tr>
			</table>
			<!-- Common --><input id="hdTemplateType" type="hidden" value="9" name="hdTemplateType" runat="server">
			<!-- Request Template -->
			<asp:DropDownList ID="ddlCollumTitle" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="<$SEQUENCY$>">Số thứ tự</asp:ListItem>
				<asp:ListItem Value="<$TITLE$>">Nhan đề</asp:ListItem>
				<asp:ListItem Value="<$AUTHOR$>">Tác giả</asp:ListItem>
				<asp:ListItem Value="<$EDITION$>">Lần xuất bản</asp:ListItem>
				<asp:ListItem Value="<$PUBLISHER$>">Nhà xuất bản</asp:ListItem>
				<asp:ListItem Value="<$YEAR$>">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="<$ISBN$>">ISBN</asp:ListItem>
				<asp:ListItem Value="<$ISSN$>">ISSN</asp:ListItem>
				<asp:ListItem Value="<$LANGUAGE$>">Ngôn ngữ</asp:ListItem>
				<asp:ListItem Value="<$COUNTRY$>">Nước xuất bản</asp:ListItem>
				<asp:ListItem Value="<$FREQCODE$>">Cấp định kỳ</asp:ListItem>
				<asp:ListItem Value="<$ISSUES$>">Số kỳ</asp:ListItem>
				<asp:ListItem Value="<$ISSUEPRICE$>">Giá lẻ</asp:ListItem>
				<asp:ListItem Value="<$SERIACODE$>">Mã số</asp:ListItem>
				<asp:ListItem Value="<$VALDSUBSCRIBEDDATE$>">Ngày yêu cầu</asp:ListItem>
				<asp:ListItem Value="<$EXPIRESUBSCRIBEDDATE$>">Ngày dừng yêu cầu</asp:ListItem>
				<asp:ListItem Value="<$DOCUMENTTYPE$>">Kiểu tài liệu</asp:ListItem>
				<asp:ListItem Value="<$MEDIUM$>">Vật mang tin</asp:ListItem>
				<asp:ListItem Value="<$UNITPRICE$>">Đơn giá</asp:ListItem>
				<asp:ListItem Value="<$CURRENCY$>">Đơn vị tiền tệ</asp:ListItem>
				<asp:ListItem Value="<$REQUESTEDCOPIES$>">Số lượng yêu cầu</asp:ListItem>
				<asp:ListItem Value="<$ACCEPTEDCOPIES$>">Số lượng duyệt</asp:ListItem>
				<asp:ListItem Value="<$RETRIEVEDCOPIES$>">Số nhận được</asp:ListItem>
				<asp:ListItem Value="<$ERRONEUOS$>">Số lượng sai lệch</asp:ListItem>
				<asp:ListItem Value="<$MONEY$>">Tổng số tiền</asp:ListItem>
				<asp:ListItem Value="<$REQUESTER$>">Người yêu cầu</asp:ListItem>
				<asp:ListItem Value="<$URGENCY$>">Cấp độ mật</asp:ListItem>
				<asp:ListItem Value="<$NOTE$>">Ghi chú</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlCollumData" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="<$SEQUENCY$>">10</asp:ListItem>
				<asp:ListItem Value="<$TITLE$>">Đồng hào có ma</asp:ListItem>
				<asp:ListItem Value="<$AUTHOR$>">Nguyễn Công Hoan</asp:ListItem>
				<asp:ListItem Value="<$EDITION$>">4 nd.</asp:ListItem>
				<asp:ListItem Value="<$PUBLISHER$>">Nhà xuất bản giáo dục</asp:ListItem>
				<asp:ListItem Value="<$YEAR$>">c2014</asp:ListItem>
				<asp:ListItem Value="<$ISBN$>">1235921</asp:ListItem>
				<asp:ListItem Value="<$ISSN$>">9564-98745</asp:ListItem>
				<asp:ListItem Value="<$LANGUAGE$>">vie</asp:ListItem>
				<asp:ListItem Value="<$COUNTRY$>">Việt Nam</asp:ListItem>
				<asp:ListItem Value="<$FREQCODE$>">w</asp:ListItem>
				<asp:ListItem Value="<$ISSUES$>">25</asp:ListItem>
				<asp:ListItem Value="<$ISSUEPRICE$>">79000</asp:ListItem>
				<asp:ListItem Value="<$SERIACODE$>">ATOZ-79</asp:ListItem>
				<asp:ListItem Value="<$VALDSUBSCRIBEDDATE$>">01/01/2014</asp:ListItem>
				<asp:ListItem Value="<$EXPIRESUBSCRIBEDDATE$>">01/01/2016</asp:ListItem>
				<asp:ListItem Value="<$DOCUMENTTYPE$>">SH</asp:ListItem>
				<asp:ListItem Value="<$MEDIUM$>">G</asp:ListItem>
				<asp:ListItem Value="<$UNITPRICE$>">79</asp:ListItem>
				<asp:ListItem Value="<$CURRENCY$>">USD</asp:ListItem>
				<asp:ListItem Value="<$REQUESTEDCOPIES$>">10</asp:ListItem>
				<asp:ListItem Value="<$ACCEPTEDCOPIES$>">10</asp:ListItem>
				<asp:ListItem Value="<$RETRIEVEDCOPIES$>">6</asp:ListItem>
				<asp:ListItem Value="<$ERRONEUOS$>">4</asp:ListItem>
				<asp:ListItem Value="<$MONEY$>">79</asp:ListItem>
				<asp:ListItem Value="<$REQUESTER$>">eMicLib</asp:ListItem>
				<asp:ListItem Value="<$URGENCY$>">1</asp:ListItem>
				<asp:ListItem Value="<$NOTE$>">Chuyển khoản</asp:ListItem>
				<asp:ListItem Value="<$AMOUNT$>">SLg</asp:ListItem>
				<asp:ListItem Value="<$AMOUNTMONEY$>">Tổng tiền</asp:ListItem>
				<asp:ListItem Value="<$STORE$>">Kho</asp:ListItem>
				<asp:ListItem Value="<$STOREA1$>">A1</asp:ListItem>
				<asp:ListItem Value="<$STOREA2$>">A2</asp:ListItem>
				<asp:ListItem Value="<$SLG$>">slg</asp:ListItem>
				<asp:ListItem Value="<$SUMCOUNT$>">Tổng số: </asp:ListItem>
				<asp:ListItem Value="<$10$>">10</asp:ListItem>
				<asp:ListItem Value="<$50$>">50</asp:ListItem>
				<asp:ListItem Value="<$3950$>">3950</asp:ListItem>
				<asp:ListItem Value="<$790$>">790</asp:ListItem>
				<asp:ListItem Value="<$5$>">5</asp:ListItem>
				<asp:ListItem Value="<$25$>">25</asp:ListItem>
				<asp:ListItem Value="<$395$>">395</asp:ListItem>
				<asp:ListItem Value="<$1975$>">1975</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlHeaderFooterData" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="TITLE">Đơn đặt ấn phẩm</asp:ListItem>
				<asp:ListItem Value="TITLE:UPPER">ĐƠN ĐẶT ẤN PHẨM</asp:ListItem>
				<asp:ListItem Value="TODAY">01/01/2014</asp:ListItem>
				<asp:ListItem Value="TODAY:DD">01</asp:ListItem>
				<asp:ListItem Value="TODAY:MM">01</asp:ListItem>
				<asp:ListItem Value="TODAY:YYYY">2014</asp:ListItem>
				<asp:ListItem Value="TODAY:HH">01</asp:ListItem>
				<asp:ListItem Value="TODAY:MI">10</asp:ListItem>
				<asp:ListItem Value="TODAY:SS">20</asp:ListItem>
				<asp:ListItem Value="NAME">Công ty cổ phần công nghệ DGSoft</asp:ListItem>
				<asp:ListItem Value="ADDRESS">138/7 Duy Tân, Phường 15</asp:ListItem>
				<asp:ListItem Value="EMAIL">info@dgsoft.vn</asp:ListItem>
				<asp:ListItem Value="TEL">04-5589970</asp:ListItem>
				<asp:ListItem Value="FAX">04-5589971</asp:ListItem>
				<asp:ListItem Value="CONTACTPERSON">Phan Hào Hiệp</asp:ListItem>
				<asp:ListItem Value="PROVINCE">Quận Phú Nhuận - Tp. Hồ Chí Minh</asp:ListItem>
				<asp:ListItem Value="COUNTRY">Việt Nam</asp:ListItem>
				<asp:ListItem Value="LIBAC">021369789</asp:ListItem>
				<asp:ListItem Value="BANKINGINFO">012547896</asp:ListItem>
				<asp:ListItem Value="X12EMAIL">info@dgsoft.vn</asp:ListItem>
				<asp:ListItem Value="X12ENABLE">phanhaohiep@dgsoft.vn</asp:ListItem>
				<asp:ListItem Value="SAN">123654</asp:ListItem>
				<asp:ListItem Value="LIBSAN">654123</asp:ListItem>
				<asp:ListItem Value="NOTE">hợp đồng đã ký</asp:ListItem>
				<asp:ListItem Value="CONTRACTCODE">ATOZ-012013</asp:ListItem>
				<asp:ListItem Value="CONTRACTNAME">Triển khai eMicLib tại các đơn vị</asp:ListItem>
				<asp:ListItem Value="CONTRACTVALIDDATE">01/01/2014</asp:ListItem>
				<asp:ListItem Value="CONTRACTEXPIREDDATE">01/01/2016</asp:ListItem>
				<asp:ListItem Value="SUM">25000</asp:ListItem>
				<asp:ListItem Value="CURRENCY">USD</asp:ListItem>
                <asp:ListItem Value="USERFULLNAME">Admin Systems</asp:ListItem>
			</asp:DropDownList>
			<!-- Post Template -->
			<!-- Complaint Template -->
			<!-- Separated Store Template --></form>
	</body>
</HTML>
