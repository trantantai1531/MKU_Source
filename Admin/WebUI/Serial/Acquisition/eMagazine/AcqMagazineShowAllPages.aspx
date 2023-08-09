<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagazineShowAllPages.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.eMagazine_AcqMagazineShowAllPages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>Danh sách tất cả các trang</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="jQuery Responsive Carousel - Owl Carusel">
    <meta name="author" content="Bartosz Wojciechowski">
    
	
    <style>
		body{margin:0; padding:0; color:#eee; background:#222; font-family:Verdana,Geneva,sans-serif; font-size:13px; line-height:20px;}
		a:link,a:visited,a:hover{color:inherit;}
		h1{font-family:Georgia,serif; font-size:18px; font-style:italic; margin:40px; color:#26beff;}
		p{margin:0 0 20px 0;}
		hr{height:0; border:none; border-bottom:1px solid rgba(255,255,255,0.13); border-top:1px solid rgba(0,0,0,1); margin:9px 10px; clear:both;}
		.links{margin:10px;}
		.links a{display:inline-block; padding:3px 15px; margin:7px 10px; background:#444; text-decoration:none; -webkit-border-radius:15px; -moz-border-radius:15px; border-radius:15px;}
		.links a:hover{background:#eb3755; color:#fff;}
		.output{margin:20px 40px;}
		code{color:#5b70ff;}
		.content{margin:10px; padding:10px; overflow:auto; background:#444; -webkit-border-radius:2px; -moz-border-radius:2px; border-radius:2px;}
		.content .images_container{overflow:hidden;}
		.content .images_container img{display:block; float:left; margin:0 5px; border:5px solid #777;}
		a[rel='toggle-buttons-scroll-type']{display:inline-block; text-decoration:none; padding:3px 15px; -webkit-border-radius:15px; -moz-border-radius:15px; border-radius:15px; background:#000; margin:5px 20px 5px 0;}	
    </style>
	<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
	<script src="js/jMobile/jquery-1.9.1.min.js"></script>
	<script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
	<link href="css/jPicture/photo.emiclib.css" type="text/css" rel="stylesheet" />
	<link href="css/jPicture/photoswipe.emiclib.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="js/jPicture/klass.min.js"></script>
	<script type="text/javascript" src="js/jPicture/code.photoswipe.jquery-3.0.5.min.js"></script>

	 <script type="text/javascript">
	     function gotoPages(p) {
	         var hidMagId = document.getElementById('hidMagId');
	         magId = hidMagId.value;
	         parent.location.href = "AcqMagazineTableOfContents.aspx?MagId=" + magId + "&page=" + p;
	     }
	</script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
     </head>
  <body>
	<div id="title">
      <div class="container">
        <h1>Tất cả các trang</h1>
      </div>
    </div>
	<div id="divContent" class="content">
		<div class="images_container">
            <asp:Table runat="server"  id="imgList" cellpadding="0" cellspacing="0" width="100%" border="0"></asp:Table>
		</div>
	</div>
    <div style="position:absolute;top:0px;left:0px;visibility:hidden;">
        <input id="hidMagId" type="hidden" value="0" runat="server" />       
    </div>

   <script>
       (function ($) {
           $(window).load(function () {
               $("#divContent").mCustomScrollbar({
                   scrollInertia: 550,
                   horizontalScroll: true,
                   mouseWheelPixels: 116,
                   scrollButtons: {
                       enable: true,
                       scrollType: "pixels",
                       scrollAmount: 116
                   },
                   callbacks: {
                       onScroll: function () { snapScrollbar(); }
                   }
               });
               /* toggle buttons scroll type */
               var content = $("#divContent");
               $("a[rel='toggle-buttons-scroll-type']").html("<code>scrollType: \"" + content.data("scrollButtons_scrollType") + "\"</code>");
               $("a[rel='toggle-buttons-scroll-type']").click(function (e) {
                   e.preventDefault();
                   var scrollType;
                   if (content.data("scrollButtons_scrollType") === "pixels") {
                       scrollType = "continuous";
                   } else {
                       scrollType = "pixels";
                   }
                   content.data({ "scrollButtons_scrollType": scrollType }).mCustomScrollbar("update");
                   $(this).html("<code>scrollType: \"" + content.data("scrollButtons_scrollType") + "\"</code>");
               });
               /* snap scrollbar fn */
               var snapTo = [];
               $("#divContent .images_container img").each(function () {
                   var $this = $(this), thisX = $this.position().left;
                   snapTo.push(thisX);
               });
               function snapScrollbar() {
                   var posX = $("#divContent .mCSB_container").position().left, closestX = findClosest(Math.abs(posX), snapTo);
                   $("#divContent").mCustomScrollbar("scrollTo", closestX, { scrollInertia: 350, callbacks: false });
               }
               function findClosest(num, arr) {
                   var curr = arr[0];
                   var diff = Math.abs(num - curr);
                   for (var val = 0; val < arr.length; val++) {
                       var newdiff = Math.abs(num - arr[val]);
                       if (newdiff < diff) {
                           diff = newdiff;
                           curr = arr[val];
                       }
                   }
                   return curr;
               }
           });
       })(jQuery);
	</script>
  </body>
</html>

