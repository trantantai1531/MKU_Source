<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WProcInventory" CodeFile="WProcInventory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WProcInventory</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="2">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR>
					<TD>
						<asp:label id="lblHeader" runat="server" CssClass="lbPageTitle" Width="100%">Số liệu xếp giá trong kho </asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblCapLib" runat="server" Font-Bold="True">Thư viện:</asp:label>&nbsp;<asp:label id="lblLib" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapLoc" runat="server" Font-Bold="True">Kho:</asp:label>&nbsp;<asp:label id="lblLoc" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapShelf" runat="server" Font-Bold="True">Giá sách:</asp:label>&nbsp;<asp:label id="lblShelf" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<tr>
								<td width="50%"><asp:label id="lblCapSumItem" runat="server">Số đầu ấn phẩm:</asp:label>&nbsp;
									<asp:label id="lblSumItem" runat="server" Font-Bold="True">0</asp:label></td>
								<td><asp:label id="lblCapCountInUsed" runat="server">Số bản đang cho mượn:</asp:label>&nbsp;
									<asp:hyperlink id="lnkInUsed" runat="server" Font-Bold="True">0</asp:hyperlink></td>
							</tr>
							<TR>
								<TD><asp:label id="lblCapSumCopy" runat="server">Số bản ấn phẩm:</asp:label>&nbsp;
									<asp:label id="lblSumCopy" runat="server" Font-Bold="True">0</asp:label></TD>
								<TD><asp:label id="lblCapCountLocked" runat="server">Số bản đang khóa:</asp:label>&nbsp;
									<asp:hyperlink id="lnkLocked" runat="server" Font-Bold="True">0</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD colSpan="2"><asp:label id="lblCapLastLiquid" runat="server">Lần kiểm kê cuối:</asp:label>&nbsp;
									<asp:label id="lblLastLiquid" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
						</table>
						<asp:hyperlink id="lnkCheckAll" runat="server" CssClass="lbLinkFunction">Chọn tất </asp:hyperlink>&nbsp;
						<asp:hyperlink id="lnkUnCheckAll" runat="server" CssClass="lbLinkFunction">Bỏ tất </asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:image id="imgLocked" runat="server" ImageUrl="../../Images/lock.gif"></asp:image>&nbsp;<asp:label id="lblLocked" runat="server">Đang khoá</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:image id="imgOnhold" runat="server" ImageUrl="../../Images/loan.gif"></asp:image>&nbsp;<asp:label id="lblOnHold" runat="server">Đang cho mượn</asp:label></TD>
				</TR>
				<tr>
					<td><input id="txtLibID" type="hidden" name="txtLibID" runat="server"> &nbsp;&nbsp;<input id="txtLocIDdgr" type="hidden" name="txtLocIDdgr" runat="server">&nbsp;
						<input id="txtAction" type="hidden" name="txtAction" runat="server">&nbsp; <input id="txtReasonID" type="hidden" name="txtReasonID" runat="server" value="0">&nbsp;
						<asp:label id="lblExisting" runat="server" Visible="False">Đăng ký cá biệt đang tồn tại !</asp:label><asp:label id="lblJS" runat="server" Visible="False"></asp:label></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khoá thành công!</asp:ListItem>
				<asp:ListItem Value="3">Mở khoá thành công!</asp:ListItem>
				<asp:ListItem Value="4">Đã ghi nhận việc huỷ bỏ ĐKCB!</asp:ListItem>
				<asp:ListItem Value="5">Bạn không đựơc cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="6">Khoá đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="7">Mở khoá đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="8">Huỷ đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="9">Cập nhật đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="10">Thư viện</asp:ListItem>
				<asp:ListItem Value="11">Kho</asp:ListItem>
				<asp:ListItem Value="12">ĐKCB</asp:ListItem>
			</asp:DropDownList>
			<input id="hidCountID" type="hidden" runat="server" value="0" NAME="hidCountID">
		</form>
	</body>
</HTML>
