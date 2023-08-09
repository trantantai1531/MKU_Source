<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCardPrintCardSuccessful" CodeFile="WCardPrintSuccessful.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ghi nhận in thẻ bạn đọc</title>
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
			<table width="100%" border="0" cellpadding="0" cellspacing="1">
				<tr>
					<td width="100%">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">Ghi nhận việc in thẻ bạn đọc</asp:Label></td>
				</tr>
				<tr>
					<td width="100%">
						<asp:DataGrid id="DgrPrinted" runat="server" Width="100%" BorderStyle="None" BorderWidth="1px"
							CellPadding="3" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
									<HeaderTemplate>
										<input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisible('DgrPrinted', 'chkID', 2, 500);">
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkID" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Code" HeaderText="Số thẻ" ItemStyle-Width="15%"></asp:BoundColumn>
								<asp:BoundColumn DataField="FullName" HeaderText="Họ tên"></asp:BoundColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="300px"></HeaderStyle>
									<ItemTemplate>
										<asp:Label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</td>
				</tr>
				<tr class="lbControlBar">
					<td>&nbsp;
						<asp:Button id="btnSave" runat="server" Text="Ghi nhận(i)" Width="91px"></asp:Button>
						<asp:Button id="btnClose" runat="server" Text="Đóng(g)" Width="70px"></asp:Button>&nbsp;&nbsp;
						<asp:TextBox id="txtHidden" runat="server" Width="0px">1</asp:TextBox>&nbsp;
						<asp:TextBox id="txtTemplateID" runat="server" Width="0px">1</asp:TextBox>&nbsp;
						<asp:TextBox id="txtIssueLibraryID" runat="server" Width="0px">1</asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:TextBox id="txtNewQ" runat="server" Width="0px"></asp:TextBox>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa chọn số thẻ bạn đọc!</asp:ListItem>
			</asp:DropDownList>
			<input type="hidden" runat="server" id="hdIDs">
		</form>
	</body>
</HTML>
