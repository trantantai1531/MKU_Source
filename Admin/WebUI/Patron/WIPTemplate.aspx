<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WIPTemplate" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WIPTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Khuôn dạng xuất dữ liệu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="1">
				<tr>
					<td width="100%" align="center"><asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="main-group-form">Xem mẫu khuôn dạng nhập dữ liệu</asp:Label></td>
				</tr>
				<tr align="center">
					<td width="100%"><asp:Label ID="lblDisplay" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr>
					<td align="center" class="lbControlBar">
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="68px"></asp:Button></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlInf" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="CODE">1234D</asp:ListItem>
				<asp:ListItem Value="VALIDDATE">10/10/2002</asp:ListItem>
				<asp:ListItem Value="EXPIREDDATE">10/10/2006</asp:ListItem>
				<asp:ListItem Value="LASTISSUEDDATE">10/10/2002</asp:ListItem>
				<asp:ListItem Value="FULLNAME">Phạm thị Hoa</asp:ListItem>
				<asp:ListItem Value="SEX">Nữ</asp:ListItem>
				<asp:ListItem Value="DOB">10/10/1986</asp:ListItem>
				<asp:ListItem Value="ETHNIC">Kinh</asp:ListItem>
				<asp:ListItem Value="TELEPHONE">5711737</asp:ListItem>
				<asp:ListItem Value="MOBILE">0912365478</asp:ListItem>
				<asp:ListItem Value="EMAIL">hoapt@greenhouse.com</asp:ListItem>
				<asp:ListItem Value="PORTRAIT">../Images/Card/163.gif</asp:ListItem>
				<asp:ListItem Value="GRADE">47</asp:ListItem>
				<asp:ListItem Value="COLLEGE">Đại học Văn Hoá</asp:ListItem>
				<asp:ListItem Value="OCCUPATION">Sinh viên</asp:ListItem>
				<asp:ListItem Value="FACULTY">Thư viện</asp:ListItem>
				<asp:ListItem Value="CLASS">TV47A</asp:ListItem>
				<asp:ListItem Value="PROVINCE">Đống Đa</asp:ListItem>
				<asp:ListItem Value="ADDRESS">123 Đê La Thành</asp:ListItem>
				<asp:ListItem Value="CITY">Hà nội- Việt Nam</asp:ListItem>
				<asp:ListItem Value="ZIP">04</asp:ListItem>
				<asp:ListItem Value="ACTIVE">Active</asp:ListItem>
				<asp:ListItem Value="LASTMODIFIEDDATE">11/11/2003</asp:ListItem>
				<asp:ListItem Value="EDUCATIONLEVEL">Đại học</asp:ListItem>
				<asp:ListItem Value="PATRONGROUPNAME">Nhóm bạn đọc</asp:ListItem>
				<asp:ListItem Value="NOTE">Đang trong giai đoạn thử nghiệm thẻ bạn đọc này</asp:ListItem>
				<asp:ListItem Value="FIRSTNAME">Phạm thị</asp:ListItem>
				<asp:ListItem Value="LASTNAME">Hoa</asp:ListItem>
				<asp:ListItem Value="IDCARD">09123212</asp:ListItem>
			</asp:dropdownlist>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
