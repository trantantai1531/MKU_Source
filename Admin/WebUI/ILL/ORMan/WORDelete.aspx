<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORDelete" CodeFile="WORDelete.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR>
					<TD>
						<asp:Label ID="lblTitleFromName" Runat="server" Width="100%" CssClass="lbPageTitle">Xóa yêu cầu</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label ID="lblAnnouncement" Runat="server" Width="100%">Xóa một yêu cầu đang trong tiến trình có thể làm ảnh hưởng đến việc xử lý của thư viện đối tác, đồng thời điều này cũng sẽ ảnh hưởng đến công tác thống kê trong hệ thống</asp:Label>
						<asp:Label ID="lblCheck" Runat="server" Visible="False">Bạn có chắc chắn xoá yêu cầu này không?</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button ID="btnDelete" Runat="server" Text="  Có (c)"></asp:Button>&nbsp;
						<asp:Button ID="btnNoDelete" Runat="server" Text=" Không (k)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Xoá yêu cầu đi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
