<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPhotocopyPrice" CodeFile="WPhotocopyPrice.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Quản lý bảng giá photocopy</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR class="lbPageTitle">
					<td colSpan="3">
						<asp:Label id="lblHeader" runat="server" CssClass="main-group-form">Quản lý bảng giá photocopy</asp:Label></td>
				</TR>
				<TR>
					<TD width="10%">
						<asp:textbox id="txtTypeName" runat="server" Width="190px"></asp:textbox></TD>
					<TD width="20%">
						<asp:textbox id="txtPricePerPage" runat="server" Width="110px"></asp:textbox></TD>
					<TD width="40%">
						<asp:button id="btnNew" runat="server" Text="Thêm mới(a)" Width="88px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Làm lại(r)" Width="75px"></asp:button></TD>
				</TR>
				<TR>
					<td colSpan="3">
						<asp:datagrid id="dtgListPrice" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
							PageSize="10">
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"TypeID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Loại giấy photocopy">
									<HeaderStyle Width="40%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblTypeName" Text='<%# DataBinder.Eval(Container.DataItem, "TypeName") %>' Runat="server" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="150px" MaxLength="100" runat="server" id="txtTypeNameGrid" Text='<%# DataBinder.Eval(Container.DataItem, "TypeName") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Giá tiền" ItemStyle-HorizontalAlign="Right">
									<HeaderStyle Width="40%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblPricePerPage" Text='<%# DataBinder.Eval(Container.DataItem, "PricePerPage") %>' Runat="server" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="150px" MaxLength="100" runat="server" id="txtPricePerPageGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PricePerPage") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;"
									CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:EditCommandColumn>
								<asp:TemplateColumn HeaderText="Chọn" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="chkTypeID"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<TR class="lbControlBar">
					<TD align="center" colSpan="3">
						<asp:button id="btnDel" runat="server" Text="Xoá(d)" Width="64px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="70px"></asp:button></TD>
				</TR>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Dữ liệu không hợp lệ</asp:ListItem>
				<asp:ListItem Value="3">Nhập mới loại giá photocopy</asp:ListItem>
				<asp:ListItem Value="4">Sửa loại giá photocopy</asp:ListItem>
				<asp:ListItem Value="5">Xoá loại giá photocopy</asp:ListItem>
				<asp:ListItem Value="6">Bạn đã nhập thông tin cho loại giá photocopy này!</asp:ListItem>
				<asp:ListItem Value="7">thành công!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
