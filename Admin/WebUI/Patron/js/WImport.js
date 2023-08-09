/**************************************************************************
************************ WImport Js file *********************************
**************************************************************************/
// Check for export data
function CheckImport(strTemplate,strSeperator){
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
// Open set default value form
function SetDefaultValue(){
SetDefaultValueWin = window.open('','SetDefaultValueWin','height=350,width=480,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=40,left=60');		
	document.forms[0].action='WSetDefaultValue.aspx';
	document.forms[0].target='SetDefaultValueWin';
	document.forms[0].submit();			
	document.forms[0].action='WImports.aspx';
	document.forms[0].target= self.name;
	SetDefaultValueWin.focus();
}