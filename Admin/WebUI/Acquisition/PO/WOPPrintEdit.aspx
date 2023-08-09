<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WOPPrintEdit" EnableViewStateMAC="False" EnableViewState="false" ValidateRequest="False" CodeFile="WOPPrintEdit.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="CustomControl" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WOPPrintEdit</title>
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
			<table cellpadding="0" cellspacing="0" width="100%">
				<tr 
                
                >
					<td>
						<b>
							<asp:Label ID="lblTitle" Runat="server" Width="100%" CssClass="main-head-form ">SOẠN THẢO ĐƠN ĐẶT</asp:Label></b>
					</td>
				</tr>
				<tr bgcolor="#ffffff">
					<td>
					</td>
				</tr>
			</table>
			<br>
			<table width="100%" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td align="center">
						<table width="100%" align="center" cellpadding="0" cellspacing="0">
							<tr>
								<td align="center">
									<!-- use this code to place the Editor on the page-->
									<CUSTOMCONTROL:RichTextEditor width="90%" height="400px" id="Editor" runat="server" RTEResourcesUrl="RTE_Resources/"
										StyleSheetUrl="Style/RTEStyleSheet.css" HideRemoveFormatting="true" HideAbout="True" HideEditWebPage="true"
										Text="" align="center"></CUSTOMCONTROL:RichTextEditor>
									<br>
									<!-- add a submit button-->
								</td>
							</tr>
						</table>
						<asp:Button cssclass="lbButton" id="btnPreview" runat="server" Text="Xem trước(x)"></asp:Button>&nbsp;
						<!--<asp:Button cssclass="lbButton" id="btnPrint" runat="server" Text="In (i)"></asp:Button>&nbsp;-->
						<asp:Button cssclass="lbButton" ID="btnClose" Runat="server" Text="Đóng (g)"></asp:Button>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
