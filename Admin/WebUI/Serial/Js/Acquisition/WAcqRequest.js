/*
	CheckRequest function
*/
function CheckRequest() {
	if (CheckNull(document.forms[0].txtTitle)) {
		document.forms[0].txtTitle.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtRequestedCopies)) {
		document.forms[0].txtRequestedCopies.focus();
		return false;
	}
	return true;
}

/*
	CheckSRequest function
*/
function CheckSRequest(strMsg1,strMsg2,strDateFormat) {
	if (CheckNull(document.forms[0].txtTitle)) {
		alert(strMsg1);
		document.forms[0].txtTitle.focus();
		return false;
	}
	else {
	if (CheckNull(document.forms[0].txtRequestedCopies)) {
		alert(strMsg1);
		document.forms[0].txtRequestedCopies.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtIssues)) {
		alert(strMsg1);
		document.forms[0].txtIssues.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtIssuePrice)) {
		alert(strMsg1);
		document.forms[0].txtIssuePrice.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtValidSubscribedDate)) {
		alert(strMsg1);
		document.forms[0].txtValidSubscribedDate.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtExpiredSubscribedDate)) {
		alert(strMsg1);
		document.forms[0].txtExpiredSubscribedDate.focus();
		return false;
	}
	if(CompareDate('document.forms[0].txtValidSubscribedDate','document.forms[0].txtExpiredSubscribedDate',strDateFormat)==0) {
		alert(strMsg2);
		document.forms[0].txtExpiredSubscribedDate.focus();
		return false;
	}	
	}
	return true;
}
function SetUnitPrice() {
	if ((trim(document.forms[0].txtIssues.value)=='')||(trim(document.forms[0].txtIssuePrice.value)=='')||(trim(document.forms[0].txtRequestedCopies.value)=='')) {
		if(trim(document.forms[0].txtRequestedCopies.value)=='') 
			document.forms[0].txtRequestedCopies.focus();
		else {
			if(trim(document.forms[0].txtIssues.value)=='') 
				document.forms[0].txtIssues.focus();
			else 
				document.forms[0].txtIssuePrice.focus();
			}
		document.forms[0].txtUnitPrice.value=0;
		return false;
	}
	if ((!CheckNum(document.forms[0].txtIssues))||(!CheckNum(document.forms[0].txtIssuePrice))||(!CheckNum(document.forms[0].txtRequestedCopies))) {
		if(!CheckNum(document.forms[0].txtRequestedCopies)) 
			document.forms[0].txtRequestedCopies.focus();
		else {
			if(!CheckNum(document.forms[0].txtIssues)) 
				document.forms[0].txtIssues.focus();
			else 
				document.forms[0].txtIssuePrice.focus();	
			}
		document.forms[0].txtUnitPrice.value=0;
		return false;
	}
	document.forms[0].txtUnitPrice.value=parseFloat(document.forms[0].txtIssues.value)*parseFloat(document.forms[0].txtIssuePrice.value);
}