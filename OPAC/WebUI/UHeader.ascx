<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UHeader.ascx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.UHeader" %>
<script src="js/jquery.blockUI.js"></script>
<script src="js/noty/packaged/jquery.noty.packaged.min.js"></script>
<script type="text/javascript" src="js/noty/notification_html.js"></script>
<link rel="stylesheet" type="text/css" href="Resources/StyleSheet/noty/buttons.css" />
<link rel="stylesheet" type="text/css" href="Resources/StyleSheet/noty/animate.css" />
<link rel="stylesheet" href="Resources/StyleSheet/noty/font-awesome/css/font-awesome.min.css" />
<style type="text/css">
    .white-popup {
        position: relative;
        background: #FFF;
        padding: 20px;
        width: auto;
        max-width: 500px;
        margin: 20px auto;
    }
    #divBannerTop {
        background: #fff;
        text-align:center;
    }
    #divBannerTop img
    {
        width:100%;
    }
    body
    {
        background:#ffffff;
    }
    #divTopHeader {
        background: #003366;
    }
    #HeaderLeft img
    {
        padding-left:10px;
    }
    header {
        background: #ececec;
        max-width: 1230px;
        margin: 0 auto;
    }
    .clr-amber {
        background: #f0a30a;
        padding-left: 10px;
    }
    .SSCBar
    {
        padding:0px;
    }
    li.active p
    {
        background: #003366;
    }
    .user-link
    {
        margin-right:10px;
        color:#fff;
        position:relative;
        top:-2px;
    }
    .PersonalOut
    {
        display:inline-block;
        position:relative;
    }
    .PersonalOut input[type=button]
    {
        padding: 10px 10px;
        border-radius: 3px;
        background: #096;
        color: #fff;
        border:0;
    }
    .SSCBar .BarItem
    {
        margin-left:0;
    }
</style>
<script type="text/javascript">
    var matched, browser;

    jQuery.uaMatch = function (ua) {
        ua = ua.toLowerCase();

        var match = /(chrome)[ \/]([\w.]+)/.exec(ua) ||
            /(webkit)[ \/]([\w.]+)/.exec(ua) ||
            /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(ua) ||
            /(msie)[\s?]([\w.]+)/.exec(ua) ||
            /(trident)(?:.*? rv:([\w.]+)|)/.exec(ua) ||
            ua.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(ua) ||
            [];

        return {
            browser: match[1] || "",
            version: match[2] || "0"
        };
    };

    matched = jQuery.uaMatch(navigator.userAgent);
    //IE 11+ fix (Trident) 
    matched.browser = matched.browser == 'trident' ? 'msie' : matched.browser;
    browser = {};

    if (matched.browser) {
        browser[matched.browser] = true;
        browser.version = matched.version;
    }

    // Chrome is Webkit, but Webkit is also Safari.
    if (browser.chrome) {
        browser.webkit = true;
    } else if (browser.webkit) {
        browser.safari = true;
    }

    jQuery.browser = browser;
    if (browser.version <= 8) {
        RedirecBox();
    }
    function RedirecBox() {
        var ask = window.confirm("Bạn có muốn cập nhật phiên bản IE mới để chương trình hoạt động tốt hơn");
        if (ask) {

            document.location.href = "http://www.microsoft.com/en-us/download/internet-explorer-11-for-windows-7-details.aspx";

        }
    }
