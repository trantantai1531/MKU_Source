<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WZ3950DB" CodeFile="WZ3950DB.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WZ3950DB</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td colSpan="2" Class="lbPageTitle"><asp:label id="lblHeader" CssClass="lbPageTitle" Runat="server">Nhập CSDL cho máy chủ Z39.50</asp:label></td>
				</tr>
				<tr>
					<td colSpan="2" height="7"></td>
				</tr>
				<tr>
					<td align="right" width="35%"><asp:label id="lblNameDB" Runat="server">Tên cơ sở dữ liệu:</asp:label></td>
					<td><asp:textbox id="txtNameDB" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblDescription" Runat="server">Chi tiết :</asp:label></td>
					<td><asp:textbox id="txtDescription" Width="350px" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="bottom" align="center" colSpan="2" height="30"><asp:button id="btnAddnew" Runat="server" Text="Tạo mới"></asp:button>&nbsp;
						<asp:button id="btnReset" Runat="server" Text="Làm lại"></asp:button>&nbsp;
						<asp:button id="btnClose" Runat="server" Text="  Đóng  "></asp:button></td>
				</tr>
			</table>
			<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td><asp:datagrid id="dtgZServerDB" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ServerID" HeaderText="ServerID"></asp:BoundColumn>
								<asp:BoundColumn DataField="idOrder" ReadOnly="True" HeaderText="STT">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="T&#234;n cơ sở dữ liệu">
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DBName") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id="txtNameDBdtg" CssClass="lbTextBox" Width=100% runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DBName") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chi tiết">
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id="dtxtDescription" CssClass="lbTextBox" Width=100% runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;Image src =&quot;../Images/update.gif&quot; border=0 title=&quot;Cập nhật&quot;&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;"
									CancelText="&lt;Image src =&quot;../Images/Cancel.gif&quot; title=&quot;Th&#244;i&quot;&gt;" EditText="&lt;image src =&quot;../Images/Edit.gif&quot; border=0 title=&quot;Sửa đổi&quot;&gt;">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Text="&lt;IMAGE SRC='../Images/Delete.gif' border=0 title=&quot;Xo&#225; bỏ&quot;&gt;"
									CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<input id="ipServerID" type="hidden" name="ipServerID" runat="server"> <input id="ipAlertEmpty" type="hidden" value="Tên phương thức là bắt buộc!!!" name="ipAlertEmpty">
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">Mã lỗi </asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Nhấn OK nếu thực sự muốn xoá!!!</asp:ListItem>
				<asp:ListItem Value="4">Tên cơ sở dữ liệu là bắt buộc!!!</asp:ListItem>
				<asp:ListItem Value="5">Tên phương thức đã tồn tại!!!</asp:ListItem>
				<asp:ListItem Value="6">Xoá danh mục các phương thức giao nhận</asp:ListItem>
				<asp:ListItem Value="7">Nhập mới danh mục các phuơng thức giao nhận </asp:ListItem>
				<asp:ListItem Value="8">Update danh mục các phuơng thức giao nhận </asp:ListItem>
				<asp:ListItem Value="9">Sửa đổi tên cơ sở dữ liệu có trong máy chủ </asp:ListItem>
				<asp:ListItem Value="10">Địa chỉ máy chủ là bắt buộc</asp:ListItem>
				<asp:ListItem Value="11">Cập nhật thành công</asp:ListItem>
				<asp:ListItem Value="12">Cập nhật không thành công</asp:ListItem>
			</asp:dropdownlist>
			<script language=javascript>
				document.forms[0].txtNameDB.focus();
			</script>
		</FORM>
	</body>
</HTML>
