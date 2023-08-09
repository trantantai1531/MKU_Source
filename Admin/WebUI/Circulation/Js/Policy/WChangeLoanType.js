function CheckAllValues(strMsg) {
	var blnFound = false;

	if (parseFloat(document.forms[0].ddlLoanType.options[document.forms[0].ddlLoanType.options.selectedIndex].value) > 0) {blnFound = true}
	if (!CheckNull(document.forms[0].txtTitle)) {blnFound = true}
	if (!CheckNull(document.forms[0].txtAuthor)) {blnFound = true}
	if (!CheckNull(document.forms[0].txtPublisher)) {blnFound = true}
	if (!CheckNull(document.forms[0].txtPublishYear)) {blnFound = true}
	if (!CheckNull(document.forms[0].txtISBN)) {blnFound = true}
	if (!CheckNull(document.forms[0].txtCopyNumber)) {blnFound = true}
	if (!blnFound) {
		alert(strMsg);
	}
	return blnFound;
}

function ClearAllValues() {
	document.forms[0].txtTitle.value='';
	document.forms[0].txtAuthor.value='';
	document.forms[0].txtPublisher.value='';
	document.forms[0].txtPublishYear.value='';
	document.forms[0].txtISBN.value='';
	document.forms[0].txtCopyNumber.value='';
	document.forms[0].ddlLoanType.options.selectedIndex = 0;
}
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {
	    if (intCounter < 10) {
	        if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked) {
	            intCount = intCount + 1;
	        }
	    } else {
	        if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked) {
	            intCount = intCount + 1;
	        }
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
function CheckAllOptionsVisible_1(strDtgName, strOptionName, intStart, intMax){	
	var intCounter;	
	var blnStatus;	
						
	if (eval('document.forms[0].CheckAll').checked) 
		blnStatus = true;
	else
		blnStatus = false;			
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName)){			
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;			
		}			
	}
}