/*
	CheckAll function
*/
function CheckAll(strMsg) {
	intStatus = 0;
	if (!CheckNull(document.forms[0].txtFrom)) {intStatus = 1;}
	if (!CheckNull(document.forms[0].txtTo)) {intStatus = 1;}
	if (!CheckNull(document.forms[0].txtFromCopyNumber)) {intStatus = 1;}
	if (!CheckNull(document.forms[0].txtToCopyNumber)) {intStatus = 1;}
	if (document.forms[0].ddlItemType.options[document.forms[0].ddlItemType.options.selectedIndex].value > 0) {intStatus = 1;}
	if (document.forms[0].txtLocation) {intStatus = 1;}
	if (intStatus==0) {
		alert(strMsg);
		return false;
	} else {
		return true;
	}
}

/*
	FilterLocation function
*/

function FilterLocation() {
	var intLibID;
	
	intLibID=document.forms[0].ddlLibrary.options[document.forms[0].ddlLibrary.options.selectedIndex].value;
	document.forms[0].ddlLocation.options.length = 0;
	
	for (j = 0; j < LibID.length; j++) {
		if (LibID[j] == intLibID) {
			document.forms[0].ddlLocation.options.length = document.forms[0].ddlLocation.options.length + 1;
			document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].value = LocID[j];
			document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].text = Location[j];
		}
	}
	document.forms[0].ddlLocation.options.selectedIndex = 0
}