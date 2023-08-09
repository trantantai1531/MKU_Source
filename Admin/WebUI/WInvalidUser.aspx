<%@ Page Language="vb" AutoEventWireup="false" Inherits=" eMicLibAdmin.WebUI.WInvalidUser" CodeFile="WInvalidUser.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WInvalidUser</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<H3><FONT COLOR="red"><img src="Images/warning.gif" height="26">
						<asp:Label id="lblMsg" Runat="server">Bạn không được cấp quyền sử dụng phân hệ này</asp:Label></FONT></H3>
			</CENTER>
		</form>
	</body>
</HTML>
