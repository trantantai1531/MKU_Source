<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestDetail" CodeFile="WRequestDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WRequestDetail</title>
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
					<TD width="60%">
						<asp:label id="lblPageTitle" runat="server" Width="100%" CssClass="lbPageTitle">Chi tiết yêu cầu đặt mua</asp:label></TD>
					<TD align="right">
						<asp:button id="btnFirst" runat="server" Width="26px" Text="|<"></asp:button><asp:button id="btnPrev" runat="server" Width="26px" Text=" <"></asp:button><asp:textbox id="txtCurrRec" runat="server" Width="50px">0</asp:textbox><asp:textbox id="txtTotalRec" runat="server" Width="50px" Enabled="False">0</asp:textbox><asp:button id="btnNext" runat="server" Width="26px" Text="> "></asp:button><asp:button id="btnLast" runat="server" Width="26px" Text=">|"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:label id="lblFileInfor" runat="server">
							<H4>Thông tin về tài liệu đặt mua</H4>
						</asp:label>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<ul>
							<li>
								<asp:label id="lblNameOfFilelb" runat="server">Tên file:&nbsp;</asp:label><asp:label id="lblNameOfFile" runat="server"></asp:label>
							<li>
								<asp:label id="lblSizeOfFilelb" runat="server">Kích cỡ file:&nbsp;</asp:label><asp:label id="lblSizeOfFile" runat="server"></asp:label>
							<li>
								<asp:label id="lblPriceOfFilelb" runat="server">Giá tiền:&nbsp;</asp:label><asp:label id="lblPriceOfFile" runat="server"></asp:label>
							<li>
								<asp:label id="lblURLlb" runat="server">URL:&nbsp;</asp:label><asp:label id="lblURL" runat="server"></asp:label>
							<li>
								<asp:label id="lblBooklb" runat="server">Tài liệu gốc:&nbsp;</asp:label><asp:label id="lblBook" runat="server"></asp:label>
							<li>
								<asp:label id="lblStatuslb" runat="server">Trạng thái của yêu cầu:&nbsp;</asp:label><asp:label id="lblStatus" runat="server"></asp:label>
							<li>
								<asp:label id="lblNotelb" runat="server">Thông tin mô tả:&nbsp;</asp:label><asp:label id="lblNote" runat="server"></asp:label></li></ul>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:label id="lblCustomerInfor" runat="server">
							<H4>Thông tin về đối tượng đặt mua</H4>
						</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<ul>
							<li>
								<asp:label id="lblCustomerNamelb" runat="server">Tên cá nhân (đơn vị) đặt mua:&nbsp;</asp:label><asp:label id="lblCustomerName" runat="server"></asp:label>
							<li>
								<asp:label id="lblAddresslb" runat="server">Địa chỉ:&nbsp;</asp:label><asp:label id="lblAddress" runat="server"></asp:label>
							<li>
								<asp:label id="lblPhonelb" runat="server">Điện thoại:&nbsp;</asp:label><asp:label id="lblPhone" runat="server"></asp:label>
							<li>
								<asp:label id="lblFAXlb" runat="server">FAX:&nbsp;</asp:label><asp:label id="lblFAX" runat="server"></asp:label>
							<li>
								<asp:label id="lblEmaillb" runat="server">Email:&nbsp;</asp:label><asp:label id="lblEmail" runat="server"></asp:label>
							<li>
								<asp:label id="lblContactorNamelb" runat="server">Người liên hệ:&nbsp;</asp:label><asp:label id="lblContactorName" runat="server"></asp:label>
							<li>
								<asp:label id="lblDebtlb" runat="server">Số dư:&nbsp;</asp:label><asp:label id="lblDebt" runat="server"></asp:label>&nbsp;
								<asp:label id="lblCurrency" runat="server">(VND)</asp:label>
							<li>
								<asp:label id="lblCustomerNotelb" runat="server">Ghi chú:&nbsp;</asp:label><asp:label id="lblCustomerNote" runat="server"></asp:label></li></ul>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="1">Xóa</asp:ListItem>
				<asp:ListItem Value="2">Gửi thông điệp</asp:ListItem>
				<asp:ListItem Value="3">Gửi file</asp:ListItem>
				<asp:ListItem Value="4">Gửi thư từ chối</asp:ListItem>
				<asp:ListItem Value="5">Gửi hoá đơn</asp:ListItem>
				<asp:ListItem Value="6">Đổi trạng thái</asp:ListItem>
				<asp:ListItem Value="7">In nhãn đóng gói</asp:ListItem>
				<asp:ListItem Value="8">Gửi thư nhắc trả tiền</asp:ListItem>
				<asp:ListItem Value="9">Chuyển sang thư mục thích hợp</asp:ListItem>
				<asp:ListItem Value="10">Chuyển sang yêu cầu huỷ</asp:ListItem>
				<asp:ListItem Value="11">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="12">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="13">Sai định dạng dữ liệu (số)!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
