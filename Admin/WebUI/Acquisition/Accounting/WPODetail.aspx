<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPODetail" CodeFile="WPODetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Chi tiết hợp đồng</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="3" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="4" Class="lbPageTitle">
						<asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="13%">
						<asp:label id="lblReceiptNo" runat="server"><U>M</U>ã số:</asp:label></TD>
					<TD>
						<asp:textbox id="txbReceiptNo" runat="server" Width="165px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right" width="13%">
						<asp:label id="lblTotalAmount" runat="server"><U>G</U>iá trị đơn đặt:</asp:label></TD>
					<TD width="18%">
						<asp:textbox id="txbTotalAmount" runat="server" Width="81px" ReadOnly="True">0</asp:textbox>
						<asp:dropdownlist id="ddlCurrency" runat="server" Enabled="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right" width="15%">
						<asp:label id="lblPOName" runat="server"><U>T</U>ên đơn đặt:</asp:label></TD>
					<TD>
						<asp:textbox id="txbPOName" runat="server" Width="298px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right">
						<asp:label id="lblFixedRate" runat="server">T<U>ỷ</U> giá:</asp:label></TD>
					<TD width="20%">
						<asp:textbox id="txbFixedRate" runat="server" Width="81px" ReadOnly="True">1</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="15%">
						<asp:label id="lblVendor" runat="server">Nhà <U>c</U>ung cấp:</asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlVendor" runat="server" Width="201px" Enabled="False"></asp:dropdownlist><INPUT id="txbVendorID" runat="server" type="hidden" size="7" NAME="txbVendorID"></TD>
					<TD align="right">
						<asp:label id="lblPrepaidAmount" runat="server">Thanh toán <U>b</U>an đầu:</asp:label></TD>
					<TD width="20%">
						<asp:textbox id="txbPrepaidAmount" runat="server" Width="81px" ReadOnly="True">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="15%">
						<asp:label id="lblValidDate" runat="server">Ngà<U>y</U> bắt đầu:</asp:label></TD>
					<TD>
						<asp:textbox id="txbValidDate" runat="server" Width="80px" ReadOnly="True"></asp:textbox>&nbsp;
						<asp:label id="Label2" runat="server">Ngày <U>k</U>ết thúc:</asp:label>
						<asp:textbox id="txbFilledDate" runat="server" Width="80px" ReadOnly="False"></asp:textbox>&nbsp;
					</TD>
					<TD align="right">
						<asp:label id="lblDiscount" runat="server">Giả<U>m</U> giá:</asp:label></TD>
					<TD width="20%">
						<asp:textbox id="txbDiscount" runat="server" Width="81px" ReadOnly="True">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="15%">
						<asp:label id="lblStatus" runat="server"><U>T</U>rạng thái</asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlStatus" runat="server" Width="223px" Enabled="False"></asp:dropdownlist></TD>
					<TD align="right">
						<asp:label id="lblPlanAmount" runat="server">Tổng dự ch<U>i</U>:</asp:label></TD>
					<TD width="20%">
						<asp:textbox id="txbPlanAmount" runat="server" Width="81px" ReadOnly="True">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="15%">
						<asp:label id="lblNote" runat="server">Ghi chú trạ<U>n</U>g thái:</asp:label></TD>
					<TD>
						<asp:textbox id="txbNote" runat="server" Width="298px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right">
						<asp:label id="lblRealAmount" runat="server">Tổng thực ch<U>i</U>:</asp:label></TD>
					<TD width="20%">
						<asp:textbox id="txbRealAmount" runat="server" Width="81px" ReadOnly="True">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4" Class="lbGroupTitle">
						<asp:label id="lblItemInfor" runat="server" CssClass="lbGroupTitle" Width="100%">Thông tin ấn phẩm</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" colspan="4">
						<asp:Table Runat="server" ID="tblItemInfor" Width="100%" CellPadding="3" CellSpacing="1"></asp:Table>
					</TD>
				</TR>
				<TR>
					<TD colspan="2"></TD>
					<TD colspan="2" align="right"></TD>
				</TR>
				<TR>
					<TD colSpan="4" Class="lbGroupTitle">
						<asp:label id="lblPoStatus" runat="server" CssClass="lbGroupTitle" Width="100%">Nhật ký trạng thái</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<asp:datagrid id="dtgStatus" runat="server" Width="100%" Height="22px" AutoGenerateColumns="False"
							HeaderStyle-HorizontalAlign="Center">
							<Columns>
								<asp:BoundColumn DataField="SetDate" HeaderText="Thời gian" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Status" HeaderText="Trạng thái" ItemStyle-Width="40%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Note" HeaderText="Ghi chú trạng thái"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="4" Class="lbGroupTitle">
						<asp:label id="Label1" runat="server" CssClass="lbGroupTitle" Width="100%">Thông tin kế toán</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<asp:datagrid id="dtgAccount" runat="server" Width="100%" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center">
							<Columns>
								<asp:BoundColumn DataField="Amount" HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="8%"></asp:BoundColumn>
								<asp:BoundColumn DataField="ExchangeRate" HeaderText="Tỷ giá" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="6%"></asp:BoundColumn>
								<asp:BoundColumn DataField="BudgetName" HeaderText="Quỹ"></asp:BoundColumn>
								<asp:BoundColumn DataField="TransactionDate" HeaderText="Ngày giao dịch" ItemStyle-HorizontalAlign="Center"
									ItemStyle-Width="9%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Inputer" HeaderText="Người nhập" ItemStyle-Width="13%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Commited" HeaderText="Trạng thái" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
								<asp:BoundColumn DataField="Reason" HeaderText="Ghi chú" ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="4" align="center">
						<asp:button id="btnClose" runat="server" Width="72px" Text="Đóng(c)"></asp:button></TD>
				</TR>
			</TABLE>
			<INPUT id="txbPOS" type="hidden" size="0" runat="server" value="0"> <INPUT id="txbPoType" type="hidden" size="0" runat="server" value="0">
			<INPUT id="txbContractID" type="hidden" size="0" runat="server" value="0"> <INPUT id="txbItemIDs" type="hidden" size="0" runat="server" value=",">
			<INPUT id="txbFunc" type="hidden" size="0" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Đơn đặt mua ấn phẩm đơn bản</asp:ListItem>
				<asp:ListItem Value="3">Đơn đặt mua ấn phẩm nhiều kỳ</asp:ListItem>
				<asp:ListItem Value="4">Cập nhật thông tin đơn đặt</asp:ListItem>
				<asp:ListItem Value="5">Xoá thông tin đơn đặt</asp:ListItem>
				<asp:ListItem Value="6">Đã tồn tại đơn đặt khác với mã số này</asp:ListItem>
				<asp:ListItem Value="7">Nhan đề</asp:ListItem>
				<asp:ListItem Value="8">Dạng tài liệu</asp:ListItem>
				<asp:ListItem Value="9">Vật mang tin</asp:ListItem>
				<asp:ListItem Value="10">Đơn giá (VND)</asp:ListItem>
				<asp:ListItem Value="11">Số lượng đặt</asp:ListItem>
				<asp:ListItem Value="12">Thành tiền (VND)</asp:ListItem>
				<asp:ListItem Value="13">Số lượng nhận</asp:ListItem>
				<asp:ListItem Value="14">Thành tiền (VND)</asp:ListItem>
				<asp:ListItem Value="15">Tổng:</asp:ListItem>
				<asp:ListItem Value="16">Giảm giá:</asp:ListItem>
				<asp:ListItem Value="17">Tổng:</asp:ListItem>
				<asp:ListItem Value="18">Loại ấn phẩm khỏi đơn đặt có mã số:</asp:ListItem>
				<asp:ListItem Value="19">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="20">Sai kiểu dữ liệu (số)</asp:ListItem>
				<asp:ListItem Value="21">Sai kiểu dữ liệu ngày tháng</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
