<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckCopyNumber" EnableViewStateMAC="False" CodeFile="WCheckCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckCopyNumber</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<asp:label id="lblPageTitle" runat="server" Width="100%" CssClass="lbPageTitle">Kiểm tra thông tin ấn phẩm</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="lblReason" runat="server">Đang kiểm tra tình trạng ấn phẩm...&nbsp;</asp:label><b><asp:label id="lblReasonInfor" runat="server"></asp:label></b></TD>
				</TR>
				<TR>
					<TD>
						<asp:label Visible="False" id="lblClick1" runat="server">Độc giả đã mượn quá hạn ngạnh, bấm:&nbsp;</asp:label>
						<asp:Button Visible="False" id="btnCheckOut1" runat="server" Text="Ghi mượn" Width="80px"></asp:Button>&nbsp;
						<asp:label Visible="False" id="lblComment1" runat="server">nếu bạn muốn tiếp tục cho mượn.</asp:label>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:label Visible="False" id="lblClick" runat="server">Bấm:&nbsp;</asp:label>
						<asp:Button Visible="False" id="btnCheckOut" runat="server" Text="Ghi mượn" Width="80px"></asp:Button>&nbsp;
						<asp:label Visible="False" id="lblComment" runat="server">nếu bạn muốn bỏ qua thông tin đặt chỗ.</asp:label>
					</TD>
				</TR>
			</TABLE>
			<INPUT type="hidden" id="hidPatronCode" runat="server" NAME="hidPatronCode"> <INPUT type="hidden" id="hidCopyNumber" runat="server">
			<INPUT type="hidden" id="hidExemptQuota" runat="server" value="1" NAME="hidExemptQuota">
			<INPUT type="hidden" id="hidIndefiniteDue" runat="server" value="1"> <INPUT type="hidden" id="hidItemID" runat="server" NAME="hidItemID" value="0">
			<INPUT type="hidden" id="hidLoanMode" runat="server"> <INPUT type="hidden" id="hidLoanTypeID" runat="server" value="0">
			<INPUT type="hidden" id="hidLocationID" runat="server"> <INPUT type="hidden" id="hidCheckOutDate" runat="server">
			<INPUT type="hidden" id="hidDueDate" runat="server"> <INPUT type="hidden" id="hidCheckOutTime" runat="server">
			<INPUT type="hidden" id="hidDueTime" runat="server"> <INPUT type="hidden" id="hidHoldIgnored" runat="server" value="0">
			<INPUT type="hidden" id="hidLibID" runat="server" value="0"> <INPUT type="hidden" id="hidRemain" runat="server">
			<asp:label id="lblMsg1" runat="server" Visible="False">Không tồn tại ĐKCB:&nbsp;</asp:label><asp:label id="lblMsg2" runat="server" Visible="False">Ấn phẩm chưa sẵn sàng phục vụ (bị khoá hoặc chưa đưa ra lưu thông)</asp:label><asp:label id="lblMsg3" runat="server" Visible="False">Ấn phẩm đang được cho mượn</asp:label>
			<asp:Label id="lblMsg4" runat="server" Visible="False">Ấn phẩm đang được bạn đọc khác đặt chỗ</asp:Label>
			<asp:Label id="lblMsg5" runat="server" Visible="False">Ấn phẩm này thuộc kho mà cán bộ thư viện không có quyền quản lý</asp:Label>
			<asp:Label id="lblMsg6" runat="server" Visible="False">Bạn đọc không được mượn ấn phẩm tại những kho mà nhóm mình không được mượn.</asp:Label>			
			<asp:Label id="lblSubmitForm" runat="server"></asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Thẻ bạn đọc đang bị khoá !</asp:ListItem>
				<asp:ListItem Value="3">Hạn trả lớn hơn ngày hết hạn thẻ. Xin vui lòng kiểm tra lại.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
