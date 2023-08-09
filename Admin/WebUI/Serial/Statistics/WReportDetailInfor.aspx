<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WReportDetailInfor" CodeFile="WReportDetailInfor.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thông tin thư mục chi tiết của ấn phẩm</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD><asp:label id="lblMainTitle" Runat="server" cssclass="lbPageTitle">Thông tin thư mục của ấn phẩm</asp:label>
					</TD>
				</TR>
				<TR>
					<TD><asp:table id="tblMainInfor" runat="server"></asp:table></TD>
				</TR>
				<TR>
					<td align="center">
						<asp:Button Runat="server" ID="btnClose" Text="Đóng (c)"></asp:Button>
					</td>
				</TR>
				<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
					<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
					<asp:ListItem Value="2">ISSN:</asp:ListItem>
					<asp:ListItem Value="3">Tác giả:</asp:ListItem>
					<asp:ListItem Value="4">Tác giả tập thể:</asp:ListItem>
					<asp:ListItem Value="5">Tên hội nghị:</asp:ListItem>
					<asp:ListItem Value="6">Nhan đề:</asp:ListItem>
					<asp:ListItem Value="7">Xuất bản:</asp:ListItem>
					<asp:ListItem Value="8">Đặc điểm vật lý:</asp:ListItem>
				</asp:DropDownList>
			</TABLE>
		</form>
	</body>
</HTML>
