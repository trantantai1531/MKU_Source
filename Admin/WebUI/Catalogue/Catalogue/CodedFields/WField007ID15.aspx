<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID15" CodeFile="WField007ID15.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID15</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(15);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--PROJECTED GRAPHIC</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="40%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="g">Projected graphic</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - Specific material <u>d</u>esignation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="c">Filmstrip cartridge</asp:ListItem>
							<asp:ListItem Value="d">Filmslip</asp:ListItem>
							<asp:ListItem Value="f">Other filmstrip type</asp:ListItem>
							<asp:ListItem Value="o">Filmstrip roll</asp:ListItem>
							<asp:ListItem Value="s">Slide</asp:ListItem>
							<asp:ListItem Value="t">Transparency</asp:ListItem>
							<asp:ListItem Value="u">Unspecified</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel3" runat="server"> 02 - Undefined; contains a blank (#) or a fill character ( | ).</asp:label></TD>
					<td>
						<asp:textbox id="txtField3" runat="server" Width="88px" Enabled="False">#</asp:textbox></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel4" runat="server"> 03 - <u>C</u>olor</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">One color</asp:ListItem>
							<asp:ListItem Value="b">Black-and-white</asp:ListItem>
							<asp:ListItem Value="c">Multicolored</asp:ListItem>
							<asp:ListItem Value="h">Hand colored</asp:ListItem>
							<asp:ListItem Value="m">Mixed</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - <u>B</u>ase of emulsion</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="d">Glass</asp:ListItem>
							<asp:ListItem Value="e">Synthetic</asp:ListItem>
							<asp:ListItem Value="j">Safety film</asp:ListItem>
							<asp:ListItem Value="k">Film base, other than safety film</asp:ListItem>
							<asp:ListItem Value="m">Mixed collection</asp:ListItem>
							<asp:ListItem Value="o">Paper</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - <u>S</u>ound on medium or separate</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" ">No sound(silent)</asp:ListItem>
							<asp:ListItem Value="a">Sound on medium</asp:ListItem>
							<asp:ListItem Value="b">Sound separate from medium</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 06 - <u>M</u>edium for sound</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField7" runat="server" Width="250px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" ">No sound(silent)</asp:ListItem>
							<asp:ListItem Value="a">Optical sound track on motion picture film</asp:ListItem>
							<asp:ListItem Value="b">Magnetic sound track on motion picture film</asp:ListItem>
							<asp:ListItem Value="c">Magnetic audio tape in catridge</asp:ListItem>
							<asp:ListItem Value="d">Sound disc</asp:ListItem>
							<asp:ListItem Value="e">Magnetic audio tape on reel</asp:ListItem>
							<asp:ListItem Value="f">Magnetic audio tape on cassette</asp:ListItem>
							<asp:ListItem Value="g">Optical and magnetic sound track on motion picture film</asp:ListItem>
							<asp:ListItem Value="h">Videotape</asp:ListItem>
							<asp:ListItem Value="i">Videodisc</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 07 - Dimensi<u>o</u>ns</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Standard 8 mm.</asp:ListItem>
							<asp:ListItem Value="b">Super 8 mm./Single 8 mm.</asp:ListItem>
							<asp:ListItem Value="c">9.5 mm.</asp:ListItem>
							<asp:ListItem Value="d">16 mm.</asp:ListItem>
							<asp:ListItem Value="e">28 mm.</asp:ListItem>
							<asp:ListItem Value="f">35 mm.</asp:ListItem>
							<asp:ListItem Value="g">70 mm.</asp:ListItem>
							<asp:ListItem Value="j">2x2 in. or 5x5 cm.</asp:ListItem>
							<asp:ListItem Value="k">2 1/4 x 2 1/4 in. or 6x6 cm.</asp:ListItem>
							<asp:ListItem Value="s">4x5 in. or 10x13 cm.</asp:ListItem>
							<asp:ListItem Value="t">5x7 in. or 13x18 cm.</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="v">8x10 in. or 21x26 cm.</asp:ListItem>
							<asp:ListItem Value="w">9x9 in. or 23x23 cm.</asp:ListItem>
							<asp:ListItem Value="x">10x10 in. or 26x26 cm.</asp:ListItem>
							<asp:ListItem Value="y">7x7 in. or 18x18 cm.</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 08 - Second<u>a</u>ry support material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" ">-#No secondary support</asp:ListItem>
							<asp:ListItem Value="c">Cardboard</asp:ListItem>
							<asp:ListItem Value="d">Glass</asp:ListItem>
							<asp:ListItem Value="e">Synthetic</asp:ListItem>
							<asp:ListItem Value="h">Metal</asp:ListItem>
							<asp:ListItem Value="j">Metal and glass</asp:ListItem>
							<asp:ListItem Value="k">Synthetic and glass</asp:ListItem>
							<asp:ListItem Value="m">Mixed collection</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="63px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
