<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField006ID6" CodeFile="WField006ID6.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField006ID6</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(6);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 006--MAPS</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="42%">
						<asp:label id="lblLabel2" runat="server">00 - <u>T</u>ype of 006 code</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="150px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="e">Catographic material</asp:ListItem>
							<asp:ListItem Value="f">Manuscript catographic material</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel3" runat="server"> 01-04 - Địa <u>h</u>ình nổi</asp:label></TD>
					<td>
						<asp:textbox id="txtField2" runat="server" Width="120px"></asp:textbox><asp:dropdownlist id="ddlTemp2" runat="server" Width="256px">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server"> 05-06 - <u>P</u>hép chiếu</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField3" runat="server" Width="336px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="##">##: Kh&#244;ng chỉ ra ph&#233;p chiếu</asp:ListItem>
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
							<asp:ListItem Value="au">au: Azimuthal, kh&#244;ng r&#245; kiểu cụ thể</asp:ListItem>
							<asp:ListItem Value="az">az: Azimuthal, kiểu kh&#225;c</asp:ListItem>
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
							<asp:ListItem Value="bu">bu: Cylindrical, kh&#244;ng r&#245; kiểu cụ thể</asp:ListItem>
							<asp:ListItem Value="bz">bz: Cylindrical, kiểu kh&#225;c</asp:ListItem>
							<asp:ListItem Value="ca">ca: Alber's equal area</asp:ListItem>
							<asp:ListItem Value="cb">cb: Bonne</asp:ListItem>
							<asp:ListItem Value="cc">cc: Lambert's conformal conic</asp:ListItem>
							<asp:ListItem Value="ce">ce: Equidistant conic</asp:ListItem>
							<asp:ListItem Value="cp">cp: Polyconic</asp:ListItem>
							<asp:ListItem Value="cu">cu: Conic, kh&#244;ng r&#245; kiểu cụ thể</asp:ListItem>
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
							<asp:ListItem Value="zz">zz: Kiểu kh&#225;c</asp:ListItem>
							<asp:ListItem Value="||">||: Kh&#244;ng nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server"> 07 - Không định nghĩa, bao gồm ký tự  ( # ) hoặc ( | )</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField4" runat="server" Width="120px" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 08 - Kiểu dữ liệu <u>b</u>ản đồ</asp:label></TD>
					<td><asp:dropdownlist id="ddlField5" runat="server" Width="336px">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 09-10 - Không định nghĩa, bao gồm ký tự  ( # ) hoặc ( | )</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField6" runat="server" Width="120px" Enabled="False">##</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 11 - Xuất bản phẩm của <u>c</u>hính phủ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField7" runat="server" Width="400px">
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
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 12 - <u>D</u>ạng tư liệu</asp:label></TD>
					<td><asp:dropdownlist id="ddlField8" runat="server" Width="336px">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server">13 - Không định nghĩa, bao gồm ký tự  ( # ) hoặc ( | )</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField9" runat="server" Width="120px" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label6" runat="server">14 - Chỉ <u>m</u>ục</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField10" runat="server" Width="184px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="0">0: Không có chỉ mục</asp:ListItem>
							<asp:ListItem Value="1">1: Có chỉ mục</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label7" runat="server">15 - Không định nghĩa, bao gồm ký tự  ( # ) hoặc ( | )</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField11" runat="server" Width="120px" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="Label8" runat="server">16-17 - Các đặc điểm kh<u>u</u>ôn dạng đặc biệt</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField12" runat="server" Width="120px"></asp:textbox><asp:dropdownlist id="ddlTemp12" runat="server" Width="320px">
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
				</TR>
				<TR vAlign="top" class="lbControlbar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="83px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
