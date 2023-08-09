<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestSendFile" CodeFile="WRequestSendFile.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gửi file tài liệu điện tử</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="2" topMargin="1">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD>
						<asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Gửi file tài liệu điện tử</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblSubject" runat="server"><U>T</U>iêu đề:</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txtSubject" runat="server" Width="200px">Thông báo gửi ấn phẩm điện tử</asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblContent" runat="server"><U>N</U>ội dung:</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txtContent" runat="server" Width="300px" TextMode="MultiLine" Rows="6">Ấn phẩm điện tử đã được gửi tới bạn bằng file gắn kèm</asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:button id="btnSend" runat="server" Width="68px" Text="Gửi(s)"></asp:button>&nbsp;
						<asp:button id="btnClose" runat="server" Width="78px" Text="Đóng(o)"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Width="0" Visible="False" Runat="server" Height="0">
				<asp:ListItem Value="0">Bạn chưa nhập đủ thông tin!</asp:ListItem>
				<asp:ListItem Value="1">Ấn phẩm điện tử đã được gửi tới bạn bằng CD</asp:ListItem>
				<asp:ListItem Value="2">Ấn phẩm điện tử đã được gửi tới bạn bằng URL</asp:ListItem>
				<asp:ListItem Value="3">Ấn phẩm bạn đặt mua đã được kích hoạt! Bạn có thể download ấn phẩm đặt mua qua URL:</asp:ListItem>
				<asp:ListItem Value="4">Sau đó đăng nhập bằng tên đăng nhập và mật khẩu của bạn</asp:ListItem>
				<asp:ListItem Value="5">Ấn phẩm điện tử đã được gửi tới bạn bằng tệp đính kèm</asp:ListItem>
				<asp:ListItem Value="6">Gửi email thành công</asp:ListItem>
				<asp:ListItem Value="7">Lỗi trong quá trình gửi email</asp:ListItem>
				<asp:ListItem Value="8">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="9">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="10">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="11">Thời gian giới hạn để bạn download ấn phẩm về kể từ ngày nhận được mail là:</asp:ListItem>
				<asp:ListItem Value="12">ngày.</asp:ListItem>
			</asp:dropdownlist><input id="hidRequestID" type="hidden" runat="server"> <input id="hidPath" type="hidden" runat="server">
		</form>
	</body>
</HTML>
