<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORAcceptCond" CodeFile="WORAcceptCond.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Trả lời thông điệp điều kiện yêu cầu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD colspan="2">
						<asp:Label Runat="server" id="lblPageTitle" CssClass="lbPageTitle">Trả lời thông điệp điều kiện yêu cầu</asp:Label>
					</TD>
				</TR>
				<TR class="lbHighLight">
					<TD colspan="2">
						<asp:Label Runat="server" id="lblTransactionDate"></asp:Label>
					</TD>
				</TR>
				<TR class="lbHighLight">
					<TD colspan="2">
						<asp:Label Runat="server" id="lblResponseDate"></asp:Label>
					</TD>
				</TR>
				<TR class="lbHighLight">
					<TD Width="20%">
						<asp:Label Runat="server" id="lblConditionTemp">Điều kiện:</asp:Label>
					</TD>
					<td>
						<asp:Label Runat="server" id="lblCondition" CssClass="lbAmount"></asp:Label>
					</td>
				</TR>
				<TR>
					<TD colspan="2">
						<hr>
						<asp:Label id="lblAccept" Runat="server">Chấp nhận điều kiện?</asp:Label>&nbsp;&nbsp;&nbsp;
						<asp:RadioButton id="rdoAccept" Runat="server" Checked="True" Text="<u>C</u>ó"></asp:RadioButton>&nbsp;&nbsp;&nbsp;
						<asp:RadioButton id="rdoDeny" Runat="server" Text="<u>K</u>hông"></asp:RadioButton>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:Label id="lblNote" Runat="server"><u>G</u>hi chú:</asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:TextBox id="txtNote" runat="server" TextMode="MultiLine" Columns="55" Rows="5"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:Button id="btnSent" runat="server" Text="Gửi (g)"></asp:Button>&nbsp;
						<asp:Button id="btnClose" runat="server" Text="Đóng (d)"></asp:Button></TD>
				</TR>
				<TR>
					<td colspan="2">
						<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Không tìm thấy thông điệp điều kiện. Tuy vậy bạn vẫn có thể gửi thông điệp chấp nhận điều kiện.</asp:ListItem>
							<asp:ListItem Value="1">Ngày gửi:</asp:ListItem>
							<asp:ListItem Value="2">Hạn trả lời:</asp:ListItem>
							<asp:ListItem Value="3">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="4">Ở trạng thái hiện thời, yêu cầu không thể thực hiện thao tác này.</asp:ListItem>
							<asp:ListItem Value="5">Thông điệp trả lời điều kiện đã được gửi đi thành công.</asp:ListItem>
							<asp:ListItem Value="6">Thông điệp trả lời điều kiện chưa được gửi đi!</asp:ListItem>
							<asp:ListItem Value="7">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="8">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="9">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
							<asp:ListItem Value="10">Chấp nhận điều kiện</asp:ListItem>
							<asp:ListItem Value="11">Không chấp nhận điều kiện</asp:ListItem>
						</asp:DropDownList>
					</td>
				</TR>
			</TABLE>
			<input id="hdnResponderID" type="hidden" runat="server" NAME="hdnResponderID">
		</form>
	</body>
</HTML>
