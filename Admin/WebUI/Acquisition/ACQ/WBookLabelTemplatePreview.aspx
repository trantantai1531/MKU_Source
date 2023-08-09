<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBookLabelTemplatePreview" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WBookLabelTemplatePreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Nhãn gáy</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td width="100%" align="center"><asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">Xem mẫu nhãn gáy nhãn bìa</asp:Label></td>
				</tr>
				<tr>
					<td width="100%" align="center"><asp:Label ID="lblDisplay" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr class="lbGroupTitle">
					<td align="center" width="100%"><asp:Button ID="btnClose" Runat="server" Text="Đóng(g)"></asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlBookLabelTemplate" Runat="server" Visible="False">
				<asp:ListItem Value="id">1234D</asp:ListItem>
				<asp:ListItem Value="no">1</asp:ListItem>
				<asp:ListItem Value="leader">00651cam  2200217u  4500</asp:ListItem>
				<asp:ListItem Value="911">Emiclib</asp:ListItem>
				<asp:ListItem Value="912">Emiclib</asp:ListItem>
				<asp:ListItem Value="001">TVL020000001</asp:ListItem>
				<asp:ListItem Value="925">G</asp:ListItem>
				<asp:ListItem Value="926">A</asp:ListItem>
				<asp:ListItem Value="927">SH</asp:ListItem>
				<asp:ListItem Value="curday">1/1/2005</asp:ListItem>
				<asp:ListItem Value="curmonth">1</asp:ListItem>
				<asp:ListItem Value="curyear">2005</asp:ListItem>
				<asp:ListItem Value="005">19920331092212.7</asp:ListItem>
				<asp:ListItem Value="008">820305s1991    nyu           001 0 eng  </asp:ListItem>
				<asp:ListItem Value="020">$a2383920583</asp:ListItem>
				<asp:ListItem Value="022">$a3459-5445</asp:ListItem>
				<asp:ListItem Value="040">$aDGSOFT$beng</asp:ListItem>
				<asp:ListItem Value="050">$aPN1992.8.S4$bT47 1991</asp:ListItem>
				<asp:ListItem Value="082">$a791.45/75/0973$219</asp:ListItem>
				<asp:ListItem Value="084">$a234.34</asp:ListItem>
				<asp:ListItem Value="090">$a791.45$bT472 1991</asp:ListItem>
				<asp:ListItem Value="094">C34	A12.5</asp:ListItem>
				<asp:ListItem Value="100">Terrace, Vincent,1948-</asp:ListItem>
				<asp:ListItem Value="110">University of Michigan.Stamford Center</asp:ListItem>
				<asp:ListItem Value="245">Fifty years of television :a guide to series and pilots, 1937-1988 /Vincent Terrace</asp:ListItem>
				<asp:ListItem Value="246">50 years of television</asp:ListItem>
				<asp:ListItem Value="250">2nd ed.</asp:ListItem>
				<asp:ListItem Value="260">$aNewYork :$bCornwall Books,c1991</asp:ListItem>
				<asp:ListItem Value="300">864 p. ;24 cm.</asp:ListItem>
				<asp:ListItem Value="490">Television techniques</asp:ListItem>
				<asp:ListItem Value="500">Includes index.</asp:ListItem>
				<asp:ListItem Value="520">Giới thiệu về lịch sử phát triển và những thay đổi trong công nghệ truyền hình và vô tuyến truyền hình trong 50 năm qua.</asp:ListItem>
				<asp:ListItem Value="650">Television pilot programsUnited StatesCatalogs.</asp:ListItem>
				<asp:ListItem Value="653">Vô tuyến truyền hình và truyền hình</asp:ListItem>
				<asp:ListItem Value="700">Meadford, Graham	Kane, Osley</asp:ListItem>
				<asp:ListItem Value="856">http://www.greenhouse.com/</asp:ListItem>
				<asp:ListItem Value="LIBOL1">Giá trị của trường</asp:ListItem>
				<asp:ListItem Value="LIB">DGSOFT</asp:ListItem>
				<asp:ListItem Value="INVENTORY">KM</asp:ListItem>
				<asp:ListItem Value="SHELF">F</asp:ListItem>
				<asp:ListItem Value="NUMBER">2384395</asp:ListItem>
				<asp:ListItem Value="CALLNUMBER">234.35<BR>H345<BR>2002</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
