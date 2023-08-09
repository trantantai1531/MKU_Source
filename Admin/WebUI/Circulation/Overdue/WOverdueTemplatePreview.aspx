<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WOverdueTemplatePreview" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WOverdueTemplatePreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thư thông báo mượn ấn phẩm quá hạn</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="PreView" width="100%" border="0">
				<tr>
					<td width="100%" align="center">
						<asp:Label ID="lblMainTitle" CssClass="main-group-form" Runat="server" Width="100%">Xem trước thư thông báo mượn ấn phẩm quá hạn</asp:Label></td>
				</tr>
				<tr>
					<td width="100%" align="center">
						<asp:Label ID="lblOutMsg" Runat="server"></asp:Label></td>
				</tr>
				<tr>
					<TD align="center" width="100%" >
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="72px"></asp:Button></TD>
				</tr>
			</table>
			<asp:Label id="lblCardNumber" Runat="server" Visible="False">Hoa007</asp:Label>
			<asp:Label id="lblName" Runat="server" Visible="False">Phạm Thị Hoa</asp:Label>
			<asp:Label id="lblDOB" Runat="server" Visible="False">1/1/2000</asp:Label>
			<asp:Label id="lblOcupation" Runat="server" Visible="False">Cán bộ</asp:Label>
			<asp:Label id="lblWorkPlace" Runat="server" Visible="False">Công ty cổ phần công nghệ DGSoft</asp:Label>
			<asp:Label id="lblWorkAddress" Runat="server" Visible="False">Phường 15</asp:Label>
			<asp:Label id="lblHomeAddress" Runat="server" Visible="False">Phường 15</asp:Label>
			<asp:Label id="lblPhone" Runat="server" Visible="False">7664943</asp:Label>
			<asp:Label id="lblGrade" Runat="server" Visible="False">Cử nhân</asp:Label>
			<asp:Label id="lblFaculity" Runat="server" Visible="False">Khoa Thông tin thư viện</asp:Label>
			<asp:Label id="lblCardValidDate" Runat="server" Visible="False">1/1/2000</asp:Label>
			<asp:Label id="lblCardExpiredDate" Runat="server" Visible="False">1/3/2000</asp:Label>
			<asp:Label id="lblEmail" Runat="server" Visible="False">hoapt@dgsoft.vn</asp:Label>
			<asp:Label id="lblItemCodeData" Runat="server" Visible="False">TVL020454243</asp:Label>
			<asp:Label id="lblCopyNumberData" Runat="server" Visible="False">KC774393</asp:Label>
			<asp:Label id="lblItemTitleData" Runat="server" Visible="False">
                Fifty years of television :a guide to series and pilots, 1937-1988</asp:Label>
			<asp:Label id="lblCheckOutDateData" Runat="server" Visible="False">1/1/2000</asp:Label>
			<asp:Label id="lblCheckInDateData" Runat="server" Visible="False">1/2/2000</asp:Label>
			<asp:Label id="lblOverdueDateData" Runat="server" Visible="False">1</asp:Label>
			<asp:Label id="lblPenatiData" Runat="server" Visible="False">20.000</asp:Label>
			<asp:Label id="lblSequencyData" Runat="server" Visible="False">1</asp:Label>
            <asp:Label ID="lblLoanCountData" runat="server" Visible="false">3</asp:Label>
            <asp:Label id="lblSequency" Runat="server" Visible="False">Số thứ tự</asp:Label>
			<asp:Label id="lblCopyNumber" Runat="server" Visible="False">Mã xếp giá</asp:Label>
			<asp:Label id="lblItemCode" Runat="server" Visible="False">Mã tài liệu</asp:Label>
			<asp:Label id="lblItemTitle" Runat="server" Visible="False">Nhan đề</asp:Label>
			<asp:Label id="lblCheckOutDate" Runat="server" Visible="False">Ngày mượn</asp:Label>
			<asp:Label id="lblCheckInDate" Runat="server" Visible="False">Ngày trả</asp:Label>
			<asp:Label id="lblOverdueDate" Runat="server" Visible="False">Số ngày quá hạn</asp:Label>
			<asp:Label id="lblPenati" Runat="server" Visible="False">Tiền phạt</asp:Label>
			<asp:Label id="lblLibrary" Runat="server" Visible="False">Thư viện</asp:Label>
			<asp:Label id="lblStore" Runat="server" Visible="False">Kho</asp:Label>
            <asp:Label id="lblNote" Runat="server" Visible="False">Ghi chú</asp:Label>
			<asp:Label id="lblOverdueLibrary" Runat="server" Visible="False">DHVL</asp:Label>
			<asp:Label id="lblOverdueStore" Runat="server" Visible="False">Kho A</asp:Label>
            <asp:Label id="lblNoteData" Runat="server" Visible="False">Thông tin ghi chú</asp:Label>
            <asp:Label ID="lblLoanCount" runat="server" Visible="false">Số lượng</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
