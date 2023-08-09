/*
	CheckAll function
	Purpose: Check null of all form's controls
*/
function ValidateForm(error0, error1, error2, error3) {
	if (CheckNull(document.forms[0].txtzServer)) {
		alert(error1);
		document.forms[0].txtzServer.focus();
		return false;}
	if (CheckNull(document.forms[0].txtZPort)) {
		alert(error2);
		document.forms[0].txtZPort.focus();
		return false;}
	if (CheckNull(document.forms[0].txtZDatabase)) {
		alert(error3);
		document.forms[0].txtZDatabase.focus();
	return false;}
	if (CheckNull(document.forms[0].txtFieldValue1) & CheckNull(document.forms[0].txtFieldValue2) & CheckNull(document.forms[0].txtFieldValue3)) {
		alert(error0);
		document.forms[0].txtFieldValue1.focus();
		return false;}
	
	document.forms[0].action='WZFind.aspx'; 
	document.forms[0].submit();
	return false;
}