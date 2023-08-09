function CheckExistsItem(){
	CheckExistsItemWin = window.open('','WCheckExitTitle','height=360,width=700,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=100,left=50');
	document.forms[0].action='WCheckTitle.aspx';
	document.forms[0].target='CheckExistsItemWin';
	document.forms[0].submit();			
	document.forms[0].action='WCreateRequest.aspx';
	document.forms[0].target= self.name;
	CheckExistsItemWin.focus();
}

function CheckNullInput(msg1,msg2){
	var chk;	
	if (document.forms[0].ddlRegularity.options.selectedIndex>0) chk=false;
	else
		chk = CheckNull(document.forms[0].txtTitle) && 	
			CheckNull(document.forms[0].txtCountry) && 	
			CheckNull(document.forms[0].txtPublisher) && 
			CheckNull(document.forms[0].txtLanguage) &&	
			CheckNull(document.forms[0].txtISSN) &&
			CheckNull(document.forms[0].txtClassify)&&
			CheckNull(document.forms[0].txtSubject) &&
			CheckNull(document.forms[0].txtKeyword)

	if (CheckNull(document.forms[0].txtGroupName))
	{
		alert(msg1);
		document.forms[0].txtGroupName.focus();
		return false;	
	}
	if (chk){
		alert(msg2);
		eval(document.forms[0].txtTitle).focus();
		return false;
	}else{
		return true;
	}	
}

function CheckNullInputSearch(msg1, msg2) {
    var chk;


    chk = CheckNull(document.forms[0].txtTitle) &&
        CheckNull(document.forms[0].txtCountry) &&
        CheckNull(document.forms[0].txtPublisher) &&
        CheckNull(document.forms[0].txtLanguage) &&
        CheckNull(document.forms[0].txtISSN) &&
        CheckNull(document.forms[0].txtClassify) &&
        CheckNull(document.forms[0].txtSubject) &&
        CheckNull(document.forms[0].txtKeyword);
    
    if (chk) {
        alert(msg2);
        eval(document.forms[0].txtTitle).focus();
        return false;
    } else {
        return true;
    }
}

// CheckDel function
function CheckDel(msg1,msg2)
{
	if (document.forms[0].ddlGroup.options[document.forms[0].ddlGroup.options.selectedIndex].value == 0)
	{
		alert(msg1);
		return false;
	}
	else
	{
		return confirm(msg2);
	}
}
function ResetForm() {
	document.forms[0].ddlRegularity.options.selectedIndex=0;
	document.forms[0].txtTitle.value="";
	document.forms[0].txtCountry.value="";
	document.forms[0].txtPublisher.value="";
	document.forms[0].txtLanguage.value="";
	document.forms[0].txtISSN.value="";
	document.forms[0].txtClassify.value="";
	document.forms[0].txtSubject.value="";
	document.forms[0].txtKeyword.value="";
	return false;
}