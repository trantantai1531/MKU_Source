/*
	DownLoad function
	Purpose: Refresh the page
*/
function DownLoad(strFile){
		document.forms[0].hidFunc.value = "DownLoad";
		document.forms[0].hidLoc.value = strFile;
		document.forms[0].submit();
}