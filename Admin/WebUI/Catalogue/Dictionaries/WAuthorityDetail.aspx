<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WAuthorityDetail" CodeFile="WAuthorityDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>WDicIndexClass</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr class="lbPageTitle">
					<td align="left" colSpan="2">
						<asp:label id="lblHeader" runat="server" CssClass="main-head-form">Từ điển</asp:label></td>
				</tr>
				<TR>
					<TD align="right" colSpan="2">
						<asp:label id="lblFilterGrid" runat="server"><u>M</u>ục từ:</asp:label>&nbsp;<asp:textbox id="txtFilter" runat="server" Width="120px"></asp:textbox>&nbsp;<asp:button id="btnFilter" runat="server" Text="Lọc(f)" Width="60px"></asp:button></TD>
				</TR>
				<tr>
					<td colSpan="2" align="center">
						<asp:Label ID="lblNoInfo" Runat="server" Visible="False">Không có mục từ nào !</asp:Label>
                        <div class="table-form">
						<asp:datagrid id="dtgDicIndex" CssClass="table-control" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
							PageSize="15">
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Chọn">
									<ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
									<ItemTemplate>
										<input type="checkbox" id="ckbdtgMerger" Runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' CssClass="lbCheckBox">
										</input>
                                        <label for="ckbdtgMerger" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mục từ">
									<ItemTemplate>
										<asp:Label ID="lblDisplayEntry" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>' Runat="server" CssClass="lbLabel">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" id="txtDisplayEntry" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Iso Code" Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblIsoCode" Text='<%# DataBinder.Eval(Container.DataItem, "IsoCode") %>' Runat="server" CssClass="lbLabel">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" id="txtIsoCode" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "IsoCode") %>' MaxLength="3"/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tên tiếng Anh" Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblName" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' Runat="server" CssClass="lbLabel">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" id="txtName" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tên tiếng Việt" Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblNameViet" Text='<%# DataBinder.Eval(Container.DataItem, "NameViet") %>' Runat="server" CssClass="lbLabel">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" id="txtNameViet" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "NameViet") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Giải thích" Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' Runat="server" CssClass="lbLabel">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" id="txtNote" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chỉ số mức trên" Visible="False">
									<ItemStyle Width="20%"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblParName" Text='<%# DataBinder.Eval(Container.DataItem, "ParName") %>' Runat="server" CssClass="lbLabel">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="0" Runat="server" ID="txtParentID" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "ParentID")%>'/>
										<asp:dropdownlist Runat="server" ID="ddlParName"></asp:dropdownlist>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="AccessEntry" ReadOnly="True" HeaderText="AccessEntry"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Cập nhật">
									<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="<img src='../images/edit2.gif' border='0'>" CommandName="Edit" CausesValidation="false" Visible='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' ToolTip="Sửa">
										</asp:LinkButton>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:LinkButton runat="server" Text="<img src='../images/update.gif' border='0'>" CommandName="Update" ID="lnkdtgUpdate" ToolTip="Cập nhật"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<img src='../images/cancel.gif' border='0'>" CommandName="Cancel" CausesValidation="false" ToolTip="Thôi"></asp:LinkButton>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                            </div>
                            </td>
				</tr>
				<tr class="lbControlBar">
					<td align="right" colspan="2">
						<asp:label id="lblFilterDrop" runat="server"><u>G</u>ộp thành:</asp:label>&nbsp;
                         <div class="input-control" id="divtxtGroup" runat="server"  style="width:120px;  display: inline-block;">
                                <div class="input-form ">
                        <asp:textbox id="txtGroup" CssClass="text-input" runat="server" Width="" AutoPostBack="True">
                            </asp:textbox></div></div>
                         <div id="divddlDic" runat="server" class="input-control" style="width:250px;  display: inline-block;">
                                <div class="dropdown-form" ><asp:dropdownlist id="ddlDic" runat="server"></asp:dropdownlist></div></div>
                        &nbsp;<asp:button id="btnGroup" runat="server" Text="Gộp(m)" Width="64px"></asp:button>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Cập nhật thành công!</asp:ListItem>
				<asp:ListItem Value="4">Gộp thành công!</asp:ListItem>
				<asp:ListItem Value="5">Bạn chưa nhập tên mục từ!</asp:ListItem>
				<asp:ListItem Value="6">Mục từ đã tồn tại trong cơ sở dữ liệu!</asp:ListItem>
				<asp:ListItem Value="7">Cập nhật mục từ:</asp:ListItem>
				<asp:ListItem Value="8">Gộp mục từ:</asp:ListItem>
				<asp:ListItem Value="9">Lỗi ! Bạn phải chọn ít nhất một mục từ khác với mục từ cần gộp!</asp:ListItem>
				<asp:ListItem Value="10">Bạn có muốn gộp mục từ đã chọn không?</asp:ListItem>
				<asp:ListItem Value="11">Bạn phải chọn ít nhất một mục từ trước khi gộp!</asp:ListItem>
				<asp:ListItem Value="12">Tiêu đề</asp:ListItem>
				<asp:ListItem Value="13">Tiêu đề (T.Việt)</asp:ListItem>
				<asp:ListItem Value="14">Tiêu đề (T.Anh)</asp:ListItem>
				<asp:ListItem Value="15">Tên chuyên ngành</asp:ListItem>
				<asp:ListItem Value="16">--- Chọn chỉ số mức trên ---</asp:ListItem>
			</asp:DropDownList>
		    <input id="hidNameTable" runat="server" type="hidden"/> <input id="hidSearchField" runat="server" type="hidden"/>
		    <input id="hidDicIDs" type="hidden" name="hidDicIDs" runat="server"/>
		</form>
	</body>
</HTML>
