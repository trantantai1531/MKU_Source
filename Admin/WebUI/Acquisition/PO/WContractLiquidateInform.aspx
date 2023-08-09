<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractLiquidateInform" CodeFile="WContractLiquidateInform.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Khai báo chi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="2" class="lbPageTitle">
						<asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle"></asp:label></TD>
				</TR>
				<tr>
					<td colspan="2" class="lbFunctionTitle" align="center">
						<asp:Label ID="lblForAmount" Runat="server" Visible="False" ForeColor="Maroon" Font-Bold="True"></asp:Label>
					</td>
				</tr>
				<TR>
					<TD align="right"><asp:label id="lblAmount" runat="server"><u>S</u>ố luợng chưa thanh toán:</asp:label></TD>
					<TD><asp:textbox id="txtAmount" runat="server"></asp:textbox>&nbsp;
						<asp:label id="lblCurrency" runat="server" CssClass="lbLabel">Cur</asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblRealAmount" runat="server">K<u>h</u>oản tiền:</asp:label></TD>
					<TD>
						<asp:textbox id="txtRealAmount" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblRate" runat="server"><u>T</u>ỷ giá:</asp:label></TD>
					<TD><asp:textbox id="txtRate" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblTransactionDate" runat="server">N<u>g</u>ày nhập:</asp:label></TD>
					<TD><asp:textbox id="txtTransactionDate" runat="server"></asp:textbox>
						<asp:hyperlink id="lnkTransactionDate" runat="server">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblReason" runat="server"><u>L</u>ý do:</asp:label></TD>
					<TD>
						<asp:textbox id="txtReason" runat="server" Rows="3" TextMode="MultiLine" Width="180px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:radiobutton id="optReal" runat="server" Width="88px" Text="<U>T</U>hực chi" GroupName="Commited"></asp:radiobutton>&nbsp;
						<asp:radiobutton id="optPlan" runat="server" Width="80px" Text="<U>D</U>ự chi" Checked="True" GroupName="Commited"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:button id="btnUpdate" runat="server" Text="Khai báo(k)" Width="93px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="75px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="63px"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dung tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Dữ liệu không phải kiểu ngày tháng</asp:ListItem>
				<asp:ListItem Value="4">Dữ liệu phải là kiểu số</asp:ListItem>
				<asp:ListItem Value="5">từ </asp:ListItem>
				<asp:ListItem Value="6"> sang </asp:ListItem>
				<asp:ListItem Value="7">Khai báo chi</asp:ListItem>
				<asp:ListItem Value="8">Dự chi vuợt quá tổng tiền cho phép</asp:ListItem>
				<asp:ListItem Value="9">Khai báo chi: Quỹ ID:</asp:ListItem>
				<asp:ListItem Value="10">Bạn chưa nhập đủ thông tin cần thiết</asp:ListItem>
				<asp:ListItem Value="11">Số tiền trong quỹ đã hết</asp:ListItem>
				<asp:ListItem Value="12">Số tiền lý thuyết :</asp:ListItem>
				<asp:ListItem Value="13">. Số tiền thực có :</asp:ListItem>
			</asp:DropDownList>
			<INPUT id="hidContractID" type="hidden" name="hidContractID" runat="server"> <INPUT id="hidBudgetID" type="hidden" name="hidBudgetID" runat="server">
			<INPUT id="hidCurrency" type="hidden" runat="server" NAME="hidCurrency"> <INPUT id="hidRateTemp" type="hidden" runat="server" NAME="hidRateTemp">
		</form>
	</body>
</HTML>
