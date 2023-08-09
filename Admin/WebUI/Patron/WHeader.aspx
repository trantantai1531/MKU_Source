<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WHeader" CodeFile="WHeader.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WHeader</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form method="post" runat="server" id="Form1">
			<table border="0" width="100%" cellspacing="0" cellpadding="0">
				<tr>
					<td width="92" onclick="javascript:MenuChange();parent.Workform.location.href='WPatronIndex.aspx'"><asp:Image ImageUrl="../Images/ban_doc.gif" id="imgModule" runat="server"></asp:Image></td>
					<td width="6" background="../Images/002_vach_01.gif"></td>
					<td width="6" id="menu1a" background="../Images/002_002.gif"></td>
					<td id="menu1" background="../Images/002_bg.gif" onmouseover="MenuHover(1)" onclick="MenuChange();OpenDocument();MenuClick(1);"
						onmouseout="MenuOut(1);">
						<p align="center">
							<asp:hyperlink id="lnkOpenDocument" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">			
								Hồ sơ
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu2a" background="../Images/002_003.gif"></td>
					<td id="menu2" background="../Images/002_bg.gif" onmouseover="MenuHover(2)" onclick="MenuChange();OpenCard();MenuClick(2);"
						onmouseout="MenuOut(2);">
						<p align="center">
							<asp:hyperlink id="lnkOpenCard" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Thẻ
							</asp:hyperlink>
						</p>
					</td>
					<td style="display:none;" width="12" id="menu3a" background="../Images/002_003.gif"></td>
					<td style="display:none;" id="menu3" background="../Images/002_bg.gif" onmouseover="MenuHover(3)" onclick="MenuChange();OpenBathProcess();MenuClick(3);"
						onmouseout="MenuOut(3);">
						<p align="center">
							<asp:hyperlink id="lnkOpenBathProcess" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Xử lý lô
							</asp:hyperlink>
						</p>
					</td>
					<td width="12" id="menu4a" background="../Images/002_003.gif"></td>
					<td id="menu4" background="../Images/002_bg.gif" onmouseover="MenuHover(4)" onclick="MenuChange();OpenStat();MenuClick(4);"
						onmouseout="MenuOut(4);">
						<p align="center">
							<asp:hyperlink id="lnkOpenStat" runat="server" NavigateUrl="#" CssClass="lbFunctionMenu">
								Thống kê
							</asp:hyperlink>
						</p>
					</td>
					<td width="6" id="menu5a" background="../Images/002_004.gif"></td>
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
						<input type="hidden" id="hidClick" value="0"> <input type="hidden" id="hidMaxMenu" value="4">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
