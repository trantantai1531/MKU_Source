<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WStatYear" CodeFile="WStatYear.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatYear</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" onload="GenURLImg(9)">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colSpan="2"><asp:label id="lblPageTitle" CssClass="lbPageTitle main-head-form" Runat="server">Thống kê yêu cầu tài liệu điện tử</asp:label></TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblRequestAmount" CssClass="lbGroupTitle" Runat="server" ForeColor="#F0A30A" Width="100%">Đồ thị số lượng yêu cầu điện tử</asp:label></TD>
				</TR>
				<TR class="lbSubformTitle">
					<TD align="center"><asp:label id="lblTitleChartBarItem1" CssClass="lbSubformTitle" Runat="server" Width="100%" >Biểu đồ hình cột</asp:label></TD>
					<TD align="center"><asp:label id="lblTitleChartBarCopynumber1" CssClass="lbSubformTitle" Runat="server" Width="100%">Biểu đồ hình tròn</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG id="chart1" src="" useMap="#map1" border="0" name="chart1" runat="server"></TD>
					<TD align="center"><IMG id="chart2" src="" border="0" name="chart2" runat="server"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><br>
					</TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblRequestsAmount" CssClass="lbGroupTitle" Runat="server" Width="100%" ForeColor="#F0A30A">Đồ thị tổng giá trị các yêu cầu (VND).</asp:label></TD>
				</TR>
				<TR class="lbSubformTitle">
					<TD align="center"><asp:label id="lblTitleChartBarItem2" CssClass="lbSubformTitle" Runat="server" Width="100%" >Biểu đồ hình cột</asp:label></TD>
					<TD align="center"><asp:label id="lblTitleChartBarCopynumber2" CssClass="lbSubformTitle" Runat="server" Width="100%" >Biểu đồ hình tròn</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG id="chart3" src="" useMap="#map3" border="0" name="chart3" runat="server"></TD>
					<TD align="center"><IMG id="chart4" src="" border="0" name="chart4" runat="server"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><br>
					</TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblTitleStatus" CssClass="lbGroupTitle" Runat="server" Width="100%" ForeColor="#F0A30A">Đồ thị số lượng yêu cầu tài liệu điện tử theo từng trạng thái</asp:label></TD>
				</TR>
				<TR class="lbSubformTitle">
					<TD align="center"><asp:label id="Label2" CssClass="lbSubformTitle" Runat="server" Width="100%">Biểu đồ hình cột</asp:label></TD>
					<TD align="center"><asp:label id="Label3" CssClass="lbSubformTitle" Runat="server" Width="100%">Biểu đồ hình tròn</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG id="chart5" src="" useMap="#map5" border="0" name="chart5" runat="server"></TD>
					<TD align="center"><IMG id="chart6" src="" border="0" name="chart6" runat="server"></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False" Height="0">
				<asp:ListItem Value="0">Tỷ lệ % số lượng yêu cầu mua tài liệu điện tử giữa các năm</asp:ListItem>
				<asp:ListItem Value="1">Tỷ lệ % tổng giá trị mua tài liệu điện tử giữa các năm</asp:ListItem>
				<asp:ListItem Value="2">Tỷ lệ % giữa các trạng thái</asp:ListItem>
				<asp:ListItem Value="3">Số lượng</asp:ListItem>
				<asp:ListItem Value="4">Giá trị (đv: 1000 VND)</asp:ListItem>
				<asp:ListItem Value="5">Trạng thái</asp:ListItem>
				<asp:ListItem Value="6">Năm</asp:ListItem>
				<asp:ListItem Value="7">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="8">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="9">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="10">Thống kê yêu cầu tài liệu điện tử theo năm</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
