<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldProperties" CodeFile="WMarcFieldProperties.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thuộc tính mô tả trường</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR>
					<TD colspan="2" align="center" class="lbPageTitle">
						<asp:Label id="lblTitle" runat="server" CssClass="main-group-form">Thuộc tính của trường</asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right" width="30%"><asp:label id="lblFieldCodeText" runat="server">Nhãn trường:</asp:label></TD>
					<TD align="left"><asp:label id="lblFieldCode" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblVietFieldNameText" runat="server">Tên trường:</asp:label></TD>
					<TD align="left"><asp:label id="lblVietFieldName" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFieldNameText" runat="server">Tên trường bằng tiếng Anh:</asp:label></TD>
					<TD align="left"><asp:label id="lblFieldName" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblDescriptionText" runat="server">Giải thích:</asp:label></TD>
					<TD align="left"><asp:label id="lblDescription" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFieldFunctionText" runat="server">Chức năng:</asp:label></TD>
					<TD align="left"><asp:label id="lblFieldFunction" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblRepeatableText" runat="server">Lặp:</asp:label></TD>
					<TD align="left"><asp:label id="lblRepeatable" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblMandatoryText" runat="server">Bắt buộc:</asp:label></TD>
					<TD align="left"><asp:label id="lblMandatory" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFieldTypeText" runat="server">Kiểu trường:</asp:label></TD>
					<TD align="left"><asp:label id="lblFieldType" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblLengthText" runat="server">Độ dài:</asp:label></TD>
					<TD align="left"><asp:label id="lblLength" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" valign="top"><asp:label id="lblIndicatorsText" runat="server">Indicators:</asp:label></TD>
					<TD align="left"><asp:label id="lblIndicators" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right" valign="top"><asp:label id="lblFieldText" runat="server" Visible="False">Là trường con của:</asp:label><asp:label id="lblFieldChildText" runat="server" Visible="False">Các trường con:</asp:label></TD>
					<TD align="left"><asp:label id="lblFieldChild" runat="server" Visible="False"></asp:label><asp:label id="lblField" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center" class="lbPageTitle">
						<asp:Button id="btnClose" runat="server" Text="Đóng(c)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
