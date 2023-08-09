<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WFeesReport" CodeFile="WFeesReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Báo cáo tài chính</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<TR align="center" class="lbGridPager">
					<TD align="center" class="lbSubTitle">
						<asp:Label ID="lblSettledTitle" runat="server">BÁO CÁO KHOẢN THU</asp:Label>
						<asp:Label ID="lblUnsettledTitle" runat="server">BÁO CÁO KHOẢN PHẢI THU</asp:Label>
					</TD>
				</TR>
				<TR align="center" class="lbGridPager">
					<TD align="center" class="lbSubTitle">
						<asp:Label id="lblSubTitle" runat="server" Visible="False"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgtResult" Runat="server" Width="100%" AllowPaging="False" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Ngày thu">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FROMDATE") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mã tài khoản">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lý do">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="13%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblAmountDisplay" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Đơn vị TT">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblCurrency" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Currency")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tỉ giá" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblRateDisplay" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Rate")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thành tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="13%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblTotal" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Total")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					</TD>
				</TR>
				<TR runat="server" id="TRSumary" align="right" class="lbGridPager">
					<TD colspan="4" align="right" class="lbSubTitle">
						<asp:Label ID="lblSumaryTemp" runat="server">Tổng: </asp:Label>
						<asp:Label ID="lblSumary" runat="server" CssClass="lbAmount"></asp:Label>
					</TD>
				</TR>
			</table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Mã tài khoản:</asp:ListItem>
				<asp:ListItem Value="1">Tháng</asp:ListItem>
				<asp:ListItem Value="2">tháng</asp:ListItem>
				<asp:ListItem Value="3">Năm</asp:ListItem>
				<asp:ListItem Value="4">năm</asp:ListItem>
				<asp:ListItem Value="5">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="6">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="7">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
