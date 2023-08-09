<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WILLOutGoing.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.WILLOutGoing"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WILLOutGoing</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ChangeFontType();" leftmargin="0" topmargin="0">
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
								<td width="115" background="../Images/ImgViet/title_bg.gif" align="left" style="WIDTH: 118px"><asp:label id="lblTitleIllOutGoing" CssClass="lbTitleHeader" Runat="server">ILL</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="10"></td>
				</tr>
			</table>
			<table width="100%" border="0" cellpadding="1" cellspacing="1">
				<tr class="lbPageTitle">
					<td>
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle">Tạo yêu cầu mượn liên thư viện</asp:Label>
					</td>
				</tr>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkBook" runat="server" NavigateUrl="WILLBook.aspx">Sách</asp:HyperLink></li></TD>
				</TR>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkILLJournal" runat="server" NavigateUrl="WILLJournal.aspx">Tạp chí</asp:HyperLink>
						</li>
					</TD>
				</TR>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkILLChapter" runat="server" NavigateUrl="WILLChapter.aspx">Chương (Sách) -- Chapter of Book</asp:HyperLink>
						</li>
					</TD>
				</TR>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkILLProcessding" runat="server" NavigateUrl="WILLIllProceeding.aspx">Kỷ yếu hội nghị -- PROCEEDINGS of a Conference</asp:HyperLink>
						</li>
					</TD>
				</TR>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkDissertation" runat="server" NavigateUrl="WILLDissertation.aspx">Luận án/Luận văn -- DISSERTATION/Thesis</asp:HyperLink>
						</li>
					</TD>
				</TR>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lblILLGovement" runat="server" NavigateUrl="WILLGoverment.aspx">Báo cáo chính phủ -- GOVERNMENT Report</asp:HyperLink>
						</li>
					</TD>
				</TR>
				<TR>
					<TD>
						<li>
							<asp:HyperLink id="lnkTechnical" runat="server" NavigateUrl="WILLTechnical.aspx">Báo cáo kỹ thuật -- TECHNICAL Report</asp:HyperLink>
						</li>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
