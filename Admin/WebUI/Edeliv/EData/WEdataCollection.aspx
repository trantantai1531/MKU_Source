<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WEdataCollection" CodeFile="WEdataCollection.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WEdataCollection</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
				<TR class="lbPageTitle">
					<td align="center" width="100%" colSpan="3">
						<asp:label id="lblCollectionTitle" runat="server" cssclass="lbPageTitle">Duyệt xem các bộ sưu tập</asp:label></td>
				</TR>
				<TR>
					<td vAlign="top" width="30%">
						<asp:label id="lblCollectionnName" runat="server">Tên <U>b</U>ộ sưu tập:</asp:label><br>
						<asp:textbox id="txtCollectionName" runat="server" Width="200px"></asp:textbox>
					<td vAlign="top">
						<asp:label id="lblDes" runat="server"><U>M</U>ô tả bộ sưu tập:</asp:label><br>
						<asp:textbox id="txtDes" runat="server" TextMode="MultiLine" Width="400px"></asp:textbox>&nbsp;<asp:button id="btnAdd" runat="server" Text="Thêm(e)"></asp:button></td>
					</td>
				</TR>
				<TR>
					<TD colSpan="3"><asp:datagrid id="dtgCollection" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
							PageSize="8" CellPadding="3">
							<Columns>
								<asp:BoundColumn Visible="False" DataField="CollectionID" ReadOnly="True" HeaderText="CollectionID"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Bộ sưu tập">
									<HeaderStyle HorizontalAlign="Left" Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Collection") %>' ID="Label2">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgCollection" CssClass="lbTextBox" runat="server" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.Collection") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mô tả bộ sưu tập">
									<HeaderStyle HorizontalAlign="Left" Width="50%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' ID="Label1">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgDescription" CssClass="lbTextBox" runat="server" TextMode="MultiLine" Width="400px" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sửa" HeaderStyle-HorizontalAlign="Center">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="<image src ='../Images/Edit.gif' border='0' title='Sửa đổi'>"
											CommandName="Edit" CausesValidation="false" ID="Linkbutton1"></asp:LinkButton>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Img src ='../Images/update.gif' border='0' title='Cập nhật'>"
											CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='../Images/Cancel.gif' border='0' title='Thôi'>"
											CommandName="Cancel" CausesValidation="false" ID="Linkbutton2"></asp:LinkButton>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Text="&lt;IMAGE SRC='../Images/Delete.gif' border='0' title=&quot;Xoá bỏ&quot;&gt;"
									HeaderText="Xoá" CommandName="Delete" HeaderStyle-HorizontalAlign="Center">
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:TemplateColumn HeaderText="Chọn" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="20px"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox ID="cbkOption" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="lblCollectionMerger" runat="server"><u>B</u>ộ sưu tập:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlCollection" runat="server"></asp:dropdownlist>&nbsp;
						<asp:button id="btnMerger" runat="server" Text=" Gộp(g) "></asp:button></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False" Width="0px">
				<asp:ListItem Value="0">Nhấn OK để khẳng định xoá bộ sưu tập này</asp:ListItem>
				<asp:ListItem Value="1">Bạn chưa điền giá trị !</asp:ListItem>
				<asp:ListItem Value="2">Bộ sưu tập </asp:ListItem>
				<asp:ListItem Value="3">đã tồn tại trong cơ sở dữ liệu !</asp:ListItem>
				<asp:ListItem Value="4">Lỗi ! Bạn phải chọn ít nhất một bộ sưu tập khác với bộ sưu tập cần gộp!</asp:ListItem>
				<asp:ListItem Value="5">Bạn có muốn gộp các các bộ sưu tập đã chọn không?</asp:ListItem>
				<asp:ListItem Value="6">Bạn phải chọn ít nhất một bộ sưu tập trước khi gộp!</asp:ListItem>
				<asp:ListItem Value="7">Gộp thành công</asp:ListItem>
				<asp:ListItem Value="8">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="9">Thêm mới bộ sưu tập</asp:ListItem>
				<asp:ListItem Value="10">Cập nhật thông tin bộ sưu tập</asp:ListItem>
				<asp:ListItem Value="11">Gộp các bộ sưu tập</asp:ListItem>
				<asp:ListItem Value="12">Xoá bộ sưu tập</asp:ListItem>
				<asp:ListItem Value="13">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="14">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="15">Cập nhật thành công !</asp:ListItem>
				<asp:ListItem Value="16">Thêm mới thành công !</asp:ListItem>
			</asp:dropdownlist></form>
		</FORM>
		<script language = javascript>
			document.forms[0].txtCollectionName.focus();
		</script>
	</body>
</HTML>
