<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WAccountReport" CodeFile="WAccountReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Báo cáo thu chi</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR class="lbGridPager" align="center">
					<TD class="lbSubTitle" align="center"><asp:label id="lblReportTitle" runat="server">BÁO CÁO CÂN ĐỐI THU CHI</asp:label></TD>
				</TR>
				<TR class="lbGridPager" align="center">
					<TD class="lbSubTitle" align="center"><asp:label id="lblSubTitle" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR runat="server" id="TRFirstRemain" class="lbControlBar">
					<TD>
						<asp:Label Runat="server" ID="lblFirstRemain" CssClass="lbLabel">Số dư đầu kỳ: </asp:Label>
						<asp:Label Runat="server" ID="lblFirstRemainAmount" CssClass="lbAmount"></asp:Label>&nbsp;
						<asp:label id="lblSetCurRemain1" Runat="server" Font-Bold="True"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD><asp:table id="tblReport" Runat="server" CellPadding="1" CellSpacing="1"></asp:table></TD>
				</TR>
				<TR runat="server" id="TRLastRemain" class="lbControlBar">
					<TD align="right">
						<asp:label id="lblLastRemain" Runat="server" CssClass="lbLabel">Số dư cuối kỳ: </asp:label>
						<asp:label id="lblLastRemainAmount" Runat="server" CssClass="lbAmount"></asp:label>&nbsp;
						<asp:label id="lblSetCurRemain2" Runat="server" Font-Bold="True"></asp:label>
					</TD>
				</TR>
				<TR>
					<td>
						<asp:dropdownlist id="ddlLabel" Runat="server" Visible="False" Width="0" Height="0">
							<asp:ListItem Value="0">Quỹ:</asp:ListItem>
							<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="3">Ngày</asp:ListItem>
							<asp:ListItem Value="4">Diễn giải</asp:ListItem>
							<asp:ListItem Value="5">Thu</asp:ListItem>
							<asp:ListItem Value="6">Chi</asp:ListItem>
							<asp:ListItem Value="7">Tỉ giá hạch toán</asp:ListItem>
							<asp:ListItem Value="8">Số tiền</asp:ListItem>
							<asp:ListItem Value="9">Đơn vị TT</asp:ListItem>
							<asp:ListItem Value="10">Tỉ giá thực tế</asp:ListItem>
							<asp:ListItem Value="11">Số tiền chênh lệch với tỉ giá (VND)</asp:ListItem>
							<asp:ListItem Value="12">Tổng</asp:ListItem>
							<asp:ListItem Value="13">tháng</asp:ListItem>
							<asp:ListItem Value="14">năm</asp:ListItem>
						</asp:dropdownlist>
						<input type="hidden" runat="server" id="hidCurrency">
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
