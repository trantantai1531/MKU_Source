<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatClassCopyNumber" CodeFile="WStatClassCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatClassCopyNumber</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" language="javascript">
            window.addEventListener("load", function () {
                GenURLImg(9);
            }, false);

        </script>
	</HEAD>
	<body bottomMargin="0" bgColor="white" leftMargin="0" topMargin="0" onload="GenAcqURL(7)"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="StatClassCopyNumber" width="100%" align="center" border="0" height="100%" runat="server" bgcolor="white">
				<tr>
					<td bgcolor="#f0f3f4">
						<IMG src="" useMap="#map1" border="0" name="anh1"></td>
					<td>
						<IMG src="" border="0" name="anh2"></td>
				</tr>
			</table>
			<input id="hdTimeFrom" type="hidden" name="hdTimeFrom" runat="server"> 
			<input id="hdTimeTo" type="hidden" name="hdTimeTo" runat="server">
			<input id="hdItemType" type="hidden" value="0" name="hdItemType" runat="server">
			<asp:Label ID="lblVTitle" Runat="server" Visible="False">Số lượng đầu ấn phẩm</asp:Label>
			<asp:Label ID="lblHTitle" Runat="server" Visible="False">Chỉ số </asp:Label>
			<asp:Label ID="lblTitle" Runat="server" Visible="False">Tỉ lệ % số lượng đầu ấn phẩm theo chỉ số </asp:Label>

			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Thống kê đầu ấn phẩm theo chỉ số phân loại</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi</asp:ListItem>
				<asp:ListItem Value=""></asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
