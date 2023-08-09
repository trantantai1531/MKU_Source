<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OViewBook.aspx.vb" Inherits="eMicLibOPAC.WebUI.OViewBook" %>
<%@ Register Src="~/s3capcha/s3capcha.ascx" TagName="s3capcha" TagPrefix="uc1" %>
<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>
<!DOCTYPE html>
<html>
   <head>
    <title>Trường Đại Học Cửu Long</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <meta property="og:url" itemprop="url" content="<%=HttpUtility.UrlEncode(Request.Url.ToString()) %>" />
    <meta property="og:type" content="website" />
    <meta property="og:image" itemprop="thumbnailUrl" content="<%=HttpUtility.UrlEncode(strUrlImage.Trim())%>" />
    <meta property="og:title" content="<%=strTitle.Trim()%>" />
    <meta property="og:site_name" content="<%=strTitle.Trim() %>" />

    <%--<link href="Resources/StyleSheet/ssc/images/design/ssc-icon.png" rel="shortcut icon" />--%>
       <link href="Images/favicon-32x32.png" rel="shortcut icon" />
    <link href="Resources/StyleSheet/ssc/styles/default.css" type="text/css" rel="StyleSheet" />
    <link href="Resources/StyleSheet/ssc/styles/main.css" type="text/css" rel="StyleSheet" />
    <link href="Resources/StyleSheet/ssc/styles/iconFont.css" type="text/css" rel="StyleSheet" />
    <link href="Resources/StyleSheet/ssc/styles/metro-icons.css" type="text/css" rel="StyleSheet" />
    <link href="Resources/StyleSheet/ssc/styles/color.css" type="text/css" rel="StyleSheet" />
    <link href="Resources/StyleSheet/magnific/magnific-popup.css" type="text/css" rel="StyleSheet" />
    <link href="Resources/StyleSheet/ssc/styles/media.css" type="text/css" rel="StyleSheet" media="all" />
    <script type="text/javascript" src="Resources/StyleSheet/ssc/java/googleajax-jquery-ui.min-1.8.2.js"></script>
    <script type="text/javascript" src="Resources/StyleSheet/ssc/java/jssor/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="JS/magnific/jquery.magnific-popup.min.js"></script>
    <script type="text/javascript" src="Resources/StyleSheet/ssc/java/metro.js"></script>

    <link href="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <link href="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>

    <script type="text/javascript" src="Viewer/Plugin/swfobject.js"></script>    
    <script type="text/javascript" src="Viewer/Plugin/swfmacmousewheel.js"></script> 
    <style type="text/css">  
        iframe {
		    display: block;       /* iframes are inline by default */
		    border: none;         /* Reset default border */
		    height: 600px;        /* Viewport-relative units */
		    width: 100%;
	    }
    </style> 
    <script type="text/javascript">
        var viewerWidth = "100%";
        var viewerHeight = "700px";
        var jFileId = 0;
        function writeMLbook(pathxml, pageNo, searchText, langcodePath) {
            var flashvars = {
                doc_url: pathxml,
                pageno: pageNo,
                searchtext: searchText,
                langcode: langcodePath
            };
            var params = {
                menu: "false",
                bgcolor: '#efefef',
                allowFullScreen: 'true',
                wmode: 'transparent'
            };
            var attributes = {
                id: 'Viewer',
                name: 'Viewer'
            };
            swfobject.embedSWF('Viewer/MLbook.swf', 'spViewer', viewerWidth, viewerHeight, '10.0',
                        'Viewer/Plugin/expressinstall.swf', flashvars, params, attributes);
            swfmacmousewheel.registerObject(attributes.id);

            if (searchText) {
                searchGotoPages(pageNo, searchText);
            }
        }

        function MLbook(docid, pageNo, fileId) {
              var pathURL = 'OViewer.aspx?DocId=' + docid + '&Page=' + pageNo + '&fileId=' + fileId;
              document.getElementById("ifrm1").src = pathURL;
          }

        function SetVar(fileId) {
            jFileId = fileId;
        }
        function gotoPage(fileId, pageno) {
            if (jFileId == fileId) {
                if (pageno > 0) {
                    linkPageViewer(pageno);
                }
            }
            else {
                var hidPageNo = document.getElementById("hidPageNo");
                if (hidPageNo) {
                    hidPageNo.value = pageno;
                }
            }
        }
        function linkPageViewer(pageno) {
            /*var flash;
            flash = getFlashMovieObject("Viewer");
            if (flash) {
                flash.GotoPages(pageno);//call to flash
            }*/
            searchGotoPages(pageno,"");
        }
        function getFlashMovieObject(movieName) {
            if (window.document[movieName]) {
                return window.document[movieName];
            }

            if (document.embeds && document.embeds[movieName]) {
                return document.embeds[movieName];
            }
            else {
                return document.getElementById(movieName);
            }
        }
        function setIframe() {
            var hidItemID = document.getElementById("hidItemID");
            if (hidItemID) {
                $('#frmSearchContent').attr('src', 'OSearchContent.aspx?ItemID=' + hidItemID.value);
            }
        }
        function CheckHighlight(chk) {
            var val = 0;
            if (chk.checked) {
                val = 1;
            }
            if (jFileId > 0) {
                var flash;
                flash = getFlashMovieObject("Viewer");
                if (flash) {
                    var hidSearchContent = document.getElementById('hidSearchContent');
                    var txt = '';
                    if (hidSearchContent) {
                        txt = hidSearchContent.value;
                    }
                    flash.showHighlight(val, txt);
                }
            }
        }
        function searchGotoPages(pageno, searchContent) {
            if (pageno > 0) {
                /*linkPageViewer(pageno);
                if (searchContent) {
                    var hidSearchContent = document.getElementById('hidSearchContent');
                    hidSearchContent.value = searchContent;
                    var chkHighlight = document.getElementById('chkHighlight');
                    if (chkHighlight) {
                        chkHighlight.disabled = false;
                        CheckHighlight(chkHighlight);
                        var divHeaderView = $('#divHeaderView');
                        divHeaderView.show();
                    }
                }*/
                $("#ifrm1").prop('contentWindow').gotoPage(pageno - 1);
            }
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
    </script>

       <!-- facebook -->
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '431341877234704',
                xfbml: true,
                version: 'v2.9'
            });
            FB.AppEvents.logPageView();
        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>
    <!-- end -->
       
    <% 
        Response.Write("<style type='text/css'>.item-box:hover h2, .item-box:hover h2 a { background: #096 none repeat scroll 0 0 !important; } .clr-cyan { background: #096; }</style>")
        Response.Write("<style type='text/css'>.item-box h3{ color:#1ba1e2; border-top:solid 2px #1ba1e2 } .item-box h3 a{ color:#1ba1e2; } .item-box:hover h2, .item-box:hover h2 a { background: #1ba1e2 none repeat scroll 0 0 !important; } .clr-cyan { background: #1ba1e2; }</style>")
            
        Response.Write("<style type='text/css'>.item-box h3.clr-cyan-2{ color:#1ba1e2; border-top:solid 2px #1ba1e2; background:none; } .item-box h3.clr-cyan-2 a{ color:#1ba1e2; }</style>")
        Response.Write("<style type='text/css'>.item-box h3.clr-cyan-3{ color:#096; border-top:solid 2px #096 } .item-box h3.clr-cyan-3 a{ color:#096; }</style>")
        Response.Write("<style type='text/css'>.item-box:hover h2.clr-cyan-2, .item-box:hover h2.clr-cyan-2 a { background: #096 none repeat scroll 0 0 !important; } .clr-cyan-2 { background: #096; }</style>")
    %>
    <style type="text/css">
        .item-info .item-intro {
            height: 250px;
            overflow: hidden;
            line-height:20px;
        }
        .item-intro p span
        {
            margin-right:0px;
        }
    </style>
