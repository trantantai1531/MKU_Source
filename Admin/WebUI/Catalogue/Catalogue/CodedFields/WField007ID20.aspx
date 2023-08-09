<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID20" CodeFile="WField007ID20.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"ansitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID20</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(18);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--REMOTE-SENSING IMAGE</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="40%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="r">Remote-sensing image</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - Specific <u>m</u>aterial designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="u">Unspecified</asp:ListItem>
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
					<TD vAlign="top"><asp:label id="lblLabel4" runat="server"> 03 - <u>A</u>ttitute of sensor</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Surface</asp:ListItem>
							<asp:ListItem value="b">Airborne</asp:ListItem>
							<asp:ListItem value="c">Spaceborne</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - Attitude <u>o</u>f sensor</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Low oblique</asp:ListItem>
							<asp:ListItem value="b">High oblique</asp:ListItem>
							<asp:ListItem value="c">Vertical</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label1" runat="server"> 05 - <u>C</u>loud cover</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="0">0 - 0-9%</asp:ListItem>
							<asp:ListItem value="1">1 - 10-19%</asp:ListItem>
							<asp:ListItem value="2">2 - 20-29%</asp:ListItem>
							<asp:ListItem value="3">3 - 30-39%</asp:ListItem>
							<asp:ListItem value="4">4 - 40-49%</asp:ListItem>
							<asp:ListItem value="5">5 - 50-59%</asp:ListItem>
							<asp:ListItem value="6">6 - 60-69%</asp:ListItem>
							<asp:ListItem value="7">7 - 70-79%</asp:ListItem>
							<asp:ListItem value="8">8 - 80-89%</asp:ListItem>
							<asp:ListItem value="9">9 - 90-100%</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server" Width="392px"> 06 - <u>P</u>latform construction type</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField7" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Balloon</asp:ListItem>
							<asp:ListItem value="b">Aircraft--low altitude</asp:ListItem>
							<asp:ListItem value="c">Aircraft--medium altitude</asp:ListItem>
							<asp:ListItem value="d">Aircraft--high altitude</asp:ListItem>
							<asp:ListItem value="e">Manned spacecraft</asp:ListItem>
							<asp:ListItem value="f">Unmanned spacecraft</asp:ListItem>
							<asp:ListItem value="g">Land-based remote-sensing device</asp:ListItem>
							<asp:ListItem value="h">Water surface-based remote-sensing device</asp:ListItem>
							<asp:ListItem value="i">Submersible remote-sensing device</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label4" runat="server"> 07 - Platform <u>u</u>se category</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Meteorological</asp:ListItem>
							<asp:ListItem value="b">Surface observing</asp:ListItem>
							<asp:ListItem value="c">Space observing</asp:ListItem>
							<asp:ListItem value="m">Mixed uses</asp:ListItem>
							<asp:ListItem value="n">Not applicable</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label6" runat="server"> 08 - <u>S</u>ensor type</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Active</asp:ListItem>
							<asp:ListItem value="b">Passive</asp:ListItem>
							<asp:ListItem value="u">Unknown</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="|"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label7" runat="server"> 09-10 - <u>D</u>ata type</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField10" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="aa">Visible light</asp:ListItem>
							<asp:ListItem value="da">Near infrared</asp:ListItem>
							<asp:ListItem value="db">Middle infrared</asp:ListItem>
							<asp:ListItem value="dc">Far infrared</asp:ListItem>
							<asp:ListItem value="dd">Thermal infrared</asp:ListItem>
							<asp:ListItem value="de">Shortwave infrared (SWIR)</asp:ListItem>
							<asp:ListItem value="df">Reflective infrared</asp:ListItem>
							<asp:ListItem value="dv">Combinations</asp:ListItem>
							<asp:ListItem value="dz">Other infrared data</asp:ListItem>
							<asp:ListItem value="ga">Sidelooking airborne radar (SLAR)</asp:ListItem>
							<asp:ListItem value="gb">Synthetic aperture radar (SAR)-Single frequency</asp:ListItem>
							<asp:ListItem value="gc">SAR-multi-frequency (multichannel)</asp:ListItem>
							<asp:ListItem value="gd">SAR-like polarization</asp:ListItem>
							<asp:ListItem value="ge">SAR-cross polarization</asp:ListItem>
							<asp:ListItem value="gf">Infometric SAR</asp:ListItem>
							<asp:ListItem value="gg">polarmetric SAR</asp:ListItem>
							<asp:ListItem value="gu">Passive microwave mapping</asp:ListItem>
							<asp:ListItem value="gz">Other microwave data</asp:ListItem>
							<asp:ListItem value="ja">Far ultraviolet</asp:ListItem>
							<asp:ListItem value="jb">Middle ultraviolet</asp:ListItem>
							<asp:ListItem value="jc">Near ultraviolet</asp:ListItem>
							<asp:ListItem value="jv">UlTraviolet combinations</asp:ListItem>
							<asp:ListItem value="jz">Other ultraviolet data</asp:ListItem>
							<asp:ListItem value="ma">Multi-spectral, multidata</asp:ListItem>
							<asp:ListItem value="mb">Multi-temporal</asp:ListItem>
							<asp:ListItem value="mm">Combination of various data types</asp:ListItem>
							<asp:ListItem value="nn">Not applicable</asp:ListItem>
							<asp:ListItem value="pa">Sonar--water depth</asp:ListItem>
							<asp:ListItem value="pb">Sonar--bottom topography images, sidescan</asp:ListItem>
							<asp:ListItem value="pc">Sonar--bottom topography, near surface</asp:ListItem>
							<asp:ListItem value="pd">Sonar--bottom topography, near bottom</asp:ListItem>
							<asp:ListItem value="pe">Seismic surveys</asp:ListItem>
							<asp:ListItem value="pz">Other acoustical data</asp:ListItem>
							<asp:ListItem value="ra">Gravity anomalies (general)</asp:ListItem>
							<asp:ListItem value="rb">Free-air</asp:ListItem>
							<asp:ListItem value="rc">Bouger</asp:ListItem>
							<asp:ListItem value="rd">Isostatic</asp:ListItem>
							<asp:ListItem value="sa">Magnetic field</asp:ListItem>
							<asp:ListItem value="ta">radiometric surveys</asp:ListItem>
							<asp:ListItem value="uu">Unknown</asp:ListItem>
							<asp:ListItem value="zz">Other</asp:ListItem>
							<asp:ListItem value="||"> No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="63px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
