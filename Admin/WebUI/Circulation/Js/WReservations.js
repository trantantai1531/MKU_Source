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