</script>
<script type="text/javascript">

    var bolSubmit = false;
    var strWarningBegin = '<div class="activity-item"> <i class="fa fa-warning text-warning"></i> <div class="activity"><H3>';
    var strWarningEnd = '</H3></div> </div>';
    $(window).ready(function () {
        $('#btSearch').click(function (event) {
            event.preventDefault();
        });
    });

    function showWaiting() {
        var spWaiting = document.getElementById('spWaiting');
        if ($.blockUI) {
            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    color: '#000',
                    backgroundColor: '#fff',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .8
                }, message: '<h3><img src="Images/loader.gif" style="vertical-align: middle;"/>&nbsp;' + spWaiting.innerHTML + '</h3>'
            });
        }
    }
    function keypressSearch(e) {
        var key = e.keyCode || e.which;
        if (key == 13) {
            if (!bolSubmit) {
                checkValid();
            }
        }
    }
    function Submit() {
        if (bolSubmit) {
            var rdSearchOption = document.getElementById("UHeader1_rdSearchOption");
            var txtSearch = document.getElementById("txtSearch");
            if (rdSearchOption && txtSearch) {
                location.href = 'Oshow.aspx?rdSearchOption=' + rdSearchOption.options[rdSearchOption.selectedIndex].value + '&txtSearch=' + txtSearch.value;
                showWaiting();
            }
        }
        else {
            //unLockShowWaiting();
        }
    }
    function clickSearch() {
        var bolFocus = true; //  $('#txtSearch').is(':focus');
        if ((bolFocus) && (!bolSubmit)) {
            checkValid();
        }
    }


    function checkValid() {
        var txtSearch = document.getElementById("txtSearch");
        if (txtSearch.value == '') {
            var spInputEmpty = document.getElementById("spInputEmpty");
            showNotify('warning', strWarningBegin + spInputEmpty.innerHTML + strWarningEnd);
        }
        else {
            bolSubmit = true;
        }
        Submit();
    }
    function showNotifyAA(type, mes) {
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

    function showNotify(type, mes) {
        //type: alert, information, error, warning, notification, success
        var n = noty({
            text: mes,
            type: type,
            dismissQueue: true,
            timeout: 3000,
            modal: false,
            layout: 'bottomRight',
            theme: 'relax',
            animation: {
                open: 'animated bounceInLeft',
                close: 'animated flipOutX',
                easing: 'swing',
                speed: 500
            }
        });
    }

    function showNotifyCart(type, mes) {
        //type: alert, information, error, warning, notification, success
        var n = noty({
            text: mes,
            type: type,
            dismissQueue: true,
            timeout: 3000,
            modal: false,
            layout: 'top',
            theme: 'relax',
            animation: {
                open: 'animated bounceInDown',
                close: 'animated flipOutX',
                easing: 'swing',
                speed: 500
            }
        });
    }

    function setCart(str) {
        if ($("#UHeader1_spMyList")) {
            $("#UHeader1_spMyList").html(str);
        }
    }

    function showPopupDetail(Item) {
        var strWord = '';
        var hidSearch = parent.document.getElementById("hidSearch");
        if (hidSearch) {
            strWord = hidSearch.value;
        }
        /* $('#popup').bPopup({
        onOpen: function () {
        $('#showMe').attr('src', 'ODetail.aspx?intItemId=' + Item.toString() + '&searchWord=' + strWord);
        }
        });*/
        $.magnificPopup.open({
            items: {
                src: 'ODetail.aspx?intItemId=' + Item.toString() + '&searchWord=' + strWord
            },
            tLoading: 'Loading...',
            type: 'iframe'
        });
    }

    function showPopupRemoveAllMyList() {
        //$.magnificPopup.close();
        $.magnificPopup.open({
            items: {
                src: 'OMyList.aspx?removeAll=1'
            },
            tLoading: 'Loading...',
            type: 'iframe'
        });
    }

    function showPopupMyList() {
        $.magnificPopup.open({
            items: {
                src: 'OMyList.aspx'
            },
            tLoading: 'Loading...',
            type: 'iframe'
        });
    }

    function closeShowLogin() {
        $.magnificPopup.close();
    }

    function setUser(val, fullname) {
        /*var hidUser = document.getElementById("hidUser");
        hidUser.value = val;
        var spAccount = document.getElementById("spAccount");
        spAccount.innerHTML = fullname;
        var spLogout = document.getElementById("spLogout");
        spLoginLogout.innerHTML = spLogout.innerHTML;*/
    }

    function checkUser() {
        var bol = false;
        var hidUser = document.getElementById("UHeader1_hidUser");
        console.log(hidUser);
        if (hidUser) {
            if (hidUser.value != '') {
                bol = true;
            }
        }
        return bol;
    }

    function showLoginComment() {
        $.magnificPopup.open({
            items: {
                src: 'OLogin.aspx??comment=1'
            },
            tLoading: 'Loading...',
            type: 'iframe'
        });
    }

    function ShowRecordByItemType(FormatType) {
        self.location.href = "OShow.aspx?FormatType=" + FormatType.toString();
        showWaiting();
    }

    function gotoShowRecord(dicId, BrowseId) {
        self.location.href = "OShow.aspx?DicID=" + dicId.toString() + "&BrowseId=" + BrowseId.toString();
        showWaiting();
    }

    function showMagazineList(ItemID) {
        self.location.href = "OMagList.aspx?ItemId=" + ItemID.toString();
    }

    function addMyList(iTemId) {
        //var spInMyList = document.getElementById('spInMyList');
        changeIconStatus(iTemId, "mif-heart");
        var hidMyListIds = document.getElementById('UHeader1_hidMyListIds');
        var Ids = hidMyListIds.value;
        if (!checkExistId(iTemId, Ids)) {
            hidMyListIds.value = Ids + iTemId.toString() + ",";
            var arrListIds = Ids.split(",");
            var iItem = arrListIds.length;
            //iItem = iItem + 1;
            var str = '';
            //var spMyListTitle = document.getElementById('spMyListTitle');
            //str = '(';
            //str = str + spMyListTitle.innerHTML + ': ';
            str = str + iItem.toString();
            //str = str + ' <span class="mif-books fg-emerald"></span>)';
            //$("#spMyList").html(str);
            setCart(str);
            PageMethods.setItemToMyList(hidMyListIds.value);
            var spInCart = document.getElementById('spInCart');
            showNotifyCart('success', spInCart.innerHTML);
        }
    }

    function checkMyList(iTemId) {
        if ($('#icon' + iTemId)) {
            var iClass = $('#icon' + iTemId).attr('class');
            if (iClass == 'mif-heart-broken') {
                removeMyList(iTemId);
            }
            else {
                addMyList(iTemId);
            }
        }
    }

    function changeIconStatus(iTemId, iClass) {
        if ($('#icon' + iTemId)) {
            if (iClass == 'mif-heart-broken') {
                $('#icon' + iTemId).removeClass(iClass).addClass("mif-heart");
                $('#h' + iTemId).removeClass("uncheck");
                //$('#icon' + iTemId).css("cursor", "pointer");
            }
            else {
                $('#icon' + iTemId).removeClass(iClass).addClass("mif-heart-broken");
                $('#h' + iTemId).addClass("uncheck");
                //$('#icon' + iTemId).css("cursor", "default");
            }
            //$('#icon' + iTemId).attr("data-hint", title);
        }
        if ($('#h' + iTemId)) {
            if (iClass == 'mif-heart-broken') {
                $('#h' + iTemId).removeClass("uncheck");
                //$('#icon' + iTemId).css("cursor", "pointer");
            }
            else {
                $('#h' + iTemId).addClass("uncheck");
                //$('#icon' + iTemId).css("cursor", "default");
            }
            //$('#icon' + iTemId).attr("data-hint", title);
        }
        if ($('#spCart' + iTemId)) {
            if (iClass == 'mif-heart-broken') {
                var spSaveList = document.getElementById('spSaveList');
                if (spSaveList) {
                    $('#spCart' + iTemId).html(spSaveList.innerHTML);
                }
                //$('#icon' + iTemId).css("cursor", "pointer");
            }
            else {
                var spCancelList = document.getElementById('spCancelList');
                if (spCancelList) {
                    $('#spCart' + iTemId).html(spCancelList.innerHTML);
                }
                //$('#icon' + iTemId).css("cursor", "default");
            }
            //$('#icon' + iTemId).attr("data-hint", title);
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
        var hidMyListIds = document.getElementById('UHeader1_hidMyListIds');
        var strListIds = hidMyListIds.value;
        var strListIdsNew = strListIds.replace(iTemId.toString() + ',', '');
        hidMyListIds.value = strListIdsNew;
        var arrListIds = strListIdsNew.split(",");
        var iItem = arrListIds.length;
        iItem = iItem - 1;
        var str = '';
        //var spMyListTitle = document.getElementById('spMyListTitle');
        //str = '(';
        //str = str + spMyListTitle.innerHTML + ': ';
        str = str + iItem.toString();
        //str = str + ' <span class="mif-books fg-emerald"></span>)';
        //$("#spMyList").html(str);
        setCart(str);
        PageMethods.setItemToMyList(hidMyListIds.value);
        //var spAddToMyList = document.getElementById('spAddToMyList');
        changeIconStatus(iTemId, "mif-heart-broken");
        var spOutCart = document.getElementById('spOutCart');
        showNotifyCart('error', spOutCart.innerHTML);
    }

    function removeALlMyList() {
        var hidMyListIds = document.getElementById('UHeader1_hidMyListIds');
        var strIds = hidMyListIds.value;
        var arrayIds = strIds.split(",");
        //var spAddToMyList = document.getElementById('spAddToMyList');
        for (i = 0; i < arrayIds.length; i++) {
            changeIconStatus(arrayIds[i], "mif-heart-broken");
        }
        hidMyListIds.value = "";
        var iItem = 0;
        var str = '';
        //var spMyListTitle = document.getElementById('spMyListTitle');
        //str = '(';
        //str = str + spMyListTitle.innerHTML + ': ';
        str = str + iItem.toString();
        //str = str + ' <span class="mif-books fg-emerald"></span>)';
        //$("#spMyList").html(str);
        setCart(str);
        PageMethods.setItemToMyList(hidMyListIds.value);
        //$('#showMyList').attr('src', 'OMyList.aspx?removeAll=1');
        var spOutCart = document.getElementById('spOutCart');
        showNotifyCart('error', spOutCart.innerHTML);

        showPopupRemoveAllMyList();
    }

    function printOptions() {
        $.magnificPopup.open({
            items: {
                src: 'OPrint2List.aspx'
            },
            tLoading: 'Loading...',
            type: 'iframe'
        });
    }

    function export2File() {
        //$.magnificPopup.close();
        $.magnificPopup.open({
            items: {
                src: 'OExport2FileUI.aspx'
            },
            tLoading: 'Loading...',
            type: 'iframe'
        });
    }
    function send2Email() {
        $.magnificPopup.open({
            items: {
                src: 'OSend2Email.aspx'
            },
            tLoading: 'Loading...',
            type: 'iframe'
        });
    }

</script>

<script type="text/javascript">
    $(document).ready(function () {
        $(".menu-icon").click(function () {
            var X = $(this).attr('id');

            if (X == 1) {
                $(".submenu").hide();
                $(this).attr('id', '0');
            }
            else {

                $(".submenu").show();
                $(this).attr('id', '1');
            }

        });

        //Mouseup textarea false
        $(".submenu").mouseup(function () {
            return false
        });
        $(".menu-icon").mouseup(function () {
            return false
        });

        //Textarea without editing.
        $(document).mouseup(function () {
            $(".submenu").hide();
            $(".menu-icon").attr('id', '');
        });

    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".user-icon").attr('id', '0');
        $(".user-icon, .icon-user").click(function () {
            var X = $(".user-icon").attr('id');

            if (X == 1) {
                $(".user-menu").hide();
                $(".user-icon").attr('id', '0');
            }
            else {

                $(".user-menu").show();
                $(".user-icon").attr('id', '1');
            }

        });

        //Mouseup textarea false
        $(".user-menu").mouseup(function () {
            return false
        });
        $(".user-icon").mouseup(function () {
            return false
        });

        //Textarea without editing.
        $(document).mouseup(function () {
            $(".user-icon").attr('id', '0');
            $(".user-menu").hide();
        });

    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".head-menu-icon").click(function () {
            var X = $(this).attr('id');

            if (X == 1) {
                $(".head-submenu").hide();
                $(this).attr('id', '0');
            }
            else {

                $(".head-submenu").show();
                $(this).attr('id', '1');
            }

        });

        //Mouseup textarea false
        $(".head-submenu").mouseup(function () {
            return false
        });
        $(".head-menu-icon").mouseup(function () {
            return false
        });

        //Textarea without editing.
        $(document).mouseup(function () {
            $(".head-submenu").hide();
            $(".head-menu-icon").attr('id', '');
        });

    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".config-menu-icon").click(function () {
            var X = $(this).attr('id');

            if (X == 1) {
                $(".config-submenu").hide();
                $(this).attr('id', '0');
            }
            else {

                $(".config-submenu").show();
                $(this).attr('id', '1');
            }

        });

        //Mouseup textarea false
        $(".config-submenu").mouseup(function () {
            return false
        });
        $(".config-menu-icon").mouseup(function () {
            return false
        });

        //Textarea without editing.
        $(document).mouseup(function () {
            $(".config-submenu").hide();
            $(".config-menu-icon").attr('id', '');
        });

    });
