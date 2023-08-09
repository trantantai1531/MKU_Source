<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORHisRequest" CodeFile="WORHisRequest.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Lịch sử yêu cầu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle"><asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Lịch sử yêu cầu</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD ROWSPAN="2">
									&nbsp;&nbsp;&nbsp;
								</TD>
								<TD>
									<asp:label id="lblContent" runat="server"></asp:label>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:button id="btnClose" runat="server" Text="Đóng (c)"></asp:button>
					<asp:dropdownlist id="ddlLabel" Runat="server" width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
							<asp:ListItem Value="1">Nơi yêu cầu</asp:ListItem>
							<asp:ListItem Value="2">Thời điểm tạo</asp:ListItem>
							<asp:ListItem Value="3">Thời điểm hết hạn</asp:ListItem>
							<asp:ListItem Value="4">Kiểu dịch vụ</asp:ListItem>
							<asp:ListItem Value="5">Ngày giao hàng</asp:ListItem>
							<asp:ListItem Value="6">Kiểu dịch vụ giao</asp:ListItem>
							<asp:ListItem Value="7">Hạn trả</asp:ListItem>
							<asp:ListItem Value="8">Có thể gia hạn</asp:ListItem>
							<asp:ListItem Value="9">Kiểu giao dịch</asp:ListItem>
							<asp:ListItem Value="10">Cung cấp có điều kiện</asp:ListItem>
							<asp:ListItem Value="11">Đề nghị gửi lại vào lúc khác</asp:ListItem>
							<asp:ListItem Value="12">Không cung cấp</asp:ListItem>
							<asp:ListItem Value="13">Giới thiệu địa chỉ cho mượn</asp:ListItem>
							<asp:ListItem Value="14">Sẽ cung cấp</asp:ListItem>
							<asp:ListItem Value="15">Đặt yêu cầu giữ chỗ</asp:ListItem>
							<asp:ListItem Value="16">Tính chi phí</asp:ListItem>
							<asp:ListItem Value="17">Lý do</asp:ListItem>
							<asp:ListItem Value="18">Ngày tháng kèm theo</asp:ListItem>
							<asp:ListItem Value="19">Ghi chú</asp:ListItem>
							<asp:ListItem Value="20">Có</asp:ListItem>
							<asp:ListItem Value="21">Không</asp:ListItem>
							<asp:ListItem Value="22">Cho phép hủy bỏ</asp:ListItem>
							<asp:ListItem Value="23">Chấp nhận điều kiện</asp:ListItem>
							<asp:ListItem Value="24">Ngày nhận được</asp:ListItem>
							<asp:ListItem Value="25">Ngày hoàn trả</asp:ListItem>
							<asp:ListItem Value="26">Ngày nhận lại</asp:ListItem>
							<asp:ListItem Value="27">Muốn gia hạn tới ngày</asp:ListItem>
							<asp:ListItem Value="28">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="29">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="30">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
							<asp:ListItem Value="31">Ngày quá hạn</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
