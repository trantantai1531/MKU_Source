<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WDictionary" CodeFile="WDictionary.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thêm mới mục từ</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="5" leftmargin="0">
		<form id="Dictionary" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colspan="2" align="center">
						<asp:Label id="lblTitle" runat="server" CssClass="lbPageTitle"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblDictionary" runat="server"></asp:label></TD>
					<TD>
						<asp:textbox id="txtDictionary" runat="server" Width="150px" MaxLength=50></asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD></TD>
					<TD>
						<asp:Button id="btnAdd" runat="server" Text="Thêm(a)" Width="70px"></asp:Button>&nbsp;&nbsp;
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" Width="70px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Nước</asp:ListItem>
				<asp:ListItem Value="3">Khoa</asp:ListItem>
				<asp:ListItem Value="4">Thêm mới:</asp:ListItem>
				<asp:ListItem Value="5">Dân tộc</asp:ListItem>
				<asp:ListItem Value="6">Trình độ</asp:ListItem>
				<asp:ListItem Value="7">Nghề nghiệp</asp:ListItem>
				<asp:ListItem Value="8">Tỉnh</asp:ListItem>
				<asp:ListItem Value="9">Bạn chưa nhập đủ thông tin!</asp:ListItem>
				<asp:ListItem Value="10">Mục từ đã tồn tại</asp:ListItem>
				<asp:ListItem Value="11">Cập nhật không thành công</asp:ListItem>
				<asp:ListItem Value="12">Trường</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