</script>

<script type="text/javascript">
    $(document).ready(function () {

        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('.scrollup').fadeIn();
            } else {
                $('.scrollup').fadeOut();
            }
        });

        $('.scrollup').click(function () {
            $("html, body").animate({ scrollTop: 0 }, 600);
            return false;
        });

        var visiblebarUser = false;
        var visibleSSCToolBar = false;
        var visibleHeadSubmenu = false;
        var visibleSSCToolBarClick = false;
        $(".BarUser").click(function () {
            if (visiblebarUser === false) {
                $(".SSCUserBar").show();
                visiblebarUser = true;

            } else {
                $(".SSCUserBar").hide();
                visiblebarUser = false;
            }
            visibleSSCToolBar = false;
            visibleHeadSubmenu = false;
            $(".head-submenu").hide();
            $(".submenu").hide();
        });
        $(".head-menu").click(function () {
            console.log(visibleSSCToolBar);
            if (visibleSSCToolBar === false) {
                $(".submenu").show();
                visibleSSCToolBar = true;
            } else {
                $(".submenu").hide();
                visibleSSCToolBar = false;
            }
            visiblebarUser = false;
            visibleHeadSubmenu = false;
            visibleSSCToolBarClick = true;
            $(".head-submenu").hide();
            $(".SSCUserBar").hide();
        });
        $(".dropdown-menu").click(function () {
            //console.log(this);
            $(".head-submenu").removeAttr('style');
            if (visibleHeadSubmenu === false) {
                $(".head-submenu").show();
                visibleHeadSubmenu = true;

            } else {
                $(".head-submenu").hide();
                visibleHeadSubmenu = false;
            }
            visiblebarUser = false;
            if (!visibleSSCToolBarClick) {
                visibleSSCToolBar = false;
                visibleSSCToolBarClick = false;
            }
            $(".submenu").hide();
            $(".SSCUserBar").hide();
        });
    });
