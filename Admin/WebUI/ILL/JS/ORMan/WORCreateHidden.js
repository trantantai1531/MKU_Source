/********************************************************************************
*					OUT REQUST CREATE HIDDEN									*
********************************************************************************/
// Load ILL Library to WORCreate.aspx
function LoadLib(strLibName,strEmailIP,strAccount){
	alert(strLibName);
	parent.Workform.document.forms[0].txtLibName.value=strLibName;
	parent.Workform.document.forms[0].txtEmailIP.value=strEmailIP;
	parent.Workform.document.forms[0].txtAccount.value=strAccount;	
	return(false);
}