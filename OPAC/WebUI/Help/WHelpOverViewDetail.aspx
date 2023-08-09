<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibOPAC.WebUI.OPAC.WHelpOverViewDetail" Codebehind="WHelpOverViewDetail.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WHelpOverViewDetail</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table style="HEIGHT: 100%" width="100%" border="0">
				<tr>
					<td><input type="button" value="<<" name="bttHidden" onclick="Hideleft();" class="lbButton"></td>
				</tr>
				<tr>				
					<td>
						<asp:Label CssClass="lbPageTitle" Height="100%" Width="100%" Runat="server" ID="lblTitle"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label Runat="server" ID="lblContent" Height="100%" Width="100%"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label CssClass="lbPageTitle" Height="100%" Width="100%" Runat="server" ID="lblTitleItemLink">Các ch?c nang liên quan</asp:Label>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:DataGrid Width="75%" ID="dtgItemLink" Runat="server" ShowHeader="False" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink ID=lnkDetail runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HelpTitle") %>' NavigateUrl="">
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
				<tr>
					<td height="100%"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
