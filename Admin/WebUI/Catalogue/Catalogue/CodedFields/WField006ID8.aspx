<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField006ID8" CodeFile="WField006ID8.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField006ID8</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(8);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top">
					<TD class="lbpageTitle" vAlign="top" colSpan="2">
						<asp:label id="lblTitle" Width="100%" runat="server" CssClass="lbPageTitle"> 006--CONTINUING RESOURCES</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>T</u>ype of 006 code</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="s">Serial control</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01 - <u>C</u>ấp định kỳ</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField2" runat="server" Width="248px" style="Z-INDEX: 116">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel3" runat="server"> 02 - Tín<u>h</u> định kỳ</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField3" runat="server" Width="248px" style="Z-INDEX: 118">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="n">n: Không định kỳ có chuẩn hoá</asp:ListItem>
							<asp:ListItem Value="r">r: Định kỳ</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="x">x: Hoàn toàn không định kỳ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server"> 03 - Không xác định</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField4" runat="server" Width="120px" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 04 - Kiểu ấn phẩ<u>m</u> định kỳ</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField5" runat="server" Width="256px" style="Z-INDEX: 122">
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
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 05 - <u>D</u>ạng tư liệu nguyên bản</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" style="Z-INDEX: 124">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 06 - Dạng tư <u>l</u>iệu</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField7" runat="server" style="Z-INDEX: 126">
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
					<TD vAlign="top"><asp:label id="Label3" runat="server"> 07 - Bản chất của toàn bộ tác <u>p</u>hẩm</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField8" runat="server" Width="400px" style="Z-INDEX: 128">
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
					<TD vAlign="top"><asp:label id="Label4" runat="server"> 08-10 - <u>B</u>ản chất của nội dung</asp:label></TD>
					<td><asp:textbox id="txtField9" runat="server" Width="120px"></asp:textbox><asp:dropdownlist id="ddlTemp9" runat="server" Width="264px">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label6" runat="server"> 11 - X<u>u</u>ất bản phẩm của chính phủ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField10" runat="server" Width="264px" style="Z-INDEX: 132">
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
					<TD vAlign="top"><asp:label id="Label7" runat="server"> 12 - Xuất bản phẩm của hội thả<u>o</u>, hội nghị</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField11" runat="server" Width="176px" style="Z-INDEX: 134">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không phải xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="1">1: Xuất bản phẩm của hội nghị</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label8" runat="server"> 13-15 - Không xác định</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField12" runat="server" Width="120px" Enabled="False">###</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label9" runat="server"> 16 - Bảng chữ cái gốc hoặc bảng chữ cái của nh<u>a</u>n đề</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField13" runat="server" Width="264px" style="Z-INDEX: 138">
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
						</asp:dropdownlist></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label10" runat="server"> 17 - Điểm truy cập cuố<u>i</u>/kế tiếp</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField14" runat="server" Width="192px" style="Z-INDEX: 140">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Điểm truy cập kế tiếp</asp:ListItem>
							<asp:ListItem Value="1">1: Điểm truy cập cuối</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="82px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(l)" Width="82px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(x)" Width="65px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
