<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.SubjectAdd" CodeFile="SubjectAdd.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SubjectAdd</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body onload='document.forms[0].txtSubject.focus();'>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colspan="2" align="center">
						<asp:Label id="lblTitle" runat="server" CssClass="lbPageTitle">Thêm chủ đề mới</asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center"><asp:textbox id="txtSubject" runat="server" Width="150px"></asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD></TD>
					<TD>
						<asp:Button id="btnAdd" runat="server" Text="Thêm(a)" Width="70px"></asp:Button>&nbsp;&nbsp;
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" Width="70px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Nước</asp:ListItem>
				<asp:ListItem Value="3">Khoa</asp:ListItem>
				<asp:ListItem Value="4">Thêm mới:</asp:ListItem>
				<asp:ListItem Value="5">Dân tộc</asp:ListItem>
				<asp:ListItem Value="6">Trình độ</asp:ListItem>
				<asp:ListItem Value="7">Nghề nghiệp</asp:ListItem>
				<asp:ListItem Value="8">Tỉnh</asp:ListItem>
				<asp:ListItem Value="9">Bạn chưa nhập đủ thông tin!</asp:ListItem>
				<asp:ListItem Value="10">Mục từ đã tồn tại</asp:ListItem>
				<asp:ListItem Value="11">Cập nhật không thành công</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
