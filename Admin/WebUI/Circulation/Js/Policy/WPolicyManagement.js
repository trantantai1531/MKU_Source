function ValidNew(strMsg) {
    console.log(strMsg);
	if (CheckNull(document.forms[0].txtNewLoanType)){
		alert(strMsg);
		document.forms[0].txtNewLoanType.focus();
		return false;
    }
    if (!CheckNum(document.forms[0].txtNewRenewals)) {
        alert(strMsg);
        document.forms[0].txtNewRenewals.focus();
        return false;
    }
    if (!CheckNum(document.forms[0].txtNewRenewalPeriod)) {
        alert(strMsg);
        document.forms[0].txtNewRenewalPeriod.focus();
        return false;
    }
    if (!CheckNum(document.forms[0].txtNewOverdueFine)) {
        alert(strMsg);
        document.forms[0].txtNewOverdueFine.focus();
        return false;
    }
    if (!CheckNumAcceptNull(document.forms[0].txtNewFee)) {
        alert(strMsg);
        document.forms[0].txtNewFee.focus();
        return false;
    }
 //   if (!CheckNum(document.forms[0].txtNewLoanPeriod)){
	//	alert(strMsg);
	//	document.forms[0].txtNewLoanPeriod.focus();
	//	return false;
	//}
    return true;
}

function SureMerge(strMsg){
	if (confirm(strMsg)){
		return true;
	}else{
		return false;
	}
}


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

/* function ValidUpdate(val,strMsg,Index){
	//var str;
	//var intConst;
	//intConst= 3 + Index ;
	//str='document.forms[0].dtgPolicy:_ctl' + intConst + ':' ;
	alert(strMsg);
	switch(val){
		case 1:
		// LoanType dtgPolicy:_ctl4:txtLoanType
			//eval(str + 'txtLoanType').focus();
			break;
		case 2:
		//dtgPolicy:_ctl4:txtLoanPeriod
			//alert(str + 'txtLoanPeriod');
			//eval(str + 'txtLoanPeriod.focus()');
			break;
		case 3:
		//dtgPolicy:_ctl4:txtRenewals
			//eval(str + 'txtRenewals').focus();
			break;
		case 4:
		//dtgPolicy:_ctl4:txtRenewalPeriod
			//alert(str + 'txtRenewalPeriod');
			//return;

//			alert(eval(document.forms[0].dtgPolicy:_ctl3:txtRenewalPeriod.value));
			
			//eval(str + 'txtRenewalPeriod.focus()');
			break;
		case 5:
		//dtgPolicy:_ctl4:txtOverdueFine
			//eval(str + 'txtOverdueFine').focus();
			break;
		case 6:
		//dtgPolicy:_ctl4:txtFee
			//eval(str + 'txtFee').focus();
			break;
	}
}*/