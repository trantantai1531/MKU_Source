<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WCheckTitle" CodeFile="WCheckTitle.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckExistItem</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMain" style="WIDTH: 746px; HEIGHT: 88px" cellSpacing="1" cellPadding="3"
				width="746" border="0">
				<TR>
					<TD align="center" width="100%" height="100%"><A name="avail"></A><asp:hyperlink id="lnkAvailable1" runat="server">Đang có</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgrResult" runat="server" Width="100%" AutoGenerateColumns="False">
							<EditItemStyle CssClass="lbGridCell"></EditItemStyle>
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="ArrField1" HeaderText="Số thứ tự" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="ArrField2" HeaderText="Nhan đề ch&#237;nh"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink ID="lnkReuse" CssClass="lbLinkFunction" text="Dùng lại" Runat="server"></asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle CssClass="lbGridPager"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD width="100%" height="100%"></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" height="100%"><A name="ordered"></A><asp:hyperlink id="lbkOrdered2" runat="server" CssClass="lbLinkFunction">Đang đặt</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD width="100%" height="100%"><asp:datagrid id="dgrResult1" runat="server" Width="100%" AutoGenerateColumns="False">
							<EditItemStyle CssClass="lbGridCell"></EditItemStyle>
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="TextField" HeaderText="Số thứ tự">
									<ItemStyle Width="10%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ValueField" HeaderText="Nhan đề ch&#237;nh"></asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="lbGridPager"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" height="100%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
			</TABLE>
			<asp:Label ID="lblAlert" CssClass="lbLabel" Runat="server" Visible="False">Hiện tại chưa có yêu cầu bổ xung nào.</asp:Label>
			<asp:Label ID="lblTypeCode" CssClass="lbLabel" Runat="server" Visible="False">TT</asp:Label>
			&nbsp;</form>
	</body>
</HTML>
