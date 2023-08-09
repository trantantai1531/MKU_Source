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
//---------------------------------------------------------------
//creteddate: 23/4/2004
//creator: sondp
//purpose: create pattern fichs
//---------------------------------------------------------------
function replace(string,text,by) {
// Replaces text with by in string in Source(string)
    var strLength = string.length, txtLength = text.length;
    if ((strLength == 0) || (txtLength == 0)) return string;

    var i = string.indexOf(text);
    if ((!i) && (text != string.substring(0,txtLength))) return string;
    if (i == -1) return string;

    var newstr = string.substring(0,i) + by;

    if (i+txtLength < strLength)
        newstr += replace(string.substring(i+txtLength,strLength),text,by);

    return newstr;
}
function storeCaret(textEl) {
	if (textEl.createTextRange)	{
		textEl.caretPos = document.selection.createRange().duplicate();
	}
}
function UsePatronInfo(textEl) {
	var text;
	text =document.Form1.ddlInf.options[document.Form1.ddlInf.selectedIndex].value;
	if (textEl.createTextRange && textEl.caretPos){
		var caretPos = textEl.caretPos;
		caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == ' ' ? text + ' ' : text;
	} else {		
		textEl.value  = text;
	}
	textEl.caretPos = caretPos + text.length;	
	textEl.focus();
}
//Load back data to WCatPatternFichDisplay.aspx
function UpLoadData(strTitle,strHeader,strContent,strFooter){	
	parent.Display.document.forms[0].txtTitle.value=replace(strTitle,'<!--`-->','\'');
	parent.Display.document.forms[0].txtHeader.value=replace(strHeader,'<!--`-->','\'');
	parent.Display.document.forms[0].txtContent.value=replace(strContent,'<!--`-->','\'');
	parent.Display.document.forms[0].txtFooter.value=replace(strFooter,'<!--`-->','\'');
	return true;
}
//Preview Catalogue Templage
function PreviewIt(){
	PreviewTemplateWin = window.open('','PreviewTemplateWin','height=400,width=630,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=40,left=60');		
	document.forms[0].action='WCatPatternFichPreview.aspx';
	document.forms[0].target='PreviewTemplateWin';
	document.forms[0].submit();			
	document.forms[0].action='WCatPatternFichDisplay.aspx';
	document.forms[0].target= self.name;
	PreviewTemplateWin.focus();
	return false;
}
//Add new Catalogue Tag
function AddTag() {
	AddTagWin = window.open("WCatPatternFichAddField.aspx", "AddTagWin", "height=480,width=630,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=7,top=7,left=60");
	AddTagWin.focus();
	return false;
}
//Add new user definetion field
function AddField(){
	AddFieldWindow = window.open('','AddFieldWindow','height=500,width=730,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=40,left=60');		
	document.forms[0].action='WCatPatternFichAddField.aspx';
	document.forms[0].target='AddFieldWindow';
	document.forms[0].submit();			
	document.forms[0].action='WCatPatternFichAddField.aspx';
	document.forms[0].target= self.name;
	AddFieldWindow.focus();
	return false;
}

function ConfirmDelete(strMsg1, strMsg2){
	if (document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value > 0) {	
		if(confirm(strMsg1)==false){//khong xoa thi lam sach cac control		
			return false;					
		}else{
			Encryptions();
			return true;//tra lai gia tri true de nut delete duoc thuc hien
		}
	} else {
		alert(strMsg2);
	}
}
//check Valid Tag
function CheckTag() {
	TagValid = true;
	if (document.forms[0].txtTagCode.value.length != 3 && document.forms[0].txtTagCode.value.length != 5) {
		TagValid = false;
	}
	else {
		tag = document.forms[0].txtTagCode.value.substring(0,3);
		if (isNaN(tag) || parseInt(tag) < 0) {
			TagValid = false;
		} 
		else {
			if (document.forms[0].txtTagCode.value.length == 5 && document.forms[0].txtTagCode.value.substring(3,4) != "$") {
				TagValid = false;
			}	
				
		}
	}
	if (! TagValid) {
		alert("Error Tag");
		document.forms[0].txtTagCode.value = '';
		document.forms[0].txtTagCode.focus();
	}
	return false;
}
function UseTagInfo (textEl, text)
{
  if (textEl.createTextRange && textEl.caretPos)
   {
    var caretPos = textEl.caretPos;
    caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == ' ' ? text + ' ' : text;
   }
  else
   textEl.value  = text;
   textEl.focus();
   textEl.caretPos = caretPos + text.length;
}

