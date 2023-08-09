<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQMenu" CodeFile="WACQMenu.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WACQMenu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="menu" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="90" onclick="javascript:MenuChange();parent.mainacq.location.href='WAcqQuickView.aspx';"><asp:Image ImageUrl="../Images/bo_sung.gif" runat="server" id="imgModule"></asp:Image></td>
					<td width="6" background="../Images/002_vach_01.gif"></td>
					<td style="display:none;" width="6" id="menu1a" background="../Images/002_002.gif"></td>
					<td style="display:none;" id="menu1" background="../Images/002_bg.gif" onmouseover="MenuHover(1)" onclick="MenuChange();IndexPO_Click();MenuClick(1);"
						onmouseout="MenuOut(1);">
						<p align="center">
							<asp:hyperlink id="lnkIndexPO" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">			
								Đơn đặt
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu2a" background="../Images/002_003.gif"></td>
					<td id="menu2" background="../Images/002_bg.gif" onmouseover="MenuHover(2)" onclick="MenuChange();IndexACQ_Click();MenuClick(2);"
						onmouseout="MenuOut(2);">
						<p align="center">
							<asp:hyperlink id="lnkIndexACQ" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Bổ sung
							</asp:hyperlink>
						</p>
					</td>
					<td style="display:none;" width="12" id="menu3a" background="../Images/002_003.gif"></td>
					<td style="display:none;" id="menu3" background="../Images/002_bg.gif" onmouseover="MenuHover(3)" onclick="MenuChange();IndexAccounting_Click();MenuClick(3);"
						onmouseout="MenuOut(3);">
						<p align="center">
							<asp:hyperlink id="lnkIndexAccounting" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Kế toán
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu4a" background="../Images/002_003.gif"></td>
					<td id="menu4" background="../Images/002_bg.gif" onmouseover="MenuHover(4)" onclick="MenuChange();IndexStore_Click();MenuClick(4);"
						onmouseout="MenuOut(4);">
						<p align="center">
							<asp:hyperlink id="lnkIndexStore" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Kho
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu5a" background="../Images/002_003.gif"></td>
					<td id="menu5" background="../Images/002_bg.gif" onmouseover="MenuHover(5)" onclick="MenuChange();IndexStat_Click();MenuClick(5);"
						onmouseout="MenuOut(5);">
						<p align="center">
							<asp:hyperlink id="lnkIndexStat" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Thống kê
							</asp:hyperlink>
						</p>
					</td>
					<td width="6" id="menu6a" background="../Images/002_004.gif"></td>
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
					<td>
						<input type="hidden" id="hidClick" value="0"> <input type="hidden" id="hidMaxMenu" value="5">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
