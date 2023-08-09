<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckInPrintResult" CodeFile="WCheckInPrintResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<meta name="vs_showGrid" content="True">
		<title>Hệ thống thư viện điện tử</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <embed type="application/pdf" src="path_to_pdf_document.pdf" id="pdfDocument" width="100%" height="100%"></embed>
        <style type="text/css" media="print">
            @page 
            {
                size: auto;   /* auto is the initial value */
                margin: 7mm;  /* this affects the margin in the printer settings */
            }
            @media print {
                html, body {
                    height: 99%;
                }
            }
        </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" bgcolor="#f3f3f3">
		<form id="Form1" method="post" runat="server">
			<table bgcolor=White width=100% height=100% cellpadding=0 cellspacing=0 border=0>
				<tr>
					<td valign=top>
						<asp:Label CssClass="lbLabel" id="lblDisplay" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
			
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
