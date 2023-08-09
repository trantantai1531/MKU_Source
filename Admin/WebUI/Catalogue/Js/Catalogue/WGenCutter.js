
/*
	LoadBack function
	Purpose: 
		- Update valuf of hidden field txtModifiedFieldCodes.
		- Load strCutter into Field090$b.
	Creator: Oanhtn
	CreatedDate: 18/05/2004
	Modification History:
*/
function LoadBack(strCutter) {
	/*var strClassification;
	if (top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf("090") < 0) {
		top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value +  "090,";
	}
	strClassification = parent.Workform.document.forms[0].tag090.value.substring(0, parent.Workform.document.forms[0].tag090.value.lastIndexOf("$b") + 2);
	parent.Workform.document.forms[0].tag090.value = strClassification + strCutter;
	parent.Sentform.document.forms[0].tag090.value = strClassification + strCutter;
    UpdateLeader("top.main.Sentform.document.forms[0].txtFieldCodes", "top.main.Sentform.document.forms[0].tag", "top.main.Sentform.document.forms[0].txtLeader", "top.main.Workform.document.forms[0].txtLeader");
	parent.Workform.document.forms[0].tag090.focus();*/
    if (top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf("082$b") < 0) {
        top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + "082$b,";
    }
    //strClassification = parent.Workform.document.forms[0].tag090.value.substring(0, parent.Workform.document.forms[0].tag090.value.lastIndexOf("$b") + 2);
    parent.Workform.document.forms[0].tag082$b.value = strCutter;
    parent.Sentform.document.forms[0].tag082$b.value = strCutter;
    UpdateLeader("top.main.Sentform.document.forms[0].txtFieldCodes", "top.main.Sentform.document.forms[0].tag", "top.main.Sentform.document.forms[0].txtLeader", "top.main.Workform.document.forms[0].txtLeader");
    parent.Workform.document.forms[0].tag082$b.focus();

}