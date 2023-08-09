<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WFeesReport" CodeFile="WFeesReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Báo cáo thu (chi) của quỹ</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<TR align="center" class="">
					<TD align="center" class="lbSubTitle">
						<asp:Label ID="lblSpendTitle" runat="server">BÁO CÁO KHOẢN CHI</asp:Label>
						<asp:Label ID="lblReceivedTitle" runat="server">BÁO CÁO KHOẢN THU</asp:Label>
					</TD>
				</TR>
				<TR align="center" class="">
					<TD align="center" class="lbSubTitle">
						<asp:Label id="lblSubTitle" runat="server" Visible="False"></asp:Label>
					</TD>
				</TR>
				<tr>
					<td>
						<asp:datagrid id="dgtResult" Runat="server" Width="100%" AllowPaging="False" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Ngày nhập">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "TRANSACTIONDATE")%>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblAmountDisplay" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmountDisplay") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tỉ giá" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblRateDisplay" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"ExchangeRate")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lý do">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Người nhập" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblReporter" Text='<%# DataBinder.Eval(Container.DataItem, "Inputer") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
						<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
							<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="2">Quỹ:</asp:ListItem>
							<asp:ListItem Value="3">tháng</asp:ListItem>
							<asp:ListItem Value="4">năm</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
