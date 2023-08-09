/*
	LoadBack function
	Purpose: load data back to opener form
*/
function LoadBack(strReceiptNo,strContractID) {
	eval(strObjName).value = strReceiptNo;
	eval(strObjContractID).value = strContractID;
	self.close();
}


function ResetAll()
{
	document.forms[0].txtContractNo.value='';
	document.forms[0].txtContractName.value='';
	document.forms[0].txtFromDate.value='';
	document.forms[0].txtToDate.value='';
	document.forms[0].ddlBudget.selectedIndex =0;
	document.forms[0].ddlVendor.selectedIndex =0;
}
