function GotoPageCSDL(idx) {
	var st="height=400, width=600,menubar=no,scrollbars=no,resizable,screenX=120,screenY=120,top=20,left=100";	
	var strURL="WZ3950DB.aspx?intServerID="+idx;
	var z3950db = window.open(strURL, "Database",st);			
	z3950db.focus();	
}
function CheckEmptyFieldZ3950(val) {
	//insert
	if(val==0) {		
		if(document.forms[0].txtHostName.value==''){
			alert(document.forms[0].ipAlertEmpty.value);
			document.forms[0].txtHostName.focus();					
			return false;
		}
		if(document.forms[0].txtAddress.value==''){
			alert(document.forms[0].ipAlertEmpty.value);
			document.forms[0].txtAddress.focus();		
			return false;
		}
	}
	else {
	}	
	return true;		
}

function CheckInserUpdate(field,strNote,strNote1) {
		if (eval(field+'txtHostNamedtg').value =="") {
				alert(strNote);
				eval(field+'txtHostNamedtg').focus();
				return false;
			}
		if (eval(field+'txtAddressdtg').value =="") {
				alert(strNote);
				eval(field+'txtAddressdtg').focus();
				return false;
			}	
		return true;	
}
