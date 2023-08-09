<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WDecSpend" CodeFile="WDecSpend.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WDecSpend</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" cellpadding="0" cellspacing="0">
				<tr class="lbPageTitle">
					<td>
						<asp:Label Runat="server" ID="lblLabel" CssClass="lbPageTitle">Khai báo chi</asp:Label>
					</td>
				</tr>
				<tr>
					<td height="1"></td>
				</tr>
				<tr>
					<td>
						<asp:DataGrid id="dgtBudget" runat="server" AutoGenerateColumns="False" PageSize="15" AllowPaging="True"
							width="100%">
							<Columns>
								<asp:TemplateColumn HeaderText="Tên quỹ">
									<ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink Runat="server" id="lnkBudgetName">
											<%# DataBinder.Eval(Container, "DataItem.BudgetName") %>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Purpose" HeaderText="Mục đích">
									<ItemStyle Width="30%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Balance" HeaderText="Số tiền tồn">
									<ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RealBalance" HeaderText="Số tiền sau khi đã trừ đi các khoản dự chi">
									<ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Currency" HeaderText="Đơn vị tiền tệ">
									<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</td>
				</tr>
				<tr>
					<td>
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
