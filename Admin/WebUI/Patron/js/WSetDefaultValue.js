/**************************************************************************
************************ WSetDefaultValue Js file *************************
**************************************************************************/
// Reset default value for form
function ResetForm(){
	document.forms[0].reset();
	return(false);
}
// Load default value
function SetUpValue(){
	if(parseInt(document.forms[0].txtValidDate.value)<=0) document.forms[0].txtValidDate.value=20;
	opener.document.forms[0].hdValidDate.value=document.forms[0].txtValidDate.value;
	opener.document.forms[0].hdLastModifiedDate.value=document.forms[0].txtLastModifiedDate.value;
	opener.document.forms[0].hdExpiredDate.value=document.forms[0].txtExpiredDate.value;
	opener.document.forms[0].hdPatronGroupID.value=document.forms[0].ddlPatronGroupID.options[document.forms[0].ddlPatronGroupID.options.selectedIndex].value;
	return(false);
}