function CheckInput(msg1,msg2,msg3,msg4,msg5,msg6){
	var chk;
	chk =	CheckNull(document.forms[0].txtIDFrom) && 	
			CheckNull(document.forms[0].txtIDTo) && 
			CheckNull(document.forms[0].txtMaxExp) 
	if (chk){
		alert(msg1);
		eval(document.forms[0].ddlDisPlayEntry).focus();
		return false;
	}
	
	if (parseInt(document.forms[0].txtMaxExp.value) <0)
	{
		alert(msg6);
		eval(document.forms[0].txtMaxExp).focus();
		eval(document.forms[0].txtMaxExp).select();
		return false;
	}
	
	if (parseInt(document.forms[0].txtIDFrom.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtIDFrom).focus();
		eval(document.forms[0].txtIDFrom).select();
		return false;
	}
	
	if (parseInt(document.forms[0].txtIDTo.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtIDTo).focus();
		eval(document.forms[0].txtIDTo).select();
		return false;
	}
		
	if (!CheckNumber(document.forms[0].txtIDFrom)) 
	{
		alert(msg3);	
		return false;
	}
	
	if (!CheckNumber(document.forms[0].txtIDTo)) 
	{
		alert(msg3);
		return false;
	}
	
	if (!CheckNumber(document.forms[0].txtMaxExp)) 
	{
		alert(msg5);
		return false;
	}
	
	if (CheckNumber(document.forms[0].txtIDFrom) && CheckNumber(document.forms[0].txtIDTo) &&
	    parseInt(document.forms[0].txtIDFrom.value) > parseInt(document.forms[0].txtIDTo.value))
	{
		alert(msg4);
		eval(document.forms[0].txtIDFrom).focus();
		return false;	
	}
	return true;
}

// CheckNumber method
function CheckNumber(obj) {
	var tempNum;
	tempNum = obj.value;
	if (isNaN(tempNum)) {
		obj.focus();							
		obj.select();							
		return false;
	} 
	return true;
}
function ResetForm() {
	document.forms[0].reset();
	document.forms[0].ddlDisPlayEntry.focus();
	return false;
}
function SetCheckGetAll() {
	if (document.forms[0].chkExpAll.checked) {
		document.forms[0].txtMaxExp.disabled=true;
		}
	else
		{
		document.forms[0].txtMaxExp.disabled=false;
		}
}
 