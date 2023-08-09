/*
	funtion CheckAll
	Purpose: Check all need fields
*/
function CheckAll(strMess, strDateFormat) {
	if (CheckNull(document.forms[0].txbReceiptNo)) {
		document.forms[0].txbReceiptNo.focus();
		alert(strMess);
		return false;
	}
	if (CheckNull(document.forms[0].txbPOName)) {
		document.forms[0].txbPOName.focus();
		alert(strMess);
		return false;
	}
	if (CheckNull(document.forms[0].txbValidDate)) {		
		document.forms[0].txbValidDate.focus();
		alert(strMess);
		return false;
	}
	if (CheckNull(document.forms[0].txbFilledDate)) {
		document.forms[0].txbFilledDate.focus();
		alert(strMess);
		return false;
	}
	if (!CompareDate(document.forms[0].txbValidDate, document.forms[0].txbFilledDate, strDateFormat)) {
		alert(strMess);
		return false;	
	}
}