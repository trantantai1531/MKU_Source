<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID18" CodeFile="WField007ID18.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID18</title>
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
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--MOTION PICTURE</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="40%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="m">Motion picture</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="c">Film catridge</asp:ListItem>
							<asp:ListItem Value="f">Film cassette</asp:ListItem>
							<asp:ListItem Value="r">Film reel</asp:ListItem>
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
						<asp:label id="lblLabel5" runat="server"> 04 - <u>M</u>otion picture presentation format</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Standard sound aperture (reduced frame)</asp:ListItem>
							<asp:ListItem Value="b">Nonanarmorphic (wide-screen)</asp:ListItem>
							<asp:ListItem Value="c">3D</asp:ListItem>
							<asp:ListItem Value="d">Anamophic (wide-screen)</asp:ListItem>
							<asp:ListItem Value="e">Other wide-screen format</asp:ListItem>
							<asp:ListItem Value="f">Standard silent aperture (full name)</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - Sound <u>o</u>n medium or separate</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" ">No sound (silent)</asp:ListItem>
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
						<asp:dropdownlist id="ddlField7" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" ">No sound (silent)</asp:ListItem>
							<asp:ListItem Value="a">Optical sound track on motion picture film</asp:ListItem>
							<asp:ListItem Value="b">Marnetic sound track on motion picture film</asp:ListItem>
							<asp:ListItem Value="c">Marnetic audio tape in cartridge</asp:ListItem>
							<asp:ListItem Value="d">Sound disc</asp:ListItem>
							<asp:ListItem Value="e">Marnetic audio tape on reel</asp:ListItem>
							<asp:ListItem Value="f">Marnetic audio tape in cassette</asp:ListItem>
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
						<asp:label id="Label3" runat="server"> 07 - <u>D</u>imensions</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Standard 8mm.</asp:ListItem>
							<asp:ListItem Value="b">Super 8mm./single 8mm.</asp:ListItem>
							<asp:ListItem Value="c">9.5 mm.</asp:ListItem>
							<asp:ListItem Value="d">16 mm.</asp:ListItem>
							<asp:ListItem Value="e">28 mm.</asp:ListItem>
							<asp:ListItem Value="f">35 mm.</asp:ListItem>
							<asp:ListItem Value="g">70 mm.</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 08 - Configuration of <u>p</u>layback channels</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="k">Mixed</asp:ListItem>
							<asp:ListItem Value="m">Nonaural</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="q">Quadraphonic, multichannel, or surround</asp:ListItem>
							<asp:ListItem Value="s">Stereophonic</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label6" runat="server"> 09 - Production <u>e</u>lements</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField10" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Workprint</asp:ListItem>
							<asp:ListItem Value="b">Trims</asp:ListItem>
							<asp:ListItem Value="c">Outtakes</asp:ListItem>
							<asp:ListItem Value="d">Rushes</asp:ListItem>
							<asp:ListItem Value="e">Mixing tracks</asp:ListItem>
							<asp:ListItem Value="f">Title bands/ntertitle rolls</asp:ListItem>
							<asp:ListItem Value="g">Production rolls</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label7" runat="server"> 10 - Positive/negative <u>a</u>spect</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField11" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Positive</asp:ListItem>
							<asp:ListItem Value="b">Negative</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label8" runat="server"> 11 - <u>G</u>eneration</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField12" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="d">Duplicate</asp:ListItem>
							<asp:ListItem Value="e">Master</asp:ListItem>
							<asp:ListItem Value="o">Original</asp:ListItem>
							<asp:ListItem Value="r">Reference print/Viewing copy</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label9" runat="server"> 12 - <u>B</u>ase of film</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField13" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Safety base, undetermined</asp:ListItem>
							<asp:ListItem Value="c">Safety base, acetate undetermined</asp:ListItem>
							<asp:ListItem Value="d">Safety base, diacetate</asp:ListItem>
							<asp:ListItem Value="p">Safety base, polyester</asp:ListItem>
							<asp:ListItem Value="r">Safety base, mixed</asp:ListItem>
							<asp:ListItem Value="t">Safety base, trialcetate</asp:ListItem>
							<asp:ListItem Value="i">Nitrate base</asp:ListItem>
							<asp:ListItem Value="m">Mixed base (nitrate and safety)</asp:ListItem>
							<asp:ListItem Value="n">Not aplicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label10" runat="server"> 13 - <u>R</u>efined categories of color</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField14" runat="server" Width="160px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">3 layer color</asp:ListItem>
							<asp:ListItem Value="b">2 layer color, single trip</asp:ListItem>
							<asp:ListItem Value="c">Undetermined 2 color</asp:ListItem>
							<asp:ListItem Value="d">Undetermined 3 color</asp:ListItem>
							<asp:ListItem Value="e">3 trip color</asp:ListItem>
							<asp:ListItem Value="f">2 trip color</asp:ListItem>
							<asp:ListItem Value="g">Red trip</asp:ListItem>
							<asp:ListItem Value="h">Blue or green trip</asp:ListItem>
							<asp:ListItem Value="i">Cyan trip</asp:ListItem>
							<asp:ListItem Value="j">Magenta trip</asp:ListItem>
							<asp:ListItem Value="k">Yellow trip</asp:ListItem>
							<asp:ListItem Value="l">S E N 2</asp:ListItem>
							<asp:ListItem Value="m">S E N 3</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="p">sepia tone</asp:ListItem>
							<asp:ListItem Value="q">Other tone</asp:ListItem>
							<asp:ListItem Value="r">Tint</asp:ListItem>
							<asp:ListItem Value="s">Tint and toned</asp:ListItem>
							<asp:ListItem Value="t">Stencil color</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="v">Hand colored</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label11" runat="server"> 14 - <u>K</u>ind of color stock or print</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField15" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Imbibition dye transfer prints</asp:ListItem>
							<asp:ListItem Value="b">Three layer stock</asp:ListItem>
							<asp:ListItem Value="c">Three layer stock, low fade</asp:ListItem>
							<asp:ListItem Value="d">Duplitized stock</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label12" runat="server"> 15 - Deterioration s<u>t</u>age</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField16" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Non apparent</asp:ListItem>
							<asp:ListItem Value="b">Nitrate: suspicious odor</asp:ListItem>
							<asp:ListItem Value="c">Nitrate: purgent odor</asp:ListItem>
							<asp:ListItem Value="d">Nitrate: brownish, discoloration, fading, dusty</asp:ListItem>
							<asp:ListItem Value="e">Nitrate: sticky</asp:ListItem>
							<asp:ListItem Value="f">Nitrate: frothy, bubbles, blisters</asp:ListItem>
							<asp:ListItem Value="g">Nitrate: congealed</asp:ListItem>
							<asp:ListItem Value="h">Nitrate: powder</asp:ListItem>
							<asp:ListItem Value="k">Non-Nitrate: detectable diterioration (diacetate odor)</asp:ListItem>
							<asp:ListItem Value="l">Non-Nitrate: advanced diterioration</asp:ListItem>
							<asp:ListItem Value="m">Non-Nitrate: disaster</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>

				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label13" runat="server"> 16 - Compl<u>e</u>teness</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField17" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="c">Complete</asp:ListItem>
							<asp:ListItem Value="i">incomplete</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label14" runat="server"> 17-22 - Film <u>i</u>nspection date</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField18" runat="server" Width="120px"></asp:textbox></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" CssClass="lbButton" Text="Nhập(u)" Width="75px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" CssClass="lbButton" Text="Ðặt lại(r)" Width="75px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" CssClass="lbButton" Text="Xem(v)" Width="65px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
