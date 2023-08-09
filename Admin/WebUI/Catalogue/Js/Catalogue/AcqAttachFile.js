/*
	CheckFileExt function
	Purpose: check the extension of attach files
*/
function CheckFileExt() {
	var strFileExt;
	var intPos;
	var strAllowedFile = ';' + document.forms[0].hidAllowedFiles.value + ';';
	var strDenniedFile = ';' + document.forms[0].hidDenniedFiles.value + ';';
	strAllowedFile = strAllowedFile.replace(" ", "");
	strDenniedFile = strDenniedFile.replace(" ", "");
	strAllowedFile = strAllowedFile.toLowerCase();
	strDenniedFile = strDenniedFile.toLowerCase();
	strFileExt = document.forms[0].filAttach.value;		
	intPos = strFileExt.lastIndexOf(".");
	strFileExt = ';' + strFileExt.substring(intPos + 1, strFileExt.length) + ';';	
	if (strAllowedFile.indexOf(strFileExt) < 0) {
	return false;
	} else if (strDenniedFile.indexOf(strFileExt) >= 0) {		
	return false;
	}
	return true;
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

	strStoreValue = eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value");
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
    //Kiem tra la truong MARC (LAP)
    //2016.05.05 B1
    if (eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "1")) {
        var currentRecord = eval("parseFloat(top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value)");

        if (currentRecord == 0) {
            eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value = 1");
            //eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "2.value = 1");
        } else {
            currentRecord--;
            if (currentRecord > intCounter1) {
                intCounter1 = currentRecord;
            }
        }
        eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "2.value = " + intCounter1.toString());
    }
    //2016.05.05 E1
	
	if (eval("top.main.Workform.document.forms[0].ind" + strFieldCode)) {
		arrFieldValues[currentRecord] = eval("top.main.Workform.document.forms[0].ind" + strFieldCode + ".value") + "::" + eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value"); 
	} else {
		arrFieldValues[currentRecord] = eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value"); 
	}

	strStoreValue = "";
	for (intCounter = 0; intCounter <= intCounter1; intCounter++) {
		if (arrFieldValues[intCounter]) {
			strStoreValue = strStoreValue + arrFieldValues[intCounter] + "$&";
		}
	}	
	strStoreValue = EscapeSingleQuote(strStoreValue);
	eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + strStoreValue + "'");
	if (strFieldCode == '907') {
	    var val907 = eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value");
	    eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + val907 + "'");
	}
	UpdateLeader("top.main.Sentform.document.forms[0].txtFieldCodes", "top.main.Sentform.document.forms[0].tag", "top.main.Sentform.document.forms[0].txtLeader", "top.main.Workform.document.forms[0].txtLeader");
}