function ClearContent()
{
	document.forms[0].txtSymbol.value = '';
	document.forms[0].txtName.value = '';
	document.forms[0].txtEmailAddress.value = '';
	document.forms[0].txtPhone.value = '';
	document.forms[0].txtCode.value = '';
	document.forms[0].txtNote.value = '';
	document.forms[0].txtEDelivMode.value = '';
	document.forms[0].txtEDelivTSAdd.value = '';
	document.forms[0].txtDelivName.value = '';
	document.forms[0].hidPostDelivName.value = '';
	document.forms[0].hidPostDelivXAddr.value = '';
	document.forms[0].txtDelivXAddr.value = '';
	document.forms[0].txtDelivStreet.value = '';
	document.forms[0].hidPostDelivXAddr.value = '';
	document.forms[0].txtDelivStreet.value = '';
	document.forms[0].hidPostDelivStreet.value = '';
	document.forms[0].txtDelivBox.value = '';
	document.forms[0].hidPostDelivBox.value = '';
	document.forms[0].txtDelivCity.value = '';
	document.forms[0].hidPostDelivCity.value = '';
	document.forms[0].txtDelivRegion.value = '';
	document.forms[0].hidPostDelivRegion.value = '';
	document.forms[0].ddlCountry.selectedIndex = 0;
	document.forms[0].hidPostDelivCountry.value = document.forms[0].ddlCountry.options[document.forms[0].ddlCountry.options.selectedIndex].value; 
	document.forms[0].txtDelivCode.value = '';
	document.forms[0].hidPostDelivCode.value = '';
	document.forms[0].hidBillDelivName.value = '';
	document.forms[0].hidBillDelivXAddr.value = '';
	document.forms[0].hidBillDelivStreet.value = '';
	document.forms[0].hidBillDelivBox.value = '';
	document.forms[0].hidBillDelivCity.value = '';
	document.forms[0].hidBillDelivRegion.value = '';
	document.forms[0].hidBillDelivCountry.value = document.forms[0].ddlCountry.options[document.forms[0].ddlCountry.options.selectedIndex].value; 
	document.forms[0].ddlEncodingSchema.options.selectedIndex = 0;
	document.forms[0].hidBillDelivCode.value = '';
	document.forms[0].hidLibID.value = 0;
}


// CheckNull function
function CheckNullInput(f, fieldname, msg1, msg2) {
	val = f.value;
	if(trim(val)!='') return false;
	alert (msg1 + ': [' + fieldname + '] ' + msg2);
	f.focus();
	return true;
}

// CheckValid function
function CheckValid(msg1,msg2,msg3, msg4, msg5, msg6,msg7) {
	if (CheckNullInput(document.forms[0].txtSymbol, msg1, msg5, msg6)) { return false; }
	if (CheckNullInput(document.forms[0].txtName, msg2, msg5, msg6)) { return false; }
	if (CheckNullInput(document.forms[0].txtEmailAddress, msg3, msg5, msg6)) { return false; }
	if (!CheckValidEmail(document.forms[0].txtEmailAddress)) { alert (msg4); return false; }
	if (CheckNullInput(document.forms[0].txtCode, msg7, msg5, msg6)) { return false; }	
	return;
}

// LoadPhysAddr fuciton
function LoadPhysAddr() {
		if (document.forms[0].rdoPosAddress.checked) {
			document.forms[0].txtDelivName.value = document.forms[0].hidPostDelivName.value;
			document.forms[0].txtDelivXAddr.value = document.forms[0].hidPostDelivXAddr.value;
			document.forms[0].txtDelivStreet.value = document.forms[0].hidPostDelivStreet.value;
			document.forms[0].txtDelivBox.value = document.forms[0].hidPostDelivBox.value;
			document.forms[0].txtDelivCity.value = document.forms[0].hidPostDelivCity.value;
			document.forms[0].txtDelivRegion.value = document.forms[0].hidPostDelivRegion.value;
			document.forms[0].txtDelivCode.value = document.forms[0].hidPostDelivCode.value;
			for (i = 0; i < document.forms[0].ddlCountry.options.length; i++) {
				if (document.forms[0].ddlCountry.options[i].value == document.forms[0].hidPostDelivCountry.value) {
					document.forms[0].ddlCountry.options.selectedIndex = i;
					break;
				}
			}
		}
		if (document.forms[0].rdoBillAddress.checked) { 
			document.forms[0].txtDelivName.value = document.forms[0].hidBillDelivName.value;
			document.forms[0].txtDelivXAddr.value = document.forms[0].hidBillDelivXAddr.value;
			document.forms[0].txtDelivStreet.value = document.forms[0].hidBillDelivStreet.value;
			document.forms[0].txtDelivBox.value = document.forms[0].hidBillDelivBox.value;
			document.forms[0].txtDelivCity.value = document.forms[0].hidBillDelivCity.value;
			document.forms[0].txtDelivRegion.value = document.forms[0].hidBillDelivRegion.value;
			document.forms[0].txtDelivCode.value = document.forms[0].hidBillDelivCode.value;
			for (i = 0; i < document.forms[0].ddlCountry.options.length; i++) {
				if (document.forms[0].ddlCountry.options[i].value == document.forms[0].hidBillDelivCountry.value) {
					document.forms[0].ddlCountry.options.selectedIndex = i;
					break;
				}
			}
		}
}

// ShowPost function 
function ShowPost() {
	document.forms[0].rdoBillAddress.checked = false;
	LoadPhysAddr();
}

// ShowBill function 
function ShowBill() {
	document.forms[0].rdoPosAddress.checked = false;
	LoadPhysAddr();
}

// UpdateValue function 
function UpdateValue (f, val) {
		if (val != -1) {
			if (document.forms[0].rdoPosAddress.checked)
				eval("document.forms[0].hidPost" + f + ".value = \"" + val + "\"");
			if (document.forms[0].rdoBillAddress.checked)
				eval("document.forms[0].hidBill" + f + ".value = \"" + val + "\"");
		}
		else {
			if (document.forms[0].rdoPosAddress.checked)
				eval("document.forms[0].hidPost" + f + ".value = document.forms[0].txt" + f + ".value");
			if (document.forms[0].rdoBillAddress.checked) 
				eval("document.forms[0].hidBill" + f + ".value = document.forms[0].txt" + f + ".value");
		}
}

// Confirm the delete (YES = Do action, NO = Cancel)
function ConfirmDelete(strMsg1, strMsg2) {
	if (document.forms[0].lstLibrary.options[document.forms[0].lstLibrary.options.selectedIndex].value > 0) {
		var truthBeTold = window.confirm(strMsg1);
		if (truthBeTold) {
			return true;
		} else{
			return false;
		}
	} else {
		alert(strMsg2)
		return false
	}
}

function OnLoad(){
	//parent.document.getElementById('frmMain').setAttribute('rows',rows="36,*,0,0");
}