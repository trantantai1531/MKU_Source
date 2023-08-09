<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WSearch" CodeFile="WSearch.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSearch</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />   
		<script language="javascript">
			function setPgb(pgbID, pgbValue) {	
				if (pgbObj = document.getElementById(pgbID))
					pgbObj.width = pgbValue + '%'; // increase the progression by changing the width of the table
				if (lblObj = document.getElementById(pgbID+'_label'))
					lblObj.innerHTML = pgbValue + '%'; // change the label value
				}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Image id="Image1" style="Z-INDEX: 101; LEFT: 200px; POSITION: absolute; TOP: 112px" runat="server"
				Width="144px" Height="56px"></asp:Image>
		</form>
	</body>
</HTML>
