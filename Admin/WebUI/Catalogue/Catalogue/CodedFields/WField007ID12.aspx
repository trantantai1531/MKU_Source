<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID12" CodeFile="WField007ID12.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID12</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(12);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--ELECTRONIC RESOURCE</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="c">Computer file</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Tape catridge</asp:ListItem>
							<asp:ListItem Value="b">Chip catridge</asp:ListItem>
							<asp:ListItem Value="c">Computer optical disc catridge</asp:ListItem>
							<asp:ListItem Value="f">Tape cassette</asp:ListItem>
							<asp:ListItem Value="h">Tape real</asp:ListItem>
							<asp:ListItem Value="j">Magnetic disc</asp:ListItem>
							<asp:ListItem Value="m">Marneto-optical disc</asp:ListItem>
							<asp:ListItem Value="o">Optical disc</asp:ListItem>
							<asp:ListItem Value="r">Remote</asp:ListItem>
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
						<asp:label id="lblLabel4" runat="server"> 03 - <u>C</u>olor</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">One color</asp:ListItem>
							<asp:ListItem Value="b">Black-and-white</asp:ListItem>
							<asp:ListItem Value="c">Multicolored</asp:ListItem>
							<asp:ListItem Value="g">Gray scale</asp:ListItem>
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
						<asp:label id="lblLabel5" runat="server"> 04 - <u>D</u>imensions</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">3 1/2 in.</asp:ListItem>
							<asp:ListItem Value="e">1/2 in.</asp:ListItem>
							<asp:ListItem Value="g">4 3/4 in. or 12 cm.</asp:ListItem>
							<asp:ListItem Value="i">1 1/8 x 2 3/8 in.</asp:ListItem>
							<asp:ListItem Value="j">3 7/8 x 2 1/2 in.</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="o">5 1/4 in.</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="v">8 in.</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label1" runat="server"> 05 - <u>S</u>ound</asp:label></TD>
					<td><asp:dropdownlist id="ddlField6" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" ">No sound (silent)</asp:ListItem>
							<asp:ListItem Value="a">Sound on medium</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" rowSpan="2">
						<asp:label id="Label2" runat="server"> 06-08 - <u>I</u>mage bit depth</asp:label></TD>
					<TD vAlign="top">
						<asp:label id="Label10" runat="server">001-999 - Exact bit depth</asp:label>&nbsp;
						<asp:textbox id="txtField7" runat="server">001</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="Label9" style="Z-INDEX: 115" runat="server"> other</asp:label>&nbsp;
						<asp:dropdownlist id="ddlTemp7" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="mmm">Multiple</asp:ListItem>
							<asp:ListItem Value="nnn">Not applicable</asp:ListItem>
							<asp:ListItem Value="---">Unknown</asp:ListItem>
							<asp:ListItem Value="|||">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 09 - <u>F</u>ile formats</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">One</asp:ListItem>
							<asp:ListItem Value="m">Multiple</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 10 - <u>Q</u>uality assurance target(s)</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Absent</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="p">Present</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label6" runat="server"> 11 - <u>A</u>ntecedent/Source</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField10" runat="server" Width="250px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">File reproduced from original</asp:ListItem>
							<asp:ListItem Value="b">File reproduced from microform</asp:ListItem>
							<asp:ListItem Value="c">File reproduced from computer file</asp:ListItem>
							<asp:ListItem Value="d">File reproduced from an intermediate (not microform)</asp:ListItem>
							<asp:ListItem Value="m">Mixed</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label7" runat="server"> 12 - L<u>e</u>vel of compression</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField11" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Uncompressed</asp:ListItem>
							<asp:ListItem Value="b">Lossless</asp:ListItem>
							<asp:ListItem Value="d">Lossy</asp:ListItem>
							<asp:ListItem Value="m">Mixed</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label8" runat="server"> 13 - <u>R</u>eformatting quality</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField12" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Access</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="p">Preservation</asp:ListItem>
							<asp:ListItem Value="r">Replacement</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="65px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
