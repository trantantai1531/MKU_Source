<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID13" CodeFile="WField007ID13.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID13</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(13);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR vAlign="top" class="lbpageTitle">
						<TD vAlign="top" colSpan="2">
							<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--GLOBE</asp:label></TD>
					</TR>
					<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
						onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
						<TD vAlign="top" width="45%">
							<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
						<TD vAlign="top">
							<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
								<asp:ListItem Value=" "></asp:ListItem>
								<asp:ListItem Value="d">Globe</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
						onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
						<TD vAlign="top">
							<asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
						<td>
							<asp:dropdownlist id="ddlField2" runat="server" Width="150px">
								<asp:ListItem Value=" "></asp:ListItem>
								<asp:ListItem Value="a">Celestial globe</asp:ListItem>
								<asp:ListItem Value="b">Planetary or lunar globe</asp:ListItem>
								<asp:ListItem Value="c">Terrestrial globe</asp:ListItem>
								<asp:ListItem Value="e">Earth moon globe</asp:ListItem>
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
						<TD vAlign="top">
							<asp:label id="lblLabel4" runat="server"> 03 - <u>C</u>olor</asp:label></TD>
						<TD vAlign="top">
							<asp:dropdownlist id="ddlField4" runat="server" Width="120px">
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
							<asp:dropdownlist id="ddlField5" runat="server" Width="120px">
								<asp:ListItem Value=" "></asp:ListItem>
								<asp:ListItem Value="a">Paper</asp:ListItem>
								<asp:ListItem Value="b">Wood</asp:ListItem>
								<asp:ListItem Value="c">Stone</asp:ListItem>
								<asp:ListItem Value="d">Metal</asp:ListItem>
								<asp:ListItem Value="e">Synthetic</asp:ListItem>
								<asp:ListItem Value="f">Skin</asp:ListItem>
								<asp:ListItem Value="g">Textile</asp:ListItem>
								<asp:ListItem Value="p">Plaster</asp:ListItem>
								<asp:ListItem Value="u">Unknown</asp:ListItem>
								<asp:ListItem Value="z">Other</asp:ListItem>
								<asp:ListItem Value="|">No attempt to code</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
						onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
						<TD vAlign="top">
							<asp:label id="Label1" runat="server"> 05 - <u>T</u>ype of reproduction</asp:label></TD>
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
					<TR vAlign="top" class="lbControlBar">
						<TD vAlign="top" colSpan="2">
							<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="73px"></asp:button>&nbsp;
							<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="73px"></asp:button>&nbsp;
							<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="65px"></asp:button>
							&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
