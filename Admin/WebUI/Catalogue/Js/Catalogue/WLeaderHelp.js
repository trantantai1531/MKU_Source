/*
	Restore function
	Purpose: restore field's strValue
*/
function Restore(strFieldValue, strFieldName, intType, intMax){
	var intCounter;
	var strValue;
	if (intType == 1) {// Textbox
		eval("document.forms[0]." +  strFieldName + ".value = strFieldValue.substring(0," + intMax + ")");
	} else { // DropdownList
		strValue = eval("strFieldValue.substring(0," + intMax + ")");
		for (intCounter = 0; intCounter < eval("document.forms[0]." + strFieldName + ".options.length"); intCounter++) {
			if (eval("document.forms[0]." + strFieldName + ".options[intCounter].value ==  '" + strValue + "'")) {
				eval("document.forms[0]." + strFieldName + ".options.selectedIndex = " + intCounter);
				break;
			}
		}
	}
	strFieldValue = strFieldValue.substring(intMax, strFieldValue.length);
	return strFieldValue;
}

/*
	CreateLeader function
	Purpose: Create value for leader field
*/
function CreateLeader(intIsUpdate) {
	var strLeader = "";
	var intCounter;
	var strFieldValue;
	for (intCounter = 1; intCounter <= 16; intCounter++) {
		if ((intCounter == 2) || (intCounter == 3 || (intCounter == 4) || (intCounter == 5) || (intCounter == 6) || (intCounter == 10) || (intCounter == 11) || (intCounter == 12))) {
			strFieldValue = eval("document.forms[0].ddlField" + intCounter + ".value");
			if (strFieldValue == null) {
				strFieldValue = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
			}			
		} else {
			strFieldValue = eval("document.forms[0].txtField" + intCounter + ".value");
			if (strFieldValue == null) {
				strFieldValue = eval("document.forms[0].txtField" + intCounter + ".options[document.forms[0].txtField" + intCounter + ".selectedIndex].value");
			}		
		}
		strLeader = strLeader + strFieldValue;
	}	
	
	if (intIsUpdate != 1) {
		if (document.forms[0].hid.value=1)
		{
			opener.document.forms[0].txtLeader.value = strLeader;	
			opener.top.main.Sentform.document.forms[0].txtLeader.value = strLeader;
		}
		else
		{
			opener.top.main.Workform.document.forms[0].txtLeader.value = strLeader;
			opener.top.main.Sentform.document.forms[0].txtLeader.value = strLeader;
		}
		
	} else {
		opener.top.main.Sentform.document.forms[0].txtLeader.value = strLeader;
		UpdateLeader("opener.top.main.Sentform.document.forms[1].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txtLeader", "opener.top.main.Workform.document.forms[0].txtLeader");		
	}
	return true;
}

/*
	ResValue function
	Restore value of the Leader field
*/
function ResValue() {
	var strLeaderValue;
	strLeaderValue = opener.top.main.Workform.document.forms[0].txtLeader.value;
	if (strLeaderValue != '') {
		strLeaderValue = Replace(strLeaderValue, " ", "#");
		strLeaderValue = Restore(strLeaderValue, 'Field1', 1, 5);
		strLeaderValue = Restore(strLeaderValue, 'Field2', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field3', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field4', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field5', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field6', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field7', 1, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field8', 1, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field9', 1, 5);
		strLeaderValue = Restore(strLeaderValue, 'Field10', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field11', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field12', 0, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field13', 1, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field14', 1, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field15', 1, 1);
		strLeaderValue = Restore(strLeaderValue, 'Field16', 1, 1);
	}
}


	
/*
	PreView function
	Purpose: allow user preview leadervalue
*/
function PreView() {
	var intCounter;
	var strLeader = "";
	var strInputValue;	
	for(intCounter=1; intCounter<=16; intCounter++) {
/*	
		if ((intCounter == 2) || (intCounter == 3 || (intCounter == 4) || (intCounter == 5) || (intCounter == 6) || (intCounter == 10) || (intCounter == 11) || (intCounter == 12))) {
			strInputValue = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
		} else {
			strInputValue = eval("document.forms[0].txtField" + intCounter + ".value");		
		}
*/
		if ((intCounter == 2) || (intCounter == 3 || (intCounter == 4) || (intCounter == 5) || (intCounter == 6) || (intCounter == 10) || (intCounter == 11) || (intCounter == 12))) {
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

function PreViewPrint() {
		alert('Hello');
	}
	
function PreViewPrintAuthority() {
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

function CreateLeaderAuthority(intIsUpdate) {
	var strLeader = "";
	var intCounter;
	var strFieldValue;
	for (intCounter = 1; intCounter <= 14; intCounter++) {
		if ((intCounter == 2) || (intCounter == 3) || (intCounter == 5) || (intCounter == 9)) {
			strFieldValue = eval("document.forms[0].ddlField" + intCounter + ".value");
			if (strFieldValue == null) {
				strFieldValue = eval("document.forms[0].ddlField" + intCounter + ".options[document.forms[0].ddlField" + intCounter + ".selectedIndex].value");
			}			
		} else {
			strFieldValue = eval("document.forms[0].txtField" + intCounter + ".value");
			if (strFieldValue == null) {
				strFieldValue = eval("document.forms[0].txtField" + intCounter + ".options[document.forms[0].txtField" + intCounter + ".selectedIndex].value");
			}		
		}
		strLeader = strLeader + strFieldValue;
	}
	strLeader = strLeader.replace("#", " ");
	strLeader = strLeader.replace("#", " ");
	strLeader = strLeader.replace("#", " ");
	strLeader = strLeader.replace("#", " ");
	strLeader = strLeader.replace("#", " ");
	if (intIsUpdate != 1) {
		opener.top.main.Workform.document.forms[0].txtLeader.value = strLeader;
		opener.top.main.Sentform.document.forms[0].txtLeader.value = strLeader;
	} else {
		opener.top.main.Sentform.document.forms[0].txtLeader.value = strLeader;
		UpdateLeader("opener.top.main.Sentform.document.forms[1].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txtLeader", "opener.top.main.Workform.document.forms[0].txtLeader");
	}
	return;
}








