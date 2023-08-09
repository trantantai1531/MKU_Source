function CheckValidDate(strMsg){
	if (! CheckDate(document.forms[0].txtCheckOutDateFrom,'dd/mm/yyyy',strMsg)){
		alert(strMsg);
		document.forms[0].txtCheckOutDateFrom.focus();
		return false;
	}else{
		if (! CheckDate(document.forms[0].txtCheckOutDateTo,'dd/mm/yyyy',strMsg)){
			alert(strMsg);
			document.forms[0].txtCheckOutDateTo.focus();
			return false;
		}else{
			if (! CheckDate(document.forms[0].txtDueDateFrom,'dd/mm/yyyy',strMsg)){
				alert(strMsg);
				document.forms[0].txtDueDateFrom.focus();
				return false;
			}else{
				if (! CheckDate(document.forms[0].txtDueDateTo,'dd/mm/yyyy',strMsg)){
					alert(strMsg);
					document.forms[0].txtDueDateTo.focus();
					return false;
				}else{
						return true;
					 }						
				}			
			}		
		}
}
function ResetForm() {
	document.forms[0].txtPatronCode.value="";
	document.forms[0].txtItemCode.value="";
	document.forms[0].txtCopyNumber.value="";
	document.forms[0].txtCheckOutDateFrom.value="";
	document.forms[0].txtCheckOutDateTo.value="";
	document.forms[0].txtDueDateTo.value="";
	document.forms[0].txtDueDateFrom.value="";
	document.forms[0].ddlLocationName.selectedIndex=0;
	return false;
}
