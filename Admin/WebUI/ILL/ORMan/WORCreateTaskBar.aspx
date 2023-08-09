<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORCreateTaskBar" CodeFile="WORCreateTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WORCreateTaskBar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="5" leftmargin="5" class="lbControlBar" onload="parent.document.getElementById('frmSubMain').setAttribute('rows',rows='*,36');">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%" border="0" class="lbControlBar">
				<tr class="lbControlBar">
					<td align="center" width="100%"><asp:button id="btnCreate" Text="Ghi(i)" Runat="server" Width="64px"></asp:button>&nbsp;&nbsp;<asp:button id="btnReset" Text="Làm lại(l)" Runat="server" Width="85px"></asp:button>&nbsp;&nbsp;&nbsp;<asp:checkbox id="ckbReview" Text="Ghi ở trạng thái cần duyệt lại" Runat="server"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnProcess" Text="Trở về xử lý yêu cầu(t)" Runat="server"></asp:button>
					</td>
				</tr>
			</table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Bạn đang thực hiện dở tạo mới yêu cầu, hãy nhấn OK để khẳng định muốn chuyển sang phần xử lý yêu cầu, và những thông tin đang nhập dở sẽ mất hết.</asp:ListItem>
				<asp:ListItem Value="1">Chưa chọn thư viện</asp:ListItem>
				<asp:ListItem Value="2">Địa chỉ Email hoặc IP không rỗng </asp:ListItem>
				<asp:ListItem Value="3">Kiểu chi trả phải là kiểu số</asp:ListItem>
				<asp:ListItem Value="4">Chưa chọn dạng tài liệu</asp:ListItem>
				<asp:ListItem Value="5">Thông tin về nhan đề là bắt buộc</asp:ListItem>
				<asp:ListItem Value="6">Chưa nhập số thẻ của bạn đọc</asp:ListItem>
				<asp:ListItem Value="7">Ngày tháng không đúng định dạng</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
