<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField008ID26" CodeFile="WField008ID26.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cấu thành dữ liệu có độ dài cố định</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(26);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top">
					<TD class="lbpageTitle" vAlign="top" colSpan="2"><asp:label id="lblLabel1" runat="server" CssClass="lbpageTitle">008 -- Sách</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%"><asp:label id="lblLabel2" runat="server" CssClass="lbLabel" Width="240px">00-05 - Ngày nhập và<u>o</u> cơ sở dữ liệu</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField1" runat="server" CssClass="lbTextBox" Width="80" MaxLength="6"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="HEIGHT: 21px"><asp:label id="lblLabel3" runat="server" CssClass="lbLabel">06 - <u>K</u>iểu ngày tháng/Trạng thái phát hành</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 21px"><asp:dropdownlist id="ddlField2" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="b">b: Không có ngày tháng nào được đưa ra; ngày tháng trước công nguyên được sử dụng</asp:ListItem>
							<asp:ListItem Value="c">c: Ấn phẩm định kỳ hiện vẫn đang xuất bản</asp:ListItem>
							<asp:ListItem Value="d">d: Ấn phẩm định kỳ đã ngừng xuất bản</asp:ListItem>
							<asp:ListItem Value="e">e: Ngày tháng cụ thể</asp:ListItem>
							<asp:ListItem Value="i">i: Ngày tháng thu thập kèm theo</asp:ListItem>
							<asp:ListItem Value="k">k: Khoảng thời gian thu thập</asp:ListItem>
							<asp:ListItem Value="m">m: Đa ngày tháng</asp:ListItem>
							<asp:ListItem Value="n">n: Ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="p">p: Ngày tháng phân phối/phát hành/ấn hành và sản xuất/ghi của phần nếu có khác biệt</asp:ListItem>
							<asp:ListItem Value="q">q: Ngày tháng không rõ ràng (có nghi vấn)</asp:ListItem>
							<asp:ListItem Value="r">r: Ngày tháng tái bản/tái phát hành và ngày tháng của nguyên bản</asp:ListItem>
							<asp:ListItem Value="s">s: Biết/ước lượng một mốc ngày tháng</asp:ListItem>
							<asp:ListItem Value="t">t: Ngày tháng phát hành và ngày tháng đăng ký bản quyền</asp:ListItem>
							<asp:ListItem Value="u">u: Ấn phẩm định kỳ không có trạng thái</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel4" runat="server" CssClass="lbLabel">07-10 - Ngày <u>t</u>háng 1</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField3" runat="server" CssClass="lbTextBox" Width="80" ReadOnly="True"></asp:textbox><asp:dropdownlist id="ddlTemp3" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server" CssClass="lbLabel">11-14 - Ngà<u>y</u> tháng 2</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField4" runat="server" CssClass="lbTextBox" Width="80" ReadOnly="True"></asp:textbox><asp:dropdownlist id="ddlTemp4" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel6" runat="server" CssClass="lbLabel">15-17 - Nơi sản <u>x</u>uất, phát hành hoặc thực hiện</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField5" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlCountryCode" runat="server">
							<asp:ListItem Value="###">###</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel7" runat="server" CssClass="lbLabel">18-21 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField6" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp6" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">a: Không có minh hoạ</asp:ListItem>
							<asp:ListItem Value="b">b: Minh hoạ</asp:ListItem>
							<asp:ListItem Value="c">c: Bản đồ</asp:ListItem>
							<asp:ListItem Value="d">d: Chân dung</asp:ListItem>
							<asp:ListItem Value="e">e: Đồ thị</asp:ListItem>
							<asp:ListItem Value="f">f: Sơ đồ</asp:ListItem>
							<asp:ListItem Value="g">g: Bảng cứng</asp:ListItem>
							<asp:ListItem Value="h">h: Âm nhạc</asp:ListItem>
							<asp:ListItem Value="i">i: Các bản fax</asp:ListItem>
							<asp:ListItem Value="j">j: Coats of arms</asp:ListItem>
							<asp:ListItem Value="k">k: Genealogical tables</asp:ListItem>
							<asp:ListItem Value="l">l: Các mẫu biểu</asp:ListItem>
							<asp:ListItem Value="m">m: Tiêu bản, bản mẫu</asp:ListItem>
							<asp:ListItem Value="o">o: Phonodisc, phonowire, etc.</asp:ListItem>
							<asp:ListItem Value="p">p: Ảnh</asp:ListItem>
							<asp:ListItem Value="|">|: Illuminations</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="HEIGHT: 14px"><asp:label id="lblLabel8" runat="server" CssClass="lbLabel">22 - K<u>h</u>án/thính/độc giả nhắm tới</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 14px"><asp:dropdownlist id="ddlField7" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không rõ hoặc không chỉ ra cụ thể</asp:ListItem>
							<asp:ListItem Value="a">a: Mẫu giáo</asp:ListItem>
							<asp:ListItem Value="b">b: Primary</asp:ListItem>
							<asp:ListItem Value="c">c: Elementary and junior high</asp:ListItem>
							<asp:ListItem Value="d">d: Phổ thông trung học (senior high)</asp:ListItem>
							<asp:ListItem Value="e">e: Người lớn</asp:ListItem>
							<asp:ListItem Value="f">f: Đối tượng đặc biệt</asp:ListItem>
							<asp:ListItem Value="g">g: Chung</asp:ListItem>
							<asp:ListItem Value="j">j: Thiếu niên</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel9" runat="server" CssClass="lbLabel">23 - Dạng tư liệ<u>u</u></asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField8" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải những dạng bên dưới</asp:ListItem>
							<asp:ListItem Value="a">a: Vi phim (Microfilm)</asp:ListItem>
							<asp:ListItem Value="b">b: Vi phích (Microfiche)</asp:ListItem>
							<asp:ListItem Value="c">c: Microopaque</asp:ListItem>
							<asp:ListItem Value="d">d: In khổ lớn</asp:ListItem>
							<asp:ListItem Value="f">f: Chữ nổi (Braille)</asp:ListItem>
							<asp:ListItem Value="r">r: Tái bản theo khổ in thường</asp:ListItem>
							<asp:ListItem Value="s">s: Điện tử</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel10" runat="server" CssClass="lbLabel">24-27 - <u>B</u>ản chất của nội dung</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField9" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp9" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có bản chất nội dung đặc tả</asp:ListItem>
							<asp:ListItem Value="a">a: Bài trích, bài tóm tắt</asp:ListItem>
							<asp:ListItem Value="b">b: Sản phẩm thư mục</asp:ListItem>
							<asp:ListItem Value="c">c: Catalogs</asp:ListItem>
							<asp:ListItem Value="d">d: Từ điển</asp:ListItem>
							<asp:ListItem Value="e">e: Bách khoa toàn thư</asp:ListItem>
							<asp:ListItem Value="f">f: Handbooks</asp:ListItem>
							<asp:ListItem Value="g">g: Các văn bản pháp quy</asp:ListItem>
							<asp:ListItem Value="i">i: Chỉ mục</asp:ListItem>
							<asp:ListItem Value="j">j: Tài liệu phát minh, sáng chế</asp:ListItem>
							<asp:ListItem Value="k">k: Discographies</asp:ListItem>
							<asp:ListItem Value="l">l: Văn bản luật</asp:ListItem>
							<asp:ListItem Value="m">m: Luận án</asp:ListItem>
							<asp:ListItem Value="n">n: Surveys of literature in a subject area</asp:ListItem>
							<asp:ListItem Value="o">o: Reviews</asp:ListItem>
							<asp:ListItem Value="p">p: Programmed texts</asp:ListItem>
							<asp:ListItem Value="q">q: Filmographies</asp:ListItem>
							<asp:ListItem Value="r">r: Thư mục</asp:ListItem>
							<asp:ListItem Value="s">s: Thống kê</asp:ListItem>
							<asp:ListItem Value="t">t: Báo cáo khoa học</asp:ListItem>
							<asp:ListItem Value="v">v: Tài liệu và ghi chú về các vụ án</asp:ListItem>
							<asp:ListItem Value="w">w: Law reports and digests</asp:ListItem>
							<asp:ListItem Value="z">z: Hiệp ước</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel11" runat="server" CssClass="lbLabel">28 - Xuất bản phẩm của chính <u>p</u>hủ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField10" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải xuất bản phẩm của chính phủ</asp:ListItem>
							<asp:ListItem Value="a">a: Đặc khu tự trị hoặc bán tự trị</asp:ListItem>
							<asp:ListItem Value="c">c: Nhiều địa phương</asp:ListItem>
							<asp:ListItem Value="f">f: Chính phủ liên bang/chính phủ nhà nước</asp:ListItem>
							<asp:ListItem Value="i">i: Liên chính phủ</asp:ListItem>
							<asp:ListItem Value="l">l: Địa phương</asp:ListItem>
							<asp:ListItem Value="m">m: Hiệp bang</asp:ListItem>
							<asp:ListItem Value="o">o: Xuất bản phẩm của chính phủ - không rõ cấp</asp:ListItem>
							<asp:ListItem Value="s">s: Cấp nhà nước, cấp tỉnh, cấp đặc khu, cấp phụ thuộc vv</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ ấn phẩm có phải là do chính phủ xuất bản không</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel12" runat="server" CssClass="lbLabel">29 - Xuất bản phẩm củ<u>a</u> hội thảo, hội nghị</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField11" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không phải xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="1">1: Xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel13" runat="server" CssClass="lbLabel">30 - <u>F</u>estschrift</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField12" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không phải festschrift</asp:ListItem>
							<asp:ListItem Value="1">1: Festschrift</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel14" runat="server" CssClass="lbLabel">31 - <u>C</u>hỉ mục</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField13" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không có chỉ mục</asp:ListItem>
							<asp:ListItem Value="1">1: Có chỉ mục</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel15" runat="server" CssClass="lbLabel">32 - Không được định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField14" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel16" runat="server" CssClass="lbLabel">33 - Dạng văn chươ<u>n</u>g</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField15" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không phải văn chương (không mô tả rõ hơn)</asp:ListItem>
							<asp:ListItem Value="1">1: Văn chương (không mô tả rõ hơn)</asp:ListItem>
							<asp:ListItem Value="c">c: Truyện tranh liên hoàn</asp:ListItem>
							<asp:ListItem Value="d">d: Kịch</asp:ListItem>
							<asp:ListItem Value="e">e: Tham luận</asp:ListItem>
							<asp:ListItem Value="f">f: Tiểu thuyết</asp:ListItem>
							<asp:ListItem Value="h">h: Humor, satires, etc.</asp:ListItem>
							<asp:ListItem Value="i">i: Thư từ</asp:ListItem>
							<asp:ListItem Value="j">j: Truyện ngắn</asp:ListItem>
							<asp:ListItem Value="m">m: Nhiều dạng pha trộn</asp:ListItem>
							<asp:ListItem Value="p">p: Thơ</asp:ListItem>
							<asp:ListItem Value="s">s: Diễn văn</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel17" runat="server" CssClass="lbLabel">34 - T<u>i</u>ểu sử</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField16" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có dữ liệu tiểu sử</asp:ListItem>
							<asp:ListItem Value="a">a: Hồi ký</asp:ListItem>
							<asp:ListItem Value="b">b: Tiểu sử cá nhân</asp:ListItem>
							<asp:ListItem Value="c">c: Tiểu sử tập hợp</asp:ListItem>
							<asp:ListItem Value="d">d: Có thông tin tiểu sử</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel18" runat="server" CssClass="lbLabel">35-37 - <u>N</u>gôn ngữ</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField17" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlLanguage" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel19" runat="server" CssClass="lbLabel">38 - Bản ghi được <u>s</u>ửa chữa</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField18" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không sửa chữa</asp:ListItem>
							<asp:ListItem Value="d">d: Dashed-on information omitted</asp:ListItem>
							<asp:ListItem Value="o">o: Latinh hóa toàn bộ/thẻ in cũng được latin hóa</asp:ListItem>
							<asp:ListItem Value="r">r: Latinh hóa toàn bộ/thẻ in vẫn ở dạng phi latinh</asp:ListItem>
							<asp:ListItem Value="s">s: Thu gọn</asp:ListItem>
							<asp:ListItem Value="x">x: Có các ký tự bị mất</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel20" runat="server" CssClass="lbLabel">39 - Nguồn biên <u>m</u>ục</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField19" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Cơ quan thư mục quốc gia</asp:ListItem>
							<asp:ListItem Value="c">c: Chương trình biên mục hợp tác</asp:ListItem>
							<asp:ListItem Value="d">d: Nguồn khác</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" align="center" class='lbControlbar"'>
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" CssClass="lbButton" Text="Nhập(u)" Width="70px"></asp:button>
						<asp:button id="btnReset" runat="server" CssClass="lbButton" Text="Đặt lại(r)" Width="88px"></asp:button>
						<asp:button id="btnPreview" runat="server" CssClass="lbButton" Text="Xem(v)" Width="70px"></asp:button>
						<asp:button id="btnClose" runat="server" CssClass="lbButton" Text="Đóng(o)" Width="70px"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Sai định dạng ngày tháng</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
