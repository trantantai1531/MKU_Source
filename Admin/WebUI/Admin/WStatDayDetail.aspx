<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WStatDayDetail" CodeFile="WStatDayDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatDayDetail</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="GenURLImg(7)">
		<form id="Form2" method="post" runat="server">
			<table id="tblStat" width="100%" align="center" border="0" runat="server">
				<tr Class="lbPageTitle">
					<td colspan="2"><asp:label id="lblPageTitle" Runat="server" CssClass="lbPageTitle" Width="100%">Thống kê Log của phân hệ&nbsp;</asp:label></td>
				</tr>
				<tr>
					<td align="center" width="40%"><IMG id="Img1" src="" usemap="#map1" border="0" name="Image1" runat="server"></td>
					<td align="center"><IMG id="Img2" src="" border="0" name="Image2" runat="server"></td>
				</tr>
				<tr class="lbControlBar">
					<td colspan="2" align="center">
						<asp:button id="btnBack" Runat="server" Text="Quay lại(b)" CssClass="lbButton" Width="88px"></asp:button>&nbsp;
						<asp:button id="btnPrevDay" Runat="server" Text="Ngày trước(p)" CssClass="lbButton" Width="104px"></asp:button>&nbsp;
						<asp:button id="btnNextDay" Runat="server" Text="Ngày sau(n)" CssClass="lbButton" Width="94px"></asp:button></td>
				</tr>
			</table>
			<input type="hidden" id="hidDay" runat="server"> <input type="hidden" id="hidMonth" runat="server">
			<input type="hidden" id="hidYear" runat="server"> <input type="hidden" id="hidModuleID" runat="server">
			<input type="hidden" id="hidType" runat="server" value="0">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Thống kê Log của phân hệ&nbsp;</asp:ListItem>
				<asp:ListItem Value="3">Không có dữ liệu thoả mãn</asp:ListItem>
				<asp:ListItem Value="4">Chức năng</asp:ListItem>
				<asp:ListItem Value="5">Số lượng giao dịch</asp:ListItem>
				<asp:ListItem Value="6">Tỷ lệ số lượng giao dịch giữa các chức năng trong phân hệ</asp:ListItem>
				<asp:ListItem Value="7">&nbsp;ngày&nbsp;</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
