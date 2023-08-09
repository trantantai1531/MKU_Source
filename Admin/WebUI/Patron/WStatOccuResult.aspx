<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatOccuResult" CodeFile="WStatOccuResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatOccuResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body onload="GenURL(7)" topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
        
			<TABLE width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
				<TR align="center">
					<TD><asp:Label ID="lblNotFound" Runat="server" Width="100%" CssClass="main-group-form" Visible="False">Không tìm thấy dữ liệu</asp:Label>
					</TD>
				</TR>
                <tr>
                    <td>
                           <div class="btn-report-prev">  <a id="hrfRequest" class="lbLinkFunction" href="javascript:window.location.href='WStatOccuForm.aspx';">Chọn lại</a></div>
                    </td>
                </tr>
				<TR align="center">
					<TD><IMG src="" border="0" name="anh1" id="anh1" runat="server">
					</TD>
				</TR>
				<tr>
					<td align="center">
						<IMG src="" border="0" name="anh2" id="anh2" runat="server">
					</td>
				</tr>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lổi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Số lượng bạn đọc</asp:ListItem>
				<asp:ListItem Value="4">Nhóm ngành nghề</asp:ListItem>
				<asp:ListItem Value="5">Tỉ lệ % sinh viên theo nhóm ngành nghề</asp:ListItem>
				<asp:ListItem Value="6">Không rõ</asp:ListItem>
				<asp:ListItem Value="7">Thống kê nhóm ngành nghề</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
