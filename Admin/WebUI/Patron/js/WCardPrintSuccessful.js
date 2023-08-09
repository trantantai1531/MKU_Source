/**************************************************************************
************************ CardPrintSuccessful Js file **********************
**************************************************************************/
/*function SelectAll(start,strDtgName, strOptionName, intMax){
	var intCounter;
	var blnStatus;
	var checked;
	if (parseInt(document.forms[0].txtHidden.value)==1){
		checked=true;
		document.forms[0].txtHidden.value='0';
	}else{
		checked=false;
		document.forms[0].txtHidden.value='1';
	}	
	for(intCounter = start; intCounter <= intMax + start; intCounter++) {
		eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked=checked;
    }
}*/

function CloseForm(){
    self.close();
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

/*function ReadCheck(start,strDtgName, strOptionName, intMax){
	var intCounter;
	var st;
	var stNotCheck;
	st='';
	stNotCheck='';
	for(intCounter = start; intCounter <= intMax + start-1; intCounter++) {
		if (!eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked){
			st=st + eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_txtID').value + ',';
			alert(st);
		}
		else{
			stNotCheck=stNotCheck + eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_txtID').value + ',';
		}
    }	
    if (st.length>0){
		st=st.substring(0,st.length-1)
    }
    document.forms[0].txtNewQ.value=st;
    if(stNotCheck!=''){
		stNotCheck=stNotCheck.substring(0,stNotCheck.length-1);
    }
    document.forms[0].hdIDs.value=stNotCheck;    
}*/