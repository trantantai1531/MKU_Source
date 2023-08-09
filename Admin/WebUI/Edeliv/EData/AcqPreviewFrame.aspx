<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqPreviewFrame.aspx.vb" Inherits="Pages_AcqPreviewFrame" %>
<head runat="server">        
    <TITLE>MicLib -- <%=Session("Fullname") %></TITLE>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<frameset border="0" framespacing="0" rows="*,28" frameborder="0">
	<frame  name="mainpreview" marginwidth="0" marginheight="0" src="AcqPreviewValue.aspx?id=<%=Request.QueryString("id")%>" scrolling="yes">
	<frame  name="footerpreview" marginwidth="0" marginheight="0" src="AcqPreviewControl.aspx?id=<%=Request.QueryString("id")%>" scrolling="no">
</frameset>