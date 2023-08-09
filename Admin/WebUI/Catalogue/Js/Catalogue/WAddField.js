/*
	AddTags function
	Purpose: add selected fields to cataloguing form
	Creator: Oanhtn
	CreatedDate: 18/05/2004
	Midification History:
*/

function AddTags() {
	// Used for bibliographic & authority data
	var intCounter;

	if (!document.forms[0].chkField.length) {
		if (document.forms[0].chkField.checked) {
			AddThisTag(document.forms[0].chkField.value);
		}
	} else {
		for (intCounter = 0; intCounter < document.forms[0].chkField.length; intCounter++) {
			if (document.forms[0].chkField[intCounter].checked) {
				AddThisTag(document.forms[0].chkField[intCounter].value);
			}
		}
	}
	openerURL = opener.top.main.Sentform.location.href;
	if (openerURL.indexOf("WCataSent.aspx") >= 0) {		
		opener.top.main.Sentform.document.forms[0].action = "WCataSent.aspx";
		opener.top.main.Sentform.document.forms[0].target = "Sentform";
		opener.top.main.Sentform.document.forms[0].submit();
	}
	if (openerURL.indexOf("WCataModify.aspx") >= 0) {
		opener.top.main.Sentform.document.forms[0].action = "WCataModify.aspx";
		opener.top.main.Sentform.document.forms[0].target = "Sentform";
		opener.top.main.Sentform.document.forms[0].submit();		
	}
	self.close();
}

/*
	AddThisTag function
	Purpose: add one field to cataloguing form
	Creator: Oanhtn
	CreatedDate: 18/05/2004
	Midification History:
*/

function AddThisTag(strFieldCode) {
	if (!eval("opener.top.main.Sentform.document.forms[0].tag" + strFieldCode)) {
		opener.top.main.Sentform.document.forms[0].txtAddedFieldCodes.value = opener.top.main.Sentform.document.forms[0].txtAddedFieldCodes.value + strFieldCode + ","
	}
}

