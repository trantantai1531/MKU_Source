<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Common.WWaiting" CodeFile="WWaiting.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WWaiting</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE width="100%" border="0" cellpadding="5" cellspacing="5">
				<TR>
					<TD align="center" valign="bottom" height="100">
						<asp:Label id="lblWaiting" runat="server">Xin vui lòng chờ đợi trong chốc lát !</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" valign="middle"><img src="../Images/progressBar.gif" border="0"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
