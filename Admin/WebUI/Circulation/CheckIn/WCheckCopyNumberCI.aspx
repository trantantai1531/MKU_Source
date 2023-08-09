<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckCopyNumberCI" EnableViewStateMAC="False" CodeFile="WCheckCopyNumberCI.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckCopyNumber</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle" Width="100%">Kiểm tra thông tin ấn phẩm</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblReason" runat="server" CssClass="lbLabel">Đang kiểm tra tình trạng ấn phẩm...&nbsp;</asp:label><b><asp:label id="lblReasonInfor" runat="server" CssClass="lbLabel"></asp:label></b></TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<INPUT id="txtPatronCode" type="hidden" runat="server"> 
			<INPUT id="txtCopyNumber" type="hidden" runat="server">
			<INPUT id="txtCheckInDate" type="hidden" runat="server"> 
			<INPUT id="hidAutoPaidFees" type="hidden" runat="server">
			<asp:label id="lblMsg1" runat="server" Visible="False">Không tồn tại ĐKCB trong danh sách ấn phẩm cho mượn:&nbsp;</asp:label><asp:label id="lblMsg2" runat="server" Visible="False">Ấn phẩm chưa sẵn sàng phục vụ (bị khoá hoặc chưa đưa ra lưu thông)</asp:label><asp:label id="lblMsg4" runat="server" Visible="False">Ấn phẩm đang được bạn đọc khác đặt chỗ</asp:label><asp:label id="lblMsg5" runat="server" Visible="False">Ấn phẩm này thuộc kho mà cán bộ thư viện không có quyền quản lý</asp:label><asp:label id="lblMsg6" runat="server" Visible="False">Bạn đọc không được mượn trả ấn phẩm tại những kho mà cán bộ thư viện quản lý</asp:label><asp:label id="lblSubmitForm" runat="server" CssClass="lbLabel"></asp:label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="false" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Không tồn tại ĐKCB trong danh sách ấn phẩm cho mượn:&nbsp;</asp:ListItem>
				<asp:ListItem Value="3">Ấn phẩm chưa sẵn sàng phục vụ (bị khoá hoặc chưa đưa ra lưu thông)</asp:ListItem>
				<asp:ListItem Value="4">Ấn phẩm đang được bạn đọc khác đặt chỗ</asp:ListItem>
				<asp:ListItem Value="5">Ấn phẩm này thuộc kho mà cán bộ thư viện không có quyền quản lý</asp:ListItem>
				<asp:ListItem Value="6">Bạn đọc không được mượn trả ấn phẩm tại những kho mà cán bộ thư viện quản lý</asp:ListItem>
			</asp:DropDownList></form>
	</body>
</HTML>
