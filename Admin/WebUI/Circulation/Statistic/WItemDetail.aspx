<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WItemDetail" CodeFile="WItemDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Mô tả tài liệu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="5" topMargin="0" rightMargin="5">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="2" cellspacing="0" width="100%">
				<tr>
					<td>
						<asp:Table ID="tblMainInfor" Runat="server" Width="100%" CellPadding="2" CellSpacing="0"></asp:Table></td>
				</tr>
				<tr class="lbControlBar">
					<td align="center">
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="64px"></asp:Button></td>
				</tr>
			</table>
			<asp:label id="lblFieldLabel1" Runat="server" Visible="False" CssClass="lbLabel">Vật mang tin: </asp:label>
			<asp:label id="lblFieldLabel2" Runat="server" Visible="False" CssClass="lbLabel">Độ mật: </asp:label>
			<asp:label id="lblFieldLabel3" Runat="server" Visible="False" CssClass="lbLabel">Cấp độ mô tả thư mục: </asp:label>
			<asp:label id="lblFieldLabel4" Runat="server" Visible="False" CssClass="lbLabel">Chỉ số ISBN: </asp:label>
			<asp:label id="lblFieldLabel5" Runat="server" Visible="False" CssClass="lbLabel">Dạng tài liệu: </asp:label>
			<asp:label id="lblFieldLabel6" Runat="server" Visible="False" CssClass="lbLabel">Địa chỉ xuất bản: </asp:label>
			<asp:label id="lblFieldLabel7" Runat="server" Visible="False" CssClass="lbLabel">Khung phân loại: </asp:label>
			<asp:label id="lblFieldLabel8" Runat="server" Visible="False" CssClass="lbLabel">Mã xếp giá: </asp:label>
			<asp:label id="lblFieldLabel9" Runat="server" Visible="False" CssClass="lbLabel">Các tác giả: </asp:label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
