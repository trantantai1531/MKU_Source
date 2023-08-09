<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WViewRequestList" CodeFile="WViewRequestList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<HTML>
	<HEAD>
		<title>WViewRequestList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMain" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="70%" class="lbPageTitle">
						<asp:Label ID="lblTitle" CssClass="lbPageTitle" Runat="server">Xem yêu cầu bổ sung ấn phẩm định kỳ</asp:Label></TD>
					<TD class="lbPageTitle" align="right">
						<asp:Hyperlink ID="lnkAcquire" CssClass="lbLinkFunction" Runat="server" Width="100%">Tạo yêu cầu bổ sung</asp:Hyperlink></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:datagrid id="dgrResult" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
							<Columns>
								<asp:BoundColumn DataField="Title" HeaderText="Nhan đề"></asp:BoundColumn>
								<asp:BoundColumn DataField="RequestedCopies" HeaderText="Số lượng">
									<ItemStyle Width="7%" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IssuePrice" HeaderText="Đơn giá">
									<ItemStyle Width="9%" HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Mức độ quan trọng">
									<ItemTemplate>
										<asp:Label ID="lblUrgency" text='<%# DataBinder.Eval(Container.dataItem,"Urgency")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
									<ItemStyle Width="11%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Requester" HeaderText="Người lập yêu cầu">
									<ItemStyle Width="14%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Status" HeaderText="Trạng thái">
									<ItemStyle Width="22%"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblUrgencyTemp" text='<%# DataBinder.Eval(Container.dataItem,"Urgency")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<asp:Label ID="lblAlert" CssClass="lbLabel" Runat="server" Visible="False">Hiện tại chưa có yêu cầu bổ sung nào.</asp:Label>
			<asp:Label ID="lblUrgency1" CssClass="lbLabel" Runat="server" Visible="False">Trung bình</asp:Label>
			<asp:Label ID="lblUrgency2" CssClass="lbLabel" Runat="server" Visible="False">Cao</asp:Label>
			<asp:Label ID="lblUrgency3" CssClass="lbLabel" Runat="server" Visible="False">Rất cao</asp:Label>
			<asp:Label ID="lblTypeCode" CssClass="lbLabel" Runat="server" Visible="False">TT</asp:Label>
			<asp:Label ID="lblError" Visible="False" Runat="server">Bạn không được cấp quyền sử dụng chức năng này.</asp:Label>
		</form>
	</body>
</HTML>
