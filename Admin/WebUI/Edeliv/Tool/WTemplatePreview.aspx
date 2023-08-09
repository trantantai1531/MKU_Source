<%@ Page Language="vb" AutoEventWireup="false"  EnableEventValidation="false"  Inherits="eMicLibAdmin.WebUI.Edeliv.WTemplatePreview" CodeFile="WTemplatePreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Emiclib - Template Preview</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td align="center" width="100%"><asp:label id="lblPageTitle" Runat="server" Width="100%" Visible="False" CssClass="lbPageTitle">Xem trước mẫu đóng gói vừa tạo</asp:label></td>
				</tr>
				<tr>
					<td align="center" width="100%"><asp:label id="lblOutMsg" Runat="server" Width="100%"></asp:label></td>
				</tr>
			</table>
			<asp:label id="lblClose" Runat="server" Visible="False">Ðóng(g)</asp:label><asp:dropdownlist id="ddlHeadRequestInfo1" Runat="server" Width="150px" Visible="False" CssClass="lbdropdrownlist">
				<asp:ListItem Value="NAME">Phan Hào Hiệp</asp:ListItem>
				<asp:ListItem Value="DELIVNAME">Công ty cổ phần công nghệ DGSoft</asp:ListItem>
				<asp:ListItem Value="DELIVXADDR">138/7 Duy Tân</asp:ListItem>
				<asp:ListItem Value="DELIVSTREET">Phường 15</asp:ListItem>
				<asp:ListItem Value="DELIVBOX">phanhaohiep@dgsoft.vn</asp:ListItem>
				<asp:ListItem Value="DELIVCITY">Tp. Hồ Chí Minh</asp:ListItem>
				<asp:ListItem Value="DELIVREGION">Khu vực phía bắc</asp:ListItem>
				<asp:ListItem Value="DELIVCOUNTRY">Việt nam</asp:ListItem>
				<asp:ListItem Value="DEBT">15000$</asp:ListItem>
				<asp:ListItem Value="CREATEDDATE">10/9/2014</asp:ListItem>
				<asp:ListItem Value="EXPIREDDATE">10/10/2014</asp:ListItem>
				<asp:ListItem Value="DD">10</asp:ListItem>
				<asp:ListItem Value="MM">10</asp:ListItem>
				<asp:ListItem Value="YYYY">2014</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlFootRequestInfo" Runat="server" Width="150px" Visible="False" CssClass="lbdropdrownlist">
				<asp:ListItem Value="NAME">Phan Hào Hiệp</asp:ListItem>
				<asp:ListItem Value="DELIVNAME">Công ty cổ phần công nghệ DGSoft</asp:ListItem>
				<asp:ListItem Value="DELIVXADDR">138/7 Duy Tân</asp:ListItem>
				<asp:ListItem Value="DELIVSTREET">Phường 15</asp:ListItem>
				<asp:ListItem Value="DELIVBOX">phanhaohiep@dgsoft.vn</asp:ListItem>
				<asp:ListItem Value="DELIVCITY">Tp. Hồ Chí Minh</asp:ListItem>
				<asp:ListItem Value="DELIVREGION">Khu vực phía bắc</asp:ListItem>
				<asp:ListItem Value="DELIVCOUNTRY">Việt nam</asp:ListItem>
				<asp:ListItem Value="DEBT">15000$</asp:ListItem>
				<asp:ListItem Value="CREATEDDATE">10/9/2014</asp:ListItem>
				<asp:ListItem Value="EXPIREDDATE">10/10/2014</asp:ListItem>
				<asp:ListItem Value="DD">10</asp:ListItem>
				<asp:ListItem Value="MM">10</asp:ListItem>
				<asp:ListItem Value="YYYY">2014</asp:ListItem>
			</asp:dropdownlist>
			<asp:dropdownlist id="ddlBodyInfo" Width="150px" Runat="server" CssClass="lbdropdrownlist" Visible="False">
				<asp:ListItem Value="NO">NO</asp:ListItem>
				<asp:ListItem Value="NOTE">Ghi chú</asp:ListItem>
				<asp:ListItem Value="FILESIZE">120</asp:ListItem>
				<asp:ListItem Value="PRICE">500</asp:ListItem>
				<asp:ListItem Value="CURRENCY">usd</asp:ListItem>
			</asp:dropdownlist>
			<asp:dropdownlist id="ddlColumnCaption" Width="150px" Runat="server" CssClass="lbdropdrownlist" Visible="False">
				<asp:ListItem Value="<$NO$>">STT</asp:ListItem>
				<asp:ListItem Value="<$NOTE$>">Mô tả tài liệu</asp:ListItem>
				<asp:ListItem Value="<$FILESIZE$>">Kích cỡ</asp:ListItem>
				<asp:ListItem Value="<$PRICE$>">Giá</asp:ListItem>
				<asp:ListItem Value="<$CURRENCY$>">đơn vị tiền tệ</asp:ListItem>
			</asp:dropdownlist>
			<asp:dropdownlist id="ddlTemplatePack" Runat="server" CssClass="lbdropdrownlist" Width="150px" Visible="False">
				<asp:ListItem VALUE="DELIVNAME">Công ty cổ phần công nghệ DGSoft</asp:ListItem>
				<asp:ListItem VALUE="DELIVXADDR">138/7 Duy Tân</asp:ListItem>
				<asp:ListItem VALUE="DELIVSTREET">Phường 15</asp:ListItem>
				<asp:ListItem VALUE="DELIVBOX">phanhaohiep@dgsoft.vn</asp:ListItem>
				<asp:ListItem VALUE="DELIVCITY">Tp. Hồ Chí Minh</asp:ListItem>
				<asp:ListItem VALUE="DELIVREGION">Khu vực phía bắc</asp:ListItem>
				<asp:ListItem VALUE="DELIVCOUNTRY">Việt Nam</asp:ListItem>
				<asp:ListItem VALUE="DELIVCODE">000108334</asp:ListItem>
				<asp:ListItem VALUE="CREATEDDATE">10/10/2014</asp:ListItem>
				<asp:ListItem VALUE="EXPIREDDATE">20/10/2014</asp:ListItem>
				<asp:ListItem VALUE="NAME">Phan Hào Hiệp</asp:ListItem>
				<asp:ListItem VALUE="DD">10</asp:ListItem>
				<asp:ListItem VALUE="MM">10</asp:ListItem>
				<asp:ListItem VALUE="YYYY">2014</asp:ListItem>
			</asp:dropdownlist>
			<asp:Label Runat="server" ID="lblLabel1" Visible="False">Bạn không được cấp quyền khai thác tính năng này</asp:Label>
			<asp:Label Runat="server" ID="lblLabel2" Visible="False">Mã lỗi</asp:Label>
			<asp:Label Runat="server" ID="lblLabel3" Visible="False">Chi tiết lỗi</asp:Label>
		</form>
	</body>
</HTML>
