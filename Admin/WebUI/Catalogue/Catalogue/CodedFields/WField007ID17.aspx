<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID17" CodeFile="WField007ID17.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID17</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(17);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--NONPROJECTED GRAPHIC</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="40%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="k">Nonprojected graphic</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="c">Collage</asp:ListItem>
							<asp:ListItem Value="d">Drawing</asp:ListItem>
							<asp:ListItem Value="e">Painting</asp:ListItem>
							<asp:ListItem Value="f">Photomecanical print</asp:ListItem>
							<asp:ListItem Value="g">Photonegative</asp:ListItem>
							<asp:ListItem Value="h">Photoprint</asp:ListItem>
							<asp:ListItem Value="i">Picture</asp:ListItem>
							<asp:ListItem Value="j">Print</asp:ListItem>
							<asp:ListItem Value="l">Technical drawing</asp:ListItem>
							<asp:ListItem Value="n">Chart</asp:ListItem>
							<asp:ListItem Value="o">Flash card</asp:ListItem>
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
						<asp:textbox id="txtField3" runat="server" CssClass="lbTextBox" Width="88px" Enabled="False">#</asp:textbox></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 10px" vAlign="top">
						<asp:label id="lblLabel4" runat="server"> 03 - <u>C</u>olor</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">One color</asp:ListItem>
							<asp:ListItem Value="b">Black-and-white</asp:ListItem>
							<asp:ListItem Value="c">Multicolored</asp:ListItem>
							<asp:ListItem Value="h">Hand colored</asp:ListItem>
							<asp:ListItem Value="m">Mixed</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - <u>P</u>rimary support material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Canvas</asp:ListItem>
							<asp:ListItem Value="b">Bristol board</asp:ListItem>
							<asp:ListItem Value="c">Canvas/illustraion board</asp:ListItem>
							<asp:ListItem Value="d">Glass</asp:ListItem>
							<asp:ListItem Value="e">Synthetic</asp:ListItem>
							<asp:ListItem Value="f">Skin</asp:ListItem>
							<asp:ListItem Value="g">Textile</asp:ListItem>
							<asp:ListItem Value="h">Metal</asp:ListItem>
							<asp:ListItem Value="m">Mixed collection</asp:ListItem>
							<asp:ListItem Value="o">Paper</asp:ListItem>
							<asp:ListItem Value="p">Plaster</asp:ListItem>
							<asp:ListItem Value="q">Hardboard</asp:ListItem>
							<asp:ListItem Value="r">Porceland</asp:ListItem>
							<asp:ListItem Value="s">Stone</asp:ListItem>
							<asp:ListItem Value="t">Wood</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - Secondary support <u>m</u>aterial</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" ">No secondary support</asp:ListItem>
							<asp:ListItem Value="a">Canvas</asp:ListItem>
							<asp:ListItem Value="b">Bristol board</asp:ListItem>
							<asp:ListItem Value="c">Canvas/illustraion board</asp:ListItem>
							<asp:ListItem Value="d">Glass</asp:ListItem>
							<asp:ListItem Value="e">Synthetic</asp:ListItem>
							<asp:ListItem Value="f">Skin</asp:ListItem>
							<asp:ListItem Value="g">Textile</asp:ListItem>
							<asp:ListItem Value="h">Metal</asp:ListItem>
							<asp:ListItem Value="m">Mixed collection</asp:ListItem>
							<asp:ListItem Value="o">Paper</asp:ListItem>
							<asp:ListItem Value="p">Plaster</asp:ListItem>
							<asp:ListItem Value="q">Hardboard</asp:ListItem>
							<asp:ListItem Value="r">Porceland</asp:ListItem>
							<asp:ListItem Value="s">Stone</asp:ListItem>
							<asp:ListItem Value="t">Wood</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(l)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(x)" Width="65px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
