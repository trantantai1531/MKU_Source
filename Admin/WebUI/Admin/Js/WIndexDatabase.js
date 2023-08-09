function ShowHideTable(val) {
	if (val==0) {
		tblPassword.style.display="none";
	}
	else {
		tblPassword.style.display="";	
	}
}

function CheckUpdate(Error1, Error2, Error3,Error4,Warnning ){
	if (trim(document.forms[0].txtConnectionName.value) == "") {
		alert(Error1);
		document.forms[0].txtConnectionName.focus();
		return false;
	}	
	if ((document.forms[0].ddlDatabase.options.selectedIndex==0) && (trim(document.forms[0].txtServerIP.value) == "")) {
		alert(Error2);
		document.forms[0].txtServerIP.focus();
		return false;
	}
	if (trim(document.forms[0].txtDataSource.value) == "") {
		alert(Error3);
		document.forms[0].txtDataSource.focus();
		return false;
	}	
	if (trim(document.forms[0].txtUserName.value) == "") {
		alert(Error4);
		document.forms[0].txtUserName.focus();
		return false;
	}
	if (document.forms[0].hidUpdate.value>0)
		if (!confirm(Warnning)) return false;
	return true;
}

function ResetControl(){
		parent.Workform.document.forms[0].hidConnID.value = 0;
		parent.Workform.document.forms[0].txtConnectionName.value = "";
		parent.Workform.document.forms[0].txtUserName.value = "";
		parent.Workform.document.forms[0].txtPasswordOld.value = "";
		parent.Workform.document.forms[0].txtPasswordNew.value = "";
		parent.Workform.document.forms[0].txtDataSource.value = "";
		parent.Workform.document.forms[0].txtServerIP.value = "";
		parent.Workform.document.forms[0].ddlDatabase.options.selectedIndex = 0;
		parent.Workform.document.forms[0].hidUpdate.value = 0;
		parent.Workform.document.forms[0].chkRun.checked = false;		
}