<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OViewerMagazine.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OViewerMagazine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link href="Images/favicon-32x32.png" rel="shortcut icon" />
    <meta charset="utf-8" />    <title>Trường Đại Học Cửu Long</title>    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />    <meta name="apple-mobile-web-app-capable" content="yes" />    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />    <meta http-equiv="X-UA-Compatible" content="IE=9" />

    <link rel="stylesheet" type="text/css" media="all" href="Resources/StyleSheet/eMagazine/iip.min.css" />
     <link rel="stylesheet" type="text/css" href="Resources/StyleSheet/eMagazine/magazine.css" media="all" />
     <link rel="stylesheet"  href="Resources/StyleSheet/jMobile/jquery.mobile-1.3.2.min.css" />
	 <link rel="stylesheet"  href="Resources/StyleSheet/jMobile/popup.css" />
	 <link href="Resources/StyleSheet/eMagazine/jquery.mCustomScrollbar.css" rel="stylesheet" />

     <script type="text/javascript" src="js/eMagazine/mootools-yui-compressed.js"></script>
     <script type="text/javascript" src="js/eMagazine/iipmooviewer-2.0-min.js"></script>
     <script type="text/javascript" src="js/eMagazine/lang/help.vi.js"></script>     
     <script type="text/javascript" src="js/eMagazine/jquery.mCustomScrollbar.concat.min.js"></script>
     <script type="text/javascript" src="js/eMagazine/jMobile/jquery-1.9.1.min.js"></script>     <script type="text/javascript" src="js/eMagazine/jMobile/jquery.mobile-1.3.2.js"></script>     <script type="text/javascript" src="js/eMagazine/jMobile/popup.js"></script>	 <script type="text/javascript" src="js/eMagazine/viewer.min.js"></script>         
      <style type="text/css">
        body{
            height: 100%;
            padding: 0;
            margin: 0;
            background-image: url("images/2.png");
        }
        div#viewer{
            height: 100%;
            min-height: 100%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
            margin: 0;
            padding: 0;
        }	
	    div#vList{
	        height: 5%;
	        min-height: 5%;
            width: 100%;
            position: absolute;
            top: 95%;      
            margin: 0;
            padding: 0;
	    }
	    div#divPage
	    {		
	        position: absolute;	
            top: 8px;      
            margin: 0;
            padding: 0;
            color:#fff; 
            left:45%;      
	    }
	    div#divHome
	    {		
	        position: absolute;	
            top: 5px;      
            margin: 0;
            padding: 0;
            left:10px;      
	    }		
	    div#divShowhidden
	    {		
	        position: absolute;	
            top: 5px;      
            margin: 0;
            padding: 0;
            left:45px;      
	    }
	    div#divFullsrceen
	    {		
	        position: absolute;	
            top: 5px;      
            margin: 0;
            padding: 0;
            left:80px;      
	    }
	    .img{
            text-align:left;
            vertical-align:middle;
        }
	    .annotation.retouches{
	        border-color: red;
	        background-color:Yellow;
	    }	    .ui-panel-inner {
		    position: absolute;
		    top: 1px;
		    left: 0;
		    right: 0;
		    bottom: 0px;
		    overflow: scroll;
		    -webkit-overflow-scrolling: touch;
	    }
	</style>
    <script type="text/javascript">
        var magId = 0;
        var docId = 0;
        var magDetailId = 0;
        var magPage = 1;
        var magPageCounts = 1;
        var magYear = 0;
        var magServer = '';
        var magFile = '';
        var magTitle = '';       </script>
