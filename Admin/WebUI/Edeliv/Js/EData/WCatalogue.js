var curtab;
var TagArr = new Array(14);
TagArr[0] = '01';
TagArr[1] = '02';
TagArr[2] = '03';
TagArr[3] = '04';
TagArr[4] = '05';
TagArr[5] = '06';
TagArr[6] = '07';
TagArr[7] = '08';
TagArr[8] = '09';
TagArr[9] = '10';
TagArr[10] = '11';
TagArr[11] = '12';
TagArr[12] = '13';
TagArr[13] = '14';
TagArr[14] = '15';

curtab = 0;

/*
	AddNew function
	Purpose: Add new row
*/
function AddNew(intBreakPoint) {
	document.forms[0].hidBreakPoint.value = intBreakPoint;
	document.forms[0].hidFieldNum.value = parseFloat(document.forms[0].hidFieldNum.value) + 1;	
	document.forms[0].hidFunc.value = 'add';
	document.forms[0].submit();
}

/*
	Remove function
	Purpose: remove selected row
*/
function Remove(intBreakPoint) {
	document.forms[0].hidBreakPoint.value = intBreakPoint;
	document.forms[0].hidFieldNum.value = parseFloat(document.forms[0].hidFieldNum.value) - 1;
	document.forms[0].hidFunc.value = 'remove';
	document.forms[0].submit();
}

/*
	ViewRecord function
	Purpose: Restore all field value of cataloguing form
	Creator: Oanhtn
	CreatedDate: 19/05/2004
*/
function ViewRecord(strStoreField, intRecordNumber, strMess1, strMess2) {
	var intMaxRecord;
	var intPosition;
	var thisField;
	var intIndex;
	var intCounter;
	var arrRecord = new Array();
	var strStoreValue = eval("document.forms[0].hid" + strStoreField + ".value");

	if (strStoreValue == "") {
		return;
	}

	intMaxRecord = eval("parseFloat(document.forms[0].nr" + strStoreField + "2.value)");
	if (intRecordNumber < 1) {
		alert(strMess1);
		return;
	}

	if (intRecordNumber > intMaxRecord) {
		alert(strMess2);
		return;
	}

	eval("document.forms[0].nr" + strStoreField + "1.value=" + intRecordNumber);
	intCounter = intRecordNumber - 1;
	intIndex = 0;
	while (strStoreValue.length > 0) {
		intPosition = strStoreValue.indexOf("$&");
		if (intPosition >= 0) {
			arrRecord[intIndex] = strStoreValue.substring(0, intPosition);
			strStoreValue = strStoreValue.substring(intPosition + 2, strStoreValue.length);
		} else {
			arrRecord[intIndex]= strStoreValue;
			strStoreValue = "";
		}
		intIndex++;
	}

	if (intCounter == intIndex) {
		intCounter--;
		eval("document.forms[0].nr" + strStoreField + "1.value=" + intIndex);
	}

	arrRecord[intCounter] = EscapeSingleQuote(arrRecord[intCounter]);
	eval("document.forms[0].txb" + strStoreField + ".value = '" + arrRecord[intCounter] + "'");
	eval("document.forms[0].txb" + strStoreField + ".focus()");
}

/*
	EscapeSingleQuote function
	Purpose: escape single quote
	Creator: Oanhtn
	CreatedDate: 19/05/2004
*/
function EscapeSingleQuote(strInput) {
    var strOutput = "";
    var intCounter;
	for (intCounter = 0; intCounter < strInput.length; intCounter++) {
	   if (strInput.charAt(intCounter) == "'") {
	        strOutput = strOutput + "\\'";
	   } else {
	        strOutput = strOutput + strInput.charAt(intCounter);
	   }
	}
	return strOutput;
}


/*
	AddNewRecord function
	Purpose: Add new value for repeatable field
	Creator: Oanhtn
	CreatedDate: 21/05/2004
*/
function AddNewRecord(strFieldCode, objControl1, objControl2) {
	var intNOR;
	var intIndex;
	eval("document.forms[0].txb" + strFieldCode + ".value = ''");
	var intNOR = CountRecord(strFieldCode);
	var intIndex = parseFloat(eval(objControl2 + ".value"));
	if (intIndex == intNOR) {
		intIndex++;
	}
	eval(objControl1 + ".value = " + intIndex);
	eval(objControl2 + ".value = " + intIndex);
	eval("document.forms[0].txb" + strFieldCode + ".focus()");
}

/*
	CountRecord function
	Purpose: Count number of value for repeatable field
	Creator: Oanhtn
	CreatedDate: 21/05/2004
*/
function CountRecord(strFieldCode) {
	var intPosition;
	var intCounter = 0;
	var strFieldValue = eval("document.forms[0].hid" + strFieldCode + ".value");
	
	while (strFieldValue.length > 0) {
		intPosition = strFieldValue.indexOf("$&");
		if (intPosition >= 0) {
			strFieldValue = strFieldValue.substring(intPosition + 2, strFieldValue.length);
		} else {
			strFieldValue = "";
		}
		intCounter++;
	}
	return intCounter;
}

