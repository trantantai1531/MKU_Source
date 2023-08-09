<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRDetail" CodeFile="WIRDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Nội dung chi tiết yêu cầu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD class="lbPageTitle" width="50%"><asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Nội dung chi tiết yêu cầu</asp:label></TD>
					<TD class="lbPageTitle" align="right"><asp:button id="btnMoveFirst" runat="server" Text="|<"></asp:button><asp:button id="btnMovePrev" runat="server" Text=" <"></asp:button><asp:textbox id="txtCurrentRec" runat="server" Width="32px">0</asp:textbox><asp:textbox id="txtTotalRec" runat="server" Width="32px">0</asp:textbox><asp:button id="btnMoveNext" runat="server" Text="> "></asp:button><asp:button id="btnMoveLast" runat="server" Text=">|"></asp:button></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top"><asp:table id="tblInfor1" runat="server" Width="100%"></asp:table></TD>
					<TD vAlign="top"><asp:table id="tblInfor2" runat="server" Width="100%"></asp:table></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel1" Width="0" Runat="server">
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
			</asp:dropdownlist><asp:dropdownlist id="ddlLabel2" Width="0" Runat="server">
				<asp:ListItem Value="0">Thông tin xử lý</asp:ListItem>
				<asp:ListItem Value="1">Ngày trả lời</asp:ListItem>
				<asp:ListItem Value="2">Ngày ghi mượn</asp:ListItem>
				<asp:ListItem Value="3">Ngày gửi đi</asp:ListItem>
				<asp:ListItem Value="4">Ngày đối tác nhận được</asp:ListItem>
				<asp:ListItem Value="5">Ngày đối tác gửi trả</asp:ListItem>
				<asp:ListItem Value="6">Ngày nhận lại</asp:ListItem>
				<asp:ListItem Value="7">Ngày hủy bỏ</asp:ListItem>
				<asp:ListItem Value="8">Ngày hết hạn mượn</asp:ListItem>
				<asp:ListItem Value="9">Số lượt gia hạn</asp:ListItem>
				<asp:ListItem Value="10">Kiểu cho mượn</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlLabel3" Width="0" Runat="server">
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
				<asp:ListItem Value="22">Trạng thái bạn đọc</asp:ListItem>
				<asp:ListItem Value="23">ĐKCB</asp:ListItem>
				<asp:ListItem Value="24">Thẻ bạn đọc</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlLabel4" Width="0" Runat="server">
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
			</asp:dropdownlist><asp:dropdownlist id="ddlLabel5" Width="0" Runat="server">
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
				<asp:ListItem Value="14">Số tham chiếu nội bộ</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="ddlLabel6" Width="0" Runat="server">
				<asp:ListItem Value="0">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
			</asp:dropdownlist><input id="hidRequestID" type="hidden" name="hidRequestID" runat="server">
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Định vị ấn phẩm</asp:ListItem>
				<asp:ListItem Value="3">In nhãn đóng gói</asp:ListItem>
				<asp:ListItem Value="4">Đặt điều kiện cho mượn</asp:ListItem>
				<asp:ListItem Value="5">Không cung cấp (đề nghị gửi lại)</asp:ListItem>
				<asp:ListItem Value="6">Không cung cấp</asp:ListItem>
				<asp:ListItem Value="7">Sẽ cung cấp</asp:ListItem>
				<asp:ListItem Value="8">Tính chi phí mượn</asp:ListItem>
				<asp:ListItem Value="9">Giao hàng</asp:ListItem>
				<asp:ListItem Value="10">Hủy bỏ yêu cầu</asp:ListItem>
				<asp:ListItem Value="11">Gia hạn</asp:ListItem>
				<asp:ListItem Value="12">Đòi lại ấn phẩm</asp:ListItem>
				<asp:ListItem Value="13">Thông báo quá hạn</asp:ListItem>
				<asp:ListItem Value="14">Ghi nhận hoàn trả</asp:ListItem>
				<asp:ListItem Value="15">Sửa chữa</asp:ListItem>
				<asp:ListItem Value="16">Lịch sử yêu cầu</asp:ListItem>
				<asp:ListItem Value="17">Đổi trạng thái</asp:ListItem>
				<asp:ListItem Value="18">Báo mất</asp:ListItem>
				<asp:ListItem Value="19">Gửi thông điệp</asp:ListItem>
				<asp:ListItem Value="20">Hỏi trạng thái</asp:ListItem>
				<asp:ListItem Value="21">Xóa</asp:ListItem>
				<asp:ListItem Value="22">Chuyển sang thư mục thích hợp</asp:ListItem>
			</asp:dropdownlist>
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
