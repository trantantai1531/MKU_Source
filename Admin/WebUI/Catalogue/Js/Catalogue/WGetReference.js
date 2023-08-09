/*
	LoadBackData function
	Purpose: 
	CreatedDate: 23/05/2004
	Creator: Oanhtn	
*/
function LoadBackData() {
    var strValue;
    if ((parseFloat(document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].value) >= 0) && (strFieldCode != '082$a')) {
		strValue = document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].text;
	} else {
		strValue = document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].value;
	}
	eval("opener.top.main." + strDestField + ".value = '" + strHeader + strSubFieldCode + strValue + "';")

	if (opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strParentFieldCode) < 0) {
		opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strParentFieldCode + ",";
	}

	if (intRepeatable != 1) {
	    if (strStoreField != "") {
	        if (strFieldCode == '915$a')
	        {
	            eval("opener.top.main." + strStoreField + ".value = '" + "  ::" + strHeader + strSubFieldCode + strValue + "';")
	        }
	        else
	        {
	            eval("opener.top.main." + strStoreField + ".value = '" + strHeader + strSubFieldCode + strValue + "';")
	        }
		}
	} else {
	    //UpdateRecord(strParentFieldCode, 1); 2016.05.11 top.main.Sentform --> opener.top.main.Sentform
	    if (opener.top.main.Sentform.document.forms[0].txtFieldCodes.value.indexOf(strParentFieldCode) < 0) {
	        opener.top.main.Sentform.document.forms[0].txtFieldCodes.value = opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strParentFieldCode + ",";
	    }
	}
	UpdateLeader("opener.top.main.Sentform.document.forms[0].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txtLeader", "opener.top.main.Workform.document.forms[0].txtLeader");
	
	eval("opener.top.main." + strDestField + ".focus();")	
	self.close();
	return false;
}

function LoadBackData915() {
	var strValue;	
	if (!document.forms[0].lstEntries.options.length) {
		return false;
	}

	strValue = "$a" + document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].text;
	strValue=strValue + "$b" + document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].value;
	var strCurValue=opener.top.main.Workform.document.forms[0].tag915.value;
	var pos;
	strCurValue=strCurValue.replace("$a","");
	strCurValue=strCurValue.replace("$b","");
	pos=strCurValue.indexOf("$");
	strCurValue=strCurValue.substring(pos);
	opener.top.main.Workform.document.forms[0].tag915.value =strValue+strCurValue;
	opener.top.main.Sentform.document.forms[0].tag915.value ="  ::"+strValue+strCurValue;
/*
	if (opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strParentFieldCode) < 0) {
		opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = opener.top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strParentFieldCode + ",";
	}

	if (intRepeatable != 1) {
		if (strStoreField != "") {
			eval("opener.top.main." + strStoreField + ".value = '" + strHeader + strSubFieldCode + strValue + "';")
		}
	} else {
		UpdateRecord(strParentFieldCode, 1);
	}
	*/
	UpdateLeader("opener.top.main.Sentform.document.forms[0].txtFieldCodes", "opener.top.main.Sentform.document.forms[0].tag", "opener.top.main.Sentform.document.forms[0].txtLeader", "opener.top.main.Workform.document.forms[0].txtLeader");	
	eval("opener.top.main.Workform.document.forms[0].tag915.focus();")	
	self.close();
	return false;
}
/*
	Close function
	Purpose: return focus to opener window & close this window
	CreatedDate: 23/05/2004
	Creator: Oanhtn
*/
function Close() {
	eval("opener.top.main." + strDestField + ".focus();")
	self.close();
	return false;
}
