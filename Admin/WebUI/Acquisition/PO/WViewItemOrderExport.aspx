<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WViewItemOrderExport" CodeFile="WViewItemOrderExport.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WViewItemOrderExport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid ID="dgr" Runat="server" Width="100%" AutoGenerateColumns="False">
				<Columns>
					<asp:TemplateColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
						<ItemTemplate>
							<asp:CheckBox ID="optChoice" runat="server" Checked="False"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Duyệt" ItemStyle-Height="5%">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:Label ID="lblAccepted" runat="server" text='<%# DataBinder.Eval(Container.dataItem,"Accepted") %>' Width =20>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="TypeCode" HeaderText="Dạng tài liệu">
						<HeaderStyle Width="8%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Code" HeaderText="Vật mang tin">
						<HeaderStyle Width="8%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="RequestedCopies" HeaderText="Sao bản yêu cầu">
						<HeaderStyle Width="7%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
						<HeaderStyle Width="13%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="MainTitle"></asp:BoundColumn>
					<asp:BoundColumn DataField="TypeCode"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Button ID="btn" Runat="server" Text="afsd"></asp:Button>
		</form>
	</body>
</HTML>
