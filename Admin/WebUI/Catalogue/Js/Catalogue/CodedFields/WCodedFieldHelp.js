
/*
 Help print information of Field 008
*/
function PreViewPrintField008Authority() {
	var intCounter;
	var strField008Autrority = "";
	var strInputValue;	
	for(intCounter=1; intCounter<=23; intCounter++) {
	
		if ((intCounter == 1) || (intCounter == 14) || (intCounter == 17) || (intCounter == 21)) {
			strInputValue = eval("document.forms[0].txtField" + intCounter + ".value");
			if (strInputValue == null) {
				strInputValue = eval("document.forms[0].txtField" + intCounter + ".options[document.forms[0].txtField" + intCounter + ".selectedIndex].value");
			}	
		} else {
		   strInputValue = eval("document.forms[0].ddlField" + intCounter + ".value");
			if (strInputValue == null) {
				strInputValue = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
			}	
					
		}		
		strField008Autrority += strInputValue;
	}
	strField008Autrority = strField008Autrority.replace(" ", "#");
	alert(strField008Autrority);
}

/*
	RunUpdate function
*/
function RunUpdate008() {
	var intCounter = 0;
	var strSendVal = "";
	var strInputVal = "";
	var strParentFieldCode;
	var strFieldCode;
	strFieldCode = strSendField.substring(strSendField.length - 3, strSendField.length);
	if (opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strFieldCode) < 0) {
		opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strFieldCode + ",";
	}
	
	for(intCounter=1; intCounter<=23; intCounter++) {
		if ((intCounter == 1) || (intCounter == 14) || (intCounter == 17) || (intCounter == 21)) {
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




function ResValue008Authority() {
	var Str = eval("opener.top.main." + strWorkField + ".value");;
	
	if (Str != '') {
		Str = Replace(Str, " ", "#");
		Str = Restore(Str, 'Field1',1,6);
		Str = Restore(Str, 'Field2',0,1);
		Str = Restore(Str, 'Field3',0,1);
		Str = Restore(Str, 'Field4',0,1);
		Str = Restore(Str, 'Field5',0,1);
		Str = Restore(Str, 'Field6',0,1);
		Str = Restore(Str, 'Field7',0,1);
		Str = Restore(Str, 'Field8',0,1);
		Str = Restore(Str, 'Field9',0,1);
		Str = Restore(Str, 'Field10',0,1);
		Str = Restore(Str, 'Field11',0,1);
		Str = Restore(Str, 'Field12',0,1);
		Str = Restore(Str, 'Field13',0,1);
		Str = Restore(Str, 'Field15',0,1);
		Str = Restore(Str, 'Field16',0,1);
		Str = Restore(Str, 'Field18',0,1);
		Str = Restore(Str, 'Field19',0,1);
		Str = Restore(Str, 'Field20',0,1);
		Str = Restore(Str, 'Field22',0,1);
		Str = Restore(Str, 'Field23',0,1);
	}
}


/*
 Create information of Field 008
*/
function CreateField008Authority(intIsUpdate) {
	var strField008Autrority = "";
	var intCounter;
	var strFieldValue;
	for (intCounter = 1; intCounter <= 23; intCounter++) {
		if ((intCounter == 1) || (intCounter == 14) || (intCounter == 17) || (intCounter == 21)) {
		 strFieldValue = eval("document.forms[0].txtField" + intCounter + ".value");
			if (strFieldValue == null) {
				strFieldValue = eval("document.forms[0].txtField" + intCounter + ".options[document.forms[0].txtField" + intCounter + ".selectedIndex].value");
			}			
		} else {
		 strFieldValue = eval("document.forms[0].ddlField" + intCounter + ".value");
			if (strFieldValue == null) {
				strFieldValue = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
			}			
		}
		strField008Autrority = strField008Autrority + strFieldValue;
	}
		if (intIsUpdate != 1) {
		opener.top.main.Workform.document.forms[0].txt008.value = strField008Autrority;
		opener.top.main.Sentform.document.forms[0].txt008.value = strField008Autrority;
	} else {
		opener.top.main.Sentform.document.forms[0].txt008.value = strField008Autrority;
		UpdateLeader("opener.top.main.Sentform.document.forms[1].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txt008", "opener.top.main.Workform.document.forms[0].txt008");
	}
	return;
}

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
		//alert(strFieldIDs.indexOf("," + intCounter + ","));
		if (strFieldIDs.indexOf("," + intCounter + ",") != -1) {
			strInputVal = eval("document.forms[0].txtField" + intCounter + ".value");
		} else {
			strInputVal = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
		}
		//alert(intCounter + ' -> ' + strFieldIDs.indexOf("," + intCounter + ",") + ' -> ' + strInputVal);
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
		case 4 :  // 006 - Book
			document.forms[0].txtField2.value = FillChar(document.forms[0].txtField2.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',4,0);
			break;
		case 6 :  // 006 - Maps
			document.forms[0].txtField2.value = FillChar(document.forms[0].txtField2.value,'#',4,0);
			document.forms[0].txtField12.value = FillChar(document.forms[0].txtField12.value,'#',2,0);
			break;
		case 7 :  // 006 - Music
			document.forms[0].txtField7.value = FillChar(document.forms[0].txtField7.value,'#',6,0);
			document.forms[0].txtField8.value = FillChar(document.forms[0].txtField8.value,'#',2,0);
			break;
		case 8 :  // 006 - Music
			document.forms[0].txtField9.value = FillChar(document.forms[0].txtField9.value,'#',3,0);
			break;
		case 14:  // 007 - Tactile material
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',2,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',3,0);
			break;
		case 26:  // 008 - Books
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',4,0);
			document.forms[0].txtField9.value = FillChar(document.forms[0].txtField9.value,'#',4,0);
			document.forms[0].txtField17.value = FillChar(document.forms[0].txtField17.value,'#',3,0);
			break;
		case 2167:  // 008 - CONTINUING RESOURCES
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField13.value = FillChar(document.forms[0].txtField13.value,'#',3,0);
			document.forms[0].txtField16.value = FillChar(document.forms[0].txtField16.value,'#',3,0);
			document.forms[0].txtField19.value = FillChar(document.forms[0].txtField19.value,'#',3,0);
			break;
		case 27:  // 008 - Computer file
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',4,0);
			document.forms[0].txtField8.value = FillChar(document.forms[0].txtField8.value,'#',3,0);
			document.forms[0].txtField12.value = FillChar(document.forms[0].txtField12.value,'#',6,0);
			document.forms[0].txtField13.value = FillChar(document.forms[0].txtField13.value,'#',3,0);
			break;
		case 28:  // 008 - Maps
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',4,0);
			document.forms[0].txtField7.value = FillChar(document.forms[0].txtField7.value,'#',2,0);
			document.forms[0].txtField10.value = FillChar(document.forms[0].txtField10.value,'#',2,0);
			document.forms[0].txtField16.value = FillChar(document.forms[0].txtField16.value,'#',2,0);
			document.forms[0].txtField17.value = FillChar(document.forms[0].txtField17.value,'#',3,0);
			break;
		case 29:  // 008 - Music
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',2,0);
			document.forms[0].txtField11.value = FillChar(document.forms[0].txtField11.value,'#',6,0);
			document.forms[0].txtField12.value = FillChar(document.forms[0].txtField12.value,'#',2,0);
			document.forms[0].txtField13.value = FillChar(document.forms[0].txtField13.value,'#',3,0);
			document.forms[0].txtField14.value = FillChar(document.forms[0].txtField14.value,'#',3,0);
			break;
		case 30:  // 008 - Visual Materals
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',3,0);
			document.forms[0].txtField9.value = FillChar(document.forms[0].txtField9.value,'#',5,0);
			document.forms[0].txtField12.value = FillChar(document.forms[0].txtField12.value,'#',3,0);
			document.forms[0].txtField15.value = FillChar(document.forms[0].txtField15.value,'#',3,0);
			break;
		case 31:  // 008 - Mixed Materals
			document.forms[0].txtField1.value = FillChar(document.forms[0].txtField1.value,'#',6,0);
			document.forms[0].txtField3.value = FillChar(document.forms[0].txtField3.value,'#',4,0);
			document.forms[0].txtField4.value = FillChar(document.forms[0].txtField4.value,'#',4,0);
			document.forms[0].txtField5.value = FillChar(document.forms[0].txtField5.value,'#',3,0);
			document.forms[0].txtField6.value = FillChar(document.forms[0].txtField6.value,'#',5,0);
			document.forms[0].txtField8.value = FillChar(document.forms[0].txtField8.value,'#',11,0);
			document.forms[0].txtField9.value = FillChar(document.forms[0].txtField9.value,'#',3,0);
			break;
	}
	RunUpdate(intMax);
}


