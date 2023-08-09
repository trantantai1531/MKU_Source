<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestFilter" CodeFile="WRequestFilter.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Lọc yêu cầu đặt mua</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" OnLoad="document.forms[0].txtCustomerName.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD colspan="2">
						<asp:Label id="lblPageTitle" CssClass="lbPageTitle" runat="server" Width="100%">Lọc yêu cầu đặt mua</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblTime" runat="server">Thời <U>g</U>ian: </asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlTimeMode" runat="server">
							<asp:ListItem Value="0" Selected="True">---------- Chọn ----------</asp:ListItem>
							<asp:ListItem Value="1">Ngày yêu cầu</asp:ListItem>
							<asp:ListItem Value="2">Ngày hết hạn</asp:ListItem>
							<asp:ListItem Value="3">Ngày kết thúc</asp:ListItem>
							<asp:ListItem Value="4">Ngày từ chối</asp:ListItem>
						</asp:DropDownList>&nbsp;
						<asp:Label id="lblTimeFrom" runat="server">t<U>ừ</U>: </asp:Label>
						<asp:TextBox id="txtTimeFrom" runat="server" Width="88px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lnkTimeFrom" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink>&nbsp;
						<asp:Label id="lblTimeTo" runat="server">đ<U>ế</U>n: </asp:Label>
						<asp:TextBox id="txtTimeTo" runat="server" Width="88px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lnkTimeTo" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblCustomerName" runat="server"><U>T</U>ên chủ tài khoản: </asp:Label></TD>
					<TD>
						<asp:TextBox id="txtCustomerName" runat="server" Width="200px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblNameOfFile" runat="server">Tê<U>n</U> file: </asp:Label></TD>
					<TD>
						<asp:TextBox id="txtNameOfFile" runat="server" Width="200px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblSizeOfFileFrom" runat="server"><U>K</U>ích thước file từ: </asp:Label></TD>
					<TD>
						<asp:TextBox id="txtSizeOfFileFrom" runat="server" Width="120px" Maxlength="12"></asp:TextBox><asp:Label id="lblComment" runat="server"> (bytes)</asp:Label>&nbsp;
						<asp:Label id="lblSizeOfFileTo" runat="server"><u>đ</u>ến: </asp:Label>
						<asp:TextBox id="txtSizeOfFileTo" runat="server" Width="120px" Maxlength="12"></asp:TextBox><asp:Label id="lblComent1" runat="server"> (bytes)</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblPriceOfFileFrom" runat="server"><U>G</U>iá tiền từ: </asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPriceOfFileFrom" runat="server" Width="120px" Maxlength="10"></asp:TextBox>&nbsp;
						<asp:Label id="lblPriceOfFileTo" runat="server">đến: </asp:Label>&nbsp;
						<asp:TextBox id="txtPriceOfFileTo" runat="server" Width="120px" Maxlength="10"></asp:TextBox>
					</TD>
				</TR>
				<TR Class="lbControlBar">
					<TD></TD>
					<TD>
						<asp:Button id="btnFilter" runat="server" Width="68px" Text="Lọc(f)"></asp:Button>
						<asp:Button id="btnReset" runat="server" Width="78px" Text="Đặt lại(r)"></asp:Button>
						<asp:Button id="btnBack" runat="server" Width="88px" Text="Quay lại(b)"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Bạn chưa nhập điều kiện lọc!</asp:ListItem>
				<asp:ListItem Value="1">Không có dữ liệu thoả mãn điều kiện tìm kiếm</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="5">Ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="6">Phải là số nguyên</asp:ListItem>
				<asp:ListItem Value="7">Giá tiền không hợp lệ</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
