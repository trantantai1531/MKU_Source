<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractPOSearch" CodeFile="WContractPOSearch.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WContractPOSearch</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="2" class="lbPageTitle"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle" Width="100%">Tìm kiếm đơn đặt</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblReceiptNo" runat="server">Mã <u>s</u>ố:</asp:label></TD>
					<TD><asp:textbox id="txtReceiptNo" runat="server" style="Z-INDEX: 102"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblPoName" runat="server"><u>T</u>ên đơn đặt:</asp:label></TD>
					<TD><asp:textbox id="txtPoName" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblVendor" runat="server">Nhà <u>c</u>ung cấp:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlVendor" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblValidDateFrom" runat="server"><u>N</u>gày lập đơn: Từ:</asp:label></TD>
					<TD><asp:textbox id="txtValidDateFrom" runat="server"></asp:textbox><asp:hyperlink id="lnkValidDateFrom" runat="server" Width="35px">Lịch</asp:hyperlink>&nbsp;
						<asp:label id="lblValidDateTo" runat="server" Width="40px">Tới:</asp:label><asp:textbox id="txtValidDateTo" runat="server" Width="81px"></asp:textbox><asp:hyperlink id="lnkValidDateTo" runat="server" Width="36px">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblAmountFrom" runat="server"><u>G</u>iá trị đơn đặt: Từ:</asp:label></TD>
					<TD><asp:textbox id="txtAmountFrom" runat="server"></asp:textbox>&nbsp;
						<asp:label id="lblAmountTo" runat="server" Width="40px">Tới:</asp:label><asp:textbox id="txtAmountTo" runat="server" Width="81px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 10px" align="right" width="20%"><asp:label id="lblCurrency" runat="server">Đơn <u>v</u>ị tiền tệ:</asp:label></TD>
					<TD style="HEIGHT: 10px"><asp:dropdownlist id="ddlCurrency" runat="server" Width="152px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblBudget" runat="server">Quỹ chi t<u>r</u>ả:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlBudget" runat="server" Width="152px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblTitle" runat="server">Nhan đề ấn <u>p</u>hẩm:</asp:label></TD>
					<TD><asp:textbox id="txtTitle" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblAuthor" runat="server">Tác <u>g</u>iả:</asp:label></TD>
					<TD><asp:textbox id="txtAuthor" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblPublisher" runat="server">Nhà <u>x</u>uất bản:</asp:label></TD>
					<TD><asp:textbox id="txtPublisher" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblPubYear" runat="server">Nă<u>m</u> xuất bản:</asp:label></TD>
					<TD><asp:textbox id="txtPubYear" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblISBN" runat="server"><u>I</u>SBN:</asp:label></TD>
					<TD><asp:textbox id="txtISBN" runat="server"></asp:textbox>&nbsp;<INPUT id="txtFilterOn" type="hidden" value="1" runat="server" NAME="txtFilterOn"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:button id="btnFilter" runat="server" CssClass="lbButton" Width="84px" Text="Tìm (t)"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" CssClass="lbButton" Width="84px" Text="Đặt lại (l)"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dung tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="4">Ngoài phạm vi kiểm tra</asp:ListItem>
				<asp:ListItem Value="5">Sai kiểu dữ liệu (số)</asp:ListItem>
				<asp:ListItem Value="6">Dữ liệu không phải kiểu ngày tháng</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
