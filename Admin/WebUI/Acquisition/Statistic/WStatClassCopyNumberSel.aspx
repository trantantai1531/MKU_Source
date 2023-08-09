<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatClassCopyNumberSel" CodeFile="WStatClassCopyNumberSel.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatClassCopyNumberSel</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="StatisticAcqDAP" border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td align="left">
						<asp:Label ID="lblMain" Runat="server" CssClass="main-head-form" width="100%">Thống kê chỉ số phân loại đầu ấn phẩm</asp:Label></td>
				</tr>
				<tr>
					<td>
						<table id="StatisticAcqDAPSub" width="100%" border="0" cellpadding="2" cellspacing="0">
							<tr>
								<td align="right" width="35%">
									<asp:Label ID="lblTimeFrom" Runat="server"><u>T</u>ừ: </asp:Label></td>
								<td colspan="2">
									<asp:TextBox ID="txtTimeFrom" CssClass="text-input" Runat="server"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfTimeFrom" Runat="server">Lịch</asp:HyperLink></td>
							</tr>
							<tr>
								<td align="right">
									<asp:Label ID="lblTimeTo" Runat="server">Tớ<u>i</u>: </asp:Label></td>
								<td colspan="2">
									<asp:TextBox ID="txtTimeTo" CssClass="text-input" Runat="server"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfTimeTo" Runat="server">Lịch</asp:HyperLink></td>
							</tr>
							<tr>
								<td align="right">
									<asp:Label ID="lblItemType" Runat="server"><U>D</U>ạng tài liệu: </asp:Label></td>
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
				<asp:ListItem Value="2">------- Chọn toàn bộ-------</asp:ListItem>
				<asp:ListItem Value="3">Kiểu ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language = javascript>
			document.forms[0].txtTimeFrom.focus();
		</script>
		
	</body>
</HTML>
