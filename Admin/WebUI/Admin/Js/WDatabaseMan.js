function LoadUserInfor(ConnID,ConnectionName,UserName, PassWordOld, DataSource, ServerIP, Database, Run) {
	// ConnID
	if (ConnID != "") {
		parent.Workform.document.forms[0].hidConnID.value = ConnID;
	}
	// Run
	if (Run == 1){
		parent.Workform.document.forms[0].chkRun.checked = true;}
	else{
		parent.Workform.document.forms[0].chkRun.checked = false;}
		
	// ConnectionName
	if (ConnectionName != "") {
		parent.Workform.document.forms[0].txtConnectionName.value = ConnectionName;
	}
	
	// UserName
	if (UserName != "") {
		parent.Workform.document.forms[0].txtUserName.value = UserName;
	}
	
	// PassWordOld
	if (PassWordOld != "") {
		parent.Workform.document.forms[0].txtPasswordOld.value = PassWordOld;
		parent.Workform.document.forms[0].txtPasswordNew.value = PassWordOld;
	}
	
	// DataSource
	if (DataSource != "") {
		parent.Workform.document.forms[0].txtDataSource.value = DataSource;
	}
	

	// ServerIP
	if (ServerIP != "") {
		parent.Workform.document.forms[0].txtServerIP.value = ServerIP;
	}
	
	// Database
	if (Database != "") {
		parent.Workform.document.forms[0].ddlDatabase.options.selectedIndex = Database;
	}
	parent.Workform.document.forms[0].hidUpdate.value = 1;	
	parent.Workform.tblPassword.style.display="";		
}