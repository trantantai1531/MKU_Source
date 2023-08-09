/**************************************************************************
************************ WClassDetail Js file *****************************
**************************************************************************/
function SelectAll(start,strDtgName, strOptionName, intMax){
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
}

function CloseForm(start,strDtgName, strOptionName, intMax){
	var intCounter;
	var blnStatus;
	var stCode;
	stCode='';
	for(intCounter = start; intCounter <= intMax + start; intCounter++) {
		if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked){
			stCode+=eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_txtCode').value;
			stCode+=',';
		}
    }
    stCode.replace(' ','')
    if (stCode.length>0){
		stCode=stCode.substring(0,stCode.length-1);
		opener.document.forms[0].txtCode.value=stCode;
		opener.document.forms[0].optCode.checked=1;
		opener.document.forms[0].txtCode.focus();
    }
    self.close();
}