/*
	ResValue function
	
*/
function ResValue() {
	strValue = eval("opener.top.main." + strWorkField + ".value");
	switch (intFileID) {
		case 4:  // 006 - Book
			if (strValue != '') {
				str006 = strValue ;
			}
			else {
				str008 = eval("opener.top.main.Sentform.document.forms[0].tag008.value");
				str006 = 'a' + str008.substring(18,22) + str008.substring(22,23) + str008.substring(23,24) + str008.substring(24,28) ;
				str006 = str006 + str008.substring(28,29) + str008.substring(29,30) + str008.substring(30,31) + str008.substring(31,32) + ' ' + str008.substring(33,34) + str008.substring(34,35);
			}
			if (str006 != '') {
				str006 = Replace(str006, " ", "#");
				str006 = Restore(str006, 'Field1',0,1);
				str006 = Restore(str006, 'Field2',1,4);
				str006 = Restore(str006, 'Field3',0,1);
				str006 = Restore(str006, 'Field4',0,1);
				str006 = Restore(str006, 'Field5',1,4);
				str006 = Restore(str006, 'Field6',0,1);
				str006 = Restore(str006, 'Field7',0,1);
				str006 = Restore(str006, 'Field8',0,1);
				str006 = Restore(str006, 'Field9',0,1);
				str006 = Restore(str006, 'Field10',1,1);
				str006 = Restore(str006, 'Field11',0,1);
				str006 = Restore(str006, 'Field12',0,1);
			}
			break;
		case 5:  // 006 - COMPUTER FILES
			if (strValue != '') {
				str006 = strValue ;
			}
			else {
				str008 = eval("opener.top.main.Sentform.document.forms[0].tag008.value");
				str006 = 'm    ' + str008.substring(22,23) + '   ' + str008.substring(26,27) + ' ' + str008.substring(28,29) + '      ' ;
			}
			if (str006 != '') {
				str006 = Replace(str006, " ", "#");
				str006 = Restore(str006, 'Field1',0,1);
				str006 = Restore(str006, 'Field3',1,1);
				str006 = Restore(str006, 'Field5',1,1);
				str006 = Restore(str006, 'Field7',1,1);
			}
			break;
		case 6:  // 006 - Maps
			if (strValue != '') {
				str006 = strValue ;
			}
			else {
				str008 = eval("opener.top.main.Sentform.document.forms[0].tag008.value");
				str006 = 'e' + str008.substring(18,22) + str008.substring(22,24) + ' ' + str008.substring(25,26) + '  ' + str008.substring(28,29) + str008.substring(29,30);
				str006 = str006 + ' ' + str008.substring(31,32) + ' ' + str008.substring(33,35) ;
			}
			if (str006 != '') {
				str006 = Replace(str006, " ", "#");
				str006 = Restore(str006, 'Field1',0,1);
				str006 = Restore(str006, 'Field2',1,4);
				str006 = Restore(str006, 'Field3',0,2);
				str006 = Restore(str006, 'Field4',1,1);
				str006 = Restore(str006, 'Field5',0,1);
				str006 = Restore(str006, 'Field6',1,2);
				str006 = Restore(str006, 'Field7',0,1);
				str006 = Restore(str006, 'Field8',0,1);
				str006 = Restore(str006, 'Field9',1,1);
				str006 = Restore(str006, 'Field10',0,1);
				str006 = Restore(str006, 'Field11',1,1);
				str006 = Restore(str006, 'Field12',1,2);
			}
			break;
		case 7:  // 006 - MUSIC
			if (strValue != '') {
				str006 = strValue ;
			}
			else {
				str008 = eval("opener.top.main.Sentform.document.forms[0].tag008.value");
				str006 = 'c' + str008.substring(18,20) + str008.substring(20,21) + str008.substring(21,22) + str008.substring(22,23) + str008.substring(23,24);
				str006 = str006 + str008.substring(24,30) + str008.substring(30,32) + ' ' + str008.substring(33,34) + ' ' ;
			}
			if (str006 != '') {
				str006 = Replace(str006, " ", "#");
				str006 = Restore(str006, 'Field1',0,1);
				str006 = Restore(str006, 'Field2',0,2);
				str006 = Restore(str006, 'Field3',0,1);
				str006 = Restore(str006, 'Field5',0,1);
				str006 = Restore(str006, 'Field6',0,1);
				str006 = Restore(str006, 'Field7',1,6);
				str006 = Restore(str006, 'Field8',1,2);
			}
			break;
		case 8:  // 006 - CONTINUING RESOURCES
			if (strValue != '') {
				str006 = strValue ;
			}
			else {
				str008 = eval("opener.top.main.Sentform.document.forms[0].tag008.value");
				str006 = 's' + str008.substring(18,19) + str008.substring(19,20) + ' ' + str008.substring(21,22) + str008.substring(22,23) + str008.substring(23,24) + str008.substring(24,25);
				str006 = str006 + str008.substring(25,28) + str008.substring(28,29) + str008.substring(29,30) + '   ' + str008.substring(33,34) + str008.substring(34,35);
			}
			if (str006 != '') {
				str006 = Replace(str006, " ", "#");
				str006 = Restore(str006, 'Field1',0,1);
				str006 = Restore(str006, 'Field2',1,1);
				str006 = Restore(str006, 'Field3',1,1);
				str006 = Restore(str006, 'Field4',1,1);
				str006 = Restore(str006, 'Field5',1,1);
				str006 = Restore(str006, 'Field6',1,1);
				str006 = Restore(str006, 'Field7',1,1);
				str006 = Restore(str006, 'Field8',1,1);
				str006 = Restore(str006, 'Field9',1,3);
				str006 = Restore(str006, 'Field10',1,1);
				str006 = Restore(str006, 'Field11',1,1);
				str006 = Restore(str006, 'Field12',1,3);
				str006 = Restore(str006, 'Field13',1,1);
				str006 = Restore(str006, 'Field14',1,1);
			}
			break;
		case 9:  // 006 - VISUAL MATERIALS
			if (strValue != '') {
				str006 = strValue ;
			}
			else {
				str008 = eval("opener.top.main.Sentform.document.forms[0].tag008.value");
				str006 = 'o' + str008.substring(18,21) + ' ' + str008.substring(22,23) + '     ' + str008.substring(28,29) + str008.substring(29,30) + '   ' ;
				str006 = str006 + str008.substring(33,34) + str008.substring(34,35) ;
			}
			if (str006 != '') {
				str006 = Replace(str006, " ", "#");
				str006 = Restore(str006, 'Field1',0,1);
				str006 = Restore(str006, 'Field2',1,3);
				str006 = Restore(str006, 'Field3',1,1);
				str006 = Restore(str006, 'Field4',0,1);
				str006 = Restore(str006, 'Field5',1,5);
				str006 = Restore(str006, 'Field6',0,1);
				str006 = Restore(str006, 'Field7',0,1);
				str006 = Restore(str006, 'Field8',1,3);
				str006 = Restore(str006, 'Field9',0,1);
				str006 = Restore(str006, 'Field10',0,1);
			}
			break;
		case 10:  // 006 - MIXED MATERIALS
			if (strValue != '') {
				str006 = strValue ;
			}
			else {
				str008 = eval("opener.top.main.Sentform.document.forms[0].tag008.value");
				str006 = 'p' + '     ' + str008.substring(23,24) + '           ';
			}
			if (str006 != '') {
				str006 = Replace(str006, " ", "#");
				str006 = Restore(str006, 'Field1',0,1);
				str006 = Restore(str006, 'Field3',0,1);
			}
			break;
		case 11: // 007-Maps
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,1);
				strValue = Restore(strValue, 'Field4',0,1);
				strValue = Restore(strValue, 'Field5',0,1);
				strValue = Restore(strValue, 'Field6',0,1);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',0,1);
			}
			break;
		case 12: // 007-Electronic resource
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,1);
				strValue = Restore(strValue, 'Field4',0,1);
				strValue = Restore(strValue, 'Field5',0,1);
				strValue = Restore(strValue, 'Field6',0,1);
				strValue = Restore(strValue, 'Field7',1,3);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',0,1);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',0,1);
			}
			break;
		case 14: // 007-Tactile material
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,1);
				strValue = Restore(strValue, 'Field4',1,2);
				strValue = Restore(strValue, 'Field5',0,1);
				strValue = Restore(strValue, 'Field6',1,3);
				strValue = Restore(strValue, 'Field7',0,1);
			}
			break;
		case 17: // 007-Maps
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,1);
				strValue = Restore(strValue, 'Field4',0,1);
				strValue = Restore(strValue, 'Field5',0,1);
				strValue = Restore(strValue, 'Field6',0,1);
			}
			break;
		case 18: // 007-Motion picture
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,1);
				strValue = Restore(strValue, 'Field4',0,1);
				strValue = Restore(strValue, 'Field5',0,1);
				strValue = Restore(strValue, 'Field6',0,1);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',0,1);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',0,1);
				strValue = Restore(strValue, 'Field13',0,1);
				strValue = Restore(strValue, 'Field14',0,1);
				strValue = Restore(strValue, 'Field15',0,1);
				strValue = Restore(strValue, 'Field16',0,1);
				strValue = Restore(strValue, 'Field17',0,1);
				strValue = Restore(strValue, 'Field18',1,6);
			}
			break;
		case 19: // 007-Kit
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
			}
			break;
		case 21: // 007-Nonprojected graphic
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,1);
				strValue = Restore(strValue, 'Field4',0,1);
				strValue = Restore(strValue, 'Field5',0,1);
				strValue = Restore(strValue, 'Field6',0,1);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',0,1);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',0,1);
				strValue = Restore(strValue, 'Field13',0,1);
				strValue = Restore(strValue, 'Field14',0,1);
			}
			break;
		case 22: // 007-Text
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',0,1);
				strValue = Restore(strValue, 'Field2',0,1);
			}
			break;
		case 26: // 008 - Books
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
			break;
		case 2167: // 008 - Continuing resources
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',1,6);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,4);
				strValue = Restore(strValue, 'Field4',1,4);
				strValue = Restore(strValue, 'Field5',1,3);
				strValue = Restore(strValue, 'Field6',0,1);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',0,1);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',0,1);
				strValue = Restore(strValue, 'Field13',1,3);
				strValue = Restore(strValue, 'Field14',0,1);
				strValue = Restore(strValue, 'Field15',0,1);
				strValue = Restore(strValue, 'Field17',0,1);
				strValue = Restore(strValue, 'Field18',0,1);
				strValue = Restore(strValue, 'Field19',0,1);
				strValue = Restore(strValue, 'Field20',1,3);
				strValue = Restore(strValue, 'Field21',0,1);
			}
			break;
		case 27: // 008 - Computer file 
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',1,6);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,4);
				strValue = Restore(strValue, 'Field4',1,4);
				strValue = Restore(strValue, 'Field5',1,3);
				strValue = Restore(strValue, 'Field6',1,4);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',1,3);
				strValue = Restore(strValue, 'Field9',0,1);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',1,6);
				strValue = Restore(strValue, 'Field13',1,3);
				strValue = Restore(strValue, 'Field14',0,1);
				strValue = Restore(strValue, 'Field15',0,1);
			}
			break;
		case 28: // 008 - Maps
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',1,6);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,4);
				strValue = Restore(strValue, 'Field4',1,4);
				strValue = Restore(strValue, 'Field5',1,3);
				strValue = Restore(strValue, 'Field6',1,4);
				strValue = Restore(strValue, 'Field7',1,2);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',0,1);
				strValue = Restore(strValue, 'Field10',1,2);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',0,1);
				strValue = Restore(strValue, 'Field13',0,1);
				strValue = Restore(strValue, 'Field14',0,1);
				strValue = Restore(strValue, 'Field15',0,1);
				strValue = Restore(strValue, 'Field16',1,2);
				strValue = Restore(strValue, 'Field17',1,3);
				strValue = Restore(strValue, 'Field18',0,1);
				strValue = Restore(strValue, 'Field19',0,1);
			}
			break;
		case 29: // 008 - Music
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',1,6);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,4);
				strValue = Restore(strValue, 'Field4',1,4);
				strValue = Restore(strValue, 'Field5',1,3);
				strValue = Restore(strValue, 'Field6',1,2);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',0,1);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',1,6);
				strValue = Restore(strValue, 'Field12',1,2);
				strValue = Restore(strValue, 'Field13',1,3);
				strValue = Restore(strValue, 'Field14',1,3);
				strValue = Restore(strValue, 'Field15',0,1);
				strValue = Restore(strValue, 'Field16',0,1);
			}
			break;	
		case 30: // 008 - Visual Materals
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',1,6);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,4);
				strValue = Restore(strValue, 'Field4',1,4);
				strValue = Restore(strValue, 'Field5',1,3);
				strValue = Restore(strValue, 'Field6',1,3);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field8',0,1);
				strValue = Restore(strValue, 'Field9',1,5);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
				strValue = Restore(strValue, 'Field12',1,3);
				strValue = Restore(strValue, 'Field13',0,1);
				strValue = Restore(strValue, 'Field14',0,1);
				strValue = Restore(strValue, 'Field15',1,3);
				strValue = Restore(strValue, 'Field16',0,1);
				strValue = Restore(strValue, 'Field17',0,1);
			}
			break;		
	case 31: // 008 - Mixed Materals
			if (strValue != '') {
				strValue = Replace(strValue, " ", "#");
				strValue = Restore(strValue, 'Field1',1,6);
				strValue = Restore(strValue, 'Field2',0,1);
				strValue = Restore(strValue, 'Field3',1,4);
				strValue = Restore(strValue, 'Field4',1,4);
				strValue = Restore(strValue, 'Field5',1,3);
				strValue = Restore(strValue, 'Field7',0,1);
				strValue = Restore(strValue, 'Field9',1,3);
				strValue = Restore(strValue, 'Field10',0,1);
				strValue = Restore(strValue, 'Field11',0,1);
			}
			break;		
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
function LoadTextData(objddl,objtxt){
	var strValueFrom, strValueTo;
	strValueFrom = "document.forms[0]." + objddl + "[document.forms[0]." + objddl + ".selectedIndex]";
	strValueTo = "document.forms[0]." + objtxt; 
	eval(strValueTo).value = eval(strValueFrom).value;
}