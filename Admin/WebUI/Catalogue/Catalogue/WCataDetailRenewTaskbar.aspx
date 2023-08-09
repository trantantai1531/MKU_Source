<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataDetailRenewTaskbar" CodeFile="WCataDetailRenewTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCataDetailTaskbar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body class="lbControlBar" topmargin="0" leftmargin="0">
		<form id="frm" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD align="right"><asp:label id="lblForm" runat="server"><u>D</u>ùng mẫu:</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlForm" runat="server"></asp:dropdownlist><asp:button id="btnCatalogue" runat="server" Text="Biên mục (u)"></asp:button>
						<asp:checkbox id="chkUseDefault" runat="server" Text="<u>S</u>ử dụng các giá trị ngầm định" Checked="True"></asp:checkbox></TD>
					<TD align="left">
						<asp:button id="btnRenew" runat="server" Text="Duyệt (r)" CssClass="lbButton"></asp:button>
						&nbsp;&nbsp;
						<asp:button id="btnDelete" runat="server" Text="Xoá (d)" CssClass="lbButton"></asp:button></TD>
				</TR>
			</TABLE>
			<P>
				<INPUT id="hidID" type="hidden" name="hidIDs" runat="server">
				<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
					<asp:ListItem Value="0">Bạn chưa lựa chọn ấn phẩm cần biên mục chi tiết!</asp:ListItem>
					<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
					<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="3">Bạn phải chọn ít nhất một ấn phẩm trước khi xoá!</asp:ListItem>
					<asp:ListItem Value="4">Bạn có muốn xoá (các) ấn phẩm đã chọn không?</asp:ListItem>
					<asp:ListItem Value="5">Bạn có đồng ý duyệt (các) ấn phẩm đã chọn không?</asp:ListItem>
					<asp:ListItem Value="6">Bạn phải chọn ít nhất một ấn phẩm trước khi duyệt!</asp:ListItem>
				</asp:DropDownList></P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
