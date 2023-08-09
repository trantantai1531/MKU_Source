// CheckNull function
function CheckNullInput(f, fieldname, msg1) {
	val = f.value;
	 for (i = 0; i < val.length; i++) {
		 if (f.value.charAt(i) != " ") {
			 return false;
		 }
	}
	alert (msg1 + ' ' + fieldname);
	return true;
}

// CheckValid function
function CheckValid(msg1,msg2,msg3,msg4,msg5,msg6,msg7) {
	if (CheckNullInput(document.forms[0].txtPatronCode, msg1, msg5)) { document.forms[0].txtPatronCode.focus();return false; }
	if (CheckNullInput(document.forms[0].txtValiddate, msg2, msg5)) { document.forms[0].txtValiddate.focus();return false; }
	if (CheckNullInput(document.forms[0].txtDOB, msg3, msg5)) { document.forms[0].txtDOB.focus();return false; }
	if (CheckNullInput(document.forms[0].txtPassword, msg4, msg5)) { document.forms[0].txtPassword.focus();return false; }		
	if (document.forms[0].txtPassword.value != document.forms[0].txtReTypePassword.value) { alert(msg6); return false;}
	if (document.forms[0].txtPassword.value.length < 4) { alert(msg7);document.forms[0].txtPassword.value = "";
	document.forms[0].txtReTypePassword.value = "";
	document.forms[0].txtPassword.focus(); return false;}
	return;
}