<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibOPAC.WebUI.OPAC.WIllDueItem" Codebehind="WILLDueItem.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WILLDueItem</title>
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
								<td width="115" background="../Images/ImgViet/title_bg.gif" align="left" style="WIDTH: 118px"><asp:label id="lblTitleIllDueItem" CssClass="lbTitleHeader" Runat="server">ILL</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="10"></td>
				</tr>
			</table>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR width="100%">
					<TD>
						<asp:Label id="lblTitle" runat="server" Width="100%" CssClass="lbPageTitle">Danh sách các ấn phẩm đã quá thời hạn mượn</asp:Label>
					</TD>
				</TR>
				<TR width="100%">
					<TD>
						<asp:DataGrid id="dtgDueItem" runat="server" width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="Title" HeaderText="Ấn phẩm"></asp:BoundColumn>
								<asp:BoundColumn DataField="PatronName" HeaderText="Tên bạn đọc"></asp:BoundColumn>
								<asp:BoundColumn DataField="CardNo" HeaderText="Thẻ bạn đọc"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
