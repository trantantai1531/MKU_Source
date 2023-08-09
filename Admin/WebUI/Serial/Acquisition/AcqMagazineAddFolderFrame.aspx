<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagazineAddFolderFrame.aspx.vb" Inherits="Pages_AcqMagazineAddFolderFrame" %>
<head runat="server">        
    <TITLE>MicLib -- <%=Session("Fullname") %></TITLE>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<frameset border="0" framespacing="0" rows="*,28" frameborder="0">
	<frame  name="mainaddfolder" marginwidth="0" marginheight="0" src="AcqMagazineAddFolderValue.aspx" scrolling="yes">
	<frame  name="footeraddfolder" marginwidth="0" marginheight="0" src="AcqMagazineAddFolderControl.aspx?addnew=<%=Request.QueryString("addnew")%>" scrolling="no">
</frameset>