function SpecTagAdd() {
	opener.UseTagInfo(opener.document.forms[0].txtContent, document.forms[0].ddlSpceTag.options[document.forms[0].ddlSpceTag.options.selectedIndex].value);
	opener.document.forms[0].txtContent.click();
	self.close();
}
function NormalTagAdd() {
	val = "";
	val = "<$" + document.forms[0].txtTagCode.value;
	if (document.forms[0].ckbUpper.checked) {
		val = val + ":upper";
	}		
	if (document.forms[0].ckbFixedVal.checked)	{
		val = val + ":fixed=" + document.forms[0].txtFixedVal.value;
	}
	if (document.forms[0].ckbSerialFormat.checked)	{
		if (document.forms[0].rdbFromStart.checked) {
			val = val + ":serialstart" + document.forms[0].ddlSerialFormat.options[document.forms[0].ddlSerialFormat.options.selectedIndex].value;
		}	
		else {
			val = val + ":serialcontinue" + document.forms[0].ddlSerialFormat.options[document.forms[0].ddlSerialFormat.options.selectedIndex].value;
		}	
	}
	nocommas = ","
	if (document.forms[0].txtNormalSeparator.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtNormalSeparator.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtPrefix.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtPrefix.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtSuffix.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtSuffix.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtReplacement.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtReplacement.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtCountTo.value != "") {
		val = val + nocommas + document.forms[0].txtCountTo.value;
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtCountFrom.value != "") {
		val = val + nocommas + document.forms[0].txtCountFrom.value;
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	val = val + "$>";
	opener.UseTagInfo(opener.document.forms[0].txtContent, val);
	opener.document.forms[0].txtContent.click();
	self.close();
}
function ShelfTagAdd() {
	val = "";
	val = "<$" + document.forms[0].ddlHoldingType.options[document.forms[0].ddlHoldingType.options.selectedIndex].value;
	if (document.forms[0].ckbIncludeFieldLib.checked) {//Library
		val = val + ":lib";
	}		
	if (document.forms[0].ckbIncludeFieldInv.checked) {//Inventory
		val = val + ":inventory";
	}		
	if (document.forms[0].ckbIncludeFieldShelf.checked) {//Shelf
		val = val + ":shelf";
	}		
	val = val + ":number";
	nocommas = ","
	if (document.forms[0].txtShelfSeparator.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtShelfSeparator.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtShelfPrefix.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtShelfPrefix.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtShelfSuffix.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtShelfSuffix.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtShelfReplacement.value != "") {
		val = val + nocommas + "\"" + document.forms[0].txtShelfReplacement.value.replace("\"", "\\\"") + "\"";
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtShelfCountTo.value != "") {
		val = val + nocommas + document.forms[0].txtShelfCountTo.value;
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	if (document.forms[0].txtShelfCountFrom.value != "") {
		val = val + nocommas + document.forms[0].txtShelfCountFrom.value;
		nocommas = ","
	}	
	else {
		nocommas = nocommas + ",";
	}	
	val = val + "$>";
	opener.UseTagInfo(opener.document.forms[0].txtContent, val);
	opener.document.forms[0].txtContent.click();
	self.close();
}
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
// DecryptionTags function
function Decryptions(){
	DecryptionTags('document.forms[0].txtHeader');
	DecryptionTags('document.forms[0].txtContent');
	DecryptionTags('document.forms[0].txtFooter');
}
// Encryptions function
function Encryptions(){
	EncryptionTags('document.forms[0].txtHeader');
	EncryptionTags('document.forms[0].txtContent');
	EncryptionTags('document.forms[0].txtFooter');
}

// CheckValidData function
function CheckValidData(strMessage){
	if(CheckNull(document.forms[0].txtTitle)){
		document.forms[0].txtTitle.focus();
		alert(strMessage);
		return(false);
	} else{	
		Encryptions();
		return true;
	}
}

// ClearForm function
function ClearForm(){		
	parent.Display.document.forms[0].txtTitle.value='';
	parent.Display.document.forms[0].txtHeader.value='';
	parent.Display.document.forms[0].txtContent.value='';
	parent.Display.document.forms[0].txtFooter.value='';
	return true;
}


// CheckFPermission function
function CheckPermission(){
	if (document.forms[0].txtTemplate.value == 0) 
	{
		document.forms[0].btnUpdate.disabled = false;
	/*
		if (document.forms[0].hidAddRight.value == 0)
		{
			document.forms[0].btnUpdate.disabled = false;
		}
		else
		{
			document.forms[0].btnUpdate.disabled = true;
		}
	*/
	}
	else
	{
		if (document.forms[0].hidUpdateRight.value == 0)
		{
			document.forms[0].btnUpdate.disabled=true;
		}
		else
		{
			document.forms[0].btnUpdate.disabled = false;
		}
	}
}