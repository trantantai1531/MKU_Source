function ClearContent()
{
	document.forms[0].txtBudgetName.focus();
	document.forms[0].txtBudgetName.value = '';
	document.forms[0].txtBudgetCode.value = '';
	document.forms[0].txtPurpose.value = '';
	document.forms[0].txtAmount.value = '';
	//document.forms[0].ddlCurrency.selectedIndex = 0;
	document.forms[0].hidBudgetId.value = 0;
	document.forms[0].rdoStatus[0].checked = true;
}

// CheckNullInput function
function CheckNullInput(f, fieldname, msg1, msg2) {
	val = f.value;
	 for (i = 0; i < val.length; i++) {
		 if (f.value.charAt(i) != " ") {
			 return false;
		 }
	}
	alert (msg1 + ': [' + fieldname + '] ' + msg2);
	return true;
}

// CheckValid function
function CheckValid(msg1,msg2,msg3,msg4,msg5) {
	if (CheckNullInput(document.forms[0].txtBudgetName, msg1, msg4, msg5)) {document.forms[0].txtBudgetName.focus(); return false; }
	if (CheckNullInput(document.forms[0].txtBudgetCode, msg2, msg4, msg5)) {document.forms[0].txtBudgetCode.focus(); return false; }
	if (CheckNullInput(document.forms[0].txtAmount, msg3, msg4, msg5)) {document.forms[0].txtAmount.focus(); return false; }
	return;
}