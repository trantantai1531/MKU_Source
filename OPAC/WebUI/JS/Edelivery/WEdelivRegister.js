// CheckNull function
function CheckNullInput(f, fieldname, msg1, msg2) {
	val = f.value;
	 for (i = 0; i < val.length; i++) {
		 if (f.value.charAt(i) != " ") {
			 return false;
		 }
	}
	alert (msg1 + ': [' + fieldname + '] ' + msg2);
	return true;
}

// CheckValid function
function CheckValid(msg1,msg2,msg3,msg4,msg5,msg6,msg7,msg8,msg9,msg10, msg11, msg12, msg13) {
	if (CheckNullInput(document.forms[0].txtFullName, msg1, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtContactName, msg2, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtPhone, msg3, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtEmailAddress, msg4, msg11, msg12)) { return false; }		
	if (CheckNullInput(document.forms[0].txtEdelivUserName, msg5, msg11, msg12)) { return false; }		
	if (CheckNullInput(document.forms[0].txtEdelivPassword, msg6, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtWorkPlace, msg7, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtAddress, msg8, msg11, msg12)) { return false; }				
	if (CheckNullInput(document.forms[0].txtCity, msg9, msg11, msg12)) { return false; }				
	if (document.forms[0].txtEdelivPassword.value != document.forms[0].txtRetypePassword.value) { alert(msg10); return false;}
	if (!CheckValidEmail(document.forms[0].txtEmailAddress)) { alert (msg13); return false; }
	return;
}