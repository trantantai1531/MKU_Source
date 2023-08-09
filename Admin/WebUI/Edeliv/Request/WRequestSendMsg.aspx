<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestSendMsg" CodeFile="WRequestSendMsg.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gửi thông điệp</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="100%" border="0" cellpadding="2" cellspacing="0">
				<TR Class="lbPageTitle">
					<TD>
						<asp:Label id="lblPageTitle" CssClass="lbPageTitle" runat="server">Gửi thông điệp</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblSubject" runat="server"><U>T</U>iêu đề:</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="txtSubject" runat="server" Width="200px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblContent" runat="server"><U>N</U>ội dung:</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="txtContent" runat="server" Width="300px" TextMode="MultiLine" Rows="4"></asp:TextBox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button id="btnSend" Text="Gửi(s)" runat="server" Width="64px"></asp:Button>&nbsp;
						<asp:Button id="btnClose" Text="Đóng(o)" runat="server" Width="64px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Bạn chưa nhập đủ thông tin!</asp:ListItem>
				<asp:ListItem Value="1">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="4">Gửi thông điệp thành công!</asp:ListItem>
				<asp:ListItem Value="5">Gửi thông điệp không thành công ( địa chỉ hòm thư không tồn tại ).</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
