<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField008Authority" CodeFile="WField008Authority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cấu thành dữ liệu có độ dài cố định </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue008Authority();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top">
					<TD class="lbpageTitle" vAlign="top" colSpan="2"><asp:label id="lblLabel1" runat="server" CssClass="lbpageTitle">008 -- Các yếu tố dữ liệu cố định độ dài</asp:label></TD>
				</TR>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%"><asp:label id="lblLabel2" runat="server" CssClass="lbLabel" Width="240px">00-05 - Ngày nhập và<u>o</u> cơ sở dữ liệu</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtField1" runat="server" CssClass="lbTextBox" Width="80" MaxLength="6"></asp:textbox>&nbsp;&nbsp;
						<asp:label id="lblLabel16" runat="server" CssClass="lbLabel" Width="240px">     yymmdd</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel3" runat="server" CssClass="lbLabel">06 - Phân mục địa lý trực tiếp hoặc gián tiếp</asp:label></TD>
					<TD vAlign="top">
						<P><asp:dropdownlist id="ddlField2" runat="server">
								<asp:ListItem Value="#"># - Không có phân mục địa lý</asp:ListItem>
								<asp:ListItem Value="d">d - Được phân mục địa lý--trực tiếp</asp:ListItem>
								<asp:ListItem Value="i">i - Được phân mục địa lý--gián tiếp</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel17" runat="server" CssClass="lbLabel" Width="440px" Height="48px">Chỉ ra xem đề mục 1XX có thể được gán phân mục địa lý nếu được sử dụng như một đề mục chủ đề hay không và trong trường hợp đó thì phương pháp phân mục được sử dụng là như thế nào. </asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel4" runat="server" CssClass="lbLabel">07-Cách thức Latin hóa chữ cái</asp:label></TD>
					<td>
						<P>
							<asp:dropdownlist id="ddlField3" runat="server" Width="272px">
								<asp:ListItem Value="a">a - Chuẩn quốc tế</asp:ListItem>
								<asp:ListItem Value="b">b - Chuẩn quốc gia</asp:ListItem>
								<asp:ListItem Value="c">c - Chuẩn hiệp hội thư viện quốc gia</asp:ListItem>
								<asp:ListItem Value="d">d - Chuẩn của thư viện hoặc cơ quan biên mục quốc gia</asp:ListItem>
								<asp:ListItem Value="e">e - Chuẩn cục bộ</asp:ListItem>
								<asp:ListItem Value="f">f - Chuẩn không rõ nguồn gốc</asp:ListItem>
								<asp:ListItem Value="g">g - Hình thức hoặc cách Latinh hóa thường dùng trong ngôn ngữ của cơ quan biên mục</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng (Đề mục 1XX không được Latinh hóa).</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel18" runat="server" CssClass="lbLabel">Chỉ ra xem trường 1XX có là tự dạng Latinh hóa của đề mục hay không và nếu có thì chỉ ra cách chuyển tự </asp:label></P>
					</td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server" CssClass="lbLabel">08 - Ngôn ngữ biên mục</asp:label></TD>
					<TD vAlign="top">
						<P><asp:dropdownlist id="ddlField4" runat="server">
								<asp:ListItem Value="#"># - Không cung cấp thông tin</asp:ListItem>
								<asp:ListItem Value="b">b - Tiếng Anh và tiếng Pháp</asp:ListItem>
								<asp:ListItem Value="e">e - Chỉ tiếng Anh</asp:ListItem>
								<asp:ListItem Value="f">f - Chỉ tiếng Pháp</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel19" runat="server" CssClass="lbLabel">Chỉ ra xem trường đề mục 1XXvà các cấu trúc tham chiếu liên quan đến nó có hợp lệ theo các quy tắc sử dụng trong việc thiết lập các đề mục cho các biên mục tiếng Anh, tiếng Pháp, hoặc cả hai hay không </asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel6" runat="server" CssClass="lbLabel">09 - Kiểu bản ghi</asp:label></TD>
					<TD vAlign="top">
						<P><asp:dropdownlist id="ddlField5" runat="server">
								<asp:ListItem Value="a">a - Đề mục thiết lập</asp:ListItem>
								<asp:ListItem Value="b">b - Tham chiếu không truy cứu</asp:ListItem>
								<asp:ListItem Value="c">c - Tham chiếu có truy cứu</asp:ListItem>
								<asp:ListItem Value="d">d - Phân mục</asp:ListItem>
								<asp:ListItem Value="e">e - Nhãn nút</asp:ListItem>
								<asp:ListItem Value="f">f - Đề mục có thiết lập và phân mục</asp:ListItem>
								<asp:ListItem Value="g">g - Tham chiếu và phân mục</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel20" runat="server" CssClass="lbLabel">Chỉ ra xem bản ghi có thể hiện một đề mục thiết lập hoặc không thiết lập 1XX hay không. </asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top"><asp:label id="lblLabel7" runat="server" CssClass="lbLabel">10 - Các quy tắc biên mục mô tả</asp:label></TD>
					<TD vAlign="top">
						<P><asp:dropdownlist id="ddlField6" runat="server">
								<asp:ListItem Value="a">a - Các quy tắc sớm hơn</asp:ListItem>
								<asp:ListItem Value="b">b - AACR 1</asp:ListItem>
								<asp:ListItem Value="c">c - AACR 2</asp:ListItem>
								<asp:ListItem Value="d">d - Đề mục tương thích AACR 2</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="z">z - Khác</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel21" runat="server" CssClass="lbLabel">Chỉ ra các quy tắc biên mục mô tả sử dụng để định dạng đề mục tên trong trường 1XX, tên/nhan đề, hoặc nhan đề thống nhất trong các bản ghi đề mục thiết lập hoặc tham chiếu</asp:label>&nbsp;</P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" style="HEIGHT: 64px"><asp:label id="lblLabel8" runat="server" CssClass="lbLabel">11 - Hệ thống đề mục chủ đề/bộ từ khóa</asp:label></TD>
					<TD vAlign="top" style="HEIGHT: 64px">
						<P><asp:dropdownlist id="ddlField7" runat="server">
								<asp:ListItem Value="a">a - Đề mục chủ đề của Thư viện Quốc hội Mỹ (LC)</asp:ListItem>
								<asp:ListItem Value="b">b - Đề mục chủ đề của LC cho văn học thiếu nhi</asp:ListItem>
								<asp:ListItem Value="c">c - Đề mục chủ đề y khoa</asp:ListItem>
								<asp:ListItem Value="d">d - Danh sách đề mục căn cứ của thư viện Nông nghiệp Quốc gia Mỹ</asp:ListItem>
								<asp:ListItem Value="k">k - Đề mục chủ đề của Canada</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="r">r - Bộ từ khóa về hội hoạ và kiến trúc</asp:ListItem>
								<asp:ListItem Value="s">s - Đề mục chủ đề theo danh sách Sears</asp:ListItem>
								<asp:ListItem Value="v">v - Đề mục chủ đề của Pháp (Répertoire de vedettes-matière)</asp:ListItem>
								<asp:ListItem Value="z">z - Khác</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel22" runat="server" CssClass="lbLabel">Chỉ ra các quy ước xây dựng hệ thống đề mục chủ đề/bộ từ khóa được sử dụng để định dạng đề mục 1XX trong các bản ghi đề mục thiết lập, tham chiếu, hoặc nhãn nút.</asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="lblLabel9" runat="server" CssClass="lbLabel">12 - Kiểu tùng thư</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField8" runat="server">
								<asp:ListItem Value="a">a - Tùng thư đơn bản</asp:ListItem>
								<asp:ListItem Value="b">b - Tài liệu nhiều phần</asp:ListItem>
								<asp:ListItem Value="c">c - Cách biểu đạt như tùng thư</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="z">z - Khác</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel23" runat="server" CssClass="lbLabel">Chỉ ra kiểu đề mục tùng thư chứa trong trường 1XX trong bản ghi đề mục thiết lập.</asp:label>&nbsp;</P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label1" runat="server" CssClass="lbLabel">13 - Tùng thư có đánh số hoặc không đánh số</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField9" runat="server">
								<asp:ListItem Value="a">a - Có đánh số</asp:ListItem>
								<asp:ListItem Value="b">b - Không đánh số</asp:ListItem>
								<asp:ListItem Value="c">c - Thay đổi cách đánh số</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel24" runat="server" CssClass="lbLabel">Chỉ ra các đặc điểm trong việc đánh số tùng thư (hoặc cách biểu đạt như tùng thư) thể hiện trong đề mục 1XX.</asp:label>&nbsp;</P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label2" runat="server" CssClass="lbLabel">14 - Sử dụng đề mục--mục từ chính hoặc bổ trợ</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField10" runat="server">
								<asp:ListItem Value="a">a - Có phù hợp</asp:ListItem>
								<asp:ListItem Value="b">b - Không phù hợp</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel25" runat="server" CssClass="lbLabel">Chỉ ra xem đề mục 1XX có thích hợp để sử dụng như mục từ chính hoặc mục từ bổ trợ trong các bản ghi biên mục không.</asp:label>&nbsp;</P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 43px" vAlign="top"><asp:label id="Label3" runat="server" CssClass="lbLabel">15 - Sử dụng đề mục--mục từ bổ trợ chủ đề</asp:label></TD>
					<TD style="HEIGHT: 43px" vAlign="top">
						<P><asp:dropdownlist id="ddlField11" runat="server">
								<asp:ListItem Value="a">a - Có phù hợp</asp:ListItem>
								<asp:ListItem Value="b">b - Không phù hợp</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel26" runat="server" CssClass="lbLabel"></asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label4" runat="server" CssClass="lbLabel">16 - Sử dụng đề mục--mục từ bổ trợ tùng thư</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField12" runat="server">
								<asp:ListItem Value="a">a - Có phù hợp</asp:ListItem>
								<asp:ListItem Value="b">b - Không phù hợp</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel27" runat="server" CssClass="lbLabel">Chỉ ra xem đề mục 1XX có thích hợp để sử dụng như mục từ bổ trợ tùng thư trong các bản ghi biên mục hay không.</asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label5" runat="server" CssClass="lbLabel">17 - Kiểu phân mục chủ đề</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField13" runat="server">
								<asp:ListItem Value="a">a - Theo chủ điểm</asp:ListItem>
								<asp:ListItem Value="b">b - Khuôn dạng</asp:ListItem>
								<asp:ListItem Value="c">c - Niên đại</asp:ListItem>
								<asp:ListItem Value="d">d - Địa lý</asp:ListItem>
								<asp:ListItem Value="e">e - Ngôn ngữ</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel28" runat="server" CssClass="lbLabel">Chỉ ra kiểu của đề mục phân mục chủ đề trong trường 1XX của một bản ghi phân mục, bản ghi đề mục thiết lập và phân mục, hoặc một bản ghi tham chiếu và phân mục. </asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label6" runat="server" CssClass="lbLabel">18-27 - Các vị trí ký tự không định nghĩa</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<asp:textbox id="txtField14" value="##########" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label7" runat="server" CssClass="lbLabel">28 - Loại cơ quan chính phủ</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField15" runat="server">
								<asp:ListItem Value="#"># - Không phải là cơ quan chính phủ</asp:ListItem>
								<asp:ListItem Value="a">a - Một đơn vị tự trị hoặc bán tự trị</asp:ListItem>
								<asp:ListItem Value="c">c - Nhiều địa phương</asp:ListItem>
								<asp:ListItem Value="f">f - Liên bang/Quốc gia</asp:ListItem>
								<asp:ListItem Value="i">i - Liên chính phủ quốc tế</asp:ListItem>
								<asp:ListItem Value="l">l - Địa phương</asp:ListItem>
								<asp:ListItem Value="m">m - Nhiều bang</asp:ListItem>
								<asp:ListItem Value="o">o - Cơ quan chính phủ -- Không xác định kiểu</asp:ListItem>
								<asp:ListItem Value="s">s - Bang, tỉnh, địa khu, lãnh thổ phụ thuộc vv.</asp:ListItem>
								<asp:ListItem Value="z">z - Khác</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel29" runat="server" CssClass="lbLabel">Chỉ ra xem đề mục 1XX có thể hiện một cơ quan chính phủ hay không và nếu có thì chỉ ra mức độ pháp định của cơ quan này.</asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label8" runat="server" CssClass="lbLabel">29 - Đánh giá mức độ tham chiếu</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField16" runat="server">
								<asp:ListItem Value="a">a - Các mục từ truy cứu nhất quán với đề mục</asp:ListItem>
								<asp:ListItem Value="b">b - Các mục từ truy cứu không cần nhất quán với đề mục</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel30" runat="server" CssClass="lbLabel">Chỉ ra xem các trường truy cứu 4XX/5XX trong một bản ghi đã được đánh giá về mức nhất quán với với các quy tắc được sử dụng để định dạng đề mục 1XX trong cùng bản ghi.</asp:label>&nbsp;</P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label9" runat="server" CssClass="lbLabel">30 - Vị trí ký tự không định nghĩa</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<asp:textbox id="txtField17" runat="server" CssClass="lbTextBox" Width="80" size="1" value="#"></asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label10" runat="server" CssClass="lbLabel">31 - Bản ghi đang chỉnh sửa</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField18" runat="server">
								<asp:ListItem Value="a">a - Bản ghi có thể sử dụng</asp:ListItem>
								<asp:ListItem Value="b">b - Bản ghi đang được chỉnh sửa</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel31" runat="server" CssClass="lbLabel">Chỉ ra xem bản ghi có đang được xem xét để thay đổi không. </asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label11" runat="server" CssClass="lbLabel">32 - Tên riêng không được phân biệt</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField19" runat="server">
								<asp:ListItem Value="a">a - Tên riêng có phân biệt</asp:ListItem>
								<asp:ListItem Value="b">b - Tên riêng không phân biệt</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel32" runat="server" CssClass="lbLabel" Width="648px">Chỉ ra xem đề mục tên riêng trong trường 100 của một bản ghi đề mục thiết lập hoặc một bản ghi tham chiếu được sử dụng bởi một hoặc nhiều người hay không.</asp:label>&nbsp;</P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label12" runat="server" CssClass="lbLabel">33 - Mức độ thiết lập</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField20" runat="server">
								<asp:ListItem Value="a">a - Thiết lập đầy đủ</asp:ListItem>
								<asp:ListItem Value="b">b - Bản ghi nhớ</asp:ListItem>
								<asp:ListItem Value="c">c - Tạm thời</asp:ListItem>
								<asp:ListItem Value="d">d - Sơ bộ</asp:ListItem>
								<asp:ListItem Value="n">n - Không áp dụng</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel33" runat="server" CssClass="lbLabel">Chỉ ra mức độ mà đề mục 100-151 tuân thủ theo các quy tắc biên mục mô tả được mã trong vị trí 10 của trường 008 và/hoặc các quy ước về hệ thống đề mục chủ đề/bộ từ khóa được mã trong vị trí 11/trường 008 </asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label13" runat="server" CssClass="lbLabel">34-37 - Các vị trí ký tự không định nghĩa</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<asp:textbox id="txtField21" runat="server" CssClass="lbTextBox" Width="80" size="4" maxlength="4"
							value="####"></asp:textbox>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label14" runat="server" CssClass="lbLabel">38 - Bản ghi bị chỉnh sửa</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField22" runat="server">
								<asp:ListItem Value="#"># - Không chỉnh sửa</asp:ListItem>
								<asp:ListItem Value="s">s - Thu ngắn</asp:ListItem>
								<asp:ListItem Value="x">x - Bỏ mất một số chữ cái</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel34" runat="server" CssClass="lbLabel">Chỉ ra xem bản ghi có bị chỉnh sửa nội dung hay không </asp:label></P>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD style="HEIGHT: 4px" vAlign="top"><asp:label id="Label15" runat="server" CssClass="lbLabel">39 - Nguồn biên mục</asp:label></TD>
					<TD style="HEIGHT: 4px" vAlign="top">
						<P><asp:dropdownlist id="ddlField23" runat="server">
								<asp:ListItem Value="#"># - Cơ quan biên mục quốc gia</asp:ListItem>
								<asp:ListItem Value="c">c - Chương trình biên mục hợp tác</asp:ListItem>
								<asp:ListItem Value="d">d - Khác</asp:ListItem>
								<asp:ListItem Value="u">u - Không rõ</asp:ListItem>
								<asp:ListItem Value="|">| - Không được nhập</asp:ListItem>
							</asp:dropdownlist>
							<asp:label id="lblLabel35" runat="server" CssClass="lbLabel">Chỉ ra cơ quan tạo ra bản ghi dữ liệu căn cứ. Nếu biết nguồn biên mục, nó sẽ được chỉ ra trong trường con 040$a. Các đơn vị chịu trách nhiệm về bản ghi dữ liệu căn cứ theo chuẩn MARC được xác định bằng mã tại vị trí 39 của trường 008 và bằng mã hoặc tên theo chuẩn MARC trong trường 040. </asp:label></P>
					</TD>
				</TR>
				<TR align="center" class="lbControlBar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" CssClass="lbButton" Text="Nhập(u)" Width="78px"></asp:button>
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
