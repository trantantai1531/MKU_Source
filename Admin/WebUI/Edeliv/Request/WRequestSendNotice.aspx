<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestSendNotice" CodeFile="WRequestSendNotice.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gửi thư nhắc trả tiền</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="1" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr class="lbPagetitle">
					<td align="center" width="100%" colSpan="2">
						<asp:label id="lblTitleTemplate" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center" width="100%" colSpan="2">
						<asp:label id="lblContents" Runat="server" Visible="False"></asp:label></td>
				</tr>
				<tr>
					<TD vAlign="top" colSpan="2"><asp:label id="lblFormat" Runat="server"><U>K</U>huôn dạng: </asp:label><asp:dropdownlist id="ddlFormatName" Runat="server" Width="300px"></asp:dropdownlist></TD>
				</tr>
				<tr class="lbControlBar">
					<td width="30%"></td>
					<td><asp:button id="btnPrintLetter" Runat="server" Text="In thư(p)" Width="78px"></asp:button>&nbsp;<asp:button id="btnSendEmail" Runat="server" Text="Gửi thư(s)" Width="90px"></asp:button>
					</td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlHerderColumn" Runat="server" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="NAME">Hoàng văn Tuấn</asp:ListItem>
				<asp:ListItem Value="DELIVNAME">Công ty Greenhouse</asp:ListItem>
				<asp:ListItem Value="DELIVXADDR">Nam Kỳ Khởi Nghĩa</asp:ListItem>
				<asp:ListItem Value="DELIVSTREET">Quận 3</asp:ListItem>
				<asp:ListItem Value="DELIVBOX">info@greenhouse.com</asp:ListItem>
				<asp:ListItem Value="DELIVCITY">TPHCM</asp:ListItem>
				<asp:ListItem Value="DELIVREGION">Khu vực phía nam</asp:ListItem>
				<asp:ListItem Value="DELIVCOUNTRY">Việt nam</asp:ListItem>
				<asp:ListItem Value="DEBT">15000$</asp:ListItem>
				<asp:ListItem Value="CREATEDDATE">Mô tả tài liệu đặt mua</asp:ListItem>
				<asp:ListItem Value="EXPIREDDATE">10/10/2004</asp:ListItem>
				<asp:ListItem Value="DD">10</asp:ListItem>
				<asp:ListItem Value="MM">10</asp:ListItem>
				<asp:ListItem Value="YYYY">2004</asp:ListItem>
				<asp:ListItem Value="NO">NO</asp:ListItem>
				<asp:ListItem Value="NOTE">Ghi chú</asp:ListItem>
				<asp:ListItem Value="FILESIZE">120</asp:ListItem>
				<asp:ListItem Value="PRICE">500</asp:ListItem>
				<asp:ListItem Value="CURRENCY">usd</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlFooterColumn" Runat="server" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="NAME">Hoàng văn Tuấn</asp:ListItem>
				<asp:ListItem Value="DELIVNAME">Công ty Greenhouse</asp:ListItem>
				<asp:ListItem Value="DELIVXADDR">Nam Kỳ Khởi Nghĩa</asp:ListItem>
				<asp:ListItem Value="DELIVSTREET">Quận 3</asp:ListItem>
				<asp:ListItem Value="DELIVBOX">info@greenhouse.com</asp:ListItem>
				<asp:ListItem Value="DELIVCITY">TPHCM</asp:ListItem>
				<asp:ListItem Value="DELIVREGION">Khu vực phía nam</asp:ListItem>
				<asp:ListItem Value="DELIVCOUNTRY">Việt nam</asp:ListItem>
				<asp:ListItem Value="DEBT">15000$</asp:ListItem>
				<asp:ListItem Value="CREATEDDATE">Mô tả tài liệu đặt mua</asp:ListItem>
				<asp:ListItem Value="EXPIREDDATE">10/10/2004</asp:ListItem>
				<asp:ListItem Value="DD">10</asp:ListItem>
				<asp:ListItem Value="MM">10</asp:ListItem>
				<asp:ListItem Value="YYYY">2004</asp:ListItem>
				<asp:ListItem Value="NO">NO</asp:ListItem>
				<asp:ListItem Value="NOTE">Ghi chú</asp:ListItem>
				<asp:ListItem Value="FILESIZE">120</asp:ListItem>
				<asp:ListItem Value="PRICE">500</asp:ListItem>
				<asp:ListItem Value="CURRENCY">usd</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlBodyColumn" Runat="server" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="NAME">Hoàng văn Tuấn</asp:ListItem>
				<asp:ListItem Value="DELIVNAME">Công ty Greenhouse</asp:ListItem>
				<asp:ListItem Value="DELIVXADDR">Nam Kỳ Khởi Nghĩa</asp:ListItem>
				<asp:ListItem Value="DELIVSTREET">Quận 3</asp:ListItem>
				<asp:ListItem Value="DELIVBOX">info@greenhouse.com</asp:ListItem>
				<asp:ListItem Value="DELIVCITY">TPHCM</asp:ListItem>
				<asp:ListItem Value="DELIVREGION">Khu vực phía nam</asp:ListItem>
				<asp:ListItem Value="DELIVCOUNTRY">Việt nam</asp:ListItem>
				<asp:ListItem Value="DEBT">15000$</asp:ListItem>
				<asp:ListItem Value="CREATEDDATE">Mô tả tài liệu đặt mua</asp:ListItem>
				<asp:ListItem Value="EXPIREDDATE">10/10/2004</asp:ListItem>
				<asp:ListItem Value="DD">10</asp:ListItem>
				<asp:ListItem Value="MM">10</asp:ListItem>
				<asp:ListItem Value="YYYY">2004</asp:ListItem>
				<asp:ListItem Value="NO">NO</asp:ListItem>
				<asp:ListItem Value="NOTE">Ghi chú</asp:ListItem>
				<asp:ListItem Value="FILESIZE">120</asp:ListItem>
				<asp:ListItem Value="PRICE">500</asp:ListItem>
				<asp:ListItem Value="CURRENCY">usd</asp:ListItem>
			</asp:dropdownlist>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Thư nhắc trả tiền</asp:ListItem>
				<asp:ListItem Value="1">Thư đã được gửi</asp:ListItem>
				<asp:ListItem Value="2">Quá trình gửi thư bị lỗi</asp:ListItem>
				<asp:ListItem Value="3">Chọn mẫu</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="5">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="7">Bạn chưa chọn mẫu.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
