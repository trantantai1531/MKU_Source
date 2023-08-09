function ResetForm() {
	document.forms[0].txtPatronCode.value="";
	document.forms[0].txtItemCode.value="";
	document.forms[0].txtCopyNumber.value="";
	document.forms[0].txtCheckOutDateFrom.value="";
	document.forms[0].txtCheckOutDateTo.value="";
	document.forms[0].txtDueDateTo.value="";
	document.forms[0].txtDueDateFrom.value="";
	document.forms[0].ddlLocationName.selectedIndex=0;
	return false;
}