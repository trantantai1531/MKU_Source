function showRecord(pg) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = pg;
    var raiseShowRecord = document.getElementById('raiseShowRecord');
    raiseShowRecord.click();
}

function removeMyList(iTemId) {    
    var id = parseInt(iTemId);   
    parent.removeMyList(id);
    var hidItem = document.getElementById('hidItem');
    hidItem.value = id;
    var raiseRemoveItem = document.getElementById('raiseRemoveItem');
    raiseRemoveItem.click();
}

function showPopupDetail(iTemId) {
    parent.showPopupDetail(iTemId);
}