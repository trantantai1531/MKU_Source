<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestRemove" CodeFile="WRequestRemove.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xoá yêu cầu đặt mua</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD align="center">
						<asp:Label id="lblPageTitle" CssClass="lbPageTitle" runat="server">Xoá yêu cầu đặt mua</asp:Label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="lblComment" runat="server">Xóa một yêu cầu đang trong tiến trình có thể làm ảnh hưởng đến công tác thống kê trong hệ thống.<br>Bạn có chắc bạn muốn xóa yêu cầu này không?</asp:Label></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button id="btnDelete" runat="server" Width="64px" Text="Xoá(d)"></asp:Button>&nbsp;
						<asp:Button id="btnClose" runat="server" Width="78px" Text="Đóng(o)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
