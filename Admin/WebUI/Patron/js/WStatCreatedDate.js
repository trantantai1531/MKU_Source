
/**************************************************************************
************************ Statistic WStatCreatedDate Js file ***************
**************************************************************************/
// Check ValidData
//function CheckValidData(strYearAlert){
//	if(document.forms[0].optEachYearExpired.Checked){
//		if(isNaN(document.forms[0].txtYear.value)){
//		alert(strYearAlert);
//		document.forms[0].txtYear.focus();
//		return(false);
//		}		
//	}
//	return(true);
//}
function CheckValidData(strMsg) {
    var fromDate = document.getElementById("txtFromDate").value;
    var ToDate = document.getElementById("txtToDate").value;
    if (!isNaN(document.forms[0].txtFromDate.value)) {
        alert(strMsg)
        document.forms[0].txtFromDate.focus();
        return false;
    }
    if (!isNaN(document.forms[0].txtToDate.value)) {
        alert(strMsg)
        document.forms[0].txtToDate.focus();
        return false;
    }
    return (true);
}
// CheckValueIt function
function CheckValueIt(strMsg){
	if(document.forms[0].optEachYearExpired.Checked){
		if(document.forms[0].txtYear.value!=''){
			if(isNaN(document.forms[0].txtYear.value)){
				alert(strMsg);
				document.forms[0].txtYear.focus();
				return(false);
			}
		}
	}
	return(true);
}