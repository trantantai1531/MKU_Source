<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORCancelReq" CodeFile="WORCancelReq.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Hủy bỏ yêu cầu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD><asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Hủy bỏ yêu cầu</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblNote" runat="server"><u>G</u>hi chú:</asp:label><br>
						<asp:textbox id="txtNote" Columns="50" Rows="5" TextMode="MultiLine" Runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnSent" Runat="server" Text="Gửi (g)"></asp:button>&nbsp;
						<asp:button id="btnCancel" Runat="server" Text="Không gửi (k)"></asp:button>
						<asp:dropdownlist id="ddlLabel" Runat="server" Width="0">
							<asp:ListItem Value="0">Thông điệp</asp:ListItem>
							<asp:ListItem Value="1">Ở trạng thái hiện thời, yêu cầu không thể được hủy bỏ.</asp:ListItem>
							<asp:ListItem Value="2">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="3">Yêu cầu hủy bỏ đã được gửi đi thành công.</asp:ListItem>
							<asp:ListItem Value="4">Yêu cầu hủy bỏ chưa được gửi đi!</asp:ListItem>
							<asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="6">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="7">Bạn không được quyền sử dụng tính năng này!</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
			</TABLE>
			<input id="hdnResponderID" type="hidden" runat="server" NAME="hdnResponderID">
		</form>
	</body>
</HTML>
