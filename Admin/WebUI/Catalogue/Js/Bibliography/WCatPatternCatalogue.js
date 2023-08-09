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
//creteddate: 19/4/2004
//creator: sondp
//purpose: created Catalogue Pattern
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
//Load back data to WCatPatternCalalogueDisplay.aspx
function UpLoadData(strTitle,strHeader,strContent,strFooter){		
	parent.Display.document.forms[0].txtTitle.value=replace(strTitle,'<!--`-->','\'');
	parent.Display.document.forms[0].txtHeader.value=replace(strHeader,'<!--`-->','\'');
	parent.Display.document.forms[0].txtContent.value=replace(strContent,'<!--`-->','\'');
	parent.Display.document.forms[0].txtFooter.value=replace(strFooter,'<!--`-->','\'');
	parent.Display.document.forms[0].hidTemplateName.value=parent.Display.document.forms[0].txtTitle.value
	return true;
}

//ClearForm function
function ClearForm(){		
	parent.Display.document.forms[0].txtTitle.value='';
	parent.Display.document.forms[0].txtHeader.value='';
	parent.Display.document.forms[0].txtContent.value='';
	parent.Display.document.forms[0].txtFooter.value='';
	return true;
}

//Preview Catalogue Templage
function PreviewIt(){
	PreviewTemplateWin = window.open('','PreviewTemplateWin','height=400,width=630,resizable,menubar=yes,scrollbars=yes,screenX=60,screenY=40,top=40,left=60');		
	document.forms[0].action='WCatPatternPreview.aspx';
	document.forms[0].target='PreviewTemplateWin';
	document.forms[0].submit();			
	document.forms[0].action='WCatPatternDisplay.aspx';
	document.forms[0].target= self.name;
	PreviewTemplateWin.focus();
	return false;
}
function Message(strMessage){
	if(confirm(strMessage)==false){//khong xoa thi lam sach cac control		
		return false;					
	}
	else{
		Encryptions();
		return true;//tra lai gia tri true de nut delete duoc thuc hien
	}
}
//active status bar
//set message:
msg = "Welcome to Emiclib";

timeID = 10;
stcnt = 16;
wmsg = new Array(33);
        wmsg[0]=msg;
        blnk = "                                                               ";
        for (i=1; i<32; i++)
        {
                b = blnk.substring(0,i);
                wmsg[i]="";
                for (j=0; j<msg.length; j++) wmsg[i]=wmsg[i]+msg.charAt(j)+b;
        }

function wiper()
{
        if (stcnt > -1) str = wmsg[stcnt]; else str = wmsg[0];
        if (stcnt-- < -40) stcnt=31;
        status = str;
        clearTimeout(timeID);
        timeID = setTimeout("wiper()",100);
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
	}
	else{	
	return true;
	}
}

// CheckPermission function
function CheckPermission()
{
	if (document.forms[0].hidTemplate.value == 0) 
	{
		if (document.forms[0].hidAddRight.value == 0)
		{
			document.forms[0].btnAddField.disabled = true;
		}
		else	
		{
			document.forms[0].btnAddField.disabled = false;
		}
	}
	else
	{
		if (document.forms[0].hidUpdateRight.value == 0)
		{
			document.forms[0].btnAddField.disabled=true;
		}
		else
		{
			document.forms[0].btnAddField.disabled = false;
		}
	}	
}
