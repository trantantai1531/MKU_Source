<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WLoanHistory" CodeFile="WLoanHistory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 transitional//EN">
<HTML>
	<HEAD>
		<title>WReportLoanCppy</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD colSpan="7">
						<asp:label id="lblTitleGroup" Runat="server" CssClass="lbPageTitle" Width="100%">Thông chi tiết về bạn đọc</asp:label></TD>
				</tr>
				<tr>
					<TD>
						&nbsp;&nbsp;&nbsp;<asp:label id="lblPatronCode" Runat="server" Font-Bold="True">Số thẻ: </asp:label></TD>
				</tr>
				<tr>
					<TD colSpan="7"><asp:datagrid id="DgdGetPatronInfor" runat="server" Width="100%" PagerStyle-Mode="NumericPages"
							AutoGenerateColumns="False" AllowPaging="True">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Content" HeaderText="Nhan đề"></asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CHECKOUTDATE" HeaderText="Ngày mượn">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CHECKINDATE" HeaderText="Ngày trả">
									<HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OverdueDays" HeaderText="Quá hạn (ngày)">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OverdueFine" HeaderText="Tiền phạt">
									<HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</tr>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2"></asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
