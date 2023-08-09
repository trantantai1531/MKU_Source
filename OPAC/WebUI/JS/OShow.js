var bolFilter = true;

function filterObject(dicId, dicName, Id, status) {
    var hidCurrentPage = document.getElementById('hidCurrentPage');
    hidCurrentPage.value = 1;//Reset current page.
    var hidFilterStatus = document.getElementById('hidFilterStatus');
    hidFilterStatus.value = status;
    var hidBrowseId = document.getElementById('hidBrowseId');
    hidBrowseId.value = Id; //pass publisher year
    var hidDicId = document.getElementById('hidDicId');
    hidDicId.value = dicId;
    var hidDicName = document.getElementById('hidDicName');
    hidDicName.value = dicName;
    var raiseFilter = document.getElementById('raiseFilter');
    if (bolFilter) {
        raiseFilter.click();
        parent.showWaiting();
    }
    if (status == 0) {
        bolFilter = false;//Prevent submit twice
    }
}
function showMe(obj, showObj, hiddenObj) {
    $("#" + obj).show();
    $("#" + hiddenObj).show();
    $("#" + showObj).hide();
}
function hiddenMe(obj, showObj, hiddenObj) {
    $("#" + obj).hide();
    $("#" + hiddenObj).hide();
    $("#" + showObj).show();
}

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

function myListInfo() {
    var hidMyListIds = document.getElementById('hidMyListIds');
    var strListIds = hidMyListIds.value;
    var arrListIds = strListIds.split(",");
    //var spMyListTitle = document.getElementById('spMyListTitle');
    var str = '';
    str = '<strong>';
    //str = str + spMyListTitle.innerHTML + ': ';
    str = str + (arrListIds.length - 1).toString();
    str = str + '</strong>';
    $("#spMyListShow").html(str);
}
/*
$(function () {
    $(".rounded").draggable({
        revert: "invalid", // when not dropped, the item will revert back to its initial position
        appendTo: "body",
        helper: "clone"
    });
    $("#cart").droppable({
        accept: ".rounded",
        activeClass: "ui-state-default",
        hoverClass: "ui-state-hover",
        drop: function (event, ui) {
            var draggableId = ui.draggable.attr("id");
            addMyList(draggableId);
        }
    });

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
*/




function printOptions() {
    $('#popupPrintOptions').bPopup({
        follow: [false, false]
    });
}

function processPrintOptions() {    
    var txtReportTitle = document.getElementById('txtReportTitle');
    var intOrder = $("input:checked").val();
    var a = document.createElement("a");
    a.href = "OPrint.aspx?orderBy=" + intOrder.toString() + "&reportTitle=" + txtReportTitle.value;
    a.target = "_blank";
    document.body.appendChild(a);
    a.click();
    var bPopup = $('#popupPrintOptions').bPopup();
    bPopup.close();
}


var bolSubmitInResult = false;

function keySearchInResult(e) {
    var key = e.keyCode || e.which;
    if (key == 13) {
        if (!bolSubmitInResult) {
            checkValidInResult();
        }
    }
}

function searchInResult(e) {
    if (!bolSubmitInResult) {
        checkValidInResult();
    }
}

function SubmitInResult() {
    if (bolSubmitInResult) {
        var raiseFilterInResult = document.getElementById("raiseFilterInResult");
        if (raiseFilterInResult) {
            raiseFilterInResult.click();
            parent.showWaiting();
        }
    }
}

function checkValidInResult() {
    var txtSearchInResult = document.getElementById("txtSearchInResult");
    if (txtSearchInResult.value == '') {
        var spInfoSearchInResult = document.getElementById("spInfoSearchInResult");
        parent.showNotify('warning', parent.strWarningBegin + spInfoSearchInResult.innerHTML + parent.strWarningEnd);
    }
    else {
        var hidSearchInResult = document.getElementById("hidSearchInResult");
        hidSearchInResult.value = txtSearchInResult.value;
        bolSubmitInResult = true;
    }
    SubmitInResult();
}

function deleteFilterInResult(val) { 
    var hidSearchInResult = document.getElementById("hidSearchInResult");
    hidSearchInResult.value = val;
    var raiseDeleteFilterInResult = document.getElementById("raiseDeleteFilterInResult");
    if (raiseDeleteFilterInResult) {
        raiseDeleteFilterInResult.click();
        parent.showWaiting();
    }
}

function gotoShow(val,muti) {
    self.location.href = "OShow.aspx?NoFilter=" + val.toString() + '&MutiLibrary=' + muti.toString();
}

function showBrowseMore(dicID) {
  $.magnificPopup.open({
      items: {
          src: 'OBrowseMore.aspx?dicID=' + dicID.toString()
      },
      tLoading: 'Loading...',
      type: 'iframe'
  });
}

function returnShow() {
    //var bpopupBrowseMore = $('#popupBrowseMore').bPopup();
    // bpopupBrowseMore.close();
    $.magnificPopup.close();
}
