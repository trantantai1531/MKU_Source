<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WCatalogue" CodeFile="WCatalogue.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>
			<%=ddlLabel.Items(14).text%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body onkeypress="microsoftKeyPress()" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<input id="hid01" type="hidden" name="hid01" runat="server"> <input id="hid02" type="hidden" name="hid02" runat="server">
			<input id="hid03" type="hidden" name="hid03" runat="server"> <input id="hid04" type="hidden" name="hid04" runat="server">
			<input id="hid05" type="hidden" name="hid05" runat="server"> <input id="hid06" type="hidden" name="hid06" runat="server">
			<input id="hid07" type="hidden" name="hid07" runat="server"> <input id="hid08" type="hidden" name="hid08" runat="server">
			<input id="hid09" type="hidden" name="hid09" runat="server"> <input id="hid10" type="hidden" name="hid10" runat="server">
			<input id="hid11" type="hidden" name="hid11" runat="server"> <input id="hid12" type="hidden" name="hid12" runat="server">
			<input id="hid13" type="hidden" name="hid13" runat="server"> <input id="hid14" type="hidden" name="hid14" runat="server">
			<input id="hid15" type="hidden" name="hid15" runat="server"> <input id="hidIsLoad" type="hidden" value="0" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="0" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD>
						<asp:Label Runat="server" ID="lblTitle" CssClass="lbPageTitle">Biên mục ấn phẩm điện tử</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:table id="tblDetail" Runat="server" BorderWidth="0" CellSpacing="0" CellPadding="1"></asp:table></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center"><asp:button id="btnUpdate" runat="server" Height="24px" Text="Cập nhật(u)" Width="90px"></asp:button>&nbsp;<asp:button id="btnDelete" runat="server" Height="24px" Text="Xoá(d)" Width="65px"></asp:button>&nbsp;<asp:button id="btnClose" runat="server" Height="24px" Text="Đóng(c)" Width="65px"></asp:button>&nbsp;
						<asp:label id="lblJS" runat="server" Width="0"></asp:label></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="2">Chuyển về bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="3">Chuyển về bản ghi trước</asp:ListItem>
				<asp:ListItem Value="4">Chuyển đến bản ghi tiếp</asp:ListItem>
				<asp:ListItem Value="5">Chuyển đến bản ghi cuối</asp:ListItem>
				<asp:ListItem Value="6">Tạo bản ghi mới</asp:ListItem>
				<asp:ListItem Value="7">Xoá bản ghi hiện hành</asp:ListItem>
				<asp:ListItem Value="8">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="9">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="10">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="11">Cập nhật thành công!</asp:ListItem>
				<asp:ListItem Value="12">Bạn chưa nhập thông tin biên mục nào !</asp:ListItem>
				<asp:ListItem Value="13">Bạn có chắc chắn xoá thông tin biên mục không?</asp:ListItem>
				<asp:ListItem Value="14">Biên mục ấn phẩm điện tử</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
