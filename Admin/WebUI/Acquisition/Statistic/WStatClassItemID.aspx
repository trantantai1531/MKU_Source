<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatClassItemID" CodeFile="WStatClassItemID.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatClassItemID</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" bgColor="white" leftMargin="0" topMargin="0" OnLoad="GenAcqURL(7)"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="StatClassItemID" width="100%" align="center" border="0" runat="server">
				<tr>
					<td><IMG src="" useMap="#map1" border="0" name="anh1"></td>
					<td><IMG src="" border="0" name="anh2"></td>
				</tr>
			</table>
			<input id="hdTimeFrom" type="hidden" name="hdTimeFrom" runat="server"> <input id="hdTimeTo" type="hidden" name="hdTimeTo" runat="server">
			<input id="hdItemType" type="hidden" value="0" name="hdItemType" runat="server">
			<asp:Label ID="lblVTitle" Runat="server" Visible="False">Số lượng bản ấn phẩm</asp:Label>
			<asp:Label ID="lblHTitle" Runat="server" Visible="False">Chỉ số </asp:Label>
			<asp:Label ID="lblTitle" Runat="server" Visible="False">Tỉ lệ % số lượng bản ấn phẩm theo chỉ số </asp:Label><asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="MainLog">Thống kê bản ấn phẩm theo chỉ số phân loại </asp:ListItem>
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
