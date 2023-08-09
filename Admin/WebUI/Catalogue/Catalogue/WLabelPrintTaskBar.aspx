<%@ Reference Page="~/Acquisition/ACQ/WLabelPrintTaskBar.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WLabelPrintTaskBar" CodeFile="WLabelPrintTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WLabelPrintTaskBar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgColor="#c0c0c0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="FrameNext" border="0">
				<tr>
					<td width="10%">
						<asp:button id="btnPrevious" Runat="server" Text="Trang trước(t)" Width="102px"></asp:button></td>
					<td align="center" width="80%"><asp:label id="lblPages" Runat="server">Tr<u>a</u>ng: </asp:label>&nbsp;<asp:textbox id="txtCurrentPage" Runat="server" Width="40"></asp:textbox>&nbsp;<asp:label id="lblInPages" Runat="server"> trong số </asp:label>&nbsp;<asp:label id="lblMaxPage" Runat="server">0</asp:label>&nbsp;<asp:label id="lblPage" Runat="server"> trang</asp:label>
						<asp:hyperlink id="hrfRequest" runat="server">
							<b>Chọn lại</b></asp:hyperlink></td>
					<td align="right" width="10%">
						<asp:button id="btnNext" Runat="server" Text="Trang tiếp(p)" Width="98px"></asp:button></td>
				</tr>
			</table>
			<input id="hdMaxPage" type="hidden" value="0" name="hdMaxPage" runat="server">
		</form>
	</body>
</HTML>
