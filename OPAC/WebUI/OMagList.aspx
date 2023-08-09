<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OMagList.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OMagList" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script src="js/OShow.js"></script>
    <script type="text/javascript">
        function gotoViewer(magId, docId) {
            location.href = "OViewerMagazine.aspx?MagId=" + magId.toString() + "&ItemID=" + docId.toString() + "&page=1";
        }
        function gotoDetailViewer(magId, docId, pageNum, coordinatesX, coordinatesY) {
            location.href = "OViewerMagazine.aspx?MagId=" + magId.toString() + "&ItemID=" + docId.toString() + "&page=" + pageNum.toString() + "&X=" + coordinatesX.toString() + "&Y=" + coordinatesY.toString();
        }
        function gotosecurityLevel(val) {
            top.parent.securityLevelInfo(val);
        }
        function showYear(docId, e) {
            location.href = 'OMagList.aspx?ItemID=' + docId + '&year=' + e.value;
        }
    </script>
    <%--<style>
        #back-top {
	        position: fixed;
	        bottom: 70px;
	        right: 15px;
	        margin-left: -150px;
	        z-index:1000;
        }
        #back-top a {
	        width: 32px;
	        display: block;
	        text-align: center;
	        font: 11px/100% Arial, Helvetica, sans-serif;
	        text-transform: uppercase;
	        text-decoration: none;
	        color: #fff;
        }
        #back-top a:hover {
	        color: #fff;
        }
        #back-top span {
	        width: 48px;
	        height: 48px;
	        display: block;
	        margin-bottom: 1px;
	        background: #0EA6E2 url(Images/Icons/up-arrow2.png) no-repeat center center;
	        background-color: transparent;
        }
        #back-top a:hover span {
	        background-color: transparent;
        }    
    </style>--%>
</head>
<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
        <%--<header data-load="OTop.aspx"></header>
         <div class="container">
            <h2><asp:Literal runat="server" ID="ltrTitle"></asp:Literal></h2>
            <asp:Table runat="server"  id="tbYearBrowseIssue" cellpadding="0" cellspacing="0" width="100%" border="0"></asp:Table>
            <asp:Table runat="server"  id="tbContents" cellpadding="0" cellspacing="0" width="100%" border="0"></asp:Table>   
            <div class="pagination">
                <ul>
                    <asp:Literal runat="server" ID="lrtPagination"></asp:Literal>
                </ul>
            </div>
            <p id="back-top" title="Trở về đầu trang" >
                <a href="#top"><span></span></a>
            </p>
         </div>   
         <div class="page-footer">
            <div class="page-footer-content">
                <uc1:UFooter ID="UFooter1" runat="server" />
            </div>
        </div> --%>      
        <uc2:UHeader ID="UHeader1" runat="server" />
         <div id="divMain">
            <div class="web-size news-page ClearFix">
                <h1><span class="mif-command"></span>Báo/tạp chí điện tử</h1>
                <h3 class="head-title"><asp:Literal runat="server" ID="ltrTitle"></asp:Literal></h3>
                <div class="input-control">
                    <B>Năm: </B>
                    <div class="dropdown-form">
                        <asp:Literal runat="server" ID="ltrYear"></asp:Literal> 
                    </div>
                </div>
                <div class="list-news">
                    <div class="row-group">  
                        <asp:Literal runat="server" ID="ltrContents"></asp:Literal>
                    </div>                    
                </div>    
                <div class="divPage">
                     <ul class="ClearFix">
                        <asp:Literal runat="server" ID="lrtPagination"></asp:Literal>
                    </ul>
                </div>         
            </div>
         </div>
         <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>  
        <div style="position:absolute;top:0px;left:0px;visibility:hidden;">
            <input id="hidMagId" type="hidden" value="0" runat="server" /> 
            <input id="hidYear" type="hidden" value="0" runat="server" /> 
            <input id="hidPage" type="hidden" value="1" runat="server" /> 
            <span runat="server" id="infoPage">Tr.</span>              
            <span runat="server" id="infoSubject">Tổng hợp</span>
            <span runat="server" id="infoTime"></span>   
            <span runat="server" id="span_SercretLevel">Tài liệu hạn chế</span> 
            <input id="docId" type="hidden" value="0" runat="server" />       
        </div>
    </form>
</body>
</html>
