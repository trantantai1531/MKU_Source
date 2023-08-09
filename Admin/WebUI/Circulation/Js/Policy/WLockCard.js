function EventKeyPress()
{
	if (event.keyCode==13)
	{
		document.forms[0].hidPatronCodeCheck.value=document.forms[0].txtPatronCodeF.value;
		document.forms[0].btnFillter.focus();	
		
		//document.forms[0].txtCardNoSearch.value='';	
		
	}
}
function EventOnChange()
{
	document.forms[0].hidPatronCodeCheck.value=document.forms[0].txtPatronCodeF.value;
	document.forms[0].btnFillter.focus();
}

function AcceptUnLock(strMsg, strPatronCode)
{
    if (confirm(strMsg)) {
        document.forms[0].hidPatronCodeNotExist.value = strPatronCode;
        document.forms[0].btnAcceptUnLock.click();
    }
}