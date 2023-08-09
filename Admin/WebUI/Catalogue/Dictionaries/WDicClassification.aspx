<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WDicClassification" CodeFile="WDicClassification.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WDicClassification</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr class="lbGroupTitle">
					<td><asp:label id="lblTitleLetf" runat="server" CssClass="lbGroupTitle">Từ điển phân loại</asp:label></td>
				</tr>
				<tr>
					<td valign="top" align="center">
						<asp:datagrid id="DtgDictionary" runat="server" AllowPaging="True" AutoGenerateColumns="False"
							Width="100%" PageSize="12">
							<Columns>
								<asp:BoundColumn DataField="Name" HeaderText="T&#234;n từ điển"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="&lt;img src=&quot;../images/update.gif&quot; border=&quot;0&quot;&gt;" DataNavigateUrlField="ShowClass"
									HeaderText="Duyệt xem">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:HyperLinkColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</td>
				</tr>
			</table>
			<asp:Label ID="lblLabel0" Runat="server" Visible="False">Bạn không được cấp quyền sử dụng chức năng này</asp:Label>
			<asp:Label ID="lblLabel1" Runat="server" Visible="False">Tạo mới</asp:Label>
			<asp:Label ID="lblLabel2" Runat="server" Visible="False">Mã lỗi</asp:Label>
			<asp:Label ID="lblLabel3" Runat="server" Visible="False">Chi tiết lỗi</asp:Label>
			<asp:Label ID="lblLabel4" Runat="server" Visible="False">Mẫu danh mục : </asp:Label>
			<asp:DropDownList ID="ddlAboutAction" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
				<asp:ListItem Value="1">Mẫu danh mục mới chưa được ghi nhận</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật mẫu danh mục thành công</asp:ListItem>
				<asp:ListItem Value="3">Đã ghi nhận mẫu mẫu danh mục mới</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa nhập tên mẫu danh mục</asp:ListItem>
				<asp:ListItem Value="5">Mẫu danh mục mới đã được ghi nhận</asp:ListItem>
				<asp:ListItem Value="6">"Insert: "</asp:ListItem>
				<asp:ListItem Value="7">"Update: "</asp:ListItem>
				<asp:ListItem Value="8">"Delete: "</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
