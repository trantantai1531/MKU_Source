/*
	CheckAll function
	Purpose: Check null value of manatory fields
*/
function CheckAll() {
	if (CheckNull(document.forms[0].txtVolume)) {
		document.forms[0].txtVolume.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtPrice)) {
		document.forms[0].txtPrice.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtCopyNumber)) {
		document.forms[0].txtCopyNumber.focus();
		return false;
	}
	return true;
}
function SetPrice(blnCheck) {
	if (document.forms[0].hidPrice.value==0) return false;
	var price=parseFloat(document.forms[0].hidPrice.value);
	var sum=parseFloat(document.forms[0].txtPrice.value);
	if (blnCheck) {
		document.forms[0].txtPrice.value=sum+price
	}
	else {
		document.forms[0].txtPrice.value=sum-price
	}	
}
function ShowBinding(CNID,VBL) {
	OpenWindow('WBindingVolumn.aspx?CopyNumberID=' + CNID + '&VolumeByLibrary=' + VBL + '&LocationID='+document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.selectedIndex].value +'&Year='+document.forms[0].ddlYear.options[document.forms[0].ddlYear.selectedIndex].value,'Binding',700,500,10,50);
}
function RefreshBinding() {	
	opener.top.main.Workform.location.href="WBinding.aspx";
}