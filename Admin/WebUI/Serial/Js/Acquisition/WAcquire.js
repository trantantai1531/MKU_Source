/*
	CheckRouting function
	Purpose: check routing infor
*/
function CheckRouting(strExcess, strErrorMsg,strErrorNumber,strinValidNumber,strMsgOK) {
	if (document.forms[0].ddlLibrary.selectedIndex==0) {
		alert(strErrorMsg);
		document.forms[0].ddlLibrary.focus();
		return false;	
	}
	if (trim(document.forms[0].txtCopies.value)=='') {
		alert(strinValidNumber);
		document.forms[0].txtCopies.focus();
		return false;	
	}
	intCopies = parseFloat(document.forms[0].txtCopies.value);
	if (intCopies<=0) {
		alert(strErrorNumber);
		return false;
		}
	
	if (eval(document.forms[0].txtRemainCopies)) {		
		intRemainCopies	= parseFloat(document.forms[0].txtRemainCopies.value);
		intPOID=parseFloat(document.forms[0].hidContractID.value);
		if ((intRemainCopies >= intCopies)||(intPOID > 0)) {
			document.forms[0].ddlLibrary.selectedIndex=0;
			document.forms[0].target='Hiddenbase';
			alert(strMsgOK);
			document.forms[0].action='WShowRoute.aspx';
			document.forms[0].submit();
		} else {
			alert(strExcess);
			document.forms[0].txtCopies.value = 0;
		}
	} else {
			document.forms[0].ddlLibrary.selectedIndex=0;
			document.forms[0].target='Hiddenbase';
			alert(strMsgOK);
			document.forms[0].action='WShowRoute.aspx';
			document.forms[0].submit();	
	}
}

/*
	ResetAll function
	Purpose: reset all controls
*/
function ResetAll() {
	document.forms[0].ddlSerCategory.options.selectedIndex = 0;
	document.forms[0].ddlAcqSource.options.selectedIndex = 0;
	document.forms[0].rdoStatus[0].checked = true;
	document.forms[0].txtBasedDate.value='';	
	document.forms[0].txtCeasedDate.value='';
	document.forms[0].chkCeased.checked=false;
	document.forms[0].txtChangeNote.value='';	
	document.forms[0].txtNote.value='';	
	document.forms[0].ddlLibrary.options.selectedIndex = 0;
	document.forms[0].ddlLocation.selectedIndex = 0;
	document.forms[0].txtCopies.value='';	
	document.forms[0].hidLocationID.value='0';	
	return false;
}
function CheckForUpdate(strMsg,strMsg1,strMsg2, strDateformat) {
if (eval(document.forms[0].chkCeased).checked) {
	if (trim(document.forms[0].txtCeasedDate.value)=='') {
		alert(strMsg); 
		document.forms[0].txtCeasedDate.focus();
		return false;
	}
	if (CompareDate(document.forms[0].hidCurrentDate,document.forms[0].txtCeasedDate,strDateformat)==1){
		alert(strMsg1); 
		document.forms[0].txtCeasedDate.focus();
		return false;		
	} 
	else {		
			if (trim(document.forms[0].txtBasedDate.value)!='') {
				if (CompareDate(document.forms[0].txtCeasedDate,document.forms[0].txtBasedDate,strDateformat)==1){
					alert(strMsg2); 
					document.forms[0].txtBasedDate.focus();
					return false;
				}
			}
		}
	}
document.forms[0].target='';
document.forms[0].action='';
return true;
}