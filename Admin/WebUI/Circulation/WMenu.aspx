<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WMenu" CodeFile="WMenu.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMenu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%" cellspacing="0" cellpadding="0">
				<tr>
					<td width="109" onclick="javascript:MenuChange();parent.Workform.location.href='WQuickView.aspx';"><asp:Image ImageUrl="../Images/luu_thong.gif" runat="server" id="imgModule"></asp:Image></td>
					<td width="6" background="../Images/002_vach_01.gif"></td>
					<td width="6" id="menu1a" background="../Images/002_002.gif"></td>
					<td id="menu1" background="../Images/002_bg.gif" onmouseover="MenuHover(1)" onclick="MenuChange();CheckOut_Click();MenuClick(1);"
						onmouseout="MenuOut(1);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkCheckOut" runat="server" NavigateUrl="#">			
								Ghi mượn
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu2a" background="../Images/002_003.gif"></td>
					<td id="menu2" background="../Images/002_bg.gif" onmouseover="MenuHover(2)" onclick="MenuChange();CheckIn_Click();MenuClick(2);"
						onmouseout="MenuOut(2);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkCheckIn" runat="server" NavigateUrl="#">
								Ghi trả
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu3a" background="../Images/002_003.gif"></td>
					<td id="menu3" background="../Images/002_bg.gif" onmouseover="MenuHover(3)" onclick="MenuChange();Renew_Click();MenuClick(3);"
						onmouseout="MenuOut(3);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkRenew" runat="server" NavigateUrl="#">
								Gia hạn
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu4a" background="../Images/002_003.gif"></td>
					<td id="menu4" background="../Images/002_bg.gif" onmouseover="MenuHover(4)" onclick="MenuChange();Overdue_Click();MenuClick(4);"
						onmouseout="MenuOut(4);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkOverdue" runat="server" NavigateUrl="#">
								Quá hạn
							</asp:hyperlink>
						</p>
					</td>
					<td style="display:none;" width="12" id="menu5a" background="../Images/002_003.gif"></td>
					<td style="display:none;" id="menu5" background="../Images/002_bg.gif" onmouseover="MenuHover(5)" onclick="MenuChange();Hold_Click();MenuClick(5);"
						onmouseout="MenuOut(5);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkHold" runat="server" NavigateUrl="#">
								Đặt chỗ
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu6a" background="../Images/002_003.gif"></td>
					<td id="menu6" background="../Images/002_bg.gif" onmouseover="MenuHover(6)" onclick="MenuChange();Policy_Click();MenuClick(6);"
						onmouseout="MenuOut(6);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkPolicy" runat="server" NavigateUrl="#">
								Chính sách
							</asp:hyperlink>
						</p>
					</td>
					<td style="display:none;" width="12" id="menu7a" background="../Images/002_003.gif"></td>
					<td  style="display:none;" id="menu7" background="../Images/002_bg.gif" onmouseover="MenuHover(7)" onclick="MenuChange();Account_Click();MenuClick(7);"
						onmouseout="MenuOut(7);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkStatistic" runat="server" NavigateUrl="#">
								Phí/phạt
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu8a" background="../Images/002_003.gif"></td>
					<td id="menu8" background="../Images/002_bg.gif" onmouseover="MenuHover(8)" onclick="MenuChange();Statistic_Click();MenuClick(8);"
						onmouseout="MenuOut(8);">
						<p align="center">
							<asp:hyperlink CssClass="lbFunctionMenu" id="lnkAccount" runat="server" NavigateUrl="#">
								Báo cáo
							</asp:hyperlink>
						</p>
					</td>
					<td width="6" id="menu9a" background="../Images/002_004.gif"></td>
					<td width="6"><img border="0" src="../Images/002_vach_01.gif" width="6" height="32"></td>
					<td width="6"><img border="0" src="../Images/002_005.gif" width="7" height="32"></td>
					<td width="31" onmouseover="this.style.backgroundImage='url(../Images/002_006_hover.gif)';"
						onmouseout="this.style.backgroundImage='url(../Images/002_006.gif)';" onclick="BackPage()"
						background="../Images/002_006.gif" height="32"></td>
					<td width="6"><img border="0" src="../Images/002_vach_02.gif" width="6" height="32"></td>
					<td width="31" onmouseover="this.style.backgroundImage='url(../Images/002_007_hover.gif)';"
						onmouseout="this.style.backgroundImage='url(../Images/002_007.gif)';" onclick="ForwardPage()"
						background="../Images/002_007.gif"></td>
					<td width="6"><img border="0" src="../Images/002_vach_02.gif" width="6" height="32"></td>
					<td>
						<input type="hidden" id="hidClick" value="0"> <input type="hidden" id="hidMaxMenu" value="8">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
