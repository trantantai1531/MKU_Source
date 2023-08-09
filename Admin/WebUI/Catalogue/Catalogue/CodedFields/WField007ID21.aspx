<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID21" CodeFile="WField007ID21.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID21</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(21);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--SOUND RECORDING</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="s">Sound recording</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - Specific <u>m</u>aterial designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="d">Sound disc</asp:ListItem>
							<asp:ListItem value="e">Cylinder</asp:ListItem>
							<asp:ListItem value="g">Sound cartridge</asp:ListItem>
							<asp:ListItem value="i">Sound-track film</asp:ListItem>
							<asp:ListItem value="q">Roll</asp:ListItem>
							<asp:ListItem value="s">Sound cassette</asp:ListItem>
							<asp:ListItem value="t">Sound-tape reel</asp:ListItem>
							<asp:ListItem value="u">Unspecified</asp:ListItem>
							<asp:ListItem value="w">Wire recording</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
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
					<TD vAlign="top"><asp:label id="lblLabel4" runat="server"> 03 - <u>S</u>peed</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">16 rpm</asp:ListItem>
							<asp:ListItem value="b">33 1/3 rpm</asp:ListItem>
							<asp:ListItem value="c">45 rpm</asp:ListItem>
							<asp:ListItem value="d">78 rpm</asp:ListItem>
							<asp:ListItem value="e">8 rpm</asp:ListItem>
							<asp:ListItem value="f">1.4 m. per sec.</asp:ListItem>
							<asp:ListItem value="h">120 rpm</asp:ListItem>
							<asp:ListItem value="i">160 rpm</asp:ListItem>
							<asp:ListItem value="k">15/16 ips</asp:ListItem>
							<asp:ListItem value="l">1 7/8 ips</asp:ListItem>
							<asp:ListItem value="m">3 3/4 ips</asp:ListItem>
							<asp:ListItem value="o">7 1/2 ips</asp:ListItem>
							<asp:ListItem value="p">15 ips</asp:ListItem>
							<asp:ListItem value="r">30 ips</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - <u>C</u>onfiguration of playback channels</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="m">Monaural</asp:ListItem>
							<asp:ListItem value="q">Quadraphonic</asp:ListItem>
							<asp:ListItem value="s">Stereophonic</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - <u>G</u>roove width/groove pitch</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="m">Microgroove/fine</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="s">Coarse/standard</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 06 - <u>D</u>imensions</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField7" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">3 in.</asp:ListItem>
							<asp:ListItem value="b">5 in.</asp:ListItem>
							<asp:ListItem value="c">7 in.</asp:ListItem>
							<asp:ListItem value="d">10 in.</asp:ListItem>
							<asp:ListItem value="e">12 in.</asp:ListItem>
							<asp:ListItem value="f">16 in.</asp:ListItem>
							<asp:ListItem value="g">4 3/4 in. or 12 cm.</asp:ListItem>
							<asp:ListItem value="j">3 7/8 x 2 1/2 in.</asp:ListItem>
							<asp:ListItem value="o">5 1/4 x 3 7/8 in.</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="s">2 3/4 x 4 in.</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 07 - Tape <u>w</u>idth</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="l">1/8 in.</asp:ListItem>
							<asp:ListItem value="m">1/4 in.</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="o">1/2 in.</asp:ListItem>
							<asp:ListItem value="p">1 in.</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label4" runat="server"> 08 - Tape configurati<u>o</u>n</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Full (1) track</asp:ListItem>
							<asp:ListItem value="b">Half (2) track</asp:ListItem>
							<asp:ListItem value="c">Quarter (4) track</asp:ListItem>
							<asp:ListItem value="d">Eight track</asp:ListItem>
							<asp:ListItem value="e">Twelve track</asp:ListItem>
							<asp:ListItem value="f">Sixteen track</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label6" runat="server"> 09 - <u>K</u>ind of disc, cylinder or tape</asp:label></TD>
					<TD valign="top">
						<asp:dropdownlist id="ddlField10" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Master tape</asp:ListItem>
							<asp:ListItem value="b">Tape duplication master</asp:ListItem>
							<asp:ListItem value="d">Disc master (negative)</asp:ListItem>
							<asp:ListItem value="i">Instantaneous (recorded on the spot)</asp:ListItem>
							<asp:ListItem value="m">Mass produced</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="r">Mother (positive)</asp:ListItem>
							<asp:ListItem value="s">Stamper (negative)</asp:ListItem>
							<asp:ListItem value="t">Test pressing</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label7" runat="server"> 10 - Kind o<u>f</u> material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField11" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Lacquered</asp:ListItem>
							<asp:ListItem value="b">Cellulose nitrate</asp:ListItem>
							<asp:ListItem value="c">Acetate tape with ferrous oxide</asp:ListItem>
							<asp:ListItem value="g">Glass with lacquer</asp:ListItem>
							<asp:ListItem value="i">Aluminum with lacquer</asp:ListItem>
							<asp:ListItem value="l">Metal</asp:ListItem>
							<asp:ListItem value="m">Plastic with metal</asp:ListItem>
							<asp:ListItem value="r">Paper with lacquer or ferrous oxide</asp:ListItem>
							<asp:ListItem value="p">Plastic</asp:ListItem>
							<asp:ListItem value="s">Shellac</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="w">Wax</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label8" runat="server"> 11 - Kind of cutt<u>i</u>ng</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField12" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="h">Hill-and-dale cutting</asp:ListItem>
							<asp:ListItem value="l">Lateral or combined cutting</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label9" runat="server"> 12 - Special <u>p</u>layback characteristics</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField13" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">NAB standard</asp:ListItem>
							<asp:ListItem value="b">CCIR standard</asp:ListItem>
							<asp:ListItem value="c">Dolby-B encoded</asp:ListItem>
							<asp:ListItem value="d">dbx encoded</asp:ListItem>
							<asp:ListItem value="e">Digital recording</asp:ListItem>
							<asp:ListItem value="f">Dolby-A encoded</asp:ListItem>
							<asp:ListItem value="g">Dolby-C encoded</asp:ListItem>
							<asp:ListItem value="h">CX encoded</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label10" runat="server"> 13 - Capture <u>a</u>nd storage technique</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField14" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Acoustical capture, direct storage</asp:ListItem>
							<asp:ListItem value="b">Direct storage, not acoustical</asp:ListItem>
							<asp:ListItem value="d">Digital storage</asp:ListItem>
							<asp:ListItem value="e">Analog electrical storage</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="63px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
