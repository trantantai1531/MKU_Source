<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOClaimAction" EnableViewStateMAC="False" EnableViewState="false" ValidateRequest="False" CodeFile="WSendPOClaimAction.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="CustomControl" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSendPOClaimAction</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" width="100%">
				<tr class="lbPageTitle">
					<td>
						<asp:Label ID="lblTitle" Runat="server" CssClass="lbPageTitle">SOẠN THẢO ĐƠN KHIẾU NẠI</asp:Label>
					</td>
				</tr>
				<tr>
					<td width="100%" align="center"><asp:Label ID="lblEmailAddress" Runat="server">Đị<u>a</u> chỉ thư: </asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtEmailAddress" Runat="server"></asp:TextBox></td>
				</tr>
				<tr bgcolor="#ffffff">
					<td align="center">
						<!-- use this code to place the Editor on the page-->
						<CUSTOMCONTROL:RichTextEditor width="90%" height="400px" id="Editor" runat="server" RTEResourcesUrl="RTE_Resources/"
							StyleSheetUrl="Style/RTEStyleSheet.css" HideRemoveFormatting="true" HideAbout="True" HideEditWebPage="true"
							Text="" align="center" Visible="true"></CUSTOMCONTROL:RichTextEditor>
					</td>
				</tr>
				<tr>
					<td width="100%" align="center"><asp:Button ID="btnPreview" Runat="server" Text="Xem thử(x)"></asp:Button>&nbsp;<asp:Button ID="btnEmail" Runat="server" Text="Gửi thư(g)"></asp:Button>&nbsp;<asp:Button ID="btnPrint" Runat="server" Text="In (n)"></asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Đã gửi thư tới các nhà cung cấp tương ứng</asp:ListItem>
				<asp:ListItem Value="3">Trong quá trình gửi thư có xuất hiện lỗi</asp:ListItem>
				<asp:ListItem Value="4">Đơn khiếu nại ấn phẩm</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
