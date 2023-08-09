function replaceSubstring(inputString, fromString, toString) {
// Goes through the inputString and replaces every occurrence of fromString with toString
temp = inputString;
	if(fromString == "") {
		return(inputString);
	}
		if(toString.indexOf(fromString) == -1) {// If the string being replaced is not a part of the replacement string (normal situation)
			while(temp.indexOf(fromString) != -1){
				var toTheLeft = temp.substring(0,temp.indexOf(fromString));
				var toTheRight = temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
				temp = toTheLeft + toString + toTheRight;
			}
	}else {// String being replaced is part of replacement string (like "+" being replaced with "++") - prevent aninfinite loop
		var midStrings = Array("~","`","_", "^","#");
		var midStringLen = 1;
		var midString = "";// Find a string that doesn't exist in the inputString to be usedas an "inbetween" string
		while (midString == "") {
			for (var i=0; i < midStrings.length; i++) {
				var tempMidString = "";
					for (var j=0; j < midStringLen; j++) { 
						tempMidString += midStrings[i]; }
					if (fromString.indexOf(tempMidString) == -1) {
						midString = tempMidString;
						i = midStrings.length + 1;
					}
			}
		}
		// Keep on going until we build an "inbetween" string that doesn't exist
		// Now go through and do two replaces - first, replace the "fromString" with the "inbetween" string
		while (temp.indexOf(fromString) != -1) {
			var toTheLeft = temp.substring(0, temp.indexOf(fromString));
			var toTheRight =temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
			temp = toTheLeft + midString + toTheRight;
		}
	// Next, replace the "inbetween" string with the "toString"
		while (temp.indexOf(midString) != -1) {
			var toTheLeft = temp.substring(0,temp.indexOf(midString));
			var toTheRight = temp.substring(temp.indexOf(midString)+midString.length,temp.length);
			temp = toTheLeft + toString + toTheRight;
		}
	}
// Ends the check to see if the string being replaced is part of the replacement string or not
	return temp;
	// Send the updated string back to the user
}

function CheckValue(field,strNote) {
	if (isNaN(replaceSubstring(eval(field).value,",","")) || parseFloat(replaceSubstring(eval(field).value,",","")) < 0) { 
		alert(strNote);		
		eval(field).focus(); 
		return false;
		} 	 
	return true;	
}

function CheckTransfer(strEmpty,strZero,strNumErr,strDateErr,strLimit,strTranErr,strNoMoney) {	
	if (document.forms[0].txtMoney.value=="") {
		alert(strEmpty);		
		document.forms[0].txtMoney.focus(); 
		return false;		
	}
	else {
		if (document.forms[0].txtMoney.value=="0"){
		alert(strZero);		
		document.forms[0].txtMoney.value = '';
		document.forms[0].txtMoney.focus(); 
		return false;
		}
		else {
			if (!CheckValue("document.forms[0].txtMoney",strNumErr)) 
				return false;
			}
	}
	
	if (document.forms[0].txtDateTran.value=="") {
		alert(strEmpty);		
		document.forms[0].txtDateTran.focus(); 
		return false;		
	}
	else {
		if (!CheckDate("document.forms[0].txtDateTran","dd/mm/yyyy",strDateErr))
			return false;
	}
	if (document.forms[0].txtDecision.value=="") {
		alert(strEmpty);		
		document.forms[0].txtDecision.focus(); 
		return false;		
	}	
	if(document.forms[0].ddlBudgetDes.selectedIndex==document.forms[0].ddlBudgetSrc.selectedIndex){
		alert(strTranErr);
		return false;
	}
	var moneyTrans=parseFloat(document.forms[0].txtMoney.value);
	var strValueSrc=document.forms[0].ddlBudgetSrc.options[document.forms[0].ddlBudgetSrc.selectedIndex].value;		
	var arrValueSrc=strValueSrc.split(",");	
	var moneyCurr=parseFloat(arrValueSrc[1]);
	if (moneyCurr<=0) {
		alert(strNoMoney);
		return false;	
	}
	if (moneyTrans>moneyCurr) {
		if (confirm(strLimit)) {
			document.forms[0].txtMoney.value=moneyCurr;
		}
		else {
			return false;
		}
	}
	return true;

}
