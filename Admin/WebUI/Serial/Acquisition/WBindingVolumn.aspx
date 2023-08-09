<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WBindingVolumn" CodeFile="WBindingVolumn.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBindingVolumn</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<TD class="lbPageTitle"><asp:label id="lblPageTitle" runat="server" Width="100%" CssClass="main-group-form">Thông tin đóng tập</asp:label></TD>
				</tr>
				<TR>
					<TD>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><asp:label id="lblIssueNo" runat="server">Chọn số:</asp:label><asp:dropdownlist id="ddlIssueNo" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>
									<asp:datagrid id="dtgCopiesToBind" runat="server" AutoGenerateColumns="False" Width="100%">
										<Columns>
											<asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderText="Chọn">
												<ItemTemplate>
													<asp:CheckBox id="chkID" Runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False">
												<ItemTemplate>
													<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
													</asp:label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="IssueNo" HeaderText="Số" ItemStyle-Width="23%"></asp:BoundColumn>
											<asp:BoundColumn DataField="IssuedMonth" HeaderText="Tháng" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="11%"></asp:BoundColumn>
											<asp:BoundColumn DataField="IssuedDate" HeaderText="Ngày phát hành" ItemStyle-HorizontalAlign="Center"
												ItemStyle-Width="23%"></asp:BoundColumn>
											<asp:BoundColumn DataField="ReceivedDate" HeaderText="Ngày nhận" ItemStyle-HorizontalAlign="Center"
												ItemStyle-Width="17%"></asp:BoundColumn>
											<asp:BoundColumn DataField="VolumeByPublisher" HeaderText="Tập (NXB)"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD height="10"></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:button id="btnAdd" runat="server" Width="84px" Text="Thêm số(t)"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="15"></TD>
				</TR>
				<tr>
					<TD><asp:datagrid id="dtgCopiesOfBind" runat="server" HeaderStyle-HorizontalAlign="center" AutoGenerateColumns="False"
							Width="100%">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SerCopyID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="VolumeByLibrary" ReadOnly="True" HeaderText="Tập"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Số">
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IssueNo") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IssueNo") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="IssuedDate" ReadOnly="True" HeaderText="Ng&#224;y ph&#225;t h&#224;nh">
									<ItemStyle HorizontalAlign="Center" Width="24%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ReceivedDate" ReadOnly="True" HeaderText="Ng&#224;y nhận">
									<ItemStyle HorizontalAlign="Center" Width="19%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="VolumeByPublisher" ReadOnly="True" HeaderText="Tập (NXB)"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="X&#243;a">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="&lt;img src=&quot;../../images/delete.gif&quot; border=&quot;0&quot;&gt;"
											CommandName="Delete" CausesValidation="false" ID="lnkdtgDelete"></asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</tr>
				<TR>
					<TD height="10"></TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnUnBind" runat="server" Width="84px" Text="Gỡ tập(u)"></asp:button>&nbsp;
						<asp:button id="btnClose" runat="server" Width="84px" Text="Đóng(d)"></asp:button></TD>
				</TR>
			</table>
			<input id="hidUpdate" type="hidden" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật thành công !</asp:ListItem>
				<asp:ListItem Value="3">Bạn có muốn loại bỏ số này ra khỏi tập hiện hành không ?</asp:ListItem>
				<asp:ListItem Value="4">Bạn có muốn gỡ tập không?</asp:ListItem>
				<asp:ListItem Value="5">Gỡ tập thành công!</asp:ListItem>
				<asp:ListItem Value="6">Gỡ tập ấn phẩm định kỳ</asp:ListItem>
			</asp:DropDownList></form>
	</body>
</HTML>
