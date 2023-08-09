/*
	ConfigureAttachDataField function
	Purpose: open new windows to configuration Attach field
	Input: strMess alert invalid field type		
*/
function ConfigureAttachDataField(strMess) {
	if (document.forms[0].ddlMarcFieldTypes.options[document.forms[0].ddlMarcFieldTypes.options.selectedIndex].value != 4) {
		if ((document.forms[0].ddlMarcFieldTypes.options[document.forms[0].ddlMarcFieldTypes.options.selectedIndex].value == 7) || (document.forms[0].ddlMarcFieldTypes.options[document.forms[0].ddlMarcFieldTypes.options.selectedIndex].value == 8)) {
			ConfigureLinkField(parseFloat(document.forms[0].txtLinkTypeID.value));
		} else	{
			alert(strMess);
		}
	} else {
		OpenWindow('WConfigureAttachField.aspx','WConfigureAttachField',540,270,50,100);
	}
}

/*
	ConfigureLinkField function
	Purpose: open new windows to configuration Link field	
*/
function ConfigureLinkField(intLinkID) {
	OpenWindow('WConfigureLinkField.aspx?LinkID=' + intLinkID,'WConfigureLinkField',360,109,50,100);
}
