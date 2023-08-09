function SubmitPage(Destination) {
    console.log('submit');
	alert(document.forms[0].hdIDs.value);
	document.forms[0].action='WShowClaimLetter.aspx?Destination=' + document.forms[0].hdClaimCycleMode.value;
	document.forms[0].method='post';
	document.forms[0].submit();
	return(true);
}
function CheckAll(strDtgName, strOptionName, strOptionCheckAll, intMax) {
    console.log('submit');
	var intCounter;
	var blnStatus;
	if (document.forms[0].ckbCheckAll.checked==false) {
		blnStatus = false;
	} else {
		blnStatus = true;
	}	
    for(intCounter = 2; intCounter < intMax + 2; intCounter++) {
		eval('document.forms[0].dgrClaimItem__ctl' + intCounter + '_ckbIssueNo').checked = blnStatus;
    }
}
function GetCSSByID() {
    console.log('submit');
	alert(document.Form1.Body.bgcolor);
}

// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg) {
    console.log('submit');
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked) {
	      intCount = intCount + 1;
	  }			
	}
	
	if (intCount != 0) {
		return true;
	}
	else
	{
		alert(strMsg);
		return false;
	}
}
