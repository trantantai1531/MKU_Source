<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Common.WZFind_Cata" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WZFind_Cata.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kết quả tìm qua Z39.50</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%">
				<tr class="lbPageTitle">
					<td>
						<table cellSpacing="0" cellPadding="2" width="100%">
							<tr>
								<td><asp:label id="lblNext" Visible="False" Runat="server">Xem tiếp 10 biểu ghi bắt đầu từ biểu ghi: </asp:label><asp:textbox id="txtNext" Visible="False" Runat="server" Width="56px">11</asp:textbox><asp:button id="btnNext" Visible="False" Runat="server" Width="70px" Text="Xem(v)"></asp:button></td>
								<td align="right"><asp:label id="lblDisplay" runat="server" Visible="False">Hiển thị:</asp:label><asp:dropdownlist id="ddlDisplay" runat="server" Visible="False" AutoPostBack="True">
										<asp:ListItem Value="MARC">MARC</asp:ListItem>
										<asp:ListItem Value="ISBD">ISBD</asp:ListItem>
										<asp:ListItem Value="SIMPLE">Đơn giản</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><asp:table id="tblResult" runat="server" Width="100%"></asp:table></td>
				</tr>
				<tr class="lbGridHeader">
					<td align="center"><asp:label id="NotFound" Visible="False" Runat="server" ForeColor="White">Không tìm thấy bản ghi nào thoả mãn điều kiện</asp:label></td>
				</tr>
				<tr class="lbPageTitle">
					<td align="center"><asp:button id="btnBack" runat="server" Text="Quay lại"></asp:button><asp:button id="btnClose" Runat="server" Width="70px" Text="Đóng(c)"></asp:button></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabel" Visible="False" Runat="server" Width="0">
				<asp:ListItem Value="0">tìm thấy </asp:ListItem>
				<asp:ListItem Value="1"> biểu ghi</asp:ListItem>
				<asp:ListItem Value="2">Tác giả</asp:ListItem>
				<asp:ListItem Value="3">Nhan đề</asp:ListItem>
				<asp:ListItem Value="4">Xuất bản</asp:ListItem>
				<asp:ListItem Value="5">Thông tin khác</asp:ListItem>
				<asp:ListItem Value="6">Xin vui lòng chờ đợi trong chốc lát !</asp:ListItem>
				<asp:ListItem Value="7">Trường xem tiếp phải có thông tin !</asp:ListItem>
				<asp:ListItem Value="8">Trường xem tiếp phải là số !</asp:ListItem>
				<asp:ListItem Value="9">Vượt quá phạm vi cho phép !</asp:ListItem>
				<asp:ListItem Value="10">Nhập các trường biên mục</asp:ListItem>
				<asp:ListItem Value="11">Nhập tất cả các trường</asp:ListItem>
			</asp:dropdownlist>
			<INPUT id="hidTag020" type="hidden" runat="server"> <INPUT id="hidTag022" type="hidden" runat="server">
			<INPUT id="hidTag041" type="hidden" runat="server"> <INPUT id="hidTag044" type="hidden" runat="server">
			<INPUT id="hidTag100" type="hidden" runat="server"> <INPUT id="hidTag245a" type="hidden" runat="server">
			<INPUT id="hidTag245b" type="hidden" runat="server"> <INPUT id="hidTag245c" type="hidden" runat="server">
			<INPUT id="hidTag245n" type="hidden" runat="server"> <INPUT id="hidTag245p" type="hidden" runat="server">
			<INPUT id="hidTag250" type="hidden" runat="server"> <INPUT id="hidTag260a" type="hidden" runat="server">
			<INPUT id="hidTag260b" type="hidden" runat="server"> <INPUT id="hidTag260c" type="hidden" runat="server">
			<INPUT id="hidTag300a" type="hidden" runat="server"> <INPUT id="hidTag300b" type="hidden" runat="server">
			<INPUT id="hidTag300c" type="hidden" runat="server"> <INPUT id="hidTag300e" type="hidden" runat="server">
            <INPUT id="hidTag082" type="hidden" runat="server" /><INPUT id="hidTag110" type="hidden" runat="server" />
			<INPUT id="hidFormID" type="hidden" runat="server"> <INPUT id="hidMedium" type="hidden" runat="server">
			<INPUT id="hidLevel" type="hidden" runat="server"> <INPUT id="hidTypeCode" type="hidden" runat="server">
			<INPUT id="hidContent" type="hidden" runat="server"> <INPUT id="hidCountRec" type="hidden" runat="server">
			<INPUT id="hidAction" type="hidden" value="2" runat="server"> <INPUT id="hidPosRec" type="hidden" value="1" runat="server">
			<INPUT id="hidImport" type="hidden" value="-1" runat="server"> <INPUT id="hidImportID" type="hidden" value="0" runat="server">
			<asp:label id="lblJS" runat="server"></asp:label></form>
	</body>
</HTML>
