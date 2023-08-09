<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField008ID28" CodeFile="WField008ID28.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
	<body leftMargin="0" topMargin="0" onload="ResValue(28);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top">
					<TD class="lbpageTitle" vAlign="top" colSpan="2"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle"> 008 -- Bản đồ</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="307" style="WIDTH: 307px"><asp:label id="lblLabel2" runat="server" CssClass="lbLabel">00-05 - <u>N</u>gày nhập vào cơ sở dữ liệu</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField1" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="WIDTH: 307px; HEIGHT: 9px" vAlign="top"><asp:label id="lblLabel3" runat="server" CssClass="lbLabel">06 - <u>K</u>iểu ngày tháng/Trạng thái phát hành</asp:label></TD>
					<TD style="HEIGHT: 9px" vAlign="top"><asp:dropdownlist id="ddlField2" runat="server">
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
					<TD vAlign="top" style="WIDTH: 307px; HEIGHT: 2px"><asp:label id="lblLabel4" runat="server" CssClass="lbLabel">07-10 - Ngày <u>t</u>háng 1</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 2px"><asp:textbox id="txtField3" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp3" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel5" runat="server" CssClass="lbLabel">11-14 - Ngà<u>y</u> tháng 2</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField4" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp4" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px; HEIGHT: 17px"><asp:label id="lblLabel6" runat="server" CssClass="lbLabel" Width="272px" Height="24px">15 - 17 - Nơi xuất bản, sản <u>x</u>uất hoặc thực hiện</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 17px"><asp:textbox id="txtField5" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlCountryCode" runat="server">
							<asp:ListItem Value="###">###</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel7" runat="server" CssClass="lbLabel">18 - 21 - Địa <u>h</u>ình nổi</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField6" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp6" runat="server" Width="256px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không thể hiện địa hình nổi</asp:ListItem>
							<asp:ListItem Value="a">a: Ðường viền</asp:ListItem>
							<asp:ListItem Value="b">b: Đổ bóng</asp:ListItem>
							<asp:ListItem Value="c">c: Gradien và màu sắc thể hiện độ sâu</asp:ListItem>
							<asp:ListItem Value="d">d: Nét chải</asp:ListItem>
							<asp:ListItem Value="e">e: Phép đo độ sâu/Phép dò độ sâu</asp:ListItem>
							<asp:ListItem Value="f">f: Các đường định dạng</asp:ListItem>
							<asp:ListItem Value="g">g: Các cao điểm</asp:ListItem>
							<asp:ListItem Value="i">i: Bằng hình tượng </asp:ListItem>
							<asp:ListItem Value="j">j: Các mẫu đất  </asp:ListItem>
							<asp:ListItem Value="k">k: Phép đo độ sâu/isolines</asp:ListItem>
							<asp:ListItem Value="m">m: Vẽ phần nổi (rock drawing)</asp:ListItem>
							<asp:ListItem Value="z">z: Kiểu địa hình nổi khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="WIDTH: 307px; HEIGHT: 4px" vAlign="top"><asp:label id="lblLabel8" runat="server" CssClass="lbLabel">22 - 23 - <u>P</u>hép chiếu</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top"><asp:textbox id="txtField7" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlField7" runat="server" Width="336px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="##">##: Không chỉ ra phép chiếu</asp:ListItem>
							<asp:ListItem Value="aa">aa: Altoff</asp:ListItem>
							<asp:ListItem Value="ab">ab: Gnomic</asp:ListItem>
							<asp:ListItem Value="ac">ac: Lambert's azimuthal equal area</asp:ListItem>
							<asp:ListItem Value="ad">ad: Othorgraphic</asp:ListItem>
							<asp:ListItem Value="ae">ae: Azimuthal equidistant</asp:ListItem>
							<asp:ListItem Value="af">af: Stereographic</asp:ListItem>
							<asp:ListItem Value="ag">ag: General vertical near-sided</asp:ListItem>
							<asp:ListItem Value="ah">ah: Modified Stereographic for Alaska</asp:ListItem>
							<asp:ListItem Value="an">an: Chamberlin trimetric</asp:ListItem>
							<asp:ListItem Value="ap">ap: Polar sterereographic</asp:ListItem>
							<asp:ListItem Value="au">au: Azimuthal, không rõ kiểu cụ thể</asp:ListItem>
							<asp:ListItem Value="az">az: Azimuthal, kiểu khác</asp:ListItem>
							<asp:ListItem Value="ba">ba: Gall</asp:ListItem>
							<asp:ListItem Value="bb">bb: Goode's homolographic</asp:ListItem>
							<asp:ListItem Value="bc">bc: Lambert's cylindrical equal area</asp:ListItem>
							<asp:ListItem Value="bd">bd: Mercator</asp:ListItem>
							<asp:ListItem Value="be">be: Miller</asp:ListItem>
							<asp:ListItem Value="bf">bf: Mollweide</asp:ListItem>
							<asp:ListItem Value="bg">bg: Sinusoidal</asp:ListItem>
							<asp:ListItem Value="bh">bh: Transverse Mercator</asp:ListItem>
							<asp:ListItem Value="bi">bi: Gauss-Kruger</asp:ListItem>
							<asp:ListItem Value="bj">bj: Equirectangular</asp:ListItem>
							<asp:ListItem Value="bo">bo: Oblique Mercator</asp:ListItem>
							<asp:ListItem Value="br">br: Robinson</asp:ListItem>
							<asp:ListItem Value="bs">bs: Space oblique Mercator</asp:ListItem>
							<asp:ListItem Value="bu">bu: Cylindrical, không rõ kiểu cụ thể</asp:ListItem>
							<asp:ListItem Value="bz">bz: Cylindrical, kiểu khác</asp:ListItem>
							<asp:ListItem Value="ca">ca: Alber's equal area</asp:ListItem>
							<asp:ListItem Value="cb">cb: Bonne</asp:ListItem>
							<asp:ListItem Value="cc">cc: Lambert's conformal conic</asp:ListItem>
							<asp:ListItem Value="ce">ce: Equidistant conic</asp:ListItem>
							<asp:ListItem Value="cp">cp: Polyconic</asp:ListItem>
							<asp:ListItem Value="cu">cu: Conic, không rõ kiểu cụ thể</asp:ListItem>
							<asp:ListItem Value="cz">cz: Conic, equal area</asp:ListItem>
							<asp:ListItem Value="da">da: Armadillo</asp:ListItem>
							<asp:ListItem Value="db">db: Butterfly</asp:ListItem>
							<asp:ListItem Value="dc">dc: Eckert</asp:ListItem>
							<asp:ListItem Value="dd">dd: Goode's homolosine</asp:ListItem>
							<asp:ListItem Value="de">de: Miller's bipolar oblique conformal conic</asp:ListItem>
							<asp:ListItem Value="df">df: Van Der Grinten</asp:ListItem>
							<asp:ListItem Value="dg">dg: Dimaxion</asp:ListItem>
							<asp:ListItem Value="dh">dh: Cordiform</asp:ListItem>
							<asp:ListItem Value="dl">dl: Lambert conformal</asp:ListItem>
							<asp:ListItem Value="zz">zz: Kiểu khác</asp:ListItem>
							<asp:ListItem Value="||">||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel9" runat="server" CssClass="lbLabel"> 24 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField8" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel10" runat="server" CssClass="lbLabel">25 - Kiểu dữ liệu <u>b</u>ản đồ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField9" runat="server" Width="336px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">a: Bản đồ đơn</asp:ListItem>
							<asp:ListItem Value="b">b: Tùng thư bản đồ</asp:ListItem>
							<asp:ListItem Value="c">c: Sêri bản đồ</asp:ListItem>
							<asp:ListItem Value="d">d: Địa cầu</asp:ListItem>
							<asp:ListItem Value="e">e: Atlas</asp:ListItem>
							<asp:ListItem Value="f">f: Bản đồ rời bổ sung cho một tác phẩm khác</asp:ListItem>
							<asp:ListItem Value="g">g: Bản đồ đi kèm với một tác phẩm khác</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Khác</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel11" runat="server" CssClass="lbLabel">26-27 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField10" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">##</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel12" runat="server" CssClass="lbLabel">28 - Xuất bản phẩm của <u>c</u>hính phủ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField11" runat="server" Width="400px">
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
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel13" runat="server" CssClass="lbLabel"> 29 - <u>D</u>ạng tư liệu</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField12" runat="server" Width="336px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải một trong những dạng dưới dây</asp:ListItem>
							<asp:ListItem Value="a">a: Microfilm</asp:ListItem>
							<asp:ListItem Value="b">b: Microfiche</asp:ListItem>
							<asp:ListItem Value="c">c: Microopaque</asp:ListItem>
							<asp:ListItem Value="d">d: In khổ lớn</asp:ListItem>
							<asp:ListItem Value="f">f: In nổi (Braille)</asp:ListItem>
							<asp:ListItem Value="r">r: Tái bản từ bản in thông thường</asp:ListItem>
							<asp:ListItem Value="s">s: Điện tử</asp:ListItem>
							<asp:ListItem Value="|">|: Điện tử</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="WIDTH: 307px; HEIGHT: 4px" vAlign="top"><asp:label id="lblLabel14" runat="server" CssClass="lbLabel">30 - Không nhập liệu</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top"><asp:textbox id="txtField13" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel15" runat="server" CssClass="lbLabel">31 - Chỉ <u>m</u>ục</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField14" runat="server" Width="184px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không có chỉ mục</asp:ListItem>
							<asp:ListItem Value="1">1: Có chỉ mục</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel16" runat="server" CssClass="lbLabel">32 - Không đựơc định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField15" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel17" runat="server" CssClass="lbLabel">33 - 34 - Các đặc điểm kh<u>u</u>ôn dạng đặc biệt</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField16" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp16" runat="server" Width="320px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không có các đặc điểm khuôn dạng đặc biệt</asp:ListItem>
							<asp:ListItem Value="e">e: Viết tay</asp:ListItem>
							<asp:ListItem Value="j">j: Bưu thiếp, bưu ảnh</asp:ListItem>
							<asp:ListItem Value="k">k: Lịch</asp:ListItem>
							<asp:ListItem Value="l">l: Câu đố</asp:ListItem>
							<asp:ListItem Value="n">n: Trò choi</asp:ListItem>
							<asp:ListItem Value="o">o: Bản đồ tượng</asp:ListItem>
							<asp:ListItem Value="p">p: Quân bài</asp:ListItem>
							<asp:ListItem Value="r">r: Tờ roi</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="e|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel18" runat="server" CssClass="lbLabel">35 - 37 - <u>N</u>gôn ngữ</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField17" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlLanguage" runat="server"></asp:dropdownlist></TD>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="lblLabel19" runat="server" CssClass="lbLabel" Width="248px">38 - Bản gh<u>i</u> được sửa chữa</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField18" runat="server" Width="336px">
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
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="WIDTH: 307px"><asp:label id="Label1" runat="server" CssClass="lbLabel">39 - Ng<u>u</u>ồn biên mục</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField19" runat="server" Width="232px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Cơ quan thư mục quốc gia</asp:ListItem>
							<asp:ListItem Value="c">c: Chương trình biên mục hợp tác</asp:ListItem>
							<asp:ListItem Value="d">d: Nguồn khác</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR align="center" class="lbControlbar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="70px"></asp:button>
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="88px"></asp:button>
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="70px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="80px"></asp:button>
					</TD>
				</TR>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
