<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WIndexDatabase" CodeFile="WIndexDatabase.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexUser</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="document.forms[0].txtConnectionName.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="2" width="100%" border="0">
				<TBODY>
					<TR class="lbPageTitle">
						<TD width="45%"><asp:label id="lblPageTitle1" runat="server" CssClass="lbPageTitle">Các kết nối tới cơ sở dữ liệu hiện thời</asp:label></TD>
						<TD><asp:label id="lblPageTitle2" runat="server" CssClass="lbPageTitle">Thông tin chi tiết</asp:label></TD>
					</TR>
					<TR>
						<TD width="45%"><asp:label id="lblNote2" runat="server">Bấm vào đường link để đặt lại các tham số kết nối tương ứng.</asp:label></TD>
						<TD><asp:label id="lblNote" runat="server">* Khi cập nhật các tham số, phải nhập mật khẩu cũ.</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD vAlign="top"><asp:datagrid id="dtgDatabase" runat="server" Width="100%" AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<HeaderTemplate>
														<input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dtgDatabase', 'chkID', 3, 10);">
													</HeaderTemplate>
													<ItemTemplate>
														<asp:CheckBox CssClass="lbCheckBox" ID="chkID" Runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="T&#234;n c&#225;c kết nối đ&#227; được tạo cho người d&#249;ng">
													<ItemTemplate>
														<asp:HyperLink Runat="server" ID="lnkDatabase" CssClass="lbLinkFunction">
															<%#DataBinder.Eval(Container.DataItem, "ConnectionName")%>
														</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False">
													<ItemTemplate>
														<asp:Label id="lblID" text='<%# DataBinder.Eval(Container.DataItem,"ID") %>' Runat="server">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR class="lbControlBar">
									<TD><asp:button id="btnDelete" runat="server" Width="70px" Text="Xoá(d)"></asp:button></TD>
								</TR>
								<TR>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top">
							<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR class="lbGroupTitle">
									<TD align="center" colSpan="2"><asp:label id="lblTitle" Runat="server" CssClass="lbGroupTitle">Thay đổi mật khẩu đăng nhập cơ sở dữ liệu</asp:label></TD>
								</TR>
								<TR>
									<TD align="right" width="30%"><asp:label id="lblConnectionName" CssClass="lbLabel" Runat="server"><u>T</u>ên kết nối:&nbsp;</asp:label></TD>
									<TD><asp:textbox id="txtConnectionName" CssClass="lbTextbox" Width="248px" Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right"><asp:label id="lblServerIP" CssClass="lbLabel" Runat="server">Địa chỉ <u>I</u>P máy chủ:&nbsp;</asp:label></TD>
									<TD><asp:textbox id="txtServerIP" CssClass="lbTextbox" Width="184px" Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right"><asp:label id="lblDatabase" CssClass="lbLabel" Runat="server">Hệ quản trị CS<u>D</u>L:&nbsp;</asp:label></TD>
									<TD><asp:dropdownlist id="ddlDatabase" Runat="server" Visible="True">
											<asp:ListItem Value="0">SQLSERVER</asp:ListItem>
											<asp:ListItem Value="1">ORACLE</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="right"><asp:label id="lblDataSource" CssClass="lbLabel" Runat="server">Tên <u>c</u>ơ sở dữ liệu:&nbsp;</asp:label></TD>
									<TD><asp:textbox id="txtDataSource" CssClass="lbTextbox" Width="150px" Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right"><asp:label id="lblUserName" CssClass="lbLabel" Runat="server"><u>T</u>ên đăng nhập:&nbsp;</asp:label></TD>
									<TD><asp:textbox id="txtUserName" CssClass="lbTextbox" Width="150px" Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right"><asp:label id="lblPasswordOld" CssClass="lbLabel" Runat="server"><u>M</u>ật khẩu:&nbsp;</asp:label></TD>
									<TD><asp:textbox id="txtPasswordOld" CssClass="lbTextbox" Width="150px" Runat="server" TextMode="Password"></asp:textbox></TD>
								</TR>
								<tr>
									<td colspan="2">
										<table id="tblPassword" cellpadding="2" cellspacing="0" border="0" width="100%">
											<TR>
												<TD align="right" width="30%"><asp:label id="lblPassWordNew" CssClass="lbLabel" Runat="server"><u>M</u>ật <u>k</u>hẩu mới:&nbsp;</asp:label></TD>
												<TD><asp:textbox id="txtPasswordNew" CssClass="lbTextbox" Width="150px" Runat="server" TextMode="Password"></asp:textbox></TD>
											</TR>
										</table>
									</td>
								</tr>
								<TR>
									<td></td>
									<td><asp:checkbox id="chkRun" CssClass="lbCheckBox" Text="Chọn mặc định" Runat="server"></asp:checkbox></td>
								</TR>
								<TR class="lbControlBar">
									<TD align="center" colSpan="2"><asp:button id="btnAdd" runat="server" Width="78px" Text="Nhập(u)"></asp:button>&nbsp;<asp:button id="btnTest" runat="server" Width="90px" Text="Kiểm tra(r)"></asp:button>&nbsp;<asp:button id="btnReset" runat="server" Width="98px" Text="Tạo mới(c)"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False" Height="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập tên cho kết nối</asp:ListItem>
				<asp:ListItem Value="4">Bạn đang chọn hệ quản trị CSDL SQLSERVER, địa chỉ IP của máy chủ là bắt buộc !</asp:ListItem>
				<asp:ListItem Value="5">Tên cơ sở dữ liệu còn trống !</asp:ListItem>
				<asp:ListItem Value="6">Tên đăng nhập còn trống !</asp:ListItem>
				<asp:ListItem Value="7">Việc thay đổi thông tin kết nối CSDL sẽ ảnh hưởng tới công việc của tất cả những người đang sử dụng phần mềm này! Bạn có chắc chắn thay đổi không ?</asp:ListItem>
				<asp:ListItem Value="8">Kết nối thành công!</asp:ListItem>
				<asp:ListItem Value="9">Kết nối không thành công!</asp:ListItem>
				<asp:ListItem Value="10">Tên kết nối đã tồn tại!</asp:ListItem>
				<asp:ListItem Value="11">Dữ liệu được đã được cập nhật thành công!</asp:ListItem>
			</asp:dropdownlist><input id="hidConnID" type="hidden" name="hidConnID" runat="server" value="0">
			<input id="hidUpdate" type="hidden" name="hidUpdate" runat="server" value="0">
			<script language="javascript">
				if (document.forms[0].hidUpdate.value==0) {
					ShowHideTable(0);
				}
				else {
					ShowHideTable(1);
				}
			</script>
		</form>
	</body>
</HTML>
