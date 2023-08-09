/*
	CheckAll function
	Purpose: Check null value of manatory fields
*/
function CheckAll() {
	if (CheckNull(document.forms[0].txtName)) {
		document.forms[0].txtName.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtPage)) {
		document.forms[0].txtPage.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtAuthor)) {
		document.forms[0].txtAuthor.focus();
		return false;
	}
	return true;
}

function CheckInserUpdate(field,strNote) {
		if (eval(field+'txtNamedt').value =="") {
				alert(strNote);
				eval(field+'txtNamedt').focus();
				return false;
			}
		if (eval(field+'txtAuthordt').value =="") {
				alert(strNote);
				eval(field+'txtAuthordt').focus();
				return false;
			}	
		/*if (eval(field+'txtSubjectdt').value =="") {
				alert(strNote);
				eval(field+'txtSubjectdt').focus();
				return false;
			}*/
		if (eval(field+'txtPagedt').value =="") {
				alert(strNote);
				eval(field+'txtPagedt').focus();
				return false;
			}
		return true;	
}
function CheckIssueIDs(strNote) {	
	var inti;
	var intCount=document.forms[0].hidIssueIDCount.value;
	for (inti=3;inti<intCount;inti++) {		
		if (eval('document.forms[0].dgrResult__ctl'+inti+'_chkIssueID')) {
			if (eval('document.forms[0].dgrResult__ctl'+inti+'_chkIssueID').checked) {
				return true;
			}
		}
		else {
			break;
		}
	}
	alert(strNote);
	return false;
}

