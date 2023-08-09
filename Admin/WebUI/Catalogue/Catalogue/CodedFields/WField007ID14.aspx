<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID14" CodeFile="WField007ID14.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID14</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(11);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR class="lbpageTitle" vAlign="top">
					<TD vAlign="top" colSpan="2"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--TACTILE MATERIAL</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%"><asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="f">Tactile material</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
					<td><asp:dropdownlist id="ddlField2" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Moon</asp:ListItem>
							<asp:ListItem Value="b">Braille</asp:ListItem>
							<asp:ListItem Value="c">Combination</asp:ListItem>
							<asp:ListItem Value="d">Tactile, with nothing write system</asp:ListItem>
							<asp:ListItem Value="u">Unspecified</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel3" runat="server"> 02 - Undefined; contains a blank (#) or a fill character ( | ).</asp:label></TD>
					<td><asp:textbox id="txtField3" runat="server" Width="120px" Enabled="False">#</asp:textbox></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel4" runat="server"> 03-04 - Class of <u>b</u>raille writing</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField4" runat="server" Width="120px"></asp:textbox><asp:dropdownlist id="ddlTemp4" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Literary braille</asp:ListItem>
							<asp:ListItem Value="b">Format code braille</asp:ListItem>
							<asp:ListItem Value="c">Mathematics and scientific braille</asp:ListItem>
							<asp:ListItem Value="d">Computer braille</asp:ListItem>
							<asp:ListItem Value="e">Music braille</asp:ListItem>
							<asp:ListItem Value="m">Multiple braille types</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server"> 05 - L<u>e</u>vel of contraction</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField5" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Uncontracted</asp:ListItem>
							<asp:ListItem Value="b">Contracted</asp:ListItem>
							<asp:ListItem Value="m">Combination</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label1" runat="server"> 06-08 - Braille <u>m</u>usic format</asp:label></TD>
					<td><asp:textbox id="txtField6" runat="server" Width="120px"></asp:textbox><asp:dropdownlist id="ddlTemp6" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Bar over bar</asp:ListItem>
							<asp:ListItem Value="b">Bar by bar</asp:ListItem>
							<asp:ListItem Value="c">Line over line</asp:ListItem>
							<asp:ListItem Value="d">Paragraph</asp:ListItem>
							<asp:ListItem Value="e">Single line</asp:ListItem>
							<asp:ListItem Value="f">Section by section</asp:ListItem>
							<asp:ListItem Value="g">Line by line</asp:ListItem>
							<asp:ListItem Value="h">Open score</asp:ListItem>
							<asp:ListItem Value="i">Spanner short form scoring</asp:ListItem>
							<asp:ListItem Value="j">Short form scoring</asp:ListItem>
							<asp:ListItem Value="k">Outline</asp:ListItem>
							<asp:ListItem Value="l">Vertical score</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label2" runat="server"> 09 - Specific <u>p</u>hysical characteristics</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField7" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">print/braille</asp:ListItem>
							<asp:ListItem Value="b">Jumbo or enlarged braille</asp:ListItem>
							<asp:ListItem Value="n">Not applicable</asp:ListItem>
							<asp:ListItem Value="u">Unknown</asp:ListItem>
							<asp:ListItem Value="z">Other</asp:ListItem>
							<asp:ListItem Value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top" colSpan="2"><asp:button id="btnUpdate" runat="server" Width="83px" Text="Nhập(u)"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Width="83px" Text="Ðặt lại(l)"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Width="65px" Text="Xem(x)"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
