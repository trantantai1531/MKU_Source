<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WSearchPatron" CodeFile="WSearchPatron.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tìm kiếm thông tin về bạn đọc</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td colspan="2" width="100%" align="center">
						<asp:Label ID="lblMainTitle" Runat="server" CssClass="lbPageTitle" Width="100%">Tìm kiếm thông tin về bạn đọc</asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="1" width="20%" align="right"><asp:Label ID="lblPatronName" Runat="server">Họ và <u>t</u>ên: </asp:Label></td>
					<td colspan="1" width="80%"><asp:TextBox ID="txtPatronName" Runat="server" Width="150px"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="1" width="20%" align="right"><asp:Label ID="lblPatronCode" Runat="server">Số t<u>h</u>ẻ: </asp:Label></td>
					<td colspan="1" width="80%"><asp:TextBox ID="txtPatronCode" Runat="server" Width="150px"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="1" width="20%" align="right"></td>
					<td colspan="1" width="80%"><asp:Button ID="btnSearch" Runat="server" Text="Tìm(m)"></asp:Button>&nbsp;<asp:Button ID="btnReset" Runat="server" Text="Làm lại(i)"></asp:Button>&nbsp;&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(g)"></asp:Button></td>
				</tr>
				<tr>
					<td colspan="2" width="20%" align="right" rowSpan="1">
						<asp:DataGrid id="dgrPatronResult" Width="100%" Runat="server" AllowPaging="True" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="ID" HeaderText="STT">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FullName" HeaderText="Họ tên">
									<HeaderStyle Width="85%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Code" HeaderText="Số thẻ">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
				<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
					<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
					<asp:ListItem Value="2">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
					<asp:ListItem Value="3">Không tìm thấy dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
				</asp:DropDownList>
			</table>
		</form>
	</body>
</HTML>
