<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WExportToXML" CodeFile="WExportToXML.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.Edeliv.clsWEData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xuất khẩu dữ liệu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr class="lbPageTitle">
					<td><asp:label id="lblMainTitle" CssClass="lbPageTitle" Runat="server">Xuất khẩu biểu ghi thư mục ấn phẩm điện tử</asp:label></td>
				</tr>
				<tr>
					<td height="15"></td>
				</tr>
				<tr align="center">
					<td><asp:label id="lblSucces" Runat="server" Visible="False" Font-Bold="True">Xuất khẩu thành công!<BR></asp:label><asp:label id="lblFail" Runat="server" Visible="False" Font-Bold="True">Xuất khẩu thất bại!<BR></asp:label><asp:label id="lblSum" Runat="server" Font-Bold="True"> Tổng số bản ghi đã chọn: </asp:label><asp:label id="lblCount" CssClass="lbAmount" Runat="server"></asp:Label><asp:label id="lblSuccessSum" Runat="server" Font-Bold="True"><BR>Tổng số bản ghi đã xuất khẩu: </asp:label><asp:label id="lblSuccessCount" CssClass="lbAmount" Runat="server"></asp:label><asp:label id="lblFailSum" Runat="server" Font-Bold="True"><BR>Tổng số bản ghi lỗi hoặc chưa được biên mục: </asp:label><asp:label id="lblFailCount" CssClass="lbAmount" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td height="15"></td>
				</tr>
				<tr align="center">
					<td><asp:label id="lblFile" Runat="server" Visible="false" Font-Bold="True">Kích vào đây để tải file về: </asp:label><asp:hyperlink id="lnkFile" CssClass="lbLinkFunction" Runat="server" Visible="False"></asp:hyperlink></td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<TR align="center">
					<TD><asp:button id="btnClose" Runat="server" Text="Đóng (c)"></asp:button><asp:dropdownlist id="ddlLabel" Runat="server" Visible="False" Height="0px" Width="0px">
							<asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="3">Bạn chưa chọn file để xuất khẩu!</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
