<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCheckingReceived" CodeFile="WCheckingReceived.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckingReceived</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tbl" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<asp:hyperlink id="lnkBack" runat="server">Quay lại trang hợp đồng</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblTitle" runat="server" Width="100%" CssClass="main-head-form">Kiểm 
          nhận</asp:label></TD>
				</TR>
				<TR>
					<TD>
					    <div class="table-form">
					        <asp:datagrid id="dgrCheckingReceived" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn Visible="False" HeaderText="lblID">
									<ItemTemplate>
										<asp:Label Id="lblID" Width="60px" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="MainTitle" HeaderText="Nhan đề">
									<ItemStyle Width="50%"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Số lượng y&#234;u cầu">
									<ItemTemplate>
										<asp:Label ID="lblRequestedCopies"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RequestedCopies") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số lượng nhận được">
									<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="txtReceive" Width="60" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"ReceivedCopies") %>'>
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ghi ch&#250;">
									<ItemTemplate>
										<asp:TextBox id="txtNote" Width ="100%" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Note") %>' Wrap =True Height ="40px">
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					    </div>
						
						<asp:button id="btnUpdate" runat="server" Width="88px" Text="Cập nhật(c)"></asp:button>
					</TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Visible="False" Runat="server" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi </asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này! </asp:ListItem>
				<asp:ListItem Value="3">Cập nhật số lượng ấn phẩm nhận được </asp:ListItem>
				<asp:ListItem Value="4">Sai kiểu dữ liệu.</asp:ListItem>
				<asp:ListItem Value="5">Cập nhật thành công.</asp:ListItem>
			</asp:dropdownlist>
			<input id="hidContractID" type="hidden" value="0" runat="server">
		</form>
	</body>
</HTML>
