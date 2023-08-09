/*
	CheckAll function
	Purpose: Check null value of all form's controls
*/
function CheckAll() {
/*
	if (!CheckNull(document.forms[0].txtIssuedDate)) {
		return true;
	}
	if (!CheckNull(document.forms[0].txtPubCountry)) {
		return true;
	}
	if (!CheckNull(document.forms[0].txtPubLanguage)) {
		return true;
	}
	if (!document.forms[0].ddlRegularity.options.selectedIndex == 0) {
		return true;
	}
	*/
	if (trim(document.forms[0].txtIssuedDate.value)=="") {
		document.forms[0].txtIssuedDate.focus();
		return false;
		}
	return true;
}

/*
	OpenRegForm function
	Purpose: open register form
*/
function OpenRegForm(lngItemID) {
    console.log(parent);
	parent.Register.location.href="WCreateIssue.aspx?ItemID=" + lngItemID;
}