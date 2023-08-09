<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCheckExistItem" CodeFile="WCheckExistItem.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kiểm tra ấn phẩm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMain" cellSpacing="1" cellPadding="3" width="100%" border="0">
				<TR>
					<TD align="center" width="100%" height="100%">
						<asp:Label id="lblNotExist" runat="server" Visible="False">Không có ấn phẩm nào trong cơ sở dữ liệu có nhan đề như trên!</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" height="100%"><A name="avail"></A>
						<asp:Label id="lblAvailable1" runat="server">Đang có</asp:Label>&nbsp;<asp:hyperlink id="lnkOrdered1" runat="server">Đang đặt</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD width="100%" height="100%"><asp:table id="tblItemAvailable" runat="server" GridLines="Both" BorderWidth="1px" CellPadding="3"
							CellSpacing="0" BorderColor="#400000" width="100%"></asp:table></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" height="100%"><A name="ordered"></A></A><asp:hyperlink id="lnkAvailable2" runat="server">Đang có</asp:hyperlink>&nbsp;
						<asp:Label id="lblOrdered2" runat="server">Đang đặt</asp:Label></TD>
				</TR>
				<TR>
					<TD width="100%" height="100%"><asp:table id="tblItemOrdered" runat="server" GridLines="Both" BorderWidth="1px" CellPadding="3"
							CellSpacing="0" BorderColor="#400000" width="100%"></asp:table></TD>
				</TR>
				<TR>
					<TD width="100%" height="100%" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="btnClose" runat="server" Text="Đóng (d)"></asp:Button>
					</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" height="100%">
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="2">Dùng lại thông tin thư mục</asp:ListItem>
							<asp:ListItem Value="3">STT</asp:ListItem>
							<asp:ListItem Value="4">Dạng tài liệu</asp:ListItem>
							<asp:ListItem Value="5">Nhan đề</asp:ListItem>
							<asp:ListItem Value="6">Số bản</asp:ListItem>
							<asp:ListItem Value="7">Đơn đặt</asp:ListItem>
							<asp:ListItem Value="8">Số bản hiện có</asp:ListItem>
							<asp:ListItem Value="9">Số bản còn rỗi</asp:ListItem>
							<asp:ListItem Value="10">Số bản đang mượn</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
