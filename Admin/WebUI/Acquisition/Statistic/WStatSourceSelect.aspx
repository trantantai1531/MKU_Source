<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatSourceSelect" CodeFile="WStatSourceSelect.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatSourceSelect</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td align="center">
						<asp:label id="lblMain" Runat="server" CssClass="lbPageTitle" width="100%">Thống kê theo nguồn bổ sung</asp:label></td>
				</tr>
				<tr>
					<td align="center">
						<asp:label id="lblFromDate" Runat="server"><U>T</U>ừ ngày:</asp:label>
						<asp:textbox id="txtFromDate" Runat="server" Width="80px"></asp:textbox>
						<asp:hyperlink id="hrfFromDate" Runat="server">Lịch</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblToDate" Runat="server">Tớ<u>i</u> ngày:</asp:label>
						<asp:textbox id="txtToDate" Runat="server" Width="80px"></asp:textbox>
						<asp:hyperlink id="hrfToDate" Runat="server">Lịch</asp:hyperlink>&nbsp;&nbsp;
						<asp:button id="btnStatistic" Runat="server" Text="Thống kê(s)" Width="98px"></asp:button>
					</td>
				</tr>
			</table>
			<asp:Label ID="lblErrorMsg" Runat="server" Visible="False">Khuôn dạng ngày tháng không hợp lệ</asp:Label>
		</form>
		
		<script language = javascript>
			document.forms[0].txtFromDate.focus();
		</script>
	</body>
</HTML>
