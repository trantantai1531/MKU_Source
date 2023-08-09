/*
	CheckAll function
	Purpose: Check valid inform user enter to create new field
*/
function CheckAll(strMess1, strMess2, strMess3, strMess4, strMess5, strMess6, strMess7) {
	if (CheckNull(parent.Workform.document.forms[0].txtFieldCode)) {alert(strMess1); return;}
	if (CheckNull(parent.Workform.document.forms[0].txtVietFieldName)) {alert(strMess2); return;}
	if (CheckTagNumber(parent.Workform.document.forms[0].txtFieldCode.value)) {
		alert(strMess3);
		return;
	}
	if (isNaN(parent.Workform.document.forms[0].txtLength.value) || parseFloat(parent.Workform.document.forms[0].txtLength.value) < 0 || CheckNull(parent.Workform.document.forms[0].txtLength)) {
		alert(strMess4);
		return;
	}
	if (parent.Workform.document.forms[0].txtFieldCode.value.indexOf("$") >= 0 && (parent.Workform.document.forms[0].txtIndicators.value != "" || parent.Workform.document.forms[0].txtVietIndicators.value != "")) {
		alert(strMess5);
		return;
	}
	if (parent.Workform.document.forms[0].ddlMarcFieldTypes.options[parent.Workform.document.forms[0].ddlMarcFieldTypes.selectedIndex].value == 4) {
		if (CheckNull(parent.Workform.document.forms[0].txtPhysicalPath)) {alert(strMess6); return;}
		if (CheckNull(parent.Workform.document.forms[0].txtURL)) {alert(strMess7); return;}
	}
	parent.Workform.document.forms[0].submit();
}

/*
	CheckTagNumber function
	Check valid fieldcode
*/
function CheckTagNumber(strFieldCode) {
	var intCount
	for (intCount = 0; intCount < strFieldCode.length; intCount++) {
		if (strFieldCode.charAt(intCount) == " ") {
			return true;
		}
	}
	if (strFieldCode.length < 3) {
		return true;
	}
	if (isNaN(strFieldCode.substring(0,3)) || parseFloat(strFieldCode.substring(0,3)) < 0) {
		return true;
	}
	if (strFieldCode.length > 3 && strFieldCode.substring(3,4) != "$") {
		return true;
	}
	return false;
}
