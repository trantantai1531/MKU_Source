<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqDisplayFrame.aspx.vb" Inherits="Pages_AcqDisplayFrame" %>
<head runat="server">        
    <TITLE>Xem dữ liệu điện tử</TITLE>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>

<frameset border="0" framespacing="0" rows="*,33,0" frameborder="0">
	<frame  name="maincontent" marginwidth="0" marginheight="0" src="AcqNothing.aspx" scrolling="no"></frame>
	<frame  name="footercontent" marginwidth="0" marginheight="0" src="AcqDisplayControl.aspx" scrolling="no"></frame>
    <frame  name="hiddenSaveFile" marginwidth="0" marginheight="0" src="AcqNothing.aspx" scrolling="no"></frame>
</frameset>