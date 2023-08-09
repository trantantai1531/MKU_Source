<%@ Page Language="vb" AutoEventWireup="false" EnableViewStateMAC="False" EnableViewState="false" Codebehind="WSavedList.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.WSavedList"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSavedList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body onload="ChangeFontType();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="2" cellPadding="2" width="100%">
				<tr class="lbPageTitle">
					<td><asp:label id="lbHeader" cssclass="lbPageTitle" Runat="server">Danh sách các tài liệu đã lựa chọn</asp:label></td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr>
								<td align="left" width="50%"><asp:hyperlink id="lnkRoot1" Runat="server" NavigateUrl="../WShowresult.aspx">Trang tìm kiếm</asp:hyperlink></td>
								<td align="right"><asp:button id="btnComBack" Runat="server" Text="Chọn tiếp(c)"></asp:button>&nbsp;<asp:button id="btnDelete" Runat="server" Text="Xoá(x)"></asp:button>&nbsp;<asp:button id="btnDownload" Runat="server" Text="Tải về(t)"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><asp:datagrid id="dtgSavedList" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:BoundColumn DataField="Content" HeaderText="Danh s&#225;ch">
									<HeaderStyle HorizontalAlign="Left" Width="90%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Checked" HeaderText="&lt;input type='checkbox' name='CheckAll' value='ON' onClick='javascript:SetCheckAll();'&gt;">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="false" Height="0">
				<asp:ListItem Value="0">Bạn cần chọn tài liệu để tải về !</asp:ListItem>
				<asp:ListItem Value="1">Chưa có tài liệu nào được chọn để xóa !</asp:ListItem>
				<asp:ListItem Value="2">Không có bản ghi, nhấn nút chọn tiếp để thêm bản ghi mới!</asp:ListItem>
				<asp:ListItem Value="3">Không có bản ghi nào cả!</asp:ListItem>
			</asp:dropdownlist><input id="arrlistsaved" type="hidden" size="2" name="arrlistsaved" runat="server">
		</form>
	</body>
</HTML>
