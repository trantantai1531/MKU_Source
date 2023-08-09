<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WLeaderHelp" CodeFile="WLeaderHelp.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Trợ giúp nhập Leader cho dữ liệu thư mục</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="center" colSpan="2">
						<asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Leader -- Chỉ dẫn đầu biểu ghi</asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField1" runat="server">00-04 - Độ dài biểu ghi</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField1" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="5"
							Text="00000"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField2" runat="server">05 - <U>T</U>rạng thái biểu ghi</asp:label></TD>
					<TD align="left">
						<asp:dropdownlist id="ddlField2" runat="server">
							<asp:ListItem Value="a">Tăng mức mã thông tin</asp:ListItem>
							<asp:ListItem Value="c">Sửa lỗi hoặc duyệt lại</asp:ListItem>
							<asp:ListItem Value="d">Xóa</asp:ListItem>
							<asp:ListItem Value="n">Mới</asp:ListItem>
							<asp:ListItem Value="p">Tăng mức mã thông tin so với trước khi xuất bản</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField3" runat="server">06 - <U>L</U>oại biểu ghi</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlField3" runat="server">
							<asp:ListItem Value="a">Tư liệu văn bản</asp:ListItem>
							<asp:ListItem Value="c">Bản nhạc in</asp:ListItem>
							<asp:ListItem Value="d">Bản nhạc viết tay</asp:ListItem>
							<asp:ListItem Value="e">Tư liệu bản đồ in</asp:ListItem>
							<asp:ListItem Value="f">Tư liệu bản đồ vẽ tay</asp:ListItem>
							<asp:ListItem Value="g">Phương tiện chiếu</asp:ListItem>
							<asp:ListItem Value="i">Bản thu âm không phải âm nhạc</asp:ListItem>
							<asp:ListItem Value="j">Bản thu âm nhạc</asp:ListItem>
							<asp:ListItem Value="k">Đồ hoạ hai chiều không chiếu được</asp:ListItem>
							<asp:ListItem Value="m">Tệp máy tính</asp:ListItem>
							<asp:ListItem Value="o">Bộ dụng cụ</asp:ListItem>
							<asp:ListItem Value="p">Vật liệu hỗn hợp</asp:ListItem>
							<asp:ListItem Value="r">Vật thể ba chiều tự nhiên hoặc nhân tạo</asp:ListItem>
							<asp:ListItem Value="t">Tư liệu văn bản viết tay</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField4" runat="server">07 - <U>C</U>ấp thư mục</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlField4" runat="server">
							<asp:ListItem Value="a">Phần cấu thành của ấn phẩm đơn bản</asp:ListItem>
							<asp:ListItem Value="b">Phần cấu thánh của ấn phẩm định kỳ</asp:ListItem>
							<asp:ListItem Value="c">Cấp sưu tập (Collection)</asp:ListItem>
							<asp:ListItem Value="d">Cấp phân tích</asp:ListItem>
							<asp:ListItem Value="m">Cấp chuyên khảo (Monograph/item)</asp:ListItem>
							<asp:ListItem Value="s">Cấp xuất bản phẩm nhiều kỳ</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField5" runat="server">08 - <U>D</U>ạng thông tin kiểm soát</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlField5" runat="server">
							<asp:ListItem Value=" ">Không xác định</asp:ListItem>
							<asp:ListItem Value="a">Archival control</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField6" runat="server">09 - <U>B</U>ộ mã ký tự sử dụng</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlField6" runat="server">
							<asp:ListItem Value=" ">MARC-8</asp:ListItem>
							<asp:ListItem Value="a">UCS/Unicode</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField7" runat="server">10 - Số lượng chỉ thị</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField7" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="1"
							Text="2"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField8" runat="server">11 - Độ dài mã trường con</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField8" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="1"
							Text="2"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField9" runat="server">12-16 - Địa chỉ gôc phần dữ liệu</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField9" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="5"
							Text="00000"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField10" runat="server">17 - Cấp <U>m</U>ã hóa</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlField10" runat="server">
							<asp:ListItem Value=" ">Cấp đầy đủ</asp:ListItem>
							<asp:ListItem Value="1">Cấp đầy đủ, tư liệu biên mục không được nghiên cứu thực</asp:ListItem>
							<asp:ListItem Value="2">Dưới cấp đầy đủ, tư liệu biên mục không được nghiên cứu thực</asp:ListItem>
							<asp:ListItem Value="3">Cấp viết tắt</asp:ListItem>
							<asp:ListItem Value="4">Cấp cốt yếu</asp:ListItem>
							<asp:ListItem Value="5">Một phần</asp:ListItem>
							<asp:ListItem Value="7">Cấp tối thiểu</asp:ListItem>
							<asp:ListItem Value="8">Cấp mô tả tiền phát hành</asp:ListItem>
							<asp:ListItem Value="u">Không rõ</asp:ListItem>
							<asp:ListItem Value="z">Không áp dụng</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField11" runat="server">18 - <U>Q</U>ui tắc biên mục áp dụng</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlField11" runat="server">
							<asp:ListItem Value=" ">Không theo ISBD</asp:ListItem>
							<asp:ListItem Value="a">AACR 2</asp:ListItem>
							<asp:ListItem Value="i">ISBD</asp:ListItem>
							<asp:ListItem Value="p">Theo ISBD một phần (BK)  [Bỏ]</asp:ListItem>
							<asp:ListItem Value="r">Provisional (VM MP MU) [Bỏ]</asp:ListItem>
							<asp:ListItem Value="u">Không rõ</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField12" runat="server">19 - <U>Y</U>êu cầu về biểu ghi liên kết</asp:label></TD>
					<TD align="left"><asp:dropdownlist id="ddlField12" runat="server">
							<asp:ListItem Value=" ">Không đòi hỏi biểu ghi liên kết</asp:ListItem>
							<asp:ListItem Value="r">Có đòi hỏi biểu ghi liên kết</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField13" runat="server">20 - Độ dài của độ dài trường</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField13" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="1"
							Text="4"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField14" runat="server">21 - Độ dài của vị trí ký tự bắt đầu</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField14" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="1"
							Text="5"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField15" runat="server">22 - Độ dài của thông tin ứng dụng tự xác định</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField15" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="1"
							Text="0"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField16" runat="server">23 - Dự trữ (không xác định)</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField16" onfocus="this.blur()" runat="server" Enabled="False" MaxLength="1"
							Text="0"></asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="70px"></asp:button>
						<asp:Button id="btnReset" runat="server" Text="Huỷ(r)" Width="64px"></asp:Button>
						<asp:Button id="btnPreview" runat="server" Text="Xem(v)" Width="70px"></asp:Button>
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" Width="78px"></asp:Button></TD>
				</TR>
			</TABLE>
			<input type="hidden" name="hid" id="hid" value="0" runat="server">
		</form>
	</body>
</HTML>
