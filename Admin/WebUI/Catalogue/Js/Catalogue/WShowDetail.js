function ResetValue(){
	var intIndex;
	
	for (intIndex = 0; intIndex<50; intIndex++) {
		if (eval("document.forms[0].chkFile" + intIndex) && eval("document.forms[0].chkFile" + intIndex).checked)
		{
			eval("document.forms[0].chkFile" + intIndex).checked = false;
		}
	}	
}

/*
	UpdateRecord function
	Purpose: UpdateRecord (repeatable fields)
	Creator: Oanhtn
	CreatedDate: 19/05/2004
	Input: - intOption (0: from cataloguing form, 1: from new window)
		   - strFieldCode: string of fielcode
*/
function myUpdateRecord(strFieldCode) {
	if (strFieldCode == "") {
		return; 
	}
	var intCounter;
	var intCounter1 = 0;
	var intPosition;
	var arrFieldValues = new Array();
	var strStoreValue;
	
	ud(strFieldCode);

	strStoreValue = eval("parent.opener.top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value");
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
		
	var currentRecord = eval("parseFloat(parent.opener.top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value)");
	
	if (currentRecord == 0) {
		eval("parent.opener.top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value = 1");
		eval("parent.opener.top.main.Workform.document.forms[0].nr" + strFieldCode + "2.value = 1");
	} else {
		currentRecord--;
		if (currentRecord > intCounter1) {
			intCounter1 = currentRecord;
		}
	}
	if (eval("parent.opener.top.main.Workform.document.forms[0].ind" + strFieldCode)) {
		arrFieldValues[currentRecord] = eval("parent.opener.top.main.Workform.document.forms[0].ind" + strFieldCode + ".value") + "::" + eval("parent.opener.top.main.Workform.document.forms[0].tag" + strFieldCode + ".value"); 
	} else {
		arrFieldValues[currentRecord] = eval("parent.opener.top.main.Workform.document.forms[0].tag" + strFieldCode + ".value"); 
		alert(arrFieldValues[currentRecord]);
	}

	strStoreValue = "";
	for (intCounter = 0; intCounter <= intCounter1; intCounter++) {
		if (arrFieldValues[intCounter]) {
			strStoreValue = strStoreValue + arrFieldValues[intCounter] + "$&";
		}
	}
	strStoreValue = EscapeSingleQuote(strStoreValue);
	eval("parent.opener.top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + strStoreValue + "'");
	UpdateLeader("parent.opener.top.main.Sentform.document.forms[0].txtFieldCodes", "parent.opener.top.main.Sentform.document.forms[0].tag", "parent.opener.top.main.Sentform.document.forms[0].txtLeader", "parent.opener.top.main.Workform.document.forms[0].txtLeader");
}

/*
	u function
	Purpose: check input field which is in Sentform. if not, add in ModifiedFieldCodes
*/
function ud(strFieldCode) {
	if (parent.opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strFieldCode) < 0) {
		parent.opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = parent.opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strFieldCode + ",";
	}
}

/*
	DownLoad function
	Purpose: Refresh the page
*/
function DownLoad(strFile){
		document.forms[0].hidFunc.value = "DownLoad";
		document.forms[0].hidLoc.value = strFile;
		document.forms[0].submit();
}