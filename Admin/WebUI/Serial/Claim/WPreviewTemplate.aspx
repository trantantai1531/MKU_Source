<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WPreviewTemplate" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WPreviewTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPreviewTemplate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblPreview" width="100%" border="0">
				<tr>
					<td align="center"><asp:label id="lblMainTitle" CssClass="main-group-form" Width="100%" Runat="server">Xem thử mẫu đơn khiếu nại</asp:label></td>
				</tr>
				<tr>
					<td ><asp:label id="lblOutMsg" Width="100%" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<th align="center">
						<asp:button id="btnClose" Runat="server" Text="Đóng(g)"></asp:button></th>
				</tr>
			</table>
			<asp:DropDownList ID="ddlHeaderFooter" Runat="server" Visible="False">
				<asp:ListItem Value="TODAY">1/3/2005</asp:ListItem>
				<asp:ListItem Value="TODAY:DD">1</asp:ListItem>
				<asp:ListItem Value="TODAY:MM">3</asp:ListItem>
				<asp:ListItem Value="TODAY:YYYY">2005</asp:ListItem>
				<asp:ListItem Value="TODAY:YY">05</asp:ListItem>
				<asp:ListItem Value="TODAY:HH">4</asp:ListItem>
				<asp:ListItem Value="TODAY:MI">20</asp:ListItem>
				<asp:ListItem Value="TODAY:SS">30</asp:ListItem>
				<asp:ListItem Value="PUBLISHER">Nhà xuất bản Giáo Dục</asp:ListItem>
				<asp:ListItem Value="ADDRESS">72 Trần Hưng Đạo</asp:ListItem>
				<asp:ListItem Value="TELEPHONE">(84)(04)2369855</asp:ListItem>
				<asp:ListItem Value="FAX">(84)(04)2369856</asp:ListItem>
				<asp:ListItem Value="EMAIL">infor@publisher.com</asp:ListItem>
				<asp:ListItem Value="CONTACTPERSON">Đặng Phi Sơn</asp:ListItem>
				<asp:ListItem Value="PROVINCE">Hà nội</asp:ListItem>
				<asp:ListItem Value="POCODE">ERP-00001</asp:ListItem>
				<asp:ListItem Value="PONAME">Đơn đặt tạp chí định kỳ</asp:ListItem>
				<asp:ListItem Value="VALIDDATE">1/1/2005</asp:ListItem>
				<asp:ListItem Value="EXPIREDDATE">1/1/2006</asp:ListItem>
				<asp:ListItem Value="MONEYTOTAL">50.000</asp:ListItem>
				<asp:ListItem Value="CURRENCY">VNĐ</asp:ListItem>
				<asp:ListItem Value="ITEMNAME">PCWorld A</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlCollum" Runat="server" Visible="False">
				<asp:ListItem Value="<$NUMBER$>">Số</asp:ListItem>
				<asp:ListItem Value="<$TOTALNUMBER$>">Số toàn cục</asp:ListItem>
				<asp:ListItem Value="<$ISSUEDATE$>">Ngày phát hành</asp:ListItem>
				<asp:ListItem Value="<$LESSAMOUNT$>">Số lượng thiếu</asp:ListItem>
				<asp:ListItem Value="<$PRICE$>">Đơn giá</asp:ListItem>
				<asp:ListItem Value="<$SPECIALTITLE$>">Tên số đặc biệt</asp:ListItem>
				<asp:ListItem Value="<$SPECIALISSUE$>">Kiểu số</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlData" Runat="server" Visible="False">
				<asp:ListItem Value="<$NUMBER$>">01</asp:ListItem>
				<asp:ListItem Value="<$TOTALNUMBER$>">256</asp:ListItem>
				<asp:ListItem Value="<$ISSUEDATE$>">1/5/2005</asp:ListItem>
				<asp:ListItem Value="<$LESSAMOUNT$>">5</asp:ListItem>
				<asp:ListItem Value="<$PRICE$>">20.000</asp:ListItem>
				<asp:ListItem Value="<$SPECIALTITLE$>">Bản tặng</asp:ListItem>
				<asp:ListItem Value="<$SPECIALISSUE$>">23</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False">
				<asp:ListItem Value="0">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi: </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
