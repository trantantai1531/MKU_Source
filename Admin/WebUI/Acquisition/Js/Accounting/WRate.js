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
function CheckAddNew(strEmpty, strNumErr, strSameCode) {
    document.forms[0].txtUnitMoney.value = document.forms[0].txtUnitMoney.value.replace(/^\s*/, "").replace(/\s*$/, "")
    document.forms[0].txtRate.value = document.forms[0].txtRate.value.replace(/^\s*/, "").replace(/\s*$/, "")
	if (document.forms[0].txtUnitMoney.value=="") {
		alert(strEmpty);		
		document.forms[0].txtUnitMoney.focus(); 
		return false;		
	}
	if (document.forms[0].txtRate.value=="") {
		alert(strEmpty);		
		document.forms[0].txtRate.focus(); 
		return false;		
	}
	else {
		if (!CheckValue("document.forms[0].txtRate",strNumErr)) 
			return false;
	}
	// check the same currencycode
	var strCode=','+document.forms[0].txtUnitMoney.value.toUpperCase()+',';
	var pos=document.forms[0].hidCurrencyCode.value.indexOf(strCode);	
	if (pos>=0) {
		alert(strSameCode);
		document.forms[0].txtUnitMoney.focus();
		return false;
	}		
	return true;

}
function CheckUpdate(field,strEmpty,strNumErr,strSameCode) {	
	if (eval(field+'txtdtgRate').value =="") {
		alert(strEmpty);
		eval(field+'txtdtgRate').focus();
		return false;	
		}
	else {
		if(!CheckValue(field+'txtdtgRate',strNumErr)) 
			return false;
	}
	return true;
}
