/* 
	CheckInput function
*/	

function CheckInput(msg){
	if (CheckNull(document.forms[0].txtDisplayEntryT)){
		alert(msg);
		document.forms[0].txtDisplayEntryT.focus();
		return false;
	}else{
		return true;
	}
}