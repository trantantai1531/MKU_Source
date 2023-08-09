<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WSimpleSearchResultTaskBar" CodeFile="WSimpleSearchResultTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSimpleSearchResultTaskBar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" width="100%" border="0">
				<tr bgColor="#FDFDC9">
					<td width="60%"><asp:button id="btnFirst" runat="server" Text="|<"></asp:button>&nbsp;<asp:button id="btnBack" runat="server" Text=" <"></asp:button>&nbsp;
						<asp:label id="lblReci" runat="server"><u>b</u>ản ghi thứ: </asp:label>&nbsp;
						<asp:textbox id="txtRec" runat="server" Width="60px">1</asp:textbox>&nbsp;
						<asp:label id="lblOf" runat="server"> trong</asp:label>&nbsp;
						<asp:label id="lblSumRec" runat="server">0</asp:label>&nbsp;
						<asp:label id="lblSumRecs" runat="server"> bản ghi tìm thấy</asp:label>&nbsp;&nbsp;
						<asp:button id="btnNext" runat="server" Text="> "></asp:button>&nbsp;<asp:button id="btnEnd" runat="server" Text=">|"></asp:button>&nbsp;<asp:button style="display:none" id="btnNew" runat="server" Text=">*"></asp:button></td>
					<td align="right">
                        <asp:button id="btnSearch" runat="server" Width="90px" Text="Tìm mới(s)"></asp:button>&nbsp;
                        <asp:button id="btnEdit" runat="server" Width="60px" Text="Sửa(u)" Height="26px"></asp:button>&nbsp;
                        <asp:button id="btnResetPass" runat="server"  Width="120px" Text="Reset PassWord" Visible="false" ></asp:button>&nbsp;
                        <asp:button id="btnDelete" runat="server" Width="60px" Text="Xoá(d)" ></asp:button>

					</td>
				</tr>
			</table>
			<input id="hidPatronTotal" type="hidden" value="0" runat="server"> <input id="hidCurRec" type="hidden" runat="server" value="0">
			<asp:dropdownlist id="ddlLabel" Width="0" Visible="False" Runat="server">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Thứ tự bản ghi phải là số!</asp:ListItem>
				<asp:ListItem Value="3">Không thể xoá được hồ sơ bạn đọc đang mượn ấn phẩm của Thư viện!</asp:ListItem>
				<asp:ListItem Value="4">Chọn OK nếu bạn thực sự muốn xoá hồ sơ bạn đọc này!</asp:ListItem>
				<asp:ListItem Value="5">Xoá hồ sơ bạn đọc</asp:ListItem>
				<asp:ListItem Value="6">Vượt qua dưới hạn thứ tự bản ghi cho phép !</asp:ListItem>
				<asp:ListItem Value="7">Xoá hồ sơ bạn đọc thành công</asp:ListItem>
                <asp:ListItem Value="8">Chọn OK để reset PassWord mặc định cho bạn đọc!</asp:ListItem>
                <asp:ListItem Value="9">Reset password thành công!</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
