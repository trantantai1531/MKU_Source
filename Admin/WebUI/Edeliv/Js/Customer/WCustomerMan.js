function ClearContent()
{
	document.forms[0].txtFullName.value = '';
	document.forms[0].txtContactName.value = '';
	document.forms[0].txtEmailAddress.value = '';
	document.forms[0].txtPhone.value = '';
	document.forms[0].txtFaxNumber.value = '';
	document.forms[0].txtNote.value = '';
	document.forms[0].txtEdelivUserName.value = '';
	document.forms[0].txtEdelivPassword.value = '';
	document.forms[0].txtRetypePassword.value = '';
	document.forms[0].txtWorkPlace.value = '';
	document.forms[0].txtDepartment.value = '';
	document.forms[0].txtAddress.value = '';
	document.forms[0].txtArea.value = '';
	document.forms[0].txtBox.value = '';
	document.forms[0].txtCity.value = '';
	document.forms[0].txtPostalCode.value = '';
	document.forms[0].txtDebt.value = '';
	document.forms[0].chkStatus.checked = false;
	document.forms[0].hidCustomerID.value = 0;
	document.forms[0].txtSecretLevel.value='0';
}

// CheckNull function
function CheckNullInput(f, fieldname, msg1, msg2) {
	val = trim(f.value);
	if (val!="") return false;
	f.focus();
	alert (msg1 + ': [' + fieldname + '] ' + msg2);
	return true;
}

// CheckValid function
function CheckValid(msg1,msg2,msg3,msg4,msg5,msg6,msg7,msg8,msg9,msg10, msg11, msg12, msg13) {
	if (CheckNullInput(document.forms[0].txtFullName, msg1, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtContactName, msg2, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtEmailAddress, msg4, msg11, msg12)) { return false; }		
	if (CheckNullInput(document.forms[0].txtPhone, msg3, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtEdelivUserName, msg5, msg11, msg12)) { return false; }		
	if (CheckNullInput(document.forms[0].txtEdelivPassword, msg6, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtWorkPlace, msg7, msg11, msg12)) { return false; }
	if (CheckNullInput(document.forms[0].txtAddress, msg8, msg11, msg12)) { return false; }				
	if (CheckNullInput(document.forms[0].txtCity, msg9, msg11, msg12)) { return false; }	
	if (document.forms[0].txtEdelivPassword.value != document.forms[0].txtRetypePassword.value) { alert(msg10); return false;}
	if (!CheckValidEmail(document.forms[0].txtEmailAddress)) { alert (msg13); return false; }
	return;
}

function OnLoad(){
	parent.document.getElementById('frmMain').setAttribute('rows',rows="*,0");
}