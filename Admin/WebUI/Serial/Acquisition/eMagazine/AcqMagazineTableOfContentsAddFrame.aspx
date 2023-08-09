<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagazineTableOfContentsAddFrame.aspx.vb" Inherits="Pages_AcqMagazineTableOfContentsAddFrame" %>
<head runat="server">        
    <TITLE>Thêm/sửa chi tiết mục lục</TITLE>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<frameset border="0" framespacing="0" rows="*,28" frameborder="0">
	<frame  name="mainTableofcontent" marginwidth="0" marginheight="0" src="AcqMagazineTableOfContentsAddValue.aspx?addnew=<%=Request.QueryString("addnew")%>&magDetailId=<%=Request.QueryString("magDetailId")%>" scrolling="yes">
	<frame  name="footerTableofcontent" marginwidth="0" marginheight="0" src="AcqMagazineTableOfContentsAddControl.aspx?addnew=<%=Request.QueryString("addnew")%>" scrolling="no">
</frameset>