<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractBrowse" CodeFile="WContractBrowse.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WContractBrowse</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tbl1" width="100%">
				<tr>
					<td>
						<asp:Label ID="lblPageTitle" Runat="server" CssClass="main-head-form" Width="100%">Duyệt xem danh sách hợp đồng đã thực hiện</asp:Label></td>
				</tr>
				<tr>
					<td align="center">
						<asp:Label ID="lblParameter1" Runat="server"></asp:Label>
						<asp:DropDownList ID="ddlParameter1" Runat="server" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;
						<asp:Label ID="lblParameter2" Runat="server"></asp:Label>
						<asp:DropDownList ID="ddlParameter2" Runat="server" AutoPostBack="True"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
					    <div class="table-form">
						<asp:DataGrid ID="dtgResult" Runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="ID" Visible="False"></asp:BoundColumn>
								<asp:HyperLinkColumn DataTextField="ReceiptNo" HeaderText="Mã số">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="POName" HeaderText="Tên đơn đặt"></asp:BoundColumn>
								<asp:BoundColumn DataField="VALIDDATE" HeaderText="Ngày lập">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalAmount" HeaderText="Tổng tiền">
									<HeaderStyle HorizontalAlign="Center" Width="16%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
                        </div>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dung tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="4">Ngoài phạm vi kiểm tra</asp:ListItem>
				<asp:ListItem Value="5">Sai kiểu dữ liệu (số)</asp:ListItem>
				<asp:ListItem Value="6">Duyệt đơn theo ngày lập đơn</asp:ListItem>
				<asp:ListItem Value="7">Năm:</asp:ListItem>
				<asp:ListItem Value="8">Tháng:</asp:ListItem>
				<asp:ListItem Value="9">Duyệt đơn theo nhà cung cấp</asp:ListItem>
				<asp:ListItem Value="10">Tên nhà cung cấp:</asp:ListItem>
				<asp:ListItem Value="11">Duyệt đơn theo quỹ chi trả</asp:ListItem>
				<asp:ListItem Value="12">Tên quỹ:</asp:ListItem>
				<asp:ListItem Value="13">Duyệt đơn theo trạng thái</asp:ListItem>
				<asp:ListItem Value="14">Tên trạng thái:</asp:ListItem>
			</asp:DropDownList>
			<input id="hidOption" runat="server" type="hidden" name="hidOption">
		</form>
	</body>
</HTML>
