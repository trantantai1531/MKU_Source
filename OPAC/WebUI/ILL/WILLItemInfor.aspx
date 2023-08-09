<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibOPAC.WebUI.OPAC.WILLItemInfor" Codebehind="WILLItemInfor.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WILLItemInfor</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onload="ChangeFontType();" leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<table width="100" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="13" rowspan="2"><img border="0" src="../Images/ImgViet/title_01.gif" width="13" height="55"></td>
								<td height="15" colspan="2" style="WIDTH: 204px"><img border="0" src="../Images/ImgViet/title_02.gif" width="85" height="15"></td>
							</tr>
							<tr>
								<td width="40"><img border="0" src="../Images/ImgViet/title_03.gif" width="40" height="40"></td>
								<td width="115" background="../Images/ImgViet/title_bg.gif" align="left" style="WIDTH: 118px"><asp:label id="lblTitleIllItemInfor" CssClass="lbTitleHeader" Runat="server">ILL</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="10"></td>
				</tr>
			</table>
			<table width="100%" border="0" cellpadding="1" cellspacing="1">
				<tr>
					<td>
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle" Width="100%"> Thông tin về các ấn phẩm</asp:Label>
					</td>
				</tr>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkRecItem" runat="server" NavigateUrl="WIllRecItem.aspx">Ấn phẩm đã mượn về thư viện</asp:HyperLink></li></TD>
				</TR>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkILLDueItem" runat="server" NavigateUrl="WILLDueItem.aspx">Ấn phẩm đã quá hạn cho phép</asp:HyperLink>
						</li>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
