<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WProcReceiveDisplay" CodeFile="WProcReceiveDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WProcReceiveDisplay</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR>
					<TD><asp:label id="lblHeader" runat="server" Width="100%" CssClass="lbPageTitle">Số liệu xếp giá chưa kiểm nhận nhập kho </asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblCapLib" runat="server" Font-Bold="True">Thư viện:</asp:label>&nbsp;<asp:label id="lblLib" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapLoc" runat="server" Font-Bold="True">Kho:</asp:label>&nbsp;<asp:label id="lblLoc" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapShelf" runat="server" Font-Bold="True">Giá sách:</asp:label>&nbsp;<asp:label id="lblShelf" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<TR>
								<TD><asp:label id="lblDes" runat="server">Đánh dấu những tài liệu muốn kiểm nhận và bấm nút kiểm nhận hoặc "kiểm nhận/mở khóa". Bạn có thể quy định lại vị trí xếp giá của các ấn phẩm được kiểm nhận cho phù hợp với thứ tự trong kho</asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<P><asp:radiobutton id="optOld" runat="server" GroupName="optShelf" Checked="True" Text="Xếp vào vị trí chỉ ra hiển th <u>ị</u>"></asp:radiobutton></P>
								</TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="optNew" runat="server" GroupName="optShelf" Text="Xếp vào vị trí sa<u>u</u>:"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblLibInput" runat="server"><u>T</u>hư viện:</asp:label><asp:dropdownlist id="ddlLib" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:label id="lblLocation" runat="server"><u>K</u>ho:</asp:label><asp:dropdownlist id="ddlLocation" runat="server"></asp:dropdownlist>&nbsp;<asp:label id="lblShelfInput" runat="server"><u>G</u>iá sách:</asp:label><asp:textbox id="txtShelf" runat="server" Width="96px"></asp:textbox></TD>
							</TR>
						</table>
						<asp:hyperlink id="lnkCheckAll" runat="server" CssClass="lbLinkFunction">Chọn tất </asp:hyperlink>&nbsp;
						<asp:hyperlink id="lnkUnCheckAll" runat="server" CssClass="lbLinkFunction">Bỏ tất </asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<tr>
					<td><asp:datagrid id="dtgResult" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="20">
							<Columns>
								<asp:TemplateColumn HeaderText="Trạng thái">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkCopyID" runat="server" Visible='<%#Not DataBinder.Eval(Container.dataItem,"InUsed") %>'>
										</asp:CheckBox>
										<input type=hidden id="hidCopyID" runat =server value ='<%# DataBinder.Eval(Container.dataItem,"ID") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ÐKCB">
									<HeaderStyle Width="6%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Volume" HeaderText="Tập">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CONTENT" HeaderText="Thông tin chi tiết">
									<HeaderStyle Width="50%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ACQUIREDDATE" HeaderText="Ngày bổ sung">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Price" HeaderText="Giá tiền">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Note" HeaderText="Ghi chú"></asp:BoundColumn>
							</Columns>
							<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><input id="txtAction" type="hidden" name="txtAction" runat="server">&nbsp;
					</td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabel" Width="0" Visible="False" Runat="server">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Kiểm nhận thành công!</asp:ListItem>
				<asp:ListItem Value="3">Kiểm nhận và mở khoá thành công!</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="5">Kiểm nhận đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="6">Kiểm nhận đăng ký cá biệt và mở khóa</asp:ListItem>
				<asp:ListItem Value="7">Không tìm thấy dữ liệu!!!</asp:ListItem>
			</asp:dropdownlist><input id="hidCountID" type="hidden" value="0" name="hidCountID" runat="server">
			<input type="hidden" id="hidTotalCopyIDs" runat="server">
		</form>
	</body>
</HTML>
