/**********************************************************************************/
/**************************		WStatSource Js file		***************************/
/**********************************************************************************/
function CheckForSubmit(strFromDateError,strToDateError){
	if(!CheckDate(document.forms[0].txtFromDate,'dd/mm/yyyy',strFromDateError)) return(false);
	if(!CheckDate(document.forms[0].txtToDate,'dd/mm/yyyy',strToDateError)) return(false);
	location.href='WStatSource.aspx?FromDate='+ document.forms[0].txtFromDate.value + '&ToDate=' + document.forms[0].txtToDate.value;
	return true;
}