</head>
<body>
    <div id="viewer">				
	</div>
	<div class="footer">
        <div class="footer-wrap">
          <div id="divHome"><a href="javascript:gotoHome()"><img src="images/eMagazine/Home.png" class="img" alt="Trang chủ" title="Trang chủ" /></a></div>          
          <div id="divShowhidden"><a href="javascript:ShowhideWindows()"><img src="images/eMagazine/ShowhideW.png" class="img" alt="Ẩn/hiện cửa sổ chuyển hướng" title="Ẩn/hiện cửa sổ chuyển hướng" /></a></div>
          <div id="divFullsrceen">
            <a id="lnkTableOfContentsAll" href="#panelTableOfContentsAll">
                <img src="images/eMagazine/Viewer/TocAll.png" class="img" alt="Tổng mục lục các trang" title="Tổng mục lục các trang" />                
			</a>
          </div>
          <div id="divPage"><a href="javascript:gotoPrevious()"><img src="images/eMagazine/Arrows/thin_left_arrow.png" class="img" alt="Trang trước"  title="Trang trước"/></a>&nbsp;<span id="pageInfo" runat="server"></span>&nbsp;<a href="javascript:gotoNext()"><img src="images/eMagazine/Arrows/thin_right_arrow.png"  class="img" alt="Trang tiếp" title="Trang tiếp"/></a></div>

          <div class="view-control-tabs">
            <a id="lnkAllPages" href="#popupAllpages" data-rel="popup" data-position-to="window" data-wrapperels="span"  aria-haspopup="true" aria-owns="popupAllpages" aria-expanded="false">
                <img src="images/eMagazine/Viewer/allPages.png" class="img" alt="Hiển thị tất cả trang" title="Hiển thị tất cả trang" />                
			</a>
			<a id="lnkBrowseIssue" href="#popupBrowseIssue" data-rel="popup" data-position-to="window" data-wrapperels="span"  aria-haspopup="true" aria-owns="popupBrowseIssue" aria-expanded="false">
                <img src="images/eMagazine/Viewer/browseIssue.png" class="img" alt="Danh sách các số đã phát hành" title="Danh sách các số đã phát hành" />		
			</a>
            <a href="javascript:Fullscreen()"><img src="images/eMagazine/Fullscreen.png" class="img" alt="Xem toàn màn hình" title="Xem toàn màn hình" /></a>
          </div>
        </div>
     </div>

    <div data-role="panel" data-position="left" data-position-fixed="true" data-display="overlay" data-theme="d" id="panelTableOfContents">
        <ul data-role="listview" data-theme="d" data-inset="false" id="lstTableOfContents">			
		</ul>
    </div>
    <div data-role="panel" data-position="left" data-position-fixed="true" data-display="overlay" data-theme="d" id="panelTableOfContentsAll">
        <ul data-role="listview" data-theme="d" data-inset="false" id="lstTableOfContentsAll">			
		</ul>
    </div>
    <div data-role="popup" id="lst-TableOfContents" data-theme="d"></div>											
    <div data-role="popup" id="popupAllpages" data-overlay-theme="a" data-theme="d" data-tolerance="15,15" class="ui-content">
	    <a href="#" data-rel="back" data-role="button" data-theme="d" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Đóng</a>
	    <iframe src="OViewerMagazineAllPages.aspx?MagId=<%=Request("MagId")%>&ItemID=<%=Request("ItemID")%>&year=<%=Request("year")%>" width="400" height="200"></iframe>		 
    </div> 
    <div data-role="popup" id="popupBrowseIssue" data-overlay-theme="a" data-theme="d" data-tolerance="15,15" class="ui-content">
		<a href="#" data-rel="back" data-role="button" data-theme="d" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Đóng</a>
		<iframe src="OViewerMagazineBrowseIssue.aspx?ItemID=<%=Request("ItemID")%>&year=<%=Request("year")%>" width="400" height="200"></iframe>		 
	</div> 
     <div style="position:absolute;top:0px;left:0px;visibility:hidden;">
        <input id="hidIIPServer" type="hidden" value="" runat="server" /> 
        <input id="hidMagId" type="hidden" value="0" runat="server" />       
        <input id="hidYear" type="hidden" value="0" runat="server" />
        <input id="hidDocId" type="hidden" value="0" runat="server" />       
        <input id="hidMagDetailId" type="hidden" value="0" runat="server" />       
        <input id="hidMagFilePath" type="hidden" value="" runat="server" /> 
        <input id="hidMagPage" type="hidden" value="1" runat="server" /> 
        <input id="hidMagPageCount" type="hidden" value="1" runat="server" /> 
        <input id="hidCoordinatesX" type="hidden" value="0" runat="server" />
        <input id="hidCoordinatesY" type="hidden" value="0" runat="server" />
        <span  id="span_warning_next_page" runat="server">Bạn đang ở trang cuối.</span>
        <span  id="span_warning_previous_page" runat="server">Bạn đang ở trang đầu.</span>
        <span  id="span_page" runat="server">Trang</span>
     </div>
</body>
</html>
