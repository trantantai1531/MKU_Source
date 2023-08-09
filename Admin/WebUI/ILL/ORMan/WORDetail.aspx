<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORDetail" CodeFile="WORDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Nội dung chi tiết yêu cầu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR>
					<TD width="50%" Class="lbPageTitle">
						<asp:Label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Nội dung chi tiết yêu cầu</asp:Label></TD>
					<TD align="right" Class="lbPageTitle">
						<asp:Button id="btnMoveFirst" runat="server" Text="|<"></asp:Button>
						<asp:Button id="btnMovePrev" runat="server" Text=" <"></asp:Button>
						<asp:TextBox id="txtCurrentRec" runat="server" Width="32px">0</asp:TextBox>
						<asp:TextBox id="txtTotalRec" runat="server" Width="32px">0</asp:TextBox>
						<asp:Button id="btnMoveNext" runat="server" Text="> "></asp:Button>
						<asp:Button id="btnMoveLast" runat="server" Text=">|"></asp:Button></TD>
				</TR>
				<TR valign="top">
					<TD valign="top">
						<asp:Table id="tblInfor1" runat="server" Width="100%"></asp:Table></TD>
					<TD valign="top">
						<asp:Table id="tblInfor2" runat="server" Width="100%"></asp:Table></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel1" Runat="server" Width="0">
				<asp:ListItem Value="0">Yêu cầu</asp:ListItem>
				<asp:ListItem Value="1">Nơi cung cấp</asp:ListItem>
				<asp:ListItem Value="2">Địa chỉ email hoặc IP</asp:ListItem>
				<asp:ListItem Value="3">Tài khoản</asp:ListItem>
				<asp:ListItem Value="4">Ngày yêu cầu</asp:ListItem>
				<asp:ListItem Value="5">Cần trước ngày</asp:ListItem>
				<asp:ListItem Value="6">Ngày hết hạn</asp:ListItem>
				<asp:ListItem Value="7">Mã số yêu cầu</asp:ListItem>
				<asp:ListItem Value="8">Kiểu dịch vụ</asp:ListItem>
				<asp:ListItem Value="9">Độ ưu tiên</asp:ListItem>
				<asp:ListItem Value="10">Bản quyền</asp:ListItem>
				<asp:ListItem Value="11">Phí tối đa</asp:ListItem>
				<asp:ListItem Value="12">Kiểu chi trả</asp:ListItem>
				<asp:ListItem Value="13">Dạng tài liệu</asp:ListItem>
				<asp:ListItem Value="14">Vật mang tin mong muốn</asp:ListItem>
				<asp:ListItem Value="15">Thỏa thuận giữa hai bên</asp:ListItem>
				<asp:ListItem Value="16">Sẽ trả phí</asp:ListItem>
				<asp:ListItem Value="17">Khoản trả kèm theo</asp:ListItem>
				<asp:ListItem Value="18">Ghi chú</asp:ListItem>
				<asp:ListItem Value="19">Thường</asp:ListItem>
				<asp:ListItem Value="20">Gấp</asp:ListItem>
				<asp:ListItem Value="21">Ấn phẩm đơn bản</asp:ListItem>
				<asp:ListItem Value="22">Ấn phẩm định kỳ</asp:ListItem>
				<asp:ListItem Value="23">Dạng khác</asp:ListItem>
				<asp:ListItem Value="24">Có</asp:ListItem>
				<asp:ListItem Value="25">Không</asp:ListItem>
				<asp:ListItem Value="26">Trạng thái</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLabel2" Runat="server" Width="0">
				<asp:ListItem Value="0">Thông tin xử lý</asp:ListItem>
				<asp:ListItem Value="1">Ngày đối tác trả lời</asp:ListItem>
				<asp:ListItem Value="2">Ngày đối tác gửi đi</asp:ListItem>
				<asp:ListItem Value="3">Ngày nhận được</asp:ListItem>
				<asp:ListItem Value="4">Ngày gửi trả</asp:ListItem>
				<asp:ListItem Value="5">Ngày đối tác nhận lại</asp:ListItem>
				<asp:ListItem Value="6">Ngày hủy bỏ</asp:ListItem>
				<asp:ListItem Value="7">Kiểu cho mượn</asp:ListItem>
				<asp:ListItem Value="8">Ngày hết hạn mượn</asp:ListItem>
				<asp:ListItem Value="9">Ngày hết hạn cục bộ</asp:ListItem>
				<asp:ListItem Value="10">Ngày ghi mượn cục bộ</asp:ListItem>
				<asp:ListItem Value="11">Ngày ghi trả cục bộ</asp:ListItem>
				<asp:ListItem Value="12">Số lượt gia hạn</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLabel3" Runat="server" Width="0">
				<asp:ListItem Value="0">Thông tin ấn phẩm</asp:ListItem>
				<asp:ListItem Value="1">Nhan đề</asp:ListItem>
				<asp:ListItem Value="2">Lần xuất bản</asp:ListItem>
				<asp:ListItem Value="3">Tác giả</asp:ListItem>
				<asp:ListItem Value="4">Cơ quan bảo trợ</asp:ListItem>
				<asp:ListItem Value="5">Nơi xuất bản</asp:ListItem>
				<asp:ListItem Value="6">Nhà xuất bản</asp:ListItem>
				<asp:ListItem Value="7">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="8">Mã tài liệu</asp:ListItem>
				<asp:ListItem Value="9">Nhan đề bài trích</asp:ListItem>
				<asp:ListItem Value="10">Tác giả bài trích</asp:ListItem>
				<asp:ListItem Value="11">Tập - Số</asp:ListItem>
				<asp:ListItem Value="12">Ngày xuất bản số</asp:ListItem>
				<asp:ListItem Value="13">Trang</asp:ListItem>
				<asp:ListItem Value="14">Số định danh</asp:ListItem>
				<asp:ListItem Value="15">ISBN</asp:ListItem>
				<asp:ListItem Value="16">ISSN</asp:ListItem>
				<asp:ListItem Value="17">Tên tùng thư</asp:ListItem>
				<asp:ListItem Value="18">Các mã số khác</asp:ListItem>
				<asp:ListItem Value="19">Nguồn chứng thực</asp:ListItem>
				<asp:ListItem Value="20">Thông tin bạn đọc</asp:ListItem>
				<asp:ListItem Value="21">Tên bạn đọc</asp:ListItem>
				<asp:ListItem Value="22">Thẻ bạn đọc</asp:ListItem>
				<asp:ListItem Value="23">Nhóm bạn đọc</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLabel4" Runat="server" Width="0">
				<asp:ListItem Value="0">Giao nhận</asp:ListItem>
				<asp:ListItem Value="1">Tên cơ quan/phòng</asp:ListItem>
				<asp:ListItem Value="2">Tên tổ chức cấp trên</asp:ListItem>
				<asp:ListItem Value="3">Địa chỉ đường phố</asp:ListItem>
				<asp:ListItem Value="4">P.O. Box</asp:ListItem>
				<asp:ListItem Value="5">Thành phố/Tỉnh</asp:ListItem>
				<asp:ListItem Value="6">Khu vực</asp:ListItem>
				<asp:ListItem Value="7">Quốc gia</asp:ListItem>
				<asp:ListItem Value="8">Mã bưu điện</asp:ListItem>
				<asp:ListItem Value="9">Địa chỉ giao nhận vật lý</asp:ListItem>
				<asp:ListItem Value="10">Địa chỉ giao nhận điện tử</asp:ListItem>
				<asp:ListItem Value="11">Phương thức</asp:ListItem>
				<asp:ListItem Value="12">Địa chỉ</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLabel5" Runat="server" Width="0">
				<asp:ListItem Value="0">Thanh toán</asp:ListItem>
				<asp:ListItem Value="1">Số đơn vị phải trả tiền</asp:ListItem>
				<asp:ListItem Value="2">Cước phí</asp:ListItem>
				<asp:ListItem Value="3">Phí bảo hiểm</asp:ListItem>
				<asp:ListItem Value="4">Phí bảo hiểm phát hoàn</asp:ListItem>
				<asp:ListItem Value="5">Nơi nhận hóa đơn</asp:ListItem>
				<asp:ListItem Value="6">Tên cơ quan/phòng</asp:ListItem>
				<asp:ListItem Value="7">Tên tổ chức cấp trên</asp:ListItem>
				<asp:ListItem Value="8">Địa chỉ đường phố</asp:ListItem>
				<asp:ListItem Value="9">P.O. Box</asp:ListItem>
				<asp:ListItem Value="10">Thành phố/Tỉnh</asp:ListItem>
				<asp:ListItem Value="11">Khu vực</asp:ListItem>
				<asp:ListItem Value="12">Quốc gia</asp:ListItem>
				<asp:ListItem Value="13">Mã bưu điện</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLabel6" Runat="server" Width="0">
				<asp:ListItem Value="0">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
			</asp:DropDownList>
			<input type="hidden" runat="server" id="hidRequestID" NAME="hidRequestID">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Duyệt/Sửa lại</asp:ListItem>
				<asp:ListItem Value="3">Nhân bản</asp:ListItem>
				<asp:ListItem Value="4">Gửi yêu cầu</asp:ListItem>
				<asp:ListItem Value="5">Huỷ bỏ yêu cầu</asp:ListItem>
				<asp:ListItem Value="6">Sửa chữa</asp:ListItem>
				<asp:ListItem Value="7">Lịch sử yêu cầu</asp:ListItem>
				<asp:ListItem Value="8">Từ chối yêu cầu</asp:ListItem>
				<asp:ListItem Value="9">Trả lời thông báo điều kiện</asp:ListItem>
				<asp:ListItem Value="10">Gửi tiếp</asp:ListItem>
				<asp:ListItem Value="11">Nhận được</asp:ListItem>
				<asp:ListItem Value="12">Gia hạn</asp:ListItem>
				<asp:ListItem Value="13">Đổi trạng thái</asp:ListItem>
				<asp:ListItem Value="14">Thông báo cho bạn đọc</asp:ListItem>
				<asp:ListItem Value="15">Hoàn trả</asp:ListItem>
				<asp:ListItem Value="16">Báo mất</asp:ListItem>
				<asp:ListItem Value="17">Gửi thông điệp</asp:ListItem>
				<asp:ListItem Value="18">Hỏi trạng thái</asp:ListItem>
				<asp:ListItem Value="19">Xóa</asp:ListItem>
				<asp:ListItem Value="20">Chuyển sang thư mục thích hợp</asp:ListItem>
				<asp:ListItem Value="21">Định vị ấn phẩm</asp:ListItem>
				<asp:ListItem Value="22">Thông báo quá hạn</asp:ListItem>
				<asp:ListItem Value="23">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlStatusToolTip" Runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Không cung cấp</asp:ListItem>
				<asp:ListItem Value="1">Chờ giải quyết</asp:ListItem>
				<asp:ListItem Value="2">Đang xử lý</asp:ListItem>
				<asp:ListItem Value="3">Chuyển tiếp</asp:ListItem>
				<asp:ListItem Value="4">Có điều kiện</asp:ListItem>
				<asp:ListItem Value="5">Chờ duyệt huỷ bỏ</asp:ListItem>
				<asp:ListItem Value="6">Huỷ bỏ</asp:ListItem>
				<asp:ListItem Value="7">Đã gửi</asp:ListItem>
				<asp:ListItem Value="8">Đã nhận được</asp:ListItem>
				<asp:ListItem Value="9">Chờ duyệt gia hạn</asp:ListItem>
				<asp:ListItem Value="10">Không nhận được thông báo quá hạn</asp:ListItem>
				<asp:ListItem Value="11">Quá hạn gia hạn</asp:ListItem>
				<asp:ListItem Value="12">Quá hạn</asp:ListItem>
				<asp:ListItem Value="13">Đã hoàn trả</asp:ListItem>
				<asp:ListItem Value="14">Đã nhận lại</asp:ListItem>
				<asp:ListItem Value="15">Đòi lại</asp:ListItem>
				<asp:ListItem Value="16">Mất</asp:ListItem>
				<asp:ListItem Value="17">Không rõ</asp:ListItem>
				<asp:ListItem Value="18">Xem xét</asp:ListItem>
				<asp:ListItem Value="19">Bạn đọc khởi tạo</asp:ListItem>
				<asp:ListItem Value="20">Mới</asp:ListItem>
				<asp:ListItem Value="21">Hoàn thành</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
