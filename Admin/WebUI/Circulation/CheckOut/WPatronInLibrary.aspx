<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPatronInLibrary" CodeFile="WPatronInLibrary.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Danh sách bạn đọc hiện trong thư viện</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>

	<body leftMargin="0" topMargin="0" oncontextmenu="return false;">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" style=" margin-top: -17px;" width="100%" border="0">
				<TR>
					<TD align="center">
						<asp:label id="lblPageTitle" runat="server" CssClass="main-group-form" Width="100%">Danh sách bạn đọc trong thư viện</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgtResult" runat="server" Width="100%" AutoGenerateColumns="False">
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" CssClass="lbGridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="ID" HeaderText="STT" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
								<asp:BoundColumn DataField="PatronCode" HeaderText="Số thẻ" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
								<asp:BoundColumn DataField="FullName" HeaderText="Họ tên" ItemStyle-Width="30%"></asp:BoundColumn>
								<asp:BoundColumn DataField="NumberItems" HeaderText="Số lượng" ItemStyle-HorizontalAlign="Right"
									ItemStyle-Width="8%"></asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="Mã xếp giá" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="lbPageTitle" align="center">
						<asp:button id="btnClose" Width="64px" Runat="server" Text="Ðóng(o)"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
