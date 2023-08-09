// rdoDefault function
function rdoDefault()
{
	if(document.forms[0].hidControl.value>0){
		if (eval('document.forms[0].rdoChoice[0]'))
		{
			document.forms[0].rdoChoice[0].checked = true; 
			document.forms[0].rdoChoice[0].click();
		}
		else
		{
			if (eval('document.forms[0].rdoChoice'))
			{
				document.forms[0].rdoChoice.checked = true; 
				document.forms[0].rdoChoice.click();
			}
		}
	}
}

function rdoEvent(strCopyNumber, intCurrentIndex){
	//rdoChoice
	var intIndex = 0;
	if (eval('document.forms[0].rdoChoice[0]'))
	{
		for(var intIndex = 0; intIndex < document.forms[0].rdoChoice.length; intIndex++) {
			if (intIndex==intCurrentIndex) {
				document.forms[0].rdoChoice[intIndex].checked = true; 
				document.forms[0].hidCopyNum.value=strCopyNumber;
			} else {
				document.forms[0].rdoChoice[intIndex].checked = false;
			}
		}	
	}
	else
	{
		if (eval('document.forms[0].rdoChoice'))
		{
			document.forms[0].rdoChoice.checked = true; 
			document.forms[0].hidCopyNum.value=strCopyNumber;
		}
	}
}


/*
	CheckIn function
	Purpose: CheckIn the selected
*/
function CheckOut(strMsg) {
	if (document.forms[0].hidCopyNum.value!='')
	{
		parent.CheckOut.document.forms[0].hidContinue.value=1;
		parent.CheckOut.document.forms[0].txtCopyNumber.value = document.forms[0].hidCopyNum.value;
		parent.CheckOut.document.forms[0].btnCheckOut.click();
	}
	else
	{
		alert(strMsg);
	}
}

/*
	CheckIn function
	Purpose: CheckIn the selected
*/
function CheckIn(strMsg) {
	if (document.forms[0].hidCopyNum.value!='')
	{
		parent.CheckIn.document.forms[0].txtCopyNumber.value = document.forms[0].hidCopyNum.value;
		parent.CheckIn.document.forms[0].btnCheckIn.click();
	}
	else
	{
		alert(strMsg);
	}
}