<%@ Page Language="vb" AutoEventWireup="false" EnableViewStateMAC="False" EnableViewState="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPrintLocationInventory" CodeFile="WPrintLocationInventory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>WPrintLocationInventory</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tbl1" width="100%">
				<tr>
					<td class="lbPageTitle"><asp:label id="lblInventoryName" Width="100%" Runat="server">Heloo</asp:label></td>
				</tr>
				<tr>
					<td><asp:datagrid id="dtgInventoryLost" runat="server" Width="100%" PageSize="20" PagerStyle-Visible="False"
							AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="IDRESERVE" ReadOnly="True" HeaderText="STT">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Nhan đề">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' ID="lbldtgContent">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ĐKCB">
									<HeaderStyle HorizontalAlign="Left" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Copynumber") %>' ID="lbldtgCopynumber">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số định danh">
									<HeaderStyle HorizontalAlign="Left" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CallNumber") %>' ID="Label1">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="L&#253; do">
									<HeaderStyle HorizontalAlign="Left" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Reason") %> ' ID="Label2">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Visible="False" Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td><asp:datagrid id="dtgInventoryFalsePath" runat="server" Width="100%" PageSize="20" PagerStyle-Visible="False"
							AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="IDRESERVE" ReadOnly="True" HeaderText="STT">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<FooterStyle HorizontalAlign="Left"></FooterStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Nhan đề">
									<HeaderStyle HorizontalAlign="Left" Width="35%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' ID="lblLabel3">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ĐKCB">
									<HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Copynumber") %>' ID="lblLabel4">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số định danh">
									<HeaderStyle HorizontalAlign="Left" Width="12%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CallNumber") %>' ID="Label5">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Vị tr&#237; kiểm k&#234;">
									<HeaderStyle HorizontalAlign="Left" Width="17%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INPATHS") %>' ID="Label6">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Vị tr&#237; đ&#250;ng">
									<HeaderStyle HorizontalAlign="Left" Width="17%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TRUEPATHS") %>' ID="Label7">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Visible="False" Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="center"><asp:label id="lblPage" Runat="server"></asp:label></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlNameNoHave" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">STT</asp:ListItem>
				<asp:ListItem Value="1">Nhan đề</asp:ListItem>
				<asp:ListItem Value="2">DKCB</asp:ListItem>
				<asp:ListItem Value="3">Số định danh</asp:ListItem>
				<asp:ListItem Value="4">Lý do</asp:ListItem>
				<asp:ListItem Value="5">
					<font><i>Danh sách đăng ký cá biệt không có trong cơ sở dữ liệu</i></font>
				</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlNameFalsePaths" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">STT</asp:ListItem>
				<asp:ListItem Value="1">Nhan đề</asp:ListItem>
				<asp:ListItem Value="2">DKCB</asp:ListItem>
				<asp:ListItem Value="3">Số định danh</asp:ListItem>
				<asp:ListItem Value="4">Vị trí kiểm kê</asp:ListItem>
				<asp:ListItem Value="5">Vị trí đúng</asp:ListItem>
				<asp:ListItem Value="6">
					<i>Danh sách đăng ký cá biệt sai đường dẫn</i></asp:ListItem>
				<asp:ListItem Value="7">
					<i>Danh sách đăng ký cá biệt thiếu</i></asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">Mã lỗi </asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="3">In kết quả kiểm kê</asp:ListItem>
				<asp:ListItem Value="4">Kỳ kiểm kê:</asp:ListItem>
				<asp:ListItem Value="5">Ngày bắt đầu kỳ kiểm kê:</asp:ListItem>
				<asp:ListItem Value="6">Ngày kết thúc kỳ kiểm kê:</asp:ListItem>
				<asp:ListItem Value="7">Thư viện: </asp:ListItem>
				<asp:ListItem Value="8">Kho: </asp:ListItem>
				<asp:ListItem Value="9">Giá: </asp:ListItem>
				<asp:ListItem Value="9">Người kiểm kê: </asp:ListItem>
				<asp:ListItem Value="10">Không tìm thấy dữ liệu </asp:ListItem>
			</asp:dropdownlist><input id="hidShortView" type="hidden" name="hidShortView" runat="server">
			<input id="hidLib" type="hidden" name="hidLib" runat="server"> <input id="hidInt" type="hidden" name="hidInt" runat="server">
			<input id="hidShelf" type="hidden" name="hidShelf" runat="server"> <input id="hidType" type="hidden" name="hidType" runat="server"><br>
			<input id="hidLoc" type="hidden" name="hidLoc" runat="server"> <input id="hidPageOneNum" type="hidden" name="hidPageOneNum" runat="server">
			<input id="hidPageNow" type="hidden" name="hidPageNow" runat="server">
		</form>
	</body>
</HTML>
