/**************************************************************************
************************ Patron Card Js file *****************************
**************************************************************************/
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
// EncryptionTags replace < or > by &lt; or &gt;
function EncryptionTags(obj){
	eval(obj).value=replaceSubstring(eval(obj).value,'<','&lt;');	
	eval(obj).value=replaceSubstring(eval(obj).value,'<','&gt;');	
	return false;
}
//Decryption tags from "<" to "gl;" so on...
function DecryptionTags(obj){
	eval(obj).value=replaceSubstring(eval(obj).value,'&lt;','<');	
	eval(obj).value=replaceSubstring(eval(obj).value,'&gt;','>');	
	return false;
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
function SetFocusIt(control){
	control.focus();
}
function CheckOut(strContent){
	return true;
}
function replace(string,text,by) {
 //Replaces text with by in string
    var strLength = string.length, txtLength = text.length;
    if ((strLength == 0) || (txtLength == 0)) return string;

    var i = string.indexOf(text);
    if ((!i)&&(text != string.substring(0,txtLength))) return string;
    if (i == -1) return string;
 
    var newstr = string.substring(0,i) + by;

    if (i+txtLength < strLength)
        newstr += replace(string.substring(i+txtLength,strLength),text,by);
        string=newstr;
    return newstr;
}
function PreviewCard(){
PreviewTemplateWin = window.open('','PreviewTemplateWin','height=350,width=480,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=40,left=60');		
	document.forms[0].method='post';
	document.forms[0].action='WCardTemplatePreview.aspx';
	document.forms[0].target='PreviewTemplateWin';
	document.forms[0].submit();			
	document.forms[0].action='WCardTemplate.aspx';
	document.forms[0].target= self.name;
	PreviewTemplateWin.focus();
}
function LoadTemplate() {
	if (document.forms[0].ddlTemplate.selectedIndex==0) {
		document.forms[0].txtTitle.value="";
		document.forms[0].txtContent.value = "";
		var oEditor = FCKeditorAPI.GetInstance('fckContent');
		oEditor.SetHTML('');
		document.forms[0].ddlInf.selectedIndex=0;
		return false;
	}
	parent.hiddenbase.location.href='WCardTemplateHiddenbase.aspx?TemplateID=' + document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.selectedIndex].value; 
	return false;
}

function InsertPatronContent() {
    var oEditor = FCKeditorAPI.GetInstance('fckContent');
    var sample = document.getElementById("ddlInf").value;
    oEditor.InsertHtml(sample);

}

function setPatronContent(val) 
{
    var oEditor = FCKeditorAPI.GetInstance('fckContent');
    oEditor.SetHTML(val);
}
function resetEditor() {
    var oEditor = FCKeditorAPI.GetInstance('fckContent');
    oEditor.SetHTML('');
}