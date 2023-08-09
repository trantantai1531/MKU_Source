<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORReceipt" CodeFile="WORReceipt.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Nhận được ấn phẩm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="3" topMargin="1">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><asp:label id="lblTitleForm" Runat="server" CssClass="lbPageTitle" Width="100%">Nhận được ấn phẩm</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblDateReceipt" Runat="server"><u>N</u>gày nhận:</asp:label></TD>
					<TD><asp:label id="lblServiceType" Runat="server">Kiểu <u>g</u>iao tài liệu:</asp:label></TD>
					<TD><asp:label id="lblCopyrightCompliance" Runat="server"><u>B</u>ản quyền:</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;
						<asp:textbox id="txtDateReceipt" Width="120px" Runat="server"></asp:textbox>
						<asp:hyperlink id="lnkDateReceipt" Runat="server">Lịch</asp:hyperlink></TD>
					<TD>&nbsp;&nbsp;
						<asp:dropdownlist id="ddlServiceType" Width="100px" Runat="server"></asp:dropdownlist></TD>
					<TD>&nbsp;&nbsp;
						<asp:dropdownlist id="ddlCopyrightCompliance" Width="100px" Runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:label id="lblReceiptPatronDate" Runat="server"><u>H</u>ạn trả với bạn đọc:</asp:label></TD>
					<TD><asp:label id="lblLocalDueDate" Runat="server" Visible="False">Điều kiện mượn:</asp:label>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2" height="5" rowSpan="1"></TD>
					<TD height="5"></TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;&nbsp;
						<asp:textbox id="txtReceiptPatronDate" Width="120px" Runat="server"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkReceiptPatronDate" Runat="server">Lịch</asp:hyperlink></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="5" rowSpan="1"></TD>
					<TD height="5"></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:label id="lblNoteSub" Runat="server"><u>G</u>hi chú:</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<td colSpan="3" vAlign="top" rowSpan="1">&nbsp;&nbsp; &nbsp;<asp:textbox id="txtNote" Runat="server" Width="90%" Rows="7" TextMode="MultiLine"></asp:textbox></td>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3" height="5"></TD>
				</TR>
				<TR>
					<td align="center" colSpan="3"><asp:button id="btnSend" Runat="server" Text="Cập nhật(c)"></asp:button>
						&nbsp;<asp:button id="btnNoSend" Runat="server" Text="Đóng(d)"></asp:button></td>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="3">Lỗi ! Thông điệp không gửi đi được.</asp:ListItem>
				<asp:ListItem Value="4">Đóng</asp:ListItem>
				<asp:ListItem Value="5">Ở trạng thái hiện thời, yêu cầu không thể thực hiện thao tác này.</asp:ListItem>
				<asp:ListItem Value="6">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
				<asp:ListItem Value="7">Thông điệp đã được gửi đi thành công.</asp:ListItem>
				<asp:ListItem Value="8">Ở trạng thái hiện thời của yêu cầu, không thể thực hiện thao tác này.</asp:ListItem>
				<asp:ListItem Value="9">Không tìm thấy thông điệp giao hàng. Tuy vậy bạn vẫn có thể tạo/gửi thông điệp nhận được.</asp:ListItem>
				<asp:ListItem Value="10">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
				<asp:ListItem Value="11">Thông báo nhận được ấn phẩm</asp:ListItem>
			</asp:DropDownList>
			<input id="hdnILLID" type="hidden" name="ILLID" runat="server"> <input id="hdnResponderID" type="hidden" name="ResponderID" runat="server">
		</form>
	</body>
</HTML>
