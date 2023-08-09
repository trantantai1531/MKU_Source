<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WOrverdueSendMailResult" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WOrverdueSendMailResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WOrverdueSendMailResult</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="PrintLetter" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%">
						<br>
						<br>
						<br>
						<asp:label CssClass="lbLabel" id="lblPrintLetter" Width="100%" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td width="100%"><asp:datagrid id="dgr" Runat="server"></asp:datagrid></td>
				</tr>
			</table>
			<asp:Label ID="lblOverdueMessage" Runat="server" Visible="False">Thông báo về ấn phẩm quá hạn</asp:Label>
			<asp:label id="lblSendMailUnsuccessful" Runat="server" Visible="False">Quá trình gửi thư bị lỗi</asp:label>
			<asp:label id="lblSendMailSuccessful" Runat="server" Visible="False">Gửi thư thành công đến những bạn đọc sau: </asp:label>
			<asp:label id="lblError" Runat="server" Visible="False">Không tìm thấy bạn đọc nào mượn ấn phẩm quá hạn</asp:label>
			<asp:label id="lblSequency" Runat="server" Visible="False">Số thứ tự</asp:label>
			<asp:label id="lblItemCode" Runat="server" Visible="False">Mã tài liệu</asp:label>
			<asp:label id="lblCopyNumber" Runat="server" Visible="False">Mã xếp giá</asp:label>
			<asp:label id="lblItemTitle" Runat="server" Visible="False">Nhan đề</asp:label>
			<asp:label id="lblCheckOutDate" Runat="server" Visible="False">Ngày mượn</asp:label>
			<asp:label id="lblCheckInDate" Runat="server" Visible="False">Ngày trả</asp:label>
			<asp:label id="lblOverDueDate" Runat="server" Visible="False">Số ngày quá hạn</asp:label>
			<asp:label id="lblPenati" Runat="server" Visible="False">Tiền phạt</asp:label>
			<asp:label id="lbLIBRARY" Runat="server" Visible="False">Thư viện</asp:label>
			<asp:label id="lbSTORE" Runat="server" Visible="False">Kho</asp:label>
			<asp:label id="lbNOTE" Runat="server" Visible="False">Ghi chú</asp:label>
			
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Gửi thư thông báo quá hạn</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
