<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WShowInforMoney" CodeFile="WShowInforMoney.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WShowInforMoney</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" colSpan="2"><asp:label id="lblHeader" runat="server" CssClass="lbPageTitle">Thông tin chí phí mua báo, tạp chí trong 1 năm</asp:label></TD>
				</TR>
				<TR>
					<TD class="lbGroupTitle" colSpan="2"><asp:label id="lblHeader4Phase" runat="server" CssClass="lbGroupTitle">Thông tin chi phí trong 4 quý (3 tháng)</asp:label></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD><asp:label id="Label1" runat="server">Tháng 1-3:</asp:label>&nbsp;<asp:label id="lblInfor4Phase1" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD><asp:label id="Label2" runat="server">Tháng 4-6:</asp:label>&nbsp;
						<asp:label id="lblInfor4Phase2" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" width="10%"></TD>
					<TD style="HEIGHT: 18px"><asp:label id="Label3" runat="server">Tháng 7-9:</asp:label>&nbsp;
						<asp:label id="lblInfor4Phase3" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD><asp:label id="Label4" runat="server">Tháng 10-12:</asp:label>&nbsp;
						<asp:label id="lblInfor4Phase4" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD class="lbGroupTitle" colSpan="2">
						<asp:Label id="lblHeader2Phase" runat="server" CssClass="lbGroupTitle">Thông tin chi phí trong 2 quý (6 tháng)</asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Label id="Label5" runat="server">Tháng 1-6:</asp:Label>&nbsp;
						<asp:Label id="lblInfor2Phase1" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Label id="Label6" runat="server">Tháng 7-12:</asp:Label>&nbsp;
						<asp:Label id="lblInfor2Phase2" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="lbGroupTitle" colSpan="2">
						<asp:Label id="lblHeader1Phase" runat="server" CssClass="lbGroupTitle">Thông tin chi phí trong 1 năm</asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Label id="Label7" runat="server">Tống chí phí:</asp:Label>&nbsp;
						<asp:Label id="lblInfor1Phase" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:Button id="btnClose" runat="server" Text="Đóng (d)"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
