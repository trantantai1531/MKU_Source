<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractBudgetInfo" CodeFile="WContractBudgetInfo.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Khai báo thu</title>
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
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD width="100%" Class="lbPageTitle" align="center">
						<asp:label id="lblMainTitle" CssClass="lbPageTitle" runat="server" Width="235px">Khai báo chi</asp:label></TD>
				</TR>
				<TR>
					<TD>
					    <div class="table-form">
						<asp:datagrid id="dtgBudget" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
							<Columns>
								<asp:HyperLinkColumn Target="_self" DataTextField="BudgetName" HeaderText="Tên quỹ">
									<ItemStyle Width="25%"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="Purpose" HeaderText="Mục đích quỹ"></asp:BoundColumn>
								<asp:BoundColumn DataField="Balance" HeaderText="Số tiền lý thuyết" ItemStyle-HorizontalAlign="Right">
									<ItemStyle Width="13%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RealBalance" HeaderText="Số tiền thực có" ItemStyle-HorizontalAlign="Right">
									<ItemStyle Width="13%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Currency" HeaderText="Đơn vị tiền tệ" ItemStyle-HorizontalAlign="Center">
									<ItemStyle Width="8%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                        </div>
					</TD>
				</TR>
			</TABLE>
			<INPUT id="hidContractID" type="hidden" name="hidContractID" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
