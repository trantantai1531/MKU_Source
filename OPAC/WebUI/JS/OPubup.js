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
    $('#showMyList').attr('src', 'OMyList.aspx?removeAll=1');
}

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

function fnShowMyList() {
    window.scrollTo(0, 10);
    $('#popupMyList').bPopup({
        onOpen: function () {
            $('#showMyList').attr('src', 'OMyList.aspx');
        }
    });
}