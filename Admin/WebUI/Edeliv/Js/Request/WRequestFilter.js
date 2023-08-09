/*
	CheckAll function
*/
function CheckAll() {
var check;
	check = CheckNull(document.forms[0].txtCustomerName) && CheckNull(document.forms[0].txtNameOfFile)
	&& CheckNull(document.forms[0].txtSizeOfFileFrom) && CheckNull(document.forms[0].txtPriceOfFileFrom) 
	&& CheckNull(document.forms[0].txtSizeOfFileTo) && CheckNull(document.forms[0].txtPriceOfFileTo) 
	&& (eval(document.forms[0].ddlTimeMode).value == 0 || (CheckNull(document.forms[0].txtTimeFrom) && CheckNull(document.forms[0].txtTimeTo)))
	
	if (check) 
		return false;
				
	return true;
}

/*
	Filter function
*/
function Filter()
{
	parent.Sentform.document.forms[0].btnFilter.disabled=false;
	parent.Sentform.document.forms[0].ddlAction.disabled=false;
	parent.Sentform.document.forms[0].btnAction.disabled=false;
	parent.Sentform.document.forms[0].btnCancelFilter.disabled=false;
	parent.Sentform.document.forms[0].btnFilter.disabled=false;
	return;
}

/*
	CheckNumber function
*/
function CheckNumber(obj,msg) {
	var tempNum;
	tempNum = eval(obj).value;
	if (isNaN(tempNum)) {
		alert(msg);
		eval(obj).value = "";							
		eval(obj).focus();							
		return false;
	} 
	else
	{
		if (parseFloat(eval(obj).value) < 0)
		{
			alert(msg);
			eval(obj).value = "";							
			eval(obj).focus();
			return false;
		}
	}
		return true;
		
}

/* 
	ClearContent function
*/
function ClearContent() {
	document.forms[0].ddlTimeMode.options.selectedIndex = 0;
	document.forms[0].txtTimeFrom.value='';
	document.forms[0].txtTimeTo.value='';
	document.forms[0].txtCustomerName.value='';
	document.forms[0].txtNameOfFile.value='';
	document.forms[0].txtSizeOfFile.value='';
	document.forms[0].txtPriceOfFile.value='';
	document.forms[0].txtCustomerName.focus();
}	