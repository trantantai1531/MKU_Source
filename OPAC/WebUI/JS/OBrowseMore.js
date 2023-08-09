function showRecord(pg) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = pg;
    var raiseShowRecord = document.getElementById('raiseShowRecord');
    raiseShowRecord.click();
}

function showRecordOrderBy(pg, e) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = pg;
    var hidOrderBy = document.getElementById('hidOrderBy');
    hidOrderBy.value = e.options[e.selectedIndex].value; ;
    var raiseOrderBy = document.getElementById('raiseOrderBy');
    raiseOrderBy.click();
}

function OpenOBrowse(dicID) {
    self.location.href = "OBrowse.aspx?DicID=" + dicID.toString();
}

var bolSubmitBrowse = false;

function keySearchBrowse(e) {
    var key = e.keyCode || e.which;
    if (key == 13) {
        if (!bolSubmitBrowse) {
            checkValidBrowse();
        }
    }
}

function searchBrowse(e) {
    if (!bolSubmitBrowse) {
        checkValidBrowse();   
    }
}

function SubmitBrowse() {
    if (bolSubmitBrowse) {
        var btSubmitBrowse = document.getElementById("btSubmitBrowse");
        if (btSubmitBrowse) {
            btSubmitBrowse.click();
        }
    }
}

function checkValidBrowse() {
    var txtSearchBrowse = document.getElementById("txtSearchBrowse");
    if (txtSearchBrowse.value == '') {
        var spInputEmptyBrowse = document.getElementById("spInputEmptyBrowse");
        parent.showNotify(1, spInputEmptyBrowse.innerHTML);
    }
    else {
        var hidSearchBrowse = document.getElementById("hidSearchBrowse");
        hidSearchBrowse.value = txtSearchBrowse.value;
        bolSubmitBrowse = true;
    }
    SubmitBrowse();
}

function gotoShowRecord(dicId, dicName, Id, status) {
    parent.filterObject(dicId, dicName, Id, status);
    returnShowRecord();  
}

function returnShowRecord() {
    parent.returnShow();
}

