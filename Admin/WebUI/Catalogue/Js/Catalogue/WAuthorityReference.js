/*
	LoadBackAReference function
	Purpose: Load authority reference to cataloguing form
	Creator: Oanhtn
	CreatedDate: 20/05/2004
*/
function LoadBackAReference(strIndicatorValue, strFieldValue, strFieldCode, strDestField, strStoreField, intRepeatable) {
	var strIndicators;
	var strTemp;
	

    eval("opener.top.main." + strDestField + ".value = strFieldValue");
	strIndicators = strDestField.replace(".tag", ".ind");
	if (eval("opener.top.main." + strIndicators)) {
		eval("opener.top.main." + strIndicators + ".value = strIndicatorValue");
	}
	
	strTemp = strDestField.substring(strDestField.length - 3, strDestField.length);
	if (opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strTemp) < 0) {
		opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = parent.Sentform.document.forms[0].txtModifiedFieldCodes.value + strTemp + ",";
	}	
	
	if (intRepeatable != 1) {
		if (strStoreField !="") {
	        eval("opener.top.main." + strStoreField).value = strIndicatorValue + "::" + strFieldValue;
		}
	} else {
		UpdateRecord(strTemp, 1);
	}

	UpdateLeader("opener.top.main.Sentform.document.forms[0].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txtLeader", "opener.top.main.Workform.document.forms[0].txtLeader");
	eval("opener.top.main." + strDestField + ".focus()");
	self.close();
	return false;
}