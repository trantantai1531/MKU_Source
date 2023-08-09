<%@ Reference Page="~/Circulation/WSearchCopyNumber.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WSearchCopyNumber" CodeFile="WSearchCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tìm kiếm tài liệu gắn kèm với file điện tử</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr>
					<td class="lbPageTitle" align="left" colSpan="4"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tìm kiếm mã tài liệu</asp:label></td>
				</tr>
				<tr height="10">
					<td colSpan="4"></td>
				</tr>
				<tr align="center">
					<td align="right" width="20%"><asp:label id="lblTitle" runat="server" CssClass="lbLabel"><u>N</u>han đề chính:</asp:label></td>
					<td align="left" width="30%"><asp:textbox id="txtTitle" runat="server" CssClass="lbTextbox" Width="100%"></asp:textbox></td>
					<TD align="right" width="20%"><asp:label id="lblCallNumber" style="Z-INDEX: 115" runat="server" CssClass="lbLabel">Số định danh:</asp:label></TD>
					<TD align="left" width="30%"><asp:textbox id="txtCallNumber" style="Z-INDEX: 116" runat="server" CssClass="lbTextbox" width="100%"></asp:textbox></TD>
				</tr>
				<tr align="center">
					<td align="right"><asp:label id="lblISBN" runat="server" CssClass="lbLabel"><u>I</u>SBN:</asp:label></td>
					<td align="left"><asp:textbox id="txtISBN" runat="server" CssClass="lbTextbox" width="100%"></asp:textbox></td>
					<TD align="right"><asp:label id="lblAuthor" style="Z-INDEX: 105" runat="server" CssClass="lbLabel"><u>T</u>ác giả:</asp:label></TD>
					<TD align="left"><asp:textbox id="txtAuthor" style="Z-INDEX: 106" runat="server" CssClass="lbTextbox" width="100%"></asp:textbox></TD>
				</tr>
				<TR align="center">
					<TD align="right"><asp:label id="lblCopyNumber" style="Z-INDEX: 103" runat="server" CssClass="lbLabel"><u>M</u>ã xếp giá:</asp:label></TD>
					<TD align="left"><asp:textbox id="txtCopyNumber" style="Z-INDEX: 104" runat="server" CssClass="lbTextbox" width="100%"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblPublisher" style="Z-INDEX: 107" runat="server" CssClass="lbLabel">Nhà xuất <u>b</u>ản:</asp:label></TD>
					<TD align="left"><asp:textbox id="txtPublisher" style="Z-INDEX: 108" runat="server" CssClass="lbTextbox" width="100%"></asp:textbox></TD>
				</TR>
				<TR align="center">
					<TD align="right"><asp:label id="lblYear" runat="server" CssClass="lbLabel">Năm <u>x</u>uất bản:</asp:label></TD>
					<TD align="left"><asp:textbox id="txtYear" runat="server" CssClass="lbTextbox" Width="100%"></asp:textbox></TD>
					<TD align="right"></TD>
					<TD align="left"><asp:button id="btnSearch" runat="server" CssClass="lbButton" Width="48px" Text="Tìm(f)"></asp:button>&nbsp;<asp:button id="btnReset" runat="server" CssClass="lbButton" Width="64px" Text="Đặt lại(r)"></asp:button>&nbsp;<asp:button id="btnClose" runat="server" CssClass="lbButton" Width="64px" Text="Đóng(c)"></asp:button></TD>
				</TR>
			</table>
			<table width="100%" border="0">
				<TR>
					<TD align="center"><asp:label id="lblCapResult" runat="server" CssClass="lbLabel" Visible="False">Tìm thấy:</asp:label>&nbsp;
						<asp:label id="lblResult" runat="server" Visible="False" ForeColor="Maroon" Font-Bold="True"></asp:label>&nbsp;
						<asp:label id="lblCap" runat="server" CssClass="lbLabel" Visible="False">bản ghi biên mục</asp:label><asp:label id="lblNotFound" CssClass="lbLabel" Visible="False" Runat="server">Không tìm thấy bản ghi nào thỏa mãn các điều kiện đặt ra </asp:label></TD>
				</TR>
				<TR>
					<td align="center"><asp:datagrid id="DgrResult" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							PageSize="15">
							<Columns>
								<asp:TemplateColumn SortExpression="Title" HeaderText="Nhan đề">
									<HeaderStyle Width="100%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink ID="lnkTitle" Runat="server">
											<%# DataBinder.Eval(Container.dataItem,"Title")%>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<tr class="lbControlBar">
					<td align="center">
						<asp:button id="btnClose2" runat="server" CssClass="lbButton" Width="64px" Text="Đóng(c)"></asp:button>
					</td>
				</tr>
			</table>
			<asp:DropDownList Runat="server" id="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="3">Kích vào đây nếu muốn chọn tài liệu này</asp:ListItem>
				<asp:ListItem Value="4">Năm xuất bản phải là kiểu số !</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
