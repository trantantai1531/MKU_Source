<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WPickedMarcFields" CodeFile="WPickedMarcFields.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPickedMarcFields</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD colspan="2" align="center">
						<asp:Label id="lblMainTitle" runat="server">Picked Marc Fields</asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:datagrid id="dtgMarcFields" runat="server" Width="100%" ShowHeader="False" AutoGenerateColumns="False">
							<Columns>
								<asp:HyperLinkColumn Target="_self" DataNavigateUrlField="URL1" DataNavigateUrlFormatString="{0}" DataTextField="FieldCode"
									HeaderText="FieldCode"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="VietFieldName" HeaderText="VietFieldName"></asp:BoundColumn>
								<asp:BoundColumn DataField="FieldName" HeaderText="FieldName"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="70px"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkPickedField" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label id="lblPickedField" text='<%# DataBinder.Eval(Container.dataItem,"FieldCode") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right">
						<asp:Button id="btnRemove" runat="server" text="Remove"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:Label ID="lblLabel0" Runat="server" Visible="False">Bạn không được cấp quyền sử dụng chức năng này</asp:Label>
			<asp:Label ID="lblLabel1" Runat="server" Visible="False">Tạo mới</asp:Label>
			<asp:Label ID="lblLabel2" Runat="server" Visible="False">Mã lỗi</asp:Label>
			<asp:Label ID="lblLabel3" Runat="server" Visible="False">Chi tiết lỗi</asp:Label>
			<asp:Label ID="lblLabel4" Runat="server" Visible="False">Mẫu phích : </asp:Label>
			<asp:DropDownList ID="ddlAboutAction" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
				<asp:ListItem Value="1">Mẫu phích mới chưa được ghi nhận</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật mẫu phích thành công</asp:ListItem>
				<asp:ListItem Value="3">Đã ghi nhận mẫu phích mới</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa nhập tên phích</asp:ListItem>
				<asp:ListItem Value="5">Mẫu phích mới đã được ghi nhận</asp:ListItem>
				<asp:ListItem Value="6">"Insert: "</asp:ListItem>
				<asp:ListItem Value="7">"Update: "</asp:ListItem>
				<asp:ListItem Value="8">"Delete: "</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
