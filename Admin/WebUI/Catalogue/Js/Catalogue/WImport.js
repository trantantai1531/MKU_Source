function CheckInput(msg1,msg2,msg3,msg4){
	var chk;
	chk = CheckNull(document.forms[0].filAttach) 
	if (chk){
		alert(msg1);
		eval(document.forms[0].filAttach).focus();
		return false;
	}
	if (CheckNumber('document.forms[0].txtLRange') && parseInt(document.forms[0].txtLRange.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtLRange).focus();
		return false;
	}
	
	if (CheckNumber('document.forms[0].txtRRange',msg3) && parseInt(document.forms[0].txtRRange.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtRRange).focus();
		return false;
	}
	
	if (!CheckNumber('document.forms[0].txtLRange')) 
	{
		alert(msg3);	
		return false;
	}
	if (!CheckNumber('document.forms[0].txtRRange')) 
	{
		alert(msg3);
		return false;
	}
	if (CheckNumber('document.forms[0].txtLRange') && CheckNumber('document.forms[0].txtRRange') &&
	    parseInt(document.forms[0].txtLRange.value) > parseInt(document.forms[0].txtRRange.value))
	{
		alert(msg4);
		eval(document.forms[0].txtLRange).focus();
		return false;	
	}
	return true;
}

function CheckNumber(obj) {
	var tempNum;
	tempNum = eval(obj).value;
	if (isNaN(tempNum)) {
		eval(obj).focus();							
		return false;
	} 
		return true;
		
}

