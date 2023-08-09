<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractCreate" CodeFile="WContractCreate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WContractCreate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD align="left" colSpan="2">
						<asp:label id="lblMainTitle" runat="server" Width="208px"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD>
						<asp:radiobutton id="optMonoItem" runat="server" Text="Ấn phẩm đơn <U>b</U>ản" GroupName="optItemType"
							Checked="True"></asp:radiobutton>&nbsp;
						<asp:radiobutton id="optSerialItem" runat="server" Text="Ấn phẩm định <U>k</U>ỳ" GroupName="optItemType"></asp:radiobutton>&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblReceiptNo" runat="server"><U>M</U>ã số:</asp:label></TD>
					<TD>
						<asp:textbox id="txbReceiptNo" runat="server" Width="165px" MaxLength="20"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblPOName" runat="server"><U>T</U>ên đơn đặt:</asp:label></TD>
					<TD>
						<asp:textbox id="txbPOName" runat="server" Width="208px" MaxLength="200"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblVendor" runat="server"><U>N</U>hà cung cấp:</asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlVendor" runat="server" Width="209px"></asp:dropdownlist>
						<asp:button id="btnAddVendor" runat="server" Text="Thêm(a)" Width="78px"></asp:button>
						<asp:button id="btnVendorDetail" runat="server" Width="108px" Text="Tham khảo(r)"></asp:button>
					    <input id="txbVendor" type="hidden" runat="server" NAME="txbVendor"/>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblValidDate" runat="server">N<U>g</U>ày bắt đầu:</asp:label></TD>
					<TD>
						<asp:textbox id="txbValidDate" runat="server" Width="165px"></asp:textbox>
						<asp:hyperlink id="lnkValidDate" runat="server" Width="63px">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblFilledDate" runat="server" Width="104px">Ngà<U>y</U> kết thúc:</asp:label></TD>
					<TD>
						<asp:textbox id="txbFilledDate" runat="server" Width="165px"></asp:textbox>
						<asp:hyperlink id="lnkFilledDate" runat="server" Width="63px">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblStatus" runat="server">T<U>r</U>ạng thái:</asp:label></TD>
					<TD>
						<asp:textbox id="txbStatus" runat="server" Width="400px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR style="display:none;">
					<TD align="right">
						<asp:label id="lblTotalAmount" runat="server">G<U>i</U>á trị đơn đặt:</asp:label></TD>
					<TD>
						<asp:textbox id="txbTotalAmount" runat="server" Width="165px" MaxLength="12">0</asp:textbox>
						<asp:dropdownlist id="ddlCurrency" runat="server" Width="125px"></asp:dropdownlist>
						<asp:button id="btnAddCurrency" runat="server" Width="110px" Text="Đơn vị khác(n)"></asp:button>
					    <INPUT id="txbCurrency" type="hidden" runat="server" NAME="txbCurrency"/>
					</TD>
				</TR>
				<TR style="display:none;">
					<TD align="right">
						<asp:label id="lblFixedRate" runat="server">Tỷ giá <U>h</U>ạch toán:</asp:label></TD>
					<TD>
						<asp:textbox id="txbFixedRate" runat="server" Width="165px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblPrepaidAmount" runat="server">Thanh toá<U>n</U> ban đầu:</asp:label></TD>
					<TD>
						<asp:textbox id="txbPrepaidAmount" runat="server" Width="165px" MaxLength="10">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblDiscount" runat="server">Giả<U>m</U> giá (%):</asp:label></TD>
					<TD>
						<asp:textbox id="txbDiscount" runat="server" Width="165px" MaxLength="10">0</asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="right" width="35%"></TD>
					<TD>
						<asp:Button id="btnCreate" runat="server" Width="118px" Text="Tạo đơn đặt(c)"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng dữ liệu không hợp lệ</asp:ListItem>
				<asp:ListItem Value="3">Đã tồn tại đơn đặt với mã số này</asp:ListItem>
				<asp:ListItem Value="4">Tạo mới hợp đồng với mã số:</asp:ListItem>
				<asp:ListItem Value="5">Tạo mới hợp đồng thành công</asp:ListItem>
				<asp:ListItem Value="6">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="7">Bạn chưa nhập đủ thông tin cần thiết hoặc thông tin không hợp lệ!</asp:ListItem>
			</asp:DropDownList>
		    <input type="hidden" id="txbFunc" runat="server"/> <input type="hidden" id="hidCurrency" runat="server"/>
		    <input type="hidden" id="hidFixedRate" runat="server"/>
		</form>
	</body>
</HTML>
