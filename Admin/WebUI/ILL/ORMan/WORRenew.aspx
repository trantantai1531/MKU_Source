<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORRenew" CodeFile="WORRenew.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xin gia hạn ấn phẩm</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colspan="2">
						<asp:Label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Xin gia hạn ấn phẩm</asp:Label></TD>
				</TR>
				<TR class="lbHighLight">
					<TD colSpan="2">
						<asp:Label id="lblContent" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD>
						<asp:Label id="lblRenewDate" runat="server"><u>N</u>gày gia hạn mong muốn:</asp:Label></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD>
						<asp:TextBox id="txtRenewDate" runat="server" Width="112px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lbkCalendar" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD>
						<asp:Label id="lblNote" runat="server"><u>G</u>hi chú:</asp:Label></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD>
						<asp:TextBox id="txtNote" runat="server" TextMode="MultiLine" Rows="5" Columns="45"></asp:TextBox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD colspan="2" align="center">
						<asp:Button id="btnSent" runat="server" Text="Gửi (g)"></asp:Button>&nbsp;
						<asp:Button id="btnCancel" runat="server" Text="Không gửi (k)"></asp:Button>
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Thông điệp xin gia hạn ấn phẩm đã được gửi thành công.</asp:ListItem>
							<asp:ListItem Value="1">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="2">Thông điệp xin gia hạn ấn phẩm chưa được gửi đi!</asp:ListItem>
							<asp:ListItem Value="3">Ở trạng thái hiện thời, yêu cầu không thể thực hiện thao tác này.</asp:ListItem>
							<asp:ListItem Value="4">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="5">Ngày tháng không hợp lệ</asp:ListItem>
							<asp:ListItem Value="6">Ngày gửi:</asp:ListItem>
							<asp:ListItem Value="7">Ngày hết hạn:</asp:ListItem>
							<asp:ListItem Value="8">Ngày hết hạn cục bộ:</asp:ListItem>
							<asp:ListItem Value="9">Đơn vị cho mượn không cho phép gia hạn, tuy nhiên bạn vẫn có thể soạn và gửi thông điệp này nếu cần thiết.</asp:ListItem>
							<asp:ListItem Value="10">Chưa có thông báo quá hạn từ đơn vị cho mượn, tuy nhiên bạn vẫn có thể soạn và gửi thông điệp này nếu cần thiết.</asp:ListItem>
							<asp:ListItem Value="11">Khuôn dạng ngày tháng không hợp lệ.</asp:ListItem>
							<asp:ListItem Value="12">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="13">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="14">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>
			<input id="hdnResponderID" type="hidden" runat="server"> <input id="hidLogID" type="hidden" runat="server">
	</form>
	</body>
</HTML>
