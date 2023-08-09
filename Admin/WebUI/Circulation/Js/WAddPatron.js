
function ValidNew(strMsg){
	if (CheckNull(document.forms[0].txtCode)){
		alert(strMsg);
		document.forms[0].txtCode.focus();
		return false;
	}else{
		if (CheckNull(document.forms[0].txtValidDate)){
			alert(strMsg);
			document.forms[0].txtValidDate.focus();
			return false;
		}else{
			if (CheckNull(document.forms[0].txtExpiredDate)){
				alert(strMsg);
				document.forms[0].txtExpiredDate.focus();
				return false;
			} else {
				if ((CheckNull(document.forms[0].txtFirstName)) || (CheckNull(document.forms[0].txtLastName))){
					alert(strMsg);
					document.forms[0].txtFirstName.focus();
					return false;
				}else{
					return true;
				}						
			}			
		}		
	}
}
function Resetform(strDateofNow) {
	document.forms[0].txtCode.value='';
	document.forms[0].txtValidDate.value=strDateofNow;
	document.forms[0].txtValidDate.value=strDateofNow;
	document.forms[0].txtFirstName.value='';
	document.forms[0].txtMiddleName.value='';
	document.forms[0].txtLastName.value='';
	document.forms[0].txtWorkPlace.value='';
	document.forms[0].txtTelephone.value='';
	document.forms[0].txtEmail.value='';
	document.forms[0].ddlPatronGroup.selectedIndex=0;	
}