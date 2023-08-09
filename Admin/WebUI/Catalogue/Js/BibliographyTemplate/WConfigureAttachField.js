/*
	InitForm
	Purpose: load data from opener document
*/
function InitForm() {
	document.forms[0].txtPhysicalPath.value = opener.document.forms[0].txtPhysicalPath.value;
	document.forms[0].txtAllowedFileExt.value = opener.document.forms[0].txtAllowedFileExt.value;
	document.forms[0].txtDeniedFileExt.value = opener.document.forms[0].txtDeniedFileExt.value;
	document.forms[0].txtMaxsize.value = opener.document.forms[0].txtMaxsize.value;
	document.forms[0].txtLogo.value = opener.document.forms[0].txtLogo.value;
	document.forms[0].txtPrefix.value = opener.document.forms[0].txtPrefix.value;
	document.forms[0].txtURL.value = opener.document.forms[0].txtURL.value;
}


/*
	SubmitForm
	Purpose: load data to opener document
*/
function SubmitForm() {
	opener.document.forms[0].txtPhysicalPath.value = document.forms[0].txtPhysicalPath.value;
	opener.document.forms[0].txtAllowedFileExt.value = document.forms[0].txtAllowedFileExt.value;
	opener.document.forms[0].txtDeniedFileExt.value = document.forms[0].txtDeniedFileExt.value;
	opener.document.forms[0].txtMaxsize.value = document.forms[0].txtMaxsize.value;
	opener.document.forms[0].txtLogo.value = document.forms[0].txtLogo.value;
	opener.document.forms[0].txtPrefix.value = document.forms[0].txtPrefix.value;
	opener.document.forms[0].txtURL.value = document.forms[0].txtURL.value;
	self.close();	
}

