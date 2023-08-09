<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcSubFields" CodeFile="WMarcSubFields.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcSubFields</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="1" topMargin="0" onload="LoadCheckedBox();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colspan="2">
						<asp:datagrid id="dtgMarcFields" runat="server" Width="100%" ShowHeader="False" AutoGenerateColumns="False"
							HeaderStyle-HorizontalAlign="Center">
							<Columns>
								<asp:HyperLinkColumn Target="_self" DataNavigateUrlField="FCURL1" DataNavigateUrlFormatString="{0}" DataTextField="FieldCode"
									HeaderText="FieldCode" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="VietFieldName" HeaderText="VietFieldName"></asp:BoundColumn>
								<asp:BoundColumn DataField="FieldName" HeaderText="FieldName"></asp:BoundColumn>
								<asp:BoundColumn DataField="OnClick" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
