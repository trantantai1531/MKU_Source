<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagRegisterNumberFrame.aspx.vb" Inherits="Pages_acqMagRegisterNumberFrame" %>
<head id="Head1" runat="server">        
    <TITLE>Đăng ký số báo - tạp chí</TITLE>       
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" /> 
</head>

<frameset border="0" framespacing="0" rows="*,33" frameborder="0">
	<frame  name="maincontentMagazine" marginwidth="0" marginheight="0" src="AcqMagRegisterNumber.aspx?add=<%=request("add") %>&DocId=<%=request("docID") %>&MagId=<%=request("MagId") %>" scrolling="auto">
	<frame  name="footercontentMagazine" marginwidth="0" marginheight="0" src="AcqMagRegisterNumberControl.aspx" scrolling="no">
</frameset>
