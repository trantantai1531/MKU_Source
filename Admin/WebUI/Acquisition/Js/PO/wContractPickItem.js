// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg) {
    var intCounter;
    var intCount;

    intCount = 0;

    for (intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {
        if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked) {
            intCount = intCount + 1;
        }
    }
    if (intCount != 0) {
        return true;
    }
    else {
        alert(strMsg);
        return false;
    }
}
