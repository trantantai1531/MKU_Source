<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WSendNoticeEmail" CodeFile="WSendNoticeEmail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gửi thư thông báo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD align="center">
						<asp:label id="lblPageTitle" CssClass="lbPageTitle" Width="100%" runat="server">Danh sách bạn đọc đặt mượn tài liệu</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="dtgResult" runat="server" Width="100%" AutoGenerateColumns="False" AlternatingItemStyle-CssClass="lbGridAlterCell"
							ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" HeaderStyle-HorizontalAlign="Center">
							<Columns>
								<asp:BoundColumn DataField="ID" HeaderText="STT" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="PatronCode" HeaderText="Số thẻ" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="FullName" HeaderText="Họ tên" ItemStyle-Width="15%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Title" HeaderText="Nhan đề đặt chỗ"></asp:BoundColumn>
								<asp:BoundColumn DataField="CreatedDate" HeaderText="Ngày đặt" ItemStyle-HorizontalAlign="Center"
									ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="TimeOutDate" HeaderText="Ngày hết hạn" ItemStyle-HorizontalAlign="Center"
									ItemStyle-Width="5%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Note" HeaderText="Ghi chú" ItemStyle-Width="7%"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Thư thông báo</asp:ListItem>
				<asp:ListItem Value="3">Kính gửi:&nbsp;</asp:ListItem>
				<asp:ListItem Value="4">Yêu cầu đặt chỗ của ông/bà cho ấn phẩm:&nbsp;</asp:ListItem>
				<asp:ListItem Value="5">thực hiện vào ngày:&nbsp;</asp:ListItem>
				<asp:ListItem Value="6">đã đến lượt.</asp:ListItem>
				<asp:ListItem Value="7">Thời gian bảo lưu lượt mượn kéo dài tới ngày:&nbsp;</asp:ListItem>
				<asp:ListItem Value="8">Xin cảm ơn.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
