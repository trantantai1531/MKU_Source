<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WHelpSearch" CodeFile="WHelpSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWHelpBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WHelpSearch</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td>
						<asp:Label Runat="server" CssClass="lbPageTitle" id="Label3" Width="100%">Nội dung tìm kiếm</asp:Label>
					</td>
				</tr>
				<tr>
					<td><asp:Label Runat="server" id="Label12">Tiêu đề:</asp:Label></td>
				</tr>
				<tr>
					<td>
						&nbsp;<asp:TextBox Runat="server" ID="txtTitle" Width="98%"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td><asp:Label Runat="server" id="Label2">Nội dung:</asp:Label></td>
				</tr>
				<tr>
					<td>
						&nbsp;<asp:TextBox Runat="server" ID="txtContent" Width="98%"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						&nbsp;<br>
						<asp:Button ID="bttSearch" Runat="server" Text="Tìm kiếm"></asp:Button>
						<br>
						&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center" rowspan="2">
						<asp:Label Visible="False" Runat="server" CssClass="lbPageTitle" id="lblResult" Width="100%">Kết quả tìm kiếm</asp:Label><br>
						<asp:Label Visible="False" Runat="server" ID="lblNoResul">Không tìm thấy giá trị nào!</asp:Label>
						<asp:DataGrid Runat="server" ID="dtgSearchResult" Width="100%" AutoGenerateColumns="False" ShowHeader="False">
							<HeaderStyle Wrap="False"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id=lnkDetail runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HelpTitle") %>' NavigateUrl="">
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
