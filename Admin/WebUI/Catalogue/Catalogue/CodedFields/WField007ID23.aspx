<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID23" CodeFile="WField007ID23.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID23</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(23);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--VIDEORECORDING</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%">
						<asp:label id="lblLabel2" runat="server"> Character <u>P</u>ositions</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="v">00 - Category of material</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> <u>V</u> deorecording</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="180">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="c">01 - Specific material designation</asp:ListItem>
							<asp:ListItem value="d">Videocartridge</asp:ListItem>
							<asp:ListItem value="f">Videodisc</asp:ListItem>
							<asp:ListItem value="r">Videocassette</asp:ListItem>
							<asp:ListItem value="u">Videoreel</asp:ListItem>
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
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server"> 03 - <u>C</u>olor</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">One color</asp:ListItem>
							<asp:ListItem value="b">Black-and-white</asp:ListItem>
							<asp:ListItem value="c">Multicolored</asp:ListItem>
							<asp:ListItem value="m">Mixed</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - Videorecording <u>f</u>ormat</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Beta (1/2  n., videocassette)</asp:ListItem>
							<asp:ListItem value="b">VHS (1/2  n., videocassette)</asp:ListItem>
							<asp:ListItem value="c">U-mat c (3/4  n., videocassette)</asp:ListItem>
							<asp:ListItem value="d">E AJ (1/2  n. reel)</asp:ListItem>
							<asp:ListItem value="e">Type C (1  n., reel)</asp:ListItem>
							<asp:ListItem value="f">Quadruplex (1  n. or 2  n., reel)</asp:ListItem>
							<asp:ListItem value="g">Laser opt cal (Reflect ve) videodisc</asp:ListItem>
							<asp:ListItem value="h">CED (Capac tance Electronic Disc) videodisc</asp:ListItem>
							<asp:ListItem value="i">Betacam (1/2  n., videocassette)</asp:ListItem>
							<asp:ListItem value="j">Betacam SP (1/2  n., videocassette)	</asp:ListItem>
							<asp:ListItem value="k">Super-VHS (1/2  n., videocassette)</asp:ListItem>
							<asp:ListItem value="m">M-   (1/2  n., videocassette)</asp:ListItem>
							<asp:ListItem value="o">D-2 (3/4  n., videocassette)</asp:ListItem>
							<asp:ListItem value="p">8 mm.</asp:ListItem>
							<asp:ListItem value="q">H -8 mm.</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="v"> DVD</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - <u>S</u>ound on medium or separate</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value=" ">No sound (silent)</asp:ListItem>
							<asp:ListItem value="a">Sound on medium</asp:ListItem>
							<asp:ListItem value="b">Sound separate from medium</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 06 - <u>M</u>edium for sound</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField7" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value=" ">No sound (silent)</asp:ListItem>
							<asp:ListItem value="a">Optical sound track on motion picture film</asp:ListItem>
							<asp:ListItem value="b">Magnetic sound track on motion picture film</asp:ListItem>
							<asp:ListItem value="c">Magnetic audio tape  nicartridge</asp:ListItem>
							<asp:ListItem value="d">Sound disc</asp:ListItem>
							<asp:ListItem value="e">Magnetic audio tape on reel</asp:ListItem>
							<asp:ListItem value="f">Magnetic audio tape  nicassette</asp:ListItem>
							<asp:ListItem value="g">Optical and magnetic sound track on motion  picture film</asp:ListItem>
							<asp:ListItem value="h">Videotape</asp:ListItem>
							<asp:ListItem value="i">Videodisc</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 07 - <u>D</u>imensions</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">8 mm.</asp:ListItem>
							<asp:ListItem value="m">1/4  n.</asp:ListItem>
							<asp:ListItem value="o">1/2  n.</asp:ListItem>
							<asp:ListItem value="p">1  n.</asp:ListItem>
							<asp:ListItem value="q">2  n.</asp:ListItem>
							<asp:ListItem value="r">3/4  n.</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 08 - Configuration of <u>p</u>layback channels</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="k">Mixed</asp:ListItem>
							<asp:ListItem value="m">Monaural</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="q">Quadraphonic, multichannel, or surround</asp:ListItem>
							<asp:ListItem value="s">Stereophonic</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" CssClass="lbButton" Text="Nhập(u)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" CssClass="lbButton" Text="Ðặt lại(r)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" CssClass="lbButton" Text="Xem(v)" Width="63px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
