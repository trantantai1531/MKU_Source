<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatTop20" CodeFile="WStatTop20.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatTop20</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" language="javascript">
            window.addEventListener("load", function () {
                GenURLImg(9);
            }, false);

        </script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" bgColor="white" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
            <table id="StatisticAcqTop20TaskBar" border="0" width="100%">
				<tr>
					<td align="left">
                  
					    <h1 class="main-head-form">	<asp:Label ID="lblMain" Runat="server" CssClass="lbPageTitle" Width="100%">Thống kê TOP 20 theo tiêu chí đã chọn</asp:Label></h1>
					
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="lblTop20" Runat="server"><u>C</u>họn kiểu thống kê: </asp:Label>&nbsp;
						<asp:DropDownList ID="ddlTop20" Width="200px" Runat="server"></asp:DropDownList>&nbsp;
						<asp:Button ID="btnStatistic" Runat="server" Text="Thống kê(t)" Width="92px"></asp:Button>
                        <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(g)" Width="64px"></asp:Button>
					</td>
				</tr>
			</table>
			<table id="StatisticItemType" width="100%" align="center" border="0" runat="server" bgcolor="white">
				<tr>
					<td colSpan="2">
						<asp:label id="lblDAP" runat="server" CssClass="lbGroupTitle" Width="100%"></asp:label></td>
				</tr>
				<tr>
					<td width="50%" colspan="1">
						<IMG src="" border="0" name="chart1"></td>
					<td width="50%" colspan="1">
						<IMG src="" border="0" name="chart2"></td>
				</tr>
				<tr>
					<td colSpan="2">
						<asp:label id="lblBAP" runat="server" CssClass="lbGroupTitle" Width="100%"></asp:label></td>
				</tr>
				<tr>
					<td width="50%" colspan="1">
						<IMG src="" border="0" name="chart3"></td>
					<td width="50%" colspan="1">
						<IMG src="" border="0" name="chart4"></td>
				</tr>
			</table>
			<asp:Label ID="lblDAPTotal" Runat="server" Visible="False">Số lượng đầu ấn phẩm: </asp:Label>
			<asp:Label ID="lblBAPTotal" Runat="server" Visible="False">Số lượng bản ấn phẩm: </asp:Label>
			<asp:label id="lblTitle" Visible="False" Runat="server">Tỉ lệ  % thống kê theo thuộc tính </asp:label><asp:label id="lblVTitle" Visible="False" Runat="server">Số lượng </asp:label>
			<asp:Label ID="lblHTitle" Runat="server" Visible="False">Thuộc tính </asp:Label>
			<asp:Label ID="lblError" Runat="server" Visible="False">Bạn chưa chọn tiêu chí thống kê</asp:Label>
			<asp:label ID="lblNothing" Runat="server" Visible="False">Không tìm thấy dữ liệu thỏa mãn tiêu chí thống kê.</asp:label>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="MainLog">Thống kê TOP 20</asp:ListItem>
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
			<asp:Label ID="lblSelectStat" Runat="server" Visible="False">------Chọn tiêu chí thống kê-----</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
