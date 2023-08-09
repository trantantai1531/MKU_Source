<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQManRef" CodeFile="WACQManRef.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WACQManRef</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="Table2" width="100%" border="0">
				<TR>
					<TD class="lbFunctionTitle"><asp:label id="lblDes" runat="server">Danh sách các chức năng của phân hệ</asp:label></TD>
				</TR>
				<tr>
					<td><asp:datagrid id="dtgResult" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="20">
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Hiển thị">
									<ItemTemplate>
										<asp:CheckBox id="chkID" runat="server" Checked='<%# DataBinder.Eval(Container.dataItem,"IsRef") %>'>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Right" HeaderText="T&#234;n CN"></asp:BoundColumn>
								<asp:BoundColumn DataField="ToolTip" HeaderText="T&#234;n ch&#250; giải CN"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Biểu tượng">
									<ItemTemplate>
										<asp:HyperLink Runat="server" ID="lnkIcon" ImageUrl='<%# DataBinder.Eval(Container.dataItem,"Icon") %>' NavigateUrl='<%#DataBinder.Eval(Container.dataItem,"URL")%>' text='<%#DataBinder.Eval(Container.dataItem,"ToolTip")%>'>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<TR>
					<TD><asp:button id="btnSave" Text="Chọn (c)" Runat="server"></asp:button></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
