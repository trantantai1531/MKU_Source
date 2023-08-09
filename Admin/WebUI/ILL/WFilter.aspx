<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WFilter" CodeFile="WFilter.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WFilter</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD colspan="2" class="lbPageTitle">
						<asp:Label Runat="server" ID="lblInPageTitle" CssClass="lbPageTitle">Lọc theo yêu cầu đến</asp:Label>
						<asp:Label Runat="server" ID="lblOutPageTitle" CssClass="lbPageTitle">Lọc theo yêu cầu đi</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD width="293" align="right" style="WIDTH: 293px" valign="top">
						<asp:Label Runat="server" ID="lblSentPlace">Nơi gửi:</asp:Label>
						<asp:Label id="lblReceivePlace" Runat="server">Nơi nhận:</asp:Label>
					</TD>
					<TD>
						<asp:ListBox id="lsbLib" runat="server" SelectionMode="Multiple"></asp:ListBox>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblTime" Runat="server">Thời <u>g</u>ian:</asp:Label>
					</TD>
					<TD>
						<asp:DropDownList id="ddlInTimeMode" runat="server">
							<asp:ListItem Value="0">--------- Chọn ---------</asp:ListItem>
							<asp:ListItem Value="1">Ngày nhận</asp:ListItem>
							<asp:ListItem Value="2">Ngày trả lời</asp:ListItem>
							<asp:ListItem Value="3">Ngày hết hạn</asp:ListItem>
							<asp:ListItem Value="4">Ngày huỷ bỏ</asp:ListItem>
							<asp:ListItem Value="5">Ngày gửi đi</asp:ListItem>
							<asp:ListItem Value="6">Ngày ghi mượn</asp:ListItem>
							<asp:ListItem Value="7">Ngày ghi trả</asp:ListItem>
						</asp:DropDownList>
						<asp:DropDownList id="ddlOutTimeMode" runat="server">
							<asp:ListItem Value="0">--------- Chọn ---------</asp:ListItem>
							<asp:ListItem Value="1">Ngày tạo</asp:ListItem>
							<asp:ListItem Value="2">Ngày yêu cầu</asp:ListItem>
							<asp:ListItem Value="3">Ngày cần trước</asp:ListItem>
							<asp:ListItem Value="4">Ngày hết hạn</asp:ListItem>
							<asp:ListItem Value="5">Ngày nhận được</asp:ListItem>
							<asp:ListItem Value="6">Ngày trả lời</asp:ListItem>
							<asp:ListItem Value="7">Ngày hủy bỏ</asp:ListItem>
							<asp:ListItem Value="8">Ngày gửi trả</asp:ListItem>
							<asp:ListItem Value="9">Ngày ghi mượn</asp:ListItem>
							<asp:ListItem Value="10">Ngày ghi trả</asp:ListItem>
						</asp:DropDownList>
						<asp:Label id="lblFrom" Runat="server"><u>T</u>ừ:</asp:Label>
						<asp:TextBox id="txtFromDate" runat="server" Width="88px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lnkFromDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink>&nbsp;
						<asp:Label id="lblTo" Runat="server">Đế<u>n</u>:</asp:Label>
						<asp:TextBox id="txtToDate" runat="server" Width="88px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lnkToDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblTitle" Runat="server">Nh<u>a</u>n đề:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtTitle" runat="server" Width="296px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblAuthor" Runat="server">Tá<u>c</u> giả:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtAuthor" runat="server" Width="208px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblPatronName" Runat="server">Họ và tên <u>b</u>ạn đọc:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPatronName" runat="server" Width="208px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblPatronCode" Runat="server"><u>S</u>ố thẻ:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPatronCode" runat="server" Width="96px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblDocType" Runat="server"><u>D</u>ạng tài liệu:</asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlDocType" runat="server">
							<asp:ListItem Value="0">-------- Chọn ---------</asp:ListItem>
							<asp:ListItem Value="1">Ấn phẩm đơn bản</asp:ListItem>
							<asp:ListItem Value="2">Ấn phẩm định kỳ</asp:ListItem>
							<asp:ListItem Value="3">Loại khác</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="right"></TD>
					<TD>
						<asp:Button id="btnFilter" runat="server" Text="Lọc(f)" Width="64px"></asp:Button>
						<asp:Button id="btnReset" runat="server" Text="Đặt lại(r)" Width="88px"></asp:Button>
						<asp:Button id="btnBack" runat="server" Text="Trở lại(b)" Width="92px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Visible="False" Width="0" Runat="server">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn phải nhập ít nhất một điều kiện lọc!</asp:ListItem>
				<asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="4">Không có dữ liệu thoả mãn điều kiện tìm kiếm</asp:ListItem>
			</asp:DropDownList>
			<input id="hidIDs" runat="server" type="hidden">
		</form>
	</body>
</HTML>
