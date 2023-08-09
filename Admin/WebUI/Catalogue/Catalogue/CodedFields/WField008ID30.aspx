<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField008ID30" CodeFile="WField008ID30.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
	<body leftMargin="0" topMargin="0" onload="ResValue(30);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top">
					<TD class="lbpageTitle" vAlign="top" colSpan="2"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle"> 008-- Tư liệu nghe nhìn</asp:label></TD>
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
					<TD vAlign="top"><asp:label id="lblLabel7" runat="server" CssClass="lbLabel">18-20 - Trường độ của <u>p</u>him hoặc video</asp:label></TD>
					<TD vAlign="top">Trường độ (001-999):
						<asp:textbox id="txtField6" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox>&nbsp;Khác:<asp:dropdownlist id="ddlTemp6" runat="server" Width="232px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="---">---: Không rõ</asp:ListItem>
							<asp:ListItem Value="000">000: Trường độ vượt quá 3 chữ số</asp:ListItem>
							<asp:ListItem Value="nnn">nnn: Không áp dụng</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel8" runat="server" CssClass="lbLabel"> 21 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField7" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel9" runat="server" CssClass="lbLabel"> 22 - Đối tượng độc giả/khán giả nhắm tớ<u>i</u></asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField8" runat="server" Width="216px">
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
					<TD vAlign="top"><asp:label id="lblLabel10" runat="server" CssClass="lbLabel"> 23-27 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField9" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">#####</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 11px" vAlign="top"><asp:label id="lblLabel11" runat="server" CssClass="lbLabel">28 - Xuất bản phẩm của <u>c</u>hính phủ</asp:label></TD>
					<TD style="HEIGHT: 11px" vAlign="top"><asp:dropdownlist id="ddlField10" runat="server" Width="296px">
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
					<TD vAlign="top"><asp:label id="lblLabel12" runat="server" CssClass="lbLabel"> 23 - <u>D</u>ạng của tư liệu</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField11" runat="server" Width="296px">
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
					<TD vAlign="top"><asp:label id="lblLabel13" runat="server" CssClass="lbLabel"> 30-32 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField12" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">###</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="lblLabel14" runat="server" CssClass="lbLabel">33 - Kiể<u>u</u> tư liệu nghe nhìn</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top"><asp:dropdownlist id="ddlField13" runat="server" Width="216px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">a: Art origial</asp:ListItem>
							<asp:ListItem Value="b">b: Kit</asp:ListItem>
							<asp:ListItem Value="c">c: Art Reproduction</asp:ListItem>
							<asp:ListItem Value="d">d: Diorama</asp:ListItem>
							<asp:ListItem Value="f">f: Đoạn phim</asp:ListItem>
							<asp:ListItem Value="g">g: Trò chơi</asp:ListItem>
							<asp:ListItem Value="i">i: Tranh ảnh</asp:ListItem>
							<asp:ListItem Value="k">k: Đồ hoạ</asp:ListItem>
							<asp:ListItem Value="l">l: Bản vẽ kỹ thuật</asp:ListItem>
							<asp:ListItem Value="m">m: Phim</asp:ListItem>
							<asp:ListItem Value="n">n: Biểu đồ</asp:ListItem>
							<asp:ListItem Value="o">o: Flash card</asp:ListItem>
							<asp:ListItem Value="p">p: Microscope slide</asp:ListItem>
							<asp:ListItem Value="q">q: Mopdel</asp:ListItem>
							<asp:ListItem Value="r">r: Realia</asp:ListItem>
							<asp:ListItem Value="s">s: Slide</asp:ListItem>
							<asp:ListItem Value="t">t: Transparency</asp:ListItem>
							<asp:ListItem Value="v">v: Băng video</asp:ListItem>
							<asp:ListItem Value="w">w: Đồ chơi</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 7px" vAlign="top"><asp:label id="lblLabel15" runat="server" CssClass="lbLabel"> 34 - Kỹ th<u>u</u>ật</asp:label></TD>
					<TD style="HEIGHT: 7px" vAlign="top"><asp:dropdownlist id="ddlField14" runat="server" Width="216px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">a: Hoạt hình</asp:ListItem>
							<asp:ListItem Value="b">b: Hoạt hình và cảnh thật</asp:ListItem>
							<asp:ListItem Value="l">l: Cảnh thật</asp:ListItem>
							<asp:ListItem Value="n">n: Không áp dụng</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="z">z: Kỹ thuật khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="Label1" runat="server" CssClass="lbLabel"> 35-37 - <u>N</u>gôn ngữ</asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:textbox id="txtField15" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlLanguage" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel19" runat="server" CssClass="lbLabel">38 - <u>B</u>ản ghi được sửa chữa</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField16" runat="server" Width="296px">
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
					<TD style="HEIGHT: 24px" vAlign="top"><asp:label id="lblLabel20" runat="server" CssClass="lbLabel"> 39 - Nguồn biên mụ<u>c</u></asp:label></TD>
					<TD style="HEIGHT: 24px" vAlign="top"><asp:dropdownlist id="ddlField17" runat="server" Width="216px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Cơ quan thư mục quốc gia</asp:ListItem>
							<asp:ListItem Value="c">c: Chương trình biên mục hợp tác</asp:ListItem>
							<asp:ListItem Value="d">d: Nguồn khấc</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" align="center" class="lbControlbar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" CssClass="lbButton" Text="Nhập(u)" Width="70px"></asp:button>
						<asp:button id="btnReset" runat="server" CssClass="lbButton" Text="Đặt lại(r)" Width="88px"></asp:button>
						<asp:button id="btnPreview" runat="server" CssClass="lbButton" Text="Xem(v)" Width="70px"></asp:button>
						<asp:button id="btnClose" runat="server" CssClass="lbButton" Text="Đóng(o)" Width="78px"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
