<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFields" CodeFile="WMarcFields.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFields</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="1" topMargin="1" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="dtgMarcFields" runat="server" Width="100%" ShowHeader="False" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center">
				<Columns>
					<asp:HyperLinkColumn Text="FieldCode" Target="_self" DataNavigateUrlField="FCURL1" DataNavigateUrlFormatString="{0}"
						DataTextField="FieldCode" HeaderText="FieldCode" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbLinkFunction" ItemStyle-Width="12%"></asp:HyperLinkColumn>
					<asp:BoundColumn DataField="VietFieldName" HeaderText="VietFieldName"></asp:BoundColumn>
					<asp:BoundColumn DataField="FieldName" HeaderText="FieldName"></asp:BoundColumn>
					<asp:HyperLinkColumn Text=">>" Target="MarcSubFields" DataNavigateUrlField="FCURL2" DataNavigateUrlFormatString="{0}"
						HeaderText="Select" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbLinkFunction"></asp:HyperLinkColumn>
				</Columns>
			</asp:datagrid>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
			 	<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
			</form>
	</body>
</HTML>
