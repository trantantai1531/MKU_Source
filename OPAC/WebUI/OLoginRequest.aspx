<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OLoginRequest.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OLoginRequest" %>
<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Trường Đại Học Cửu Long</title>
    <%--<script src="js/ui/jquery.js"></script>
    <script src="js/ui/core.js"></script>
	<script src="js/ui/widget.js"></script>
	<script src="js/ui/mouse.js"></script>
	<script src="js/ui/draggable.js"></script>
	<script src="js/ui/droppable.js"></script>
    <script src="js/ui/jquery.bpopup.min.js"></script>
    <script src="js/metro.min.js"></script>
    <script src="js/docs.js"></script>--%>
</head>
<body  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px" id="top">
<asp:ScriptManager ID="sm" runat="server" EnablePageMethods="false" />
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
             <div class="web-size ClearFix">
                <iframe id="frmLogin" src="OLogin.aspx?viewer=<%=Request("viewer")%>&RequestLogin=<%=Request("RequestLogin")%>" style="width:100%;height:450px;border:0px;" scrolling="no"></iframe>
             </div>
        </div>
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
    </form>
</body>
</html>