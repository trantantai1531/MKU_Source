<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WDicIndexClass" CodeFile="WDicIndexClass.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WDicIndexClass</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="center" colSpan="2"><asp:label id="lblHeader" runat="server">Từ điển</asp:label></td>
				</tr>
				<TR>
					<TD align="right" colSpan="2"><asp:label id="lblFilterGrid" runat="server" CssClass="lbLabel"><u>L</u>ọc</asp:label><asp:textbox id="txtFilter" runat="server" Width="96px" CssClass="lbTextBox"></asp:textbox><asp:button id="btnFilter" runat="server" CssClass="lbButton" Text="Lọc (c)"></asp:button></TD>
				</TR>
				<tr>
					<td colSpan="2"><asp:datagrid id="dtgDicIndex" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
							<Columns>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="1px"></HeaderStyle>
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="optCheck" ReadOnly="True">
									<HeaderStyle Width="1px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="DisplayEntry">
									<ItemTemplate>
										<asp:Label ID="lblDisplayEntry" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Width="100" CssClass="lbTextBox" runat="server" id="txtDisplayEntry" Enabled='<%# DataBinder.Eval(Container.DataItem, "Enable") %>' Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="AccessEntry" ReadOnly="True" HeaderText="AccessEntry"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../images/update.gif&quot; border=&quot;0&quot;&gt;"
									CancelText="&lt;img src=&quot;../images/cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../images/edit2.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td width="20%">&nbsp;&nbsp;&nbsp;<INPUT id="txtIDs" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" name="txtIDs"
							runat="server"></td>
					<td align="right" width="80%"><asp:label id="lblFilterDrop" runat="server" CssClass="lbLabel"><u>G</u>ộp thành</asp:label>&nbsp;<asp:textbox id="txtGroup" runat="server" Width="80px" CssClass="lbTextBox" AutoPostBack="True"></asp:textbox>&nbsp;<asp:dropdownlist id="ddlDic" runat="server"></asp:dropdownlist>&nbsp;<asp:button id="btnGroup" runat="server" CssClass="lbButton" Text="Gộp (p)"></asp:button></td>
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
