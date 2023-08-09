/**************************************************************************
************************ Monitor Print Card Js file ***********************
**************************************************************************/
function CheckAll(st){
	// check Date
	if (!CheckDate(document.forms[0].txtDOB,'dd/mm/yyyy',st)){
		return false;
	}else{
		if (!CheckDate(document.forms[0].txtValidDate,'dd/mm/yyyy',st)){
			return false;
		}else{
			return true;
		}
	}
}

function ClearAll() {
	document.forms[0].txtCode.value = '';
	document.forms[0].txtFullName.value = '';
	document.forms[0].txtValidDate.value = '';
	document.forms[0].txtDOB.value = '';
	document.forms[0].txtGrade.value = '';
	document.forms[0].txtClass.value = '';
	document.forms[0].ddlSelectTop.options.selectedIndex = 0;
	document.forms[0].ddlSex.options.selectedIndex = 0;
	
}