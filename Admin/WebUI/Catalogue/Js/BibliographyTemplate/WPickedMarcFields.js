/*
	RemovePickedFields function
	Purpose: Remove all selected fields
*/
function RemovePickedFields() {
	var intTotal;
	var intCount;
	var strPickedFieldIDs;
		
	intTotal = document.forms[0].chkMarcSubField.length;
	strPickedFieldIDs = "";
	if (intTotal > 0) {
		for (intCount = 0; intCount < intTotal; intCount++) {
			if (document.forms[0].chkMarcSubField[intCount].checked) {
				RemoveField(document.forms[0].chkMarcSubField[intCount].value);
			} else {
				strPickedFieldIDs = strPickedFieldIDs + document.forms[0].chkMarcSubField[intCount].value + ",";
			}
		}
	} else {
		if (document.forms[0].chkMarcSubField.checked) {
			RemoveField(document.forms[0].chkMarcSubField.value);
		} else {
			strPickedFieldIDs = strPickedFieldIDs + document.forms[0].chkMarcSubField.value + ",";
		}
	}
	self.location.href="WPickedMarcFields.aspx?FieldIDs=" + strPickedFieldIDs.substring(0, strPickedFieldIDs.length - 1);
}

/*
	RemoveField function
	Purpose: Remove the selected field
*/
function RemoveField(strField) {
	var strCurrentMandatoryFields;
	var strCurrentFields;
	var strHeader;
	var trailer;
	var intPosition;
	
	strCurrentFields = opener.top.Sentform.document.forms[0].txtPickedFields.value;
	intPosition = strCurrentFields.indexOf("," + strField + ",");
	if (intPosition >=0) {
		strHeader = strCurrentFields.substring(0, intPosition);
		strTrailer = strCurrentFields.substring(intPosition + strField.length + 1, strCurrentFields.length);
		opener.top.Sentform.document.forms[0].txtPickedFields.value = strHeader + strTrailer;
	}
	strCurrentMandatoryFields = opener.top.Sentform.document.forms[0].txtMandatoryFields.value;
	intPosition = strCurrentMandatoryFields.indexOf("," + strField + ",");
	if (intPosition >=0) {
		strHeader = strCurrentMandatoryFields.substring(0, intPosition);
		strTrailer = strCurrentMandatoryFields.substring(intPosition + strField.length + 1, strCurrentMandatoryFields.length);
		opener.top.Sentform.document.forms[0].txtMandatoryFields.value = strHeader + strTrailer;
	}
}