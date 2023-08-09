//method: replaceSubstring
//Purpose: Replate String
//In: string source, string find, string replate
//Out: string source
//Creator: sondp
//CreatedDate: 25/09/2004
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
	// Ends the "replaceSubstring" function		
function EncryptionTags(){
	document.forms[0].Editor.value=replaceSubstring(document.forms[0].Editor.value,'<','&lt;');
	document.forms[0].Editor.value=replaceSubstring(document.forms[0].Editor.value,'>','&gt;');
}			
function EditSubmit(SignFlage){	
	document.forms[0].Editor.value=replaceSubstring(document.forms[0].Editor.value,'"','');
	document.forms[0].Editor.value=replaceSubstring(document.forms[0].Editor.value,'<','&lt;');
	document.forms[0].Editor.value=replaceSubstring(document.forms[0].Editor.value,'>','&gt;');
EditForm = window.open('','EditForm','width='+800+',height='+600+',left=0,top=0,menubar=yes,scrollbars=yes,toolbar=yes');		
	document.forms[0].action='WPreviewLetter.aspx?SignFlage=' + SignFlage;
	document.forms[0].target='EditForm';
	document.forms[0].method='post';
	document.forms[0].submit();			
	document.forms[0].action='WEditClaimLetter.aspx';
	document.forms[0].target= self.blank;
	EditForm.focus();
}
