// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked)
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


// If find an check object, check, if not, through away
function CheckOptionVisible(strDtgName, strOptionName, intvalue){	
	var blnStatus;						
	
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName))
	{
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked) 
	{
		blnStatus = false;
	}
	else
	{
		blnStatus = true;	
	}	
	eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked = blnStatus;			
	}			
	
}

// chkEvent event
function chkEvent(val)
{
	eval('document.forms[0].dtgCopyNumber__ctl' + val + 'ckbdtgCopyNumber').checked=!eval('document.forms[0].dtgCopyNumber__ctl' + val + 'ckbdtgCopyNumber').checked;
}
	