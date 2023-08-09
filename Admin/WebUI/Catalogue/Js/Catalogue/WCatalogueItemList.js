function OpenProperty(intItemID) {
    window.open("WCataloguePropertyPopup.aspx?intItemID=" + intItemID, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=400,width=800,height=800");
}

function DeleteItem(strCode) {
    if (confirm('Bạn có chắc muốn xóa tài liệu ' + strCode + ' ?')) {
        return true;
    }
    else {
        return false;
    }
}

function LoadControlBar() {
    if (eval(parent.Sentform.document.forms[0].txtMaxReNum).value != 1) {
        parent.Sentform.document.location.href = 'WControlBarItemList.aspx?intTopNum=10&intPage=' + eval(parent.Sentform.document.forms[0].txtReNum).value;
    }
    else {
        parent.Sentform.document.location.href = 'WControlBarItemList.aspx?intTopNum=10&intPage=1';
    }
}

function ChangeToModifyPage(intCurrentID, intItemID, intFormID) {
    var strURL;
    strURL = "WCataModify.aspx?CurrentID=" + intCurrentID + "&ItemID=" + intItemID + "&FormID=" + intFormID;
    parent.Sentform.document.location.href = strURL;
}
function ChangeToReusePage(intCurrentID, intItemID, intFormID) {
    var strURL;
    strURL = "WCataModify.aspx?Reuse=1&CurrentID=" + intCurrentID + "&ItemID=" + intItemID + "&FormID=" + intFormID + "&IsCopy=1";
    parent.Sentform.document.location.href = strURL;
}