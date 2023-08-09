<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OIndex.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OIndex" %>

<%@ Register Src="UFooter.ascx" TagName="UFooter" TagPrefix="uc1" %>
<%@ Register Src="UHeader.ascx" TagName="UHeader" TagPrefix="uc2" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script type="text/javascript" src="js/OIndex.js"></script>
    <%--<script type="text/javascript" src="Resources/StyleSheet/ssc/java/googleajax-jquery-ui.min-1.8.2.js"></script>
    <script type="text/javascript" src="Resources/StyleSheet/ssc/java/jssor/jquery-1.9.1.min.js"></script>--%>
    <link href="Resources/StyleSheet/ssc/java/owl/owl.carousel.css" rel="stylesheet" />
    <link href="Resources/StyleSheet/ssc/java/owl/owl.theme.css" rel="stylesheet" />
    <style type="text/css">
        .above {
            width: 47.5% !important;
        }

        #SiteMap1 {
            height: 500px;
            overflow: scroll;
        }

        iframe {
            min-height: 300px;
            width: 100%;
        }

        .captionOrange, .captionBlack {
            color: #fff;
            font-size: 20px;
            line-height: 30px;
            text-align: center;
            border-radius: 4px;
        }

        .captionOrange {
            height: auto !important;
        }

        .captionOrange {
            background: #333;
            background-color: rgba(235, 81, 0, 0.6);
        }

        .captionBlack {
            font-size: 16px;
            background: #000;
            background-color: rgba(0, 0, 0, 0.4);
        }

        a.captionOrange, A.captionOrange:active, A.captionOrange:visited {
            color: #ffffff;
            text-decoration: none;
        }

            a.captionOrange:hover {
                color: #333;
                text-decoration: underline;
                background-color: #eeeeee;
                background-color: rgba(238, 238, 238, 0.7);
            }

        .bricon {
            background: url(../img/browser-icons.png);
        }

        .jssorb01 div, .jssorb01 div:hover, .jssorb01 .av {
            filter: alpha(opacity=70);
            opacity: .7;
            overflow: hidden;
            cursor: pointer;
            border: #000 1px solid;
        }

        .jssorb01 div {
            background-color: gray;
        }

            .jssorb01 div:hover, .jssorb01 .av:hover {
                background-color: #d3d3d3;
            }

        .jssorb01 .av {
            background-color: #fff;
        }

        .jssorb01 .dn, .jssorb01 .dn:hover {
            background-color: #555555;
        }

        .jssora05l, .jssora05r, .jssora05ldn, .jssora05rdn {
            position: absolute;
            cursor: pointer;
            display: block;
            background: url(Resources/StyleSheet/ssc/images/jssor/a21.png) no-repeat;
            overflow: hidden;
        }

        .jssora05l {
            background-position: -10px -40px;
        }

        .jssora05r {
            background-position: -70px -40px;
        }

        .jssora05l:hover {
            background-position: -130px -40px;
        }

        .jssora05r:hover {
            background-position: -190px -40px;
        }

        .jssora05ldn {
            background-position: -250px -40px;
        }

        .jssora05rdn {
            background-position: -310px -40px;
        }

        #slider2_container img
        {
            border:0;
        }
        .modul-list li
        {
            margin-bottom:10px;
        }
        .list-news
        {
            margin-left:-10px;
            margin-right:-10px;
        }
        .row-group
        {
            padding:0;
        }
        .div-blank
        {
            height:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
        <uc2:UHeader ID="UHeader1" runat="server" />
        <style type="text/css">
            .modul-box span {
                font-size: 400%;
                margin-bottom: 15px;
            }.modul-box {
                height: 160px;
            }
        </style>
        <div id="divMain">
            <div class="two-column main-banner web-size ClearFix" style="padding-top:0px;">
                <div class="two-column-form banner-list" style="padding-top:20px;">
                    <script type="text/javascript" src="Resources/StyleSheet/ssc/java/jssor/jssor.js"></script>
                    <script type="text/javascript" src="Resources/StyleSheet/ssc/java/jssor/jssor.slider.js"></script>
                    <script type="text/javascript">
                        jQuery(document).ready(function ($) {
                            //Reference http://www.jssor.com/development/slider-with-slideshow-jquery.html
                            //Reference http://www.jssor.com/development/tool-slideshow-transition-viewer.html

                            var _SlideshowTransitions = [
                            //Swing Outside in Stairs
                            { $Duration: 1200, x: 0.2, y: -0.1, $Delay: 20, $Cols: 8, $Rows: 4, $Clip: 15, $During: { $Left: [0.3, 0.7], $Top: [0.3, 0.7] }, $Formation: $JssorSlideshowFormations$.$FormationStraightStairs, $Assembly: 260, $Easing: { $Left: $JssorEasing$.$EaseInWave, $Top: $JssorEasing$.$EaseInWave, $Clip: $JssorEasing$.$EaseOutQuad }, $Outside: true, $Round: { $Left: 1.3, $Top: 2.5 } }

                                        //Dodge Dance Outside out Stairs
                            , { $Duration: 1500, x: 0.3, y: -0.3, $Delay: 20, $Cols: 8, $Rows: 4, $Clip: 15, $During: { $Left: [0.1, 0.9], $Top: [0.1, 0.9] }, $SlideOut: true, $Formation: $JssorSlideshowFormations$.$FormationStraightStairs, $Assembly: 260, $Easing: { $Left: $JssorEasing$.$EaseInJump, $Top: $JssorEasing$.$EaseInJump, $Clip: $JssorEasing$.$EaseOutQuad }, $Outside: true, $Round: { $Left: 0.8, $Top: 2.5 } }

                                        //Dodge Pet Outside in Stairs
                            , { $Duration: 1500, x: 0.2, y: -0.1, $Delay: 20, $Cols: 8, $Rows: 4, $Clip: 15, $During: { $Left: [0.3, 0.7], $Top: [0.3, 0.7] }, $Formation: $JssorSlideshowFormations$.$FormationStraightStairs, $Assembly: 260, $Easing: { $Left: $JssorEasing$.$EaseInWave, $Top: $JssorEasing$.$EaseInWave, $Clip: $JssorEasing$.$EaseOutQuad }, $Outside: true, $Round: { $Left: 0.8, $Top: 2.5 } }

                                        //Dodge Dance Outside in Random
                            , { $Duration: 1500, x: 0.3, y: -0.3, $Delay: 80, $Cols: 8, $Rows: 4, $Clip: 15, $During: { $Left: [0.3, 0.7], $Top: [0.3, 0.7] }, $Easing: { $Left: $JssorEasing$.$EaseInJump, $Top: $JssorEasing$.$EaseInJump, $Clip: $JssorEasing$.$EaseOutQuad }, $Outside: true, $Round: { $Left: 0.8, $Top: 2.5 } }

                                        //Flutter out Wind
                            , { $Duration: 1800, x: 1, y: 0.2, $Delay: 30, $Cols: 10, $Rows: 5, $Clip: 15, $During: { $Left: [0.3, 0.7], $Top: [0.3, 0.7] }, $SlideOut: true, $Reverse: true, $Formation: $JssorSlideshowFormations$.$FormationStraightStairs, $Assembly: 2050, $Easing: { $Left: $JssorEasing$.$EaseInOutSine, $Top: $JssorEasing$.$EaseOutWave, $Clip: $JssorEasing$.$EaseInOutQuad }, $Outside: true, $Round: { $Top: 1.3 } }

                                        //Collapse Stairs
                            , { $Duration: 1200, $Delay: 30, $Cols: 8, $Rows: 4, $Clip: 15, $SlideOut: true, $Formation: $JssorSlideshowFormations$.$FormationStraightStairs, $Assembly: 2049, $Easing: $JssorEasing$.$EaseOutQuad }

                                        //Collapse Random
                            , { $Duration: 1000, $Delay: 80, $Cols: 8, $Rows: 4, $Clip: 15, $SlideOut: true, $Easing: $JssorEasing$.$EaseOutQuad }

                                        //Vertical Chess Stripe
                            , { $Duration: 1000, y: -1, $Cols: 12, $Formation: $JssorSlideshowFormations$.$FormationStraight, $ChessMode: { $Column: 12 } }

                                        //Extrude out Stripe
                            , { $Duration: 1000, x: -0.2, $Delay: 40, $Cols: 12, $SlideOut: true, $Formation: $JssorSlideshowFormations$.$FormationStraight, $Assembly: 260, $Easing: { $Left: $JssorEasing$.$EaseInOutExpo, $Opacity: $JssorEasing$.$EaseInOutQuad }, $Opacity: 2, $Outside: true, $Round: { $Top: 0.5 } }

                                        //Dominoes Stripe
                            , { $Duration: 2000, y: -1, $Delay: 60, $Cols: 15, $SlideOut: true, $Formation: $JssorSlideshowFormations$.$FormationStraight, $Easing: $JssorEasing$.$EaseOutJump, $Round: { $Top: 1.5 } }
                            ];

                            var options = {
                                $AutoPlay: true,                                    //[Optional] Whether to auto play, to enable slideshow, this option must be set to true, default value is false
                                $AutoPlaySteps: 1,                                  //[Optional] Steps to go for each navigation request (this options applys only when slideshow disabled), the default value is 1
                                $AutoPlayInterval: 4000,                            //[Optional] Interval (in milliseconds) to go for next slide since the previous stopped if the slider is auto playing, default value is 3000
                                $PauseOnHover: 1,                               //[Optional] Whether to pause when mouse over if a slider is auto playing, 0 no pause, 1 pause for desktop, 2 pause for touch device, 3 pause for desktop and touch device, 4 freeze for desktop, 8 freeze for touch device, 12 freeze for desktop and touch device, default value is 1

                                $ArrowKeyNavigation: true,   			            //[Optional] Allows keyboard (arrow key) navigation or not, default value is false
                                $SlideDuration: 500,                                //[Optional] Specifies default duration (swipe) for slide in milliseconds, default value is 500
                                $MinDragOffsetToSlide: 10,                          //[Optional] Minimum drag offset to trigger slide , default value is 20
                                $SlideWidth: 600,                                 //[Optional] Width of every slide in pixels, default value is width of 'slides' container
                                $SlideHeight: 332,                                //[Optional] Height of every slide in pixels, default value is height of 'slides' container
                                $SlideSpacing: 0, 					                //[Optional] Space between each slide in pixels, default value is 0
                                $DisplayPieces: 1,                                  //[Optional] Number of pieces to display (the slideshow would be disabled if the value is set to greater than 1), the default value is 1
                                $ParkingPosition: 0,                                //[Optional] The offset position to park slide (this options applys only when slideshow disabled), default value is 0.
                                $UISearchMode: 1,                                   //[Optional] The way (0 parellel, 1 recursive, default value is 1) to search UI components (slides container, loading screen, navigator container, arrow navigator container, thumbnail navigator container etc).
                                $PlayOrientation: 1,                                //[Optional] Orientation to play slide (for auto play, navigation), 1 horizental, 2 vertical, 5 horizental reverse, 6 vertical reverse, default value is 1
                                $DragOrientation: 3,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $DisplayPieces is greater than 1, or parking position is not 0)

                                $SlideshowOptions: {                                //[Optional] Options to specify and enable slideshow or not
                                    $Class: $JssorSlideshowRunner$,                 //[Required] Class to create instance of slideshow
                                    $Transitions: _SlideshowTransitions,            //[Required] An array of slideshow transitions to play slideshow
                                    $TransitionsOrder: 1,                           //[Optional] The way to choose transition to play slide, 1 Sequence, 0 Random
                                    $ShowLink: true                                    //[Optional] Whether to bring slide link on top of the slider when slideshow is running, default value is false
                                },

                                $BulletNavigatorOptions: {                                //[Optional] Options to specify and enable navigator or not
                                    $Class: $JssorBulletNavigator$,                       //[Required] Class to create navigator instance
                                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                                    $AutoCenter: 0,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                                    $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                                    $Lanes: 1,                                      //[Optional] Specify lanes to arrange items, default value is 1
                                    $SpacingX: 0,                                   //[Optional] Horizontal space between each item in pixel, default value is 0
                                    $SpacingY: 0,                                   //[Optional] Vertical space between each item in pixel, default value is 0
                                    $Orientation: 1                                 //[Optional] The orientation of the navigator, 1 horizontal, 2 vertical, default value is 1
                                },

                                $ArrowNavigatorOptions: {
                                    $Class: $JssorArrowNavigator$,              //[Requried] Class to create arrow navigator instance
                                    $ChanceToShow: 2                                //[Required] 0 Never, 1 Mouse Over, 2 Always
                                }
                            };

                            var jssor_slider2 = new $JssorSlider$("slider2_container", options);

                            //responsive code begin
                            //you can remove responsive code if you don't want the slider scales while window resizes
                            function ScaleSlider() {
                                var parentWidth = jssor_slider2.$Elmt.parentNode.clientWidth;
                                if (parentWidth)
                                    jssor_slider2.$ScaleWidth(Math.min(parentWidth, 1230));
                                else
                                    window.setTimeout(ScaleSlider, 30);
                            }

                            ScaleSlider();

                            $(window).bind("load", ScaleSlider);
                            $(window).bind("resize", ScaleSlider);
                            $(window).bind("orientationchange", ScaleSlider);

                            //responsive code end
                        });
                    </script>
                    <div id="slider2_container" style="position: relative; width: 600px; height: 332px;">
                        <!-- Loading Screen -->
                        <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; background-color: #000; top: 0px; left: 0px; width: 600px; height: 100%;">
                            </div>
                            <div style="position: absolute; display: block; background: url(Resources/StyleSheet/ssc/images/jssor/loading.gif) no-repeat center center; top: 0px; left: 0px; width: 600px; height: 100%;">
                            </div>
                        </div>

                        <!-- Slides Container -->
                        <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 100%; height: 332px; overflow: hidden;">
                            <%--<div>
                            <a href="#"><img u="image" src="Resources/StyleSheet/ssc/dbimg/banner/Collection1.jpg" /></a>
                            <div u=caption t="*" class="captionOrange"  style="position:absolute; left:0px; top: 0px; width:100%; height:30px;"> Bộ sưu tập về tài chính</div>
                        </div>
                        <div>
                            <a href="#"><img u="image" src="Resources/StyleSheet/ssc/dbimg/banner/Collection6.jpg" /></a>
                            <div u=caption t="*" class="captionOrange"  style="position:absolute; left:0px; top: 0px; width:100%; height:30px;"> Bộ sưu tập về kế toán</div>
                        </div>
                        <div>
                            <a href="#"><img u="image" src="Resources/StyleSheet/ssc/dbimg/banner/Siberian_Husky_bi_eyed_Flickr.jpg" /></a>
                            <div u=caption t="*" class="captionOrange"  style="position:absolute; left:0px; top: 0px; width:100%; height:30px;"> Bộ sưu tập về bất động sản</div>
                        </div>
                        <div>
                            <a href="#"><img u="image" src="Resources/StyleSheet/ssc/dbimg/banner/kiem_tra_cau_hinh_may_tinh.jpg" /></a>
                            <div u=caption t="*" class="captionOrange"  style="position:absolute; left:0px; top: 0px; width:100%; height:30px;"> Bộ sưu tập về máy tính</div>
                        </div>--%>
                            <asp:Literal runat="server" ID="lrtCollection"></asp:Literal>
                        </div>
                        <!-- bullet navigator container -->
                        <div u="navigator" class="jssorb01" style="position: absolute; bottom: 16px; right: 10px; display:none;">
                            <!-- bullet navigator item prototype -->
                            <div u="prototype" style="POSITION: absolute; WIDTH: 12px; HEIGHT: 12px; display:none;"></div>
                        </div>
                        <!-- Arrow Left -->
                        <span u="arrowleft" class="jssora05l" style="width: 40px; height: 40px; top: 50%; left: 8px; display:none;"></span>
                        <!-- Arrow Right -->
                        <span u="arrowright" class="jssora05r" style="width: 40px; height: 40px; top: 50%; right: 8px; display:none;"></span>
                    </div>
                </div>
                <div class="two-column-form modul-list" style="padding-top:20px;">
                    <ul>
                        <li>
                            <div class="modul-box clr-steel ">
                                <a href="javascript:parent.gotoShowRecord(10,1);" class=""><span class="icon-book"></span>Sách truyền thống<br /><label runat="server" id="spBook"></label>
                                </a>
                            </div>
                        </li>
                        <li>
                            <div class="modul-box clr-cyan ">
                                <%--<a href="javascript:parent.ShowRecordByItemType(4);" class="">
                                    <span class="icon-laptop"></span>Tài liệu số (Toàn văn)<br />
                                    <label runat="server" id="spEbooks"></label>
                                </a>--%>
                                <a href="javascript:parent.gotoShowRecord(10,32);" class="">
                                    <span class="icon-laptop"></span>Tài liệu số (Toàn văn)<br />
                                    <label runat="server" id="spEbooks"></label>
                                </a>
                            </div>
                        </li>
                        <li>
                            <div class="modul-box clr-pink">
                                <a href="javascript:parent.gotoShowRecord(10,3);" class=""><span class="icon-list"></span>Luận văn<br /><label runat="server" id="spDissertation"></label>
                                </a>
                            </div>
                        </li>
                        <li>
                            <div class="modul-box clr-red">
                                <%--<a href="#" class=""><span class="mif-school"> (0)</span>Ngân hàng đề thi</a>--%>
                                <%--<a href="javascript:parent.gotoShowRecord(11,7);" class=""><span class="icon-newspaper"></span>Ấn phẩm định kỳ<br /><label runat="server" id="spMagazine"></label>--%>
                                <a href="javascript:parent.gotoShowRecord(10,9);" class=""><span class="icon-newspaper"></span>Báo / Tạp chí<br /><label runat="server" id="spMagazine"></label>
                                </a>
                            </div>
                        </li>
                        <li>
                            <div class="modul-box clr-green">
                                <a href="javascript:parent.gotoShowRecord(10,17);" class=""><span class="icon-cone"></span>Giáo trình cấp trường<br /><label runat="server" id="spGTCapTruong"></label>
                                </a>
                            </div>
                            <%--
                            <div class="modul-box clr-green">
                                <a href="javascript:parent.gotoShowRecord(10,23);" class="">
                                    <span class="icon-film"></span>Phim ảnh<br />
                                    <span class="icon-cdrom" style="margin-top:-3px;"><img src="Images/cd-rom.png" alt="" height="55" /></span>CD-Rom<br />
                                    <label runat="server" id="spPicture"></label>
                                </a>
                            </div>
                                --%>
                        </li>

                        <li>
                            <div class="modul-box clr-amber">
                                <a href="javascript:parent.gotoShowRecord(10,16);" class=""><span class="icon-layers-alt"></span>Bài giảng môn học<br /><label runat="server" id="spBGMonHoc"></label>
                                </a>
                            </div>
                            <%--
                            <div class="modul-box clr-amber">
                                <a href="javascript:parent.gotoShowRecord(10,10);" class=""><span class="icon-film"></span>Video<br /><label runat="server" id="spMedia"></label>
                                </a>
                            </div>
                                 --%>
                        </li>

                        <li style="display:none;">
                            <div class="modul-box clr-pink">
                                <a href="javascript:parent.ShowRecordByItemType(3);" class=""><span class="icon-music"></span>Sách nói<br /><label runat="server" id="spAudioEbooks"></label>
                                </a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="main-list web-size ClearFix">
                <div class="two-column">
                    <div class="two-column-form">
                        <h1 class="head-title"><span>Hướng dẫn sử dụng</span></h1>
                        <div class="main-new-list" >
                            <iframe src="Upload/HDSD_TRACUU_OPAC.v1.1.pdf"></iframe>
                            <%--<img src="Images/Working-Time.jpg" alt="" style="width:100%;" />--%>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <h1 class="head-title" ><span>Tài liệu mới nhất</span></h1>
                        <div class="main-new-list" >
                            <ul>
                                <%--<li><h2><span class="icon-book clr-cyan"></span><a href="detail.html">Bí mật toán học / Tuấn Minh biên dịch</a></h2></li>
                            <li><h2><span class="mif-database clr-pink"></span><a href="detail.html">Microsoft SQL Server 2000 unleashed / Ray Rankins, Paul Bertucci, Paul Jensen...</a></h2></li>
                            <li><h2><span class="icon-film clr-green"></span><a href="detail.html">BDigital business : concepts and strategy / Eloise Coupey.</a></h2></li>
                            <li><h2><span class="mif-database clr-pink"></span><a href="detail.html">Social problems : readings with four questions / [edited by] Joel M. Charon,...</a></h2></li>
                            <li><h2><span class="icon-book clr-cyan"></span><a href="detail.html">Security management : an introduction / P.J. Ortmeier.</a></h2></li>--%>
                                <asp:Literal runat="server" ID="ltrTopNewItem"></asp:Literal>
                            </ul>
                        </div>
                   


                        <h1 class="head-title" style="display: none"><a href="#" >Tài liệu mượn nhiều nhất</a></h1>
                        <div class="main-new-list" style="display: none">
                            <ul>
                                <%--<li><h2><span class="icon-book clr-cyan"></span><a href="detail.html">Bí mật toán học / Tuấn Minh biên dịch</a></h2></li>
                            <li><h2><span class="mif-database clr-pink"></span><a href="detail.html">Microsoft SQL Server 2000 unleashed / Ray Rankins, Paul Bertucci, Paul Jensen...</a></h2></li>
                            <li><h2><span class="icon-film clr-green"></span><a href="detail.html">BDigital business : concepts and strategy / Eloise Coupey.</a></h2></li>
                            <li><h2><span class="mif-database clr-pink"></span><a href="detail.html">Social problems : readings with four questions / [edited by] Joel M. Charon,...</a></h2></li>
                            <li><h2><span class="icon-book clr-cyan"></span><a href="detail.html">Security management : an introduction / P.J. Ortmeier.</a></h2></li>--%>
                                <asp:Literal runat="server" ID="ltrTopBestView"></asp:Literal>
                            </ul>
                        </div>

                        <div class="div-blank" style="display: none"></div>



                        <h1 class="head-title" style="display: none"><a href="OWebUseful.aspx">Liên kết tham khảo</a></h1>
                        <div class="link-box ClearFix" style="display: none">
                            <a href="OWebUseful.aspx">
                                <p>
                                    <img src="Resources/StyleSheet/ssc/dbimg/WebsiteLink.png" alt="" />Liên kết này liệt kê danh sách Website hữu dụng trong nước và ngoài nước giúp cho bạn đọc tìm kiếm thông tin dễ dàng, thuận tiện hơn,...: Công cụ tìm tiếm, tổ chức chính phủ, cơ quan nhà nước, tổ chức chính trị, tổ chức quốc tế, tổ chức xã hội, văn bản pháp luật, báo chí, các viện và trường học, trung tâm thông tin và thư viện, thông tin tham khảo, thông tin về thành phố Hồ Chí Minh, các tỉnh thành khác,...
                                </p>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="div-blank"></div>
            <div class="main-list web-size ClearFix">
                <h1 class="head-title"><a href="ONews.aspx">Tin tức</a></h1>
                <div class="list-news">
                    <div class="row-group">
                        <%--<li>
                        <img src="Resources/StyleSheet/ssc/dbimg/news.jpg" alt="News Name"/>
                        <h2><a href="newsdetail.html">Thư viện Quốc gia Việt Nam tổ chức Tập huấn sử dụng Khung phân loại thập phân Dewey - Ấn bản 23 tiếng Việt</a></h2>
                    </li>
                    <li><h2><a href="newsdetail.html">Hội sách Hà Nội năm 2014</a></h2></li>
                    <li><h2><a href="newsdetail.html">Tầm quan trọng của Thư viện</a></h2></li>--%>
                        <asp:Literal runat="server" ID="ltrNews"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="div-blank"></div>

            <div class="main-adver web-size" style="display:none;">
                <h1 class="head-title"><a href="#">Danh mục tài liệu</a></h1>
                <telerik:RadSiteMap runat="server" ID="SiteMap1" OnNodeDataBound="SiteMap1_NodeDataBound"
                    DataFieldID="ID" DataFieldParentID="ParentID" DataTextField="Caption" DataValueField="ID" MaxDataBindDepth="3" DefaultLevelSettings-ListLayout-RepeatColumns="4" ShowNodeLines="true" Skin="Silk">
                    <LevelSettings>
                        <telerik:SiteMapLevelSetting Level="0" Layout="List" ImageUrl="~/Images/Icons/createfolder.gif">
                        </telerik:SiteMapLevelSetting>
                        <telerik:SiteMapLevelSetting Level="1" Layout="List">
                        </telerik:SiteMapLevelSetting>
                    </LevelSettings>
                </telerik:RadSiteMap>
            </div>
            <div class="main-adver web-size" style="display:none;">
                <script src="Resources/StyleSheet/ssc/java/owl/owl.carousel.js" type="text/javascript"></script>
                <script type="text/javascript">
                    $(document).ready(function () {

                        $("#owl-example").owlCarousel({

                            autoPlay: 3000, //Set AutoPlay to 3 seconds

                            items: 4,
                            itemsDesktop: [1199, 3],
                            itemsDesktopSmall: [979, 3]

                        });

                    });
                </script>
                <div id="owl-example" class="owl-carousel">
                    <div class="item">
                        <a target="_blank" href="http://tracuu.thuvientphcm.gov.vn/OIndex.aspx?Site=1">
                            <img src="Resources/Images/TVKHTH.jpg" alt="Adver name" /></a>
                            <p style="text-align:center">Thư viện Khoa Học Tổng Hợp</p>
                    </div>
                    <div class="item">
                        <a target="_blank" href="http://opac.vaa.edu.vn/">
                            <img src="Resources/Images/HVHK.jpg" alt="Adver name" /></a>
                        <p style="text-align:center">Học viện Hàng Không Việt Nam</p>
                    </div>
                    <div class="item">
                        <a target="_blank" href="http://opac.thessc.vn/">
                            <img src="Resources/StyleSheet/ssc/dbimg/huongnghiep.jpg" alt="Adver name" /></a>
                            <p style="text-align:center">Dự án thẻ học đường SSC<br />(Sở Giáo Dục TPHCM)</p>
                    </div>
                    <div class="item">
                        <a target="_blank" href="http://113.161.196.135:8081/">
                            <img src="Resources/Images/TVVL.jpg" alt="Adver name" /></a>
                        <p style="text-align:center">Thư viện Tỉnh Vĩnh Long</p>
                    </div>
                    <div class="item">
                        <a target="_blank" href="http://www.daitruongphat.com/">
                            <img src="Resources/Images/DTP.jpg" alt="Adver name" /></a>
                        <p style="text-align:center">Tập đoàn giáo dục Đại Trường Phát</p>
                    </div>
                    <div class="item">
                        <a target="_blank" href="http://tracuu.thuvientphcm.gov.vn/OIndex.aspx?Site=1">
                            <img src="Resources/Images/TVKHTH.jpg" alt="Adver name" /></a>
                            <p style="text-align:center">Thư viện Khoa Học Tổng Hợp</p>
                    </div>
                    <div class="item">
                        <a target="_blank" href="http://opac.vaa.edu.vn/">
                            <img src="Resources/Images/HVHK.jpg" alt="Adver name" /></a>
                        <p style="text-align:center">Học viện Hàng Không Việt Nam</p>
                    </div>
                </div>
            </div>
        </div>


        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
        <div style="display: none; height: 0px;">
            <span id="spDescriptionCollection" runat="server">Báo in/Tạp chí</span>
        </div>
    </form>
</body>
</html>
