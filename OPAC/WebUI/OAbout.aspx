<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OAbout.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OAbout" %>

<%@ Register Src="UFooter.ascx" TagName="UFooter" TagPrefix="uc1" %>
<%@ Register Src="UHeader.ascx" TagName="UHeader" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <style type="text/css">
        iframe
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="main-list web-size">
                <iframe id="frameAbout" frameborder="0" scrolling="no" onload="resizeIframe(this)"></iframe>
            </div>
        </div>
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
        <div style="display:none;">
            <asp:HiddenField ID="HiddenFieldLink" runat="server" Value="-1" />
            <asp:DropDownList ID="DropDownListLink" runat="server">
                <asp:ListItem Value="0">OTongQuan.aspx</asp:ListItem>
                <asp:ListItem Value="1">ONoiQuy.aspx</asp:ListItem>
                <%--<asp:ListItem Value="2">OChinhSach.aspx</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        
        <script type="text/javascript">
            function resizeIframe(obj) {
                obj.style.height = (obj.contentWindow.document.body.scrollHeight + 10) + 'px';
            }
            
            var HiddenFieldLink = document.getElementById('<%=HiddenFieldLink.ClientID %>').value;
            if(HiddenFieldLink == '0')
            {
                document.getElementById("frameAbout").src = "OTongQuan.aspx";
            }
            if (HiddenFieldLink == '1') {
                document.getElementById("frameAbout").src = "ONoiQuy.aspx";
            }
            //if (HiddenFieldLink == '2') {
            //    document.getElementById("frameAbout").src = "OChinhSach.aspx";
            //}
        </script>
    </form>
</body>
</html>
