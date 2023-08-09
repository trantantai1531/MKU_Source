<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORPatronMess" CodeFile="WORPatronMess.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thông báo nhận được ấn phẩm</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colspan="2">
						<asp:Label ID="lblTitleFrom" Runat="server" CssClass="lbPageTitle" Width="100%">Thông báo nhận được ấn phẩm</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="2"><asp:label id="lblContents" Runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD width="30%" align="right">
						<asp:Label ID="lblModelMail" Runat="server"><u>M</u>ẫu thư:&nbsp;</asp:Label>
					</TD>
					<TD>
						<asp:DropDownList ID="ddlModelMail" Runat="server" Width="160px"></asp:DropDownList>
					</TD>
				</TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:Button ID="btnPrintMail" Runat="server" Text="In thư(i)"></asp:Button>
						<asp:Button ID="btnSendMail" Runat="server" Text="Gửi thư(g)"></asp:Button>
						<asp:Button ID="btnSendSMS" Runat="server" Text="Gửi SMS(s)"></asp:Button>&nbsp;
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(d)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">CALLNUMBER,TITLE,AUTHOR,ADDRESSOFPUBLISHER,PUBLISHER,SERIESTITLENUMBER,VOLUMEISSUE,PUBLISHEDYEAR,PUBLISHEDDATE,ARTICLEAUTHOR,PAGINATION,NATIONALBIBNUMBER,ISBN,ISSN,ITEMCODE,SPONSORINGBODY,DELIVNAME,DELIVADDRESS1,DELIVADDRESS2,DELIVBOX,DELIVCITY,DELIVSTREET,DELIVCOUNTRY,DELIVCODE,REQUESTCODE,SHIPPEDDATE,DUEDATE,DELIVCONDITION,PATRONNAME,PATRONCODE,REASONDENIED,CLASS,FACULITY,GRADE,WORKINGPLACE,WORKINGADDRESS,ADDRESS,RETRIEVEDDATE,CHECKOUTDATE,EXPIREDDATE,OVERDUEDATE</asp:ListItem>
				<asp:ListItem Value="3">--- Chọn mẫu thư ----</asp:ListItem>
				<asp:ListItem Value="4">--- Chọn lý do từ chối ---</asp:ListItem>
				<asp:ListItem Value="5">Thư đã được gửi</asp:ListItem>
				<asp:ListItem Value="6">Quá trình gửi thư xuất hiện lỗi</asp:ListItem>
				<asp:ListItem Value="7">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
				<asp:ListItem Value="8">Thông báo nhận được ấn phẩm cho bạn đọc</asp:ListItem>
			</asp:DropDownList>
			<input id="hdnResponderID" type="hidden" runat="server">
		</form>
	</body>
</HTML>
