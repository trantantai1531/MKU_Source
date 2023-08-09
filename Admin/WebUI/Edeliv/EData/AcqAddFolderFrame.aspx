<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqAddFolderFrame.aspx.vb" Inherits="Pages_AcqAddFolderFrame" %>
<head runat="server">        
    <TITLE>MicLib -- <%=Session("Fullname") %></TITLE>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<frameset border="0" framespacing="0" rows="*,28" frameborder="0">
	<frame id="mainaddfolder" name="mainaddfolder" marginwidth="0" marginheight="0" src="AcqAddFolderValue.aspx?Dialog_Content_Child=<%=Request.QueryString("Dialog_Content_Child")%>&nodeName=<%=Request.QueryString("nodeName")%>" scrolling="yes">
	<frame id="footeraddfolder" name="footeraddfolder" marginwidth="0" marginheight="0" src="AcqAddFolderControl.aspx?addnew=<%=Request.QueryString("addnew")%>" scrolling="no">
</frameset>