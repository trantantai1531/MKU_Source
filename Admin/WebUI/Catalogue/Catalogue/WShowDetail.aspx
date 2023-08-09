<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WShowDetail" CodeFile="WShowDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWEData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WShowDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResetValue();">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr class="lbPageTitle">
					<td>
						<asp:label id="lblFreePageTitle" CssClass="lbPageTitle" Visible="False" Runat="server">Chọn tệp gắn kèm dữ liệu điện tử truy cập tự do</asp:label>
						<asp:label id="lblNotFreePageTitle" CssClass="lbPageTitle" Visible="False" Runat="server">Chọn tệp gắn kèm dữ liệu điện tử có thu phí</asp:label>
					</td>
				</tr>
			</table>
			<asp:table id="tblNavigator" runat="server" BorderWidth="0" CellSpacing="0" CellPadding="4"></asp:table>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="left"><asp:table id="tblHeader" runat="server" BorderWidth="0"></asp:table></td>
					<td vAlign="top" align="right"><asp:label id="lblView" Runat="server"><u>C</u>hế độ hiển thị: </asp:label><asp:dropdownlist id="ddlView" Runat="server" AutoPostBack="True">
							<asp:ListItem Value="0" Selected="True">Danh sách</asp:ListItem>
							<asp:ListItem Value="1">Chi tiết</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD align="left" colSpan="2"><asp:table id="tblPaging" runat="server"></asp:table></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2"><asp:table id="tblResult" runat="server"></asp:table></TD>
				</TR>
			</table>
			<asp:dropdownlist id="ddlLabel" Runat="server" Visible="False" Height="0px" Width="0px">
				<asp:ListItem Value="0">Tên tệp</asp:ListItem>
				<asp:ListItem Value="1">Kiểu tệp</asp:ListItem>
				<asp:ListItem Value="2">Kích thước</asp:ListItem>
				<asp:ListItem Value="3">Ngày nhập</asp:ListItem>
				<asp:ListItem Value="4">Ngày sửa cuối</asp:ListItem>
				<asp:ListItem Value="5">Không tìm thấy tệp nào trong dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="6">Định dạng</asp:ListItem>
				<asp:ListItem Value="7">Trạng thái</asp:ListItem>
				<asp:ListItem Value="8">Mức độ mật</asp:ListItem>
				<asp:ListItem Value="9">Số lần tải về</asp:ListItem>
				<asp:ListItem Value="10">Biểu ghi thư mục liên kết</asp:ListItem>
				<asp:ListItem Value="11">Dữ liệu metadata</asp:ListItem>
				<asp:ListItem Value="12">Thuộc tính</asp:ListItem>
				<asp:ListItem Value="13">Được khai thác</asp:ListItem>
				<asp:ListItem Value="14">Đang xử lý</asp:ListItem>
				<asp:ListItem Value="15">Chờ duyệt</asp:ListItem>
				<asp:ListItem Value="16">Ngừng khai thác</asp:ListItem>
				<asp:ListItem Value="17">Tải về</asp:ListItem>
				<asp:ListItem Value="18">Tải về máy trạm và soạn thảo</asp:ListItem>
				<asp:ListItem Value="19">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="20">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="21">Trang</asp:ListItem>
				<asp:ListItem Value="22">Kiểu tệp ảnh</asp:ListItem>
				<asp:ListItem Value="23">Hệ màu</asp:ListItem>
				<asp:ListItem Value="24">Khuôn hình</asp:ListItem>
				<asp:ListItem Value="25">Độ phân giải</asp:ListItem>
				<asp:ListItem Value="26">Số màu</asp:ListItem>
				<asp:ListItem Value="27">Trường độ</asp:ListItem>
				<asp:ListItem Value="28">Album</asp:ListItem>
				<asp:ListItem Value="29">Nghệ sĩ</asp:ListItem>
				<asp:ListItem Value="30">BitRate</asp:ListItem>
				<asp:ListItem Value="31">Thể loại</asp:ListItem>
				<asp:ListItem Value="32">Số trang</asp:ListItem>
				<asp:ListItem Value="33">Người nhập</asp:ListItem>
				<asp:ListItem Value="34">Trong</asp:ListItem>
				<asp:ListItem Value="35">Tổng số file trong CSDL</asp:ListItem>
				<asp:ListItem Value="36">Tổng số file vật lý</asp:ListItem>
				<asp:ListItem Value="37">Chế độ hiển thị</asp:ListItem>
				<asp:ListItem Value="38">Bạn có chắc chắn muốn chọn tệp này. Bấm OK để khẳng định, bấm Cancel để huỷ thao tác</asp:ListItem>
				<asp:ListItem Value="39">Biểu ghi biên mục liên kết</asp:ListItem>
				<asp:ListItem Value="40">Chế độ khai thác</asp:ListItem>
				<asp:ListItem Value="41">Ấn phẩm điện tử truy cập tự do</asp:ListItem>
				<asp:ListItem Value="42">Chọn tệp cần đính kèm</asp:ListItem>
				<asp:ListItem Value="43">Thu mục bạn lựa chọn không nằm trong các phạm vi thiết đặt cho cơ sở dữ liệu số.</asp:ListItem>
				<asp:ListItem Value="44">Xem chi tiết biểu ghi biên mục</asp:ListItem>
			</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="hidFunc" type="hidden" runat="server" NAME="hidFunc">
			<input id="hidLoc" type="hidden" runat="server" NAME="hidLoc">
		</form>
	</body>
</HTML>
