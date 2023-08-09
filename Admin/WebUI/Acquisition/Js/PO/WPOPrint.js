/**********************************************************************************/
/***********************		WOPPrint Js file		***************************/
/**********************************************************************************/
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
function GetEmailName(strMsg,strMsg1,strMsg2) {
	if((strMsg!='')&&(document.forms[0].ddlForm.options.selectedIndex==0)){
		alert(strMsg);
		document.forms[0].ddlForm.focus();
		return(false);
	}
	
	var strEmail=prompt(strMsg1);
	if(strEmail==null) return false;
	if (!CheckValidEmails(strEmail)) {
		alert(strMsg2);
		return false;
		}
	document.forms[0].hidToEmail.value=strEmail;
	return true;	
}

// Submit function
function Submit(strFormSelected,strFlage){
	if(document.forms[0].ddlForm.options.selectedIndex==0){
		alert(strFormSelected);
		document.forms[0].ddlForm.focus();
		return(false);
	}
	if(document.forms[0].ddlPublisher.options.selectedIndex==0) document.forms[0].hdPublisher.value='';	
	document.forms[0].action='WPOPrint.aspx?Flage=' + strFlage;	
	document.forms[0].submit();
	return(false);
}
// Sub Submit function
function EditSubmit(){
	document.forms[0].action='WOPPrintEdit.aspx';
	document.forms[0].submit();
	DecryptionTags('document.forms[0].hdDisplay');
	return(false);
}
// BindSumCurrency function
function BindSumCurrency(){
	if(document.forms[0].ddlSumCurrency.options.selectedIndex>0){
		document.forms[0].txtSumCurrency.value=document.forms[0].ddlSumCurrency.options[document.forms[0].ddlSumCurrency.options.selectedIndex].text;		
	}	
	return(false);
}
// BindCurrency function
function BindCurrency(){
	if(document.forms[0].ddlCurrency.options.selectedIndex>0){
		document.forms[0].txtCurrency.value=document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.options.selectedIndex].text;
	}
	return(false);
}
// Encryption controls
function Encryption(){
	EncryptionTags('document.forms[0].Editor');
	return(true);
}
// Decryption controls
function Decryption(){
	DecryptionTags('document.forms[0].Editor');
	return(true);
}
// Preview function
function Preview(){
	PreviewFormWin = window.open('','PreviewFormWin','height=200,width=770,resizable,menubar=yes,scrollbars=yes,screenX=0,screenY=0,top=10,left=10');		
	document.forms[0].action='WPOPrintPreview.aspx';
	document.forms[0].target='PreviewFormWin';
	document.forms[0].submit();			
	document.forms[0].action='WOPPrintEdit.aspx';
	document.forms[0].target= self.name;
	PreviewFormWin.focus();
	Decryption();
}