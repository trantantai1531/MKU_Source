<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestChangeStat" CodeFile="WRequestChangeStat.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thay đổi trạng thái của yêu cầu đặt mua</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD colSpan="2">
						<asp:Label id="lblPageTitle" CssClass="lbPageTitle" runat="server">Thay đổi trạng thái của yêu cầu đặt mua</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right" width="30%">
						<asp:Label id="lblChangeStatus" runat="server"><u>Đ</u>ổi trạng thái thành:</asp:Label>
					</TD>
					<td>
						<asp:DropDownList id="ddlStatus" runat="server">
							<asp:ListItem Value="6">Đã hoàn thành giao dịch</asp:ListItem>
							<asp:ListItem Value="7">Đã trả tiền cho giao dịch</asp:ListItem>
						</asp:DropDownList>
					</td>
				</TR>
				<TR class="lbControlBar">
					<TD align="center" colspan="2">
						<asp:Button id="btnChange" Text="Thay đổi(c)" runat="server" Width="98px"></asp:Button>&nbsp;
						<asp:Button id="btnCancel" Text="Không thay đổi(u)" runat="server" Width="140px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Trạng thái của yêu cầu đã được thay đổi</asp:ListItem>
				<asp:ListItem Value="1">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu!</asp:ListItem>
				<asp:ListItem Value="2">Không được phục vụ!</asp:ListItem>
				<asp:ListItem Value="3">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="4">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
