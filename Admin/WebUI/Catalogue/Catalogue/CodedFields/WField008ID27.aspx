<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField008ID27" CodeFile="WField008ID27.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
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
	<body leftMargin="0" topMargin="0" onload="ResValue(27);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD class="lbpageTitle" vAlign="top" colSpan="2"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle">008 -- Tệp máy tính</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%"><asp:label id="lblLabel2" runat="server" CssClass="lbLabel" >00-05 - Ngày nhập và<u>o</u> cơ sở dữ liệu</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField1" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="HEIGHT: 9px"><asp:label id="lblLabel3" runat="server" CssClass="lbLabel" >06 - <u>K</u>iểu ngày tháng/Trạng thái phát hành</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 9px"><asp:dropdownlist id="ddlField2" runat="server" >
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
					<TD vAlign="top" style="HEIGHT: 2px"><asp:label id="lblLabel4" runat="server" CssClass="lbLabel">07-10 - Ngày <u>t</u>háng 1</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 2px"><asp:textbox id="txtField3" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp3" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server" CssClass="lbLabel">11-14 - Ngà<u>y</u> tháng 2</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField4" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlTemp4" runat="server">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="####">####: Không áp dụng được cấu thành ngày tháng</asp:ListItem>
							<asp:ListItem Value="uuuu">uuuu: Toàn bộ hoặc một phần của cấu thành ngày tháng không rõ</asp:ListItem>
							<asp:ListItem Value="||||">||||: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel6" runat="server" CssClass="lbLabel" Width="280px">15-17 - Nơi sản xuất, sản <u>x</u>uất hoặc thực hiện</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField5" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlCountryCode" runat="server">
							<asp:ListItem Value="###">###</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel7" runat="server" CssClass="lbLabel">18-21 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField6" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">####</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel8" runat="server" CssClass="lbLabel">22 - K<u>h</u>án/thính/độc giả nhắm tới</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField7" runat="server" Width="256" Height="22">
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
					<TD vAlign="top"><asp:label id="lblLabel9" runat="server" CssClass="lbLabel">23 - 25 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField8" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">###</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel10" runat="server" CssClass="lbLabel">26 - Kiểu tệp <u>m</u>áy tính</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField9" runat="server" Width="256" Height="22">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">a: Số liệu</asp:ListItem>
							<asp:ListItem Value="b">b: Chương trình máy tính</asp:ListItem>
							<asp:ListItem Value="c">c: Representational</asp:ListItem>
							<asp:ListItem Value="d">d: Văn bản</asp:ListItem>
							<asp:ListItem Value="e">e: Dữ liệu thư mục</asp:ListItem>
							<asp:ListItem Value="f">f: Phông chữ</asp:ListItem>
							<asp:ListItem Value="g">g: Trò chơi</asp:ListItem>
							<asp:ListItem Value="h">h: Âm thanh</asp:ListItem>
							<asp:ListItem Value="i">i: Đa phương tiện tương tác</asp:ListItem>
							<asp:ListItem Value="j">j: Dịch vụ hoặc hệ thống trực tuyến</asp:ListItem>
							<asp:ListItem Value="m">m: Kết hợp</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="z">z: Khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel11" runat="server" CssClass="lbLabel">27 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField10" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel12" runat="server" CssClass="lbLabel">28 - Xuất bản phẩm của chính <u>p</u>hủ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField11" runat="server">
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
					<TD vAlign="top"><asp:label id="lblLabel13" runat="server" CssClass="lbLabel" Width="280px">29 - 34 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField12" runat="server" CssClass="lbTextBox" Width="80" Enabled="False">######</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="HEIGHT: 6px"><asp:label id="lblLabel14" runat="server" CssClass="lbLabel">35 - 37 - <u>N</u>gôn ngữ</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 6px"><asp:textbox id="txtField13" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox><asp:dropdownlist id="ddlLanguage" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel15" runat="server" CssClass="lbLabel">38 - Bản ghi được <u>s</u>ửa chữa</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField14" runat="server" Width="320" Height="22">
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
					<TD vAlign="top"><asp:label id="lblLabel16" runat="server" CssClass="lbLabel">39 - Ng<u>u</u>ồn biên mục</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField15" runat="server" Width="256" Height="22">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="#">#: Cơ quan thư mục quốc gia</asp:ListItem>
							<asp:ListItem Value="c">c: Chương trình biên mục hợp tác</asp:ListItem>
							<asp:ListItem Value="d">d: Nguồn khác</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR align="center" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="70px"></asp:button>
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="88px"></asp:button>
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="70px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="78px"></asp:button>
						</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
