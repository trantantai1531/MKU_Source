<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORAskStatus" CodeFile="WORAskStatus.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gửi yêu cầu hỏi trạng thái</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD>
						<asp:Label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Gửi yêu cầu hỏi trạng thái</asp:Label></TD>
				</TR>
				<TR>
					<TD width="5%" align="center">
						<asp:Label id="lblNote" runat="server"><u>G</u>hi chú</asp:Label></TD>
				</TR>
				<TR>
					<TD width="5%" align="center">
						<asp:TextBox id="txtNote" runat="server" Columns="45" Rows="5" TextMode="MultiLine"></asp:TextBox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button id="btnSent" runat="server" Text="Gửi (g)"></asp:Button>&nbsp;
						<asp:Button id="btnCancel" runat="server" Text="Không gửi (k)"></asp:Button>
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Thông điệp hỏi trạng thái được gửi thành công</asp:ListItem>
							<asp:ListItem Value="1">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="2">Thông điệp hỏi trạng thái chưa được gửi đi!</asp:ListItem>
							<asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="4">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="5">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>
			<input id="hdnResponderID" type="hidden" runat="server" NAME="hdnResponderID">
		</form>
	</body>
</HTML>
