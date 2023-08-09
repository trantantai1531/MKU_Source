<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField008ID29" CodeFile="WField008ID29.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
	<body leftMargin="0" topMargin="0" onload="ResValue(29);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top">
					<TD class="lbpageTitle" vAlign="top" colSpan="2"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle"> 008 -- Âm thanh, âm nhạc</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%"><asp:label id="lblLabel2" runat="server" CssClass="lbLabel">00-05 - <u>N</u>gày nhập vào cơ sở dữ liệu</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField1" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 9px" vAlign="top"><asp:label id="lblLabel3" runat="server" CssClass="lbLabel">06 - <u>K</u>iểu ngày tháng/Trạng thái xuất bản</asp:label></TD>
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
					<TD style="HEIGHT: 2px" vAlign="top"><asp:label id="lblLabel4" runat="server" CssClass="lbLabel">07 - 10 - Ngày <u>t</u>háng 1</asp:label></TD>
					<TD style="HEIGHT: 2px" vAlign="top"><asp:textbox id="txtField3" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp3" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server" CssClass="lbLabel">11 - 14 - Ngà<u>y</u> tháng 2</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField4" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp4" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel6" runat="server" CssClass="lbLabel" Width="280px">15 - 17 - Nơi xuất bản, sản <u>x</u>uất hoặc thực hiện</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField5" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlCountryCode" runat="server">
							<asp:ListItem Value="###">###</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel7" runat="server" CssClass="lbLabel">18 - 19 - <u>H</u>ình thức của tác phẩm</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField6" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp6" runat="server" Width="224px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="an">an: Anthems</asp:ListItem>
							<asp:ListItem Value="bd">bd: Ballads</asp:ListItem>
							<asp:ListItem Value="bg">bg: Nhạc Bluegrass</asp:ListItem>
							<asp:ListItem Value="bl">bl: Blues</asp:ListItem>
							<asp:ListItem Value="bt">bt: Ballets</asp:ListItem>
							<asp:ListItem Value="ca">ca: Chaconnes</asp:ListItem>
							<asp:ListItem Value="cb">cb: Chants, Other religions</asp:ListItem>
							<asp:ListItem Value="cc">cc: Chants, Christian</asp:ListItem>
							<asp:ListItem Value="cg">cg: Concerti grossi</asp:ListItem>
							<asp:ListItem Value="ch">ch: Chorales</asp:ListItem>
							<asp:ListItem Value="cl">cl: Chorale preludes</asp:ListItem>
							<asp:ListItem Value="cn">cn: Canons and rounds</asp:ListItem>
							<asp:ListItem Value="co">co: Concertos</asp:ListItem>
							<asp:ListItem Value="cp">cp: Chansons, polyphonic</asp:ListItem>
							<asp:ListItem Value="cr">cr: Carois</asp:ListItem>
							<asp:ListItem Value="cs">cs: Chance copositions</asp:ListItem>
							<asp:ListItem Value="ct">ct: Cantatas</asp:ListItem>
							<asp:ListItem Value="cy">cy: Country music</asp:ListItem>
							<asp:ListItem Value="cz">cz: Canzonas</asp:ListItem>
							<asp:ListItem Value="df">df: Dance forms</asp:ListItem>
							<asp:ListItem Value="dv">dv: Divertimentos, serenades, cassations, divertissements, notturni</asp:ListItem>
							<asp:ListItem Value="fg">fg: Fugues</asp:ListItem>
							<asp:ListItem Value="fm">fm: Nhạc dân ca</asp:ListItem>
							<asp:ListItem Value="ft">ft: Fantasias</asp:ListItem>
							<asp:ListItem Value="gm">gm: Gospel music</asp:ListItem>
							<asp:ListItem Value="hy">hy: Hymns</asp:ListItem>
							<asp:ListItem Value="jz">jz: Jazz</asp:ListItem>
							<asp:ListItem Value="mc">mc: Musical revues and comedies</asp:ListItem>
							<asp:ListItem Value="md">md: Madrigals</asp:ListItem>
							<asp:ListItem Value="mi">mi: Minuets</asp:ListItem>
							<asp:ListItem Value="mo">mo: Motets</asp:ListItem>
							<asp:ListItem Value="mp">mp: Motion picture music</asp:ListItem>
							<asp:ListItem Value="mr">mr: Marches</asp:ListItem>
							<asp:ListItem Value="ms">ms: Masses</asp:ListItem>
							<asp:ListItem Value="mu">mu: Multiple forms</asp:ListItem>
							<asp:ListItem Value="mz">mz: Mazurkas</asp:ListItem>
							<asp:ListItem Value="nc">nc: Nocturnes</asp:ListItem>
							<asp:ListItem Value="nn">nn: Không áp dụng</asp:ListItem>
							<asp:ListItem Value="op">op: operas</asp:ListItem>
							<asp:ListItem Value="or">or: Oratorious</asp:ListItem>
							<asp:ListItem Value="ov">ov: Overtures</asp:ListItem>
							<asp:ListItem Value="pg">pg: Program music</asp:ListItem>
							<asp:ListItem Value="pm">pm: Passion music</asp:ListItem>
							<asp:ListItem Value="po">po: Polonaises</asp:ListItem>
							<asp:ListItem Value="pp">pp: Popular music</asp:ListItem>
							<asp:ListItem Value="pr">pr: Preludes</asp:ListItem>
							<asp:ListItem Value="ps">ps: Passacaglias</asp:ListItem>
							<asp:ListItem Value="pt">pt: Part-songs</asp:ListItem>
							<asp:ListItem Value="pv">pv: Pavans</asp:ListItem>
							<asp:ListItem Value="rc">rc: Nhạc rock</asp:ListItem>
							<asp:ListItem Value="rd">rd: Rondos</asp:ListItem>
							<asp:ListItem Value="rg">rg: Ragtime music</asp:ListItem>
							<asp:ListItem Value="ri">ri: Ricercars</asp:ListItem>
							<asp:ListItem Value="rp">rp: Rhapsodies</asp:ListItem>
							<asp:ListItem Value="rq">rq: Requiems</asp:ListItem>
							<asp:ListItem Value="sd">sd: Square dance music</asp:ListItem>
							<asp:ListItem Value="sg">sg: Bài hát</asp:ListItem>
							<asp:ListItem Value="sn">sn: Sonatas</asp:ListItem>
							<asp:ListItem Value="sp">sp: Symphonic poems</asp:ListItem>
							<asp:ListItem Value="st">st: Studies and exercises</asp:ListItem>
							<asp:ListItem Value="su">su: Suites</asp:ListItem>
							<asp:ListItem Value="sy">sy: Giao hưởng</asp:ListItem>
							<asp:ListItem Value="tc">tc: Toccatas</asp:ListItem>
							<asp:ListItem Value="ts">ts: Trio-sonatas</asp:ListItem>
							<asp:ListItem Value="uu">uu: Không rõ</asp:ListItem>
							<asp:ListItem Value="vr">vr: Variations</asp:ListItem>
							<asp:ListItem Value="wz">wz: Waltzes</asp:ListItem>
							<asp:ListItem Value="zz">zz: Khác</asp:ListItem>
							<asp:ListItem Value="||">||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel8" runat="server" CssClass="lbLabel">20 - Định dạng <u>b</u>ản nhạc</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField7" runat="server" Width="304px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">a: Full score</asp:ListItem>
							<asp:ListItem Value="b">b: Full score, miniature or study size</asp:ListItem>
							<asp:ListItem Value="c">c: Accompaniment reduced for keyboard</asp:ListItem>
							<asp:ListItem Value="d">d: Voice score</asp:ListItem>
							<asp:ListItem Value="e">e: Condenced score or piano-conductor score</asp:ListItem>
							<asp:ListItem Value="g">g: Close score</asp:ListItem>
							<asp:ListItem Value="m">m: Multiple score formats</asp:ListItem>
							<asp:ListItem Value="n">n: Không áp dụng</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel9" runat="server" CssClass="lbLabel"> 21 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField8" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel10" runat="server" CssClass="lbLabel">22 - Đối tượng thính giả nhắm tớ<u>i</u></asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField9" runat="server" Width="192px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không rõ hoặc không chỉ rõ</asp:ListItem>
							<asp:ListItem Value="a">a: Trước tuổi đến trường</asp:ListItem>
							<asp:ListItem Value="b">b: Tiểu học</asp:ListItem>
							<asp:ListItem Value="c">c: Trung học cơ sở</asp:ListItem>
							<asp:ListItem Value="d">d: Trung học phổ thông</asp:ListItem>
							<asp:ListItem Value="e">e: Người lớn</asp:ListItem>
							<asp:ListItem Value="f">f: Đặc biệt</asp:ListItem>
							<asp:ListItem Value="g">g: Chung</asp:ListItem>
							<asp:ListItem Value="j">j: Thiếu niên</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 11px" vAlign="top"><asp:label id="lblLabel11" runat="server" CssClass="lbLabel">23 - <u>D</u>ạng của tư liệu</asp:label></TD>
					<TD style="HEIGHT: 11px" vAlign="top"><asp:dropdownlist id="ddlField10" runat="server" Width="304px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Không phải một trong các dạng dưới đây</asp:ListItem>
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
					<TD vAlign="top"><asp:label id="lblLabel12" runat="server" CssClass="lbLabel">24 - 29 - Tư liệu đi kè<u>m</u></asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField11" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlField11" runat="server" Width="400px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: No accompanying matter</asp:ListItem>
							<asp:ListItem Value="a">a: Discography</asp:ListItem>
							<asp:ListItem Value="b">b: Thư mục</asp:ListItem>
							<asp:ListItem Value="c">c: Chỉ mục chủ đề</asp:ListItem>
							<asp:ListItem Value="d">d: Libbretto or text</asp:ListItem>
							<asp:ListItem Value="e">e: Tiểu sử tác giả hoặc người sáng tác</asp:ListItem>
							<asp:ListItem Value="f">f: Tiểu sử của người trình diễn hoặc lịch sử của khúc đồng diễn</asp:ListItem>
							<asp:ListItem Value="g">g: Thông tin lịch sử và/hoặc thông tin kỹ thuật về các nhạc cụ</asp:ListItem>
							<asp:ListItem Value="h">h: Thông tin kỹ thuật về âm nhạc</asp:ListItem>
							<asp:ListItem Value="i">i: Thông tin lịch sử</asp:ListItem>
							<asp:ListItem Value="k">k: Thông tin dân tộc học</asp:ListItem>
							<asp:ListItem Value="r">r: Tài liệu giới thiệu</asp:ListItem>
							<asp:ListItem Value="s">s: Âm nhạc</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel13" runat="server" CssClass="lbLabel"> 30 - 31 - Phần lời văn ch<u>o</u> tư liệu âm nhạc</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField12" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp12" runat="server" Width="224px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Tư liệu là bản ghi âm nhạc </asp:ListItem>
							<asp:ListItem Value="a">a: Hồi kí</asp:ListItem>
							<asp:ListItem Value="b">b: Tiểu sử</asp:ListItem>
							<asp:ListItem Value="c">c: Kỷ yếu hội thảo</asp:ListItem>
							<asp:ListItem Value="d">d: Kịch</asp:ListItem>
							<asp:ListItem Value="e">e: Khoá luận</asp:ListItem>
							<asp:ListItem Value="f">f: Tiểu thuyết</asp:ListItem>
							<asp:ListItem Value="g">g: Bản tường trình</asp:ListItem>
							<asp:ListItem Value="h">h: Lịch sử</asp:ListItem>
							<asp:ListItem Value="i">i: Bản giới thiệu</asp:ListItem>
							<asp:ListItem Value="j">j: Giới thiệu ngôn ngữ</asp:ListItem>
							<asp:ListItem Value="k">k: Hài kịch</asp:ListItem>
							<asp:ListItem Value="l">l: Bài giảng, bài nói</asp:ListItem>
							<asp:ListItem Value="m">m: Nhật ký</asp:ListItem>
							<asp:ListItem Value="n">n: Không áp dụng</asp:ListItem>
							<asp:ListItem Value="o">o: Trưyện dân gian</asp:ListItem>
							<asp:ListItem Value="p">p: Thơ</asp:ListItem>
							<asp:ListItem Value="r">r: Bài diễn tập</asp:ListItem>
							<asp:ListItem Value="s">s: Âm thanh</asp:ListItem>
							<asp:ListItem Value="t">t: Phỏng vấn</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="lblLabel14" runat="server" CssClass="lbLabel">32 -34 - Không định nghĩ<u>a</u></asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top"><asp:textbox id="txtField13" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">###</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel15" runat="server" CssClass="lbLabel">35 - 37 - <u>N</u>gôn ngữ</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField14" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlLanguage" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel19" runat="server" CssClass="lbLabel" Width="248px">38 - Bản gh<u>i</u> được sửa chữa</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField15" runat="server" Width="304px">
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
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="lblLabel20" runat="server" CssClass="lbLabel"> 39 - Ng<u>u</u>ồn biên mục</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:dropdownlist id="ddlField16" runat="server" Width="232px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Cơ quan thư mục quốc gia</asp:ListItem>
							<asp:ListItem Value="c">c: Chương trình biên mục hợp tác</asp:ListItem>
							<asp:ListItem Value="d">d: Nguồn khấc</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				<TR vAlign="top" align="center" class="lbControlbar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="80px"></asp:button>
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="88px"></asp:button>
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="70px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="80px"></asp:button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddllabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
