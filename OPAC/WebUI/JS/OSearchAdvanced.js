function ResetAll(){
	document.forms[0].reset();
	return false;
}

function ValidData() {
    var blnOK;
    var Msg = document.forms[0].txtMsg.value;
    blnOK = CheckNull(document.forms[0].txtFieldValue1);
    blnOK = blnOK && CheckNull(document.forms[0].txtFieldValue2);
    blnOK = blnOK && CheckNull(document.forms[0].txtFieldValue3);
    //blnOK = blnOK && CheckNull(document.forms[0].txtFieldValue4);
    if (blnOK) {
        document.forms[0].txtFieldValue1.focus();
        parent.showNotify('warning', parent.strWarningBegin + Msg + parent.strWarningEnd);
        return false;
    } else {
        parent.showWaiting();
        return true;
    }
}

function CheckNull(obj) {
    strValue = eval(obj).value;
    if (strValue == "") {
        this.value = '';
        this.focus();
        return true;
    }
    else {
        Status = 0;
        for (i = 0; i < strValue.length; i++) {
            if (strValue.charAt(i) != " ") {
                Status = 1;
                break;
            }
        }
        if (Status == 0) {
            return true;
        }
        else {
            this.value = '';
            this.focus();
            return false;
        }
    }
}