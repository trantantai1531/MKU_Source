<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField006ID5" CodeFile="WField006ID5.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField006ID5</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(5);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" Class="lbPageTitle">
					<TD class="lbpageTitle" vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 006--COMPUTER FILES</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="30%">
						<asp:label id="lblLabel2" runat="server">00 - <u>T</u>ype of 006 code</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="120px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="m">Computer file</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel3" runat="server">01-04 - Không định nghĩa, bao gồm ký tự trắng ( # ) hoặc ( | )</asp:label></TD>
					<td>
						<asp:textbox id="txtField2" runat="server" Width="120px" Enabled="False">####</asp:textbox></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server" Width="392px">05 - K<u>h</u>án/thính/độc giả nhắm tới</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField3" runat="server" Width="256" Height="22">
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
						</asp:dropdownlist>
					</TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel5" runat="server">06-08 - Không định nghĩa, bao gồm ký tự trắng ( # ) hoặc ( | )</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField4" runat="server" Width="120px" Enabled="False">###</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 09 - Kiểu tệp <u>m</u>áy tính</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField5" runat="server" Width="256" Height="22">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label2" runat="server"> 10 - Không định nghĩa, bao gồm ký tự trắng ( # ) hoặc ( | )</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField6" runat="server" Width="120px" Enabled="False">#</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 11 - Xuất bản phẩm của chính <u>p</u>hủ</asp:label></TD>
					<TD vAlign="top"><asp:dropdownlist id="ddlField7" runat="server">
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
						<asp:label id="Label4" runat="server"> 12-17 - Không định nghĩa, bao gồm ký tự trắng ( # ) hoặc ( | )</asp:label></TD>
					<td>
						<asp:textbox id="txtField8" runat="server" Width="120px" Enabled="False">######</asp:textbox></td>
				</TR>
				<TR vAlign="top" class="lbControlbar">
					<TD vAlign="top" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="83px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Ðặt lại(r)" Width="75px"></asp:button>&nbsp;
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="63px"></asp:button>
						&nbsp;<asp:Button ID="btnClose" Runat="server" Text="Đóng(c)" Width="63px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
