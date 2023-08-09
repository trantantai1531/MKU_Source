<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WShowRoute" EnableViewStateMAC="False" CodeFile="WShowRoute.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Phân kho tạp chí</title>
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
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<asp:label id="lblPageTitle" runat="server" Width="100%" CssClass="main-group-form">Phân kho ấn phẩm định kỳ</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblTitle" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblContractCodelb" runat="server">Mã đơn đặt:&nbsp;</asp:label><asp:label id="lblContractCode" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dtgResult" runat="server" Width="100%"
							AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Location" ReadOnly="True" HeaderText="Kho"></asp:BoundColumn>
								<asp:BoundColumn DataField="Copies" HeaderText="Số lượng">
									<ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AppliedDate" HeaderText="Áp dụng từ ngày">
									<ItemStyle HorizontalAlign="Center" Width="26%"></ItemStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;"
									HeaderText="Sửa" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
									EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
									<ItemStyle HorizontalAlign="Center" Width="8%" CssClass="lbLinkFunction"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Text="&lt;img src=&quot;../../images/Delete.gif&quot; border=&quot;0&quot;&gt;"
									HeaderText="Xoá" CommandName="Delete">
									<ItemStyle HorizontalAlign="Center" Width="5%" CssClass="lbLinkFunction"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblTotallb" runat="server">Tổng số bản đã phân kho:&nbsp;</asp:label><asp:label id="lblTotal" runat="server"></asp:label></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:Button ID="btnClose" Text="Đóng(o)" Width="70px" Runat="server"></asp:Button></TD>
				</TR>
			</TABLE>
			<input id="hidContractCode" type="hidden" name="hidContractCode" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="3">Phân kho tạp chí</asp:ListItem>
				<asp:ListItem Value="4">Xoá phân kho tạp chí</asp:ListItem>
				<asp:ListItem Value="5">Bạn có muốn xoá phân kho ấn phẩm định kỳ không?</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
