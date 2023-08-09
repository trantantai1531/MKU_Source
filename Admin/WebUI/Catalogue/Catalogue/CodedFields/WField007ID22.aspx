<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField007ID22" CodeFile="WField007ID22.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField007ID22</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(22);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 007--TEXT</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="35%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>C</u>ategory of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="t">Text</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - <u>S</u>pecific material designation</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem value="a">Regular print</asp:ListItem>
							<asp:ListItem value="b">Large print</asp:ListItem>
							<asp:ListItem value="c">Braille</asp:ListItem>
							<asp:ListItem value="d">Text in looseleaf binder</asp:ListItem>
							<asp:ListItem value="z">Other</asp:ListItem>
							<asp:ListItem value="u">Unspecified</asp:ListItem>
							<asp:ListItem value="|">No attempt to code</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="63px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
