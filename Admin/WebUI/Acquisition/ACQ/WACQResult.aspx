<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQResult" CodeFile="WACQResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WACQResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="DKCBDisplay" width="100%">
				<tr>
					<td width="100%" align="left"><asp:Label ID="lblPageHeader" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr>
					<td width="100%"><asp:Label ID="lblOutMsg" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr>
					<td width="100%" align="right"><asp:Label ID="lblPageFooter" Runat="server" Width="100%"></asp:Label></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="Log">In báo cáo bổ sung</asp:ListItem>
			</asp:DropDownList>  		
		</form>
        <SCRIPT type="text/javascript">
            function PrintPg() {
                self.focus();
                setTimeout('self.print()', 1);
            }
		</SCRIPT>	
	</body>
</HTML>
