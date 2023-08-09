<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqTableOfContentsFrame.aspx.vb" Inherits="Pages_AcqTableOfContentsFrame" %>
<head runat="server">        
    <TITLE>Xem dữ liệu biên mục</TITLE>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>

<frameset border="0" framespacing="0" rows="*,36" frameborder="0">
	<frame  name="maincontent" id="maincontent" marginwidth="0" marginheight="0" src="AcqTableOfContents.aspx" scrolling="yes">
	<frame  name="footercontent" id="footercontent" marginwidth="0" marginheight="0" src="AcqTableOfContentsControl.aspx" scrolling="no">
</frameset>