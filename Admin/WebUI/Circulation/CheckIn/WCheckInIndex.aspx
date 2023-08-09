<%@ Page Language="vb" AutoEventWireup="false" Inherits="WCheckInIndex" CodeFile="WCheckInIndex.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WCheckInIndex</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<frameset border="0" frameSpacing="0" rows="*,0" frameBorder="0" id="frmCheckIn">
		<frameset border="0" frameSpacing="0" cols="34%,66%" frameBorder="0">
			<frame name="CheckIn" marginWidth="0" marginHeight="0" src="WCheckIn.aspx" noResize scrolling="no">
			<frame name="CheckInMain" marginWidth="0" marginHeight="0" noResize src="../../WNothing.aspx"
				noResize scrolling="auto">
		</frameset>
		<frame name="Reservations" marginwidth="0" marginheight="0" noResize src="../WReservationsRun.aspx"
			scrolling="no">
	</frameset>
</HTML>
