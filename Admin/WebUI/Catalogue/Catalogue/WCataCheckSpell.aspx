<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataCheckSpell" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCataCheckSpell.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kiểm tra lỗi chính tả</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <style>
            #txtMyField {
                height: auto;
            }
        </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="10" leftmargin="5">
		<form id="frm" method="post" runat="server">
			<TABLE id="tbl" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center" class="lbPageTitle">
						<asp:Label cssclass="main-group-form" id="lblTitle" runat="server">Kiểm tra chính tả nội dung bản ghi biên mục</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:TextBox id="txtMyField" runat="server"  Width="100%" Rows="15" TextMode="MultiLine"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button id="btnSpell" runat="server" Text="Kiểm tra(c)"></asp:Button>
						<asp:Button id="btnUpdate" runat="server" Text="Cập nhật(u)"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
