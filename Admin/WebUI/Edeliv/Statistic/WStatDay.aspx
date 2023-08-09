<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WStatDay" CodeFile="WStatDay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatDay</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
         <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="GenURLImg(9)">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colSpan="2"><asp:label id="lblPageTitle" Runat="server" CssClass="lbPageTitle  main-head-form">Thống kê yêu cầu tài liệu điện tử</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;&nbsp;
						<asp:label id="lblYear" runat="server" CssClass="lbLabel"><u>N</u>ăm</asp:label>&nbsp;
						<asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>&nbsp;<asp:label id="lblMonth" runat="server" CssClass="lbLabel"><u>T</u>háng</asp:label>&nbsp;
						<asp:dropdownlist id="ddlMonth" runat="server"></asp:dropdownlist>&nbsp;<asp:button id="btnDraw" runat="server" CssClass="lbButton" Width="88px" Text="Vẽ đồ thị (v)"></asp:button>&nbsp;<asp:button id="btnShowAll" runat="server" CssClass="lbButton" Width="136px" Text="Hiển thị toàn bộ (a)"></asp:button></TD>
				</TR>
				<TR Class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblRequestAmount" Runat="server" CssClass="lbGroupTitle" Width="100%" ForeColor="#F0A30A">Đồ thị số lượng yêu cầu điện tử</asp:label></TD>
				</TR>
				<TR Class="lbSubformTitle">
					<TD align="center"><asp:label id="lblTitleChartBarItem1" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình cột</asp:label></TD>
					<TD align="center"><asp:label id="lblTitleChartBarCopynumber1" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình tròn</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG src="" useMap="#map1" border="0" name="Image1" runat="server" id="image1"></TD>
					<TD align="center"><IMG src="" border="0" name="Image2" runat="server" id="image2"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><br>
					</TD>
				</TR>
				<TR Class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblRequestsAmount" Runat="server" CssClass="lbGroupTitle" Width="100%" ForeColor="#F0A30A">Đồ thị tổng giá trị các yêu cầu (VND).</asp:label></TD>
				</TR>
				<TR Class="lbSubformTitle">
					<TD align="center"><asp:label id="lblTitleChartBarItem2" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình cột</asp:label></TD>
					<TD align="center"><asp:label id="lblTitleChartBarCopynumber2" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình tròn</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG src="" useMap="#map3" border="0" name="Image3" runat="server" id="image3"></TD>
					<TD align="center"><IMG src="" border="0" name="Image4" runat="server" id="image4"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><br>
					</TD>
				</TR>
				<TR Class="lbGroupTitle">
					<TD colSpan="2"><asp:label id="lblTitleStatus" Runat="server" CssClass="lbGroupTitle" Width="100%" ForeColor="#F0A30A">Đồ thị số lượng yêu cầu tài liệu điện tử theo từng trạng thái</asp:label></TD>
				</TR>
				<TR Class="lbSubformTitle">
					<TD align="center"><asp:label id="Label2" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình cột</asp:label></TD>
					<TD align="center"><asp:label id="Label3" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình tròn</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG src="" useMap="#map5" border="0" name="Image5" runat="server" id="image5"></TD>
					<TD align="center"><IMG src="" border="0" name="Image6" runat="server" id="image6"></TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Tỷ lệ % số lượng yêu cầu mua giữa các ngày trong tháng</asp:ListItem>
				<asp:ListItem Value="1">Tỷ lệ % tổng giá trị mua tài liệu điện tử giữa các ngày trong tháng</asp:ListItem>
				<asp:ListItem Value="2">Tỷ lệ % giữa các trạng thái trong tháng </asp:ListItem>
				<asp:ListItem Value="3">Ngày</asp:ListItem>
				<asp:ListItem Value="4">Số lượng</asp:ListItem>
				<asp:ListItem Value="5">Giá trị (đv: 1000 VND)</asp:ListItem>
				<asp:ListItem Value="6"> Trạng thái</asp:ListItem>
				<asp:ListItem Value="7">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="8">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="9">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="10">Thống kê yêu cầu tài liệu điện tử theo ngày</asp:ListItem>
			</asp:DropDownList>
			<input id="hidMonth" type="hidden" runat="server" NAME="hidMonth"> <input id="hidYear" type="hidden" runat="server" NAME="hidYear">
		</form>
	</body>
</HTML>
