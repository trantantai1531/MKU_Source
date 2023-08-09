<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OView.aspx.vb" Inherits="eMicLibOPAC.WebUI.OView" %>
<%@ Register Src="~/s3capcha/s3capcha.ascx" TagName="s3capcha" TagPrefix="uc1" %>
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
    <script src="js/ui/jquery.easing.1.3.min.js"></script>--%>
    <link href="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <link href="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <link href="Css/jPlayer/jplayer.blue.monday.min.css" rel="stylesheet" type="text/css" />
    <link href="Css/lightgallery/lightgallery.min.css" type="text/css" rel="stylesheet" />
    <script language="JavaScript" type="text/javascript" src="Viewer/jPlayer/jquery.jplayer.min.js"></script>
    <script language="JavaScript" type="text/javascript" src="Viewer/jPlayer/jplayer.playlist.min.js"></script>
    <%--<script language="JavaScript" type="text/javascript" src="Viewer/Plugin/swfobject.js"></script>    
    <script language="JavaScript" type="text/javascript" src="Viewer/Plugin/swfmacmousewheel.js"></script> --%>
    
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
    </style>
    <script src="js/OPubup.js"></script>
    <script src="js/metro.min.js"></script>
    <script src="js/docs.js"></script>--%>
    <script type="text/javascript">
        var viewerWidth = "100%";
        var viewerHeight = "80%"; // "80%";
        function writeMLAudio(pathxml) {
        }

        function writeMLpicture(pathxml) {
        }

        function writeMLmeida(pathxml, multi) {
        }


        function showNotify(type, mes) {
            //Type: 1:info, 2:fail, 3:success
            switch (type) {
                case 1:
                    $.Notify({ style: { background: '#1ba1e2', color: 'white' }, caption: 'Thông báo...', content: mes });
                    break;
                case 2:
                    $.Notify({ style: { background: 'red', color: 'white' }, caption: 'Thông báo...', content: mes });
                    break;
                case 3:
                    $.Notify({ style: { background: 'green', color: 'white' }, caption: 'Thông báo...', content: mes });
                    break;
                default:
                    $.Notify({ content: mes });
                    break;
            }
        }

        function showAlert(val) {
            //window.scrollTo(0, 10);
            var spAlert = document.getElementById('spAlert');
            spAlert.innerHTML = val;
            $('#popupAlert').bPopup();
        }
        function closeAlert() {
            var bPopup = $('#popupAlert').bPopup();
            bPopup.close();
        }

        function onRaiseComment() {
            var divRating = $('#divRating').data('rating');
            if (divRating) {
                if (divRating.value() == '') {
                    var spCommentEmpty = document.getElementById('spCommentEmpty');
                    parent.showNotify('warning', spCommentEmpty.innerHTML);
                    return;
                }
            }
            var txtComment = document.getElementById('txtComment');
            if (txtComment.value.toString().trim() == '') {
                var spCommentContentEmpty = document.getElementById('spCommentContentEmpty');
                //showAlert(spCommentContentEmpty.innerHTML);
                parent.showNotify('warning', spCommentContentEmpty.innerHTML);
                return;
            }
            var hidComment = document.getElementById('hidComment');
            if (hidComment) {
                hidComment.value = txtComment.value;
            }
            /*
            var hidRating = document.getElementById('hidRating');
            var intRate = hidRating.value;
            if (intRate == 0) {
                var spCommentEmpty = document.getElementById('spCommentEmpty');
                //showAlert(spCommentEmpty.innerHTML);
                parent.showNotify('warning', spCommentEmpty.innerHTML);
                return;
            }*/
            var hidRating = document.getElementById('hidRating');
            if (hidRating) {
                hidRating.value = divRating.value();
            }

            var bolUser = parent.checkUser();
            if (bolUser) {
                onSubmitComment();
            }
            else {
                parent.showLoginComment();
            }
        }
        function onSubmitComment() {
            var CommentOnSubmit = document.getElementById('CommentOnSubmit');
            CommentOnSubmit.click();
        }

        function gotoShowRecord(dicId, BrowseId) {
            top.location.href = "OShow.aspx?DicID=" + dicId.toString() + "&BrowseId=" + BrowseId.toString();
        }
        function showComment(pg) {
            var hidCurrentPage = document.getElementById('hidCurrentPage');
            hidCurrentPage.value = pg;
            var raiseShowComment = document.getElementById('raiseShowComment');
            raiseShowComment.click();
            parent.showWaiting();
        }

        $(document).ready(function () {

            var paraFileType = "<%=Request("fileType")%>";

            if (paraFileType == 3) {

                var spViewerMedia = document.getElementById("spViewerMedia");
                var spViewerAudio = document.getElementById("spViewerAudio");
                var spViewerPiture = document.getElementById("spViewerPiture");
                if (spViewerMedia) {
                    spViewerMedia.style.display = "none";
                }
                if (spViewerPiture) {
                    spViewerPiture.style.display = "none";
                }
                if (spViewerAudio) {
                    spViewerAudio.style.display = "inline";
                }

                var cssSelector = {
                    jPlayer: '#emiclib_audio_jplayer',
                    cssSelectorAncestor: '#emiclib_audio_jplayer_container'
                };
                var playlist = [];
                var options = {
                    swfPath: '../../Javascript/jPlayer',
                    supplied: 'oga, mp3',
                    volume: '1',
                    wmode: 'window',
                    useStateClassSkin: true,
                    autoBlur: false,
                    smoothPlayBar: true,
                    keyEnabled: true,
                    playlistOptions: { autoPlay: true }
                };
                var myPlaylist = new jPlayerPlaylist(cssSelector, playlist, options);
                var paraItemID = "<%=Request("ItemID")%>";

                var strServiceURL = "<%= Page.ResolveUrl("~/eService.asmx/getFiles")%>";
                $.ajax({
                    url: strServiceURL,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    data: { ItemID: paraItemID },
                    dataType: 'json',
                    success: function (json) {
                        console.log(json.length);
                        if (json.length > 0)
                            var lbltitle = $("#lbltitle");
                        var strDescription = '';
                        var strTitle = '';
                        var strMp3 = '';
                        var strFileName = '';
                        var intTotal = json.length;
                        var intAllowPercent = "<%=fGlbUserViewOfDoc%>";
                        var intAllowPercentDownload = "<%=fDownload%>";
                        var intAllowFiles = intTotal * intAllowPercent / 100;
                        var intAllowFilesDownload = intTotal * intAllowPercentDownload / 100;

                        for (i = 0; i < json.length; i++) {
                            strDescription = '';
                            strTitle = '';
                            strMp3 = '';
                            strFileName = '';
                            if (i >= intAllowFiles) {
                                strTitle = lbltitle.text() + " <div style='font-weight:bold;color: Red;'>(*)</div>";
                            }
                            else {
                                if (json[i].description) {
                                    strDescription = json[i].description;
                                    strTitle = strDescription;
                                }
                                else {
                                    strTitle = lbltitle.text();
                                }
                                strMp3 = json[i].file;
                                strFileName = json[i].downloadFile;
                                if (i < intAllowFilesDownload) {
                                    //console.log('a' + strMp3);
                                    strTitle = strTitle + '&nbsp;<span class="jp-playlist-item-free"><a  href="' + strMp3 + '" tabindex="1" target="_blank">(Tải về)</a></span>';
                                }
                            }

                            myPlaylist.add({
                                title: (i + 1) + '. ' + strTitle,
                                mp3: strMp3
                            })
                            //console.log(json[i].file + ' - ');
                        }
                        myPlaylist.play();
                    },
                    error: function (xhr, status, error) {
                        //alert('L\u1ed7i k\u1ebft n\u1ed1i d\u1eef li\u1ec7u.');
                        //console.log(error);
                    }
                });
            }
            else if (paraFileType == 2) {
                var spViewerMedia = document.getElementById("spViewerMedia");
                var spViewerAudio = document.getElementById("spViewerAudio");
                var spViewerPiture = document.getElementById("spViewerPiture");
                if (spViewerPiture) {
                    spViewerPiture.style.display = "none";
                }
                if (spViewerAudio) {
                    spViewerAudio.style.display = "none";
                }
                if (spViewerMedia) {
                    spViewerMedia.style.display = "inline";
                }

                var cssSelector = {
                    jPlayer: '#emiclib_meida_jplayer',
                    cssSelectorAncestor: '#emiclib_meida_jplayer_container'
                };
                var playlist = [];
                var options = {
                    swfPath: '../../Javascript/jPlayer',
                    supplied: 'webmv, ogv, m4v',
                    volume: '1',
                    wmode: 'window',
                    useStateClassSkin: true,
                    autoBlur: false,
                    smoothPlayBar: true,
                    keyEnabled: true,
                    playlistOptions: { autoPlay: true }
                };
                var myPlaylist = new jPlayerPlaylist(cssSelector, playlist, options);
                var paraItemID = "<%=Request("ItemID")%>";
                var strServiceURL = "<%= Page.ResolveUrl("~/eService.asmx/getFiles")%>";
                $.ajax({
                    url: strServiceURL,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    data: { ItemID: paraItemID },
                    dataType: 'json',
                    success: function (json) {
                        //console.log(json.length);
                        if (json.length > 0)
                            var lbltitle = $("#lbltitle");
                        var strDescription = '';
                        var strTitle = '';
                        var strType = '';
                        var strMp4 = '';
                        var strFileName = '';
                        var intTotal = json.length;
                        var intAllowPercent = "<%=fGlbUserViewOfDoc %>";
                        var intAllowPercentDownload = "<%=fDownload%>";
                        var intAllowFiles = intTotal * intAllowPercent / 100;
                        var intAllowFilesDownload = intTotal * intAllowPercentDownload / 100;

                        for (i = 0; i < json.length; i++) {
                            strDescription = '';
                            strTitle = '';
                            strMp4 = '';
                            strType = '';
                            strFileName = '';
                            if (json[i].type) {
                                strType = json[i].type;
                            }
                            if (i >= intAllowFiles) {
                                strTitle = lbltitle.text() + " <div style='font-weight:bold;color: Red;'>(*)</div>";
                            }
                            else {
                                if (json[i].description) {
                                    strDescription = json[i].description;
                                    strTitle = strDescription;
                                }
                                else {
                                    strTitle = lbltitle.text();
                                }
                                strMp4 = json[i].file;
                                strFileName = json[i].downloadFile;
                                if (strType == '') {
                                    if (i < intAllowFilesDownload) {
                                        strTitle = strTitle + '&nbsp;<span class="jp-playlist-item-free"><a  href="' + strMp4 + '" tabindex="1"  target="_blank">(Tải về)</a></span>';
                                    }
                                }
                            }

                            myPlaylist.add({
                                type: strType,
                                title: (i + 1) + '. ' + strTitle,
                                m4v: strMp4
                            })
                        }
                        myPlaylist.play();
                    },
                    error: function (xhr, status, error) {
                        //alert('L\u1ed7i k\u1ebft n\u1ed1i d\u1eef li\u1ec7u.');
                        //console.log(error);
                    }
                });
            }
            else if (paraFileType == 1) {
                var spViewerMedia = document.getElementById("spViewerMedia");
                var spViewerAudio = document.getElementById("spViewerAudio");
                var spViewerPiture = document.getElementById("spViewerPiture");
                if (spViewerPiture) {
                    spViewerPiture.style.display = "inline";
                }
                if (spViewerAudio) {
                    spViewerAudio.style.display = "none";
                }
                if (spViewerMedia) {
                    spViewerMedia.style.display = "none";
                }

                var paraItemID = "<%=Request("ItemID")%>";
                var strServiceURL = "<%= Page.ResolveUrl("~/eService.asmx/getFiles")%>";
                $.ajax({
                    url: strServiceURL,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    data: { ItemID: paraItemID },
                    dataType: 'json',
                    success: function (json) {
                        if (json.length > 0)
                            var strData = '';
                        var intTotal = json.length;
                        var intAllowPercent = "<%=fGlbUserViewOfDoc %>";
                        var intAllowFiles = intTotal * intAllowPercent / 100;
                        for (i = 0; i < json.length; i++) {
                            strData = '';
                            if (i > intAllowFiles) {
                                strData = '<a href="<%= Page.ResolveUrl("~/Images/Account/permission.png")%>">';
                                    strData = strData + '<img src="<%= Page.ResolveUrl("~/Images/Account/permission.png")%>" class="img-responsive"/>';
                                    strData = strData + '</a>';
                                }
                                else {
                                    strData = '<a href="' + json[i].file + '">';
                                    strData = strData + '<img src="' + json[i].file + '" class="img-responsive" style="width:250px;height:150px; padding:5px;"/>';
                                    strData = strData + '</a>';
                                }
                                /*
                                if (i>intAllowFiles){
                                    strTitle = lbltitle.text() + " <div style='font-weight:bold;color: Red;'>(*)</div>" ;
                                }
                                else {
                                    if (json[i].description){
                                        strDescription = json[i].description;
                                        strTitle = strDescription;
                                    }
                                    else {
                                        strTitle = lbltitle.text();
                                    }
                                    strMp3 = json[i].file;
                                    strTitle = strTitle +'&nbsp;<span class="jp-playlist-item-free"><a target="_blank" href="' + strMp3 + '" tabindex="1">(Tải về)</a></span>';
                                }*/
                                $('#lightgallery').append(strData);
                            }
                        //$('#lightgallery').lightGallery();

                        $('#lightgallery').lightGallery({
                            thumbnail: true,
                            animateThumb: true,
                            showThumbByDefault: true
                        });
                    },
                    error: function (xhr, status, error) {
                        //alert('L\u1ed7i k\u1ebft n\u1ed1i d\u1eef li\u1ec7u.');
                        //console.log(error);
                    }
                });
                }
        });

    </script>