</script>

<div id="divBannerTop">
    <div class="web-size ClearFix">
        <img class="" src="Images/Header/mut-banner.jpg" />
    </div>
</div>
<div class="SSCBar">
    <div id="divTopHeader" class="ClearFix">
        <div id="HeaderRight">

            <div id="divLogin" class="ClearFix">
                <div class="SSCBarLogin">
                    <div class="PersonalOut" >
                        <input type="button" value="Đăng nhập" id="btnStudentLogin" class="LogoutBtn" runat="server" />
                        <input type="button" value="Đăng xuất" id="btnLogout" class="LogoutBtn" runat="server" visible="false" />
                    </div>
                    <div class="BarItem BarUser">
                        <a href="#" class="user-icon"><span runat="server" class="user-link" id="spFullName"></span><i class="icon-user" style="font-size: 20px; background: #fff; color: #096; padding: 5px; border-radius: 50%;" data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white' data-hint="Tài khoản"></i></a>
                        <div class="SSCUserBar user-menu">
                            <div class="InputUserInfo fadeIn animated">
                                <div class="divPersonal">
                                    <div class="NarrowUser">
                                        <div class="FormArrow">
                                            <span class="NarrowBorder"></span>
                                            <span class="NarrowBG"></span>
                                        </div>
                                    </div>

                                    <div class="PersonalForm ClearFix">
                                        <div class="PersonalLeft"><i class="icon-user-3 UserIcon"></i></div>
                                        <div class="PersonalRight">
                                            <asp:Literal runat="server" ID="ltrAccountInfo"></asp:Literal>
                                            <%--<h3>Hứa Lê Ngọc</h3>
                                                <h4>ngocpromise@gmail.com</h4>
                                                <a href="#">Thiết lập tài khoản</a>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="HeaderLeft" class="fadeInLeft animated">
            <a href="OIndex.aspx">
                <img src="Resources/StyleSheet/ssc/images/design/Logo.png" data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white' data-hint="Trang chủ" /></a>
        </div>
        <div id="divSearch" class="ClearFix fadeInLeft animated">
            <div id="SearchForm" class="ClearFix">
                <div class="select-box">
                    <select id="rdSearchOption" runat="server">
                        <option value="1">Tài liệu in (Biên mục)</option>
                        <option value="2">Tài liệu số (Toàn văn)</option>
                    </select>
                </div>
                <div class="search-box">
                    <input class="InputSearch" type="text" id="txtSearch" placeholder="Tìm kiếm tài liệu ở đây" onkeypress="keypressSearch(event);" />
                    <div class="btn-search">
                        <input type="button" class="btnSearch" id="btSearch" onclick="clickSearch()" />
                        <span class="icon-search"></span>
                    </div>
                </div>
            </div>
            <a class="search-link" href="OSearchAdvanced.aspx">Tìm kiếm nâng cao</a>
        </div>
    </div>
