<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OViewer.aspx.vb" Inherits="eMicLibOPAC.WebUI.OViewer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link href="Images/favicon-32x32.png" rel="shortcut icon" />
     <title>Trường Đại Học Cửu Long</title>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
         <link rel="stylesheet" type="text/css" href="viewer/css/BookReader.css" id="BRCSS"/>
        <link rel="stylesheet" type="text/css" href="viewer/css/BookReaderDemo.css"/>

        <script src="viewer/js/jquery.min.js"></script>
        <script type="text/javascript" src="viewer/js/jquery-ui-1.8.5.custom.min.js"></script>

        <script type="text/javascript" src="viewer/js/dragscrollable.js"></script>
        <script type="text/javascript" src="viewer/js/jquery.colorbox-min.js"></script>
	    <script type="text/javascript" src="viewer/js/jquery.ui.ipad.js"></script>
        <script type="text/javascript" src="viewer/js/jquery.bt.min.js"></script>
        <script type="text/javascript" src="viewer/js/BookReader.js"></script>

        <script type="text/javascript">
	    <!--
    var urlBook = '<%=fXMLPath%>' + 'img/';
            var numLeafsTotal = '<%=fImgTotal %>';
            var bookTitle = '<%=fImgTotal %>';
            var bookPage = '<%=fbookPage %>';
            function gotoPage(pageIndex) {
                br.jumpToIndex(pageIndex);
            }

            function CancelContextMenu(evt) {
                evt = (evt == null) ? window.event : evt;
                evt.cancelBubble = true;
                evt.returnValue = false;
                evt.preventDefault(); //Firefox
                return false;
            }
            //-->
	    </script>

    </telerik:RadCodeBlock>
</head>
<body  class="bgbody" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0"  oncontextmenu="CancelContextMenu(event);">
    <form id="form1" runat="server">
        <div id="BookReader" >
            Đại học giao thông vận tải Tp. Hồ Chí Minh    <br/>

            <noscript>
            <p>
                Trình đọc sách cần JavaScript để được kích hoạt. Hãy kiểm tra xem trình duyệt của bạn có hỗ trợ JavaScript và rằng nó được kích hoạt trong cài đặt trình duyệt.
            </p>
            </noscript>
	
        </div>
        <script type="text/javascript" src="viewer/js/BookReaderJSSimple.js"></script>
    </form>
</body>
</html>
