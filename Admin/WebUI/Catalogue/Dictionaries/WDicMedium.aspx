<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WDicMedium" CodeFile="WDicMedium.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WDicMedium</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />


	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr class="lbPageTitle">
					<td align="center" colSpan="2"><asp:label id="lblHeader" runat="server" CssClass="main-group-form">Vật mang tin</asp:label></td>
				</tr>
				<TR>
					<TD align="right" colSpan="2">
						<table width="100%" border="0">
							<tr>
								<td width="70%">
									<asp:Label id="lblCode" runat="server"><u>K</u>ý hiệu:</asp:Label>
									<asp:TextBox id="txtCode" runat="server" Width="64px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
									<asp:Label id="lblDescription" runat="server"><u>V</u>ật mang tin:</asp:Label>
									<asp:TextBox id="txtDescription" runat="server" Width="160px"></asp:TextBox>
									<asp:Button id="btnNew" runat="server" OnClientClick="CheckAddNew('Ký hiệu không được để trống')" Text="Tạo mới(n)" Width="90px"></asp:Button>
								</td>
								<td align="right" width="30%">
									<asp:label id="lblFilterGrid" runat="server"><u>L</u>ọc:</asp:label>
									<asp:textbox id="txtFilter" runat="server" Width="96px"></asp:textbox>
									<asp:button id="btnFilter" runat="server" Text="Lọc(f)" Width="64px"></asp:button>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				<tr>
					<td colSpan="2">
						<asp:datagrid id="dtgDicIndex" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
							PageSize="15">
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn ItemStyle-Width="5%" DataField="optCheck" ReadOnly="True" HeaderText="Chọn"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Kí hiệu" ItemStyle-Width="8%">
									<ItemTemplate>
										<asp:Label ID="LblCode" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100" CssClass="lbTextBox" runat="server" id="txtCodeG" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Vật mang tin">
									<ItemTemplate>
										<asp:Label ID="lblDescriptionG" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100" CssClass="lbTextBox" runat="server" id="txtDescriptionG" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sửa">
									<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="<img src='../images/edit2.gif' border='0'>" CommandName="Edit" CausesValidation="false" Visible='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' ToolTip="Sửa" ID="Linkbutton1">
										</asp:LinkButton>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:LinkButton runat="server" Text="<img src='../images/update.gif' border='0'>" CommandName="Update"
											ID="lnkdtgUpdate" ToolTip="Cập nhật"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<img src='../images/cancel.gif' border='0'>" CommandName="Cancel"
											CausesValidation="false" ToolTip="Thôi" ID="Linkbutton2"></asp:LinkButton>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<tr class="lbControlBar">
					<td align="right" colspan="2">
						<INPUT id="txtIDs" type="hidden" name="txtIDs" runat="server">
						<asp:label id="lblFilterDrop" runat="server" CssClass="lbLabel"><u>G</u>ộp thành:</asp:label>&nbsp;<asp:textbox id="txtGroup" runat="server" Width="80px" CssClass="lbTextBox" AutoPostBack="True"></asp:textbox>
						<asp:dropdownlist id="ddlDic" runat="server"></asp:dropdownlist>
						<asp:button id="btnGroup" runat="server" CssClass="lbButton" Text="Gộp(m)" Width="64px"></asp:button></td>
				</tr>
			</table>
			<asp:Label ID="lblLabel0" Runat="server" Visible="False">Bạn không được cấp quyền sử dụng chức năng này</asp:Label>
			<asp:Label ID="lblLabel1" Runat="server" Visible="False">Tạo mới</asp:Label>
			<asp:Label ID="lblLabel2" Runat="server" Visible="False">Mã lỗi</asp:Label>
			<asp:Label ID="lblLabel3" Runat="server" Visible="False">Chi tiết lỗi</asp:Label>
			<asp:Label ID="lblLabel4" Runat="server" Visible="False">Mẫu danh mục : </asp:Label>
			<asp:DropDownList ID="ddlAboutAction" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
				<asp:ListItem Value="1">Mẫu danh mục mới chưa được ghi nhận</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật mẫu danh mục thành công</asp:ListItem>
				<asp:ListItem Value="3">Đã ghi nhận mẫu mẫu danh mục mới</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa nhập tên mẫu danh mục</asp:ListItem>
				<asp:ListItem Value="5">Mẫu danh mục mới đã được ghi nhận</asp:ListItem>
				<asp:ListItem Value="6">"Insert: "</asp:ListItem>
				<asp:ListItem Value="7">"Update: "</asp:ListItem>
				<asp:ListItem Value="8">"Delete: "</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
