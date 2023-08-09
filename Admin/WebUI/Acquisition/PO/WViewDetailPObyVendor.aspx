<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WViewDetailPObyVendor" CodeFile="WViewDetailPObyVendor.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Danh sách hợp đồng đã thực hiện</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMain" cellSpacing="1" cellPadding="3" border="0" width="100%">
				<tr Class="lbPageTitle">
					<td width="100%">
						<asp:Label ID="lblMainTitle" Runat="server" CssClass="main-group-form" Width="100%"></asp:Label></td>
				</tr>
				<TR>
					<TD width="100%" height="100%">
						<asp:table id="tblPODetail" runat="server" GridLines="Both" BorderWidth="1px" CellPadding="3"
							CellSpacing="0" BorderColor="#400000" width="100%">
							<asp:TableRow ID="Header" CssClass="lbGridHeader">
								<asp:TableCell Text="Tên hợp đồng" ID="POName"></asp:TableCell>
								<asp:TableCell Text="Giá trị (VND)" ID="TotalAmount" Width="10%"></asp:TableCell>
								<asp:TableCell Text="Sắp triển khai" ID="PrepareDeploy" Width="8%"></asp:TableCell>
								<asp:TableCell Text="Đang triển khai" ID="Deploying" Width="9%"></asp:TableCell>
								<asp:TableCell Text="Hoàn thành đúng hạn" ID="AccomplishOnTime" Width="9%"></asp:TableCell>
								<asp:TableCell Text="Hoàn thành không đúng hạn" ID="Accomplish" Width="13%"></asp:TableCell>
								<asp:TableCell Text="Khiếu nại" ID="Appeal" Width="6%"></asp:TableCell>
								<asp:TableCell Text="Huỷ bỏ" ID="Dispose" Width="6%"></asp:TableCell>
								<asp:TableCell Text="Giảm giá(%)" ID="DisCount" Width="8%"></asp:TableCell>
								<asp:TableCell Text="Tiền nợ" ID="Debt" Width="11%"></asp:TableCell>
							</asp:TableRow>
						</asp:table>
					</TD>
				</TR>
				<TR>
					<TD width="100%" height="100%">
						<TABLE cellSpacing="0" cellPadding="1" border="0" width="100%">
							<TR>
								<TD colSpan="2">
									<asp:label id="lblVendorInformation" runat="server" Width="100%" CssClass="lbSubTitle">Thông tin về nhà cung cấp</asp:label></TD>
							</TR>
							<TR>
								<TD align="right" width="20%">
									<asp:label id="lblVName" runat="server" Width="120px">Tên: </asp:label></TD>
								<TD>&nbsp;
									<asp:label id="lblNameV" runat="server" Width="200px"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:label id="lblVAddress" runat="server" Width="120px">Địa chỉ: </asp:label></TD>
								<TD>&nbsp;
									<asp:label id="lblAddressV" runat="server" Width="200px"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:label id="lblVTelephone" runat="server" Width="120px">Số điện thoại: </asp:label></TD>
								<TD>&nbsp;
									<asp:label id="lblTelephoneV" runat="server" Width="200px"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:label id="lblVFax" runat="server" Width="120px">Fax: </asp:label></TD>
								<TD>&nbsp;
									<asp:label id="lblFaxV" runat="server" Width="200px"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:label id="lblVEmail" runat="server" Width="120px">Email: </asp:label></TD>
								<TD>&nbsp;
									<asp:label id="lblEmailV" runat="server" Width="200px"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:label id="lblVContactPerson" runat="server" Width="120px">Người liên hệ: </asp:label></TD>
								<TD>&nbsp;
									<asp:label id="lblContactPersonV" runat="server" Width="200px"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:label id="lblVNote" runat="server" Width="120px">Ghi chú: </asp:label></TD>
								<TD>&nbsp;
									<asp:label id="lblNoteV" runat="server" Width="200px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="66px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Visible="False" Width="0px" Runat="server">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết</asp:ListItem>
				<asp:ListItem Value="2">Tổng số: </asp:ListItem>
				<asp:ListItem Value="3">Danh sách các hợp đồng của thư viện với nhà cung cấp: </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
