<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WILLMainIndex" CodeFile="WILLMainIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WILLMainIndex</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<FRAMESET id="frmMain" border="0" frameSpacing="0" rows="*,0" frameBorder="0">
		<%--<FRAME name="Header" marginWidth="0" marginHeight="0" src="WILLMenu.aspx" scrolling="no">--%>
		<frameset cols="0,*">
			<FRAME NAME="Refernce" SRC="../Common/WReference.aspx" MARGINHEIGHT="0" MARGINWIDTH="0"
				noresize scrolling="no">
			<frameset id="frmSubMain" rows="*,0">
				<FRAME name="Workform" marginWidth="0" marginHeight="0" src="WILLQuickView.aspx" noresize>
				<FRAME name="Sentform" marginWidth="0" marginHeight="0" src="Nothing.htm" noresize>
			</frameset>
		</frameset>
		<FRAME name="Hiddenbase" marginWidth="0" marginHeight="0" src="Nothing.htm" scrolling="no">
	</FRAMESET>
</HTML>
