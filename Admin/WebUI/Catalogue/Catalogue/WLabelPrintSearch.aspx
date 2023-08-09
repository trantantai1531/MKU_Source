<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WLabelPrintSearch" CodeFile="WLabelPrintSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>In nhãn gáy</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body bgColor="#f0f3f4" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="PrintLabel" width="100%" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td colspan="4" width="100%">
						<asp:Label cssclass="main-group-form" ID="lblMain" Runat="server" Width="100%">In nhãn cho tài liệu</asp:Label></td>
				</tr>
				<tr>
					<td align="right"><asp:Label id="lblLibrary" Runat="server">Thư <u>v</u>iện: </asp:Label></td>
					<td colspan="3"><asp:DropDownList ID="ddlLibrary" Runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblStore" Runat="server">Kh<u>o</u>: </asp:Label></td>
					<td colspan="3">
						<asp:DropDownList ID="ddlStore" Runat="server"></asp:DropDownList>
						<input type="hidden" id="txtStore" runat="server" NAME="txtStore" value="0"></td>
				</tr>
				<tr class="lbGroupTitle">
					<td colspan="2"><asp:RadioButton CssClass="lbSubTitle" ID="optCodeItem" Runat="server" GroupName="PrintWhat" Text="In cho từng tên <u>s</u>ách"></asp:RadioButton></td>
					<td colspan="2"><asp:RadioButton CssClass="lbSubTitle" ID="optCopyNumber" Runat="server" GroupName="PrintWhat" Text="In cho từng đăng ký <u>c</u>á biệt"
							Checked="True"></asp:RadioButton></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblFromCodeItem" Runat="server">Từ mã tà<u>i</u> liệu: </asp:Label></td>
					<td colspan="1"><asp:TextBox ID="txtFromCodeItem" Runat="server"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfFromCodeItem" Runat="server">Tìm</asp:HyperLink></td>
					<td align="right"><asp:Label ID="lblFromCopyNumber" Runat="server">Từ đăng <u>k</u>ý cá biệt: </asp:Label></td>
					<td colspan="1"><asp:TextBox ID="txtFromCopyNumber" Runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblToCodeItem" Runat="server">Tới mã tài <u>l</u>iệu: </asp:Label></td>
					<td width="20%"><asp:TextBox ID="txtToCodeItem" Runat="server"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfToCodeItem" Runat="server">Tìm</asp:HyperLink></td>
					<td align="right"><asp:Label ID="lblToCopyNumber" Runat="server">Tới đă<u>n</u>g ký cá biệt: </asp:Label></td>
					<td colspan="1"><asp:TextBox ID="txtToCopyNumber" Runat="server"></asp:TextBox></td>
				</tr>
				<tr class="lbGroupTitle">
					<td colspan="4"><asp:RadioButton CssClass="lbSubTitle" ID="optElse" Runat="server" GroupName="PrintWhat" Text="Hoặc in các giá trị sau"></asp:RadioButton></td>
				</tr>
				<tr>
					<td align="right" valign="top"><asp:Label ID="lblElse" Runat="server">Các <u>g</u>iá trị cần in: </asp:Label></td>
					<td colspan="2"><asp:TextBox ID="txtElse" Runat="server" Width="100%" TextMode="MultiLine" Wrap="False" Height="90px"></asp:TextBox></td>
					<td colspan="1"></td>
				</tr>
				<tr>
					<td align="right" colspan="1"><asp:Label ID="lblItemType" Runat="server"><u>D</u>ạng tài liệu: </asp:Label></td>
					<td colspan="3"><asp:DropDownList ID="ddlItemType" Runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblFormal" Runat="server">Mẫu <u>n</u>hãn: </asp:Label></td>
					<td colspan="3"><asp:DropDownList ID="ddlFormal" Runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblColPage" Runat="server">Số cột/t<u>r</u>ang: </asp:Label></td>
					<td colspan="3"><asp:TextBox ID="txtColPage" Runat="server" Width="60">5</asp:TextBox></td>
				</tr>
				<tr>
					<td align="right"><asp:Label ID="lblHagPage" Runat="server"><u>S</u>ố hàng/trang: </asp:Label></td>
					<td colspan="3"><asp:TextBox ID="txtHagPage" Runat="server" Width="60">4</asp:TextBox></td>
				</tr>
				<tr class="lbControlBar">
					<td align="right"></td>
					<td colspan="3">
						<asp:Button ID="btnPrint" Runat="server" Text="In nhãn(p)" Width="90px"></asp:Button>
						<asp:Button ID="btnReset" Runat="server" Text="Đặt lại(r)" Width="90px"></asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Khuôn dạng dữ liệu không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="4">Không tìm thấy dữ liệu!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
