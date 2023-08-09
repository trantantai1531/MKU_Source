<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRPackage" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WIRPackage.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>In nhãn đóng gói</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblPacket" width="100%" border="0" cellpadding="1" cellspacing="1">
				<tr Class="lbPageTitle">
					<td colspan="2" width="100%">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">In nhãn đóng gói</asp:Label></td>
				</tr>
				<tr>
					<td width="40%" align="right"><asp:Label ID="lblTemplate" Runat="server">Mẫu nhã<u>n</u>: </asp:Label></td>
					<td><asp:DropDownList ID="ddlTemplate" Runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td width="100%" colspan="2" align="center" bgcolor="#c0c0c0"><asp:Button ID="btnPrint" Runat="server" Text="In (n )"></asp:Button></td>
				</tr>
				<tr>
					<td width="100%" colspan="2" align="center"><asp:Label ID="lblDisplay" Runat="server" Width="100%" Visible="false"></asp:Label></td>
				</tr>
				<tr>
					<td width="100%" colspan="2" align="center" bgcolor="#c0c0c0"><asp:Button ID="btnClose" Runat="server" Text="Đóng(g)" Visible="False"></asp:Button></td>
				</tr>
			</table>
			<input type="hidden" id="hidILLID" runat="server" value="0"> <input type="hidden" runat="server" id="hdTemplateID" name="hdTemplateID" value="0">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
				<asp:ListItem Value="3">Yêu cầu này không có địa chỉ giao nhận vật lý.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
