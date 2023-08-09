function ShowHideTable(val) {
	if (val==0) {
		tblViewTemps.style.display="";
		tblAddnew.style.display="none";
	}
	else {
		tblAddnew.style.display="";
		tblViewTemps.style.display="none";	
	}
}
function UpdateTemplates(TempID) {
	var inti;
	var intLength;	
	document.forms[0].hidAction.value=1
	ShowHideTable(1)
	document.forms[0].txtTitle.focus();
	intLength=document.forms[0].ddlTemplate.options.length;
	for(inti=0;inti<intLength;inti++) {
		if(document.forms[0].ddlTemplate.options[inti].value==TempID) {
			document.forms[0].ddlTemplate.options[inti].selected=true;
			break;
		}
	}	
	top.main.hiddenbase.location.href='WBookLabelTemplateHidden.aspx?TemplateID='+ TempID;
	return(false);
}
function DeleteTemplates(TempID) {
	top.main.hiddenbase.location.href='WBookLabelTemplateHidden.aspx?TemplateID='+ TempID + '&Action=Delete';
}

// Change Template function
function ChangeTemplate() {
    alert('111');
}