<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqDisplayChooseFilesFrame.aspx.vb" Inherits="Pages_AcqDisplayChooseFilesFrame" %>
<head runat="server">        
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>

<frameset border="0" framespacing="0" rows="*,28" frameborder="0">
	<frame  name="maincontentchoosefile" marginwidth="0" marginheight="0" src="AcqDisplayFolder.aspx?sfile=<%=Request.QueryString("sfile")%>&repeatable=<%=Request.QueryString("repeatable")%>&wfield=<%=Request.QueryString("wfield")%>&sfield=<%=Request.QueryString("sfield")%>&FieldCode=<%=Request.QueryString("FieldCode")%>" scrolling="no">
	<frame  name="footercontentchoosefile" marginwidth="0" marginheight="0" src="AcqDisplayControlChooseFiles.aspx" scrolling="no">
</frameset>