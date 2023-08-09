<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WLoanDetail" CodeFile="WLoanDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Danh sách ấn phẩm đang mượn</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="4" width="100%" border="0">
				<TR>
					<TD>
						<asp:label id="lblPageTitle" runat="server" CssClass="main-group-form" width="100%">Ấn phẩm đang mượn</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dtgResult" runat="server" Width="100%" AllowCustomPaging="False" HeaderStyle-HorizontalAlign="Center"
							AutoGenerateColumns="False" ItemStyle-VerticalAlign="Top">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="STT" HeaderText="STT" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB" ItemStyle-Width="12%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Title" HeaderText="Nhan đề"></asp:BoundColumn>
								<asp:BoundColumn DataField="CHECKOUTDATE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="14%"
									HeaderText="Ngày mượn"></asp:BoundColumn>
								<asp:BoundColumn DataField="DUEDATE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" HeaderText="Ngày trả"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" Width="64px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">về nhà</asp:ListItem>
				<asp:ListItem Value="3">tại chỗ</asp:ListItem>
				<asp:ListItem Value="4">ngoài hạn ngạch</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
