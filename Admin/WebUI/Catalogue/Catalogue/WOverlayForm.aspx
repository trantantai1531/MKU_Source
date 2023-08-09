<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WOverlayForm" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WOverlayForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Nhập đè bản ghi thư mục</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="5" topMargin="5">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="Center" colSpan="3">
						<asp:label id="lblMainTitle" runat="server" CssClass="main-group-form">Nhập khẩu bản ghi biên mục (MARC 21)</asp:label></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3">
						<asp:label id="Label2" runat="server">Mã tài liệu:  </asp:label><asp:textbox id="txtItemCode" runat="server" Width="160px"></asp:textbox>&nbsp;
						<asp:label id="lblComment" runat="server">(Gắn bản ghi nhập khẩu với bản ghi có mã tài liệu này)</asp:label>&nbsp;&nbsp;</TD>
				</TR>
				<TR valign="middle">
					<TD align="left">
						<asp:label id="lblDataFormat" runat="server">Kiểu dữ liệu: </asp:label></TD>
					<TD align="left" colspan="2">
						<asp:RadioButton GroupName="Format" id="row" runat="server" Text="R<U>a</U>w MARC (ISO 2709)" Checked="True"></asp:RadioButton>&nbsp;
						<asp:RadioButton GroupName="Format" id="tag" runat="server" Text="<U>T</U>agged MARC"></asp:RadioButton></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3"><asp:label id="lblLeader" runat="server">Chỉ dẫn đầu biểu ghi:   </asp:label><asp:textbox id="txtLeader" runat="server" Width="440px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkLeaderHelp" runat="server" CssClass="lbLinkFunction">Trợ giúp</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3"><asp:label id="lblContent" runat="server"><U>N</U>ội dung bản ghi: </asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtContent" runat="server" Width="656px" Rows="8" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblDesignator" runat="server"><U>C</U>hỉ thị trường con:</asp:label></TD>
					<TD><asp:label id="lblDeliminator" runat="server"><U>P</U>hân cách giữa các trường: </asp:label></TD>
					<TD><asp:label id="lblExcludeFields" runat="server">Các trường <U>b</U>ỏ qua, cách nhau bởi dấu phảy (,): </asp:label></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txtDesignator" runat="server" Width="112px" MaxLength="1"></asp:textbox></TD>
					<TD><asp:textbox id="txtDeliminator" runat="server" Width="159px" MaxLength="3"></asp:textbox></TD>
					<TD><asp:textbox id="txtExcludeFields" runat="server" Width="256px"></asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD colSpan="3">
						<asp:button id="btnImport" runat="server" Text="Nhập khẩu(u)" Width="93px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="72px"></asp:button>&nbsp;
						<asp:button id="btnZ3950" runat="server" Text="Tải về qua Z3950(z)" Width="144px"></asp:button></TD>
				</TR>
			</TABLE>
			<input type="hidden" id="hidFormID" runat="server"> <input type="hidden" id="hidStage" runat="server">
			<input type="hidden" id="hidCurrentID" runat="server"> <input type="hidden" id="hidItemID" runat="server">
		</form>
	</body>
</HTML>
