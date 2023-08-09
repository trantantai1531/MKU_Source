/*
	AddSubField function
	Purpose: Add index, value of the selected objcheckbox in to 2 hidden fields
*/
function AddSubField(objCheckBox) {	
	var intIndex1;
	var strFieldID;
	var strPickedFieldCodes;
	strPickedFieldCodes = top.main.Sentform.document.forms[0].txtPickedFields.value;	
	intIndex1 = strPickedFieldCodes.indexOf("," + eval(objCheckBox).value + ",");
	if (intIndex1 < 0) {
		top.main.Sentform.document.forms[0].txtPickedFields.value = top.main.Sentform.document.forms[0].txtPickedFields.value + eval(objCheckBox).value + ",";
	} else {
		objCheckBox.checked = false;
	}	
}

/*
	RemoveSubField function
	Purpose: Remove the selected item 
*/
function RemoveSubField(objCheckBox) {
	var intIndex1;
	var strFieldCode;
	var strPickedFieldCodes;
	var strCurrentManTags;
	var strTrailer;
	var strHeader;
	strFieldCode = eval(objCheckBox).value;
	strPickedFieldCodes = top.main.Sentform.document.forms[0].txtPickedFields.value;
	intIndex1 = strPickedFieldCodes.indexOf("," + strFieldCode + ",");
	if (intIndex1 >=0) {
		strHeader = strPickedFieldCodes.substring(0, intIndex1);
		strTrailer = strPickedFieldCodes.substring(intIndex1 + strFieldCode.length + 1, strPickedFieldCodes.length);
		top.main.Sentform.document.forms[0].txtPickedFields.value = strHeader + strTrailer;
	}
	strCurrentManTags = top.main.Sentform.document.forms[0].txtMandatoryFields.value;
	intIndex1 = strCurrentManTags.indexOf("," + strFieldCode + ",");
	if (intIndex1 >=0) {
		strHeader = strCurrentManTags.substring(0, intIndex1);
		strTrailer = strCurrentManTags.substring(intIndex1 + strFieldCode.length + 1, strCurrentManTags.length);
		top.main.Sentform.document.forms[0].txtMandatoryFields.value = strHeader + strTrailer;
	}
}

/*
	LoadCheckedBox function
	Purpose: Load status of all checkbox in display form
*/
function LoadCheckedBox() {
	var intCount;
	var intTotal;
	var strFieldCode;
    intTotal = document.forms[0].chkMarcSubField.length;
	if (intTotal > 0) {
	    for (intCount = 0; intCount < intTotal; intCount++) {
			strFieldCode = document.forms[0].chkMarcSubField[intCount].value;
		    if (top.main.Sentform.document.forms[0].txtPickedFields.value.indexOf("," + strFieldCode + ",") >= 0) {
			    document.forms[0].chkMarcSubField[intCount].checked = true;
			}
		}
    } else {
		strFieldCode = document.forms[0].chkMarcSubField.value;
		if (top.main.Sentform.document.forms[0].txtPickedFields.value.indexOf("," + strFieldCode + ",") >= 0) {
			document.forms[0].chkMarcSubField.checked = true;
		}
	}
}

