<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WFindAuthorityID" CodeFile="WFindAuthorityID.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WFilterAuthority</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" align="center" cellpadding="0" cellspacing="0">
				<TBODY>
					<tr class="lbPageTitle">
						<td align="left" colSpan="2"><asp:label id="lblTitle" CssClass="lbPageTitle" Runat="server">Sửa bản ghi dữ liệu căn cứ (Authority)</asp:label></td>
					</tr>
					<tr class="lbGroupTitle">
						<td colSpan="2"><asp:label id="lblSubTitle1" Runat="server" cssclass="lbGroupTitle">Nhập mã số <u>b</u>iểu ghi dữ liệu căn cứ cần sửa:</asp:label></td>
					</tr>
					<TR>
						<TD colSpan="2" height="5"></TD>
					</TR>
					<tr>
						<td align="right" width="20%"><asp:label id="lblAuthorityID" Runat="server">Mã số biểu gh<u>i</u>:</asp:label>&nbsp;</td>
						<td align="left" width="80%"><asp:textbox id="txtAuthorityID" Runat="server" Width="96px"></asp:textbox>&nbsp;<asp:button id="btnModify" Runat="server" Text="Sửa(m)"></asp:button></td>
					</tr>
					<tr>
						<td colSpan="2" height="5" rowSpan="1"></td>
					</tr>
					<tr class="lbGroupTitle">
						<td colSpan="2"><asp:label cssclass="lbGroupTitle" id="lblSubTitle2" Runat="server">Hoặc tìm biểu ghi này:</asp:label></td>
					</tr>
					<TR>
						<TD colSpan="2" height="5" rowSpan="1"></TD>
					</TR>
					<tr>
						<td align="right"><asp:label id="lblAccessEntry" Runat="server">Mục từ <u>c</u>hứa:</asp:label>&nbsp;</td>
						<td><asp:textbox id="txtAccessEntry" Runat="server"></asp:textbox></td>
					</tr>
					<TR>
						<TD align="right" colSpan="2" height="5"></TD>
					</TR>
					<tr>
						<td align="right"><asp:label id="lblReference" Runat="server">Trong dữ liệ<u>u</u>:</asp:label>&nbsp;</td>
						<td><asp:dropdownlist id="ddlReference" Runat="server">
								<asp:ListItem Value="0">Mọi mục từ</asp:ListItem>
								<asp:ListItem Value="1">T&#234;n ri&#234;ng</asp:ListItem>
								<asp:ListItem Value="2">T&#234;n tập thể</asp:ListItem>
								<asp:ListItem Value="3">T&#234;n hội nghị</asp:ListItem>
								<asp:ListItem Value="4">Nhan đề thống nhất</asp:ListItem>
								<asp:ListItem Value="5">Thuật ngữ chủ điểm</asp:ListItem>
								<asp:ListItem Value="6">Địa danh</asp:ListItem>
								<asp:ListItem Value="7">Thuật ngữ thể loại/h&#236;nh thức</asp:ListItem>
								<asp:ListItem Value="8">Tiểu mục chung</asp:ListItem>
								<asp:ListItem Value="9">Tiểu mục địa l&#253;</asp:ListItem>
								<asp:ListItem Value="10">Tiểu mục ni&#234;n đại</asp:ListItem>
								<asp:ListItem Value="11">Tiểu mục h&#236;nh thức</asp:ListItem>
							</asp:dropdownlist></td>
					</tr>
					<tr>
						<td colspan="2" height="5"></td>
					</tr>
					<tr>
						<td></td>
						<td><asp:button id="btnSearch" Runat="server" Text="Thuật ngữ chủ điểm(t)"></asp:button></td>
					</tr>
					<TR>
						<TD colSpan="2" height="5" rowSpan="1"></TD>
					</TR>
					<tr>
						<td colSpan="2" align="center">
							<asp:label id="lblCapResult" runat="server" Visible="False">Tìm thấy:</asp:label>
							<asp:label id="lblResult" runat="server" Visible="False" ForeColor="Maroon" Font-Bold="True"></asp:label>
							<asp:label id="lblCap" runat="server" Visible="False">bản ghi biên mục</asp:label></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2" height="5"></TD>
					</TR>
					<tr>
						<td colSpan="2"><asp:datagrid id="dgrResult" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<Columns>
									<asp:TemplateColumn HeaderText="Thuật ngữ chủ điểm">
										<ItemTemplate>
											<asp:HyperLink ID="lnkContent" Runat="server">
												<%# DataBinder.Eval(Container.dataItem,"DisplayEntry")%>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Position="TopAndBottom" CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<tr>
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Không tìm thấy bản ghi nào có mã số biểu ghi như trên!</asp:ListItem>
							<asp:ListItem Value="1">Bạn phải nhập vào mã số biểu ghi trước khi sửa!</asp:ListItem>
							<asp:ListItem Value="2">Không tìm thấy bản ghi nào thoả mãn điều kiện tìm kiếm!</asp:ListItem>
							<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="5">----- Chọn dữ liệu -----</asp:ListItem>
						</asp:DropDownList>
					</tr>
				</TBODY>
			</table>
		</form>
		</TD></TR></TBODY></TABLE></FORM>
		<script language = javascript>
			document.forms[0].txtAuthorityID.focus();
		</script>
	</body>
</HTML>
