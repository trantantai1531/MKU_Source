/*
	FillChar function
*/
function FillChar(strInput, chrAddedChar, intMax, intDirection) {
	if (intDirection == 0 ){
		while (strInput.length < intMax) {
			strInput = chrAddedChar + strInput;
		}
	} else {
		while (strInput.length < intMax) {
			strInput += chrAddedChar;
		}		
	}
	return strInput;
}

/*
	RunUpdate function
*/
function RunUpdate(intMax) {
	var intCounter = 0;
	var strSendVal = "";
	var strInputVal = "";
	var strParentFieldCode;
	var strFieldCode = strSendField.substring(strSendField.length - 3, strSendField.length);
	
	if (opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strFieldCode) < 0) {
		opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strFieldCode + ",";
	}
	
	for(intCounter=1; intCounter<=intMax; intCounter++) {
		if (strFieldIDs.indexOf("," + intCounter + ",") != -1) {
			strInputVal = eval("document.forms[0].txtField" + intCounter + ".value");
		} else {
			strInputVal = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
		}
		strSendVal = strSendVal + strInputVal;
	}
	strSendVal = Replace(strSendVal, "#", " ");
	eval("opener.top.main." + strSendField + ".value='" + strSendVal + "'");
	eval("opener.top.main." + strWorkField + ".value='" + strSendVal + "'");
	if (eval("opener.top.main." + strWorkField + ".value.indexOf(\"$\")") >= 0) {
		strParentFieldCode = strSendField.substring(0, strSendField.lastIndexOf("$"));
		if (eval("opener.top.main." + strParentFieldCode)) {
			UpdateRecord(strSendField, strSendVal);
		}
	}
	eval("opener.top.main." + strWorkField + ".focus()");
	UpdateLeader("opener.top.main.Sentform.document.forms[0].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txtLeader", "opener.top.main.Workform.document.forms[0].txtLeader");
	self.close();
}

/*
	PreView function
	Purpose: preview the value of field008
*/
function PreView(intMax) {
	var strSend = "";
	var strInputVal;
	var intCounter;
	for(intCounter=1; intCounter<=intMax; intCounter++) {
		if (strFieldIDs.indexOf("," + intCounter + ",") != -1) {
			strInputVal = eval("document.forms[0].txtField" + intCounter + ".value");
		} else {
			strInputVal = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
		}
		strSend = strSend + Replace(strInputVal, " ", "#");
	}
	strSend = Replace(strSend, " ", "#");
	alert(strSend);
}

/*
	Update function
*/
function Update(intMax){
	switch (intFileID) {
		case 26: 
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',4,0);
			document.forms[0].txtField9.value = FillChar(document.forms[0].txtField9.value,'#',4,0);
			document.forms[0].txtField17.value = FillChar(document.forms[0].txtField17.value,'#',3,0);
	}
	RunUpdate(intMax);
}

/*
	ResValue function
*/
function ResValue() {
	strValue = eval("opener.top.main." + strWorkField + ".value");
	switch (intFileID) {
		case 26:
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',1,6);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,4);
				strValue = Restore(strValue, 'Field4',1,4);
				strValue = Restore(strValue, 'Field5',1,3);
				strValue = Restore(strValue, 'Field6',1,4);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',1,4);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',0,1);
				strValue = Restore(strValue, 'Field13',0,1);
				strValue = Restore(strValue, 'Field14',1,1);
				strValue = Restore(strValue, 'Field15',0,1);
				strValue = Restore(strValue, 'Field16',0,1);
				strValue = Restore(strValue, 'Field17',1,3);
				strValue = Restore(strValue, 'Field18',0,1);
				strValue = Restore(strValue, 'Field19',0,1);
			}		
	}
}

/*
	Restore function
	Purpose: restore value of the selected field
	Input: strInput, strFieldName, intType, intMax
	Output: string of the value after restored
*/
function Restore(strInput, strFieldName, intType, intMax){
	var intCounter = 0;
	var strValue = "";
	if (intType == 1) { // Textbox
		eval("document.forms[0].txt" +  strFieldName + ".value = strInput.substring(0," + intMax + ")");
	} else { // dropdownlist
		strValue = eval("strInput.substring(0," + intMax + ")");
		for (intCounter = 0; intCounter < eval("document.forms[0].ddl" + strFieldName + ".options.length"); intCounter++) {
			if (eval("document.forms[0].ddl" + strFieldName + ".options[intCounter].value ==  '" + strValue + "'")) {
				eval("document.forms[0].ddl" + strFieldName + ".options.selectedIndex = " + intCounter);
				break;
			}
		}
	}
	strInput = strInput.substring(intMax, strInput.length);
	return strInput;
}

/*
	Replace function
*/
function Replace(strInput, strFindChar, strReplaceChar) {
	var strOffset;
	var strFirst;
	var strLast;
	while (strInput.indexOf(strFindChar) !=-1){
		strOffset = strInput.indexOf(strFindChar);
		strFirst = strInput.substring(0, strOffset);
		strFirst += strReplaceChar;
		strLast = strInput.substring(strOffset + strFindChar.length, strInput.length);
		strInput = strFirst + strLast;
	}
	return strInput;
}

// function LoadtextData: Load the data from the drop down list to the text boxes
function LoadTextData(objddl,objtxt)
{
var strValueFrom, strValueTo;
	strValueFrom = "document.forms[0]." + objddl + "[document.forms[0]." + objddl + ".selectedIndex]";
	strValueTo = "document.forms[0]." + objtxt; 
	eval(strValueTo).value = eval(strValueFrom).value;
}

function PreViewPrintAlert() {
	var intCounter;
	var strLeader = "";
	var strInputValue;	
	for(intCounter=1; intCounter<=14; intCounter++) {
	
		if ((intCounter == 2) || (intCounter == 3) || (intCounter == 5) || (intCounter == 9)) {
			strInputValue = eval("document.forms[0].ddlField" + intCounter + ".value");
			if (strInputValue == null) {
				strInputValue = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
			}			
		} else {
			strInputValue = eval("document.forms[0].txtField" + intCounter + ".value");
			if (strInputValue == null) {
				strInputValue = eval("document.forms[0].txtField" + intCounter + ".options[document.forms[0].txtField" + intCounter + ".selectedIndex].value");
			}		
		}		
		strLeader += strInputValue;
	}
	strLeader = strLeader.replace(" ", "#");
	alert(strLeader);
}
