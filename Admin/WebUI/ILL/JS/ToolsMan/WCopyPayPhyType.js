
/****************************************************
// PaymentType, Physical mode, Copyright Compliance 
*****************************************************/

// Check for Addnew
function CheckAddNew(strEmtyName){	
	if(trim(document.forms[0].txtNewPayment.value)==''){
		alert(strEmtyName);
		document.forms[0].txtNewPayment.focus();
		return(false);
	}
	return(true);
}

// Check for Update
function CheckUpdate(strEmtyName){
	if(document.forms[0].lsbIndexPayment.options[document.forms[0].lsbIndexPayment.options.selectedIndex].value==0){
		return(false);// Update faile
	}
	if(trim(document.forms[0].txtNewPayment.value)==''){
		alert(strEmtyName);
		document.forms[0].txtNewPayment.focus();
		return(false);
	}
	return(true);
}

// Check for Delete
function CheckDelete(){
	if(document.forms[0].lsbIndexPayment.options[document.forms[0].lsbIndexPayment.options.selectedIndex].value==0){
		return(false);// Delete faile
	}
	return(true);
}

// Load data to textbox
function LoadData(){
	if(document.forms[0].lsbIndexPayment.options.selectedIndex >= 0){
		if(document.forms[0].lsbIndexPayment.options[document.forms[0].lsbIndexPayment.options.selectedIndex].value==0){
			document.forms[0].txtNewPayment.value='';
			document.forms[0].txtNewPayment.focus();
		}
		else{
			document.forms[0].txtNewPayment.value=document.forms[0].lsbIndexPayment.options[document.forms[0].lsbIndexPayment.options.selectedIndex].text;	
		}
	}
}
