function ValidInput(strMsg1,strMsg2){
	if (trim(document.forms[0].txtCardNum.value)==''){
		alert(strMsg1);
		document.forms[0].txtCardNum.focus();
		return false;
	}
	if (trim(document.forms[0].txtPassword.value)==''){
		alert(strMsg2);
		document.forms[0].txtPassword.focus();
		return false;
	}
	return true;
}