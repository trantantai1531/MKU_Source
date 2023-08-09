<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WShelfPos" CodeFile="WShelfPos.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WShelfPos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="1" width="100%">
				<TR Class="lbPageTitle">
					<td>
						<asp:label id="lblTitle" width="100%" CssClass="lbPageTitle" runat="server">Sơ đồ giá sách</asp:label></td>
				</TR>
				<tr>
					<td>
						<asp:label id="lblLibrary" runat="server"><u>T</u>hư viện:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlLibrary" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblLocation" Runat="server"><U>K</U>ho:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlLocation" AutoPostBack="True" Runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="1" cellPadding="1" width="100%">
							<tr>
								<td align="right" width="15%">
									<asp:label id="lblShelf" Runat="server"><U>G</U>iá sách:</asp:label></td>
								<td>
									<asp:textbox id="txtShelf" Runat="server" Width="72px" MaxLength="10"></asp:textbox></td>
								<td align="right" width="7%">
									<asp:label id="lblShelfWidth" Runat="server">Chiều <u>r</u>ộng giá:</asp:label></td>
								<td>
									<asp:textbox id="txtShelfWidth" Runat="server" Width="80px" MaxLength="6"></asp:textbox>&nbsp;
									<asp:label id="lblUnitCm1" Runat="server">(cm)</asp:label></td>
							</tr>
							<tr>
								<td align="right">
									<asp:label id="lblDirection" Runat="server"><u>P</u>hương:</asp:label></td>
								<td>
									<asp:DropDownList ID="ddlDirection" Runat="server">
										<asp:ListItem Value="0" Selected="True">Ngang</asp:ListItem>
										<asp:ListItem Value="1">Dọc</asp:ListItem>
									</asp:DropDownList>
								</td>
								<td align="right">
									<asp:label id="lblShelfDepth" Runat="server">Chiều dà<U>i</U> giá:</asp:label></td>
								<td>
									<asp:textbox id="txtShelfDepth" Runat="server" Width="80px" MaxLength="6"></asp:textbox>&nbsp;<asp:label id="lblUnitCm2" Runat="server">(cm)</asp:label></td>
							</tr>
							<tr>
								<td width="50%" colSpan="4" class="lbGroupTitle">
									<asp:label id="lblLeftTopCoor" Runat="server" Width="100%" ForeColor="#FFFFFF">Vị trí của giá trong sơ đồ kho. Toạ độ đỉnh (góc trên bên trái) của giá trong sơ đồ kho.</asp:label></td>
							</tr>
							<tr>
								<td align="right">
									<asp:label id="lblTopCoor" Runat="server"><U>T</U>ung độ:</asp:label></td>
								<td>
									<asp:textbox id="txtTopCoor" Runat="server" Width="80px" MaxLength="6"></asp:textbox>&nbsp;<asp:label id="lblUnitPixel1" Runat="server">(pixels)</asp:label></td>
								<td align="right">
									<asp:label id="lblLeftCoor" Runat="server"><U>H</U>oành độ:</asp:label></td>
								<td>
									<asp:textbox id="txtLeftCoor" Runat="server" Width="80px" MaxLength="6"></asp:textbox>&nbsp;<asp:label id="lblUnitPixel2" Runat="server">(pixels)</asp:label></td>
							</tr>
							<tr>
								<td class="lbGroupTitle" colSpan="4">
									<asp:label id="lblHelp" Runat="server" ForeColor="#FFFFFF">Nếu không rõ tung độ và hoành độ của giá trong sơ đồ kho, bạn hãy nhấn</asp:label>&nbsp;
									<asp:hyperlink id="lnkShowSchema" Runat="server" NavigateUrl="#" ForeColor="#ccff99">vào đây</asp:hyperlink>&nbsp;
									<asp:label id="lblHelp1" Runat="server" ForeColor="#FFFFFF">để xác định.</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class="lbControlBar">
					<td align="center">
						<asp:button id="btnAddNew" Runat="server" Text="Tạo mới(c)" Width="90px"></asp:button>
						<asp:button id="btnReset" Runat="server" Text="Làm lại(r)" Width="90px"></asp:button></td>
				</tr>
				<tr>
					<td>
						<asp:datagrid id="dtgContent" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn HeaderText="Tên giá">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Shelf") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgShelf" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Shelf") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chiều rộng(cm)">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Width") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgWidth" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Width") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chiều dài(cm)">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Depth") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgDepth" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Depth") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Phương">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.lbDirection") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:DropDownList ID="ddldtgDirection" Runat="server" CssClass="lbDropDownList">
											<asp:ListItem Value="0" Selected="True">Ngang</asp:ListItem>
											<asp:ListItem Value="1">Dọc</asp:ListItem>
										</asp:DropDownList>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tung độ(pixel)">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TopCoor") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgTopCoor" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TopCoor") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Hoành độ(pixel)">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LeftCoor") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgLeftCoor" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LeftCoor") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sửa">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="<image src ='../../Images/Edit.gif' border=0 title='Sửa'>"
											CommandName="Edit" CausesValidation="false" ID="Linkbutton1"></asp:LinkButton>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:LinkButton ID="lnkdtgUpdate" runat="server" Text="<Image src ='../../Images/update.gif' border=0 title='Cập nhật'>"
											CommandName="Update"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='../../Images/Cancel.gif' border=0 title='Thôi'>"
											CommandName="Cancel" CausesValidation="false" ID="Linkbutton2"></asp:LinkButton>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Text="<Image src ='../../Images/Delete.gif' border=0 title='Xoá'>" HeaderText="Xoá"
									CommandName="Delete">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="Direction" ReadOnly="True" HeaderText="Direction"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Shelf" ReadOnly="True" HeaderText="Shelf"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Nhấn OK để khẳng định xoá phương thức này !</asp:ListItem>
				<asp:ListItem Value="1">Trường này không nhận giá trị rỗng!</asp:ListItem>
				<asp:ListItem Value="2">Giá trị không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="3">Ngang</asp:ListItem>
				<asp:ListItem Value="4">Dọc</asp:ListItem>
				<asp:ListItem Value="5">Tạo mới giá sách và vị trí giá sách:</asp:ListItem>
				<asp:ListItem Value="6">Cập nhật giá sách và sơ đồ giá sách:</asp:ListItem>
				<asp:ListItem Value="7">Xoá giá sách và sơ đồ giá sách:</asp:ListItem>
				<asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="9">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="10">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="11">Khuôn dạng dữ liệu không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="12">Giá đã tồn tại trong cơ sở dữ liệu!</asp:ListItem>
				<asp:ListItem Value="13">Giá trị vượt quá giới hạn cho phép.</asp:ListItem>
			</asp:dropdownlist>
			<input id="hidIndex" runat="server" type="hidden" name="hidIndex">
		</form>
		<script language="javascript">
			document.forms[0].txtShelf.focus();
		</script>
	</body>
</HTML>
