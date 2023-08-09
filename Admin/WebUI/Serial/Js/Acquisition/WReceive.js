/*
	CheckAll function
	Purpose: Check null value of manatory fields
*/
function CheckAllReceive(strMsgNull,strMsgIssue,strFormatdate,strErrDate,strErrNum1,strErrNum2) {	
	if (trim(document.forms[0].txtReceivedCopies.value)=='') {
		alert(strMsgNull);
		document.forms[0].txtReceivedCopies.focus();
		return false;
	}
	if (trim(document.forms[0].txtReceivedDate.value)=='') {
		alert(strMsgNull);
		document.forms[0].txtReceivedDate.focus();	
		return false;
	}
	if (document.forms[0].ddlIssue.options.selectedIndex==-1) {
			alert(strMsgIssue) ;
			document.forms[0].ddlIssue.focus();
			return false;
	}
	//if (!(trim(document.forms[0].hidCeasedDate.value)=='') && (CompareDate(document.forms[0].hidCeasedDate,document.forms[0].txtReceivedDate,strFormatdate)==1)) {
	//alert(strErrDate); 
	//	document.forms[0].txtReceivedDate.focus(); 
	//	return false;
	//}
	if (isNaN(document.forms[0].txtReceivedCopies.value)) {
		alert(strErrNum1); 
		document.forms[0].txtReceivedCopies.focus(); 
		return false;
	}
	if(parseFloat(document.forms[0].txtReceivedCopies.value)<=0) {
		alert(strErrNum2); 
		document.forms[0].txtReceivedCopies.focus(); 
		return false;
	}
	return true;
}


/*
	CheckValidNumber function
	Purpose: Check the number user typing in the issue copy text is valid or not
*/
function CheckValidNumber(msg1,msg2) {
	if (!CheckNumBer(document.forms[0].txtReceivedCopies, msg1))
		{
			return false;
		}
	else
		{
			if (parseFloat(document.forms[0].txtReceivedCopies.value) < 1)
			{
				alert(msg2);
				return false;
			}
			
		}
	return true;
}

// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for (intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {
	    var indexInt = "";
	    if (intCounter < 10)
	    {
	        indexInt = "0" + intCounter;
	    }
	    else
	    {
	        indexInt = intCounter;
	    }
	    if (eval('document.forms[0].' + strDtgName + '_ctl' + indexInt + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl' + indexInt + '_' + strOptionName).checked)
		{
			intCount = intCount + 1		
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


// Confirm the delete (YES = Do action, NO = Cancel)
function ConfirmDelete(msg)
{
var truthBeTold = window.confirm(msg);
if (truthBeTold) {
return true;
}  else  {
			return false;
}
}

// If find an check object, check, if not, through away

function CheckOptionVisible(strDtgName, strOptionName, intvalue){	
	var blnStatus;						
	var indexInt = "";
	if (intvalue < 10) {
	    indexInt = "0" + intvalue;
	}
	else {
	    indexInt = intvalue;
	}
	if (eval('document.forms[0].' + strDtgName + '_ctl' + indexInt + '_' + strOptionName))
	{
	    if (eval('document.forms[0].' + strDtgName + '_ctl' + indexInt + '_' + strOptionName).checked)
	    {
		    blnStatus = false;
	    }
	    else
	    {
		    blnStatus = true;	
	    }	
	    eval('document.forms[0].' + strDtgName + '_ctl' + intvalue + '_' + strOptionName).checked = blnStatus;
	}			
	
}
