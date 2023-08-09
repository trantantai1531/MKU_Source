/*
	CheckAllIn function
*/
function CheckAllIn() {
var check;
	check = CheckNull(document.forms[0].txtTitle) && CheckNull(document.forms[0].txtAuthor)
	&& CheckNull(document.forms[0].txtPatronName) && CheckNull(document.forms[0].txtPatronCode) 
	&& document.forms[0].lsbLib.options.selectedIndex < 0 && document.forms[0].ddlDocType.value == 0
	&& (eval(document.forms[0].ddlInTimeMode).value == 0 || (CheckNull(document.forms[0].txtFromDate) && CheckNull(document.forms[0].txtToDate)))
	
	if (check) 
		return false;
	var strIDs="";
	var i;	
	for(i=0;i<document.forms[0].lsbLib.length;i++){
		if(document.forms[0].lsbLib.options[i].selected) {
			strIDs=strIDs + document.forms[0].lsbLib.options[i].value+",";
		}
	}
	document.forms[0].hidIDs.value=strIDs;
	return true;
}

/*
	CheckAllOut function
*/
function CheckAllOut() {
var check;
	check = CheckNull(document.forms[0].txtTitle) && CheckNull(document.forms[0].txtAuthor)
	&& CheckNull(document.forms[0].txtPatronName) && CheckNull(document.forms[0].txtPatronCode) 
	&& document.forms[0].lsbLib.options.selectedIndex < 0 && document.forms[0].ddlDocType.value == 0
	&& (eval(document.forms[0].ddlOutTimeMode).value == 0 || (CheckNull(document.forms[0].txtFromDate) && CheckNull(document.forms[0].txtToDate)))
	
	if (check) 
		return false;

	var strIDs="";
	var i;	
	for(i=0;i<document.forms[0].lsbLib.length;i++){
		if(document.forms[0].lsbLib.options[i].selected) {
			strIDs=strIDs + document.forms[0].lsbLib.options[i].value+",";
		}
	}
	document.forms[0].hidIDs.value=strIDs;
	return true;
}

/*
	Filter function
*/
function Filter()
{
	parent.Sentform.document.forms[0].btnFilter.disabled=false;
	parent.Sentform.document.forms[0].ddlAction.disabled=false;
	parent.Sentform.document.forms[0].btnAction.disabled=false;
	parent.Sentform.document.forms[0].btnCancelFilter.disabled=false;
	parent.Sentform.document.forms[0].btnFilter.disabled=false;
	if (eval(parent.Sentform.document.forms[0].btnCreate))
	{
		parent.Sentform.document.forms[0].btnCreate.disabled = false;
	}
	return;
}

/*
	CheckNumber function
*/
function CheckNumber(obj,msg) {
	var tempNum;
	tempNum = eval(obj).value;
	if (isNaN(tempNum)) {
		alert(msg);
		eval(obj).value = "";							
		eval(obj).focus();							
		return false;
	} 
	else
	{
		if (parseFloat(eval(obj).value) < 0)
		{
			alert(msg);
			eval(obj).value = "";							
			eval(obj).focus();
			return false;
		}
	}
		return true;
		
}
function ResetForm() {
	if (eval(document.forms[0].ddlInTimeMode))
		document.forms[0].ddlInTimeMode.selectedIndex=0;
	else
		document.forms[0].ddlOutTimeMode.selectedIndex=0;
	document.forms[0].txtFromDate.value='';
	document.forms[0].txtToDate.value='';
	document.forms[0].txtTitle.value='';
	document.forms[0].txtAuthor.value='';
	document.forms[0].txtPatronName.value='';
	document.forms[0].txtPatronCode.value='';
	document.forms[0].ddlDocType.selectedIndex=0;
	return false;
}