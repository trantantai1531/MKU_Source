// CheckNull function
function CheckNullInput(f, fieldname, msg1, msg2) {
	val = f.value;
	 for (i = 0; i < val.length; i++) {
		 if (f.value.charAt(i) != " ") {
			 return false;
		 }
	}
	alert (msg1 + ': [' + fieldname + '] ' + msg2);
	f.focus();
	return true;
}

// CheckValid function
function CheckValid(msg1,msg2,msg3,msg4,msg5,msg6,msg7,msg8) {
	if (CheckNullInput(document.forms[0].txtChapterTitle, msg1, msg6, msg7)) { return false; }
	if (CheckNullInput(document.forms[0].txtBookName, msg2, msg6, msg7)) { return false; }
	if (CheckNullInput(document.forms[0].txtPage, msg3, msg6, msg7)) { return false; }
	if (CheckNullInput(document.forms[0].txtCardNum, msg4, msg6, msg7)) { return false; }
	if (CheckNullInput(document.forms[0].txtPassword, msg5, msg6, msg7)) { return false; }
	if (!CheckDate(document.forms[0].txtExpireDate,'dd/mm/yyyy',msg8)) { return false; }
	return;
}
function ResetCtlValue(){	
	if (document.forms[0].hidReset.value==1) 
	{
		for(var i=0; i<document.Form1.elements.length; i++) {	
			if (document.Form1.elements[i].type=='text')
				document.Form1.elements[i].value = '';	
		}
		document.forms[0].hidReset.value=0;
	}
}