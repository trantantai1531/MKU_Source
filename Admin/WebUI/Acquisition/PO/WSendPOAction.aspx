<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOAction" ValidateRequest="false" CodeFile="WSendPOAction.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="CustomControl" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSendPOAction</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" width="100%">
				<tr >
					<td>
						<b>
							<asp:Label ID="lblTitle" Runat="server" Width="100%" CssClass="lbPageTitle">SOẠN THẢO ĐƠN ĐẶT</asp:Label></b>
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
							Text="" align="center" Visible="false"></CUSTOMCONTROL:RichTextEditor>
					</td>
				</tr>
				<tr>
					<td width="100%" align="center"><asp:Button ID="btnPreview" Runat="server" Text="Xem thử(x)"></asp:Button>&nbsp;<asp:Button ID="btnEmail" Runat="server" Text="Gửi thư(g)"></asp:Button>&nbsp;<asp:Button ID="btnPrint" Runat="server" Text="In (n)"></asp:Button></td>
				</tr>
			</table>
			<asp:Label ID="lblSendEmailSuccessful" Runat="server" Visible="False">Đã gửi thư tới các nhà cung cấp tương ứng</asp:Label>
			<asp:Label ID="lblSendEmailUnSuccessful" Runat="server" Visible="False">Trong quá trình gửi thư có xuất hiện lỗi</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False">
				<asp:ListItem Value="0">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="2">Gửi đơn đặt</asp:ListItem>
				<asp:ListItem Value="3">Địa chỉ Email không được rỗng !</asp:ListItem>
				<asp:ListItem Value="4">Địa chỉ email không hợp lệ !</asp:ListItem>
			</asp:DropDownList>
		    <input id="hidAction" runat="server" type="hidden"/>
			<script language="javascript">
				if (document.forms[0].hidAction.value=='PRINT') {
					Encryption();
					Preview('Print');
					Decryption();
				}
				if (document.forms[0].hidAction.value=='EMAIL') {
					if (eval(parent.workform))
						parent.workform.location.href = "WContractDetail.aspx?Pos=" + parseFloat(parent.taskbar.document.forms[0].txtCurrentID.value);				
					else
						window.location.href = "WSendPOSearch.aspx";
					}

			</script>
		</form>
	</body>
</HTML>
