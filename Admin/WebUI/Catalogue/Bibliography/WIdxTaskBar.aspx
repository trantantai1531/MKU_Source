<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIdxTaskBar" CodeFile="WIdxTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIdxTaskBar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="1" cellspacing="0">
				<tr>
					<td width="50%">
						<asp:button id="btnFirst" runat="server" Text="|<" Width="22px"></asp:button>
						<asp:button id="btnBack" runat="server" Text="< " Width="22px"></asp:button>
						<asp:label id="lblPagei" runat="server">Trang thứ:</asp:label>&nbsp;
						<asp:textbox id="txtCurrentpage" runat="server" Width="40px">1</asp:textbox>&nbsp;
						<asp:label id="lblOF" runat="server">trong số</asp:label>&nbsp;
						<asp:label id="lblTotal" runat="server">1</asp:label>
						<asp:button id="btnNext" runat="server" Text=" >" Width="22px"></asp:button>
						<asp:button id="btnLast" runat="server" Text=">|" Width="22px"></asp:button>&nbsp;
					</td>
					<td >
						<asp:textbox id="txtFieldSToIndex" style="display: none" runat="server" Width="150px"></asp:textbox>&nbsp;
						<asp:button id="btnIdx" runat="server"  style="display: none" Text="Đánh chỉ mục(c)" Width="120px"></asp:button></td>
					<td align="right" >
						<asp:HyperLink id="lnkOtherPrint" runat="server">Yêu cầu khác</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Dữ liệu không phải là số!</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="2">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="3">Ngoài phạm vi kiểm tra</asp:ListItem>
			</asp:DropDownList>
			<input id="hidMaxId" runat="server" type="hidden" value="0">
		</form>
	</body>
</HTML>
