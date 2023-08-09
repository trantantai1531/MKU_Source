<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WZForm" CodeFile="WZForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Libol - Z39.50 Gateway</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD align="left" colSpan="3">
						<asp:label id="lblMainTitle" cssclass="lbPageTitle" runat="server" Width="100%">Libol - Z39.50 Gateway</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2">
						<asp:label id="lblzServer" runat="server"><u>T</u>ên máy chủ Z39.50 :</asp:label></TD>
					<TD><asp:textbox id="txtzServer" runat="server" Width="211px" Height="21px"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkZServerList" runat="server">Danh sách</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><asp:label id="lblZPort" runat="server"><u>C</u>ổng dịch vụ :</asp:label></TD>
					<TD><asp:textbox id="txtZPort" runat="server" Width="77px" Height="21px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><asp:label id="lblZDatabase" runat="server">Tên cơ sở <u>d</u>ữ liệu :</asp:label></TD>
					<TD><asp:textbox id="txtZDatabase" runat="server" Width="181px" Height="21px"></asp:textbox></TD>
				</TR>
				<TR class="lbPageTitle">
					<TD align="left" colSpan="3"><asp:label cssclass="lbPageTitle" id="lblSubTitle" runat="server">Điều kiện tìm kiếm</asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:dropdownlist id="ddlFieldName1" runat="server" Width="125px" Height="24px"></asp:dropdownlist></TD>
					<TD><asp:textbox id="txtFieldValue1" runat="server" Width="249px" Height="21px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:dropdownlist id="ddlOperator2" runat="server" Width="86px" Height="24px"></asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlFieldName2" runat="server" Width="125px" Height="24px"></asp:dropdownlist></TD>
					<TD><asp:textbox id="txtFieldValue2" runat="server" Width="249px" Height="21px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="1" rowSpan="1"><asp:dropdownlist id="ddlOperator3" runat="server" Width="86px" Height="24px"></asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlFieldName3" runat="server" Width="125px" Height="24px"></asp:dropdownlist></TD>
					<TD><asp:textbox id="txtFieldValue3" runat="server" Width="249px" Height="21px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><asp:label id="lblDisplay" runat="server">Hiển thị:</asp:label></TD>
					<TD><asp:radiobutton id="optMARC" runat="server" Height="21px" Text="<u>M</u>ARC" GroupName="optDisplay"></asp:radiobutton>&nbsp;
						<asp:radiobutton id="optISBD" runat="server" Height="21px" Text="<u>I</u>SBD" Checked="True" GroupName="optDisplay"></asp:radiobutton>&nbsp;
						<asp:radiobutton id="optSimple" runat="server" Height="21px" Text="Đơn <u>g</u>iản " GroupName="optDisplay"></asp:radiobutton>&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
					<TD><asp:button id="btnSearch" runat="server" Height="22px" Text="Tìm kiếm(k)"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Height="22px" Text="Làm lại(r)"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
					<TD>
						<asp:Label id="lblTitle" runat="server" Visible="False">Nhan đề</asp:Label>
						<asp:Label id="lblSeri" runat="server" Visible="False">Nhan đề tùng thư</asp:Label>
						<asp:Label id="lblAuthor" runat="server" Visible="False">Tác giả</asp:Label>
						<asp:Label id="lblAuthorGr" runat="server" Visible="False">Tác giả tập thể</asp:Label>
						<asp:Label id="lblSubject" runat="server" Visible="False">Chủ đề</asp:Label>
						<asp:Label id="lblISBN" runat="server" Visible="False">ISBN</asp:Label>
						<asp:Label id="lblISSN" runat="server" Visible="False">ISBN</asp:Label>
						<asp:Label id="lblAllFields" runat="server" Visible="False">Mọi trường</asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
