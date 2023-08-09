/**********************************************************************************/
/********************		WStatClassCopyNumbeSel Js file		*******************/
/**********************************************************************************/
function TransferData(strMsgTimeFrom,strMsgTimeTo,strURL){
	if(!CheckDate(document.forms[0].txtTimeFrom,'dd/mm/yyyy',strMsgTimeFrom)){//loi kieu ngay thang
		document.forms[0].txtTimeFrom.focus();
		return false;
	}
	if(!CheckDate(document.forms[0].txtTimeTo,'dd/mm/yyyy',strMsgTimeTo)){ //loi kieu ngay thang
		document.forms[0].txtTimeTo.focus();
		return false;
	}
	self.location.href=strURL + '?ItemTypeID=' + document.forms[0].ddlItemType.options[document.forms[0].ddlItemType.options.selectedIndex].value + '&TimeFrom=' + document.forms[0].txtTimeFrom.value + '&TimeTo=' + document.forms[0].txtTimeTo.value;
	return false;
}
function TransferExport(strMsgTimeFrom, strMsgTimeTo, strURL) {
    if (!CheckDate(document.forms[0].txtTimeFrom, 'dd/mm/yyyy', strMsgTimeFrom)) {//loi kieu ngay thang
        document.forms[0].txtTimeFrom.focus();
        return false;
    }
    if (!CheckDate(document.forms[0].txtTimeTo, 'dd/mm/yyyy', strMsgTimeTo)) { //loi kieu ngay thang
        document.forms[0].txtTimeTo.focus();
        return false;
    }
    self.location.href = strURL + '?export=true&ItemTypeID=' + document.forms[0].ddlItemType.options[document.forms[0].ddlItemType.options.selectedIndex].value + '&TimeFrom=' + document.forms[0].txtTimeFrom.value + '&TimeTo=' + document.forms[0].txtTimeTo.value;
    return false;
}