/*
	function: CheckAll
	Purpose: validate data
*/	
function CheckAll(strMsg) {
	if (!CheckNull(document.forms[0].txbTitle)) {return true}
	if (!CheckNull(document.forms[0].txbFromDate)) {return true}
	if (!CheckNull(document.forms[0].txbToDate)) {return true}
	if (!CheckNull(document.forms[0].txbIssue)) {return true}
	if (!CheckNull(document.forms[0].txbVolume)) {return true}
	alert(strMsg);
	return false;
}

/*
	function: ReLoadData
	Purpose: Load data to opener form
*/
function ReLoadData(strFieldCode, strValue) {
	ud(strFieldCode);
	eval("opener.top.main.Workform.document.forms[0].tag" + strFieldCode + ".value = '" + strValue + "'");
	if (eval("opener.top.main.Workform.document.forms[0].nr" + strFieldCode + "1")) {
		myUpdateRecord(strFieldCode, strValue);
	} else {
		eval("opener.top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '::" + strValue + "'");
	}
	eval("opener.top.main.Workform.document.forms[0].tag" + strFieldCode + ".focus()");
	self.close();
    return;
}


/*
	UpdateRecord function
	Purpose: UpdateRecord (repeatable fields)
	Creator: Oanhtn
	CreatedDate: 19/05/2004
	Input: - strValue: value
		   - strFieldCode: string of fieldcode
*/		   
function myUpdateRecord(strFieldCode, strValue) {
	if (strFieldCode == "") {
		return; 
	}
	var intCounter;
	var intCounter1 = 0;
	var intPosition;
	var arrFieldValues = new Array();
	var strStoreValue;
	
	strStoreValue = eval("opener.top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value");
	while (strStoreValue.length > 0) {
		intPosition = strStoreValue.indexOf("$&");
		if (intPosition >= 0) {
			arrFieldValues[intCounter1] = strStoreValue.substring(0, intPosition);
			strStoreValue = strStoreValue.substring(intPosition + 2, strStoreValue.length);
		} else {
			arrFieldValues[intCounter1]= strStoreValue;
			strStoreValue = "";
		}
		intCounter1++;
	}
		
	var currentRecord = eval("parseFloat(opener.top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value)");
	
	if (currentRecord == 0) {
		eval("opener.top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value = 1");
		eval("opener.top.main.Workform.document.forms[0].nr" + strFieldCode + "2.value = 1");
	} else {
		currentRecord--;
		if (currentRecord > intCounter1) {
			intCounter1 = currentRecord;
		}
	}
	if (eval("opener.top.main.Workform.document.forms[0].ind" + strFieldCode)) {
		arrFieldValues[currentRecord] = eval("opener.top.main.Workform.document.forms[0].ind" + strFieldCode + ".value") + "::" + strValue;
	} else {
		arrFieldValues[currentRecord] = strValue;
	}

	strStoreValue = "";
	for (intCounter = 0; intCounter <= intCounter1; intCounter++) {
		if (arrFieldValues[intCounter]) {
			strStoreValue = strStoreValue + arrFieldValues[intCounter] + "$&";
		}
	}
	strStoreValue = EscapeSingleQuote(strStoreValue);
	eval("opener.top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + strStoreValue + "'");
	UpdateLeader("opener.top.main.Sentform.document.forms[0].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txtLeader", "opener.top.main.Workform.document.forms[0].txtLeader");
}

/*
	function: CheckAll
	Purpose: validate data
*/	
function CheckAll(strMsg) {
	document.forms[0].txbTitle.value='';
	document.forms[0].txbTitle.focus();
	document.forms[0].txbFromDate.value='';
	document.forms[0].txbToDate.value='';
	document.forms[0].txbIssue.value='';
	document.forms[0].txbVolume.value='';
}