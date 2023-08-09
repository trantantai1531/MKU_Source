//creator: sondp
//createdate: 29/11/2004
//purpose: ILL purponse
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
}
function storeCaret(textEl) {
	if (!textEl.focus()) textEl.focus();
	if (textEl.createTextRange)	{
		textEl.caretPos = document.selection.createRange().duplicate();
	}
}
function UsePatronInfo(textEl,source) {
	var text;
	if (!textEl.focus()) textEl.focus();	
	text =source.options[source.selectedIndex].value;
	if (textEl.createTextRange && textEl.caretPos){
		var caretPos = textEl.caretPos;
		caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == ' ' ? text + ' ' : text;
	} else {		
		textEl.value  = text;
	}
	textEl.caretPos = caretPos + text.length;	
	textEl.focus();
}
// Preview template
function PreviewTemplate(){
	PreviewTemplateWindow = window.open("", "PreviewTemplateWindow", "height=400,width=540,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=40,left=60");
	document.forms[0].action="WPreviewTemplate.aspx";
	document.forms[0].target="PreviewTemplateWindow";
	EncryptionTags();
	document.forms[0].submit();
	document.forms[0].action="WTemplate.aspx";
	document.forms[0].target= self.name;
	PreviewTemplateWindow.focus();	
	DecryptionTags()
	return(false);
}
// Check for update or insert
function CheckforUpdate(strCaptionEmty){
	if(CheckNull(document.forms[0].txtCaption)){
		document.forms[0].txtCaption.focus();		
		alert(strCaptionEmty);
		return(false);
	}
	// update or insert 		
	EncryptionTags();
	return(true);	
}
// Check for delete
function CheckforDelete(){
	//alert(document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value);
	if(document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value==0){
		return(false); // delete cancel
	}	
	EncryptionTags();
	// delete
	return(true);
}
//Encryption tags as "<" or ">"
function EncryptionTags(){
	document.forms[0].txtContent.value=replaceSubstring(document.forms[0].txtContent.value,'<','&lt;');
	document.forms[0].txtContent.value=replaceSubstring(document.forms[0].txtContent.value,'>','&gt;');
}
//Decryption tags from "<" to "gl;" so on...
function DecryptionTags(){
	document.forms[0].txtContent.value=replaceSubstring(document.forms[0].txtContent.value,'&lt;','<');
	document.forms[0].txtContent.value=replaceSubstring(document.forms[0].txtContent.value,'&gt;','>');
}
// Load back data 
function LoadBackData(strTitle,strContent){
	parent.Workform.document.forms[0].txtCaption.value=strTitle;
	parent.Workform.document.forms[0].txtContent.value=replaceSubstring(strContent,'<~>','\n');
	
}
// Refresh data
function RefreshData(){
	parent.Workform.document.forms[0].txtCaption.value='';
	parent.Workform.document.forms[0].txtContent.value='';	
}