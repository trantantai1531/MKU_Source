function ResetForm(intFormID) {
	if (intFormID == 0) { // new a MarcForm
		self.location.href='WMarcSend.aspx';
		parent.Workform.location.href='WMarcFrame.aspx';
	} else { // update current MarcForm
		self.location.href='WMarcSend.aspx?FormID=' + intFormID;
		parent.Workform.location.href='WMarcFrame.aspx';
	}
}
/*
	CheckValidForm function
	Purpose: Check some fields have been selected 
	Input: Two error messages
*/
function CheckValidForm(strMess1, strMess2, intUtf) {
	if (document.forms[0].txtPickedFields.value == ",") {
		alert(strMess1);
		return;
	}
	if (CheckNull(document.forms[0].txtFormName)) {
		alert(strMess2);
		return;
	}

	document.forms[0].action="WMarcFormSave.aspx";
	document.forms[0].target="Workform";
	document.forms[0].submit();
}

/*
	OpenMandatoryFieldsWin function
	Purpose: open MandatoryFields windows
*/
function OpenMandatoryFieldsWin(strManFieldIDs, strFieldIDs, strWinname, intWidth, intHeight, intLeft, intTop) {
    OpenWindow("WMandatoryMarcFields.aspx?MandatoryFieldIDs=" + strManFieldIDs + "&FieldIDs=" + strFieldIDs.substring(1, strFieldIDs.length - 1), 'WMandatoryFieldsWin', intWidth, intHeight, intLeft, intTop);
}

/*
	OpenMarcFormViewWin function
	Purpose: open MarcForm windows
*/
function OpenMarcFormViewWin(strPickedFieldCodes, strManFieldCodes, strWinname, intWidth, intHeight, intLeft, intTop) {
	var WPickedFieldsWin;
	WPickedFieldsWin = window.open('','WPickedFieldsWin', "width=" + intWidth + ",height=" + intHeight + ",left=" + intLeft+ ",top=" + intTop+ ",menubar=no,resizable=no,scrollbars=yes");
	document.forms[0].action='WMarcFormView.aspx';
	document.forms[0].target='WPickedFieldsWin';
	document.forms[0].submit();
	WPickedFieldsWin.focus();
}
