<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibOPAC.WebUI.OPAC.OLibrary" Codebehind="OLibrary.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Trường Đại Học Cửu Long</title>
	</head>
	<body  style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0">
		<form id="Form1" method="post" runat="server">
        <table border="0" width="100%" cellspacing="0" cellpadding="0" style="background-color:#25A0DA;height:20px;">
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
			<table border="0" width="100%" cellspacing="2" cellpadding="2">
				<tr>
					<td  style="text-align:left;width:120px;"><img src="images/Imgviet/blueLogo.png" border="0"></td>
					<td style="text-align:left;" colspan="2">
                        <asp:Label id="lblWelcome" CssClass="lbSubTitle" runat="server">Chào mừng đến với thư viện điện tử - thư viện số eMicLib</asp:Label>
                    </td>
                    <td style="text-align:right;">
                            <asp:Label ID="lblLanguage" runat="server">Ngôn ngữ:</asp:Label>
                            <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True">
				                <asp:ListItem Value="vie">Tiếng Việt</asp:ListItem>
				                <asp:ListItem Value="eng">Tiếng Anh</asp:ListItem>
			                </asp:DropDownList>
			        </td>
                </tr>       
                <tr style="height:10px;">
                    <td colspan="3">&nbsp;</td>
                </tr>        
			</table>
            <table border="0" cellspacing="0" cellpadding="0" style="text-align:center;width:100%;">
                <tr>
                    <td style="text-align:center;width:10%;"></td>
                    <td style="text-align:center;width:80%;">
                        <asp:Table ID="tbLibrary"  runat="server" CellPadding="3" CellSpacing="0" Width="100%" border="1" bordercolor="#25A0DA" ></asp:Table>
                    </td>
                    <td style="text-align:center;width:10%;"></td>
                </tr>
                 <tr style="height:20px;">
                    <td colspan="3">&nbsp;</td>
                </tr>
            </table>
            <table border="0" width="100%" cellspacing="0" cellpadding="0" style="background-color:#25A0DA;">
				<tr>
					<td  style="text-align:center;width:100%;height:20px;">
					    <asp:Label id="lblFooter" runat="server" CssClass="lbLabelHeader"><strong>DGSoft Technologies JSC © eMicLib 2014. All Rights Reserved</strong></asp:Label>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
