<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagazineTableOfContentsFrame.aspx.vb" Inherits="Pages_AcqMagazineTableOfContentsFrame" %>
<head id="Head1" runat="server">        
    <TITLE>Biên mục mục lục</TITLE>     
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />   
</head>

<frameset border="0" framespacing="0" rows="*,28" frameborder="0">
	<frame  name="maincontentMagazine" marginwidth="0" marginheight="0" src="AcqMagazineTableOfContents.aspx?MagId=<%=request("MagId") %>" scrolling="no">
	<frame  name="footercontentMagazine" marginwidth="0" marginheight="0" src="AcqMagazineTableOfContentsControl.aspx" scrolling="no">
</frameset>
