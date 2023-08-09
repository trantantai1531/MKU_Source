// CheckNumber method
function CheckNumber(obj,msg) {
	var tempNum;
	tempNum = replaceSubstring(eval(obj).value,',','.')
	if (isNaN(tempNum)) {
		alert(msg);
		eval(obj).focus();							
		return false;
	} 
	return true;
}

// CheckValidNumber method
function CheckValidNumber(obj,msg1,msg2) {
	var tempNum;
	tempNum = replaceSubstring(eval(obj).value,',','.')
	if (isNaN(tempNum)) {
		alert(msg1);
		eval(obj).focus();							
		return false;
	}
	else
	{
		if (parseFloat(tempNum) <=0)
		{
			alert(msg2);
			eval(obj).focus();
			return false;
		}
	} 
	return true;
}

// CheckAll function
function CheckAll(msg1,msg2,msg3){
	if (CheckNull(document.forms[0].txtPatronCode)) {
		alert(msg1);
		document.forms[0].txtPatronCode.focus();
		return false;	
	}
	if (CheckNull(document.forms[0].txtAmount)) {
		alert(msg1);
		document.forms[0].txtAmount.focus();
		return false;	
	}
	if (CheckNull(document.forms[0].txtRate)) {
		alert(msg1);
		document.forms[0].txtRate.focus();
		return false;	
	}
	if (CheckNull(document.forms[0].txtDate)) {
		alert(msg1);
		document.forms[0].txtDate.focus();
		return false;	
	}
	else 
	{
		if (parseFloat(document.forms[0].txtAmount.value) <= 0)
		{
				alert(msg2);
				document.forms[0].txtAmount.focus();
				document.forms[0].txtAmount.select();
				return false;
		}
		
		if (parseFloat(document.forms[0].txtRate.value) <= 0)
		{
				alert(msg3);
				document.forms[0].txtRate.focus();
				document.forms[0].txtRate.select();
				return false;
		}
	}
	
	return true;
}	

// DateToDay function
/*function DateToday() {
   var Today = new Date();
   var ThisDay = Today.getDate();
   var ThisMonth = Today.getMonth()+1;
   var ThisYear = Today.getFullYear();
   return ThisDay+"/"+ThisMonth+"/"+ThisYear;
}


//StartForm function
function StartForm() {
if (eval('document.forms[0].txtDate')){
   document.forms[0].txtDate.value = DateToday();
   }
}*/

//checkInserUpdate
// field,strNote	
function CheckInsertUpdate(field,strNote,strNumErr1,strNumErr2) {
	if (CheckNull(field+'txtCreatedDate')) {
		alert(strNote);
		eval(field+'txtCreatedDate').focus();
		return false;	
		}
	
	if (CheckNull(field+'txtPatronCodeDisplay')) {
		alert(strNote);
		eval(field+'txtPatronCodeDisplay').focus();
		return false;	
		}
		
	if (CheckNull(field+'txtAmountDisplay')) {
		alert(strNote);
		eval(field+'txtAmountDisplay').focus();
		return false;	
		}
	else {
		if (!CheckValidNumber(field+'txtAmountDisplay',strNumErr1,strNumErr2))
			return false;
		
	}
		
	if (CheckNull(field+'txtRateDisplay')) {
		alert(strNote);
		eval(field+'txtRateDisplay').focus();
		return false;	
	}	
	return true;
}


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


