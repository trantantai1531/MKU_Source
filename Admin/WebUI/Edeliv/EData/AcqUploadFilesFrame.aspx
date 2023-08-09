<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqUploadFilesFrame.aspx.vb" Inherits="Pages_AcqUploadFilesFrame" %>
<head runat="server">        
    <TITLE>MicLib -- <%=Session("Fullname") %></TITLE>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<frameset border="0" framespacing="0" rows="*,28" frameborder="0">
	<frame  name="mainupload" marginwidth="0" marginheight="0" src="AcqUploadFilesValue.aspx?uploadPath=<%=Request.QueryString("uploadPath")%>" scrolling="yes">
	<frame  name="footerupload" marginwidth="0" marginheight="0" src="AcqUploadFilesControl.aspx" scrolling="no">
</frameset>