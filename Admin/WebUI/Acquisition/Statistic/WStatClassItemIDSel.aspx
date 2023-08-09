<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatClassItemIDSel" CodeFile="WStatClassItemIDSel.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatClassItemIDSel</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" language="javascript">
            window.addEventListener("load", function () {
                GenURLImg(9);
            }, false);

    </script>
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="StatisticAcqDAP" border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr Class="lbPageTitle">
					<td align="left">
						<asp:Label ID="lblMain" Runat="server" CssClass="main-head-form" width="100%">Thống kê chỉ số phân loại bản ấn phẩm</asp:Label></td>
				</tr>
				<tr>
					<td width="60%" align="center">
						<table id="StatisticAcqDAPSub" width="100%" border="0" cellpadding="2" cellspacing="0">
							<tr>
								<td align="right">
									<asp:Label ID="lblTimeFrom" Runat="server"><u>T</u>ừ:</asp:Label></td>
								<td colspan="2">
									<asp:textbox CssClass="text-input" ID="txtTimeFrom" Runat="server" Width="100"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfTimeFrom" Runat="server">Lịch</asp:HyperLink></td>
							</tr>
							<tr>
								<td align="right">
									<asp:Label ID="lblTimeTo" Runat="server">Tớ<u>i</u>:</asp:Label></td>
								<td colspan="2">
									<asp:textbox CssClass="text-input" ID="txtTimeTo" Runat="server" Width="100"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfTimeTo" Runat="server">Lịch</asp:HyperLink></td>
							</tr>
							<tr>
								<td align="right">
									<asp:Label ID="lblItemType" Runat="server"><U>D</U>ạng tài liệu:</asp:Label></td>
								<td colspan="2">
									<asp:DropDownList ID="ddlItemType" Runat="server"></asp:DropDownList></td>
							</tr>
							<tr class="lbControlBar">
								<td colspan="1"></td>
								<td colspan="2">
									<asp:Button ID="btnStatistic" Runat="server" Text="Thống kê(s)" Width="98px"></asp:Button>
                                    <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
									<asp:Button ID="btnReset" Runat="server" Text="Làm lại(r)" Width="90px"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">--------- Chọn toàn bộ ---------</asp:ListItem>
				<asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language = javascript>
			document.forms[0].txtTimeFrom.focus();
		</script>
	</body>
</HTML>
