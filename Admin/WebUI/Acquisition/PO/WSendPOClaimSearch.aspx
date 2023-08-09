<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOClaimSearch" CodeFile="WSendPOClaimSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSendPOClaimSearch</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="5" leftmargin="5" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="50%">
						<asp:Label ID="lblTemplate" Runat="server"><U>C</U>họn mẫu: </asp:Label>&nbsp;
						<asp:DropDownList ID="ddlTemplate" Runat="server"></asp:DropDownList>&nbsp;
						<asp:Label ID="lblUbound" Runat="server"><U>G</U>iới hạn: </asp:Label>&nbsp;
						<asp:DropDownList ID="ddlUbound" Runat="server">
							<asp:ListItem Value="1">1</asp:ListItem>
							<asp:ListItem Value="10" Selected="True">10</asp:ListItem>
							<asp:ListItem Value="100">100</asp:ListItem>
							<asp:ListItem Value="1000">1000</asp:ListItem>
							<asp:ListItem Value="-1">tất cả</asp:ListItem>
						</asp:DropDownList></td>
					<td align="right">
						<asp:Button ID="btnPreview" Runat="server" Text="Xem trước(e)" Width="98px"></asp:Button>
						<asp:Button ID="btnPrint" Runat="server" Text="In(i)" Width="48px"></asp:Button>
						<asp:Button ID="btnEmail" Runat="server" Text="Gửi thư(t)" Width="75px"></asp:Button>
						<asp:Button ID="btnSaveToFile" Runat="server" Text="Ghi file(f)" Width="83px"></asp:Button>
					</td>
				</tr>
			</table>
		    <input type="hidden" id="hidContractID" runat="server" value="0" name="hidContractID"/>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">---------- Chọn ----------</asp:ListItem>
				<asp:ListItem Value="3">Chưa chọn mẫu đơn khiếu nại</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
