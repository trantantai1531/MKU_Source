// PostItemID fuction
function PostItemID(intItemID) {
    parent.Sentform.document.forms[0].ItemID.value = intItemID;
    return;
}

// LoadControlBar function
function LoadControlBar() {
    if (eval(parent.Sentform.document.forms[0].txtMaxReNum).value != 1) {
        parent.Sentform.document.forms[0].submit();
        parent.Sentform.document.forms[0].ddlView.options.selectedIndex = 0;
        return;
    }
    else {
        parent.Sentform.document.forms[0].btnCancelFil.click();
        parent.Sentform.document.forms[0].submit();
        return;
    }
}

// LoadBack function
function LoadBack(strmsg) {
    alert(strmsg);
    parent.Sentform.document.forms[0].submit();
    parent.Sentform.document.forms[0].ddlView.options.selectedIndex = 0;
    return;
}