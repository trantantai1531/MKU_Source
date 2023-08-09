<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OTop.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"  lang="en">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/jquery.blockUI.js"></script>
    <style>
          #iLogo
          {
      	    margin-top:-12px;
      	    height:36px;
          }
          #popupMyList, .bMulti
	        {
	            background-color: #FFF;
                border-radius: 10px 10px 10px 10px;
                box-shadow: 0 0 25px 5px #999;
                color: #111;
                display: none;
                min-width: 450px;
                min-height: 250px;
                padding: 25px;
            }
            .bt.b-close, .bt.bClose {
                border-radius: 7px 7px 7px 7px;
                box-shadow: none;
                font: bold 131% sans-serif;
                padding: 0 6px 2px;
                position: absolute;
                right: -7px;
                top: -7px;
            }
            .bt {
                background-color: #2B91AF;
                border-radius: 10px;
                box-shadow: 0 2px 3px rgba(0, 0, 0, 0.3);
                color: #FFF;
                cursor: pointer;
                display: inline-block;
                padding: 10px 20px;
                text-align: center;
                text-decoration: none;
            }        
    </style>
    <script type="text/javascript">
        $(window).ready(function () {
            $('#btSearch').click(function (event) {                
                event.preventDefault();
            });
        });

        function showWaiting() {
            var spWaiting = document.getElementById('spWaiting');
            if (spWaiting) {
                $.blockUI({ css: {
                    border: 'none',
                    padding: '15px',
                     color: '#000',
                    backgroundColor: '#fff',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .8
                }, message: '<h4><img src="Images/loader.gif" />&nbsp;' + spWaiting.innerHTML + '</h4>'
                });                
            }
        }

        function unLockShowWaiting() {
            $.unblockUI();
        }

        var bolSubmit = false;

        function keySearch(e) {
            var key = e.keyCode || e.which;
            if (key == 13) {
                if (!bolSubmit) {
                    checkValid();
                }
            }
        }

        function Submit() {
            if (bolSubmit) {
                var btSubmit = document.getElementById("btSubmit");
                if (btSubmit) {
                    btSubmit.click();
                    showWaiting();
                }
            }
            else {
                //unLockShowWaiting();
            }
        }

        function clickSearch(e) {
            if (!bolSubmit) {
                checkValid();
            }
        }

        function checkValid() {
            var txtSearch = document.getElementById("txtSearch");
            if (txtSearch.value == '') {
                var spInputEmpty = document.getElementById("spInputEmpty");
                showNotify(1, spInputEmpty.innerHTML);                
            }
            else {
                bolSubmit = true;
            }
            Submit();
        }


        function showPopupDetail(Item) {
            var strWord = '';
            var hidSearch = parent.document.getElementById("hidSearch");
            if (hidSearch) {
                strWord = hidSearch.value;
            }
            $('#popup').bPopup({
                onOpen: function () {
                    $('#showMe').attr('src', 'ODetail.aspx?intItemId=' + Item.toString() + '&searchWord=' + strWord);
                }
            });
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

        function setUser(val,fullname) {
            var hidUser = document.getElementById("hidUser");
            hidUser.value = val;
            var spAccount = document.getElementById("spAccount");
            spAccount.innerHTML = fullname;
            var spLogout = document.getElementById("spLogout");
            spLoginLogout.innerHTML = spLogout.innerHTML;
        }
        function showLogin() {
            var hidUser = document.getElementById("hidUser");
            if (hidUser.value =='') {
                window.scrollTo(0, 10);
                $('#popupLogin').bPopup();
//                var spLogin = document.getElementById("spLogin");
//                spLoginLogout.innerHTML = spLogin.innerHTML;
            }
            else {
                /*var spLoginLogout = document.getElementById("spLoginLogout");
                var spLogout = document.getElementById("spLogout");
                spLoginLogout.innerHTML = spLogout.innerHTML;*/
                var raiseLogout = document.getElementById("raiseLogout");
                raiseLogout.click();
            }
        }
        function closeShowLogin() {
            var bPopup = $('#popupLogin').bPopup();
            bPopup.close();
        }

        function fnShowMyList(val) {
            window.scrollTo(0, 10);        
            $('#popupMyList').bPopup({
                onOpen: function () {
                    changeTabInfo(val);
                }
            });
        }


        function changeTabInfo(val) {
            //$('#liMyList').removeClass("active");
            switch (val) {
                case 'MYLIST':
                    $('#liMyList').addClass("active");
                    $('#frmShowMyList').show();
                    $('#frmShowPatronInfo').hide();
                    $('#showMyList').attr('src', 'OMyList.aspx');
                    break;
                case 'PATRONINFO':
                    $('#liPatronInfo').addClass("active");
                    $('#frmShowMyList').hide();
                    $('#frmShowPatronInfo').show();
                    $('#showPatronInfo').attr('src', 'OPatronInfo.aspx');
                    break;
            }
        }

        function changLanguage(val) {
            var Language = "Lang=" + val;
            var url = String(location.href);
            url = url.replace('Lang=', 'L=').replace('#','');
            if (url != null)
                if (url.indexOf("?") > 0)
                    url = String(url) + "&" + Language;
                else
                    url = String(url) + "?" + Language;
            location.href = url;
        }

        function gotoMagazineList(url) {
            top.location.href = url;
        }

        function addMyList(iTemId) {
            var spInMyList = document.getElementById('spInMyList');
            changeIconStatus(iTemId, "icon-checkmark", spInMyList.innerHTML);
            var hidMyListIds = document.getElementById('hidMyListIds');
            var Ids = hidMyListIds.value;
            if (!checkExistId(iTemId, Ids)) {
                hidMyListIds.value = Ids + iTemId.toString() + ",";
                var arrListIds = Ids.split(",");
                var iItem = arrListIds.length;
                //iItem = iItem + 1;
                var str = '';
                var spMyListTitle = document.getElementById('spMyListTitle');
                str = '<strong>';
                str = str + spMyListTitle.innerHTML + ': ';
                str = str + iItem.toString();
                str = str + '</strong>';
                $("#spMyList").html(str);
                if ($("#spMyListShow")) {
                    $("#spMyListShow").html(str);
                }
                PageMethods.setItemToMyList(hidMyListIds.value);
            }
        }

        function changeIconStatus(iTemId, iClass, title) {
            if ($('#icon' + iTemId)) {
                if (iClass == 'icon-plus') {
                    $('#icon' + iTemId).removeClass("icon-checkmark").addClass(iClass);
                    $('#icon' + iTemId).css("cursor", "pointer");
                }
                else {
                    $('#icon' + iTemId).removeClass("icon-plus").addClass(iClass);
                    $('#icon' + iTemId).css("cursor", "default");
                }
                $('#icon' + iTemId).attr("data-hint", title);
            }
        }

        function checkExistId(id, Ids) {
            var bolResult = false;
            if (Ids.toString().indexOf(id.toString() + ',') != -1) {
                bolResult = true;
            }
            return bolResult;
        }

        function removeMyList(iTemId) {
            var hidMyListIds = document.getElementById('hidMyListIds');
            var strListIds = hidMyListIds.value;
            var strListIdsNew = strListIds.replace(iTemId.toString() + ',', '');
            hidMyListIds.value = strListIdsNew;
            var arrListIds = strListIdsNew.split(",");
            var iItem = arrListIds.length;
            iItem = iItem - 1;
            var str = '';
            var spMyListTitle = document.getElementById('spMyListTitle');
            str = '<strong>';
            str = str + spMyListTitle.innerHTML + ': ';
            str = str + iItem.toString();
            str = str + '</strong>';
            $("#spMyList").html(str);
            if ($("#spMyListShow")) {
                $("#spMyListShow").html(str);
            }
            var spAddToMyList = document.getElementById('spAddToMyList');
            changeIconStatus(iTemId, "icon-plus", spAddToMyList.innerHTML);
        }

        function removeALlMyList() {
            var hidMyListIds = document.getElementById('hidMyListIds');
            var strIds = hidMyListIds.value;
            var arrayIds = strIds.split(",");
            var spAddToMyList = document.getElementById('spAddToMyList');
            for (i = 0; i < arrayIds.length; i++) {
                changeIconStatus(arrayIds[i], "icon-plus", spAddToMyList.innerHTML);
            }
            hidMyListIds.value = "";
            var iItem = 0;
            var str = '';
            var spMyListTitle = document.getElementById('spMyListTitle');
            str = '<strong>';
            str = str + spMyListTitle.innerHTML + ': ';
            str = str + iItem.toString();
            str = str + '</strong>';
            $("#spMyList").html(str);
            if ($("#spMyListShow")) {
                $("#spMyListShow").html(str);
            }
            $('#showMyList').attr('src', 'OMyList.aspx?removeAll=1');
        }

        function printOptions() {
            $('#popupPrintOptions').bPopup({
                follow: [false, false]
            });
        }

        function export2File() {
            $('#popupexport2File').bPopup({
                follow: [false, false]
            });
        }
        function send2Email() {
            $('#popupSend2Email').bPopup({
                follow: [false, false]
            });
        }
        function processExport2File() {
            var intType = 1; // $("input:checked").val();
            var rdWord = document.getElementById('rdWord');
            if (rdWord.checked) {
                intType = 1;
            }
            else {
                intType = 2;
            }
            var a = document.createElement("a");
            a.href = "OExport2File.aspx?intType=" + intType.toString();
            a.target = "_blank";
            document.body.appendChild(a);
            a.click();
            var bPopup = $('#popupexport2File').bPopup();
            bPopup.close();
        }

        function processSend2Email() {
            var txtEmail = document.getElementById('txtEmail');
            if (ValidateEmail(txtEmail)) {
                var a = document.createElement("a");
                a.href = "OSendEmail.aspx?EmailTo=" + txtEmail.value;
                a.target = "_blank";
                document.body.appendChild(a);
                a.click();
                var bPopup = $('#popupSend2Email').bPopup();
                bPopup.close();
            }
            else {
                var spEmailInValid = document.getElementById('spEmailInValid');
                alert(spEmailInValid.innerHTML);
            }
        }

        function ValidateEmail(inputText) {
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if (inputText.value.match(mailformat)) {
                return true;
            }
            else {
                return false;
            }
        } 

        function processPrintOptions() {
            var txtReportTitle = document.getElementById('txtReportTitle');
            var intOrder = 1; // $("input:checked").val();
            var rdTitle = document.getElementById('rdTitle');
            if (rdTitle.checked) {
                intOrder = 1;
            }
            else {
                var rdAuthor = document.getElementById('rdAuthor');
                if (rdAuthor.checked) {
                    intOrder = 2;
                }
                else {
                    intOrder = 3;
                }
            }
            var a = document.createElement("a");
            a.href = "OPrint.aspx?orderBy=" + intOrder.toString() + "&reportTitle=" + txtReportTitle.value;
            a.target = "_blank";
            document.body.appendChild(a);
            a.click();
            var bPopup = $('#popupPrintOptions').bPopup();
            bPopup.close();
        }
        /*
        function fnShowMyList() {
            window.scrollTo(0, 10);
            $('#popupMyList').bPopup({
                onOpen: function () {
                    $('#showMyList').attr('src', 'OMyList.aspx');
                }
            });
        }*/
    </script>
</head>
<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;">
    <asp:ScriptManager ID="smHeader" runat="server" EnablePageMethods="true" />
    <form method="post" action="OShow.aspx">
        <div class="navigation-bar" id="navHeader" runat="server">
            <div class="navigation-bar-content container">
                <div class="grid fluid">                    
                    <div class="row">
                        <div>
                            <a title="Trợ giúp" href="#" class="element place-right"><span class="icon-help"></span></a>
                            <div class="element place-right">
				                <a class="dropdown-toggle" href="#" title="Thay đổi ngôn ngữ" runat="server" id="lnkChangLanguage">
					                <img src="images/Language/vie.png" style="height:22px;width:22px;text-align:center;vertical-align:text-top;margin-top:-3px;" id="imgFlag" runat="server"/>
				                </a>
				                <ul class="dropdown-menu place-right" data-role="dropdown">
                                    <asp:Literal runat="server" ID="ltrLanguage"></asp:Literal>   
				                </ul>
			                </div>
                            <a title="Đăng nhập tài khoản" onclick="showLogin()" class="element place-right" style="cursor:pointer;"><span class="icon-user-2" id="spLoginLogout" runat="server">Đăng nhập</span></a>
                            <span class="element-divider place-right"></span>
                            <a title="Thông tin của tôi" href="#" onclick="fnShowMyList('PATRONINFO');" class="element place-right"><span class="icon-info" id="spMyInfo" runat="server">Thông tin của tôi</span></a>
                            <div class="element place-right">
				                <a class="dropdown-toggle" href="#" title="Liên kết website">
					                <span class="icon-newspaper"  id="spLibraryInfo" runat="server">Liên kết website</span>
				                </a>
				                <ul class="dropdown-menu place-right" data-role="dropdown">
                                    <li><a href="ONews.aspx" id="spNews" runat="server"><i class="icon-newspaper"></i>&nbsp;Tin tức</a></li>
                                    <li class="divider"></li>
					                <li><a href="OWebUseful.aspx" id="spLinkSite" runat="server"><i class="icon-anchor"></i>&nbsp;Website hữu ích</a></li>
                                    <li class="divider"></li>
                                    <asp:Literal runat="server" ID="ltrLibraryList"></asp:Literal>
				                </ul>
			                </div>                           
                            <div class="element place-right">
				                <a class="dropdown-toggle" href="#" title="Tìm kiếm">
					                <span class="icon-search" id="spSearch" runat="server">Tìm kiếm</span>
				                </a>
				                <ul class="dropdown-menu place-right" data-role="dropdown">
                                    <li><a href="OSearchAdvanced.aspx"  id="spSearchAdvance" runat="server"><i class="icon-target-2"></i>&nbsp;Tìm kiếm nâng cao</a></li>
					                <li><a href="OZ3950.aspx"  id="spSearchZ3950" runat="server"><i class="icon-cloud-2"></i>&nbsp;Tìm kiếm Z39.50</a></li>
				                </ul>
			                </div>
                            <div class="element place-right">
				                <a class="dropdown-toggle" href="#" title="Duyệt theo">
					                <span class="icon-compass"  id="spBrowseTo" runat="server">Duyệt theo</span>
				                </a>
				                <ul class="dropdown-menu place-right" data-role="dropdown">
                                   <li><a href="OBrowse.aspx?DicID=14"  id="spBrowseByCollection" runat="server"><i class="icon-cabinet"></i>&nbsp;Bộ sưu tập</a></li>
                                    <li class="divider"></li>
					                <%--<li><a href="OBrowse.aspx?DicID=12" id="spBrowseByCategory" runat="server"><i class="icon-tree-view"></i>&nbsp;Danh mục</a></li>--%>
                                    <li><a href="OBrowse.aspx?DicID=13" id="spBrowseByTitle" runat="server"><i class="icon-type"></i>&nbsp;Nhan đề</a></li>
                                    <li><a href="OBrowse.aspx?DicID=1" id="spBrowseByAuthor" runat="server"><i class="icon-user-3"></i>&nbsp;Tác giả</a></li>
                                    <li><a href="OBrowse.aspx?DicID=9" id="spBrowseByPublisherYear" runat="server"><i class="icon-calendar"></i>&nbsp;Năm xuất bản</a></li>
                                    <li><a href="OBrowse.aspx?DicID=2" id="spBrowseByPublisher" runat="server"><i class="icon-award-fill"></i>&nbsp;Nhà xuất bản</a></li>                                   
                                    <li><a href="OBrowse.aspx?DicID=5" id="spBrowseBySubjectHeading" runat="server"><i class="icon-glasses-2"></i>&nbsp;Tiêu đề đề mục</a></li>
                                    <li><a href="OBrowse.aspx?DicID=3" id="spBrowseByKeyword" runat="server"><i class="icon-target"></i>&nbsp;Từ khóa</a></li>
                                    <li class="divider"></li>
                                    <li><a href="OBrowse.aspx?DicID=10" id="spBrowseByDocType" runat="server"><i class="icon-cube"></i>&nbsp;Dạng tài liệu</a></li>                                   
                                    <li class="divider"></li>
                                    <%--<li><a href="OBrowse.aspx?DicID=11" id="spBrowseElectronicData" runat="server"><i class="icon-rocket"></i>&nbsp;Tài liệu số (Toàn văn)</a></li>--%>                                   
				                </ul>
			                </div>                            
                            <a title="Trang chủ" href="OIndex.aspx" class="element place-right"><span class="icon-home" id="spHome" runat="server">Trang chủ</span></a>
                        </div>
                    </div>
                    <div class="row">
                        <a href="OIndex.aspx" class="element"><img src="images/logo/logotentv2015.png" id="iLogo"  style="width:94px;height:94px;margin-top:-55px;" /></a>   
		                <div class="element input-element">
                            <div class="input-control text" data-role="input-control"  id="divSearch" runat="server">
                                 <input type="text" placeholder="Nhập thông tin tìm kiếm của bạn ở đây" id="txtSearch" name="txtSearch" value="" style="width:400px;"/>
				                 <button class="btn-search" id="btSearch" onclick="clickSearch()"></button>
			                </div>
                            <div>
                                <div class="input-control radio inline-block" data-role="input-control">
                                    <label id="Label6" class="inline-block" runat="server">
                                        <input type="radio" name="rdSearchOption" checked="" id="rdRecordByPrint" value="1" />
                                        <span class="check"></span>
                                       <span runat="server" id="spRecordByPrint">Tài liệu in (Biên mục)</span> 
                                    </label>&nbsp;
                                    <label id="Label7" class="inline-block"  runat="server">
                                        <input type="radio" name="rdSearchOption" id="rdRecordByEbooks"  value="2" />
                                        <span class="check"></span>
                                        <span runat="server" id="spRecordByEbooks">Tài liệu số (Toàn văn)</span> 
                                    </label>
                                </div>     
                             </div>  
		                </div>
                        <div class="place-right" style="margin-top:15px;">
                            <div style="text-align:center;line-height: normal !important;vertical-align:text-top;">
                                <span class="icon-database" id="spLibrary" runat="server" style="margin-bottom:10px;"><strong>Thư viện Khoa Học Tổng Hợp - Tp. Hồ Chí Minh</strong></span>
                                <br />
                                <span class="icon-user" id="spAccount" runat="server">Xin chào, khách!</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
        <div style="display:none">        
        
             <div style="display:none;">
                 <span id="spAddToMyList" runat="server">Thêm vào danh sách của tôi</span>
                 <span id="spInMyList" runat="server">Đã trong danh sách của tôi</span>
                 <input id="hidMyListIds" type="hidden" value="" runat="server" />
                 <span id="spMyListTitle" runat="server">Tiêu đề</span>
                 <div id="myList" style="position: fixed; top: 65px; z-index: 100;cursor:pointer;" class="panel">
                    <div class="panel-header bg-darkRed fg-white text-center"  style="cursor:pointer;">
                        <span id="spLblMyList" runat="server" class="line-height" style="font-size:medium;">Danh sách của tôi</span>
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
            </div>  
            
            <input id="hidUser" type="hidden" value="" runat="server" />
            <div id="popup" class="bMulti" style="width:920px;height:620px;">
		        <span class="bt b-close"><span>X</span></span>
		        <iframe id="showMe" src="" style="width:880px;height:580px;border:0px;" class="frame"></iframe>
	        </div>
            <button class="btn-search" id="btSubmit"></button>
            <div id="popupMyList" class="bMulti" style="width:870px;height:580px;">
                <span class="bt b-close"><span>X</span></span>
                <div class="tab-control" data-role="tab-control">
                    <ul class="tabs">
                        <li id="liMyList"><a href="#showMyList" onclick="changeTabInfo('MYLIST');" ><span id="spMyListDialog" class="list-subtitle" runat="server">Danh sách của tôi</span></a></li>
                        <li id="liPatronInfo"><a href="#showPatronInfo" onclick="changeTabInfo('PATRONINFO');" ><span id="spPatronInfo" class="list-subtitle" runat="server">Thông tin cá nhân của tôi</span></a></li>
                    </ul>
                    <div class="frames" style="width:800px;height:470px;"  id="frmShowMyList">
                        <iframe id="showMyList" src="" style="width:800px;height:470px;border:0px;" class="frame"></iframe>
                        <div style="height:30px;margin-top:10px;">
                            <a class="element place-left" onclick="export2File()" title="Xuất ra file" style="cursor:pointer;"><span class="icon-file">Xuất ra file&nbsp;</span></a>
                            <a class="element place-left" onclick="send2Email()" title="Gửi email" style="cursor:pointer;"><span class="icon-mail-2">Gửi email&nbsp;</span></a>
                            <a class="element place-right" onclick="removeALlMyList()" title="Xóa danh sách" style="cursor:pointer;"><span class="icon-remove">Xóa danh sách&nbsp;</span></a>&nbsp;&nbsp;
                            <a class="element place-right" onclick="printOptions()" title="In danh sách" style="cursor:pointer;"><span class="icon-printer">In danh sách&nbsp;</span></a>
                        </div>                        
                    </div>
                    <div class="frames" style="width:800px;height:470px;"  id="frmShowPatronInfo">
                        <iframe id="showPatronInfo" src="" style="width:800px;height:470px;border:0px;" class="frame"></iframe>
                    </div>
                </div>
            </div>
            <div id="popupLogin" class="bMulti" style="width:540px;height:410px;">
                <span class="bt b-close"><span>X</span></span>                
                <div class="tab-control" data-role="tab-control">
                    <ul class="tabs">
                    <li class="active"><a href="#" style="cursor:default;"><span id="spPopupLogin" class="list-subtitle" runat="server">Đăng nhập</span></a></li>
                    </ul>
                    <iframe id="ifrmLogin" src="OLogin.aspx?comment=1" style="width:500px;height:310px;border:1px solid #eaeaea;" scrolling="no" class="frame" ></iframe>
                </div>
            </div>
            <div id="popupPrintOptions" class="bMulti"  style="width:440px;height:340px;">
                <span class="bt b-close"><span>X</span></span>
                <div class="tab-control" data-role="tab-control">
                        <ul class="tabs">
                        <li class="active"><a href="#showPrintOptions"><span id="Span1" class="list-subtitle" runat="server">Danh sách biên mục</span></a></li>
                        </ul>
                        <div class="frames" style="width:400px;height:230px;" id="showPrintOptions">
                        <div class="input-control radio inline-block" data-role="input-control">
                            <div class="grid no-margin">
                                <div class="row">&nbsp;</div>
                                <div class="row">
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <div class="span11">
                                        <div class="input-control text info-state" data-role="input-control" style="width:380px;">
                                            <input type="text" value="Danh sách của tôi" id="txtReportTitle" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="span2">
                                        <span id="Span2" class="list-title" runat="server"><strong>Sắp xếp theo:</strong></span>
                                    </div>
                                </div>
                                <div class="row">
                                        <div class="span1">&nbsp;</div>
                                        <div class="span11">
                                        <label id="Label2" class="inline-block" runat="server">
                                            <input type="radio" name="r1" checked="" id="rdTitle" value="1" >
                                            <span class="check"></span>
                                            Nhan đề
                                        </label>
                                        <br />
                                        <label id="Label1" class="inline-block"  runat="server">
                                            <input type="radio" name="r1" id="rdAuthor"  value="2">
                                            <span class="check"></span>
                                            Tác giả
                                        </label>
                                            <br />
                                        <label id="Label3" class="inline-block"  runat="server">
                                            <input type="radio" name="r1" id="rdCallNo"  value="3">
                                            <span class="check"></span>
                                            Mã xếp giá
                                        </label>
                                        </div>
                                </div>
                            </div>
                        </div>                            
                    </div>
                    <div style="height:30px;margin-top:10px;">
                        <a class="element place-right" onclick="processPrintOptions()" title="Xem trước khi in" style="cursor:pointer;"><span class="icon-zoom-in">Xem trước khi in&nbsp;</span></a>&nbsp;&nbsp;
                    </div>
                </div>
            </div>

             <div id="popupexport2File" class="bMulti"  style="width:440px;height:340px;">
                <span class="bt b-close"><span>X</span></span>
                <div class="tab-control" data-role="tab-control">
                        <ul class="tabs">
                        <li class="active"><a href="#showExport2File"><span id="spLblExport2file" class="list-subtitle" runat="server">Xuất ra file</span></a></li>
                        </ul>
                        <div class="frames" style="width:400px;height:230px;" id="showExport2File">
                        <div class="input-control radio inline-block" data-role="input-control">
                            <div class="grid no-margin">
                                <div class="row">&nbsp;</div>
                                <div class="row">
                                        <div class="span1">&nbsp;</div>
                                        <div class="span11">
                                        <label id="Label4" class="inline-block" runat="server">
                                            <input type="radio" name="r2" checked="" id="rdWord" value="1" >
                                            <span class="check"></span>
                                            <span class="icon-file-word"></span>&nbsp;Microsoft Word
                                        </label>
                                        <br />
                                        <label id="Label5" class="inline-block"  runat="server">
                                            <input type="radio" name="r2" id="rdPDF"  value="2">
                                            <span class="check"></span>
                                            <span class="icon-file-pdf"></span>&nbsp;PDF
                                        </label>
                                        </div>
                                </div>
                            </div>
                        </div>                            
                    </div>
                    <div style="height:30px;margin-top:10px;">
                        <a class="element place-right" onclick="processExport2File()" title="Xuất ra file" style="cursor:pointer;"><span class="icon-files">Xuất ra file&nbsp;</span></a>&nbsp;&nbsp;
                    </div>
                </div>
            </div>
            <div id="popupSend2Email" class="bMulti"  style="width:440px;height:340px;">
                <span class="bt b-close"><span>X</span></span>
                <div class="tab-control" data-role="tab-control">
                        <ul class="tabs">
                        <li class="active"><a href="#showSend2Email"><span id="Span3" class="list-subtitle" runat="server">Gửi đến email</span></a></li>
                        </ul>
                        <div class="frames" style="width:400px;height:230px;" id="showSend2Email">
                        <div class="input-control radio inline-block" data-role="input-control">
                            <div class="grid no-margin">
                                <div class="row">&nbsp;</div>
                                <div class="row">
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <div class="span11">
                                        <div class="input-control text info-state" data-role="input-control" style="width:380px;">
                                            <input type="text" value="" id="txtEmail" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>                            
                    </div>
                    <div style="height:30px;margin-top:10px;">
                        <a class="element place-right" onclick="processSend2Email()" title="Gửi email" style="cursor:pointer;"><span class="icon-mail">Gửi email&nbsp;</span></a>&nbsp;&nbsp;
                    </div>
                </div>
            </div>
        </div>       
    </form>
    <form  id="form1" runat="server">
        <div style="display:none">
            <span id="spLogin" runat="server">Đăng nhập</span>
            <span id="spLogout" runat="server">Đăng xuất</span>
            <span id="spHello" runat="server">Xin chào,</span>
            <span id="spGuest" runat="server">Khách</span>
            <span id="spInputEmpty" runat="server">Bạn vui lòng nhập nhập vào thông tin tìm kiếm.</span>
            <span id="spLanguageVietNamese" runat="server">Tiếng Việt</span>
            <span id="spLanguageEnglish" runat="server">Tiếng Anh</span>
            <span id="spWaiting" runat="server">Xin vui lòng đợi trong chốc lát...</span>
            <span id="spEmailValid" runat="server">Đã gửi thông tin thành công. Vui lòng kiểm tra lại hộp mail của bạn.</span>
            <span id="spEmailInValid" runat="server">Email nhập vào không hợp lệ...</span>
            <span id="spLibraryLink" runat="server">Liên kết thư viện</span>
            <asp:Button runat="server" ID="raiseLogout"  Text="raiseLogout" CausesValidation="false"/>
        </div>
    </form>
</body>
</html>
