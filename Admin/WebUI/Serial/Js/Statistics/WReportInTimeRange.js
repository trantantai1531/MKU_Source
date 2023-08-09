/********************************************************************************/
/****************************	WReportInTimeRange	*****************************/
/********************************************************************************/
function CheckReport(strNote) {
	if (!CheckDate('document.forms[0].txtFromTime','dd/mm/yyyy',strNote)) {
		document.forms[0].txtFromTime.focus();
		return false;
	}
	if (!CheckDate('document.forms[0].txtToTime','dd/mm/yyyy',strNote)) {
		document.forms[0].txtFromTime.focus();
		return false;
	}
	return true;
}

function ResetForm(){
	document.forms[0].txtFromTime.value='';
	document.forms[0].txtToTime.value='';
	return(false);
}

function LoadForm(intItemID) {
	parent.Hiddenbase.location.href='WLoadBack.aspx?ItemID=' + intItemID;
	return;
}
