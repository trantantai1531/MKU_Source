<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractToBudget" CodeFile="WContractToBudget.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Hoàn quỹ</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE width="100%" cellSpacing="1" cellPadding="0" border="0">
				<TR>
					<TD align="center" colspan="2" Class="lbPageTitle">
						<asp:Label id="lblMainTitle" CssClass="main-group-form" runat="server">Hoàn quỹ</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:Label id="lblBudget" runat="server">Q<u>u</u>ỹ: </asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlBudget" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:Label id="lblAmount" runat="server" ><u>S</u>ố tiền:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtAmount" runat="server" Width="200px"></asp:TextBox>
						<asp:DropDownList id="ddlCurrency" runat="server" Width="53px"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:Label id="lblRate" runat="server"><u>T</u>ỷ giá:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtRate" runat="server" Width="200px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:Label id="lblInputer" runat="server" Width="50px">Người n<u>h</u>ập:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtInputer" runat="server" Enabled="False" Width="200px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:Label id="lblTransactionDate" runat="server">N<u>g</u>ày:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtTransactionDate" runat="server" Width="200px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lnkTransactionDate" runat="server" Width="39px">Lịch</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:Label id="lblReason" runat="server">Lý <u>d</u>o:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtReason" runat="server" BorderStyle="Solid"  BorderWidth="1px"  TextMode="MultiLine" Width="280" Height="60"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"></TD>
					<TD>
						<asp:Button id="btnUpdate" runat="server" Text="Cập nhật(u)" Width="92px"></asp:Button>
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)" Width="62px"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dung tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Dữ liệu không phải kiểu ngày tháng</asp:ListItem>
				<asp:ListItem Value="4">Dữ liệu phải là kiểu số</asp:ListItem>
				<asp:ListItem Value="5">Hoàn quỹ</asp:ListItem>
			</asp:DropDownList>
			<INPUT type="hidden" id="hidContractID" runat="server" NAME="txtContractID" value="0">
		</form>
	</body>
</HTML>
