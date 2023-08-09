<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORChangeStatus" CodeFile="WORChangeStatus.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thay đổi trạng thái của yêu cầu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD colspan="2">
						<asp:Label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Thay đổi trạng thái của yêu cầu</asp:Label></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD>
						<asp:Label id="lblWarning" runat="server">Cảnh báo: Thay đổi trạng thái của một yêu cầu có thể làm ảnh hưởng ngược lại phía đối tác trong phiên giao dịch. Bạn chỉ nên thay đổi trạng thái của một yêu cầu nếu thông điệp ILL cần thiết bị mất hoặc phía đối tác không thể gửi lại được. Thay đổi trạng thái của giao dịch sẽ ảnh hưởng tới trạng thái chung cuộc. </asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Label id="lblChange" runat="server"><u>Đ</u>ổi trạng thái thành:</asp:Label>
						<asp:DropDownList id="ddlStatus" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD></TD>
					<TD>
						<asp:Label id="lblNote" cssclass="lbGroupTitle" runat="server"><u>G</u>hi chú:</asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:TextBox id="txtNote" runat="server" Rows="6" TextMode="MultiLine" Columns="65"></asp:TextBox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD colspan="2" align="center">
						<asp:Button id="btnChange" runat="server" Text="Thay đổi (t)"></asp:Button>&nbsp;
						<asp:Button id="btnCancel" runat="server" Text="Không thay đổi (k)" Width="136px"></asp:Button>
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Trạng thái của yêu cầu đã được thay đổi</asp:ListItem>
							<asp:ListItem Value="1">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="2">Không được phục vụ</asp:ListItem>
							<asp:ListItem Value="3">Hủy bỏ</asp:ListItem>
							<asp:ListItem Value="4">Đã hoàn tất</asp:ListItem>
							<asp:ListItem Value="5">Thông điệp thay đổi trạng thái chưa được gửi đi!</asp:ListItem>
							<asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="7">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="8">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
							<asp:ListItem Value="9">sang trạng thái không phục vụ (Not supplied) </asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
