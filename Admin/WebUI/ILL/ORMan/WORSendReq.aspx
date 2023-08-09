<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORSendReq" CodeFile="WORSendReq.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gửi yêu cầu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="2" cellspacing="0" border="0" width="100%">
				<tr Class="lbPageTitle">
					<td>
						<asp:Label Runat="server" CssClass="lbPageTitle" id="lblFormTitle">Gửi yêu cầu</asp:Label>
					</td>
				</tr>
				<TR>
					<TD align="center">
						<P>
							<asp:Label id="lblConfirm" Runat="server">Bạn có muốn gửi yêu cầu ILL này đi không?</asp:Label></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<tr align="center">
					<td>
						<asp:Button Runat="server" ID="btnSent" text="Gửi (g)"></asp:Button>&nbsp;
						<asp:Button Runat="server" ID="btnCancel" text="Chưa gửi (c)"></asp:Button>&nbsp;
						<asp:Button Runat="server" ID="btnViewMail" text="Xem thư EDIFACT (e)" Width="165px"></asp:Button>
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="1">Ở trạng thái hiện thời, yêu cầu không thể được gửi đi, để gửi hãy nhân bản yêu cầu và gửi yêu cầu mới.</asp:ListItem>
							<asp:ListItem Value="2">Yêu cầu đã được gửi đi thành công.</asp:ListItem>
							<asp:ListItem Value="3">Yêu cầu chưa được gửi đi thành công.</asp:ListItem>
							<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="5">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="6">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
			</table>
			<input id="hdnResponderID" type="hidden" runat="server">
		</form>
	</body>
</HTML>