</head>
<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px" id="top">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="web-size ClearFix book-detail">
                 <div class="col-right-7 item-detail">
                        <div id="divViewerAudio" style="width: 100%;">
                            <table width="100%" class="panel_view" cellpadding="3px" cellspacing="0px">
                                <tr>
                                    <td>
                                        <div class="row_ebooks_odd">
                                            <div class="cell_ebooks">
                                                <div class="thumb_ebook">
                                                    <asp:Literal ID="imgTitle" runat="server"></asp:Literal>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                    <td style="width: 100%; height: 100%;vertical-align:text-top;">
                                        <div id="spViewerAudio" style="vertical-align:text-top;">
                                            <div style="overflow-y: scroll; height:215px;margin-top:3px;vertical-align:text-top;" id="spFlash">
                                                <div id="emiclib_audio_jplayer" class="jp-jplayer">
                                                </div>
                                                <div id="emiclib_audio_jplayer_container" class="jp-audio" role="application" aria-label="media player">
                                                    <div class="jp-type-playlist">
                                                        <div class="jp-gui jp-interface">
                                                            <div class="jp-controls">
                                                                <button class="jp-previous" role="button" tabindex="0">
                                                                    previous</button>
                                                                <button class="jp-play" role="button" tabindex="0">
                                                                    play</button>
                                                                <button class="jp-next" role="button" tabindex="0">
                                                                    next</button>
                                                                <button class="jp-stop" role="button" tabindex="0">
                                                                    stop</button>
                                                            </div>
                                                            <div class="jp-progress">
                                                                <div class="jp-seek-bar">
                                                                    <div class="jp-play-bar">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="jp-volume-controls">
                                                                <button class="jp-mute" role="button" tabindex="0">
                                                                    mute</button>
                                                                <button class="jp-volume-max" role="button" tabindex="0">
                                                                    max volume</button>
                                                                <div class="jp-volume-bar">
                                                                    <div class="jp-volume-bar-value">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="jp-time-holder">
                                                                <div class="jp-current-time" role="timer" aria-label="time">
                                                                    &nbsp;</div>
                                                                <div class="jp-duration" role="timer" aria-label="duration">
                                                                    &nbsp;</div>
                                                            </div>
                                                            <div class="jp-toggles">
                                                                <button class="jp-repeat" role="button" tabindex="0">
                                                                    repeat</button>
                                                            </div>
                                                        </div>
                                                        <div class="jp-playlist">
                                                            <ul>
                                                                <li>&nbsp;</li>
                                                            </ul>
                                                        </div>
                                                        <div class="jp-no-solution">
                                                            <span>Update Required</span> To play the media you will need to either update your
                                                            browser to a recent version or update your <a href="http://get.adobe.com/flashplayer/"
                                                                target="_blank">Flash plugin</a>.
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="spViewerMedia" style="vertical-align:text-top;" class="viewMediaForm">
                                            <div id="emiclib_meida_jplayer_container" class="jp-video jp-video-420p" role="application"
                                                aria-label="media player">
                                                <div class="jp-type-playlist">
                                                    <div id="emiclib_meida_jplayer" class="jp-jplayer">
                                                    </div>
                                                    <div class="jp-gui">
                                                        <div class="jp-video-play">
                                                            <button class="jp-video-play-icon" role="button" tabindex="0">
                                                                play</button>
                                                        </div>
                                                        <div class="jp-interface">
                                                            <div class="jp-progress">
                                                                <div class="jp-seek-bar">
                                                                    <div class="jp-play-bar">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="jp-current-time" role="timer" aria-label="time">
                                                                &nbsp;</div>
                                                            <div class="jp-duration" role="timer" aria-label="duration">
                                                                &nbsp;</div>
                                                            <div class="jp-controls-holder">
                                                                <div class="jp-controls">
                                                                    <button class="jp-previous" role="button" tabindex="0">
                                                                        previous</button>
                                                                    <button class="jp-play" role="button" tabindex="0">
                                                                        play</button>
                                                                    <button class="jp-next" role="button" tabindex="0">
                                                                        next</button>
                                                                    <button class="jp-stop" role="button" tabindex="0">
                                                                        stop</button>
                                                                </div>
                                                                <div class="jp-volume-controls">
                                                                    <button class="jp-mute" role="button" tabindex="0">
                                                                        mute</button>
                                                                    <button class="jp-volume-max" role="button" tabindex="0">
                                                                        max volume</button>
                                                                    <div class="jp-volume-bar">
                                                                        <div class="jp-volume-bar-value">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="jp-toggles">
                                                                    <button class="jp-repeat" role="button" tabindex="0">
                                                                        repeat</button>
                                                                    <button class="jp-full-screen" role="button" tabindex="0">
                                                                        full screen</button>
                                                                </div>
                                                            </div>
                                                            <div class="jp-details">
                                                                <div class="jp-title" aria-label="title">
                                                                    &nbsp;</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="jp-playlist">
                                                        <ul>
                                                            <!-- The method Playlist.displayPlaylist() uses this unordered list -->
                                                            <li>&nbsp;</li>
                                                        </ul>
                                                    </div>
                                                    <div class="jp-no-solution">
                                                        <span>Update Required</span> To play the media you will need to either update your
                                                        browser to a recent version or update your 
                                                        <a href="http://get.adobe.com/flashplayer/"
                                                            target="_blank">Flash plugin</a>.
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="spViewerPiture" style="width: 100%;">
                                            <table width="100%" class="panel_view" cellpadding="3px" cellspacing="0px">
                                                <tr>
                                                    <td align="center" style="width: 100%; height: 100%;">
                                                        <div id="spViewer">
                                                            <div style="overflow-y: scroll; height: 200px;">
                                                                <div id="lightgallery">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    <div class="div-blank"></div>
                    <div class="detail-head ClearFix">
	                    <asp:Literal runat="server" ID="ltrRelationWord"></asp:Literal>
                    </div>  
                    <div class="detail-comment">
                        <div class="comment-detail">                       
                            <a name="toComment" id="toComment" style="display: block;"></a>                             
                            <div class="detail-rating ClearFix">
                                <p style="vertical-align:top;">Đánh giá :</p>
                                <div class="rating" data-role="rating" id="divRating" data-show-score="false"></div>
                            </div>
                        
                            <div class="detail-control">
                                <div class="input-control">
                                    <textarea placeholder="Viết bình luận" class="tb-area" id="txtComment"></textarea>
                                </div>
                                <uc1:s3capcha ID="s3capcha1" runat="server" />  
                                <div class="button-control">
                                    <div class="button-form">
                                        <input type="button" class="btn-icon" onclick="onRaiseComment(); return false;">
                                        <div class="btn-value"><span class="mif-bubbles" ></span>Gửi bình luận</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <a name="toPageComment" id="toPageComment" style="display: block;"></a>  
                        <div class="divPage">
                            <ul class="ClearFix">
                                <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                            </ul>
                        </div>
                        <div class="detail-feed">
                            <asp:Literal runat="server" ID="ltrComment"></asp:Literal>
                        </div>    
                        <div class="divPage">
                	        <ul class="ClearFix">
                                 <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                            </ul>
                        </div>  
                     </div>
                 </div>       
                 <div class="col-left-3 page-list">
                    <div id="CollapsiblePanel1" class="CollapsiblePanel" runat="server">
                        <div class="CollapsiblePanelTab" tabindex="0"  id="divRelationDocument" runat="server">Tài liệu liên quan</div>
                        <div class="CollapsiblePanelContent">
                            <div class="list-book">
                        	    <ul class="ClearFix">
                                    <asp:Literal runat="server" ID="ltrBookList"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="CollapsiblePanel2" class="CollapsiblePanel" runat="server">
                        <div class="CollapsiblePanelTab" tabindex="0"  id="divRelationAuthor" runat="server">Tài liệu cùng tác giả</div>
                        <div class="CollapsiblePanelContent">
                            <div class="list-book">
                        	    <ul class="ClearFix">
                                    <asp:Literal runat="server" ID="ltrRelationAuthor"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>         
            </div>            
        </div>
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
        <div style="position:absolute;top:0px;left:0px;visibility:hidden;">
            <asp:Label ID="lbltitle" runat="server" Text="Nhan đề"></asp:Label>
            <input type="hidden" id="hidComment" runat="server"/>
            <input type="hidden" id="hidRating" value="3" name="hidRating" runat="server" />
            <button id="CommentOnSubmit" name="CommentOnSubmit" runat="server" ></button>  
            <asp:Button runat="server" ID="raiseShowComment"  Text="raiseShowComment" CausesValidation="false"/>  
            <span id="spRecordItem" runat="server">Mục</span>
            <span id="spRecordTo" runat="server">đến</span>
            <span id="spRecordOf" runat="server">của</span>
            <span id="spPreviousPage" runat="server">Trang trước</span>
            <span id="spNextPage" runat="server">Trang tiếp</span> 
            <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
            <span id="spSaveList" runat="server">Lưu danh sách</span>
            <span id="spCancelList" runat="server">Hủy danh sách</span>
            <span id="spMXG" runat="server">Ký hiệu</span>
            <span id="spAudiobook" runat="server">Sách nói</span> 
            <span id="spMedia" runat="server">Phim ảnh</span> 
            <span id="spPicture" runat="server">Hình ảnh</span> 
            <span id="spCapchaInfo" runat="server">Mã xác nhận chọn không đúng. Bạn vui lòng chọn lại.</span> 
            <span id="spCommentSuccess" runat="server">Gửi bình luận thành công.</span> 
            <span id="spCommentFail" runat="server">Gửi bình luận không thành công.</span> 
            <span id="spEDATAContent" runat="server">Đọc nội dung</span> 
            <span id="spEDATA" runat="server">Dữ liệu điện tử</span>
            <span id="spItemType" runat="server">Dạng tài liệu</span> 
            <span id="spISSN" runat="server">ISSN</span>         
            <span id="spAuthor" runat="server">Tác giả</span>
            <span id="spPublisher" runat="server">Nhà xuất bản</span>
            <span id="spPhysicalInfo" runat="server">Mô tả vật lý</span>
            <span id="spPublisherInfo" runat="server">Thông tin xuất bản</span>
            <span id="spKeyword" runat="server">Từ khóa</span>
            <span id="spSubjectHeading" runat="server">Tiêu đề đề mục</span>
            <span id="spDDC" runat="server">DDC</span>
            <span id="spNLM" runat="server">NLM</span>
            <span id="spSeries" runat="server">Tuyển tập (Series)</span>
            <span id="spRelatedWord" runat="server">Mục từ truy cập</span>
            <input id="hidSearchContent" type="hidden" value="" runat="server" />
           <input type="hidden" id="hidPageNo" runat="server" value="1" />
           <input id="hidItemID" type="hidden" name="hidItemID" runat="server" />
           <span id="spAddToMyList" runat="server">Thêm vào danh sách của tôi</span>
            <span id="spInMyList" runat="server">Đã trong danh sách của tôi</span>
            <input id="hidMyListIds" type="hidden" value="" runat="server" />
            <span id="spMyListTitle" runat="server">Tiêu đề</span>
            <span id="spNoFound" runat="server">Không có thông tin</span>
            <span id="spCommentEmpty" runat="server">Đánh giá là rỗng. Vui lòng đánh dấu chọn biểu tượng ngôi sao để đánh giá về tài liệu này.</span>
            <span id="spCommentContentEmpty" runat="server">Bình luận là rỗng. Vui lòng chia sẻ vài dòng suy nghĩ của bạn về tài liệu này.</span>
            <div id="myList" style="position: fixed; top: 65px; z-index: 100;cursor:pointer;" class="panel">
                <div class="panel-header bg-darkRed fg-white text-center"  style="cursor:pointer;">
                    <span id="Span1" runat="server" class="line-height" style="font-size:medium;">Danh sách của tôi</span>
                </div>
                <div class="panel-content" id="cart" style="margin-top:-2px;">
                    <div class="grid no-margin">
                        <div class="row text-center">
                            <span id="spMyList" runat="server" class="line-height"><strong>Tiêu đề: 0</strong></span>
                        </div>
                        <div class="row" style="z-index:-1;">
                            <img src="images/icons/Drag-and-Drop.png"/>
                        </div>
                    </div>
                </div>
            </div>
            
            <div id="popupAlert" class="bMulti" style="width:250px;height:150px;">
                <span class="bt b-close"><span>X</span></span> 
                <h4 style="text-align:justify;line-height:150%;">
                    <span class="icon-warning" style="background: red;color: white;padding: 10px;border-radius: 50%"></span>   
                    <span id="spAlert" class="list-subtitle" runat="server">Đăng nhập</span>
                </h4>   
                <hr />
                <br />
                <button class="image-button bg-darkGreen fg-white image-left place-right" onclick="closeAlert();">
                    Đóng
                    <i class="icon-exit bg-green fg-white"></i>
                </button>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1");
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    </script>
    <script language="JavaScript" type="text/javascript" src="JS/picturefill.min.js"></script>
    <script language="JavaScript" type="text/javascript" src="JS/lightgallery-all.min.js"></script>
    <script language="JavaScript" type="text/javascript" src="JS/jquery.mousewheel.min.js"></script>
    <style>
        /*.jp-video-270p {
            width: 90%;
        }

        .viewMediaForm {
            width: 100%;
        }

        .jp-jplayer {
            width: 90% !important;
            height: 450px !important;
        }

        .jp-video-play-icon {
            margin-top: -130px !important;
        }

        .emiclib_meida_jplayer {
            width: 100% !important;
            height: 450px !important;
        }

        .jp-video {
            width: 100% !important;
            height: 450px !important;
        }*/
        /*#emiclib_meida_jplayer{
            width:100%!important;
            height:390px!important;
        }
        #emiclib_meida_jplayer_container{
            width:90%!important;
        }
        #jp_poster_0 #jp_video_0{
            width:100%!important;
            height:390px!important;
        }*/
    </style>
    
</body>
</html>