/*
	DeleteRecord function
	Purpose: delete current value for repeatable field
	Creator: Oanhtn
	CreatedDate: 21/05/2004
*/
function DeleteRecord(strFieldCode, recno) {
	var intPosition;
	var intNOR;
	var intCounter;
	var records = new Array();
	var currentRecord;

	var strFieldValue = eval("document.forms[0].hid" + strFieldCode + ".value");
	if (strFieldValue == "") {
		return;
	}
	
	intNOR = 0;
	intCounter = 0;
	
	while (strFieldValue.length > 0) {
		intPosition = strFieldValue.indexOf("$&");
		if (intPosition >= 0) {
			records[intCounter] = strFieldValue.substring(0, intPosition);
			strFieldValue = strFieldValue.substring(intPosition + 2, strFieldValue.length);
		} else {
			records[intCounter]= strFieldValue;
			strFieldValue = "";
		}
		intCounter++;
	}
	
	intNOR = intCounter;
	if (intNOR==0) {return;}
	currentRecord = recno - 1;
	records[currentRecord] = "";

	for (intCounter = 0; intCounter <= intNOR; intCounter++) {
		if (records[intCounter]) {
			strFieldValue = strFieldValue + records[intCounter] + "$&";
		}
	}

	strFieldValue = EscapeSingleQuote(strFieldValue);
	eval("document.forms[0].hid" + strFieldCode + ".value='" + strFieldValue + "'");

	intNOR--;
	eval("document.forms[0].nr" + strFieldCode + "2.value=" + intNOR);
	if (intNOR > 0) {
		ViewRecord(strFieldCode, 1, '', '');
	} else {
		eval("document.forms[0].nr" + strFieldCode + "1.value=" + intNOR);
		eval ("document.forms[0].txb" + strFieldCode + ".value = ''");
	}
}


/*
	UpdateRecord function
	Purpose: UpdateRecord (repeatable fields)
	Creator: Oanhtn
	CreatedDate: 19/05/2004
	Input: - strFieldCode: string of fielcode
*/
function UpdateRecord(strFieldCode) {
	if (strFieldCode == "") {
		return;
	}
	var intCounter;
	var intCounter1 = 0;
	var intPosition;
	var arrFieldValues = new Array();
	var strStoreValue;
	
	// u(strFieldCode);

	strStoreValue = eval("document.forms[0].hid" + strFieldCode + ".value");

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

	var currentRecord = eval("parseFloat(document.forms[0].nr" + strFieldCode + "1.value)");
	if (currentRecord == 0) {
		eval("document.forms[0].nr" + strFieldCode + "1.value = 1");
		eval("document.forms[0].nr" + strFieldCode + "2.value = 1");
	} else {
		currentRecord--;
		if (currentRecord > intCounter1) {
			intCounter1 = currentRecord;
		}
	}
	arrFieldValues[currentRecord] = eval("document.forms[0].txb" + strFieldCode + ".value");

	strStoreValue = "";
	for (intCounter = 0; intCounter <= intCounter1; intCounter++) {
		if (arrFieldValues[intCounter]) {
			strStoreValue = strStoreValue + arrFieldValues[intCounter] + "$&";
		}
	}
	strStoreValue = EscapeSingleQuote(strStoreValue);
	eval("document.forms[0].hid" + strFieldCode + ".value = '" + strStoreValue + "'");
}

/*
	microsoftKeyPress
	Purpose: create some 
*/
function microsoftKeyPress() {
	var strCurrentValue;
	var strPrefix = '';
	
	if (window.event.keyCode == 13) {
		strCurrentValue = eval("document.forms[0].txb" + TagArr[curtab] + ".value");
		if (strCurrentValue != "") {
			if (eval("document.forms[0].nr" + TagArr[curtab] + "1")) {
				eval("document.forms[0].txb" + TagArr[curtab] + ".blur()");
				eval("document.forms[0].btn" + TagArr[curtab] + "5.click()");
			} else {
				curtab = curtab + 1;
				if (curtab < TagArr.length) {
					eval("document.forms[0].txb" + TagArr[curtab] + ".focus()");
				} else {
					eval("document.forms[0].txb" + TagArr[curtab - 1] + ".blur()");
					document.forms[0].btnUpdate.focus();
				}
			}
		} else {
			curtab = curtab + 1;
			if (curtab < TagArr.length) {
				eval("document.forms[0].txb" + TagArr[curtab] + ".focus()");
			} else {
				eval("document.forms[0].txb" + TagArr[curtab - 1] + ".blur()");
				document.forms[0].btnUpdate.focus();
			}
		}
		window.event.keyCode = 27;
		//return false;
	}
 }

/*
	ChangeTab function
*/
function ChangeTab(tag) {
	var intCounter;
	for (intCounter = 0; intCounter < TagArr.length; intCounter++) {
		if (TagArr[intCounter] == tag) {
			curtab = intCounter;
			break;
		}
	}
}

/*
	LoadRecNo function
	Purpose: Load record number
*/
function LoadRecNo(strFieldCode) {
	var intCount;
	intCount = CountRecord(strFieldCode);
	eval("document.forms[0].nr" + strFieldCode + "1.value=" + intCount);
	eval("document.forms[0].nr" + strFieldCode + "2.value=" + intCount);
}
