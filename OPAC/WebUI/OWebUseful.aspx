<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OWebUseful.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OWebUseful" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Trường Đại Học Cửu Long</title>
    <link href="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
</head>
<body class="metro"  id="top"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
<asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
<form id="form1" runat="server">
    <uc2:UHeader ID="UHeader1" runat="server" />
     <div id="divMain" style="min-height:400px">
        <div class="web-size news-page ClearFix">
            <h1 runat="server" id="h1Weblink"><span class="mif-earth"></span>Wesite hữu ích</h1>
            <div class="list-web">
                <asp:Literal runat="server" ID="ltrWeblink"></asp:Literal>
            </div>
        </div>
     </div>
     <uc1:UFooter ID="UFooter1" runat="server" />
    <a href="#" id="toTop" class="scrollup">Scroll</a>
    <div style="display:none">
        <span id="spRecordItem" runat="server">Mục</span>
        <span id="spRecordTo" runat="server">đến</span>
        <span id="spRecordOf" runat="server">của</span>
        <span id="spPreviousPage" runat="server">Trang trước</span>
        <span id="spNextPage" runat="server">Trang tiếp</span>
        <span id="spAuthor" runat="server">Tác quyền: </span>
        <span id="spFormat" runat="server">Nhóm định dạng: </span>
        <span id="spLexile" runat="server">Nhóm trang: </span>
        <span id="spLanguage" runat="server">Nhóm ngôn ngữ: </span>
        <span id="spGrade" runat="server">Nhóm trình độ: </span>
        <span id="spDescription" runat="server">Mô tả: </span>
        <span id="spPicture" runat="server">Hình ảnh: </span>
        <span id="spView" runat="server">Xem chi tiết</span>
        <span id="spNoContent" runat="server">Không có nội dung</span>
    </div>
    <script type="text/javascript">
        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });
        var CollapsiblePanel6 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel6", { contentIsOpen: false });
        var CollapsiblePanel7 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel7", { contentIsOpen: false });
        var CollapsiblePanel8 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel8", { contentIsOpen: false });
        var CollapsiblePanel9 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel9", { contentIsOpen: false });
        var CollapsiblePanel10 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel10", { contentIsOpen: false });
        var CollapsiblePanel11 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel11", { contentIsOpen: false });
        var CollapsiblePanel12 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel12", { contentIsOpen: false });
        var CollapsiblePanel13 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel13", { contentIsOpen: false });
        var CollapsiblePanel14 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel14", { contentIsOpen: false });
        var CollapsiblePanel15 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel15", { contentIsOpen: false });
        var CollapsiblePanel16 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel16", { contentIsOpen: false });
        var CollapsiblePanel17 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel17", { contentIsOpen: false });
        var CollapsiblePanel18 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel18", { contentIsOpen: false });
        var CollapsiblePanel19 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel19", { contentIsOpen: false });
        var CollapsiblePanel20 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel20", { contentIsOpen: false });
        var CollapsiblePanel21 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel21", { contentIsOpen: false });
        var CollapsiblePanel22 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel22", { contentIsOpen: false });
        var CollapsiblePanel23 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel23", { contentIsOpen: false });
        var CollapsiblePanel24 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel24", { contentIsOpen: false });
        var CollapsiblePanel25 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel25", { contentIsOpen: false });
        var CollapsiblePanel26 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel26", { contentIsOpen: false });
        var CollapsiblePanel27 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel27", { contentIsOpen: false });
        var CollapsiblePanel28 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel28", { contentIsOpen: false });
        var CollapsiblePanel29 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel29", { contentIsOpen: false });
        var CollapsiblePanel30 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel30", { contentIsOpen: false });
    </script>
</form>
</body>
</html>
