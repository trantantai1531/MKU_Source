/**********************************************************************************/
/*****************		WComprehendsiveReportBook Js file		*******************/
/**********************************************************************************/
// Purpose: kiem tra va gan cac gia tri cho phan in so bao cao tong quat
// Creator: sondp
// CreatedDate: 13/04/2005
// Goto previous page
function PreviousClick(MaxPage,CurrentPage,strMessage){
	if(CurrentPage<=1) {
		alert(strMessage);
		return false;
	}
	document.forms[0].txtCurrentPage.value=parseInt(CurrentPage)-1;
	parent.Display.location.href='WComprehReportBookD.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
// Goto next page
function NextClick(MaxPage,CurrentPage,strMessage){
	if(CurrentPage>=MaxPage) {
		alert(strMessage);
		return false;
	}
	document.forms[0].txtCurrentPage.value=parseInt(CurrentPage)+1;
	parent.Display.location.href='WComprehReportBookD.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
// Goto page
function CurrentPageChange(MaxPage,CurrentPage,strMessage,strMessage1){
	if(trim(CurrentPage)=='') {	
		alert(strMessage1);
		document.forms[0].txtCurrentPage.focus();
		return false;
	}
	if(isNaN(CurrentPage)){	
		alert(strMessage1);
		document.forms[0].txtCurrentPage.focus();
		return false;
	}
	if((CurrentPage>MaxPage)||(CurrentPage<1)){	
		alert(strMessage);
		document.forms[0].txtCurrentPage.focus();
		return false;
	}	
	parent.Display.location.href='WComprehReportBookD.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
}
// Method: replaceSubstring
// Purpose: Replate String
// In: string source, string find, string replace
// Out: string source
// Creator: sondp
// CreatedDate: 25/09/2004
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
}// Ends the "replaceSubstring" function		
// Replace < or > by &lt; or &gt;
function EncryptionTags(obj){
	eval(obj).value=replaceSubstring(eval(obj).value,'<','&lt;');
	eval(obj).value=replaceSubstring(eval(obj).value,'>','&gt;');	
}			
// Replace &lt; or &gt; by < or >
function DecryptionTags(obj){
	eval(obj).value=replaceSubstring(eval(obj).value,'&lt;','<');
	eval(obj).value=replaceSubstring(eval(obj).value,'&gt;','>');	
}
// Encryption controls
function Encryption(){
	EncryptionTags('document.forms[0].Editor');	
}
// Decryption controls
function Decryption(){
	DecryptionTags('document.forms[0].Editor');
}
// Preview function
function Preview(action){
	PreviewFormWin = window.open('','PreviewFormWin','height=400,width=800,resizable,menubar=yes,scrollbars=yes,screenX=0,screenY=0,top=10,left=10');		
	document.forms[0].action='WComprehReportBookP.aspx?action=' + action;
	document.forms[0].target='PreviewFormWin';
	document.forms[0].submit();			
	document.forms[0].action='WComprehReportBookE.aspx';
	document.forms[0].target= self.name;
	PreviewFormWin.focus();
	return(false);
}

function ResetForm() {
	document.forms[0].txtItemsOnPage.value = 25;
	document.forms[0].txtSequency.value = 1;
	document.forms[0].txtToTime.value = '';
	document.forms[0].txtFromTime.value = '';
	document.forms[0].ddlLibrary.options.selectedIndex = 0;
}