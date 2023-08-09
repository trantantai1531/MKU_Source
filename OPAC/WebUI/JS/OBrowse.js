function showRecord(pg) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = pg;
    var raiseShowRecord = document.getElementById('raiseShowRecord');
    raiseShowRecord.click();
    parent.showWaiting();
}

function showRecordOrderBy(pg, e) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = pg;
    var hidOrderBy = document.getElementById('hidOrderBy');
    hidOrderBy.value = e.options[e.selectedIndex].value;
    var raiseOrderBy = document.getElementById('raiseOrderBy');
    raiseOrderBy.click();
    parent.showWaiting();
}

$(function () {

    $("#back-top").hide();

    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('#back-top').fadeIn();
        } else {
            $('#back-top').fadeOut();
        }
    });

    // scroll body to 0px on click
    $('#back-top a').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });
});

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
            parent.showWaiting();
        }
    }
}

function checkValidBrowse() {
    var txtSearchBrowse = document.getElementById("txtSearchBrowse");
    if (txtSearchBrowse.value == '') {
        var spInputEmptyBrowse = document.getElementById("spInputEmptyBrowse");
        parent.showNotify('warning', parent.strWarningBegin + spInputEmptyBrowse.innerHTML + parent.strWarningEnd);
    }
    else {
        var hidSearchBrowse = document.getElementById("hidSearchBrowse");
        hidSearchBrowse.value = txtSearchBrowse.value;
        bolSubmitBrowse = true;
    }
    SubmitBrowse();
}

function gotoShowRecord(dicId, BrowseId) {
    self.location.href = "OShow.aspx?DicID=" + dicId.toString() + "&BrowseId=" + BrowseId.toString();
    parent.showWaiting();
}