<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqTableOfContentsAddFrame.aspx.vb" Inherits="Pages_AcqTableOfContentsAddFrame" %>
<head runat="server">        
    <TITLE>MicLib -- <%=Session("Fullname") %></TITLE>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<frameset border="0" framespacing="0" rows="*,36" frameborder="0">
	<frame  name="mainTableofcontent" marginwidth="0" marginheight="0" src="AcqTableOfContentsAddValue.aspx?nodeId=<%=Request.QueryString("nodeId")%>&page=<%=Request.QueryString("page")%>" scrolling="no">
	<frame  name="footerTableofcontent" marginwidth="0" marginheight="0" src="AcqTableOfContentsAddControl.aspx?addnew=<%=Request.QueryString("addnew")%>" scrolling="no">
</frameset>