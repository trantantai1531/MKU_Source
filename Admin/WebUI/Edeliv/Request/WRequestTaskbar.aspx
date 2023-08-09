<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestTaskbar" CodeFile="WRequestTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WRequestTaskbar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="1" leftmargin="5" class="lbControlBar">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellspacing="0" cellPadding="2" width="100%" border="0" class="lbControlBar">
				<TR class="lbControlBar">
					<TD>
						<asp:Label id="lblAction" runat="server"><u>H</u>ành động: </asp:Label>
						<asp:DropDownList id="ddlAction" runat="server"></asp:DropDownList>
						<asp:Button id="btnAction" runat="server" Text="Thực hiện(d)" Width="98px"></asp:Button>
					</TD>
					<TD align="right">
						<asp:Button id="btnFilter" runat="server" Text="Lọc(f)" Width="60px"></asp:Button>
						<asp:Button id="btnCancelFilter" runat="server" Text="Bỏ lọc(u)" Width="80px"></asp:Button>
					</TD>
				</TR>
			</TABLE>
			<INPUT id="hidRequestID" type="hidden" name="hidRequestID" runat="server">
		</form>
	</body>
</HTML>