</head>

<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px"  onload="setIframe()">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="web-size ClearFix book-detail">
                <div class="col-right-7 item-detail">
                    <div id="divHeaderView" class="element place-right" runat="server" style="display:none;">
                        <label class="inline-block">
	                        <input type="checkbox" checked="" id="chkHighlight" name="chkHighlight" onclick="CheckHighlight(this);" disabled />
	                        <span class="check"></span>
	                        Hiển thị mục từ tìm kiếm
                        </label>
                    </div>
                    <div id="spViewer" style="padding-top:10px;">
                        <%--<div style="position:absolute">
                            <div style="position:relative; left:0px; top:0px;">
                                <div class="detail-control">
                                    <div style="width:50px; height:40px; background:#ebebeb;"></div>
                                </div>
                            </div>  
                        </div>--%>
                        <div style="position:absolute;">
                            <div style="position:relative; left:5px; top:5px;">
                                <div class="detail-control">
                                    <div class="button-control">
                                        <div class="button-form">
                                            <asp:Panel ID="PanelDownLoad" runat="server" Visible="false">
                                                <asp:Button ID="btnDownLoad" CssClass="btn-icon" runat="server" />
                                                <div class="btn-value"><span class="mif-download"></span>Download</div>     
                                            </asp:Panel>    
                                        </div>
                                    </div>
                                </div>
                            </div>  
                        </div>
                                <iframe  allowtransparency="true" class="iframe" id="ifrm1" scrolling="no" src="" ></iframe>
			            <%--<h1>Nếu bạn không xem được, xin vui lòng tải và cài đặt Flash Player bên dưới</h1>
                        <p><img src="Viewer/Plugin/get_adobe_flash_player.png" alt="Tải Flash player" /></p>
			            <p><a href="Viewer/Plugin/install_flash_player_ax_32bit.exe">Tải Flash Player 11.2.202.235 cho trình duyệt Internet Explorer (windows 32-bit)</a></p>
			            <p><a href="Viewer/Plugin/install_flash_player_ax_64bit.exe">Tải Flash Player 11.2.202.235 cho trình duyệt Internet Explorer (windows 64-bit)</a></p>
                        <p><a href="Viewer/Plugin/install_flash_player_32bit.exe">Tải Flash Player 11.2.202.235 cho trình duyệt khác (windows 32-bit)</a></p>
			            <p><a href="Viewer/Plugin/install_flash_player_64bit.exe">Tải Flash Player 11.2.202.235 cho trình duyệt khác (windows 64-bit)</a></p>--%>
                         
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
                                <div class="rating">
                                    <%--<iframe src="https://www.facebook.com/plugins/share_button.php?href=<%=HttpUtility.UrlEncode(Request.Url.ToString())%>&layout=button&size=small&mobile_iframe=true&width=100&height=20" width="100" height="20" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowTransparency="true"></iframe>--%>
                                    <div class="fb-like"
                                         data-share="true"
                                         data-width="450"
                                         data-show-faces="true">
                                    </div>
                                </div>
                            </div>
                            <div class="detail-control">
                                <div class="input-control">
                                    <textarea placeholder="Viết bình luận" class="tb-area" id="txtComment"></textarea>
                                </div>
                                <uc1:s3capcha ID="s3capcha1" runat="server" />  
                                <div class="button-control">
                                    <div class="button-form">
                                        <input type="button" class="btn-icon"  onclick="onRaiseComment();return false;">
                                        <div class="btn-value"><span class="mif-bubbles"></span>Gửi bình luận</div>                                        
                                    </div>
                                    <%--<div class="button-form" style="float:right;">
                                        <asp:Panel ID="PanelDownLoad" runat="server" Visible="false">
                                            <asp:Button ID="btnDownLoad" CssClass="btn-icon" runat="server" />
                                            <div class="btn-value"><span class="mif-download"></span>Tải File</div>     
                                        </asp:Panel>                                   
                                    </div>--%>
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
                    <div id="CollapsiblePanel1" class="CollapsiblePanel">
                        <div class="CollapsiblePanelTab" tabindex="0">Tìm tài liệu theo nội dung kiến thức</div>
                            <div class="CollapsiblePanelContent">
                            <div class="search-detail">
                                <div>
			                        <iframe id="frmSearchContent" src="" style="width:100%;height:100%;border:0px;" class="frame"></iframe>
		                        </div>
                            </div>
                        </div>
                    </div>
                    <div id="CollapsiblePanel2" class="CollapsiblePanel" runat="server">
                        <div class="CollapsiblePanelTab" tabindex="0">Mục lục</div>
                        <div class="CollapsiblePanelContent">
                            <ul class="sub-menu-list">
                                <asp:Literal runat="server" ID="ltrTableOfContent"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                    <div id="CollapsiblePanel3" class="CollapsiblePanel" runat="server">
                        <div class="CollapsiblePanelTab" tabindex="0"  id="divRelationDocument" runat="server">Tài liệu liên quan</div>
                        <div class="CollapsiblePanelContent">
                            <div class="list-book">
                        	    <ul class="ClearFix">
                                   <asp:Literal runat="server" ID="ltrBookList"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="CollapsiblePanel4" class="CollapsiblePanel" runat="server">
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
            <span id="spCapchaInfo" runat="server">Mã xác nhận chọn không đúng. Bạn vui lòng chọn lại.</span> 
            <span id="spCommentSuccess" runat="server">Gửi bình luận thành công.</span> 
            <span id="spCommentFail" runat="server">Gửi bình luận không thành công.</span> 
            <span id="spEDATAContent" runat="server">&nbsp;Đọc nội dung</span> 
            <span id="spEDATA" runat="server">Dữ liệu điện tử</span>
            <span id="spItemType" runat="server">Dạng tài liệu</span> 
            <span id="spISSN" runat="server">ISSN</span>         
            <span id="spAuthor" runat="server">Tác giả</span>
            <span id="spPublisher" runat="server">Nhà xuất bản</span>
            <span id="spPhysicalInfo" runat="server">Mô tả vật lý</span>
            <span id="spPublisherInfo" runat="server">Thông tin xuất bản</span>
            <input id="hidSearchContent" type="hidden" value="" runat="server" />
           <input type="hidden" id="hidPageNo" runat="server" value="1" />
           <input id="hidItemID" type="hidden" name="hidItemID" runat="server" />
           <span id="spAddToMyList" runat="server">Thêm vào danh sách của tôi</span>
            <span id="spInMyList" runat="server">Đã trong danh sách của tôi</span>
            <input id="hidMyListIds" type="hidden" value="" runat="server" />
            <span id="spMyListTitle" runat="server">Tiêu đề</span>
            <span id="spCommentEmpty" runat="server">Đánh giá là rỗng. Vui lòng đánh dấu chọn biểu tượng ngôi sao để đánh giá về tài liệu này.</span>
            <span id="spCommentContentEmpty" runat="server">Bình luận là rỗng. Vui lòng chia sẻ vài dòng suy nghĩ của bạn về tài liệu này.</span>
            <span id="spKeyword" runat="server">Từ khóa</span>
            <span id="spSubjectHeading" runat="server">Tiêu đề đề mục</span>
            <span id="spDDC" runat="server">DDC</span>
            <span id="spNLM" runat="server">NLM</span>
            <span id="spSeries" runat="server">Tuyển tập (Series)</span>
            <span id="spRelatedWord" runat="server">Mục từ truy cập</span>
            <span id="spMXG" runat="server">Ký hiệu</span>
            <span id="spNoFound" runat="server">Không có thông tin</span>
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
         var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
         var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
         var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3");
         var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4");
         //var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    </script>
</body>
</html>
