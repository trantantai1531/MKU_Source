<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WShowGroup" CodeFile="WShowGroup.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Emiclib - Phân hệ biên mục - Danh sách các nhóm đã tạo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%">
				<tr class="lbPageTitle">
					<td width="100%" align="center">
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle main-group-form">Danh sách các nhóm đã tạo</asp:Label></td>
				</tr>
				<TR>
					<TD width="100%">
						<asp:DataGrid id="dtgGrp" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
							<Columns>
								<asp:BoundColumn DataField="GroupID" HeaderText="Mã nhóm"></asp:BoundColumn>
								<asp:BoundColumn DataField="strViewLink" HeaderText="Tên nhóm/số tài liệu"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</TD>
				</TR>
				<tr>
					<td align="center" class="lbControlbar">
						<asp:Button Runat="server" ID="btnClose" Text="Đóng (c)"></asp:Button>
					</td>
				</tr>
			</table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
