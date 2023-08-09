<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WLoadCopyNumberInfor" CodeFile="WLoadCopyNumberInfor.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WLoadCopyNumberInfor</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<INPUT type="hidden" id="hidPatronCode" runat="server"> <INPUT type="hidden" id="hidCopyNumber" runat="server">
			<INPUT type="hidden" id="hidExemptQuota" runat="server" value="1"> <INPUT type="hidden" id="hidIndefiniteDue" runat="server" value="1">
			<INPUT type="hidden" id="hidItemID" runat="server"> <INPUT type="hidden" id="hidLoanMode" runat="server">
			<INPUT type="hidden" id="hidLoanTypeID" runat="server"> 
			<INPUT type="hidden" id="hidLocationID" runat="server"> 
			<INPUT type="hidden" id="hidCheckOutDate" runat="server">
			<INPUT type="hidden" id="hidDueDate" runat="server"> <INPUT type="hidden" id="hidCheckOutTime" runat="server">
			<INPUT type="hidden" id="hidDueTime" runat="server">
			<INPUT type="hidden" id="hidHoldIgnored" runat="server">
		</form>
	</body>
</HTML>
