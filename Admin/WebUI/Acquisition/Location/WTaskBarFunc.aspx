<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WTaskBarFunc" CodeFile="WTaskBarFunc.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WTaskBarFunc</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
     
		<script language="javascript">
			
		</script>
	</HEAD>
	<body topmargin="2" leftmargin="2" rightmargin="2" bottommargin="2">
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%" class="lbPageTitle">
				<tr>
					<td>
						<asp:Label id="lblReason" runat="server" Visible="False"><U>L</U>ý do:</asp:Label>
						<asp:DropDownList id="ddlReasonID" runat="server" Visible="False"></asp:DropDownList>
						<asp:Button id="btnLock" runat="server" Text="Khoá(l)" Width="56px" Visible="False"></asp:Button>
						<asp:Button id="btnUnlock" runat="server" Text="Mở khoá(u)" Width="92px" Visible="False"></asp:Button>
						<asp:Button id="btnRemove" runat="server" Text="Huỷ(r)" Width="52px" Visible="False"></asp:Button>
						<asp:Button id="btnRestoreUnlock" runat="server" Text="Phục hồi(o)" Width="92px" Visible="False"></asp:Button>
						<asp:Button id="btnRestore" runat="server" Text="Phục hồi/Mở khoá(v)" Width="160px" Visible="False"></asp:Button>
						<asp:Button id="btnReceive" runat="server" Text="Kiểm nhận(c)" Width="98px" Visible="False"></asp:Button>
						<asp:Button id="btnReceiveUnlock" runat="server" Text="Kiểm nhận/Mở khoá(d)" Width="160px" Visible="False"></asp:Button>
						<asp:Button id="btnSearch" runat="server" Text="Tìm kiếm(s)" Width="91px"></asp:Button>
						<asp:Button ID="btnDelete" Runat="server" Text="Xóa(x)" Width="52px"></asp:Button>
					</td>
					<td>
						<asp:HyperLink ID="hrfPrevious" Runat="server" NavigateUrl="#"><<</asp:HyperLink>
					</td>
					<td align="center">
						<asp:TextBox ID="txtCurrentPage" Runat="server" Width="40px">0</asp:TextBox><asp:Label ID="lblInPage" Runat="server">/
</asp:Label><asp:Label ID="lblUboundPage" Runat="server"></asp:Label><asp:Label ID="lblTotalPage" Runat="server">trang</asp:Label>
					</td>
					<td align="right">
						<asp:HyperLink ID="hrfNext" Runat="server" NavigateUrl="#">>></asp:HyperLink>
					</td>
				</tr>
			</table>
			<input type="hidden" id="hidTotalCopyIDs" runat="server">
			<asp:Label ID="lblNote" Runat="server" Visible="False">Bạn phải chọn ít nhất một ÐKCB!</asp:Label>
			<asp:Label ID="lblNote1" Runat="server" Visible="False">ÐKCB không được rỗng!!!</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Dữ liệu nhập vào phải là số nguyên dương!!!</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở trang đầu tiên!!!</asp:ListItem>
				<asp:ListItem Value="2">Bạn đang ở trang cuối cùng!!!</asp:ListItem>
				<asp:ListItem Value="3">Vượt quá tổng số trang dang có!!!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
