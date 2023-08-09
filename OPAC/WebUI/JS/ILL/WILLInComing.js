// CheckValid function
function CheckValid(msg1,msg2,msg3,msg4,msg5,msg6) {
	if (CheckNull(document.forms[0].txtRequesterSymbol))  {document.forms[0].txtRequesterSymbol.focus();alert(msg1); return false; }
	if (CheckNull(document.forms[0].txtRequestID)) {document.forms[0].txtRequestID.focus();alert(msg6); return false; }
	if (CheckNull(document.forms[0].txtRequesterName)) {document.forms[0].txtRequesterName.focus();alert(msg2); return false; }	
	if (CheckNull(document.forms[0].txtEmailReplyAddress)) {document.forms[0].txtEmailReplyAddress.focus();alert(msg3); return false; }
	if (!CheckValidEmail(document.forms[0].txtEmailReplyAddress)) {
		document.forms[0].txtEmailReplyAddress.focus();alert(msg5); return false; 
		}
	if (CheckNull(document.forms[0].txtTitle)) {document.forms[0].txtTitle.focus();alert(msg4); return false; }	
	return true;
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