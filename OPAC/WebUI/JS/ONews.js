function showRecord(pg,Ids) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = pg;
    var hidIds = document.getElementById('hidIds');
    hidIds.value = Ids;
    var raiseShowRecord = document.getElementById('raiseShowRecord');
    raiseShowRecord.click();
    parent.showWaiting();
}