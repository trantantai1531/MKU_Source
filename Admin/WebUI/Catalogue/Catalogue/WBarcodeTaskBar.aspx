<%@ Reference Page="~/Acquisition/ACQ/WBarcodeTaskBar.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WBarcodeTaskBar" CodeFile="WBarcodeTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBarcodeTaskBar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="FrameNext" border="0">
				<tr>
					<td width="10%"><asp:button cssclass="lbButton" id="btnPrevious" Text="Trang trước(t)" Runat="server"></asp:button></td>
					<td align="center" width="80%"><asp:label cssclass="lbLabel" id="lblPages" Runat="server" style="Z-INDEX: 101">Tr<u>a</u>ng thứ: </asp:label>&nbsp;<asp:textbox cssclass="lbTextbox" id="txtCurrentPage" Runat="server" Width="40" style="Z-INDEX: 102"></asp:textbox>&nbsp;<asp:label cssclass="lbLabel" id="lblInPages" Runat="server">trong số</asp:label>&nbsp;<asp:label cssclass="lbLabel" id="lblMaxPage" Runat="server"> 0</asp:label>&nbsp;<asp:label cssclass="lbLabel" id="lblPage" Runat="server"> trang</asp:label>&nbsp;&nbsp;&nbsp;
						<asp:HyperLink id="hrfRequest" style="display: none;" runat="server" CssClass="lbLinkFunction"> Yêu cầu khác</asp:HyperLink></td>
					<td align="right" width="10%"><asp:button cssclass="lbButton" id="btnNext" Text="Trang tiếp(p)" Runat="server"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
