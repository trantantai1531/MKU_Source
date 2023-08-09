<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WFindFieldByName" CodeFile="WFindFieldByName.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Tìm theo tên trường</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </HEAD>
	<body topmargin="0" leftmargin="0" onkeypress="if (window.event.keyCode == 13) {document.forms[0].btnFind.click(); return false;}"
		onload="document.forms[0].txtPattern.focus();">
		<form id="frm" method="post" runat="server">
			<TABLE id="tbl" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colspan="2" align="center" class="lbPageTitle">
						<asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle main-group-form">Tìm thông tin theo tên trường</asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblFind" runat="server"><U>T</U>ên trường cần tìm:</asp:label>&nbsp;</TD>
					<TD align="left">
						<asp:textbox id="txtPattern" runat="server" Width="200px"></asp:textbox>
						<asp:button id="btnFind" runat="server" Text="Tìm(s)" Width="60px"></asp:button>
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="72px"></asp:Button></TD>
				</TR>
				<TR>
					<TD colSpan="2">
					    <div class="table-form">
					        <asp:datagrid id="dgr" runat="server" AutoGenerateColumns="False" Width="100%" PageSize="50" AllowPaging="True"
							HeaderStyle-HorizontalAlign="center">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Nh&#227;n trường">
									<ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink Id="lnkLink" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"FieldCode") %>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="M&#244; tả">
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VietFieldName") %>'>
										</asp:Label>
									</ItemTemplate>									
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chọn">
									<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton ID="lnkChoose" Runat="server" text="Chọn"></asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					    </div>
						
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập tên trường cần tìm</asp:ListItem>
				<asp:ListItem Value="3">Không có trường thông tin thoả mãn điều kiện!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
