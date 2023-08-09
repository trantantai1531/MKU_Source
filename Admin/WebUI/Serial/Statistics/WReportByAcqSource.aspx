<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WReportByAcqSource" CodeFile="WReportByAcqSource.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xem chi tiết thông tin ấn phẩm định kỳ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
           <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="3" cellPadding="0" width="100%">
				<tr class="lbPageTitle">
					<td><asp:label id="lblMainTitle" Runat="server" Width="100%" cssclass="main-head-form">Xem chi tiết thông tin về ấn phẩm định kỳ</asp:label></td>
				</tr>
				<tr>
				</tr>
				<tr>
					<td><asp:datagrid id="DtgResult" runat="server" Width="100%" AllowPaging="True" PageSize="15" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="Title" HeaderText="Nhan đề">
									<HeaderStyle Width="23%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ISSN" HeaderText="ISSN">
									<HeaderStyle Width="10%" VerticalAlign="Top" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FreqCode" HeaderText="Cấp định kỳ">
									<HeaderStyle HorizontalAlign="Center" Width="7%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="POID" HeaderText="Mã số đơn đặt">
									<HeaderStyle HorizontalAlign="Center" Width="8%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Ceased" HeaderText="Đình bản">
									<HeaderStyle HorizontalAlign="Center" Width="6%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalIssues" HeaderText="Số kỳ">
									<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalCopies" HeaderText="Số bản">
									<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OnSubscription" HeaderText="Trạng thái đặt">
									<HeaderStyle HorizontalAlign="Center" Width="8%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AcqSourceID" HeaderText="Nguồn bổ sung">
									<HeaderStyle HorizontalAlign="Center" Width="6%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SummaryHolding" HeaderText="Số liệu bổ sung tổng hợp">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<asp:DropDownList id="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Đang đặt</asp:ListItem>
				<asp:ListItem Value="4">Ngừng/Chưa đặt</asp:ListItem>
				<asp:ListItem Value="5">Mua theo hợp đồng</asp:ListItem>
				<asp:ListItem Value="6">Mua lẻ</asp:ListItem>
				<asp:ListItem Value="7">Tặng</asp:ListItem>
				<asp:ListItem Value="8">Trao đổi</asp:ListItem>
				<asp:ListItem Value="9">Lưu chiểu</asp:ListItem>
				<asp:ListItem Value="10">Dạng khác</asp:ListItem>
				<asp:ListItem Value="11">Đóng góp</asp:ListItem>
				<asp:ListItem Value="12">Sưu tầm</asp:ListItem>
			</asp:DropDownList></form>
	</body>
</HTML>
