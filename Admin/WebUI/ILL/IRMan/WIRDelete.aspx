<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRDelete" CodeFile="WIRDelete.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xóa yêu cầu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" width="100%" cellpadding="3" cellspacing="2">
				<tr Class="lbPageTitle">
					<td>
						<asp:Label ID="lblHeader" Width="100%" Runat="server" cssClass="lbPageTitle">Xóa yêu cầu</asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="lblContent" Runat="server">Xóa một yêu cầu đang trong tiến trình có thể làm ảnh hưởng đến việc xử lý của thư viện đối tác
Đồng thời điều này cũng sẽ ảnh hưởng đến công tác thống kê trong hệ thống</asp:Label>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:Button ID="btnDelete" Runat="server" Text="Xoá(x)" Width="60px"></asp:Button>
						<asp:Button ID="btnCancel" Runat="server" Text="Đóng(d)" Width="71px"></asp:Button>
					</td>
				</tr>
			</table>
			<input id="hidIllID" type="hidden" runat="server">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
				<asp:ListItem Value="3">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
				<asp:ListItem Value="4">Đã xử lý thành công!</asp:ListItem>
				<asp:ListItem Value="5">Bạn có chắc bạn muốn xóa yêu cầu này không?</asp:ListItem>
				<asp:ListItem Value="6">Lỗi trong quá trình xử lý dữ liệu.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
