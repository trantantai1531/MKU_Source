/**********************************************************************************/
/***********************		WVendorMan Js file		***************************/
/**********************************************************************************/
// ConfirmDelete function
function ConfirmDelete(strMssg1, strMssg2){
	if(document.forms[0].ddlVendorLists.options[document.forms[0].ddlVendorLists.options.selectedIndex].value==0){
		alert(strMssg2);
		return false;
	}
	if (confirm(strMssg1)) {
		return true;
	} else {
		return false;
	}
}
// CheckValidData function
function CheckValidData(strEmail, strNaN, strMandatory){
	if (CheckNull(document.forms[0].txtName)) {
		alert(strMandatory);
		document.forms[0].txtName.focus();
		return false;		
	}

	if (!CheckNum(document.forms[0].txtClaimCycle1)) {
		alert(strNaN);
		document.forms[0].txtClaimCycle1.value='';
		document.forms[0].txtClaimCycle1.focus();
		return false;		
	}

	if (!CheckNum(document.forms[0].txtClaimCycle2)) {
		alert(strNaN);
		document.forms[0].txtClaimCycle2.value='';
		document.forms[0].txtClaimCycle2.focus();
		return false;		
	}
	
	if (!CheckNum(document.forms[0].txtClaimCycle3)) {
		alert(strNaN);
		document.forms[0].txtClaimCycle3.value='';
		document.forms[0].txtClaimCycle3.focus();
		return false;		
	}
	
	if (!CheckNum(document.forms[0].txtDeliveryTime)) {
		alert(strNaN);
		document.forms[0].txtDeliveryTime.value='';
		document.forms[0].txtDeliveryTime.focus();
		return false;		
	}
		
	if(document.forms[0].txtEmail.value!='') {
		if(CheckValidEmail(document.forms[0].txtEmail)==false){
			alert(strEmail);
			document.forms[0].txtEmail.focus();
			return false;
		}
	}
	
	if(document.forms[0].txtX12Email.value!='') {
		if(CheckValidEmail(document.forms[0].txtX12Email)==false){
			alert(strEmail);
			document.forms[0].txtX12Email.focus();
			return false;
		}
	}
	
	if(document.forms[0].txtClaimEmail.value!='') {
		if(CheckValidEmail(document.forms[0].txtClaimEmail)==false){
			alert(strEmail);
			document.forms[0].txtClaimEmail.focus();
			return false;
		}
	}
	return true;
}