</div>
<header>
    <nav class="clr-amber">
        <div class="control-head-menu  web-size ClearFix">
            <div class="control-left">
                <div class="dropdown-menu">
                    <a href="#" class="head-menu-icon"><span class="icon-drop-menu mif-list"></span></a>
                </div>
                <div class="head-submenu animated fadeIn" style="display: none;">
                    <div class="sub-list-menu">
                        <ul>
                            <li><a href="#" class="main-sub-icon"><span class="icon-drop-menu mif-apps"></span>Danh mục</a>
                                <div class="group-item">
                                    <h1><a href="javascript:ShowRecordByItemType(4);"><span class="icon-book"></span>Tài liệu số (Toàn văn)</a></h1>
                                    <h1><a href="javascript:ShowRecordByItemType(3);"><span class="mif-database"></span>Sách nói</a></h1>
                                    <h1><a href="javascript:ShowRecordByItemType(2);"><span class="icon-film"></span>Phim ảnh</a></h1>
                                    <h1><a href="javascript:ShowRecordByItemType(1);"><span class="icon-screen"></span>Hình ảnh</a></h1>
                                    <h1><a href="javascript:gotoShowRecord(11,7);"><span class="icon-newspaper"></span>Báo/Tạp chí điện tử</a></h1>
                                    <h1><a href="javascript:gotoShowRecord(10,1);"><span class="mif-quote"></span>Sách truyền thống</a></h1>
                                </div>
                            </li>
                            <li>
                                <a href="#" class="main-sub-icon"><span class="icon-drop-menu mif-sort-asc"></span>Duyệt theo</a>
                                <div class="group-item">
                                    <h1><a href="OBrowse.aspx?DicID=14"><span class="mif-cabinet"></span>Bộ sưu tập</a></h1>
                                    <h1><a href="OBrowse.aspx?DicID=12"><span class="mif-list"></span>Danh mục</a></h1>
                                    <h1><a href="OBrowse.aspx?DicID=13"><span class="mif-spell-check"></span>Nhan đề</a></h1>
                                    <h1><a href="OBrowse.aspx?DicID=1"><span class="mif-users"></span>Tác giả</a></h1>
                                    <h1><a href="OBrowse.aspx?DicID=9"><span class="mif-calendar"></span>Năm xuất bản</a></h1>
                                    <h1><a href="OBrowse.aspx?DicID=2"><span class="mif-bookmark"></span>Nhà xuất bản</a></h1>
                                    <%--<h1><a href="OBrowse.aspx?DicID=5"><span class="mif-tag"></span>Tiêu đề đề mục</a></h1>--%>
                                    <h1><a href="OBrowse.aspx?DicID=3"><span class="mif-target"></span>Từ khóa</a></h1>
                                    <h1><a href="OBrowse.aspx?DicID=10"><span class="mif-shareable"></span>Dạng tài liệu</a></h1>
                                    <%--<h1><a href="OBrowse.aspx?DicID=11"><span class="mif-cogs"></span>Tài liệu số (Toàn văn)</a></h1>--%>
                                </div>
                            </li>
                            <li>
                                <a href="#" class="main-sub-icon"><span class="icon-drop-menu mif-search"></span>Tìm kiếm</a>
                                <div class="group-item">
                                    <h1><a href="OSearchAdvanced.aspx"><span class="mif-filter"></span>Tìm kiếm nâng cao</a></h1>
                                    <h1><a href="OZ3950.aspx"><span class="mif-rocket"></span>Tìm kiếm Z39.50</a></h1>
                                </div>
                            </li>
                            <li>
                                <a href="#" class="main-sub-icon"><span class="icon-drop-menu mif-file-text"></span>Thông tin thư viện</a>
                                <div class="group-item">
                                    <h1><a href="ONews.aspx"><span class="mif-command"></span>Tin tức</a></h1>
                                    <h1><a href="OWebUseful.aspx"><span class="mif-earth"></span>Website hữu ích</a></h1>
                                </div>
                            </li>
                        </ul>
                        <div class="group-menu">
                        </div>
                    </div>
                </div>
                <div class="menu-head-list">
                    <ul style="display: none;">
                        <li><a href="OIndex.aspx">
                            <p>Thư viện điện tử</p>
                        </a></li>
                    </ul>
                    <ul>
                        <%
                            Dim strDicID As String = ""
                            Dim bCurrentPageOBrowse As Boolean = False
                            Dim strCurrentPage As String = HttpContext.Current.Request.Url.AbsolutePath
                            If Not (IsNothing(Request("DicID"))) Then
                                strDicID = Request("DicID")
                            End If
                            
                            If strCurrentPage.Length > 0 Then
                                strCurrentPage = strCurrentPage.Substring(1).Replace(".aspx","")
                            End If
                            
                            If strCurrentPage = "OBrowse" Then
                                bCurrentPageOBrowse = True
                            End If
                        %>
                        <li><a href="OIndex.aspx">
                            <p><span class="mif-cabinet"></span>Trang Chủ</p>
                        </a></li>
                        <li class="<%= If(bCurrentPageOBrowse And strDicID = "14", "active", "")%>" style="display:none"><a href="OBrowse.aspx?DicID=14">
                            <p><span class="mif-cabinet"></span>Bộ sưu tập</p>
                        </a></li>
                        
                        <li class="<%= If(bCurrentPageOBrowse And strDicID = "13", "active", "")%>"><a href="OBrowse.aspx?DicID=13">
                            <p><span class="mif-spell-check"></span>Nhan đề</p>
                        </a></li>
                        <li class="<%= If(bCurrentPageOBrowse And strDicID = "1", "active", "")%>"><a href="OBrowse.aspx?DicID=1">
                            <p><span class="mif-users"></span>Tác giả</p>
                        </a></li>
                        <li style="display:none" class="<%= If(bCurrentPageOBrowse And strDicID = "9", "active", "")%>"><a href="OBrowse.aspx?DicID=9">
                            <p><span class="mif-calendar"></span>Năm xuất bản</p>
                        </a></li>
                        <li style="display:none" class="<%= If(bCurrentPageOBrowse And strDicID = "2", "active", "")%>"><a href="OBrowse.aspx?DicID=2">
                            <p><span class="mif-bookmark"></span>Nhà xuất bản</p>
                        </a></li>
                        <li class="<%= If(bCurrentPageOBrowse And strDicID = "3", "active", "")%>"><a href="OBrowse.aspx?DicID=3">
                            <p><span class="mif-target"></span>Từ khóa</p>
                        </a></li>
                        <li style="display:none" class="<%= If(bCurrentPageOBrowse And strDicID = "10", "active", "")%>"><a href="OBrowse.aspx?DicID=10">
                            <p><span class="mif-shareable"></span>Dạng tài liệu</p></a>
                        </li>
                        <li style="display:none" class="<%= If(bCurrentPageOBrowse And strDicID = "12", "active", "")%>"><a href="OBrowse.aspx?DicID=12">
                            <p><span class="mif-list"></span>Danh mục<p>
                        </a></li>
                        <%--<li>
                            <a href="OAbout.aspx?link=0">
                                <p>Giới thiệu</p>
                            </a>
                        </li>
                        <li>
                            <a href="OAbout.aspx?link=1">
                                <p>Nội quy thư viện</p>
                            </a>
                        </li>--%>
                        <%-- 
                        <li class="<%= If(bCurrentPageOBrowse And strDicID = "11", "active", "")%>"><a href="OBrowse.aspx?DicID=11">
                            <p><span class="mif-shareable"></span>Tài liệu số (Toàn văn)</p></a>
                        </li
                         --%>
                    </ul>
                </div>
            </div>
            <div class="place-right mif-favorite mif-3x fg-emerald" onclick="showPopupMyList();" style="cursor: pointer; margin-top: -5px; margin-right:10px;" data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white' data-hint="Danh sách yêu thích" data-hint-position="left">
                <div style="position:relative;">
                    <div id="spMyList" runat="server" style="font-size: large; top: -31px; color: white; position:absolute; right: 16px;"></div>
                </div>
            </div>
            <div style="position:relative; display:none">
                <p style="position:absolute; top: -5px; right:10px; ">
                    <a href="#FacebookTop" onclick="shareFacebook('<%=Request.Url.Authority %>')">
                        <img id="FacebookTop" src="Images/Icons/logo-facebook.png" style="border:none; width:45px;" />
                    </a>
                </p>
            </div>
        </div>
    </nav>
