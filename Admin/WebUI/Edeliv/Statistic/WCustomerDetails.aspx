<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WCustomerDetails" CodeFile="WCustomerDetails.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCustomerDetails</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr class="lbGroupTitle">
					<td colspan="4">
						<asp:Label Runat="server" ID="lblTitle" CssClass="lbGroupTitle"></asp:Label>
					</td>
				</tr>
				<tr class="lbSubFormTitle">
					<td colspan="2">
						<asp:label id="lblAcountInformation" CssClass="lbSubFormTitle" Runat="server">Thông tin tài khoản:</asp:label>
					</td>
					<td colspan="2">
						<asp:label id="lblShippingInformation" CssClass="lbSubFormTitle" Runat="server">Địa chỉ giao nhận</asp:label>
					</td>
				</tr>
				<TR>
					<TD width="20%" align="right">
						<asp:label id="lblFullName" Runat="server">Tên chủ tài khoản:</asp:label></TD>
					<TD width="30%">
						<asp:label id="lblField1" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD width="20%" align="right">
						<asp:label id="lblWorkPlace" Runat="server">Tên đơn vị:</asp:label></TD>
					<TD width="30%">
						<asp:label id="lblField9" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblContactName" Runat="server">Tên người liên hệ:</asp:label></TD>
					<TD>
						<asp:label id="lblField2" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD align="right">
						<asp:label id="lblDepartment" Runat="server">Phòng ban:</asp:label></TD>
					<TD>
						<asp:label id="lblField10" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblEmailAddress" Runat="server">Địa chỉ email:</asp:label></TD>
					<TD>
						<asp:label id="lblField3" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD align="right">
						<asp:label id="lblAddress" Runat="server">Đường phố:</asp:label></TD>
					<TD>
						<asp:label id="lblField11" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblPhone" Runat="server">Điện thoại:</asp:label></TD>
					<TD>
						<asp:label id="lblField4" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD align="right">
						<asp:label id="lblBox" Runat="server">Hộp thư:</asp:label></TD>
					<TD>
						<asp:label id="lblField12" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblFax" Runat="server">Fax:</asp:label></TD>
					<TD>
						<asp:label id="lblField5" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD align="right">
						<asp:label id="lblCity" Runat="server">Thành phố:</asp:label></TD>
					<TD>
						<asp:label id="lblField13" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblNote" Runat="server">Ghi chú:</asp:label></TD>
					<TD>
						<asp:label id="lblField6" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD align="right">
						<asp:label id="lblArea" Runat="server">Khu vực:</asp:label></TD>
					<TD>
						<asp:label id="lblField14" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblEdelivUserName" Runat="server">Mã tài khoản:</asp:label></TD>
					<TD>
						<asp:label id="lblField7" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD align="right">
						<asp:label id="lblCountry" Runat="server">Quốc gia:</asp:label></TD>
					<TD>
						<asp:label id="lblField15" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblDebt" Runat="server">Tiền nợ:</asp:label></TD>
					<TD>
						<asp:label id="lblField8" Runat="server" Font-Bold="True"></asp:label></TD>
					<TD align="right">
						<asp:label id="lblPostalCode" Runat="server">Mã bưu điện (ZIP):</asp:label></TD>
					<TD>
						<asp:label id="lblField16" Runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<asp:Button id="btnClose" runat="server" Text="Đóng (c)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
			<asp:Label Runat="server" ID="lblLabel1" Visible="False">Bạn không được cấp quyền khai thác tính năng này</asp:Label>
			<asp:Label Runat="server" ID="lblLabel2" Visible="False">Mã lỗi</asp:Label>
			<asp:Label Runat="server" ID="lblLabel3" Visible="False">Chi tiết lỗi</asp:Label>
		</form>
	</body>
</HTML>
