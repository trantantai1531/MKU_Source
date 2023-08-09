function CheckAll(msg1,msg2,msg3,msg4)
{
var chk1,chk2,chk3,chk4;

	chk1 =	CheckNull(document.forms[0].txtLocID);	
	chk2 =	CheckNull(document.forms[0].txtItemCode); 	
	chk3 =	CheckNull(document.forms[0].txtCopyNumber);
	chk4 =  CheckNumber(document.forms[0].txtCost,msg4);
	if (chk1)
	{
		alert(msg1);
		document.forms[0].ddlLibrary.focus();
		return false;
	}
	if (chk2)
	{
		alert(msg2);
		document.forms[0].txtItemCode.focus();
		return false;
	}
	if (chk3)
	{
		alert(msg3);
		document.forms[0].txtCopyNumber.focus();
		return false;
	}
	if (!chk4)
	{
		return false;
	}
	
	return true;
}

// CheckNumber method
function CheckNumber(obj,msg) {
	var tempNum;
	tempNum = eval(obj).value;
	if (isNaN(tempNum)) {
		alert(msg);
		eval(obj).focus();							
		eval(obj).select();							
		return false;
	} 
	return true;
}

function Back_cl(){
	self.location.href='WAddItem.aspx';
	return false;	
}
