<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WLeaderHelpAuthority" CodeFile="WLeaderHelpAuthority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Trợ giúp nhập Leader cho dữ liệu căn cứ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="center" colSpan="2"><asp:label id="lblPageTitle" style="Z-INDEX: 101" runat="server" CssClass="lbPageTitle">Leader -- Chỉ dẫn đầu biểu ghi</asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField1" runat="server">00-04 - Độ dài biểu ghi</asp:label></TD>
					<TD align="left"><asp:textbox id="txtField1" onfocus="this.blur()" runat="server" Text="00000" MaxLength="5" Enabled="False"></asp:textbox></TD>
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
						
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField3" runat="server">06 - <U>L</U>oại biểu ghi</asp:label></TD>
					<TD align="left">
						<asp:dropdownlist id="ddlField3" runat="server" Width="128px">
							<asp:ListItem Value="z">Dữ liệu căn cứ</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField4" runat="server">07-08 <U>C</U>ác vị trí ký tự không định nghĩa</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField4" onfocus="this.blur()" runat="server" Text="" MaxLength="1" Width="88px">##</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField6" runat="server">09 - Bộ mã <U>k</U>ý tự sử dụng</asp:label></TD>
					<TD align="left">
						<asp:dropdownlist id="ddlField5" runat="server">
							<asp:ListItem Value=" ">MARC-8</asp:ListItem>
							<asp:ListItem Value="b">UCS/Unicode</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField7" runat="server">10 - Số lượng chỉ thị</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField6" onfocus="this.blur()" runat="server" Text="2" MaxLength="1" Enabled="False">2</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField8" runat="server">11 - Độ dài mã trường con</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField7" onfocus="this.blur()" runat="server" Text="2" MaxLength="1" Enabled="False">2</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField9" runat="server">12-16 - Địa chỉ gốc phần dữ liệu</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField8" onfocus="this.blur()" runat="server" Text="00000" MaxLength="5" Enabled="False">00000</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField10" runat="server">17 - Cấ<U>p</U> mã hóa</asp:label></TD>
					<TD align="left">
						<asp:dropdownlist id="ddlField9" runat="server">
							<asp:ListItem Value="n">Bản ghi dữ liệu căn cứ hoàn chỉnh</asp:ListItem>
							<asp:ListItem Value="o">Bản ghi dữ liệu căn cứ không hoàn chỉnh</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField11" runat="server">18-19- Các vị trí ký tự <U>k</U>hông định nghĩa</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField10" onfocus="this.blur()" runat="server" Text="" MaxLength="1" Width="88px">## </asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField13" runat="server">20 - Độ dài của độ dài trường</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField11" onfocus="this.blur()" runat="server" Text="4" MaxLength="1" Enabled="False">4</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField14" runat="server">21 - Độ dài của vị trí ký tự bắt đầu</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField12" onfocus="this.blur()" runat="server" Text="5" MaxLength="1" Enabled="False">5</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField15" runat="server">22 - Độ dài của thông tin ứng dụng tự xác định</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField13" onfocus="this.blur()" runat="server" Text="0" MaxLength="1" Enabled="False">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblField16" runat="server">23 - Dự trữ (không xác định)</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtField14" onfocus="this.blur()" runat="server" Text="0" MaxLength="1" Enabled="False">0</asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center" colSpan="2">
						<asp:button id="btnUpdate" runat="server" Text="Nhập(u)" Width="70px"></asp:button>
						<asp:button id="btnReset" runat="server" Text="Huỷ(r)" Width="70px"></asp:button>
						<asp:button id="btnPreview" runat="server" Text="Xem(v)" Width="70px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="78px"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
