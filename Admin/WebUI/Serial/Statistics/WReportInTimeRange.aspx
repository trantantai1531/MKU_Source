<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WReportInTimeRange" CodeFile="WReportInTimeRange.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WReportInTimeRange</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="1">
				<tr Class="lbPageTitle">
					<td width="100%" colspan="2"><asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle main-head-form">Báo cáo những tài liệu bổ sung trong một khoảng thời gian</asp:Label>
					</td>
				</tr>
				<tr>
					<td width="40%" align="right">
						<asp:Label ID="lblFromTime" Runat="server"><u>T</u>ừ thời gian: </asp:Label>
					</td>
					<td width="80%"><asp:TextBox ID="txtFromTime" Runat="server" Width="100px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkFromTime" Runat="server">Lịch</asp:HyperLink></td>
				</tr>
				<tr>
					<td width="20%" align="right">
						<asp:Label ID="lblToTime" Runat="server"> Đến thời gia<u>n</u>: </asp:Label>
					</td>
					<td width="80%"><asp:TextBox ID="txtToTime" Runat="server" Width="100px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkToTime" Runat="server">Lịch</asp:HyperLink>
					</td>
				</tr>
				<tr>
					<td width="20%" align="right">
					</td>
					<td width="80%">
						<asp:Button ID="btnReport" Runat="server" Text="Báo cáo(b)" Width="90px"></asp:Button>&nbsp;<asp:Button ID="btnReset" Runat="server" Width="65px" Text="Đặt lại(l)"></asp:Button>
					</td>
				</tr>
			</table>
			<table width="100%" border="0" cellpadding="0" cellspacing="1">
				<tr>
					<td height="8"></td>
				</tr>
				<tr>
					<td width="100%">
						<asp:Label ID="lblDataNotFound" Runat="server" Width="100%" Visible="false" CssClass="lbPageTitle">Không tìm thấy dữ liệu</asp:Label>
						<asp:DataGrid ID="dtgResult" Runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn HeaderText="Nhan đề">
									<HeaderStyle Width="40%"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink CssClass="lbLinkFunction" ID="lnkdtgTitle" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Content")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="summary" HeaderText="Số liệu tổng hợp">
									<HeaderStyle Width="40%"></HeaderStyle>
									<ItemStyle VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LastDateReceived" HeaderText="Ng&#224;y nhận cuối">
									<HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Chọn">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink Runat="server" ID="lnkSelect" CssClass="lbLinkFunction">
											<img src="../../Images/select.jpg" border="0"></asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="Top" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Sai kiểu ngày tháng</asp:ListItem>
				<asp:ListItem Value="4">T</asp:ListItem>
				<asp:ListItem Value="5">>></asp:ListItem>
				<asp:ListItem Value="6">Số có</asp:ListItem>
				<asp:ListItem Value="7">Số thiếu</asp:ListItem>
				<asp:ListItem Value="8">Ấn phẩm được chọn làm ấn phẩm hiện thời!</asp:ListItem>
				<asp:ListItem Value="9">Không tập</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
