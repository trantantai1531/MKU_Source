function CheckInput(msg1,msg2,msg3,msg4){
	var chk;
	chk =	CheckNull(document.forms[0].txtTitle) && 	
			CheckNull(document.forms[0].txtAuthor) && 	
			CheckNull(document.forms[0].txtPublisher) && 
			CheckNull(document.forms[0].txtFrameType) &&	
			CheckNull(document.forms[0].txtLanguage) &&
			CheckNull(document.forms[0].txtKeyWord) &&
			CheckNull(document.forms[0].txtFrom) &&
			CheckNull(document.forms[0].txtTo)
	if (chk){
		alert(msg1);
		eval(document.forms[0].txtTitle).focus();
		return false;
	}
	
	if (parseInt(document.forms[0].txtFrom.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtFrom).focus();
		eval(document.forms[0].txtFrom).select();
		return false;
	}
	
	if (parseInt(document.forms[0].txtTo.value) <0)
	{
		alert(msg2);
		eval(document.forms[0].txtTo).focus();
		eval(document.forms[0].txtTo).select();
		return false;
	}
	
	if (!CheckNumber(document.forms[0].txtFrom)) 
	{
		alert(msg3);	
		return false;
	}
	
	if (!CheckNumber(document.forms[0].txtTo)) 
	{
		alert(msg3);
		return false;
	}
	
	if (CheckNumber(document.forms[0].txtFrom) && CheckNumber(document.forms[0].txtTo) &&
	    parseInt(document.forms[0].txtFrom.value) > parseInt(document.forms[0].txtTo.value))
	{
		alert(msg4);
		eval(document.forms[0].txtFrom).focus();
		return false;	
	}	
	return true;
}
// add by lent
// purpose : show or hidden table
function ShowHideTable(val) {
	if (val==0) {
		tblMain.style.display="";
		tblShowResult.style.display="none";
	}
	else {
		tblShowResult.style.display="";
		tblMain.style.display="none";	
	}
}

// CheckNumber method
function CheckNumber(obj) {
	var tempNum;
	tempNum = obj.value;
	if (isNaN(tempNum)) {
		obj.focus();							
		obj.select();							
		return false;
	} 
	return true;
}

function ClearContent()
{
	document.forms[0].txtTitle.value='';
	document.forms[0].txtAuthor.value='';
	document.forms[0].txtPublisher.value='';
	document.forms[0].txtFrameType.value='';
	document.forms[0].txtLanguage.value='';
	document.forms[0].txtKeyWord.value='';
	document.forms[0].txtFrom.value='';
	document.forms[0].txtTo.value='';
	document.forms[0].ddlItemType.options.selectedIndex = 0;
	document.forms[0].ddlEditPerson.options.selectedIndex = 0;
	document.forms[0].ddlPattern.options.selectedIndex = 0;	
	document.forms[0].txtTitle.focus();
}