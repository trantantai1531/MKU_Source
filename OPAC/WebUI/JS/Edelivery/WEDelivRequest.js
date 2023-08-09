// ConvertCurrency function
function ConvertCurrency(amount, c1, c2) {
	return amount*GetRatio(c1)/GetRatio(c2);
}

function GetRatio(c) {
	for (i = 0; i < CU.length; i++) {
		if (CU[i] == c.toUpperCase()) {
			return Ratio[i];
		}
	}
	return 1;
}

// ConvertCurrency function
function ReCalculate(a, c, b1) {
	v = ConvertCurrency(a,c, document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.options.selectedIndex].text);
	
	if (b1) {
		document.forms[0].txtTotal.value = Math.round((parseFloat(document.forms[0].txtTotal.value) + v)*100)/100;
	}
	else {
		document.forms[0].txtTotal.value = Math.round((parseFloat(document.forms[0].txtTotal.value) - v)*100)/100;
	}
}

// Confirm the delete (YES = Do action, NO = Cancel)
function ConfirmTrans(msg)
{
var truthBeTold = window.confirm(msg);
if (truthBeTold) {
return true;
}  else  {
	return false;
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

// ReCalculateAll function
function ReCalculateAll(strOptionName, intStart, intMax) {
	document.forms[0].txtTotal.value = 0;
	for (j = intStart; j < intMax + intStart; j++) {
		if (eval('document.forms[0].dgrResult__ctl' + j + '_' + strOptionName).checked) {
			eval('document.forms[0].dgrResult__ctl' + j + '_' + strOptionName).checked = ! eval('document.forms[0].dgrResult__ctl' + j + '_' + strOptionName).checked;
			eval('document.forms[0].dgrResult__ctl' + j + '_' + strOptionName).click();	
		}	
	}
}


// If find an check object, check, if not, through away

function CheckAllItems(strDtgName, strOptionName, intStart){	
	var intCounter;	
	var blnStatus;
	var intMax;
	intMax = eval('document.forms[0].hidRecordNum').value;	
	
	document.forms[0].txtTotal.value = 0;
	if (eval('document.forms[0].CheckAll').checked) 
		blnStatus = true;
	else
		blnStatus = false;			
				
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName))
		{
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = !blnStatus;			
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).click();
			
		}			
	}
	if (blnStatus == false)
		document.forms[0].txtTotal.value = 0;
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
		eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked = !blnStatus;			
		eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).click();
	}			
	
}

// FirstMethod fucntion
function FirstMethod()
{
	document.forms[0].rdoMethod2.checked = false;
	document.forms[0].rdoMethod3.checked = false;
}

// SecondMethod fucntion
function SecondMethod()
{
	document.forms[0].rdoMethod1.checked = false;
	document.forms[0].rdoMethod3.checked = false;
}

// LastMethod fucntion
function LastMethod()
{
	document.forms[0].rdoMethod1.checked = false;
	document.forms[0].rdoMethod2.checked = false;
}

