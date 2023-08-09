<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldSearch" CodeFile="WMarcFieldSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFieldSearch</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" onkeypress="if (window.event.keyCode == 13) {document.forms[0].btnSearch.click(); return false;}" onload="document.forms[0].txtPattern.focus();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="center">
						<asp:Label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tìm theo tên trường</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="lblSearch" runat="server"><U>T</U>ên trường: </asp:Label><asp:TextBox id="txtPattern" runat="server"></asp:TextBox>
						<asp:Button id="btnSearch" runat="server" Text="Tìm(s)"></asp:Button></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblMsg" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dtgMarcFields" runat="server" Width="100%" ShowHeader="False" AutoGenerateColumns="False"
							HeaderStyle-HorizontalAlign="Center">
							<Columns>
								<asp:HyperLinkColumn Target="_self" DataNavigateUrlField="FCURL1" DataNavigateUrlFormatString="{0}" DataTextField="FieldCode" ItemStyle-CssClass="lbLinkFunction"
									HeaderText="FieldCode" ItemStyle-HorizontalAlign="center" ItemStyle-Width="12%"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="VietFieldName" HeaderText="VietFieldName"></asp:BoundColumn>
								<asp:BoundColumn DataField="FieldName" HeaderText="FieldName"></asp:BoundColumn>
								<asp:BoundColumn DataField="OnClick" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Bạn chưa nhập tên trường cần tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="3">Trường biên mục không tồn tại!</asp:ListItem>
			</asp:DropDownList>
		</form>
		</SCRIPT>
	</body>
</HTML>
