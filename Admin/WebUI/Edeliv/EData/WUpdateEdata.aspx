<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WUpdateEdata" CodeFile="WUpdateEdata.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cập nhật thông tin ấn phẩm điện tử có thu phí</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colspan="2">
						<asp:Label Runat="server" ID="lblTitle" CssClass="lbPageTitle">Cập nhật thông tin ấn phẩm điện tử có thu phí</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right" width="30%">
						<asp:Label id="lblFile" Runat="server">Tên tệp:</asp:Label></TD>
					<TD>
						<asp:Label id="lblFileName" runat="server" Font-Bold="True"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblPrice" Runat="server"><u>G</u>iá tiền:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPrice" runat="server" Width="120px"></asp:TextBox>
						<asp:DropDownList id="ddlCurrency" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblNote" Runat="server">Ghi <u>c</u>hú:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtNote" runat="server" Width="440px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblFileFormat" Runat="server"><u>K</u>iểu dữ liệu:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtFileFormat" runat="server" Width="192px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblPagination" Runat="server"><u>S</u>ố trang:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtPagination" runat="server" Width="72px"></asp:TextBox>&nbsp;
						<asp:Label id="lblPage" Runat="server">trang</asp:Label></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="right">
					</TD>
					<TD>
						<asp:Button id="btnUpdate" runat="server" Text="Cập nhật(u)" Width="88px"></asp:Button>
						<asp:Button id="btnReset" runat="server" Text="Đặt lại(r)" Width="72px"></asp:Button>
						<asp:Button id="btnClose" runat="server" Text="Đóng(c)" Width="64px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0px" Height="0px" Visible="False">
				<asp:ListItem Value="0">Cập nhật thành công!</asp:ListItem>
				<asp:ListItem Value="1">Bạn phải nhập dữ liệu kiểu số!</asp:ListItem>
				<asp:ListItem Value="2">Trường [giá tiền] là bắt buộc!</asp:ListItem>
				<asp:ListItem Value="3">File không tồn tại hoặc chưa lựa chọn file!</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="5">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
			</asp:dropdownlist>
		</form>
	</body>
</HTML>
