<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WField006ID9" CodeFile="WField006ID9.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WField006ID9</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ResValue(9);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" width="100%" border="0">
				<TR vAlign="top" class="lbpageTitle">
					<TD vAlign="top" colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" Width="100%"> 006--VISUAL MATERIALS</asp:label></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top" width="45%">
						<asp:label id="lblLabel2" runat="server"> 00 - <u>T</u>ype of 006 code</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField1" runat="server" Width="200px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="g">Projected medium</asp:ListItem>
							<asp:ListItem Value="k">Two-dimensional nonprojectable graphic</asp:ListItem>
							<asp:ListItem Value="o">Kit</asp:ListItem>
							<asp:ListItem Value="r">Three-dimensional artifact or naturally occurring object</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label5" runat="server"> 01-03 - Trường độ của <u>p</u>him hoặc video</asp:label></TD>
					<td>
						Trường độ (001-999):
						<asp:textbox id="txtField2" runat="server" CssClass="lbTextBox" Width="80"></asp:textbox>&nbsp;Khác:<asp:dropdownlist id="ddlTemp2" runat="server" Width="232px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="---">---: Không rõ</asp:ListItem>
							<asp:ListItem Value="000">000: Trường độ vượt quá 3 chữ số</asp:ListItem>
							<asp:ListItem Value="nnn">nnn: Không áp dụng</asp:ListItem>
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel3" runat="server"> 04 - Không định nghĩa</asp:label></TD>
					<td>
						<asp:textbox id="txtField3" runat="server" Width="120px" Enabled="False">#</asp:textbox></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="lblLabel4" runat="server"> 05 - Đối tượng độc giả/khán giả nhắm tớ<u>i</u></asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField4" runat="server" Width="216px">
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
						<asp:label id="lblLabel5" runat="server"> 06-10 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField5" runat="server" Width="120px" Enabled="False">#####</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label1" runat="server"> 11 - Xuất bản phẩm của <u>c</u>hính phủ</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField6" runat="server" Width="296px">
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
						<asp:label id="Label2" runat="server"> 12 - <u>D</u>ạng của tư liệu</asp:label></asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField7" runat="server" Width="296px">
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
					<TD vAlign="top">
						<asp:label id="Label3" runat="server"> 13-15 - Không định nghĩa</asp:label></TD>
					<TD vAlign="top">
						<asp:textbox id="txtField8" runat="server" Width="120px" Enabled="False">###</asp:textbox></TD>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label4" runat="server"> 16 - Kiể<u>u</u> tư liệu nghe nhìn</asp:label></TD>
					<td>
						<asp:dropdownlist id="ddlField9" runat="server" Width="216px">
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
						</asp:dropdownlist></td>
				</TR>
				<TR onmouseover="javascript: mOvr(this,'#FFCC99');" onfocus="javascript: mOvr(this,'#FFCC99');"
					onmouseout="javascript: mOut(this,'#f0f3f4');" vAlign="top">
					<TD vAlign="top">
						<asp:label id="Label6" runat="server"> 17 - Kỹ th<u>u</u>ật</asp:label></TD>
					<TD vAlign="top">
						<asp:dropdownlist id="ddlField10" runat="server" Width="216px">
							<asp:ListItem Value=" "></asp:ListItem>
							<asp:ListItem Value="a">a: Hoạt hình</asp:ListItem>
							<asp:ListItem Value="c">c: Hoạt hình và cảnh thật</asp:ListItem>
							<asp:ListItem Value="l">l: Cảnh thật</asp:ListItem>
							<asp:ListItem Value="n">n: Không áp dụng</asp:ListItem>
							<asp:ListItem Value="u">u: Không rõ</asp:ListItem>
							<asp:ListItem Value="z">z: Kỹ thuật khác</asp:ListItem>
							<asp:ListItem Value="|">|: Không nhập liệu</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR vAlign="top" class="lbControlBar">
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
