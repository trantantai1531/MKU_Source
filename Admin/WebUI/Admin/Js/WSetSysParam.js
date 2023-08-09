/*
	MarkChange function
	Purpose: mark changed control
*/
function MarkChange(strControlName) {
	strValue = "#" + document.forms[0].hidAlterParams.value;
	if (strValue.indexOf("#" + strControlName + "#") < 0) {
		document.forms[0].hidAlterParams.value = document.forms[0].hidAlterParams.value + strControlName + "#";
	}
}