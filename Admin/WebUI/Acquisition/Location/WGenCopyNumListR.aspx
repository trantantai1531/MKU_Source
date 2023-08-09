<%@ Page Language="vb" AutoEventWireup="false" EnableViewStateMAC="False" EnableViewState="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WGenCopyNumListR" CodeFile="WGenCopyNumListR.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Danh sách đăng ký cá biệt</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
            <div style="text-align:right;padding-right:20px">
               <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file excel"></asp:Button>
            </div>
			<table cellpadding="2" cellspacing="2" border="0" width="100%">
				<tr>
					<td align="center">
						<asp:label id="lblTitle" runat="server" Font-Size="Large" Font-Bold="True">Danh sách đăng ký cá biệt</asp:label>
					</td>
				</tr>
				<tr>
					<td>
						<table cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td width="20%">
									<asp:Label ID="lblLocation" Runat="server">Kho:</asp:Label>
								</td>
								<td width="25%">
									<asp:Label ID="lblDateInventory" Runat="server">Ngày kiểm kê:</asp:Label>
								</td>
								<td>
									<asp:Label ID="lblInventor" Runat="server">Người kiểm kê:.................................................</asp:Label>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:DataGrid id="dtgResult" runat="server" Width="100%" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center"
							AllowPaging="True" PagerStyle-Visible="False">
							<Columns>
								<asp:BoundColumn DataField="OrderNum" HeaderText="STT" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Content" HeaderText="Nhan đề"></asp:BoundColumn>
								<asp:BoundColumn DataField="Shelf" HeaderText="Giá sách" ItemStyle-Width="8%"></asp:BoundColumn>
								<asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh" ItemStyle-Width="12%"></asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Có" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
									<ItemTemplate>
										<asp:Image Runat="server" ImageUrl="../Images/box.gif" BorderWidth="0"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:Label ID="lblNumPage" Runat="server">-1-</asp:Label>
					</td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabel" runat="server" Visible="False" Width="0px">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Không có ấn phẩm nào thỏa mãn điều kiện.</asp:ListItem>
			</asp:dropdownlist>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
		        <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                <asp:ListItem Value="2">Giá sách</asp:ListItem>
                <asp:ListItem Value="3">Số định danh</asp:ListItem>
                <asp:ListItem Value="4">ĐKCB</asp:ListItem>
                <asp:ListItem Value="5">Có</asp:ListItem>
		    </asp:DropDownList>
			<SCRIPT LANGUAGE="JavaScript">
			<!--
				self.focus();
				setTimeout('self.print()',1);
			//-->
			</SCRIPT>
		</form>
	</body>
</HTML>
