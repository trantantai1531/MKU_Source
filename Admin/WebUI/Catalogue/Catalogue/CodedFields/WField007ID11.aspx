<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID11" CodeFile="WField007ID11.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID11</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(11);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--MAP</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Map</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="d">Atlas</asp:ListItem>
							<asp:ListItem Value="g">Diagram</asp:ListItem>
							<asp:ListItem Value="j">Map</asp:ListItem>
							<asp:ListItem Value="k">Profile</asp:ListItem>
							<asp:ListItem Value="q">Model</asp:ListItem>
							<asp:ListItem Value="r">Remote-sensing image</asp:ListItem>
							<asp:ListItem Value="s">Section</asp:ListItem>
							<asp:ListItem Value="u">Unspecified</asp:ListItem>
							<asp:ListItem Value="y">View</asp:ListItem>
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
						<asp:dropdownlist id="ddlField4" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">One color</asp:ListItem>
							<asp:ListItem Value="c">Multicolored</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - <u>P</u>hysical medium</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Paper</asp:ListItem>
							<asp:ListItem Value="b">Wood</asp:ListItem>
							<asp:ListItem Value="c">Stone</asp:ListItem>
							<asp:ListItem Value="d">Metal</asp:ListItem>
							<asp:ListItem Value="e">Synthetic</asp:ListItem>
							<asp:ListItem Value="f">Skin</asp:ListItem>
							<asp:ListItem Value="g">Textile</asp:ListItem>
							<asp:ListItem Value="j">Glass</asp:ListItem>
							<asp:ListItem Value="p">Plaster</asp:ListItem>
							<asp:ListItem Value="q">Flexible base photographic, positive</asp:ListItem>
							<asp:ListItem Value="r">Flexible base photographic, negative</asp:ListItem>
							<asp:ListItem Value="s">Non-flexible base photographic, positive</asp:ListItem>
							<asp:ListItem Value="t">Non-flexible base photographic, negative</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="y">Other photographic medium</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - Type of <u>r</u>eproduction</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="f">Facsimile</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 06 - Production/reproduction <u>d</u>etails</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField7" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Photography, blueline print</asp:ListItem>
							<asp:ListItem Value="b">Photocopy</asp:ListItem>
							<asp:ListItem Value="c">Pre-production</asp:ListItem>
							<asp:ListItem Value="d">Film</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 07 - <u>P</u>ositive/negative aspect</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField8" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Positive</asp:ListItem>
							<asp:ListItem Value="b">Negative</asp:ListItem>
							<asp:ListItem Value="m">Mixed polarity</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2" align="center"><asp:button id="btnUpdate" runat="server" Text="Cập nhật (a)"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Hủy bỏ (h)"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(e)"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(n)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
