<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WOREdiFactView" CodeFile="WOREdiFactView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WOREdiFactView</title>
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
					<TD><asp:label id="lblPageTitle" CssClass="lbPageTitle" Runat="server">
							ILLREQ
						</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblContent" Runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<HR width="100%" SIZE="1">
						&nbsp;
						<asp:Button Runat="server" ID="btnClose" Text="Đóng (c)"></asp:Button>
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="2">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="3">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
