<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField006ID10" CodeFile="WField006ID10.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField006ID10</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(10);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="lbpageTitle" vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle">006--MIXED MATERIALS</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%">
						<asp:label id="lblLabel2" runat="server">00 Form of material</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="p">Mixed material</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%">
						<asp:label id="lblLabel3" runat="server">01-05 Không định nghĩa</asp:label></TD>
					<td>
						<asp:textbox id="txtField2" runat="server" Enabled="False" Width="88px">#####</asp:textbox></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel4" runat="server">06 <u>D</u>ạng của tư liệu</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField3" runat="server" Width="296px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải một trong các dạng dưới đây</asp:ListItem>
							<asp:ListItem Value="a">a: Microfilm</asp:ListItem>
							<asp:ListItem Value="b">b: Microfiche</asp:ListItem>
							<asp:ListItem Value="c">c: Microopaque</asp:ListItem>
							<asp:ListItem Value="d">d: In khổ lớn</asp:ListItem>
							<asp:ListItem Value="f">f: In nổi (Braille)</asp:ListItem>
							<asp:ListItem Value="r">r: Tái bản từ bản in thông thường</asp:ListItem>
							<asp:ListItem Value="s">s: Điện tử</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server">07-17 Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField4" runat="server" Enabled="False" Width="88px">###########</asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="2" class="lbControlbar">
						<asp:button id="btnUpdate" runat="server" Text="Cập nhật(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="75px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="63px"></asp:button>&nbsp;
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
