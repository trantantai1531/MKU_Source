/*************************************************************
					ELECTRIC DELMODE 	
*************************************************************/

// Check for AddNew
function CheckAddNew(strAlert){
	if(trim(document.forms[0].txtAddnew.value)==''){
		alert(strAlert);
		document.forms[0].txtAddnew.focus();
		return(false);
	}
	else {
		if (trim(document.forms[0].txtAddr.value)==''){
			alert(strAlert);
			document.forms[0].txtAddr.focus();
			return(false);
		}
	}
	return(true);
}
function CheckInserUpdate(field,strNote) {
		document.forms[0].hidEArr.value = eval(field+'txtEArr').value;
		document.forms[0].hidEMode.value = eval(field+'txtEMode').value;		
		if (eval(field+'txtEMode').value =="") {
				alert(strNote);
				eval(field+'txtEMode').focus();
				return (false);
			}
		else {
			if (eval(field+'txtEArr').value =="") {
				alert(strNote);
				eval(field+'txtEArr').focus();
				return (false);
			}
		}
		return (true);	
}