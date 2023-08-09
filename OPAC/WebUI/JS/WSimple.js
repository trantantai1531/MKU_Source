function ResetAll(){
	document.forms[0].reset();
	return false;
}

function ValidInput(strMSG){
	if((trim(document.forms[0].txtFieldValue1.value)=='') && (trim(document.forms[0].txtFieldValue2.value)=='') && (trim(document.forms[0].txtFieldValue3.value)=='') && (trim(document.forms[0].txtFieldValue4.value)=='')){
		document.forms[0].txtFieldValue1.focus();
		alert(strMSG);
		return false;
	}else{
		return true;
	}
}