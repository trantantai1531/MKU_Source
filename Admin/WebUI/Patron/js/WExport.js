/**************************************************************************
************************ WExport Js file *********************************
**************************************************************************/
// Check for export data
function CheckExport(strTemplate,strSeperator){
	if(document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value==0){
		alert(strTemplate);
		document.forms[0].ddlTemplate.focus();
		return(false);
	}
	if(document.forms[0].txtSeperator.value==''){
		alert(strSeperator);
		document.forms[0].txtSeperator.value='#'
		document.forms[0].txtSeperator.focus();
		return(false);
	}
	return(true);
}
// Open It method
function OpenIt(strPath){	
	document.forms[0].lnkPhysicalPath.url=strPath;
}
