
function CheckValid(MsgErr){
	if (CheckNull(document.forms[0].txtFuntionName)){
		alert(MsgErr);
		document.forms[0].txtFuntionName.focus();
		return false;
	}else{
		return true;
	}
}

function CheckIcon(MsgErr){
	if (CheckNull(document.forms[0].URLFile)){
		alert(MsgErr);
		document.forms[0].URLFile.focus();
		return false;
	}else{
		return true;
	}	
}


