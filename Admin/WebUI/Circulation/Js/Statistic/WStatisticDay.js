// CheckValidNumber method
function CheckValidNumber(obj,msg1) {
	var tempNum;
	tempNum = eval(obj).value;
	if (isNaN(tempNum)) {
		alert(msg1);
		eval(obj).focus();							
		return false;
	}
	else
	{
		if (parseInt(tempNum) <=0)
		{
			alert(msg1);
			eval(obj).focus();
			return false;
		}
	} 
	return true;
}

function CheckStatic(strNote,strNumErr1,strNumErr2) {
	if(document.forms[0].txtMonth.value=="") {
		alert(strNote);
		document.forms[0].txtMonth.focus();
		return false;
	}
	else {
		if(!CheckValidNumber('document.forms[0].txtMonth',strNumErr1)){
			alert(strNumErr1);
			document.forms[0].txtMonth.focus();
			return false;
			}
		if (parseInt(document.forms[0].txtMonth.value)>12) {
			alert(strNumErr1);
			document.forms[0].txtMonth.focus();
			return(false);
		}
			
	}
	if(document.forms[0].txtYear.value=="") {
		alert(strNote);
		document.forms[0].txtYear.focus();
		return false;
	}
	else {
		if(!CheckValidNumber('document.forms[0].txtYear',strNumErr2))
			return false;
	}
	return true;
	//document.forms[0].action='WStatisticDay.aspx?x=" & GenRandomNumber(10) & "' ; document.forms[0].submit();	
}