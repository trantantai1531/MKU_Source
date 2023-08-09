<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIDXSaveForm" CodeFile="WIdxSaveForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIDXViewForm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" id="tblForm">
				<tr class="lbPageTitle">
					<td colspan="2" align="center">
						<asp:Label id="lbHeader" runat="server" CssClass="lbPageTitle">In danh mục ra file</asp:Label>
					</td>
				</tr>
				<tr>
					<td width="40%" align="right">
					</td>
					<td>
					</td>
				</tr>
				<TR>
					<TD align="right" width="40%">
						<asp:Label id="lblTemplate" runat="server"><u>K</u>huôn dạng:</asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlTemplate" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD align="right" width="40%">
						<asp:Label id="lblPageSize" runat="server"><u>S</u>ố mục hiển thị / trang:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPageSize" runat="server" Width="135px" MaxLength="3">20</asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right" width="40%"></TD>
					<TD>
						<asp:Button id="btnSaveToFile" runat="server" Text="Ghi ra file (g) "></asp:Button>&nbsp;
						<asp:Button id="btnReset" runat="server" Text="Làm lại (r) "></asp:Button></TD>
				</TR>
			</table>
			<table width="100%" border="0" id="tblDisplay">
				<TR>
					<TD align="center" width="100%">
						<asp:Label id="lblClick" runat="server" Visible="False">Click</asp:Label>&nbsp;
						<asp:HyperLink id="lnkLink" runat="server" Visible="False">vào đây</asp:HyperLink>&nbsp;
						<asp:Label id="lblLinkTail" runat="server" Visible="False">để lấy file về</asp:Label></TD>
				</TR>
			</table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="3">Có lỗi trong quá trình chuyển sang file Word, bạn chỉ có thể xem file dạng HTML!!! </asp:ListItem>
				<asp:ListItem Value="4"></asp:ListItem>
				<asp:ListItem Value="5"></asp:ListItem>
				<asp:ListItem Value="6">Sai kiểu dữ liệu.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
