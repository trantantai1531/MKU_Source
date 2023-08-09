<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WClassDetail" CodeFile="WClassDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WClassDetail</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link id="Link1" runat="server" href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link id="Link2" runat="server" href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link id="Link3" runat="server" href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="lbPageTitle" align="center">
						<asp:Label Runat="server" ID="lblTitle" CssClass="main-group-form" Width="100%">Danh sách các bạn đọc tìm thấy trong lớp</asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:DataGrid id="dgrPatron" runat="server" Width="100%" Height="40px" AutoGenerateColumns="False"
							Visible="False">
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="0%"></HeaderStyle>
									<ItemTemplate>
										<asp:textbox id="txtCode" text='<%# DataBinder.Eval(Container.dataItem,"Code") %>' Runat="server" Width="0px">
										</asp:textbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkSelectedCode" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Code" HeaderText="Số thẻ">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FullName" HeaderText="Họ tên">
									<HeaderStyle Width="50%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOB" HeaderText="Ngày sinh">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
				<tr>
					<td><asp:hyperlink id="lnkCheckAll" runat="server" NavigateUrl=" " Visible="False">Chọn tất</asp:hyperlink></td>
				</tr>
				<tr>
					<td>
						<asp:Button id="btnSelect" runat="server" Text="Chọn(n)" Visible="False"></asp:Button>&nbsp;
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(g)"></asp:Button>
						<asp:TextBox id="txtHidden" runat="server" Width="0px">1</asp:TextBox>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
