// CheckAllInput fucntion
function CheckAllInput(msg1, msg2, msg3, msg4)
{

	if ((document.forms[0].txtFullName.value=='')||(document.forms[0].txtNewPassword.value=='') || (document.forms[0].txtNewPassword.value!=document.forms[0].txtRetypePassword.value)) {
		if (document.forms[0].txtFullName.value=='') {
			alert(msg2);
			document.forms[0].txtFullName.focus();
		}
		else if (document.forms[0].txtNewPassword.value==''){
			alert(msg4);
			document.forms[0].txtNewPassword.focus();
		}
		else if (document.forms[0].txtNewPassword.value!=document.forms[0].txtRetypePassword.value) {
			alert(msg1);
			document.forms[0].txtRetypePassword.focus();
		}
		return false;		
	}
	
	return true;
}
//Check input FullName
function CheckInputName(msg1) {
	if (document.forms[0].txtFullName.value=='') {
			alert(msg1);
			document.forms[0].txtFullName.focus();
			return false;
	}
	return true;
}