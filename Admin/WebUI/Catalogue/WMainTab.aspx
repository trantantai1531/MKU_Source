<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMainTab" CodeFile="WMainTab.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMainTab</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="99" onclick="javascript:MenuChange();parent.Workform.location.href='WOverViewCatalogue.aspx';"><asp:Image ImageUrl="../Images/002_001_bienmuc.gif" runat="server" id="imgModule"></asp:Image></td>
					<td width="6" background="../Images/002_vach_01.gif"></td>
					<td width="6" id="menu1a" background="../Images/002_002.gif"></td>
					<td id="menu1" background="../Images/002_bg.gif" onmouseover="MenuHover(1)" onclick="MenuChange();Index_Click();MenuClick(1);"
						onmouseout="MenuOut(1);">
						<p align="center"><asp:hyperlink id="lnkIndex" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Thư mục
							</asp:hyperlink>
						</p>
					</td>					
					<td width="12" id="menu2a" background="../Images/002_003.gif"></td>
					<td id="menu2" background="../Images/002_bg.gif" onmouseover="MenuHover(2)" onclick="MenuChange();Dictionary_Click();MenuClick(2);"
						onmouseout="MenuOut(2);">
						<p align="center">
							<asp:hyperlink id="lnkDictionary" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Chỉ mục
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu3a" background="../Images/002_003.gif"></td>
					<td id="menu3" background="../Images/002_bg.gif" onmouseover="MenuHover(3);" onclick="MenuChange();IDX_Click();MenuClick(3);"
						onmouseout="MenuOut(3);">
						<p align="center">
							<asp:hyperlink id="lnkBib" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Danh mục
							</asp:hyperlink>
						</p>
					</td>
					<td width="6" id="menu4a" background="../Images/002_004.gif"></td>
					<td width="6"><img border="0" src="../Images/002_vach_01.gif" width="6" height="32"></td>
					<td width="6"><img border="0" src="../Images/002_005.gif" width="7" height="32"></td>
					<td width="31" onmouseover="this.style.backgroundImage='url(../Images/002_006_hover.gif)';"
						onmouseout="this.style.backgroundImage='url(../Images/002_006.gif)';" onclick="BackPage();"
						background="../Images/002_006.gif" height="32"></td>
					<td width="6"><img border="0" src="../Images/002_vach_02.gif" width="6" height="32"></td>
					<td width="31" onmouseover="this.style.backgroundImage='url(../Images/002_007_hover.gif)';"
						onmouseout="this.style.backgroundImage='url(../Images/002_007.gif)';" onclick="ForwardPage();"
						background="../Images/002_007.gif"></td>
					<td width="6"><img border="0" src="../Images/002_vach_02.gif" width="6" height="32"></td>
					<td width="100" background="../Images/002_bg_02.gif" style="display:none;">
						<asp:TextBox id="txtTotalItem" runat="server" CssClass="lbTextBox" Enabled="False" Width="80"></asp:TextBox>
					</td>
					<td><INPUT id="hidCount" type="hidden" name="hidCount" runat="server"> <INPUT id="hidPage" type="hidden" value="empt" name="hidPage" runat="server">
						<INPUT id="histCataForm" type="hidden" value="menuidx.aspx" name="hidCataForm" runat="server">
						<input type="hidden" id="hidClick" value="0"> <input type="hidden" id="hidMaxMenu" value="5">
					</td>
				</tr>
			</table>
			<asp:label id="lblLabel1" runat="server" Visible="False">Mã lỗi</asp:label><asp:label id="lblLabel2" runat="server" Visible="False">Chi tiết lỗi</asp:label></form>
	</body>
</HTML>
