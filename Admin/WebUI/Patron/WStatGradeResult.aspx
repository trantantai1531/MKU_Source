<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatGradeResult" CodeFile="WStatGradeResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatGradeResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
      
	</HEAD>
	<body bgColor="#ffffff" onload="GenURL(7)" topmargin="0" leftmargin="0"
		bottommargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0"
				bgcolor="#ffffff">
				<tr>
					<td width="100%"><asp:Label ID="lbNotFound" Runat="server" Visible="False" CssClass="lbPageTitle" Width="100%">Không tìm thấy dữ liệu</asp:Label></td>
				</tr>
				<TR>
					<TD align="center">&nbsp;<img src="" border="0" name="anh1" id="anh1" runat="server">
						<img src="" border="0" name="anh2" id="anh2" runat="server">
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lổi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Số lượng sinh viên</asp:ListItem>
				<asp:ListItem Value="4">Khoá học</asp:ListItem>
				<asp:ListItem Value="5">Tỉ lệ % sinh viên theo khoá học</asp:ListItem>
				<asp:ListItem Value="6">Không rõ</asp:ListItem>
				<asp:ListItem Value="7">Thống kê theo khoá học</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
