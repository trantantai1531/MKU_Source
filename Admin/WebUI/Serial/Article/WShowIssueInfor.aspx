<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WShowIssueInfor" CodeFile="WShowIssueInfor.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<HTML>
	<HEAD>
		<title>Danh mục ấn phẩm định kỳ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMain" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colspan="2">
						<asp:label id="lblTitleForm" Runat="server" cssClass="lbPageTitle" width="100%">Đăng ký mục lục ấn phẩm định kỳ</asp:label></TD>
					</TD></TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:label id="lblTitle" Runat="server" width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:Label ID="lblML" Runat="server">
							<b>&nbsp;&nbsp;&nbsp;Nhập<br>
								mục lục</b></asp:Label>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblYear" Runat="server"><U>N</U>ăm:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlYear" Runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;
						<asp:Label ID="lblMonth" Runat="server"><u>T</u>háng:</asp:Label>&nbsp;
						<asp:DropDownList ID="ddlMonth" Runat="server" AutoPostBack="True">
							<asp:ListItem Value="0">Toàn bộ</asp:ListItem>
							<asp:ListItem Value="1">1</asp:ListItem>
							<asp:ListItem Value="2">2</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="4">4</asp:ListItem>
							<asp:ListItem Value="5">5</asp:ListItem>
							<asp:ListItem Value="6">6</asp:ListItem>
							<asp:ListItem Value="7">7</asp:ListItem>
							<asp:ListItem Value="8">8</asp:ListItem>
							<asp:ListItem Value="9">9</asp:ListItem>
							<asp:ListItem Value="10">10</asp:ListItem>
							<asp:ListItem Value="11">11</asp:ListItem>
							<asp:ListItem Value="12">12</asp:ListItem>
						</asp:DropDownList>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblIssue" Runat="server"><U>S</U>ố:</asp:label>&nbsp;
						<asp:textbox id="txtIssue" Runat="server" Width="80px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:table id="tblResult" runat="server"></asp:table></TD>
				</TR>
				<tr>
					<asp:label id="lblAlert" Runat="server" Visible="False">Hiện tại chưa có yêu cầu bổ sung nào</asp:label>
					<asp:label id="lblUrgency1" Runat="server" Visible="False">Trung bình</asp:label>
					<asp:label id="lblUrgency2" Runat="server" Visible="False">Cao</asp:label>
					<asp:label id="lblUrgency3" Runat="server" Visible="False">Rất cao</asp:label>
					<asp:label id="lblTypeCode" Runat="server" Visible="False">TT</asp:label>
					<asp:label id="lblIssueDate" Runat="server" Visible="False">Ngày phát hành: </asp:label>
					<asp:label id="lblSpecialTitle" Runat="server" Visible="False">Tên số đặc biệt: </asp:label>
					<asp:label id="lblPhysDetail" Runat="server" Visible="False">Đặc trưng số lượng: </asp:label>
					<asp:label id="lblCopyNumberTitle" Runat="server" Visible="False" Font-Underline="True" Font-Italic="True">Xếp giá:</asp:label>
					<asp:label id="lblPage" Runat="server" Visible="False">tr</asp:label>
					<asp:label id="lblCm" Runat="server" Visible="False">cm</asp:label>
					<asp:label id="lblVolumeL" Runat="server" Visible="False">Bản</asp:label>
					<asp:label id="lblIssueTitle" Runat="server" Visible="False">Số:</asp:label>
					<asp:label id="lblVolumeP" Runat="server" Visible="False">Tập:</asp:label>
					<asp:label id="lblSpecialName" Runat="server" Visible="False">Tên đặc biệt:</asp:label>
					<asp:label id="lblSummary" Runat="server" Visible="False">Tóm tắt:</asp:label>
					<asp:label id="lbltt" Runat="server" Visible="False" Font-Underline="True" Font-Italic="True">Tóm tắt:</asp:label>
					<asp:dropdownlist id="ddlLabel" Runat="server" Width="0px" Visible="False">
						<asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
						<asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
						<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
						<asp:ListItem Value="3">Không tồn tại dữ liệu thoả mãn điều kiện tìm kiếm </asp:ListItem>
						<asp:ListItem Value="4">Nhập mục lục</asp:ListItem>
						<asp:ListItem Value="5">Đang lấy dữ liệu, xin vui lòng chờ trong giây lát !</asp:ListItem>
					</asp:dropdownlist></tr>
			</TABLE>
			<input id="hidYears" type="hidden" name="hidYears" value="0" runat="server">
		</form>
	</body>
</HTML>
