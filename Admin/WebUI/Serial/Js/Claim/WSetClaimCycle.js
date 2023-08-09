//Check for Set Claim Cycle
//CreatedDate: 29/09/2004
//Creator: Sondp
//Load back intial value to 4 text box
function LoadBackInitalValue(){
	document.forms[0].txtDeliveryTime.value=document.forms[0].hdDeliveryTime.value;
	document.forms[0].txtClaimCycle1.value=document.forms[0].hdClaimCycle1.value;
	document.forms[0].txtClaimCycle2.value=document.forms[0].hdClaimCycle2.value;
	document.forms[0].txtClaimCycle3.value=document.forms[0].hdClaimCycle3.value;
}
//Check for Set up
function CheckForSetUp(strDeliveryNotIsNumeric,strClaimCycle1NotIsNumeric,strClaimCycle2NotIsNumeric,strClaimCycle3NotIsNumeric,strClaimCycle1LessThan23,strClaimCyCle2LessThan3){
	if(isNaN(document.forms[0].txtDeliveryTime.value)){	
		alert(strDeliveryNotIsNumeric);
		document.forms[0].txtDeliveryTime.focus;
		return(false);
	}
	if(isNaN(document.forms[0].txtClaimCycle1.value)){
		alert(strClaimCycle1NotIsNumeric);
		document.forms[0].txtClaimCycle1.focus;
		return(false)
	}
	if(isNaN(document.forms[0].txtClaimCycle2.value)){
		alert(strClaimCycle2NotIsNumeric);
		document.forms[0].txtClaimCycle2.focus;
		return(false);
	}
	if(isNaN(document.forms[0].txtClaimCycle3.value)){
		alert(strClaimCycle3NotIsNumeric);
		document.forms[0].txtClaimCycle3.focus;
		return(false);
	}
	if(parseInt(document.forms[0].txtClaimCycle1.value)>parseInt(document.forms[0].txtClaimCycle2.value) || parseInt(document.forms[0].txtClaimCycle1.value)>parseInt(document.forms[0].txtClaimCycle3.value)){
		alert(strClaimCycle1LessThan23);
		document.forms[0].txtClaimCycle1.focus;
		return(false);
	}
	if(parseInt(document.forms[0].txtClaimCycle2.value)>parseInt(document.forms[0].txtClaimCycle3.value)){
		alert(strClaimCyCle2LessThan3);
		document.forms[0].txtClaimCycle3.focus;
		return(false);
	}
	document.forms[0].hdDeliveryTime.value=document.forms[0].txtDeliveryTime.value;
	document.forms[0].hdClaimCycle1.value=document.forms[0].txtClaimCycle1.value;
	document.forms[0].hdClaimCycle2.value=document.forms[0].txtClaimCycle2.value;
	document.forms[0].hdClaimCycle3.value=document.forms[0].txtClaimCycle3.value;
	return(true);
}

//Reset all value
function ResetAll()
{
	document.forms[0].txtDeliveryTime.value='';
	document.forms[0].txtClaimCycle1.value='';
	document.forms[0].txtClaimCycle2.value='';
	document.forms[0].txtClaimCycle3.value='';
	return false;
}

// CheckAllValue function
function CheckAllValue(msg)
{
	if (trim(document.forms[0].txtDeliveryTime.value)=="") {
		alert(msg);
		document.forms[0].txtDeliveryTime.focus();
		return false;		
	}
	if (trim(document.forms[0].txtClaimCycle1.value)=="") {
		alert(msg);
		document.forms[0].txtClaimCycle1.focus();
		return false;		
	}
	if (trim(document.forms[0].txtClaimCycle2.value)=="") {
		alert(msg);
		document.forms[0].txtClaimCycle2.focus();
		return false;		
	}
	if (trim(document.forms[0].txtClaimCycle3.value)=="") {
		alert(msg);
		document.forms[0].txtClaimCycle3.focus();
		return false;		
	}
	return true;	
}