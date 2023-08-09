// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked)
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


function CheckAllOptionsVisible_1(strDtgName, strOptionName, intStart, intMax) {
    var intCounter;
    var blnStatus;
    blnStatus = false;

    if (eval('document.forms[0].CheckAll')) {
        if (eval('document.forms[0].CheckAll').checked)
            blnStatus = true;
    }
    else {
        if (eval('document.forms[0].chkCheckAll')) {
            if (eval('document.forms[0].chkCheckAll').checked)
                blnStatus = true;
        }
    }

    for (intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {
        console.log(('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName));
        if (intCounter < 10) {
            if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName)) {

                eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked = blnStatus;
            }
        } else {
            if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName)) {

                eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked = blnStatus;
            }
        }
    }
}