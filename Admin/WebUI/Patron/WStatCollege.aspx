<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatCollege" CodeFile="WStatCollege.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatCollege</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" onload="GenURL(7)" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0"
				bgcolor="#ffffff">
				<tr>
					<TD align="center"><asp:Label ID="lblNotFoundData" Runat="server" Visible="False" Width="100%" CssClass="lbPageTitle">Không tìm thấy dữ liệu</asp:Label>
					</TD>
				</tr>
                  <tr>
                    <td>
                      <div class="btn-report-prev">
                          <a id="hrfRequest" class="lbLinkFunction" href="javascript:window.location.href='WStatColleFaculGraClass.aspx';">Chọn lại</a>
                          </div>
                    </td>
                </tr>
				<tr>
				    <TD align="center"><img src="" border="0" name="anh1" id="anh1" runat="server"/>
					</TD>
				</tr>

				<tr>
					<td align="center">
						<img src="" border="0" name="anh2" id="anh2" runat="server"></td>
				</tr>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lổi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Tên trường</asp:ListItem>
				<asp:ListItem Value="4">Số lượng sinh viên</asp:ListItem>
				<asp:ListItem Value="5">Tỉ lệ % sinh viên theo trường</asp:ListItem>
				<asp:ListItem Value="6">Không rõ</asp:ListItem>
				<asp:ListItem Value="7">Thống kê theo trường</asp:ListItem>
			</asp:DropDownList></form>
	</body>
</HTML>
