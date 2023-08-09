<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestCancel" CodeFile="WRequestCancel.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xử lý yêu cầu huỷ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD align="center">
						<asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Xử lý yêu cầu huỷ</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblComment" runat="server"><u>G</u>hi chú:</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:textbox id="txtNote" runat="server" Width="412px" TextMode="MultiLine" Rows="5"></asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:button id="btnAccept" runat="server" Text="Chấp nhận(a)" Width="95px"></asp:button>
						<asp:button id="btnNotAccept" runat="server" Text="Không chấp nhận(u)" Width="133px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="78px"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Yêu cầu huỷ đã được chấp nhận</asp:ListItem>
				<asp:ListItem Value="1">Yêu cầu huỷ không được chấp nhận</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
