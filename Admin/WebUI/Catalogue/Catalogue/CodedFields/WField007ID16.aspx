<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID16" CodeFile="WField007ID16.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID16</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(16);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--MICROFORM</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="h">Microform</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Apeture card</asp:ListItem>
							<asp:ListItem Value="b">Microfilm cartridge</asp:ListItem>
							<asp:ListItem Value="c">Microfilm cassette</asp:ListItem>
							<asp:ListItem Value="d">Microfilm reel</asp:ListItem>
							<asp:ListItem Value="e">Microfiche</asp:ListItem>
							<asp:ListItem Value="f">Microfiche cassette</asp:ListItem>
							<asp:ListItem Value="g">Microopaque</asp:ListItem>
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
						<asp:textbox id="txtField3" runat="server" Width="120px" Enabled="False">#</asp:textbox></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server"> 03 - Positive/negative <u>a</u>spect</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Positive</asp:ListItem>
							<asp:ListItem Value="b">Negative</asp:ListItem>
							<asp:ListItem Value="m">Mixed polarity</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - <u>D</u>imensions</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">8 mm.</asp:ListItem>
							<asp:ListItem Value="d">16 mm.</asp:ListItem>
							<asp:ListItem Value="f">35 mm.</asp:ListItem>
							<asp:ListItem Value="g">70 mm.</asp:ListItem>
							<asp:ListItem Value="h">105 mm.</asp:ListItem>
							<asp:ListItem Value="l">3x5 in. or 8x13 cm.</asp:ListItem>
							<asp:ListItem Value="m">4x6 in. or 1x15 cm.</asp:ListItem>
							<asp:ListItem Value="o">6x9 in. or 16x23 cm.</asp:ListItem>
							<asp:ListItem Value="p">3 1/4 x 7 3/8 in. or 9x19 cm.</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - <u>R</u>eduction ratio range</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Low reduction</asp:ListItem>
							<asp:ListItem Value="b">Normal reduction</asp:ListItem>
							<asp:ListItem Value="c">High reduction</asp:ListItem>
							<asp:ListItem Value="d">Very high reduction</asp:ListItem>
							<asp:ListItem Value="e">Ultra high reduction</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="v">Reduction rate varies</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 06-08 - Reduction rati<u>o</u></asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField7" runat="server" Width="120px"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 09 - <u>C</u>olor</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="b">Black and white (or monochrome)</asp:ListItem>
							<asp:ListItem Value="c">Multicolored</asp:ListItem>
							<asp:ListItem Value="m">Mixed</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 10 - <u>E</u>mulsion on film</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Silver hadide</asp:ListItem>
							<asp:ListItem Value="b">Diazo</asp:ListItem>
							<asp:ListItem Value="c">Vesicular</asp:ListItem>
							<asp:ListItem Value="m">Mixed emulsion</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label6" runat="server"> 11 - <u>G</u>eneration</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField10" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">First generation (master)</asp:ListItem>
							<asp:ListItem Value="b">Printing master</asp:ListItem>
							<asp:ListItem Value="c">Service copy</asp:ListItem>
							<asp:ListItem Value="m">Mixed generation</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label7" runat="server"> 12 - <u>B</u>ase of film</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField11" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Safety base, undetermined</asp:ListItem>
							<asp:ListItem Value="c">Safety base, acetate undertimined</asp:ListItem>
							<asp:ListItem Value="d">Safety base, diacetate</asp:ListItem>
							<asp:ListItem Value="p">Safety base, polyester</asp:ListItem>
							<asp:ListItem Value="r">Safety base, mixed</asp:ListItem>
							<asp:ListItem Value="t">Safety base, triacetate</asp:ListItem>
							<asp:ListItem Value="i">Nitrate base</asp:ListItem>
							<asp:ListItem Value="m">Mixed base (nitrate and safety)</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" CssClass="lbButton" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" CssClass="lbButton" Text="Ðặt lại(l)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" CssClass="lbButton" Text="Xem(x)" Width="65px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
