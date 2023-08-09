<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField006ID4" CodeFile="WField006ID4.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField006ID4</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(4);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" Class="lbPageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" cssClass="lbPageTitle" Width="100%">006--BOOKS</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%">
						<asp:label id="lblLabel2" runat="server" Width="264px">00 - Type of 006 code</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">Books</asp:ListItem>
							<asp:ListItem Value="t">Manuscript language material</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel3" runat="server">01-04 - Không định nghĩa</asp:label></TD>
					<td>
						<asp:textbox id="txtField2" runat="server" Width="120px" MaxLength="4"></asp:textbox><asp:dropdownlist id="ddlTemp2" runat="server">
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
						</asp:dropdownlist>
					</td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server">05 - K<u>h</u>án/thính/độc giả nhắm tới</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField3" runat="server">
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
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server">06 -  Dạng tư liệ<u>u</u></asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server">
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
					<TD vAlign="top" style="HEIGHT: 16px"><asp:label id="lblLabel6" runat="server">07-10 - <u>B</u>ản chất của nội dung</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 16px"><asp:textbox id="txtField5" runat="server" Width="120px" MaxLength="4"></asp:textbox>
						<asp:dropdownlist id="ddlTemp5" runat="server">
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
						</asp:dropdownlist>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel7" runat="server">11 - Xuất bản phẩm của chính <u>p</u>hủ</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField6" runat="server">
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
					<TD vAlign="top">
						<asp:label id="lblLabel8" runat="server">12 - Xuất bản phẩm củ<u>a</u> hội thảo, hội nghị</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField7" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không phải xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="1">1: Xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel9" runat="server">13 - Festschrift</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField8" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không phải festschrift</asp:ListItem>
							<asp:ListItem Value="1">1: Festschrift</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server" Width="248px">14 - <u>C</u>hỉ mục</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField9" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không có chỉ mục</asp:ListItem>
							<asp:ListItem Value="1">1: Có chỉ mục</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel19" runat="server">15 - Không định nghĩa; bao gồm 1 ký tự trắng (#) hoặc ( | )</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField10" runat="server" Width="120px" Enabled="False" MaxLength="1">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel20" runat="server">16 -  Dạng văn chươ<u>n</u>g</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField11" runat="server">
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
					<TD vAlign="top"><asp:label id="lblLabel12" runat="server">17 - T<u>i</u>ểu sử</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField12" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có dữ liệu tiểu sử</asp:ListItem>
							<asp:ListItem Value="a">a: Hồi ký</asp:ListItem>
							<asp:ListItem Value="b">b: Tiểu sử cá nhân</asp:ListItem>
							<asp:ListItem Value="c">c: Tiểu sử tập hợp</asp:ListItem>
							<asp:ListItem Value="d">d: Có thông tin tiểu sử</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbcontrolbar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(i)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="73px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="63px"></asp:button>&nbsp;
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
