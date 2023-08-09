<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WDicItemType" CodeFile="WDicItemType.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WDicItemType</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr class="lbPageTitle">
					<td align="center" colSpan="2"><asp:label id="lblHeader" runat="server" CssClass="lbPageTitle">Dạng tài liệu</asp:label></td>
				</tr>
				<TR>
					<TD align="right" colSpan="2">
						<table width="100%" border="0">
							<tr>
								<td width="64%">
									<asp:label id="lblCode" runat="server"><u>K</u>ý hiệu:</asp:label>&nbsp;<asp:textbox id="txtCode" runat="server" Width="64px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblDescription" runat="server"><u>D</u>ạng tài liệu:</asp:label>&nbsp;<asp:textbox id="txtDescription" runat="server" Width="170px"></asp:textbox>
									<asp:button id="btnNew" runat="server" Text="Tạo mới(n)" Width="90px"></asp:button></td>
								<td align="right">
									<asp:label id="lblFilterGrid" runat="server"><u>D</u>ạng tài liệu:</asp:label>&nbsp;<asp:textbox id="txtFilter" runat="server" CssClass="lbTextBox" Width="96px"></asp:textbox>
									<asp:button id="btnFilter" runat="server" Text="Lọc(f)" Width="60px"></asp:button>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				<tr>
					<td align="center" colSpan="2">
						<asp:label id="lblNoInfo" Visible="False" Runat="server">Không có dạng tài liệu nào !</asp:label>
                        <div class="table-form">
                            <asp:datagrid id="dtgDicIndex" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							PageSize="15">
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Chọn">
									<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="ckbdtgMerger" Runat="server" Text="&nbsp;" Visible='<%# DataBinder.Eval(Container.DataItem, "Enable") %>'>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Kí hiệu">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="LblTypeCode" Text='<%# DataBinder.Eval(Container.DataItem, "TypeCode") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100" CssClass="lbTextBox" runat="server" id="txtTypeCode" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "TypeCode") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Dạng tài liệu">
									<ItemTemplate>
										<asp:Label ID="lblTypeName" Text='<%# DataBinder.Eval(Container.DataItem, "TypeName") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100" CssClass="lbTextBox" runat="server" id="txtTypeName" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "TypeName") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sửa">
									<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="<img src='../images/edit2.gif' border='0'>" CommandName="Edit" CausesValidation="false" Visible='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' ToolTip="Sửa">
										</asp:LinkButton>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:LinkButton runat="server" Text="<img src='../images/update.gif' border='0'>" CommandName="Update"
											ID="lnkdtgUpdate" ToolTip="Cập nhật"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<img src='../images/cancel.gif' border='0'>" CommandName="Cancel"
											CausesValidation="false" ToolTip="Thôi"></asp:LinkButton>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                        </div>
						</td>
				</tr>
				<tr class="lbControlBar">
					<td align="right" colSpan="2">
						<asp:label id="lblFilterDrop" runat="server" CssClass="lbLabel"><u>G</u>ộp thành:</asp:label>&nbsp;<asp:textbox id="txtGroup" runat="server" CssClass="lbTextBox" Width="80px" AutoPostBack="True"></asp:textbox>&nbsp;<asp:dropdownlist id="ddlDic" runat="server"></asp:dropdownlist>
						<asp:button id="btnGroup" runat="server" CssClass="lbButton" Text="Gộp(m)" Width="64px"></asp:button></td>
				</tr>
			</table>
			<input id="hidDicIDs" type="hidden" name="hidDicIDs" runat="server">
			<asp:dropdownlist id="ddlLabel" Width="0px" Visible="False" Runat="server">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Cập nhật thành công !</asp:ListItem>
				<asp:ListItem Value="4">Tạo mới thành công !</asp:ListItem>
				<asp:ListItem Value="5">Bạn chưa nhập ký hiệu dạng tài liệu!</asp:ListItem>
				<asp:ListItem Value="6">Tạo mới dạng tài liêu :</asp:ListItem>
				<asp:ListItem Value="7">Cập nhật dạng tài liêu :</asp:ListItem>
				<asp:ListItem Value="8">Gộp dạng tài liệu :</asp:ListItem>
				<asp:ListItem Value="9">Lỗi ! Bạn phải chọn ít nhất một dạng tài liệu khác với dạng tài liệu cần gộp!</asp:ListItem>
				<asp:ListItem Value="10">Bạn có muốn gộp dạng tài liệu đã chọn không?</asp:ListItem>
				<asp:ListItem Value="11">Bạn phải chọn ít nhất một dạng tài liệu trước khi gộp!</asp:ListItem>
				<asp:ListItem Value="12">Gộp thành công!</asp:ListItem>
				<asp:ListItem Value="13">Ký hiệu sách đã tồn tại trong cơ sở dữ liệu!</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
