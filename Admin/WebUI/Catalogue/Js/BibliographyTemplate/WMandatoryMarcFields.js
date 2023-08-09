/*
	UpdateMandatoryFields function
	Purpose: Update mandatory fields depending on user's selections
*/

function UpdateMandatoryFields() {
	var intTotal;
	var intCount;
	var strMandatoryFieldIDs;
	intTotal = document.forms[0].chkMarcSubField.length;
	strMandatoryFieldIDs = ",";
	if (intTotal > 0) {
		for (intCount = 0; intCount < intTotal; intCount++) {
			if (document.forms[0].chkMarcSubField[intCount].checked) {
				strMandatoryFieldIDs = strMandatoryFieldIDs + document.forms[0].chkMarcSubField[intCount].value + ",";
			}
		}
	}
	opener.top.Sentform.document.forms[0].txtMandatoryFields.value = strMandatoryFieldIDs;
	self.close();
}
