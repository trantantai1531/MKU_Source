/* 
	CheckAll function
	Purpose: check all mandatory fields
*/ 
function CheckAllInput(){
	return true;
	var chk;
	chk =	CheckNull(document.forms[0].txtTitle) && 	
			CheckNull(document.forms[0].txtCountry) && 	
			CheckNull(document.forms[0].txtPublisher) && 
			CheckNull(document.forms[0].txtLanguage) &&	
			CheckNull(document.forms[0].txtISSN) &&
			CheckNull(document.forms[0].txtClassify)&&
			CheckNull(document.forms[0].txtSubject) &&
			CheckNull(document.forms[0].txtKeyword);
	if (chk && document.forms[0].ddlRegularity.options.selectedIndex == 0) {
		return false;
	}
	return true;
}

/*
	SaveSession function
	Purpose: save session
*/
function SaveSession(lngItemID, strTitle) {
	parent.Hiddenbase.location.href='WSaveSession.aspx';
	parent.Hiddenbase.document.forms[0].hidItemID.value= lngItemID;	
	parent.Hiddenbase.document.forms[0].hidTitle.value= strTitle;	
	parent.Hiddenbase.document.forms[0].btnSave.click();
	return false;
}


/*
	ResetAll function
	Purpose: reset all controls
*/
function ResetAll() {
	document.forms[0].txtTitle.value='';	
	document.forms[0].txtCountry.value='';	
	document.forms[0].txtPublisher.value='';	
	document.forms[0].txtLanguage.value='';	
	document.forms[0].txtISSN.value='';	
	document.forms[0].txtClassify.value='';	
	document.forms[0].txtSubject.value='';	
	document.forms[0].txtKeyword.value='';	
	document.forms[0].ddlYears.options.selectedIndex = 0;
	document.forms[0].ddlRegularity.options.selectedIndex = 0;
	return false;
}
