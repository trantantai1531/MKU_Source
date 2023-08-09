<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatalogueDetails" CodeFile="WCatalogueDetails.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CatalogueDetails</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="frm" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD>
						<asp:Label id="lblMainTitleView" runat="server" CssClass="lbPageTitle">Xem bản ghi dữ liệu biên mục</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="grdProperty" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:TemplateColumn HeaderText="Mã trường">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink ID="lnkFieldCode" Runat="server">
											<%#DataBinder.Eval(Container.dataItem,"FieldCode")%>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Ind" HeaderText="Ind">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Content" HeaderText="Nội dung"></asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="lbGridPager"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<tr class="lbPageTitle">
					<td align="center"><asp:Button id="btnClose" runat="server" Text="Đóng (c)"></asp:Button>
						<asp:dropdownlist ID="ddlLabel" Runat="server" Visible="False" Width="0">
							<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
