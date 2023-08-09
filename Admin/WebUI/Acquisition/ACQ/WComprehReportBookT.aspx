<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WComprehReportBookT" CodeFile="WComprehReportBookT.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WComprehReportBookT</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="FrameNext" border="0" cellpadding="2" cellspacing="0">
				<tr class="lbControlBar">
					<td width="10%">
						<asp:button id="btnPrevious" Runat="server" Text="Trang trước(p)" Width="108px"></asp:button></td>
					<td align="center" width="80%">
						<asp:label id="lblPages" Runat="server">Tr<u>a</u>ng:</asp:label>&nbsp;<asp:textbox id="txtCurrentPage" Runat="server" Width="40"></asp:textbox>&nbsp;<asp:label id="lblInPages" Runat="server">trong số</asp:label>&nbsp;<asp:label id="lblMaxPage" Runat="server">0</asp:label>&nbsp;<asp:label id="lblPage" Runat="server">trang</asp:label>
						<asp:hyperlink id="hrfRequest" runat="server">
							<b>Chọn lại</b></asp:hyperlink></td>
					<td align="right" width="10%"><asp:button id="btnNext" Runat="server" Text="Trang tiếp(n)" Width="108px"></asp:button></td>
				</tr>
			</table>
			<input id="hdMaxPage" type="hidden" value="0" name="hdMaxPage" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible=False Width=0 Height=0>
				<asp:ListItem Value="0">Ngoài phạm vi số trang cho phép !</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở trang đầu tiên !</asp:ListItem>
				<asp:ListItem Value="2">Bạn đang ở trang cuối cùng !</asp:ListItem>
				<asp:ListItem Value="3">Không đúng kiểu số !</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
