function CheckNullInput(msg){
	var chk;
	chk =	CheckNull(document.forms[0].txtTitle) && 	
			CheckNull(document.forms[0].txtCopyNumber) && 	
			CheckNull(document.forms[0].txtISBN) && 
			CheckNull(document.forms[0].txtAuthor) &&	
			CheckNull(document.forms[0].txtPublisher) &&
			CheckNull(document.forms[0].txtYear)&&
			CheckNull(document.forms[0].txtCallNumber)
		
	if (chk && (document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value=='0' || document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value=='')){
		alert(msg);
		eval(document.forms[0].txtTitle).focus();
		return false;
	}else{
		return true;
	}
}
function ResetForm(){
	document.forms[0].txtTitle.value="";
	document.forms[0].txtISBN.value="";
	document.forms[0].txtCopyNumber.value="";
	document.forms[0].txtCallNumber.value="";
	document.forms[0].txtAuthor.value="";
	document.forms[0].txtPublisher.value="";
	document.forms[0].txtYear.value="";
	document.forms[0].txtTitle.focus();
	return false;
}