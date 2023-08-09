<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WIndexBud" CodeFile="WIndexBud.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexBud</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="frm" method="post" runat="server">
			<TABLE width="100%">
				<TR>
					<TD colspan="4" class="lbPageTitle">
						<asp:Label id="lblMainTitle" runat="server">K? TOÁN</asp:Label></TD>
				</TR>
				<TR>
					<td colspan="2" width="50%" height="0"></td>
					<td colspan="2" width="50%"></td>
				</TR>
				<TR>
					<TD vAlign="bottom" width="2%">
						<asp:ImageButton id="imgSpeDec" runat="server" ImageUrl="../images/icons/khai_bao_chi.gif"></asp:ImageButton>
					</TD>
					<TD valign="bottom">
						<asp:HyperLink id="lnkSpeDec" runat="server" CssClass="lbFunctionTitle">Khai báo chi. </asp:HyperLink>
					</TD>
					<TD vAlign="bottom" width="2%">
						<asp:ImageButton id="imgWRateChange" runat="server" ImageUrl="../images/icons/ty_gia_hach_toan.gif"></asp:ImageButton>
					</TD>
					<TD valign="bottom">
						<asp:HyperLink id="lnkWRateChange" runat="server" CssClass="lbFunctionTitle">T? giá h?ch toán </asp:HyperLink>
					</TD>
				</TR>
				<TR>
					<TD valign="top" colspan="2">
						<asp:Label id="lblSpeDec" runat="server" CssClass="lbFunctionDetail">Chi ti?n hay d? chi ti?n t? các qu? khác nhau cho h?p d?ng. </asp:Label></TD>
					<TD valign="top" colspan="2">
						<asp:Label id="lblWRateChange" runat="server" CssClass="lbFunctionDetail">Thay d?i t? giá h?ch toán c?a các ngo?i t? so v?i d?ng Vi?t Nam </asp:Label></TD>
				</TR>
				<TR>
					<TD valign="bottom">
						<asp:ImageButton id="imgAcqDec" runat="server" ImageUrl="../images/icons/khai_bao_thu.gif"></asp:ImageButton>
					</TD>
					<TD valign="bottom">
						<asp:HyperLink id="lnkAcqDec" runat="server" CssClass="lbFunctionTitle">Khai báo thu </asp:HyperLink>
					</TD>
					<TD valign="bottom">
						<asp:ImageButton id="imgWBudgetFrame" runat="server" ImageUrl="../images/icons/trang_thai_quy.gif"></asp:ImageButton>
					</TD>
					<TD valign="bottom">
						<asp:HyperLink id="lnkWBudgetFrame" runat="server" CssClass="lbFunctionTitle">Tr?ng thái qu? </asp:HyperLink>
					</TD>
				</TR>
				<TR>
					<TD valign="top" colspan="2">
						<asp:Label id="lblAcqDec" runat="server" CssClass="lbFunctionDetail">Khai báo các kho?n thu, nh?p qu?, hoàn qu?. </asp:Label></TD>
					<TD valign="top" colspan="2">
						<asp:Label id="lblWBudgetFrame" runat="server" CssClass="lbFunctionDetail">Thay d?i tr?ng thái qu? </asp:Label></TD>
				</TR>
				<TR>
					<TD valign="bottom">
						<asp:ImageButton id="imgWBudgetFrameNhamhang" runat="server" ImageUrl="../images/icons/bao_cao_quy.gif"></asp:ImageButton>
					</TD>
					<TD valign="bottom">
						<asp:HyperLink id="HyperLink3" runat="server" CssClass="lbFunctionTitle">Báo cáo qu?. </asp:HyperLink>
					</TD>
					<TD valign="bottom">
						<asp:ImageButton id="ImageButton6" runat="server" ImageUrl="../images/icons/chuyen-_tien.gif"></asp:ImageButton>
					</TD>
					<TD valign="bottom">
						<asp:HyperLink id="HyperLink6" runat="server" CssClass="lbFunctionTitle">Chuy?n ti?n </asp:HyperLink>
					</TD>
				</TR>
				<TR>
					<TD valign="top" colspan="2">
						<asp:Label id="Label3" runat="server" CssClass="lbFunctionDetail">Báo cáo s? du cu?i k? c?a t?ng qu?. </asp:Label></TD>
					<TD valign="top" colspan="2">
						<asp:Label id="Label6" runat="server" CssClass="lbFunctionDetail">Chuy?n d?i ti?n t? qu? này sang qu? khác </asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
