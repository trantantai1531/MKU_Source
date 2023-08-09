<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WGenCopyNumberMenu" CodeFile="WGenCopyNumberMenu.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WGenCopyNumberMenu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="5" topMargin="0">
		<form id="Form1" method="post" target="ContentCopyNumber" runat="server">
			<table cellSpacing="0" cellPadding="3" width="100%">
				<tr>
					<td width="30%" align="left">
						<asp:hyperlink id="lnkGoBack" Runat="server" NavigateUrl="WGenCopyNumListF.aspx" Target="mainacq">Báo cáo khác</asp:hyperlink>
					</td>
					<td align="right" colspan="2">
						<asp:Label ID="lblOrderBy" Runat="server"><U>S</U>ắp xếp :</asp:Label>
						<asp:DropDownList ID="ddlOrderBy" Runat="server">
							<asp:ListItem Value="0" Selected="True">Nhan đề chính</asp:ListItem>
							<asp:ListItem Value="1">Ký hiệu giá sách</asp:ListItem>
							<asp:ListItem Value="2">Số định danh</asp:ListItem>
							<asp:ListItem Value="3">Đăng ký cá biệt</asp:ListItem>
						</asp:DropDownList>
						<asp:CheckBox ID="ckbDesc" Checked="True" Runat="server" Text="Theo thứ tự <U>t</U>ăng dần"></asp:CheckBox>
                        
					</td>
				</tr>
               
				<tr>
					<td colspan="3">
						<hr width="100%" color="#ffffff" width="1">
					</td>
				</tr>
				<tr>
					<td>
						<asp:button id="btnLastPage" Text="Trang trước(p)" Width="98px" Runat="server"></asp:button></td>
					<td align="center">
						<asp:label id="lblIndexPage" Runat="server">Tran<U>g</U> thứ</asp:label>&nbsp;
						<asp:textbox id="txtPageIndex" Runat="server" Width="50px">1</asp:textbox>&nbsp;
						<asp:label id="lblIndexPage1" Runat="server">trong số</asp:label>&nbsp;
						<asp:label id="lblIndexPage2" Runat="server">trang</asp:label></td>
					<td align="right">
						<asp:button id="btnNextPage" Text="Trang tiếp(n)" Width="95px" Runat="server"></asp:button></td>
				</tr>
			</table>
			<input id="ddlLibrary" type="hidden" name="ddlLibrary" runat="server"> <input id="ddlLocation" type="hidden" name="ddlLocation" runat="server">
			<input id="txtShelf" type="hidden" name="txtShelf" runat="server"> <input id="txttoCopyNum" type="hidden" name="txttoCopyNum" runat="server">
			<input id="txtfromCopyNum" type="hidden" runat="server" name="txtfromCopyNum"> <input id="hidNameLocation" type="hidden" runat="server" name="hidNameLocation">
			<input id="txtCopyNum1Page" type="hidden" runat="server" name="txtCopyNum1Page">
			<input id="hidOrderBy" type="hidden" runat="server" name="hidOrderBy" value="0">
			<script language="javascript">
				GotoSubmit();
			</script>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Vượt quá số trang cho phép!</asp:ListItem>
				<asp:ListItem Value="3">Phải là số!</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
			</asp:dropdownlist>
            
		</form>
	</body>
</HTML>
