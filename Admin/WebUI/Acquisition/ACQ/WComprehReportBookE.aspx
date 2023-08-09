<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WComprehReportBookE" CodeFile="WComprehReportBookE.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="CustomControl" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>WComprehReportBookE</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" width="100%">
				<tr 
                >
					<td>
						<b>
							<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">SOẠN THẢO SỔ BÁO CÁO TỔNG QUÁT</asp:Label></b>
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
			<asp:dropdownlist id="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="Permission">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Báo cáo tổng quát.</asp:ListItem>
			</asp:dropdownlist>
			<asp:Label ID="lblSendEmailSuccessful" Runat="server" Visible="False">Đã gửi thư tới địa chỉ cần thiết</asp:Label>
			<asp:Label ID="lblSendMailUnSuccessful" Runat="server" Visible="False">Qúa trình gửi thư có lỗi</asp:Label>
		</form>
	</body>
</HTML>
