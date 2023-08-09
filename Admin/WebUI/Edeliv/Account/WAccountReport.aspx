<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WAccountReport" CodeFile="WAccountReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WAccountReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR class="lbGridPager" align="center">
					<TD class="lbSubTitle" align="center"><asp:label id="lblReportTitle" runat="server">BÁO CÁO CÂN ĐỐI CÁC KHOẢN THU VÀ PHẢI THU</asp:label></TD>
				</TR>
				<TR class="lbGridPager" align="center">
					<TD class="lbSubTitle" align="center"><asp:label id="lblSubTitle" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:table id="tblReport" Runat="server" CellPadding="1" CellSpacing="1"></asp:table></TD>
				</TR>
				<TR>
					<TD class="lbSubTitle" align="right">
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Tháng</asp:ListItem>
							<asp:ListItem Value="1">tháng</asp:ListItem>
							<asp:ListItem Value="2">Năm</asp:ListItem>
							<asp:ListItem Value="3">năm</asp:ListItem>
							<asp:ListItem Value="4">Số dư</asp:ListItem>
							<asp:ListItem Value="5">Tổng</asp:ListItem>
							<asp:ListItem Value="6">Ngày</asp:ListItem>
							<asp:ListItem Value="7">Diễn giải</asp:ListItem>
							<asp:ListItem Value="8">Thu</asp:ListItem>
							<asp:ListItem Value="9">Phải thu</asp:ListItem>
							<asp:ListItem Value="10">Tỉ giá hạch toán</asp:ListItem>
							<asp:ListItem Value="11">Số tiền</asp:ListItem>
							<asp:ListItem Value="12">Đơn vị TT</asp:ListItem>
							<asp:ListItem Value="13">Tỉ giá thực tế</asp:ListItem>
							<asp:ListItem Value="14">Số tiền chênh lệch với tỉ giá (VND)</asp:ListItem>
							<asp:ListItem Value="15">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="16">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="17">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="18">Mã tài khoản:</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
