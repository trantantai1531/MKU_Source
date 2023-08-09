<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatTop20Taskbar" CodeFile="WStatTop20Taskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatTop20Taskbar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
         <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgcolor="white" topmargin="0" leftmargin="0" rightmargin="0"
		bottommargin="0">
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
			<asp:Label ID="lblSelectStat" Runat="server" Visible="False">------Chọn tiêu chí thống kê-----</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
