<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WProcLost" CodeFile="WProcLost.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WProcLost</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="2">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR>
					<TD>
						<asp:label id="lblHeader" runat="server" CssClass="lbPageTitle" Width="100%">Số liệu xếp giá đã thanh lý/mất </asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblCapLib" runat="server" Font-Bold="True">Thư viện:</asp:label>&nbsp;<asp:label id="lblLib" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapLoc" runat="server" Font-Bold="True">Kho:</asp:label>&nbsp;<asp:label id="lblLoc" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapShelf" runat="server" Font-Bold="True">Giá sách:</asp:label>&nbsp;<asp:label id="lblShelf" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<TR>
								<TD><asp:label id="lblDes" runat="server">Bạn có thể phục hồi lại một tư liệu đã bị ghi 
nhận là mất hoặc đã thanh lý. Bản tư liệu này có thể được phục hồi vào vị trí 
cũ hoặc sang một vị trí mới.</asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<P><asp:radiobutton id="optOld" runat="server" Text="Phục hồi vào vị trí <u>c</u>ũ" Checked="True" GroupName="optShelf"></asp:radiobutton></P>
								</TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="optNew" runat="server" Text="Phục hồi vào vị trí <u>s</u>au:" GroupName="optShelf"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblLibInput" runat="server"><u>T</u>hư viện:</asp:label>&nbsp;<asp:dropdownlist id="ddlLib" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:label id="lblLocation" runat="server"><u>K</u>ho:</asp:label>&nbsp;<asp:dropdownlist id="ddlLocation" runat="server"></asp:dropdownlist>&nbsp;<asp:label id="lblShelfInput" runat="server"><u>G</u>iá sách:</asp:label>&nbsp;<asp:textbox id="txtShelf" runat="server" Width="96px"></asp:textbox></TD>
							</TR>
						</table>
						<asp:hyperlink id="lnkCheckAll" runat="server" CssClass="lbLinkFunction">Chọn tất </asp:hyperlink>&nbsp;
						<asp:hyperlink id="lnkUnCheckAll" runat="server" CssClass="lbLinkFunction">Bỏ tất </asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<tr>
					<td><asp:datagrid id="dtgResult" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:TemplateColumn HeaderText="Trạng th&#225;i">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkCopyID" runat="server"></asp:CheckBox>
										<asp:label id="lblCopyID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="LibName" HeaderText="Thư viện"></asp:BoundColumn>
								<asp:BoundColumn DataField="LocName" HeaderText="Kho"></asp:BoundColumn>
								<asp:BoundColumn DataField="Shelf" HeaderText="Gi&#225; s&#225;ch"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ĐKCB">
									<ItemTemplate>
										<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CopyNumber") %>' ID="txtdtgCopynumber">
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh"></asp:BoundColumn>
								<asp:BoundColumn DataField="Volume" HeaderText="Tập"></asp:BoundColumn>
								<asp:BoundColumn DataField="CONTENT" HeaderText="Th&#244;ng tin chi tiết"></asp:BoundColumn>
								<asp:BoundColumn DataField="ACQUIREDDATE" HeaderText="Ng&#224;y bổ sung">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Price" HeaderText="Gi&#225; tiền">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Reason" HeaderText="L&#253; do"></asp:BoundColumn>
								<asp:BoundColumn DataField="REMOVEDDATE" HeaderText="Ng&#224;y ghi nhận mất">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATELASTUSED" HeaderText="Ng&#224;y mượn cuối">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="UseCount" HeaderText="Số lượt mượn">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<input id="txtAction" type="hidden" name="txtAction" runat="server">&nbsp;
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Phục hồi thành công!</asp:ListItem>
				<asp:ListItem Value="3">Phục hồi và mở khoá thành công!</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="5">Phục hồi đăng ký cá biệt đã thanh lý/mất</asp:ListItem>
				<asp:ListItem Value="6">Phục hồi đăng ký cá biệt đã thanh lý/mất và mở khoá</asp:ListItem>
				<asp:ListItem Value="7">ĐKCB:</asp:ListItem>
				<asp:ListItem Value="8">đã tồn tại, bạn phải đổi ĐKCB khác để phục hồi lại.</asp:ListItem>
			</asp:DropDownList>
			<input id="hidCountID" type="hidden" runat="server" value="0" NAME="hidCountID">
		</form>
	</body>
</HTML>