</header>
<div style="display: none;">
    <span id="spInCart">Bạn đã lưu vào mục danh sách</span>
    <span id="spOutCart">Bạn đã hủy mục danh sách</span>
    <span id="spWaiting">Xin vui lòng đợi trong chốc lát...</span>
    <span id="spAccountConfig" runat="server">Trang cá nhân</span>
    <span id="spInputEmpty">Bạn vui lòng nhập vào thông tin tìm kiếm.</span>
    <input id="hidMyListIds" type="hidden" value="" runat="server" />
    <span id="spSearchAll" runat="server">Toàn bộ</span>
    <span id="spSearchFulltext" runat="server">Tài liệu số (Toàn văn)</span>
    <input id="hidUser" type="hidden" value="" runat="server" />
    <span class="icon-user" id="spAccount" runat="server">Xin chào, khách!</span>
    <span id="spLogin" runat="server">Đăng nhập</span>
    <span id="spLogout" runat="server">Đăng xuất</span>
    <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Height="0" Visible="False">
        <asp:ListItem Value="0">Tài khoản chưa được nhập vào hệ thống !</asp:ListItem>
        <asp:ListItem Value="1">Hiện tại thẻ này đang bị khoá !</asp:ListItem>
        <asp:ListItem Value="2">Số thẻ không được để trống !</asp:ListItem>
        <asp:ListItem Value="3">Mật khẩu không được để trống !</asp:ListItem>
        <asp:ListItem Value="4">Hiện tại thẻ này đã hết hạn sử dụng !</asp:ListItem>
    </asp:DropDownList>
</div>


<script type="text/javascript">
    function shareFacebook(strUrl) {
        window.open("https://www.facebook.com/sharer/sharer.php?kid_directed_site=0&u=" + strUrl + "&display=popup&ref=plugin&src=share_button", "_blank", "top=500,left=500");
    }
</script>