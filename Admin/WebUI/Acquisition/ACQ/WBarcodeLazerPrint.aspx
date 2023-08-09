<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBarcodeLazerPrint" CodeFile="WBarcodeLazerPrint.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBarcodeLazerPrint</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <style type="text/css">
            body {
                -moz-transform: scale(1.0, 1.0); /* Moz-browsers */
                zoom: 1; /* Other non-webkit browsers */
                zoom: 100%; /* Webkit browsers */
                margin-left:0;
            }
            @page { margin: 1cm 0.75cm } 
            
        </style>
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" bgcolor=#ffffff>
				<tr>
					<td><asp:Label ID="lblDisplay" Runat="server" Visible="true"></asp:Label></td>
				</tr>
				<tr>
					<td><asp:HyperLink ID="hrf" Runat="server" Visible="False" NavigateUrl="#"></asp:HyperLink></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
