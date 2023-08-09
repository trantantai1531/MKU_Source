// Check selected template format 
function CheckIt(strMsg){
	if(document.forms[0].ddlFormatName.selectedIndex==0){
		alert(strMsg);
		return false;
	}
	return true;
}