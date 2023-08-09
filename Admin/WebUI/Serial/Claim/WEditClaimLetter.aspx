<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WEditClaimLetter" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WEditClaimLetter.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="CustomControl" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WEditClaimLetter</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
          <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td align="center">
						<table width="90%">
							<tr>
								<td width="100%" align="center"><asp:Label ID="lblEmailAddress" Runat="server" CssClass="lbLabel">Địa chỉ Email: </asp:Label><asp:TextBox ID="txtEmailAddress" Width="300px" Runat="server" CssClass="lbTextbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator id="revliAddressEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
										ErrorMessage="<-- Địa chỉ Email chưa đúng định dạng!!!" ControlToValidate="txtEmailAddress"></asp:RegularExpressionValidator></td>
							</tr>
							<tr>
								<td align="center">
									<!-- use this code to place the Editor on the page-->
									<CUSTOMCONTROL:RichTextEditor width="700" height="400" id="Editor" runat="server" RTEResourcesUrl="RTE_Resources/"
										StyleSheetUrl="Style/RTEStyleSheet.css" HideRemoveFormatting="true" HideAbout="True" HideEditWebPage="true"
										Text=""></CUSTOMCONTROL:RichTextEditor>
									<br>
									<!-- add a submit button-->
								</td>
							</tr>
						</table>
						&nbsp;
						<asp:Button id="btnPreview" runat="server" Text="Xem trước(x)" CssClass="lbButton"></asp:Button>&nbsp;
						<asp:Button id="btnPrint" runat="server" Text="In thư(i)" CssClass="lbButton"></asp:Button>&nbsp;
						<asp:Button id="btnSendEmail" runat="server" Text="Gửi thư(g)" CssClass="lbButton"></asp:Button>
					</td>
				</tr>
			</table>
			<asp:Label ID="lblEmailTitle" Runat="server" Visible="False">Thư khiếu nại ấn phẩm định kỳ</asp:Label>
			<asp:Label ID="lblEmailAddressEmty" Runat="server" Visible="False">Chưa nhập địa chỉ Email</asp:Label>
			<asp:Label ID="lblSendEmailSuccessful" Runat="server" Visible="False">Gửi thư thành công</asp:Label>
			<asp:Label ID="lblSendEmailUnSuccessful" Runat="server" Visible="False">Gửi thư không thành công</asp:Label>
			<asp:Label ID="lblErrorCode" Runat="server" Visible="False">Mã lỗi</asp:Label>
			<asp:Label ID="lblErrorMsg" Runat="server" Visible="False">Chi tiết lỗi</asp:Label>
			<asp:Label ID="lblMailError" Runat="server" Visible="False">Địa chỉ mail không hợp lệ</asp:Label>
		</form>
	</body>
</HTML>
