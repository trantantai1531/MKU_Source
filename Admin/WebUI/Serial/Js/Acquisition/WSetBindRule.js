/*
	CheckAll function
	Purpose: Check null value of manatory fields
*/
function CheckAll() {
	var intRetVal = false;
	if ((!CheckNull(document.forms[0].txtNOIs)) & (document.forms[0].rdoByIssue.checked)) {
		return true;
	}
	if ((!CheckNull(document.forms[0].txtNODs)) & (document.forms[0].rdoByTime.checked)) {
		return true;
	}
	return false;
}