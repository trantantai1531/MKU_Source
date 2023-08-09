<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WAcqReportTemlatePreview" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WAcqReportTemlatePreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WAcqReportTemlatePreview</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="RequestPreview" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="center" width="100%"><asp:label id="lblMainTitle" CssClass="lbPageTitle" Width="100%" Runat="server"> Xem mẫu in báo cáo bổ sung</asp:label></td>
				</tr>
				<tr>
					<td width="100%"><asp:label id="lblPageHeader" Width="100%" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="left" width="100%"><asp:label id="lblDisplay" Width="100%" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="100%"><asp:label id="lblPageFooter" Width="100%" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="btnClose" Runat="server" Text="Đóng(g)"></asp:button></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlCollumsData" Runat="server" Visible="False">
				<asp:ListItem Value="<$SEQUENCY$>">Số thứ tự</asp:ListItem>
				<asp:ListItem Value="<$DKCB$>">KM 0001/2005</asp:ListItem>
				<asp:ListItem Value="<$TITLE$>">Truyện Kiều toàn tập- Nguyễn Du</asp:ListItem>
				<asp:ListItem Value="<$PLACE$>">NXB Giáo Dục</asp:ListItem>
				<asp:ListItem Value="<$YEAR$>">2005</asp:ListItem>
				<asp:ListItem Value="<$ISSUEPRICE$>">80000VND</asp:ListItem>
				<asp:ListItem Value="<$ACQUISITIONDATE$>">01/01/2005</asp:ListItem>
				<asp:ListItem Value="<$NOTE$>">Có kèm tặng phẩm</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlCollumsTitle" Runat="server" Visible="False">
				<asp:ListItem Value="<$SEQUENCY$>">Số thứ tự</asp:ListItem>
				<asp:ListItem Value="<$DKCB$>">Đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="<$TITLE$>">Nhan đề</asp:ListItem>
				<asp:ListItem Value="<$PLACE$>">Nơi xuất bản</asp:ListItem>
				<asp:ListItem Value="<$YEAR$>">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="<$ISSUEPRICE$>">Đơn giá</asp:ListItem>
				<asp:ListItem Value="<$ACQUISITIONDATE$>">Ngày bổ sung</asp:ListItem>
				<asp:ListItem Value="<$NOTE$>">Ghi chú</asp:ListItem>
			</asp:dropdownlist>
			<asp:DropDownList ID="ddlHeaderFooter" Runat="server" Visible="False">
				<asp:ListItem Value="TODAY">01/01/2005</asp:ListItem>
				<asp:ListItem Value="TODAY:DD">01</asp:ListItem>
				<asp:ListItem Value="TODAY:MM">01</asp:ListItem>
				<asp:ListItem Value="TODAY:YYYY">2005</asp:ListItem>
				<asp:ListItem Value="TODAY:HH">20</asp:ListItem>
				<asp:ListItem Value="TODAY:MI">20</asp:ListItem>
				<asp:ListItem Value="TODAY:SS">20</asp:ListItem>
				<asp:ListItem Value="LIB">GREENHOUSE</asp:ListItem>
				<asp:ListItem Value="INV">KM</asp:ListItem>
				<asp:ListItem Value="TITLE">Truyện Kiều toàn tập- Nguyễn Du</asp:ListItem>
				<asp:ListItem Value="TITLE:UPPER">TRUYỆN KIỀU TOÀN TẬP- NGUYỄN DU</asp:ListItem>
			</asp:DropDownList></form>
	</body>
</HTML>
