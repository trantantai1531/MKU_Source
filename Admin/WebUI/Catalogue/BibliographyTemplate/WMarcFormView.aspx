<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFormView" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WMarcFormView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xem mẫu biên mục</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="LoadForm()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="center" colSpan="2"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Các trường đã chọn</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:datagrid id="dtgMarcFields" runat="server" HeaderStyle-HorizontalAlign="Center" AutoGenerateColumns="False"
							Width="100%">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<Columns>
								<asp:HyperLinkColumn Target="_self" DataNavigateUrlField="FCURL1" DataNavigateUrlFormatString="{0}" DataTextField="FieldCode"
									HeaderText="Nhãn trường"></asp:HyperLinkColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label id="lblFieldCode" text='<%# DataBinder.Eval(Container.dataItem,"FieldCode") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="VietFieldName" HeaderText="Tên trường"></asp:BoundColumn>
								<asp:BoundColumn DataField="FieldName" HeaderText="Tên trường"></asp:BoundColumn>
								<asp:BoundColumn DataField="txtIndicatorValue" HeaderText="Chỉ định dữ liệu"></asp:BoundColumn>
								<asp:BoundColumn DataField="txtFieldDefaultValue" HeaderText="Giá trị ngầm định"></asp:BoundColumn>
								<asp:BoundColumn DataField="chkIsTextBox" HeaderText="TextArea">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="chkMandatoryField" HeaderText="Bắt buộc">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="chkPickedField" HeaderText="Bỏ">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right"><asp:button id="btnUpdate" runat="server" text="Cập nhật(u)"></asp:button>
						<asp:Button id="btnClose" runat="server" text="Đóng(c)"></asp:Button></TD>
				</TR>
			</TABLE>
			<INPUT id="txtPickedFields" type="hidden" value="," name="txtPickedFields" runat="server">
			<INPUT id="txtLoadedFields" type="hidden" value="," name="txtLoadedFields" runat="server">
			<INPUT id="txtMandatoryFields" type="hidden" value="," name="txtMandatoryFields" runat="server">
			<INPUT id="txtFieldDefaultValues" type="hidden" name="txtFieldDefaultValues" runat="server">
			<INPUT id="txtFieldIndicatorValues" type="hidden" name="txtFieldIndicatorValues" runat="server">
			<INPUT id="txtTextBoxFields" type="hidden" name="txtTextBoxFields" runat="server">
			<INPUT id="txtFormID" type="hidden" name="txtFormID" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật thành công!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
