<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPatronDetail" CodeFile="WPatronDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thông tin bạn đọc</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><asp:label id="Label1" runat="server" CssClass="main-group-form" Width="100%">Thông tin chi tiết của bạn đọc</asp:label></TD>
				</TR>
				<TR>
					<TD width="70%"><asp:table id="tblMainInfor" runat="server" Width="100%"></asp:table></TD>
				</TR>
			</TABLE>
			<asp:label id="lbl1" CssClass="lbLabel" Visible="False" Runat="server">Họ tên: </asp:label>
			<asp:label id="lbl2" CssClass="lbLabel" Visible="False" Runat="server">Dân tộc: </asp:label>
			<asp:label id="lbl3" CssClass="lbLabel" Visible="False" Runat="server">Ngày sinh: </asp:label>
			<asp:label id="lbl4" CssClass="lbLabel" Visible="False" Runat="server">Giới tính: </asp:label>
			<asp:label id="lbl5" CssClass="lbLabel" Visible="False" Runat="server">Trình độ văn hoá: </asp:label>
			<asp:label id="lbl6" CssClass="lbLabel" Visible="False" Runat="server">Số thẻ: </asp:label>
			<asp:label id="lbl7" CssClass="lbLabel" Visible="False" Runat="server">Ngày cấp thẻ: </asp:label>
			<asp:label id="lbl8" CssClass="lbLabel" Visible="False" Runat="server">Ngày hết hạn thẻ: </asp:label>
			<asp:label id="lbl9" CssClass="lbLabel" Visible="False" Runat="server">Nhóm bạn đọc: </asp:label>
			<asp:label id="lbl10" CssClass="lbLabel" Visible="False" Runat="server">Khoá học: </asp:label>
			<asp:label id="lbl11" CssClass="lbLabel" Visible="False" Runat="server">Khoa: </asp:label>
			<asp:label id="lbl12" CssClass="lbLabel" Visible="False" Runat="server">Lớp: </asp:label>
			<asp:label id="lbl13" CssClass="lbLabel" Visible="False" Runat="server">Nhóm nghề nghiệp: </asp:label>
			<asp:label id="lbl14" CssClass="lbLabel" Visible="False" Runat="server">Nghề nghiệp: </asp:label>
			<asp:label id="lbl15" CssClass="lbLabel" Visible="False" Runat="server">Trường: </asp:label>
			<asp:label id="lbl16" CssClass="lbLabel" Visible="False" Runat="server">Địa chỉ nơi làm việc: </asp:label>
			<asp:label id="lbl17" CssClass="lbLabel" Visible="False" Runat="server">Địa chỉ: </asp:label>
			<asp:label id="lbl18" CssClass="lbLabel" Visible="False" Runat="server">Số điện thoại cố định: </asp:label>
			<asp:label id="lbl19" CssClass="lbLabel" Visible="False" Runat="server">Số điện thoại di động: </asp:label>
			<asp:label id="lbl20" CssClass="lbLabel" Visible="False" Runat="server">Email: </asp:label>
			<asp:label id="Label2" runat="server" CssClass="lbGroupTitle" Visible="False">Thông tin hồ sơ</asp:label>
			<asp:label id="Label3" runat="server" CssClass="lbGroupTitle" Visible="False">Thông tin trực thuộc</asp:label>
			<asp:label id="Label4" runat="server" CssClass="lbGroupTitle" Visible="False">Thông tin liên lạc</asp:label>
			<asp:label id="Label5" runat="server" CssClass="lbGroupTitle" Visible="False">Nam</asp:label>
			<asp:label id="Label6" runat="server" CssClass="lbGroupTitle" Visible="False">Nữ</asp:label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
			<asp:Label id="lblJSAction" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 112px"
				runat="server" Visible="True"></asp:Label>
		</form>
	</body>
</HTML>
