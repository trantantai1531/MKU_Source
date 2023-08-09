<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WAdvanceSearch" CodeFile="WAdvanceSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBarcodes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body bgColor="#f0f3f4" leftMargin="0" topMargin="0" onload="document.forms[0].txtFieldValue1.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="1" width="100%" border="0">
				<tr class="lbPageTitle">
					<td align="center" colSpan="8"><asp:label id="lblSearch" runat="server" width="100%" CssClass="main-head-form">Tìm kiếm nâng cao</asp:label></td>
				</tr>
				<TR>
					<TD>&nbsp;&nbsp;</TD>
					<TD style="WIDTH: 122px"><asp:dropdownlist id="ddlFieldName1" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="1">Số thẻ</asp:ListItem>
							<asp:ListItem Value="2" Selected="True">Họ tên</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 268px" colSpan="6">
						<asp:textbox id="txtFieldValue1" runat="server" Width="330"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:dropdownlist id="ddlOperator1" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="AND" Selected="True">AND</asp:ListItem>
							<asp:ListItem Value="OR">OR</asp:ListItem>
							<asp:ListItem Value="AND NOT">NOT</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 122px"><asp:dropdownlist id="ddlFieldName2" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="1">Số thẻ</asp:ListItem>
							<asp:ListItem Value="2" Selected="True">Họ tên</asp:ListItem>
						
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 268px" colSpan="6"><asp:textbox id="txtFieldValue2" runat="server" Width="331"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:dropdownlist id="ddlOperator2" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="AND" Selected="True">AND</asp:ListItem>
							<asp:ListItem Value="OR">OR</asp:ListItem>
							<asp:ListItem Value="AND NOT">NOT</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 122px"><asp:dropdownlist id="ddlFieldName3" runat="server" Width="109" Height="28px">
						
							<asp:ListItem Value="2" Selected="True">Ngày cấp thẻ</asp:ListItem>
							<asp:ListItem Value="3">Ngày hết hạn thẻ</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 53px"><asp:dropdownlist id="ddlFieldOpeFrom1" runat="server" Width="42" Height="28px">
							<asp:ListItem Value="1" Selected="True">=</asp:ListItem>
							<asp:ListItem Value="2">>=</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 36px"><asp:textbox id="txtFieldValueFrom1" runat="server" Width="83"></asp:textbox></TD>
					<TD style="WIDTH: 56px"><asp:hyperlink id="lnkFromDate1" runat="server">Lịch</asp:hyperlink></TD>
					<TD style="WIDTH: 6px"><asp:label id="lblTo1" runat="server">Đế<u>n</u>: </asp:label></TD>
					<TD colSpan="2"><asp:textbox id="txtFieldValueTo1" runat="server" Width="68"></asp:textbox>&nbsp;<asp:hyperlink id="lnkToDate1" runat="server">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right" style="HEIGHT: 23px"><asp:dropdownlist id="ddlOperator3" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="AND" Selected="True">AND</asp:ListItem>
							<asp:ListItem Value="OR">OR</asp:ListItem>
							<asp:ListItem Value="AND NOT">NOT</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 122px; HEIGHT: 23px"><asp:dropdownlist id="ddlFieldName4" runat="server" Width="109" Height="28px">
						
							<asp:ListItem Value="2" Selected="True">Ngày cấp thẻ</asp:ListItem>
							<asp:ListItem Value="3">Ngày hết hạn thẻ</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 53px; HEIGHT: 23px"><asp:dropdownlist id="ddlFieldOpeFrom2" runat="server" Width="41" Height="28px">
							<asp:ListItem Value="1">=</asp:ListItem>
							<asp:ListItem Value="2">>=</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 36px; HEIGHT: 23px"><asp:textbox id="txtFieldValueFrom2" runat="server" Width="83"></asp:textbox></TD>
					<TD style="WIDTH: 56px; HEIGHT: 23px"><asp:hyperlink id="lnkFromDate2" runat="server">Lịch</asp:hyperlink></TD>
					<TD style="WIDTH: 6px; HEIGHT: 23px"><asp:label id="lblTo2" runat="server">Đ<u>ế</u>n: </asp:label></TD>
					<TD colSpan="2" style="HEIGHT: 23px"><asp:textbox id="txtFieldValueTo2" runat="server" Width="69"></asp:textbox>&nbsp;<asp:hyperlink id="lnkToDate2" runat="server">Lịch</asp:hyperlink></TD>
				</TR>
				<TR style="display: none">
					<TD style="HEIGHT: 17px" align="right">
					    <asp:dropdownlist id="ddlOperator4" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="AND" Selected="True">AND</asp:ListItem>
							<asp:ListItem Value="OR">OR</asp:ListItem>
							<asp:ListItem Value="AND NOT">NOT</asp:ListItem>
						</asp:dropdownlist>
					</TD>
					<TD style="WIDTH: 122px; HEIGHT: 17px"><asp:dropdownlist id="ddlFieldName5" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="1" Selected="True">Khoa</asp:ListItem>
							<asp:ListItem Value="2">Trường</asp:ListItem>
							<asp:ListItem Value="3">Trình độ</asp:ListItem>
							<asp:ListItem Value="4">Dân tộc</asp:ListItem>
							<asp:ListItem Value="5">Nhóm ngành nghề</asp:ListItem>
							<asp:ListItem Value="6">Tỉnh</asp:ListItem>
							<asp:ListItem Value="7">Nhóm bạn đọc</asp:ListItem>
							<asp:ListItem Value="8">Giới tính</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 168px; HEIGHT: 17px" colSpan="6"><asp:dropdownlist id="ddlOptionFieldValue1" runat="server" Width="226" Height="28px"></asp:dropdownlist></TD>
				</TR>
				<TR style="display: none">
					<TD style="HEIGHT: 19px" align="right"><asp:dropdownlist id="ddlOperator5" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="AND" Selected="True">AND</asp:ListItem>
							<asp:ListItem Value="OR">OR</asp:ListItem>
							<asp:ListItem Value="AND NOT">NOT</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 122px; HEIGHT: 19px"><asp:dropdownlist id="ddlFieldName6" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="1" Selected="True">Khoa</asp:ListItem>
							<asp:ListItem Value="2">Trường</asp:ListItem>
							<asp:ListItem Value="3">Trình độ</asp:ListItem>
							<asp:ListItem Value="4">Dân tộc</asp:ListItem>
							<asp:ListItem Value="5">Nhóm ngành nghề</asp:ListItem>
							<asp:ListItem Value="6">Tỉnh</asp:ListItem>
							<asp:ListItem Value="7">Nhóm bạn đọc</asp:ListItem>
							<asp:ListItem Value="8">Giới tính</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="WIDTH: 168px; HEIGHT: 19px" colSpan="6"><asp:dropdownlist id="ddlOptionFieldValue2" runat="server" Width="226" Height="28px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" align="right"><asp:label id="lblDisplayMode" runat="server" Height="21px">Kiểu hiển th<u>ị</u>: </asp:label></TD>
					<TD colSpan="7"><asp:dropdownlist id="ddlDisplayMode" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="0" Selected="True">Hồ sơ</asp:ListItem>
							<asp:ListItem Value="1">Bảng</asp:ListItem>
						</asp:dropdownlist><input id="txtFieldShow" type="hidden" value="0,1,2,17" name="txtFieldShow" runat="server">&nbsp;
						<input id="txtPageSize" type="hidden" value="20" name="txtPageSize" runat="server">&nbsp;
						<ASP:BUTTON id="btnSetFieldShow" runat="server" text="Đặt tham số(s)" width="110px"></ASP:BUTTON></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px" align="right"><asp:label id="lblOrderBy" runat="server" Height="19px">Sắp <u>x</u>ếp theo: </asp:label></TD>
					<TD style="WIDTH: 122px; HEIGHT: 3px"><asp:dropdownlist id="ddlOrderBy" runat="server" Width="109" Height="28px">
							<asp:ListItem Value="1" Selected="True">Ngày cấp</asp:ListItem>
							<asp:ListItem Value="2">Ngày hết hạn</asp:ListItem>
							<asp:ListItem Value="3">Ngày sinh</asp:ListItem>
							<asp:ListItem Value="4">Số thẻ</asp:ListItem>
							<asp:ListItem Value="5">Họ</asp:ListItem>
							<asp:ListItem Value="6">Tên</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD colSpan="6"><asp:label id="lblMaxRecord" runat="server" Height="20px">Giới <u>h</u>ạn: </asp:label>&nbsp;
						<asp:dropdownlist id="ddlMaxRecord" runat="server" Width="108" Height="28px">
							<asp:ListItem Value="1000" Selected="True">Toàn bộ</asp:ListItem>
							<asp:ListItem Value="50">50</asp:ListItem>
							<asp:ListItem Value="100">100</asp:ListItem>
							<asp:ListItem Value="200">200</asp:ListItem>
							<asp:ListItem Value="300">300</asp:ListItem>
						</asp:dropdownlist><INPUT id="txtHidden1" type="hidden" size="12" name="txtPageSize" runat="server"><INPUT id="txtHidden2" type="hidden" size="9" name="txtPageSize" runat="server"></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><asp:button id="btnSearch" runat="server" Width="98px" Text="Tìm kiếm(k)"></asp:button></TD>
					<TD colSpan="6"><asp:button id="btnReset" runat="server" Width="78px" Text="Đặt lại(l)"></asp:button>&nbsp;<asp:button id="btnSearchSimp" runat="server" Width="118px" Text="Tìm đơn giản(g)"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Nữ,Nam,Toàn bộ</asp:ListItem>
				<asp:ListItem Value="4">-----Chọn------</asp:ListItem>
				<asp:ListItem Value="5">Tra cứu bạn đọc nâng cao</asp:ListItem>
				<asp:ListItem Value="6">Ngày tháng sai định dạng</asp:ListItem>
				<asp:ListItem Value="7">Chỉ đặt tham số khi kết quả hiển thị là bảng</asp:ListItem>
				<asp:ListItem Value="8">Không có hồ sơ bạn đọc thoả mãn điều kiện tìm kiếm!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
