<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OViewerMagazineBrowseIssue.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OViewerMagazineBrowseIssue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <style>
		body{margin:0; padding:0; color:#eee; background:#222; font-family:Verdana,Geneva,sans-serif; font-size:13px; line-height:20px;background-image: url("images/eMagazine/viewer/bgViewer2.png");}
		a:link,a:visited,a:hover{color:inherit;}
		h1{font-family:Georgia,serif; font-size:18px; font-style:italic; margin:40px; color:#26beff;}
		h2{font-family:Georgia,serif; font-size:18px; font-style:italic;}
		p{margin:0 0 10px 0;}
		hr{height:0; border:none; border-bottom:1px solid rgba(255,255,255,0.13); border-top:1px solid rgba(0,0,0,1); margin:9px 10px; clear:both;}
		.links{margin:10px;}
		.links a{display:inline-block; padding:3px 15px; margin:7px 10px; background:#444; text-decoration:none; -webkit-border-radius:15px; -moz-border-radius:15px; border-radius:15px;}
		.links a:hover{background:black; color:#fff;}
		.leftcontent{margin:0 0 10px 10px; width:15%; height:80%; padding:20px; overflow:auto; -webkit-border-radius:3px; -moz-border-radius:3px; border-radius:3px; float:left;}
		.leftcontent p:nth-child(even){font-family:Georgia,serif; font-size:17px; font-style:italic;}
		.rightcontent{margin:0px 0px 0px 20px; left:16%; width:75%; height:80%;position: absolute; padding:18px; overflow:auto; -webkit-border-radius:3px; -moz-border-radius:3px; border-radius:3px; float:left;}
		.rightcontent p:nth-child(even){font-family:Georgia,serif; font-size:17px; font-style:italic;}
		#yearBrowseIssue{color:#eee;background-image: url("images/eMagazine/viewer/bgViewer6.png");}
		#yearBrowseIssue p:nth-child(even){color:#999;}
		#BrowseIssue{color:#eee;background-image: url("images/eMagazine/viewer/bgViewer5.png");}
		#BrowseIssue p:nth-child(even){color:#666;}		
	</style>
	
	<link href="Resources/StyleSheet/eMagazine/jquery.mCustomScrollbar.css" rel="stylesheet" />
	<script type="text/javascript" src="js/eMagazine/jMobile/jquery-1.9.1.min.js"></script>
	<script type="text/javascript" src="js/eMagazine/jquery.mCustomScrollbar.concat.min.js"></script>

	<link href="Resources/StyleSheet/jPicture/photo.emiclib.css" type="text/css" rel="stylesheet" />
	<link href="Resources/StyleSheet/jPicture/photoswipe.emiclib.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="js/eMagazine/jPicture/klass.min.js"></script>
	<script type="text/javascript" src="js/eMagazine/jPicture/code.photoswipe.jquery-3.0.5.min.js"></script>
    <script type="text/javascript">
     (function ($) {
         $(window).load(function () {
             $("#yearBrowseIssue").mCustomScrollbar({
                 scrollButtons: {
                     enable: true
                 }
             });
             $("#BrowseIssue").mCustomScrollbar({
                 scrollButtons: {
                     enable: true
                 }
					,
                 theme: "light-thick"
             });
         });
     })(jQuery);

   </script>
	  
	<script type="text/javascript">
	    function gotoViewerNumber(magId, docId, year) {
	        var strUrl = "OViewerMagazine.aspx?MagId=" + magId.toString() + "&ItemID=" + docId.toString() + "&page=1";
	        if (year > 0) {
	            strUrl = strUrl + "&year=" + year;
	        }
	        parent.location.href = strUrl;
	    }
	    function getMagNumByYear(year) {
	        var hidYear = document.getElementById('hidYear');
	        hidYear.value = year;
	        var raiseBrowseIssue = document.getElementById('raiseBrowseIssue');
	        raiseBrowseIssue.click();
	    }
	</script>
</head>
<body>
    <form id="browseList" runat="server">
        <h1>Danh sách các số</h1>
	    <div id="yearBrowseIssue" class="leftcontent">
            <asp:Table runat="server"  id="tbYearBrowseIssue" cellpadding="0" cellspacing="0" width="100%" border="0"></asp:Table>
	    </div>
	    <div id="BrowseIssue" class="rightcontent" >
            <asp:Table runat="server"  id="imgList" cellpadding="0" cellspacing="0" width="100%" border="0"></asp:Table>
	    </div>	
        <div style="position:absolute;top:0px;left:0px;visibility:hidden;">
            <input id="docId" type="hidden" value="0" runat="server" />       
            <input id="hidYear" type="hidden" value="0" runat="server" />  
            <asp:Button runat="server" ID="raiseBrowseIssue"  Text="raiseBrowseIssue"/>
        </div>
    </form>
</body>
</html>
