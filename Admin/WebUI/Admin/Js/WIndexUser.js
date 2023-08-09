// CheckAllInput fucntion
function CheckAllInput(msg1, msg2, msg3)
{
	var chk1;
	var chk2;
	chk1 = CheckNull(document.forms[0].txtFullName) || 
		   CheckNull(document.forms[0].txtUserName) 
	chk2 = !CheckNull(document.forms[0].txtPassword) || !CheckNull(document.forms[0].txtRetypePass)
	
		if (document.forms[0].hidUpdate.value == 0)
		{	
			if (chk1)
			{
				alert(msg1);
				return false;
			}
			else
			{
				if (document.forms[0].txtPassword.value != document.forms[0].txtRetypePass.value)
				{ 
					alert(msg2); 
					return false;
				}
			}
		}
		else
		{
			if (chk1)
			{
				alert(msg1);
				return false;
			}
			else
			{
				if ((chk2) & document.forms[0].txtPassword.value != document.forms[0].txtRetypePass.value)
				{ 
					alert(msg2); 
					return false;
				}
			}
			if ((document.forms[0].hidParentID.value != 1) && (document.forms[0].hidParentIDTemp.value == 1))
				{
					return confirm(msg3);
				}
		}
	return;
}


// If find an check object, check, if not, through away

function CheckOptionVisible(strDtgName, strOptionName, intvalue){	
	var blnStatus;						
	
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName))
	{
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked) 
	{
		blnStatus = false;
	}
	else
	{
		blnStatus = true;	
	}	
	eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked = blnStatus;			
	}			
	
}

// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked)
		{
			intCount = intCount + 1		
		}			
	}
	
	if (intCount != 0) {
		return true;
	}
	else
	{
		alert(strMsg);
		return false;
	}
}

// Confirm the delete (YES = Do action, NO = Cancel)
function ConfirmDelete(msg)
{
var truthBeTold = window.confirm(msg);
if (truthBeTold) {
return true;
}  else  {
			return false;
}
}