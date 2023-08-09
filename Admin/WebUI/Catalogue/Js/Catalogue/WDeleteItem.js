function CheckNullInput(msg) {
    var chk;
    chk = (CheckNull(document.forms[0].txtTitle) && document.forms[0].ddlItemInfor.selectedIndex==0) &&
			//CheckNull(document.forms[0].txtCopyNumber) && 	
			CheckNull(document.forms[0].txtISBN) &&
			CheckNull(document.forms[0].txtAuthor) &&
			CheckNull(document.forms[0].txtPublisher) &&
			CheckNull(document.forms[0].txtItemCode) &&
			CheckNull(document.forms[0].txtCopyNumber) &&
			CheckNull(document.forms[0].txtYear)
    if (chk) {
        alert(msg);
        eval(document.forms[0].txtFromCode).focus();
        return false;
    } else {
        return true;
    }
}
function CheckNullAll(msg) {
    var chk;
    chk = (CheckNull(document.forms[0].txtTitle) && document.forms[0].ddlItemInfor.selectedIndex == 0) &&
			CheckNull(document.forms[0].txtCopyNumber) &&
			CheckNull(document.forms[0].txtISBN) &&
			CheckNull(document.forms[0].txtAuthor) &&
			CheckNull(document.forms[0].txtPublisher) &&
			CheckNull(document.forms[0].txtYear) &&
			CheckNull(document.forms[0].txtItemCode)
    if (chk) {
        alert(msg);
        document.forms[0].txtTitle.focus();
        return false;
    } else {
        return true;
    }
}
/*
function ResetForm() {
	document.forms[0].txtTitle.value="";
	document.forms[0].txtCopyNumber.value="";
	document.forms[0].txtISBN.value="";
	document.forms[0].txtAuthor.value="";
	document.forms[0].txtPublisher.value="";
	document.forms[0].txtPublisher.txtYear="";
	document.forms[0].txtTitle.focus();
	return false;
	
}
*/
function ResetForm() {
    document.forms[0].txtTitle.value = "";
    document.forms[0].txtFromCode.value = "";
    document.forms[0].txtToCode.value = "";
    document.forms[0].txtAuthor.value = "";
    document.forms[0].txtPublisher.value = "";
    document.forms[0].txtYear.value = "";
    document.forms[0].txtISBN.value = '';
    document.forms[0].txtFromCode.focus();
    return false;
}

function ResetFormSearch() {
    document.forms[0].txtTitle.value = "";
    document.forms[0].txtCopyNumber.value = "";
    document.forms[0].txtPublisher.value = "";
    document.forms[0].txtAuthor.value = "";
    document.forms[0].txtYear.value = "";
    document.forms[0].txtISBN.value = '';
    document.forms[0].txtTitle.focus();
    return false;
}

//Use for WDeleteItem.aspx
function rdoEvent(val, iRow) {
    //chkChoice
    eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;
    eval('document.forms[0].chkChoice' + val).checked = !eval('document.forms[0].chkChoice' + val).checked;
    //rdoChoice		
    for (var i = 0; i < document.forms[0].rdoChoice.length; i++) {
        if (i == iRow)
            document.forms[0].rdoChoice[i].checked = true;
        else
            document.forms[0].rdoChoice[i].checked = false;
    }
    GetCheckboxValue();
}


// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg) {
    var intCounter;
    var intCount;

    intCount = 0;

    for (intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++)
    {
        if (intCounter < 10) {
            if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked) {
                intCount = intCount + 1;
            }
        } else {
            if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked) {
                intCount = intCount + 1;
            }
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


// Confirm the delete (YES = Do action, NO = Cancel)
function ConfirmDelete(msg) {
    var truthBeTold = window.confirm(msg);
    if (truthBeTold) {
        return true;
    } else {
        return false;
    }
}


// If find an check object, check, if not, through away

function CheckOptionVisible(strDtgName, strOptionName, intvalue) {
    var blnStatus;

    if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName)) {
        if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked) {
            blnStatus = false;
        }
        else {
            blnStatus = true;
        }
        eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked = blnStatus;
    }

}

//
function chkEvent(val) {
    eval('document.forms[0].DgrResult__ctl' + val + 'CheckItemID').checked = !eval('document.forms[0].DgrResult__ctl' + val + 'CheckItemID').checked;
    //GetCheckboxValue();
}
function GotoModify(ItemID) {
    parent.Sentform.location.href = 'WCataModify.aspx?ItemID=' + ItemID + '&CurrentID=0';
}

function FindGotoModify(ItemID) {
    parent.Sentform.location.href = 'WCataModify.aspx?FindModify=1&ItemID=' + ItemID + '&CurrentID=0';
}


