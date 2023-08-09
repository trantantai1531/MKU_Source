<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibOPAC.WebUI.OPAC.WILLIndex" Codebehind="WILLIndex.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WILLIndex</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body onload="ChangeFontType();" topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<table width="50" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="13" rowspan="2"><img border="0" src="../Images/ImgViet/title_01.gif" width="13" height="55"></td>
								<td height="15" colspan="2"><img border="0" src="../Images/ImgViet/title_02.gif" width="85" height="15"></td>
							</tr>
							<tr>
								<td width="40"><img border="0" src="../Images/ImgViet/title_03.gif" width="40" height="40"></td>
								<td width="171" background="../Images/ImgViet/title_bg.gif" align="left"><asp:label id="lblTitleIllIndex" CssClass="lbTitleHeader" Runat="server">ILL</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="10"></td>
				</tr>
			</table>
			<table width="100%" cellpadding="1" cellspacing="1" border="0">
				<TR class="lbPageTitle">
					<TD colSpan="2">
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle">ILL - Mượn liên thư viện.</asp:Label></TD>
				</TR>
				<tr>
					<td colspan="2">
						<asp:HyperLink id="lnkInComing" runat="server" NavigateUrl="WILLInComing.aspx">Phục vụ các thư viện khác</asp:HyperLink>
					</td>
				</tr>
				<TR>
					<TD width="10%"></TD>
					<TD>
						<asp:Label id="lblInComingDes" runat="server" CssClass="lbfunctionDetail">Mẫu yêu cầu mượn liên thư viện trên Web dành cho các thư viện, tổ chức muốn gửi yêu cầu mượn đến thư viện cục bộ. </asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:HyperLink id="lnkOutGoing" runat="server" NavigateUrl="WILLOutGoing.aspx">Phục vụ bạn đọc của thư viện</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD>
						<asp:Label id="lblOutGoingDes" runat="server" CssClass="lbfunctionDetail">Mẫu yêu cầu mượn liên thư viện trên Web dành cho bạn đọc của thư viện cục bộ muốn yêu cầu mượn ấn phẩm tại các thư viện khác. </asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:HyperLink id="lnkItemInfor" runat="server" NavigateUrl="WILLItemInfor.aspx">Thông tin về các ấn phẩm</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD>
						<asp:Label id="lblItemInforDes" runat="server" CssClass="lbfunctionDetail">Liệt kê các ấn phẩm đã được chuyển về thư viện cục bộ theo yêu cầu bạn đọc và các ấn phẩm mà bạn đọc đã mượn quá hạn. </asp:Label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
