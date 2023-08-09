<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORReturn" CodeFile="WORReturn.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Hoàn trả ấn phẩm</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD colspan="3">
						<asp:Label ID="lblTitleFromName" Runat="server" Width="100%" CssClass="lbPageTitle">Hoàn trả ấn phẩm</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right" width="30%">
						<asp:Label ID="lblDateReturn" Runat="server"><u>N</u>gày hoàn trả:</asp:Label>
					</TD>
					<TD colspan="2">
						<asp:TextBox ID="txtDateReturn" Runat="server" Width="150"></asp:TextBox>&nbsp;
						<asp:HyperLink ID="lnkDateReturn" Runat="server">Lịch</asp:HyperLink>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label ID="lblSendFollow" Runat="server"><u>G</u>ửi qua:</asp:Label>
					</TD>
					<TD colspan="2">
						<asp:TextBox ID="txtSendFollow" Runat="server" Width="100%"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label ID="lblInsure" Runat="server"><u>B</u>ảo hiểm:</asp:Label>
					</TD>
					<TD>
						<asp:TextBox ID="txtInsure" Runat="server" Width="150"></asp:TextBox>
					</TD>
					<TD align="right">
						<asp:Label ID="lblCurrency" Runat="server">Đơn <u>v</u>ị tiền tệ:</asp:Label>
						<asp:DropDownList ID="ddlCurrency" Runat="server" Width="120px"></asp:DropDownList>
					</TD>
				</TR>
				<TR>
					<TD align="right" valign="top">
						<asp:Label ID="lblNote" Runat="server"><u>G</u>hi chú:</asp:Label>
					</TD>
					<TD colspan="2">
						<asp:TextBox ID="txtNote" Runat="server" Width="100%" TextMode="MultiLine" Rows="3"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD align="center" colspan="3">
						<asp:Button ID="btnSend" Runat="server" Text="Gửi(g)"></asp:Button>&nbsp;&nbsp;
						<asp:Button ID="btnNoSend" Runat="server" Text="Không gửi(k)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
				<asp:ListItem Value="3">Thông điệp đã được gửi đi thành công.</asp:ListItem>
				<asp:ListItem Value="4">Ở trạng thái hiện thời của yêu cầu, không thể thực hiện thao tác này.</asp:ListItem>
				<asp:ListItem Value="5">Ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="6">Lỗi ! Thông điệp không gửi đi được.</asp:ListItem>
				<asp:ListItem Value="7">Đóng</asp:ListItem>
				<asp:ListItem Value="8">Ở trạng thái hiện thời, yêu cầu không thể thực hiện thao tác này.</asp:ListItem>
				<asp:ListItem Value="9">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
				<asp:ListItem Value="10">Kiểu dữ liệu không hợp lệ.</asp:ListItem>
			</asp:DropDownList>
			<input id="hdnILLID" type="hidden" name="ILLID" runat="server"> <input id="hdnResponderID" type="hidden" name="ResponderID" runat="server">
			<input id="func" type="hidden" name="func" runat="server" value="action">
		</form>
	</body>
</HTML>
