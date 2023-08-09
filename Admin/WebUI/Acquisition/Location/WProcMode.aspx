<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WProcMode" CodeFile="WProcMode.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WProcMode</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%">
				<tr>
					<td bgcolor="#AACFEA " style=" height: 38px;">
						<asp:Label ID="lblMode" Runat="server"><U>L</U>oại số liệu: </asp:Label>
						<asp:DropDownList ID="ddlMode" Runat="server" Width="112px">
							<asp:ListItem Value="0">Chưa kiểm nhận</asp:ListItem>
							<asp:ListItem Value="1">Trong kho</asp:ListItem>
							<asp:ListItem Value="2">Đã mất/Thanh lý</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
