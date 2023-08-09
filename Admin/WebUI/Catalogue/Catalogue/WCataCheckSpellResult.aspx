<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataCheckSpellResult" CodeFile="WCataCheckSpellResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kết quả kiểm tra</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="lbpageTitle" align="center" colSpan="2"><asp:label id="lblMainTitle" runat="server" CssClass="lbpageTitle">Sửa lỗi chính tả</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblNotFound" runat="server">Không tìm thấy</asp:label></TD>
					<TD><asp:button id="btnReplace" runat="server" Text="Thay thế(r)" width="80px"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="notFound" runat="server" ReadOnly="True"></asp:textbox></TD>
					<TD><asp:button id="btnReplaceAll" runat="server" Text="Thay toàn bộ(a)" width="110px"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblReplaceBy" runat="server"><U>T</U>hay thế bằng</asp:label></TD>
					<TD><asp:button id="btnIgnore" runat="server" Text="Bỏ qua(i)" width="72px"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="replacement" runat="server"></asp:textbox></TD>
					<TD><asp:button id="btnIgnoreAll" runat="server" Text="Bỏ toàn bộ(g)" width="98px"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblGuide" runat="server">Các <U>g</U>ợi ý</asp:label></TD>
					<TD><asp:button id="btnClose" runat="server" Text="Kết thúc(e)" width="82px"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:listbox id="pp" runat="server">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
							<asp:ListItem></asp:ListItem>
						</asp:listbox></TD>
					<TD><asp:label id="lblJS" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
