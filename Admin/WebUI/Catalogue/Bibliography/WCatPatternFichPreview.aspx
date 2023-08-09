<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatPatternFichPreview" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCatPatternFichPreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xem mẫu phích</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<Table ID="CatPatternPreview" Width="100%" cellpadding="2" cellspacing="0">
				<tr class="lbPageTitle">
					<td align="center">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" cssclass="lbPageTitle main-group-form">Xem mẫu phích</asp:Label></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="lblContent" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr class="lbControlBar">
					<td align="center">
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="64px"></asp:Button></td>
				</tr>
				<asp:DropDownList ID="ddlViewField" Runat="server" Width="0" Visible="False">
					<asp:ListItem Value="NoID">Hiển thị được ID</asp:ListItem>
					<asp:ListItem Value="ID">123</asp:ListItem>
					<asp:ListItem Value="No">1</asp:ListItem>
					<asp:ListItem Value="Leader">00651cam  2200217u  4500</asp:ListItem>
					<asp:ListItem Value="001">TVL020000001</asp:ListItem>
					<asp:ListItem Value="911">Phạm thị Hoa</asp:ListItem>
					<asp:ListItem Value="912">Phạm thị Hoa</asp:ListItem>
					<asp:ListItem Value="925">G</asp:ListItem>
					<asp:ListItem Value="926">A</asp:ListItem>
					<asp:ListItem Value="927">SH</asp:ListItem>
					<asp:ListItem Value="005">19920331092212.7</asp:ListItem>
					<asp:ListItem Value="008">820305s1991    nyu           001 0 vie  </asp:ListItem>
					<asp:ListItem Value="020">$a2383920583</asp:ListItem>
					<asp:ListItem Value="040">$a3459-5445</asp:ListItem>
					<asp:ListItem Value="041">$aeng</asp:ListItem>
					<asp:ListItem Value="082">$a791.45/75/0973$219</asp:ListItem>
					<asp:ListItem Value="084">$a234.34</asp:ListItem>
					<asp:ListItem Value="090">$a791.45$bT472 1991</asp:ListItem>
					<asp:ListItem Value="094">$aC34	$aA12.5</asp:ListItem>
					<asp:ListItem Value="100">$aTerrace, Vincent,$d1948-</asp:ListItem>
					<asp:ListItem Value="110">$aUniversity of Michigan.$bStamford Center</asp:ListItem>
					<asp:ListItem Value="245">$aFifty years of television :$ba guide to series and pilots, 1937-1988 /$cVincent Terrace</asp:ListItem>
					<asp:ListItem Value="246">$a50 years of television</asp:ListItem>
					<asp:ListItem Value="250">$a2nd ed.</asp:ListItem>
					<asp:ListItem Value="260">$aNew York :$bCornwall Books,$cc1991</asp:ListItem>
					<asp:ListItem Value="300">$a864 p. ;$c24 cm.</asp:ListItem>
					<asp:ListItem Value="490">$aTelevision techniques</asp:ListItem>
					<asp:ListItem Value="500">$aIncludes index.</asp:ListItem>
					<asp:ListItem Value="520">$aGiới thiệu về lịch sử phát triển và những thay đổi trong công nghệ truyền hình và vô tuyến truyền hình trong 50 năm qua. </asp:ListItem>
					<asp:ListItem Value="650">$aTelevision pilot programs$zUnited States$vCatalogs.</asp:ListItem>
					<asp:ListItem Value="653">$aVô tuyến truyền hình	$aKỹ thuật truyền hình</asp:ListItem>
					<asp:ListItem Value="700">$aMeadford, Graham	$aKane, Osley</asp:ListItem>
					<asp:ListItem Value="856">$uhttp://www.greenhouse.com/</asp:ListItem>
					<asp:ListItem Value="Else">Giá trị của trường</asp:ListItem>
					<asp:ListItem Value="Lib">GREENHOUSE.</asp:ListItem>
					<asp:ListItem Value="Inventory">KC.</asp:ListItem>
					<asp:ListItem Value="Shelf">F.</asp:ListItem>
					<asp:ListItem Value="HoldingCompositeelse">02305-435</asp:ListItem>
					<asp:ListItem Value="Number">2384395</asp:ListItem>
					<asp:ListItem Value="CallNumber">234.35 H345 2002</asp:ListItem>
					<asp:ListItem Value="Temp">Template</asp:ListItem>
				</asp:DropDownList>
			</Table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
