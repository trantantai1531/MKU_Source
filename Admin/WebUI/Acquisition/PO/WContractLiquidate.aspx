<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractLiquidate" CodeFile="WContractLiquidate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Quản lý khoản dự chi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD class="lbPageTitle" align="center">
							<asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle" Width="100%">Khai báo chi cho những khoản đã dự chi</asp:label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:label id="lblPoName" runat="server" Width="100%"></asp:label></TD>
					</TR>
					<TR>
						<TD>
							<asp:datagrid id="dtgDetail" runat="server" Width="100%" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="center">
								<Columns>
									<asp:BoundColumn DataField="BudgetName" HeaderText="Tên quỹ"></asp:BoundColumn>
									<asp:BoundColumn DataField="Reason" HeaderText="Lý do chi" ItemStyle-Width="15%"></asp:BoundColumn>
									<asp:BoundColumn DataField="Amount" HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%"></asp:BoundColumn>
									<asp:BoundColumn DataField="Currency" HeaderText="Đơn vị tiền tệ" ItemStyle-Width="10%"></asp:BoundColumn>
									<asp:BoundColumn DataField="TransactionDate" HeaderText="Ngày giao dịch" ItemStyle-HorizontalAlign="Center"
										ItemStyle-Width="10%"></asp:BoundColumn>
									<asp:TemplateColumn Visible="False">
										<ItemTemplate>
											<asp:Label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tỷ giá" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="8%">
										<ItemTemplate>
											<asp:TextBox id="txtExchangeRate" Width="70" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"ExchangeRate") %>'>
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Chọn" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
										<ItemTemplate>
											<asp:CheckBox id="chkSelectedID" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD>
							<asp:button id="btnUpdate" runat="server" Text="Thực chi(p)" Width="86px"></asp:button>
							<asp:button id="btnCancel" runat="server" Text="Huỷ dự chi(r)" Width="102px"></asp:button>
							<asp:button id="btnClose" runat="server" Text="Đóng(c)" Width="73px"></asp:button>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dung tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Dữ liệu không phải kiểu ngày tháng</asp:ListItem>
				<asp:ListItem Value="4">Dữ liệu phải là kiểu số</asp:ListItem>
				<asp:ListItem Value="5">Hiện tại không có dự định chi nào cho đơn này</asp:ListItem>
				<asp:ListItem Value="6">Bạn chưa chọn quỹ nào</asp:ListItem>
				<asp:ListItem Value="7">Tên đơn đặt</asp:ListItem>
				<asp:ListItem Value="8">Huỷ dự chi</asp:ListItem>
				<asp:ListItem Value="9">Thực chi cho khoản dự chi</asp:ListItem>
			</asp:DropDownList>
			<INPUT id="hidContractID" name="hidContractID" type="hidden" runat="server" value="0">
		</form>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
