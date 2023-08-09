/*
	Purpose: some function for insert new field
	CreatedDate: 21/03/2004
	Creator: Oanhtn
*/

/*
	CheckUniqueField function
	Purpose: check unique field
*/
function CheckUniqueField(intUTF, strMess) {
	if (CheckTagNumber(document.forms[0].txtFieldCode.value)) {
		alert(strMess);
		document.forms[0].txtFieldCode.value = "";
		document.forms[0].txtFieldCode.focus();
	} else {
		parent.Hiddenbase.location.href='WMarcFieldCheck.aspx?FieldCode=' + Esc(document.forms[0].txtFieldCode.value, intUTF);
	}
}

/*
	CheckTagNumber function
	Check valid fieldcode
*/
function CheckTagNumber(strFieldCode) {
	var intCount;
	for (intCount = 0; intCount < strFieldCode.length; intCount++) {
		if (strFieldCode.charAt(intCount) == " ") {
			return true;
		}
	}
	if (strFieldCode.length < 3) {
		return true;
	}
	if (isNaN(strFieldCode.substring(0,3)) || parseFloat(strFieldCode.substring(0,3)) < 0) {
		return true;
	}
	if (strFieldCode.length > 3 && strFieldCode.substring(3,4) != "$") {
		return true;
	}
	return false;
}

/*
	ConfigureAttachDataField function
	Purpose: open new windows to configuration Attach field
	Input: strMess alert invalid field type		
*/
function ConfigureAttachDataField(strMess) {
	if (document.forms[0].ddlMarcFieldTypes.options[document.forms[0].ddlMarcFieldTypes.options.selectedIndex].value != 4) {
		if ((document.forms[0].ddlMarcFieldTypes.options[document.forms[0].ddlMarcFieldTypes.options.selectedIndex].value == 7) || (document.forms[0].ddlMarcFieldTypes.options[document.forms[0].ddlMarcFieldTypes.options.selectedIndex].value == 8)) {
			ConfigureLinkField();
		} else	{
			alert(strMess);
		}
	} else {
		OpenWindow('WConfigureAttachField.aspx','WConfigureAttachField',700,360,50,100);
	}
}

/*
	ConfigureLinkField function
	Purpose: open new windows to configuration Link field	
*/

function ConfigureLinkField(strMess) {
	OpenWindow('WConfigureLinkField.aspx','WConfigureLinkField',700,360,50,100);
}

/*
	RefreshPage function
	Purpose: refresh page to insert another field
*/
function RefreshPage() {
	document.forms[0].txtFieldCode.value = '';
	document.forms[0].txtFieldName.value = '';
	document.forms[0].txtVietFieldName.value = '';
	document.forms[0].txtIndicators.value = '';
	document.forms[0].txtVietIndicators.value = '';
	document.forms[0].txtDescription.value = '';
	document.forms[0].txtLength.value = '';
	document.forms[0].chkMandatory.checked = false;
	document.forms[0].chkRepeatable.checked = false;
	document.forms[0].ddlAuthorityControl.selectedIndex = 0;
	document.forms[0].ddlMarcFieldTypes.selectedIndex = 1;
	document.forms[0].ddlMarcFunctions.selectedIndex = 1;
	document.forms[0].reset();
}