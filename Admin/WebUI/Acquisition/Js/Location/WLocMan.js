// Check for Addnew
function CheckAddNew(strNote1,strNote2,strTitle,strConfirm){
	//return false;
	if((trim(document.forms[0].txtCode.value)=='') || (trim(document.forms[0].txtLocation.value)=='')){
		if (trim(document.forms[0].txtCode.value)=='') {
			alert(strNote1);
			document.forms[0].txtCode.focus();
			return(false);
		}
		else {
			alert(strNote2);
			document.forms[0].txtLocation.focus();
			return(false);
		}
		
	}
	else {
		var Index=document.forms[0].ddlLocation.options.length;;
		var strtemp;		
		for(i=0;i<Index;i++) {				
			strtemp=document.forms[0].ddlLocation.options[i].text;
			if(trim(document.forms[0].txtLocation.value).toUpperCase()==trim(strtemp).toUpperCase()){
				alert(strTitle+" '"+trim(document.forms[0].txtLocation.value)+"' "+strConfirm);
				return false;					
				}				
			}	
		}	
	return(true);
}
// Check for update
function CheckUpdate(intIDcur,txtField,ddlField,strNote,strTitle,strConfirm){
	//return false;
	if(trim(eval(txtField).value)==''){
		alert(strNote);
		eval(txtField).focus();
		return(false);
	}
	else {
		var Index=eval(ddlField).options.length;;
		var strtemp;
		var strCodeLib;
		var i;		
			
		for(i=0;i<Index;i++) {				
			if(intIDcur!=eval(ddlField).options[i].value) {
				strtemp=eval(ddlField).options[i].text;			
				if(trim(eval(txtField).value).toUpperCase()==trim(strtemp).toUpperCase()){
					alert(strTitle+" '"+trim(eval(txtField).value)+"' "+strConfirm);
					return false;																
					}							
				}
			}	
		}	
	return(true);
}

function CheckMerger(strErr,strNote,strErrorMerger,strConfirm) {	
	if (document.forms[0].hidLocIDs.value=="") {
		alert(strErr);
		return false;
	}		
	var inti;
	var arrLocIDs=document.forms[0].hidLocIDs.value.split(',');	
	var intCount=arrLocIDs.length+3;	
	var currID=document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value;
	var CheckMerger=0;
	var checkSelected=0;
	var intCurrIndex=parseInt(document.forms[0].hidPageIndex.value);	
	for (inti = 3; inti < intCount; inti++) {
	    console.log('document.forms[0].dtgLocation_ct10' + inti + '_ckbdtgMerger');
	    console.log('document.forms[0].dtgLocation_ct10' + inti + '_ckbdtgMerger');
	    if (eval('document.forms[0].dtgLocation_ctl0' + inti + '_ckbdtgMerger')) {
	        if (eval('document.forms[0].dtgLocation_ctl0' + inti + '_ckbdtgMerger').checked) {
				if (currID!=arrLocIDs[inti+intCurrIndex-3]) {
					CheckMerger=1;					
					break;
				}
				checkSelected=1;
			}
		}
	}
	// no selected for merger
	if ((inti==intCount)&&(checkSelected==0)) {
		alert(strNote);
		return false;
	}
	// selected one that the same libid need merger
	if(CheckMerger==0) {
		alert(strErrorMerger);
		return false;
	}

	if (!confirm(strConfirm))
		return false;
	return true;

}

// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;			
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked)
		{
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

// Confirm the merge (YES = Do action, NO = Cancel)
function ConfirmCloseOpen(msg) {
var truthBeTold = window.confirm(msg);
if (truthBeTold) 
	return true;	
else  
	return false;
}


