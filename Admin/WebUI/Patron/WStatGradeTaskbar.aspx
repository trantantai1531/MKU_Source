<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatGradeTaskbar" CodeFile="WStatGradeTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatGradeTaskbar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
      
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td>
						<asp:Label ID="lblCollege" Runat="server"><u>C</u>họn trường: </asp:Label>
						<asp:DropDownList ID="ddlCollege" Runat="server"></asp:DropDownList>
						<asp:Button ID="btnBack" Runat="server" Text="Quay lại(b)" Width="88px"></asp:Button>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">--------- Chọn trường ---------</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
