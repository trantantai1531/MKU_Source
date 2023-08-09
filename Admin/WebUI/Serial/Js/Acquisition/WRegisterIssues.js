/*
	GetNextIssue function
	Purpose: get information of the next IssueNo
*/
function GetNextIssue() {
	document.forms[0].txtStartIssueNo.value = parseFloat(document.forms[0].hidLastIssueNo.value) + 1;
	document.forms[0].txtStartOvIssueNo.value = parseFloat(document.forms[0].hidLastOvIssueNo.value) + 1;
}

/*
	CheckAll function
	Purpose: Check null value of manatory fields
*/
function CheckAll(strMsg1,strMsg2,strMsg3,strDateFormat) {

	if (CheckNull(document.forms[0].txtStartDate)) {
		alert(strMsg1);
		document.forms[0].txtStartDate.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtEndDate)) {
		alert(strMsg1);
		document.forms[0].txtEndDate.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtStartIssueNo)) {
		alert(strMsg1);
		document.forms[0].txtStartIssueNo.focus();
		return false;
	}
	if (CompareDate('document.forms[0].txtEndDate','document.forms[0].txtStartDate',strDateFormat)==1) {
		alert(strMsg3);
		document.forms[0].txtEndDate.focus();
		return false;
	}
	if (!CheckNull(document.forms[0].txtStartOvIssueNo)) {
		if ((parseFloat(document.forms[0].txtStartOvIssueNo.value)>0) && ((parseFloat(document.forms[0].txtStartIssueNo.value)-parseFloat(document.forms[0].txtStartOvIssueNo.value))>0)) {
			alert(strMsg2); 
			document.forms[0].txtStartOvIssueNo.focus();
			return false;
		}	
	}	
	return true;	
}

/*
	ResetAll function
	Purpose: reset all controls
*/
function ResetAll() {
	document.forms[0].txtStartDate.value='';
	document.forms[0].txtEndDate.value='';
	document.forms[0].txtStartIssueNo.value='';
	document.forms[0].txtStartOvIssueNo.value='';
	document.forms[0].txtPrice.value='0';
	document.forms[0].txtCopies.value='1';
	document.forms[0].VolumeByPublisher.value='';
	return false;
}