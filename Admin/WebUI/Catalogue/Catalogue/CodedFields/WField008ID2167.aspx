<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField008ID2167" CodeFile="WField008ID2167.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
	<body leftMargin="0" topMargin="0" onload="ResValue(2167);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle"> 008-- Xuất bản nhiều kỳ</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%"><asp:label id="lblLabel2" runat="server" CssClass="lbLabel" style="Z-INDEX: 102">00-05 - Ngày nhập vào cơ sở dữ liệ<u>u</u></asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField1" runat="server" CssClass="lbTextBox" Width="80" style="Z-INDEX: 103"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel3" runat="server" CssClass="lbLabel" style="Z-INDEX: 104">06 - <u>K</u>iểu ngày tháng/Trạng thái xuất bản</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField2" runat="server" style="Z-INDEX: 105">
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
					<TD style="HEIGHT: 2px" vAlign="top"><asp:label id="lblLabel4" runat="server" CssClass="lbLabel" style="Z-INDEX: 106">07 - 10 - Ngày <u>t</u>háng 1</asp:label></TD>
					<TD style="HEIGHT: 2px" vAlign="top"><asp:textbox id="txtField3" runat="server" CssClass="lbTextBox" Width="80" style="Z-INDEX: 107"></asp:textbox><asp:dropdownlist id="ddlTemp3" runat="server" style="Z-INDEX: 108">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server" CssClass="lbLabel" style="Z-INDEX: 109">11 - 14 - Ngà<u>y</u> tháng 2</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField4" runat="server" CssClass="lbTextBox" Width="80" style="Z-INDEX: 110"></asp:textbox><asp:dropdownlist id="ddlTemp4" runat="server" style="Z-INDEX: 111">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel6" runat="server" CssClass="lbLabel" Width="342px">15 - 17 - Nơi xuất bản, <u>s</u>ản xuất hoặc thực hiện</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField5" runat="server" CssClass="lbTextBox" Width="80" style="Z-INDEX: 113"></asp:textbox><asp:dropdownlist id="ddlCountryCode" runat="server" style="Z-INDEX: 114">
							<asp:ListItem Value="###">###</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel7" runat="server" CssClass="lbLabel" style="Z-INDEX: 115"> 18 - <u>C</u>ấp định kỳ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField6" runat="server" Width="248px" style="Z-INDEX: 116">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có cấp địn kyf xác định</asp:ListItem>
							<asp:ListItem Value="a">a: Hàng năm</asp:ListItem>
							<asp:ListItem Value="b">b: Hai tháng 1 kỳ</asp:ListItem>
							<asp:ListItem Value="c">c: Một tuần 2 kỳ</asp:ListItem>
							<asp:ListItem Value="d">d: Hàng ngày</asp:ListItem>
							<asp:ListItem Value="e">e: Hai tuần 1 kỳ</asp:ListItem>
							<asp:ListItem Value="f">f: Sáu tháng 1 kỳ</asp:ListItem>
							<asp:ListItem Value="g">g: Hai năm 1 kỳ</asp:ListItem>
							<asp:ListItem Value="h">h: Ba năm 1 kỳ</asp:ListItem>
							<asp:ListItem Value="i">i: Một tuần 3 kỳ</asp:ListItem>
							<asp:ListItem Value="j">j: Một tháng 3 kỳ</asp:ListItem>
							<asp:ListItem Value="m">m: Hàng tháng</asp:ListItem>
							<asp:ListItem Value="q">q: Hàng quý</asp:ListItem>
							<asp:ListItem Value="s">s: Một tháng 2 kỳ</asp:ListItem>
							<asp:ListItem Value="t">t: Bốn tháng một kỳ</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="w">w: Hàng tuần</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">w: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel8" runat="server" CssClass="lbLabel" style="Z-INDEX: 117"> 19 - Tín<u>h</u> định kỳ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField7" runat="server" Width="248px" style="Z-INDEX: 118">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="n">n: Không định kỳ có chuẩn hoá</asp:ListItem>
							<asp:ListItem Value="r">r: Định kỳ</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="x">x: Hoàn toàn không định kỳ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel9" runat="server" CssClass="lbLabel" style="Z-INDEX: 119"> 20 - Trung tâm <u>I</u>SSN</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField8" runat="server" Width="320px" style="Z-INDEX: 120">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có mã do trung tâm ISSN cấp</asp:ListItem>
							<asp:ListItem Value="0">0: Trung tâm quốc tế</asp:ListItem>
							<asp:ListItem Value="1">1: Mỹ</asp:ListItem>
							<asp:ListItem Value="4">4: Canada</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel10" runat="server" CssClass="lbLabel" style="Z-INDEX: 121"> 21 - Kiểu ấn phẩ<u>m</u> định kỳ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField9" runat="server" Width="256px" style="Z-INDEX: 122">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải một trong các dạng sau  </asp:ListItem>
							<asp:ListItem Value="m">m: Tùng thư đơn giản </asp:ListItem>
							<asp:ListItem Value="n">n: Báo chí</asp:ListItem>
							<asp:ListItem Value="p">p: Ấn phẩm định kỳ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="Label5" runat="server" CssClass="lbLabel" style="Z-INDEX: 123"> 22 - <u>D</u>ạng tư liệu nguyên bản</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:dropdownlist id="ddlField10" runat="server" style="Z-INDEX: 124">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải một trong những dạng dưới dây</asp:ListItem>
							<asp:ListItem Value="a">a: Microfilm</asp:ListItem>
							<asp:ListItem Value="b">b: Microfiche</asp:ListItem>
							<asp:ListItem Value="c">c: Microopaque</asp:ListItem>
							<asp:ListItem Value="d">d: In khổ lớn</asp:ListItem>
							<asp:ListItem Value="f">f: In nổi (Braille)</asp:ListItem>
							<asp:ListItem Value="r">r: Tái bản từ bản in thông thường</asp:ListItem>
							<asp:ListItem Value="s">s: Điện tử</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="Label7" runat="server" CssClass="lbLabel" style="Z-INDEX: 125"> 23 - Dạng tư <u>l</u>iệu</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:dropdownlist id="ddlField11" runat="server" style="Z-INDEX: 126">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải một trong những dạng dưới d&#226;y</asp:ListItem>
							<asp:ListItem Value="a">a: Microfilm</asp:ListItem>
							<asp:ListItem Value="b">b: Microfiche</asp:ListItem>
							<asp:ListItem Value="c">c: Microopaque</asp:ListItem>
							<asp:ListItem Value="d">d: In khổ lớn</asp:ListItem>
							<asp:ListItem Value="f">f: In nổi (Braille)</asp:ListItem>
							<asp:ListItem Value="r">r: T&#225;i bản từ bản in th&#244;ng thường</asp:ListItem>
							<asp:ListItem Value="s">s: Điện tử</asp:ListItem>
							<asp:ListItem Value="|">|: Kh&#244;ng nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 11px" vAlign="top"><asp:label id="lblLabel11" runat="server" CssClass="lbLabel" style="Z-INDEX: 127">24 - Bản chất của toàn bộ tác <u>p</u>hẩm</asp:label></TD>
					<TD style="HEIGHT: 11px" vAlign="top"><asp:dropdownlist id="ddlField12" runat="server" Width="400px" style="Z-INDEX: 128">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có bản chất rõ ràng </asp:ListItem>
							<asp:ListItem Value="a">a: Tóm tắt, tổng lược</asp:ListItem>
							<asp:ListItem Value="b">b: Thư mục</asp:ListItem>
							<asp:ListItem Value="c">c: Catalô</asp:ListItem>
							<asp:ListItem Value="d">d: Từ điển</asp:ListItem>
							<asp:ListItem Value="e">e: Bách khoa thư</asp:ListItem>
							<asp:ListItem Value="f">f: Handbooks</asp:ListItem>
							<asp:ListItem Value="g">g: Văn bản pháp luật</asp:ListItem>
							<asp:ListItem Value="h">h: Tiểu sử</asp:ListItem>
							<asp:ListItem Value="i">i: Mục lục</asp:ListItem>
							<asp:ListItem Value="k">k: Discographies</asp:ListItem>
							<asp:ListItem Value="l">l: Legislation: </asp:ListItem>
							<asp:ListItem Value="m">m: Luận án</asp:ListItem>
							<asp:ListItem Value="n">n: Surveys of literature in a subject area</asp:ListItem>
							<asp:ListItem Value="o">o: Reviews</asp:ListItem>
							<asp:ListItem Value="p">p: Programmed texts</asp:ListItem>
							<asp:ListItem Value="q">q: Filmographies</asp:ListItem>
							<asp:ListItem Value="r">r: Directories</asp:ListItem>
							<asp:ListItem Value="s">s: Thống kê</asp:ListItem>
							<asp:ListItem Value="t">t: Báo cáo kỹ thuật</asp:ListItem>
							<asp:ListItem Value="v">v: Legal cases and case notes</asp:ListItem>
							<asp:ListItem Value="w">w: Law reports and digests</asp:ListItem>
							<asp:ListItem Value="z">z: Treaties</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu </asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel12" runat="server" CssClass="lbLabel" style="Z-INDEX: 129"> 25-27 - <u>B</u>ản chất của nội dung</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField13" runat="server" CssClass="lbTextBox" Width="80" style="Z-INDEX: 130"></asp:textbox><asp:dropdownlist id="ddlTemp13" runat="server" Width="264px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Nội dung không có bản chất đặc tả </asp:ListItem>
							<asp:ListItem Value="a">a: Tóm tắt, tổng lược</asp:ListItem>
							<asp:ListItem Value="b">b: Thư mục</asp:ListItem>
							<asp:ListItem Value="c">c: Catalô</asp:ListItem>
							<asp:ListItem Value="d">d: Từ điển</asp:ListItem>
							<asp:ListItem Value="e">e: Bách khoa thư</asp:ListItem>
							<asp:ListItem Value="f">f: Handbooks</asp:ListItem>
							<asp:ListItem Value="g">g: Văn bản pháp luật</asp:ListItem>
							<asp:ListItem Value="h">h: Tiểu sử</asp:ListItem>
							<asp:ListItem Value="i">i: Mục lục</asp:ListItem>
							<asp:ListItem Value="k">k: Discographies</asp:ListItem>
							<asp:ListItem Value="l">l: Legislation: </asp:ListItem>
							<asp:ListItem Value="m">m: Luận văn</asp:ListItem>
							<asp:ListItem Value="n">n: Surveys of literature in a subject area</asp:ListItem>
							<asp:ListItem Value="o">o: Reviews</asp:ListItem>
							<asp:ListItem Value="p">p: Programmed texts</asp:ListItem>
							<asp:ListItem Value="q">q: Filmographies</asp:ListItem>
							<asp:ListItem Value="r">r: Directories</asp:ListItem>
							<asp:ListItem Value="s">s: Thống kê</asp:ListItem>
							<asp:ListItem Value="t">t: Báo cáo kỹ thuật</asp:ListItem>
							<asp:ListItem Value="v">v: Legal cases and case notes</asp:ListItem>
							<asp:ListItem Value="w">w: Law reports and digests</asp:ListItem>
							<asp:ListItem Value="z">z: Treaties</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu </asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel13" runat="server" CssClass="lbLabel" Width="280px" style="Z-INDEX: 131"> 28 - X<u>u</u>ất bản phẩm của chính phủ</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField14" runat="server" Width="264px" style="Z-INDEX: 132">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải xuất bản phẩm của chính phủ </asp:ListItem>
							<asp:ListItem Value="a">a: Đặc khu tự trị hoặc bán tự trị</asp:ListItem>
							<asp:ListItem Value="c">c: Nhiều địa phương</asp:ListItem>
							<asp:ListItem Value="f">f: Chính phủ liên bang/Chính phủ Nhà nước</asp:ListItem>
							<asp:ListItem Value="i">i: Liên chính phủ</asp:ListItem>
							<asp:ListItem Value="l">l: Địa phương</asp:ListItem>
							<asp:ListItem Value="m">m: Hiệp bang</asp:ListItem>
							<asp:ListItem Value="o">o: Xuất bản phẩm của Chính phủ - không rõ cấp</asp:ListItem>
							<asp:ListItem Value="s">s: Cấp nhà nước, cấp tỉnh, cấp phụ thuộc v.v</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ ấn phẩm có phải là do Chính phủ xuất bản không</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="lblLabel14" runat="server" CssClass="lbLabel" style="Z-INDEX: 133">29 - Xuất bản phẩm của hội thả<u>o</u>, hội nghị</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top"><asp:dropdownlist id="ddlField15" runat="server" Width="176px" style="Z-INDEX: 134">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không phải xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="1">1: Xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel15" runat="server" CssClass="lbLabel" style="Z-INDEX: 135"> 30-32 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField16" runat="server" CssClass="lbTextBox" Width="80" Enabled="False" style="Z-INDEX: 136">###</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="Label1" runat="server" CssClass="lbLabel" style="Z-INDEX: 137"> 33 - Bảng chữ cái gốc hoặc bảng chữ cái của nh<u>a</u>n đề</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:dropdownlist id="ddlField17" runat="server" Width="264px" style="Z-INDEX: 138">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có bảng chữ cái nguyên gốc </asp:ListItem>
							<asp:ListItem Value="a">a: Latin cơ sở</asp:ListItem>
							<asp:ListItem Value="b">b: Latin mở rộng</asp:ListItem>
							<asp:ListItem Value="c">c: Ciryllic</asp:ListItem>
							<asp:ListItem Value="d">d: Nhật</asp:ListItem>
							<asp:ListItem Value="e">e: Hán</asp:ListItem>
							<asp:ListItem Value="f">f: Ả rập</asp:ListItem>
							<asp:ListItem Value="g">g: Hy lạp</asp:ListItem>
							<asp:ListItem Value="h">h: Do thái</asp:ListItem>
							<asp:ListItem Value="i">i: Thái</asp:ListItem>
							<asp:ListItem Value="j">j: Divanagari</asp:ListItem>
							<asp:ListItem Value="k">k: Triều Tiên</asp:ListItem>
							<asp:ListItem Value="l">l: Tamil</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label4" runat="server" CssClass="lbLabel" style="Z-INDEX: 139">34 - Điểm truy cập cuố<u>i</u>/kế tiếp</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField18" runat="server" Width="192px" style="Z-INDEX: 140">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Điểm truy cập kế tiếp</asp:ListItem>
							<asp:ListItem Value="1">1: Điểm truy cập cuối</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="Label3" runat="server" CssClass="lbLabel" style="Z-INDEX: 143"> 35 - 37: <u>N</u>gôn n<u>g</u>ữ</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:textbox id="txtField19" runat="server" CssClass="lbTextBox" Width="80" style="Z-INDEX: 144"></asp:textbox><asp:dropdownlist id="ddlLanguage" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="lblLabel19" runat="server" CssClass="lbLabel" style="Z-INDEX: 141">38 - Bả<u>n</u> ghi được sửa chữa</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:dropdownlist id="ddlField20" runat="server" style="Z-INDEX: 142">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không sửa chữa</asp:ListItem>
							<asp:ListItem Value="d">d: Dashed-on information omitted</asp:ListItem>
							<asp:ListItem Value="o">o: Latinh hoá toàn bộ/thẻ in cũng được latin hoá</asp:ListItem>
							<asp:ListItem Value="r">r: Latinh hoá toàn bộ/thẻ in vẫn ở dạng phi latinh</asp:ListItem>
							<asp:ListItem Value="s">s: Thu gọn</asp:ListItem>
							<asp:ListItem Value="x">x: Có các kí tự bị mất</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="Label2" runat="server" CssClass="lbLabel" Width="248px"> 39 - Nguồn biên <u>m</u>ục</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top">
					<asp:dropdownlist id="ddlField21" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không sửa chữa</asp:ListItem>
							<asp:ListItem Value="d">d: Dashed-on Information omitted</asp:ListItem>
							<asp:ListItem Value="o">o: Latin hoá toàn bộ/thẻ in cũng được latin hoá</asp:ListItem>
							<asp:ListItem Value="r">r: Latin hoá toàn bộ/thẻ in vẫn ở dạng phi latinh </asp:ListItem>
							<asp:ListItem Value="s">s: Thu gọn</asp:ListItem>
							<asp:ListItem Value="x">x: Có các kí tự bị mất</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu </asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar" align="center">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" CssClass="lbButton" Text="Nhập(u)" Width="70px"></asp:button>
						<asp:button id="btnReset" runat="server" CssClass="lbButton" Text="Đặt lại(r)" Width="88px"></asp:button>
						<asp:button id="btnPreview" runat="server" CssClass="lbButton" Text="Xem(v)" Width="64px"></asp:button>
						<asp:button id="btnClose" runat="server" CssClass="lbButton" Text="Đóng(o)" Width="72px"></asp:button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
				<asp:ListItem Value="1">Mẫu danh mục mới chưa được ghi nhận</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật mẫu danh mục thành công</asp:ListItem>
				<asp:ListItem Value="3">Đã ghi nhận mẫu mẫu danh mục mới</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa nhập tên mẫu danh mục</asp:ListItem>
				<asp:ListItem Value="5">Mẫu danh mục mới đã được ghi nhận</asp:ListItem>
				<asp:ListItem Value="6">Insert: </asp:ListItem>
				<asp:ListItem Value="7">Update: </asp:ListItem>
				<asp:ListItem Value="8">Delete: </asp:ListItem>
				<asp:ListItem Value="9">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="10">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
