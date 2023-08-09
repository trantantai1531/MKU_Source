/************************************************************************
							PhyDelAddr
************************************************************************/

// Check for Addnew
function CheckAddNew(){
	return true;
}

// Split listbox value
function SplitIt(){
var strSplit;
var arrSplit;
	if(document.forms[0].lsbAddressIndex.options.selectedIndex==0){
		document.forms[0].txtAddress.value='';
		document.forms[0].txtXAddress.value='';
		document.forms[0].txtStreet.value='';
		document.forms[0].txtPOBox.value='';
		document.forms[0].txtCity.value='';
		document.forms[0].txtRegion.value='';
		document.forms[0].ddlCountry.options[0].selected=true;
		document.forms[0].txtPostCode.value='';
		document.forms[0].txtAddress.focus();
		document.forms[0].hdAddressIndex.value='';
		return false;
	}
	else{
		strSplit=document.forms[0].lsbAddressIndex.options[document.forms[0].lsbAddressIndex.options.selectedIndex].value;
		document.forms[0].hdAddressIndex.value=strSplit;
		arrSplit=strSplit.split('<$#$>');
		document.forms[0].txtAddress.value=arrSplit[1];
		document.forms[0].txtXAddress.value=arrSplit[2];
		document.forms[0].txtStreet.value=arrSplit[3];
		document.forms[0].txtPOBox.value=arrSplit[4];
		document.forms[0].txtCity.value=arrSplit[5];
		document.forms[0].txtRegion.value=arrSplit[6];
		for(i=0;i<document.forms[0].ddlCountry.length;i++){
			if(document.forms[0].ddlCountry.options[i].value==arrSplit[7]){
				document.forms[0].ddlCountry.options[i].selected=true;
				i=document.forms[0].ddlCountry.length + 1;
			}
		}
		document.forms[0].txtPostCode.value=arrSplit[8];
		return true;
	}	
}

// Check for Addnew 
function CheckAddNew(strAddress){
	if(trim(document.forms[0].txtAddress.value)==''){
		alert(strAddress);
		document.forms[0].txtAddress.focus();
		return false; // Can't addnew
	}
	// Addnew action alow
	document.forms[0].hdAddressIndex.value='';
	return true;
}

// Check for Update
function CheckUpdate(strAddress){
	if(trim(document.forms[0].txtAddress.value)=='' || document.forms[0].lsbAddressIndex.length <=0 ){
		alert(strAddress);
		document.forms[0].txtAddress.focus();
		return false; // Can't update
	}
	// Update action alow
	return true;
}

// Check for Delete
function CheckDelete(strMsg1, strMsg2){
	if(document.forms[0].lsbAddressIndex.options.selectedIndex==0){ 
		alert(strMsg2);
		return false;
	} 
	if(confirm(strMsg1) && document.forms[0].lsbAddressIndex.length > 0){
		return true;
	}
	return false;
}