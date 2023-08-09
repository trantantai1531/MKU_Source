function viewRecord(val){
    var hidView = document.getElementById('hidView');
    hidView.value = val;
    var raiseView = document.getElementById('raiseView');
    raiseView.click();
}
var tabId = 'ISBD';
function setTab(val) {
    tabId = val;
}
function changeTab(val) {
    $('#liISBD').removeClass("active");
    switch (val) {
        case 'SIMPLE':
            $('#liSimple').addClass("active");
            $('#SimpleDisplay').show();
            $('#ISBDDisplay').hide();
            $('#FullDisplay').hide();
            $('#MARCDisplay').hide();
            $('#divRelation').hide();
            break;
        case 'ISBD':
            $('#liISBD').addClass("active");
            $('#SimpleDisplay').hide();
            $('#ISBDDisplay').show();
            $('#FullDisplay').hide();
            $('#MARCDisplay').hide();
            $('#divRelation').hide();
            break;
        case 'FULLRECORD':
            $('#liFULLRECORD').addClass("active");
            $('#SimpleDisplay').hide();
            $('#ISBDDisplay').hide();
            $('#FullDisplay').show();
            $('#MARCDisplay').hide();
            $('#divRelation').hide();
            break;
         case 'MARC':
            $('#liMARC').addClass("active");
            $('#SimpleDisplay').hide();
            $('#ISBDDisplay').hide();
            $('#FullDisplay').hide();
            $('#MARCDisplay').show();
            $('#divRelation').hide();
            break;
        case 'RELATION':
            $('#liRelation').addClass("active");
            $('#SimpleDisplay').hide();
            $('#ISBDDisplay').hide();
            $('#FullDisplay').hide();
            $('#MARCDisplay').hide();
            $('#divRelation').show();
            break;
    }
}

function addMyList(Item) {
    parent.addMyList(Item);
    var spInMyList = document.getElementById('spInMyList');
    changeIconStatus(Item, "icon-checkmark", spInMyList.innerHTML);
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

function viewDetail(ItemID) {
    var strWord = '';
    var hidSearch = parent.document.getElementById("hidSearch");
    if (hidSearch) {
        strWord = hidSearch.value;
    }
    location.href = 'ODetail.aspx?intItemId=' + ItemID.toString() + '&searchWord=' + strWord;
}

 $(document).ready(function () {
     changeTab(tabId);
 });

 function gotoShowRecord(dicId, BrowseId) {
     top.location.href = "OShow.aspx?DicID=" + dicId.toString() + "&BrowseId=" + BrowseId.toString();
 }