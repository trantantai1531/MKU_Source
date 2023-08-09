function CheckInput(msg1,msg2,msg3,msg4){
	var chk;
	chk = CheckNull(document.forms[0].filAttach) 
	if (chk){
		alert(msg1);
		eval(document.forms[0].filAttach).focus();
		return false;
	}
	if (parseInt(document.forms[0].txtLRange.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtLRange).focus();
		eval(document.forms[0].txtLRange).select();
		return false;
	}
	
	if (parseInt(document.forms[0].txtRRange.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtRRange).focus();
		eval(document.forms[0].txtRRange).select();
		return false;
	}
	
	if (!CheckNumber(document.forms[0].txtLRange)) 
	{
		alert(msg3);	
		return false;
	}
	
	if (!CheckNumber(document.forms[0].txtRRange)) 
	{
		alert(msg3);
		return false;
	}
	
	if (CheckNumber(document.forms[0].txtLRange) && CheckNumber(document.forms[0].txtRRange) &&
	    parseInt(document.forms[0].txtLRange.value) > parseInt(document.forms[0].txtRRange.value))
	{
		alert(msg4);
		eval(document.forms[0].txtLRange).focus();
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
