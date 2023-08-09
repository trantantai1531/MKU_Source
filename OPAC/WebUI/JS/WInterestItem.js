// Replace String function
// In: inputString, fromString, toString
// Out: intputString with replaced
// Creator: dgsoft2016
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
}	// Ends the "replaceSubstring" function		
function Replace(Str, FindChar, ReplaceChar) {
		while (Str.indexOf(FindChar) !=-1){
			offset = Str.indexOf(FindChar);
			First = Str.substring(0, offset);
			First += ReplaceChar;
			Last = Str.substring(offset + FindChar.length, Str.length);
			Str = First + Last;
		}
		return Str;
}
// Open parent-> view all it's Childs
function ParentOpen(ID,Closed,intHTTP_USER_AGENT){
var temp;
	temp = parent.Hiddenbase.document.forms[0].hdOpenedParentIDs.value;
var position;
	position= temp.indexOf('||' + ID + '||');
	if  (Closed!==2){	
		if (position >= 0||Closed ==1) {
			var NewVal; 
			NewVal= Replace(temp,'||' + ID + '||', '||');
			parent.Hiddenbase.document.forms[0].hdOpenedParentIDs.value = NewVal;			
		} else {
			parent.Hiddenbase.document.forms[0].hdOpenedParentIDs.value = temp + ID + '||';	
		}
	}		
	document.forms[0].hdInterestObject.value = parent.Hiddenbase.document.forms[0].hdInterestObject.value;	
	document.forms[0].hdOpenedParentIDs.value = parent.Hiddenbase.document.forms[0].hdOpenedParentIDs.value;		
	if (parent.Hiddenbase.document.forms[0].hdRefreshInheritanceMap.value != 'TRUE'){
		document.forms[0].hdInheritanceMap.value = parent.Hiddenbase.document.forms[0].hdInheritanceMap.value;	
	}else{
		parent.Hiddenbase.document.forms[0].hdRefreshInheritanceMap.value = 'FALSE';
		document.forms[0].hdInheritanceMap.value = '||';
	}
	if((intHTTP_USER_AGENT) > 0) document.forms[0].hdScrollTop.value = document.body.hdScrollTop;		 
	document.forms[0].hdUpdateFlag.value ='FALSE';
	document.forms[0].submit();		
}

function ChildClick(value) {	
	var temp;
	temp = parent.Hiddenbase.document.forms[0].hdInterestObject.value;		
	var position;
	position = temp.indexOf("||" + value + "||");		
	if (position < 0) {		
		parent.Hiddenbase.document.forms[0].hdInterestObject.value = temp + value+ '||';
	} else {		
		var NewVal = Replace(temp,'||' + value + '||', '||');
		parent.Hiddenbase.document.forms[0].hdInterestObject.value = NewVal;
	}	
	parent.Hiddenbase.document.forms[0].hdRefreshInheritanceMap.value = "TRUE";				
}

function ParentClick(value, notRefresh,intHTTP_USER_AGENT) {	
	var hdInterestObject;
	hdInterestObject = parent.Hiddenbase.document.forms[0].hdInterestObject.value;		
	var temp2;
	temp2 = parent.Hiddenbase.document.forms[0].hdInheritanceMap.value;		
	var position;
	position = hdInterestObject.indexOf("||" + value + "||");	
	parent.Hiddenbase.document.forms[0].hdRefreshInheritanceMap.value = "TRUE";	 
	if (position < 0) {		
		hdInterestObject = hdInterestObject + value+ '||';
		parent.Hiddenbase.document.forms[0].hdInterestObject.value = hdInterestObject;
		document.forms[0].hdAllwaysChecking.value = "True";		
		if (temp2.indexOf("_" + value + "_YES") > 0||temp2.indexOf("||" + value + "_") >0){			
			ParentOpen(value,2,intHTTP_USER_AGENT);			
		}
	} else {		
		hdInterestObject = Replace(hdInterestObject,'||' + value + '||', '||');
		parent.Hiddenbase.document.forms[0].hdInterestObject.value = hdInterestObject; 
		if (temp2.indexOf("||" + value + "_") > 0){ 
			ParentOpen(value,2,intHTTP_USER_AGENT);	
		}
	}	 		
}
function Left(str, n){
	if (n <= 0){
		return("");
	}
	else{
		if (n > String(str).length){
			return str;
		}
		else{
			return String(str).substring(0,n);
		}
	}
}
function Right(str, n){
    if (n <= 0){ return("");
    }
    else{ 
		if (n > str.length){
			return str;
		}
		else {
			var iLen = str.length;
			return str.substring(iLen, iLen - n);
		}
	}
}
function CheckUpdate(intHTTP_USER_AGENT){	
	var strIDs;
		strIDs='';
	if (parent.Hiddenbase.document.forms[0].hdRefreshInheritanceMap.value != "TRUE"){
		document.forms[0].hdInheritanceMap.value = parent.Hiddenbase.document.forms[0].hdInheritanceMap.value;	
	}else{
		parent.Hiddenbase.document.forms[0].hdRefreshInheritanceMap.value = "FALSE";
		document.forms[0].hdInheritanceMap.value = "||";
	}
	if((intHTTP_USER_AGENT) > 0) document.forms[0].hdScrollTop.value = document.body.hdScrollTop;		 
	document.forms[0].hdInterestObject.value = parent.Hiddenbase.document.forms[0].hdInterestObject.value;	
	document.forms[0].hdOpenedParentIDs.value = parent.Hiddenbase.document.forms[0].hdOpenedParentIDs.value;
	document.forms[0].hdUpdateFlag.value ="TRUE";			
	for(i=0;i<document.forms[0].elements.length;i++){		
		if (document.forms[0].elements[i].type == 'checkbox'){
			if(document.forms[0].elements[i].checked){
				strIDs=strIDs + document.forms[0].elements[i].value + ',';
			}
		 }
	}
	if(strIDs.length>0) strIDs = ',' + strIDs;
	document.forms[0].hdInterestObject.value=strIDs;
	return(true);
}

