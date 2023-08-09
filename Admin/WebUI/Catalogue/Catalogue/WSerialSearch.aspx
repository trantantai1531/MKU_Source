<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WSerialSearch" CodeFile="WSerialSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tìm kiếm ấn phẩm định kỳ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="document.forms[0].txbTitle.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="1" width="100%" border="0">
				<TR class="lbPageTitle" align="center">
					<TD colspan="4">
						<asp:Label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Tìm ấn phẩm định kỳ</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblTitle" runat="server"><U>N</U>han đề:</asp:Label></TD>
					<TD colspan="3">
						<asp:TextBox id="txbTitle" runat="server" Width="280px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblFromDate" runat="server">Ngày phát hành <U>t</U>ừ:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txbFromDate" runat="server" Width="104px"></asp:TextBox>&nbsp;<asp:HyperLink id="lnkFromDate" runat="server">Lịch</asp:HyperLink></TD>
					<TD align="right">
						<asp:Label id="lblToDate" runat="server">đế<U>n</U>:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txbToDate" runat="server" Width="104px"></asp:TextBox>&nbsp;<asp:HyperLink id="lnkToDate" runat="server">Lịch</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblIssue" runat="server"><U>S</U>ố:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txbIssue" runat="server" Width="104px"></asp:TextBox></TD>
					<TD align="right">
						<asp:Label id="lblVolume" runat="server"><U>T</U>ập:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txbVolume" runat="server" Width="104px"></asp:TextBox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD></TD>
					<TD colspan="3">
						<asp:Button id="btnSearch" runat="server" Width="70px" Text="Tìm(s)"></asp:Button>
						<asp:Button id="btnReset" runat="server" Width="90px" Text="Đặt lại(r)"></asp:Button></TD>
				</TR>
			</TABLE>
			<table width="100%" border="0" cellpadding="2" cellspacing="1">
				<TR>
					<TD align="center">
						<asp:Label id="lblCapResult" runat="server" Visible="False">Tìm thấy:</asp:Label>
						<asp:Label id="lblResult" runat="server" Visible="False" Font-Bold="True" ForeColor="Maroon"></asp:Label>
						<asp:Label id="lblCap" runat="server" Visible="False">bản ghi biên mục</asp:Label></TD>
				</TR>
				<tr>
					<td align="center">
						<asp:Table id="tblResult" runat="server" Width="100%" CellPadding="2" CellSpacing="1" BorderWidth="0"></asp:Table></td>
				</tr>
			</table>
			<input type="hidden" id="hidFieldCode" runat="server" NAME="hidFieldCode">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="3">Chọn</asp:ListItem>
				<asp:ListItem Value="4">Thông tin biên mục</asp:ListItem>
				<asp:ListItem Value="5">Khuôn dạng dữ liệu không hợp lệ</asp:ListItem>
				<asp:ListItem Value="6">Số</asp:ListItem>
				<asp:ListItem Value="7">Không có bản ghi nào thoả mãn điều kiện tìm kiếm!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
