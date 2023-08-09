/**********************************************************************************/
/***********************		WStatLocation Js file		***********************/
/**********************************************************************************/
function SendLibrary(){
	parent.Display.location.href='WStatLocation.aspx?LocID=' + document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.selectedIndex].value;
	return(false);
}
function BackToStat(){
	parent.parent.mainacq.location.href='WStatIndex.aspx';
	return(false);
}
