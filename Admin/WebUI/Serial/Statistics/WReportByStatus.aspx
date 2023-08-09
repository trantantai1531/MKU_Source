<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WReportByStatus" CodeFile="WReportByStatus.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thông tin chi tiết về ấn phẩm định kỳ</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="2" leftmargin="5">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="3" cellPadding="0" width="100%">
				<tr class="lbPageTitle">
					<td colSpan="6"><asp:label id="lblMainTitle" Runat="server" width="100%" cssclass="lbPageTitle main-head-form">Xem chi tiết thông tin về ấn phẩm định kỳ</asp:label></td>
				</tr>
				<tr>
				</tr>
				<tr>
					<td colSpan="6"><asp:datagrid id="DgrResult" runat="server" Width="100%" AllowPaging="True" PageSize="15" AutoGenerateColumns="False">
							<EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Title" HeaderText="Nhan đề"></asp:BoundColumn>
								<asp:BoundColumn DataField="ISSN" HeaderText="ISSN">
									<HeaderStyle Width="5%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FreqCode" HeaderText="Cấp định kỳ">
									<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="POID" HeaderText="M&#227; đơn đặt">
									<HeaderStyle Width="10%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ValidDate" HeaderText="Ng&#224;y bắt đầu">
									<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FilledDate" HeaderText="Ng&#224;y kết th&#250;c">
									<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Top"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="Top" CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<asp:DropDownList id="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
