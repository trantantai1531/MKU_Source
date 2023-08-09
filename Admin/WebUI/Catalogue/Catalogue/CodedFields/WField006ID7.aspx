<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField006ID7" CodeFile="WField006ID7.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField006ID7</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(7);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD class="lbpageTitle" vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 006--MUSIC</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%"><asp:label id="lblLabel2" runat="server"> 00 - <u>T</u>ype of 006 code</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="180px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="c">Printed music</asp:ListItem>
							<asp:ListItem Value="d">Manuscript music</asp:ListItem>
							<asp:ListItem Value="i">Nonmusical sound recording</asp:ListItem>
							<asp:ListItem Value="j">Musical sound recording</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01-02 - <u>H</u>ình thức của tác phẩm</asp:label></TD>
					<td><asp:dropdownlist id="ddlField2" runat="server" Width="224px">
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
							<asp:ListItem Value="fm">fm: Nhạc d&#226;n ca</asp:ListItem>
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
							<asp:ListItem Value="nn">nn: Kh&#244;ng &#225;p dụng</asp:ListItem>
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
							<asp:ListItem Value="sg">sg: B&#224;i h&#225;t</asp:ListItem>
							<asp:ListItem Value="sn">sn: Sonatas</asp:ListItem>
							<asp:ListItem Value="sp">sp: Symphonic poems</asp:ListItem>
							<asp:ListItem Value="st">st: Studies and exercises</asp:ListItem>
							<asp:ListItem Value="su">su: Suites</asp:ListItem>
							<asp:ListItem Value="sy">sy: Giao hưởng</asp:ListItem>
							<asp:ListItem Value="tc">tc: Toccatas</asp:ListItem>
							<asp:ListItem Value="ts">ts: Trio-sonatas</asp:ListItem>
							<asp:ListItem Value="uu">uu: Kh&#244;ng r&#245;</asp:ListItem>
							<asp:ListItem Value="vr">vr: Variations</asp:ListItem>
							<asp:ListItem Value="wz">wz: Waltzes</asp:ListItem>
							<asp:ListItem Value="zz">zz: Kh&#225;c</asp:ListItem>
							<asp:ListItem Value="||">||: Kh&#244;ng nhập liệu</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="HEIGHT: 7px">
						<asp:label id="lblLabel3" runat="server"> 03 - Định dạng <u>b</u>ản nhạc</asp:label></TD>
					<td style="HEIGHT: 7px"><asp:dropdownlist id="ddlField3" runat="server" Width="304px">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server"> 04 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField4" runat="server" Width="120px" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 05 - Đối tượng thính giả nhắm tớ<u>i</u></asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField5" runat="server" Width="192px">
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
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 06 - <u>D</u>ạng của tư liệu</asp:label></TD>
					<td><asp:dropdownlist id="ddlField6" runat="server" Width="304px">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 07-12 - Tư liệu đi kè<u>m</u></asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField7" runat="server" Width="120px"></asp:textbox><asp:dropdownlist id="ddlTemp7" runat="server" Width="345px">
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
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 13-14 - Phần lời văn ch<u>o</u> tư liệu âm nhạc</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField8" runat="server" Width="120px"></asp:textbox><asp:dropdownlist id="ddlTemp8" runat="server" Width="224px">
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
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 15-17 - Không định nghĩa</asp:label></TD>
					<td>
						<asp:textbox id="txtField9" runat="server" Width="120px" Enabled="False">###</asp:textbox></td>
				</TR>
				<TR vAlign="top" class="lbControlbar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="75px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
